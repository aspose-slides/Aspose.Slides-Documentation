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
  - pont kezelése
  - bekezdés behúzás
  - függő behúzás
  - bekezdés pont
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
  - prezentáció
  - Java
  - Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, pontozást, számozott listákat, behúzásokat, HTML tartalmat és bekezdésképeket az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Java a szöveget egy szövegkeretekből, bekezdésekből és részekből álló hierarchiaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) egy alakzatban lévő szövegtárolót képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdés szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) egy szövegrészt képvisel egy bekezdésen belül. Minden résznek saját szövege és karakter szintű formázása lehet.

Egy bekezdés tehát több részt felhasználva különböző betűtípusokkal, színekkel, méretekkel és egyéb formázásokkal tartalmazhat szöveget.

## **Bekezdések létrehozása és formázása**

### **Több részes bekezdések létrehozása**

Az alábbi lépések három bekezdésből álló szövegkeretet hoznak létre, mindegyik három részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érje el.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diára.
4. A forma [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-éhez férjen hozzá.
5. Használja az alapértelmezett bekezdést, és adjon hozzá további két [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) objektumot a szövegkerethez.
6. Minden bekezdéshez adjon elegendő [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) objektumot, hogy három részt tartalmazzon. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazza a karakter szintű formázást az [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#getPortionFormat--) segítségével.
9. Mentse a módosított bemutatót.

Ez a Java példa megvalósítja a lépéseket:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Felsoroláspontok és számozott listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A pontok és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érje el.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a kiválasztott diához.
4. A forma [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-éhez férjen hozzá.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) elemet egy szimbólum pontozáshoz.
7. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/) értékre, és adja meg a pont karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, pont színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/) értékre.
11. Állítsa be a számozott pont stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a bemutatót.

Ez a Java példa egy szimbólum pontot és egy számozott pontot hoz létre:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Képes pontok használata**

A képes pontok lehetővé teszik egy saját kép használatát a szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érje el.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet, és férjen hozzá annak [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-éhez.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a pontképet, és adja hozzá a bemutató képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/)ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/) értékre.
8. Állítsa be a képet az [IBulletFormat.getPicture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#getPicture--) segítségével, és adja meg a pont magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított bemutatót.

Ez a Java példa egy képes pontot hoz létre:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Többszintű lista létrehozása**

Állítsa be az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setDepth-short-) értékét a bekezdések különböző szintű listában való elhelyezéséhez. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) elemet, és férjen hozzá egy diához.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet, és távolítsa el az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és állítsa be azok pontszimbólumait.
4. Állítsa be az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setDepth-short-) értékét `0`, `1`, `2` és `3`-ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a bemutatót.

Ez a Java példa egy négy szintű felsorolást hoz létre:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Számozott listaelemek egyéni kezdőértékkel**

Az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) segítségével állítható be egy számozott bekezdés kezdeti száma.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) elemet, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet egy diához.
2. Távolítsa el az alapértelmezett bekezdést a forma szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét `2`, `3` és `7`-re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a bemutatót.

Ez a Java példa egyedi kezdőszámot rendel minden bekezdéshez:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bekezdéselrendezés és végjellemzők vezérlése**

### **Első sor behúzásának beállítása**

Az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) segítségével szabályozható egy bekezdés első sorának behúzása. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)‑t, ha az egész bekezdést szeretné eltolni. Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑t, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket alkalmaz a első sor behúzásának hatásának bemutatására.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a cél diához.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
4. A forma [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)‑éhez férjen hozzá, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állítható be egy bekezdés behúzása:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az első sor behúzása a bekezdésekben](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt az effektust az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) negatív értékével érhetjük el, amely az első sort balra mozgatja a bekezdéstörzshöz képest.

Gyakorlatilag az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) definiálja a bekezdés törzsének bal pozícióját, míg az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) az első sor pozícióját a margóhoz képest. Függő behúzás létrehozásához adjon pozitív értéket a `setMarginLeft`‑nek, és negatív értéket a `setIndent`‑nek.

Ez a formázás hasznos például bibliográfiák, hivatkozások, szójegyzékek és egyéb olyan bekezdések esetén, ahol a sortöréseknek a bekezdés törzse alá kell igazodniuk, nem pedig az első sor első karakterébe.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a cél diához.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
4. A forma [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)‑éhez férjen hozzá, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és minden bekezdéshez adjon pozitív értéket az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)‑nek.
6. Adjon negatív értéket az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑nek a függő behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állítható be a függő behúzás egy bekezdéshez:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdések függő behúzása](hanging_indent.png)

### **Végleges bekezdésformázás beállítása**

Az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) szabályozza a bekezdés zárójelének formázását. Az alábbi példa egy betűméretet és latin betűtípust rendel a második bekezdés zárójeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) elemet, és férjen hozzá egy diához.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portionformat/) elemet a második bekezdés zárójeléhez.
5. Állítsa be az [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) és az [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) értékeket.
6. Az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-)‑nel rendelje hozzá a formátumot, és mentse a bemutatót.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Megjelenített sorok számolása**

