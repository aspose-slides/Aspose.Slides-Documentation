---
title: Konvertera PowerPoint-presentationer till PDF med noteringar i Python
linktitle: PowerPoint till PDF med noteringar
type: docs
weight: 50
url: /sv/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera PPT
- konvertera PPTX
- PowerPoint till PDF
- presentation till PDF
- PPT till PDF
- PPTX till PDF
- spara presentation som PDF
- exportera PPT till PDF
- exportera PPTX till PDF
- talarnoter
- PDF med noteringar
- Python
- Java
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till PDF med talarnoter med Aspose.Slides för Python via Java. Konfigurera notplacering och behåll långa noteringar."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint-presentationer till PDF med talarnoter med Aspose.Slides för Python via Java. Du kan inkludera noteringar under varje bild och låta långa noteringar fortsätta på ytterligare sidor. För andra PDF‑exportinställningar, se [Konvertera PowerPoint till PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/).

För att ställa in notsidans dimensioner och orientering innan export, se [Notsidans storlek](/slides/sv/python-java/notes-size/).

## **Konvertera PowerPoint till PDF med noteringar**

Använd [save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save)-metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) för att exportera en PPT‑ eller PPTX‑presentation till PDF. För att inkludera talarnoter, skapa ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/)-objekt och konfigurera notplaceringen med dess [setNotesPosition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)-metod. Tilldela detta layout till [PdfOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/) med [setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Följande exempel laddar `sample.pptx` och exporterar den till `output.pdf` med talarnoter under bilderna:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Konfigurera PDF-alternativ för att rendera talarnoter.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Spara presentationen till PDF med talarnoter.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Du kan också prova [Online PowerPoint till PDF‑konverterare](https://products.aspose.app/slides/sv/conversion).
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag förhindra att långa talarnoter klipps av?**

Använd [NotesPositions.BottomFull](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/#BottomFull), som i exemplet ovan. Den här inställningen visar hela noterna och använder ytterligare sidor vid behov.

**Kan jag hålla varje bild och dess noter på en enda sida?**

Använd [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/#BottomTruncated). Denna inställning begränsar noterna till en sida, så noteringar som inte får plats kan trunkeras.

**Hur exporterar jag bilder utan talarnoter?**

Utelämna konfigurationen av notlayout och använd den standard PDF‑export som beskrivs i [Konvertera PowerPoint till PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/).