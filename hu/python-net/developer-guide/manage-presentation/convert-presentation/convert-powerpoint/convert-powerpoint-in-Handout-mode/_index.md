---
title: Prezentációk konvertálása kézikönyv módban Python használatával
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- kézikönyv mód
- kézikönyv
- PowerPoint
- prezentáció
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Konvertálja a prezentációkat kézikönyvvé Pythonban. Állítsa be a diákat oldalanként, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekbe az Aspose.Slides segítségével, mintakóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a prezentációk különböző formátumokra történő konvertálását, többek között kézikönyvek létrehozását nyomtatásra a Kézikönyv módban. Ez a mód lehetővé teszi, hogy beállítsa, hogyan jelenjenek meg több dia egyetlen oldalon, ami hasznos konferenciákon, szemináriumokon és egyéb eseményeken. Ezt a módot a `slides_layout_options` tulajdonság beállításával engedélyezheti a [PdfOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/), és [TiffOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/tiffoptions/) osztályokban.

## **Kézikönyv mód exportálása**

A Kézikönyv mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egy oldalra, valamint egyéb megjelenítési paramétereket.

Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy prezentációt PDF-re Kézikönyv módban.

```py
# Prezentáció betöltése.
with slides.Presentation("sample.pptx") as presentation:

    # Exportálási beállítások megadása.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 dia egy oldalon vízszintesen
    slides_layout_options.print_slide_numbers = True                                 # dia számok nyomtatása
    slides_layout_options.print_frame_slide = True                                   # keret nyomtatása a diáknak
    slides_layout_options.print_comments = False                                     # nincsenek megjegyzések

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # A prezentáció exportálása PDF-be a kiválasztott elrendezéssel.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Ne feledje, hogy a `slides_layout_options` tulajdonság csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF esetén, illetve képként történő rendereléskor.
{{% /alert %}} 

## **GYIK**

**Mi a maximális dia bélyegkép szám oldalanként a Kézikönyv módban?**

Az Aspose.Slides [presets](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handouttype/) támogatja legfeljebb 9 bélyegképet oldalanként, vízszintes vagy függőleges elrendezéssel: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyedi rácsot, például 5 vagy 8 dia oldalanként?**

Nem. A bélyegképek száma és elrendezése szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handouttype/) felsorolt típus által van meghatározva; tetszőleges elrendezések nem támogatottak.

**Bele lehet foglalni rejtett diákot a Kézikönyv kimenetbe?**

Igen. Engedélyezze a `show_hidden_slides` beállítást az export beállításokban a célformátumhoz, például a [PdfOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/) vagy [TiffOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/tiffoptions/) esetén.