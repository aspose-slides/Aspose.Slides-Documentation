---
title: 3D hatások létrehozása prezentációkban Node.js használatával
linktitle: 3D prezentáció
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
description: "Alkalmazzon és rendereljen 3D hatásokat PowerPoint alakzatokra és szövegre Node.js-ben az Aspose.Slides segítségével. Állítsa be a kamerát, a világítást, az anyagot, az extrudálást, a kitöltéseket, és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint‑szerű 3D formázást alakzatokhoz és szöveghez. Ez a cikk olyan 3D hatásokat fed le, mint a forgatás, extrúzió, rézsútok, világítás, anyag, színátmenetes vagy képkitöltések, valamint a 3D szöveg.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatokon és szövegen alkalmazott 3D formázási hatásokról szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Ha egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használd a [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus egy [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét vezérli.

Szöveghez a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) metódust használd. Ez a szövegkeretre alkalmaz 3D formázást a alakzat teste helyett.

A legfontosabb API tagok a következők:

| API tag | Mit vezérel | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Az objektum forgatása 3D térben vagy egy PowerPoint 3D forgatási előbeállítás egyezése. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Világítás előre beállított, irány, és a fény forgatása. | A kiemelések és árnyékok megjelenésének megváltoztatása a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Felületi anyag, például lapos, matt, műanyag vagy fém. | Ugyanazon geometria laposabbá, puhábbá, fényesebbé vagy fémesebbé tétele. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Mennyire nyúlik vissza az alakzat az első felülete mögött. | Lapos alakzat átalakítása láthatóan vastag 3D objektummá. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Az extrudált oldalak színe. | Mélység láthatóvá tétele vagy az oldal színének koordinálása az elülső kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | További 3D mélység, amit a PowerPoint 3D formázás használ. | A mélység finomhangolása alakzatok vagy szöveg esetén, különösen rézsút és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Emelkedett vagy lekerekített él a front és hátsó felületeken. | Puha vagy formázott él hozzáadása ahelyett, hogy éles, lapos felület lenne. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Körvonal a 3D objektum körül. | Az objektum határának hangsúlyozása a renderelt kimenetben. |

## **3D alakzat létrehozása**

Egy alakzathoz általában négyféle beállítás szükséges, hogy meggyőzően 3D‑snek tűnjön:

- Kamera beállítások, mivel az alapértelmezett előnézet elrejtheti az extrudálást.
- Világítási beállítások, mivel a fény megjeleníti a felületeket és oldalakat.
- Anyag beállítások, mivel a felület befolyásolja a fény ábrázolását.
- Extrudálás vagy mélység beállítások, mivel egy lapos alakzatnak vastagságra van szüksége.

Az alábbi példa egy téglalapot hoz létre, szöveget ad hozzá az előoldalához, és alkalmaz 3D formázást. A kamera forgatás értékei fokokban vannak, az extrudálás magassága pedig 100 pont. A példa a diát PNG képre rendereli kétszeresére az alapértelmezett méretben, és a prezentációt PPTX formátumban menti.

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

A renderelt diákkép a téglalapot egy vastag 3D blokként mutatja:

![Kék 3D téglalap, fehér 3D szöveggel az előoldalon](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a 3‑D forgatás panelből állítható be. Az X, Y és Z forgatási értékek megfelelnek a kamera API-n keresztül beállított forgatásnak.

![PowerPoint 3‑D forgatás panel, kiemelve az X, Y és Z forgatási értékekkel](img_02_01.png)

Az Aspose.Slides‑ban a kamerához a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) segítségével férhetsz hozzá. Ez a példa egy téglalapot hoz létre, ortografikus előnézetet választ, és X, Y, Z forgatásait a 20, 30 és 40 fokra állítja. A alakzatot a memóriában konfigurálja mentés nélkül:

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

Használd a kamerát, amikor meg kell változtatni, ahogyan a néző látja az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. Megváltoztatja a PowerPoint és az Aspose.Slides által a rendereléskor használt 3D nézetpontot.

