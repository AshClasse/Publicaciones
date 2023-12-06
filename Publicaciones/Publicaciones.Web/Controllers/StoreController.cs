﻿using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Store;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Store;
using Publicaciones.Web.Service;

namespace Publicaciones.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;
        private readonly string storeApiURLBase;
        private readonly IWebService webService;

        public StoreController(IStoreService storeService, IWebService webService, IConfiguration configuration)
        {
            this.storeService = storeService;
            this.webService = webService;
            this.storeApiURLBase = configuration["ApiSettings:StoreApiBaseUrl"];
        }
        public ActionResult Index()
        {
            try
            {
                BaseResponse<List<StoreViewResult>> responseData = webService.GetDataFromApi<List<StoreViewResult>>($"{storeApiURLBase}GetStores");
                return View(responseData.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                BaseResponse<StoreViewResult> responseData = webService.GetDataFromApi<StoreViewResult>($"{storeApiURLBase}GetStoreByID?storeID={id}");
                return View(responseData.data);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreDtoAdd storeDtoAdd)
        {
            var apiUrl = $"{storeApiURLBase}SaveStore";

            storeDtoAdd.ChangeDate = DateTime.Now;
            storeDtoAdd.ChangeUser = 1;

            try
            {
                webService.PostDataToApi<BaseResponse<StoreDtoAdd>>(apiUrl, storeDtoAdd);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                BaseResponse<StoreViewResult> responseData = webService.GetDataFromApi<StoreViewResult>($"{storeApiURLBase}GetStoreByID?storeID={id}");
                return View(responseData.data);
            }
            catch( Exception ex )
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoreDtoUpdate storeDtoUpdate)
        {
            var apiUrl = $"{storeApiURLBase}UpdateStore";

            storeDtoUpdate.ChangeDate = DateTime.Now;
            storeDtoUpdate.ChangeUser = 1;

            try
            {
                webService.PostDataToApi<BaseResponse<StoreDtoUpdate>>(apiUrl, storeDtoUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                BaseResponse<StoreDtoRemove> responseData = webService.GetDataFromApi<StoreDtoRemove>($"{storeApiURLBase}GetStoreByID?storeID={id}");
                return View(responseData.data);
            }
            catch ( Exception ex )
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(StoreDtoRemove storeDtoRemove)
        {
            var apiUrl = $"{storeApiURLBase}RemoveStore";

            storeDtoRemove.ChangeDate = DateTime.Now;
            storeDtoRemove.ChangeUser = 1;

            try
            {
                var response = webService.PostDataToApi<BaseResponse<StoreDtoRemove>>(apiUrl, storeDtoRemove);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}