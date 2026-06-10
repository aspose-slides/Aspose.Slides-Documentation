---
title: PowerPoint szöveg bekezdések kezelése JavaScriptben
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/nodejs-java/manage-paragraph/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- lista pont kezelése
- bekezdés behúzása
- függőleges behúzás
- bekezdés felsorolásjel
- számozott lista
- pontozott lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Mesteri bekezdésformázás az Aspose.Slides for Node.js segítségével Java‑on keresztül — optimalizálja a kiigazítást, sortávolságot és stílust PPT, PPTX és ODP prezentációkban JavaScriptben."
---
## **Bevezetés**

Az Aspose.Slides minden szükséges osztályt biztosít a PowerPoint szövegekkel, bekezdésekkel és részekkel való munkához Java-ban.

* Az Aspose.Slides biztosítja a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) osztályt, amely lehetővé teszi, hogy bekezdést reprezentáló objektumokat adjunk hozzá. Egy `TextFame` objektum egy vagy több bekezdést tartalmazhat (minden bekezdés egy sortöréssel jön létre).
* Az Aspose.Slides biztosítja a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztályt, amely lehetővé teszi, hogy részeket reprezentáló objektumokat adjunk hozzá. Egy `Paragraph` objektum egy vagy több részt (szöverrész‑objektumok gyűjteményét) tartalmazhat.
* Az Aspose.Slides biztosítja a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) osztályt, amely lehetővé teszi, hogy szövegeket és azok formázási tulajdonságait reprezentáló objektumokat adjunk hozzá.

Egy `Paragraph` objektum a benne lévő `Portion` objektumok segítségével képes különböző formázási tulajdonságú szövegeket kezelni.

## **Több bekezdés hozzáadása, amelyek több részt tartalmaznak**

Az alábbi lépések megmutatják, hogyan adhatunk hozzá egy szövegdobozt, amely 3 bekezdést, és minden bekezdés 3 részt tartalmaz:

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzük meg a megfelelő dia referencia­ját indexe alapján.
3. Adjunk egy téglalap‑[AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diára.
4. Szerezzük meg az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑hez tartozó ITextFrame‑et.
5. Hozzunk létre két [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) objektumot, és adjuk őket a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) `IParagraphs` gyűjteményéhez.
6. Hozzunk létre három [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) objektumot az egyes új `Paragraph`‑okhoz (alapértelmezett bekezdésnél két Portion objektum), és adjuk őket az egyes `Paragraph`‑ok IPortion gyűjteményéhez.
7. Állítsunk be szöveget minden részhez.
8. Alkalmazzuk a kívánt formázási beállításokat minden részre a `Portion` objektum által nyújtott tulajdonságok segítségével.
9. Mentsük el a módosított prezentációt.

Ez a Javascript‑kód az előző lépések megvalósítása bekezdések és részek hozzáadásához:

