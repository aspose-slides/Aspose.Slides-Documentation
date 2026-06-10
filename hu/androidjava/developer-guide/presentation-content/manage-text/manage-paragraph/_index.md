---
title: PowerPoint szöveg bekezdések kezelése Androidon
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/androidjava/manage-paragraph/
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
- felsoroláslista
- bekezdés tulajdonságai
- HTML importálása
- szöveg HTML-be
- bekezdés HTML-be
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Android segítségével könnyedén kezelheti a bekezdések formázását – optimalizálja az igazítást, sortávolságot és stílust PPT, PPTX és ODP prezentációkban Java‑ban."
---
## **Bevezetés**

Az Aspose.Slides minden interfészt és osztályt biztosít, amelyekre a PowerPoint szövegek, bekezdések és részek Java-ban történő kezeléséhez szükség van.

* Az Aspose.Slides a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) interfészt biztosítja, amely lehetővé teszi, hogy olyan objektumokat adjunk hozzá, amelyek egy bekezdést képviselnek. Egy `ITextFame` objektum egy vagy több bekezdést (minden bekezdés egy sortöréssel jön létre) tartalmazhat.
* Az Aspose.Slides a [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) interfészt biztosítja, amely lehetővé teszi, hogy olyan objektumokat adjunk hozzá, amelyek részeket képviselnek. Egy `IParagraph` objektum egy vagy több részt (az iPortions objektumok gyűjteménye) tartalmazhat.
* Az Aspose.Slides a [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) interfészt biztosítja, amely lehetővé teszi, hogy olyan objektumokat adjunk hozzá, amelyek szövegeket és azok formázási tulajdonságait képviselik.

Az `IParagraph` objektum képes különböző formázási tulajdonságú szövegeket kezelni az alatta lévő `IPortion` objektumok segítségével.

## **Több bekezdés hozzáadása, amelyek több szövegrészt tartalmaznak**

Az alábbi lépések bemutatják, hogyan adhatunk hozzá egy szövegdobozt, amely 3 bekezdést tartalmaz, és minden bekezdés 3 részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő dia referenciájához az indexével.
3. Adjunk hozzá egy Rectangle [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumot a diára.
4. Szerezze meg a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/)‑hez tartozó ITextFrame‑et.
5. Hozzon létre két [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) objektumot, és adja hozzá őket az [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) `IParagraphs` gyűjteményéhez.
6. Hozzon létre három [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) objektumot minden új `IParagraph` számára (alapértelmezett bekezdéshez két Portion objektum), és adja hozzá az egyes `IPortion` objektumokat az adott `IParagraph` IPortion gyűjteményéhez.
7. Állítson be szöveget minden részhez.
8. Alkalmazza a kívánt formázási tulajdonságokat minden részre a `IPortion` objektum által biztosított formázási beállításokkal.
9. Mentse el a módosított prezentációt.

Ez a Java kód a bekezdések és részek hozzáadásának lépéseinek megvalósítása:

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Hozzáad egy Rectangle típusú AutoShape-et
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Az AutoShape TextFrame-jének elérése
    ITextFrame tf = ashp.getTextFrame();

    // Bekezdések és részek létrehozása különböző szövegformátumokkal
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // PPTX írása lemezre
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bekezdés felsorolási pontok kezelése**

