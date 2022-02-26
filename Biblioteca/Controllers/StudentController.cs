﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.Controllers
{
    public class StudentController : Controller 
    {
        public async Task<IActionResult> Index()
        {
            List<Student> students = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5001/api/student"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
            return View(students);            
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Student student = new Student();
            if (id == null) return NotFound();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5001/api/student/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            if(student == null) return NotFound();
            return View(student);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id,Student student)
        {
            var jsonStudent = JsonConvert.SerializeObject(student);            
            var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync("http://localhost:5001/api/student/" + id, content))
                {                  
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }                   
                }
            }
            return View(student);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Student student = new Student();
            if (id == null) return NotFound();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5001/api/student/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        student = JsonConvert.DeserializeObject<Student>(apiResponse);
                    }
                    
                
                }
            }
            if (student == null) return NotFound();
            return View(student);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5001/api/student/" + id))
                {
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                }
            }
            return View("Index");

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name")] Student student)
        {
            var jsonStudent = JsonConvert.SerializeObject(student);
            var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync("http://localhost:5001/api/student", content))
                {                    
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(student);

        }
    }



}
