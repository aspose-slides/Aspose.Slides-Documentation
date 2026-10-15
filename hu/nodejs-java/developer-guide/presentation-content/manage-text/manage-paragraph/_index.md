---
title: PowerPoint szövegbekezdések kezelése JavaScriptben
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
- bekezdés felsorolása
- számozott lista
- felsorolás lista
- bekezdés tulajdonságai
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
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, felsorolásokat, számozott listákat, behúzásokat, HTML tartalmat és bekezdésképeket az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Node.js via Java a szöveget szövegkeretek, bekezdések és szakaszok (portions) hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) a szövegkonténert egy alakzatban képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a szakaszaihoz valamint a bekezdés szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) egy szövegfolyamot képvisel egy bekezdésen belül. Minden szakasz saját szöveggel és karakter szintű formázással rendelkezhet.

Ezáltal egy bekezdés több szakasz használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

Hozzon létre bekezdéseket egy alakzat szövegkeretében, és használja a szakaszokat az egyedi szövegfolyamok formázásához. Ez a rész bemutatja, hogyan kombináljon több szakaszt minden bekezdésben, és alkalmazzon különböző színeket, betűméreteket és stílusokat.

### **Bekezdések létrehozása több szakaszzal**

Az alábbi JavaScript‑példa három bekezdést hoz létre, mindegyik három szövegfolyamot tartalmaz a [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/) által visszaadott gyűjteményben. Újra felhasználja az alapértelmezett bekezdést és annak üres szakaszát, majd hozzáadja a maradék bekezdéseket és szakaszokat. A formázás a [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/) segítségével történik: az első szakasz minden bekezdésben piros, félkövér és 15 pont; a második kék, dőlt és 18 pont. A harmadik szakasz megtartja az alapértelmezett formázást:

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

Rendezze a bekezdés‑szöveget listákba szimbólumok, számok vagy egyedi képek segítségével. Ebben a szekcióban a listaformázás, több szintű listák és egyedi kezdőszámok példáit mutatjuk be.

### **Felsorolásos vagy számozott lista létrehozása**

A felsorolások és a számozás segít a kapcsolódó elemek gyors áttekintésében. Az Aspose.Slides‑ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) határozza meg.

Ez a JavaScript‑példa egy szimbólum‑felsorolást és egy számozott elemet ad ugyanahhoz a szövegkerethez. A [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) kiválasztja a felsorolás típusát, a [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) megadja a szimbólumot, a [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) pedig a számozási stílust. Mindkét elem fekete felsorolást kap 100 % magassággal és 25 pont bekezdésbehúzással:

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

Ez a JavaScript‑példa betölti az `image.png`‑t az alkalmazás munkakönyvtárából, a képet hozzáadja a bemutató képgyűjteményéhez egy [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)‑ként, majd beállítja bekezdés‑felsorolásként. A [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) hívásával képes felsorolást választ, a kép a [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) segítségével kerül hozzárendelésre. A [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) 100 %-ra van állítva, hogy a felsorolás mérete a bekezdés‑szöveghez viszonyítva legyen:

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

A [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) segítségével a bekezdéseket a lista különböző szintjeire lehet helyezni. A legfelső szint mélysége `0`.

Ez a JavaScript‑példa a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) értékeit 0‑tól 3‑ig rendeli négy bekezdéshez, így egy hierarchiát hoz létre egy szövegkeretben. Minden bekezdés szimbólum‑felsorolást használ, a [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) váltakozva egy kör alakú és egy kötőjel‑felsorolás között, hogy elkülönítse az egymás melletti szinteket:

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

### **Számozott elemek egyéni kezdőértékkel**

A [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) segítségével megadható a számozott bekezdés kezdeti száma.

Ez a JavaScript‑példa a [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/)‑t használja a számozásra három bekezdésnél, majd a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) értékeit 2, 3 és 7-re állítja. A kezdőérték minden bekezdésnél külön konfigurálható, így a megjelenített számok kihagyhatnak értékeket:

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

## **Bekezdés‑elrendezés és befejező tulajdonságok vezérlése**

Állítsa be a bekezdés margóit és behúzásait, hogy szabályozza az első sor és a tördelő sorok helyzetét. A bekezdés befejező jelét is formázhatja külön a látható szövegszakaszoktól.

### **Első sor behúzásának beállítása**

A [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) metódussal szabályozható egy bekezdés első sorának behúzása. Ez a beállítás csak az első sort mozgatja a bekezdés bal margójához képest. Pozitív érték esetén az első sor jobbra tolódik, míg a többi sor a bekezdés testhez igazodik.

A [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) akkor használható, ha a teljes bekezdést kell eltolni. A [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) akkor, ha csak az első sort kell elmozdítani.

Az alábbi példa három bekezdésnek ugyanazt a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 20 pont értéket és a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) 0, 20 és 40 pont értékeket adja. Az első sorok egyre nagyobb eltolással kezdődnek, míg a tördelő sorok ugyanazt a bal margót tartják:

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