A bekezdés szabályairól, amelyek az automatikus sortörést és a pontozást befolyásolják, lásd a [Control Line Breaking](/slides/hu/java/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/java/text-formatting/#control-hanging-punctuation) oldalakat.

Az [IParagraph.getLinesCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getLinesCount--) segítségével megszámolhatók a bekezdés által a szövegelrendezés után elfoglalt sorok, beleértve az automatikus sortörést. Ez hasznos a szöveg hosszának és elrendezésének ellenőrzésénél a prezentációs sablonokban.

Egy bekezdés a [ITextFrame.getParagraphs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParagraphs--) egyik eleme, és több megjelenített sort is elfoglalhat. Egy explicit sortörés a bekezdésen belül új sort kényszerít anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy explicit sortörés karaktereket illesztene be a szövegbe. Ezért a bekezdések vagy sortörés karakterek számlálása nem adja meg a megjelenített sorok számát.

Az alábbi példa egy szöveges alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A sortörés engedélyezett, az automatikus illesztés le van tiltva, így az alakzat szélessége szabályozza a sortörést anélkül, hogy a szöveg automatikusan zsugorodna vagy az alakzat mérete változna. Az alakzat méretei pontban vannak. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a szövegkeretben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a rövidebb szövegre cserélés csökkenti azt. A pontos számok a betűtípus elérhetőségétől, helyettesítéstől, betűmérettől, margóktól, behúzástól, sortöréstől és az automatikus illesztés beállításaitól is függenek. A sablon ellenőrzésekor a célkörnyezethez szánt betűtípusokat és elrendezési beállításokat használja.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlnyúlik-e a tárolóján. A rendelkezésre álló magasság, sormagasság, bekezdés- és sorköz, valamint az automatikus illesztés viselkedése is számít; még egy sor is túlnyúlhat a rendelkezésre álló szélességen, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódust a HTML jelölés bekezdésekké és részekké konvertálásához egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés egy diához, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet.
3. A forma [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)‑éhez férjen hozzá, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)‑nek.
6. Mentse a módosított bemutatót.

Ez a Java példa HTML‑t importál egy szövegkeretbe:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Bekezdés szövegének exportálása HTML‑be**

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kiválasztott bekezdéstartomány HTML‑ként történő exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból, és töltse be a kívánt bemutatót.
2. Hozzáférés a diához, és keresse meg a szöveget tartalmazó [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet.
3. A forma [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-éhez férjen hozzá.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)‑t a kezdő bekezdésindex és az exportálandó bekezdések száma megadásával.
5. Írja a visszaadott HTML karakterláncot egy fájlba.

Ez a Java példa az első szöveges alakzat összes bekezdését exportálja:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Bekezdés renderelése képként**

Az [IParagraph.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getImage--) egy önálló bekezdést renderel, és visszaad egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektumot. A kapott eredményt mentse fájlba vagy adatfolyamba az [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/#save-java.lang.String-int-)‑nel. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan levágni.

Az [IParagraph.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getImage--) `null` értéket adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a felhasználás után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezésben**

Tegyük fel, hogy van egy sample.pptx nevű bemutatófájlunk egy diával, amelynek első alakzata egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy szabályos szöveges alakzatban rendereli alapértelmezett méretezésben, és PNG formátumban menti a visszakapott képet. A `finally` blokk biztosítja, hogy a kép helyesen legyen felszabadítva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázatcellában méretezéssel**

Használja az [IParagraph.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getImage-float-float-) túlterhelést, amely `float scaleX` és `float scaleY` paramétereket fogad, a vízszintes és függőleges méretezési tényezők beállításához. Az alábbi példa egy táblázatot hoz létre, a bekezdést rendereli az első cellájában a szélesség és magasság kétszeresére, majd PNG képként menti az eredményt.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Az `1` érték megtartja az adott tengely alapértelmezett képpontméretét. Például a `2` mindkét tényezőre azt eredményezi, hogy a kép szélessége és magassága megközelítőleg kétszerese az alapméreteknek, így a pixelmennyiség négyszeresére nő. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de nő a memóriahasználat és a fájlméret is. Az `1`‑nél kisebb tényezők kisebb képet hoznak létre kevesebb részlettel. Használjon egyenlő tényezőket a bekezdés méretarányának megőrzéséhez; különböző vízszintes és függőleges tényezők a kimenetet függetlenül nyújtják.

Egy teljes alakzat renderelése az [IShape.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getImage--)‑nel akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, keretét vagy egyéb vizuális kontextusát. Csak bekezdést ábrázoló képhez használja az [IParagraph.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getImage--)‑t.

## **GYIK**

**Teljesen letiltható a sortörés egy szövegkereten belül?**

Igen. Az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) beállításával letiltható a sortörés, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kapható meg egy adott bekezdés pontos helyi mérete?**

Az [IParagraph.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getRect--) segítségével lekérhető a bekezdés körülhatároló téglalapja. Az [IPortion.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#getRect--) egyedi rész határait adja meg.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

Az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) egy bekezdés‑szintű beállítás, és a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

**Beállítható-e a bizonyos nyelv helyesírási ellenőrzése egy bekezdés egy részén?**

Igen. Az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) beállítható egyedi részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.