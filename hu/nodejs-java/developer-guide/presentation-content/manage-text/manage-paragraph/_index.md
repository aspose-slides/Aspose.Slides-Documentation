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
  - felsorolás kezelése
  - bekezdés behúzása
  - függő behúzás
  - bekezdés felsorolás
  - számozott lista
  - felsorolt lista
  - bekezdés tulajdonságok
  - HTML importálása
  - szöveg HTML-re
  - bekezdés HTML-re
  - bekezdés képre
  - szöveg képre
  - bekezdés exportálása
  - PowerPoint
  - prezentáció
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmat és bekezdés képeket az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java a szöveget szövegkeretek, bekezdések és részek hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) a szöveg tárolója egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) egy bekezdést ábrázol egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdés-szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) a szöveg egy futását ábrázolja egy bekezdésen belül. Minden résznek saját szövege és karakter-szintű formázása lehet.

Ezáltal egy bekezdés különböző betűtípusú, színű, méretű és egyéb formázású szöveget is tartalmazhat több rész használatával.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több résszel**

A következő lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát az indexe alapján.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet a diához.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) elemét.
5. Használja az alapértelmezett bekezdést, és adjon hozzá további két [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) objektumot a szövegkerethez.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter-szintű formázást a [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/) segítségével.
9. Mentse a módosított bemutatót.

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

A felsorolások és a számozás megkönnyíti a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet a kiválasztott diához.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) elemet egy szimbólum felsoroláshoz.
7. Állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) értékét [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/)‑ra, és adja meg a felsorolás karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a felsorolás színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) értékét [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/)‑ra.
11. Állítsa be a számozott felsorolás stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a bemutatót.

Ez a JavaScript példa létrehoz egy szimbólum felsorolást és egy számozott felsorolást:

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

### **Képes felsorolások használata**

A képes felsorolások lehetővé teszik egy egyedi kép használatát szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet, és érje el annak [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) elemét.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a felsorolás képet, és adja hozzá a bemutató képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) értékét [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/)‑ra.
8. Rendelje hozzá a képet a [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) segítségével, és állítsa be a felsorolás magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított bemutatót.

