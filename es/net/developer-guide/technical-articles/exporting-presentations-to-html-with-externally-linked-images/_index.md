---
title: Exportar presentaciones a HTML con imágenes enlazadas externamente
type: docs
weight: 100
url: /es/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- exportar diapositiva
- exportar PPT
- exportar PPTX
- exportar ODP
- PowerPoint a HTML
- OpenDocument a HTML
- presentación a HTML
- diapositiva a HTML
- PPT a HTML
- PPTX a HTML
- ODP a HTML
- imagen enlazada
- imagen enlazada externamente
- recurso enlazado
- recurso externo
- .NET
- C#
- Aspose.Slides
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML en .NET usando Aspose.Slides con imágenes y otros recursos guardados como archivos externos enlazados."
---
## **Resumen**

De forma predeterminada, Aspose.Slides exporta una presentación a un archivo HTML autocontenido. Las imágenes y otros recursos se escriben directamente en el HTML, generalmente como datos Base64. Esto es conveniente cuando necesita un único archivo portátil, pero no siempre es el mejor formato para un sitio web, un CMS o una canalización de conversión del lado del servidor.

Utilice recursos enlazados externamente cuando desee:

- reducir el tamaño del documento HTML;
- almacenar en caché imágenes, fuentes, audio o vídeo por separado en un navegador o CDN;
- inspeccionar, reemplazar, comprimir o post‑procesar los recursos generados después de la exportación;
- mantener la estructura de salida más cercana a lo que una aplicación web espera.

Para el flujo de trabajo general de conversión a HTML, vea [Convertir presentaciones de PowerPoint a HTML](/slides/es/net/convert-powerpoint-to-html/). Este artículo se centra en la parte de enlace de recursos de la exportación.

## **Cómo funciona la exportación de recursos enlazados**

[ILinkEmbedController](https://reference.aspose.com/slides/es/net/aspose.slides.export/ilinkembedcontroller/) permite a su aplicación decidir, recurso por recurso, si el exportador incrusta los datos en el HTML o los guarda externamente y escribe un enlace.

La interfaz tiene tres métodos:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/es/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) decide si un recurso debe enlazarse o incrustarse.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/es/net/aspose.slides.export/ilinkembedcontroller/geturl/) devuelve la URL que se escribirá en el HTML generado o en otro recurso enlazado.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/es/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) escribe los datos del recurso enlazado en disco o en otro objetivo de almacenamiento.

La ruta del sistema de archivos y la URL del navegador son aspectos independientes. Por ejemplo, el ejemplo a continuación escribe los archivos de recursos en `html-output/assets` en disco, mientras que el HTML contiene URL relativas como `assets/resource-1.svg`. Un navegador resuelve esas URL respecto al archivo que contiene el enlace. Por lo tanto, un enlace desde `presentation.html` a un archivo SVG utiliza `assets/resource-1.svg`, mientras que un enlace desde ese archivo SVG a una imagen guardada en la misma carpeta `assets` utiliza `resource-4.jpg`.

## **Exportar HTML con recursos enlazados**

El siguiente ejemplo en C# crea un directorio de salida, guarda el archivo HTML allí y almacena los recursos enlazados en un subdirectorio `assets`. El controlador enlaza recursos comunes de imagen, fuente, audio, vídeo y CSS cuando Aspose.Slides proporciona o puede deducir una extensión de archivo segura. Los recursos que no se reconocen permanecen incrustados.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

Después de la exportación, la carpeta de salida tiene esta estructura:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Los archivos exactos dependen del contenido de la presentación y de las opciones de exportación. Por ejemplo, las imágenes raster suelen exportarse como JPEG o PNG. Aspose.Slides puede elegir un códec de imagen diferente al usado en la presentación original cuando eso produce un archivo más pequeño o más adecuado. Las imágenes con transparencia se exportan como PNG.

## **Elección de URL para la implementación**

El ejemplo usa un prefijo de URL relativo: `assets/`. Si `presentation.html` se abre desde `html-output/presentation.html`, el navegador carga `html-output/assets/resource-1.svg`.

Cuando un recurso enlazado hace referencia a otro recurso enlazado, el ejemplo usa el parámetro `referrer` en [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/es/net/aspose.slides.export/ilinkembedcontroller/geturl/) y devuelve solo el nombre del archivo. Por ejemplo, si `resource-1.svg` y `resource-4.jpg` están ambos en la carpeta `assets`, el archivo SVG debe referirse a `resource-4.jpg`, no a `assets/resource-4.jpg`.

Utilice un prefijo de URL diferente cuando los archivos se despliegan en otro lugar:

- Use `assets/` cuando el directorio de activos está junto al archivo HTML.
- Use `../assets/` cuando el directorio de activos está un nivel por encima del archivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` cuando los archivos se cargan en un CDN o servidor de archivos estáticos.

La URL devuelta por [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/es/net/aspose.slides.export/ilinkembedcontroller/geturl/) debe coincidir con la ubicación final de despliegue del archivo escrito por [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/es/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). En aplicaciones de servidor, use un directorio de salida único o un prefijo de almacenamiento de objetos para cada trabajo de conversión para evitar sobrescribir archivos de otra exportación.

## **Cuándo incrustar en su lugar**

El HTML incrustado en Base64 sigue siendo útil cuando la salida debe ser un único archivo, como un adjunto de correo electrónico, una vista previa sin conexión o un documento que se moverá sin una carpeta de activos de soporte. Los recursos enlazados son más adecuados cuando el HTML será servido por una aplicación web, almacenado en un CMS, optimizado por una tubería de compilación o almacenado en caché por los navegadores de forma independiente del HTML.

## **Preguntas frecuentes**

**¿Puedo externalizar solo las imágenes y mantener los demás recursos incrustados?**

Sí. En [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/es/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), devuelva `LinkEmbedDecision.Link` solo para los tipos de contenido que desee guardar como archivos separados, y devuelva `LinkEmbedDecision.Embed` para todo lo demás.

**¿Por qué la extensión de la imagen exportada difiere de la presentación original?**

Aspose.Slides puede volver a codificar las imágenes raster durante la exportación a HTML para mejorar el tamaño o la compatibilidad con el navegador. Por ejemplo, una imagen del archivo original puede escribirse como JPEG o PNG según el resultado renderizado.

**¿Funcionan las URL relativas después de mover el archivo HTML?**

Las URL relativas solo funcionan cuando se conserva la misma estructura de carpetas relativa. Si el HTML hace referencia a `assets/resource-1.png`, la carpeta `assets` debe permanecer junto al archivo HTML a menos que genere un prefijo de URL diferente.

**¿Deben las aplicaciones del servidor reutilizar la misma carpeta de salida?**

No. Use un directorio de salida único o un prefijo de almacenamiento para cada trabajo de conversión. Esto evita colisiones de nombres de archivo y evita que una exportación sobrescriba los recursos generados por otra exportación.