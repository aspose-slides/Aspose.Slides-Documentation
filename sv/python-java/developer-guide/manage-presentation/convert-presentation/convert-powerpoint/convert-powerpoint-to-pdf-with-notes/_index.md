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
- talarnoteringar
- PDF med noteringar
- Python
- Java
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till PDF med talarnoteringar med hjälp av Aspose.Slides för Python via Java. Konfigurera noteringsplacering och bevara långa noteringar."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint-presentationer till PDF med talarnoteringar med Aspose.Slides för Python via Java. Du kan infoga noteringar under varje bild och låta långa noteringar fortsätta på ytterligare sidor. För andra PDF‑exportinställningar, se [Convert PowerPoint to PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/).

## **Konvertera PowerPoint till PDF med noteringar**

Använd metoden [save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) för klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) för att exportera en PPT‑ eller PPTX‑presentation till PDF. För att inkludera talarnoteringar, skapa ett objekt av typen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/) och konfigurera noteringsplaceringen med dess metod [setNotesPosition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Tilldela detta layout till [PdfOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/) med hjälp av [setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Följande exempel läser in `sample.pptx` och exporterar det till `output.pdf` med talarnoteringar under bilderna:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Konfigurera PDF-alternativ för att rendera talarnoteringar.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Spara presentationen som PDF med talarnoteringar.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Du kan också prova [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion).
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag förhindra att långa talarnoteringar blir avklippta?**  
Använd [NotesPositions.BottomFull](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/#BottomFull), som i exemplet ovan. Denna inställning visar hela noteringarna och använder ytterligare sidor vid behov.

**Kan jag hålla varje bild och dess noteringar på en enda sida?**  
Använd [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/#BottomTruncated). Denna inställning begränsar noteringarna till en sida, så noteringar som inte får plats kan trunkeras.

**Hur exporterar jag bilder utan talarnoteringar?**  
Utelämna konfigurationen för noteringslayout och använd den standard PDF‑export som beskrivs i [Convert PowerPoint to PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/).