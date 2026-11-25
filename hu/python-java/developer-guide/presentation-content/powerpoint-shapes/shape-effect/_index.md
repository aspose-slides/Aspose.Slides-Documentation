---
title: Alakzat hatások alkalmazása prezentációkban Python via Java
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/python-java/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- tükröződés hatás
- ragyogás hatás
- puha szélek hatás
- hatásformátum
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat hatásokkal az Aspose.Slides for Python via Java használatával — hozzon létre lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásai használhatók egy forma kiemelésére, különböznek a [kitöltésektől](/slides/hu/python-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásaival meggyőző tükröződéseket hozhat létre egy alakzaton, szórhatja az alakzat ragyogását stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást alkalmazhat egy alakzatra.

Egyes hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint a **Preset** menüpont alatt kínál opciókat. Az Előre beállított opciók két vagy több hatás kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy előre beállítást kiválasztva nem kell időt vesztegetni különböző hatások tesztelésével vagy kombinálásával a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Python via Java külső és belső árnyékokat támogat a alakzatoknál. Színét, irányát, távolságát és elmosódási sugarát testre szabhatja a prezentációja tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a diák háttérből. Az árnyék a forma széleit meghaladja, így benyomást keltve, mintha a forma a dia felett lenne emelve. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a sablon világításához és stílusához.

Ez a Python kód mutatja, hogyan lehet alkalmazni a [külső árnyékhatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

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

![Árnyékhatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Egy sablon vizuális stílusának újrateremtésekor használjon belső árnyékot, hogy a kártya vagy panel mélyedett megjelenést kapjon. A külső árnyék a forma külső oldalára nyúlik és emelt hatást kelt, míg a belső árnyék a szélek belsejét árnyékolja.

Hívja a [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) metódust, majd állítsa be a [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosódási sugárértékek puhábban határozzák meg a széleket.

Ez a Python példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, elmosódási sugara pedig 6 pont:

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

A belső árnyék eltávolításához hívja a [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat effektusformátumán.

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja a [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) metódust, majd a [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) segítségével válasszon egy [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) típust. A stílus váltásához módosítsa az előre beállítást ugyanazon az alakzaton. Hívja a [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) metódust az árnyék eltávolításához, miközben megőrzi a kitöltést és a körvonalat.

A példa minden lépésben lemásolja a téglalapot, így összehasonlíthatja a négy állapotot egymás mellett egy dián. Mindkét árnyék 10 ponttal van eltolva. A 225° irány az első árnyékot a téglalap fölé és balra helyezi. A 45° irány a másodikat alulra és jobbra helyezi.

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

| Eredeti | Első előre beállítás | Második előre beállítás | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső árnyék](preset_shadow_top_left.png) | ![Jobb alsó árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Tükröződés hatás alkalmazása**

Az Aspose.Slides for Python via Java használatával a tükröződés hatást úgy alkalmazhatja, hogy a alakzatokhoz tükörszerű visszaverődést ad, beállítva például a távolságot, átlátszóságot és méretet. Ez a hatás fokozza a prezentációk esztétikáját, polírozottabb és kifinomultabb megjelenést kölcsönözve az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a konzisztens dizájn érdekében.

Ez a Python kód bemutatja, hogyan lehet alkalmazni a [reflexiós hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:

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

![Reflexiós hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

Az Aspose.Slides for Python via Java-ben a ragyogás hatást úgy alkalmazhatja, hogy a alakzatok köré lágy, fénylő aurát ad, beállítva például a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemfelkeltő vizuális elemet ad a prezentációhoz. Minimális kóddal könnyen megvalósítható, javítva diák összképét.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [ragyogás hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:

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

![Ragyogás hatás](glow_effect.png)

## **Puhító szélek hatás alkalmazása**

Az Aspose.Slides for Python via Java-ben a puha szélek hatást úgy alkalmazhatja, hogy egy sima, elmosódott átmenetet hoz létre az alakzat szélein. Ez a hatás finomabb és kifinomultabb megjelenést ad, ideális olyan tervekhez, amelyeknek enyhe, lágyabb hatásra van szükségük. Könnyen beállíthatja a sugár értékét a kívánt hatás eléréséhez különféle alakzatoknál a prezentációban.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [puha szélek hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:

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

![Puhító szélek hatás](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használja az alakzat elmosódását a kitöltés és a körvonal lágyítására, miközben az alakzat szerkeszthető marad. Hívja a [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) metódust az alakzat effektusformátumán. A sugár pontokban (1/72 hüvelyk) mérve van: használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlan megjelenést hagy.

A [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) beállítás szabályozza a hatás látható határait. `False` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, lesz vágva. `True` esetén az elmosódás túlnyúlhat ezekre a határokra. Egyik beállítás sem változtatja az alakzat pozícióját vagy méreteit.

Az alábbi összehasonlítás egységes kitöltést, körvonalat és alakzati méreteket használ. A felső sor `grow = False` értéket, az alsó sor `grow = True` értéket használ.

![Eredeti téglalap összehasonlítva 5 és 15 pontos elmosódási sugárral, a grow letiltva és engedélyezve](shape_blur_comparison.png)

Ez a Python példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pontos elmosódást alkalmaz, majd egy újabb [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) hívással 15 pontos elmosódásra frissíti. Mindkét elmosódott állapotot menti, majd a [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) hívással menti az elmosódás nélküli alakzatot.

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

Az alakzat elmosódása egyszerre érinti a kitöltést és a körvonalat. A puha szélek hatás a forma széleit halványítja, míg az árnyék elmosódása csak az árnyékot lágyítja. A képek átalakítási hatásai a kép tartalmára hatnak; ez a példa közvetlenül az alakzat effektusformátumára alkalmaz elmosódást, anélkül, hogy az alakzatot képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, kombinálhat különböző hatásokat, például árnyékot, reflexiót és ragyogást egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, alkalmazhat hatásokat csoportosított alakzatokra. A hatás az egész csoportra vonatkozik.