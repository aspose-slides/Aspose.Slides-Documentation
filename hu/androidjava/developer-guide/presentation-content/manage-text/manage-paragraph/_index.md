---
title: PowerPoint szöveg bekezdéseinek kezelése Androidon
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
- jelölő kezelése
- bekezdés behúzása
- függőleges behúzás
- bekezdés jelölő
- számozott lista
- felsorolt lista
- bekezdés tulajdonságai
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képként
- szöveg képként
- bekezdés exportálása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, jelölőket, számozott listákat, behúzásokat, HTML tartalmakat és bekezdésképeket az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java a szöveget a szövegkeretek, bekezdések és szakaszok hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) a szöveg tárolója egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményhez.
* [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít annak szakaszaihoz és a bekezdés szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) egy szövegrészt képvisel egy bekezdésen belül. Minden résznek saját szövege és karakter szintű formázása lehet.

Egy bekezdés tehát több szakasz használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Besorozott szakaszokkal rendelkező bekezdések létrehozása**

A következő lépések egy három bekezdésből álló szövegkeretet hoznak létre, mindegyik három szakaszt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexe alapján érje el.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) a diához.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)-jét.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) objektumot a szövegkerethez.
6. Adj hozzá elegendő [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) objektumot, hogy minden bekezdés három szakaszt tartalmazzon. Az alapértelmezett bekezdés már tartalmaz egy üres szakaszt.
7. Állítsa be minden szakasz szövegét.
8. Alkalmazzon karakter szintű formázást a [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#getPortionFormat--) segítségével.
9. Mentse a módosított prezentációt.

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

## **Felsorolás és számozott lista létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A felsorolások és számozások megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/) definiálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexe alapján érje el.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)-jét.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) objektumot egy szimbólum jelölőhöz.
7. Állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-int-) értékét [BulletType.Symbol](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/) -ra, és adja meg a jelölő karaktert.
8. Állítsa be a bekezdés szövegét, behúzását, a jelölő színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-int-) értékét [BulletType.Numbered](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/) -ra.
11. Konfigurálja a számozott jelölő stílusát, majd adja hozzá a bekezdést a szövegkerethez.
12. Mentse a prezentációt.

Ez az Android via Java példa egy szimbólum jelölőt és egy számozott jelölőt hoz létre:

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

### **Képes jelölők használata**

A képes jelölőkkel egy egyéni képet használhat szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexe alapján érje el.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet, és érje el annak [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)-jét.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a jelölő képet, és adja hozzá a prezentáció képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/)ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) objektumot, és állítsa be a szövegét.
7. Állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-int-) értékét [BulletType.Picture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/) -ra.
8. Rendelje hozzá a képet a [IBulletFormat.getPicture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#getPicture--) segítségével, és állítsa be a jelölő magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított prezentációt.

Ez az Android via Java példa egy képes jelölőt hoz létre:

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

Állítsa be az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) értékét, hogy a bekezdéseket különböző lista szinteken helyezze el. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) objektumot, és nyisson meg egy diát.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és konfigurálja azok jelölő szimbólumait.
4. Állítsa be azok [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) értékeit `0`, `1`, `2` és `3`-ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a prezentációt.

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

### **Számozott lista elemek indítása egyedi értékekkel**

Használja az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metódust a számozott bekezdés kezdeti számának beállításához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) objektumot, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet egy diára.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét `2`, `3` és `7`-re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a prezentációt.

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

## **Bekezdéselrendezés és végjellemzők vezérlése**

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust az első sor behúzásának szabályozásához. Ez a metódus csak az első sort helyezi el a bekezdés bal margójához képest. Pozitív érték az első sort jobbra tolja, míg a többi sor a bekezdés törzséhez marad igazítva.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódust, ha a teljes bekezdést szeretné eltolni. Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja a bekezdéselrendezést az első sor behúzása.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt.
2. Érje el a céldiat.
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) -jét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be bekezdésbehúzást:

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

A függőleges behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides-ben ezt a hatást az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) használatával hozhatja létre. Negatív értékkel tolja balra az első sort a bekezdés törzséhez képest.

Gyakorlatban az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) meghatározza a bekezdés törzsének bal pozícióját, az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pedig az első sor helyzetét e margóhoz képest. Függőleges behúzáshoz adjon pozitív értéket a `setMarginLeft`-nek, és negatív értéket a `setIndent`-nek.

Ez a formázás különösen hasznos bibliográfiák, hivatkozások, szószedeti bejegyzések és egyéb bekezdések esetén, ahol a sortörésnek a bekezdés törzsénél kell igazodnia, nem pedig az első karakternél.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt.
2. Érje el a céldiat.
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) -jét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és minden bekezdéshez adjon pozitív értéket az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódusnak.
6. Adjon negatív értéket az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódusnak a függőleges behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

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

### **Befejező bekezdés részeinek beállítása**

Az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) vezérli a bekezdés zárójelezésének formázását. Az alábbi példa egy betűméretet és latin betűtípust rendel a második bekezdés zárójelezéséhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) fájlt, és érje el egy diát.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon szövegszakaszokat hozzájuk.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portionformat/) objektumot a második bekezdés zárójelezéséhez.
5. Állítsa be az [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) és az [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) értékeket.
6. Rendelje hozzá a formátumot az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) segítségével, majd mentse a prezentációt.

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

