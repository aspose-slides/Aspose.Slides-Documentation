---
title: Convertir presentaciones de PowerPoint a Markdown en .NET
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/net/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a MD
- presentación a MD
- diapositiva a MD
- PPT a MD
- PPTX a MD
- guardar PowerPoint como Markdown
- guardar presentación como Markdown
- guardar diapositiva como Markdown
- guardar PPT como MD
- guardar PPTX como MD
- exportar PPT a MD
- exportar PPTX a MD
- exportación de imágenes Markdown
- enlaces de imágenes CDN
- PowerPoint
- presentación
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Convertir presentaciones PPT y PPTX a Markdown en .NET y controlar dónde se guardan y referencian las imágenes exportadas en bitmap, metarchivo y SVG."
---
## **Visión general**

Aspose.Slides for .NET puede convertir presentaciones PPT y PPTX a Markdown para documentación, sitios estáticos, migración de contenido y flujos de trabajo de control de versiones. Puede elegir un sabor de Markdown, controlar cómo se renderiza el contenido de las diapositivas y decidir dónde se almacenan las imágenes exportadas y cómo el Markdown generado las referencia.

De forma predeterminada, la exportación a Markdown utiliza solo texto. Para exportar contenido visual, establezca la propiedad [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/exporttype/) en el valor `Sequential` o `Visual` del enumerado [MarkdownExportType](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownexporttype/). `Sequential` renderiza los elementos de la diapositiva por separado y en orden, mientras que `Visual` mantiene los elementos agrupados para preservar su relación visual. El valor `TextOnly` no genera recursos de imagen, por lo que los eventos de guardado de imágenes no se invocan en ese modo.

## **Convertir una presentación a Markdown**

Carga el archivo fuente con la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y luego llama al método [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) con el valor `Md` del enumerado [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Seleccionar un sabor de Markdown**

La propiedad [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/flavor/) controla la especificación de Markdown utilizada para la salida. El enumerado [Flavor](https://reference.aspose.com/slides/es/net/aspose.slides.export/flavor/) incluye CommonMark, GitHub Flavored Markdown y otras variantes compatibles.

El siguiente ejemplo exporta una presentación como CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Exportar imágenes con el comportamiento predeterminado de guardado local**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/) proporciona dos propiedades para imágenes guardadas localmente:

- [BasePath](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/basepath/) especifica el directorio base para el documento Markdown y sus recursos.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) especifica el subdirectorio de imágenes. Su valor predeterminado es `Images`.

El siguiente ejemplo renderiza contenido visual, escribe imágenes en `output/assets` y crea referencias de imagen relativas en el documento Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Este comportamiento también sirve como alternativa cuando un controlador personalizado de guardado de imágenes devuelve `false`.

## **Personalizar el guardado de imágenes y los enlaces Markdown**

