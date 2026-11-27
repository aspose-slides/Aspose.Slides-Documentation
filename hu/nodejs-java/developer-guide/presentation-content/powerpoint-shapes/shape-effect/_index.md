---
title: Alakzat hatások alkalmazása prezentációkban JavaScript segítségével
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/nodejs-java/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- visszatükrözés hatás
- ragyogás hatás
- lágy szélek hatás
- hatás formátum
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alakítsd át PPT és PPTX fájljaidat fejlett alakzat hatásokkal JavaScript és Aspose.Slides for Node.js használatával—hozz létre lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait használhatja egy alakzat kiemelésére, különböznek a [kitöltésektől](/slides/hu/nodejs-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásait használva meggyőző visszatükrözéseket hozhat létre egy alakzaton, kiterjesztheti az alakzat ragyogását stb.

![Alakzat hatása](shape-effect.png)

A PowerPoint hat hatást kínál, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt lehetőségeket kínál. Az Preset opciók két vagy több hatás kombinációi, amelyekről ismert, hogy jól néznek ki. Így egy előre beállított választásával nem kell időt vesztegetnie a különféle hatások tesztelésével vagy kombinálásával a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik ugyanazon hatások alkalmazását PowerPoint‑prezentációk alakzataira.

## **Árnyék hatás alkalmazása**

Az Aspose.Slides for Node.js via Java külső és belső árnyékokat támogat az alakzatokhoz. Testreszabhatja a színüket, irányukat, távolságukat és a elmosódási sugárukat, hogy illeszkedjenek a prezentáció tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttér előtt. Az árnyék a forma szélei túlra nyúlik, és azt a benyomást kelti, hogy a forma a dia fölé emelkedik. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a sablon megvilágításához és stílusához.

Ez a JavaScript kód bemutatja, hogyan alkalmazhatja a [külső árnyék hatást](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

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

![Árnyék hatás](shadow_effect.png)

#### **Az árnyék irányának vezérlése, amikor egy alakzat forog**

Alapértelmezés szerint a külső árnyék a formával együtt forog. Ahhoz, hogy a különböző forgatású alakzatok ugyanabból az irányból legyenek megvilágítva, hívja a [setRotateShadowWithShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setRotateShadowWithShape) metódust `false` értékkel, és használja a [setDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setDirection) metódust, hogy ugyanazt az irányt adja az árnyékoknak.

A példa két kék nyilat hoz létre szürke árnyékokkal, amelyek 42 ponttal jobbra el vannak tolva (0°). Ezután megkettőzi a diát, és mindkét nyilat 90°-kal az óramutató járásával megegyező irányban forgatja.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const before = presentation.getSlides().get_Item(0);
    
    const left = before.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    left.getFillFormat().getSolidFillColor().setColor(fillColor);
    left.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    left.getEffectFormat().enableOuterShadowEffect();
    const shadow = left.getEffectFormat().getOuterShadowEffect();
    const shadowColor = java.getStaticFieldValue("java.awt.Color", "GRAY");
    shadow.getShadowColor().setColor(shadowColor);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    const right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    const after = presentation.getSlides().addClone(before);
    const arrows = after.getShapes();
    for (let i = 0; i < arrows.size(); i++) {
        arrows.get_Item(i).setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A második dián a bal nyíl lefelé vet árnyékot, míg a jobb nyíl továbbra is jobbra vet árnyékot. A beállított irány mindkét árnyék esetén 0° marad.

![PowerPoint megjelenítés 90° forgatás előtt és után. Mindkét árnyék a jobb oldalon kezdődik. Forgatás után az árnyék a bal nyíl alá kerül, és a jobb nyíl jobb oldalán marad.](arrow-shadow-rotation.png)

### **Belső árnyék alkalmazása**

A sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel benyomuló megjelenést kapjon. A külső árnyék a forma kívülére nyúlik, és emelés érzetét kelti, míg a belső árnyék a szélek belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) metódust, majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosódási sugárértékek lágyabb széleket eredményeznek.

Ez a JavaScript példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, és elmosódási sugara 6 pont:

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

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat effektusformátumán.

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) metódust, és használja a [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) metódust egy [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) kiválasztásához. A stílusváltáshoz módosítsa az előre beállítást ugyanazon az alakzaton. Hívja meg a [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) metódust az árnyék eltávolításához, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa négy állapotot mutat egymás mellett egy dián. Mindkét árnyék 10 ponttal van eltolva. A 225°-os irány az első árnyékot a téglalap felett és balra helyezi, a 45°-os irány a másodikat alul és jobbra helyezi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Eredeti | Első előre beállítás | Második előre beállítás | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső vető árnyék](preset_shadow_top_left.png) | ![Jobb alsó vető árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Visszatükrözés hatás alkalmazása**

Az Aspose.Slides for Node.js via Java segítségével a visszatükrözés hatás alkalmazásához tükröződésszerű visszatükrözést adhat az alakzatokhoz, beállítva a távolságot, átlátszóságot és méretet. Ez a hatás javítja a prezentációk esztétikáját, egy kifinomultabb, polírozott megjelenést kölcsönözve az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a következetes tervezés érdekében.

Ez a JavaScript kód bemutatja, hogyan alkalmazhatja a [visszatükrözés hatást](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:

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

![Visszatükrözés hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

A ragyogás hatás alkalmazásához egy alakzatra az Aspose.Slides for Node.js via Java segítségével lágy, fényes aurát adhat az alakzatok köré, beállítva a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat és vonzó, szemnek tartózkodó vizuális elemet ad a prezentációhoz. Könnyen megvalósítható minimális kóddal, javítva a diák összképét.

Ez a JavaScript kód bemutatja, hogyan alkalmazhatja a [ragyogás hatást](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:

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

![Ragyogás hatás](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

A lágy szélek hatás alkalmazásához az Aspose.Slides for Node.js via Java segítségével sima, elmosódott átmenetet hozhat létre egy alakzat szélei körül. Ez a hatás finomabb, elegánsabb megjelenést ad, tökéletes olyan tervekhez, amelyeknek gyengéd, lágyabb megjelenésre van szüksége. Könnyen beállíthatja a paramétereket, például a sugárértéket, a kívánt hatás eléréséhez a prezentációban lévő különböző alakzatoknál.

Ez a JavaScript kód bemutatja, hogyan alkalmazhatja a [lágy szélek hatást](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:

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

![Lágy szélek hatás](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használja a forma elmosódását a forma kitöltésének és körvonalának lágyításához, miközben a forma szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) metódust az alakzat effektusformátumán. A sugár pontban (1/72 hüvelyk) van mérve: használjon nem negatív értéket, a nagyobb értékek erőteljesebb elmosódást eredményeznek. A nulla sugár a megjelenést érintetlenül hagyja.

A [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, lesz vágva. `true` esetén az elmosódás túlnyúlhat ezekre a határokra. Egyik beállítás sem változtatja meg az alakzat pozícióját vagy méreteit.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és alakzatemméreteket használja mindenhol. A felső sor `grow = false`; az alsó sor `grow = true`.

![Eredeti téglalap összehasonlítva 5 és 15 pontos elmosódási sugárral, a növekedés letiltva és engedélyezve](shape_blur_comparison.png)

Ez a JavaScript példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pont elmosódást alkalmaz, majd a [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) újbóli meghívásával 15 pont elmosódásra frissíti. Mindkét elmosódott állapotot elmenti, majd a [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) metódussal eltávolítja az elmosódást, és elmenti az alakzatot elmosódás nélkül.

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

A forma elmosódás a kitöltést és a körvonalat együtt érinti. A lágy szélek hatás a forma széleit halványítja, míg az árnyék elmosódása csak az árnyékot lágyítja. A képtranszformációs hatások a kép tartalmára hatnak; ez a példa közvetlenül az alakzat effektusformátumára alkalmaz elmosódást, anélkül, hogy az alakzatot képpé alakítaná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, kombinálhat különböző hatásokat, például árnyékot, visszatükrözést és ragyogást egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, többek között automatikus alakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és másokra.

**Alkalmazhatok hatásokat csoportos alakzatokra?**

Igen, a csoportos alakzatokra is alkalmazhat hatásokat. A hatás a teljes csoportra vonatkozik.