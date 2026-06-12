---
title: PowerPoint-presentaties naar Markdown omzetten in JavaScript
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint omzetten
- presentatie omzetten
- slide omzetten
- PPT omzetten
- PPTX omzetten
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
- exportPPTX naar MD
- PowerPoint
- presentatie
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint-slides omzetten in JavaScript - PPT, PPTX - naar nette Markdown met Aspose.Slides voor Node.js via Java, documentatie automatiseren en opmaak behouden."
---
## **Inleiding**

Aspose.Slides stelt u in staat PowerPoint‑presentaties om te zetten naar Markdown, wat nuttig kan zijn voor documentatieworkflows, statische site‑generatie, content‑migratie en versie‑gecontrolleerde tekst‑publicatie. De API ondersteunt directe export van PPT‑ en PPTX‑presentaties naar MD‑bestanden en biedt extra opties om te bepalen hoe de slide‑inhoud wordt weergegeven in het resulterende Markdown‑document.

U kunt presentaties exporteren als platte Markdown, kiezen uit meerdere Markdown‑varianten zoals CommonMark en GitHub Flavored Markdown, en configureren hoe afbeeldingen worden afgehandeld tijdens de export. Voor presentaties met visuele inhoud laat Aspose.Slides u ook afbeeldingen opslaan in een aparte map en hiernaar verwijzen vanuit het gegenereerde Markdown‑bestand.

{{% alert color="warning" %}} 
PowerPoint‑naar‑Markdown‑export gebeurt standaard **zonder afbeeldingen**. Als u een PowerPoint‑document met afbeeldingen wilt exporteren, moet u `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` aanroepen en ook de `BasePath` instellen waar de afbeeldingen die in het Markdown‑document worden verwezen, worden opgeslagen.
{{% /alert %}} 

## **PowerPoint omzetten naar Markdown**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse om een presentatieobject te vertegenwoordigen.  
2. Gebruik de [save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-)‑methode om het object op te slaan als een markdown‑bestand.

Deze JavaScript‑code laat zien hoe u PowerPoint naar markdown omzet:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint omzetten naar Markdown‑variant**

Aspose.Slides maakt het mogelijk PowerPoint om te zetten naar markdown (met basis‑syntaxis), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab en 17 andere markdown‑varianten.

Deze JavaScript‑code laat zien hoe u PowerPoint naar CommonMark omzet:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

De 23 ondersteunde markdown‑varianten staan [listed onder de Flavor‑enumeratie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/flavor/) van de [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/)‑klasse.

## **Presentatie met afbeeldingen omzetten naar Markdown**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownsaveoptions/)‑klasse biedt eigenschappen en enumeraties die u kunt gebruiken om bepaalde opties of instellingen voor het resulterende markdown‑bestand te bepalen. De [MarkdownExportType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markdownexporttype/)‑enum kan bijvoorbeeld worden ingesteld op waarden die bepalen hoe afbeeldingen worden gerenderd of afgehandeld: `Sequential`, `TextOnly`, `Visual`.

### **Afbeeldingen sequentieel omzetten**

Wilt u dat de afbeeldingen één voor één verschijnen in het resulterende markdown‑document, kies dan de sequentiële optie. Deze JavaScript‑code laat zien hoe u een presentatie met afbeeldingen naar markdown omzet:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Afbeeldingen visueel omzetten**

Wilt u dat de afbeeldingen samen verschijnen in het resulterende markdown‑document, kies dan de visuele optie. In dat geval worden afbeeldingen opgeslagen in de huidige map van de applicatie (en wordt er een relatief pad voor hen opgebouwd in het markdown‑document), of u kunt uw eigen pad en mapnaam opgeven.

Deze JavaScript‑code demonstreert de werking:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Blijven hyperlinks behouden na de export naar Markdown?**

Ja. Tekst‑[hyperlinks](/slides/nl/nodejs-java/manage-hyperlinks/) blijven behouden als standaard Markdown‑links. Slide‑[transitions](/slides/nl/nodejs-java/slide-transition/) en -[animations](/slides/nl/nodejs-java/powerpoint-animation/) worden niet geconverteerd.

**Kan ik de conversie versnellen door deze in meerdere threads uit te voeren?**

U kunt paralleliseren per bestand, maar [don’t share](/slides/nl/nodejs-java/multithreading/) dezelfde [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie over threads. Gebruik aparte instanties/processen per bestand om conflicten te voorkomen.

**Wat gebeurt er met afbeeldingen—waar worden ze opgeslagen en zijn de paden relatief?**

[Images](/slides/nl/nodejs-java/image/) worden geëxporteerd naar een speciale map, en het Markdown‑bestand verwijst standaard naar hen met relatieve paden. U kunt het basis‑outputpad en de mapnaam voor assets configureren om een voorspelbare repository‑structuur te behouden.