A felsoroláslista segít az információ gyors és hatékony rendszerezésében és bemutatásában. A felsorolásos bekezdések mindig könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő dia referenciájához az indexével.
3. Adjunk hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumot a kiválasztott diához.
4. Hozzáférés az autoshape [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumához.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ből.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztállyal.
7. Állítsa be a bekezdés bullet `Type` értékét `Symbol`‑ra, és adja meg a bullet karaktert.
8. Állítsa be a bekezdés `Text` értékét.
9. Állítsa be a bekezdés `Indent` értékét a bullethez.
10. Állítson be színt a bullethez.
11. Állítson be magasságot a bulletnek.
12. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
13. Adja hozzá a második bekezdést, és ismételje a 7‑13. lépésben leírt folyamatot.
14. Mentse el a prezentációt.

Ez a Java kód bemutatja, hogyan adhatunk hozzá bekezdés bulletet:

```java
    // Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
    Presentation pres = new Presentation();
    try {
        // Az első dia elérése
        ISlide slide = pres.getSlides().get_Item(0);
        
        // Autoshape hozzáadása és elérése
        IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

        // Az autoshape szövegdobozának elérése
        ITextFrame txtFrm = aShp.getTextFrame();

        // Az alapértelmezett bekezdés eltávolítása
        txtFrm.getParagraphs().removeAt(0);

        // Bekezdés létrehozása
        Paragraph para = new Paragraph();

        // Bekezdés bullet stílusának és szimbólumának beállítása
        para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
        para.getParagraphFormat().getBullet().setChar((char)8226);

        // Bekezdés szövegének beállítása
        para.setText("Welcome to Aspose.Slides");

        // Bullet behúzás beállítása
        para.getParagraphFormat().setIndent(25);

        // Bullet szín beállítása
        para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
        para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
        para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // állítsa az IsBulletHardColor értékét true-ra saját bullet szín használatához

        // Bullet magasság beállítása
        para.getParagraphFormat().getBullet().setHeight(100);

        // Bekezdés hozzáadása a szövegdobozhoz
        txtFrm.getParagraphs().add(para);

        // Második bekezdés létrehozása
        Paragraph para2 = new Paragraph();

        // Bekezdés bullet típusának és stílusának beállítása
        para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
        para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

        // Bekezdés szövegének hozzáadása
        para2.setText("This is numbered bullet");

        // Bullet behúzás beállítása
        para2.getParagraphFormat().setIndent(25);

        para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
        para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
        para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // állítsa az IsBulletHardColor értékét true-ra saját bullet szín használatához

        // Bullet magasság beállítása
        para2.getParagraphFormat().getBullet().setHeight(100);

        // Bekezdés hozzáadása a szövegdobozhoz
        txtFrm.getParagraphs().add(para2);
        
        // A módosított prezentáció mentése
        pres.save("Bullet_out.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **Képes bulletek kezelése**

A felsoroláslisták segítenek az információ gyors és hatékony rendszerezésében és bemutatásában. A képes bekezdések könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő dia referenciájához az indexével.
3. Adjunk hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumot a diához.
4. Hozzáférés az autoshape [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumához.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ből.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztállyal.
7. Töltse be a képet a [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) segítségével.
8. Állítsa be a bullet típusát [Picture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/)‑re, és adja meg a képet.
9. Állítsa be a Paragraph `Text` értékét.
10. Állítsa be a Paragraph `Indent` értékét a bullethez.
11. Állítson be színt a bullethez.
12. Állítson be magasságot a bulletnek.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
14. Adja hozzá a második bekezdést, és ismételje meg a lépéseket az előzőek alapján.
15. Mentse el a módosított prezentációt.

Ez a Java kód bemutatja, hogyan adhatunk hozzá és kezelhetünk képes bulleteket:

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation presentation = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = presentation.getSlides().get_Item(0);

    // Létrehozza a bulletekhez használt képet
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Autoshape hozzáadása és elérése
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Az autoshape szövegdobozának elérése
    ITextFrame textFrame = autoShape.getTextFrame();

    // Az alapértelmezett bekezdés eltávolítása
    textFrame.getParagraphs().removeAt(0);

    // Új bekezdés létrehozása
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Bekezdés bullet stílusának és képének beállítása
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Bullet magasság beállítása
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Bekezdés hozzáadása a szövegdobozhoz
    textFrame.getParagraphs().add(paragraph);

    // A prezentáció mentése PPTX fájlként
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // A prezentáció mentése PPT fájlként
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Többszintű bulletek kezelése**

A felsoroláslisták segítik az információ gyors és hatékony rendszerezését és bemutatását. A többszintű bulletek könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő dia referenciájához az indexével.
3. Adjunk hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumot az új dián.
4. Hozzáférés az autoshape [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumához.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ből.
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztállyal, és állítsa a mélységet 0‑ra.
7. Hozza létre a második bekezdést a `Paragraph` osztállyal, és állítsa a mélységet 1‑re.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztállyal, és állítsa a mélységet 2‑re.
9. Hozza létre a negyedik bekezdést a `Paragraph` osztállyal, és állítsa a mélységet 3‑ra.
10. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
11. Mentse el a módosított prezentációt.

Ez a Java kód bemutatja, hogyan adhatunk hozzá és kezelhetünk többszintű bulleteket:

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshape hozzáadása és elérése
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // A létrehozott autoshape szövegdobozának elérése
    ITextFrame text = aShp.addTextFrame("");

    // Az alapértelmezett bekezdés törlése
    text.getParagraphs().clear();

    // Az első bekezdés hozzáadása
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // A bullet szint beállítása
    para1.getParagraphFormat().setDepth((short)0);

    // A második bekezdés hozzáadása
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // A bullet szint beállítása
    para2.getParagraphFormat().setDepth((short)1);

    // A harmadik bekezdés hozzáadása
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // A bullet szint beállítása
    para3.getParagraphFormat().setDepth((short)2);

    // A negyedik bekezdés hozzáadása
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // A bullet szint beállítása
    para4.getParagraphFormat().setDepth((short)3);

    // Bekezdések hozzáadása a gyűjteményhez
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // A prezentáció mentése PPTX fájlként
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Egy bekezdés kezelése egy egyéni számozott listával**

Az [IBulletFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/) interfész a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) tulajdonságot és másokat biztosít, amelyek lehetővé teszik, hogy egyéni számozással vagy formázással rendelkező bekezdéseket kezeljünk.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a bekezdést tartalmazó diához.
3. Adjunk hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumot a diához.
4. Hozzáférés az autoshape [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumához.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ből.
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztállyal, és állítsa a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét 2‑re.
7. Hozza létre a második bekezdést a `Paragraph` osztállyal, és állítsa a `NumberedBulletStartWith` értékét 3‑ra.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztállyal, és állítsa a `NumberedBulletStartWith` értékét 7‑re.
9. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
10. Mentse el a módosított prezentációt.

Ez a Java kód bemutatja, hogyan adhatunk hozzá és kezelhetünk bekezdéseket egyéni számozással vagy formázással:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Eléri a létrehozott autoshape szövegdobozát
    ITextFrame textFrame = shape.getTextFrame();

    // Eltávolítja az alapértelmezett, már meglévő bekezdést
    textFrame.getParagraphs().removeAt(0);

    // Első lista
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Első sor behúzás beállítása bekezdéshez**

Az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódus használatával szabályozhatja egy bekezdés első sorának behúzását. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódust, ha a teljes bekezdést szeretné elmozdítani. Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust, ha csak az első sort szeretné eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző behúzási értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a cél diához.
3. Adjunk hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) objektumot a diához.
4. Adjunk egy üres [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) objektumot az alakzathoz, és távolítsuk el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse el a módosított prezentációt.

Ez a kód bemutatja, hogyan állíthat be bekezdésbehúzást:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdések első sorának behúzása](first_line_indent.png)

## **Függő behúzás beállítása bekezdéshez**

A függő behúzás egy bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ben ezt a hatást az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódus segítségével hozhatja létre. Állítsa a behúzást negatív értékre, hogy az első sort a bekezdés törzséhez képest balra mozgassa.

Gyakorlatban az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) a bekezdés törzsének bal pozícióját határozza meg, míg az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) az első sor pozícióját az adott margóhoz képest. Függő behúzás létrehozásához állítsa be a `MarginLeft` értékét pozitívra, és az `Indent` értékét negatívra.

Ez a formázás hasznos bibliográfiák, hivatkozások, szójegyzék bejegyzések és más bekezdések esetén, ahol a tördelő soroknak a bekezdés törzsének alá kell illeszkedniük, nem pedig az első sor első karakteréhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a cél diához.
3. Adjunk hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) objektumot a diához.
4. Hozzáférés egy üres [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) objektumhoz az alakzathoz, és távolítsuk el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be pozitív [MarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) értéket minden bekezdéshez.
6. Állítson be negatív [Indent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értéket a függő behúzás hatás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse el a módosított prezentációt.

Ez a kód bemutatja, hogyan állíthat be függő behúzást egy bekezdéshez:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdések függő behúzása](hanging_indent.png)

## **A bekezdés végi futtatási tulajdonságok kezelése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezze be a bekezdést tartalmazó dia referenciáját a pozíciója alapján.
3. Adjunk hozzá egy téglalap [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumot a diához.
4. Adjunk egy [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumot két bekezdéssel a téglalaphoz.
5. Állítsa be a bekezdések `FontHeight` és betűtípus típusát.
6. Állítsa be a bekezdések End (vég) tulajdonságait.
7. Írja ki a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan állíthatja be a bekezdések End (vég) tulajdonságait a PowerPointban:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **HTML szöveg importálása bekezdésekbe**

Az Aspose.Slides fejlett támogatást nyújt a HTML szöveg bekezdésekbe való importálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő dia referenciájához az indexével.
3. Adjunk hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumot a diához.
4. Adjunk hozzá és érjük el az `autoshape` [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumot.
5. Távolítsa el az alapértelmezett bekezdést az `ITextFrame`‑ből.
6. Olvassa be a forrás HTML fájlt egy TextReader segítségével.
7. Hozza létre az első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztállyal.
8. Adja hozzá a beolvasott TextReaderből származó HTML fájl tartalmát a TextFrame [ParagraphCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/) gyűjteményéhez.
9. Mentse el a módosított prezentációt.

Ez a Java kód a HTML szövegek bekezdésekbe importálásának lépéseinek megvalósítása:

```java
// Üres prezentációs példány létrehozása
Presentation pres = new Presentation();
try {
    // A prezentáció alapértelmezett első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape hozzáadása a HTML tartalom elhelyezéséhez
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Szövegdoboz hozzáadása az alakzathoz
    ashape.addTextFrame("");

    // A hozzáadott szövegdoboz összes bekezdésének törlése
    ashape.getTextFrame().getParagraphs().clear();

    // HTML fájl betöltése stream olvasóval
    TextReader tr = new StreamReader("file.html");

    // Szöveg hozzáadása a HTML stream olvasóból a szövegdobozhoz
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Prezentáció mentése
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bekezdés szöveg exportálása HTML-be**

Az Aspose.Slides fejlett támogatást nyújt a szövegek (bekezdésekben lévő) HTML-be exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.
2. Hozzáférés a megfelelő dia referenciájához az indexével.
3. Hozzáférés ahhoz az alakzathoz, amely a HTML-be exportálandó szöveget tartalmazza.
4. Hozzáférés az alakzat [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) objektumához.
5. Hozzon létre egy `StreamWriter` példányt, és adja hozzá az új HTML fájlt.
6. Adjon meg egy kezdő indexet a StreamWriternek, és exportálja a kívánt bekezdéseket.

Ez a Java kód bemutatja, hogyan exportálhatja a PowerPoint bekezdés szövegeket HTML-be:

```java
// Tölti be a prezentáció fájlt
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // A prezentáció alapértelmezett első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Kívánt index
    int index = 0;

    // A hozzáadott alakzat elérése
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Kimeneti HTML fájl létrehozása
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Első bekezdés kinyerése HTML-ként
    // Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bekezdés mentése képként**

Ebben a szakaszban két példát vizsgálunk meg, amelyek bemutatják, hogyan menthetünk egy szövegbekezdéset, amelyet az [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) interfész képvisel, képként. Mindkét példa magában foglalja a bekezdést tartalmazó alakzat képének lekérését a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) interfész `getImage` metódusaival, a bekezdés határainak kiszámítását az alakzaton belül, és a bitmap képként történő exportálást. Ezek a megközelítések lehetővé teszik, hogy a PowerPoint prezentációkból származó szöveg meghatározott részeit különálló képként nyerjük ki, ami különböző forgatókönyvekben hasznos lehet.

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egy diával, ahol az első alakzat egy szövegdoboz, amely három bekezdést tartalmaz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

**Példa 1**

Ebben a példában a második bekezdést képként nyerjük ki. Ehhez az alakzat képét a prezentáció első diájáról kivonjuk, majd kiszámítjuk a második bekezdés határait az alakzat szövegdobozában. A bekezdést ezután egy új bitmap képre rajzoljuk, amely PNG formátumban kerül mentésre. Ez a módszer különösen hasznos, ha egy adott bekezdést különálló képként szeretnénk menteni, miközben megőrzük a szöveg pontos méreteit és formázását.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A forma mentése memóriában bitmapként.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Form bitmap létrehozása memóriából.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // A második bekezdés határainak kiszámítása.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // A kimeneti kép koordinátáinak és méretének kiszámítása (minimum méret - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // A forma bitmap vágása, hogy csak a bekezdés bitmap maradjon.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

**Példa 2**

Ebben a példában a korábbi megközelítést kiterjesztjük a bekezdés képre skálázási tényezőket alkalmazva. Az alakzatot a prezentációból kivonjuk, és `2` skálázási tényezővel képként mentjük. Ez magasabb felbontású kimenetet tesz lehetővé a bekezdés exportálásakor. A bekezdés határait ezután a skálát figyelembe véve számítjuk ki. A skálázás különösen hasznos lehet, ha részletesebb képre van szükség, például nagy minőségű nyomtatott anyagokhoz.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A forma mentése memóriában bitmapként skálázással.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Forma bitmap létrehozása memóriából.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // A második bekezdés határainak kiszámítása.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // A kimeneti kép koordinátáinak és méretének kiszámítása (minimum méret - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // A forma bitmap levágása, hogy csak a bekezdés bitmap maradjon.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Teljesen letilthatom a sorok tördelését egy szövegdobozban?**

Igen. Használja a szövegdoboz tördelési beállítását ([setWrapText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) a tördelés kikapcsolásához, így a sorok nem törnek meg a keret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián belüli határait?**

Lekérheti a bekezdés (és akár egyetlen rész) határoló téglalapját, hogy megtudja annak pontos pozícióját és méretét a dián.

**Hol állítható be a bekezdés igazítása (balra/jobbra/középre/széthúzott)?**

[Alignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) a bekezdés szintű beállítás a [ParagraphFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphformat/)‑ban; a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

**Beállíthatok helyesírás-ellenőrzési nyelvet a bekezdés csak egy részére (például egy szóra)?**

Igen. A nyelvet a rész szintjén állítja be ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), így több nyelv is létezhet egy bekezdésen belül.