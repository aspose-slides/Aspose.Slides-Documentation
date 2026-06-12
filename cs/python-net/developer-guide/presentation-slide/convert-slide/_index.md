---
title: Převod snímků PowerPoint na obrázky v Pythonu
linktitle: Snímek na obrázek
type: docs
weight: 41
url: /cs/python-net/convert-slide/
keywords:
- převést snímek
- převést snímek na obrázek
- exportovat snímek jako obrázek
- uložit snímek jako obrázek
- snímek na obrázek
- snímek na PNG
- snímek na JPEG
- snímek na bitmapu
- Python
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Python via .NET převádět snímky PowerPoint a OpenDocument do různých formátů. Jednoduše exportujte snímky PPTX a ODP do BMP, PNG, JPEG, TIFF a dalších formátů s vysokou kvalitou."
---
## **Úvod**

Aspose.Slides for Python via .NET vám umožňuje snadno převádět snímky prezentací PowerPoint a OpenDocument do různých formátů obrázků, včetně BMP, PNG, JPG (JPEG), GIF a dalších.

Chcete‑li převést snímek na obrázek, postupujte podle těchto kroků:

1. Definujte požadovaná nastavení převodu a vyberte snímky, které chcete exportovat, pomocí:
    - třídy [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/), nebo
    - třídy [RenderingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/).
2. Vygenerujte obrázek snímku zavoláním metody `get_image` ze třídy [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/).

V Aspose.Slides for Python via .NET je [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) třída, která vám umožňuje pracovat s obrázky definovanými pixelovými daty. Pomocí instance této třídy můžete ukládat obrázky v široké škále formátů (BMP, JPG, PNG atd.).

## **Převod snímků na bitmapu a uložení obrázků ve formátu PNG**

Snímek můžete převést na objekt bitmapy a použít jej přímo ve své aplikaci. Případně můžete snímek převést na bitmapu a následně uložit obrázek ve formátu JPEG nebo jakémkoli jiném preferovaném formátu.

Tento Python kód ukazuje, jak převést první snímek prezentace na objekt bitmapy a následně uložit obrázek ve formátu PNG:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Převést první snímek v prezentaci na bitmapu.
    with presentation.slides[0].get_image() as image:
        # Uložit obrázek ve formátu PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Převod snímků na obrázky s vlastním rozměrem**

Možná budete potřebovat obrázek o určité velikosti. Pomocí přetížení metody [get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) můžete převést snímek na obrázek s konkrétními rozměry (šířka a výška). 

Ukázkový kód demonstruje, jak to provést:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # Převést první snímek v prezentaci na bitmapu s uvedenou velikostí.
    with presentation.slides[0].get_image(image_size) as image:
        # Uložit obrázek ve formátu JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Některé snímky mohou obsahovat poznámky a komentáře.

Aspose.Slides poskytuje dvě třídy —[TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/) a [RenderingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/) —které vám umožňují řídit vykreslování snímků prezentace do obrázků. Obě třídy obsahují vlastnost `slides_layout_options`, která vám umožňuje konfigurovat vykreslování poznámek a komentářů na snímku při jeho převodu na obrázek.

S třídou [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notescommentslayoutingoptions/) můžete určit preferovanou pozici poznámek a komentářů ve výsledném obrázku.

Tento Python kód ukazuje, jak převést snímek s poznámkami a komentáři:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # Nastavit pozici poznámek.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # Nastavit pozici komentářů.
    notes_comments_options.comments_area_width = 500                                       # Nastavit šířku oblasti komentářů.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # Nastavit barvu oblasti komentářů.

    # Vytvořit možnosti vykreslování.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Převést první snímek prezentace na obrázek.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Uložit obrázek ve formátu GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 

V jakémkoli procesu převodu snímku na obrázek nelze vlastnost [notes_position](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) nastavit na `BOTTOM_FULL` (pro určení pozice poznámek), protože text poznámky může být příliš rozsáhlý a nevejde se do určené velikosti obrázku.

{{% /alert %}} 

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/) poskytuje větší kontrolu nad výsledným TIFF obrázkem tím, že vám umožňuje zadat parametry jako velikost, rozlišení, barevnou paletu a další.

Tento Python kód ukazuje proces převodu, kde jsou použity TIFF možnosti k výstupu černobílého obrázku s rozlišením 300 DPI a velikostí 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Načíst soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:
    # Získat první snímek z prezentace.
    slide = presentation.slides[0]

    # Nastavit konfiguraci výstupního TIFF obrázku.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Nastavit velikost obrázku.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Nastavit formát pixelů (černobílý).
    options.dpi_x = 300                                                        # Nastavit horizontální rozlišení.
    options.dpi_y = 300                                                        # Nastavit vertikální rozlišení.

    # Převést snímek na obrázek s určenými možnostmi.
    with slide.get_image(options) as image:
        # Uložit obrázek ve formátu TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Převod všech snímků na obrázky**

Aspose.Slides vám umožňuje převést všechny snímky v prezentaci na obrázky, čímž prakticky převede celou prezentaci na sérii obrázků.

Ukázkový kód demonstruje, jak v Pythonu převést všechny snímky v prezentaci na obrázky:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Vykreslit prezentaci na obrázky snímek po snímku.
    for i, slide in enumerate(presentation.slides):
        # Ovládat skryté snímky (nevykreslovat skryté snímky).
        if slide.hidden:
            continue

        # Převést snímek na obrázek.
        with slide.get_image(scale_x, scale_y) as image:
            # Uložit obrázek ve formátu JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne, metoda `get_image` ukládá pouze statický obrázek snímku, bez animací.

**Lze skryté snímky exportovat jako obrázky?**

Ano, skryté snímky lze zpracovat stejně jako běžné. Jen se ujistěte, že jsou zahrnuty do smyčky zpracování.

**Lze obrázky uložit se stíny a efekty?**

Ano, Aspose.Slides podporuje vykreslování stínů, průhlednosti a dalších grafických efektů při ukládání snímků jako obrázků.