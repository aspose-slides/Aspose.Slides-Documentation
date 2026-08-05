---
title: PowerPoint szöveg bekezdések kezelése Java-ban
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
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
- felsorolás lista
- bekezdés tulajdonságai
- HTML importálás
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Mesteri bekezdésformázás az Aspose.Slides for Java-val — optimalizálja a igazítást, sorközöket és a stílust PPT, PPTX és ODP prezentációkban Java-ban."
---
## **Bevezetés**

Az Aspose.Slides minden interfészt és osztályt biztosít, amelyre a PowerPoint szövegek, bekezdések és részek kezeléséhez Java‑ban szükség van.

* Az Aspose.Slides biztosítja az [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) interfészt, amely lehetővé teszi olyan objektumok hozzáadását, amelyek egy bekezdést képviselnek. Egy `ITextFame` objektumnak egy vagy több bekezdése lehet (minden bekezdés egy sorvége karakterrel jön létre).
* Az Aspose.Slides biztosítja az [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) interfészt, amely lehetővé teszi olyan objektumok hozzáadását, amelyek részeket képviselnek. Egy `IParagraph` objektumnak egy vagy több rész (iPortions objektumok gyűjteménye) lehet.
* Az Aspose.Slides biztosítja az [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) interfészt, amely lehetővé teszi olyan objektumok hozzáadását, amelyek szöveget és formázási tulajdonságait képviselik. 

Egy `IParagraph` objektum képes különböző formázási tulajdonságú szövegeket kezelni az alatta lévő `IPortion` objektumok segítségével.

## **Több bekezdés hozzáadása, amely több részt tartalmaz**

Az alábbi lépések bemutatják, hogyan adhatunk hozzá egy szövegkeretet, amely 3 bekezdést tartalmaz, és minden bekezdés 3 részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. A megfelelő dia hivatkozását érje el az indexe alapján.  
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diára.  
4. Szerezze meg az [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) által használt ITextFrame-et.  
5. Hozzon létre két [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) objektumot, és adja hozzá őket az [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) `IParagraphs` gyűjteményéhez.  
6. Hozzon létre három [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) objektumot minden új `IParagraph` számára (az alapértelmezett bekezdéshez két Portion objektumot), és adja hozzá az egyes `IPortion` objektumokat az adott `IParagraph` IPortion gyűjteményéhez.  
7. Állítson be szöveget minden részhez.  
8. Alkalmazza a kívánt formázási beállításokat minden részre a `IPortion` objektum által biztosított formázási tulajdonságok segítségével.  
9. Mentse el a módosított prezentációt.  

```java
// PPTX fájlt képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Téglalap típusú AutoShape hozzáadása
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Az AutoShape TextFrame-jének elérése
    ITextFrame tf = ashp.getTextFrame();

    // Bekezdések és Részek létrehozása különböző szövegformátumokkal
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

## **Bekezdés felsorolások kezelése**

A felsorolások segítenek gyorsan és hatékonyan szervezni és bemutatni az információt. A felsorolt bekezdések mindig könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. A megfelelő dia hivatkozását érje el az indexe alapján.  
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a kiválasztott diához.  
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) elemét.  
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.  
6. Hozza létre az első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) osztály segítségével.  
7. Állítsa be a bekezdés bullet `Type` értékét `Symbol`-ra, és adja meg a bullet karaktert.  
8. Állítsa be a bekezdés `Text` értékét.  
9. Állítsa be a bekezdés `Indent` értékét a bullethez.  
10. Állítson be színt a bulletnek.  
11. Állítson be magasságot a bulletnek.  
12. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.  
13. Adja hozzá a második bekezdést, és ismételje meg a 7‑13. lépésekben leírt folyamatot.  
14. Mentse el a prezentációt.  

```java
// PPTX fájlt képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshape hozzáadása és elérése
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Az autoshape szövegkeretének elérése
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

    // Bullet behúzásának beállítása
    para.getParagraphFormat().setIndent(25);

    // Bullet színének beállítása
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // állítsa az IsBulletHardColor értékét true-ra saját bullet szín használatához

    // Bullet magasságának beállítása
    para.getParagraphFormat().getBullet().setHeight(100);

    // Bekezdés hozzáadása a szövegkerethez
    txtFrm.getParagraphs().add(para);

    // Második bekezdés létrehozása
    Paragraph para2 = new Paragraph();

    // Bekezdés bullet típusának és stílusának beállítása
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Bekezdés szövegének hozzáadása
    para2.setText("This is numbered bullet");

    // Bullet behúzásának beállítása
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // állítsa az IsBulletHardColor értékét true-ra saját bullet szín használatához

    // Bullet magasságának beállítása
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Bekezdés hozzáadása a szövegkerethez
    txtFrm.getParagraphs().add(para2);
    
    // A módosított prezentáció mentése
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Képes bullet-ek kezelése**