A bekezdés szabályai, amelyek az automatikus szövegeltörést és a sorvégi írásjelek kezelését érintik, megtalálhatók a [Control Line Breaking](/slides/hu/androidjava/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/androidjava/text-formatting/#control-hanging-punctuation) oldalakon.

Az [IParagraph.getLinesCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) metódus segítségével megszámolhatók a bekezdés által a szövegelrendezés után elfoglalt sorok, beleértve az automatikus sortörést. Ez hasznos a szöveghossz és elrendezés ellenőrzésénél prezentációs sablonokban.

Egy bekezdés egy elem a [ITextFrame.getParagraphs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParagraphs--) gyűjteményben, és több megjelenített sorban is megjelenhet. Egy explicit sortörés egy bekezdésen belül új sort hoz létre anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy explicit sortörő karaktereket illesztene be a szövegbe. A bekezdések vagy sortörő karakterek számlálása ezért nem ad helyes megjelenített sor számot.

Az alábbi példa egy szöveges alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd egy rövidebb szöveggel helyettesíti a tartalmat. A sortörés engedélyezve van, az automatikus illeszkedés (autofit) pedig le van tiltva, így a forma szélessége szabályozza a sortörést anélkül, hogy a szöveg automatikusan zsugorodna vagy a forma átméreteződne. A forma méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összegzi a sorok számát a szövegkeretben.

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

Ezekkel a szövegekkel és méretekkel a forma szűkítése növeli a sorok számát, míg a rövidebb szövegre cseréje csökkenti azt. A pontos számok a betűkészlet elérhetőségétől, helyettesítésétől, betűmérettől, margóktól, behúzástól, sortöréstől és az autofit beállításoktól függnek. A célkörnyezethez szánt betűkészleteket és elrendezési beállításokat használja a sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg kileng-e a tárolóból. A rendelkezésre álló magasság, sormagasságok, bekezdés- és sorköz, valamint az autofit viselkedése is számít; még egy sor is túllépheti a rendelkezésre álló szélességet, ha a sortörés ki van kapcsolva.

## **Bekezdés tartalom importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódust HTML jelölés átalakításához bekezdésekké és szakaszokká egy szövegkeretben.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt.
2. Nyisson meg egy diát, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet.
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) -jét, és tisztítsa meg az alapértelmezett bekezdéstől.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML sztringet a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak.
6. Mentse a módosított prezentációt.

Ez az Android via Java példa HTML-t importál egy szövegkeretbe:

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

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kiválasztott bekezdéstartomány HTML-ként történő exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt, és töltse be a kívánt prezentációt.
2. Nyissa meg a diát, és keresse meg a szöveget tartalmazó [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet.
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) -jét.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja ki a visszakapott HTML sztringet egy fájlba.

Ez az Android via Java példa az első szövegkeret összes bekezdését exportálja:

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

Az [IParagraph.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getImage--) metódus egy egyedi bekezdést renderel közvetlenül, és visszaad egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektumot. A visszakapott képet mentse fájlba vagy folyamathoz a [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) segítségével. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet saját kezűleg levágni.

Az [IParagraph.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getImage--) visszatérhet `null` értékkel, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem lehet renderelni. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretben**

Tegyük fel, hogy van egy *sample.pptx* nevű prezentációs fájlunk egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést rendereli egy szabályos szöveges alakzatban alapértelmezett méretben, és PNG formátumban menti a visszakapott képet. A `finally` blokk biztosítja a kép megfelelő felszabadítását.

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

Használja az [IParagraph.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) túlterhelést, amely `float scaleX` és `float scaleY` paraméterekkel fogadja a vízszintes és függőleges méretezési faktorokat. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres szélesség és magasság mellett rendereli, majd a képet PNG formátumban menti.

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

Az `1` méretfaktor megtartja az adott tengely alapértelmezett pixelméretét. Például a `2` mindkét faktor esetén olyan képet eredményez, amelynek szélessége és magassága megközelítőleg a duplája az alapértelmezett méreteknek, így négyzet szorzóban a pixel mennyisége is növekszik. A nagyobb faktorok általában élesebb szöveget eredményeznek a nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti faktorok kisebb képet hoznak létre kevesebb részlettel. Egyenlő faktorok megőrzik a bekezdés képarányát; eltérő vízszintes és függőleges faktorok önállóan nyújtják a kimenetet.

Az egész alakzat renderelése az [IShape.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getImage--) segítségével továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Ha csak a bekezdés képre van szükség, használja az [IParagraph.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getImage--) metódust.

## **GYIK**

**Teljesen letilthatom a sortörést egy szövegkereten belül?**

Igen. Az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) beállításával letiltható a sortörés, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kapom meg egy adott bekezdés pontos helyi koordinátáit?**

Használja az [IParagraph.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getRect--) metódust a bekezdés határoló téglalapjának lekérdezéséhez. Az [IPortion.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#getRect--) egyedi szakaszok határait adja meg.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

Az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) bekezdés szintű beállítás, és a teljes bekezdésre vonatkozik, függetlenül az egyedi szakaszformázástól.

**Beállíthatok helyesírási nyelvet egy bekezdés egy részére?**

Igen. Az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) beállításával egyes szakaszok számára megadható, így egy bekezdés több nyelven is tartalmazhat szöveget.