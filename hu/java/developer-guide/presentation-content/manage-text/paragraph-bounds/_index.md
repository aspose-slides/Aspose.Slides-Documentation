---
title: Bekezdés határainak lekérése prezentációkból Java-ban
linktitle: Bekezdés határai
type: docs
weight: 43
url: /hu/java/paragraph-bounds/
keywords:
- bekezdés határai
- bekezdés koordináta
- bekezdés mérete
- szövegkeret
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés határait az Aspose.Slides for Java-ban, hogy optimalizálja a szöveg elhelyezését PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet lekérni a bekezdések határait, méretét és koordinátáit az Aspose.Slides-ban. Megmutatja, hogyan lehet egy bekezdés téglalapját lekérni egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) segítségével a [IParagraph.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IParagraph#getRect--) használatával, hogyan lehet a bekezdés koordinátáit egy táblázatcella szövegkeretén belül lekérni, és kiemeli a fontos részleteket, például a mérőegységeket, a szöveg tördelésének hatását a határokra, a pixelkonverziót és a hatékony bekezdésformázási értékeket.

## **Bekezdés téglalap koordinátáinak lekérése**

Használja a [IParagraph.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IParagraph#getRect--) metódust a bekezdés körülhatároló téglalapjának lekéréséhez.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **A bekezdés méretének lekérése egy táblázatcella szövegkeretén belül**

A [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) méretének és koordinátáinak egy táblázatcella szövegkeretében való lekéréséhez használja a [IParagraph.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IParagraph#getRect--) metódust. A visszaadott téglalap a táblázatcella szövegkeretéhez képest relatív, ezért a diaszintű koordinátákhoz adja hozzá a tábla pozícióját és a cella eltolását.

A következő példában lekéri a bekezdés határait egy táblázatcella belül, és téglalapokat rajzol a diára a határok megjelenítéséhez:

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

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

**Milyen mértékegységben mérik a bekezdés koordinátáit?**

A koordinátákat pontban (point) mérik, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre vonatkozik a diámon.

**A szöveg tördelése befolyásolja a bekezdés határait?**

Igen. Ha a [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) be van kapcsolva a [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/), a szöveg megtörik, hogy illeszkedjen a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők a pixelre az exportált képen?**

Igen. A pontokat pixelekre a következő képlettel konvertálhatja: pixel = pont x (DPI / 72). Az eredmény a rendereléshez vagy exportáláshoz választott DPI-től függ.

**Hogyan kaphatok meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílusöröklődést?**

Használja a [effective paragraph formatting data structure](/slides/hu/java/shape-effective-properties/) struktúrát; ez visszaadja a behúzások, távolságok, tördelés, RTL és egyéb beállítások végső, konszolidált értékeit.