```javascript
// Példányosíts egy Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // Adjunk hozzá egy téglalap típusú AutoShape-et
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Az AutoShape TextFrame-jének elérése
    var tf = ashp.getTextFrame();
    // Hozz létre bekezdéseket és részeket különböző szövegformátumokkal
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Írd a PPTX-et a lemezre
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bekezdés‑pontok kezelése**

A pontlista segít gyorsan és hatékonyan rendszerezni, bemutatni az információt. A pontozott bekezdések könnyebben olvashatóak és érthetőek.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzük meg a megfelelő dia referencia­ját indexe alapján.
3. Adjunk egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a kiválasztott diára.
4. Szerezzük meg az autoshape‑hez tartozó [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑t.
5. Távolítsuk el az alapértelmezett bekezdést a `TextFrame`‑ből.
6. Hozzuk létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztállyal.
7. Állítsuk be a bekezdés bullet `Type`‑ját `Symbol`‑ra, és adjuk meg a bullet karaktert.
8. Állítsuk be a bekezdés `Text`‑ét.
9. Állítsuk be a bekezdés `Indent`‑jét a bullethez.
10. Állítsunk be egy színt a bullethez.
11. Állítsunk be egy magasságot a bullethez.
12. Adjunk hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
13. Adjunk hozzá egy második bekezdést, és ismételjük meg a 7‑13. lépésekben leírtakat.
14. Mentsük el a prezentációt.

Ez a Javascript‑kód megmutatja, hogyan adhatunk hozzá egy bekezdés‑bullet‑t:

```javascript
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // AutoShape hozzáadása és elérése
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Az autoshape szövegdobozának elérése
    var txtFrm = aShp.getTextFrame();
    // Az alapértelmezett bekezdés eltávolítása
    txtFrm.getParagraphs().removeAt(0);
    // Bekezdés létrehozása
    var para = new aspose.slides.Paragraph();
    // Bekezdés bullet stílusának és szimbólumának beállítása
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Bekezdés szövegének beállítása
    para.setText("Welcome to Aspose.Slides");
    // Bullet behúzásának beállítása
    para.getParagraphFormat().setIndent(25);
    // Bullet színének beállítása
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// Állítsa az IsBulletHardColor értékét true-ra, hogy saját bullet színt használjon
    // Bullet magasságának beállítása
    para.getParagraphFormat().getBullet().setHeight(100);
    // Bekezdés hozzáadása a szövegdobozhoz
    txtFrm.getParagraphs().add(para);
    // Második bekezdés létrehozása
    var para2 = new aspose.slides.Paragraph();
    // Bekezdés bullet típusának és stílusának beállítása
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Bekezdés szövegének hozzáadása
    para2.setText("This is numbered bullet");
    // Bullet behúzásának beállítása
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// Állítsa az IsBulletHardColor értékét true-ra, hogy saját bullet színt használjon
    // Bullet magasságának beállítása
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Bekezdés hozzáadása a szövegdobozhoz
    txtFrm.getParagraphs().add(para2);
    // A módosított prezentáció mentése
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Képes bullet‑ok kezelése**

A bullet‑lista segít gyorsan és hatékonyan rendszerezni, bemutatni az információt. A képes bekezdések könnyen olvashatóak és érthetőek.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzük meg a megfelelő dia referencia­ját indexe alapján.
3. Adjunk egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diára.
4. Szerezzük meg az autoshape‑hez tartozó [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑t.
5. Távolítsuk el az alapértelmezett bekezdést a `TextFrame`‑ből.
6. Hozzuk létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztállyal.
7. Töltsük be a képet a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/)‑ben.
8. Állítsuk be a bullet típusát [Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/)-ra, és adjuk meg a képet.
9. Állítsuk be a Paragraph `Text`‑ét.
10. Állítsuk be a Paragraph `Indent`‑jét a bullethez.
11. Állítsunk be egy színt a bullethez.
12. Állítsunk be egy magasságot a bullethez.
13. Adjunk hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
14. Adjunk hozzá egy második bekezdést, és ismételjük meg a korábbi lépéseket.
15. Mentsük el a módosított prezentációt.

Ez a Javascript‑kód megmutatja, hogyan adhatunk hozzá és kezelhetünk képes bullet‑okat:

