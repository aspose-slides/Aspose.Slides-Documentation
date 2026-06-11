---
title: Zarządzanie fragmentami tekstu w prezentacjach przy użyciu PHP
linktitle: Fragment tekstu
type: docs
weight: 70
url: /pl/php-java/portion/
keywords:
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak zarządzać fragmentami tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Java, zwiększając wydajność i możliwości dostosowania."
---
## **Wprowadzenie**

Fragment tekstu reprezentuje konkretny fragment tekstu wewnątrz akapitu i umożliwia pracę z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides fragmenty można używać, gdy potrzebujesz pobrać pozycję fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

## **Pobieranie współrzędnych fragmentu tekstu**
[**getCoordinates()**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/getcoordinates/) metoda została dodana do klasy [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/), co pozwala na pobranie współrzędnych początku fragmentu.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Przekształcanie kontekstu prezentacji
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę zastosować hiperlink tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperlink](/slides/pl/php-java/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylów: co nadpisuje fragment, a co jest pobierane z akapitu/ramki tekstu?**

Właściwości na poziomie fragmentu mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona w [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/), silnik pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/); jeśli nie jest tam ustawiona, z [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) lub stylu [theme](https://reference.aspose.com/slides/pl/php-java/aspose.slides/theme/).

**Co się stanie, jeśli czcionka określona dla fragmentu nie jest dostępna na docelowym komputerze/serwerze?**

[Zasady podstawiania czcionek](/slides/pl/php-java/font-selection-sequence/) mają zastosowanie. Tekst może ulec przestawieniu: metryki, dzielenie wyrazów i szerokość mogą się zmienić, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu, niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.