---
title: Dostosowywanie wykresów bąbelkowych w prezentacjach przy użyciu PHP
linktitle: Wykres bąbelkowy
type: docs
url: /pl/php-java/bubble-chart/
keywords:
- wykres bąbelkowy
- rozmiar bąbelka
- skalowanie rozmiaru
- reprezentacja rozmiaru
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz i dostosowuj imponujące wykresy bąbelkowe w PowerPoint za pomocą Aspose.Slides for PHP via Java, aby łatwo ulepszyć wizualizację danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresami bąbelkowymi w Aspose.Slides. Obejmuje dwie konkretne opcje konfiguracyjne: skalowanie rozmiarów bąbelków za pomocą metody `setBubbleSizeScale` oraz kontrolowanie, jak wartości rozmiaru bąbelka są reprezentowane za pomocą metody `setBubbleSizeRepresentation`.

Przykłady demonstrują, jak utworzyć wykres bąbelkowy, dostosować skalowanie jego rozmiaru oraz przełączyć reprezentację rozmiaru bąbelka na szerokość. Artykuł zawiera także krótką sekcję FAQ, która wyjaśnia wsparcie dla typu wykresu „Bubble with 3-D”, zauważa, że praktyczne limity wykresów zależą od wydajności i docelowej wersji PowerPoint oraz wyjaśnia, że eksport zachowuje wygląd wykresu dzięki silnikowi renderującemu Aspose.Slides.

## **Skalowanie rozmiaru wykresu bąbelkowego**
Aspose.Slides for PHP via Java zapewnia wsparcie dla skalowania rozmiaru wykresu bąbelkowego. W Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) oraz [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) dodano metody. Poniżej podany jest przykładowy kod.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Reprezentowanie danych jako rozmiary wykresu bąbelkowego**
Dodano metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) oraz [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) do klas [ChartSeries](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/) oraz powiązanych klas. **BubbleSizeRepresentation** określa, w jaki sposób wartości rozmiaru bąbelka są reprezentowane na wykresie bąbelkowym. Możliwe wartości to: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/BubbleSizeRepresentationType#Area) i [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Odpowiednio, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/BubbleSizeRepresentationType) został dodany, aby określić możliwe sposoby reprezentacji danych jako rozmiary wykresu bąbelkowego. Poniżej podany jest przykładowy kod.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy wykres bąbelkowy z efektem 3‑D jest obsługiwany i czym różni się od standardowego?**

Tak. Istnieje osobny typ wykresu „Bubble with 3-D”. Nakłada stylizację 3‑D na bąbelki, ale nie dodaje dodatkowej osi; dane pozostają X‑Y‑S (rozmiar). Typ jest dostępny w klasie [chart type](https://reference.aspose.com/slides/pl/php-java/aspose.slides/charttype/).

**Czy istnieje limit liczby serii i punktów w wykresie bąbelkowym?**

Nie ma sztywnego limitu na poziomie API; ograniczenia są determinowane przez wydajność i docelową wersję PowerPoint. Zaleca się utrzymywanie liczby punktów na rozsądnym poziomie, aby zapewnić czytelność i szybkość renderowania.

**Jak eksport wpłynie na wygląd wykresu bąbelkowego (PDF, obrazy)?**

Eksport do obsługiwanych formatów zachowuje wygląd wykresu; renderowanie jest wykonywane przez silnik Aspose.Slides. Dla formatów rastrowych/wektorowych obowiązują ogólne zasady renderowania grafiki wykresów (rozdzielczość, antyaliasing), dlatego należy wybrać odpowiednią wartość DPI do druku.