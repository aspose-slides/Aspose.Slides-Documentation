---
title: PowerPoint szöveges bekezdések kezelése Androidon
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
keywords:
  - szöveg hozzáadása
  - bekezdés hozzáadása
  - szöveg kezelése
  - bekezdés kezelése
  - felsorolás kezelése
  - bekezdés behúzása
  - függőleges behúzás
  - bekezdés listaelem
  - számozott lista
  - felsoroláslista
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
  - Android
  - Java
  - Aspose.Slides
description: "Mesteri bekezdésformázás Aspose.Slides for Android segítségével—optimalizálja az igazítást, távolságokat és a stílust PPT, PPTX és ODP prezentációkban Java-ban."
---
## **Bevezetés**

Az Aspose.Slides minden szükséges interfészt és osztályt biztosít, amelyre a PowerPoint szövegekkel, bekezdésekkel és részekkel való munka során Java‑ban szüksége van.

* Az Aspose.Slides biztosítja a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) interfészt, amely lehetővé teszi olyan objektumok hozzáadását, amelyek bekezdést képviselnek. Egy `ITextFame` objektum egy vagy több bekezdést tartalmazhat (minden bekezdés egy sortöréssel jön létre).
* Az Aspose.Slides biztosítja a [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) interfészt, amely lehetővé teszi olyan objektumok hozzáadását, amelyek részeket képviselnek. Egy `IParagraph` objektum egy vagy több részt (iPortions objektumok gyűjteményét) tartalmazhat.
* Az Aspose.Slides biztosítja a [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) interfészt, amely lehetővé teszi olyan objektumok hozzáadását, amelyek szöveget és annak formázási tulajdonságait képviselik.

Egy `IParagraph` objektum képes a szövegeket különböző formázási tulajdonságokkal kezelni az alatta lévő `IPortion` objektumokon keresztül.

## **Több bekezdés hozzáadása, amelyek több szövegrészt tartalmaznak**

Ezek a lépések azt mutatják, hogyan adjon hozzá egy szövegkeretet, amely 3 bekezdést, és minden bekezdés 3 részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg az [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/)‑hoz tartozó ITextFrame-et.
5. Hozzon létre két [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) objektumot, és adja hozzá az [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) `IParagraphs` gyűjteményéhez.
6. Hozzon létre három [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) objektumot minden új `IParagraph` számára (alapértelmezett bekezdéshez két Portion objektum), majd tegye az egyes `IPortion` objektumokat a megfelelő `IParagraph` IPortion gyűjteményébe.
7. Állítson be szöveget minden részhez.
8. Alkalmazza a kívánt formázási funkciókat minden részre a `IPortion` objektum által biztosított formázási tulajdonságok segítségével.
9. Mentse el a módosított prezentációt.

