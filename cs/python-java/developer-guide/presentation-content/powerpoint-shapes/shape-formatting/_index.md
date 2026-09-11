---
title: Formátování tvarů PowerPointu v Pythonu přes Java
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/python-java/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- skicovací efekt
- skicovat čáru tvaru
- formátování stylu spojení
- gradientové vyplnění
- vzorové vyplnění
- obrázkové vyplnění
- texturové vyplnění
- jednobarevné vyplnění
- průhlednost tvaru
- černobílé vykreslování tvaru
- šedotónové vykreslování tvaru
- otáčení tvaru
- 3D efekt zkosení
- 3D otáčecí efekt
- resetování formátování
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak v Pythonu přes Java pomocí Aspose.Slides formátovat tvary v PowerPointu — nastavte výplň, čáru a styly efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPoint můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysy. Navíc můžete tvary formátovat zadáním nastavení, která řídí, jak jsou jejich vnitřky vyplněny.

![formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides for Python via Java poskytuje třídy a metody, které vám umožňují formátovat tvary pomocí stejných možností dostupných v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Nastavte [line style](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte automatický tvar typu Obdélník.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Nastavte barvu výplně pro obdélníkový tvar.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Aplikujte formátování na čáry obdélníku.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Nastavte barvu čáry obdélníku.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Uložte soubor PPTX na disk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

## **Použití skicovacích efektů na čáry tvaru**

Efekt skici způsobí, že čára tvaru vypadá ručně kresleně. Použijte [Shape.getLineFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getLineFormat) k přístupu k nastavením čáry, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/lineformat/#getSketchFormat) k přístupu k nastavením skici a [SketchFormat.setSketchType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sketchformat/#setSketchType) k výběru hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linesketchtype/).

Následující kód v Pythonu ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linesketchtype/#Curved), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None_](https://reference.aspose.com/slides/cs/python-java/aspose.slides/linesketchtype/#None):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Získejte formát čáry tvaru a jeho formát skici.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Aplikujte skicovací efekt.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Přečtěte skicovací efekt přiřazený přímo tvaru.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Odstraňte skicovací efekt.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Hodnota vrácená metodou [SketchFormat.getSketchType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sketchformat/#getSketchType) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozvržení snímku, použijte [LineFormat.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/lineformat/#getEffective), přistupte k `LineFormatEffectiveData.getSketchFormat` a přečtěte `SketchFormatEffectiveData.getSketchType`. Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Formátování stylů spojů**

Zde jsou tři možnosti typu spoje:

* Round
* Miter
* Bevel

Ve výchozím nastavení PowerPoint při spojení dvou čar pod úhlem (například v rohu tvaru) používá nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spoje v prezentaci](join-style-powerpoint.png)

Následující kód v Pythonu ukazuje, jak byly vytvořeny tři obdélníky (jak je vidět na obrázku výše) pomocí nastavení typu spoje Miter, Bevel a Round:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte tři automatické tvary typu Obdélník.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Nastavte barvu výplně pro každý obdélníkový tvar.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Nastavte šířku čáry.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Nastavte barvu čáry každého obdélníku.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Nastavte styl spoje.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Přidejte text do každého obdélníku.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Uložte soubor PPTX na disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gradientové vyplnění**

V PowerPointu je Gradient Fill formátovací možnost, která vám umožní aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, že jedna postupně přechází v druhou.

Zde je postup, jak aplikovat gradientové vyplnění na tvar pomocí Aspose.Slides:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metody [addPresetColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/gradientstopcollection/#addPresetColor) kolekce gradientových zastávek, kterou vystavuje třída [GradientFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/gradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte automatický tvar typu Elipsa.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Aplikujte gradientové formátování na elipsu.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Nastavte směr gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Přidejte dva gradientové zastávky.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Uložte soubor PPTX na disk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Elipsa s gradientovým vyplněním](gradient-fill.png)

## **Vzorové vyplnění**

V PowerPointu je Pattern Fill formátovací možnost, která vám umožní aplikovat dvoubarevný design – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete si zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na tvary a zvýšit tak vizuální přitažlivost svých prezentací. I po výběru předdefinovaného vzoru můžete ještě určit přesné barvy, které se mají použít.

Zde je postup, jak aplikovat vzorové vyplnění na tvar pomocí Aspose.Slides:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/python-java/aspose.slides/patternformat/#getBackColor) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/python-java/aspose.slides/patternformat/#getForeColor) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte automatický tvar typu Obdélník.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Nastavte typ výplně na Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Nastavte styl vzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Nastavte barvy pozadí a popředí vzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Uložte soubor PPTX na disk.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Obdélník s vzorovým vyplněním](pattern-fill.png)

## **Obrázkové vyplnění**

V PowerPointu je Picture Fill formátovací možnost, která vám umožní vložit obrázek do tvaru – efektivně použít obrázek jako pozadí tvaru.

Zde je návod, jak pomocí Aspose.Slides aplikovat obrázkové vyplnění na tvar:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim obrázkového vyplnění na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) z obrázku, který chcete použít.
1. Předávejte obrázek metodě `SlidesPicture.setImage`.
1. Uložte upravenou prezentaci jako soubor PPTX.

![Obrázek lotosu](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte automatický tvar typu Obdélník.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Nastavte typ výplně na Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Nastavte režim vyplnění obrázkem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Načtěte obrázek a přidejte jej do zdrojů prezentace.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Nastavte obrázek.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Uložte soubor PPTX na disk.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Tvar s obrázkovým vyplněním](picture-fill.png)

### **Dlaždicový obrázek jako textura**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Nastavuje režim obrázkového vyplnění — buď `Tile` nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#setTileAlignment): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#setTileFlip): Řídí, zda je dlaždice převrácena vodorovně, svisle nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definuje vodorovné měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definuje svislé měřítko dlaždice v procentech.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte první snímek.
    first_slide = presentation.getSlides().get_Item(0)

    # Přidejte automatický tvar obdélníku.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Nastavte typ výplně tvaru na Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Načtěte obrázek a přidejte jej do zdrojů prezentace.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Přiřaďte obrázek k tvaru.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Nakonfigurujte režim vyplnění obrázkem a vlastnosti dlaždic.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Uložte soubor PPTX na disk.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Možnosti dlaždic](tile-options.png)

## **Jednobarevné vyplnění**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní tvar jednou, jednotnou barvou. Tato jednoduchá barva pozadí se použije bez jakýchkoli přechodů, textur nebo vzorů.

Pro aplikaci jednobarevného vyplnění na tvar pomocí Aspose.Slides postupujte takto:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte automatický tvar typu Obdélník.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Nastavte typ výplně na Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Nastavte barvu výplně.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Uložte soubor PPTX na disk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Tvar s jednobarevným vyplněním](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když použijete jednobarevné, gradientové, obrázkové nebo texturové vyplnění na tvary, můžete také nastavit úroveň průhlednosti pro řízení neprůhlednosti výplně. Vyšší hodnota průhlednosti činí tvar průhlednějším, což umožňuje, aby pozadí nebo podkladové objekty byly částečně viditelné.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou hodnoty alfa v barvě použitých pro výplň. Zde je postup:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) tvaru na `Solid`.
1. Použijte třídu [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte pevný obdélníkový automatický tvar.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Přidejte transparentní obdélníkový automatický tvar nad pevný tvar.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Uložte soubor PPTX na disk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umísťování vizuálních prvků s konkrétním zarovnáním nebo designovým požadavkem.

Pro otáčení tvaru na snímku postupujte takto:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte automatický tvar typu Obdélník.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Otočte tvar o 5 stupňů.
    shape.setRotation(5)

    # Uložte soubor PPTX na disk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D efektů zkosení**

Aspose.Slides umožňuje aplikovat 3D efekty zkosení na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/).

