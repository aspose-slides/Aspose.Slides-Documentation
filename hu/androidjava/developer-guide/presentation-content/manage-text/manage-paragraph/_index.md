---
title: PowerPoint szövegbekezdések kezelése Androidon
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/androidjava/manage-paragraph/
aliases:
  - /androidjava/bekezdes/
  - /androidjava/szakasz/
keywords:
  - szöveg hozzáadása
  - bekezdés hozzáadása
  - szöveg kezelése
  - bekezdés kezelése
  - golyó kezelése
  - bekezdés behúzása
  - függőleges behúzás
  - bekezdés golyó
  - számozott lista
  - felsoroláslista
  - bekezdés tulajdonságok
  - HTML importálása
  - szöveg HTML-re
  - bekezdés HTML-re
  - bekezdés képbe
  - szöveg képpé
  - bekezdés exportálása
  - PowerPoint
  - bemutató
  - Android
  - Java
  - Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, felsorolásjeleket, számozott listákat, behúzásokat, HTML‑tartalmat és bekezdésképeket az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Android via Java a szöveget szövegdobozok, bekezdések és szakaszok hierarchiájában ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) a szövegkonténert egy alakzatban képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegdobozban, és hozzáférést biztosít a szakaszokhoz és a bekezdés-szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) egy szövegrészt képvisel egy bekezdésen belül. Minden szakasz saját szöveggel és karakter-szintű formázással rendelkezhet.

Ezáltal egy bekezdés különböző betűtípusokkal, színekkel, méretekkel és egyéb formázásokkal rendelkező szöveget tartalmazhat több szakasz használatával.

## **Bebe​dzések létrehozása és formázása**

### **Bebe​dzések létrehozása több szakaszszal**

Az alábbi lépések egy szövegdobozt hoznak létre három bekezdéssel, mindegyik három szakaszt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő diát a indexén keresztül.
3. Adjon egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) részéhez.
5. Használja az alapértelmezett bekezdést, és adjon hozzá még két [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) objektumot a szövegdobozhoz.
6. Adjon elegendő [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három szakaszt tartalmazzanak. Az alapértelmezett bekezdés már tartalmaz egy üres szakaszt.
7. Állítsa be minden szakasz szövegét.
8. Alkalmazzon karakter‑szintű formázást az [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#getPortionFormat--) segítségével.
9. Mentse a módosított bemutatót.

Ez az Android via Java példa megvalósítja a lépéseket:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Felsorolások és számozott listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A golyók és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides‑ben a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő diát a indexén keresztül.
3. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) részéhez.
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) elemet egy szimbólum golyóhoz.
7. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-int-) értékét [BulletType.Symbol](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/)‑ra, és adja meg a golyó karaktert.
8. Állítsa be a bekezdés szövegét, behúzását, golyó színét és golyó magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Hozzon létre egy második bekezdést, és állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-int-) értékét [BulletType.Numbered](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/)‑ra.
11. Konfigurálja a számozott golyó stílusát, és adja hozzá a bekezdést a szövegdobozhoz.
12. Mentse a bemutatót.

Ez az Android via Java példa egy szimbólum golyót és egy számozott golyót hoz létre:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Képgolyók használata**