```javascript
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
var presentation = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = presentation.getSlides().get_Item(0);
    // Példányosítja a bullet képet
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // AutoShape hozzáadása és elérése
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Az autoshape szövegdobozának elérése
    var textFrame = autoShape.getTextFrame();
    // Az alapértelmezett bekezdés eltávolítása
    textFrame.getParagraphs().removeAt(0);
    // Új bekezdés létrehozása
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Bekezdés bullet stílusának és képének beállítása
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Bullet magasságának beállítása
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Bekezdés hozzáadása a szövegdobozhoz
    textFrame.getParagraphs().add(paragraph);
    // A prezentáció mentése PPTX fájlként
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // A prezentáció mentése PPT fájlként
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Többszintű bullet‑ok kezelése**

A bullet‑lista segít gyorsan és hatékonyan rendszerezni, bemutatni az információt. A többszintű bullet‑ok könnyen olvashatóak és érthetőek.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzük meg a megfelelő dia referencia­ját indexe alapján.
3. Adjunk egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet az új dián.
4. Szerezzük meg az autoshape‑hez tartozó [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑t.
5. Távolítsuk el az alapértelmezett bekezdést a `TextFrame`‑ből.
6. Hozzuk létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztállyal, és állítsuk a mélységet 0‑ra.
7. Hozzuk létre a második bekezdést a `Paragraph` osztállyal, és állítsuk a mélységet 1‑re.
8. Hozzuk létre a harmadik bekezdést a `Paragraph` osztállyal, és állítsuk a mélységet 2‑re.
9. Hozzuk létre a negyedik bekezdést a `Paragraph` osztállyal, és állítsuk a mélységet 3‑ra.
10. Adjunk hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
11. Mentsük el a módosított prezentációt.

Ez a Javascript‑kód megmutatja, hogyan adhatunk hozzá és kezelhetünk többszintű bullet‑okat:

```javascript
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // AutoShape hozzáadása és elérése
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // A létrehozott autoshape szövegdobozának elérése
    var text = aShp.addTextFrame("");
    // Az alapértelmezett bekezdés törlése
    text.getParagraphs().clear();
    // Az első bekezdés hozzáadása
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // A bullet szint beállítása
    para1.getParagraphFormat().setDepth(0);
    // A második bekezdés hozzáadása
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // A bullet szint beállítása
    para2.getParagraphFormat().setDepth(1);
    // A harmadik bekezdés hozzáadása
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // A bullet szint beállítása
    para3.getParagraphFormat().setDepth(2);
    // A negyedik bekezdés hozzáadása
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // A bullet szint beállítása
    para4.getParagraphFormat().setDepth(3);
    // Bekezdések hozzáadása a gyűjteményhez
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // A prezentáció mentése PPTX fájlként
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Egyedi számozott lista kezelése bekezdésben**

A [BulletFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/) osztály a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) tulajdonságot és másokat biztosít, amelyekkel egyedi számozású vagy formázott bekezdéseket kezelhetünk.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzük meg a bekezdést tartalmazó diát.
3. Adjunk egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diára.
4. Szerezzük meg az autoshape‑hez tartozó [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑t.
5. Távolítsuk el az alapértelmezett bekezdést a `TextFrame`‑ből.
6. Hozzuk létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztállyal, és állítsuk a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) értékét 2‑re.
7. Hozzuk létre a második bekezdést a `Paragraph` osztállyal, és állítsuk a `NumberedBulletStartWith` értékét 3‑ra.
8. Hozzuk létre a harmadik bekezdést a `Paragraph` osztállyal, és állítsuk a `NumberedBulletStartWith` értékét 7‑re.
9. Adjunk hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
10. Mentsük el a módosított prezentációt.

Ez a Javascript‑kód megmutatja, hogyan adhatunk hozzá és kezelhetünk egyedi számozású vagy formázott bekezdéseket:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // A létrehozott autoshape szövegdobozának elérése
    var textFrame = shape.getTextFrame();
    // Az alapértelmezett létező bekezdés eltávolítása
    textFrame.getParagraphs().removeAt(0);
    // Első lista
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Első sor behúzásának beállítása bekezdéshez**

Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés szövegtörzséhez igazodik.

Használja a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)‑t, ha az egész bekezdést szeretné eltolni. A [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/)‑t pedig csak az első sor eltolásához.

Az alábbi példa több bekezdést hoz létre, és különböző behúzási értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja a bekezdés elrendezését az első sor behúzása.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzük meg a cél diát.
3. Adjunk egy téglalap‑[AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diára.
4. Adjunk egy üres [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) elemet a formához, és távolítsuk el az alapértelmezett bekezdést.
5. Hozzunk létre több bekezdést, és állítsuk be számukra különböző [Indent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) értékeket.
6. Adjunk hozzá a bekezdéseket a szövegdobozhoz.
7. Mentsük el a módosított prezentációt.

Ez a kód megmutatja, hogyan állítható be a bekezdés behúzása:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdések első sorának behúzása](first_line_indent.png)

## **Függőleges behúzás beállítása bekezdéshez**

