---
title: "Felsorolásjeles és számozott listák kezelése prezentációkban Java-ban"
linktitle: "Listák kezelése"
type: docs
weight: 60
url: /hu/java/manage-lists/
keywords:
- "felsorolásjel"
- "felsorolásjeles lista"
- "számozott lista"
- "szimbólum felsorolásjel"
- "képes felsorolásjel"
- "egyéni felsorolásjel"
- "többszintű lista"
- "felsorolásjel létrehozása"
- "felsorolásjel hozzáadása"
- "lista hozzáadása"
- PowerPoint
- OpenDocument
- "prezentáció"
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és formázhat felsorolásjeles, képes, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Java lehetővé teszi, hogy felsorolásjelekkel és számozott listákkal hozzon létre és formázzon PowerPoint és OpenDocument prezentációkat. A listaelem egy bekezdés, amelynek a felsorolásjeles beállításai a bekezdés formázásán keresztül szabályozhatók.

Használja a [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--), amely egy [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a felsorolásjel típusát, szimbólumát, képét, színét, méretét, a számozási stílust és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- létrehozni egy felsorolásjeles listát egy egyéni szimbólummal
- létrehozni egy képes felsorolásjelet
- létrehozni több szintű listát a bekezdés mélység beállításával
- létrehozni egy számozott listát
- vizsgálni és módosítani a lista formázását egy meglévő prezentációban
- kiolvasni a tényleges lista jelzőket és számokat a bekezdés szövege mellett

## **Felsorolásjeles lista létrehozása**

Felsorolásjeles lista létrehozásához adjon [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) objektumokat egy [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) elemhez, és állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) értékét [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol)-ra. Ezután beállíthatja a [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-), a [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--) és a [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) értékeket a felsorolásjel megjelenésének vezérléséhez.

Az alábbi Java kód bemutatja, hogyan hozhat létre egy felsorolásjeles listát egy dián:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szimbólum felsorolásjelek](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) értékét [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered)-ra. A számozási formátumot a [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) metódussal is kiválaszthatja, vagy a [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) segítségével állíthatja be, ha a lista 1 helyett más értékkel kezdődjön.

Az alábbi Java kód bemutatja, hogyan hozhat létre egy számozott listát egy dián:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A számozott felsorolásjelek](numbered_bullets.png)

## **Képes felsorolásjel létrehozása**

Az Aspose.Slides lehetővé teszi, hogy a szokásos felsorolásjeles szimbólumot egy képpel helyettesítse. A képes felsorolásjelek a legegyszerűbb képekkel működnek a legjobban, amelyek kis méretben is olvashatóak, például ikonok vagy kis átlátszó PNG fájlok.

{{% alert color="info" title="Note" %}}
Elvileg, ha a szokásos felsorolásjeles szimbólumot egy képpel kívánja helyettesíteni, a legjobb, ha egy egyszerű, átlátszó háttérrel rendelkező grafikát választ. Az ilyen képek jól működnek egyéni felsorolásjeles szimbólumokként.

Ne feledje, hogy a kép nagyon kis méretre lesz kicsinyítve. Ezért erősen javasoljuk, hogy olyan képet válasszon, amely tiszta és vizuálisan hatékony marad, ha felsorolásjelként használják a listában.
{{% /alert %}}

Képes felsorolásjel létrehozásához adjon egy képet a [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) metódushoz, és rendelje hozzá a visszaadott képobjektumot a [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) metódushoz. A képet hozzárendelés előtt állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) értékét [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture)-ra.

Tegyük fel, hogy van egy "image.png" fájlunk:

![Kép a felsorolásjelekhez](picture_for_bullets.png)

Az alábbi Java kód bemutatja, hogyan hozhat létre képes felsorolásjeleket egy dián:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A képes felsorolásjelek](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) metódust a listaelemek különböző szintekre helyezéséhez. A 0. szint a legfelső szint, az 1. szint alatta van, és így tovább.

Az alábbi Java kód bemutatja, hogyan hozhat létre egy többszintű felsorolásjeles listát:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A többszintű lista](multilevel_list.png)

## **Meglévő lista módosítása**

A lista formázásának meglévő prezentációban történő módosításához érje el a célnékezetet, és frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) beállításait. Ugyanazok a tulajdonságok, amelyeket listák létrehozásához használt, felhasználhatók a PPT, PPTX vagy ODP fájlból betöltött listák megtekintésére vagy módosítására.

Az alábbi Java kód megváltoztatja egy szövegkeret első bekezdését, hogy számozott lista stílust használjon:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A tényleges felsorolásjel értékek olvasása**

Prezentáció tartalmának kinyerésekor tartsa meg a lista jelzőket a bekezdés szövegével együtt. Hívja meg az [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) metódust, és érje el a [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) értékét a tényleges felsorolásjelformátum megszerzéséhez. Olvasás előtt ellenőrizze a [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) értékét a [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) meghívása előtt.

Számozott listák esetén különböztesse meg a következő három értéket:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) meghatározza a formátumot, például arab számok ponttal vagy kisbetűs betűk ponttal követve.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) adja meg a kezdő számot egy számozott bekezdéscsoport számára.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) visszaadja egy adott bekezdés formázott jelzőjét. Például egy 5-től induló lista második eleme `6.`-ot ad vissza.

Minden bekezdésnél őrizze meg a [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--) értékét a beágyazási szint megtartásához. A tényleges jelző nem kódolja a teljes hierarchiát: egy belső elem `c.`-t adhat vissza a `6.c.`-hez hasonló kombinált címke helyett.

Az alábbi önálló példa listákat hoz létre, elmenti őket egy prezentációba, majd újratölti a prezentációt, hogy jelentést készítsen minden bekezdés szövegéről, mélységéről, felsorolásjeles típusáról és tényleges értékéről. A kicsi kék képjelző inline SVG-ből jön létre.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Készítsen képes jelzőt külső képfájl nélkül.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Az eredeti listák alább láthatók.

![5-től induló listák, beágyazott betű- és római számú elemek, szimbólum jelző, felsorolásjel nélküli bekezdés, és egy kék képes jelző](actual_bullet_values.png)

A jelentés megegyezik a PowerPointban megjelenített jelzőkkel:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

A [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) esetén a [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) `null` értéket ad vissza, nem üres karakterláncot. Kezelje ezeket a típusokat külön: az előzőnek nincs jelzője, míg az utóbbit külön kell kivonni a felsorolásképből. A képes felsorolásjel nem reprodukálható csak egy szövegjelző kinyerésével.

## **GYIK**

**Exportálhatók-e a felsorolásjeles és számozott listák PDF-re vagy képekre?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és felsorolásjeles funkciókat.

**Szerkeszthetek listákat meglévő prezentációkban?**

Igen. Töltse be a prezentációt, érje el a célnékezetet, vizsgálja vagy frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) beállításait, és mentse a prezentációt.

**Tartalmazhatnak-e a listák nem latin karaktereket?**

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így többnyelvű prezentációkban is létrehozhat listákat. Győződjön meg róla, hogy a prezentációban használt betűtípusok támogatják a szükséges karaktereket.