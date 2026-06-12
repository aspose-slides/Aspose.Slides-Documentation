---
title: PowerPoint-presentaties naar TIFF met notities in .NET
linktitle: PowerPoint naar TIFF met notities
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
- PowerPoint met notities
- presentatie met notities
- dia met notities
- PPT met notities
- PPTX met notities
- TIFF met notities
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-presentaties naar TIFF met notities converteren met Aspose.Slides voor .NET. Leer hoe je dia's met sprekernotities efficiënt kunt exporteren."
---
## **Inleiding**

Aspose.Slides for .NET biedt een eenvoudige oplossing voor het converteren van PowerPoint‑ en OpenDocument‑presentaties (PPT, PPTX en ODP) met notities naar het TIFF‑formaat. Dit formaat wordt veelgebruikt voor opslag van afbeeldingen van hoge kwaliteit, afdrukken en documentarchivering. Met Aspose.Slides kun je niet alleen volledige presentaties met sprekernotities exporteren, maar ook miniatuurafbeeldingen van dia's genereren in de Notitiesdia‑weergave. Het conversieproces is eenvoudig en efficiënt; het maakt gebruik van de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse om de volledige presentatie om te zetten in een reeks TIFF‑afbeeldingen terwijl de notities en lay‑out behouden blijven.

## **Een presentatie naar TIFF met notities converteren**

Het opslaan van een PowerPoint‑ of OpenDocument‑presentatie naar TIFF met notities met Aspose.Slides for .NET omvat de volgende stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse: laad een PowerPoint‑ of OpenDocument‑bestand.  
2. Configureer de opties voor de uitvoer‑lay‑out: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om op te geven hoe notities en opmerkingen moeten worden weergegeven.  
3. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/methods/save/index)‑methode.

Stel dat we een bestand "speaker_notes.pptx" hebben met de volgende dia:

![De presentatiedia met sprekernotities](slide_with_notes.png)

De onderstaande codefragment toont hoe de presentatie te converteren naar een TIFF‑afbeelding in de Notitiesdia‑weergave met behulp van de [SlidesLayoutOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/slideslayoutoptions/)‑eigenschap.

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Configureer de TIFF-opties met Notities lay-out.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Toon de notities onder de dia.
        }
    };

    // Sla de presentatie op als TIFF met de sprekernotities.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Het resultaat:

![De TIFF‑afbeelding met sprekernotities](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Bekijk de gratis PowerPoint‑naar‑Poster‑converter van Aspose [Gratis PowerPoint‑naar‑Poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan ik de positie van het notitiegebied in de resulterende TIFF bepalen?**

Ja. Gebruik de [instellingen voor notitie‑lay‑out](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) om te kiezen tussen opties zoals `None`, `BottomTruncated` of `BottomFull`, die respectievelijk de notities verbergen, ze in één pagina passen, of ze toestaan door te vloeien naar extra pagina's.

**Hoe kan ik de grootte van een TIFF‑bestand met notities verkleinen zonder merkbaar kwaliteitsverlies?**

Kies een [efficiënte compressie](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/compressiontype/) (bijv. `LZW` of `RLE`), stel een redelijk DPI‑aantal in en, indien acceptabel, gebruik een lager [pixel‑formaat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/pixelformat/) (zoals 8 bpp of 1 bpp voor monochroom). Het iets verkleinen van de [afbeeldingsafmetingen](https://reference.aspose.com/slides/nl/net/aspose.slides.export/tiffoptions/imagesize/) kan eveneens helpen zonder de leesbaarheid merkbaar te schaden.

**Heeft het lettertype in de notities invloed op het resultaat als de oorspronkelijke lettertypen ontbreken op het systeem?**

Ja. Ontbrekende lettertypen activeren [substitutie](/slides/nl/net/font-selection-sequence/), wat de tekstmetingen en het uiterlijk kan wijzigen. Om dit te voorkomen, [lever de vereiste lettertypen](/slides/nl/net/custom-font/) of stel een standaard [fallback‑lettertype](/slides/nl/net/fallback-font/) in zodat de beoogde typografieën worden gebruikt.