A függőleges behúzás olyan bekezdéselrendezés, ahol az első sor balra kezdődik a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) metódussal érhetjük el. Negatív érték megadásával az első sort balra mozdítjuk a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) határozza meg a bekezdés törzsének bal pozícióját, míg a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) határozza meg az első sor pozícióját ennek a marginnak a relatívjában. Függőleges behúzáshoz állítsunk be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a tördelődő soroknak a bekezdés törzséhez kell igazodniuk, nem pedig az első sor első karakteréhez.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzük meg a cél diát.
3. Adjunk egy téglalap‑[AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diára.
4. Adjunk egy üres [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) elemet a formához, és távolítsuk el az alapértelmezett bekezdést.
5. Hozzunk létre bekezdéseket, és minden bekezdéshez állítsunk be egy pozitív [MarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) értéket.
6. Állítsunk be egy negatív [Indent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) értéket a függőleges behúzás megvalósításához.
7. Adjunk hozzá a bekezdéseket a szövegdobozhoz.
8. Mentsük el a módosított prezentációt.

Ez a kód megmutatja, hogyan állítható be a függőleges behúzás bekezdéshez:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdések függőleges behúzása](hanging_indent.png)

## **Bekezdés befejező futtatási tulajdonságainak kezelése**

1. Hozzunk létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt.
1. Szerezzük meg a bekezdést tartalmazó dia referencia­ját a pozíciója alapján.
1. Adjunk egy téglalap‑[AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diára.
1. Adjunk egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) elemet két bekezdéssel a téglalaphoz.
1. Állítsuk be a `FontHeight` és a betűtípus típusát a bekezdésekhez.
1. Állítsuk be a bekezdések End tulajdonságait.
1. Írjuk ki a módosított prezentációt PPTX fájlként.

Ez a Javascript‑kód megmutatja, hogyan állítható be az End tulajdonság bekezdésekhez PowerPoint‑ban:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **HTML‑szöveg importálása bekezdésekbe**

Az Aspose.Slides kiterjesztett támogatást nyújt HTML‑szöveg bekezdésekbe történő importálásához.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzük meg a megfelelő dia referencia­ját indexe alapján.
3. Adjunk egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diára.
4. Adjunk hozzá és szerezzük meg az `AutoShape` [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑t.
5. Távolítsuk el az alapértelmezett bekezdést a `TextFrame`‑ből.
6. Olvassuk be a forrás HTML‑fájlt egy TextReader‑ben.
7. Hozzuk létre az első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztállyal.
8. Adjunk hozzá a TextFrame [ParagraphCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/)-hez a beolvasott TextReader HTML‑tartalmát.
9. Mentsük el a módosított prezentációt.

Ez a Javascript‑kód a HTML‑szövegek bekezdésekbe importálásának lépéseit valósítja meg:

```javascript
// Üres prezentáció példány létrehozása
var pres = new aspose.slides.Presentation();
try {
    // A prezentáció alapértelmezett első diájának elérése
    var slide = pres.getSlides().get_Item(0);
    // AutoShape hozzáadása a HTML tartalom elhelyezéséhez
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Szövegdoboz hozzáadása a formához
    ashape.addTextFrame("");
    // Az addott szövegdoboz összes bekezdésének törlése
    ashape.getTextFrame().getParagraphs().clear();
    // HTML fájl betöltése stream olvasóval
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Szöveg hozzáadása a HTML stream olvasóból a szövegdobozba
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Prezentáció mentése
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bekezdések exportálása HTML‑be**

Az Aspose.Slides kiterjesztett támogatást nyújt a bekezdésekben szereplő szövegek HTML‑be exportálásához.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból, és töltsük be a kívánt prezentációt.
2. Szerezzük meg a megfelelő dia referencia­ját indexe alapján.
3. Szerezzük meg azt a formát, amelyik a HTML‑be exportálandó szöveget tartalmazza.
4. Szerezzük meg a forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑t.
5. Hozzunk létre egy `StreamWriter` példányt, és adjuk hozzá az új HTML‑fájlt.
6. Adjunk meg egy kezdő indexet a StreamWriter‑nek, majd exportáljuk a kívánt bekezdéseket.

Ez a Javascript‑kód megmutatja, hogyan exportálhatók PowerPoint‑bekezdés‑szövegek HTML‑be:

```javascript
// Töltsd be a prezentáció fájlt
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // A prezentáció alapértelmezett első diájának elérése
    var slide = pres.getSlides().get_Item(0);
    // Kívánt index
    var index = 0;
    // A hozzáadott forma elérése
    var ashape = slide.getShapes().get_Item(index);
    // Kimeneti HTML fájl létrehozása
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Az első bekezdés kinyerése HTML-ként
    // Bekezdések adatainak írása HTML-be a bekezdés kezdő indexének és a másolandó bekezdések számának megadásával
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bekezdés mentése képként**

Ebben a részben két példát mutatunk be, amelyek bemutatják, hogyan menthetünk el egy szöveg‑bekezdést, amelyet a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztály képvisel, képként. Mindkét példa tartalmazza a bekezdést tartalmazó forma képének megszerzését a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) osztály `getImage` metódusaival, a bekezdés határainak kiszámítását a formában, és a bitmap‑képbe való exportálást. Ezek a megközelítések lehetővé teszik, hogy a PowerPoint‑prezentációkból egyes szövegrészeket külön képként mentsünk, ami különböző felhasználási esetekben hasznos lehet.

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egy diával, ahol az első forma egy szövegdoboz, amely három bekezdést tartalmaz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

