---
title: Zarządzaj znacznikami danych wykresu w prezentacjach przy użyciu PHP
linktitle: Znacznik danych
type: docs
url: /pl/php-java/chart-data-marker/
keywords:
- wykres
- punkt danych
- znacznik
- opcje znacznika
- rozmiar znacznika
- typ wypełnienia
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak dostosować znaczniki danych wykresu w Aspose.Slides dla PHP, zwiększając efekt prezentacji w formatach PPT i PPTX dzięki przejrzystym przykładom kodu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować ze znacznikami danych wykresu w Aspose.Slides. Pokazuje, jak utworzyć wykres, uzyskać dostęp do serii i jej punktów danych, zastosować wypełnienie obrazem do znaczników na poziomie punktu danych, dostosować rozmiar znacznika oraz zapisać zaktualizowaną prezentację. Zawiera również informację, że standardowe kształty znaczników są dostępne poprzez wyliczenie `MarkerStyleType` oraz że wygląd znacznika jest zachowywany przy eksportowaniu wykresów do formatów rastrowych lub SVG.

## **Ustaw opcje znacznika wykresu**
Znaczniki można ustawić na punktach danych wykresu w określonych seriach. Aby ustawić opcje znacznika wykresu, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Ustaw obraz.
- Weź pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy opcje znacznika wykresu na poziomie punktów danych.

```php
  # Tworzenie pustej prezentacji
  $pres = new Presentation();
  try {
    # Dostęp do pierwszego slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Tworzenie domyślnego wykresu
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Pobieranie indeksu domyślnego arkusza danych wykresu
    $defaultWorksheetIndex = 0;
    # Pobieranie arkusza danych wykresu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Usuwanie serii demonstracyjnej
    $chart->getChartData()->getSeries()->clear();
    # Dodawanie nowej serii
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Ładowanie obrazu 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Ładowanie obrazu 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Pobranie pierwszej serii wykresu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Dodanie nowego punktu (1:3) tam.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Zmienianie znacznika serii wykresu
    $series->getMarker()->setSize(15);
    # Zapis prezentacji z wykresem
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Jakie kształty znaczników są dostępne od razu?**

Dostępne są standardowe kształty (koło, kwadrat, romb, trójkąt itp.); lista jest określona przez klasę [MarkerStyleType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markerstyletype/). Jeśli potrzebujesz kształtu niestandardowego, użyj znacznika z wypełnieniem obrazem, aby emulować własne elementy wizualne.

**Czy znaczniki są zachowywane przy eksporcie wykresu do obrazu lub SVG?**

Tak. Podczas renderowania wykresów do [formatów rastrowych](/slides/pl/php-java/convert-powerpoint-to-png/) lub zapisywania [kształtów jako SVG](/slides/pl/php-java/render-a-slide-as-an-svg-image/), znaczniki zachowują swój wygląd i ustawienia, w tym rozmiar, wypełnienie i obrys.