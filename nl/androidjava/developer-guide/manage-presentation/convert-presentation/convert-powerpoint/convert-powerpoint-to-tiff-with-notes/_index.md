---
title: Convert PowerPoint Presentations to TIFF with Notes on Android
linktitle: PowerPoint to TIFF with Notes
type: docs
weight: 100
url: /nl/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- PowerPoint met aantekeningen
- presentatie met aantekeningen
- dia met aantekeningen
- PPT met aantekeningen
- PPTX met aantekeningen
- TIFF met aantekeningen
- Android
- Java
- Aspose.Slides
description: "PowerPoint‑presentaties converteren naar TIFF met aantekeningen met behulp van Aspose.Slides voor Android via Java. Leer efficiënt dia’s met spreker­aantekeningen exporteren."
---
## **Inleiding**

Aspose.Slides for Android via Java biedt een eenvoudige oplossing voor het converteren van PowerPoint- en OpenDocument‑presentaties (PPT, PPTX en ODP) met aantekeningen naar het TIFF‑formaat. Dit formaat wordt veel gebruikt voor opslag van hoge kwaliteit afbeeldingen, afdrukken en documentarchivering. Met Aspose.Slides kunt u niet alleen volledige presentaties met spreker­aantekeningen exporteren, maar ook miniaturen van dia’s genereren in de Notities‑dia‑weergave. Het conversieproces is eenvoudig en efficiënt en maakt gebruik van de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse om de volledige presentatie om te zetten naar een reeks TIFF‑beelden, met behoud van de aantekeningen en lay‑out.

## **Een presentatie naar TIFF met aantekeningen converteren**

Een PowerPoint- of OpenDocument‑presentatie opslaan als TIFF met aantekeningen met Aspose.Slides for Android via Java gebeurt in de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse: laad een PowerPoint‑ of OpenDocument‑bestand.  
1. Stel de uitvoer‑lay‑outopties in: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notescommentslayoutingoptions/)‑klasse om te bepalen hoe aantekeningen en opmerkingen worden weergegeven.  
1. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑methode.

Stel dat we een bestand “speaker_notes.pptx” hebben met de volgende dia:

![The presentation slide with speaker notes](slide_with_notes.png)

De codefragment hieronder toont hoe u de presentatie naar een TIFF‑afbeelding in Notities‑dia‑weergave converteert met de [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)‑methode.

```java
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Geef de aantekeningen onder de dia weer.

    // Configureer de TIFF-opties met notitie-lay-out.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sla de presentatie op als TIFF met de spreker-aantekeningen.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Bekijk de gratis Aspose [PowerPoint‑naar‑Poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Kan ik de positie van het aantekeningsgebied in de resulterende TIFF bepalen?**

Ja. Gebruik de [notes layout settings](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) om te kiezen tussen opties zoals `None`, `BottomTruncated` of `BottomFull`, die respectievelijk de aantekeningen verbergen, ze in één pagina passen of toestaan dat ze doorlopen naar extra pagina’s.

**Hoe kan ik de bestandsgrootte van een TIFF‑bestand met aantekeningen verkleinen zonder merkbaar kwaliteitsverlies?**

Kies een [efficient compression](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (bijv. `LZW` of `RLE`), stel een redelijke DPI in en, mits acceptabel, gebruik een lager [pixel format](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (zoals 8 bpp of 1 bpp voor monochroom). Het iets verkleinen van de [image dimensions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) kan ook helpen zonder de leesbaarheid merkbaar te verminderen.

**Heeft het lettertype in de aantekeningen invloed op het resultaat als de originele lettertypen niet op het systeem aanwezig zijn?**

Ja. Ontbrekende lettertypen activeren een [substitution](/slides/nl/androidjava/font-selection-sequence/), wat de tekstopmaak en het uiterlijk kan wijzigen. Om dit te voorkomen, [supply the required fonts](/slides/nl/androidjava/custom-font/) of stel een standaard [fallback font](/slides/nl/androidjava/fallback-font/) in zodat de gewenste lettertypen worden gebruikt.