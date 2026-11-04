---
title: Formátování tvarů PowerPointu v Pythonu přes Java
linktitle: Formátování tvaru
type: docs
weight: 20
url: /cs/python-java/shape-formatting/
keywords:
  - formátování tvaru
  - formátování čáry
  - skicový efekt
  - skicová čára tvaru
  - formátování stylu spojení
  - gradientní výplň
  - vzorová výplň
  - obrázková výplň
  - texturová výplň
  - plná barva výplně
  - průhlednost tvaru
  - černobílé vykreslení tvaru
  - vykreslení tvaru ve stupních šedi
  - otáčení tvaru
  - 3d efekt zkosení
  - 3d rotační efekt
  - resetování formátování
  - PowerPoint
  - prezentace
  - Python
  - Java
  - Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v Pythonu přes Java pomocí Aspose.Slides—nastavit výplň, čáru a styly efektů pro soubory PPT a PPTX s přesností a plnou kontrolou."
---
## **Úvod**

Formátujte tvary v PowerPointu úpravou jejich obrysů, výplní a efektů. Aspose.Slides pro Python přes Java vám umožňuje ovládat tato nastavení programově, včetně průhlednosti, otáčení a 3D formátování.

![Možnosti formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro Python přes Java poskytuje třídy a metody, které umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Použijte [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) k ovládání obrysu tvaru. Tento příklad vytváří nevyplněný obdélník s modrým, čárkovaným obrysem. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) vybírá spojení tlusté a tenké čáry, zatímco [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) nastavuje šířku na 7 bodů a [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) volí vzor čáry.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

### **Nastavit vlastní vzory čárek**

