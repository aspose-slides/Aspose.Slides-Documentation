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
- bekezdésbehúzás
- függő behúzás
- bekezdés felsorolás
- számozott lista
- felsoroláslista
- bekezdéstulajdonságok
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmat és bekezdésképeket az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Java a szöveget szövegkeretek, bekezdések és részek hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) a shape szövegkonténerét képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) egy bekezdést képvisel a szövegkeretben, és hozzáférést biztosít a részekhez és a bekezdésszintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) egy szöveg futást jelent egy bekezdésen belül. Minden résznek lehet saját szövege és karakter szintű formázása.

Egy bekezdés tehát több részt használva különböző betűtípusokkal, színekkel, méretekkel és egyéb formázással rendelkező szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Több részt tartalmazó bekezdések létrehozása**

Az alábbi lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. A kívánt diát érje el az indexe alapján.
3. Adjon egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés a shape [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-hez.
5. Használja az alapértelmezett bekezdést, és vegyen fel még két [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) objektumot a szövegkeretbe.
6. Adjon elegendő [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alapértelmezett bekezdés már tartalmaz egy üres részt.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#getPortionFormat--) segítségével.
9. Mentse el a módosított prezentációt.

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

## **Felsorolásjelek és számozott listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A felsorolásjelek és a számozás segítik az összefüggő elemek gyors átlapozását. Az Aspose.Slides-ben a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. A kívánt diát érje el az indexe alapján.
3. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Hozzáférés a shape [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-hez.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) elemet egy szimbólum jellegű felsoroláshoz.
7. Állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/) típusra, és adja meg a felsorolás karakterét.
8. Állítsa be a bekezdés szövegét, a behúzást, a felsorolás színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/) típusra.
11. Konfigurálja a számozott felsorolás stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse el a prezentációt.

Ez a Java példa szimbólum és számozott felsorolást hoz létre:

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

### **Képes felsorolásjelek használata**

A képes felsorolásjelekkel egyedi képet használhat szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. A kívánt diát érje el az indexe alapján.
3. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet, és férjen hozzá annak [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-éhez.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a felsorolás képet, és adja hozzá a prezentáció képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/)ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/) típusra.
8. Rendelje hozzá a képet a [IBulletFormat.getPicture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#getPicture--) segítségével, és állítsa be a felsorolás magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse el a módosított prezentációt.

Ez a Java példa képes felsorolást hoz létre:

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

Állítsa be az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setDepth-short-) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és konfigurálja azok felsorolás szimbólumait.
4. Állítsa be a [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setDepth-short-) értékeit `0`, `1`, `2` és `3`-ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse el a prezentációt.

Ez a Java példa négy szintű felsorolást hoz létre:

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

### **Számozott listaelemek kezdőértékének egyedi beállítása**

Használja az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metódust, hogy egy számozott bekezdés kezdeti számát állítsa be.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) elemet, és adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet egy diára.
2. Törölje az alapértelmezett bekezdést a shape szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét `2`, `3` és `7`-re a megfelelő bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse el a prezentációt.

Ez a Java példa egyedi kezdőszámot állít be minden bekezdésnél:

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

## **Bekezdéselrendezés és befejező tulajdonságok vezérlése**

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés testhez igazodik.

Ha a teljes bekezdést szeretné mozgatni, használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)-t. Ha csak az első sort akarja mozgatni, használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-)-t.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a céldiaphoz.
3. Adjon egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés a shape [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-hez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse el a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be bekezdésbehúzást:

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

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Függőleges behúzás beállítása**

A függőleges behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides-ben ezt az effektust az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) segítségével hozhatja létre. Negatív értékkel mozgathatja az első sort balra a bekezdés testhez képest.

Gyakorlatban az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) határozza meg a bekezdés test bal pozícióját, az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pedig az első sor pozícióját ahhoz képest. Függőleges behúzás létrehozásához adjon meg pozitív értéket a `setMarginLeft`‑nek, és negatív értéket az `setIndent`‑nek.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szószedet-bejegyzésekhez és egyéb bekezdésekhez, ahol a sortöréseknek a bekezdés test alatt kell elhelyezkedniük, nem pedig az első sor első karaktere alatt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a céldiaphoz.
3. Adjon egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés a shape [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-hez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és adjon pozitív értéket az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) minden bekezdéshez.
6. Adjon negatív értéket az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metódusnak a függőleges behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse el a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be függőleges behúzást egy bekezdéshez:

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

