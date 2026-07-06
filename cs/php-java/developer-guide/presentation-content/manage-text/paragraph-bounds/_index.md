---
title: Získání ohraničení odstavce z prezentací v PHP
linktitle: Ohraničení odstavce
type: docs
weight: 43
url: /cs/php-java/paragraph-bounds/
keywords:
- ohraničení odstavce
- souřadnice odstavce
- velikost odstavce
- textový rámec
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak získat ohraničení odstavce v Aspose.Slides pro PHP pomocí Javy, abyste optimalizovali umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců v Aspose.Slides. Ukazuje, jak pomocí [Paragraph::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/getrect/) získat obdélník odstavce z [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/), jak získat souřadnice odstavce uvnitř textového rámce buňky tabulky a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavce.

## **Získání obdélníkových souřadnic odstavce**

Použijte [Paragraph::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/getrect/) k získání ohraničujícího obdélníku odstavce.

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

## **Získání velikosti odstavce uvnitř textového rámce buňky tabulky**

Chcete-li získat velikost a souřadnice [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) v textovém rámci buňky tabulky, použijte [Paragraph::getRect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/getrect/). Vrácený obdélník je relativní k textovému rámci buňky tabulky, takže přidejte pozici tabulky a offset buňky, pokud potřebujete souřadnice na úrovni snímku.

Následující příklad získá ohraničení odstavce uvnitř buňky tabulky a vykreslí obdélníky na snímku pro vizualizaci těchto ohraničení:

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

## **Často kladené otázky**

**V jakých jednotkách jsou měřeny souřadnice odstavce?**

Měří se v bodech, kde 1 palec odpovídá 72 bodům. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je pro [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) povoleno [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/setwraptext/), text se zalamuje tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převádějte body na pixely pomocí tohoto vzorce: pixely = body x (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslení nebo export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylu?**

Použijte [effective paragraph formatting data structure](/slides/cs/php-java/shape-effective-properties/); vrací konečné konsolidované hodnoty odsazení, mezery, zalamování, RTL a další.