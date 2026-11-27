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
- puháélek hatás
- hatás formátum
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat hatásokkal az Aspose.Slides for Java segítségével—hozzon létre lenyűgöző, professzionális diákot másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásai használhatók egy alakzat kiemelésére, különböznek a [kitöltésektől](/slides/hu/java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásával meggyőző tükröződéseket hozhat létre egy alakzaton, eloszthatja az alakzat ragyogását stb.

![Alakzathatás](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint lehetőségeket kínál a **Preset** alatt. A Preset lehetőségek két vagy több hatás kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy preset kiválasztásával nem kell időt pazarolnia a különböző hatások tesztelésére vagy kombinálására, hogy egy jó kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) osztályban biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik ugyanazon hatások alkalmazását a PowerPoint prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Java támogatja a külső és belső árnyékokat az alakzatokhoz. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljenek a prezentáció tervezésének.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérből. Az árnyék a forma szélei túlra nyúlik, és azt a benyomást kelti, mintha a forma a dia fölé lenne emelve. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a sablon fénykörülményeihez és stílusához.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [külső árnyékhatást](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) egy téglalapra:

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

#### **Az árnyék irányának szabályozása alakzat forgatásakor**

Alapértelmezés szerint a külső árnyék az alakzattal együtt forog. Ahhoz, hogy a különböző forgatásokkal rendelkező alakzatok ugyanabból az irányból legyenek megvilágítva, hívja meg a [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) metódust `false` értékkel, és használja a [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-) metódust, hogy árnyékuknak ugyanazt az irányt adja.

A példa két kék nyilat hoz létre szürke árnyékkal, amelyek 42 ponttal jobbra (0°) vannak eltolva. Ezután megkettőzi a diát, és mindkét nyilat 90°-kal jobbra forgatja.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
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

A második dián a bal nyíl lefelé vet árnyékot, míg a jobb nyíl továbbra is jobbra vet árnyékot. A beállított irány mindkét árnyék esetén 0° marad.

![PowerPoint megjelenítés 90° forgatás előtt és után. Mindkét árnyék a jobb oldalon kezdődik. Forgatás után az árnyék a bal nyíl alatt helyezkedik el, és a jobb nyílnál jobbra marad.](arrow-shadow-rotation.png)

### **Belső árnyék alkalmazása**

Sablon vizuális megjelenésének reprodukálásakor használjon belső árnyékot, hogy egy kártya vagy panel mélyedő hatást kapjon. A külső árnyék a forma kívülre nyúlik, és emelteként mutatja, míg a belső árnyék a szélek belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) metódust, majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) által visszaadott árnyékot. A nagyobb elmosódási sugárértékek lágyabb széleket eredményeznek.

Ez a Java példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, elmosódási sugara 6 pont:

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

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) metódust az alakzat effekt formátumán.

### **Preset árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) metódust, és használja a [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) metódust egy [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) kiválasztásához. A stílusok váltásához módosítsa a presetet ugyanazon az alakzaton. Hívja meg a [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) metódust az árnyék eltávolításához, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa négy állapotot mutat egymás mellett egy dián. Mindkét árnyék 10 ponttal el van tolva. A 225° irány az első árnyékot a téglalap fölé és balra helyezi, a 45° irány a másodikat alá és jobbra.

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
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső eső árnyék](preset_shadow_top_left.png) | ![Jobb alsó eső árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Tükröződés hatás alkalmazása**

Az Aspose.Slides for Java-ban a tükröződés hatás alkalmazásához hozzáadhat tükörszerű tükröződést az alakzatokhoz, beállítva például a távolságot, átlátszóságot és méretet. Ez a hatás javítja a prezentációk esztétikáját, mivel az alakzatok kifinomultabb, elegánsabb megjelenést kapnak. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a konzisztens dizájn érdekében.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [tükröződés hatást](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) egy alakzatra:

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

Az Aspose.Slides for Java-ban egy alakzatra a ragyogás hatás alkalmazásához puha, fénylő aurát adhat az alakzatok köré, beállítva például a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemrevaló vizuális elemet ad a prezentációhoz. Minimális kóddal könnyen megvalósítható, javítva a diák általános megjelenését.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [ragyogás hatást](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) egy alakzatra:

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

## **Puhákélek hatás alkalmazása**

Az Aspose.Slides for Java-ban a puháélek hatás alkalmazásához létrehozhat sima, elmosódott átmenetet egy alakzat szélein. Ez a hatás finomabb és kifinomultabb megjelenést ad, ideális olyan tervekhez, amelyeknek enyhe, lágyabb megjelenésre van szükségük. Könnyen beállíthatja a paramétereket, például a sugarat, hogy a kívánt hatást elérje a prezentáció különböző alakzatai között.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [puhákélek hatást](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) egy alakzatra:

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

![Puhákélek hatás](soft_edges_effect.png)

## **Elmosás hatás alkalmazása**

Használja a forma elmosását, hogy lágyabbá tegye a forma kitöltését és körvonalát, miközben a forma szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metódust a forma effekt formátumán. A sugár pontban van mérve (1/72 hüvelyk): használjon nemnegatív értéket, a nagyobb értékek erősebb elmosást eredményeznek. A nulla sugár változatlanul hagyja a megjelenést.

A [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) beállítás szabályozza a hatás látható határait. `false` esetén az elmosás az eredeti festett határokra, beleértve a körvonalat, lesz vágva. `true` esetén az elmosás túlnyúlhat ezen határokon. Egyik beállítás sem változtatja meg a forma pozícióját vagy méretét.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és forma méreteket használja mindvégig. A felső sor `grow = false`-t használ; az alsó sor `grow = true`-t.

![Eredeti téglalap összehasonlítva 5 és 15 pont elmosódási sugárral, a grow letiltva és engedélyezve](shape_blur_comparison.png)

Ez a Java példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, alkalmaz egy 5 pontos elmosást, majd egy újabb [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) hívással 15 pontos elmosásra frissíti. Mindkét elmosott állapotot menti, majd meghívja a [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) metódust, és menti a formát elmosás nélkül.

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

A forma elmosás a kitöltést és a körvonalat együtt érinti. A puháélek hatás a forma széleit halványítja, míg az árnyék elmosás csak az árnyékot lágyítja. A képtranszformációs hatások a kép tartalmán működnek; ez a példa közvetlenül a forma effekt formátumára alkalmaz elmosást anélkül, hogy a formát képpé alakítaná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, mint például árnyék, tükröződés és ragyogás, egyetlen alakzatra kombinálhat, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, többek között autoshape-ekre, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyebekre.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra lesz alkalmazva.