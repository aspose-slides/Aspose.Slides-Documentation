---
title: Alakzat hatások alkalmazása prezentációkban Java használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/java/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- reflexió hatás
- ragyogás hatás
- lágy szélek hatás
- effektusformátum
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzathi hatáslarla az Aspose.Slides for Java segítségével—hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusai segítségével kiemelhet egy alakzatot, ezek különböznek a [kitöltésektől](/slides/hu/java/shape-formatting/#gradient-fill) vagy a körvonalaktól. PowerPoint effektusokkal meggyőző tükröződéseket hozhat létre egy alakzaton, terjesztheti az alakzat fénykibúvását stb.

![Shape effect](shape-effect.png)

A PowerPoint hat effektust biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több effektust is alkalmazhat egy alakzatra.

Néhány effektuskombináció jobb hatást kelt, mint mások. Emiatt a PowerPoint a **Preset** menüpont alatt lehetőségeket kínál. A Preset opciók két vagy több, jól kinéző effektus kombinációi. Így egy előre beállított elem kiválasztásával nem kell időt vesztegetnie különböző effektusok tesztelésére vagy kombinálására a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) osztályban biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat az effektusokat alkalmazza a PowerPoint bemutatók alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Java külső és belső árnyékokat támogat az alakzatokhoz. Testreszabhatja a színüket, irányukat, távolságukat és elmosódási sugarukat, hogy illeszkedjenek a bemutató tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérrel szemben. Az árnyék túlnyúlik az alakzat élein, ezáltal azt a benyomást keltve, mintha az alakzat a dia fölé lenne emelve. Állítsa be a színét, irányát, távolságát és elmosódási sugarát a sablon megvilágításához és stílusához illően.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [külső árnyékhatás](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) egy téglalapra:

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

![Shadow effect](shadow_effect.png)

### **Belső árnyék alkalmazása**

A sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat kívülére nyúlik és emelt hatást kelt, míg a belső árnyék az élek belsejét árnyékosra teszi.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) metódust, majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) által visszaadott árnyékot. A nagyobb elmosódási sugárértékek lágyabb éleket eredményeznek.

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) metódust az alakzat effektusformátumán.

## **Reflexióhatás alkalmazása**

Az Aspose.Slides for Java-ban a reflexióhatás alkalmazásához hozzáadhat tükörszerű tükröződést az alakzatokhoz, beállítva olyan paramétereket, mint a távolság, átlátszóság és méret. Ez a hatás javítja a bemutatók esztétikáját, elegánsabb, kifinomultabb megjelenést kölcsönözve az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, gyors alkalmazást biztosítva több elemre a konzisztens tervezés érdekében.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [reflexióhatás](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) egy alakzatra:

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

Az Aspose.Slides for Java-ban a ragyogás hatás alkalmazásához puha, fényes aurát adhat az alakzatok köré, beállítva a színt és méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, feltűnő vizuális elemet ad a bemutatóhoz. Minimális kóddal könnyen megvalósítható, javítva a diák általános megjelenését.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [ragyogás hatás](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) egy alakzatra:

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

![Glow effect](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

Az Aspose.Slides for Java-ban a lágy szélek hatás alkalmazásával sima, elmosódott átmenetet hozhat létre az alakzat szélein. Ez a hatás finomabb, kifinomultabb megjelenést ad, tökéletes a finom, lágyabb megjelenést igénylő tervekhez. Könnyen beállíthatja a sugár paraméterét, hogy a kívánt hatást elérje különböző alakzatoknál a bemutatóban.

Ez a Java kód bemutatja, hogyan kell alkalmazni a [lágy szélek hatás](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) egy alakzatra:

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

## **FAQ**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**

Igen, különböző effektusokat, például árnyékot, reflexiót és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Különböző alakzatokra alkalmazhat effektusokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok effektusokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat effektusokat. A hatás a teljes csoportra lesz alkalmazva.