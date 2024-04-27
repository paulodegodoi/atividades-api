using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Atividades.Domain.Enums;

namespace Atividades.Domain.Models
{
	public class Atividade
	{
		[JsonPropertyName("atividadeId")]
		public int AtividadeId { get; set; }
		[DisplayName("Título")]
		[Required(ErrorMessage = "O campo título é obrigatório.")]
		[JsonPropertyName("name")]
		public string Name { get; set; } = string.Empty;
		[JsonPropertyName("status")]
		public EAtividade.EStatus Status { get; set; }
		[JsonPropertyName("prioridade")]
		public EAtividade.EPrioridade Prioridade { get; set; }
	}
}

