---
title: Alakzathatások alkalmazása Android előadásokban
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/androidjava/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- reflexió hatás
- ragyogás hatás
- lágy szélek hatás
- hatás formátum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzateffektusokkal az Aspose.Slides for Android via Java segítségével—hozzon létre lenyűgöző, professzionális diákot pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPointben lévő hatások egy alakzat kiemelésére használhatók, különböznek a [kitöltésektől](/slides/hu/androidjava/shape-formatting/#gradient-fill) vagy körvonalaktól. PowerPoint hatások segítségével meggyőző visszatükrözéseket hozhat létre egy alakzaton, szétterítheti az alakzat ragyogását stb.

![Shape effect](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt beállításokat kínál. A Preset beállítások két vagy több hatás kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy előre beállítást kiválasztva nem kell időt vesztegetni a különböző hatások tesztelésével vagy kombinálásával, hogy megtalálja a jó kombinációt.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint előadások alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Android via Java külső és belső árnyékokat támogat a alakzatokhoz. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjenek az előadás dizájnjához.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a diák háttéréből. Az árnyék meghaladja az alakzat széleit, így benyomást keltve, hogy az alakzat a dia fölött emelkedik. Igazítsa a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablon megvilágításának és stílusának.

Ez a Java kód bemutatja, hogyan lehet alkalmazni a [külső árnyék hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) egy téglalapra:
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

![Shadow effect](shadow_effect.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel mélyedett megjelenést kapjon. A külső árnyék az alakzat kívülére nyúlik, és emelkedettnek tűnik, míg a belső árnyék az élei belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) metódust, majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) által visszaadott árnyékot. A nagyobb elmosódási sugárértékek lágyabb éleket eredményeznek.

Ez a Java példa egy világoskék kártyát hoz létre sötét szürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, elmosódási sugara pedig 6 pont:
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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) metódust az alakzat effektusformátumán.

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) metódust, és használja a [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) metódust egy [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) kiválasztásához. Stílusváltáshoz módosítsa az előre beállítást ugyanazon az alakzaton. Hívja meg a [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) metódust az árnyék eltávolításához, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa négy szakaszt mutat egymás mellett egy dián. Mindkét árnyék 10 ponttal el van tolva. A 225° irány az első árnyékot a téglalap fölé és balra helyezi, a 45° irány a másodikat alulra és jobbra helyezi.
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
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső árnyék](preset_shadow_top_left.png) | ![Jobb alsó árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Visszatükrözés hatás alkalmazása**

Az Aspose.Slides for Android via Java segítségével visszatükrözés hatást alkalmazhat, amely tükörszerű visszatükrözést ad az alakzatoknak, és beállíthatja a távolságot, átlátszóságot és méretet. Ez a hatás fokozza az előadások esztétikáját, mivel az alakzatokat kifinomultabb és elegánsabb megjelenésűvé teszi. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre egységes design érdekében.

Ez a Java kód bemutatja, hogyan lehet alkalmazni a [reflexió hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) egy alakzatra:
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

![Reflection effect](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

Az Aspose.Slides for Android via Java segítségével ragyogás hatást alkalmazhat egy alakzatra, amely lágy, fényes aurát ad az alakzaton, és beállíthatja a színt és méretet. Ez a hatás segít kiemelni az alakzatokat és vonzó, szemfelébresztő vizuális elemet ad az előadáshoz. Könnyen megvalósítható minimális kóddal, javítva a diák általános megjelenését.

Ez a Java kód bemutatja, hogyan lehet alkalmazni a [ragyogás hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) egy alakzatra:
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

![Glow effect](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

Az Aspose.Slides for Android via Java segítségével lágy szélek hatást alkalmazhat, amely a forma szélein sima, elmosódott átmenetet hoz létre. Ez a hatás finomabb és kifinomultabb megjelenést ad, tökéletes olyan tervekhez, amelyeknek enyhe, lágyabb megjelenésre van szükségük. Könnyen állíthatja a paramétereket, például a sugarat, hogy elérje a kívánt hatást különböző alakzatoknál a bemutatóban.

Ez a Java kód bemutatja, hogyan lehet alkalmazni a [lágy szélek hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) egy alakzatra:
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

![Soft edges effect](soft_edges_effect.png)

## **Elmosás hatás alkalmazása**

Használja a forma elmosását a kitöltés és a körvonal elmosásához, miközben a forma szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metódust a forma effektusformátumán. A sugár pontban (1/72 hüvelyk) mérve: használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlan megjelenést hagy.

A [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, van vágva. `true` esetén az elmosódás túlnyúlhat ezek fölé. Egyik beállítás sem változtatja meg a forma helyzetét vagy méreteit.

A lenti összehasonlítás ugyanazt a kitöltést, körvonalat és forma méreteket használja mindvégig. A felső sor `grow = false`-t használ; az alsó sor `grow = true`-t használ.

![Eredeti téglalap összehasonlítva 5 és 15 pont elmosódási sugárral, `grow` letiltva és engedélyezve](shape_blur_comparison.png)

Ez a Java példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pontos elmosódást alkalmaz, majd a [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) újbóli meghívásával 15 pontos elmosódásra frissíti. Mindkét elmosódott állapotot menti, majd a [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) metódust meghívva elmenti a formát elmosás nélkül.
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

A forma elmosása egyszerre a kitöltést és a körvonalat érinti. A lágy szélek hatás a forma széleit halványítja, míg az árnyék elmosása csak az árnyékot lágyítja. A képtranszformációs hatások a képtartalmon működnek; ez a példa közvetlenül a forma effektusformátumára alkalmaz elmosást anélkül, hogy a formát képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, több különböző hatást, például árnyékot, visszatükrözést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportos alakzatokra?**

Igen, csoportos alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra lesz alkalmazva.