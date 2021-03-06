create proc [dbo].[StudentAdd]
    @PersonId varchar(50),
	@Name nvarchar(100),
	@Gender nchar(1),
    @IdGroup int,
    @Birthday date,
    @Username varchar(100),
    @PasswordHash varchar(100)
as
	insert into Person (IdPerson, [Name], Gender, IdGroup, Birthday)
                values (@PersonId, @Name, @Gender, @IdGroup, @Birthday)
    insert into [User] (Id, [Username], PasswordHash)
                values (@PersonId, @Username, @PasswordHash)
    insert into UserRoles (UserId, RoleId)
                values (@PersonId, 'S')