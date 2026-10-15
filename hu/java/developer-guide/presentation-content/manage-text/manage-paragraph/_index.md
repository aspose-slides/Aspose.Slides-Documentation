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
  - jelölő kezelése
  - bekezdés behúzás
  - függőbehúzás
  - bekezdés jelölő
  - számozott lista
  - felsorolás lista
  - bekezdés tulajdonságok
  - HTML importálása
  - szöveg HTML-be
  - bekezdés HTML-be
  - bekezdés képre
  - szöveg képre
  - bekezdés exportálása
  - PowerPoint
  - prezentáció
  - Java
  - Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, jelölőket, számozott listákat, behúzásokat, HTML tartalmat és bekezdés képeket az Aspose.Slides for Java használatával."
---
## **Áttekintés**

Aspose.Slides for Java a szöveget a szövegkeretek, bekezdések és részek hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) a alakzatban lévő szövegtárolót képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) egy bekezdést jelent egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdésszintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) egy szövegrészt (text run) jelöl egy bekezdésen belül. Minden résznek saját szövege és karakter-szintű formázása lehet.

Egy bekezdés ezért több részt felhasználva különböző betűtípusokkal, színekkel, méretekkel és egyéb formázásokkal tartalmazhat szöveget.

## **Bekezdések létrehozása és formázása**

Hozzon létre bekezdéseket az alakzat szövegkerében, és használjon részeket az egyes szövegrészek formázásához. Ez a szakasz bemutatja, hogyan kombinálhatók több rész egy bekezdésen belül, és hogyan alkalmazhatók különböző színek, betűméretek és stílusok.

### **Bekezdések létrehozása több részkel**

A következő Java példában három bekezdést hoz létre, amelyek mindegyike három szövegrészt (text run) tartalmaz a [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) által visszaadott gyűjteményben. Újrahasználja az alapértelmezett bekezdést és annak üres részét, majd hozzáadja a többi bekezdést és részt. A formázást a [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) segítségével alkalmazzák: az egyes bekezdések első része piros, félkövér és 15 pont; a második kék, dőlt és 18 pont. A harmadik rész megtartja az alapértelmezett formázását:

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

## **Felsorolások és számozott listák létrehozása**

Rendszerezze a bekezdés szövegét listákba szimbólumokkal, számokkal vagy egyedi képekkel. A szakaszban szereplő példák a jelölő formázást, többszintű listákat és egyedi kezdőszámokat fedik le.

### **Felsorolás vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait a [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) definiálja.

Ez a Java példa egy szimbólum jelölőt és egy számozott elemet ad hozzá ugyanahhoz a szövegkerethez. A [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) választja ki a jelölő típusát, míg a [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) a szimbólumot adja meg, és a [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) a számozási stílust választja. Mindkét elem fekete jelölőket használ 100 százalékos magassággal és 25 pontos bekezdésbehúzással:

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

### **Képes jelölők használata**

A képes jelölők lehetővé teszik, hogy egy egyedi képet használjon szimbólum vagy szám helyett.

Ez a Java példa egy képet ad a prezentáció képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) formájában, és azt használja bekezdés jelölőként. A [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) hívásával képes jelölőt választ, és a képet a [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) segítségével rendeli hozzá. A [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) 100 százalékra van beállítva, hogy a jelölő mérete a bekezdés szövegéhez viszonyítva legyen:

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

A [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) beállításával a bekezdéseket a lista különböző szintjeire helyezheti. A felső szint mélysége `0`.

Ez a Java példa 0-tól 3-ig terjedő [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) értékeket ad négy bekezdésnek, egy hierarchiát hozva létre egy szövegkereten belül. Minden bekezdés szimbólum jelölőt használ, a [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) váltogatva egy kör jelölő és egy kötőjel között a szomszédos szintek megkülönböztetéséhez:

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

### **Számozott listaelemek elindítása egyedi értékekkel**

Használja a [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) metódust a számozott bekezdés kezdeti számának beállításához.

Ez a Java példa a [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) beállítja a számozás használatát három bekezdésnél, és a [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékeit 2, 3 és 7-re állítja. A kezdő érték minden bekezdésnél külön van konfigurálva, ami lehetővé teszi, hogy a megjelenített számok kihagyjanak értékeket:

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

## **Bekezdés elrendezésének és záró tulajdonságainak vezérlése**

Állítsa be a bekezdés margóit és behúzásait a első sor és a sortörött sorok pozíciójának vezérléséhez. A bekezdés záró jelét is formázhatja külön a látható szövegrészektől.

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust egy bekezdés első sorának behúzásának szabályozásához. Ez a beállítás csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra helyezi az első sort, míg a többi sor a bekezdés testehez igazodik.

Használja az [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) metódust, ha az egész bekezdést kell elmozdítani. Használja az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) metódust, ha csak az első sort kell elmozdítani.

