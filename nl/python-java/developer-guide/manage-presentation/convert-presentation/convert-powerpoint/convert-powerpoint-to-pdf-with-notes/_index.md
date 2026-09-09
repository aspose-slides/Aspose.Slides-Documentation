---
title: PowerPoint-presentaties converteren naar PDF met notities in Python
linktitle: PowerPoint naar PDF met notities
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
- sprekernotities
- PDF met notities
- Python
- Java
- Aspose.Slides
description: "Converteer PPT- en PPTX-presentaties naar PDF met sprekernotities met behulp van Aspose.Slides voor Python via Java. Stel de plaatsing van notities in en behoud lange notities."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties naar PDF met spreker­notities kunt converteren met Aspose.Slides voor Python via Java. Je kunt notities onder elke dia opnemen en lange notities laten doorgaan op extra pagina's. Voor andere PDF‑exportinstellingen, zie [Convert PowerPoint to PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/) .

## **PowerPoint naar PDF converteren met notities**

Gebruik de [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse om een PPT‑ of PPTX‑presentatie naar PDF te exporteren. Om spreker­notities op te nemen, maak je een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/)‑object aan en configureer je de notitieplaatsing met de [setNotesPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)‑methode. Wijs deze lay‑out toe aan [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/) via [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) .

Het volgende voorbeeld laadt `sample.pptx` en exporteert het naar `output.pdf` met spreker­notities onder de dia’s:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Configureer PDF-opties voor weergave van sprekernotities.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Sla de presentatie op als PDF met sprekernotities.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}}

Je kunt ook de [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/nl/conversion) proberen.

{{% /alert %}}

## **FAQ**

**Hoe kan ik voorkomen dat lange spreker­notities worden afgekapt?**

Gebruik [NotesPositions.BottomFull](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notespositions/#BottomFull), zoals in het voorbeeld hierboven. Deze instelling geeft de volledige notities weer en gebruikt extra pagina’s indien nodig.

**Kan ik elke dia en de bijbehorende notities op één pagina houden?**

Gebruik [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notespositions/#BottomTruncated). Deze instelling beperkt de notities tot één pagina, waardoor notities die niet passen worden afgekapt.

**Hoe exporteer ik dia's zonder spreker­notities?**

Laat de notitie‑lay‑outconfiguratie weg en gebruik de standaard PDF‑export beschreven in [Convert PowerPoint to PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/) .