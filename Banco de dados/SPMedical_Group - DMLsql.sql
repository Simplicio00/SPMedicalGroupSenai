use SPMedicalGroup_Senai_Manha

go

insert into Empresa(NomeEmpresa,CNPJ,EnderecoEmpresa)
values('SP Medical Group - Clínica Possarle','86.400.902/0001-30','Av. Barão Limeira, 532, São Paulo, SP')

go

insert into TipoUsuario(Titulo)values('Administrador'),('Comum')


go
insert into Usuario(IdEmpresa,IdTipoUsuario,Email,Senha)values(1,2,'RobertoPossarle@email.com','rob123'),
(1,2,'RicardoLemos@email.com','ric123'),(1,2,'HelenaStrada@email.com','ele123'),(1,2,'ligia@email.com','lig123'),
(1,2,'Alexandre@email.com','ale123'),(1,2,'Fernando@email.com','fer123'),(1,2,'Henrique@email.com','hen123'),
(1,2,'Joao@email.com','joa123'),(1,2,'Bruno@email.com','bru123'),(1,2,'Mariana@email.com','mar123')


go
insert into Especialidade(NomeEspecialidade)values('Acumpuntura'),('Anestesiologia'),('Angiologia'),
('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia da mão'),
('Cirurgia Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pediátrica'),
('Cirurgia Plástica'),('Cirurgia Toráxica'),('Cirurgia Vascular'),
('Dermatologia'),('Radio Terapia'),('Urologia'),('Pediatria'),('Psiquiatria'),('Outro(a)')

go

insert into Medico(IdEspecialidade,IdUsuario,NomeMedico,CRM)values(17,1,'Roberto Possarle','54321-SP'),(2,2,'Ricardo Lemos','53452-SP'),
(16,3,'Helena Strada','65463-SP')



go

insert into Paciente(IdUsuario,NomePaciente, RG, CPF, Telefone, Endereco)
values(4,'Ligia','43522543-5','94839859000',1134567654,'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
(5,'Alexandre','32654345-7','73556944057',11987656543,'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
(6,'Fernando','54636525-3','16839338002',11972084453,'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
(7,'Henrique','54366362-5','14332654765',1134566543,'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
(8,'João','t32544444-1','91305348010',1176566377,'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
(9,'Bruno','54566266-7','79799299004',11954368769,'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
(10,'Mariana','54566266-8','13771913039',1190907678,'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140')



go

insert into Consulta(IdPaciente,IdMedico,TituloConsulta,SituacaoConsulta,DataConsulta)
values(7,2,'Consulta de rotina','Realizada','20/01/2020 15:00'),
(8,1,'Consulta de rotina','Cancelada','06/01/2020 10:00'),
(9,1,'Consulta de rotina','Realizada','07/02/2020 11:00'),
(10,1,'Consulta de rotina','Realizada','06/02/2018 10:00'),
(11,3,'Consulta de rotina','Cancelada','07/02/2019 10:00'),
(12,2,'Consulta de rotina','Agendada','08/03/2020 10:00'),
(13,3,'Consulta de rotina','Agendada','09/03/2020 10:00');