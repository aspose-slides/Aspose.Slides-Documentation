---
title: Vytvoření miniatur tvarů prezentace v Pythonu přes Java
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/python-java/create-shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslit tvar
- vykreslování tvaru
- vizuální ohraničení
- ohraničení tvaru
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí Aspose.Slides pro Python via Java – snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides for Python via Java lze použít k vytváření souborů prezentací, kde každá stránka odpovídá snímku. Snímky lze zobrazit otevřením souborů prezentace v Microsoft PowerPoint. Někdy však vývojáři potřebují zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech Aspose.Slides for Python via Java pomáhá vygenerovat miniatury tvarů na snímku.

Tento článek popisuje, jak generovat miniatury tvarů různými způsoby:

- Generování miniatury tvaru uvnitř snímku.
- Generování miniatury tvaru pro tvar na snímku s uživatelem definovanými rozměry.
- Generování miniatury tvaru v mezích vzhledu tvaru.

## **Generování miniatury tvaru ze snímku**
Pro vygenerování miniatury tvaru z libovolného snímku pomocí Aspose.Slides for Python via Java postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek pomocí jeho ID nebo indexu.
1. [Získejte obrázek miniatury tvaru](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) tvaru na odkazovaném snímku v výchozím měřítku.
1. Uložte obrázek miniatury v požadovaném formátu obrázku.

Tento ukázkový kód ukazuje, jak vygenerovat miniaturu tvaru ze snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation("Thumbnail.pptx")
try:
    # Vytvořte obrázek v plném měřítku.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Uložte obrázek na disk ve formátu PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Generování miniatury s uživatelem definovaným faktorem měřítka**
Pro vygenerování miniatury tvaru snímku pomocí Aspose.Slides for Python via Java postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek pomocí jeho ID nebo indexu.
1. [Získejte obrázek miniatury tvaru](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) tvaru na odkazovaném snímku s uživatelem definovanými rozměry.
1. Uložte obrázek miniatury v požadovaném formátu obrázku.

Tento ukázkový kód ukazuje, jak vygenerovat miniaturu tvaru na základě definovaného faktoru měřítka:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation("Thumbnail.pptx")
try:
    # Vytvořte obrázek měřítkovaný faktorem 2 v obou směrech.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Uložte obrázek na disk ve formátu PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Vytvoření miniatury tvaru na základě ohraničení vzhledu**
Tato metoda vytváření miniatur tvarů umožňuje vývojářům vygenerovat miniaturu v mezích vzhledu tvaru. Bere v úvahu všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena mezemi snímku. Pro vygenerování miniatury tvaru na snímku v mezích jeho vzhledu postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek pomocí jeho ID nebo indexu.
1. Získejte obrázek miniatury tvaru na odkazovaném snímku pomocí jeho ohraničení vzhledu.
1. Uložte obrázek miniatury v požadovaném formátu obrázku.

Tento ukázkový kód vychází z výše uvedených kroků:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation("Thumbnail.pptx")
try:
    # Vytvořte obrázek v plném měřítku.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Uložte obrázek na disk ve formátu PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Získání skutečných vizuálních ohraničení tvaru**

Vlastnosti rámce [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/) — její metody [getX](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getWidth) a [getHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getHeight) — popisují obdélník uložený v modelu prezentace. Obsah, který se skutečně vykresluje, může přesahovat tento rámec nebo zabírat jiný osově zarovnaný obdélník. Rotace, obrysy, šipky, rozvržení a přetečení textu, generovaná geometrie SmartArt a další efekty vykreslování mohou změnit obsazenou oblast.

Použijte [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getVisualBounds) k výpočtu této obsazené oblasti bez vytváření obrázku. Metoda vrací objekt [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) v souřadnicích snímku. Vrácený obdélník není oříznut na snímek, takže jeho souřadnice mohou být záporné, pokud obsah přesahuje počátek snímku.

Následující příklad získává a porovnává rámcová a vizuální ohraničení:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Stejný objekt [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) lze použít k zarovnání blízkých tvarů k levému, pravému, hornímu nebo spodnímu okraji; rezervovat dostatek prostoru v generovaném rozvržení; nebo detekovat obsah mimo povolenou oblast. Vizuální ohraničení jsou zvláště užitečná pro SmartArt, textová pole, šipky, obrázky, otáčené tvary a seskupené tvary, kde uložený rámec nemusí představovat celý vykreslený výsledek.

Použijte [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getVisualBounds), když potřebujete souřadnice pro rozvržení nebo validaci a nepotřebujete bitmapu. Použijte [Shape.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage), když potřebujete tvar vykreslit. S [ShapeThumbnailBounds](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapethumbnailbounds/) a [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapethumbnailbounds/#Shape) se velikost obrázku určuje podle ohraničení tvaru, včetně nastavení obrysu, zatímco [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapethumbnailbounds/#Appearance) určuje velikost podle vzhledu tvaru a omezí výsledek na ohraničení snímku. Na rozdíl od toho [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getVisualBounds) vrací pouze vypočtený obdélník a neorezuje jej na snímek.

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#writeAsSvgToBytes) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi ohraničením Shape a Appearance při vykreslování miniatury?**

`Shape` používá geometrii tvaru; `Appearance` bere v úvahu [vizuální efekty](/slides/cs/python-java/shape-effect/) (stíny, záře atd.).

**Co se stane, když je tvar označen jako skrytý? Bude se stále vykreslovat jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje pouze zobrazení v prezentaci, ale nebrání generování obrázku tvaru.

**Jsou podporovány seskupené tvary, grafy, SmartArt a další složité objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/)) může být uložen jako miniatura nebo jako SVG.

**Ovlivňují systémově nainstalované fonty kvalitu miniatur textových tvarů?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/python-java/custom-font/) (nebo [konfigurovat náhrady fontů](/slides/cs/python-java/font-substitution/)), aby nedocházelo k nechtěným náhradám a přetečení textu.