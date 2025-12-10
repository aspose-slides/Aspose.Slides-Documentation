---
title: Convertir des présentations PowerPoint en Markdown avec .NET
linktitle: PowerPoint en Markdown
type: docs
weight: 140
url: /fr/net/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir une présentation
- convertir une diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en MD
- présentation en MD
- diapositive en MD
- PPT en MD
- PPTX en MD
- enregistrer PowerPoint en Markdown
- enregistrer la présentation en Markdown
- enregistrer la diapositive en Markdown
- enregistrer PPT en MD
- enregistrer PPTX en MD
- exporter PPT en MD
- exporter PPTX en MD
- PowerPoint
- présentation
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint—PPT, PPTX—en Markdown propre avec Aspose.Slides pour .NET, automatisez la documentation et conservez la mise en forme."
---

{{% alert color="info" %}} 

Le support de la conversion de PowerPoint en markdown a été implémenté dans [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

L'exportation de PowerPoint vers markdown est **sans images** par défaut. Si vous souhaitez exporter un document PowerPoint contenant des images, vous devez définir `ExportType = MarkdownExportType.Visual` et définir le BasePath où les images référencées dans le document markdown seront enregistrées.

{{% /alert %}} 

## **Convertir PowerPoint en Markdown**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) pour représenter un objet de présentation.
2. Utilisez la [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)method pour enregistrer l'objet en fichier markdown.

Ce code C# vous montre comment convertir PowerPoint en markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **Convertir PowerPoint en variante Markdown**

Aspose.Slides permet de convertir PowerPoint en markdown (contenant la syntaxe de base), CommonMark, le markdown à la façon de GitHub, Trello, XWiki, GitLab, et 17 autres variantes de markdown.

Ce code C# vous montre comment convertir PowerPoint en CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


Les 23 variantes de markdown prises en charge sont [listées sous l'énumération Flavor](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) de la classe [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convertir une présentation contenant des images en Markdown**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fournit des propriétés et des énumérations qui vous permettent d'utiliser certaines options ou paramètres pour le fichier markdown résultant. L'énumération [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) peut, par exemple, être définie sur des valeurs qui déterminent comment les images sont rendues ou gérées : `Sequential`, `TextOnly`, `Visual`.

### **Convertir les images séquentiellement**

Si vous souhaitez que les images apparaissent individuellement, l’une après l’autre, dans le markdown résultant, vous devez choisir l'option séquentielle. Ce code C# montre comment convertir une présentation contenant des images en markdown:
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


### **Convertir les images visuellement**

Si vous souhaitez que les images apparaissent ensemble dans le markdown résultant, vous devez choisir l'option visuelle.   Dans ce cas, les images seront enregistrées dans le répertoire courant de l'application (et un chemin relatif sera créé pour elles dans le document markdown), ou vous pouvez spécifier le chemin et le nom du dossier de votre préférence.

Ce code C# démontre l'opération:
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

**Les hyperliens survivent-ils à l'exportation vers Markdown ?**

Oui. Les [hyperliens](/slides/fr/net/manage-hyperlinks/) du texte sont conservés sous forme de liens Markdown standard. Les [transitions](/slides/fr/net/slide-transition/) et les [animations](/slides/fr/net/powerpoint-animation/) des diapositives ne sont pas converties.

**Puis-je accélérer la conversion en l’exécutant sur plusieurs threads ?**

Vous pouvez paralléliser par fichiers, mais [ne partagez pas](/slides/fr/net/multithreading/) la même instance de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) entre les threads. Utilisez des instances/processus séparés par fichier pour éviter les conflits.

**Que se passe-t-il avec les images — où sont‑elles enregistrées, et les chemins sont‑ils relatifs ?**

Les [images](/slides/fr/net/image/) sont exportées vers un dossier dédié, et le fichier Markdown les référence par des chemins relatifs par défaut. Vous pouvez configurer le chemin de sortie de base et le nom du dossier d’actifs pour maintenir une structure de référentiel prévisible.