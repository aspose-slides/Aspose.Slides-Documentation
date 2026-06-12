---
title: PowerPoint-presentaties naar Markdown converteren in PHP
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/php-java/convert-powerpoint-to-markdown/
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
- exportPPTX naar MD
- PowerPoint
- presentatie
- Markdown
- PHP
- Aspose.Slides
description: "Converteer PowerPoint-dia’s - PPT, PPTX - naar schone Markdown met Aspose.Slides voor PHP via Java, automatiseer documentatie en behoud de opmaak."
---
## **Inleiding**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties naar Markdown te converteren, wat nuttig kan zijn voor documentatieworkflows, statische site‑generatie, contentmigratie en versie‑gecontroleerde tekstopmaak. De API ondersteunt directe export van PPT‑ en PPTX‑presentaties naar MD‑bestanden en biedt extra opties om te bepalen hoe slide‑inhoud wordt weergegeven in het resulterende Markdown‑document.

U kunt presentaties exporteren als eenvoudige Markdown, kiezen uit meerdere Markdown‑varianten zoals CommonMark en GitHub Flavored Markdown, en configureren hoe afbeeldingen worden behandeld tijdens de export. Voor presentaties met visuele inhoud laat Aspose.Slides u bovendien afbeeldingen opslaan in een aparte map en deze vanuit het gegenereerde Markdown‑bestand refereren.

{{% alert color="warning" %}}

PowerPoint‑naar‑Markdown‑export is standaard **zonder afbeeldingen**. Als u een PowerPoint‑document met afbeeldingen wilt exporteren, moet u `ExportType = MarkdownExportType::Visual` instellen en `BasePath` opgeven, waar de afbeeldingen die in het Markdown‑document worden gerefereerd worden opgeslagen.

{{% /alert %}}

## **Een presentatie converteren naar Markdown**

Deze sectie legt uit hoe Aspose.Slides PowerPoint‑ en OpenDocument‑presentaties (PPT, PPTX, ODP) omzet naar schone Markdown, waarbij de oorspronkelijke slide‑hiërarchie, tekst en opmaak behouden blijven zodat u de inhoud kunt hergebruiken in documentatie of versie‑gecontroleerde workflows zonder extra handmatige inspanning.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse om de presentatie te vertegenwoordigen.
1. Gebruik de [save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save)‑methode om deze te exporteren als een Markdown‑bestand.

Deze PHP‑code toont hoe u een PowerPoint‑presentatie naar Markdown kunt converteren:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Een presentatie converteren naar een Markdown‑variant**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties naar Markdown met basale syntaxis te converteren, evenals naar CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab en zeventien andere Markdown‑varianten.

De volgende PHP‑code laat zien hoe u een PowerPoint‑presentatie naar CommonMark kunt converteren:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

De 23 ondersteunde Markdown‑varianten worden opgesomd in de [Flavor enumeration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/flavor/).

## **Een presentatie met afbeeldingen converteren naar Markdown**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/)‑klasse exposeert eigenschappen en enumeraties waarmee u het resulterende Markdown‑bestand kunt configureren. Bijvoorbeeld, de [MarkdownExportType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownexporttype/)‑enumeratie bepaalt hoe afbeeldingen worden behandeld: `Sequential`, `TextOnly` of `Visual`.

{{% alert color="warning" %}}

Standaard bevat PowerPoint‑naar‑Markdown‑export **geen afbeeldingen**. Om afbeeldingen in te sluiten, roep `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` aan en stel `BasePath` in, zodat wordt aangegeven waar de afbeeldingen die in het Markdown‑bestand worden gerefereerd, moeten worden opgeslagen.

{{% /alert %}}

### **Afbeeldingen sequentieel converteren**

Wanneer u de afbeeldingen afzonderlijk, één voor één, in de gegenereerde Markdown wilt laten verschijnen, moet u de optie `Sequential` kiezen. De volgende PHP‑code toont hoe u een presentatie met afbeeldingen naar Markdown kunt converteren:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Afbeeldingen visueel converteren**

Wanneer u de afbeeldingen gezamenlijk in de gegenereerde Markdown wilt laten verschijnen, moet u de optie `Visual` kiezen. In dat geval worden de afbeeldingen opgeslagen in de huidige map van de applicatie (en er wordt een relatief pad voor hen gegenereerd in het Markdown‑document), of u kunt uw gewenste map en foldernaam opgeven.

De volgende PHP‑code demonstreert de werking:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Blijven hyperlinks behouden bij de export naar Markdown?**

Ja. Tekst-[hyperlinks](/slides/nl/php-java/manage-hyperlinks/) worden behouden als standaard Markdown‑links. Slide-[transitions](/slides/nl/php-java/slide-transition/) en -[animations](/slides/nl/php-java/powerpoint-animation/) worden niet geconverteerd.

**Kan ik de conversie versnellen door deze in meerdere threads uit te voeren?**

U kunt paralleliseren per bestand, maar [deel niet](/slides/nl/php-java/multithreading/) dezelfde [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie niet over threads heen. Gebruik aparte instanties/processen per bestand om conflicten te vermijden.

**Wat gebeurt er met afbeeldingen—waar worden ze opgeslagen en zijn de paden relatief?**

[Afbeeldingen](/slides/nl/php-java/image/) worden geëxporteerd naar een speciale map, en het Markdown‑bestand verwijst standaard naar hen met relatieve paden. U kunt het basis‑outputpad en de naam van de asset‑map configureren om een voorspelbare repositoriumstructuur te behouden.