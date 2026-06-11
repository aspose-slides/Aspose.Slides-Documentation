---
title: Eksport wykresów z prezentacji w PHP
linktitle: Eksport wykresu
type: docs
weight: 90
url: /pl/php-java/export-chart/
keywords:
- wykres
- wykres do obrazu
- wykres jako obraz
- wyodrębnij obraz wykresu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak eksportować wykresy z prezentacji za pomocą Aspose.Slides dla PHP poprzez Java, obsługując formaty PPT i PPTX, oraz usprawnić raportowanie w dowolnym przepływie pracy."
---
## **Przegląd**

Aspose.Slides umożliwia wyeksportowanie wykresu z prezentacji jako obrazu. Ten artykuł pokazuje, jak uzyskać obraz wykresu i zapisać go, co jest przydatne, gdy trzeba ponownie wykorzystać wizualizacje wykresu poza prezentacją PowerPoint.

## **Uzyskaj obraz wykresu**
Aspose.Slides for PHP via Java zapewnia obsługę wyodrębniania obrazu konkretnego wykresu. Poniżej podany jest przykładowy kod.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę wyeksportować wykres jako wektor (SVG) zamiast obrazu rastrowego?**

Tak. Wykres jest kształtem, a jego zawartość można zapisać jako SVG przy użyciu [metody zapisu shape-to-SVG](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/writeassvg/).

**Jak mogę ustawić dokładny rozmiar wyeksportowanego wykresu w pikselach?**

Użyj przeciążeń renderowania obrazu, które umożliwiają określenie rozmiaru lub skali — biblioteka obsługuje renderowanie obiektów o podanych wymiarach/skali.

**Co powinienem zrobić, jeśli czcionki w etykietach i legendzie wyglądają nieprawidłowo po eksporcie?**

[Załaduj wymagane czcionki](/slides/pl/php-java/custom-font/) za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/), aby renderowanie wykresu zachowało metryki i wygląd tekstu.

**Czy eksport respektuje motyw, style i efekty PowerPointa?**

Tak. Renderowanie Aspose.Slides stosuje formatowanie prezentacji (motywy, style, wypełnienia, efekty), dzięki czemu wygląd wykresu jest zachowany.

**Gdzie mogę znaleźć dostępne możliwości renderowania/eksportu poza obrazami wykresów?**

Zobacz [API](https://reference.aspose.com/slides/pl/php-java/aspose.slides/)/[dokumentację](/slides/pl/php-java/convert-powerpoint/) dotyczącą docelowych formatów wyjściowych ([PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/pl/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/pl/php-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/php-java/convert-powerpoint-to-html/), itp.) oraz powiązane opcje renderowania.