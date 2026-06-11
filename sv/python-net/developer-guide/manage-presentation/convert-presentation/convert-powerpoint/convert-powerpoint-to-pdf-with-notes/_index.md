---
title: Konvertera presentationer till PDF med anteckningar i Python
linktitle: Presentation till PDF med anteckningar
type: docs
weight: 50
url: /sv/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- konvertera PPT
- konvertera PPTX
- konvertera ODP
- PowerPoint till PDF
- OpenDocument till PDF
- presentation till PDF
- PPT till PDF
- PPTX till PDF
- ODP till PDF
- talarnoter
- PDF med anteckningar
- Python
- Aspose.Slides
description: "Konvertera formaten PPT, PPTX och ODP till PDF med anteckningar med hjälp av Aspose.Slides för Python. Bevara layouter och talarnoter för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint‑presentationer till PDF‑format med talarnoter med hjälp av Aspose.Slides. Denna guide täcker de nödvändiga stegen och ger kodexempel för att hjälpa dig att utföra uppgiften effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint‑bilder till PDF‑dokument samtidigt som talarnoterna bevaras.
- Anpassa den genererade PDF‑filen så att talarnoterna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med anteckningar**

`save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) kan användas för att konvertera en PPT‑ eller PPTX‑presentation till en PDF med talarnoter. Med Aspose.Slides laddar du bara presentationen, konfigurerar layoutalternativen med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/) för att inkludera talarnoter och sparar sedan filen som PDF. Följande kodsnutt visar hur du konverterar en exempel‑presentation till en PDF i vy med noteringsbilder.

```py
with slides.Presentation("sample.pptx") as presentation:

    # Konfigurera PDF-alternativ för att rendera talarnoter.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Spara presentationen till PDF med talarnoter.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
Du kanske vill kolla in Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion). 
{{% /alert %}}