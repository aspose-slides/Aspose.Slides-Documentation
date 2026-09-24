---
title: PowerPoint szöveg bekezdések kezelése JavaScriptben
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- pontozás kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés pont
- számozott lista
- felsorolásos lista
- bekezdés tulajdonságok
- HTML importálás
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálás
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, pontozásokat, számozott listákat, behúzásokat, HTML tartalmakat és bekezdés képeket az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java a szöveget szövegdobozok, bekezdések és részek hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) egy forma szövegtárolóját képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegdobozban, és hozzáférést nyújt a részeihez és a bekezdés‑szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) egy szövegrészt képvisel egy bekezdésen belül. Minden rész saját szöveggel és karakter‑szintű formázással rendelkezhet.

Ezért egy bekezdés több részt használva tartalmazhat különböző betűtípusokkal, színekkel, méretekkel és egyéb formázásokkal ellátott szöveget.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több részzel**

A következő lépések egy szövegdobozt hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érje el.
3. Adj egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑t a diára.
4. A forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)-jét érje el.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) objektumot a szövegdobozhoz.
6. Adjunk elegendő [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három részt tartalmazzon. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/getportionformat/) segítségével.
9. Mentse el a módosított bemutatót.

Ez a JavaScript példa megvalósítja a lépéseket:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Felsorolások és számozott listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik az összefüggő elemek áttekintését. Az Aspose.Slides-ben a lista beállításokat a [BulletFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/) definiálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érje el.
3. Adj egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a kiválasztott diához.
4. A forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)-jét érje el.
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) elemet egy szimbólum pontozáshoz.
7. Állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/settype/) értékét [BulletType.Symbol](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bullettype/)‑ra, és adja meg a pont karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a pont színét és magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Hozzon létre egy második bekezdést, és állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/settype/) értékét [BulletType.Numbered](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bullettype/).
11. Konfigurálja a számozott pont stílusát, és adja hozzá a bekezdést a szövegdobozhoz.
12. Mentse el a bemutatót.

Ez a JavaScript példa egy szimbólum pontot és egy számozott pontot hoz létre:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kép pontok használata**

Kép pontokkal saját képet használhat szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érje el.
3. Adj egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑t, és a forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)-jét érje el.
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
5. Töltse be a pontkép fájlt, és adja hozzá a bemutató képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) formájában.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/)‑t, és állítsa be a szövegét.
7. Állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/settype/) értékét [BulletType.Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bullettype/)-ra.
8. Rendelje hozzá a képet a [BulletFormat.getPicture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/getpicture/) segítségével, és állítsa be a pont magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Mentse el a módosított bemutatót.

