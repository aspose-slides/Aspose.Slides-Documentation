---
title: PowerPoint-presentaties converteren naar Markdown in .NET
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar MD
- presentatie naar MD
- dia naar MD
- PPT naar MD
- PPTX naar MD
- PowerPoint opslaan als Markdown
- presentatie opslaan als Markdown
- dia opslaan als Markdown
- PPT opslaan als MD
- PPTX opslaan als MD
- PPT exporteren naar MD
- PPTX exporteren naar MD
- PowerPoint
- presentatie
- Markdown
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-dia’s—PPT, PPTX—omzetten naar nette Markdown met Aspose.Slides voor .NET, documentatie automatiseren en opmaak behouden."
---
## **Inleiding**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties naar Markdown te converteren, wat nuttig kan zijn voor documentatieworkflows, statische sitegeneratie, contentmigratie en versie‑gecontroleerde tekstpublicatie. De API ondersteunt directe export van PPT‑ en PPTX‑presentaties naar MD‑bestanden en biedt extra opties om te bepalen hoe de inhoud van dia's wordt weergegeven in het resulterende Markdown‑document.

U kunt presentaties exporteren als platte Markdown, kiezen uit meerdere Markdown‑varianten zoals CommonMark en GitHub Flavored Markdown, en configureren hoe afbeeldingen worden behandeld tijdens de export. Voor presentaties die visuele inhoud bevatten, laat Aspose.Slides u ook afbeeldingen opslaan in een aparte map en ernaar verwijzen vanuit het gegenereerde Markdown‑bestand.

{{% alert color="warning" %}}
PowerPoint‑naar‑Markdown export is standaard **zonder afbeeldingen**. Als u een PowerPoint‑document met afbeeldingen wilt exporteren, moet u `ExportType = MarkdownExportType.Visual` instellen en `BasePath` opgeven, waar de afbeeldingen die in het Markdown‑document worden aangeduid, worden opgeslagen.
{{% /alert %}}

## **PowerPoint naar Markdown converteren**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) aan om een presentatie‑object te vertegenwoordigen.  
2. Gebruik de [Save ](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/methods/save)method om het object op te slaan als een markdown‑bestand.

Deze C#‑code laat zien hoe u PowerPoint naar markdown converteert:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **PowerPoint naar een Markdown‑variant converteren**

Aspose.Slides stelt u in staat om PowerPoint naar markdown (met basis‑syntaxis), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab en nog eens 17 andere markdown‑varianten te converteren.

Deze C#‑code laat zien hoe u PowerPoint naar CommonMark converteert:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

De 23 ondersteunde markdown‑varianten zijn [vermeld onder de enumeratie Flavor](https://reference.aspose.com/slides/nl/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) van de klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Een presentatie met afbeeldingen naar Markdown converteren**

De klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) biedt eigenschappen en enumeraties waarmee u bepaalde opties of instellingen voor het resulterende markdown‑bestand kunt gebruiken. De enumeratie [MarkdownExportType](https://reference.aspose.com/slides/nl/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) kan bijvoorbeeld ingesteld worden op waarden die bepalen hoe afbeeldingen worden gerenderd of verwerkt: `Sequential`, `TextOnly`, `Visual`.

### **Afbeeldingen opeenvolgend converteren**

Als u wilt dat de afbeeldingen afzonderlijk achter elkaar in het resulterende markdown verschijnen, moet u de opeenvolgende optie kiezen. Deze C#‑code laat zien hoe u een presentatie met afbeeldingen naar markdown converteert:

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

### **Afbeeldingen visueel converteren**

Als u wilt dat de afbeeldingen samen in het resulterende markdown verschijnen, moet u de visuele optie kiezen. In dat geval worden afbeeldingen opgeslagen in de huidige map van de applicatie (en wordt een relatief pad voor hen opgebouwd in het markdown‑document), of u kunt uw gewenste pad en mapnaam opgeven.

Deze C#‑code demonstreert de werking:

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

**Blijven hyperlinks behouden bij export naar Markdown?**

Ja. Tekst‑[hyperlinks](/slides/nl/net/manage-hyperlinks/) worden bewaard als standaard Markdown‑links. Dia‑[transities](/slides/nl/net/slide-transition/) en [animaties](/slides/nl/net/powerpoint-animation/) worden niet geconverteerd.

**Kan ik de conversie versnellen door deze in meerdere threads uit te voeren?**

U kunt paralleliseren per bestand, maar [deel niet](/slides/nl/net/multithreading/) dezelfde [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie niet over threads. Gebruik afzonderlijke instanties/processen per bestand om concurrentie te vermijden.

**Wat gebeurt er met afbeeldingen — waar worden ze opgeslagen en zijn de paden relatief?**

[Afbeeldingen](/slides/nl/net/image/) worden geëxporteerd naar een speciale map en het Markdown‑bestand verwijst er standaard naar met relatieve paden. U kunt het basisuitvoerpad en de mapnaam voor assets configureren om een voorspelbare repository‑structuur te behouden.