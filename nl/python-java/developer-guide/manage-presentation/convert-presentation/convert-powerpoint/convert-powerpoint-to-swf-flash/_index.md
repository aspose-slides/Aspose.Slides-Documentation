---
title: PowerPoint-presentaties converteren naar SWF Flash in Python via Java
linktitle: PowerPoint naar SWF
type: docs
weight: 80
url: /nl/python-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar SWF
- presentatie naar SWF
- dia naar SWF
- PPT naar SWF
- PPTX naar SWF
- PowerPoint naar Flash
- presentatie naar Flash
- dia naar Flash
- PPT naar Flash
- PPTX naar Flash
- PPT opslaan als SWF
- PPTX opslaan als SWF
- PPT exporteren naar SWF
- PPTX exporteren naar SWF
- Python
- Java
- Aspose.Slides
description: "Converteer PowerPoint-presentaties naar SWF Flash in Python via Java met Aspose.Slides. Configureer de viewer, notities, verborgen dia's, compressie en lettertypen."
---
## **Overzicht**

Aspose.Slides for Python via Java stelt u in staat PowerPoint‑presentaties naar SWF te converteren zonder Microsoft PowerPoint. Gebruik [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) om de presentatie te exporteren en [SwfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/swfoptions/) om de viewer‑instellingen, beeldkwaliteit en de lay‑out van notities of opmerkingen te configureren.

## **Presentaties naar Flash converteren**

Laad het bronbestand met [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/), configureer [SwfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/swfoptions/), en sla het op met behulp van [SaveFormat.Swf](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Swf).

Het volgende voorbeeld exporteert `presentation.pptx` naar `presentation.swf`. Het schakelt de ingebedde viewer uit met [setViewerIncluded](https://reference.aspose.com/slides/nl/python-java/aspose.slides/swfoptions/#setViewerIncluded) en voegt spreker‑notities onder de dia's toe met [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Voordat u het voorbeeld uitvoert, [installeer Aspose.Slides for Python via Java](/slides/nl/python-java/installation/) en plaats `presentation.pptx` in de werkmap. De JVM wordt één keer per Python‑proces gestart.

Het voorbeeld past [NotesPositions.BottomFull](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notespositions/#BottomFull) toe via [setNotesPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) en geeft de lay‑out door aan [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Om ook opmerkingen op te nemen, configureert u [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) vóór het exporteren.

## **FAQ**

**Kan ik verborgen dia's opnemen in de SWF?**

Ja. Roep [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) aan met `True`. Standaard worden verborgen dia's niet geëxporteerd.

**Hoe kan ik compressie en de uiteindelijke SWF‑grootte regelen?**

Gebruik [SwfOptions.setCompressed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/swfoptions/#setCompressed) om compressie in of uit te schakelen en [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/nl/python-java/aspose.slides/swfoptions/#setJpegQuality) om de JPEG‑beeldkwaliteit aan te passen. Een lagere JPEG‑kwaliteit kan de bestandsgrootte verkleinen ten koste van de beeldfidelity.

**Waar is de ingebedde viewer voor en wanneer moet ik deze uitschakelen?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/nl/python-java/aspose.slides/swfoptions/#setViewerIncluded) bepaalt of de gegenereerde SWF de viewer bevat. Geef `False` op wanneer u de geëxporteerde dia's zonder de ingebedde viewer nodig heeft, zoals in het bovenstaande voorbeeld.

**Wat gebeurt er als een bronlettertype ontbreekt op de exportmachine?**

U kunt een standaard‑regulier lettertype opgeven met [setDefaultRegularFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), geërfd door [SwfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/swfoptions/). Kies een lettertype dat beschikbaar is voor het exportproces; lettertype‑substitutie kan de weergave en lay‑out van tekst veranderen.