A felsorolások segítenek gyorsan és hatékonyan szervezni és bemutatni az információt. A képes bekezdések könnyen olvashatóak és érthetőek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. A megfelelő dia hivatkozását érje el az indexe alapján.  
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diára.  
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) elemét.  
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.  
6. Hozza létre az első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) osztály segítségével.  
7. Töltse be a képet az [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) segítségével.  
8. Állítsa be a bullet típusát [Picture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) értékre, és adja meg a képet.  
9. Állítsa be a Paragraph `Text` értékét.  
10. Állítsa be a Paragraph `Indent` értékét a bullethez.  
11. Állítson be színt a bulletnek.  
12. Állítson be magasságot a bulletnek.  
13. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.  
14. Adja hozzá a második bekezdést, és ismételje meg a folyamatot az előző lépések alapján.  
15. Mentse el a módosított prezentációt.  

```java
// PPTX fájlt képviselő Presentation osztály példányosítása
Presentation presentation = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = presentation.getSlides().get_Item(0);

    // Bulletokhoz használt kép példányosítása
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Autoshape hozzáadása és elérése
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Az autoshape szövegkeretének elérése
    ITextFrame textFrame = autoShape.getTextFrame();

    // Az alapértelmezett bekezdés eltávolítása
    textFrame.getParagraphs().removeAt(0);

    // Új bekezdés létrehozása
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Bekezdés bullet stílusának és képének beállítása
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Bullet magasságának beállítása
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Bekezdés hozzáadása a szövegkerethez
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

## **Többszintű bullet-ek kezelése**

A felsorolások segítenek gyorsan és hatékonyan szervezni és bemutatni az információt. A többszintű bullet-ek könnyen olvashatóak és érthetőek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. A megfelelő dia hivatkozását érje el az indexe alapján.  
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet az új dián.  
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) elemét.  
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.  
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) osztállyal, és állítsa be a mélységet 0-ra.  
7. Hozza létre a második bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 1-re.  
8. Hozza létre a harmadik bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 2-re.  
9. Hozza létre a negyedik bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 3-ra.  
10. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.  
11. Mentse el a módosított prezentációt.  

```java
// PPTX fájlt képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshape hozzáadása és elérése
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // A létrehozott autoshape szövegkeretének elérése
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
    // Bullet szintjének beállítása
    para1.getParagraphFormat().setDepth((short)0);

    // A második bekezdés hozzáadása
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Bullet szintjének beállítása
    para2.getParagraphFormat().setDepth((short)1);

    // A harmadik bekezdés hozzáadása
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Bullet szintjének beállítása
    para3.getParagraphFormat().setDepth((short)2);

    // A negyedik bekezdés hozzáadása
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Bullet szintjének beállítása
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

