create procedure insertarArchivo
(
@id int = '',
@nombre varchar(50) = '',
@extension varchar(5) = '',
@tamanio float = '',
@ubicacion text = ''
)
as 
begin
insert into FILEX(nombre,extension,tamanio,ubicacion)
values(@nombre, @extension, @tamanio, @ubicacion);

end;
