---
title: Vytvořte prohlížeč prezentací v Pythonu
linktitle: Prohlížeč prezentací
type: docs
weight: 50
url: /cs/python-net/presentation-viewer/
keywords:
- zobrazit prezentaci
- prohlížeč prezentací
- vytvořit prohlížeč prezentací
- zobrazit PPT
- zobrazit PPTX
- zobrazit ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Zjistěte, jak vytvořit vlastní prohlížeč prezentací v Pythonu pomocí Aspose.Slides. Jednoduše zobrazte soubory PowerPoint (PPTX, PPT) a OpenDocument (ODP) bez Microsoft PowerPoint nebo jiného kancelářského softwaru."
---
## **Úvod**

Aspose.Slides pro Python se používá k vytváření souborů prezentací s diapozitivy. Tyto diapozitivy lze zobrazit otevřením prezentací v Microsoft PowerPointu, například. Vývojáři však mohou někdy potřebovat zobrazit diapozitivy jako obrázky ve svém preferovaném prohlížeči obrázků nebo je použít v vlastním prohlížeči prezentací. V takových případech umožňuje Aspose.Slides exportovat jednotlivé diapozitivy jako obrázky. Tento článek vysvětluje, jak to provést.

## **Vytvořit SVG obrázek z diapozitivu**

Chcete-li vytvořit SVG obrázek z diapozitivu prezentace pomocí Aspose.Slides, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Získejte odkaz na diapozitiv podle jeho indexu.
3. Otevřete souborový proud.
4. Uložte diapozitiv jako SVG obrázek do souborového proudu.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Vytvořit miniaturu diapozitivu**

Aspose.Slides vám pomáhá generovat miniatury diapozitivů. Pro vytvoření miniatury diapozitivu pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Získejte odkaz na diapozitiv podle jeho indexu.
3. Vytvořte miniaturu odkazovaného diapozitivu v požadovaném měřítku.
4. Uložte miniaturu v preferovaném formátu obrázku.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Vytvořit miniaturu diapozitivu s uživatelsky definovanými rozměry**

Pro vytvoření miniatury diapozitivu s uživatelsky definovanými rozměry postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Získejte odkaz na diapozitiv podle jeho indexu.
3. Vygenerujte miniaturu odkazovaného diapozitivu se zadanými rozměry.
4. Uložte miniaturu v preferovaném formátu obrázku.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Vytvořit miniaturu diapozitivu s poznámkami přednášejícího**

Pro vygenerování miniatury diapozitivu s poznámkami přednášejícího pomocí Aspose.Slides postupujte podle následujících kroků:

1. Vytvořte instanci třídy [RenderingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/) .
2. Použijte vlastnost `RenderingOptions.slides_layout_options` k nastavení pozice poznámek přednášejícího.
3. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
4. Získejte odkaz na diapozitiv podle jeho indexu.
5. Vygenerujte miniaturu odkazovaného diapozitivu pomocí možností vykreslování.
6. Uložte miniaturu v preferovaném formátu obrázku.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Ukázkový příklad**

Vyzkoušejte bezplatnou aplikaci [**Aspose.Slides Viewer**](https://products.aspose.app/slides/cs/viewer/), abyste viděli, co můžete implementovat pomocí API Aspose.Slides:

[![Online PowerPoint prohlížeč](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/cs/viewer/)

## **Často kladené otázky**

**Mohu vložit prohlížeč prezentací do webové aplikace ASP.NET?**

Ano. Můžete použít Aspose.Slides na straně serveru k vykreslení diapozitivů jako [obrázky](/slides/cs/python-net/convert-powerpoint-to-png/) nebo [HTML](/slides/cs/python-net/convert-powerpoint-to-html/) a zobrazit je v prohlížeči. Funkce navigace a přiblížení lze implementovat pomocí JavaScriptu pro interaktivní zkušenost.

**Jaký je nejlepší způsob, jak zobrazit diapozitivy v vlastním .NET prohlížeči?**

Doporučený postup je vykreslit každý diapozitiv jako [obrázek](/slides/cs/python-net/convert-powerpoint-to-png/) (např. PNG nebo SVG) nebo jej převést na [HTML](/slides/cs/python-net/convert-powerpoint-to-html/) pomocí Aspose.Slides, a poté zobrazit výstup uvnitř picture boxu (pro desktop) nebo HTML kontejneru (pro web).

**Jak zvládnout velké prezentace s mnoha diapozitivy?**

U velkých prezentací zvažte lazy-loading nebo načítání na požádání (on-demand) vykreslování diapozitivů. To znamená generovat obsah diapozitivu pouze v okamžiku, kdy k němu uživatel přejde, čímž se sníží paměťová náročnost a doba načítání.