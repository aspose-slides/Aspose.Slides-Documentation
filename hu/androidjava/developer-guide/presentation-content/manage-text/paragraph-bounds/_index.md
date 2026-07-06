---
title: Bekezdés határok lekérdezése Android prezentációkból
linktitle: Bekezdés határok
type: docs
weight: 43
url: /hu/androidjava/paragraph-bounds/
keywords:
- bekezdés határok
- bekezdés koordináta
- bekezdés méret
- szövegkeret
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés határokat az Aspose.Slides for Android-ban Java segítségével a PowerPoint prezentációk szövegpozicionálásának optimalizálása érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet lekérni a bekezdések határait, méretét és koordinátáit az Aspose.Slides-ban. Megmutatja, hogyan lehet egy bekezdés téglalapját lekérni egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) segítségével a [IParagraph.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraph#getRect--) használatával, hogyan lehet a bekezdés koordinátáit egy táblázatcella szövegkeretben lekérni, és kiemeli a fontos részleteket, például a mérési egységeket, a szövegcsomagolás hatását a határokra, a pixelkonverziót és a hatékony bekezdésformázási értékeket.

## **Paragrafus téglalap koordinátáinak lekérése**

Használja a [IParagraph.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraph#getRect--) metódust egy bekezdés határoló téglalapjának lekéréséhez.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Paragrafus méretének lekérése egy táblázatcella TextFrame-ben**

Egy [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) méretének és koordinátáinak lekéréséhez egy táblázatcella szövegkeretében használja a [IParagraph.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraph#getRect--) metódust. A visszaadott téglalap a táblázatcella szövegkeretére vonatkozik, így a táblázat pozícióját és a cella eltolását kell hozzáadni, ha diaszintű koordinátákra van szükség.

Az alábbi példa lekéri a bekezdés határait egy táblázatcellán belül, és téglalapokat rajzol a diára a határok megjelenítéséhez:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Milyen egységben vannak megadva a bekezdés koordinátái?**

A koordináták pontban (point) vannak megadva, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre a dián érvényes.

**A szövegcsomagolás befolyásolja a bekezdés határait?**

Igen. Ha a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) be van kapcsolva az [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) számára, a szöveg megtörik, hogy illeszkedjen a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők pixelekre az exportált képen?**

Igen. A pontok pixelekké történő átalakításához használja a következő képletet: pixel = pont × (DPI / 72). Az eredmény a rendereléshez vagy exportáláshoz választott DPI-től függ.

**Hogyan kaphatom meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílus öröklődését?**

Használja a [hatékony bekezdésformázási adatstruktúrát](/slides/hu/androidjava/shape-effective-properties/); ez visszaadja a behúzások, sortávolságok, csomagolás, jobb‑bal irány (RTL) és egyéb beállítások végső, konszolidált értékeit.