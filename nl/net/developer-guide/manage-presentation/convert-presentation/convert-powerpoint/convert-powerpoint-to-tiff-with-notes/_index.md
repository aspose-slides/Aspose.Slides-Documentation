---
title: PowerPoint‑presentaties converteren naar TIFF met aantekeningen in .NET
linktitle: PowerPoint naar TIFF met aantekeningen
type: docs
weight: 100
url: /nl/net/convert-powerpoint-to-tiff-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint‑presentaties naar TIFF met aantekeningen met behulp van Aspose.Slides voor .NET. Leer hoe u dia’s met spreker‑aantekeningen efficiënt kunt exporteren."
---
## **Introductie**

Aspose.Slides for .NET biedt een eenvoudige oplossing voor het converteren van PowerPoint‑ en OpenDocument‑presentaties (PPT, PPTX en ODP) met aantekeningen naar het TIFF‑formaat. Dit formaat wordt veel gebruikt voor opslag van afbeeldingen van hoge kwaliteit, afdrukken en documentarchivering. Met Aspose.Slides kunt u niet alleen volledige presentaties met spreker‑aantekeningen exporteren, maar ook miniatuur‑dia’s genereren in de Notities‑dia‑weergave. Het conversieproces is eenvoudig en efficiënt en maakt gebruik van de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse om de volledige presentatie om te zetten in een reeks TIFF‑afbeeldingen, waarbij de aantekeningen en lay‑out behouden blijven.

## **Presentatie converteren naar TIFF met aantekeningen**

Een PowerPoint‑ of OpenDocument‑presentatie opslaan als TIFF met aantekeningen met behulp van Aspose.Slides for .NET omvat de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse: laad een PowerPoint‑ of OpenDocument‑bestand.  
1. Configureer de uitvoer‑lay‑outopties: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om op te geven hoe aantekeningen en opmerkingen moeten worden weergegeven.  
1. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/methods/save/index)‑methode.

Stel dat we een bestand “speaker_notes.pptx” hebben met de volgende dia:

![De presentatiedia met spreker‑aantekeningen](slide_with_notes.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Configureer de TIFF-opties met notitie-lay-out.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Toon de aantekeningen onder de dia.
        }
    };

    // Sla de presentatie op als TIFF met de spreker-aantekeningen.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Het resultaat:

![De TIFF‑afbeelding met spreker‑aantekeningen](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Bekijk de gratis Aspose [PowerPoint‑naar‑poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Kan ik de positie van het aantekeningsgebied in de resulterende TIFF regelen?

Ja. Gebruik de [notes layout settings](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) om te kiezen tussen opties zoals `None`, `BottomTruncated` of `BottomFull`, die respectievelijk de aantekeningen verbergen, ze op één pagina passen, of ze laten doorlopen naar extra pagina’s.

### Hoe kan ik de grootte van een TIFF‑bestand met aantekeningen verkleinen zonder merkbaar kwaliteitsverlies?

Kies een [efficiënte compressie](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/compressiontype/) (bijv. `LZW` of `RLE`), stel een redelijk DPI‑waarde in en, indien acceptabel, gebruik een lager [pixel format](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/pixelformat/) (zoals 8 bpp of 1 bpp voor monochroom). Het iets verkleinen van de [image dimensions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/imagesize/) kan ook helpen zonder de leesbaarheid duidelijk te schaden.

### Heeft het lettertype in de aantekeningen invloed op het resultaat als de oorspronkelijke lettertypen ontbreken op het systeem?

Ja. Ontbrekende lettertypen activeren [substitutie](/slides/nl/net/font-selection-sequence/), wat de tekstmetriek en het uiterlijk kan veranderen. Om dit te vermijden, [lever de benodigde lettertypen](/slides/nl/net/custom-font/) of stel een standaard [fallback font](/slides/nl/net/fallback-font/) in zodat de bedoelde lettertypen worden gebruikt.