### **Kameraorientáció másolása egy sablon alakzatról**

A sablon alakzat orientációjának egyezéséhez olvasd ki a kamera előbeállítását a [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) metódussal, és a forgatási szögeket a [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation) metódussal. A példa megnyitja a `template.pptx`‑t, és a első dián az első alakzatról a második alakzatra másolja a kameraorientációt. Mindkét alakzat már rendelkezik 3D világítással, a második alakzatnak pedig nincsen explicit kamera forgatása.

A szögek fokban vannak. Az index `0` a szélességi fok, az index `1` a hosszúsági fok, az index `2` a körfordulat. Ezeket az [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) metódusnak ebben a sorrendben kell átadni. Ha a forrás `null`‑t ad vissza, nincs explicit forgatás, így a második alakzat szögei maradnak beállítatlanok. Az explicit `(0, 0, 0)` forgatás három nullát ad és másolni kell.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Amikor a `camera-copy.pptx`‑t újra megnyitod PowerPointban, a jobb oldali nyíl ugyanazzal a kamera előbeállítással és forgatással rendelkezik, mint a bal oldali téglalap. Mindkét alakzat ugyanazzal a világítással és extrudálási mélységgel rendelkezik.

![Egy kék 3D téglalap és egy jobb nyíl, egyező kameraorientációval, felülről és jobbról nézve](camera-orientation.png)

## **Extrudálás és mélység hozzáadása**

Az extrudálás vastagabbá teszi az alakzatot, ha azt az elülső felület mögé nyújtja. PowerPointban a mélység szabályozó állítja be ezt a látható vastagságot, és a szín szabályozó az oldal felületek színét.

![PowerPoint mélység szabályozók leképezve az extrudálás színére és magasságára](img_02_02.png)

Használd a [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) metódust a vastagság beállításához, és a [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) metódust az oldal színének lekéréséhez. Ez a példa egy téglalapnak 100 pont extrudálást ad lila oldalakkal, és forgatja a kamerát, hogy látható legyen a vastagsága. Az alakzatot memóriában konfigurálja mentés nélkül:

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

A [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) metódus beállítja egy 3D alakzat mélységét. A [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) metódus szabályozza az extrudálási hatás magasságát, ahogy ez a példában látható.

## **Színátmenetes vagy képi kitöltések használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhatsz egyszínű, színátmenetes, mintás vagy képi kitöltést az előoldalra, miközben ugyanazokat a kamera-, fény-, anyag- és extrudálási beállításokat használod.

Ez a példa kék‑narancssárga színátmenetet alkalmaz az előoldalra, és sötét narancssárga színt a 150 pont extrudálásra. A színátmenet állomásai 0‑nál és 100‑nál jelölik a kezdőt és a végét. A kamera forgatás értékei fokokban vannak. A diát PNG képre rendereli kétszeresére az alapértelmezett méretekkel:

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

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képi kitöltés használatához add hozzá a képet a prezentációhoz, és rendeld az alakzat kitöltéséhez. Ez a példa egy már létező, „image.jpg” nevű fájlt igényel a munkakönyvtárban. Nyújtja a képet, hogy kitöltse a téglalapot, 150 pont extrudálást alkalmaz, és a kamera forgatást fokokban állítja. Az alakzatot memóriában konfigurálja mentés vagy renderelés nélkül:

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

![Renderelt 3D téglalap fotó kitöltéssel az előoldalon és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása a szövegre**

Az alakzat 3D formázása az alakzat testét érinti. A szöveg 3D formázása a szövegkeretet. Ez hasznos WordArt‑szerű hatásokhoz, ahol a betűknek maguknak szükségük van extrudálásra, anyagra, világításra és kamera beállításokra.

Az alábbi példa szöveget hoz létre narancssárga‑fehér rácsmintával, alkalmaz egy felfelé ívelt ívet, és a 3D beállításokat a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) segítségével konfigurálja. Az extrudálási magasság és a mélység pontokban, a fény forgatás fokokban van megadva. Az alakzat kitöltése és körvonala rejtve van, hogy csak a szöveg legyen látható. A példa PNG képet renderel a diák kétszeres alapméretével, és a prezentációt PPTX‑ként menti:

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

