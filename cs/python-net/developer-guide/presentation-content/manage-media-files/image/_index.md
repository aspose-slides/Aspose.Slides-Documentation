---
title: Optimalizace správy obrázků v PowerPointu pomocí Pythonu
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
- prezentace
- Python
- Aspose.Slides
description: "Zjednodušte správu obrázků v PowerPointu a OpenDocument pomocí Aspose.Slides pro Python přes .NET, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a zajímavějšími. V Microsoft PowerPoint můžete do snímků vložit obrázky ze souboru, internetu nebo jiných zdrojů. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků několika způsoby.

{{% alert  title="Tip" color="primary" %}}
Aspose poskytuje bezplatné převodníky — [JPEG to PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG to PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt) — které vám umožní rychle vytvořit prezentace z obrázků.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Pokud chcete přidat obrázek jako rámec — zejména pokud plánujete použít standardní možnosti formátování, jako je změna velikosti nebo aplikace efektů — viz [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/cs/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Upozornění" color="warning" %}}
Můžete použít operace I/O pro obrázky a prezentace k převodu obrázků mezi formáty. Podívejte se na tyto stránky: převést [obrázek na JPG](https://products.aspose.com/slides/cs/python-net/conversion/image-to-jpg/); převést [JPG na obrázek](https://products.aspose.com/slides/cs/python-net/conversion/jpg-to-image/); převést [JPG na PNG](https://products.aspose.com/slides/cs/python-net/conversion/jpg-to-png/); převést [PNG na JPG](https://products.aspose.com/slides/cs/python-net/conversion/png-to-jpg/); převést [PNG na SVG](https://products.aspose.com/slides/cs/python-net/conversion/png-to-svg/); a převést [SVG na PNG](https://products.aspose.com/slides/cs/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides podporuje práci s obrázky v populárních formátech, jako jsou JPEG, PNG, BMP, GIF a další.

## **Přidání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo více obrázků z počítače do snímku v prezentaci. Následující příklad v Pythonu ukazuje, jak přidat obrázek do snímku:

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

Není-li obrázek, který chcete přidat do snímku, k dispozici ve vašem počítači, můžete jej vložit přímo z webu.

Následující příklad v Pythonu ukazuje, jak přidat obrázek z URL do snímku:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání obrázků do hlavních snímků (Slide Masters)**

Slide master je hlavní snímek nejvyšší úrovně, který ukládá a řídí informace — témata, rozvržení a podobně — pro všechny podřízené snímky. Když přidáte obrázek do slide masteru, tento obrázek se objeví na každém snímku, který tento master používá.

Následující příklad v Pythonu ukazuje, jak přidat obrázek do slide masteru:

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

## **Nastavení obrázku jako pozadí snímku**

Můžete chtít použít obrázek jako pozadí konkrétního snímku nebo více snímků. Podrobnosti najdete v [Set an Image as the Background for a Slide](https://docs.aspose.com/slides/cs/python-net/presentation-background/#set-image-as-background-for-slide).

## **Přidání SVG do prezentací**

Můžete vložit libovolný obrázek do prezentace pomocí metody [add_picture_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_picture_frame/) třídy [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/).

Pro vytvoření objektu obrázku ze souboru SVG postupujte podle následujících kroků:

1. Vytvořte [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/) a přidejte jej do kolekce obrázků prezentace.  
2. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) z [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/).  
3. Vytvořte objekt [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) pomocí [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/).

Následující ukázka v Pythonu ukazuje, jak přidat SVG obrázek do prezentace pomocí těchto kroků:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Načtěte obsah souboru SVG.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Vytvořte objekt SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Vytvořte objekt PPImage.
        pp_image = presentation.images.add_image(svg_image)

        # Vytvořte nový PictureFrame.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Uložte prezentaci ve formátu PPTX.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Převod SVG na sadu tvarů**

Aspose.Slides převádí SVG soubory na sadu tvarů podobně jako PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Tato funkčnost je poskytována přetížením metody [add_group_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_group_shape/) ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/), která jako první argument přijímá [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/). 

Následující ukázkový kód ukazuje, jak převést soubor SVG na sadu tvarů.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Načtěte obsah souboru SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Vytvořte objekt SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Získejte velikost snímku.
        slide_size = presentation.slide_size.size

        # Převěďte SVG obrázek na skupinu tvarů a upravte jeho měřítko podle velikosti snímku.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Uložte prezentaci ve formátu PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání obrázků jako EMF do snímků**

Aspose.Slides pro Python umožňuje vkládat obrázky Enhanced Metafile (EMF) do prezentací.

Následující příklad v Pythonu to demonstruje:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Nahrazení obrázků v kolekci obrázků**

Aspose.Slides vám umožňuje nahradit obrázky uložené v kolekci obrázků prezentace, včetně těch, které jsou použity tvary snímků. V této části jsou popsány různé přístupy k aktualizaci obrázků v kolekci. API poskytuje jednoduché metody pro nahrazení obrázku surovými bajty, instancí [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) nebo jiným obrázkem, který již v kolekci existuje.

Postupujte podle těchto kroků:

1. Načtěte prezentaci, která obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).  
2. Načtěte nový obrázek ze souboru do pole bytů.  
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bytů.  
4. Alternativně načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.  
5. Nebo nahraďte cílový obrázek obrázkem, který již existuje v kolekci obrázků prezentace.  
6. Uložte upravenou prezentaci jako soubor PPTX.

```py
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
S bezplatným převodníkem [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) od Aspose můžete snadno animovat text a vytvářet GIFy z textu.
{{% /alert %}}

## **FAQ**

**Zůstane po vložení zachována původní rozlišení obrázku?**

Ano. Zdrojové pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [picture](/slides/cs/python-net/picture-frame/) na snímku škálováno a jaká komprese je použita při ukládání.

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítkách snímků?**

Umístěte logo na master slide nebo rozvržení a nahraďte jej v kolekci obrázků prezentace — aktualizace se projeví ve všech prvcích, které tento zdroj používají.

**Lze vložený SVG převést na editovatelné tvary?**

Ano. SVG můžete převést na skupinu tvarů, po čemž se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvarů.

**Jak mohu nastavit obrázek jako pozadí pro více snímků najednou?**

[Přiřaďte obrázek jako pozadí](/slides/cs/python-net/presentation-background/) na master slide nebo příslušné rozvržení — všechny snímky používající tento master/rozvržení zdědí pozadí.

**Jak zabránit tomu, aby se prezentace kvůli mnoha obrázkům „nafouklá“?**

Opakovaně používejte jeden obrazový zdroj místo duplicit, zvolte rozumná rozlišení, použijte kompresi při ukládání a opakující se grafiku umístěte na master, kde je to vhodné.