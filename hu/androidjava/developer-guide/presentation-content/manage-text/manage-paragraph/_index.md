---
title: PowerPoint szöveg bekezdések kezelése Androidon
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- pont kezelése
- bekezdés behúzása
- függő behúzás
- bekezdés felsorolásjel
- számozott lista
- felsorolt lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmat és bekezdés képeket az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java a szöveget szövegkeretek, bekezdések és részek hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) a szövegtároló egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést ad a részeihez valamint a bekezdés‑szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) egy szövegrészt jelöl egy bekezdésen belül. Minden résznek saját szövege és karakter‑szintű formázása lehet.

Egy bekezdés tehát különböző betűtípusokkal, színekkel, méretekkel és egyéb formázással rendelkező szöveget tartalmazhat több rész használatával.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több részlettel**

Az alábbi lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. A megfelelő diát indexével érje el.
3. Adj hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diához.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑ét.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) objektumot a szövegkerethez.
6. Adj elegendő [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter‑szintű formázást az [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--) segítségével.
9. Mentse a módosított bemutatót.

Ez a Android via Java példa megvalósítja a lépéseket:

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

## **Felsorolási és számozott listák létrehozása**

### **Felsorolt vagy számozott lista létrehozása**

A felsorolások és számozás megkönnyítik a kapcsolódó elemek átláthatóságát. Az Aspose.Slides‑ben a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) definiálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. A megfelelő diát indexével érje el.
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a kiválasztott diához.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑ét.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) elemet egy szimbólum‑ponthoz.
7. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/)‑ra, és adja meg a pont karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, pont színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/)‑ra.
11. Konfigurálja a számozott pont stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a bemutatót.

Ez az Android via Java példa egy szimbólum‑pontot és egy számozott pontot hoz létre:

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

### **Képjelölő pontok használata**

A képjelölő pontok lehetővé teszik egy egyéni kép használatát szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. A megfelelő diát indexével érje el.
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet, és érje el annak [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑ét.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a pont képet, és adja hozzá a prezentáció képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)‑ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-int-) értékét a [BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/)‑ra.
8. Rendelje hozzá a képet az [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--) segítségével, és állítsa be a pont magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított bemutatót.

Ez az Android via Java példa egy kép‑pontot hoz létre:

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

