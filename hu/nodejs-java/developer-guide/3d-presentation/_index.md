---
title: Hozzon létre 3D hatásokat prezentációkban Node.js használatával
linktitle: 3D Prezentáció
type: docs
weight: 232
url: /hu/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrudálás
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre Node.js-ben az Aspose.Slides használatával. Állítsa be a kamerát, a megvilágítást, az anyagot, az extrudálást, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint-szerű 3D formázást alakzatokra és szövegre. Ez a cikk olyan 3D hatásokat fed le, mint a forgatás, extrudálás, szegélyek, megvilágítás, anyag, színátmenetes vagy képes kitöltések, valamint a 3D szöveg.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatokon és szövegen alkalmazott 3D formázási hatásokról szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről van szó. Amikor egy diát képbe, PDF‑be vagy HTML‑be exportál, az Aspose.Slides ezeket a 3D hatásokat a kiexportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getThreeDFormat) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus egy [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét szabályozza.

Szöveg esetén használja a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) metódust. Ez a szövegkeretre, nem az alakzat törzsére alkalmaz 3D formázást.

A legfontosabb API tagok:

| API tag | Mit szabályoz | Mikor használja |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getCamera) | Nézetpont, előre meghatározott kamera típus, forgatás, nagyítás és perspektíva. | Forgassa az objektumot 3D térben, vagy egyeztesse a PowerPoint 3D forgatás előbeállításával. |
| [getLightRig](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getLightRig) | Fény előbeállítás, irány és fényforgatás. | Megváltoztatja, hogyan jelennek meg a fények és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getMaterial) és [setMaterial](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setMaterial) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Ugyanezt a geometriát laposabbá, puhábbá, fényesebbé vagy fémesebbé teheti. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Mennyire nyúlik visszafelé az alakzat az előoldalától. | Lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Az extrudált oldalak színe. | Láthatóvá teszi a mélységet vagy összhangba hozza az oldalszínnel az előoldali kitöltést. |
| [getDepth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getDepth) és [setDepth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setDepth) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatok vagy szövegek esetén, különösen a szegély és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getBevelTop) és [getBevelBottom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Megemelt vagy lekerekített élek az elő- és hátoldalon. | Puha vagy formázott él hozzáadása éles, lapos felület helyett. |
| [getContourColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getContourWidth) és [setContourWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Körvonal a 3D objektum körül. | Kiemeli az objektum határait a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzathoz általában négyféle beállítás szükséges ahhoz, hogy meggyőzően 3D‑nek tűnjön:

- Kamera beállítások, mert az alapértelmezett előnézet elrejtheti az extrudálást.
- Fény beállítások, mert a megvilágítás teszi olvashatóvá az oldalak és felületek.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrudálás vagy mélység beállítások, mert a lapos alakzatnak vastagságra van szüksége.

Az alábbi példa egy téglalapot hoz létre, szöveget ad az előoldalához, és 3D formázást alkalmaz. A kamera forgatási értékek fokban vannak megadva, az extrudálás magassága pedig 100 pont. A példa a diát PNG‑képre rendereli a kétszeres alapméretben, és PPTX‑ként menti a prezentációt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A renderelt dia kép mutatja a téglalapot, mint egy vastag 3D blokk:

![Renderelt kék 3D téglalap fehér 3D szöveggel az előoldalon](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatást a **3‑D Rotation** ablaktáblán állítják be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3D forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slidesben a kamerához a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getCamera) segítségével férhet hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai előnézetet választ, és X, Y, Z forgatásait rendre 20, 30 és 40 fokra állítja. A példában a forma memóriában van konfigurálva, fájlt nem mentve:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Használja a kamerát, ha meg kell változtatni, hogy a néző hogyan látja az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A 3D nézetpontot változtatja meg, amelyet a PowerPoint és az Aspose.Slides a rendereléskor használ.

## **Extrudálás és mélység hozzáadása**

Az extrudálás azt eredményezi, hogy egy alakzat vastagabbá válik az előoldala mögé nyúlva. PowerPointban a mélység vezérlés állítja be ezt a látható vastagságot, a szín vezérlés pedig az oldalfelületek színét.

![PowerPoint mélység vezérlők leképezve az extrudálás színre és magasság tulajdonságokra](img_02_02.png)

Használja a [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) metódust a vastagság beállításához, és a [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) metódust az oldal színének lekéréséhez. Ez a példa egy téglalapot 100 pont extrudálással, lila oldalakkal ad, és a kamerát elfordítja, hogy látható legyen a vastagság. A forma memóriában van konfigurálva, fájlt nem mentve:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

A [ThreeDFormat.setDepth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setDepth) metódus egy 3D alakzat mélységét állítja be. A [setExtrusionHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) metódus az extrudálás magasságát szabályozza, ahogy ez a példában látható.

## **Színátmenetes vagy képes kitöltések használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat szilárd színt, színátmenetet, mintát vagy képet az előoldalra, miközben ugyanazokat a kamera-, fény-, anyag- és extrudálási beállításokat használja.

Ez a példa egy kék‑narancs színátmenetet alkalmaz az előoldalon, és egy sötét narancssárga színt az 150 pont magasságú extrudáláshoz. A színátmenet állomásai a 0 és 100‑nál találhatók, amelyek a színátmenet kezdetét és végét jelzik. A kamera forgatási értékek fokban vannak megadva. A dia PNG‑képre renderelődik a kétszeres alapméretben:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

A renderelt kimenet megtartja a színátmenetet az előoldalon, és az extrudálást külön rendereli:

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képes kitöltés használatához adja hozzá a képet a prezentációhoz, és rendelje az alakzat kitöltéséhez. Ez a példa egy „image.jpg” nevű fájlt feltételez a munkakönyvtárban. A képet úgy nyújtja, hogy kitöltse a téglalapot, 150 pont extrudálást alkalmaz, és fokban állítja be a kamera forgatását. A forma memóriában van konfigurálva, fájlt nem ment vagy renderel:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

A kép az előoldalon jelenik meg, míg az extrudálás a 3D oldal felületként renderelődik:

![Renderelt 3D téglalap fénykép kitöltéssel az előoldalon és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat törzsére vonatkozik. A szöveg 3D formázása a szövegkeretre. Ez hasznos olyan WordArt‑szerű hatásokhoz, ahol a betűknek maguknak kell extrudálás, anyag, megvilágítás és kamera beállítások.

Az alábbi példa szöveget hoz létre egy narancssárga‑fehér rácsmintával, felül ívelt ívet ad, és a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) segítségével konfigurálja a 3D beállításokat. Az extrudálás magassága és a mélység pontban van megadva, a fényforgatás fokban. A forma kitöltése és körvonala rejtve van, csak a szöveg látszik. A példa PNG‑képre rendereli a diát a kétszeres alapmérettel, és PPTX‑ként menti a prezentációt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A szöveg görbített, extrudált 3D betűként renderelődik:

![Renderelt 3D szöveg íves WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Szöveg lapos megtartása 3D alakzaton**

A szöveg lapos megtartásához hívja a [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) metódust a [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) segítségével. Ha az érték `true`, a szöveg kívül marad a 3D jeleneten. Ha `false`, a szöveg részt vesz a jelenetben, és követi annak 3D tájolását.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, a megvilágítás, az anyag és az extrudálás továbbra is a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getThreeDFormat) által van beállítva. Emellett különbözik a szokásos forgatástól. A [Shape.setRotation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#setRotation) a forma diaplanejét forgatja, míg a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) a szöveg egyéni forgatását szabályozza a saját keretén belül. A szöveg 3D jelenetből történő kizárása nem állítja vissza ezeket a szögeket.

Az alábbi önálló példa egy kék téglalapot hoz létre szöveggel, majd azt a jobb oldalra klónozza. Mindkét forma ugyanazt a 3D formázást kapja; csak a szöveg beállítása különbözik: bal oldalon `false`, jobb oldalon `true`. A kamera szögek fokban vannak, az extrudálás magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a comparatív diát PNG‑re rendereli a kétszeres alapmérettel.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Bal oldalon a szöveg követi a 3D tájolást. Jobb oldalon lapos marad és könnyebben olvasható. Mindkét téglalap megtartja ugyanazt a látható extrudálást és 3D tájolást.

![Egymás melletti 3D téglalapok: a szöveg követi a 3D tájolást bal oldalon, jobb oldalon lapos marad](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrizheti a 3D formázást, ha PowerPoint‑formátumba (például PPTX‑be) menti a fájlt. Fix‑elrendezésű formátumokba (PNG, PDF, HTML, videó‑keret) történő renderelés vagy exportálás esetén a 3D jelenet rasterizálódik vagy 2D‑ként kerül a kimenetbe. Ez érvényes, amikor a diákat [PNG](/slides/hu/nodejs-java/convert-powerpoint-to-png/)-re rendereli, [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/)-re exportál, [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/)-re exportál, vagy [videó konverzió](/slides/hu/nodejs-java/convert-powerpoint-to-video/) keretként generálja.

Vegye figyelembe a következőket:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja forgatni az export után.
- A végső megjelenés a kamera, fényrendszer, anyag, extrudálás, kitöltés és dia méretezés kombinációjától függ.
- Ha öröklött vagy téma‑alapú formázási értékeket kell megvizsgálnia, olvassa el a [effective shape properties](/slides/hu/nodejs-java/shape-effective-properties/) oldal tartalmát.
- Néhány kimeneti formátum nem képes tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelve van, nem szerkeszthető 3D beállításként tárolva.

## **GYIK**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**  
Az Aspose.Slides PowerPoint‑3D‑effekteket hoz létre és renderel alakzatokra és szövegre. Nem teszi az exportált képeket, PDF‑eket vagy HTML‑oldalakat interaktív 3D jelenetekké, amelyeket a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ha a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effektus között?**  
A 3D modell egy különálló, a prezentációba beszúrt 3D objektum. A 3D effektus egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrudálás, szegély, megvilágítás és anyag. Ez a cikk a 3D effektusokról szól.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**  
Legalább egy kamera forgatás és az extrudálás vagy mélység beállítása szükséges. Gyakorlati szempontból ajánlott egy fényrendszer és anyag beállítása is, hogy a renderelt felületeknek legyenek egyértelmű kiemelései és árnyékai.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre egyaránt?**  
Igen. Használja a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getThreeDFormat) metódust az alakzat törzsére, és a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) metódust a szövegre.

**Megjelennek a 3D hatások exportáláskor képekre, PDF‑re, HTML‑re vagy videoképkockákra?**  
Igen. Az Aspose.Slides a 3D hatásokat rendereli, amikor dia képeket, PDF‑kimenetet, HTML‑kimenetet vagy videó‑konverzióhoz szükséges képkockákat generál. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Olvashatom a végső 3D értékeket öröklődés és téma beállítások után?**  
Igen. Használja az effektív formázási API‑kat, amelyek a [Shape Effective Properties](/slides/hu/nodejs-java/shape-effective-properties/) leírásában szerepelnek, hogy elolvassa a végleges kamera, fényrendszer, szegély és egyéb 3D értékeket.