---
title: PowerPoint szövegbekezdések kezelése Java-ban
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
- jelölő kezelése
- bekezdés behúzása
- függő behúzás
- bekezdés jelölő
- számozott lista
- felsoroláslista
- bekezdés tulajdonságai
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
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, jelölőket, számozott listákat, behúzásokat, HTML tartalmat, és bekezdés képeket az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Java a szöveget szövegkeretek, bekezdések és szakaszok hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) a szövegkonténert jelenti egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) egy bekezdést jelöl egy szövegkeretben, és hozzáférést biztosít a szakaszokhoz és a bekezdés szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) egy szövegrészt (run) jelöl egy bekezdésen belül. Minden szakasz saját szöveget és karakter szintű formázást tartalmazhat.

Ezért egy bekezdés több szakasz használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget is tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Több szakaszos bekezdések létrehozása**

A következő lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három szakaszt tartalmaz.

1. Hozzon létre egy példányt a Presentation osztályból.
2. Érje el a megfelelő diát az indexe alapján.
3. Adjon hozzá egy téglalap alakú IAutoShape elemet a diára.
4. Érje el az alakzat ITextFrame-jét.
5. Használja az alapértelmezett bekezdést, és adjon még két IParagraph objektumot a szövegkerethez.
6. Adjon elegendő IPortion objektumot minden bekezdéshez, hogy három szakaszt tartalmazzon. Az alapértelmezett bekezdés már egy üres szakaszt tartalmaz.
7. Állítsa be minden szakasz szövegét.
8. Alkalmazzon karakter szintű formázást az IPortion.getPortionFormat segítségével.
9. Mentse a módosított prezentációt.

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

## **Felsorolás és számozott lista létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

Az elemek felsorolása és számozása megkönnyíti a kapcsolódó tételek áttekintését. Az Aspose.Slides-ban a lista beállításait az IBulletFormat határozza meg.

1. Hozzon létre egy példányt a Presentation osztályból.
2. Érje el a megfelelő diát az indexe alapján.
3. Adjon hozzá egy IAutoShape elemet a kiválasztott diához.
4. Érje el az alakzat ITextFrame-jét.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy Paragraph elemet egy szimbólum jelölőhöz.
7. Állítsa be az IBulletFormat.setType értékét a BulletType.Symbol-re, és adja meg a jel karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a jel színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be az IBulletFormat.setType értékét a BulletType.Numbered-re.
11. Állítsa be a számozott jel stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a prezentációt.

Ez a Java példa egy szimbólum- és egy számozott jelölőt hoz létre:

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

### **Képes jelek használata**

Az képes jelek lehetővé teszik, hogy egyéni képet használjon szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a Presentation osztályból.
2. Érje el a megfelelő diát az indexe alapján.
3. Adjon hozzá egy IAutoShape elemet, és érje el annak ITextFrame-jét.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a jel képet, és adja hozzá a prezentáció képgyűjteményéhez IPPImageként.
6. Hozzon létre egy Paragraph elemet, és állítsa be annak szövegét.
7. Állítsa be az IBulletFormat.setType értékét a BulletType.Picture-re.
8. Rendelje hozzá a képet az IBulletFormat.getPicture segítségével, és állítsa be a jel magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított prezentációt.

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

Az IParagraphFormat.setDepth beállításával helyezhet be bekezdéseket egy lista különböző szintjeire. A legfelső szint mélysége `0`.

1. Hozzon létre egy Presentation példányt, és érje el egy diát.
2. Adjon hozzá egy IAutoShape elemet, és törölje az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és állítsa be a jel szimbólumaikat.
4. Állítsa be az IParagraphFormat.setDepth értékeiket `0`, `1`, `2`, és `3`.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

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

### **Számozott listaelemek kezdése egyedi értékekkel**

Az IBulletFormat.setNumberedBulletStartWith használatával állítható be a számozott bekezdés kezdeti száma.

1. Hozzon létre egy Presentation példányt, és adjon hozzá egy IAutoShape elemet egy diához.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be az IBulletFormat.setNumberedBulletStartWith értékét a megfelelő bekezdésekhez `2`, `3` és `7`.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

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

