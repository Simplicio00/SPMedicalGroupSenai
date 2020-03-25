use SPMedicalGroup_Senai_Manha;

go

select * from INFORMATION_SCHEMA.TABLES

go

select * from SPMedicalGroup_Senai_Manha.dbo.Usuario

go


select Medico.NomeMedico, Paciente.NomePaciente, Consulta.TituloConsulta, Consulta.SituacaoConsulta, Consulta.DataConsulta from Consulta
inner join Medico on Medico.IdMedico = Consulta.IdMedico
inner join Paciente on Paciente.IdPaciente = Consulta.IdPaciente
order by Consulta.DataConsulta desc;


go


select COUNT(Usuario.IdUsuario) as TotaldeUsuarios from Usuario

go





create procedure Quantidade 
@contagem int 
as
select Medico.NomeMedico from Medico
inner join Especialidade on Especialidade.IdEspecialidade = Medico.IdEspecialidade
where Especialidade.IdEspecialidade = @contagem;

go

execute Quantidade 17;








go

create procedure UserIdade
@usuario varchar(250)
as
select Usuario.Idade, Medico.NomeMedico from Medico
inner join Usuario on Usuario.IdUsuario = Medico.IdUsuario
where Medico.NomeMedico = @usuario;
select Usuario.Idade, Paciente.NomePaciente from Paciente
inner join Usuario on Usuario.IdUsuario = Paciente.IdUsuario
where Paciente.NomePaciente = @usuario;


execute UserIdade 'Roberto Possarle';

select * from Medico

select Especialidade.NomeEspecialidade, Medico.NomeMedico from Medico 
inner join Especialidade on Especialidade.IdEspecialidade = Medico.IdEspecialidade
where NomeEspecialidade like '%P%'


select Email, Adm from Usuario 

