---
title: PowerPoint-presentaties converteren naar Markdown op Android
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren
- presentatie converteren
- slide converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar MD
- presentatie naar MD
- slide naar MD
- PPT naar MD
- PPTX naar MD
- PowerPoint opslaan als Markdown
- presentatie opslaan als Markdown
- slide opslaan als Markdown
- PPT opslaan als MD
- PPTX opslaan als MD
- PPT exporteren naar MD
- PPTX exporteren naar MD
- PowerPoint
- presentatie
- Markdown
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint-slides—PPT, PPTX—naar nette Markdown met Aspose.Slides voor Android via Java, automatiseer documentatie en behoud opmaak."
---
## **Inleiding**

Aspose.Slides stelt u in staat PowerPoint‑presentaties naar Markdown te converteren, wat nuttig kan zijn voor documentatieworkflows, het genereren van statische sites, contentmigratie en versie‑gecontroleerde tekstpublicatie. De API ondersteunt directe export van PPT‑ en PPTX‑presentaties naar MD‑bestanden en biedt extra opties om te bepalen hoe slide‑inhoud wordt weergegeven in het resulterende Markdown‑document.

U kunt presentaties exporteren als platte Markdown, kiezen uit verschillende Markdown‑varianten zoals CommonMark en GitHub Flavored Markdown, en configureren hoe afbeeldingen worden afgehandeld tijdens de export. Voor presentaties met visuele inhoud laat Aspose.Slides u bovendien afbeeldingen opslaan in een aparte map en deze refereren vanuit het gegenereerde Markdown‑bestand.

Aspose.Slides ondersteunt conversie van presentaties naar Markdown.

{{% alert color="warning" %}} 
PowerPoint‑naar‑Markdown‑export is standaard **zonder afbeeldingen**. Als u een PowerPoint‑document met afbeeldingen wilt exporteren, moet u `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` instellen en ook de `BasePath` opgeven waar de afbeeldingen die in het Markdown‑document worden gerefereerd, opgeslagen moeten worden.
{{% /alert %}} 

## **PowerPoint naar Markdown converteren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse om een presentatie‑object te representeren.
2. Gebruik de [Save ](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)methode om het object op te slaan als een markdown‑bestand.

Deze Java‑code toont hoe u PowerPoint naar markdown converteert:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint naar Markdown‑variant converteren**

Aspose.Slides stelt u in staat PowerPoint naar markdown (met basale syntaxis), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab en 17 andere markdown‑varianten te converteren.

Deze Java‑code toont hoe u PowerPoint naar CommonMark converteert:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

De 23 ondersteunde markdown‑varianten staan [opgenomen onder de Flavor‑enumeratie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/flavor/) van de klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Een presentatie met afbeeldingen naar Markdown converteren**

De klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/) biedt eigenschappen en enumeraties waarmee u bepaalde opties of instellingen voor het resulterende markdown‑bestand kunt gebruiken. De enum [MarkdownExportType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownexporttype/) kan bijvoorbeeld worden ingesteld op waarden die bepalen hoe afbeeldingen worden gerenderd of afgehandeld: `Sequential`, `TextOnly`, `Visual`.

### **Afbeeldingen opeenvolgend converteren**

Als u wilt dat de afbeeldingen afzonderlijk achter elkaar verschijnen in het resulterende markdown, moet u de opeenvolgende optie kiezen. Deze Java‑code toont hoe u een presentatie met afbeeldingen naar markdown converteert:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Afbeeldingen visueel converteren**

Als u wilt dat de afbeeldingen samen verschijnen in het resulterende markdown, moet u de visuele optie kiezen. In dat geval worden de afbeeldingen opgeslagen in de huidige map van de applicatie (en wordt er een relatief pad voor hen opgebouwd in het markdown‑document), of u kunt uw gewenste pad en mapnaam opgeven.

Deze Java‑code demonstreert de werking:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Blijven hyperlinks behouden bij export naar Markdown?**

Ja. Tekst-[hyperlinks](/slides/nl/androidjava/manage-hyperlinks/) blijven bewaard als standaard Markdown‑links. Slide-[transities](/slides/nl/androidjava/slide-transition/) en -[animaties](/slides/nl/androidjava/powerpoint-animation/) worden niet geconverteerd.

**Kan ik de conversie versnellen door deze in meerdere threads uit te voeren?**

U kunt paralleliseren over bestanden, maar [deel niet](/slides/nl/androidjava/multithreading/) dezelfde [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie niet over threads. Gebruik aparte instanties/processen per bestand om conflicten te vermijden.

**Wat gebeurt er met afbeeldingen—waar worden ze opgeslagen en zijn de paden relatief?**

[Afbeeldingen](/slides/nl/androidjava/image/) worden geëxporteerd naar een speciale map, en het Markdown‑bestand verwijst standaard naar hen met relatieve paden. U kunt het basis‑outputpad en de asset‑mapnaam configureren om een voorspelbare repository‑structuur te behouden.