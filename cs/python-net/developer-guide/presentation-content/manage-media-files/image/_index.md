---
title: Optimalizace správy obrázků v PowerPointu s Pythonem
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/python-net/image/
keywords:
- přidat obrázek
- přidat obrázek
- přidat bitmapu
- nahradit obrázek
- nahradit obrázek
- z webu
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- přidat EMF
- přidat WMF
- přidat TIFF
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zefektivněte správu obrázků v PowerPointu a OpenDocument pomocí Aspose.Slides pro Python přes .NET, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavější a zajímavější. V Microsoft PowerPoint můžete do snímků vkládat obrázky ze souboru, internetu nebo jiných zdrojů. Podobně Aspose.Slides vám umožňuje přidávat obrázky na snímky několika způsoby.

{{% alert  title="Tip" color="primary" %}}
Aspose poskytuje zdarma převodníky —[JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt)—které vám umožní rychle vytvořit prezentace z obrázků.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Pokud chcete přidat obrázek jako objekt rámečku – zejména pokud plánujete použít standardní možnosti formátování, jako je změna velikosti nebo aplikace efektů – podívejte se na [Přidání rámečků obrázků do prezentací s Pythonem](https://docs.aspose.com/slides/cs/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Můžete použít operace I/O obrazu a prezentace k převodu obrázků mezi formáty. Viz tyto stránky: převést [obrázek na JPG](https://products.aspose.com/slides/cs/python-net/conversion/image-to-jpg/); převést [JPG na obrázek](https://products.aspose.com/slides/cs/python-net/conversion/jpg-to-image/); převést [JPG na PNG](https://products.aspose.com/slides/cs/python-net/conversion/jpg-to-png/); převést [PNG na JPG](https://products.aspose.com/slides/cs/python-net/conversion/png-to-jpg/); převést [PNG na SVG](https://products.aspose.com/slides/cs/python-net/conversion/png-to-svg/); a převést [SVG na PNG](https://products.aspose.com/slides/cs/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides podporuje práci s obrázky v běžných formátech, jako jsou JPEG, PNG, BMP, GIF a další.

## **Přidání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo více obrázků z počítače na snímek v prezentaci. Následující příklad v Pythonu ukazuje, jak přidat obrázek na snímek:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání obrázků z webu do snímků**

Pokud obrázek, který chcete přidat na snímek, není k dispozici ve vašem počítači, můžete jej vložit přímo z webu.

Následující příklad v Pythonu ukazuje, jak přidat obrázek z URL na snímek:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Stáhněte syrová data obrázku.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání obrázků do hlavního snímku**

Master slide je vrchní úroveň snímku, která ukládá a řídí informace – motiv, rozvržení a podobně – pro všechny snímky pod ní. Když přidáte obrázek do master slide, tento obrázek se objeví na každém snímku, který tento master používá.

Následující příklad v Pythonu ukazuje, jak přidat obrázek do master slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání obrázků jako pozadí snímků**

Můžete použít obrázek jako pozadí pro jeden nebo více snímků. Podrobnosti najdete v *[Nastavení obrázků jako pozadí snímků](/slides/cs/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Obsah SVG lze do prezentace přidat pomocí třídy [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/). Výsledný SVG obrázek lze poté přidat do kolekce obrázků prezentace a použít k vytvoření rámečku obrázku.

Následující příklad v Pythonu importuje samostatný řetězec SVG. Všechny obrázky, styly a další zdroje použité v tomto SVG jsou vloženy přímo do obsahu SVG.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Převod SVG na sadu tvarů**

Aspose.Slides převádí SVG na sadu tvarů podobně jako PowerPoint zachází s SVG.

![PowerPoint Popup Menu](img_01_01.png)

Tato funkčnost je poskytována přetížením metody [add_group_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_group_shape/) ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/), která přijímá [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/) jako svůj první argument.

Ukázkový kód níže ukazuje, jak převést soubor SVG na sadu tvarů.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Přečtěte obsah souboru SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Vytvořte objekt SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Získejte velikost snímku.
        slide_size = presentation.slide_size.size

        # Převést SVG obrázek na skupinu tvarů a upravit jeho velikost podle velikosti snímku.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Uložte prezentaci ve formátu PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání obrázků jako EMF na snímky**

Aspose.Slides pro Python vám umožňuje vkládat obrázky Enhanced Metafile (EMF) do prezentací.

Následující příklad v Pythonu to demonstruje:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Nahrazení obrázků v kolekci obrázků**

Aspose.Slides vám umožňuje nahradit obrázky uložené v kolekci obrázků prezentace, včetně těch použité v tvarech snímků. Tato sekce popisuje několik přístupů k aktualizaci obrázků v kolekci. API poskytuje jednoduché metody pro nahrazení obrázku surovými bajty, instancí [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) nebo jiným obrázkem, který již v kolekci existuje.

Postupujte podle těchto kroků:

1. Načtěte prezentaci, která obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Načtěte nový obrázek ze souboru do pole bajtů.
1. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.
1. Případně načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.
1. Nebo nahraďte cílový obrázek obrázkem, který již v kolekci obrázků prezentace existuje.
1. Uložte upravenou prezentaci jako soubor PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:

    # První způsob.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # Druhý způsob.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # Třetí způsob.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Uložte prezentaci do souboru.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
S bezplatným převodníkem Aspose [Text na GIF](https://products.aspose.app/slides/cs/text-to-gif) můžete snadno animovat text a vytvářet GIFy z textu.
{{% /alert %}}

## **Často kladené otázky**

**Zůstane původní rozlišení obrázku po vložení nedotčeno?**

Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [obrázek](/slides/cs/python-net/picture-frame/) na snímku měněn velikostí a na případné kompresi při ukládání.

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítky snímků?**

Umístěte logo na master slide nebo na rozvržení a nahraďte jej v kolekci obrázků prezentace – aktualizace se projeví ve všech prvcích, které tento zdroj používají.

**Lze vložené SVG převést na editovatelné tvary?**

Ano. SVG můžete převést na skupinu tvarů, po které se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvarů.

**Jak mohu nastavit obrázek jako pozadí pro více snímků najednou?**

[Přiřaďte obrázek jako pozadí](/slides/cs/python-net/presentation-background/) na master slide nebo příslušné rozvržení – všechny snímky používající tento master/rozvržení zdědí pozadí.

**Jak zabránit tomu, aby se prezentace kvůli mnoha obrázkům stala příliš velkou?**

Znovu použijte jeden zdroj obrázku místo duplicit, zvolte rozumné rozlišení, při ukládání aplikujte kompresi a opakující se grafiku umístěte na master slide, kde je to vhodné.