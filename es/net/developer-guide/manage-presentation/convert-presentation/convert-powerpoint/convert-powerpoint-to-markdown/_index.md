---
title: Convertir PowerPoint a Markdown en C#
type: docs
weight: 140
url: /es/net/convert-powerpoint-to-markdown/
keywords: "Convertir PowerPoint a Markdown, Convertir ppt a md, PowerPoint, PPT, PPTX, Presentación, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir PowerPoint a Markdown en C#"
---

{{% alert color="info" %}} 

El soporte para la conversión de PowerPoint a markdown fue implementado en [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

La exportación de PowerPoint a markdown es **sin imágenes** por defecto. Si deseas exportar un documento de PowerPoint que contenga imágenes, necesitas establecer `ExportType = MarkdownExportType.Visual` y establecer la BasePath donde se guardarán las imágenes referenciadas en el documento markdown.

{{% /alert %}} 

## **Convertir PowerPoint a Markdown**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) para representar un objeto de presentación.
2. Utiliza el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) para guardar el objeto como un archivo markdown.

Este código C# te muestra cómo convertir PowerPoint a markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## Convertir PowerPoint a Sabor de Markdown

Aspose.Slides te permite convertir PowerPoint a markdown (que contiene sintaxis básica), CommonMark, markdown de GitHub, Trello, XWiki, GitLab y otros 17 sabores de markdown.

Este código C# te muestra cómo convertir PowerPoint a CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

Los 23 sabores de markdown compatibles están [listados bajo la enumeración Flavor](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la clase [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir Presentación que Contiene Imágenes a Markdown**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) proporciona propiedades y enumeraciones que te permiten usar ciertas opciones o configuraciones para el archivo markdown resultante. La enumeración [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) puede, por ejemplo, establecerse en valores que determinan cómo se renderizan o manejan las imágenes: `Sequential`, `TextOnly`, `Visual`.

### **Convertir Imágenes Secuencialmente**

Si deseas que las imágenes aparezcan individualmente una tras otra en el markdown resultante, debes elegir la opción secuencial. Este código C# te muestra cómo convertir una presentación que contiene imágenes a markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Convertir Imágenes Visualmente**

Si deseas que las imágenes aparezcan juntas en el markdown resultante, debes elegir la opción visual. En este caso, las imágenes se guardarán en el directorio actual de la aplicación (y se construirá una ruta relativa para ellas en el documento markdown), o puedes especificar tu ruta y nombre de carpeta preferidos.

Este código C# demuestra la operación:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```