```java
// Példányosíts egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Adj hozzá egy Rectangle típusú AutoShape-et
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Az AutoShape TextFrame-jének elérése
    ITextFrame tf = ashp.getTextFrame();

    // Hozz létre bekezdéseket és részeket különböző szövegformátumokkal
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

    // Írd a PPTX-et a lemezre
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Bekezdés felsorolások kezelése**

A felsorolások segítenek gyorsan és hatékonyan rendszerezni, valamint bemutatni az információkat. A felsorolt bekezdések mindig könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a kiválasztott diához.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)‑jét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Hozza létre az első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztály segítségével.
7. Állítsa be a bekezdés bullet `Type`‑ját `Symbol`‑ra, és adja meg a bullet karaktert.
8. Állítsa be a bekezdés `Text`‑ét.
9. Állítsa be a bekezdés `Indent`‑et a bullet számára.
10. Állítson be színt a bullet‑nek.
11. Állítson be magasságot a bullet‑nek.
12. Adja hozzá az új bekezdést a `TextFrame` bekezdéggyűjteményéhez.
13. Adja hozzá a második bekezdést, és ismételje meg a 7‑13 lépéseket.
14. Mentse el a prezentációt.

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Az első diát eléri
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshape-et hozzáad és eléri
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Az autoshape szövegkeretét eléri
    ITextFrame txtFrm = aShp.getTextFrame();

    // Eltávolítja az alapértelmezett bekezdést
    txtFrm.getParagraphs().removeAt(0);

    // Létrehoz egy bekezdést
    Paragraph para = new Paragraph();

    // Beállítja a bekezdés bullet stílusát és szimbólumát
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Beállítja a bekezdés szövegét
    para.setText("Welcome to Aspose.Slides");

    // Beállítja a bullet behúzást
    para.getParagraphFormat().setIndent(25);

    // Beállítja a bullet színét
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // állítsa az IsBulletHardColor értékét true-ra a saját bullet szín használatához

    // Beállítja a bullet magasságát
    para.getParagraphFormat().getBullet().setHeight(100);

    // Bekezdés hozzáadása a szövegkerethez
    txtFrm.getParagraphs().add(para);

    // Létrehoz egy második bekezdést
    Paragraph para2 = new Paragraph();

    // Beállítja a bekezdés bullet típusát és stílusát
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Bekezdés szövegének hozzáadása
    para2.setText("This is numbered bullet");

    // Beállítja a bullet behúzást
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // állítsa az IsBulletHardColor értékét true-ra a saját bullet szín használatához

    // Beállítja a bullet magasságát
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Bekezdés hozzáadása a szövegkerethez
    txtFrm.getParagraphs().add(para2);
    
    // Mentse el a módosított prezentációt
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kép alapú felsorolások kezelése**

A felsorolások segítenek gyorsan és hatékonyan rendszerezni, valamint bemutatni az információkat. A képes bekezdések könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)‑jét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Hozza létre az első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztály segítségével.
7. Töltse be a képet a [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/)‑be.
8. Állítsa be a bullet típusát [Picture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/)‑re, és adja meg a képet.
9. Állítsa be a bekezdés `Text`‑ét.
10. Állítsa be a bekezdés `Indent`‑et a bullet számára.
11. Állítson be színt a bullet‑nek.
12. Állítson be magasságot a bullet‑nek.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdéggyűjteményéhez.
14. Adja hozzá a második bekezdést, és ismételje meg a korábbi lépéseket.
15. Mentse el a módosított prezentációt.

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation presentation = new Presentation();
try {
    // Az első diát eléri
    ISlide slide = presentation.getSlides().get_Item(0);

    // Példányosítja a bullet-ekhez használt képet
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Autoshape-et hozzáad és eléri
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Az autoshape szövegkeretét eléri
    ITextFrame textFrame = autoShape.getTextFrame();

    // Eltávolítja az alapértelmezett bekezdést
    textFrame.getParagraphs().removeAt(0);

    // Létrehoz egy új bekezdést
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Beállítja a bekezdés bullet stílusát és képét
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Beállítja a bullet magasságát
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

## **Többszintű felsorolások kezelése**

A felsorolások segítenek gyorsan és hatékonyan rendszerezni, valamint bemutatni az információkat. A többszintű bullet‑ok könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet az új dián.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)‑jét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Hozza létre az első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztállyal, és állítsa be a mélységet 0‑ra.
7. Hozza létre a második bekezdés példányt a `Paragraph` osztállyal, és állítsa be a mélységet 1‑re.
8. Hozza létre a harmadik bekezdés példányt a `Paragraph` osztállyal, és állítsa be a mélységet 2‑re.
9. Hozza létre a negyedik bekezdés példányt a `Paragraph` osztállyal, és állítsa be a mélységet 3‑ra.
10. Adja hozzá az új bekezdéseket a `TextFrame` bekezdéggyűjteményéhez.
11. Mentse el a módosított prezentációt.

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Az első diát eléri
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshape-et hozzáad és eléri
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // A létrehozott autoshape szövegkeretét eléri
    ITextFrame text = aShp.addTextFrame("");

    // Törli az alapértelmezett bekezdést
    text.getParagraphs().clear();

    // Hozzáadja az első bekezdést
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Beállítja a bullet szintjét
    para1.getParagraphFormat().setDepth((short)0);

    // Hozzáadja a második bekezdést
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Beállítja a bullet szintjét
    para2.getParagraphFormat().setDepth((short)1);

    // Hozzáadja a harmadik bekezdést
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Beállítja a bullet szintjét
    para3.getParagraphFormat().setDepth((short)2);

    // Hozzáadja a negyedik bekezdést
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Beállítja a bullet szintjét
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

## **Egy bekezdés saját számozott listával történő kezelése**

Az [IBulletFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/) interfész biztosítja a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) tulajdonságot és másokat, amelyekkel saját számozású vagy formázott bekezdéseket kezelhet.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el azt a diát, amelyik a bekezdést tartalmazza.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diához.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)‑jét.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Hozza létre az első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztállyal, és állítsa be a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét 2‑re.
7. Hozza létre a második bekezdés példányt a `Paragraph` osztállyal, és állítsa be a `NumberedBulletStartWith` értékét 3‑ra.
8. Hozza létre a harmadik bekezdés példányt a `Paragraph` osztállyal, és állítsa be a `NumberedBulletStartWith` értékét 7‑re.
9. Adja hozzá az új bekezdéseket a `TextFrame` bekezdéggyűjteményéhez.
10. Mentse el a módosított prezentációt.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Eléri a létrehozott autoshape szövegkeretét
    ITextFrame textFrame = shape.getTextFrame();

    // Eltávolítja az alapértelmezett létező bekezdést
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

## **Első sor behúzás beállítása egy bekezdéshez**

Az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust használja a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódust, ha a teljes bekezdést szeretné eltolni. Az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust használja, ha csak az első sort kell eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző behúzási értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el a céldiát.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) elemet a diához.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket számukra.
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

Az eredmény:

![A bekezdések első sorának behúzása](first_line_indent.png)

## **Függőleges behúzás beállítása egy bekezdéshez**

A függőleges (hanging) behúzás egy olyan bekezdéselrendezés, ahol az első sor balra kezdődik a többi sorhoz képest. Az Aspose.Slides‑ben ezt az effektust az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódussal hozhatja létre. Állítson be negatív értéket a behúzásnál, hogy az első sort a bekezdés törzséhez képest balra mozdítsa.

Gyakorlatban az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) határozza meg a bekezdés törzsének bal pozícióját, míg az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) határozza meg az első sor helyzetét ehhez a margóhoz képest. A függőleges behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a sortörésnek a bekezdés törzsének alá kell esnie, nem pedig az első sor első karaktere alá.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el a céldiát.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) elemet a diához.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be pozitív [MarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) értéket minden bekezdéshez.
6. Állítson be negatív [Indent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értéket a függőleges behúzás hatásának létrehozásához.
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

Az eredmény:

![A bekezdések függőleges behúzása](hanging_indent.png)

## **Befejező bekezdés futtatási tulajdonságok kezelése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezze be a bekezdést tartalmazó dia referenciáját a pozíciója alapján.
3. Adjon hozzá egy téglalap [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diához.
4. Adjon egy [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) elemet két bekezdéssel a téglalaphoz.
5. Állítsa be a `FontHeight`‑et és a betűtípust a bekezdésekhez.
6. Állítsa be a befejező (End) tulajdonságokat a bekezdésekhez.
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

## **HTML‑szöveg importálása bekezdésekbe**

Az Aspose.Slides kibővített támogatást nyújt HTML‑szöveg bekezdésekbe történő importálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
4. Adjon hozzá és érje el az `autoshape` [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)‑jét.
5. Távolítsa el az alapértelmezett bekezdést az `ITextFrame`‑ben.
6. Olvassa be a forrás‑HTML‑fájlt egy `TextReader`‑ben.
7. Hozza létre az első bekezdés példányt a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) osztállyal.
8. Adja hozzá a HTML‑fájl tartalmát a `TextReader`‑ben olvasott szöveget a `TextFrame` [ParagraphCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/)-hoz.
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

    // Szövegkeret hozzáadása az alakzathoz
    ashape.addTextFrame("");

    // A hozzáadott szövegkeret összes bekezdésének törlése
    ashape.getTextFrame().getParagraphs().clear();

    // HTML fájl betöltése stream reader‑rel
    TextReader tr = new StreamReader("file.html");

    // Szöveg hozzáadása a HTML stream reader‑ből a szövegkeretbe
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Prezentáció mentése
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bekezdés szöveg exportálása HTML‑be**

Az Aspose.Slides kibővített támogatást nyújt a bekezdésekben található szövegek HTML‑be exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.
2. Érje el a megfelelő dia referenciáját az indexe alapján.
3. Érje el a szöveget tartalmazó alakzatot, amelyet HTML‑be exportál.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)‑jét.
5. Hozzon létre egy `StreamWriter` példányt, és adja hozzá az új HTML‑fájlt.
6. Adjon meg egy kezdő indexet a `StreamWriter`‑nek, és exportálja a kívánt bekezdéseket.

```java
// A prezentációfájl betöltése
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

    //Az első bekezdés kinyerése HTML-ként
    // Bekezdések adatainak írása HTML-be a bekezdés kezdőindexének és a másolandó bekezdések számának megadásával
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bekezdés mentése képként**

