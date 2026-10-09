---
title: Alakzat effektusok alkalmazása prezentációkban JavaScript használatával
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/nodejs-java/shape-effect/
keywords:
- alakzat effektus
- árnyék effektus
- tükröződés effektus
- ragyogás effektus
- lágy élek effektus
- effektus formátum
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat effektusokkal JavaScript és az Aspose.Slides for Node.js segítségével – hozzon létre lenyűgöző, professzionális diákat néhány másodperc alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusok használhatók egy alakzat kiemelésére, eltérnek a [kitöltésektől](/slides/hu/nodejs-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint effektusok segítségével meggyőző tükröződéseket hozhatunk létre egy alakzaton, eloszthatjuk az alakzat ragyogását stb.

![Alakzat effektus](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy alakzatra egy vagy több effektust is alkalmazhat.

Néhány effektus kombináció szebben néz ki, mint mások. Emiatt a PowerPoint a **Preset** (Előbeállítás) alatt biztosít lehetőségeket. Az Előbeállítás opciók két vagy több effektus kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy előbeállítás kiválasztásával nem kell időt pazarolni különböző effektusok tesztelésére vagy kombinálására egy szép kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) osztály alatt olyan tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik, hogy ugyanazokat az effektusokat alkalmazza a PowerPoint prezentációk alakzataira.

## **Árnyék effektus alkalmazása**

Az Aspose.Slides for Node.js Java használatával támogatja a külső és belső árnyékokat alakzatokhoz. Testreszabhatja a színüket, irányukat, távolságukat és az elmosódási sugarat, hogy megfeleljenek a prezentációja dizájnjának.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttéréből. Az árnyék meghaladja az alakzat szélét, és azt az érzetet kelti, mintha az alakzat a dia fölött lenne. Állítsa be a színét, irányát, távolságát és az elmosódási sugarát, hogy megfeleljen a sablon fényviszonyainak és stílusának.

Ez a JavaScript kód bemutatja, hogyan alkalmazzon [külső árnyék effektust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Árnyék effektus](shadow_effect.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy egy kártyának vagy panelnek benyomott megjelenést adjon. A külső árnyék a forma külső részén nyúlik ki és azt emeltnek mutatja, míg a belső árnyék a szélek belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosódási sugárértékek lágyabb széleket eredményeznek.

Ez a JavaScript példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, a távolsága 7 pont, és az elmosódási sugara 6 pont:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat effektusformáján.

## **Tükröződés effektus alkalmazása**

A tükröződés effektus alkalmazásához az Aspose.Slides for Node.js Java használatával hozzáadhat tükörszerű visszaverődést az alakzatokhoz, beállítva olyan paramétereket, mint a távolság, átlátszóság és méret. Ez az effektus javítja a prezentációk esztétikáját azzal, hogy az alakzatoknak kifinomultabb, elegánsabb megjelenést kölcsönöz. Könnyen megvalósítható egyszerű kóddal, lehetővé téve a gyors alkalmazást több elemre a egységes dizájn érdekében.

Ez a JavaScript kód bemutatja, hogyan alkalmazzon [tükröződés effektust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Tükröződés effektus](reflection_effect.png)

## **Ragyogás effektus alkalmazása**

A ragyogás effektus alkalmazásához egy alakzatra az Aspose.Slides for Node.js Java használatával lágy, fénylő aurát adhat az alakzatok köré, beállítva olyan tulajdonságokat, mint a szín és a méret. Ez az effektus segít kiemelni az alakzatokat, és vonzó, szemrevaló vizuális elemet ad a prezentációjához. Könnyen megvalósítható minimális kóddal, javítva a diák összképét.

Ez a JavaScript kód bemutatja, hogyan alkalmazzon [ragyogás effektust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Ragyogás effektus](glow_effect.png)

## **Lágy élek effektus alkalmazása**

A lágy élek effektus alkalmazásához az Aspose.Slides for Node.js Java használatával sima, elmosódott átmenetet hozhat létre az alakzat szélein. Ez az effektus finomabb, kifinomultabb megjelenést ad, ideális olyan tervekhez, amelyeknek enyhe, lágyabb hatásra van szükségük. Könnyen állíthatja a sugár értékét, hogy a kívánt hatást elérje a prezentációja különböző alakzatai között.

Ez a JavaScript kód bemutatja, hogyan alkalmazzon [lágy élek effektust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Lágy élek effektus](soft_edges_effect.png)

## **GYIK**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**

Igen, különböző effektusokat, például árnyékot, tükröződést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Különböző alakzatokra alkalmazhat effektusokat, többek között automatikus alakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyebekre.

**Alkalmazhatok effektusokat csoportosított alakzatokra?**

Igen, a csoportosított alakzatokra is alkalmazhat effektusokat. Az effektus az egész csoportra lesz hatással.