---
title: PowerPoint szöveg bekezdések kezelése JavaScript-ben
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
  - bullet kezelése
  - bekezdés behúzás
  - függő behúzás
  - bekezdés bullet
  - számozott lista
  - felsorolás lista
  - bekezdés tulajdonságok
  - HTML importálása
  - szöveg HTML-be
  - bekezdés HTML-be
  - bekezdés képpé
  - szöveg képpé
  - bekezdés exportálása
  - PowerPoint
  - prezentáció
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, bullet‑eket, számozott listákat, behúzásokat, HTML‑tartalmat és bekezdésképeket az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Node.js via Java a szöveget szövegdobozok, bekezdések és részek hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) a szövegtárolót reprezentálja egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegdobozban, és hozzáférést ad a részeihez valamint a bekezdés‑szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) egy szövegrészt jelent egy bekezdésen belül. Minden résznek saját szövege és karakter‑szintű formázása lehet.

Egy bekezdés tehát több részt is tartalmazhat, lehetővé téve a különböző betűkészletek, színek, méretek és egyéb formázások használatát.

## **Bekezdések létrehozása és formázása**

### **Több részes bekezdések létrehozása**

Az alábbi lépések egy szövegdobozt hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a kívánt diát az indexén keresztül.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
4. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) részéhez.
5. Használja az alapértelmezett bekezdést, és adjon hozzá még két [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) objektumot a szövegdobozhoz.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) objektumot úgy, hogy minden bekezdés három részt tartalmazzon. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter‑szintű formázást a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/getportionformat/) segítségével.
9. Mentse a módosított prezentációt.

Ez a JavaScript példa megvalósítja a fenti lépéseket:

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

A felsorolások és a számozás megkönnyíti a kapcsolódó elemek áttekintését. Az Aspose.Slides‑ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a kívánt diát az indexén keresztül.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a kiválasztott diához.
4. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) részéhez.
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) elemet egy szimbólum‑bullethez.
7. Állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/settype/) értékét [BulletType.Symbol](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bullettype/)-ra, és adja meg a bullet karaktert.
8. Állítsa be a bekezdés szövegét, behúzását, bullet színét és magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Hozzon létre egy második bekezdést, és állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/settype/) értékét [BulletType.Numbered](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bullettype/)-ra.
11. Konfigurálja a számozott bullet stílusát, majd adja hozzá a bekezdést a szövegdobozhoz.
12. Mentse a prezentációt.

Ez a JavaScript példa szimbólum‑bulletet és számozott bulletet hoz létre:

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

### **Képes bullet használata**

A képes bullet lehetővé teszi, hogy szimbólum vagy szám helyett egy egyéni képet használjon.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a kívánt diát az indexén keresztül.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet, majd férjen hozzá annak [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) részéhez.
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
5. Töltse be a bullet képet, és adja hozzá a prezentáció képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) formájában.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/settype/) értékét [BulletType.Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bullettype/)-ra.
8. A [BulletFormat.getPicture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/getpicture/) segítségével rendelje hozzá a képet, és állítsa be a bullet magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Mentse a módosított prezentációt.

Ez a JavaScript példa képes bulletet hoz létre:

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

