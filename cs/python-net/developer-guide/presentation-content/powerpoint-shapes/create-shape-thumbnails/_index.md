---
title: Vytvoření miniatur tvarů v prezentaci v Pythonu
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/python-net/create-shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslení tvaru
- renderování tvaru
- vizuální ohraničení
- ohraničení tvaru
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Generujte vysoce kvalitní miniatury tvarů z PowerPoint a OpenDocument snímků pomocí Aspose.Slides pro Python přes .NET – snadno vytvářejte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides pro Python prostřednictvím .NET se používá k vytváření souborů prezentací, kde je každá stránka snímek. Tyto snímky můžete zobrazit v Microsoft PowerPoint otevřením souboru prezentace. Vývojáři však někdy potřebují zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech může Aspose.Slides vygenerovat miniatury obrázků pro tvary na snímcích. Tento článek vysvětluje, jak tuto funkci použít.

## **Generování miniatur tvarů ze snímků**

Když potřebujete náhled konkrétního objektu místo celého snímku, můžete vykreslit miniaturu pro jednotlivý tvar. Aspose.Slides vám umožňuje exportovat jakýkoli tvar do obrázku, což usnadňuje vytváření lehkých náhledů, ikon nebo prostředků pro následné zpracování.

Pro vygenerování miniatury z libovolného tvaru:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho ID nebo indexu.
1. Získejte odkaz na tvar na tomto snímku.
1. Vykreslete miniaturu obrázku tvaru.
1. Uložte obrázek miniatury v požadovaném formátu.

Příklad níže generuje miniaturu tvaru.

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

## **Generování miniatur s vlastním měřítkem**

Tato část ukazuje, jak v Aspose.Slides generovat miniatury tvarů s uživatelem definovaným měřítkem. Řízením měřítka můžete jemně doladit velikost miniatury pro náhledy, exporty nebo displeje s vysokým DPI.

Pro vygenerování miniatury pro libovolný tvar na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte snímek podle jeho ID nebo indexu.
1. Získejte cílový tvar na tomto snímku.
1. Vykreslete obrázek miniatury tvaru se zadaným měřítkem.
1. Uložte obrázek miniatury v požadovaném formátu.

Příklad níže generuje miniaturu s uživatelem definovaným měřítkem.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Vytvořte instanci třídy Presentation pro otevření souboru prezentace.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Vytvořte obrázek s definovaným měřítkem.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Uložte obrázek na disk ve formátu PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generování miniatur pomocí ohraničení vzhledu tvaru**

Tato část ukazuje, jak vygenerovat miniaturu v rámci ohraničení vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaná miniatura je omezena ohraničením snímku.

Pro vygenerování miniatury libovolného tvaru na snímku v rámci ohraničení jeho vzhledu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte snímek podle jeho ID nebo indexu.
1. Získejte cílový tvar na tomto snímku.
1. Vykreslete obrázek miniatury tvaru s určenými ohraničeními.
1. Uložte obrázek miniatury v požadovaném formátu obrázku.

Příklad níže vytvoří miniaturu s uživatelem definovanými ohraničeními.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Vytvořte instanci třídy Presentation pro otevření souboru prezentace.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Vytvořte obrázek tvaru podle ohraničení vzhledu.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Uložte obrázek na disk ve formátu PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Získání skutečných vizuálních ohraničení tvaru**

Vlastnosti rámce [Shape]—`Shape.x`, `Shape.y`, `Shape.width` a `Shape.height`—popisují obdélník uložený v modelu prezentace. Obsah, který je skutečně vykreslen, může přesahovat tento rámec nebo zabírat jiný osově zarovnaný obdélník. Rotace, obrysy, konce šipek, rozvržení a přetečení textu, generovaná geometrie SmartArt a další efekty vykreslování mohou všechny změnit obsazenou oblast.

Použijte [Shape.get_visual_bounds](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_visual_bounds/) k výpočtu této obsazené oblasti bez vytváření obrázku. Metoda vrací obdélník s plovoucí desetinnou čárkou ve souřadnicích snímku. Vrácený obdélník není oříznut na snímek, takže jeho souřadnice mohou být záporné, když obsah přesahuje počátek snímku.

Následující příklad získá a porovná rámcová a vizuální ohraničení:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Stejný obdélník lze použít k zarovnání sousedních tvarů k jeho `left`, `right`, `top` nebo `bottom` okraji; rezervovat dostatek prostoru v generovaném rozložení; nebo detekovat obsah mimo povolenou oblast. Vizuální ohraničení jsou obzvláště užitečná pro SmartArt, textová pole, šipky, obrázky, otočené tvary a seskupené tvary, kde uložený rámec nemusí představovat celý vykreslený výsledek.

Použijte [Shape.get_visual_bounds](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_visual_bounds/) když potřebujete souřadnice pro rozvržení nebo validaci a nepotřebujete bitmapu. Použijte [Shape.get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/) když potřebujete tvar vykreslit. S [ShapeThumbnailBounds](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.SHAPE` určuje velikost obrázku podle ohraničení tvaru, včetně nastavení obrysu, zatímco `ShapeThumbnailBounds.APPEARANCE` určuje velikost podle vzhledu tvaru a omezuje výsledek na ohraničení snímku. Naopak `Shape.get_visual_bounds` vrací pouze vypočtený obdélník a neorezuje jej na snímek.

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/write_as_svg/) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi ohraničením SHAPE a APPEARANCE při vykreslování miniatury?**

`SHAPE` používá geometrii tvaru; `APPEARANCE` bere v úvahu [vizuální efekty](/slides/cs/python-net/shape-effect/) (stíny, záře apod.).

**Co se stane, když je tvar označen jako skrytý? Vykreslí se stále jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení v prezentaci, ale nebrání generování obrázku tvaru.

**Jsou podporovány seskupené tvary, grafy, SmartArt a další složité objekty?**

Ano. Každý objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/), a [SmartArt](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/)) lze uložit jako miniaturu nebo jako SVG.

**Ovlivňují systémově nainstalované fonty kvalitu miniatur pro textové tvary?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/python-net/custom-font/) (nebo [nastavit náhradu fontů](/slides/cs/python-net/font-substitution/)), aby se předešlo nechtěným náhradám a přeformátování textu.