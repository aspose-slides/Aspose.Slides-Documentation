---
title: Prezentációk konvertálása nyomtatvány módban Python használatával
linktitle: Nyomtatvány mód
type: docs
weight: 150
url: /hu/python-net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- nyomtatvány mód
- nyomtatvány
- PowerPoint
- prezentáció
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Konvertáljon prezentációkat nyomtatványokká Pythonban. Állítsa be az oldalon megjelenő diák számát, tartsa meg a jegyzeteket, exportáljon PDF-re vagy képekre az Aspose.Slides segítségével, minta kóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a prezentációk különböző formátumokba való konvertálását, beleértve a nyomtatványok létrehozását nyomtatásra a Handout módban. Ez a mód lehetővé teszi, hogy beállítsa, hány dia jelenjen meg egy oldalon, ami konferenciák, szemináriumok és egyéb események esetén hasznos. A mód engedélyezhető a `slides_layout_options` tulajdonság beállításával a [PdfOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/) és [TiffOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/tiffoptions/) osztályokban.

## **Nyomtatvány módú exportálás**

A Handout mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerüljön egy oldalra, valamint a többi megjelenítési paramétert.

Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy prezentációt PDF‑be Handout módban.

```py
# Töltsön be egy prezentációt.
with slides.Presentation("sample.pptx") as presentation:

    # Állítsa be az exportálási beállításokat.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 dia egy oldalon vízszintesen
    slides_layout_options.print_slide_numbers = True                                 # nyomtassa ki a dia számait
    slides_layout_options.print_frame_slide = True                                   # nyomtasson keretet a diák köré
    slides_layout_options.print_comments = False                                     # nincsenek megjegyzések

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Exportálja a prezentációt PDF-be a kiválasztott elrendezéssel.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Ne feledje, hogy a `slides_layout_options` tulajdonság csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, illetve képformátumok renderelése esetén.
{{% /alert %}} 

## **GYIK**

**Mi a maximális diaképlet száma oldalanként a nyomtatvány módban?**

Az Aspose.Slides a [handouttype](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handouttype/) beállításban legfeljebb 9 diaképletet támogat oldalanként, vízszintes vagy függőleges elrendezésben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyéni rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A diaképletek száma és elrendezése szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handouttype/) felsorolás által van meghatározva; tetszőleges elrendezések nem támogatottak.

**Toldhatok rejtett diákat a nyomtatvány kimenetbe?**

Igen. Engedélyezze a `show_hidden_slides` opciót a célformátum exportálási beállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/) vagy [TiffOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/tiffoptions/) osztályokban.