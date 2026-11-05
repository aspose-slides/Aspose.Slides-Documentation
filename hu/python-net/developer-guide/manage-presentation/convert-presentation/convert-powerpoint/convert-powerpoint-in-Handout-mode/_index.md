---
title: Prezentációk konvertálása Kézikönyv módban Python használatával
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/python-net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- kézikönyv mód
- kézikönyv
- PowerPoint
- prezentáció
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Prezentációk kézikönyvvé konvertálása Pythonban. Állítsa be az oldalankénti diákat, tartsa meg a jegyzeteket, exportáljon PDF-et vagy képeket az Aspose.Slides segítségével, mintakóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Aspose.Slides lehetővé teszi a prezentációk különféle formátumokba történő konvertálását, beleértve a kézikönyvek nyomtatásra való létrehozását Kézikönyv módban. Ez a mód lehetővé teszi, hogy beállítsa, hány dia jelenjen meg egy oldalon, ami hasznos konferenciák, szemináriumok és egyéb események esetén. Engedélyezheti ezt a módot a `slides_layout_options` tulajdonság beállításával a [PdfOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/), és [TiffOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/tiffoptions/) osztályokban.

A kézikönyv oldal méretének és tájolásának exportálás előtti beállításához lásd a [Megjegyzés oldal mérete](/slides/hu/python-net/notes-size/) oldalt.

## **Kézikönyv mód exportálása**

A Kézikönyv mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egy oldalra, valamint egyéb megjelenítési paramétereket.

Az alábbi kódrészlet bemutatja, hogyan konvertáljon egy prezentációt PDF‑be Kézikönyv módban.

```py
import aspose.slides as slides

# Töltsön be egy prezentációt.
with slides.Presentation("sample.pptx") as presentation:

    # Állítsa be az exportálási beállításokat.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 dia egy oldalon vízszintesen
    slides_layout_options.print_slide_numbers = True                                 # diák számának nyomtatása
    slides_layout_options.print_frame_slide = True                                   # keret nyomtatása a diák köré
    slides_layout_options.print_comments = False                                     # nincsenek megjegyzések

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Exportálja a prezentációt PDF-be a kiválasztott elrendezéssel.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
Tartsa szem előtt, hogy a `slides_layout_options` tulajdonság csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, illetve képként történő rendereléskor.
{{% /alert %}} 

## **GYIK**

**Mi a maximális dia bélyegkép száma oldalanként Kézikönyv módban?**

Aspose.Slides támogatja a [presets](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handouttype/) legfeljebb 9 bélyegkép oldalanként vízszintes vagy függőleges sorrendben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyedi rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A bélyegképek száma és sorrendje szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handouttype/) felsorolás által van szabályozva; tetszőleges elrendezések nem támogatottak.

**Tinklhetők rejtett diák a Kézikönyv kimenetben?**

Igen. Engedélyezze a `show_hidden_slides` opciót az export beállításokban a célformátumhoz, például a [PdfOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/) vagy [TiffOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/tiffoptions/) esetén.