Az [IBulletFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/) interfész biztosítja a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) tulajdonságot és másokat, amelyek lehetővé teszik a bekezdések egyéni számozásának vagy formázásának kezelését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. Érje el a bekezdést tartalmazó diát.  
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.  
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) elemét.  
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.  
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) osztállyal, és állítsa be a [NumberedBulletStartWith] értékét 2-re.  
7. Hozza létre a második bekezdést a `Paragraph` osztály segítségével, és állítsa be a `NumberedBulletStartWith` értékét 3-ra.  
8. Hozza létre a harmadik bekezdést a `Paragraph` osztály segítségével, és állítsa be a `NumberedBulletStartWith` értékét 7-re.  
9. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.  
10. Mentse el a módosított prezentációt.  

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // A létrehozott autoshape szövegkeretének elérése
    ITextFrame textFrame = shape.getTextFrame();

    // Az alapértelmezett létező bekezdés eltávolítása
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

Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódust, ha az egész bekezdést szeretné eltolni. Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust, ha csak az első sort szeretné eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző behúzási értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. Érje el a célzott diát.  
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) elemet a diához.  
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.  
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket számukra.  
6. Adja hozzá a bekezdéseket a szövegkerethez.  
7. Mentse el a módosított prezentációt.  

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

![A bekezdések első sorának behúzása](first_line_indent.png)

## **Függő behúzás beállítása bekezdéshez**

A függő behúzás olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metódussal hozhatja létre. A behúzást negatív értékre állítva az első sor balra mozdul a bekezdés törzséhez képest.

Gyakorlati értelemben az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) határozza meg a bekezdés törzs bal oldalú pozícióját, míg az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) határozza meg az első sor helyzetét e margóhoz képest. Függő behúzáshoz állítson pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szójegyzék bejegyzései és egyéb bekezdések esetén, ahol a sortörésű soroknak a bekezdés törzsének alá kell igazodniuk, nem pedig az első sor első karakteréhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. Érje el a célzott diát.  
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) elemet a diához.  
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.  
5. Hozzon létre bekezdéseket, és állítson be minden bekezdéshez egy pozitív [MarginLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) értéket.  
6. Állítson be egy negatív [Indent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) értéket a függő behúzás létrehozásához.  
7. Adja hozzá a bekezdéseket a szövegkerethez.  
8. Mentse el a módosított prezentációt.  

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

![A bekezdések függő behúzása](hanging_indent.png)

## **A bekezdés végének karaktertulajdonságainak kezelése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. Szerezze meg a bekezdést tartalmazó dia hivatkozását a pozíciója alapján.  
3. Adjon hozzá egy téglalap [autoshape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.  
4. Adjon egy [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) elemet két bekezdéssel a téglalaphoz.  
5. Állítsa be a bekezdések `FontHeight` és betűtípus értékét.  
6. Állítsa be a bekezdések End tulajdonságait.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. A megfelelő dia hivatkozását érje el az indexe alapján.  
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diára.  
4. Adjon hozzá és érje el az `autoshape` [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) elemet.  
5. Távolítsa el az alapértelmezett bekezdést az `ITextFrame`-ből.  
6. Olvassa be a forrás HTML fájlt egy TextReader segítségével.  
7. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) osztály használatával.  
8. Adja hozzá a beolvasott TextReader tartalmát a TextFrame [ParagraphCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphcollection/) gyűjteményéhez.  
9. Mentse el a módosított prezentációt.  

```java
// Üres prezentációpéldány létrehozása
Presentation pres = new Presentation();
try {
    // A prezentáció alapértelmezett első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape hozzáadása a HTML tartalom elhelyezéséhez
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Szövegkeret hozzáadása a formához
    ashape.addTextFrame("");

    // Az összes bekezdés törlése a hozzáadott szövegkeretben
    ashape.getTextFrame().getParagraphs().clear();

    // HTML fájl betöltése stream readerrel
    TextReader tr = new StreamReader("file.html");

    // Szöveg hozzáadása a HTML stream readerből a szövegkeretbe
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Prezentáció mentése
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bekezdés szöveg exportálása HTML-be**

Az Aspose.Slides fejlett támogatást nyújt a bekezdésekben szereplő szövegek HTML-be exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.  
2. A megfelelő dia hivatkozását érje el az indexe alapján.  
3. Érje el azt a formát, amely a HTML-be exportálandó szöveget tartalmazza.  
4. Érje el a forma [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/) elemét.  
5. Hozzon létre egy `StreamWriter` példányt, és adja hozzá az új HTML fájlt.  
6. Adjon meg egy kezdő indexet a StreamWriter-nek, és exportálja a kívánt bekezdéseket.  

```java
// Töltsd be a prezentáció fájlt
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // A prezentáció alapértelmezett első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Kívánt index
    int index = 0;

    // Hozzáadott forma elérése
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Kimeneti HTML fájl létrehozása
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Első bekezdés kinyerése HTML-ként
    // Bekezdések adatainak írása HTML-be a bekezdés kezdő indexének és a másolandó bekezdések számának megadásával
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bekezdés mentése képként**

