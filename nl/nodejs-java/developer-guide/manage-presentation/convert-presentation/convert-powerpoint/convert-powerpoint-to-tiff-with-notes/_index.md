---
title: PowerPoint‑presentaties converteren naar TIFF met notities in JavaScript
linktitle: PowerPoint naar TIFF met notities
type: docs
weight: 100
url: /nl/nodejs-java/convert-powerpoint-to-tiff-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint‑presentaties naar TIFF met notities in JavaScript met Aspose.Slides voor Node.js. Leer hoe u dia's efficiënt kunt exporteren met spreker‑notities."
---
## **Inleiding**

Aspose.Slides voor Node.js via Java biedt een eenvoudige oplossing voor het converteren van PowerPoint‑ en OpenDocument‑presentaties (PPT, PPTX en ODP) met notities naar het TIFF‑formaat. Dit formaat wordt veel gebruikt voor het opslaan van afbeeldingen van hoge kwaliteit, voor afdrukken en voor documentarchivering. Met Aspose.Slides kunt u niet alleen volledige presentaties met spreker­notities exporteren, maar ook miniaturen van dia’s genereren in de Notities‑dia‑weergave. Het conversieproces is eenvoudig en efficiënt, waarbij de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse wordt gebruikt om de volledige presentatie om te zetten in een reeks TIFF‑afbeeldingen, waarbij de notities en de lay‑out behouden blijven.

## **Presentatie naar TIFF met notities converteren**

Een PowerPoint‑ of OpenDocument‑presentatie opslaan als TIFF met notities met Aspose.Slides voor Node.js via Java omvat de volgende stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse: laad een PowerPoint‑ of OpenDocument‑bestand.  
2. Configureer de uitvoer‑lay‑outopties: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notescommentslayoutingoptions/)‑klasse om op te geven hoe notities en opmerkingen moeten worden weergegeven.  
3. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save)‑methode.

Stel dat we een bestand “speaker_notes.pptx” hebben met de volgende dia:

![De presentatiedia met spreker­notities](slide_with_notes.png)

De code­fragment hieronder laat zien hoe de presentatie wordt geconverteerd naar een TIFF‑afbeelding in de Notities‑dia‑weergave met behulp van de [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions)‑methode.

```js
// Instantieer de Presentation‑klasse die een presentatie‑bestand representeert.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Geef de notities onder de dia weer.

    // Configureer de TIFF‑opties met notitie‑lay‑out.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sla de presentatie op als TIFF met de spreker‑notities.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De TIFF‑afbeelding met spreker­notities](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Bekijk de Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik de positie van het notitiegebied in de resulterende TIFF bepalen?**

Ja. Gebruik de [notes layout settings](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) om te kiezen tussen opties zoals `None`, `BottomTruncated` of `BottomFull`, die respectievelijk notities verbergen, ze in één pagina passen of ze laten doorlopen naar extra pagina’s.

**Hoe kan ik de grootte van een TIFF‑bestand met notities verkleinen zonder merkbaar kwaliteitsverlies?**

Kies een [efficient compression](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (bijv. `LZW` of `RLE`), stel een redelijke DPI in en, indien acceptabel, gebruik een lager [pixel format](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) (zoals 8 bpp of 1 bpp voor monochroom). Het iets verkleinen van de [image dimensions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/setimagesize/) kan ook helpen zonder de leesbaarheid duidelijk te beïnvloeden.

**Heeft het lettertype in de notities invloed op het resultaat als de originele lettertypen ontbreken op het systeem?**

Ja. Ontbrekende lettertypen activeren [substitution](/slides/nl/nodejs-java/font-selection-sequence/), wat de tekstmetingen en weergave kan veranderen. Om dit te voorkomen, [supply the required fonts](/slides/nl/nodejs-java/custom-font/) of stel een standaard [fallback font](/slides/nl/nodejs-java/fallback-font/) in zodat de beoogde lettertypen worden gebruikt.