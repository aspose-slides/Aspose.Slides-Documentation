---
title: Pontozott és számozott listák kezelése bemutatókban Androidon
linktitle: Listák kezelése
type: docs
weight: 60
url: /hu/androidjava/manage-lists/
keywords:
- golyó
- felsoroláslista
- számozott lista
- szimbólum golyó
- kép golyó
- egyéni golyó
- többszintű lista
- golyó létrehozása
- golyó hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Tudja meg, hogyan hozhat létre és formázhat pontozott, képes, többszintű és számozott listákat PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy felsorolás- és számozott listákat hozzunk létre és formázzunk PowerPoint és OpenDocument bemutatókban. Egy listaelem egy bekezdés, amelynek golyóbeállításait a bekezdésformátum vezérli.

Használja a [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) amely egy [IBulletFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a golyó típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- létrehozni egy felsoroláslistát egy egyéni szimbólummal
- kép golyót létrehozni
- többszintű listát létrehozni a bekezdés mélységének beállításával
- számozott listát létrehozni
- megnézni és módosítani a lista formázását egy meglévő bemutatóban

## **Felsoroláslista létrehozása**

A felsoroláslista létrehozásához adjon bekezdéseket egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/)‑hez, és állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/)‑ra. Ezután a [IBulletFormat.setChar](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), a [IBulletFormat.getColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#getColor--) és a [IBulletFormat.setHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) segítségével szabályozhatja a golyó megjelenését.

Az alábbi Java‑kód bemutatja, hogyan hozhatunk létre felsoroláslistát egy dián:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szimbólum golyók](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje számít. Állítsa a [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/)‑ra. A számozási formátumot a [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-)‑val választhatja ki, vagy a [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)‑val adhat meg egy 1‑től eltérő kezdőértéket.

Az alábbi Java‑kód mutatja, hogyan hozhatunk létre számozott listát egy dián:

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

![A számozott golyók](numbered_bullets.png)

## **Kép golyó létrehozása**

Az Aspose.Slides lehetővé teszi, hogy a szokásos golyó szimbólumot egy képpel helyettesítse. A kép golyók leginkább egyszerű, kis méretben is olvasható képekkel működnek, például ikonokkal vagy kis átlátszó PNG‑fájlokkal.

{{% alert color="primary" %}}
Ideális esetben, ha a szokásos golyó szimbólumot képpel kívánja helyettesíteni, egyszerű, átlátszó háttérrel rendelkező grafikát válasszon. Az ilyen képek jól használhatók egyéni golyó szimbólumokként.

Ne feledje, hogy a képet nagyon kicsi méretre skálázzák le. Ezért erősen ajánljuk, hogy olyan képet válasszon, amely a lista golyójaként is tisztán és hatékonyan látható.
{{% /alert %}}

A kép golyó létrehozásához adjon egy képet a [Presentation.getImages](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getImages--)‑hez, és a visszakapott [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumot rendelje a [IBulletFormat.getPicture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#getPicture--)‑hez. A kép hozzárendelése előtt állítsa be a [IBulletFormat.setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/bullettype/)‑ra.

Tegyük fel, hogy van egy "image.png" fájlunk:

![Kép a golyókhoz](picture_for_bullets.png)

Az alábbi Java‑kód mutatja, hogyan hozhatunk létre kép golyókat egy dián:

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

![A kép golyók](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-)‑t a listaelemek különböző szintekre helyezéséhez. A 0‑szint a legfelső szint, az 1‑szint alatta, és így tovább.

Az alábbi Java‑kód bemutatja, hogyan hozhatunk létre többszintű felsoroláslistát:

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

A lista formázásának módosításához egy meglévő bemutatóban érje el a cél bekezdést, és frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) beállításait. Az ugyanazok a metódusok, amelyeket listák létrehozásához használ, alkalmazhatók a PPT, PPTX vagy ODP fájlból betöltött listák megtekintésére vagy módosítására.

Az alábbi Java‑kód megváltoztatja az első bekezdést egy szövegdobozban, hogy számozott lista stílust használjon:

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

**Exportálhatók a felsorolás- és számozott listák PDF vagy képek formátumba?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célnyelv támogatja a megfelelő szövegelrendezést és golyó funkciókat.

**Szerkeszthetek listákat meglévő bemutatókban?**

Igen. Töltse be a bemutatót, érje el a cél bekezdést, vizsgálja meg vagy frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) beállításait, és mentse a bemutatót.

**Tartalmazhatnak a listák nem latin szöveget?**

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így többnyelvű bemutatókban is létrehozhat listákat. Győződjön meg róla, hogy a bemutatóban használt betűtípusok támogatják a szükséges karaktereket.