Pro přidání 3D efektů zkosení na tvar postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidejte tvar na snímek.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Set the shape's ThreeDFormat properties.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidání 3D otáčecích efektů**

Aspose.Slides umožňuje aplikovat 3D otáčecí efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/).

Pro aplikaci 3D otáčení na tvar:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Použijte metody [setCameraType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/camera/#setCameraType) a [setLightType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/lightrig/#setLightType) k definování 3D otáčení.
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![3D otáčecí efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslení pro tvary**

Metoda [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setBlackWhiteMode) určuje, jak se jednotlivý tvar vykresluje, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Nezapíná černobílý režim sama o sobě a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu ze třídy [BlackWhiteMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `Automatic` ponechá výběr konverze na aplikaci, `Gray` a `LightGray` používají šedé odstíny, `BlackWhite` používá jen černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová normální barvy a `Hidden` tvar v černobílém režimu skryje. `NotDefined` znamená, že pro tvar není nastaven žádný režim.

Následující kód v Pythonu vytvoří barevný tvar a způsobí, že se v černobílém režimu zobrazí šedě:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Zachovejte oranžovou výplň v barevném režimu, ale vykreslete tvar s šedým zbarvením v černobílém režimu.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

V normálním barevném režimu si obdélník ponechává oranžovou výplň. V pracovním postupu černobílého zobrazení používá šedé zbarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat plnobarevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné procesy, které respektují nastavení černobílého zobrazení prezentace.

## **Resetování formátování**

Následující kód v Pythonu ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů s placeholdery na [LayoutSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/) na jejich výchozí nastavení:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Resetujte každý tvar na snímku, který má placeholder v rozvržení.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a multimédia zabírají většinu místa v souboru, zatímco parametry tvarů jako barvy, efekty a gradienty jsou uloženy jako metadata a téměř nepřidávají žádnou velikost.

**Jak mohu na snímku zjistit tvary, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opakované použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, naklonujte potřebné stylované tvary a aplikujte jejich formátování tam, kde je to potřeba.