---
title: PowerPoint szöveges bekezdések kezelése JavaScript-ben
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
- listaelem kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés listaelem
- számozott lista
- pontozott lista
- bekezdés tulajdonságai
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
description: "Mestere a bekezdésformázásnak az Aspose.Slides for Node.js Java-n keresztül—optimalizálja az igazítást, távolságot és stílust PPT, PPTX és ODP prezentációkban JavaScript-ben."
---
## **Bevezetés**

Az Aspose.Slides minden szükséges osztályt biztosít a PowerPoint szövegek, bekezdések és részek kezeléséhez Java-ban.

* Az Aspose.Slides a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) osztályt biztosítja, amely lehetővé teszi olyan objektumok hozzáadását, amelyek egy bekezdést képviselnek. Egy `TextFame` objektum egy vagy több bekezdést tartalmazhat (minden bekezdés egy sortöréssel kerül létrehozásra).
* Az Aspose.Slides a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztályt biztosítja, amely lehetővé teszi olyan objektumok hozzáadását, amelyek részeket képviselnek. Egy `Paragraph` objektum egy vagy több részt (szöverrész-objektumok gyűjteményét) tartalmazhat.
* Az Aspose.Slides a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) osztályt biztosítja, amely lehetővé teszi olyan objektumok hozzáadását, amelyek szövegeket és azok formázási tulajdonságait képviselik.

Egy `Paragraph` objektum képes különböző formázási tulajdonságokkal rendelkező szövegeket kezelni az alatta lévő `Portion` objektumok segítségével.

## **Több bekezdés hozzáadása, amely több részt tartalmaz**

Az alábbi lépések megmutatják, hogyan adjon hozzá egy szövegkeretet, amely 3 bekezdést tartalmaz, és minden bekezdés 3 részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Hozzon hozzáférést a megfelelő dia referencia‑jához az indexe alapján.
3. Adjon egy téglalap‑[AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diára.
4. Szerezze meg az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑hez tartozó ITextFrame‑et.
5. Hozzon létre két [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) objektumot, és adja hozzá őket a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) `IParagraphs` gyűjteményéhez.
6. Hozzon létre három [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) objektumot minden új `Paragraph`‑hez (alapértelmezett bekezdéshez két Portion objektum), és adja hozzá minden `Portion` objektumot az adott `Paragraph` IPortion gyűjteményéhez.
7. Állítson be szöveget minden részhez.
8. Alkalmazza a kívánt formázási jellemzőket minden részre a `Portion` objektum által kínált formázási tulajdonságokkal.
9. Mentse a módosított prezentációt.

```javascript
// PPTX fájlt reprezentáló Presentation osztály példányosítása
var pres = new aspose.slides.Presentation();
try {
    // Első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // Téglalap típusú AutoShape hozzáadása
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Az AutoShape TextFrame-jének elérése
    var tf = ashp.getTextFrame();
    // Bekezdések és részek létrehozása különböző szövegformátumokkal
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
    // PPTX írása lemezre
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bekezdés‑pontszámok kezelése**

A pontozott listák segítenek gyorsan és hatékonyan szervezni és bemutatni az információkat. A pontozott bekezdések mindig könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Hozzon hozzáférést a megfelelő dia referencia‑jához az indexe alapján.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a kiválasztott diára.
4. Szerezze meg az autoshape‑[TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑ét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Hozzon létre egy első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztállyal.
7. Állítsa be a bekezdés bullet `Type`‑ját `Symbol`‑ra, és adja meg a bullet karaktert.
8. Állítsa be a bekezdés `Text`‑ét.
9. Állítsa be a bekezdés `Indent`‑et a bullethez.
10. Állítson be színt a bullethez.
11. Állítson be magasságot a bullethez.
12. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
13. Adja hozzá a második bekezdést, és ismételje meg a 7‑13. lépésekben leírtakat.
14. Mentse a prezentációt.

```javascript
// PPTX fájlt reprezentáló Presentation osztály példányosítása
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // AutoShape hozzáadása és elérése
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Az autoshape szövegkeretének elérése
    var txtFrm = aShp.getTextFrame();
    // Az alapértelmezett bekezdés eltávolítása
    txtFrm.getParagraphs().removeAt(0);
    // Bekezdés létrehozása
    var para = new aspose.slides.Paragraph();
    // Bekezdés listaelem stílusának és szimbólumának beállítása
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Bekezdés szövegének beállítása
    para.setText("Welcome to Aspose.Slides");
    // Listaelem behúzásának beállítása
    para.getParagraphFormat().setIndent(25);
    // Listaelem színének beállítása
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// állítsa a IsBulletHardColor értékét true-ra az egyéni listaelem szín használatához
    // Listaelem magasságának beállítása
    para.getParagraphFormat().getBullet().setHeight(100);
    // Bekezdés hozzáadása a szövegkerethez
    txtFrm.getParagraphs().add(para);
    // Második bekezdés létrehozása
    var para2 = new aspose.slides.Paragraph();
    // Bekezdés listaelem típusának és stílusának beállítása
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Bekezdés szövegének hozzáadása
    para2.setText("This is numbered bullet");
    // Listaelem behúzásának beállítása
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// állítsa a IsBulletHardColor értékét true-ra az egyéni listaelem szín használatához
    // Listaelem magasságának beállítása
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Bekezdés hozzáadása a szövegkerethez
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

