---
title: 3D hatások létrehozása prezentációkban Node.js segítségével
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatok és szöveg számára Node.js-ben az Aspose.Slides segítségével. Konfigurálja a kamerát, a megvilágítást, az anyagot, az extrúziót, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatok és szöveg számára. Ez a cikk a 3D hatásokat tárgyalja, mint például a forgatás, extrúzió, élezés, megvilágítás, anyag, színátmenetes vagy képes kitöltés, valamint a 3D szöveg.

{{% alert color="primary" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Ha egy diát képre, PDF-re vagy HTML-re exportál, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe jeleníti meg.
{{% /alert %}}

## **3D formázási koncepciók**

A [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` használatával alkalmazhat 3D formázást egy alakzatra. A visszaadott [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) objektum vezérli az adott alakzat 3D jelenetét.

Szöveghez használja a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`. Ez a szövegkeretre alkalmaz 3D formázást az alakzat testének helyett.

A legfontosabb API tagok a következők:

| API tag | Mit irányít | Mikor kell használni |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getCamera) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Az objektum 3D térben történő forgatása vagy a PowerPoint 3D forgatás előre beállított értékének egyeztetése. |
| [getLightRig](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getLightRig) | Fény előbeállítás, irány és fény forgatás. | Megváltoztatja, hogyan jelennek meg a fények és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getMaterial) és [setMaterial](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setMaterial) | Felület anyaga, például lapos, matt, műanyag vagy fém. | Ugyanazt a geometriai formát laposabbá, lágyabbá, fényesebbé vagy fémesebbé teheti. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Mennyire nyúlik visszafelé az alakzat az első felületétől. | Egy lapos alakzatot láthatóan vastag 3D objektummá alakíthat. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Az extrudált oldalak színe. | Mélységet láthatóvá tesz, vagy az oldalszín összehangolásával a frontális kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getDepth) és [setDepth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setDepth) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a lekerekítés és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getBevelTop) és [getBevelBottom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Emelkedett vagy lekerekített élek az első és hátsó felületeken. | Lábnyább vagy formázott él hozzáadása ahelyett, hogy éles, lapos felület lenne. |
| [getContourColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getContourWidth) és [setContourWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Körvonal a 3D objektum körül. | Kiemeli az objektum határát a megjelenített kimenetben. |

## **3D alakzat létrehozása**

Egy alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D-nak tűnik:

- Kamera beállítások, mert az alapértelmezett frontális nézet elrejtheti az extrúziót.
- Fény beállítások, mert a megvilágítás teszi olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad hozzá az első felületéhez, 3D formázást alkalmaz, a prezentációt PPTX formátumban menti, és a diát PNG képre rendereli.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

A renderelt dia kép a téglalapot vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az első felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatás a 3-D Forgatás panelen konfigurálható. Az X, Y és Z forgatási értékek megfelelnek a kamera API-n keresztül beállított forgatásnak.

![PowerPoint 3-D Forgatás panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides-ban a kamera típusát és forgatását a `shape.getThreeDFormat()` által visszaadott 3D formátumban állíthatja be:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Használja a kamerát, amikor meg akarja változtatni, hogyan láthatja a néző az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot módosítja.

## **Extrúzió és mélység hozzáadása**

Az extrúzió azt eredményezi, hogy egy alakzat vastagabbnak tűnik, ha a frontális felület mögé nyúlik. PowerPointban a mélység vezérlő állítja be ezt a látható vastagságot, a színvezérlő pedig az oldalfelületek színét.

![PowerPoint mélység beállítások leképezve az extrúzió színre és extrúzió magasság tulajdonságokra](img_02_02.png)

Állítsa be az extrúzió magasságát a vastagsághoz és az extrúzió színét az oldalszínhez:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Használja a mélység beállítást, ha közvetlenül kell kezelni a PowerPoint mélység értékét, vagy a mélységet kombinálni szeretné a lekerekítéssel, anyaggal és szöveghatásokkal. Számos alakzatszituációban az extrúzió magassága egyértelműbb beállítás, mivel közvetlenül kifejezi a látható extrúziót.

## **Színátmenetes vagy képes kitöltések használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egy egyszínű, színátmenetes, mintás vagy képes kitöltést az első felületre, miközben ugyanazokat a kamera, fény, anyag és extrúzió beállításokat használja.

Ez a példa színátmenetes kitöltést alkalmaz az alakzatra és sötétebb extrúzió színt az oldalakra:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

A renderelt kimenet megőrzi a színátmenetet az első felületen, és külön rendereli az extrúziót:

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Képes kitöltés használatához adja a képet a prezentációhoz, majd rendelje hozzá az alakzat kitöltéséhez:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

A kép az első felületen jelenik meg, míg az extrúzió 3D oldalfelületként kerül renderelésre:

![Renderelt 3D téglalap fotó kitöltéssel az első felületen és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testét befolyásolja. A szöveg 3D formázása a szövegkeretet érinti. Ez hasznos a WordArt-szerű hatásokhoz, ahol maguk a betűk is extrúziót, anyagot, megvilágítást és kamera beállításokat igényelnek.

A következő példa mintás kitöltésű szöveget hoz létre, WordArt transzformációt alkalmaz, és 3D beállításokat konfigurál a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`-on:

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

A szöveg ívelt, extrudált 3D betűkkel jelenik meg:

![Renderelt 3D szöveg ívelt WordArt transzformációval, narancssárga mintás kitöltéssel és sötét extrúzióval](img_02_05.png)

## **Exportálás és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást PowerPoint formátumokba, például PPTX-be mentéskor. Renderelés vagy rögzített elrendezésű formátumokba történő exportálás esetén a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetbe. Ez akkor is érvényes, amikor dia képeket renderel [PNG](/slides/hu/nodejs-java/convert-powerpoint-to-png/), [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/), vagy kereteket generál [videó konverzió](/slides/hu/nodejs-java/convert-powerpoint-to-video/) számára.

Tartsa szem előtt a következő pontokat:

- Az exportált képek és PDF-ek nem interaktívak. Az objektumot a néző nem tudja elforgatni export után.
- A végső megjelenés a kamera, fényrig, anyag, extrúzió, kitöltés és dia méretezés kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy téma alapú formázási értékeket, olvassa el a [hatékony alakzat tulajdonságok](/slides/hu/nodejs-java/shape-effective-properties/).
- Néhány kimeneti formátum nem képes tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként megőrzött.

## **GYIK**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides PowerPoint 3D hatásokat hoz létre és renderel alakzatok és szöveg számára. Nem teszi interaktívvá az exportált képeket, PDF-eket vagy HTML-oldalakat olyan 3D jelenetekké, amelyeket a néző elforgathat. PPTX-ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D hatás között?**

A 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. A 3D hatás egy formázás, amelyet egy szabványos PowerPoint alakzatra vagy szövegre alkalmaznak, például forgatás, extrúzió, lekerekítés, megvilágítás és anyag. Ez a cikk a 3D hatásokat tárgyalja.

**Mely beállítások szükségesek egy látható 3D alakzathoz?**

Minimum egy kamera forgatás és vagy extrúzió vagy mélység beállítása szükséges. Gyakorlatban továbbá be kell állítani a fényriget és az anyagot, hogy a renderelt felületeknek legyenek egyértelmű kiemelései és árnyékai.

**Alkalmazhatok 3D hatásokat alakzatokra és szövegre egyaránt?**

Igen. Használja a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/).`getThreeDFormat()`-t az alakzat testére és a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`-t a szövegre.

**Megjelennek a 3D hatások képek, PDF, HTML vagy videókockák exportálásakor?**

Igen. Az Aspose.Slides 3D hatásokat renderel, amikor diaképeket, PDF kimenetet, HTML kimenetet és a videó konverzióhoz használt kockákat állít elő. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Olvashatom a végső 3D értékeket öröklés és téma beállítások alkalmazása után?**

Igen. Használja a [Alakzat hatékony tulajdonságok](/slides/hu/nodejs-java/shape-effective-properties/) leírt hatékony formázási API-kat, hogy elolvassa a végső kamera, fényrig, lekerekítés és kapcsolódó 3D értékeket.