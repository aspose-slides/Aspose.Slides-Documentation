---
title: Konvertera presentationer i handout-läge med Python
linktitle: Handout-läge
type: docs
weight: 150
url: /sv/python-net/convert-powerpoint-in-handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- handout-läge
- handout
- PowerPoint
- presentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Konvertera presentationer till handouts i Python. Ställ in antal bilder per sida, behåll anteckningar, exportera till PDF eller bilder med Aspose.Slides, med exempelprogramkod. Prova gratis."
---
## **Introduktion**

Aspose.Slides ger möjlighet att konvertera presentationer till olika format, inklusive att skapa handouts för utskrift i Handout‑läge. Detta läge låter dig konfigurera hur flera bilder visas på en enda sida, vilket är användbart för konferenser, seminarier och andra evenemang. Du kan aktivera detta läge genom att ange egenskapen `slides_layout_options` i klasserna [PdfOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/), och [TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/).

## **Export av handout‑läge**

För att konfigurera Handout‑läge använder du objektet [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/handoutlayoutingoptions/), som bestämmer hur många bilder som placeras på en ensam sida samt andra visningsparametrar.

Nedan visas ett kodexempel som visar hur du konverterar en presentation till PDF i Handout‑läge.

```py
# Ladda en presentation.
with slides.Presentation("sample.pptx") as presentation:

    # Ställ in exportalternativen.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 bilder på en sida horisontellt
    slides_layout_options.print_slide_numbers = True                                 # skriv ut bildnummer
    slides_layout_options.print_frame_slide = True                                   # skriv ut en ram runt bilderna
    slides_layout_options.print_comments = False                                     # inga kommentarer

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Exportera presentationen till PDF med den valda layouten.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Kom ihåg att egenskapen `slides_layout_options` endast är tillgänglig för vissa utdataformat, såsom PDF, HTML, TIFF och vid rendering som bilder.
{{% /alert %}} 

## **Vanliga frågor**

**Vad är det maximala antalet bildminiatyrer per sida i Handout‑läge?**

Aspose.Slides stöder [presets](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/handouttype/) upp till 9 miniatyrer per sida med horisontell eller vertikal ordning: 1, 2, 3, 4 (horisontell/vertikal), 6 (horisontell/vertikal) och 9 (horisontell/vertikal).

**Kan jag definiera ett eget rutnät, till exempel 5 eller 8 bilder per sida?**

Nej. Antalet och ordningen på miniatyrerna styrs strikt av uppräkningen [HandoutType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/handouttype/); godtyckliga layouter stöds inte.

**Kan jag inkludera dolda bilder i Handout‑utdata?**

Ja. Aktivera alternativet `show_hidden_slides` i exportinställningarna för målformatet, till exempel [PdfOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/), eller [TiffOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/).