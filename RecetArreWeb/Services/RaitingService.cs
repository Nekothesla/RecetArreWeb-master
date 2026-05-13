using System.Net.Http.Json;
using RecetArreWeb.DTOs;

namespace RecetArreWeb.Services
{
    public interface IRaitingService
    {
        Task<List<RaitingDto>> ObtenerPorReceta(int recetaId);
        Task<RaitingResumenDto?> ObtenerResumenPorReceta(int recetaId);
        Task<RaitingDto?> ObtenerMiRaiting(int recetaId);
        Task<RaitingDto?> Crear(RaitingCreacionDto dto);
        Task<bool> Actualizar(int id, RaitingModificacionDto dto);
        Task<bool> Eliminar(int id);
    }

    public class RaitingService : IRaitingService
    {
        private readonly HttpClient httpClient;
        // La API real se llama raiting según el backend
        private const string endpoint = "api/raiting";

        public RaitingService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<RaitingDto>> ObtenerPorReceta(int recetaId)
        {
            try
            {
                var raitings = await httpClient.GetFromJsonAsync<List<RaitingDto>>($"{endpoint}/receta/{recetaId}");
                return raitings ?? new List<RaitingDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener valoraciones: {ex.Message}");
                return new List<RaitingDto>();
            }
        }

        public async Task<RaitingResumenDto?> ObtenerResumenPorReceta(int recetaId)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<RaitingResumenDto>($"{endpoint}/receta/{recetaId}/resumen");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener resumen de valoraciones: {ex.Message}");
                return null;
            }
        }

        public async Task<RaitingDto?> ObtenerMiRaiting(int recetaId)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<RaitingDto>($"{endpoint}/mio/{recetaId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener mi valoración (o no existe): {ex.Message}");
                return null;
            }
        }

        public async Task<RaitingDto?> Crear(RaitingCreacionDto dto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync(endpoint, dto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RaitingDto>();
                }

                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al crear valoración: {error}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear valoración: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Actualizar(int id, RaitingModificacionDto dto)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync($"{endpoint}/{id}", dto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar valoración {id}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{endpoint}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar valoración {id}: {ex.Message}");
                return false;
            }
        }
    }
}
