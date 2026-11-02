---
title: "Prezentációk pontozott és számozott listáinak kezelése JavaScript használatával"
linktitle: "Listák kezelése"
type: docs
weight: 60
url: /hu/nodejs-java/manage-lists/
keywords:
- "pont"
- "pontozott lista"
- "számozott lista"
- "szimbólum pont"
- "kép pont"
- "egyéni pont"
- "többszintű lista"
- "pont létrehozása"
- "pont hozzáadása"
- "lista hozzáadása"
- PowerPoint
- OpenDocument
- "prezentáció"
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat pontozott, kép, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Node.js via Java lehetővé teszi, hogy pontozott és számozott listákat hozzon létre és formázzon PowerPoint és OpenDocument prezentációkban. Egy listaelem olyan bekezdés, amelynek a bullet beállításait a bekezdés formátuma vezérli.

Használja a [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) osztályt a bekezdés-szintű lista beállítások eléréséhez. A fő belépési pont a `Paragraph.getParagraphFormat().getBullet()`, amely egy [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a bullet típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- egy egyéni szimbólummal ellátott pontozott lista létrehozása
- kép bullet létrehozása
- többszintű lista létrehozása a bekezdés mélységének beállításával
- számozott lista létrehozása
- listaformázás megtekintése és módosítása egy meglévő prezentációban
- valódi listajelzők és számok beolvasása a bekezdés szövegével együtt

## **Pontozott lista létrehozása**

Pontozott lista létrehozásához adjon [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) objektumokat egy [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)-hez, és állítsa be a `BulletFormat.setType` értékét [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). Ezután beállíthatja a `BulletFormat.setChar`, `BulletFormat.getColor` és `BulletFormat.setHeight` értékeket a bullet megjelenésének szabályozásához.

Az alábbi JavaScript kód bemutatja, hogyan hozhat létre pontozott listát egy dián:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szimbólum bullet-ek](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa be a `BulletFormat.setType` értékét [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/). Megadhatja a számozási formátumot a `BulletFormat.setNumberedBulletStyle` segítségével, vagy a `BulletFormat.setNumberedBulletStartWith`‑ot, ha a lista 1 helyett más értékkel kell, hogy induljon.

Az alábbi JavaScript kód megmutatja, hogyan hozhat létre számozott listát egy dián:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A számozott bullet-ek](numbered_bullets.png)

## **Kép bullet létrehozása**

Aspose.Slides lehetővé teszi, hogy egy szabályos bullet szimbólumot képpel helyettesítsen. A kép bullet-ek leginkább egyszerű képekkel működnek jól, amelyek kis méretben is olvashatóak, például ikonok vagy kis átlátszó PNG fájlok.

{{% alert color="info" title="Note" %}}
Optimálisan, ha a szabályos bullet szimbólumot képpel szeretné helyettesíteni, a legjobb, ha egy egyszerű, átlátszó háttérrel rendelkező grafikát választ. Az ilyen képek jól működnek egyéni bullet szimbólumokként.

Ne feledje, hogy a képet nagyon kis méretre méretezzük le. Emiatt erősen ajánljuk, hogy olyan képet válasszon, amely listában bullet‑ként használva is tiszta és vizuálisan hatékony marad.
{{% /alert %}}

Kép bullet létrehozásához adjon hozzá egy képet a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑hez a `Presentation.getImages().addImage` segítségével, és rendelje hozzá a visszakapott [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) objektumot a `BulletFormat.getPicture().setImage`‑hez. A kép hozzárendelése előtt állítsa be a `BulletFormat.setType` értékét [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/).

Tegyük fel, hogy van egy „image.png” fájlunk:

![Kép a bullet-ekhez](picture_for_bullets.png)

Az alábbi JavaScript kód megmutatja, hogyan hozhat létre kép bullet‑eket egy dián:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Az eredmény:

![A kép bullet-ek](picture_bullets.png)

## **Többszintű lista létrehozása**

A `ParagraphFormat.setDepth` használatával helyezheti a listaelemeket különböző szintekre. A 0. szint a legfelső, az 1. szint alatta van beágyazva, és így tovább.

Az alábbi JavaScript kód megmutatja, hogyan hozhat létre többszintű pontozott listát:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A többszintű lista](multilevel_list.png)

## **Meglévő lista módosítása**

A listaformázás módosításához egy meglévő prezentációban, érje el a cél bekezdést, és frissítse a `ParagraphFormat.getBullet` beállításait. Ugyanazokat a tulajdonságokat, amelyekkel listákat hozott létre, használhatja a PPT, PPTX vagy ODP fájlból betöltött listák megtekintésére vagy módosítására.

Az alábbi JavaScript kód megváltoztatja egy szövegkeret első bekezdését, hogy számozott lista stílusra használja:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Valódi bullet értékek olvasása**

