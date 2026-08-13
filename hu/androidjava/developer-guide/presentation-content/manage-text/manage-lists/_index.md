---
title: Felsorolásjeles és számozott listák kezelése Android prezentációkban
linktitle: Listák kezelése
type: docs
weight: 60
url: /hu/androidjava/manage-lists/
keywords:
- jel
- felsorolásjeles lista
- számozott lista
- szimbólum jel
- képes jel
- egyedi jel
- többszintű lista
- jel létrehozása
- jel hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolásjeles, képes, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy felsorolásjelekkel és számozott listákkal rendelkező PowerPoint és OpenDocument bemutatókat hozzon létre és formázzon. Egy listaelem egy bekezdés, amelynek a jelbeállításait a bekezdésformázás szabályozza.

Használja az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont az [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) amely egy [IBulletFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a jel típusát, szimbólumát, képét, színét, méretét, a számozási stílust és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- készítsen felsorolásjeles listát egy egyéni szimbólummal
- készítsen képes jelölőt
- készítsen többszintű listát a bekezdés mélységének beállításával
- készítsen számozott listát
- vizsgálja és módosítsa a lista formázását egy meglévő bemutatóban

## **Felsorolásjeles lista létrehozása**

Felsorolásjeles lista létrehozásához adjon bekezdéseket egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumhoz, és állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) metódust a [BulletType.Symbol](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/) értékre. Ezután beállíthatja az [IBulletFormat.setChar](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#getColor--) és [IBulletFormat.setHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) metódusokat a jel megjelenésének szabályozásához.

Az alábbi Java kód bemutatja, hogyan hozhat létre felsorolásjeles listát egy dián:

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

![A szimbólum jelölők](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, amikor a tételek sorrendje fontos. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) metódust a [BulletType.Numbered](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/) értékre. A számozási formátumot is kiválaszthatja az [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) metódussal, vagy beállíthatja az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét, ha a lista az 1-etől eltérő értékkel kell kezdődjön.

Az alábbi Java kód mutatja, hogyan hozhat létre számozott listát egy dián:

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

![A számozott jelölők](numbered_bullets.png)

## **Képes jel létrehozása**

Az Aspose.Slides lehetővé teszi, hogy a normál jel szimbólumát képpel helyettesítse. A képes jelölők a legegyszerűbb képekkel működnek a legjobban, amelyek kis méretben is olvashatóak, például ikonok vagy kis átlátszó PNG fájlok.

{{% alert color="info" %}}
Ideális esetben, ha a normál jel szimbólumát képpel szeretné helyettesíteni, a legjobb egy egyszerű, átlátszó háttérrel rendelkező grafikát választani. Az ilyen képek jók egyedi jel szimbólumokként.

Ne feledje, hogy a kép nagyon kicsi méretre lesz skálázva. Ezért erősen ajánljuk, hogy olyan képet válasszon, amely tiszta és vizuálisan hatékony marad, amikor lista jelölőjeként használja.
{{% /alert %}}

Ahhoz, hogy képes jelölőt hozzon létre, adjon egy képet a [Presentation.getImages](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getImages--) metódushoz, és rendelje a visszakapott [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumot az [IBulletFormat.getPicture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#getPicture--) metódusnak. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) metódust a [BulletType.Picture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/) értékre a kép hozzárendelése előtt.

Tegyük fel, hogy van egy "image.png" fájlunk:

![Kép a jelölőkhöz](picture_for_bullets.png)

Az alábbi Java kód mutatja, hogyan hozhat létre képes jelölőket egy dián:

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

![A képes jelölők](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) metódust, hogy a listaelemeket különböző szinteken helyezze el. A 0. szint a legfelső, az 1. szint alá van ágyazva, és így tovább.

Az alábbi Java kód mutatja, hogyan hozhat létre többszintű listát:

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

A meglévő bemutatóban a lista formázásának módosításához érje el a cél bekezdést, és frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) beállításait. Ugyanazok a metódusok, amelyeket listák létrehozásához használ, alkalmazhatók a PPT, PPTX vagy ODP fájlból betöltött listák vizsgálatára vagy módosítására is.

Az alábbi Java kód módosítja a szövegkeret első bekezdését, hogy számozott lista stílust használjon:

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

## **GYIK**

### Exportálhatóak a felsorolásjeles és számozott listák PDF vagy képek formátumba?

Igen. Az Aspose.Slides megőrzi a lista formázását, amikor a célformátum támogatja a megfelelő szövegelrendezést és jelző funkciókat.

### Szerkeszthetem a listákat meglévő bemutatókban?

Igen. Töltse be a bemutatót, érje el a cél bekezdést, vizsgálja vagy frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) beállításait, és mentse el a bemutatót.

### Tartalmazhatnak a listák nem latin szöveget?

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így többnyelvű bemutatókban is létrehozhat listákat. Győződjön meg róla, hogy a bemutatóban használt betűtípusok támogatják a szükséges karaktereket.