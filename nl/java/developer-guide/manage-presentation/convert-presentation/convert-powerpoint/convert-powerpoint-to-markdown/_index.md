---
title: PowerPoint-presentaties converteren naar Markdown in Java
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/java/convert-powerpoint-to-markdown/
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
- export PPTX naar MD
- PowerPoint
- presentatie
- Markdown
- Java
- Aspose.Slides
description: "Converteer PowerPoint-dia’s—PPT, PPTX—naar schone Markdown met Aspose.Slides voor Java, automatiseer documentatie en behoud de opmaak."
---
## **Inleiding**

Aspose.Slides stelt u in staat PowerPoint‑presentaties naar Markdown te converteren, wat handig kan zijn voor documentatieworkflows, statische site‑generatie, contentmigratie en versie‑gecontroleerde tekstopmaak. De API ondersteunt directe export van PPT‑ en PPTX‑presentaties naar MD‑bestanden en biedt extra opties om te bepalen hoe de inhoud van dia’s wordt weergegeven in het resulterende Markdown‑document.

U kunt presentaties exporteren als gewone Markdown, kiezen uit verschillende Markdown‑varianten zoals CommonMark en GitHub Flavored Markdown, en configureren hoe afbeeldingen worden afgehandeld tijdens de export. Voor presentaties die visuele inhoud bevatten, laat Aspose.Slides u ook afbeeldingen opslaan in een aparte map en ernaar verwijzen vanuit het gegenereerde Markdown‑bestand.

{{% alert color="warning" %}}

PowerPoint‑naar‑Markdown‑export is standaard **zonder afbeeldingen**. Als u een PowerPoint‑document met afbeeldingen wilt exporteren, moet u `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` gebruiken en tevens `setBasePath` instellen waar de afbeeldingen die in het markdown‑document worden gerefereerd, worden opgeslagen.

{{% /alert %}}

## **PowerPoint naar Markdown converteren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse om een presentatie‑object weer te geven.
2. Gebruik de [Save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)‑methode om het object op te slaan als een markdown‑bestand.

Deze Java‑code laat zien hoe u PowerPoint naar markdown converteert:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint naar Markdown‑variant converteren**

Aspose.Slides stelt u in staat PowerPoint naar markdown (met basis‑syntaxis), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab en nog 17 andere markdown‑varianten te converteren.

Deze Java‑code laat zien hoe u PowerPoint naar CommonMark converteert:

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

De 23 ondersteunde markdown‑varianten staan [onder de Flavor‑enumeratie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/flavor/) van de [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/)‑klasse.

## **Een presentatie met afbeeldingen naar Markdown converteren**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/)‑klasse biedt eigenschappen en enumeraties waarmee u bepaalde opties of instellingen voor het resulterende markdown‑bestand kunt gebruiken. De enum [MarkdownExportType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownexporttype/), bijvoorbeeld, kan worden ingesteld op waarden die bepalen hoe afbeeldingen worden gerenderd of afgehandeld: `Sequential`, `TextOnly`, `Visual`.

### **Afbeeldingen opeenvolgend converteren**

Als u wilt dat de afbeeldingen één voor één verschijnen in het resulterende markdown, moet u de opeenvolgende optie kiezen. Deze Java‑code laat zien hoe u een presentatie met afbeeldingen naar markdown converteert:

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

Als u wilt dat de afbeeldingen samen verschijnen in het resulterende markdown, moet u de visuele optie kiezen. In dit geval worden afbeeldingen opgeslagen in de huidige map van de applicatie (en wordt er een relatief pad voor hen opgebouwd in het markdown‑document), of u kunt uw voorkeurspad en mapnaam opgeven.

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

Ja. Tekst [hyperlinks](/slides/nl/java/manage-hyperlinks/) blijven bewaard als standaard Markdown‑links. Dia [transitions](/slides/nl/java/slide-transition/) en [animations](/slides/nl/java/powerpoint-animation/) worden niet omgezet.

**Kan ik de conversie versnellen door meerdere threads te gebruiken?**

U kunt paralleliseren per bestand, maar [don’t share](/slides/nl/java/multithreading/) dezelfde [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) instantie niet over threads. Gebruik afzonderlijke instanties/processen per bestand om conflicten te vermijden.

**Wat gebeurt er met afbeeldingen — waar worden ze opgeslagen en zijn de paden relatief?**

[Images](/slides/nl/java/image/) worden geëxporteerd naar een speciale map, en het Markdown‑bestand verwijst standaard naar hen met relatieve paden. U kunt het basis‑uitvoerpad en de asset‑mapnaam configureren om een voorspelbare repository‑structuur te behouden.