![Renderelt 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Szöveg sík tartása 3D alakzaton**

A szöveg olvashatóságának megőrzéséhez, miközben az alakzat 3D megjelenését megtartod, hívd a [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) metódust a [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) segítségével. Ha az érték `true`, a szöveg kívül marad a 3D jelenetből. Ha `false`, a szöveg részt vesz a jelenetben és követi annak 3D orientációját.

Ez a beállítás nem távolítja el az alakzat 3D formázását: kamera, világítás, anyag és extrudálás továbbra is a [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) segítségével van beállítva. Emellett eltér a hagyományos forgatástól. A [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) a alakzatot a diaplanon forgatja, míg a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) a szöveg saját forgatását a keretén belül szabályozza. A szöveg 3D‑n kívül tartása nem állítja vissza ezen szögek egyikét sem.

Az alábbi önálló példa egy kék téglalapot hoz létre szöveggel, és egy másolatot helyez mellé. Mindkét alakzat ugyanazt a 3D formázást kapja, csak a szöveg beállítása különbözik: a bal oldalon `false`, a jobb oldalon `true`. A kamera szögei fokokban, az extrudálás magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a összehasonlító diát PNG‑re rendereli kétszeres alapmérettel:

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

Bal oldalon a szöveg követi a 3D orientációt. Jobb oldalon sík marad, így könnyebb olvasni. Mindkét téglalap ugyanazzal a látható extrudálással és 3D orientációval rendelkezik.

![Egymás mellé helyezett 3D téglalapok: a szöveg követi a 3D orientációt bal oldalon, jobb oldalon sík marad](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást PowerPoint formátumok (például PPTX) mentésekor. Fix elrendezésű formátumok renderelése vagy exportálása során a 3D jelenet raszterizálódik vagy 2D‑ként kerül a kimenetbe. Ez akkor is érvényes, ha a diákat [PNG](/slides/hu/nodejs-java/convert-powerpoint-to-png/), [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/) formátumba rendereli, illetve a [video conversion](/slides/hu/nodejs-java/convert-powerpoint-to-video/) kereteit állítja elő.

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja elforgatni az export után.
- A végső megjelenés a kamera, fényrendszer, anyag, extrudálás, kitöltés és dia méretezés kombinációjától függ.
- Ha a öröklött vagy téma‑alapú formázási értékeket szeretnéd megvizsgálni, olvasd a [hatékony alakzattulajdonságok](/slides/hu/nodejs-java/shape-effective-properties/) leírást.
- Egyes kimeneti formátumok nem tárolhatják a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként marad meg.

## **GYIK**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D hatásait alakzatokra és szövegre. Nem teszi interaktívvá az exportált képeket, PDF‑ket vagy HTML oldalakat úgy, hogy a néző forgathassa őket. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy a prezentációba beszúrt különálló 3D objektum. A 3D hatás egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrudálás, rézsút, világítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább a kamera forgatását és az extrudálást vagy a mélységet kell beállítani. Gyakorlatban érdemes a fényrendszert és az anyagot is beállítani, hogy a renderelt felületeknek világos kiemelései és árnyékai legyenek.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre egyaránt?**

Igen. Használd a [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) metódust az alakzat testéhez és a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) metódust a szöveghez.

**Megjelennek a 3D hatások képekre, PDF‑re, HTML‑re vagy videókeretekre exportáláskor?**

Igen. Az Aspose.Slides rendereli a 3D hatásokat diaképek, PDF‑kimenet, HTML‑kimenet és a videókonvertáláshoz használt képkockák előállításakor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvashatom a végső 3D értékeket öröklődés és téma beállítások után?**

Igen. Használd a hatékony formázási API‑kat, amelyeket a [hatékony alakzattulajdonságok](/slides/hu/nodejs-java/shape-effective-properties/) leírása tartalmaz.