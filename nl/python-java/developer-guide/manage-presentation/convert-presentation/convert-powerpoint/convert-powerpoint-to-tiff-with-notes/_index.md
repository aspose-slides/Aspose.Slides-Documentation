---
title: "PowerPoint‑presentaties converteren naar TIFF met notities in Python"
linktitle: "PowerPoint naar TIFF met notities"
type: docs
weight: 100
url: /nl/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- "PowerPoint converteren"
- "presentatie converteren"
- "dia converteren"
- "PPT converteren"
- "PPTX converteren"
- "PowerPoint naar TIFF"
- "presentatie naar TIFF"
- "dia naar TIFF"
- "PPT naar TIFF"
- "PPTX naar TIFF"
- "PPT opslaan als TIFF"
- "PPTX opslaan als TIFF"
- "PPT exporteren naar TIFF"
- "PPTX exporteren naar TIFF"
- "PowerPoint met notities"
- "presentatie met notities"
- "dia met notities"
- "PPT met notities"
- "PPTX met notities"
- "TIFF met notities"
- Python
- Java
- Aspose.Slides
description: "Converteer PowerPoint‑presentaties naar TIFF met notities met Aspose.Slides voor Python via Java. Leer hoe u dia's met spreker‑notities efficiënt exporteert."
---
## **Introductie**

Aspose.Slides for Python via Java biedt een eenvoudige oplossing voor het converteren van PowerPoint- en OpenDocument‑presentaties (PPT, PPTX en ODP) met notities naar het TIFF‑formaat. Dit formaat wordt veel gebruikt voor opslag van afbeeldingen van hoge kwaliteit, afdrukken en documentarchivering. Gebruik de [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse om dia’s en hun spreker‑notities te exporteren naar één multipagina‑TIFF‑bestand.

## **Presentatie converteren naar TIFF met notities**

Een PowerPoint‑ of OpenDocument‑presentatie opslaan als TIFF met notities met behulp van Aspose.Slides for Python via Java omvat de volgende stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse: laad een PowerPoint‑ of OpenDocument‑bestand.  
1. Configureer de uitvoer‑lay‑outopties: gebruik de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/)‑klasse om op te geven hoe notities en opmerkingen moeten worden weergegeven.  
1. Sla de presentatie op als TIFF: geef de geconfigureerde opties door aan de [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑methode.

Stel dat we een bestand “speaker_notes.pptx” hebben met de volgende dia:

![De presentatieslide met notities](slide_with_notes.png)

De code‑fragment hieronder laat zien hoe de presentatie kan worden geconverteerd naar een TIFF‑afbeelding in Notities‑dia‑weergave met behulp van de [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions)‑methode.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Toon de volledige spreker-notities onder elke dia.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # Configureer de TIFF-resolutie en de notitie-layout.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Sla de presentatie op als TIFF met spreker-notities.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Het resultaat:

![De TIFF-afbeelding met notities](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Bekijk de gratis Aspose PowerPoint‑naar‑Poster‑converter ([Free PowerPoint to Poster Converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online)).
{{% /alert %}}

## **FAQ**

**Kan ik de positie van het notitiegebied in de resulterende TIFF regelen?**

Ja. Configureer [setNotesPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) met [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notespositions/#BottomTruncated) om notities op één pagina te plaatsen, eventueel af te kappen, of [NotesPositions.BottomFull](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notespositions/#BottomFull) om alle notities weer te geven met extra pagina’s indien nodig. Om dia’s zonder notities te exporteren, laat u de notitie‑lay‑outconfiguratie weg zoals getoond in [Convert PowerPoint to TIFF](/slides/nl/python-java/convert-powerpoint-to-tiff/).

**Hoe kan ik de grootte van een TIFF‑bestand met notities verkleinen zonder kwaliteitsverlies?**

Gebruik lossless [LZW compression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffcompressiontypes/#LZW) via [setCompressionType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/#setCompressionType). Het verlagen van de resolutie of kleurdiepte kan de bestandsgrootte verder verkleinen, maar kan de beeldkwaliteit en leesbaarheid van de notities beïnvloeden. Zie [TIFF export settings](/slides/nl/python-java/convert-powerpoint-to-tiff/) voor meer opties.

**Heeft het lettertype in de notities invloed op het resultaat als de originele lettertypen ontbreken op het systeem?**

Ja. Ontbrekende lettertypen veroorzaken [font substitution](/slides/nl/python-java/font-selection-sequence/), wat de tekstmetriek en het uiterlijk kan veranderen. [Supply the required fonts](/slides/nl/python-java/custom-font/) om de beoogde lettertypen te behouden.