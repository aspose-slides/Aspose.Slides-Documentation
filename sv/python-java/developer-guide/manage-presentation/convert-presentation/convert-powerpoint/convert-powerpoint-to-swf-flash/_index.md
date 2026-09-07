---
title: Konvertera PowerPoint-presentationer till SWF Flash i Python via Java
linktitle: PowerPoint till SWF
type: docs
weight: 80
url: /sv/python-java/convert-powerpoint-to-swf-flash/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till SWF
- presentation till SWF
- bild till SWF
- PPT till SWF
- PPTX till SWF
- PowerPoint till Flash
- presentation till Flash
- bild till Flash
- PPT till Flash
- PPTX till Flash
- spara PPT som SWF
- spara PPTX som SWF
- exportera PPT till SWF
- exportera PPTX till SWF
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till SWF Flash i Python via Java med Aspose.Slides. Konfigurera visaren, anteckningar, dolda bilder, komprimering och teckensnitt."
---
## **Översikt**

Aspose.Slides for Python via Java låter dig konvertera PowerPoint‑presentationer till SWF utan Microsoft PowerPoint. Använd [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) för att exportera presentationen och [SwfOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/swfoptions/) för att konfigurera visarinställningar, bildkvalitet och layouten för anteckningar eller kommentarer.

## **Konvertera presentationer till Flash**

Läs in källfilen med [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/), konfigurera [SwfOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/swfoptions/), och spara den med [SaveFormat.Swf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Swf).

Följande exempel exporterar `presentation.pptx` till `presentation.swf`. Det inaktiverar den inbäddade visaren med [setViewerIncluded](https://reference.aspose.com/slides/sv/python-java/aspose.slides/swfoptions/#setViewerIncluded) och inkluderar föreläsaranteckningar under bilderna med hjälp av [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/).

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

Innan du kör exemplet, [install Aspose.Slides for Python via Java](/slides/sv/python-java/installation/) och placera `presentation.pptx` i arbetskatalogen. JVM startas en gång per Python-process.

Exemplet använder [NotesPositions.BottomFull](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/#BottomFull) via [setNotesPosition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) och skickar layouten till [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). För att även inkludera kommentarer, konfigurera [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) innan export.

## **Vanliga frågor**

**Kan jag inkludera dolda bilder i SWF?**

Ja. Anropa [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) med `True`. Som standard exporteras inte dolda bilder.

**Hur kan jag kontrollera komprimering och den slutgiltiga SWF‑storleken?**

Använd [SwfOptions.setCompressed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/swfoptions/#setCompressed) för att aktivera eller inaktivera komprimering och [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/sv/python-java/aspose.slides/swfoptions/#setJpegQuality) för att justera JPEG‑bildkvaliteten. Lägre JPEG‑kvalitet kan minska filstorleken på bekostnad av bildens klarhet.

**Vad är den inbäddade visaren till för, och när bör jag inaktivera den?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/sv/python-java/aspose.slides/swfoptions/#setViewerIncluded) styr om den genererade SWF‑filen inkluderar visaren. Skicka `False` när du behöver de exporterade bilderna utan den inbäddade visaren, som i exemplet ovan.

**Vad händer om ett källteckensnitt saknas på exportmaskinen?**

Du kan ange ett standardvanligt teckensnitt med [setDefaultRegularFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), som ärvs av [SwfOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/swfoptions/). Välj ett teckensnitt som är tillgängligt för exportprocessen; teckensnittsbyte kan ändra textens utseende och layout.