A következő példa három bekezdésnek ugyanazt a 20 pontos [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) értéket és a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) értékeket 0, 20 és 40 pontban adja meg. Az első sorok fokozatosan nagyobb eltolással kezdődnek, míg a sortörött sorok ugyanazt a bal margót megtartják:

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

![A bekezdések első sor behúzása](first_line_indent.png)

### **Függőbehúzás beállítása**

A függőbehúzás egy bekezdéselrendezés, ahol az első sor a maradék sorok bal oldalára indul. Az Aspose.Slides-ben ezt a hatást az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) tulajdonsággal hozhatja létre. A `Indent`-et negatív értékre állítva az első sor balra kerül a bekezdés testéhez képest.

Gyakorlati példában a [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) határozza meg a bekezdés testének bal pozícióját, és az [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) határozza meg az első sor pozícióját ehhez a margóhoz viszonyítva. Függőbehúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szójegyzék bejegyzéseihez és egyéb bekezdésekhez, ahol a sortörött soroknak a bekezdés testje alatt kell igazodniuk, nem pedig az első sor első karaktere alatt.

A következő Java példa a [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 40 és 60 pontos értékeit párosítja a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) -20 és -30 pontos értékeivel. Minden bekezdésben az első sor a sortörött sorok bal oldalán kezdődik; a második bekezdés mélyebb függőbehúzással rendelkezik:

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

![A bekezdések függőbehúzása](hanging_indent.png)

### **A bekezdés záró futtatásának tulajdonságainak beállítása**

A [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) metódus a bekezdés záró jelének formázását irányítja. A következő példa egy [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) objektumot hoz létre, amelyben a [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 48 pontra, a [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) Times New Roman-ra van beállítva. Ezt a formátumot a második bekezdés záró jelére rendeli, a látható szövegrészeket változatlanul hagyva:

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

A bekezdés szabályokért, amelyek az automatikus sortörést és a sorvégi írásjelek kezelését befolyásolják, lásd a [Control Line Breaking](/slides/hu/java/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/java/text-formatting/#control-hanging-punctuation) oldalakat.

Használja a [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) metódust a bekezdés által elfoglalt sorok számolásához a szöveg elrendezése után, beleértve az automatikus sortörést. Ez hasznos a szöveghossz és elrendezés ellenőrzésénél prezentációs sablonokban.

Egy bekezdés egy elem a [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) kollekcióban, és több megjelenített sort is elfoglalhat. Egy explicit sortörés a bekezdésen belül új sort kényszerít, anélkül hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicit sortöréseket szúrna a szövegbe. A bekezdések vagy sortörés karakterek számlálása ezért nem adja meg a megjelenített sorok számát.

A következő példa egy szöveg alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd egy rövidebb karakterláncra cseréli a szöveget. A példa engedélyezi a sortörést a [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) használatával, és letiltja az automatikus illesztést a [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) segítségével, hogy az alakzat szélessége szabályozza a sortörést anélkül, hogy automatikusan kicsinyítené a szöveget vagy átméretezné az alakzatot. Minden mérés a [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) metódust használja. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá és összeadja a sorok számát a szövegkereten belül.

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

Ezzel a szöveggel és ezekkel a méretekkel a alakzat szűkítése növeli a sorok számát, míg a szöveg rövid karakterláncra cserélése csökkenti azt. A pontos számok a betűkészlet elérhetőségétől és helyettesítésétől, betűmérettől, margóktól, behúzástól, sortöréstől és az automatikus illesztés beállításaitól függően változhatnak. Ellenőrzéskor használja a célkörnyezethez szánt betűket és elrendezési beállításokat.

A sorok száma önmagában nem határozza meg, hogy a szöveg túllépi-e a tárolóját. A rendelkezésre álló magasság, sormagasságok, bekezdés- és sorköz, valamint az automatikus illesztés viselkedése is számít; akár egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

Használjon HTML-t a szöveg prezentációba való beillesztéséhez vagy a meglévő bekezdések exportálásához a prezentáción kívül. Ez a szakasz bemutatja, hogyan jeleníthető meg egyes bekezdések képként, beleértve a táblázatcellákban lévő bekezdéseket is.

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódust a HTML jelölő nyelv bekezdésekké és részekké történő konvertálásához egy szövegkeretben.

Ez a Java példa egy fájlból olvas be HTML-t, és átadja a jelölőt a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) metódusnak. Törli a szövegkeret alapértelmezett bekezdését, így a keret csak az importált tartalmat tartalmazza. A téglalap alakzat minden oldalon 10 pont margót hagy a dián:

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

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) metódust a kiválasztott bekezdéstartomány HTML-be exportálásához. Weboldalon való újrafelhasználáskor előfordulhat, hogy meg akarja őrizni a helyi hangsúlyt anélkül, hogy a prezentáció betűtípusát, méretét vagy szövegdoboz stílusait átvinné. Állítsa a [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) értékét, hogy szabályozza, milyen mértékben követi az exportáló a formázási öröklődést.

