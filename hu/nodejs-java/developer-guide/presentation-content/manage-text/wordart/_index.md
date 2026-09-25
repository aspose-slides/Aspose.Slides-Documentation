---
title: WordArt hatások létrehozása és alkalmazása Node.js-ben
linktitle: WordArt
type: docs
weight: 110
url: /hu/nodejs-java/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt effektus
- árnyék effektus
- tükröződés effektus
- ragyogás effektus
- WordArt átalakítás
- 3D effektus
- külső árnyék effektus
- belső árnyék effektus
- Node.js
- JavaScript
- Aspose.Slides
description: "WordArt hatások létrehozása és testreszabása az Aspose.Slides for Node.js via Java segítségével. Ez a lépésről lépésre útmutató segít a fejlesztőknek professzionális szöveggel gazdagítani a prezentációkat Node.js-ben."
---
## **Áttekintés**

A WordArt effektusok lehetővé teszik a szöveg formázását kitöltésekkel, körvonalakkal, árnyékokkal, tükröződésekkel, ragyogással, átalakításokkal és 3D formázással. Ez a cikk bemutatja, hogyan hozhatók létre és testreszabhatók ezek az effektusok PowerPoint prezentációkban az Aspose.Slides for Node.js via Java használatával, Microsoft Office telepítése nélkül.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

Az alábbi példák egy egyszerű WordArt stílust hoznak létre a szöveg, betűtípus, minta kitöltés és körvonal beállításával.

Mindegyik példa egy új prezentációt hoz létre, és egy téglalapot ad az első diájához; nincs szükség bemeneti fájlra. Az első példa a szöveget "Aspose.Slides"-re állítja. A forma pozíciója és méretei pontban vannak megadva:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Állítsa be a betűtípust Arial Black-ra 36 pontban, hogy a formázás jobban látható legyen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Alkalmazzon egy [SmallGrid](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/patternstyle/#SmallGrid) mintát sötét narancssárga előtérrel és fehér háttérrel, majd adjon hozzá egy fekete szöveg körvonalat 1 pont szélességgel:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![Az egyszerű WordArt sablon](WordArt_template.png)

## **Más WordArt effektusok alkalmazása**

Az alábbi példák bemutatják, hogyan alkalmazhatók árnyékok, tükröződések, ragyogás, átalakítások és 3D effektusok a szövegre.

### **Külső árnyék effektusok alkalmazása**

Az külső árnyék mélységet ad azáltal, hogy a szöveg mögé helyez egy árnyékot. Testreszabhatja annak színét, irányát, távolságát, elmosódási sugarát, méretét és döntését.

Ez a példa meghívja a [enableOuterShadowEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) metódust, és egy fekete árnyékot állít be 4 pont elmosódási sugárral, 230 fokos iránnyal és 30 pont távolsággal. A 100-as méretezési értékek megtartják az árnyék méretét, míg a vízszintes döntés 20 fokkal billenti. Az alfa transzformáció 32%-os átlátszatlanságot állít be:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![A külső árnyék effektus](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Ha a külső és előre beállított árnyékok együtt vannak használva, csak a külső árnyék kerül alkalmazásra.
- Ha a külső és belső árnyékok egyszerre vannak használva, az eredményelt effektus a PowerPoint verziójától függ. Például a PowerPoint 2013-ban az effektus duplázódik, míg a PowerPoint 2007-ben csak a külső árnyék kerül alkalmazásra.
{{% /alert %}}

### **Tükröződés effektusok alkalmazása**

A tükröződés egy tükrözött másolatot hoz létre a szövegről. Állítsa be a pozícióját, méretét, elmosódását és átlátszatlanságát a megjelenés szabályozásához.

Ez a példa meghívja a [enableReflectionEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) metódust, és függőlegesen fordítja meg a tükröződést -100% mérettel. 0,5 pont elmosódási sugárral és 4,72 pont távolsággal dolgozik. Az átlátszatlanság 60%-ról 0,9%-ra csökken a tükröződés 0% és 60% közötti pozíciói között:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![A tükröződés effektus](reflection_effect.png)

### **Ragyogás effektusok alkalmazása**

A ragyogás egy lágy színes körvonalat ad a szöveg köré. Állítsa be a színét, átlátszatlanságát és sugarát az effektus szabályozásához.

Ez a példa meghívja a [enableGlowEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) metódust, és egy piros ragyogást alkalmaz 54%-os átlátszatlansággal és 7 pont sugárral:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![A ragyogás effektus](glow_effect.png)

### **WordArt átalakítások alkalmazása**

A WordArt átalakítások hajlítják, nyújtják vagy torzítják a szövegrészt.

Állítsa be a [setTransform](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setTransform) értékét [ArchUpPour](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) értékre, hogy a teljes szövegdoboz felfelé íveljen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![A WordArt átalakítás](transform_effect.png)

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Node.js via Java előre meghatározott [átalakítási típusok](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textshapetype/) készletet biztosít.
{{% /alert %}}

### **3D effektusok alkalmazása alakzatokra és szövegre**

3D effektusokat alkalmazhat egy alakzatra vagy annak szövegére. A rézsúták, extrudálás, megvilágítás és kamera beállítások szabályozzák a végeredményt.

Az alábbi példa a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) segítségével körkörös rézsútákat, narancssárga extrudálást és sötétvörös körvonalat ad a téglalaphoz. A rézsúták mérete, az extrudálás magassága, a körvonal szélessége és a mélység pontban van megadva. Egy műanyag anyag, a Z tengely körül 40 fokkal elforgatott kiegyensúlyozott megvilágítás és egy perspektív kamera határozza meg a megjelenését:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott alakzat:

![Az alakzat 3D effektusa](shape_3D_effect.png)

Ez a példa hasonló 3D formázást alkalmaz a szövegre a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) segítségével. A kisebb rézsúták a betűk széleit formálják, míg az extrudálás és megvilágítás mélységet ad a szövegnek:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott szöveg:

