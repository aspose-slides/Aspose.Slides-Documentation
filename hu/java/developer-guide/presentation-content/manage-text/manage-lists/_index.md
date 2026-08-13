---
title: Felsorolási és számozott listák kezelése prezentációkban Java-ban
linktitle: Listák kezelése
type: docs
weight: 60
url: /hu/java/manage-lists/
keywords:
- pont
- felsoroláslista
- számozott lista
- szimbólum pont
- kép pont
- egyéni pont
- többszintű lista
- pont létrehozása
- pont hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolás-, kép-, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for Java lehetővé teszi felsorolás- és számozott listák létrehozását és formázását PowerPoint és OpenDocument prezentációkban. A listaelem egy bekezdés, amelynek felpontozási beállításait a bekezdés formátuma szabályozza.

Használja a [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getParagraphFormat--) metódust a bekezdés-szintű lista beállítások eléréséhez. A fő belépési pont a [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getBullet--) metódus, amely egy [IBulletFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a felpontozás típusát, szimbólumát, képét, színét, méretét, számozási stílusát és kezdőszámát.

Ez a cikk bemutatja, hogyan:

- hozhat létre egy egyéni szimbólummal ellátott felsorolást
- hozhat létre képjeles felpontozást
- hozhat létre többszintű listát a bekezdés mélységének beállításával
- hozhat létre számozott listát
- vizsgálja és módosítsa a lista formázását egy meglévő prezentációban

## **Felsoroláslista létrehozása**

A felsoroláslista létrehozásához adjon [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) objektumokat egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/)‑hez, és állítsa be az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-byte-) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/#Symbol) típusra. Ezután beállíthatja az [IBulletFormat.setChar](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#getColor--) és [IBulletFormat.setHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setHeight-float-) értékeket a felpontozás megjelenésének szabályozásához.

Az alábbi Java‑kód bemutatja, hogyan hozhat létre felsoroláslistát egy dián:

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

![A szimbólumú felsorolások](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-byte-) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/#Numbered) típusra. A számozási formátumot a [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) segítségével választhatja ki, vagy beállíthatja a [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) értékét, ha a lista nem 1‑től kell, hogy induljon.

Az alábbi Java‑kód megmutatja, hogyan hozhat létre számozott listát egy dián:

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

![A számozott felsorolások](numbered_bullets.png)

## **Képjeles felsorolás létrehozása**

Az Aspose.Slides lehetővé teszi, hogy a szabályos felpontozási szimbólumot egy képpel helyettesítse. A képjeles felpontozás leginkább egyszerű, kis méretben is olvasható képekkel működik, például ikonokkal vagy kis áttetsző PNG‑fájlokkal.

{{% alert color="info" %}}
Ideális esetben, ha a szabályos felpontozási szimbólumot képpel szeretné helyettesíteni, érdemes egyszerű grafikát választani átlátszó háttérrel. Az ilyen képek jól használhatók egyéni felpontozási szimbólumként.

Ne feledje, hogy a képet nagyon kis méretre lesz átméretezve. Emiatt erősen ajánljuk, hogy olyan képet válasszon, amely a felpontozásként való használat során is tiszta és vizuálisan hatásos marad.
{{% /alert %}}

A képjeles felpontozás létrehozásához adjon képet a [Presentation.getImages](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getImages--) metódushoz, és rendelje hozzá a visszakapott képtárgyat az [IBulletFormat.getPicture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#getPicture--) metódushoz. Állítsa az [IBulletFormat.setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibulletformat/#setType-byte-) értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/bullettype/#Picture) típusra, mielőtt a képet hozzárendeli.

Tegyük fel, hogy van egy „image.png” fájlunk:

![Kép a felsoroláshoz](picture_for_bullets.png)

Az alábbi Java‑kód bemutatja, hogyan hozhat létre képjeles felpontozást egy dián:

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

![A képjeles felsorolások](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja az [IParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setDepth-short-) metódust a listaelemek különböző szintekre helyezéséhez. A 0‑szint a legfelső, az 1‑szint alatta van, és így tovább.

Az alábbi Java‑kód mutatja, hogyan hozhat létre többszintű felsoroláslistát:

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

A lista formázásának módosításához egy meglévő prezentációban érje el a célbekezdést, és frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getBullet--) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok használhatók a PPT, PPTX vagy ODP fájlból betöltött listák vizsgálatára vagy módosítására.

Az alábbi Java‑kód a szövegkeret első bekezdését számozott lista stílusra állítja:

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

### Exportálhatók a felsorolás- és számozott listák PDF‑re vagy képekre?

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és felpontozási funkciókat.

### Szerkeszthetek listákat meglévő prezentációkban?

Igen. Töltse be a prezentációt, érje el a célbekezdést, vizsgálja vagy frissítse annak [IParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getBullet--) beállításait, majd mentse a prezentációt.

### Tartalmazhatnak a listák nem latin betűket?

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így többnyelvű prezentációkban is létrehozhat listákat. Győződjön meg arról, hogy a prezentációban használt betűtípusok támogatják a szükséges karaktereket.