Ebben a szakaszban két példát mutatunk be, amelyek bemutatják, hogyan lehet egy [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) interfész által képviselt szöveges bekezdést képként menteni. Mindkét példában szerepel a bekezdést tartalmazó forma képének megszerzése a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfész `getImage` metódusaival, a bekezdés határainak kiszámítása a formán belül, valamint a bitmapként való exportálás. Ezek a megoldások lehetővé teszik a PowerPoint prezentációkból származó szövegrészek kiválasztását és külön képként mentését, ami különböző felhasználási esetekben hasznos lehet.

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egy diával, ahol az első forma egy szövegdoboz, amely három bekezdést tartalmaz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

**Példa 1**

Ebben a példában a második bekezdést képként nyerjük ki. Ehhez a prezentáció első diájának formájának képét nyerjük ki, majd kiszámítjuk a második bekezdés határait a forma szövegkeretében. A bekezdést ezután új bitmapképre rajzoljuk, amely PNG formátumban kerül mentésre. Ez a módszer különösen hasznos, ha egy adott bekezdést szeretnénk külön képként menteni, miközben megőrizzük a szöveg pontos méretét és formázását.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A forma mentése memóriába bitmapként.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Bitmap létrehozása a memóriából.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // A második bekezdés határainak kiszámítása.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // A kimeneti kép koordinátáinak és méretének kiszámítása (minimum méret - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // A forma bitmap vágása, hogy csak a bekezdés bitmapje maradjon.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

![A bekezdés képe](paragraph_to_image_output.png)

**Példa 2**

Ebben a példában a korábbi megközelítést kiterjesztjük skálázási tényezők hozzáadásával a bekezdés képéhez. A forma a prezentációból ki van nyerve, és a kép skálázási tényezővel `2` kerül mentésre. Ez lehetővé teszi a magasabb felbontású kimenetet a bekezdés exportálásakor. A bekezdés határait a skálázás figyelembevételével számítjuk ki. A skálázás különösen hasznos lehet, ha részletesebb kép szükséges, például magas minőségű nyomtatott anyagokhoz.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A forma mentése memóriába bitmapként skálázással.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Bitmap létrehozása a memóriából.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // A második bekezdés határainak kiszámítása.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // A kimeneti kép koordinátáinak és méretének kiszámítása (minimum méret - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // A forma bitmap vágása, hogy csak a bekezdés bitmapje maradjon.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **GYIK**

**Kikapcsolhatom teljesen a sortörést egy szövegkereten belül?**  
Igen. Használja a szövegkeret sortörés beállítását ([setWrapText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) a beállítás kikapcsolásához, így a sorok nem törnek meg a keret szélén.

**Hogyan tudom lekérdezni egy adott bekezdés pontos helyét a dián?**  
Lekérdezheti a bekezdés (vagy akár egyetlen rész) határoló téglalapját, hogy megtudja annak pontos helyzetét és méretét a dián.

**Hol állítható be a bekezdés igazítása (balra/jobbra/középre/széthúzott)?**  
Az [Alignment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphformat/#setAlignment-int-) a bekezdés szintű beállítás a [ParagraphFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphformat/) osztályban; az egész bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

**Beállíthatok helyesírási nyelvet csak a bekezdés egy részére (például egy szóra)?**  
Igen. A nyelv a rész szintjén van beállítva ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), így több nyelv is megjelenhet egy bekezdésen belül.