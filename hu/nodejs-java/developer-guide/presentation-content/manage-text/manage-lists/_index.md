---
title: Felsorolt és számozott listák kezelése bemutatókban JavaScript segítségével
linktitle: Listák kezelése
type: docs
weight: 60
url: /hu/nodejs-java/manage-lists/
keywords:
- felsorolásjel
- felsorolt lista
- számozott lista
- szimbólum felsorolásjel
- képes felsorolásjel
- egyedi felsorolásjel
- többszintű lista
- felsorolásjel létrehozása
- felsorolásjel hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és formázhat felsorolt, képes, többszintű és számozott listákat PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy felsorolásjelekkel és számozott listákkal készítsen és formázzon PowerPoint és OpenDocument bemutatókat. Egy listaelem egy bekezdés, amelynek a felsorolásjeles beállításait a bekezdés formátuma szabályozza.

Használja a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztályt a bekezdés-szintű lista beállítások eléréséhez. A fő belépési pont a `Paragraph.getParagraphFormat().getBullet()`, amely egy [BulletFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a felsorolás típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- hozhat létre egy egyedi szimbólummal ellátott felsorolást
- hozhat létre egy képes felsorolást
- hozhat létre több szintű listát a bekezdés mélységének beállításával
- hozhat létre számozott listát
- ellenőrizheti és módosíthatja a lista formázását egy meglévő bemutatóban

## **Felsorolás létrehozása**

Felsorolás létrehozásához adjon [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) objektumokat egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑hez, és állítsa be a `BulletFormat.setType` értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bullettype/)‑ra. Ezután a `BulletFormat.setChar`, `BulletFormat.getColor` és `BulletFormat.setHeight` segítségével szabályozhatja a felsorolás megjelenését.

Az alábbi JavaScript kód bemutatja, hogyan hozhat létre felsorolást egy dián:

```javascript
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

![The symbol bullets](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa be a `BulletFormat.setType` értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bullettype/)‑ra. A `BulletFormat.setNumberedBulletStyle`‑val kiválaszthat egy számozási formátumot, vagy a `BulletFormat.setNumberedBulletStartWith`‑el megadhatja a kezdő értéket, ha a lista nem 1‑tel kezdődik.

Az alábbi JavaScript kód megmutatja, hogyan hozhat létre számozott listát egy dián:

```javascript
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

![The numbered bullets](numbered_bullets.png)

## **Képes felsorolás létrehozása**

Az Aspose.Slides lehetővé teszi, hogy egy szabványos felsorolásjel helyett képet használjon. A képes felsorolások leginkább egyszerű, kis méretben is olvasható képekkel működnek, például ikonokkal vagy kis átlátszó PNG fájlokkal.

{{% alert color="primary" %}}

Ideális esetben, ha a szabványos felsorolásjelet képre szeretné cserélni, válasszon egyszerű grafikát átlátszó háttérrel. Az ilyen képek jól használhatók egyedi felsorolásjeleként.

Ne feledje, hogy a kép nagyon kicsire lesz méretezve. Ezért erősen ajánljuk, hogy olyan képet válasszon, amely kicsi méretben is tiszta és vizuálisan hatékony.

{{% /alert %}}

Képes felsorolás létrehozásához adjon egy képet a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/)‑hez a `Presentation.getImages().addImage` metódussal, majd a visszakapott [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumot rendelje a `BulletFormat.getPicture().setImage`‑hez. A kép hozzárendelése előtt állítsa be a `BulletFormat.setType` értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bullettype/)‑ra.

Tegyük fel, hogy van egy „image.png” nevű képfájlunk:

![A picture for the bullets](picture_for_bullets.png)

Az alábbi JavaScript kód bemutatja, hogyan hozhat létre képes felsorolást egy dián:

```javascript
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

![The picture bullets](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a `ParagraphFormat.setDepth`‑t a listaelemek különböző szinteken való elhelyezéséhez. A 0‑szint a legfelső szint, az 1‑szint alatta, stb.

Az alábbi JavaScript kód megmutatja, hogyan hozhat létre többszintű felsorolt listát:

```javascript
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

![The multilevel list](multilevel_list.png)

## **Meglévő lista módosítása**

Meglévő bemutató listaformázásának módosításához érje el a cél bekezdést, és frissítse a `ParagraphFormat.getBullet` beállításait. A listák létrehozásához használt ugyanazon tulajdonságokkal ellenőrizheti vagy módosíthatja a PPT, PPTX vagy ODP fájlból betöltött listákat.

Az alábbi JavaScript kód a szövegkeret első bekezdését számozott lista stílusra állítja:

```javascript
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

## **GYIK**

**Exportálhatóak a felsorolásjelek és számozott listák PDF‑be vagy képekbe?**

Igen. Az Aspose.Slides megőrzi a listaformázást, ha a célformátum támogatja a megfelelő szövegelrendezést és felsorolásjeles funkciókat.

**Szerkeszthetem a listákat meglévő bemutatókban?**

Igen. Töltse be a bemutatót, érje el a cél bekezdést, ellenőrizze vagy frissítse a `ParagraphFormat.getBullet` beállításait, majd mentse a bemutatót.

**Tartalmazhat a lista nem latin betűket?**

Igen. A listaelemek szövege Unicode karaktereket is tartalmazhat, így többnyelvű bemutatókban is létrehozhat listákat. Győződjön meg róla, hogy a bemutatóban használt betűtípusok támogatják a szükséges karaktereket.