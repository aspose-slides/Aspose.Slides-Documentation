---
title: Vytvoření náhledů tvarů prezentace v Pythonu
linktitle: Náhledy tvarů
type: docs
weight: 70
url: /cs/python-net/create-shape-thumbnails/
keywords:
- náhled tvaru
- obrázek tvaru
- vykreslit tvar
- renderování tvaru
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Generujte vysoce kvalitní náhledy tvarů z PowerPoint a OpenDocument snímků pomocí Aspose.Slides pro Python přes .NET – snadno vytvářejte a exportujte náhledy prezentací."
---
## **Úvod**

Aspose.Slides pro Python přes .NET se používá k vytváření prezentačních souborů, kde je každá stránka snímek. Tyto snímky můžete zobrazit v Microsoft PowerPoint otevřením prezentačního souboru. Vývojáři však někdy mohou potřebovat zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech může Aspose.Slides generovat náhledové obrázky pro tvary snímků. Tento článek vysvětluje, jak tuto funkci použít.

## **Generování náhledových obrázků tvarů ze snímků**

Když potřebujete náhled konkrétního objektu místo celého snímku, můžete vykreslit náhled pro jednotlivý tvar. Aspose.Slides vám umožňuje exportovat libovolný tvar do obrázku, což usnadňuje vytváření odlehčených náhledů, ikon nebo prostředků pro následné zpracování.

Pro vygenerování náhledu z libovolného tvaru:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho ID nebo indexu.
3. Získejte odkaz na tvar na tomto snímku.
4. Vykreslete náhledový obrázek tvaru.
5. Uložte náhledový obrázek v požadovaném formátu.

Níže uvedený příklad generuje náhled tvaru.

```py
import aspose.slides as slides

# Instancujte třídu Presentation pro otevření souboru prezentace.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Vytvořte obrázek s výchozím měřítkem.
    with shape.get_image() as thumbnail:
        # Uložte obrázek na disk ve formátu PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Generování náhledů s vlastním měřítkem**

Tato část ukazuje, jak generovat náhledové obrázky tvarů s uživatelem definovaným měřítkem v Aspose.Slides. Ovládáním měřítka můžete jemně doladit velikost náhledu pro náhledy, exporty nebo displeje s vysokým DPI.

Pro vygenerování náhledu pro libovolný tvar na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte snímek podle jeho ID nebo indexu.
3. Získejte cílový tvar na tomto snímku.
4. Vykreslete náhledový obrázek tvaru se specifikovaným měřítkem.
5. Uložte náhledový obrázek v požadovaném formátu.

Níže uvedený příklad generuje náhled s uživatelem definovaným měřítkem.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instancujte třídu Presentation pro otevření souboru prezentace.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Vytvořte obrázek s definovaným měřítkem.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Uložte obrázek na disk ve formátu PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generování náhledů pomocí vzhledových hranic tvaru**

Tato část ukazuje, jak generovat náhled v rámci vzhledových hranic tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaný náhled je omezen hranicemi snímku.

Pro vygenerování náhledu libovolného tvaru snímku v rámci jeho vzhledových hranic:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte snímek podle jeho ID nebo indexu.
3. Získejte cílový tvar na tomto snímku.
4. Vykreslete náhledový obrázek tvaru se specifikovanými hranicemi.
5. Uložte náhledový obrázek v požadovaném formátu obrázku.

Níže uvedený příklad vytváří náhled s uživatelem definovanými hranicemi.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instancujte třídu Presentation pro otevření souboru prezentace.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Vytvořte obrázek tvaru s hranicemi vzhledu.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Uložte obrázek na disk ve formátu PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání náhledových obrázků tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/write_as_svg/) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi hranicemi SHAPE a APPEARANCE při renderování náhledu?**

`SHAPE` používá geometrii tvaru; `APPEARANCE` zohledňuje [vizuální efekty](/slides/cs/python-net/shape-effect/) (stíny, záře atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude se stále renderovat jako náhled?**

Skrytý tvar zůstává součástí modelu a lze jej renderovat; příznak skrytí ovlivňuje pouze zobrazení ve slideshow, ale nebrání vytvoření obrázku tvaru.

**Jsou podporovány skupinové tvary, grafy, SmartArt a další složité objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/)) lze uložit jako náhled nebo jako SVG.

**Ovlivňují systémové fonty kvalitu náhledů textových tvarů?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/python-net/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/python-net/font-substitution/)), aby se zabránilo nechtěným náhradám a přeskupení textu.