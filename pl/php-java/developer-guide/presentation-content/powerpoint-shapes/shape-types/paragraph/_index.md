---
title: Pobierz granice akapitu z prezentacji w PHP
linktitle: Akapit
type: docs
weight: 60
url: /pl/php-java/paragraph/
keywords:
- granice akapitu
- granice fragmentu tekstu
- współrzędne akapitu
- współrzędne fragmentu
- rozmiar akapitu
- rozmiar fragmentu tekstu
- ramka tekstowa
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu i fragmentu tekstu w Aspose.Slides dla PHP poprzez Java, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów oraz fragmentów tekstu w Aspose.Slides. Pokazuje, jak przy użyciu `getRect()` pobrać prostokąt akapitu w `TextFrame`, jak uzyskać współrzędne akapitu i fragmentu w ramce tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję na piksele oraz wartości efektywnego formatowania akapitu.

## **Pobieranie współrzędnych akapitu i fragmentu w TextFrame**
Korzystając z Aspose.Slides dla PHP poprzez Java, programiści mogą teraz uzyskać prostokątne współrzędne akapitu w kolekcji akapitów TextFrame. Umożliwia to także pobranie [współrzędne fragmentu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#getCoordinates) w kolekcji fragmentów akapitu. W tym temacie pokażemy na przykładzie, jak uzyskać prostokątne współrzędne akapitu wraz z pozycją fragmentu wewnątrz akapitu.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **Pobieranie prostokątnych współrzędnych akapitu**
Za pomocą metody [**getRect()**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#getRect) programiści mogą uzyskać prostokąt granic akapitu.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Pobieranie rozmiaru akapitu i fragmentu w ramce tekstowej komórki tabeli**

Aby uzyskać rozmiar i współrzędne [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Portion) lub [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Paragraph) w ramce tekstowej komórki tabeli, można użyć metod [Portion::getRect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#getRect) i [Paragraph::getRect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/#getRect).

Ten przykładowy kod demonstruje opisaną operację:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**W jakich jednostkach podawane są współrzędne akapitu i fragmentów tekstu?**

W punktach, gdzie 1 cal = 72 punkty. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [zawijanie](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/setwraptext/) jest włączone w [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/), tekst dzieli się, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie przeliczyć na piksele w wyeksportowanym obrazie?**

Tak. Konwertuj punkty na piksele używając: pixels = points × (DPI / 72). Wynik zależy od wybranej DPI przy renderowaniu/eksportowaniu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [struktury danych efektywnego formatowania akapitu](/slides/pl/php-java/shape-effective-properties/); zwraca ona ostateczne, skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.