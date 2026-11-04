---
title: Použití efektů tvarů v prezentacích pomocí Pythonu přes Java
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/python-java/shape-effect/
keywords:
- efekt tvaru
- efekt stínu
- odrazový efekt
- efekt záře
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro Python přes Java—vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/python-java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint nabízí možnosti pod **Předvolba**. Možnosti Předvolby jsou kombinace dvou nebo více efektů, o nichž je známo, že vypadají dobře. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/), které vám umožní použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použití stínového efektu**

Aspose.Slides pro Python via Java podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly návrhu vaší prezentace.

### **Použití vnějšího stínu**

Použijte vnější stín, aby karta nebo panel vynikl na pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že je tvar nadzvednutý nad snímek. Upravit jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

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

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel získala zapuštěný vzhled. Vnější stín přesahuje mimo tvar a způsobí, že se zdá být zvednutý, zatímco vnitřní stín stínuje vnitřní část jeho okrajů.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), pak nakonfigurujte stín vrácený metodou [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Větší hodnoty poloměru rozostření vytvoří měkčí hrany.

Tento Python příklad vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX. Směr stínu je 225 stupňů, jeho vzdálenost je 7 bodů a poloměr rozostření je 6 bodů:

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

Chcete-li odstranit vnitřní stín, zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formát efektu tvaru.

## **Použití odrazového efektu**

Chcete-li použít odrazový efekt v Aspose.Slides pro Python via Java, můžete přidat zrcadlový odraz k tvarům a upravit parametry, jako jsou vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvarům dodává uhlazenější a sofistikovanější vzhled. Je snadné ho implementovat pomocí jednoduchého kódu, což umožňuje rychlé použití na více prvcích pro jednotný design.

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

## **Použití efektu záře**

Chcete-li aplikovat efekt záře na tvar v Aspose.Slides pro Python via Java, můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, upoutávající vizuální prvek do vaší prezentace. Je snadné ho implementovat s minimálním kódem, což zlepšuje celkový vzhled vašich snímků.

Tento Python kód ukazuje, jak použít [efekt záře](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) na tvar:

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

![Efekt záře](glow_effect.png)

## **Použití efektu měkkých okrajů**

Chcete-li použít efekt měkkých okrajů v Aspose.Slides pro Python via Java, můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává subtilnější a elegantnější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Můžete snadno upravit parametry, jako je poloměr, abyste dosáhli požadovaného efektu u různých tvarů ve vaší prezentaci.

Tento Python kód ukazuje, jak použít [efekt měkkých okrajů](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) na tvar:

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

![Efekt měkkých okrajů](soft_edges_effect.png)

## **Použití rozostřeného efektu**

Použijte rozostření tvaru k zeslabení výplně a obrysu tvaru při zachování možnosti úprav. Zavolejte [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) na formát efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty způsobí silnější rozostření. Poloměr nula ponechává vzhled nezměněn.

Nastavení [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) řídí viditelné hranice efektu. S `False` je rozostření oříznuto na původní vykreslené hranice, včetně obrysu. S `True` může rozostření přesáhnout tyto hranice. Žádné z nastavení nemění pozici ani rozměry tvaru.

Níže uvedené srovnání používá stejnou výplň, obrys a rozměry tvaru. Horní řada používá `grow = False`; spodní řada používá `grow = True`.

![Původní obdélník porovnaný s poloměry rozostření 5 a 15 bodů, s vypnutým a zapnutým zvětšením](shape_blur_comparison.png)

Tento Python příklad vytvoří oranžový obdélník s tmavě modrým obrysem, použije 5bodové rozostření a poté ho aktualizuje na 15bodové rozostření opětovným voláním [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Uloží oba rozostřené stavy, poté zavolá [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) a uloží tvar bez rozostření.

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

Rozostření tvaru ovlivňuje výplň i obrys společně. Efekt měkkých okrajů zeslabuje hrany tvaru, zatímco rozostření stínu zeslabuje jen stín. Efekty transformace obrázku působí na obsah obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru, aniž by tvar převáděl na obrázek.

## **Často kladené dotazy**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jediném tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.