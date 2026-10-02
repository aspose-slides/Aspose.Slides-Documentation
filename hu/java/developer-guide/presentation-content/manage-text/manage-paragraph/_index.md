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
- bekezdés behúzás
- függő behúzás
- bekezdés felsorolás
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
description: "Tanulja meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmat és bekezdésképeket az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Java a szöveget szövegdobozok, bekezdések és részek hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) a szövegtároló egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.  
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) egy bekezdést ábrázol egy szövegdobozban, és hozzáférést ad a részekhez és a bekezdés szintű formázáshoz.  
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) egy szövegrészt jelöl egy bekezdésen belül. Minden résznek lehet saját szövege és karakter szintű formázása.

Egy bekezdés ezért több részt felhasználva tartalmazhat különböző betűtípusú, színű, méretű és egyéb formázású szöveget.

## **Bekezdések létrehozása és formázása**

### **Több részt tartalmazó bekezdések létrehozása**

A következő lépések egy szövegdobozt hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.  
2. Érje el a megfelelő diát az indexén keresztül.  
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot a diára.  
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).  
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) objektumot a szövegdobozhoz.  
6. Adjon elegendő [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alapértelmezett bekezdés már tartalmaz egy üres részt.  
7. Állítsa be minden rész szövegét.  
8. Alkalmazzon karakter szintű formázást az [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) segítségével.  
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

## **Felsorolás- és számozott listák létrehozása**

### **Felsorolás- vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides esetén a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.  
2. Érje el a megfelelő diát az indexén keresztül.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot a kiválasztott diához.  
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).  
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.  
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) objektumot egy szimbólum felsoroláshoz.  
7. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) értékre, és adja meg a felsorolás karakterét.  
8. Állítsa be a bekezdés szövegét, a behúzást, a felsorolás színét és magasságát.  
9. Adja hozzá a bekezdést a szövegdobozhoz.  
10. Hozzon létre egy második bekezdést, és állítsa az [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) értékre.  
11. Konfigurálja a számozott felsorolás stílusát, és adja hozzá a bekezdést a szövegdobozhoz.  
12. Mentse a bemutatót.

Ez a Java példa egy szimbólum felsorolást és egy számozott felsorolást hoz létre:

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

### **Képes felsorolások használata**

A képes felsorolások lehetővé teszik, hogy egy egyedi képet használjon szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.  
2. Érje el a megfelelő diát az indexén keresztül.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot, és érje el annak [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) elemét.  
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.  
5. Töltse be a felsorolás képet, és adja hozzá a bemutató képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)ként.  
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) objektumot, és állítsa be a szövegét.  
7. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) értékre.  
8. Rendelje hozzá a képet az [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) segítségével, és állítsa be a felsorolás magasságát.  
9. Adja hozzá a bekezdést a szövegdobozhoz.  
10. Mentse a módosított bemutatót.

Ez a Java példa egy képes felsorolást hoz létre:

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

Állítsa be az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A felső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) objektumot, és érje el egy diát.  
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot, és tisztítsa meg az alapértelmezett bekezdést a szövegdobozából.  
3. Hozzon létre négy bekezdést, és konfigurálja azok felsorolás szimbólumait.  
4. Állítsa be azok [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) értékeit `0`, `1`, `2`, és `3`‑ra.  
5. Adja a bekezdéseket a szövegdobozhoz, és mentse a bemutatót.

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

### **Számozott listaelemek kezdőértékének egyedi beállítása**

Használja a [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metódust a számozott bekezdés kiinduló számának beállításához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) objektumot, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot a diához.  
2. Törölje az alapértelmezett bekezdést az alakzat szövegdobozából.  
3. Hozzon létre három számozott bekezdést.  
4. Állítsa be a [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét a megfelelő bekezdésekhez `2`, `3`, és `7`-re.  
5. Adja a bekezdéseket a szövegdobozhoz, és mentse a bemutatót.

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

Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust egy bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódust, ha az egész bekezdést szeretné elmozdítani. Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust, ha csak az első sort szeretné elmozdítani.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.  
2. Érje el a cél diát.  
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot a diára.  
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) és távolítsa el az alapértelmezett bekezdést.  
5. Hozzon létre több bekezdést, és állítson be különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket azoknál.  
6. Adja a bekezdéseket a szövegdobozhoz.  
7. Mentse a módosított bemutatót.

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

### **Függő behúzás beállítása**

A függő behúzás egy bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ban ezt az effektust az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) segítségével hozhatja létre. Negatív értéket adjon meg, hogy az első sor balra mozduljon a bekezdés törzséhez képest.

A gyakorlatban az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) határozza meg a bekezdés törzsének bal pozícióját, az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pedig az első sor helyzetét ehhez a margóhoz képest. Függő behúzás létrehozásához adjon pozitív értéket a `setMarginLeft`‑nek, és negatív értéket a `setIndent`‑nek.

Ezt a formázást bibliográfiák, hivatkozások, szójegyzék bejegyzések és más bekezdések esetén használják, ahol a sortörés utáni soroknak a bekezdés törzsének alá kell igazodniuk, nem pedig az első sor első karaktere alá.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.  
2. Érje el a cél diát.  
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot a diára.  
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) és távolítsa el az alapértelmezett bekezdést.  
5. Hozzon létre bekezdéseket, és minden bekezdéshez adjon meg egy pozitív értéket az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) számára.  
6. Adjon negatív értéket az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) számára, hogy létrehozza a függő behúzást.  
7. Adja a bekezdéseket a szövegdobozhoz.  
8. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állíthat be függő behúzást egy bekezdéshez:

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

