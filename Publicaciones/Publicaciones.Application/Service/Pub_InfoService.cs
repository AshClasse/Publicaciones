﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Application.Exceptions;
using Publicaciones.Application.Response;
using Publicaciones.Application.Validations;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
	public class Pub_InfoService : IPub_InfoService
	{
		private readonly IPub_InfoRepository _pub_info_repository;
		private readonly ILogger<Pub_InfoService> _logger;
		private readonly IConfiguration configuration;

		public Pub_InfoService(IPub_InfoRepository pub_InfoRepository, 
								ILogger<Pub_InfoService> logger,
								IConfiguration configuration)
		{
			this._pub_info_repository = pub_InfoRepository;
			this._logger = logger;
			this.configuration = configuration;
		}
		public ServiceResult GetAll()
		{
			ServiceResult result = new ServiceResult();
			try
			{
				result.Data = this._pub_info_repository.GetPublishersInfos();
				result.Message = $"{configuration["PubInfoSuccessMessage:getAllSuccessMessage"]}";
			}
			catch (Pub_InfoServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["Pub_InfoErrorMessage:getAllErrorMessage"]}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult GetByID(int id)
		{
			ServiceResult result = new ServiceResult();
			try
			{
				result.Data = this._pub_info_repository.GetPub_InfosByPublisherID(id);
				result.Message = $"{configuration["PubInfoSuccessMessage:getByIdSuccessMessage"]}";
			}
			catch (Pub_InfoServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["Pub_InfoErrorMessage:getByIdErrorMessage"]}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Save(Pub_InfoDtoAdd dtoAdd)
		{
			Pub_InfoResponse result = new Pub_InfoResponse();

			try
			{
				
				Pub_Info pub_Info = new Pub_Info()
				{
					CreationDate = dtoAdd.ChangeDate,
					IDCreationUser = dtoAdd.ChangeUser,
					PubID = dtoAdd.PubId,
					Logo = dtoAdd.Logo,
					Pr_Info = dtoAdd.Pr_Info
				};

				this._pub_info_repository.Save(pub_Info);
				result.Message = "PubInfo guardado exitosamente";
				result.PubInfo_Id = pub_Info.PubInfoID;

			}
			catch (Pub_InfoServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error guardando la información de publicación: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Update(Pub_InfoDtoUpdate dtoUpdate)
		{
			ServiceResult result = new ServiceResult();

			try
			{

				Pub_Info pub_Info = new Pub_Info()
				{
					ModifiedDate = dtoUpdate.ChangeDate,
					IDModifiedUser = dtoUpdate.ChangeUser,
					PubInfoID = dtoUpdate.PubInfoID,
					PubID = dtoUpdate.PubId,
					Logo = dtoUpdate.Logo,
					Pr_Info = dtoUpdate.Pr_Info
				};

				this._pub_info_repository.Update(pub_Info);
				result.Message = "PubInfo actualizado exitosamente";
			}
			catch (Pub_InfoServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error actualizando la información de publicación: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}
		
		public ServiceResult Remove(Pub_InfoDtoRemove dtoRemove)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				Pub_Info pub_Info = new Pub_Info()
				{
					PubInfoID = dtoRemove.Id,
					Deleted = dtoRemove.Deleted,
					DeletedDate = dtoRemove.ChangeDate,
					IDDeletedUser = dtoRemove.ChangeUser
				};

				this._pub_info_repository.Remove(pub_Info);
				result.Message = "PubInfo borrado exitosamente";
			}
			catch (Pub_InfoServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error borrando la información de publicación: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		ServiceResult IPub_InfoService.ExistsInPublishers(int pubId)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var exists = this._pub_info_repository.ExistsInPublishers(pubId);
				result.Data = exists;

				if (!exists)
				{
					result.Success = false;
					result.Message = $"{configuration["ValidationMessage:pubIdExists"]}";
				}

			}
			catch (Exception ex)
			{
				result.Success = false;
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		ServiceResult IPub_InfoService.GetPub_InfosByPublisherID(int pubId)
		{
			ServiceResult result = new ServiceResult();
			try
			{
				result.Data = this._pub_info_repository.GetPub_InfosByPublisherID(pubId);
				result.Message = "PubInfos obtenidos exitosamente";
			}
			catch (Pub_InfoServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"The following error occurred while getting publish information: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

	}
}
