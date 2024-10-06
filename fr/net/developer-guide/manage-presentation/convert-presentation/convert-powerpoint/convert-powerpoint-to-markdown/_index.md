---
title: Convertir PowerPoint en Markdown en C#
type: docs
weight: 140
url: /net/convert-powerpoint-to-markdown/
keywords: "Convertir PowerPoint en Markdown, Convertir ppt en md, PowerPoint, PPT, PPTX, Présentation, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir PowerPoint en Markdown en C#"
---

{{% alert color="info" %}} 

Le support de la conversion de PowerPoint en markdown a été implémenté dans [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

L'exportation de PowerPoint en markdown est **sans images** par défaut. Si vous souhaitez exporter un document PowerPoint contenant des images, vous devez définir `ExportType = MarkdownExportType.Visual` et définir le BasePath où les images référencées dans le document markdown seront enregistrées.

{{% /alert %}} 

## **Convertir PowerPoint en Markdown**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) pour représenter un objet de présentation.
2. Utilisez la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) pour enregistrer l'objet en tant que fichier markdown.

Ce code C# vous montre comment convertir PowerPoint en markdown :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## Convertir PowerPoint en Markdown Flavor

Aspose.Slides vous permet de convertir PowerPoint en markdown (contenant une syntaxe de base), CommonMark, markdown version GitHub, Trello, XWiki, GitLab, et 17 autres versions de markdown.

Ce code C# vous montre comment convertir PowerPoint en CommonMark :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

Les 23 versions de markdown prises en charge sont [listées sous l'énumération Flavor](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir une Présentation contenant des Images en Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent d'utiliser certaines options ou paramètres pour le fichier markdown résultant. L'énumération [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) peut par exemple être définie sur des valeurs qui déterminent comment les images sont rendues ou gérées : `Sequential`, `TextOnly`, `Visual`.

### **Convertir des Images Séquentiellement**

Si vous souhaitez que les images apparaissent individuellement les unes après les autres dans le markdown résultant, vous devez choisir l'option séquentielle. Ce code C# vous montre comment convertir une présentation contenant des images en markdown :

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

### **Convertir des Images Visuellement**

Si vous souhaitez que les images apparaissent ensemble dans le markdown résultant, vous devez choisir l'option visuelle. Dans ce cas, les images seront enregistrées dans le répertoire actuel de l'application (et un chemin relatif sera construit pour elles dans le document markdown), ou vous pouvez spécifier votre chemin et nom de dossier préférés.

Ce code C# illustre l'opération :

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