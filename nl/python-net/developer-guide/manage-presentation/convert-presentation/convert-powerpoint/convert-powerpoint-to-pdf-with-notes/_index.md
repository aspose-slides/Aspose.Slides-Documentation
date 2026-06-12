---
title: Presentaties converteren naar PDF met notities in Python
linktitle: Presentatie naar PDF met notities
type: docs
weight: 50
url: /nl/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- PPT converteren
- PPTX converteren
- ODP converteren
- PowerPoint naar PDF
- OpenDocument naar PDF
- presentatie naar PDF
- PPT naar PDF
- PPTX naar PDF
- ODP naar PDF
- sprekersnotities
- PDF met notities
- Python
- Aspose.Slides
description: "Converteer de formaten PPT, PPTX en ODP naar PDF met notities met behulp van Aspose.Slides voor Python. Behoud lay‑outs en sprekersnotities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt converteren naar PDF‑formaat met sprekers notities met behulp van Aspose.Slides. Deze gids behandelt de benodigde stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Het conversieproces implementeren om PowerPoint‑dia's om te zetten naar PDF‑documenten terwijl de sprekers notities behouden blijven.
- De output‑PDF aanpassen zodat de sprekers notities worden opgenomen en geformatteerd volgens uw eisen.

## **PowerPoint converteren naar PDF met notities**

De `save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie te converteren naar een PDF met sprekers notities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de lay‑outopties met behulp van de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om sprekers notities op te nemen, en slaat u vervolgens het bestand op als een PDF. Het volgende code‑fragment laat zien hoe u een voorbeeldpresentatie kunt converteren naar een PDF in de Notities‑diaweergave.

```py
with slides.Presentation("sample.pptx") as presentation:

    # Configureer PDF-opties voor het weergeven van sprekersnotities.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Sla de presentatie op als PDF met sprekersnotities.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
U wilt misschien de Aspose [Online PowerPoint naar PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken. 
{{% /alert %}}