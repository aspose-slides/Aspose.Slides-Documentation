---
title: Pobieranie granic akapitu z prezentacji w PHP
linktitle: Granice akapitu
type: docs
weight: 43
url: /pl/php-java/paragraph-bounds/
keywords:
- granice akapitu
- współrzędne akapitu
- rozmiar akapitu
- ramka tekstowa
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu w Aspose.Slides dla PHP za pośrednictwem Java, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu z [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) przy użyciu [Paragraph::getRect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/getrect/), jak uzyskać współrzędne akapitu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję pikseli oraz wartości efektywnego formatowania akapitu.

## **Uzyskaj prostokątne współrzędne akapitu**

Użyj [Paragraph::getRect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/getrect/), aby otrzymać prostokąt ograniczający akapit.

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

## **Uzyskaj rozmiar akapitu wewnątrz ramki tekstowej komórki tabeli**

Aby uzyskać rozmiar i współrzędne [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) w ramce tekstowej komórki tabeli, użyj [Paragraph::getRect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/getrect/). Zwrócony prostokąt jest względem ramki tekstowej komórki tabeli, dlatego należy dodać pozycję tabeli oraz offset komórki, gdy potrzebne są współrzędne na poziomie slajdu.

Poniższy przykład pobiera granice akapitu wewnątrz komórki tabeli i rysuje prostokąty na slajdzie, aby zwizualizować te granice:

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

**W jakich jednostkach mierzone są współrzędne akapitu?**

Są one mierzone w punktach, gdzie 1 cal równa się 72 punktom. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/setwraptext/) jest włączone dla [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/), tekst łamie się, aby dopasować do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie przeliczyć na piksele w wyeksportowanym obrazie?**

Tak. Przelicz punkty na piksele używając wzoru: piksele = punkty × (DPI / 72). Wynik zależy od wybranej rozdzielczości DPI przy renderowaniu lub eksporcie.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [effective paragraph formatting data structure](/slides/pl/php-java/shape-effective-properties/); zwraca ona ostateczne, scentralizowane wartości wcięć, odstępów, zawijania, RTL i innych.