A függő behúzás olyan bekezdéselrendezés, ahol az első sor a maradék sorok bal oldalán kezdődik. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) metódussal érhetjük el. Negatív érték beállításával az első sor balra tolódik a bekezdés testéhez képest.

Gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) határozza meg a bekezdés testének bal pozícióját, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) pedig az első sor pozícióját ahhoz a margóhoz képest. Függő behúzás létrehozásához állítsunk be pozitív bal margót és negatív behúzást.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a tördelő soroknak a bekezdés testje alatt kell igazodniuk, nem pedig az első karakter alá.

Az alábbi JavaScript‑példa a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 40  és 60 pont értékeit kombinálja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) –20 és –30 pont értékeivel. Minden bekezdésben az első sor a tördelő sorok bal oldalán kezdődik; a második bekezdés mélyebb függő behúzást kap:

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

### **Bekezdés‑vége formázási tulajdonságok beállítása**

A [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) metódus szabályozza a bekezdés befejező jelének formázását. Az alábbi példa létrehoz egy [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) objektumot, amelynek a [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) értéke 48 pont, a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) pedig Times New Roman. Ezt a formátumot a második bekezdés befejező jeléhez rendeli, miközben a látható szövegszakaszok változatlanok maradnak:

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

A bekezdés‑szabályok, amelyek az automatikus tördelést és a sorvégi írásjelek viselkedését befolyásolják, megtalálhatók a [Control Line Breaking](/slides/hu/nodejs-java/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/nodejs-java/text-formatting/#control-hanging-punctuation) dokumentumokban.

A [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) segítségével megszámolható, hány sort foglal el egy bekezdés a szöveg elrendezése után, beleértve az automatikus tördelést. Ez hasznos a szöveghossz és az elrendezés ellenőrzéséhez prezentációs sablonokban.

A bekezdés egy elem a [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/) gyűjteményében, és több renderelt sort is elfoglalhat. Egy explicit sortörés egy bekezdésen belül új sort hoz létre anélkül, hogy új bekezdést képezne. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicit sortöréseket illesztene a szövegbe. Így a bekezdések vagy sortörés‑karakterek számlálása nem adja meg a renderelt sorok számát.

Az alábbi példa létrehoz egy szövegalakzatot, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A példa engedélyezi a tördelést a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) segítségével, és letiltja az automatikus illesztést a [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/)‑val, hogy az alakzat szélessége szabályozza a tördelést anélkül, hogy a szöveg automatikusan zsugorodna vagy az alakzat mérete változna. Minden mérés a [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) használatával történik. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a teljes szövegkeretben.

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

Ezzel a szöveggel és ezekkel a méretekkel a szűkítés növeli a sorok számát, míg a rövidebb szöveg csökkenti azt. A pontos számok a betűtípus elérhetőségétől, betűcsere beállításaitól, betűmérettől, margóktól, behúzásoktól, tördeléstől és az automatikus illesztés beállításaitól függnek. A célkörnyezetben használt betűtípusok és elrendezési beállítások alkalmazása ajánlott sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlfut-e a tárolóján. A rendelkezésre álló magasság, sormagasságok, bekezdés‑ és sorközök, valamint az automatikus illesztés viselkedése is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a tördelés ki van kapcsolva.

## **Bekezdés‑tartalom importálása és exportálása**

HTML‑el hozhat szöveget egy prezentációba, vagy exportálhat meglévő bekezdéseket külső felhasználásra. Ez a szekció továbbá bemutatja, hogyan lehet egyedi bekezdéseket képként renderelni, beleértve a táblázatcellákban lévő bekezdéseket is.

### **HTML‑szöveg importálása bekezdésekbe**

A [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) segítségével a HTML‑markupot bekezdésekké és szakaszokká alakíthatja egy szövegkeretben.

Ez a JavaScript‑példa a `file.html`‑t olvassa be az alkalmazás munkakönyvtárából, és a markupot átadja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)‑nak. Törli a szövegkeret alapértelmezett bekezdését, így a keret csak a importált tartalmat tartalmazza. A téglalap alakzat 10 pont margót hagy a dia minden oldala körül:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bekezdés‑szöveg exportálása HTML‑be**

A [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) segítségével egy kiválasztott bekezdéssorozatot exportálhat HTML‑ként. Ha a bemutató szöveget egy weboldalon szeretné újra felhasználni, előfordulhat, hogy a helyi kiemeléseket szeretné megőrizni anélkül, hogy a bemutató betűtípusa, mérete vagy szövegdoboz‑stílusa átkerülne. A [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) beállításával szabályozható, hogy a konverter meddig követi a formázási öröklődést.

Töltse le a [mintaprezentációt](text-inheritance.pptx), és helyezze az alkalmazás munkakönyvtárába. Az első dia egy szövegdobozt tartalmaz a „Inherited text; explicit red 18pt” szöveggel. A bemeneti dokumentum szándékosan több formázási szintet használ:

