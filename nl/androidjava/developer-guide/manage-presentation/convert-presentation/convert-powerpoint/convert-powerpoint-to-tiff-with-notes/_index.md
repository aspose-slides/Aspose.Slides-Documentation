---
title: PowerPoint-presentaties naar TIFF met notities op Android
linktitle: PowerPoint naar TIFF met notities
type: docs
weight: 100
url: /nl/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint converteren
- presentatie converteren
- slide converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar TIFF
- presentatie naar TIFF
- slide naar TIFF
- PPT naar TIFF
- PPTX naar TIFF
- PPT opslaan als TIFF
- PPTX opslaan als TIFF
- PPT exporteren naar TIFF
- PPTX exporteren naar TIFF
- PowerPoint met notities
- presentatie met notities
- slide met notities
- PPT met notities
- PPTX met notities
- TIFF met notities
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint-presentaties naar TIFF met notities met behulp van Aspose.Slides voor Android via Java. Leer hoe u dia's met spreker-notities efficiënt kunt exporteren."
---
## **Inleiding**

Aspose.Slides for Android via Java biedt een eenvoudige oplossing voor het converteren van PowerPoint‑ en OpenDocument‑presentaties (PPT, PPTX en ODP) met notities naar het TIFF‑formaat. Dit formaat wordt veel gebruikt voor hoogwaardige beeldopslag, afdrukken en documentarchivering. Met Aspose.Slides kun je niet alleen volledige presentaties met spreker‑notities exporteren, maar ook miniatuur‑slides genereren in de Notities‑slide‑weergave. Het conversieproces is eenvoudig en efficiënt en maakt gebruik van de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse om de volledige presentatie om te zetten in een reeks TIFF‑beelden, waarbij de notities en lay‑out behouden blijven.

## **Een presentatie naar TIFF met notities converteren**

Het opslaan van een PowerPoint‑ of OpenDocument‑presentatie naar TIFF met notities met Aspose.Slides for Android via Java omvat de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse: laadt een PowerPoint‑ of OpenDocument‑bestand.  
2. Configureer de uitvoer‑lay‑outopties: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notescommentslayoutingoptions/)‑klasse om op te geven hoe notities en opmerkingen moeten worden weergegeven.  
3. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑methode.

Stel dat we een bestand “speaker_notes.pptx” hebben met de volgende slide:

![De presentatieslide met sprekernotities](slide_with_notes.png)

De code‑fragment hieronder toont hoe je de presentatie converteert naar een TIFF‑beeld in de Notities‑slide‑weergave met de [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)‑methode.

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Geef de notities onder de slide weer.

    // Configureer de TIFF-opties met notitie-lay-out.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sla de presentatie op als TIFF met de spreker-notities.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Het TIFF‑beeld met sprekernotities](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Bekijk de gratis PowerPoint‑naar‑poster converter van Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Kan ik de positie van het notitiegebied in de gegenereerde TIFF regelen?

Ja. Gebruik de [notes layout settings](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) om te kiezen uit opties zoals `None`, `BottomTruncated` of `BottomFull`, die respectievelijk notities verbergen, ze in één pagina passen of laten doorlopen over extra pagina’s.

### Hoe kan ik de grootte van een TIFF‑bestand met notities verkleinen zonder merkbaar kwaliteitsverlies?

Kies een [efficiënte compressie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (bijv. `LZW` of `RLE`), stel een redelijk DPI‑waarde in en, indien acceptabel, gebruik een lager [pixel format](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (zoals 8 bpp of 1 bpp voor monochroom). Het iets verkleinen van de [image dimensions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) kan ook helpen zonder de leesbaarheid merkbaar te beïnvloeden.

### Heeft het lettertype in de notities invloed op het resultaat als de oorspronkelijke lettertypen ontbreken op het systeem?

Ja. Ontbrekende lettertypen activeren een [substitution](/slides/nl/androidjava/font-selection-sequence/), wat de tekstmetrics en weergave kan veranderen. Om dit te voorkomen, [lever de benodigde lettertypen](/slides/nl/androidjava/custom-font/) of stel een standaard [fallback font](/slides/nl/androidjava/fallback-font/) in zodat de beoogde lettertypes worden gebruikt.