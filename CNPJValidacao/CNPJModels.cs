using System;
using System.Collections.Generic;
using YourNamespace;

namespace CNPJValidacao
{
    public class Atividade
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }

    public class QSA
    {
        public string Nome { get; set; }
        public string Qual { get; set; }
        public string NomeRepLegal { get; set; }
        public string QualRepLegal { get; set; }
    }

    public class Billing
    {
        public bool Free { get; set; }
        public bool Database { get; set; }
    }

    public class AtividadePrincipal
    {
        public string Id { get; set; }
        public string Secao { get; set; }
        public string Divisao { get; set; }
        public string Grupo { get; set; }
        public string Classe { get; set; }
        public string Subclasse { get; set; }
        public string Descricao { get; set; }
    }

    public class Estabelecimento
    {
        public string Cnpj { get; set; }
        public List<Atividade> AtividadesSecundarias { get; set; }
        public string CnpjRaiz { get; set; }
        public string CnpjOrdem { get; set; }
        public string CnpjDigitoVerificador { get; set; }
        public string Tipo { get; set; }
        public string NomeFantasia { get; set; }
        public string SituacaoCadastral { get; set; }
        public string DataSituacaoCadastral { get; set; }
        public string DataInicioAtividade { get; set; }
        public string NomeCidadeExterior { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Ddd1 { get; set; }
        public string Telefone1 { get; set; }
        public string Ddd2 { get; set; }
        public string Telefone2 { get; set; }
        public string DddFax { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string SituacaoEspecial { get; set; }
        public string DataSituacaoEspecial { get; set; }
        public string AtualizadoEm { get; set; }
        public AtividadePrincipal AtividadePrincipal { get; set; }
        public Pais Pais { get; set; }
        public Estado Estado { get; set; }
        public Cidade Cidade { get; set; }
        public List<InscricaoEstadual> InscricoesEstaduais { get; set; }
    }

    public class Pais
    {
        public string Id { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string Nome { get; set; }
        public string ComexId { get; set; }
    }

    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int IbgeId { get; set; }
    }

    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IbgeId { get; set; }
        public string SiafiId { get; set; }
    }

    public class InscricaoEstadual
    {
        public string NumeroInscricao { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime AtualizacaoData { get; set; }
        public Estado Estado { get; set; }
    }

    public class CNPJModels
    {
        public string CnpjRaiz { get; set; }
        public string RazaoSocial { get; set; }
        public string CapitalSocial { get; set; }
        public string ResponsavelFederativo { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public Porte Porte { get; set; }
        public NaturezaJuridica NaturezaJuridica { get; set; }
        public QualificacaoResponsavel QualificacaoResponsavel { get; set; }
        public List<QSA> Socios { get; set; }
        public object Simples { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
    }

    public class Porte
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
    }

    public class NaturezaJuridica
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
    }

    public class QualificacaoResponsavel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
