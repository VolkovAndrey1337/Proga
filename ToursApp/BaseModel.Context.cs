﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToursApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PoliclinicaPractikaEntities : DbContext
    {
        private static PoliclinicaPractikaEntities _context;
        public PoliclinicaPractikaEntities()
            : base("name=PoliclinicaPractikaEntities")
        {
        }
    
        public static PoliclinicaPractikaEntities GetContext()
        {
            if (_context == null)
                _context = new PoliclinicaPractikaEntities();
            
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Diagnosis> Diagnosis { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
