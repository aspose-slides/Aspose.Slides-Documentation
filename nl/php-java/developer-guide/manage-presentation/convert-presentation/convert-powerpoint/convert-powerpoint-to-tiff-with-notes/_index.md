---
title: PowerPoint‑presentaties naar TIFF met notities converteren in PHP
linktitle: PowerPoint naar TIFF met notities
type: docs
weight: 100
url: /nl/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar TIFF
- presentatie naar TIFF
- dia naar TIFF
- PPT naar TIFF
- PPTX naar TIFF
- PPT opslaan als TIFF
- PPTX opslaan als TIFF
- PPT exporteren naar TIFF
- PPTX exporteren naar TIFF
- PowerPoint met notities
- presentatie met notities
- dia met notities
- PPT met notities
- PPTX met notities
- TIFF met notities
- PHP
- Aspose.Slides
description: "Converteer PowerPoint‑presentaties naar TIFF met notities met behulp van Aspose.Slides voor PHP via Java. Leer hoe u dia’s met spreker‑notities efficiënt kunt exporteren."
---
## **Introductie**

Aspose.Slides for PHP via Java biedt een eenvoudige oplossing om PowerPoint- en OpenDocument‑presentaties (PPT, PPTX en ODP) met notities naar het TIFF‑formaat te converteren. Dit formaat wordt veel gebruikt voor opslag van beelden van hoge kwaliteit, afdrukken en documentarchivering. Met Aspose.Slides kun je niet alleen volledige presentaties met spreker‑notities exporteren, maar ook miniatuur‑dia’s genereren in de Notities‑dia‑weergave. Het conversie‑proces is eenvoudig en efficiënt en maakt gebruik van de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse om de volledige presentatie om te zetten in een reeks TIFF‑afbeeldingen, met behoud van de notities en lay‑out.

## **Converteer een presentatie naar TIFF met notities**

Het opslaan van een PowerPoint‑ of OpenDocument‑presentatie naar TIFF met notities met behulp van Aspose.Slides for PHP via Java omvat de volgende stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse: laad een PowerPoint‑ of OpenDocument‑bestand.  
2. Configureer de lay‑outopties voor de uitvoer: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/) klasse om op te geven hoe notities en commentaren moeten worden weergegeven.  
3. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) methode.

Stel dat we een bestand "speaker_notes.pptx" hebben met de volgende dia:

![De presentatiedia met notities](slide_with_notes.png)

De onderstaande code‑fragment laat zien hoe de presentatie kan worden geconverteerd naar een TIFF‑afbeelding in de Notities‑dia‑weergave met behulp van de [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) methode.

```php
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Toon de notities onder de dia.

    // Configureer de TIFF-opties met notitie-lay-out.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Sla de presentatie op als TIFF met de spreker-notities.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De TIFF‑afbeelding met notities](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Bekijk Aspose [Gratis PowerPoint‑naar‑Poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik de positie van het notitie‑gebied in de resulterende TIFF regelen?**

Ja. Gebruik de [instellingen voor notitie‑lay‑out](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) om te kiezen tussen opties zoals `None`, `BottomTruncated` of `BottomFull`, die respectievelijk notities verbergen, ze in één pagina passen, of toestaan dat ze doorstromen naar extra pagina's.

**Hoe kan ik de grootte van een TIFF‑bestand met notities verminderen zonder zichtbaar kwaliteitsverlies?**

Kies een [efficiënte compressie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/setcompressiontype/) (bijv. `LZW` of `RLE`), stel een redelijk DPI‑waarde in en, indien acceptabel, gebruik een lager [pixelformaat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/setpixelformat/) (bijvoorbeeld 8 bpp of 1 bpp voor monotoon). Het iets verkleinen van de [afbeeldingsafmetingen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/setimagesize/) kan ook helpen zonder de leesbaarheid merkbaar te verminderen.

**Heeft het lettertype in de notities invloed op het resultaat als de originele lettertypen ontbreken op het systeem?**

Ja. Ontbrekende lettertypen activeren [substitutie](/slides/nl/php-java/font-selection-sequence/), wat de tekstmetingen en het uiterlijk kan wijzigen. Om dit te voorkomen, [lever de vereiste lettertypen](/slides/nl/php-java/custom-font/) of stel een standaard [fallback‑lettertype](/slides/nl/php-java/fallback-font/) in zodat de beoogde lettertypen worden gebruikt.