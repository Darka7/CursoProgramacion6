﻿using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IVehiculoService
    {
        Task<DBEntity> Create(VehiculoEntity entity);
        Task<DBEntity> Delete(VehiculoEntity entity);
        Task<IEnumerable<VehiculoEntity>> Get();
        Task<VehiculoEntity> GetById(VehiculoEntity entity);
        Task<DBEntity> Update(VehiculoEntity entity);

        Task<IEnumerable<VehiculoEntity>> GetLista();
    }

    public class VehiculoService : IVehiculoService
    {
        private readonly IDataAccess sql;

        public VehiculoService(IDataAccess _sql)
        {
            sql = _sql;
        }


        public async Task<IEnumerable<VehiculoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<VehiculoEntity, MarcaVehiculoEntity>("VehiculoObtener", "VehiculoId,MarcaVehiculoId");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<VehiculoEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<VehiculoEntity>("VehiculoLista");

                return await result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }


        public async Task<VehiculoEntity> GetById(VehiculoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<VehiculoEntity>("VehiculoObtener", new
                {
                    entity.VehiculoId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DBEntity> Create(VehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("VehiculoInsertar", new
                {
                    entity.Matricula,
                    entity.Color,
                    entity.Modelo,
                    entity.FechaModelo,
                    entity.Estado,
                    entity.MarcaVehiculoId,
                    entity.TieneDefectos,
                    Defectos = entity.TieneDefectos ? entity.Defectos:null
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Update(VehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("VehiculoActualizar", new
                {
                    entity.VehiculoId,
                    entity.Matricula,
                    entity.Color,
                    entity.Modelo,
                    entity.FechaModelo,
                    entity.Estado,
                    entity.MarcaVehiculoId,
                    entity.TieneDefectos,
                    Defectos = entity.TieneDefectos ? entity.Defectos : null
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Delete(VehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("VehiculoEliminar", new
                {
                    VehiculoId = entity.VehiculoId,
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
