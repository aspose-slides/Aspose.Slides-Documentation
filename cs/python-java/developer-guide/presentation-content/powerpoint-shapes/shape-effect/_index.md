---
title: Použití efektů tvarů v prezentacích pomocí Pythonu přes Java
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/python-java/shape-effect/
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých hran
- formát efektu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů v Aspose.Slides pro Python přes Java—vytvořte úchvatné, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [výplní](/slides/cs/python-java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint nabízí možnosti pod **Preset**. Předvolby jsou kombinace dvou nebo více efektů, o nichž se ví, že vypadají dobře. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli pěknou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody pod třídou [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/), které umožňují použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použití stínového efektu**

Aspose.Slides pro Python via Java podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření, aby odpovídaly designu vaší prezentace.

### **Použití vnějšího stínu**

Použijte vnější stín, aby karta nebo panel vynikl oproti pozadí snímku. Stín se rozprostírá za okraji tvaru a vytváří dojem, že je tvar nad snímkem. Přizpůsobte jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento Python kód ukazuje, jak použít [vnější stínový efekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) na obdélník:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Stínový efekt](shadow_effect.png)

### **Použití vnitřního stínu**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel měl zapuštěný vzhled. Vnější stín se rozprostírá mimo tvar a dává mu vzhled zvýšeného, zatímco vnitřní stín zesvětluje vnitřní okraje.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), poté nakonfigurujte stín vrácený metodou [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Větší hodnoty poloměru rozostření produkují měkčí okraje.

Tento Python příklad vytvoří světlemodrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX. Směr stínu je 225 stupňů, vzdálenost 7 bodů a poloměr rozostření 6 bodů:

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Světle modrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Pro odebrání vnitřního stínu zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formátu efektu tvaru.

### **Použití, změna a odebrání přednastaveného stínu**

Zavolejte [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), poté použijte [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) pro výběr [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). Pro změnu stylu změňte předvolbu na stejném tvaru. Zavolejte [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) pro odebrání stínu při zachování výplně a obrysu.

Příklad klonuje obdélník v každé fázi, takže můžete porovnat všechny čtyři stavy vedle sebe na jednom snímku. Oba stíny jsou posunuté o 10 bodů. Směr 225° umisťuje první stín nad a vlevo od obdélníku. Směr 45° umisťuje druhý pod a vpravo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Originál | První předvolba | Druhá předvolba | Po odebrání |
| :---: | :---: | :---: | :---: |
| ![Žádný stín](preset_shadow_original.png) | ![Stín nahoře vlevo](preset_shadow_top_left.png) | ![Stín dole vpravo](preset_shadow_bottom_right.png) | ![Žádný stín po odebrání](preset_shadow_removed.png) |

## **Použití odrazového efektu**

Pro použití odrazového efektu v Aspose.Slides pro Python via Java můžete přidat zrcadlový odraz na tvary a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt vylepšuje estetiku vašich prezentací tím, že tvary získají uhlazený a sofistikovaný vzhled. Je snadné jej implementovat jednoduchým kódem, což umožňuje rychlé použití napříč více prvky pro konzistentní design.

Tento Python kód ukazuje, jak použít [odrazový efekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) na tvar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Odrazový efekt](reflection_effect.png)

## **Použití zářivého efektu**

Pro použití zářivého efektu na tvar v Aspose.Slides pro Python via Java můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, upoutávající vizuální prvek do vaší prezentace. Je snadné jej implementovat s minimálním kódem, což zlepšuje celkový vzhled vašich snímků.

Tento Python kód ukazuje, jak použít [zářivý efekt](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) na tvar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Zářivý efekt](glow_effect.png)

## **Použití efektu měkkých hran**

Pro použití efektu měkkých hran v Aspose.Slides pro Python via Java můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro designy, které potřebují jemný, měkčí vzhled. Jednoduše můžete upravit parametry jako poloměr, abyste dosáhli požadovaného efektu napříč různými tvary v prezentaci.

Tento Python kód ukazuje, jak použít [efekt měkkých hran](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) na tvar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efekt měkkých hran](soft_edges_effect.png)

## **Použití rozostření**

Použijte rozostření tvaru ke změkčení výplně a obrysu tvaru při zachování editovatelnosti tvaru. Zavolejte [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) na formátu efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž vyšší hodnoty vytvářejí silnější rozostření. Poloměr nula ponechává vzhled beze změny.

Nastavení [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) řídí viditelné ohraničení efektu. S hodnotou `False` je rozostření oříznuto na původní vykreslené ohraničení, včetně obrysu. S hodnotou `True` může rozostření přesáhnout tato ohraničení. Žádné nastavení nemění pozici ani rozměry tvaru.

Porovnání níže používá stejnou výplň, obrys a rozměry tvaru po celou dobu. Horní řada používá `grow = False`; spodní řada používá `grow = True`.

![Originální obdélník porovnaný s rozostřením 5 a 15 bodů, s vypnutým a zapnutým rostem](shape_blur_comparison.png)

Tento Python příklad vytvoří oranžový obdélník s tmavě modrým obrysem, použije 5‑bodové rozostření a poté jej aktualizuje na 15‑bodové rozostření opětovným voláním [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Uloží oba rozostřené stavy, pak zavolá [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) a uloží tvar bez rozostření.

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rozostření tvaru postihuje výplň i obrys společně. Efekt měkkých hran zeslabuje okraje tvaru, zatímco rozostření stínu změkčuje pouze stín. Efekty transformace obrazu pracují s obsahem obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru bez převodu tvaru na obrázek.

## **Často kladené otázky**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu použít efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.