Ez a JavaScript példa egy kép pontot hoz létre:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Többszintű lista létrehozása**

Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setdepth/)‑t, hogy a bekezdéseket a lista különböző szintjein helyezze el. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/)‑t, és érje el egy diát.
2. Adj egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑t, és törölje az alapértelmezett bekezdést a szövegdobozból.
3. Hozzon létre négy bekezdést, és állítsa be a pont szimbólumaikat.
4. Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setdepth/) értékét `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, és mentse el a bemutatót.

Ez a JavaScript példa egy négy szintű felsorolást hoz létre:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **A számozott listaelemek egyéni kezdőértékekkel való indítása**

Használja a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/)‑t, hogy beállítsa a számozott bekezdés kezdeti számát.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/)‑t, és adj egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑t egy diára.
2. Törölje az alapértelmezett bekezdést a forma szövegdobozából.
3. Hozzon létre három számozott bekezdést.
4. Állítsa a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) értékét `2`, `3` és `7`‑re a megfelelő bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, és mentse el a bemutatót.

Ez a JavaScript példa egyedi kezdőszámot rendel minden bekezdéshez:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bekezdéselrendezés és végjellemzők szabályozása**

### **Első sor behúzásának beállítása**

Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/)‑t, hogy szabályozza a bekezdés első sorának behúzását. Ez a módszer csak az első sort mozgatja a bekezdés bal margójához képest. Pozitív érték az első sort jobbra tolják, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)‑t, ha az egész bekezdést szeretné elmozdítani. Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/)‑t, ha csak az első sort kell eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a céldiat.
3. Adj egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑t a diára.
4. A forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑jét érje el, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse el a módosított bemutatót.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdések első sor behúzása](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor balra kezd a többi sorhoz képest. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) segítségével hozhatja létre. Negatív érték megadása balra mozdítja az első sort a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) definiálja a bekezdés törzsének bal pozícióját, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) pedig az első sor pozícióját ehhez a margóhoz képest. A függő behúzás létrehozásához adjon meg pozitív értéket a `setMarginLeft`‑nek, és negatív értéket a `setIndent`‑nek.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szószedet-bejegyzésekhez és más bekezdésekhez, ahol a sortöréseknek a bekezdés törzse alatt kell igazodniuk, nem pedig az első sor első karaktere alatt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a céldiat.
3. Adj egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑t a diára.
4. A forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑jét érje el, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és minden bekezdéshez adjon meg egy pozitív értéket a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) számára.
6. Adj egy negatív értéket a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) számára, hogy létrehozd a függő behúzást.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse el a módosított bemutatót.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdések függő behúzása](hanging_indent.png)

### **A bekezdés végi futtatási tulajdonságok beállítása**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) szabályozza a bekezdés végjelének formázását. Az alábbi példa betűméretet és latin betűtípust állít be a második bekezdés végjelére:

1. Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/)‑t, és érje el egy diát.
2. Adj egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑t, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon szöverrészeket hozzájuk.
4. Hozzon egy [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/)‑t a második bekezdés végi jelhez.
5. Állítsa be a [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) és a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) segítségével, és mentse el a bemutatót.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Megjelenített sorok számlálása**

Használja a [Paragraph.getLinesCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getLinesCount)‑t, hogy megszámolja egy bekezdés által a szöveg elrendezése után elfoglalt sorokat, beleértve az automatikus sortörést. Ez hasznos a szöveghossz és elrendezés ellenőrzéséhez prezentációs sablonokban.

Egy bekezdés egy elem a [TextFrame.getParagraphs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParagraphs)‑ből, és több megjelenített sort is elfoglalhat. Egy explicit sortörés egy bekezdésen belül új sort képez anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicit sortöréseket illesztene a szövegbe. Ezért a bekezdések vagy sortörő karakterek számlálása nem adja meg a megjelenített sorok számát.

Az alábbi példa egy szövegformátumot hoz létre, megszámolja a sorait, szűkíti a formátumot, majd egy rövidebb karakterláncra cseréli a szöveget. A sortörés engedélyezett, az automatikus méretezés letiltott, így a forma szélessége szabályozza a sortörést anélkül, hogy a szöveget automatikusan kicsinyítené vagy a formátum méretét változtatná. A forma méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összegzi a sorok számát a szövegdobozon belül.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a rövid szövegre cserélés csökkenti azt. A pontos számok változhatnak a betűtípus elérhetősége és helyettesítése, betűméret, margók, behúzás, sortörés és automatikus méretezés beállításai miatt. A célkörnyezetben használandó betűtípusokat és elrendezési beállításokat vegye alapul a sablon ellenőrzésekor.

Az egyedüli sorok száma nem határozza meg, hogy a szöveg kikerül-e a tárolóból. A rendelkezésre álló magasság, sormagasságok, bekezdés‑ és sor‑köz, valamint az automatikus méretezés viselkedése is számít; még egyetlen sor is túlnyúlhat a rendelkezésre álló szélességen, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)‑t, hogy a HTML jelölést bekezdésekké és részekké konvertálja egy szövegdobozban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el egy diát, és adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑t.
3. A forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)-jét érje el, és törölje az alapértelmezett bekezdést.
4. Definiálja vagy olvassa be a forrás HTML karakterláncot.
5. Adja át a HTML karakterláncot a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) metódusnak.
6. Mentse el a módosított bemutatót.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bekezdés szövegének exportálása HTML-be**

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/)‑t, hogy a kiválasztott bekezdés‑tartományt HTML‑ként exportálja.

1. Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt.
2. Érje el a diát, és keresse meg a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑t, amely a szöveget tartalmazza.
3. A forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)-jét érje el.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Bekezdés renderelése képként**

[Paragraph.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getImage) egy egyedi bekezdést renderel közvetlenül, és egy [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) objektumot ad vissza. A végeredményt a [IImage.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/#save)‑vel mentse fájlba. Nem szükséges a környező formát renderelni vagy a bitmapot manuálisan vágni.

[Paragraph.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getImage) `null`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezésben**

A szövegdoboz három bekezdést tartalmaz:

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy normál szövegdobozban alapértelmezett méretezéssel rendereli, és PNG formátumban menti a visszakapott képet. A `finally` blokk biztosítja, hogy a kép helyesen legyen felszabadítva.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázat‑cellában skálázással**

Használja a [Paragraph.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getImage) olyan túlterhelését, amely `scaleX` és `scaleY` paramétereket fogad, a vízszintes és függőleges méretezési tényezők beállításához. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres alapméretű szélességgel és magassággal rendereli, majd PNG képként menti az eredményt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

A `1` méretarány megtartja az adott tengely alap pixelméretét. Például a `2` mindkét tényezőre közel kétszeres szélességet és magasságot eredményez, ami négyszeres pixel számot ad. A nagyobb tényezők általában élesebb szöveget biztosítanak nagyításkor vagy nagy felbontású kimenetnél, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb, kevésbé részletgazdag képet adnak. Használjon egyenlő tényezőket a bekezdés képarányának megőrzéséhez; a különböző vízszintes és függőleges tényezők pedig önállóan nyújtják a kimenetet.

Egy egész forma renderelése a [Shape.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage)‑del akkor hasznos, ha a kimenetnek tartalmaznia kell a forma kitöltését, szegélyét vagy más vizuális kontextusát. Csak bekezdés‑képet szeretne, használja a [Paragraph.getImage]‑t.

## **GYIK**

**Teljesen letilthatom a sortörést egy szövegdobozon belül?**

Igen. Állítsa a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/setwraptext/) értékét a sortörés letiltásához, így a sorok nem törnek meg a szövegdoboz szélén.

**Hogyan szerezhetem meg egy adott bekezdés pontos helyi határait a dián?**

Használja a [Paragraph.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/getrect/) metódust a bekezdés határoló téglalapjának lekéréséhez. A [Portion.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#getRect) egyetlen rész határait adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setalignment/) bekezdés‑szintű beállítás, amely az egész bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

**Beállíthatom a helyesírási nyelvet egy bekezdés egy részére?**

Igen. Állítsa be a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) értékét az egyes részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.