A pontozott listák segítenek gyorsan és hatékonyan szervezni és bemutatni az információkat. A képes bekezdések könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Hozzon hozzáférést a megfelelő dia referencia‑jához az indexe alapján.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diára.
4. Szerezze meg az autoshape‑[TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑ét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Hozzon létre egy első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztállyal.
7. Töltse be a képet a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/)‑ben.
8. Állítsa be a bullet típusát a [Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/)‑re, és adja meg a képet.
9. Állítsa be a bekezdés `Text`‑ét.
10. Állítsa be a bekezdés `Indent`‑et a bullethez.
11. Állítson be színt a bullethez.
12. Állítson be magasságot a bullethez.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
14. Adja hozzá a második bekezdést, és ismételje meg a korábbi lépéseket.
15. Mentse a módosított prezentációt.

```javascript
// PPTX fájlt reprezentáló Presentation osztály példányosítása
var presentation = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = presentation.getSlides().get_Item(0);
    // Létrehozza a listaelemekhez használandó képet
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
    // Az autoshape szövegkeretének elérése
    var textFrame = autoShape.getTextFrame();
    // Az alapértelmezett bekezdés eltávolítása
    textFrame.getParagraphs().removeAt(0);
    // Új bekezdés létrehozása
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Bekezdés listaelem stílusának és képének beállítása
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Listaelem magasságának beállítása
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Bekezdés hozzáadása a szövegkerethez
    textFrame.getParagraphs().add(paragraph);
    // Prezentáció mentése PPTX fájlként
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Prezentáció mentése PPT fájlként
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Többszintű bullet‑ok kezelése**

A pontozott listák segítenek gyorsan és hatékonyan szervezni és bemutatni az információkat. A többszintű bullet‑ok könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Hozzon hozzáférést a megfelelő dia referencia‑jához az indexe alapján.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot az új diára.
4. Szerezze meg az autoshape‑[TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑ét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Hozzon létre egy első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztály segítségével, és állítsa a mélységet 0‑ra.
7. Hozzon létre egy második bekezdés példányt a `Paragraph` osztály segítségével, és állítsa a mélységet 1‑re.
8. Hozzon létre egy harmadik bekezdés példányt a `Paragraph` osztály segítségével, és állítsa a mélységet 2‑re.
9. Hozzon létre egy negyedik bekezdés példányt a `Paragraph` osztály segítségével, és állítsa a mélységet 3‑ra.
10. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
11. Mentse a módosított prezentációt.

```javascript
// PPTX fájlt reprezentáló Presentation osztály példányosítása
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // AutoShape hozzáadása és elérése
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // A létrehozott autoshape szövegkeretének elérése
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
    // Listaelem szintjének beállítása
    para1.getParagraphFormat().setDepth(0);
    // A második bekezdés hozzáadása
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Listaelem szintjének beállítása
    para2.getParagraphFormat().setDepth(1);
    // A harmadik bekezdés hozzáadása
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Listaelem szintjének beállítása
    para3.getParagraphFormat().setDepth(2);
    // A negyedik bekezdés hozzáadása
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Listaelem szintjének beállítása
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

