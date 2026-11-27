---
title: Alakzat effektusok alkalmazása Android prezentációkban
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/androidjava/shape-effect/
keywords:
- alakzat effektus
- árnyék effektus
- tükröződés effektus
- ragyogás effektus
- lágy szélek effektus
- effektus formátum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat effektusokkal az Aspose.Slides for Android via Java segítségével—hozzon létre lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusok használhatók egy alakzat kiemelésére, eltérnek a [kitöltések](/slides/hu/androidjava/shape-formatting/#gradient-fill) vagy körvonalaktól. PowerPoint effektusokkal meggyőző tükröződéseket hozhatunk létre egy alakzaton, szórhatjuk az alakzat ragyogását stb.

![Alakzat effektus](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több effektust is alkalmazhat egy alakzatra.

Néhány effektuskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt lehetőségeket kínál. A Preset beállítások két vagy több, jó hatású kombinációt jelentenek. Így egy előre beállított opció kiválasztásával nem kell időt pazarolni a különböző effektusok tesztelésével vagy kombinálásával egy szép megoldás megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) osztály alatt tulajdonságokat és metódusokat biztosít, amelyekkel a PowerPoint prezentációkban lévő alakzatokra ugyanazokat az effektusokat alkalmazhatja.

## **Árnyék effektus alkalmazása**

Az Aspose.Slides for Android via Java támogatja a külső és belső árnyékokat alakzatokhoz. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugárát, hogy illeszkedjen a bemutató dizájnjához.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérből. Az árnyék túlnyúlik az alakzat szélén, és azt a benyomást kelti, hogy az alakzat emelkedett a dián. Állítsa be a színét, irányát, távolságát és elmosódási sugárát a sablon megvilágításához és stílusához.

Ez a Java kód bemutatja, hogyan alkalmazhatja a [külső árnyék effektust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) egy téglalapra:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Árnyék effektus](shadow_effect.png)

#### **Az árnyék irányának vezérlése alakzat forgatásakor**

Alapértelmezés szerint a külső árnyék az alakzattal együtt forog. Hogy a különböző forgatású alakzatok ugyanabból az irányból legyenek megvilágítva, hívja meg a [setRotateShadowWithShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) metódust `false` értékkel, és használja a [setDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setDirection-float-) metódust, hogy ugyanazt az irányt adja az árnyékoknak.

A példa két kék nyilat hoz létre szürke árnyékokkal, amelyek 42 ponttal jobbra vannak eltolva (0°). Ezután megduplázza a diát, és mindkét nyilat 90°-kal óramutató járásával megegyező irányba forgatja.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(128, 128, 128));
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A második diáron a bal nyíl lefelé vet árnyékot, míg a jobb nyíl továbbra is jobbra vet. A beállított irány mindkét árnyék esetén 0° marad.

![PowerPoint ábrázolás 90° forgatás előtt és után. Mindkét árnyék jobb oldalon kezdődik. Forgatás után az árnyék a bal nyíl alá kerül, a jobb nyíl jobb oldalán marad.](arrow-shadow-rotation.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy egy kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat kívülére nyúlik, és azt eredményezi, hogy az emelkedettnek tűnik, míg a belső árnyék az alakzat szélén belül árnyékol.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) metódust, majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) által visszaadott árnyékot. A nagyobb elmosódási sugár értékek lágyabb széleket eredményeznek.

Ez a Java példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, majd PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, elmosódási sugara 6 pont:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) metódust az alakzat effektusformátumán.

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) metódust, és használja a [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) metódust egy [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) kiválasztásához. A stílusok váltásához változtassa meg a presetet ugyanazon alakzaton. Az [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) metódus eltávolítja az árnyékot, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa négy szakaszt mutat egymás mellett egy dián. Mindkét árnyék 10 ponttal van eltolva. A 225°-os irány az első árnyékot a téglalap bal felső részébe helyezi, a 45°-os irány a másodikat jobb alsó részbe.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

| Eredeti | Első előre beállítás | Második előre beállítás | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Tükröződés effektus alkalmazása**

A tükröződés effektus Aspose.Slides for Android via Java segítségével egyszerűen hozzáadható alakzatokhoz, a távolság, átlátszóság és méret paramétereit szabályozva. Ez az effektus fokozza a prezentáció esztétikáját, professzionálisabb megjelenést kölcsönözve az alakzatoknak. Könnyen megvalósítható egyszerű kóddal, gyors alkalmazást biztosítva több elemre a konzisztens tervezés érdekében.

Ez a Java kód bemutatja, hogyan alkalmazhatja a [tükröződés effektust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) egy alakzatra:

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

![Tükröződés effektus](reflection_effect.png)

## **Ragyogás effektus alkalmazása**

Az Aspose.Slides for Android via Java segítségével ragyogás effektust adhat az alakzatok köré, a szín és méret tulajdonságok beállításával. Ez az effektus segít kiemelni az alakzatokat, és vonzó, szemköröző vizuális elemet ad a prezentációnak. Könnyen megvalósítható minimális kóddal, javítva a diák összképét.

Ez a Java kód bemutatja, hogyan alkalmazhatja a [ragyogás effektust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) egy alakzatra:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Ragyogás effektus](glow_effect.png)

## **Lágy szélek effektus alkalmazása**

Az Aspose.Slides for Android via Java segítségével lágy szélek effektust hozhat létre, amely sima, elmosódott átmenetet biztosít az alakzat szélein. Ez az effektus finomabb, kifinomultabb megjelenést kölcsönöz, tökéletes azoknak a tervezéseknek, amelyeknek enyhébb, lágyabb hatásra van szükségük. Könnyen állíthatja a sugár paraméterét a kívánt eredmény eléréséhez az egész prezentációban.

Ez a Java kód bemutatja, hogyan alkalmazhatja a [lágy szélek effektust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) egy alakzatra:

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

![Lágy szélek effektus](soft_edges_effect.png)

## **Elmosódás effektus alkalmazása**

Használja az alakzat elmosódását a kitöltés és a körvonal puhításához, miközben az alakzat tovább szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metódust az alakzat effektusformátumán. A sugár pontban (1/72 hüvelyk) mérve, nemnegatív értékkel adható meg; a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlan megjelenést hagy.

A [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) beállítás szabályozza az effektus látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, lesz levágva. `true` esetén az elmosódás meghaladhatja ezeket a határokat. Egyik beállítás sem módosítja az alakzat pozícióját vagy méretét.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és alakzatformátumot használja. A felső sorban `grow = false`; az alul `grow = true`.

![Eredeti téglalap összehasonlítva 5 és 15 pont elmosódási sugarakkal, a növekedés ki- és bekapcsolásával](shape_blur_comparison.png)

Ez a Java példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pont elmosódást alkalmaz, majd 15 pont elmosódásra frissíti a [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) újbóli meghívásával. Mindkét elmosódott állapotot menti, majd a [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) meghívásával elmenti az alakzatot elmosódás nélkül.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

Az alakzat elmosódása egyszerre befolyásolja a kitöltést és a körvonalat. A lágy szélek effektus a forma széleit halványítja, míg az árnyék elmosódása csak az árnyékot lágyítja. A képtranszformációs effektusok a képtartalmon működnek; ez a példa közvetlenül a forma effektusformátumára alkalmazza az elmosódást, anélkül, hogy a formát képpé alakítaná.

## **GYIK**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**

Igen, különböző effektusokat, például árnyékot, tükröződést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Különféle alakzatokra alkalmazhat effektusokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok effektusokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat effektusokat. Az effektus az egész csoportra lesz alkalmazva.