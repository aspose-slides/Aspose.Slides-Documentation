---
title: Konvertera presentationer till PDF med noteringar i Python
linktitle: Presentation till PDF med noteringar
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
- PDF med noteringar
- Python
- Aspose.Slides
description: "Konvertera formaten PPT, PPTX och ODP till PDF med noteringar med hjälp av Aspose.Slides för Python. Bevara layouter och talarnoter för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med talarnoter med hjälp av Aspose.Slides. Den här guiden kommer att täcka de nödvändiga stegen och tillhandahålla kodexempel för att hjälpa dig att utföra denna uppgift effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som talarnoterna bevaras.
- Anpassa den genererade PDF-filen för att säkerställa att talarnoterna inkluderas och formateras enligt dina krav.

För att ställa in notssidans dimensioner och orientering före export, se [Notssidans storlek](/slides/sv/python-net/notes-size/).

## **Konvertera PowerPoint till PDF med talarnoter**

Metoden `save` i klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) kan användas för att konvertera en PPT- eller PPTX-presentation till en PDF med talarnoter. Med Aspose.Slides laddar du bara presentationen, konfigurerar layoutalternativen med hjälp av klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/) för att inkludera talarnoter, och sparar sedan filen som en PDF. Följande kodexempel visar hur du konverterar en exempelpresentation till en PDF i Noter‑bild‑vyn.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Konfigurera PDF-alternativ för att rendera talarnoter.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Spara presentationen som PDF med talarnoter.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Du kanske vill kolla in Aspose [Online PowerPoint till PDF-konverterare](https://products.aspose.app/slides/sv/conversion).
{{% /alert %}}