Állítsa be az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) értékét, hogy a bekezdéseket a lista különböző szintjein helyezze el. A felső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet, és törölje le az alapértelmezett bekezdést a szövegkeretéből.
3. Hozzon létre négy bekezdést, és konfigurálja azok pontszimbólumait.
4. Állítsa be a [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) értékeit `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a bemutatót.

Ez az Android via Java példa egy négy szintű felsorolt listát hoz létre:

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

Használja az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metódust, hogy a számozott bekezdés kezdeti számát állítsa be.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) elemet, és adj egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet egy diára.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét `2`, `3` és `7`‑re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a bemutatót.

Ez az Android via Java példa egy egyéni kezdőszámmal rendelkező bekezdést állít be:

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

## **Bekezdéselrendezés és befejezési tulajdonságok vezérlése**

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust az első sor behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolatja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódust, ha az egész bekezdést szeretné mozgatni. Az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) csak az első sort érinti.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja a bekezdéselrendezést az első sor behúzása.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el a céldiát.
3. Adj hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diához.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑ét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket számukra.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állítsa be egy bekezdés behúzását:

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

### **Függő behúzás beállítása**

A függő behúzás olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt az effektust az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-)‑vel érhetjük el, negatív érték megadásával mozdítva az első sort balra a bekezdéstörzshöz képest.

Gyakorlatban az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) határozza meg a bekezdés törzs bal pozícióját, az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pedig az első sor relatív pozícióját ehhez a margóhoz. A függő behúzás létrehozásához állítsa be a `setMarginLeft`‑t pozitív értékre, és a `setIndent`‑t negatív értékre.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és más bekezdések esetén, ahol a sortöréseknek a bekezdés törzsének alá kell illeszkedniük, nem pedig az első karakter alá.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el a céldiát.
3. Adj hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diához.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑ét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon bekezdéseket, és állítson pozitív értéket az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)‑nek minden bekezdéshez.
6. Állítson negatív értéket az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-)‑nek, hogy létrehozza a függő behúzást.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állítsa be egy bekezdés függő behúzását:

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

![A bekezdések függő behúzása](hanging_indent.png)

### **A bekezdés befejező rész tulajdonságainak beállítása**

Az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) szabályozza a bekezdés végjelzésének formázását. Az alábbi példa betűméretet és latin betűtípust állít be a második bekezdés végjelzésére:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adj egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet, és törölje a alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) objektumot a második bekezdés végjelzéséhez.
5. Állítsa be az [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) és az [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) értékeket.
6. Rendelje hozzá a formátumot az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) metódussal, majd mentse a bemutatót.

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

A bekezdés szabályaival, amelyek az automatikus sortörést és a sorvégeken lévő központozást befolyásolják, lásd a [Vonalak törésének vezérlése](/slides/hu/androidjava/text-formatting/#control-line-breaking) és a [Függő központozás vezérlése](/slides/hu/androidjava/text-formatting/#control-hanging-punctuation) című oldalakat.

Használja az [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) metódust a bekezdés által a szövegelrendezés után elfoglalt sorok számának megszámolásához, beleértve az automatikus sortörést. Ez hasznos a szöveghossz és elrendezés ellenőrzésénél prezentációs sablonokban.

Egy bekezdés egy elem az [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) gyűjteményében, és több megjelenített sort is elfoglalhat. Egy expliciten beillesztett sortörés a bekezdésen belül új sort eredményez anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicit sortöréseket illesztene be a szövegbe. Ezért a bekezdések vagy sortörés karakterek számlálása nem adja meg a megjelenített sorok számát.

Az alábbi példa létrehoz egy szöveges alakzatot, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A sortörés engedélyezett, az automatikus méretezés (autofit) le van tiltva, így a forma szélessége szabályozza a sortörést anélkül, hogy a szöveget vagy a formát automatikusan kicsinyítené. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát az egész szövegkeretben.

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

Ezzel a szöveggel és méretekkel a forma szűkítése növeli a sorok számát, míg a szöveg rövid változatra cserélése csökkenti azt. A pontos számok a betűkészlet elérhetőségétől, helyettesítésétől, betűmérettől, margóktól, behúzástól, sortöréstől és az autofit beállításoktól függenek. A célkörnyezetben használandó betűtípusokat és elrendezési beállításokat alkalmazza sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túllépi-e a tárolóját. A rendelkezésre álló magasság, a sortávolságok, a bekezdés‑ és sorközök, valamint az autofit viselkedés is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a sortörés ki van kapcsolva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódust HTML jelölés konvertálásához bekezdésekké és részekké egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Érje el egy diát, és adj egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet.
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑ét, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML‑fájlt.
5. Adja át a HTML‑szöveget a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak.
6. Mentse a módosított bemutatót.

Ez az Android via Java példa HTML‑t importál egy szövegkeretbe:

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

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kiválasztott bekezdéstartomány HTML‑ként történő exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.
2. Érje el a diát, és keresse meg a szöveget tartalmazó [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet.
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑ét.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML‑szöveget egy fájlba.

Ez az Android via Java példa az első szöveges alakzat összes bekezdését exportálja:

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

Az [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) egy egyedi bekezdést renderel közvetlenül, és egy [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) objektumot ad vissza. Az eredményt fájlba vagy adatfolyamba mentheti az [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metódussal. Nem szükséges a szülő alakzatot renderelni vagy képet manuálisan vágni.

Az [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) null értéket adhat vissza, ha a bekezdés nem található a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett mérettel**

Tegyük fel, hogy van egy *sample.pptx* nevű bemutatófájl egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy szabályos szövegdobozban rendereli alapértelmezett mérettel, és a visszakapott képet PNG formátumban menti. A **finally** blokk biztosítja, hogy a kép helyesen legyen felszabadítva.

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

#### **Bekezdés renderelése táblázatcellában nagyítással**

Használja az [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) túlterhelést, amely a `float scaleX` és `float scaleY` paramétereket fogadja, a vízszintes és függőleges méretezési tényezők beállításához. Az alábbi példa egy táblázatot hoz létre, és a bekezdést az első cellájában duplájára méretezi, majd PNG képként menti az eredményt.

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

Az `1` érték megtartja az adott tengelyt az alapértelmezett pixelméretben. Például a `2` mindkét tényezőnél olyan képet eredményez, amelynek szélessége és magassága körülbelül kétszerese az alapértelmezett méretnak, így a pixelek száma négyszeresre nő. A nagyobb tényezők általában élesebb szöveget biztosítanak nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb, részletgazdagabb képet eredményeznek. Használjon egyenlő tényezőket az oldalarány megőrzéséhez; a különböző vízszintes és függőleges tényezők önállóan nyújtják a képet.

A teljes alakzat renderelése az [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) segítségével akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, keretét vagy egyéb vizuális kontextusát. Egy kizárólag bekezdés‑képhoz használja az [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) metódust.

## **GYIK**

**Teljesen letiltható a sortörés egy szövegkereten belül?**

Igen. Állítsa az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) értékét a sortörés letiltásához, így a sorok nem törnek a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos helyi határait a dián?**

Használja az [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) metódust a bekezdés körülhatároló téglalap lekéréséhez. Az [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) egyetlen rész határait adja vissza.

**Hol van a bekezdés igazítása (balra, jobbra, középre vagy sorkizárás) szabályozva?**

Az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) bekezdés‑szintű beállítás, amely az egész bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

A különböző betűméretű részek függőleges igazításához egy soron belül lásd a [Betűk soron belüli igazítása](/slides/hu/androidjava/text-formatting/#align-fonts-within-a-line) útmutatót.

**Beállítható-e a helyesírási nyelv egy bekezdés részére?**

Igen. Állítsa be az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) értékét egyes részeknél, így egy bekezdés több nyelven írt szöveget is tartalmazhat.