using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leodanny_maria_mercedes_P1_AP1.DAL;
using Leodanny_maria_mercedes_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Leodanny_maria_mercedes_P1_AP1.Services
{
    public class ServicesReportes(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(reportes reporte)
        {
            if (!await Existe(reporte.ReporteId))
                return await Insertar(reporte);
            else
                return await Modificar(reporte);
        }

        public async Task<bool> Existe(int reporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Reportes.AnyAsync(a => a.ReporteId == reporteId);
        }

        public async Task<bool> Insertar(reportes reporte) // Cambiado a "Reportes"
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Reportes.Add(reporte);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int reporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var eliminarArticulo = await contexto.Reportes
                .Where(a => a.ReporteId == reporteId)
                .ExecuteDeleteAsync();
            return eliminarArticulo > 0;
        }

        public async Task<bool> Modificar(reportes reporte) // Cambiado a "Reportes"
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(reporte);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<reportes?> Buscar(int reporteId) // Cambiado a "Reportes"
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Reportes
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ReporteId == reporteId);
        }

        public async Task<List<reportes>> Listar(Expression<Func<reportes, bool>> criterio) // Cambiado a "Reportes"
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Reportes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}