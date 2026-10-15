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
- felsorolás kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés felsorolás
- számozott lista
- felsorolásos lista
- bekezdés tulajdonságai
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmakat és bekezdés képeket az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java a szöveget szövegkeretek, bekezdések és részek hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) a szövegtárolót egy alakzatban képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdés-szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) egy szövegrészt képvisel egy bekezdésen belül. Minden résznek saját szövege és karakter-szintű formázása lehet.

Ezáltal egy bekezdés különböző betűtípusú, színű, méretű és egyéb formázású szövegeket is tartalmazhat több rész használatával.

## **Bekezdések létrehozása és formázása**

Hozzon létre bekezdéseket egy alakzat szövegkeretében, és használjon részeket az egyes szövegrészek formázásához. Ez a szakasz azt mutatja be, hogyan lehet több részt kombinálni minden bekezdésben, és különböző színeket, betűméreteket és stílusokat alkalmazni.

### **Több részes bekezdések létrehozása**

A következő Android via Java példa három bekezdést hoz létre, mindegyik három szövegrészt tartalmazva a [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--)- által visszaadott gyűjteményben. Újra felhasználja az alapértelmezett bekezdést és annak üres részét, majd hozzáadja a maradék bekezdéseket és részeket. A formázást a [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--) segítségével alkalmazzák: az első rész minden bekezdésben piros, félkövér és 15 pont; a második kék, dőlt és 18 pont. A harmadik rész az alapértelmezett formázást megtartja:

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

Rendezze a bekezdés szövegét listákba szimbólumokkal, számokkal vagy egyéni képekkel. Ebben a szakaszban bemutatott példák a felsorolásformázást, a többszintű listákat és az egyedi kezdőszámokat fedik le.

### **Felsorolás vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait a [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) segítségével definiálják.

Ez az Android via Java példa egy szimbólumos felsorolást és egy számozott elemet ad ugyanahhoz a szövegkerethez. A [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) kiválasztja a felsorolás típusát, míg a [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) megadja a szimbólumot, és a [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) kiválasztja a számozási stílust. Mindkét elem fekete felsorolást használ, amelynek magassága 100 százalék, és a bekezdés behúzása 25 pont:

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

### **Képes felsorolások használata**

A képes felsorolások lehetővé teszik, hogy egy egyéni képet használjon szimbólum vagy szám helyett.

Ez az Android via Java példa egy képet ad a prezentáció képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)‑ként, és bekezdés felsorolásként használja. A [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) hívásával képes felsorolást állít be, és a képet a [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--) segítségével rendeli hozzá. A [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) 100 százalékra van beállítva, hogy a felsorolás mérete a bekezdés szövegéhez képest legyen:

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

Az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) beállításával a bekezdéseket a lista különböző szintjeire helyezhetjük. A legfelső szint mélysége `0`.

Ez az Android via Java példa a [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) értékeit 0‑tól 3‑ig rendeli négy bekezdéshez, egy hierarchiát hozva létre egy szövegkereten belül. Minden bekezdés szimbólumos felsorolást használ, a [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) váltakozva egy kör alakú felsorolás és egy kötőjel között a szomszédos szintek megkülönböztetésére:

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

### **Számozott listaelemek egyéni kezdőértékekkel**

A [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) használatával állítható be a számozott bekezdés elsőként megjelenő száma.

Ez az Android via Java példa a [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) beállítja a számozást három bekezdéshez, és a [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékeit 2, 3 és 7‑re állítja. A kezdőérték minden bekezdésnél külön van beállítva, lehetővé téve, hogy a megjelenő számok kihagyjanak értékeket:

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

## **Bekezdés elrendezésének és befejező tulajdonságainak vezérlése**

Állítsa be a bekezdés margóit és behúzásait a első sor és a tördelve megjelenő sorok helyzetének szabályozásához. A bekezdés befejezési jelét is formázhatja külön a látható szövegrészektől.

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a beállítás csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez illeszkedik.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódust, ha az egész bekezdést kell eltolni. Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust, ha csak az első sort kell eltolni.

A következő példa három bekezdésnek ugyanazt a [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 20 pont értéket ad, és [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket 0, 20 és 40 pont között. Az első sorok fokozatosan nagyobb eltolással kezdődnek, míg a tördelő sorok ugyanazt a bal margót megtartják:

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

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás egy olyan bekezdéselrendezés, amelyben az első sor a maradék sorok bal oldalán kezdődik. Az Aspose.Slides-ben ezt a hatást az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) tulajdonsággal hozhatja létre. Az `Indent` negatív értéke az első sort balra mozgatja a bekezdés törzséhez képest.

Gyakorlati példában az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) határozza meg a bekezdés törzsének bal pozícióját, míg az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) meghatározza az első sor pozícióját ehhez a margóhoz képest. Függő behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szószedet‑bejegyzésekhez és egyéb bekezdésekhez, ahol a tördelő soroknak a bekezdés törzse alatt kell igazodniuk, nem pedig az első sor első karaktere alatt.

