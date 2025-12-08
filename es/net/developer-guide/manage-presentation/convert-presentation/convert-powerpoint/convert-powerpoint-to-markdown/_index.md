---
title: Convertir PowerPoint a Markdown en C#
type: docs
weight: 140
url: /es/net/convert-powerpoint-to-markdown/
keywords: "Convertir PowerPoint a Markdown, Convertir ppt a md, PowerPoint, PPT, PPTX, Presentación, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir PowerPoint a Markdown en C#"
---

{{% alert color="info" %}} 

La compatibilidad para la conversión de PowerPoint a markdown se implementó en [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

La exportación de PowerPoint a markdown es **sin imágenes** por defecto. Si desea exportar un documento de PowerPoint que contenga imágenes, debe establecer `ExportType = MarkdownExportType.Visual` y definir el BasePath donde se guardarán las imágenes referenciadas en el documento markdown.

{{% /alert %}} 

## **Convertir PowerPoint a Markdown**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) para representar un objeto de presentación.
2. Utilice el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) para guardar el objeto como un archivo markdown.

Este código C# le muestra cómo convertir PowerPoint a markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **Convertir PowerPoint a un Sabor de Markdown**

Aspose.Slides le permite convertir PowerPoint a markdown (con sintaxis básica), CommonMark, markdown con estilo de GitHub, Trello, XWiki, GitLab y otros 17 sabores de markdown.

Este código C# le muestra cómo convertir PowerPoint a CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


Los 23 sabores de markdown compatibles están [enumerados en la enumeración Flavor](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la clase [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir Presentación con Imágenes a Markdown**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) proporciona propiedades y enumeraciones que permiten usar ciertas opciones o configuraciones para el archivo markdown resultante. El enum [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), por ejemplo, puede establecerse en valores que determinan cómo se renderizan o manejan las imágenes: `Sequential`, `TextOnly`, `Visual`.

### **Convertir Imágenes Secuencialmente**

Si desea que las imágenes aparezcan individualmente una tras otra en el markdown resultante, debe elegir la opción secuencial. Este código C# le muestra cómo convertir una presentación con imágenes a markdown:
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

Si desea que las imágenes aparezcan juntas en el markdown resultante, debe elegir la opción visual. En este caso, las imágenes se guardarán en el directorio actual de la aplicación (y se generará una ruta relativa para ellas en el documento markdown), o puede especificar la ruta y el nombre de carpeta que prefiera.

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


## **FAQ**

**¿Los hipervínculos sobreviven a la exportación a Markdown?**

Sí. Los hipervínculos de texto [hyperlinks](/slides/es/net/manage-hyperlinks/) se conservan como enlaces Markdown estándar. Las [transiciones](/slides/es/net/slide-transition/) y [animaciones](/slides/es/net/powerpoint-animation/) de diapositivas no se convierten.

**¿Puedo acelerar la conversión ejecutándola en varios hilos?**

Puede paralelizar por archivos, pero [no comparta](/slides/es/net/multithreading/) la misma instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) entre hilos. Utilice instancias o procesos separados por archivo para evitar contenciones.

**¿Qué ocurre con las imágenes—dónde se guardan y son las rutas relativas?**

Las [Images](/slides/es/net/image/) se exportan a una carpeta dedicada, y el archivo Markdown las referencia con rutas relativas por defecto. Puede configurar la ruta base de salida y el nombre de la carpeta de activos para mantener una estructura de repositorio predecible.