- A prezentáció alapértelmezett szövegstílusa Calibri betűtípust és 28 pt méretet ad.
- A szövegkeret első‑szintű stílusa kék és dőlt szöveget ad.
- A bekezdés explicit módon félkövér szöveget állít be.
- A második szakasz, „explicit red 18pt”, explicit módon piros szöveget és 18 pt méretet ad.

Az alábbi teljes példa háromszor exportálja ugyanazokat a bekezdéseket. A [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/)‑t átadja az export‑metódusnak, és minden eredményt külön UTF‑8 HTML‑fájlba ír:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
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

A generált HTML a következő CSS‑t tartalmazza az első szakaszhoz, „Inherited text; “. A táblázat a releváns deklarációkat sorolja fel; a többi generált tulajdonság ki van hagyva a tisztaság kedvéért.

| Kimenet | Az első szakasz releváns CSS‑e | Megjelenés |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg 28 pt Calibri‑val, ha a betűtípus elérhető. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg; a környező oldal vagy böngésző adja a betűcsaládot és méretet. |
| `ParagraphOnly.html` | `font-weight:bold` | Félkövér szöveg; a környező oldal vagy böngésző adja a betűcsaládot, méretet, színt és dőlt stílust. |

A második szakasz megtartja a `color:#ff0000`, `font-size:18pt` és `font-weight:bold` értékeket mindhárom kimenetben. Az „All” és a „TextBox” verziók dőlt formátumot is megőrzik, a „ParagraphOnly” nem. Az öröklődés korlátozása tehát nem távolítja el a bekezdéshez vagy szakaszhoz explicit módon hozzárendelt formázást.

Nyissa meg a fájlokat ugyanabban a böngészőben a összehasonlításhoz. A két korlátozott módban a kihagyott CSS‑tulajdonságokat a céloldal stílusai vagy a böngésző alapértelmezései egészítik ki, így a végeredmény megjelenése attól függ, hogy hol használják a HTML‑t.

### **Bekezdés renderelése képként**

A [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) egyetlen bekezdést renderel közvetlenül, és egy [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/)‑t ad vissza. A végeredményt a [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save)‑vel mentheti fájlba vagy adatfolyamba. Nem szükséges a tartalmazó alakzatot renderelni vagy manuálisan bitmap‑et vágni.

A [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) `null`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. A mentés előtt ellenőrizze az eredményt, és használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alap mérettel**

A példa létrehoz egy prezentációt egyetlen diával, melynek első alakzata egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

Az alábbi példa a 1‑es indexű (második) bekezdést választja, és a [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage)‑et skálaparaméterek nélkül hívja. Ellenőrzi, hogy az alakzat tartalmazza a szükséges bekezdést, és hogy a renderelés valóban képet ad vissza, mielőtt a [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save)‑val PNG‑ként mentené. A `finally` blokk a kép felhasználása után felszabadítja azt.

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

#### **Bekezdés renderelése táblázatcellában skálázással**

Használja a [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) olyan túlterhelését, amely `scaleX` és `scaleY` paramétereket fogad, a vízszintes és függőleges skálázási tényezők beállításához. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres alap szélességgel és magassággal rendereli, majd PNG‑képként menti.

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

Az 1‑es skálafaktor megtartja az adott tengelyt az alappixelméretén. Például a 2‑es érték mindkét tényezőre egy olyan képet eredményez, amelynek szélessége és magassága nagyjából kétszerese az alapdimenzióknak, azaz négyszeres pixel számmal. A nagyobb tényezők általában élesebb szöveget adnak nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az 1‑nél kisebb tényezők kisebb, kevésbé részletes képeket hoznak létre. A képarány megtartásához használjon egyenlő tényezőket; a vízszintes és függőleges eltérő tényezők külön-külön nyújtják a kimenetet.

Egy teljes alakzat renderelése a [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage)‑val akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdés‑képet szeretne, akkor használja a [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage)-t.

## **GYIK**

**Teljesen le lehet tiltani a sortördelést egy szövegkereten belül?**

Igen. A [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) beállításával letiltható a tördelés, így a sorok nem törnek a szövegkeret szélén.

**Hogyan lehet pontosan lekérdezni egy adott bekezdés dián megjelenő határait?**

Használja a [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) metódust a bekezdés körülhatároló téglalap lekéréséhez. A [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) egy adott szakasz határait adja vissza.

**Hol vezérelhető a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes szakaszok formázásától.

A különböző betűméretű szakaszok függőleges igazításához lásd a [Align Fonts Within a Line](/slides/hu/nodejs-java/text-formatting/#align-fonts-within-a-line) dokumentumot.

**Be lehet állítani a nyelvellenőrzés nyelvét a bekezdés egy részére?**

Igen. A [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) beállítható egyes szakaszokra, így egy bekezdés több nyelven is tartalmazhat szöveget.