﻿using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Repo
{
    public class PatientRepository : IPatientRepo
    {
        private readonly DataContext _context;

        public PatientRepository(DataContext context)
        {
            _context = context;
        }

        public void AddNewPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            _context.PatientsInfo.Add(patient);
        }

        public IEnumerable<Patient> GetDetailsOfAllPatients()
        {
            var _patients = _context.PatientsInfo.ToList();

            return _patients;
        }

        public Patient GetPatientById(string id)
        {
            return _context.PatientsInfo.Find(id);
        }

        public void RemovePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            _context.PatientsInfo.Remove(patient);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //To save changes into the database
        }

        public void UpdatePatient(Patient patient)
        {
            //Nothing to do here
        }
    }
}