![A szöveg 3D effektusa](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A 3D effektusok szövegre vagy alakzatra való alkalmazását – és ezek kölcsönhatását – konkrét szabályok szabályozzák. Tekintsen meg egy jelenetet, amely magában foglalja a szöveget és a tartalmazó alakzatot. Egy 3D effektus tartalmazza az objektum 3D ábrázolását és a benne elhelyezett jelenetet.

- Ha a jelenet mind az alakzatra, mind a szövegre be van állítva, az alakzat jelenete előnyt élvez, a szöveg jelenete figyelmen kívül marad.
- Ha az alakzatnak nincs saját jelenete, de van 3D ábrázolása, a szöveg jelenete kerül felhasználásra.
- Ha az alakzat egyáltalán nem rendelkezik 3D effektussal, laposnak tekintik, és a 3D effektus csak a szövegre vonatkozik.

Ezek a viselkedések a [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getLightRig) és a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getCamera) metódusokra vonatkoznak.
{{% /alert %}}

A szöveg lapos és olvasható tartásához, miközben megtartja az alakzat 3D formázását, lásd a [Keep Text Flat on a 3D Shape](/slides/hu/nodejs-java/3d-presentation/) oldalt a két beállítás összehasonlításáért és egy teljes JavaScript példáért.

## **GYIK**

**Használhatok WordArt effektusokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides for Node.js via Java támogatja a Unicode-ot, és minden főbb betűtípussal és írásrendszerrel működik. A WordArt effektusok, mint például az árnyék, kitöltés és körvonal, nyelvtől függetlenül alkalmazhatók, bár a betűtípusok elérhetősége és a megjelenítés a rendszer betűkészleteitől függhet.

**Alkalmazhatok WordArt effektusokat dia-mester elemekre?**

Igen, a WordArt effektusokat alkalmazhatja a mester diák alakzataira, beleértve a címhelyettesítőket, lábléceket vagy háttérszöveget. A mester elrendezésén végzett módosítások minden kapcsolódó diára kihatnak.

**Vagy befolyásolják a WordArt effektusok a prezentáció fájlméretét?**

Enyhén. Az olyan WordArt effektusok, mint az árnyékok, ragyogások és gradient kitöltések, kis mértékben növelhetik a fájlméretet a hozzáadott formázási metaadatok miatt, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt effektusok eredményét anélkül, hogy menteném a prezentációt?**

Igen, a WordArt-ot tartalmazó diák képekké (például PNG, JPEG) renderelhetők a [Slide.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) segítségével, vagy az egyes alakzatok a [Shape.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage) metódussal. Ez lehetővé teszi a végeredmény előnézetét memóriában vagy a képernyőn a teljes prezentáció mentése vagy exportálása előtt.