Az IParagraphFormat.setIndent használatával szabályozhatja egy bekezdés első sorának behúzását. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az IParagraphFormat.setMarginLeft metódust, ha az egész bekezdést szeretné eltolni. Használja az IParagraphFormat.setIndent-et, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző IParagraphFormat.setIndent értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a Presentation osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú IAutoShape elemet a diára.
4. Érje el az alakzat ITextFrame-jét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítsa be a számukra a különböző IParagraphFormat.setIndent értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

Ezzel a kóddal megtekintheti, hogyan állíthat be bekezdésbehúzást:

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

![Az első sor behúzása a bekezdéseknél](first_line_indent.png)

### **Függő behúzás beállítása**

Az úgynevezett függő behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides-ban ezt az IParagraphFormat.setIndent segítségével hozhatja létre. Negatív érték megadásával az első sor balra mozdul a bekezdés törzséhez képest.

Gyakorlatban az IParagraphFormat.setMarginLeft határozza meg a bekezdés törzs bal pozícióját, míg az IParagraphFormat.setIndent az első sor helyzetét a margóhoz képest. Függő behúzás létrehozásához adjon pozitív értéket a setMarginLeft-nek, és negatív értéket a setIndent-nek.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szószedet-bejegyzésekhez és egyéb bekezdésekhez, ahol a tördelés sorai a bekezdés törzs alá kell, hogy illeszkedjenek, nem pedig az első sor első karaktere alá.

1. Hozzon létre egy példányt a Presentation osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú IAutoShape elemet a diára.
4. Érje el az alakzat ITextFrame-jét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és adjon pozitív értéket az IParagraphFormat.setMarginLeft-nek minden bekezdéshez.
6. Adjon negatív értéket az IParagraphFormat.setIndentnek a függő behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

Ezzel a kóddal megtekintheti, hogyan állíthat be függő behúzást egy bekezdéshez:

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

![A bekezdések függő behúzása](hanging_indent.png)

### **Bekezdés végjellemzőinek beállítása**

IParagraph.setEndParagraphPortionFormat vezérli a bekezdés végejelzésének formázását. Az alábbi példa egy betűméretet és latin betűtípust rendel hozzá a második bekezdés végejelzéséhez:

1. Töltsön be egy Presentation-t, és érje el egy diát.
2. Adjon hozzá egy IAutoShape elemet, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon szövegszakaszokat hozzájuk.
4. Hozzon létre egy PortionFormat objektumot a második bekezdés végejelzéséhez.
5. Állítsa be az IBasePortionFormat.setFontHeight és az IBasePortionFormat.setLatinFont értékeket.
6. Rendelje hozzá a formátumot az IParagraph.setEndParagraphPortionFormat segítségével, és mentse a prezentációt.

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

Az IParagraph.getLinesCount használatával megszámolhatja, hány sort foglal el egy bekezdés a szöveg elrendezése után, beleértve az automatikus tördelést. Ez hasznos a szöveg hosszának és elrendezésének ellenőrzésénél a prezentációs sablonokban.

Egy bekezdés egy elem az ITextFrame.getParagraphs kollekcióban, és több megjelenített sort is elfoglalhat. A bekezdésen belüli explicit sortörés új sort hoz létre anélkül, hogy új bekezdést hozna létre. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy a szövegbe explicit sortöréseket illesztene. Ezért a bekezdések vagy sortörés karakterek számolása nem adja meg a megjelenített sorok számát.

Az alábbi példa létrehoz egy szöveges alakzatot, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A tördelés engedélyezve van, az automatikus méretezés le van tiltva, így az alakzat szélessége szabályozza a tördelést anélkül, hogy a szöveg automatikusan zsugorodna vagy az alakzat mérete változna. Az alakzat méretei pontokban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a szövegkeretben.

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

Az adott szöveg és méretek mellett a forma szűkítése növeli a sorok számát, míg a rövid szövegre cserélés csökkenti azt. A pontos számok változhatnak a betűkészlet rendelkezésre állása és helyettesítése, betűméret, margók, behúzás, tördelés és automatikus méretezés beállításai szerint. A sablon ellenőrzésekor használja a célkörnyezet számára tervezett betűkészleteket és elrendezési beállításokat.

