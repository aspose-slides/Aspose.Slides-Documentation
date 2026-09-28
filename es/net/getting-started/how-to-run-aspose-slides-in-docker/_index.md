---
title: Ejecutar Aspose.Slides para .NET en Docker
linktitle: Docker
type: docs
weight: 140
url: /es/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- contenedor Docker
- compilación multi-etapa
- imagen de contenedor
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- fuentes
- conversión a PDF
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Compila y ejecuta una aplicación de consola Aspose.Slides para .NET en Docker: un Dockerfile multi-etapa basado en las imágenes oficiales de .NET, las librerías y fuentes de Linux que necesita, y cómo copiar los archivos generados a tu máquina."
---
## **Descripción general**

Este artículo muestra cómo ejecutar Aspose.Slides for .NET en un contenedor Docker. Construye una pequeña aplicación de consola que crea una presentación con un cuadro de texto y la convierte a PDF, la empaqueta con un Dockerfile de varias etapas basado en las imágenes oficiales de .NET de Microsoft, la ejecuta y copia los archivos generados a tu máquina. El artículo también enumera las librerías y fuentes de Linux que Aspose.Slides necesita en el contenedor y finaliza con una variante para Alpine Linux.

Solo necesitas Docker en tu máquina. El SDK de .NET forma parte de la imagen de compilación, por lo que no es necesario instalarlo. Para instalar Docker, consulta [Obtener Docker](https://docs.docker.com/get-started/get-docker/).

## **Seleccionar el paquete y la imagen base**

Las imágenes de contenedor predeterminadas de .NET 10 se basan en Ubuntu 24.04. En estas imágenes, usa el paquete [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Requiere la librería `fontconfig`, y la imagen de tiempo de ejecución de .NET no contiene ni esa librería ni fuentes, por lo que el Dockerfile de este artículo instala ambos.

Aspose.Slides.NET6.CrossPlatform no funciona en Alpine Linux. Para imágenes basadas en Alpine, usa el paquete [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) con `libgdiplus`, como se describe en [Ejecutar en Alpine Linux](#run-on-alpine-linux). [Instalación](/slides/es/net/installation/) compara los dos paquetes.

## **Crear el proyecto**

Crea una carpeta llamada *HelloSlidesDocker* y añade los tres archivos siguientes.

*HelloSlidesDocker.csproj* describe una aplicación de consola para .NET 10, la versión de las imágenes de contenedor usadas a continuación, y hace referencia a Aspose.Slides.NET6.CrossPlatform. Establece la versión del paquete a la más reciente que figura en [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* crea una [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/), añade un rectángulo con texto a su primera diapositiva y guarda la presentación dos veces con el método [Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/): como PPTX y como PDF. Ambos archivos se almacenan en la carpeta *output* bajo el directorio de trabajo. La aplicación luego enumera las fuentes que fueron sustituidas mientras se renderizaba el PDF, usando [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getsubstitutions/), para que puedas ver si el contenedor tiene las fuentes que la presentación utiliza.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* mantiene fuera del contexto de compilación de Docker las carpetas *bin* y *obj* de una compilación local, y la salida de ejecuciones anteriores, de modo que la imagen se construye sólo a partir de los archivos fuente.

```text
bin/
obj/
output/
```

## **Escribir el Dockerfile**

Añade un archivo llamado *Dockerfile* a la misma carpeta:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

El archivo tiene dos etapas:

- **La etapa de compilación** parte de la imagen del SDK de .NET. Copia primero el archivo del proyecto y restaura los paquetes NuGet, de modo que Docker reutiliza esa capa mientras el archivo del proyecto no cambie. Luego copia el código fuente y publica la aplicación en */app*.
- **La etapa de tiempo de ejecución** parte de la imagen de tiempo de ejecución de .NET, que es más pequeña y no incluye el SDK, y copia sólo la aplicación publicada. Instala dos paquetes:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform carga esta librería al iniciarse. Sin ella, la aplicación se detiene con una `DllNotFoundException` que menciona `libfontconfig.so.1`.
  - `fonts-dejavu-core`: la imagen de tiempo de ejecución no contiene fuentes, y Aspose.Slides necesita al menos una fuente instalada para dibujar texto; sin ninguna, la conversión se detiene con `InvalidOperationException: Cannot find any fonts installed on the system.` El texto con fuentes no instaladas se dibuja con una fuente sustituta. Las fuentes DejaVu son un conjunto pequeño que permite que el texto se represente; para renderizar presentaciones con las fuentes con las que fueron diseñadas, consulta [Desplegar fuentes](/slides/es/net/deploy-fonts/).

  `--no-install-recommends` y la eliminación de las listas de paquetes mantienen la imagen pequeña. Las últimas líneas crean la carpeta *output*, la asignan al usuario no root `app` que definen las imágenes oficiales de .NET (su ID de usuario está en la variable `APP_UID`), y ejecutan la aplicación con ese usuario.

Para una aplicación ASP.NET Core, inicia la etapa de tiempo de ejecución desde `mcr.microsoft.com/dotnet/aspnet:10.0` en su lugar. Está basada en la misma imagen de Ubuntu, por lo que se requieren los mismos paquetes.

## **Compilar y ejecutar el contenedor**

Abre una terminal en la carpeta *HelloSlidesDocker*. Compila la imagen y luego ejecuta un contenedor a partir de ella:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

La primera compilación descarga las imágenes base y los paquetes NuGet, por lo que tarda más que compilaciones posteriores. El contenedor ejecuta la aplicación y se detiene. Imprime:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

La primera línea muestra que el texto usa Calibri, la fuente predeterminada de una presentación nueva, y que Calibri no está instalada en la imagen, por lo que Aspose.Slides dibujó el texto con DejaVu Sans. El texto del PDF es texto real, seleccionable, con esa fuente. Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación a cada diapositiva que guarda; consulta [Licencias](/slides/es/net/licensing/).

## **Copiar la salida a su máquina**

Los archivos están en la carpeta */app/output* del contenedor detenido. Cópialos a una carpeta *output* en tu máquina y, a continuación, elimina el contenedor:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Estos dos comandos funcionan de la misma forma en Bash, PowerShell y el símbolo del sistema de Windows.

En Linux, puedes montar una carpeta de tu máquina dentro del contenedor, de modo que la aplicación escriba sus archivos allí directamente:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

La opción `--user` ejecuta la aplicación con tus IDs de usuario y grupo, por lo que puede escribir en la carpeta que creaste y los archivos le pertenecen. `--rm` elimina el contenedor cuando se detiene.

## **Ejecutar en Alpine Linux**

Para ejecutar la aplicación en una imagen basada en Alpine, cambia al paquete Aspose.Slides.NET y modifica la etapa de tiempo de ejecución. La etapa de compilación permanece igual.

1. En *HelloSlidesDocker.csproj*, reemplaza la referencia al paquete:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. En *Program.cs*, añade esta instrucción después de las directivas `using`, antes de la primera llamada a Aspose.Slides. Habilita la compatibilidad de System.Drawing para Linux que utiliza Aspose.Slides.NET:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. En *Dockerfile*, reemplaza la etapa de tiempo de ejecución (todo lo que sigue a la segunda línea `FROM`) con:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

La etapa de Alpine instala tres paquetes y cambia una configuración:

- `libgdiplus` es la biblioteca gráfica que Aspose.Slides.NET usa en Linux.
- `font-dejavu` aporta fuentes. Sin ninguna fuente, la conversión se detiene con `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` y `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` proporcionan datos de cultura. Las imágenes .NET para Alpine se ejecutan, por defecto, en modo globalización invariante, y en ese modo Aspose.Slides se detiene con una `CultureNotFoundException` para `en-US`.

Compila, ejecuta y copia la salida con los mismos comandos que antes. En esta imagen, la aplicación solo imprime la línea `Saved`: con Aspose.Slides.NET en Linux, fontconfig elige el sustituto para una fuente faltante, y [GetSubstitutions](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getsubstitutions/) no la enumera. [Desplegar fuentes](/slides/es/net/deploy-fonts/) muestra cómo comprobar qué fuente se está usando.

## **Preguntas frecuentes**

**La aplicación se detiene con “Unable to load shared library 'libaspose.slides.drawing.capi…'”. ¿Qué falta?**

En imágenes de Ubuntu y Debian, el paquete `libfontconfig1`; el mensaje indica `libfontconfig.so.1` como el archivo que no se pudo abrir. En Alpine Linux, el mensaje significa que se está usando Aspose.Slides.NET6.CrossPlatform; cambia a Aspose.Slides.NET como se describe en [Ejecutar en Alpine Linux](#run-on-alpine-linux).

**¿Por qué el texto del PDF tiene una fuente diferente a la de PowerPoint?**

Las fuentes que utiliza la presentación no están instaladas en la imagen, por lo que Aspose.Slides dibuja el texto con una fuente sustituta. La salida de la aplicación indica cada fuente reemplazada. [Desplegar fuentes](/slides/es/net/deploy-fonts/) explica cómo instalar fuentes en la imagen o cargarlas desde la carpeta de la aplicación.

**¿Necesito el SDK de .NET en mi máquina?**

No. La etapa de compilación genera la aplicación dentro de la imagen del SDK. Solo necesitas el SDK si deseas compilar y ejecutar la aplicación fuera de Docker; consulta [Instalación](/slides/es/net/installation/).