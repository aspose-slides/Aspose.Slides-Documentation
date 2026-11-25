---
title: Alakzat hatások alkalmazása prezentációkban Java használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/java/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- tükröződés hatás
- ragyogás hatás
- lágy szélek hatás
- hatás formátum
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat-hatásokkal az Aspose.Slides for Java használatával – hozzon létre lenyűgöző, professzionális diákat néhány másodperc alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait egy alakzat kiemelésére lehet használni, eltérnek a [kitöltésektől](/slides/hu/java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásainak használatával hiteles tükröződéseket hozhatunk létre egy alakzaton, eloszthatjuk az alakzat ragyogását stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt lehetőségeket kínál. A Preset beállítások két vagy több hatás kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy preset kiválasztásával nem kell időt vesztegetni a különböző hatások tesztelésével vagy kombinálásával, hogy megtalálja a megfelelő kombinációt.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) osztályban biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint előadások alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Java a külső és belső árnyékokat támogatja az alakzatokhoz. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljenek az előadás tervezésének.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérrel szemben. Az árnyék túlnyúlik az alakzat szélén, és azt az benyomást kelti, mintha az alakzat a dia fölé emelkedne. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a sablon fényviszonyaihoz és stílusához.

Ez a Java kód bemutatja, hogyan alkalmazhatja a [külső árnyékhatást](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) egy téglalapra:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Árnyékhatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat kívülre nyúlik, és azt a benyomást kelti, mintha fel lenne emelve, míg a belső árnyék az éleik belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) metódust, majd állítsa be a [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) által visszaadott árnyékot. Nagyobb elmosódási sugárértékek lágyabb éleket eredményeznek.

Ez a Java példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, és elmosódási sugara 6 pont:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) metódust az alakzat effektusformátumán.

### **Preset árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) metódust, és használja a [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) metódust egy [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) kiválasztásához. A stílusok váltásához változtassa meg a presetet ugyanazon az alakzaton. Hívja meg a [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) metódust az árnyék eltávolításához, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa négy szakaszt mutat egymás mellett egy dián. Mindkét árnyék 10 ponttal van eltolva. A 225°-os irány az első árnyékot a téglalap felett és bal oldalán helyezi el, a 45°-os irány a másodikat alul és jobbra helyezi.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Eredeti | Első preset | Második preset | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső vetett árnyék](preset_shadow_top_left.png) | ![Jobb alsó vetett árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Tükröződés hatás alkalmazása**

Az Aspose.Slides for Java-ban a tükröződés hatás alkalmazásához hozzáadhat tükörszerű tükröződést az alakzatokhoz, és beállíthatja a távolságot, az átlátszóságot és a méretet. Ez a hatás javítja a prezentációk esztétikáját, polírozottabb és kifinomultabb megjelenést kölcsönözve az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a konzisztens tervezés érdekében.

Ez a Java kód bemutatja, hogyan alkalmazhatja a [tükröződés hatást](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) egy alakzatra:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Tükröződés hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

Az Aspose.Slides for Java-ban egy alakzatra a ragyogás hatás alkalmazásához hozzáadhat egy lágy, fényes aurát az alakzatok körül, és beállíthatja a színt és méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemfelébb vonzó vizuális elemet ad a prezentációhoz. Kevés kóddal könnyen megvalósítható, javítva a diák általános megjelenését.

Ez a Java kód bemutatja, hogyan alkalmazhatja a [ragyogás hatást](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) egy alakzatra:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Ragyogás hatás](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

Az Aspose.Slides for Java-ban a lágy szélek hatás alkalmazásához létrehozhat egy sima, elmosódott átmenetet az alakzat szélén. Ez a hatás finomabb és kifinomultabb megjelenést ad, tökéletes olyan tervekhez, amelyeknek enyhe, lágyabb kinézetre van szükségük. Könnyen beállíthatja a sugár értékét, hogy a kívánt hatást elérje a prezentáció különféle alakzatai között.

Ez a Java kód bemutatja, hogyan alkalmazhatja a [lágy szélek hatást](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) egy alakzatra:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Lágy szélek hatás](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Készítsen alakzat elmosódást a kitöltés és a körvonal lágyításához, miközben az alakzat szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metódust az alakzat effektusformátumán. A sugár pontban (1/72 hüvelyk) van mérve: használjon nem negatív értéket, nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár nem változtatja a megjelenést.

A [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, lesz vágva. `true` esetén az elmosódás túl is léphet ezeken a határokon. Egyik beállítás sem változtatja az alakzat helyzetét vagy méretét.

Az alábbi összehasonlításban mindenhol ugyanazt a kitöltést, körvonalat és alakzati méreteket használja. A felső sor `grow = false`; az alsó sor `grow = true`.

![Eredeti téglalap összehasonlítva 5 és 15 pont elmosódási sugárral, grow letiltva és engedélyezve](shape_blur_comparison.png)

Ez a Java példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pont elmosódást alkalmaz, majd a [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) újbóli meghívásával 15 pont elmosódásra frissíti. Mindkét elmosódott állapotot elmenti, majd a [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) meghívásával elmenti az árnyék nélküli alakzatot.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alakzat elmosódás a kitöltést és a körvonalat együtt érinti. A lágy szélek hatás elhalványítja az alakzat éleit, míg az árnyék elmosódás csak az árnyékot lágyítja. A képek átalakítási hatásai a kép tartalmára vonatkoznak; ez a példa közvetlenül az alakzat effektusformátumára alkalmaz elmosódást, alakzat képpé alakítása nélkül.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különféle hatásokat, például árnyékot, tükröződést és ragyogást kombinálhat egyetlen alakzaton, így dinamikusabb megjelenést hozva létre.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra lesz alkalmazva.