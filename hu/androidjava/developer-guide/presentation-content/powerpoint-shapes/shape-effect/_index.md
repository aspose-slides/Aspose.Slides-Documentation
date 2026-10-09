---
title: Alakzateffektusok alkalmazása prezentációkban Androidon
linktitle: Alakzateffektus
type: docs
weight: 30
url: /hu/androidjava/shape-effect/
keywords:
- alakzateffektus
- árnyékhatás
- reflexióhatás
- fénylődés hatás
- lágy szélek hatás
- effektusformátum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzateffektusokkal az Aspose.Slides for Android via Java segítségével -- hozzon létre lenyűgöző, professzionális diákat néhány másodperc alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusai egy alakzat kiemelésére használhatók, különböznek a [kitöltésektől](/slides/hu/androidjava/shape-formatting/#gradient-fill) vagy körvonalaktól. PowerPoint effektusok használatával meggyőző reflexiókat hozhat létre egy alakzaton, szórhatja az alakzat fénylődését stb.

![Shape effect](shape-effect.png)

A PowerPoint hat hatást kínál, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Bizonyos effektuskombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint **Preset** menüpontra kínál lehetőségeket. Az előre beállított lehetőségek két vagy több hatás kombinációi, amelyekről tudják, hogy jól mutatnak. Így egy előre beállítást választva nem kell időt vesztegetnie különböző hatások tesztelésére vagy kombinálására egy szép kombináció megtalálásához.

Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) osztály alatt biztosít tulajdonságokat és metódusokat, amelyekkel ugyanazokat az effektusokat alkalmazhatja PowerPoint‑prezentációkban lévő alakzatokra.

## **Árnyékhatás alkalmazása**

Aspose.Slides for Android Java‑hoz támogatja a külső és belső árnyékokat az alakzatoknál. Testreszabhatja a színüket, irányukat, távolságukat és a elmosódási sugarat, hogy illeszkedjenek a prezentáció tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérrel szemben. Az árnyék az alakzat szélei túlra nyúlik, így a benyomást kelti, hogy az alakzat a dia fölé emelkedik. Állítsa be a színét, irányát, távolságát és az elmosódási sugarat, hogy megfeleljen a sablon megvilágításának és stílusának.

Ez a Java kód bemutatja, hogyan alkalmazzon [külső árnyékhatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) egy téglalapra:

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

![Árnyékhatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel mélyedett megjelenést kapjon. A külső árnyék az alakzat külső részén nyúlik ki és emelkedettnek mutatja, míg a belső árnyék az alakzat belső szélei felé árnyékol.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) által visszaadott árnyékot. A nagyobb elmosódási sugár értékek lágyabb éleket eredményeznek.

Ez a Java példa egy világoskék kártyát hoz létre, amelynek sötétszürke belső árnyéka van, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, elmosódási sugara 6 pont:

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

## **Reflexiós hatás alkalmazása**

A Aspose.Slides for Android Java‑hoz a reflexiós hatás alkalmazásához hozzáadhat tükörszerű reflexiót az alakzatokhoz, beállíthatja a távolságot, átlátszóságot és méretet. Ez a hatás javítja a prezentációk esztétikáját, mivel az alakzatok letisztultabb és kifinomultabb megjelenést kapnak. Egyszerű kóddal könnyen megvalósítható, gyorsan alkalmazható több elemre a konzisztens dizájn érdekében.

Ez a Java kód bemutatja, hogyan alkalmazzon [reflexiós hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) egy alakzatra:

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

![Reflexiós hatás](reflection_effect.png)

## **Fénylődés hatás alkalmazása**

A Aspose.Slides for Android Java‑hoz a fénylődés hatás alkalmazásával lágy, fényes aurát adhat az alakzatok köré, szín és méret tulajdonságait beállítva. Ez a hatás segít kiemelni az alakzatokat és vonzó, szemrevaló vizuális elemet ad a prezentációhoz. Minimális kóddal könnyen megvalósítható, javítva a diák általános megjelenését.

Ez a Java kód bemutatja, hogyan alkalmazzon [fénylődés hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) egy alakzatra:

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

![Fénylődés hatás](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

A Aspose.Slides for Android Java‑hoz a lágy szélek hatás alkalmazásával simított, elmosódott átmenetet hozhat létre az alakzat szélein. Ez a hatás finomabb és kifinomultabb megjelenést ad, ami tökéletes a kevésbé éles, lágyabb kinézetet igénylő tervekhez. A paramétereket, például a sugarat könnyen beállíthatja, hogy a kívánt hatást elérje a prezentáció különböző alakzatai között.

Ez a Java kód bemutatja, hogyan alkalmazzon [lágy szélek hatást](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) egy alakzatra:

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

## **GYIK**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**  
Igen, különböző effektusokat – például árnyékot, reflexiót és fénylődést – kombinálhat egyetlen alakzaton a dinamikusabb megjelenés érdekében.

**Milyen alakzatokra alkalmazhatok effektusokat?**  
Különféle alakzatokra alkalmazhat effektusokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt elemeket, OLE objektumokat és egyebeket.

**Alkalmazhatok effektusokat csoportosított alakzatokra?**  
Igen, effektusokat alkalmazhat csoportosított alakzatokra is. A hatás az egész csoportra lesz érvényes.