Az egyedül a sorok száma nem határozza meg, hogy a szöveg túlcsordul-e a tárolóján. Az elérhető magasság, sor magasságok, bekezdés- és sorközök, valamint az automatikus méretezés viselkedése is számít; még egyetlen sor is túllépheti a rendelkezésre álló szélességet, ha a tördelés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

A ParagraphCollection.addFromHtml használatával HTML jelölőnyelvet konvertálhat bekezdésekké és szakaszokká egy szövegkeretben.

1. Hozzon létre egy példányt a Presentation osztályból.
2. Érje el egy diát, és adjon hozzá egy IAutoShape elemet.
3. Érje el az alakzat ITextFrame-jét, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a ParagraphCollection.addFromHtml-nek.
6. Mentse a módosított prezentációt.

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

### **Bekezdés szövegének exportálása HTML-be**

A ParagraphCollection.exportToHtml használatával egy kiválasztott bekezdéstartományt exportálhat HTML-ként.

1. Hozzon létre egy Presentation példányt, és töltse be a kívánt prezentációt.
2. Érje el a diát, és keresse meg a szöveget tartalmazó IAutoShape elemet.
3. Érje el az alakzat ITextFrame-jét.
4. Hívja meg a ParagraphCollection.exportToHtml-t a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszaadott HTML karakterláncot egy fájlba.

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

Az IParagraph.getImage közvetlenül renderel egyetlen bekezdést, és visszaad egy IImage objektumot. A kapott eredményt fájlba vagy streambe mentheti az IImage.save segítségével. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan kivágni.

Az IParagraph.getImage null értéket adhat vissza, ha a bekezdés nem található a szülő kollekcióban, nincs érvényes renderelési határa, vagy nem renderelhető. Mentés előtt ellenőrizze az eredményt, és használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezéssel**

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést rendereli egy normál szöveges alakzatban alapértelmezett méretezéssel, és a kapott képet PNG formátumban menti. A `finally` blokk biztosítja, hogy a kép helyesen legyen felszabadítva.

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

![A bekezdés képe](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázatcellában skálázással**

Használja az IParagraph.getImage túltöltését, amely `float scaleX` és `float scaleY` paramétereket fogad, a vízszintes és függőleges méretezési tényezők beállításához. Az alábbi példa létrehoz egy táblázatot, a bekezdést az első cellájában kétszeres alap szélesség és magasság mellett rendereli, és az eredményt PNG képként menti.

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

A `1` méretezési tényező az adott tengelyt az alap pixelméretén tartja. Például a `2` mindkét tényező esetén egy olyan képet eredményez, amelynek szélessége és magassága nagyjából duplája az alap méreteknek, ezáltal négyzetes számú pixel keletkezik. A nagyobb tényezők általában élesebb szöveget biztosítanak nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb, részletgazdagabb képeket eredményeznek. Az egyenlő tényezők használata megőrzi a bekezdés képarányát; a különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

Egy teljes alakzat renderelése az IShape.getImage segítségével akkor is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Ha csak bekezdésképet szeretne, használja az IParagraph.getImage-t.

## **GYIK**

**Teljesen letilthatom a sortördelést egy szövegkereten belül?**

Igen. Az ITextFrameFormat.setWrapText beállításával letilthatja a tördelést, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan szerezhetem meg egy adott bekezdés pontos dián lévő határait?**

Az IParagraph.getRect segítségével lekérheti a bekezdés határoló téglalapját. Az IPortion.getRect egy adott szakasz határait adja vissza.

**Hol szabályozzák a bekezdés igazítását (balra, jobbra, középre vagy sorkizárt)?**

Az IParagraphFormat.setAlignment bekezdés szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes szakaszok formázásától.

**Beállíthatam-e a helyesírási nyelvet egy bekezdés részére?**

Igen. Az IBasePortionFormat.setLanguageId beállításával egyes szakaszoknál megadható a nyelv, így egy bekezdés több nyelven is tartalmazhat szöveget.