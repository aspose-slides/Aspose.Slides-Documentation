---
title: Alakzat effektusok alkalmazása bemutatókban JavaScript segítségével
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/nodejs-java/shape-effect/
keywords:
- alakzat effektus
- árnyék effektus
- visszaverődés effektus
- ragyogás effektus
- lágy szél effektus
- effektus formátum
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat effektusokkal JavaScript és Aspose.Slides for Node.js használatával — hozzon létre lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusok használhatók egy alakzat kiemelésére, eltérnek a [kitöltések](/slides/hu/nodejs-java/shape-formatting/#gradient-fill) vagy a kontúrokól. A PowerPoint effektusokkal meggyőző visszaverődéseket hozhat létre egy alakzaton, eloszthatja az alakzat ragyogását stb.

![Alakzat effektus](shape-effect.png)

A PowerPoint hat effektust biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több effektust is alkalmazhat egy alakzatra.

Néhány effektuskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt lehetőségeket kínál. A Preset lehetőségek két vagy több effektus kombinációi, amelyekről ismert, hogy jól mutatnak. Így egy preset kiválasztásával nem kell időt vesztegetni a különböző effektusok tesztelésével vagy kombinálásával a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) osztály alatt olyan tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik ugyanazoknak az effektusoknak az alkalmazását PowerPoint előadásban lévő alakzatokra.

## **Árnyék effektus alkalmazása**

Az Aspose.Slides for Node.js via Java támogatja a külső és belső árnyékokat alakzatokhoz. Testreszabhatja azok színét, irányát, távolságát és elmosódási radiusát, hogy illeszkedjenek a bemutató tervezéséhez.

## **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttér előtt. Az árnyék túlnyúlik az alakzat szélén, ezáltal azt a benyomást keltve, mintha az alakzat a dia felett lenne. Állítsa be a színét, irányát, távolságát és elmosódási radiusát, hogy megfeleljen a sablon fény- és stílusbeállításainak.

Ez a JavaScript kód bemutatja, hogyan kell alkalmazni a [külső árnyék effektust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:
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

## **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel mélyedett megjelenést kapjon. A külső árnyék kifelé nyúlik az alakzaton, és azt kelti, hogy az emelkedett, míg a belső árnyék az alakzat szélén belül árnyékol.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) metódust, majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosódási sugarú értékek lágyabb szélűek.

Ez a JavaScript példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlba menti. Az árnyék iránya 225 fok, távolsága 7 pont, és elmosódási sugara 6 pont:
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

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat effektus formátumán.

## **Visszaverődés effektus alkalmazása**

A visszaverődés effektus alkalmazásához az Aspose.Slides for Node.js via Java segítségével hozzáadhat tükörszerű visszaverődést alakzatokhoz, beállítva például a távolságot, átlátszóságot és méretet. Ez az effektus javítja a bemutatók esztétikáját, elegánsabb és kifinomultabb megjelenést adva az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a konzisztens tervezés érdekében.

Ez a JavaScript kód bemutatja, hogyan kell alkalmazni a [visszaverődés effektus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:
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

![Visszaverődés effektus](reflection_effect.png)

## **Ragyogás effektus alkalmazása**

A ragyogás effektus alkalmazásához egy alakzatra az Aspose.Slides for Node.js via Java segítségével hozzáadhat egy lágy, fényes aurát az alakzat körül, beállítva a szín és méret tulajdonságait. Ez az effektus segít kiemelni az alakzatokat, és vonzó, szemfelé ragadó vizuális elemet ad a bemutatóhoz. Minimális kóddal könnyen megvalósítható, javítva a diákat teljes megjelenését.

Ez a JavaScript kód bemutatja, hogyan kell alkalmazni a [ragyogás effektus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:
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

## **Lágy szél effektus alkalmazása**

A lágy szél effektus alkalmazásához az Aspose.Slides for Node.js via Java segítségével egy sima, elmosódott átmenetet hozhat létre egy alakzat szélein. Ez az effektus finomabb és kifinomultabb megjelenést ad, ideális olyan tervezésekhez, amelyeknek enyhe, lágyabb megjelenésre van szükségük. Könnyedén állíthatja be a paramétereket, például a sugarat, hogy a kívánt hatást elérje különböző alakzatokon a bemutatóban.

Ez a JavaScript kód bemutatja, hogyan kell alkalmazni a [lágy szél effektus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:
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

![Lágy szél effektus](soft_edges_effect.png)

## **Elmosódás effektus alkalmazása**

Használja a forma elmosódását a forma kitöltésének és kontúrájának lágyításához, miközben a forma szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) metódust az alakzat effektus formátumán. A sugár pontban mérve (1/72 hüvelyk): használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlanul hagyja a megjelenést.

A [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) beállítás szabályozza az effektus látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, lesz vágva. `true` esetén az elmosódás túlnyúlhat ezeken a határokon. Egyik beállítás sem változtatja meg az alakzat pozícióját vagy méreteit.

Az alábbi összehasonlítás ugyanazt a kitöltést, kontúrt és alakzati méreteket használja mindenhol. A felső sor `grow = false`-t használ; az alsó sor `grow = true`-t.

![Eredeti téglalap összehasonlítva 5 és 15 pontos elmosódási sugarakkal, grow letiltva és engedélyezve](shape_blur_comparison.png)

Ez a JavaScript példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pontos elmosódást alkalmaz, majd egy újabb [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) hívással 15 pontos elmosódásra frissíti. Mindkét elmosódott állapotot menti, majd meghívja a [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) metódust, és elmenti az alakzatot elmosódás nélkül.
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A forma elmosódása egyszerre befolyásolja a kitöltést és a kontúrt. A lágy szél effektus elhalványítja a forma széleit, míg az árnyék elmosódása csak az árnyékot lágyítja. A képtranszformációs effektusok a képtartalmon működnek; ez a példa közvetlenül a forma effektus formátumára alkalmaz elmosódást, alakzatot képpé konvertálva nélkül.

## **GYIK**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**

Igen, különböző effektusokat, például árnyékot, visszaverődést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Különféle alakzatokra alkalmazhat effektusokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok effektusokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat effektusokat. Az effektus az egész csoportra lesz alkalmazva.