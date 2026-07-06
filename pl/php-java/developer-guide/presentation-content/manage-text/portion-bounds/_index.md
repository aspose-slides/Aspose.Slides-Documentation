---
title: Pobieranie granic fragmentu tekstu z prezentacji w PHP
linktitle: Granice fragmentu
type: docs
weight: 47
url: /pl/php-java/portion-bounds/
keywords:
- granice fragmentu tekstu
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice fragmentu tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP przez Java."
---
## **Przegląd**

Fragment tekstu reprezentuje konkretny fragment tekstu wewnątrz akapitu i pozwala pracować z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides fragmenty można używać, gdy potrzebne jest pobranie granic fragmentu tekstu, zastosowanie formatowania tylko do części akapitu lub kontrolowanie zachowania tekstu na bardziej szczegółowym poziomie.

Ten artykuł pokazuje, jak uzyskać prostokąt ograniczający fragment, używając [Portion::getRect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/getrect/). Pokazuje również, jak uzyskać współrzędne początku fragmentu, używając [Portion::getCoordinates](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/getcoordinates/). Dodatkowo podkreśla typowe scenariusze związane z fragmentami, takie jak zastosowanie hiperlinku do pojedynczego fragmentu tekstu, zrozumienie, jak formatowanie jest dziedziczone przez fragment, akapit, ramkę tekstową i motyw, oraz obsługę przypadków, gdy określona czcionka jest niedostępna.

## **Uzyskanie granic fragmentu tekstowego**

Użyj [Portion::getRect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/getrect/) aby pobrać prostokąt ograniczający fragment tekstowy:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Uzyskanie współrzędnych fragmentu tekstowego**

Użyj [Portion::getCoordinates](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/getcoordinates/) aby pobrać współrzędne początku fragmentu tekstowego:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Najczęściej zadawane pytania**

**Czy mogę zastosować hiperlink tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperlink](/slides/pl/php-java/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylów: co fragment nadpisuje, a co jest pobierane z akapitu lub ramki tekstowej?**

Właściwości na poziomie fragmentu mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona na [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/), Aspose.Slides pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/). Jeśli nie jest ustawiona również tam, Aspose.Slides używa stylu z [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) lub [theme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/theme/).

**Co się stanie, jeśli czcionka określona dla fragmentu jest nieobecna na docelowym komputerze lub serwerze?**

Obowiązują [zasady podstawiania czcionek](/slides/pl/php-java/font-selection-sequence/). Tekst może się przerywać: metryki, podział wyrazów i szerokość mogą się zmienić, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.