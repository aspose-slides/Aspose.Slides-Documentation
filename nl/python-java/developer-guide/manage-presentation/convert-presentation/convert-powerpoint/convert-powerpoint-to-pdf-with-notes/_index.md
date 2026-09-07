---
title: Conversie van PowerPoint-presentaties naar PDF met aantekeningen in Python
linktitle: PowerPoint naar PDF met aantekeningen
type: docs
weight: 50
url: /nl/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint converteren
- presentatie converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PDF
- presentatie naar PDF
- PPT naar PDF
- PPTX naar PDF
- presentatie opslaan als PDF
- PPT exporteren naar PDF
- PPTX exporteren naar PDF
- spreker aantekeningen
- PDF met aantekeningen
- Python
- Java
- Aspose.Slides
description: "Converteer PPT- en PPTX-presentaties naar PDF met aantekeningen van de spreker met Aspose.Slides voor Python via Java. Stel de positie van de aantekeningen in en behoud lange aantekeningen."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties kunt converteren naar PDF met aantekeningen van de spreker met Aspose.Slides voor Python via Java. Je kunt aantekeningen onder elke dia opnemen en lange aantekeningen laten doorgaan op extra pagina’s. Voor andere PDF‑exportinstellingen, zie [Convert PowerPoint to PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/).

## **PowerPoint naar PDF converteren met aantekeningen**

Gebruik de [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)-methode van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse om een PPT‑ of PPTX‑presentatie te exporteren naar PDF. Om aantekeningen van de spreker op te nemen, maak je een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/)‑object aan en configureer je de [setNotesPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)-methode. Wijs deze lay‑out toe aan [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) met behulp van [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Het volgende voorbeeld laadt `sample.pptx` en exporteert het naar `output.pdf` met aantekeningen van de spreker onder de dia’s:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Configureer PDF-opties voor het renderen van spreker aantekeningen.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Sla de presentatie op als PDF met spreker aantekeningen.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}}
Je kunt ook de [Online PowerPoint naar PDF Converter](https://products.aspose.app/slides/nl/conversion) proberen.
{{% /alert %}}

## **Veelgestelde vragen**

**Hoe kan ik voorkomen dat lange aantekeningen afgekapt worden?**

Gebruik [NotesPositions.BottomFull](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notespositions/#BottomFull), zoals in het voorbeeld hierboven. Deze instelling toont de volledige aantekeningen en gebruikt extra pagina’s indien nodig.

**Kan ik elke dia en de bijbehorende aantekeningen op één pagina houden?**

Gebruik [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notespositions/#BottomTruncated). Deze instelling beperkt de aantekeningen tot één pagina, waardoor aantekeningen die niet passen kunnen worden afgekapt.

**Hoe exporteer ik dia's zonder aantekeningen van de spreker?**

Sla de configuratie van de notities‑lay‑out over en gebruik de standaard PDF‑export zoals beschreven in [Convert PowerPoint to PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/).