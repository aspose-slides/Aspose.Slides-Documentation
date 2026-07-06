---
title: Bekezdés határok lekérése előadásokból JavaScriptben
linktitle: Bekezdés határok
type: docs
weight: 43
url: /hu/nodejs-java/paragraph-bounds/
keywords:
- bekezdés határok
- bekezdés koordináta
- bekezdés méret
- szövegdoboz
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés határokat az Aspose.Slides for Node.js Java használatával a PowerPoint előadások szövegpozíciójának optimalizálásához."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan lehet lekérni egy bekezdés határait, méretét és koordinátáit az Aspose.Slides-ban. Bemutatja, hogyan lehet egy bekezdés téglalapot lekérni egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) segítségével a [Paragraph.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/getrect/) használatával, hogyan lehet a bekezdés koordinátáit egy táblázatcellához tartozó szövegdobozban lekérni, és kiemeli a fontos részleteket, mint a mérési egységek, a szöveg tördelésének hatása a határokra, a képpontkonverzió és a „hatékony” bekezdés formázási értékek.

## **Bekezdés téglalap koordinátáinak lekérése**

Használja a [Paragraph.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/getrect/) metódust a bekezdés határoló téglalapjának lekéréséhez.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Bekezdés méretének lekérése egy táblázatcellában lévő TextFrame-ben**

A [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) méretének és koordinátáinak lekéréséhez egy táblázatcellában lévő szövegdobozban, használja a [Paragraph.getRect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/getrect/) metódust. A visszaadott téglalap a táblázatcella szövegdobozhoz viszonyított, ezért adja hozzá a táblázat pozícióját és a cella eltolását, ha diákszintű koordinátákra van szükség.

Az alábbi példa lekéri a bekezdés határait egy táblázatcellában, és téglalapokat rajzol a diára a határok megjelenítéséhez:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Milyen egységben mérik a bekezdés koordinátáit?**

A pontokban (points) mérik, ahol 1 hüvelyk 72 pontnak felel meg. Ez minden koordinátára és méretre a dián vonatkozik.

**A szöveg tördelése befolyásolja a bekezdés határait?**

Igen. Ha a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/setwraptext/) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) számára, a szöveg megtörik, hogy illeszkedjen a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők képpontokra az exportált képen?**

Igen. A pontokat képpontokra a következő képlettel lehet konvertálni: pixelek = pontok x (DPI / 72). Az eredmény a rendereléshez vagy exportáláshoz kiválasztott DPI-től függ.

**Hogyan kaphatom meg a „hatékony” bekezdés formázási paramétereket, a stílusöröklés figyelembevételével?**

Használja a [effective paragraph formatting data structure](/slides/hu/nodejs-java/shape-effective-properties/) elemet; ez visszaadja a végső összevont értékeket a behúzásokra, térközökre, tördelésre, RTL-re és egyebekre vonatkozóan.