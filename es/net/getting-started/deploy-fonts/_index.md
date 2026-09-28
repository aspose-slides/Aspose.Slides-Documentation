---
title: Deploy Fonts for Aspose.Slides on Linux and in Docker
linktitle: Deploy Fonts
type: docs
weight: 145
url: /es/net/deploy-fonts/
keywords:
- desplegar fuentes
- instalar fuentes
- fuentes en Docker
- fuentes en Linux
- fuentes faltantes
- sustitución de fuentes
- fuentes principales de Microsoft
- ttf-mscorefonts-installer
- fuentes personalizadas
- fuente predeterminada
- servidor
- contenedor
- conversión a PDF
- presentación
- .NET
- C#
- Aspose.Slides
description: "Despliegue fuentes para Aspose.Slides para .NET en servidores Linux y contenedores Docker: compruebe qué fuentes se sustituyen, instale paquetes de fuentes en Debian, Ubuntu y Alpine, añada sus propios archivos de fuentes y establezca una fuente predeterminada."
---
## **Visión general**

Aspose.Slides dibuja el texto con las fuentes que tiene disponibles al renderizar una presentación, por ejemplo cuando convierte diapositivas a PDF o a imágenes. Un escritorio Windows suele disponer de las fuentes que utilizan las presentaciones. Los servidores y contenedores Linux normalmente tienen pocas fuentes o ninguna, por lo que Aspose.Slides dibuja el texto con una fuente de sustitución. Una sustitución tiene formas y anchos de letra diferentes, de modo que las líneas pueden ajustarse de forma distinta y el texto puede desbordarse de su forma, y los caracteres que le faltan a la fuente de sustitución no se dibujan correctamente. Si no hay ninguna fuente instalada, la conversión se detiene con un error.

Este artículo muestra cómo comprobar qué fuentes sustituye Aspose.Slides, cómo instalar fuentes en Debian, Ubuntu y Alpine Linux, cómo añadir sus propios archivos de fuentes y cómo establecer la fuente que se utiliza cuando falta una fuente. Los ejemplos se ejecutan en Docker con las imágenes oficiales de .NET, como en [Ejecutar Aspose.Slides para .NET en Docker](/slides/es/net/how-to-run-aspose-slides-in-docker/). Los comandos del paquete son instrucciones de Dockerfile; en un servidor Linux, ejecute los mismos comandos como root.

Para la propia API de fuentes, como incrustar fuentes en una presentación y reglas de reserva y sustitución, consulte [Fuentes de PowerPoint](/slides/es/net/powerpoint-fonts/).

## **Comprobar qué fuentes se sustituyen**

La siguiente aplicación de consola informa de las fuentes que Aspose.Slides sustituye en el entorno actual. Cree una carpeta llamada *FontCheck* y añada los archivos siguientes a ella.

