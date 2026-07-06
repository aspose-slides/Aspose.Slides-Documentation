---
title: Bekezdés határainak lekérése a prezentációkból PHP-ben
linktitle: Bekezdés határai
type: docs
weight: 43
url: /hu/php-java/paragraph-bounds/
keywords:
- bekezdés határai
- bekezdés koordináta
- bekezdés mérete
- szövegkeret
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés határait az Aspose.Slides for PHP segítségével Java-n keresztül, a PowerPoint prezentációk szövegpozicionálásának optimalizálása érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet lekérni a bekezdések határait, méretét és koordinátáit az Aspose.Slides-ben. Megmutatja, hogyan lehet egy bekezdés téglalapot lekérni egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) segítségével a [Paragraph::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/getrect/) metódussal, hogyan lehet bekezdés koordinátákat kapni egy táblázatcellában lévő szövegkeretben, és kiemeli a fontos részleteket, például a mérési egységeket, a szöveg tördelésének hatását a határokra, a képpont-konverziót és a hatékony bekezdésformázási értékeket.

## **Bekezdés téglalap koordinátáinak lekérése**

Használja a [Paragraph::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/getrect/) metódust a bekezdés körülhatároló téglalapjának lekéréséhez.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **A táblázatcellában lévő TextFrame bekezdés méretének lekérése**

A [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) méretének és koordinátáinak lekéréséhez egy táblázatcellában lévő szövegkeretben, használja a [Paragraph::getRect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/getrect/) metódust. A visszaadott téglalap a táblázatcellában lévő szövegkerethez relatív, ezért szükség esetén adja hozzá a táblázat pozícióját és a cella eltolását, ha diaszintű koordinátákra van szükség.

Az alábbi példa lekéri a bekezdés határait egy táblázatcellában, és téglalapokat rajzol a diára a határok vizualizálásához:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Milyen egységben mérik a bekezdés koordinátáit?**

A koordinátákat pontban mérik, ahol 1 hüvelyk 72 pontnak felel meg. Ez minden koordinátára és méretre vonatkozik a diáron.

**A szó tördelése befolyásolja a bekezdés határait?**

Igen. Ha a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) számára engedélyezve van a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/setwraptext/) metódus, a szöveg megtörik, hogy illeszkedjen a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők pixelre az exportált képen?**

Igen. A pontokat pixelekre a következő képlettel konvertálhatja: pixel = pont × (DPI / 72). Az eredmény a rendereléshez vagy exportáláshoz kiválasztott DPI-től függ.

**Hogyan kaphatom meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílus öröklődést?**

Használja a [effective paragraph formatting data structure](/slides/hu/php-java/shape-effective-properties/) struktúrát; visszaadja a végső összevont értékeket a behúzásokra, távolságokra, tördelésre, RTL-re és egyebekre vonatkozóan.