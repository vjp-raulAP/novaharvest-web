1. De .cshtml a HTML. Explica qué le pasa a Surplus.cshtml desde que haces dotnet
build hasta que el navegador recibe el HTML. Compila con dotnet build
-p:EmitCompilerGeneratedFiles=true, busca la clase generada para Status.cshtml y
copia un WriteLiteral y un Write: ¿de qué parte de tu .cshtml sale cada uno? ¿Por qué
no hay ningún .cshtml dentro del contenedor? ¿En qué ensamblado acaban las páginas, y en cuál acababan antes de .NET 6?
2. Tecnologías. Escribe la línea Precio de excedente: ... de tu página como se
escribiría en PHP y en ASP clásico, y compárala con la tuya en Razor: ¿cómo marca cada
una dónde empieza y dónde acaba el código? ¿Qué has ganado al pasar de los MapGet de
UT2 a Razor Pages? Compara tu Program.cs de antes y de ahora. Añade también esa línea escrita en ERB (Ruby on Rails).
3. Etiquetas de código. Copia de tu proyecto un ejemplo de cada: expresión implícita,
expresión explícita, bloque @{ }, @@ y comentario @* *@, junto con el HTML que genera
cada uno (código fuente de la página). ¿Por qué info@novaharvest.es no necesita @@ y
@novaharvest sí?
4. Sintaxis. Haz estos dos cambios en Surplus.cshtml (y deshazlos después): escribe
@Model.SurplusPrize en lugar de @Model.SurplusPrice, y escribe
@Model.Surplus.PricePerKg * 0.7m en alguna línea. Copia lo que ocurre en cada caso
(el error de dotnet build o el HTML generado). ¿Por qué el primero no compila y el
segundo sí, aunque el resultado esté mal? ¿Cómo se corrige el segundo?
5. Efectos en el documento. Compara cómo se ve la nota del productor en pantalla y en el
código fuente de /surplus. ¿Qué ha hecho Razor y por qué? ¿Qué podría pasar si usaras
@Html.Raw y la nota la escribiera un usuario malintencionado? Copia el elemento de los
días y el botón en los escenarios A, C y D, y explica por qué a veces el atributo class o
disabled no aparece. Para