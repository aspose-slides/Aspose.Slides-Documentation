---
title: Presentaties naar PDF converteren met notities in Python
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
- spreker notities
- PDF met notities
- Python
- Aspose.Slides
description: "Converteer de formaten PPT, PPTX en ODP naar PDF met notities met behulp van Aspose.Slides voor Python. Behoud lay-outs en spreker notities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leer je hoe je PowerPoint‑presentaties naar PDF‑formaat met spreker‑notities kunt converteren met Aspose.Slides. Deze gids behandelt de benodigde stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kun je:

- Het conversieproces implementeren om PowerPoint‑dia's om te zetten in PDF‑documenten terwijl de spreker‑notities behouden blijven.
- De output‑PDF aanpassen zodat de spreker‑notities worden opgenomen en geformatteerd volgens jouw eisen.

Om de afmetingen en oriëntatie van de notitiepagina in te stellen vóór export, zie [Notitiepagina‑grootte](/slides/nl/python-net/notes-size/).

## **PowerPoint naar PDF converteren met notities**

De `save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie naar een PDF met spreker‑notities te converteren. Met Aspose.Slides laad je eenvoudig de presentatie, configureer je de layout‑opties met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om spreker‑notities op te nemen, en sla je het bestand vervolgens op als PDF. Het volgende code‑fragment laat zien hoe je een voorbeeldpresentatie converteert naar een PDF in notities‑dia‑weergave.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Configureer PDF-opties voor het renderen van spreker-notities.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Sla de presentatie op als PDF met spreker-notities.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Opmerking" %}}

U kunt de Aspose [Online PowerPoint‑naar‑PDF‑converter](https://products.aspose.app/slides/nl/conversion) bekijken.

{{% /alert %}}