A képgolyók lehetővé teszik egy egyedi kép használatát a szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő diát a indexén keresztül.
3. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet, és férjen hozzá annak [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) részéhez.
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
5. Töltse be a golyó képet, és adja hozzá a bemutató képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/)‑ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-int-) értékét [BulletType.Picture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/)‑ra.
8. Rendelje hozzá a képet az [IBulletFormat.getPicture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#getPicture--) segítségével, és állítsa be a golyó magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Mentse a módosított bemutatót.

Ez az Android via Java példa egy képgolyót hoz létre:

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

Állítsa be az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) elemet, és férjen hozzá egy diához.
2. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet, és távolítsa el az alapértelmezett bekezdést a szövegdobozából.
3. Hozzon létre négy bekezdést, és konfigurálja a golyó szimbólumaikat.
4. Állítsa be azok [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) értékeit `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, és mentse a bemutatót.

Ez az Android via Java példa egy négy szintű golyós listát hoz létre:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Használja az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metódust a számozott bekezdés kezdeti számának beállításához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) elemet, és adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet egy diára.
2. Távolítsa el az alapértelmezett bekezdést az alakzat szövegdobozából.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét `2`, `3` és `7`‑re az egyes bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, és mentse a bemutatót.

Ez az Android via Java példa egyedi kezdőszámot rendel minden bekezdéshez:

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

## **Beke​dzés elrendezésének és végjellemzőinek vezérlése**

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a módszer csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés testhez igazodik.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódust, ha az egész bekezdést szeretné eltolni. Az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) csak az első sort mozgatja.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értékekkel mutatja be, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt.
2. Hozzáférés a cél diához.
3. Adjon egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) részéhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állíthat be bekezdés behúzást:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Függőleges (hanging) behúzás beállítása**

A függőleges behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt az effektust az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) negatív értékével érheti el, amely az első sort balra mozdítja a bekezdés testhez képest.

Gyakorlatban az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) határozza meg a bekezdés test bal pozícióját, míg az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) az első sor pozícióját ezen a margón belül. A függőleges behúzás létrehozásához adjon pozitív értéket a `setMarginLeft`‑nak, és negatív értéket a `setIndent`‑nek.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szószedet-bejegyzésekhez és más bekezdésekhez, ahol a tördelő soroknak a bekezdés test alatt kell igazodniuk, nem pedig az első sor első karaktere alatt.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt.
2. Hozzáférés a cél diához.
3. Adjon egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) részéhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és adjon pozitív értéket minden bekezdéshez az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódussal.
6. Adjon negatív értéket az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódusnak a függőleges behúzás hatásának eléréséhez.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állíthat be függőleges behúzást egy bekezdéshez:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Befejező bekezdés‑szakasz formátumának beállítása**

Az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) a bekezdés végjelet formázza. Az alábbi példa a második bekezdés végjeléhez állít be betűméretet és latin betűtípust:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) fájlt, és férjen hozzá egy diához.
2. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegszakaszokat.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portionformat/) objektumot a második bekezdés végjeléhez.
5. Állítsa be az [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) és az [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) értékeket.
6. Rendelje hozzá a formátumot az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) segítségével, és mentse a bemutatót.

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

## **Beke​dzés tartalmának importálása és exportálása**

### **HTML‑szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódust a HTML‑jelölés bekezdésekké és szakaszokká konvertálásához egy szövegdobozban.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt.
2. Hozzáférés egy diához, és adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet.
3. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) részéhez, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás‑HTML fájlt.
5. Adja át a HTML‑karakterláncot a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak.
6. Mentse a módosított bemutatót.

Ez az Android via Java példa HTML‑t importál egy szövegdobozba:

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

### **Beke​dzés‑szöveg exportálása HTML‑be**

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kiválasztott bekezdéstartomány HTML‑ként történő exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt, és töltse be a kívánt bemutatót.
2. Hozzáférés a diához, és keresse meg a szöveget tartalmazó [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet.
3. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) részéhez.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszaadott HTML‑karakterláncot fájlba.

Ez az Android via Java példa az első szöveges alakzatról exportálja az összes bekezdést:

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

### **Beke​dzés renderelése képként**

Az [IParagraph.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getImage--) egyedi bekezdést renderel közvetlenül, és visszaad egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektumot. Mentse az eredményt fájlba vagy streambe az [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metódussal. Nem szükséges a szülő alakzatot renderelni vagy a bitmapet manuálisan levágni.

Az [IParagraph.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getImage--) `null`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Beke​dzés renderelése az alapértelmezett méretezéssel**

Tegyük fel, hogy van egy `sample.pptx` nevű bemutatófájl egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést rendeli a szabályos szövegalkotáshoz alapértelmezett méretben, és PNG formátumban menti a visszakapott képet. A `finally` blokk biztosítja a kép helyes felszabadítását.

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

#### **Beke​dzés renderelése táblázatcellában méretezéssel**

Használja az [IParagraph.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) túlterhelést, amely `float scaleX` és `float scaleY` paramétereket fogad, hogy beállítsa a vízszintes és függőleges skálafaktorokat. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellában duplájára méretezi, és PNG képként menti az eredményt.

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

Az `1` skálafaktor megtartja az adott tengely alapértelmezett pixelméretét. Például a `2` mindkét tényezőnél olyan képet eredményez, amelynek szélessége és magassága megközelítőleg kétszerese az alapértelmezett dimenzióknak, így négyzetgyöke négy egységnyi pixel. A nagyobb faktorek általában élesebb szöveget adnak nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti faktorek kisebb, részletgazdagabb képet eredményeznek. Egyenlő faktorekkel megőrizhető a bekezdés arány, míg a különböző vízszintes és függőleges faktorek önállóan nyújtják a képet.

Az egész alakzat renderelése az [IShape.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getImage--) metódussal akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csupán bekezdés‑képre csak az [IParagraph.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getImage--) elegendő.

## **GYIK**

**Teljesen letiltható a sortörés egy szövegdobozban?**

Igen. Állítsa az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) értékét a sorok szélek mentén való törésének letiltásához.

**Hogyan kapható meg egy adott bekezdés pontos diára vonatkozó határa?**

Használja az [IParagraph.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getRect--) metódust a bekezdés körülhatároló téglalap lekéréséhez. Az [IPortion.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#getRect--) egyedi szakasz határait adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

Az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) egy bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyedi szakaszformázástól.

**Beállítható a nyelvi helyesírás-ellenőrzés egy bekezdés részére?**

Igen. Állítsa az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) értékét egyedi szakaszokra, így egy bekezdés több nyelven írt szöveget is tartalmazhat.