Ez a JavaScript példa létrehoz egy képes felsorolást:

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

Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretéből.
3. Hozzon létre négy bekezdést, és konfigurálja azok felsorolás szimbólumait.
4. Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) értékeket `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a bemutatót.

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

### **Számozott listaelemek indítása egyéni értékekkel**

Használja a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) metódust a számozott bekezdés kezdeti számának beállításához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) elemet, és adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet egy diához.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) értékét a megfelelő bekezdésekhez `2`, `3` és `7`‑re.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a bemutatót.

Ez a JavaScript példa egyéni kezdőszámot ad minden bekezdéshez:

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

## **Bekezdés elrendezésének és vég tulajdonságainak vezérlése**

### **Első sor behúzásának beállítása**

Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolják az első sort, míg a többi sor a bekezdéstörzshez igazodik.

Használja a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) metódust, ha a teljes bekezdést szeretné eltolni. Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) metódust, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet a diára.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) elemét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított bemutatót.

Ez a kód azt mutatja, hogyan állíthat be bekezdésbehúzást:

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

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás egy bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) segítségével hozza létre. Negatív értékkel mozgathatja az első sort balra a bekezdés törzséhez képest.

A gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) határozza meg a bekezdés törzse bal pozícióját, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) pedig az első sor pozícióját ahhoz a margóhoz képest. Függő behúzás létrehozásához pozitív értéket adjon a `setMarginLeft`‑nek és negatív értéket a `setIndent`‑nek.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedeti bejegyzések és más bekezdések esetén, ahol a sortöréses soroknak a bekezdés törzse alatt kell igazodniuk, nem pedig az első sor első karaktere alatt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet a diára.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) elemét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és minden bekezdéshez adjon pozitív értéket a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)‑nek.
6. Adjon negatív értéket a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)‑nek a függő behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított bemutatót.

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

### **A bekezdés végének futtatási tulajdonságainak beállítása**

A [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) szabályozza a bekezdés végjelének formázását. A következő példa betűméretet és latin betűtípust rendel a második bekezdés végjeléhez:

1. Hozzon létre vagy töltse be egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon hozzá szöveg részeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) elemet a második bekezdés végjeléhez.
5. Állítsa be a [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) és a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) segítségével, és mentse a bemutatót.

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

## **Renderelt sorok számlálása**

A bekezdés szabályai, amelyek az automatikus sortörést és a sorvégi írásjeleket érintik, lásd: [Control Line Breaking](/slides/hu/nodejs-java/text-formatting/#control-line-breaking) és [Control Hanging Punctuation](/slides/hu/nodejs-java/text-formatting/#control-hanging-punctuation).

Használja a [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) metódust, hogy megszámolja a bekezdés által elfoglalt sorok számát a szöveg elrendezése után, beleértve az automatikus sortörést. Ez hasznos a szöveghossz és elrendezés ellenőrzésénél a bemutató sablonokban.

Egy bekezdés a [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParagraphs) egy eleme, és több renderelt sort is foglalhat el. Egy explicit sortörés a bekezdésen belül új sort kényszerít anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicite sortörés karaktereket illesztene a szövegbe. Így a bekezdések vagy sortörés karakterek számlálása nem adja meg a renderelt sorok számát.

A következő példa létrehoz egy szöveg alakzatot, megszámolja a sorait, szűkíti az alakzatot, majd egy rövidebb karakterláncra cseréli a szöveget. A sortörés engedélyezett, az autofit le van tiltva, így az alakzat szélessége szabályozza a sortörést anélkül, hogy automatikusan zsugorítaná a szöveget vagy átméretezné az alakzatot. Az alakzat méretei pontban vannak. Végül a példa hozzáad egy másik bekezdést, és összeadja a sorok számát a szövegkeretben.

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

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a szöveg rövid karakterláncra cserélése csökkenti azt. A pontos számok változhatnak a betűtípusok elérhetősége és helyettesítése, betűméret, margók, behúzás, sortörés és autofit beállítások függvényében. A sablon ellenőrzésekor a célnak megfelelő betűtípusokat és elrendezési beállításokat használja.

A sorok száma önmagában nem határozza meg, hogy a szöveg túllépi-e a konténert. A rendelkezésre álló magasság, sor magasságok, bekezdés- és sorköz, valamint az autofit viselkedés is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) metódust, hogy az HTML jelölőnyelvet bekezdésekké és részekké alakítsa egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Érje el egy diát, és adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) elemét, és törölje az alapértelmezett bekezdést.
4. Határozza meg vagy olvassa be a forrás HTML karakterláncot.
5. Adja át az HTML karakterláncot a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) metódusnak.
6. Mentse a módosított bemutatót.

Ez a JavaScript példa HTML-t importál egy szövegkeretbe:

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

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) metódust, hogy a kiválasztott bekezdéstartományt HTML-ként exportálja.

1. Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) példányt.
2. Érje el a diát, és keresse meg a szöveget tartalmazó [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) elemét.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszaadott HTML karakterláncot egy fájlba.

Ez az önálló JavaScript példa létrehoz egy szöveg alakzatot, és exportálja az összes bekezdését:

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

A [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) közvetlenül renderel egy egyedi bekezdést, és visszaad egy [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) objektumot. Az eredményt egy fájlba mentheti a [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) segítségével. Nem kell a tartalmazó alakzatot renderelni vagy kézzel kivágni egy bitmapet.

A [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) `null` értéket adhat vissza, ha a bekezdést nem találja meg a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Mentés előtt ellenőrizze az eredményt, és a használat után engedje el a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett mérettel**

A következő szövegmező három bekezdést tartalmaz:

![A három bekezdést tartalmazó szövegmező](paragraph_to_image_input.png)

A következő példa a második bekezdést egy normál szöveg alakzatban az alapértelmezett mérettel rendereli, és a visszaadott képet PNG formátumban menti. A `finally` blokk biztosítja, hogy a kép helyesen el legyen engedve.

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

#### **Bekezdés renderelése táblázat cellában méretezéssel**

Használja a [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) túlterhelését, amely `scaleX` és `scaleY` paramétereket fogad, hogy beállítsa a vízszintes és függőleges méretezési tényezőket. A következő példa egy táblázatot hoz létre, a bekezdést az első cellájában a alapértelmezett szélesség és magasság kétszeresére rendereli, és az eredményt PNG képként menti.

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

Az `1` méretezési tényező megtartja az adott tengely alapértelmezett képméretét. Például a `2` mindkét tényező esetén egy olyan képet eredményez, amelynek szélessége és magassága körülbelül kétszerese az alapértelmezett méretnek, így négyszer annyi pixel keletkezik. A nagyobb tényezők általában élesebb szöveget biztosítanak nagyításhoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájl méretét. Az `1` alatti tényezők kisebb, részletgazdagabb képeket eredményeznek. Azonos tényezőket használjon a bekezdés arányának megőrzéséhez; a különböző vízszintes és függőleges tényezők önállóan nyújtják a képet.

Egy teljes alakzat renderelése a [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) segítségével még mindig hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Bekezdés‑csak képek esetén használja a [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) metódust.

## **FAQ**

**Letilthatom teljesen a sortörést egy szövegkereten belül?**

Igen. Állítsa a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) értékét a sortörés letiltásához, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián lévő határait?**

Használja a [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) metódust a bekezdés határoló téglalapjának lekéréséhez. A [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/#getRect) egy egyedi rész határait adja meg.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) bekezdés-szintű beállítás, amely az egész bekezdésre vonatkozik, függetlenül az egyedi részformázástól.  
A különböző betűméretű részek soron belüli függőleges igazításához tekintse meg a [Align Fonts Within a Line](/slides/hu/nodejs-java/text-formatting/#align-fonts-within-a-line) útmutatót.

**Beállíthatom a helyesírás-nyelvet egy bekezdés egy részére?**

Igen. Állítsa be az egyes részeknél a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) értékét, így egy bekezdés több nyelven is tartalmazhat szöveget.