![A bekezdések függőleges behúzása](hanging_indent.png)

### **Befejező bekezdésformázás beállítása**

Az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) a bekezdés végét jelző jel karakter formázását szabályozza. Az alábbi példa a második bekezdés végjelére betűméretet és latin betűtípust állít be:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet, és törölje annak alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon szövegrétegeket hozzájuk.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portionformat/) objektumot a második bekezdés végjeléhez.
5. Állítsa be az [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) és az [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) értékeket.
6. Rendelje hozzá a formátumot az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) metódussal, majd mentse el a prezentációt.

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

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódust, hogy HTML jelölőnyelvet alakítson bekezdésekké és részekké egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés egy diához, és adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet.
3. Hozzáférés a shape [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-hez, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak.
6. Mentse el a módosított prezentációt.

Ez a Java példa HTML-t importál egy szövegkeretbe:

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

### **Bekezdésszöveg exportálása HTML-be**

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust, hogy a bekezdések egy kiválasztott tartományát HTML-ként exportálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.
2. Hozzáférés a diához, és keresse meg a szöveget tartalmazó [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet.
3. Hozzáférés a shape [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)-hez.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kezdő bekezdésindexszel és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

Ez a Java példa az első szöveges shape összes bekezdését exportálja:

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

Az [IParagraph.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getImage--) egyetlen bekezdést renderel közvetlenül, és egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektumot ad vissza. A visszakapott képet mentse fájlba vagy streambe az [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/#save-java.lang.String-int-) metódussal. Nem szükséges a teljes shape-et renderelni vagy a bitmapet manuálisan levágni.

Az [IParagraph.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getImage--) `null` értéket adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretarányban**

Tegyük fel, hogy van egy `sample.pptx` nevű prezentációfájl egy diával, ahol az első shape egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy szabályos szöveges shape-ben rendereli alapértelmezett méretarányban, és PNG formátumban menti a visszakapott képet. A `finally` blokk biztosítja, hogy a kép megfelelően felszabaduljon.

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

#### **Bekezdés renderelése táblázatcella méretezéssel**

Használja az [IParagraph.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getImage-float-float-) túlterhelést, amely a `float scaleX` és `float scaleY` paramétereket fogadja a vízszintes és függőleges méretezési tényezők megadásához. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres szélességgel és magassággal rendereli, majd PNG képként menti.

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

Az `1` méretarány megtartja az adott tengely alapértelmezett pixelméretét. Például a `2` mindkét tényezőnél olyan képet eredményez, amelynek szélessége és magassága körülbelül kétszerese az alapértelmezett méretnek, ezáltal négyzetgyökú pixel számot adva. Nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet is. Az `1` alatti tényezők kisebb, kevésbé részletes képeket hoznak. Használjon egyenlő tényezőket az arányok megőrzéséhez; a különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

Egy teljes shape renderelése az [IShape.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getImage--) továbbra is hasznos, ha a kimenetnek tartalmaznia kell a shape kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdés képe esetén használja az [IParagraph.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getImage--) metódust.

## **Gyakran ismételt kérdések**

**Teljesen letiltható a sortörés egy szövegkereten belül?**

Igen. Állítsa be az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) értékét a sortörés letiltásához, így a sorok nem törnek a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián belüli határait?**

Használja az [IParagraph.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getRect--) metódust a bekezdés határoló téglalapjának lekérdezéséhez. Az [IPortion.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#getRect--) egyedi rész határait adja vissza.

**Hol van a bekezdés igazítás (balra, jobbra, középre vagy sorkizárás) vezérelve?**

Az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) egy bekezdés szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyedi részformázástól.

**Beállítható-e a nyelvellenőrzés egy bekezdés egy részére?**

Igen. Állítsa be az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) értékét egyedi részeknél, így egy bekezdés több nyelvű szöveget is tartalmazhat.