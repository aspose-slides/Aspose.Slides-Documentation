---
title: Alakzat effektusok alkalmazása prezentációkban a Python via Java használatával
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/python-java/shape-effect/
keywords:
- alakzat effektus
- árnyék effektus
- reflexió effektus
- ragyogás effektus
- puhított élek effektus
- effektusformátum
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat effektusokkal az Aspose.Slides for Python via Java segítségével – hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusok használhatók egy alakzat kiemelésére, különböznek a [kitöltésektől](/slides/hu/python-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. PowerPoint effektusokkal meggyőző tükröződéseket hozhat létre egy alakzaton, eloszlathatja annak ragyogását, stb.

![Alakzat effektus](shape-effect.png)

A PowerPoint hat effektust biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több effektust is alkalmazhat egy alakzatra.

Néhány effektuskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt lehetőségeket biztosít. Az előbeállítások két vagy több effektus kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy előbeállítás kiválasztásával nem kell időt vesztegetnie különböző effektusok tesztelésével vagy kombinálásával, hogy jó kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) osztályban olyan tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik ugyanazon effektusok alkalmazását PowerPoint prezentációk alakzatain.

## **Árnyék effektus alkalmazása**

Az Aspose.Slides for Python via Java külső és belső árnyékokat támogat alakzatokra. Színét, irányát, távolságát és elmosási sugarát testre szabhatja a prezentációja tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttéréből. Az árnyék túlnyúlik az alakzat szélén, ezáltal úgy tűnik, mintha az alakzat a dia felett lebegne. Állítsa be a színét, irányát, távolságát és elmosási sugarát, hogy illeszkedjen a sablonja megvilágításához és stílusához.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [külső árnyék effektust](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

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

![Árnyék effektus](shadow_effect.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel visszahúzott megjelenést kapjon. A külső árnyék az alakzat kívülére nyúlik és emeltté teszi, míg a belső árnyék a szélek belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) metódust, majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosási sugárértékek lágyabb éleket eredményeznek.

Ez a Python példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti el. Az árnyék iránya 225 fok, a távolsága 7 pont, az elmosási sugara pedig 6 pont:

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

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat effektusformátumán.

## **Reflexió effektus alkalmazása**

A reflexió effektus alkalmazásához az Aspose.Slides for Python via Java segítségével tükörszerű tükröződést adhat alakzatokhoz, beállítva például a távolságot, átlátszóságot és méretet. Ez az effektus javítja a prezentációk esztétikáját, mivel elegánsabb, kifinomultabb megjelenést kölcsönöz az alakzatoknak. Könnyen megvalósítható egyszerű kóddal, lehetővé téve a gyors alkalmazást több elemre a konzisztens tervezés érdekében.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [reflexió effektust](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:

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

![Reflexió effektus](reflection_effect.png)

## **Ragyogás effektus alkalmazása**

A ragyogás effektus alkalmazásához egy alakzatra az Aspose.Slides for Python via Java segítségével lágy, fényes aurát adhat a formáknak, szín és méret tulajdonságok beállításával. Ez az effektus segít kiemelni az alakzatokat, és vonzó, szemrevaló vizuális elemet ad a prezentációjához. Könnyen megvalósítható minimális kóddal, javítva a diák összképét.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [ragyogás effektust](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:

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

![Ragyogás effektus](glow_effect.png)

## **Puhított élek effektus alkalmazása**

A puhított élek effektus alkalmazásához az Aspose.Slides for Python via Java segítségével egy sima, elmosott átmenetet hozhat létre egy alakzat élei körül. Ez az effektus finomabb és kifinomultabb megjelenést ad, tökéletes a gyengédebb, lágyabb kinézetet igénylő tervekhez. Könnyen állíthatja a sugár paramétert, hogy a kívánt hatást elérje különböző alakzatok esetén a prezentációban.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [puhított élek effektust](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:

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

![Puhított élek effektus](soft_edges_effect.png)

## **Elmosás effektus alkalmazása**

Használja a formaelmosást az alakzat kitöltésének és körvonalának lágyításához, miközben az alakzat szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) metódust az alakzat effektusformátumán. A sugár pontban van mérve (1/72 hüvelyk): használjon nemnegatív értéket, a nagyobb értékek erősebb elmosást eredményeznek. A nulla sugarú beállítás nem változtatja meg a megjelenést.

A [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) beállítás szabályozza az effektus látható határait. `False` esetén az elmosás az eredeti festett határokra, beleértve a körvonalat, lesz vágva. `True` esetén az elmosás túlnyúlhat ezekre a határokra. Egyik beállítás sem változtatja meg az alakzat pozícióját vagy méreteit.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és alakzati méreteket használja. A felső sor a `grow = False` értéket, az alsó sor a `grow = True` értéket használja.

![Eredeti téglalap elmosási sugarakkal 5 és 15 pont, a növekedés letiltva és engedélyezve](shape_blur_comparison.png)

Ez a Python példa egy narancssárga téglalapot hoz létre sötétkék körvonalakkal, 5 pontos elmosást alkalmaz, majd ugyanazt 15 pontos elmosásra módosít a [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) újbóli meghívásával. Mindkét elmosott állapotot elmenti, majd meghívja a [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) metódust, és elmenti az alakzatot elmosás nélkül.

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

A formaelmosás egyszerre érinti a kitöltést és a körvonalat. A puhított élek effektus elhalványítja az alakzat széleit, míg az árnyék elmosás csak az árnyékot lágyítja. A képenkénti átalakító effektusok a kép tartalmán működnek; ez a példa közvetlenül az alakzat effektusformátumára alkalmaz elmosást, anélkül, hogy az alakzatot képpé konvertálná.

## **GYIK**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**

Igen, több különböző effektust – például árnyékot, reflexiót és ragyogást – kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Különféle alakzatokra alkalmazhat effektusokat, beleértve az autoshape‑eket, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok effektusokat csoportos alakzatokra?**

Igen, csoportos alakzatokra is alkalmazhat effektusokat. Az effektus az egész csoportra lesz hatással.