A [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setdepth/) beállításával helyezheti a bekezdéseket a lista különböző szintjeire. A felső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet, majd törölje az alapértelmezett bekezdést a szövegdobozából.
3. Hozzon létre négy bekezdést, és állítsa be a bullet szimbólumaikat.
4. Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setdepth/) értékeit `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a prezentációt.

Ez a JavaScript példa négy szintű felsorolást hoz létre:

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

### **Számozott lista elemeinek egyéni kezdőértéke**

A [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) használatával állíthatja be a számozott bekezdés kezdeti számát.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) elemet, és adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet egy diához.
2. Törölje a forma szövegdobozából az alapértelmezett bekezdést.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) értékeit `2`, `3` és `7`‑re a megfelelő bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a prezentációt.

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

## **Bekezdéselrendezés és befejezési tulajdonságok vezérlése**

### **Első sor behúzás beállítása**

A [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) segítségével szabályozhatja egy bekezdés első sorának behúzását. Ez a metódus csak az első sort mozdítja el a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

A teljes bekezdés elmozgatásához használja a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)-t. Az első sor csak valódi eltolásához használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/)-et.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a céldiat.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
4. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) részéhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) értékeket nekik.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be bekezdésbehúzást:

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

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) használatával érheti el. Negatív érték átadása a első sort balra tolja a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) definiálja a bekezdés törzsének bal pozícióját, míg a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) határozza meg az első sor helyzetét ehhez a margóhoz képest. Függő behúzás létrehozásához adjon meg pozitív értéket a `setMarginLeft`‑nek, és negatív értéket a `setIndent`‑nek.

Ez a formázás különösen hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a sortörésű soroknak a bekezdés törzsének alá kell illeszkedniük, nem pedig az első sor első karakteréhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a céldiat.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
4. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) részéhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és minden bekezdésnél adjon meg pozitív értéket a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)‑nek.
6. Adjon negatív értéket a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/)‑nek, hogy létrejöjjön a függő behúzás hatása.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be függő behúzást egy bekezdéshez:

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

### **Befejező bekezdés‑run tulajdonságok beállítása**

A [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) szabályozza a bekezdés befejező jelének formázását. Az alábbi példa betűméretet és latin betűtípust állít be a második bekezdés befejező jelére:

1. Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet, és tisztítsa meg az alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/) objektumot a második bekezdés befejező jeléhez.
5. Állítsa be a [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) és a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/)‑el, és mentse a prezentációt.

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

## **Bekezdés tartalom importálása és exportálása**

### **HTML‑szöveg importálása bekezdésekbe**

A [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) segítségével HTML‑kódolást alakíthat bekezdésekké és részekké egy szövegdobozban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el egy diát, és adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet.
3. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) részéhez, és távolítsa el az alapértelmezett bekezdést.
4. Definiálja vagy olvassa be a forrás HTML‑szöveget.
5. Adja át a HTML‑szöveget a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)-nek.
6. Mentse a módosított prezentációt.

Ez a JavaScript példa HTML‑t importál egy szövegdobozba:

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

### **Bekezdés szövegének exportálása HTML‑be**

A [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) segítségével a bekezdések egy kiválasztott tartományát exportálhatja HTML‑ként.

1. Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt.
2. Érje el a diát, és keresse meg a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet, amely a szöveget tartalmazza.
3. Hozzáférés a forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) részéhez.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/)‑t a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszaadott HTML‑szöveget egy fájlba.

Ez az önálló JavaScript példa szöveges alakzatot hoz létre, majd az összes bekezdését exportálja:

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

A [Paragraph.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getImage) közvetlenül megjeleníti az egyes bekezdést, és egy [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) objektumot ad vissza. Az eredményt a [IImage.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/#save)‑vel mentheti fájlba. Nem szükséges a környező alakzatot renderelni vagy a bitmapet manuálisan kivágni.

A [Paragraph.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getImage) `null`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Mentség előtt ellenőrizze az eredményt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezésben**

Az alábbi szövegdoboz három bekezdést tartalmaz:

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy szabályos szöveges alakzatban rendereli alapértelmezett méretezésben, és a kapott képet PNG formátumban menti. A `finally` blokk biztosítja a kép helyes felszabadítását.

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

#### **Bekezdés renderelése táblázatcella‑szintű skálázással**

Használja a [Paragraph.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getImage) olyan overload‑ját, amely a `scaleX` és `scaleY` paramétereket fogadja, hogy beállítsa a vízszintes és függőleges skálafaktorokat. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában a kép szélességénél és magasságánál kétszeresére skálázza, majd PNG képként menti az eredményt.

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

Az `1` skálafaktor megtartja az adott tengely alapértelmezett pixelméretét. Például a `2` mindkét tényező esetén a kép szélessége és magassága megközelítőleg kétszeres lesz, ami néggyszeres pixel számot eredményez. A nagyobb tényezők általában élesebb szöveget adnak nagyításhoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1`‑nél kisebb tényezők kisebb, kevésbé részletgazdag képeket hoznak létre. Az egyenlő tényezők megtartják a bekezdés képarányát; a különböző vízszintes és függőleges tényezők önállóan nyújtják a képet.

A teljes alakzat renderelése a [Shape.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage)‑val akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, keretét vagy egyéb vizuális kontextusát. Csak bekezdés‑képhez használja a [Paragraph.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getImage)‑t.

## **GYIK**

**Teljesen le tudom tiltani a sortörést egy szövegdobozon belül?**

Igen. Állítsa a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/setwraptext/) értékét a törés letiltásához, így a sorok nem törnek meg a szövegdoboz szélein.

**Hogyan kaphatom meg egy adott bekezdés pontos dián belüli határait?**

Használja a [Paragraph.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/getrect/) metódust a bekezdés határoló téglalapjának lekéréséhez. A [Portion.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#getRect) egy adott rész határait adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárás)?**

A [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setalignment/) bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

**Be tudok-e állítani nyelvi ellenőrzést a bekezdés egy részére?**

Igen. Állítsa be a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) értékét az egyes részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.