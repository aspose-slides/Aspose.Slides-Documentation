---
title: Alakzat hatások alkalmazása prezentációkban JavaScript használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/nodejs-java/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- visszaverés hatás
- fénylő hatás
- lágy élek hatás
- hatásformátum
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzati hatásokkal JavaScript és az Aspose.Slides for Node.js segítségével—hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

Míg a PowerPoint effektusai segítségével egy alakzat kiemelhető, eltérnek a [kitöltésektől](/slides/hu/nodejs-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint effektusok használatával hiteles visszaverődéseket hozhat létre egy alakzaton, eloszthatja az alakzat fényvisszaverődését stb.

![Alakzati effektus](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** (Előre beállított) menüpont alatt kínál lehetőségeket. A Preset beállítások két vagy több hatás kombinációi, amelyekről ismert, hogy jól néznek ki. Így egy előre beállítást kiválasztva nem kell időt pazarolni különböző hatások tesztelésére vagy kombinálására, hogy szép kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Node.js via Java támogatja a külső és belső árnyékokat alakzatoknál. Testreszabhatja a színüket, irányukat, távolságukat és elmosódási sugarukat, hogy illeszkedjenek a prezentáció tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérből. Az árnyék túlnyúlik az alakzat szélein, és azt az érzetet kelti, mintha az alakzat a dia felett lenne. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablon világításának és stílusának.

Ez a JavaScript kód mutatja, hogyan kell alkalmazni a [külső árnyékhatás](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:
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

### **Belső árnyék alkalmazása**

Ha egy sablon vizuális stílusát kívánja reprodukálni, használjon belső árnyékot, hogy a kártya vagy panel recesszív megjelenést kapjon. A külső árnyék kívülre nyúlik az alakzaton, és azt a benyomást kelti, hogy az emelkedett, míg a belső árnyék az alakzat szélei belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosódási sugárértékek lágyabb éleket eredményeznek.

Ez a JavaScript példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, elmosódási sugara 6 pont:
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

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat effectformat objektumán.

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect), és használja a [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) metódust egy [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) kiválasztásához. A stílusok váltásához változtassa meg az előre beállítást ugyanazon az alakzaton. A [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) meghívásával eltávolíthatja az árnyékot, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa négy szakaszt mutat egymás mellett egy dián. Mindkét árnyék 10 ponttal van eltolva. A 225° irány az első árnyékot a téglalap bal felső részére helyezi, a 45° a másodikat a jobb alsó részre.
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
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Visszaverés effektus alkalmazása**

Az Aspose.Slides for Node.js via Java segítségével a visszaverés effektus alkalmazásához tükörszerű visszaverődést adhat alakzatokhoz, beállítva olyan paramétereket, mint távolság, átlátszóság és méret. Ez az effektus javítja a prezentációk esztétikáját, mivel a alakzatok kifinomultabb, csiszoltabb megjelenést kapnak. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a konzisztens tervezés érdekében.

Ez a JavaScript kód mutatja, hogyan kell alkalmazni a [visszaverés effektus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:
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

![Visszaverés effektus](reflection_effect.png)

## **Fénylő hatás alkalmazása**

Az Aspose.Slides for Node.js via Java segítségével a fénylő hatás alkalmazásához puha, ragyogó aurát adhat a alakzatok köré, beállítva olyan tulajdonságokat, mint a szín és a méret. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemrevaló vizuális elemet ad a prezentációhoz. Minimális kóddal könnyen megvalósítható, javítva a diák általános megjelenését.

Ez a JavaScript kód mutatja, hogyan kell alkalmazni a [fénylő hatás](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:
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

![Fénylő hatás](glow_effect.png)

## **Lágy élek hatás alkalmazása**

Az Aspose.Slides for Node.js via Java segítségével a lágy élek hatás alkalmazásához sima, elmosódott átmenetet hozhat létre az alakzat szélein. Ez a hatás finomabb és kifinomultabb megjelenést ad, ami tökéletes a lágy, puhább hatásra szoruló tervekhez. Könnyen állíthatja a paramétereket, például a sugarat, hogy a kívánt hatást elérje különböző alakzatokon a prezentációban.

Ez a JavaScript kód mutatja, hogyan kell alkalmazni a [lágy élek hatás](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:
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

![Lágy élek hatás](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használja az alakzat elmosódását az alakzat kitöltésének és körvonalának lágyításához, miközben az alakzat szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) metódust az alakzat effectformat objektumán. A sugár pontban (1/72 hüvelyk) van mérve: használjon nemnegatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlanul hagyja a megjelenést.

Az [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, van vágva. `true` esetén az elmosódás túlnyúlhat ezen határokon. Egyik beállítás sem módosítja az alakzat helyzetét vagy méreteit.

A lenti összehasonlítás során mindenhol ugyanaz a kitöltés, körvonal és alakzati méret van használva. A felső sor `grow = false`; az alsó sor `grow = true`.

![Az eredeti téglalap 5 és 15 pont elmosódási sugárral összehasonlítva, a grow letiltva és engedélyezve](shape_blur_comparison.png)

Ez a JavaScript példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pont elmosódást alkalmaz, majd egy újabb [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) meghívásával 15 pont elmosódásra frissíti. Mindkét elmosódott állapotot elmenti, majd meghívja a [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) metódust, és az alakzatot elmosódás nélkül menti.
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

Az alakzat elmosódása a kitöltést és a körvonalat együtt érinti. A lágy élek hatás az alakzat éleit halványítja, míg az árnyék elmosódása csak az árnyékot lágyítja. A képek átalakítási hatások a kép tartalmán működnek; ez a példa közvetlenül az alakzat effectformat objektumára alkalmaz elmosódást, az alakzatot képpé konvertálás nélkül.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**  
Igen, különböző hatásokat, például árnyékot, visszaverést és fénylő hatást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést hozzon létre.

**Milyen alakzatokra alkalmazhatok hatásokat?**  
Hatásokat különféle alakzatokra alkalmazhat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**  
Igen, a csoportosított alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra vonatkozik.