## **Bekezdések kezelése egyedi számozott listával**

A [BulletFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/) osztály biztosítja a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) tulajdonságot és egyéb lehetőségeket, amelyekkel egyedi számozású vagy formázott bekezdéseket kezelhet.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Hozzon hozzáférést a bekezdést tartalmazó diához.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diára.
4. Szerezze meg az autoshape‑[TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑ét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Hozzon létre egy első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztály segítségével, és állítsa a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) értékét 2‑re.
7. Hozzon létre egy második bekezdés példányt a `Paragraph` osztály segítségével, és állítsa a `NumberedBulletStartWith` értékét 3‑ra.
8. Hozzon létre egy harmadik bekezdés példányt a `Paragraph` osztály segítségével, és állítsa a `NumberedBulletStartWith` értékét 7‑re.
9. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
10. Mentse a módosított prezentációt.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // A létrehozott autoshape szövegkeretének elérése
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

## **Első sor behúzás beállítása egy bekezdéshez**

Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozdítja el a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)‑t, ha a teljes bekezdést szeretné elmozdítani. Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/)‑t, ha csak az első sort szeretné elmozdítani.

Az alábbi példa több bekezdést hoz létre, és különböző behúzási értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Hozzon hozzáférést a cél diához.
3. Adjon egy téglalap‑[AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumot a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

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

## **Függő behúzás beállítása egy bekezdéshez**

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) metódussal hozhatja létre. Állítson be negatív értéket a behúzáshoz, hogy az első sort balra mozgassa a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) határozza meg a bekezdés törzsének bal pozícióját, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) pedig az első sor helyzetét ehhez a margóhoz képest. Függő behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szószedeti bejegyzésekhez és más bekezdésekhez, ahol a sortörésű sorok a bekezdés törzse alá kell, hogy illeszkedjenek, nem pedig az első sor első karaktere alá.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Hozzon hozzáférést a cél diához.
3. Adjon egy téglalap‑[AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumot a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be minden bekezdéshez pozitív [MarginLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) értéket.
6. Állítson be negatív [Indent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setindent/) értéket a függő behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

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

![A bekezdések függő behúzása](hanging_indent.png)

## **Befejező tulajdonságok kezelése bekezdéshez**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt.
1. Szerezze meg a bekezdést tartalmazó dia referencia‑ját a pozíciója alapján.
1. Adjon egy téglalap‑[AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diára.
1. Adjon egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumot két bekezdéssel a téglalaphoz.
1. Állítsa be a `FontHeight`‑et és a betűtípust a bekezdésekhez.
1. Állítsa be a befejező (End) tulajdonságokat a bekezdésekhez.
1. Írja ki a módosított prezentációt PPTX formátumban.

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

Az Aspose.Slides kiterjesztett támogatást nyújt HTML‑szöveg bekezdésekbe való importálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt.
2. Hozzon hozzáférést a megfelelő dia referencia‑jához az indexe alapján.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diára.
4. Adjon hozzá és érje el az `AutoShape`‑[TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑ét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Olvassa be a forrás HTML‑fájlt egy TextReader‑rel.
7. Hozzon létre egy első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztály segítségével.
8. Adja hozzá a HTML‑fájl tartalmát a beolvasott TextReader‑ből a TextFrame‑[ParagraphCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphcollection/)-hez.
9. Mentse a módosított prezentációt.

```javascript
// Üres prezentáció példány létrehozása
var pres = new aspose.slides.Presentation();
try {
    // A prezentáció alapértelmezett első diájának elérése
    var slide = pres.getSlides().get_Item(0);
    // AutoShape hozzáadása a HTML tartalom befogadásához
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Szövegkeret hozzáadása a formához
    ashape.addTextFrame("");
    // Az hozzáadott szövegkeret összes bekezdésének törlése
    ashape.getTextFrame().getParagraphs().clear();
    // HTML fájl betöltése stream olvasóval
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Szöveg hozzáadása a HTML stream olvasóból a szövegkeretbe
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

Az Aspose.Slides kiterjesztett támogatást nyújt a bekezdésekben található szövegek HTML‑be exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt, és töltse be a kívánt prezentációt.
2. Hozzon hozzáférést a megfelelő dia referencia‑jához az indexe alapján.
3. Szerezze meg a szöveget tartalmazó formát, amelyet HTML‑be exportálni kíván.
4. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑ét.
5. Hozzon létre egy `StreamWriter` példányt, és adja meg az új HTML‑fájlt.
6. Adjon meg egy kezdő indexet a StreamWriter‑nek, és exportálja a kívánt bekezdéseket.

```javascript
// Tölti be a prezentációfájlt
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

Ebben a részben két példát vizsgálunk meg, amelyek bemutatják, hogyan menthetünk egy szöveg‑bekezdéset, amelyet a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) osztály képvisel, képként. Mindkét példában a bekezdést tartalmazó forma képét a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) osztály `getImage` metódusaival nyerjük ki, kiszámítjuk a bekezdés határait a forma belsejében, majd bitmap képként exportáljuk. Ezek a megközelítések lehetővé teszik a PowerPoint‑presentációk szövegrészeinek kinyerését és különálló képként történő mentését, ami hasznos lehet különböző további felhasználási esetekben.

Tegyük fel, hogy van egy `sample.pptx` nevű prezentációs fájlunk egy diával, ahol az első forma egy szövegdoboz, amely három bekezdést tartalmaz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

**Példa 1**

Ebben a példában a második bekezdést képként nyerjük ki. Ehhez a prezentáció első diájáról kinyerjük a forma képét, majd kiszámítjuk a második bekezdés határait a forma szövegkeretében. A bekezdést ezután új bitmap‑képre rajzoljuk, amelyet PNG formátumban mentünk. Ez a módszer különösen hasznos, ha egy adott bekezdést külön képként szeretne menteni, miközben megőrzi a szöveg pontos méretét és formátumát.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A forma mentése memóriába bitmapként.
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

    // A forma bitmap levágása, hogy csak a bekezdés bitmap legyen.
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

**Példa 2**

Ebben a példában a korábbi megközelítést bővítjük a bekezdés képére skálázási tényezők alkalmazásával. A forma a prezentációból kerül kinyerésre, és a kép `2`‑es skálázási tényezővel kerül mentésre. Ez magasabb felbontású kimenetet biztosít a bekezdés exportálásakor. A bekezdés határait ezután a skálázást figyelembe véve számítjuk ki. A skálázás különösen hasznos, ha részletesebb képre van szükség, például nyomtatott anyagokhoz.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A forma mentése memóriába bitmapként skálázással.
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

    // A forma bitmap levágása, hogy csak a bekezdés bitmap legyen.
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

**Teljesen letilthatom a sortörést egy szövegkereten belül?**

Igen. Használja a szövegkeret sortörés beállítását ([setWrapText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/setwraptext/)), hogy kikapcsolja a sortörést, így a sorok nem törnek meg a keret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián belüli határait?**

Lekérheti a bekezdés (vagy akár egyetlen rész) határoló téglalapját, hogy pontos helyzetét és méretét ismerje a diához képest.

**Hol szabályozható a bekezdés igazítása (balra/jobbra/középre/justified)?**

A [setAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setalignment/) a [ParagraphFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/) bekezdés‑szintű beállítása; a bekezdés egészére vonatkozik, függetlenül az egyes részek formázásától.

**Beállíthatok helyesírási nyelvet csak a bekezdés egy részére (például egy szóra)?**

Igen. A nyelv a rész‑szintjén állítható be ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), így egy bekezdésen belül több nyelv is használható.