using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;

namespace FormContato2.Models
{
    [Table("formulario_contatos")]
    public class FormularioModel
    {
        [Key]
        public int FormularioId { get; set; }

        [Required]
        [DisplayName("Empresa")]
        public string Empresa { get; set; }
        
        [Required]
        [DisplayName("Nome")]
        [StringLength(50, MinimumLength = 5)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone deve ser informado.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Forneça o número do telefone no formato (000) 000-0000")]
        [DisplayName("Número do Telefone")]
        public string Telefone { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Informe seu endereço de e-mail")]
        [RegularExpression(@"^[a-z0-9._\-]+@[a-z0-9]+(\.)[a-z]+(\.[a-z]+)?$", ErrorMessage="O endereço de e-mail não é válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public void Create()
        {
            try
            {
                this.DataCadastro = DateTime.Now;

                using (var context = new Contexto.Contexto())
                {
                    context.Formulario.Add(this);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                String Error = String.Empty;
                foreach (var eve in e.EntityValidationErrors)
                {
                    Error += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    Console.WriteLine(Error);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Error += String.Format("- Propriedade: \"{0}\", Erro: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                        Console.WriteLine("- Propriedade: \"{0}\", Erro: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(Error);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}