Použijte [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern), pokud předdefinované styly čar neposkytují požadované délky čárek a mezer, například pro značkové obrysy nebo technické diagramy. Při přiřazení vzoru se automaticky mění styl čáry na [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Pole vstupů střídá délky čáry a mezery, počínaje čárou. Každá hodnota je násobkem šířky čáry: `[4, 2]` při šířce 3 body vytváří čáru o délce 12 bodů následovanou mezerou 6 bodů. Používejte dvojice konečných, nezáporných hodnot k definování úplných úseků čáry a mezery. Příklad používá kladné hodnoty, aby byly všechny čáry i mezery viditelné.

Tento příklad vytváří pět modrých čar stejné délky a se rovnými zakončeními. První tři porovnávají vzory při šířce 3 body. Čtvrtá opakuje první vzor při dvojnásobné šířce, čímž zdvojnásobí jak délku čáry, tak mezery. Pátá přepíná z vlastního vzoru na plnou čáru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # Nastavit poslední čáru na plný styl.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro návrat k předdefinovanému čárkovanému stylu použijte [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) jako argument metody [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). Vybraný styl řídí vzhled čáry.

Výsledek v PowerPointu, shora dolů: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; a **Solid, 3 pt**.

![Tři vlastní vzory čárek, širší čára s prvním vzorem a plná čára v PowerPointu](custom-dash-patterns.png)

### **Nastavit zakončení čar**

Použijte [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) k nastavení konců otevřené čáry. Třída [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) poskytuje tři explicitní styly zakončení:

- `Flat`: Tah končí v koncovém bodě.
- `Round`: Polokulové zakončení přesahuje koncový bod o polovinu šířky čáry.
- `Square`: Čtvercové zakončení přesahuje koncový bod o polovinu šířky čáry.

Třída také obsahuje `NotDefined`, což znamená, že žádný styl zakončení není explicitně přiřazen.

Zakončení se liší od šipek, které přidávají symboly na konce čar, a od spojů, které řídí rohy mezi úseky čar. Tento příklad zakazuje šipky pomocí [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) a [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle), aby byly porovnány pouze tvary zakončení.

Následující příklad vytváří tři jinak identické vodorovné čáry, široké 20 bodů. Shora dolů používají rovná, kulatá a čtvercová zakončení. Jejich koncové body mají stejné vodorovné souřadnice; kulatá a čtvercová zakončení přesahují 10 bodů za každý koncový bod.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek v PowerPointu, shora dolů: **Flat**, **Round** a **Square**.

![Rovná, kulatá a čtvercová zakončení na identických tlustých čarách v PowerPointu](line-caps.png)

## **Použít skicové efekty na čáry tvaru**

Skicový efekt způsobí, že čára tvaru vypadá ručně kreslená. Použijte [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) pro přístup k nastavení čáry, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) pro přístup k nastavení skici a [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) pro výběr hodnoty ze třídy [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Následující kód Python ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

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

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Hodnota vrácená metodou [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) představuje nastavení přiřazené přímo tvaru. Pokud lze formátování čáry zdědit z motivu, hlavního snímku nebo rozložení snímku, použijte [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) a přečtěte typ skici z vráceného efektivního formátování čáry, jak je ukázáno níže. Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti. Tento příklad vyžaduje existující prezentaci s alespoň jedním tvarem na prvním snímku a vypisuje obě hodnoty:

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

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Styl spojení řídí, jak se dva úseky obrysu setkají v rohu. Použijte **Round** pro zakulacené rohy, **Miter** pro ostré rohy nebo **Bevel** pro zploštělé rohy.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Tento příklad vytváří tři černé obdélníky s modrými obrysy širokými 15 bodů. Používá [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) pro nastavení hodnot miter, bevel a round třídy [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) a porovnává, jak jsou rohy vykresleny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Omezit miterové spoje u ostrých rohů**

Použijte [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) spolu s [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) nastaveným na [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) pro omezení, jak daleko může ostrý roh vyčnívat.

Limit je poměr vzdálenosti mezi vnitřním a vnějším rohem spoje k šířce čáry. Například hodnota `8` umožní délku miteru až osminásobek šířky čáry; není to měření v bodech. Pokud by roh překročil limit, PowerPoint použije u tohoto rohu zkosený spoj. Větší limit umožňuje ostřejší špičky. Nastavení ovlivňuje pouze miterové spoje a jeho změna nemá viditelný efekt, pokud roh zůstane v obou limitech.

Tento příklad vytváří dva identické nevyplněné trojúhelníky s obrysy širokými 20 bodů. Levý trojúhelník používá limit `2` a pravý `8`. Každý trojúhelník má šířku 80 bodů a výšku 160 bodů, což dává jeho hornímu rohu poměr délky miteru k šířce čáry přibližně `4,12`. V důsledku toho PowerPoint zkosení levého vrcholu a zachová pravý vrchol.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek v PowerPointu: **Miter limit 2** vlevo a **miter limit 8** vpravo.

![Zkosený vrchol s limitem miteru 2 a špičatý vrchol s limitem miteru 8 v PowerPointu](miter-limits.png)

## **Gradientní výplň**

Gradientní výplň míchá barvy napříč tvarem. Tento příklad vyplní elipsu lineárním gradientem pod úhlem 45 stupňů od červené po fialovou pomocí [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). Metoda [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) umístí barevné zastávky na 0 a 1, tedy na začátek a konec gradientu. Vymazání existujících zastávek zajišťuje, že budou použity pouze tyto dvě barvy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Elipsa s gradientní výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, podívejte se na [Vyberte styl vykreslování gradientu](/slides/cs/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování, aniž byste měnili gradientní výplň uloženou v prezentaci.

### **Nastavit úhel lineárního gradientu**

Použijte [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) k ovládání orientace výplně [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/). Úhel se měří ve stupních a zvyšuje se ve směru hodinových ručiček: `0` jde zleva doprava, `90` shora dolů, `180` zprava doleva a `270` zdola nahoru. Podporovány jsou i zlomkové úhly. Konečné úhly mimo interval `[0, 360)` jsou normalizovány na jednu otáčku; například `-45` se převede na `315` a `360` na `0`.

Tento příklad vytváří šest obdélníků se stejnými červenými, zelenými a modrými zastávkami na pozicích `0`, `0,5` a `1`. Škálování je zakázáno, aby bylo možné úhel porovnat nezávisle na proporcích obdélníků. Úhly, zleva doprava, jsou `0`, `45` a `90` v první řadě a `135`, `180` a `270` ve druhé řadě.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek v PowerPointu:

![Lineární gradienty při 0, 45 a 90 stupních v horní řadě a 135, 180 a 270 stupních ve spodní řadě](linear-gradient-angles.png)

### **Škálovat lineární gradient s tvarem**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) přijímá hodnotu [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). Nastavte ji explicitně na `False_`, aby se geometrický úhel gradientu udržel při změně proporcí tvaru, nebo na `True_`, aby se gradient škáloval spolu se šířkou a výškou tvaru. Při povoleném škálování se viditelný úhel může lišit od přiřazeného úhlu u nečtvercového tvaru.

Následující příklad používá úhel `45` stupňů a stejné barevné zastávky jako při porovnávání úhlů. Levý sloupec používá `False_`; pravý sloupec používá `True_`. Každý sloupec obsahuje široký obdélník nad vysokým obdélníkem. Oba začínají se stejnými rozměry; změna šířky a výšky druhého obdélníku ukazuje, jak výplň reaguje na změnu velikosti bez změny nastavení gradientu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek v PowerPointu, se škálováním zakázaným doleva a povoleným napravo:

![Široké a vysoké obdélníky s 45‑stupňovým gradientem, porovnání LinearGradientScaled False vlevo a True vpravo](linear-gradient-scaling.png)

Při zakázaném škálování si šikmé barevné pásy zachovávají stejnou orientaci v obou obdélnících. Při povoleném škálování se pásy roztahují s proporcemi tvaru. To pomáhá reprodukovat gradient šablony při přizpůsobení tvaru na jinou velikost. Na čtverci povolení škálování nemění vzhled tohoto gradientu s úhlem `45` stupňů.

Oba nastavení, úhel i škálování, se vztahují jen na lineární gradienty. Neovlivňují výplně [GradientShape.Radial nebo GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **Kombinovat úhel se směrem gradientu**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) vybírá styl gradientu ze třídy [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/); není to náhrada za číselný úhel. U lineárního gradientu mohou styly rohů změnit oblast, na kterou jsou barvy rozděleny, aniž by se změnil úhel nastavený pomocí [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). Při porovnávání úhlů nebo škálování ponechte směr beze změny.

Následující příklad aplikuje stejná nastavení v opačném pořadí. Oba obdélníky mají stejný vzhled: nastavení směru před nebo po úhlu nemění výsledek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vzorová výplň**

Vzorová výplň aplikuje dvoubarevný návrh, například tečky, proužky nebo šachovnici. tento příklad používá [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) k výběru vzoru "trellis". [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) poskytuje světle šedé pozadí a [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) žlutou barvu vzoru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

Obrázková výplň používá obrázek uvnitř tvaru. Tento příklad vyžaduje lokální obrázek a používá [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) k načtení do kolekce obrázků prezentace. Nastavení [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) na režim dlaždic opakuje obrázek uvnitř obdélníku. Zdrojový obrázek použitý zde je zobrazen níže:

![Obrázek lotosu](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Dlaždice obrázku jako textura**

Pokud chcete nastavit opakovaný obrázek jako texturu a přizpůsobit chování opakování, můžete použít následující metody třídy [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Nastavuje režim obrázkové výplně – buď `Tile` nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Ovládá, zda je dlaždice překlopena horizontálně, vertikálně nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definuje vodorovné měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definuje svislé měřítko dlaždice v procentech.

Tento příklad vyžaduje lokální obrázek a konfiguruje [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) k jeho opakování na 50 % původní velikosti. Posuny –32 bodů posunou dlaždice horizontálně i vertikálně; zarovnání vpravo dole a překlopení v obou směrech určuje, jak je textura uspořádána.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Možnosti dlaždic](tile-options.png)

## **Plná barva výplně**

Plná výplň dává tvaru jednotnou barvu. Tento příklad používá [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) k nastavení režimu plné výplně a přiřazuje žlutou barvu pomocí [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), poté ukládá obdélník v prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Tvar s plnou barvou výplně](solid-color-fill.png)

## **Použít pozadí snímku jako výplň tvaru**

Použijte [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill), když má tvar odpovídat pozadí snímku, například v šabloně prezentace. Nejprve nastavte [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) na [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), aby se odstranila jakákoliv explicitní výplň. Tímto kombinovaným nastavením tvar použije pozadí snímku místo své stylové výplně. Pouze aktivace příznaku neodstraní existující explicitní výplň.

To se liší od [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): výplň pozadím pokrývá objekty za tvarem odpovídající oblastí pozadí snímku, zatímco žádná výplň tyto objekty nechává viditelné. Gradient zůstává zarovnán k snímku místo toho, aby se restartoval uvnitř každého tvaru.

Následující příklad vytváří hlavní pozadí zděděné snímkem a umisťuje magentový pruh za tři obdélníky. Levý obdélník používá pozadí, prostřední nemá výplň a pravý přepíná z výplně pozadím na explicitní oranžovou výplň.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # Zdědit gradient z masteru.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # Přidejte tento objekt jako první, aby byl za obdélníky.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # Zakážte výplň pozadí před použitím explicitní výplně.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek, zleva doprava: **výplň pozadím**, **žádná výplň** a **explicitní výplň**. Magentový pruh je skrytý levým a pravým obdélníkem, ale zůstává viditelný skrz prostřední obdélník.

![Výplň pozadím, žádná výplň a explicitní oranžová výplň přes magentový pruh](background-fill.png)

Stejné chování platí pro pozadí definované přímo na snímku nebo zděděné z rozložení. Tvar používá rozpoznané pozadí snímku; příklad nechává pozadí snímku i rozložení nedefinované, aby ho poskytl hlavní.

## **Nastavit průhlednost**

U plné výplně komponenta alfa barvy řídí neprůhlednost: 0 je úplně průhledná a 255 úplně neprůhledná. Tento příklad používá hodnotu alfa 128 pro žlutý obdélník, což jej činí přibližně 50 % průhledným, takže podkladový obdélník zůstává viditelný. Barva je přiřazena pomocí [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otáčet tvary**

Použijte [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) k otáčení tvaru v rovině snímku. Úhel se měří ve stupních; tento příklad otáčí obdélník o 5 stupňů ve směru hodinových ručiček a ukládá prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Rotace tvaru](shape-rotation.png)

## **Přidat 3D efekty zkosení**

Použijte [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) k přidání hloubky a zkosených hran tvaru. Tento příklad vytváří zelenou elipsu s oranžovým obrysem, používá [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) k nastavení hloubky na 4 body a aplikuje kruhové horní zkosení se šířkou a výškou 6 bodů pomocí [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). Frontální ortografická kamera a trojibodové osvětlení zpřístupňují zkosení.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidat 3D rotační efekty**

3D pohled tvaru řídí nastavení kamery. Tento příklad používá [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) s úhly šířky, výšky a rotace 40, 35 a 20 stupňů. Vybere izometrickou kameru pomocí [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) a vyvážené osvětlení pomocí [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), poté uloží formátovaný obdélník.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![3D rotační efekt](3D-rotation-effect.png)

## **Řídit černobílý rendering pro tvary**

Metoda [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) určuje, jak je jednotlivý tvar vykreslen při prohlížení nebo zpracování prezentace v černobílém režimu. Nezapíná černobílý režim samotný a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu ze třídy [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `Automatic` nechá aplikaci zvolit převod, `Gray` a `LightGray` použijí šedé zabarvení, `BlackWhite` použije pouze černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová normální barvy a `Hidden` vynechá tvar v černobílém režimu. `NotDefined` znamená, že nebyl přiřazen žádný režim na úrovni tvaru.

Tento příklad vytváří oranžový obdélník a pomocí [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) nastaví režim na šedou. Uložený tvar si zachová oranžovou výplň pro normální barevné zobrazení a požaduje šedé zabarvení od aplikací, které respektují nastavení černobílého zobrazení:

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
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

V normálním barevném režimu si obdélník zachová oranžovou výplň. V pracovním postupu černobílého zobrazení používá šedé zabarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat plnobarevný snímek a definovat odlišný vzhled pro tisk, náhled nebo jiné pracovní postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Resetovat formátování**

Použijte [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) k obnovení polohy, velikosti a formátování zástupných objektů snímku z jejich odpovídajících zástupných objektů rozložení. Tento příklad vyžaduje existující prezentaci se zástupnými objekty propojenými s rozložením a před uložením resetuje každý snímek. Tvary bez odpovídajících zástupných objektů rozložení nejsou resetovány.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené dotazy**

**Ovlivňuje formátování tvaru konečnou velikost souboru prezentace?**

Barvy, styly čar a nastavení efektů obecně přidávají jen málo dat ve srovnání s vloženými obrázky a médii. Výplně obrázků mohou velikost souboru zvýšit, protože jejich obrázky jsou uloženy v prezentaci.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky seskupte tyto tvary, což zjednoduší následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony snímků nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je to potřeba.