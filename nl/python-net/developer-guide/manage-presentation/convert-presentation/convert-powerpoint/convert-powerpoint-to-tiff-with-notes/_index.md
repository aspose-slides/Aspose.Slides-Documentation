---
title: PowerPoint-presentaties converteren naar TIFF met aantekeningen in Python
linktitle: PowerPoint naar TIFF met aantekeningen
type: docs
weight: 100
url: /nl/python-net/convert-powerpoint-to-tiff-with-notes/
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
- PowerPoint met aantekeningen
- presentatie met aantekeningen
- dia met aantekeningen
- PPT met aantekeningen
- PPTX met aantekeningen
- TIFF met aantekeningen
- Python
- Aspose.Slides
description: "PowerPoint-presentaties omzetten naar TIFF met aantekeningen met Aspose.Slides voor Python via .NET. Leer hoe u dia's met spreker‑aantekeningen efficiënt exporteert."
---
## **Inleiding**

Aspose.Slides for Python via .NET biedt een eenvoudige oplossing voor het converteren van PowerPoint‑ en OpenDocument‑presentaties (PPT, PPTX en ODP) met aantekeningen naar het TIFF‑formaat. Dit formaat wordt veel gebruikt voor opslag van afbeeldingen van hoge kwaliteit, afdrukken en documentarchivering. Met Aspose.Slides kunt u niet alleen volledige presentaties met spreker‑aantekeningen exporteren, maar ook miniatuurdia’s genereren in de Notities‑diaweergave. Het conversieproces is eenvoudig en efficiënt, en maakt gebruik van de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse om de volledige presentatie om te zetten naar een reeks TIFF‑afbeeldingen, waarbij de aantekeningen en lay‑out behouden blijven.

## **Een presentatie naar TIFF met aantekeningen converteren**

Het opslaan van een PowerPoint‑ of OpenDocument‑presentatie naar TIFF met aantekeningen met Aspose.Slides for Python via .NET omvat de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse: laad een PowerPoint‑ of OpenDocument‑bestand.
1. Stel de uitvoer‑lay‑outopties in: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om op te geven hoe aantekeningen en opmerkingen moeten worden weergegeven.
1. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions)‑methode.

Stel dat we een bestand “speaker_notes.pptx” hebben met de volgende dia:

![De presentatiedia met spreker‑aantekeningen](slide_with_notes.png)

Het code‑fragment hieronder laat zien hoe u de presentatie kunt omzetten naar een TIFF‑afbeelding in de Notities‑diaweergave met behulp van de [slides_layout_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/slides_layout_options/)‑eigenschap.

```py
# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # Geef de aantekeningen onder de dia weer.
    
    # Configureer de TIFF-opties met notitie‑lay‑out.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # Sla de presentatie op als TIFF met de spreker‑aantekeningen.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Het resultaat:

![De TIFF‑afbeelding met spreker‑aantekeningen](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Bekijk de gratis Aspose [PowerPoint‑naar‑poster‑converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik de positie van het aantekeningen‑gebied in de resulterende TIFF bepalen?**

Ja. Gebruik de [instellingen voor notitie‑lay‑out](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) om te kiezen tussen opties zoals `NONE`, `BOTTOM_TRUNCATED` of `BOTTOM_FULL`, die respectievelijk de aantekeningen verbergen, ze op één pagina passen, of ze laten doorlopen over extra pagina’s.

**Hoe kan ik de grootte van een TIFF‑bestand met aantekeningen verkleinen zonder zichtbaar kwaliteitsverlies?**

Kies een [efficiënte compressie](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/compression_type/) (bijv. `LZW` of `RLE`), stel een redelijke DPI in en, indien acceptabel, gebruik een lager [pixel‑formaat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/pixel_format/) (zoals 8 bpp of 1 bpp voor monochroom). Het iets verkleinen van de [afbeeldingsafmetingen](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/image_size/) kan ook helpen zonder de leesbaarheid merkbaar te schaden.

**Heeft het lettertype in de aantekeningen invloed op het resultaat als de originele lettertypen ontbreken op het systeem?**

Ja. Ontbrekende lettertypen activeren [substitution](/slides/nl/python-net/font-selection-sequence/), wat de tekstmetingen en het uiterlijk kan wijzigen. Om dit te vermijden, [supply the required fonts](/slides/nl/python-net/custom-font/) of stel een standaard‑[fallback font](/slides/nl/python-net/fallback-font/) in zodat de beoogde lettertypen worden gebruikt.