A következő Android via Java példa a [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 40 és 60 pont értékeit párosítja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) -20 és -30 pont értékeivel. Minden bekezdésben az első sor a tördelő sorok bal oldalán kezdődik; a második bekezdés mélyebb függő behúzást kap:

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

![A bekezdések függő behúzása](hanging_indent.png)

### **Befejező bekezdés részformátumának beállítása**

Az [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) metódus szabályozza a bekezdés befejezési jel formázását. A következő példa egy [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) objektumot hoz létre, amelynek [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 48 pontra, [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) pedig Times New Roman-ra van beállítva. Ezt a formátumot a második bekezdés befejezési jeléhez rendeli, míg a látható szövegrészek változatlanok maradnak:

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

## **Renderelt sorok számlálása**

A bekezdés szabályok, amelyek befolyásolják az automatikus tördelést és a sorvégi írásjeleket, lásd a [Control Line Breaking](/slides/hu/androidjava/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/androidjava/text-formatting/#control-hanging-punctuation) oldalakat.

A [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) használatával megszámolhatók a bekezdés által elfoglalt sorok a szöveg elrendezése után, beleértve az automatikus tördelést. Ez hasznos a szöveghossz és az elrendezés ellenőrzésénél prezentációs sablonokban.

Egy bekezdés egy eleme a [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) gyűjteménynek, és több renderelt sort is elfoglalhat. Egy explicit sortörés egy bekezdésen belül új sort hoz létre anélkül, hogy újabb bekezdést hozna létre. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy explicit sortörés karaktereket illesztene a szövegbe. Ezért a bekezdések vagy sortörés karakterek számlálása nem adja meg a renderelt sorok számát.

A következő példa egy szöveges alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A példa engedélyezi a tördelést a [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) segítségével, és letiltja az autofit‑et a [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) segítségével, így a forma szélessége szabályozza a tördelést anélkül, hogy automatikusan kicsinyítené a szöveget vagy átméretezné az alakzatot. Minden mérés a [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) használatával történik. A forma méretei pontban vannak. Végül a példa egy újabb bekezdést ad hozzá és összeadja a sorok számát a szövegkeretben.

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

Ezzel a szöveggel és ezeket a méretekkel a forma szűkítése növeli a sorok számát, míg a szöveg rövid karakterláncra cserélése csökkenti azt. A pontos számlálás a betűtípus elérhetőségétől és helyettesítésétől, betűmérettől, margóktól, behúzásoktól, tördeléstől és autofit beállításoktól függ. A célnyelvi környezetben használandó betűtípusok és elrendezés beállításait használja a sablon ellenőrzésekor.

A sorok számának önmagában nem határozza meg, hogy a szöveg túllépi-e a tárolóját. A rendelkezésre álló magasság, sormagasságok, bekezdés‑ és sorköz, valamint az autofit viselkedés is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a tördelés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

Használjon HTML‑t a szöveg prezentációba való beviteléhez vagy a meglévő bekezdések exportálásához a kívülről való felhasználáshoz. Ebben a szakaszban bemutatjuk, hogyan lehet egyes bekezdéseket képként renderelni, beleértve a táblázatcellákban lévő bekezdéseket is.

### **HTML szöveg importálása bekezdésekbe**

A [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) használatával a HTML jelölőnyelvet bekezdésekké és részekké konvertálhatja egy szövegkeretben.

Ez az Android via Java példa egy fájlból olvas HTML‑t, és a jelölőnyelvet átadja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak. Törli a szövegkeret alapértelmezett bekezdését, így a keret csak az importált tartalmat tartalmazza. A téglalap alakzat 10 pontos margót hagy a diák mindkét oldalán:

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

### **Bekezdés szöveg exportálása HTML‑be**

A [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) használatával a kiválasztott bekezdés‑tartományt exportálhatja HTML‑ként. Ha a prezentáció szövegét weboldalon használja újra, megőrizheti a helyi hangsúlyt anélkül, hogy a prezentáció betűtípusát, méretét vagy szövegdoboz stílusait átvinné. A [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) beállításával szabályozhatja, milyen mélységig kövesse a formázás öröklődését az exportáló.

Töltse le a [mintaprezentációt](text-inheritance.pptx) és helyezze az alkalmazás munkakönyvtárába. Az első diája egy szöveges alakzatot tartalmaz a "Inherited text; explicit red 18pt" szöveggel. A bemenet szándékosan több formázási szintet használ:

- A prezentáció alapértelmezett szövegstílusa Calibri‑t és 28 pt méretet biztosít.
- A szövegkeret első szintű szövegstílusa kék szöveget és dőlt betűt biztosít.
- A bekezdés kifejezetten félkövér szöveget állít be.
- A második rész, "explicit red 18pt", kifejezetten piros szöveget és 18 pt méretet állít be.

A következő teljes példa háromszor exportálja ugyanazokat a bekezdéseket. A [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) objektumot adja át az export metódusnak, és minden eredményt külön UTF‑8 HTML fájlba ír:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

A generált HTML a következő CSS‑t tartalmazza az első részhez, "Inherited text; ". A táblázat felsorolja a releváns deklarációkat; a többi generált tulajdonság el van hagyva az átláthatóság kedvéért.

| Kimenet | Az első részhez releváns CSS | Megjelenés |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg 28 pt mérettel a Calibri betűtípussal, ha az a betűtípus elérhető. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot és a méretet. |
| `ParagraphOnly.html` | `font-weight:bold` | Félkövér szöveg; a körnész oldal vagy böngésző biztosítja a betűcsaládot, méretet, színt és a dőlt stílust. |

A második rész megtartja a `color:#ff0000`, `font-size:18pt` és `font-weight:bold` értékeket mindhárom kimenetben. A dőlt formázást is megtartja az `All` és `TextBox` esetén, de a `ParagraphOnly` esetén nem. A öröklődés korlátozása tehát nem távolítja el a bekezdéshez vagy részhez kifejezetten hozzárendelt formázást.

Nyissa meg a fájlokat ugyanabban a böngészőben a összehasonlításhoz. A két korlátozott módban a kihagyott CSS tulajdonságokat a céloldal stílusai vagy a böngésző alapértelmezései oldják fel, ezért a megjelenés attól függ, hogy hol használják a HTML‑t.

### **Bekezdés renderelése képként**

A [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) közvetlenül renderel egy egyedi bekezdést, és egy [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) objektumot ad vissza. Az eredményt fájlba vagy adatfolyamba mentheti a [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) segítségével. Nem kell a tartalmazó alakzatot renderelni vagy a bitmapet kézzel vágni.

A [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) `null` értéket adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt mentés előtt, és a használat után szabadítsa fel a visszaadott képet.

#### **Bekezdés renderelése alapértelmezett méretezésben**

A példa egy olyan prezentációt használ, amelynek egy diája van, és az első alakzata egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

A következő példa a második bekezdést (1. index) választja ki, és a [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) metódust skálaparaméterek nélkül hívja. Ellenőrzi, hogy az alakzat tartalmazza‑e a szükséges bekezdést, és hogy a renderelés képet ad‑e vissza, mielőtt a [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metódussal PNG formátumban mentené. A `finally` blokk a használat után felszabadítja a képet.

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

#### **Bekezdés renderelése táblázatcellában méretezéssel**

Használja a [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) túlterhelését, amely `float scaleX` és `float scaleY` paramétereket fogad, a vízszintes és függőleges skálázási tényezők beállításához. A következő példa egy táblázatot hoz létre, a bekezdést az első cellájában a alapértelmezett szélesség és magasság kétszeresére rendereli, és az eredményt PNG képként menti.

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

Egy `1` skálafaktor megtartja az adott tengely alapértelmezett képméretét. Például a `2` mindkét tényező esetén olyan képet eredményez, amelynek szélessége és magassága körülbelül a kétszerese az alapértelmezett méretnek, ezáltal négyszer annyi pixel keletkezik. A nagyobb tényezők általában élesebb szöveget adnak a nagyításhoz vagy a nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb, kevésbé részletes képeket adnak. Egyenlő tényezőket használjon a bekezdés képarányának megtartásához; különböző vízszintes és függőleges tényezők függetlenül nyújtják a kimenetet.

Egy egész alakzat renderelése a [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) segítségével akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy más vizuális kontextusát. Egy csak bekezdésképet igénylő esetben használja a [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) metódust.

## **FAQ**

**Teljesen letilthatom a sortördelést egy szövegkereten belül?**

Igen. Állítsa az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) értékét a wrap (tördelés) letiltásához, így a sorok nem szakadnak meg a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos diára vonatkozó határait?**

Használja az [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) metódust a bekezdés határoló téglalapjának lekéréséhez. Az [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) egy egyedi rész határait adja meg.

**Hol vezérelhető a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

Az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) bekezdés‑sztűi beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

A különböző betűméretű részek függőleges igazításához egy soron belül, lásd a [Align Fonts Within a Line](/slides/hu/androidjava/text-formatting/#align-fonts-within-a-line) oldalt.

**Beállíthatom a helyesírási nyelvet egy bekezdés részéhez?**

Igen. Az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) használatával egyedi részekhez állíthatja be a nyelvet, így egy bekezdés több nyelven is tartalmazhat szöveget.