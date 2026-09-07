---
title: Konvertera PowerPoint-presentationer till PDF med anteckningar i Python
linktitle: PowerPoint till PDF med anteckningar
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
- presentatörsanteckningar
- PDF med anteckningar
- Python
- Java
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till PDF med presentatörsanteckningar med Aspose.Slides för Python via Java. Konfigurera anteckningsplacering och bevara långa anteckningar."
---
## **Översikt**

Denna artikel förklarar hur du konverterar PowerPoint‑presentationer till PDF med presentatörsanteckningar med Aspose.Slides för Python via Java. Du kan inkludera anteckningar under varje bild och låta långa anteckningar fortsätta på ytterligare sidor. För andra PDF‑exportinställningar, se [Convert PowerPoint to PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/).

## **Konvertera PowerPoint till PDF med anteckningar**

Använd metoden [save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) för klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) för att exportera en PPT‑ eller PPTX‑presentation till PDF. För att inkludera presentatörsanteckningar, skapa ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/)‑objekt och konfigurera dess [setNotesPosition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)‑metod. Tilldela denna layout till [PdfOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/) med hjälp av [setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Följande exempel laddar `sample.pptx` och exporterar den till `output.pdf` med presentatörsanteckningar under bilderna:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Konfigurera PDF-alternativ för att rendera presentatörsanteckningar.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Spara presentationen som PDF med presentatörsanteckningar.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Du kan också prova [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion).
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag förhindra att långa presentatörsanteckningar kapas av?**

Använd [NotesPositions.BottomFull](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/#BottomFull), som i exemplet ovan. Denna inställning visar hela anteckningarna och använder extra sidor vid behov.

**Kan jag hålla varje bild och dess anteckningar på en enda sida?**

Använd [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/#BottomTruncated). Denna inställning begränsar anteckningarna till en sida, så anteckningar som inte får plats kan trunkeras.

**Hur exporterar jag bilder utan presentatörsanteckningar?**

Utelämna konfigurationen för anteckningslayouten och använd den standard PDF‑export som beskrivs i [Convert PowerPoint to PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/).