Ebben a szakaszban két példát mutatunk be, amelyek azt szemléltetik, hogyan menthet egy szövegbekezdést, amelyet az [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) interfész képvisel, képként. Mindkét példa tartalmazza a bekezdést tartalmazó alakzat képének megszerzését a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) interfész `getImage` metódusaival, a bekezdés alakzaton belüli határainak kiszámítását, valamint bitmap‑ként való exportálását. Ezek a módszerek lehetővé teszik a PowerPoint‑prezentációk szövegének specifikus részeinek kivonását és külön képként való mentését, ami különféle további felhasználási eseteknél hasznos lehet.

Tegyük fel, hogy van egy `sample.pptx` nevű prezentációs fájlunk, amely egy diát tartalmaz, ahol az első alakzat egy szövegdoboz három bekezdéssel.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

**Példa 1**

Ebben a példában a második bekezdést mentjük képként. Ehhez először a prezentáció első diáján lévő alakzat képét nyerjük ki, majd kiszámítjuk a második bekezdés határait az alakzat szövegkeretében. A bekezdést ezután egy új bitmap‑képre rajzoljuk, amelyet PNG formátumban mentünk. Ez a módszer különösen hasznos, ha egy adott bekezdést szeretne elkülönített képként menteni, miközben megőrzi a szöveg pontos méretét és formázását.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A forma mentése memóriában bitmapként.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Forma bitmap létrehozása memóriából.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // A második bekezdés határainak kiszámítása.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Koordináták és méret számítása a kimeneti képhez (minimum méret - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // A forma bitmap vágása, hogy csak a bekezdés bitmapje legyen.
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

