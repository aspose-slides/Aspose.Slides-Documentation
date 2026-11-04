---
title: Alakzat hatások alkalmazása bemutatókban Androidon
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/androidjava/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- tükröződés hatás
- ragyogás hatás
- lágy szélek hatás
- hatás formátum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat hatásokkal az Aspose.Slides for Android Java‑on keresztül — hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusok használhatók egy alakzat kiemelésére, eltérnek a [kitöltésektől](/slides/hu/androidjava/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint effektusok segítségével meggyőző tükröződéseket hozhatunk létre egy alakzaton, kiterjeszthetjük az alakzat ragyogását, stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást kínál, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Bizonyos effektuskombinációk vonzóbbak, mint mások. Emiatt a PowerPoint a **Preset** alatt lehetőségeket biztosít. A Preset opciók két vagy több hatás kombinációi, amelyekről ismert, hogy jól néznek ki. Így egy előre beállítást kiválasztva nem kell időt vesztegetni a különböző hatások tesztelésével vagy kombinálásával, hogy jó kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) osztályban biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat az effektusokat alkalmazza a PowerPoint‑prezentációkban lévő alakzatokra.

## **Árnyék hatás alkalmazása**

Az Aspose.Slides for Android Java‑on keresztül támogatja a külső és belső árnyékokat az alakzatoknál. Testreszabhatja a színüket, irányukat, távolságukat és a homály rádiuszt, hogy megfeleljenek a prezentációja dizájnjának.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy a kártya vagy panel kiemelkedjen a dia hátteréből. Az árnyék túlnyúlik az alakzat szélén, így azt a benyomást keltve, mintha az alakzat a dia fölé lenne emelve. Állítsa be a színét, irányát, távolságát és a homály rádiuszt, hogy illeszkedjen a sablon megvilágításához és stílusához.

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

![Árnyék hatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának újraalkotásakor használjon belső árnyékot, hogy a kártya vagy panel inktójtaszerű megjelenést kapjon. A külső árnyék túlnyúlik az alakzaton és emelt hatást eredményez, míg a belső árnyék a szélek belsejét árnyékosabbá teszi.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) metódust, majd állítsa be a [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) által visszaadott árnyékot. A nagyobb homály rádiuszk értékek puhább éleket eredményeznek.

Ez a Java példában egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, a homály rádiusa pedig 6 pont:
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

## **Tükröződés hatás alkalmazása**

Az Aspose.Slides for Android Java‑on keresztül történő tükröződés hatás alkalmazásához hozzáadhat tükörszerű tükröződést az alakzatokhoz, beállítva például a távolságot, átlátszóságot és méretet. Ez a hatás javítja a prezentációk esztétikáját, mivel az alakzatok kifinomultabb, fényesebb megjelenést kapnak. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemen a konzisztens dizájn érdekében.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [tükröződés hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) egy alakzatra:
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

Az Aspose.Slides for Android Java‑on keresztül egy alakzatra való ragyogás hatás alkalmazásához puha, fényes aurát adhat az alakzatok köré, beállítva a szín és méret tulajdonságait. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemet vonzó vizuális elemként jelenik meg a prezentációban. Kicsi kóddal könnyen megvalósítható, javítva a diák átfogó megjelenését.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [ragyogás hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) egy alakzatra:
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

![Ragyogás hatás](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

Az Aspose.Slides for Android Java‑on keresztül a lágy szélek hatás alkalmazásához sima, elmosódott átmenetet hozhat létre az alakzat szélein. Ez a hatás finomabb, kifinomult megjelenést ad, tökéletes olyan tervekhez, amelyeknek enyhe, lágyabb kinézetre van szükségük. Könnyen beállíthatja a paramétereket, például a rádiust, a kívánt hatás eléréséhez különböző alakzatoknál a prezentációban.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [lágy szélek hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) egy alakzatra:
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

## **Elmosás hatás alkalmazása**

Használja a formaelmosást a forma kitöltésének és körvonalának lágyításához, miközben a forma szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metódust a forma effektusformátumán. A rádiust pontban mérik (1/72 hüvelyk): használjon nem negatív értéket, a nagyobb értékek erősebb elmosást eredményeznek. A nulla rádius változatlan megjelenést hagy.

A [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) beállítás szabályozza a hatás látható határait. `false` esetén az elmosás az eredeti festett határokra, beleértve a körvonalat, van vágva. `true` esetén az elmosás túlnyúlhat ezeken a határokon. Egyik beállítás sem változtatja meg a forma helyzetét vagy méreteit.

Az alábbi összehasonlításban mindenhol ugyanaz a kitöltés, körvonal és forma mérete van használva. A felső sor `grow = false`‑ot, az alsó sor `grow = true`‑t használ.
![Eredeti téglalap 5 és 15 pont elmosási rádiusokkal, a grow letiltva és engedélyezve](shape_blur_comparison.png)

Ez a Java példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pont elmosást alkalmaz, majd a [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) újrahívásával 15 pont elmosásra frissíti. Mindkét elmosott állapotot elmenti, majd a [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) hívásával menti a formát elmosás nélkül.
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

A formaelmosás egyszerre a kitöltést és a körvonalat érinti. A lágy szélek hatás elhalványítja a forma széleit, míg az árnyék elmosása csak az árnyékot lágyítja. A képelemző hatások a kép tartalmára hatnak; ez a példa közvetlenül a forma effektusformátumára alkalmaz elmosást, anélkül, hogy a formát képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, tükröződést és ragyogást, kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportos alakzatokra?**

Igen, a csoportos alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra vonatkozik.