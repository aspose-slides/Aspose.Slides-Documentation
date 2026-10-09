---
title: Alakzat-hatások alkalmazása prezentációkban Python via Java használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/python-java/shape-effect/
keywords:
- alakzat hatás
- árnyékhatás
- tükröződési hatás
- ragyogás hatás
- lágy szegélyek hatás
- hatásformátum
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat-hatásokkal az Aspose.Slides for Python via Java használatával — hozzon létre lenyűgöző, professzionális diákat néhány másodperc alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait felhasználhatja egy alakzat kiemelésére, ezek különböznek a [kitöltésektől](/slides/hu/python-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásaival meggyőző tükröződéseket hozhat létre egy alakzaton, elnyújthatja az alakzat ragyogását stb.

![Shape effect](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt opciókat kínál. A Preset beállítások két vagy több hatás kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy előre beállítást kiválasztva nem kell időt pazarolnia különböző hatások tesztelésére vagy kombinálására egy szép kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) osztály alatt tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik ugyanazon hatások alkalmazását PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Python via Java támogatja a külső és belső árnyékokat alakzatokra. Testreszabhatja a színüket, irányukat, távolságukat és a elmosódási sugárukat, hogy illeszkedjenek a prezentáció tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a diák háttérétől. Az árnyék túlnyúlik az alakzat szélein, így a benyomást kelti, mintha az alakzat a dia fölé lenne emelve. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablon világításának és stílusának.

Ez a Python‑kód bemutatja, hogyan lehet alkalmazni a [külső árnyék hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

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

![Shadow effect](shadow_effect.png)

### **Belső árnyék alkalmazása**

Amikor egy sablon vizuális stílusát reprodukálja, használjon belső árnyékot, hogy a kártya vagy panel belevonódott megjelenést kapjon. A külső árnyék az alakzat kívülére nyúlik, és emelt hatást kelt, míg a belső árnyék az élékek belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) metódust, majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosódási sugár értékek lágyabb széleket eredményeznek.

Ez a Python‑példa világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX‑fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, elmosódási sugara 6 pont:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat hatásformátumán.

## **Tükröződési hatás alkalmazása**

A tükröződési hatás alkalmazásához az Aspose.Slides for Python via Java‑ban hozzáadhat tükörszerű tükröződést alakzatokhoz, beállítva például a távolságot, átlátszóságot és méretet. Ez a hatás fokozza a prezentációk esztétikáját azáltal, hogy az alakzatok kifinomultabb, precíz megjelenést kapnak. Könnyen megvalósítható egyszerű kóddal, amely gyors alkalmazást tesz lehetővé több elemre a konzisztens tervezés érdekében.

Ez a Python‑kód bemutatja, hogyan lehet alkalmazni a [tükröződési hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:

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

![Reflection effect](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

A ragyogás hatás alkalmazásához egy alakzaton az Aspose.Slides for Python via Java‑ban lágy, fénylő aurát adhat a körülöttük, a szín és a méret tulajdonságait állítva. Ez a hatás segít kiemelni az alakzatokat és vonzó, szemkáprázó vizuális elemet ad a prezentációnak. Könnyen megvalósítható minimális kóddal, amely javítja a diák általános megjelenését.

Ez a Python‑kód bemutatja, hogyan lehet alkalmazni a [ragyogás hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:

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

![Glow effect](glow_effect.png)

## **Lágy szegélyek hatás alkalmazása**

A lágy szegélyek hatás alkalmazásához az Aspose.Slides for Python via Java‑ban egy sima, elmosódott átmenetet hozhat létre az alakzat szélén. Ez a hatás finomabb és kifinomultabb megjelenést ad, ami tökéletes a gyengébb, lágyabb kinézetet igénylő tervekhez. Könnyen beállíthatja a sugár paramétert a kívánt hatás eléréséhez a prezentáció különböző alakzatai között.

Ez a Python‑kód bemutatja, hogyan lehet alkalmazni a [lágy szegélyek hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:

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

![Soft edges effect](soft_edges_effect.png)

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, tükröződést és ragyogást kombinálhat egyetlen alakzatra, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az autoshape‑eket, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportos alakzatokra?**

Igen, a hatásokat csoportos alakzatokra is alkalmazhatja. A hatás az egész csoportra érvényesül.