Utilice el evento [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/imagesaving/) para recursos de mapa de bits y metarchivo que no sean SVG emitidos durante la exportación a Markdown. Su delegado [MarkdownImageSavingHandler](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) recibe el objeto [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/), su [ImageFormat](https://reference.aspose.com/slides/es/net/aspose.slides/imageformat/), y el enlace Markdown generado como parámetro `ref string`. Guarde o cargue la imagen con el formato proporcionado y reemplace `link` con la referencia que debe aparecer en la salida Markdown.

Los recursos emitidos en formato SVG se gestionan por separado. Suscríbase al evento [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), cuyo delegado [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) recibe un objeto [ISvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/) y el parámetro `ref string link`. Un SVG no tiene argumento `ImageFormat`; escriba o cargue sus datos XML desde la propiedad [ISvgImage.SvgData](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/svgdata/) en su lugar. Según el modo de exportación y el agrupamiento visual, un SVG en la presentación de origen puede rasterizarse o combinarse con otro contenido; el recurso no SVG resultante se pasa entonces a `ImageSaving`. Suscríbase a ambos eventos cuando cada recurso visual exportado requiera procesamiento personalizado.

El valor devuelto por el controlador determina quién procesa la imagen:

- Devuelva `true` después de que el controlador haya guardado, cargado, transformado o procesado la imagen y haya asignado un valor válido a `link`. Aspose.Slides escribe ese valor en el documento Markdown y no realiza su guardado local predeterminado.
- Devuelva `false` para que Aspose.Slides guarde la imagen localmente y genere su enlace según [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/basepath/) y [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Un controlador que devuelve `true` asume la responsabilidad de la imagen. Si devuelve `true` sin asignar un enlace válido y no vacío, la exportación falla con una `InvalidOperationException`.
{{% /alert %}}

### **Guardar imágenes en un directorio de origen CDN y usar URLs externas**

El siguiente ejemplo trata `cdn-origin/presentations/quarterly-report` como un directorio de origen CDN montado o sincronizado. Cada controlador extrae el nombre de archivo generado, guarda la imagen en ese directorio personalizado y sustituye la referencia local generada por una URL pública de CDN. El ejemplo en sí no realiza carga de red: la URL solo será válida después de que el directorio se monte como origen CDN o sus archivos se publiquen en el CDN. Para almacenamiento de objetos, reemplace la escritura en el sistema de archivos por la operación de carga del SDK de almacenamiento y asigne `link` solo después de que la carga tenga éxito.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

El controlador de mapa de bits devuelve deliberadamente `false` para imágenes menores de 128 × 128 píxeles, de modo que Aspose.Slides guarda esas imágenes en `output/fallback-images` usando el comportamiento predeterminado. Los recursos de mapa de bits y metarchivo más grandes, así como los recursos SVG, son gestionados por el código personalizado. Por ejemplo, una referencia local generada como `fallback-images/image1.png` se convierte en `https://cdn.example.com/presentations/quarterly-report/image1.png`. Los controladores usan rutas del sistema operativo solo al escribir archivos; los enlaces escritos en Markdown utilizan barras diagonales y nombres de archivo escapados en URL. Aplique la misma norma al crear enlaces relativos: use `/`, no el separador de directorios específico de la plataforma.

## **Preguntas frecuentes**

**¿Puede un mismo controlador procesar tanto imágenes rasterizadas como SVG?**

No. Utilice [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/imagesaving/) para recursos de mapa de bits y metarchivo emitidos y [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) para recursos emitidos como SVG. El primero proporciona un objeto [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) y un [ImageFormat](https://reference.aspose.com/slides/es/net/aspose.slides/imageformat/); el segundo proporciona un objeto [ISvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/) cuyo dato SVG puede leerse desde [ISvgImage.SvgData](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/svgdata/). Un SVG de origen que se rasteriza durante la exportación se procesa mediante `ImageSaving` en su lugar.

**¿Qué ocurre cuando un controlador de guardado de imagen devuelve `false`?**

Aspose.Slides utiliza su comportamiento predeterminado de guardado local. La ubicación de la imagen y la referencia generada están controladas por [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/basepath/) y [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/es/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**¿Puede un controlador proporcionar una URL sin guardar la imagen localmente?**

Sí. El controlador puede cargar la imagen en almacenamiento de objetos o pasarla a otro servicio, asignar la URL resultante a `link` y devolver `true`. El controlador debe completar el procesamiento por sí mismo; devolver `true` impide el guardado local predeterminado.

**¿Por qué la exportación a Markdown lanza una `InvalidOperationException` desde un controlador?**

Esta excepción ocurre cuando el controlador devuelve `true` pero no proporciona un enlace válido. Asigne la ruta relativa o URL externa que debe escribirse en Markdown antes de devolver `true`.

**¿Qué separador de rutas deben usar los enlaces de imagen?**

Utilice barras diagonales en los enlaces Markdown y URLs. Use `Path.Combine` solo para rutas del sistema de archivos y construya o normalice la referencia Markdown por separado.

**¿Se conservan los hipervínculos durante la exportación a Markdown?**

Sí. Los [hipervínculos](/slides/es/net/manage-hyperlinks/) de texto se conservan como enlaces Markdown estándar. Las [transiciones](/slides/es/net/slide-transition/) y [animaciones](/slides/es/net/powerpoint-animation/) de diapositivas no se convierten.

**¿Se pueden convertir presentaciones a Markdown en paralelo?**

Puede procesar diferentes archivos de presentación en paralelo, pero no comparta la misma instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) entre hilos. Siga las [directrices de multihilo](/slides/es/net/multithreading/) y utilice una instancia separada para cada archivo.