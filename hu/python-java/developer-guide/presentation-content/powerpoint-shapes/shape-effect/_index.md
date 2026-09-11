---
title: Alakzateffektusok alkalmazása prezentációkban Pythonon keresztül Java-val
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/python-java/shape-effect/
keywords:
- alakzateffektus
- árnyékhatás
- tükröződés hatás
- ragyogás hatás
- lágy szegélyek hatás
- effektus formátum
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzateffektusokkal az Aspose.Slides Python Java integrációval — hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

A PowerPoint‑ben a hatások a alakzat kiemelésére használhatók, de különböznek a [kitöltésektől](/slides/hu/python-java/shape-formatting/#gradient-fill) vagy a kontúroktól. PowerPoint‑hatások segítségével meggyőző tükröződéseket készíthet egy alakzaton, szórhatja az alakzat ragyogását stb.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* A PowerPoint hat hatást biztosít, amelyek alkalmazhatók alakzatokra. Egy vagy több hatást is alkalmazhat egy alakzatra. 

* Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint lehetőségeket kínál a **Preset** alatt. Az Előre beállított lehetőségek tulajdonképpen két vagy több hatás kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy előre beállított kiválasztásával nem kell időt vesztegetni a különböző hatások tesztelésével vagy kombinálásával a jó kombináció megtalálásához.

Aspose.Slides tulajdonságokat és metódusokat biztosít a [EffectFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effectformat/) osztály alatt, amelyek lehetővé teszik a PowerPoint‑prezentációk alakzataira ugyanazoknak a hatásoknak az alkalmazását.

## **Árnyékhatás alkalmazása**

Ez a Python kód bemutatja, hogyan alkalmazhatja a külső árnyékhatást ([EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effectformat/#getOuterShadowEffect)) egy téglalapra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tükröződés alkalmazása**

Ez a Python kód bemutatja, hogyan alkalmazhatja a tükröződés hatást egy alakzatra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ragyogás hatás alkalmazása**

Ez a Python kód bemutatja, hogyan alkalmazhatja a ragyogás hatást egy alakzatra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lágy szegélyek hatás alkalmazása**

Ez a Python kód bemutatja, hogyan alkalmazhatja a lágy szegélyek hatást egy alakzatra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat – például árnyékot, tükröződést és ragyogást – kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Hatásokat különféle alakzatokra alkalmazhat, köztük automatikus alakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyebekre.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, a csoportosított alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra érvényesül.