*FontCheck.csproj* hace referencia a [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), el paquete para Debian y Ubuntu. También copia los archivos de una carpeta opcional *fonts* a la salida de la aplicación; la sección [Cargar fuentes desde la carpeta de la aplicación](#load-fonts-from-the-application-folder) la utiliza.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* añade un cuadro de texto por cada nombre de fuente a una diapositiva y asigna la fuente mediante la propiedad [LatinFont](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/latinfont/). Los nombres de fuente provienen de la línea de comandos; sin argumentos, la aplicación comprueba Calibri, Arial y Times New Roman. Imprime las carpetas donde Aspose.Slides busca fuentes ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/getfontfolders/)), renderiza la diapositiva a *output/fonts.pdf* y muestra las sustituciones reportadas por [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getsubstitutions/). Los dos pasos opcionales al inicio, cargar una carpeta *fonts* y leer una variable `DEFAULT_FONT`, se explican más adelante en este artículo.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Las fuentes a comprobar: los argumentos de la línea de comandos, o tres fuentes comunes de Office.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Cargar los archivos de fuentes desde la carpeta fonts situada junto a la aplicación, si existe.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Usar la fuente especificada en la variable de entorno DEFAULT_FONT, si está definida, para el texto cuya fuente falta.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* mantiene los resultados locales de la compilación fuera del contexto de construcción:

```text
bin/
obj/
output/
```

*Dockerfile* construye la aplicación con la imagen del SDK de .NET y la ejecuta en la imagen de tiempo de ejecución de .NET. La fase de tiempo de ejecución instala `libfontconfig1`, que Aspose.Slides.NET6.CrossPlatform requiere, y las fuentes DejaVu. [Ejecutar Aspose.Slides para .NET en Docker](/slides/es/net/how-to-run-aspose-slides-in-docker/) explica cada instrucción.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Compile la imagen y ejecute la comprobación:

```bash
docker build -t font-check .
docker run --rm font-check
```

La imagen solo contiene las fuentes DejaVu, por lo que las tres fuentes se reemplazan por DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Para comprobar las fuentes de sus propias presentaciones, pase sus nombres como argumentos, por ejemplo `docker run --rm font-check "Segoe UI" Consolas`. Para copiar *output/fonts.pdf* fuera del contenedor, use los comandos en [Copiar la salida a su máquina](/slides/es/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Instalar fuentes en Debian y Ubuntu**

### **Fuentes principales de Microsoft**

El paquete `ttf-mscorefonts-installer` descarga e instala las fuentes principales de Microsoft para la web, entre ellas Arial, Times New Roman, Courier New, Verdana, Georgia y Trebuchet MS. Las fuentes están licenciadas bajo el acuerdo de licencia de usuario final (EULA) de Microsoft, y el paquete las instala solo después de que se acepte la EULA. Una compilación de Docker no puede responder al aviso, por lo que el instalador rechaza la EULA y no instala fuentes, aunque `apt-get install` sigue indicando éxito. Acepte la EULA con `debconf-set-selections` **antes** de que se instale el paquete.

En el *Dockerfile*, reemplace la instrucción `RUN` que instala los paquetes en la fase de tiempo de ejecución con:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Compile la imagen y ejecute nuevamente la comprobación con los mismos dos comandos. Ahora Arial y Times New Roman están instalados:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, la fuente predeterminada de una presentación que crea Aspose.Slides, no es una de las fuentes principales, por lo que sigue siendo reemplazada. Consulte [Establecer una fuente predeterminada para fuentes faltantes](#set-a-default-font-for-missing-fonts).

En Debian, el paquete está en el componente del repositorio `contrib`, que las imágenes de Debian no habilitan; las imágenes predeterminadas de .NET 8 y .NET 9 se basan en Debian 12. Habilite `contrib` en la misma instrucción:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Las imágenes de .NET 10 basadas en Ubuntu ya habilitan `multiverse`, el componente de Ubuntu que contiene el paquete.

### **Otros paquetes de fuentes**

Debian y Ubuntu también empaquetan fuentes con licencia libre, por ejemplo:

| Package | Fonts |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif y Mono, con las mismas métricas que Arial, Times New Roman y Courier New |
| `fonts-crosextra-carlito` | Carlito, con las mismas métricas que Calibri |
| `fonts-crosextra-caladea` | Caladea, con las mismas métricas que Cambria |

Instálelos con `apt-get install` en la misma instrucción `RUN`. Aspose.Slides.NET6.CrossPlatform no aplica los alias de fuentes de la configuración de fuentes de Linux: con `fonts-liberation` instalado, el texto en Arial sigue dibujándose con la fuente de sustitución general, no con Liberation Sans. Para usar una fuente compatible en métricas en lugar de una que falta, establézcala como la [fuente predeterminada](#set-a-default-font-for-missing-fonts) o añada una [regla de sustitución de fuentes](/slides/es/net/font-substitution/).

## **Añadir sus propios archivos de fuentes**

Las fuentes que las distribuciones no empaquetan, como las fuentes de su organización u otras fuentes que tiene licencia para usar en el servidor, pueden añadirse como archivos de fuentes. Coloque los archivos de fuentes, por ejemplo archivos *.ttf*, en una carpeta llamada *fonts* dentro de la carpeta *FontCheck*. Los ejemplos siguientes usan los archivos de Carlito, una fuente con las mismas métricas que Calibri, que puede descargar de [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Instalar las fuentes en una carpeta de fuentes del sistema**

Aspose.Slides lee las fuentes en las carpetas mostradas en la línea `Font folders`. Para instalar sus fuentes para todas las aplicaciones de la imagen, cópielas en */usr/local/share/fonts*, la carpeta para fuentes instaladas localmente. Añada esta instrucción a la fase de tiempo de ejecución del *Dockerfile*, después de la instrucción `RUN` que instala los paquetes:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Cargar fuentes desde la carpeta de la aplicación**

En lugar de instalar las fuentes en la imagen, puede enviarlas con la aplicación y cargarlas con [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/loadexternalfonts/). Las fuentes estarán entonces disponibles solo para Aspose.Slides, y se despliegan junto con la aplicación. *FontCheck* hace esto: *FontCheck.csproj* copia la carpeta *fonts* a la salida de la aplicación, y *Program.cs* pasa esa carpeta a `LoadExternalFonts` antes de crear la presentación. [Fuente personalizada](/slides/es/net/custom-font/) describe otras formas de proporcionar fuentes, como cargarlas desde memoria.

Reconstruya la imagen, luego compruebe Calibri y Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

La carpeta de la aplicación ahora aparece entre las carpetas de fuentes, y Carlito ya no se sustituye:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Establecer una fuente predeterminada para fuentes faltantes**

Cuando falta una fuente, Aspose.Slides usa una sustitución que elige por sí mismo. Para elegirla usted, establezca la propiedad [DefaultRegularFont](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/defaultregularfont/) de [LoadOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/) y pase las opciones al constructor de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). *FontCheck* lee el nombre de la fuente de la variable de entorno `DEFAULT_FONT`. Con Carlito cargado, úsela para fuentes faltantes:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Ahora Calibri se dibuja con Carlito, cuyos caracteres tienen el mismo ancho que los de Calibri, por lo que el texto mantiene sus saltos de línea:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

La fuente predeterminada sustituye cada fuente faltante. Para asignar fuentes individuales, por ejemplo Arial a Liberation Sans y Calibri a Carlito, use [reglas de sustitución de fuentes](/slides/es/net/font-substitution/). Las reglas cambian la salida renderizada, pero `GetSubstitutions` no las refleja, así que compruebe las fuentes en el archivo de salida. Para texto asiático, establezca también [DefaultAsianFont](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/defaultasianfont/); consulte [Fuente predeterminada](/slides/es/net/default-font/).

## **Instalar fuentes en Alpine Linux**

En Alpine Linux, use el paquete Aspose.Slides.NET; [Ejecutar en Alpine Linux](/slides/es/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) enumera los cambios del proyecto. Realice los mismos cambios en *FontCheck*: reemplace la referencia al paquete, añada la instrucción `SetSwitch` a *Program.cs* y use esta fase de tiempo de ejecución, que también instala las fuentes principales de Microsoft:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` descarga e instala las mismas fuentes principales de Microsoft que el paquete de Debian y Ubuntu, y su EULA se aplica de la misma manera. `fc-cache` actualiza la caché de fuentes.

Con Aspose.Slides.NET en Linux, la biblioteca de configuración de fuentes (fontconfig) elige la sustitución para una fuente que falta, y `GetSubstitutions` no la informa, por lo que *FontCheck* muestra `No font substitutions.` Para ver qué fuente se usa para un nombre de fuente, consulte fontconfig en el contenedor:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Con las fuentes principales de Microsoft instaladas, Arial se usa para Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Sin ellas, cuando la instrucción `RUN` instala solo `icu-libs libgdiplus font-dejavu`, el mismo comando muestra:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**¿Por qué una presentación se ve diferente cuando se convierte en un servidor?**

El servidor no dispone de las fuentes que utiliza la presentación, por lo que Aspose.Slides dibuja el texto con una fuente de sustitución cuyas letras tienen otros anchos. Ejecute *FontCheck* con los nombres de fuentes de la presentación para ver qué fuentes se sustituyen, y luego instale esas fuentes o cárguelas desde la carpeta de la aplicación.

**La compilación instaló ttf-mscorefonts-installer, pero Arial sigue sustituyéndose. ¿Por qué?**

La EULA no se aceptó antes de que se instalara el paquete, por lo que el instalador omitió las fuentes. Añada el comando `debconf-set-selections` antes de `apt-get install`, como se muestra en [Fuentes principales de Microsoft](#microsoft-core-fonts), y vuelva a compilar la imagen.

**¿El ordenador que abre el PDF necesita las fuentes?**

No. En estos ejemplos, el PDF contiene las fuentes que se utilizaron para dibujar el texto, por lo que se ve igual en cualquier ordenador. Las fuentes solo se necesitan donde Aspose.Slides renderiza la presentación.