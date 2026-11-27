---
title: "Alakzat-hatások alkalmazása prezentációkban Python via Java segítségével"
linktitle: "Alakzat hatás"
type: docs
weight: 30
url: /hu/python-java/shape-effect/
keywords:
- "alakzat hatás"
- "árnyék hatás"
- "tükröződés hatás"
- "ragyogás hatás"
- "lágy szélű hatás"
- "hatásformátum"
- "PowerPoint"
- "prezentáció"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat-hatásokkal az Aspose.Slides for Python via Java segítségével—hozzon létre lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait felhasználhatja egy alakzat kiemelésére, különböznek a [kitöltésektől](/slides/hu/python-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásainak használatával meggyőző tükröződéseket hozhat létre egy alakzaton, terjesztheti az alakzat ragyogását stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást kínál, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Egyes hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint **Preset** alatt lehetőségeket biztosít. Az Előbeállítások olyan két vagy több hatás kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy előbeállítás kiválasztásával nem kell időt vesztegetni a különböző hatások tesztelésével vagy kombinálásával egy szép kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) osztály alatt olyan tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint előadásban lévő alakzatokra.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Python via Java külső és belső árnyékokat támogat a alakzatoknál. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjenek a prezentációja tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a diavetítés hátteréből. Az árnyék a alakzat szélei túlra nyúlik, ezáltal azt a benyomást keltve, hogy az alakzat a dia fölé emelkedik. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablonja megvilágításának és stílusának.

Ez a Python kód bemutatja, hogyan lehet alkalmazni a [külső árnyék hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

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

#### **Az árnyék irányának vezérlése, amikor egy alakzat elforog**

Alapértelmezés szerint a külső árnyék az alakzattal együtt forog. Ahhoz, hogy a különböző elforgatású alakzatok ugyan abból az irányból legyenek megvilágítva, hívja a [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) metódust `False` értékkel, és használja a [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) metódust, hogy az árnyékok ugyanazt az irányt kapják.

A példa két kék nyilat hoz létre szürke árnyékokkal, amelyek 42 ponttal jobbra vannak eltolva (0°). Ezután megkettőzi a diát, és a két nyilat 90°-kal az óramutató járásával megegyező irányban forgatja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A második dián a bal nyíl lefelé vet árnyékot, míg a jobb nyíl továbbra is jobbra vet árnyékot. A beállított irány mindkét árnyék esetében 0° marad.

![PowerPoint megjelenítés 90° forgatás előtt és után. Mindkét árnyék jobb oldalról indul. Forgatás után az árnyék a bal nyíl alá kerül, és a jobb nyíl jobb oldalán marad.](arrow-shadow-rotation.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel benyomult megjelenést kapjon. A külső árnyék az alakzaton kívülre nyúlik és emelt hatást kelt, míg a belső árnyék az élek belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) metódust, majd állítsa be a [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosódási sugár értékek lágyabb széleket eredményeznek.

Ez a Python példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, és elmosódási sugara 6 pont:

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

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat effektus formáján.

### **Előbeállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) metódust, majd használja a [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) metódust egy [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) kiválasztásához. A stílusok váltásához módosítsa az előbeállítást ugyanazon az alakzaton. Hívja meg a [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) metódust az árnyék eltávolításához, miközben megőrzi a kitöltést és a körvonalat.

A példa minden lépésben klónozza a téglalapot, így egy dián négy állapotot tud összehasonlítani egymás mellett. Mindkét árnyék 10 ponttal van eltolva. A 225° irány az első árnyékot a téglalap fölé és balra helyezi. A 45° irány a másodikat alulra és jobbra helyezi.

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

| Eredeti | Első előbeállítás | Második előbeállítás | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső vetett árnyék](preset_shadow_top_left.png) | ![Jobb alsó vetett árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Tükröződés hatás alkalmazása**

Az Aspose.Slides for Python via Java segítségével tükröződés hatást alkalmazhat, amely tükörszerű tükröződést ad az alakzatokhoz, beállítva például a távolságot, átlátszóságot és méretet. Ez a hatás fokozza a prezentációk esztétikáját, elegáns és kifinomult megjelenést kölcsönözve az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, gyorsan alkalmazható több elemre a konzisztens tervezés érdekében.

Ez a Python kód bemutatja, hogyan lehet alkalmazni a [tükröződés hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:

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

![Tükröződés hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

Az Aspose.Slides for Python via Java segítségével egy alakzatra ragyogás hatást alkalmazhat, amely puha, fényes aurát ad az alakzat köré, beállítva például a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemet gyönyörködtető vizuális elemet ad a prezentációhoz. Könnyen megvalósítható minimális kóddal, javítva a diák általános megjelenését.

Ez a Python kód bemutatja, hogyan lehet alkalmazni a [ragyogás hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:

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

## **Lágy szélű hatás alkalmazása**

Az Aspose.Slides for Python via Java segítségével lágy szélű hatást alkalmazhat, amely sima, elmosódott átmenetet hoz létre az alakzat szélei körül. Ez a hatás finomabb és kifinomultabb megjelenést ad, tökéletes azoknak a terveknek, amelyek enyhe, lágyabb megjelenést igényelnek. Könnyen beállíthatók a paraméterek, például a sugár, a kívánt hatás eléréséhez a prezentáció különböző alakzataiban.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [lágy szélű hatást](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:

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

![Lágy szélű hatás](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használjon alakzat elmosódást a kitöltés és a körvonal lágyításához, miközben az alakzat szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) metódust az alakzat effektus formáján. A sugár pontban (1/72 hüvelyk) mérhető: használjon nem negatív értéket, ahol a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlanul hagyja a megjelenést.

A [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) beállítás szabályozza a hatás látható határait. `False` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, van vágva. `True` esetén az elmosódás túl is nyúlhat ezeken a határokon. Egyik beállítás sem módosítja az alakzat pozícióját vagy méreteit.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és alakzat méreteket használja mindenhol. A felső sor `grow = False`‑t alkalmaz; az alsó sor `grow = True`‑t.

![Eredeti téglalap összehasonlítva 5 és 15 pont elmosódási sugarakkal, a növekedés letiltva és engedélyezve](shape_blur_comparison.png)

Ez a Python példa egy narancssárga téglalapot hoz létre sötétkék körvonaljal, 5 pont elmosódást alkalmaz, majd egy [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) újbóli meghívásával 15 pont elmosódásra frissíti. Mindkét elmosódott állapotot menti, majd meghívja a [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) metódust, és menti az alakzatot elmosódás nélkül.

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

Az alakzat elmosódás egyaránt befolyásolja a kitöltést és a körvonalat. A lágy szélű hatás elhalványítja az alakzat éleit, míg az árnyék elmosódása csak az árnyékot lágyítja. A képtranszformációs hatások a képtartalmon működnek; ez a példa közvetlenül az alakzat effektus formájára alkalmaz elmosódást, alakzat képpé konvertálása nélkül.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, tükröződést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra tudok hatásokat alkalmazni?**

Különféle alakzatokra tud hatásokat alkalmazni, többek között automatikus alakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyebekre.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra vonatkozik.