### **A bekezdés végén lévő futás tulajdonságainak beállítása**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) szabályozza a bekezdés végjelének formázását. A következő példa betűméretet és latin betűtípust rendel a második bekezdés végjeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) objektumot, és érje el egy diát.  
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot, és törölje az alapértelmezett bekezdését.  
3. Hozzon létre két bekezdést, és adjon hozzá szövegrésszeket.  
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) objektumot a második bekezdés végjeléhez.  
5. Állítsa be az [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) és az [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) értékeket.  
6. Rendelje hozzá a formázást az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) segítségével, és mentse a bemutatót.

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

## **Megjelenített sorok számlálása**

A bekezdés szabályok, amelyek az automatikus sortörést és a sorvégi írásjeleket befolyásolják, lásd: [Control Line Breaking](/slides/hu/java/text-formatting/#control-line-breaking) és [Control Hanging Punctuation](/slides/hu/java/text-formatting/#control-hanging-punctuation).

Használja az [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) metódust a bekezdés által elfoglalt sorok számolásához a szöveg elrendezése után, beleértve az automatikus sortörést. Ez hasznos a szöveg hossza és elrendezése ellenőrzésénél a bemutatói sablonokban.

Egy bekezdés az [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) egy eleme, és több megjelenített sort is elfoglalhat. Egy explicit sortörés a bekezdésen belül új sort kényszerít anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz sorokat, anélkül, hogy explicit sortöréseket illesztene a szövegbe. A bekezdések vagy sortörő karakterek számlálása ezért nem adja meg a megjelenített sorok számát.

A következő példa egy szöveg alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A sortörés engedélyezett, az automatikus méretezés le van tiltva, így az alakzat szélessége szabályozza a sortörést, anélkül, hogy a szöveget automatikusan lecsökkentené vagy az alakzat méretét módosítaná. Az alakzat méretei pontban vannak megadva. Végül a példa egy további bekezdést ad hozzá, és összeadja a sorok számát a szövegdobozban.

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

Ezzel a szöveggel és ezekkel a méretekkel a alakzat szűkítése megnöveli a sorok számát, míg a szöveg rövid karakterláncra cserélése csökkenti azt. A pontos számok változhatnak a betűkészlet elérhetősége és helyettesítése, betűméret, margók, behúzás, sortörés és automatikus méretezés beállításai alapján. A sablon ellenőrzésekor használja a célkörnyezetnek szánt betűtípusokat és elrendezési beállításokat.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlcsordul-e a tárolóján. Az elérhető magasság, sormagasságok, bekezdés- és sorköz, valamint az automatikus méretezés viselkedése is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

A [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) használatával HTML jelölőnyelvet alakíthat bekezdésekké és részekké egy szövegdobozban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.  
2. Érje el egy diát, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot.  
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) és távolítsa el az alapértelmezett bekezdést.  
4. Olvassa be a forrás HTML fájlt.  
5. Adja át a HTML karakterláncot a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak.  
6. Mentse a módosított bemutatót.

Ez a Java példa HTML-t importál egy szövegdobozba:

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

A [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) segítségével exportálhat egy kijelölt bekezdéssort HTML-ként.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) példányt, és töltse be a kívánt bemutatót.  
2. Érje el a diát, és keresse meg a szöveget tartalmazó [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot.  
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).  
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.  
5. Írja a visszaadott HTML karakterláncot egy fájlba.

Ez a Java példa exportálja az összes bekezdést az első szövegdobozból:

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

Az [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) közvetlenül rendereli az egyes bekezdést, és egy [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) objektumot ad vissza. A végeredményt fájlba vagy adatfolyamba mentheti az [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) segítségével. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan vágni.

Az [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) `null` értéket adhat vissza, ha a bekezdés nem található a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretben**

Tegyük fel, hogy van egy sample.pptx nevű bemutató fájlunk, egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

A következő példa a második bekezdést egy normál szövegdobozban alapértelmezett méretben rendereli, és a visszakapott képet PNG formátumban menti. A `finally` blokk biztosítja, hogy a kép helyesen legyen felszabadítva.

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

Használja az [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) túlterhelését, amely elfogadja a `float scaleX` és `float scaleY` paramétereket a vízszintes és függőleges méretezési tényezők beállításához. A következő példa egy táblázatot hoz létre, a bekezdést az első cellájában a normál szélesség és magasság kétszeresén rendereli, és az eredményt PNG képként menti.

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

Egy `1` skálafaktor megtartja az adott tengely alapértelmezett képméretét. Például, ha mindkét tényező `2`, akkor a kép szélessége és magassága körülbelül a normál méretek duplája lesz, ami négyszeres képpontszámot eredményez. Nagyobb tényezők általában élesebb szöveget adnak nagyításhoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb képeket eredményeznek kevesebb részlettel. Használjon egyenlő tényezőket a bekezdés képarányának megtartásához; a különböző vízszintes és függőleges tényezők függetlenül nyújtják a kimenetet.

Egy teljes alakzat renderelése az [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) segítségével továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy más vizuális kontextusát. Egy csak bekezdést tartalmazó képhez használja az [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) metódust.

## **GYIK**

**Teljesen le tudom tiltani a sortörést egy szövegdobozban?**  
Igen. Állítsa az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) értékét a sortörés letiltásához, így a sorok nem törnek meg a szövegdoboz szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián látható határait?**  
Használja az [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) metódust a bekezdés határoló téglalapjának lekéréséhez. Az [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) egy adott rész határait adja meg.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**  
Az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) bekezdés szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.  
A soron belül a különböző betűméretű részek függőleges igazításához lásd: [Align Fonts Within a Line](/slides/hu/java/text-formatting/#align-fonts-within-a-line).

**Beállíthatom a helyesírási nyelvet a bekezdés egy részére?**  
Igen. Az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) beállítható egyes részekhez, így egy bekezdés több nyelvű szöveget is tartalmazhat.