Ebben a példában a korábbi megközelítést bővítjük skálázási tényezők hozzáadásával a bekezdés képéhez. Az alakzatot a prezentációból kivesszük, és `2`‑es skálázási tényezővel mentjük képként, ami magasabb felbontású kimenetet biztosít a bekezdés exportálásakor. A bekezdés határait ezután a skálázás figyelembevételével számoljuk ki. A skálázás különösen hasznos, ha részletesebb képre van szükség, például nyomtatási anyagokhoz.

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

    // A forma bitmap vágása, hogy csak a bekezdés bitmapje legyen.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **GYIK**

**Teljesen letiltható a sortörés egy szövegkereten belül?**

Igen. Használja a szövegkeret `setWrapText` ([setWrapText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) beállítását a sortörés kikapcsolásához, így a sorok nem törnek meg a keret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos diákon belüli határait?**

A bekezdés (vagy akár egyetlen rész) körülhatároló téglalapjának lekérésével pontos pozícióját és méretét határozhatja meg a dián.

**Hol van szabályozva a bekezdés igazítása (bal/right/közép/igazított)?**

Az [Alignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) beállítás a [ParagraphFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphformat/)‑ban, bekezdés szintű, és a teljes bekezdésre vonatkozik a részletek formázásától függetlenül.

**Beállíthatok helyesírási nyelvet csak a bekezdés egy részére (például egy szóra)?**

Igen. A nyelv a [PortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)‑nél kerül beállításra, így egy bekezdésen belül több nyelv is létezhet.