A prezentáció tartalmának kinyerésekor tartsa meg a listajelzőket a bekezdés szövegével együtt. Hívja a [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective)‑t, és érje el az [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--)‑t a hatékony bullet formátum lekéréséhez. Olvasás előtt ellenőrizze a [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) értékét a [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) meghívása előtt.

Számozott listák esetén különböztesse meg ezt a három értéket:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) meghatározza a formátumot, például arab számok ponttal, vagy kisbetűk ponttal.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) határozza meg a kezdő számot egy számozott bekezdéscsoport számára.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) visszaadja egy adott bekezdés formázott jelzőjét. Például egy 5‑től induló lista második eleme `6.`‑ot ad.

Minden bekezdésnél őrizze meg a [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDepth) értékét a beágyazottsági szint megtartásához. A tényleges jelző nem kódolja a teljes hierarchiát: egy beágyazott elem visszaadhatja a `c.`‑t a `6.c.`‑helyett.

Az alábbi önálló példa listákat hoz létre, menti őket egy prezentációba, majd újratölti a prezentációt, hogy jelentést készítsen minden bekezdés szövegéről, mélységéről, bullet típusáról és tényleges értékéről. A kis kék képjelző inline SVG‑ből készült.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Készítsen egy képjelzőt külső képfájl nélkül.
    const svg = new aspose.slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    const bulletImage = presentation.getImages().addImage(svg);

    function addParagraph(text, depth, type, start, style) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.setText(text);

        const format = paragraph.getParagraphFormat();
        format.setDepth(java.newShort(depth));
        format.setMarginLeft(30 + depth * 40);
        format.setIndent(-28);
        format.setSpaceAfter(8);
        format.getDefaultPortionFormat().setFontHeight(22);
        format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(black);
        format.getBullet().setType(java.newByte(type));
        format.getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
        format.getBullet().getColor().setColor(black);
        if (type === aspose.slides.BulletType.Numbered) {
            format.getBullet().setNumberedBulletStyle(java.newByte(style));
            format.getBullet().setNumberedBulletStartWith(java.newShort(start));
        } else if (type === aspose.slides.BulletType.Symbol) {
            format.getBullet().setChar(java.newChar(0x2022));
        } else if (type === aspose.slides.BulletType.Picture) {
            format.getBullet().getPicture().setImage(bulletImage);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    addParagraph("First item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Second item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Next nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Deep item", 2, aspose.slides.BulletType.Numbered, 4, aspose.slides.NumberedBulletStyle.BulletRomanLCPeriod);
    addParagraph("Back to top level", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Symbol marker", 0, aspose.slides.BulletType.Symbol, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("No bullet", 0, aspose.slides.BulletType.None, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Picture marker", 0, aspose.slides.BulletType.Picture, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const loadedPresentation = new aspose.slides.Presentation("actual_bullet_values.pptx");
try {
    const loadedShape = loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Text | Depth | Type | Actual value");
    const paragraphs = loadedShape.getTextFrame().getParagraphs();
    for (let i = 0; i < paragraphs.getCount(); i++) {
        const paragraph = paragraphs.get_Item(i);
        const bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        let marker;
        switch (bullet.getType()) {
            case aspose.slides.BulletType.Numbered:
            case aspose.slides.BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case aspose.slides.BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case aspose.slides.BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        const typeName = Object.keys(aspose.slides.BulletType).find(name => aspose.slides.BulletType[name] === bullet.getType());
        console.log(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Az eredeti listák alább láthatók.

![Listák 5‑től kezdve, beágyazott betű és római számú elemek, egy szimbólum jelző, egy bekezdés bullet nélkül, és egy kék képjelző](actual_bullet_values.png)

A jelentés megegyezik a PowerPointban megjelenített jelzőkkel:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

A [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) esetén a [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null`‑t ad vissza, nem üres karakterláncot. Kezelje ezeket a típusokat külön: az elsőnek nincs jelzője, míg a másodikhoz a bullet képet külön kell kinyerni. A kép bullet-t nem lehet kizárólag szöveges jelző kinyerésével reprodukálni.

## **GYIK**

**Exportálhatók a pontozott és számozott listák PDF‑re vagy képekre?**

Igen. Az Aspose.Slides megőrzi a listaformázást, ha a célformátum támogatja a megfelelő szövegelrendezést és bullet funkciókat.

**Szerkeszthetek listákat meglévő prezentációkban?**

Igen. Töltse be a prezentációt, érje el a cél bekezdést, ellenőrizze vagy frissítse a `ParagraphFormat.getBullet` beállításait, majd mentse a prezentációt.

**Tartalmazhatnak a listák nem latin szöveget?**

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így többnyelvű prezentációkban is létrehozhat listákat. Győződjön meg róla, hogy a prezentációban használt betűtípusok támogatják a szükséges karaktereket.