**1. példa**

Ebben a példában a második bekezdést képként szerzük meg. Ehhez először kinyerjük a forma képét az első diához, majd kiszámítjuk a második bekezdés határait a forma szövegdobozában. A bekezdést ezután egy új bitmap‑képre rajzoljuk, amelyet PNG formátumban mentünk. Ez a módszer különösen hasznos, ha egy adott bekezdést szeretnénk külön képként menteni, miközben megőrzünk minden méretet és formázást.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A forma mentése a memóriába bitmapként.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Bitmap létrehozása a memóriából.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // A második bekezdés határainak kiszámítása.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // A kimeneti kép koordinátáinak és méretének kiszámítása (minimum méret - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // A forma bitmap vágása, hogy csak a bekezdés bitmap legyen.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

**2. példa**

Ebben a példában a korábbi megközelítést kiterjesztjük skálázási tényezőkkel a bekezdésképre. A forma a prezentációból kerül kinyerésre, és `2`‑es skálázási tényezővel mentődik képként, ami nagy felbontású kimenetet biztosít. A bekezdés határait ezután a skálázás figyelembevételével számítjuk ki. A skálázás különösen hasznos, ha részletesebb képre van szükség, például magas minőségű nyomtatott anyagokhoz.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A forma mentése a memóriába bitmapként skálázással.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Bitmap létrehozása a memóriából.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // A második bekezdés határainak kiszámítása.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // A kimeneti kép koordinátáinak és méretének kiszámítása (minimum méret - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // A forma bitmap vágása, hogy csak a bekezdés bitmap legyen.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **GYIK**

**Teljesen letiltható a sortörés egy szövegdobozban?**

Igen. Használja a szövegdoboz wrap beállítását ([setWrapText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/setwraptext/)) a sortörés kikapcsolásához, így a sorok nem törnek a doboz szélén.

**Hogyan kapható meg egy adott bekezdés pontos helyzete a dián?**

Lekérdezhető a bekezdés (illetve akár egyetlen rész) határoló téglalapja, amely megmutatja a pontos pozíciót és méretet a dián.

**Hol állítható be a bekezdés igazítása (bal/jobb/közép/széthúzott)?**

A [setAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setalignment/) a [ParagraphFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/) bekezdés‑szintű metódusa; a bekezdés egészére vonatkozik, függetlenül az egyes részek formázásától.

**Beállítható-e helyesírás-ellenőrzési nyelv csak a bekezdés egy részére (pl. egy szóra)?**

Igen. A nyelv a rész (Portion) szintjén állítható be ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), így egy bekezdésen belül több nyelv is megjelenhet.