Töltse le a [példa prezentációt](text-inheritance.pptx), és helyezze az alkalmazás munkakönyvtárába. Az első diája egy szöveg alakzatot tartalmaz a "Inherited text; explicit red 18pt" szöveggel. A bemenet szándékosan több formázási szintet használ:

- A prezentáció alapértelmezett szövegstílusa Calibri-t és 28 pt méretet biztosít.
- A szövegkeret első szintű szövegstílusa kék szöveget és dőlt betűt biztosít.
- A bekezdés expliciten félkövér szöveget állít be.
- A második rész, "explicit red 18pt", expliciten piros szöveget és 18 pt méretet állít be.

A következő teljes példa háromszor exportálja ugyanazokat a bekezdéseket. Átadja a [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) objektumot az export metódusnak, és minden eredményt külön UTF-8 HTML fájlként ír:

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

Az előállított HTML a következő CSS-t tartalmazza az első részhez, "Inherited text; ". A táblázat felsorolja a releváns deklarációkat; a többi generált tulajdonság az áttekinthetőség kedvéért nincs megjelenítve.

| Kimenet | Az első részhez releváns CSS | Megjelenés |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg 28 pt Calibri-ban, ha az a betűkészlet elérhető. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot és méretet. |
| `ParagraphOnly.html` | `font-weight:bold` | Félkövér szöveg; a körnél lévő oldal vagy böngésző biztosítja a betűcsaládot, méretet, színt és dőlt stílust. |

A második rész minden három kimenetben megtartja a `color:#ff0000`, `font-size:18pt` és `font-weight:bold` értékeket. Emellett megtartja a dőlt stílust az `All` és `TextBox` esetén, de nem a `ParagraphOnly` esetén. Az öröklődés korlátozása ezért nem távolítja el a bekezdéshez vagy részhez explicit módon hozzárendelt formázást.

Nyissa meg a fájlokat ugyanabban a böngészőben, hogy összehasonlítsa őket. A két korlátozott módban a kihagyott CSS tulajdonságokat a céloldal stílusai vagy a böngésző alapértelmezései oldják fel, így a végső megjelenés attól függ, ahol a HTML-t használják.

### **Bekezdés képként való megjelenítése**

Az [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) közvetlenül megjeleníti egy adott bekezdést, és visszaad egy [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) objektumot. Az eredményt fájlba vagy streambe mentheti a [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) segítségével. Nem szükséges a tartalmazó alakzatot megjeleníteni vagy kézzel vágni egy bitmapet.

Az [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) `null` értéket adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes megjelenítési határa, vagy nem tud megjelenni. Ellenőrizze az eredményt mentés előtt, és használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés megjelenítése az alapértelmezett méretezésben**

A példa egy olyan prezentációt használ, amelynek egyetlen diája van, és az első alakzata egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

A következő példa a 1 indexű (második) bekezdést választja ki, és a [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) metódust hívja skálaparaméterek nélkül. Ellenőrzi, hogy az alakzat tartalmazza-e a szükséges bekezdést és hogy a megjelenítés képet ad-e vissza, mielőtt a [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) segítségével PNG formátumban mentené. A `finally` blokk a kép használat után felszabadítja.

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

#### **Bekezdés megjelenítése táblázatcellában méretezéssel**

Használja az [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) túlterhelést, amely `float scaleX` és `float scaleY` paramétereket fogad a vízszintes és függőleges skálázási tényezők beállításához. A következő példa egy táblázatot hoz létre, a bekezdést az első cellájában a default szélesség és magasság dupláján megjeleníti, és PNG képként menti az eredményt.

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

Az `1` skálázási tényező az adott tengelyt a default pixel méretben tartja. Például, ha mindkét tényező `2`, akkor egy képet kapunk, amelynek szélessége és magassága megközelítőleg duplája a default méreteknek, négyzetét adva a pixel számnak. A nagyobb tényezők általában élesebb szöveget eredményeznek zoomoláshoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb képet adnak kevesebb részlettel. Egyenlő tényezőket használjon a bekezdés arányának megőrzéséhez; a különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

Egy teljes alakzat [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) segítségével történő megjelenítése továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Csak bekezdés képe esetén használja az [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) metódust.

## **FAQ**

**Kikapcsolhatom teljesen a sortörést egy szövegkereten belül?**

Igen. Állítsa a [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) értékét a sortörés letiltásához, így a sorok nem törnek a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián belüli határait?**

Használja a [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) metódust a bekezdés körülhatároló téglalap lekéréséhez. Az [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) egy adott rész határait adja vissza.

**Hol vezérelhető a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt?)**

Az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) egy bekezdés-szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

A különböző betűméretű részek soron belüli függőleges igazításához lásd a [Align Fonts Within a Line](/slides/hu/java/text-formatting/#align-fonts-within-a-line).

**Beállíthatok ellenőrzési nyelvet a bekezdés egy részére?**

Igen. Állítsa be az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) értékét az egyes részekhez, így egy bekezdés több nyelven szereplő szöveget tartalmazhat.