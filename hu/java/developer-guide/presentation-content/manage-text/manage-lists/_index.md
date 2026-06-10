---
title: Felsorolás- és számozott listák kezelése prezentációkban Java-ban
linktitle: Listák kezelése
type: docs
weight: 60
url: /hu/java/manage-lists/
keywords:
- felsorolásjel
- felsoroláslista
- számozott lista
- szimbólum felsorolásjel
- képes felsorolásjel
- egyéni felsorolásjel
- többszintű lista
- felsorolásjel létrehozása
- felsorolásjel hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolás, képes, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Java lehetővé teszi, hogy felsorolásjelekkel és számozott listákkal készült PowerPoint és OpenDocument bemutatókat hozzon létre és formázzon. Egy listaelem egy bekezdés, amelynek a felsorolásjellel kapcsolatos beállításait a bekezdés formátuma vezérli.

Használja az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getParagraphFormat--) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont az [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getBullet--) , amely egy [IBulletFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a felsorolásjel típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- egy egyéni szimbólummal ellátott felsoroláslista létrehozása
- képes felsorolásjel létrehozása
- többszintű lista létrehozása a bekezdés mélységének beállításával
- számozott lista létrehozása
- listaformátum ellenőrzése és módosítása egy létező bemutatóban

## **Felsoroláslista létrehozása**

Felsoroláslista létrehozásához adjon [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) objektumokat egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)‑hez, és állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-byte-) értékét [BulletType.Symbol](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/#Symbol)-ra. Ezután beállíthatja az [IBulletFormat.setChar](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setChar-char-), az [IBulletFormat.getColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#getColor--) és az [IBulletFormat.setHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setHeight-float-) értékeket a felsorolásjel megjelenésének vezérléséhez.

Az alábbi Java kód bemutatja, hogyan hozhat létre felsoroláslistát egy dián:

```java
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

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-byte-) értékét [BulletType.Numbered](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/#Numbered)-ra. Választhat egy számozási formátumot az [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) segítségével, vagy beállíthatja az [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értéket, ha a lista 1‑nél eltérő értékkel kezdődik.

Az alábbi Java kód megmutatja, hogyan hozhat létre számozott listát egy dián:

```java
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

Az Aspose.Slides lehetővé teszi, hogy a szokásos felsorolásjel szimbólumát egy képpel helyettesítse. A képes felsorolásjelek leginkább egyszerű képekkel működnek jól, amelyek kis méretben is olvashatóak, például ikonok vagy kicsi átlátszó PNG fájlok.

{{% alert color="primary" %}}
Ideális esetben, ha a szokásos felsorolásjel szimbólumát képpel kívánja helyettesíteni, a legjobb egy egyszerű, átlátszó háttérrel rendelkező grafika kiválasztása. Az ilyen képek jól működnek egyéni felsorolásjelszimbólumokként.
{{% /alert %}}

Képes felsorolásjel létrehozásához adjon egy képet a [Presentation.getImages](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getImages--) metódushoz, és rendelje hozzá a visszakapott képobjektumot az [IBulletFormat.getPicture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#getPicture--)-hez. Állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-byte-) értékét [BulletType.Picture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/#Picture)-ra, mielőtt a képet hozzárendeli.

Tegyük fel, hogy van egy "image.png" fájlunk:

![Kép a felsorolásjelekhez](picture_for_bullets.png)

Az alábbi Java kód megmutatja, hogyan hozhat létre képes felsorolásjeleket egy dián:

```java
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

Használja az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setDepth-short-) metódust a listaelemek különböző szintekre helyezéséhez. A 0‑szint a legfelső szint, az 1‑szint alá van ágyazva, stb.

Az alábbi Java kód mutatja, hogyan hozhat létre többszintű felsoroláslistát:

```java
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

A listaformátum módosításához egy meglévő bemutatóban, érje el a célbekezdést, és frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getBullet--) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok használhatók a PPT, PPTX vagy ODP fájlból betöltött listák ellenőrzésére vagy módosítására.

Az alábbi Java kód módosítja egy szövegkeret első bekezdését, hogy számozott lista stílust használjon:

```java
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

**Exportálhatók a felsorolás- és számozott listák PDF‑be vagy képekbe?**

Igen. Az Aspose.Slides megőrzi a listaformátumot, ha a célformátum támogatja a megfelelő szövegelrendezést és felsorolásjellel kapcsolatos funkciókat.

**Szerkeszthetek listákat meglévő bemutatókban?**

Igen. Töltse be a bemutatót, érje el a célbekezdést, ellenőrizze vagy frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getBullet--) beállításait, majd mentse a bemutatót.

**Tartalmazhatnak a listák nem latin szöveget?**

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így többnyelvű bemutatókban is létrehozhat listákat. Győződjön meg róla, hogy a bemutatóban használt betűtípusok támogatják a szükséges karaktereket.