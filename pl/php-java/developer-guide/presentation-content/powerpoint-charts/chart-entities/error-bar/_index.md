---
title: Dostosowywanie słupków błędów w wykresach prezentacji przy użyciu PHP
linktitle: Słupki błędów
type: docs
url: /pl/php-java/error-bar/
keywords:
- słupek błędu
- niestandardowa wartość
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak dodać i dostosować słupki błędów w wykresach za pomocą Aspose.Slides dla PHP via Java — zoptymalizuj wizualizację danych w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z słupkami błędów w wykresach w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak dodać słupki błędów do serii wykresu, skonfigurować ustawienia słupków błędów X i Y oraz zastosować różne typy wartości, takie jak stałe, procentowe i niestandardowe.

Pokazuje również, jak przypisać niestandardowe wartości słupków błędów do poszczególnych punktów danych w serii, korzystając z odpowiedniej kolekcji punktów danych. Dodatkowo artykuł zawiera krótkie uwagi na temat zachowania słupków błędów podczas eksportu, ich kompatybilności ze znacznikami i etykietami danych oraz gdzie znaleźć powiązane klasy i wyliczenia w dokumentacji API.

## **Dodaj słupki błędów**
Aspose.Slides for PHP via Java udostępnia prosty interfejs API do zarządzania wartościami słupków błędów. Przykładowy kod ma zastosowanie przy użyciu typu wartości niestandardowej. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji [**data points**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriescollection/) serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Dodaj wykres bąbelkowy na wybranym slajdzie.
3. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu X.
4. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu Y.
5. Ustaw wartości słupków i ich format.
6. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    # Tworzenie wykresu bąbelkowego
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Dodawanie słupków błędów i ustawianie ich formatu
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Zapisywanie prezentacji
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dodaj niestandardowe wartości słupków błędów**
Aspose.Slides for PHP via Java udostępnia prosty interfejs API do zarządzania niestandardowymi wartościami słupków błędów. Przykładowy kod ma zastosowanie, gdy metoda [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/errorbarsformat/#getValueType) zwraca **Custom**. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji [**data points**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriescollection/) serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Dodaj wykres bąbelkowy na wybranym slajdzie.
3. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu X.
4. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu Y.
5. Uzyskaj dostęp do poszczególnych punktów danych serii wykresu i ustaw wartości słupka błędu dla indywidualnego punktu danych serii.
6. Ustaw wartości słupków i ich format.
7. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    # Tworzenie wykresu bąbelkowego
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Dodawanie niestandardowych słupków błędów i ustawianie ich formatu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Dostęp do punktu danych serii wykresu i ustawianie wartości słupków błędów dla
    # poszczególnego punktu
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Ustawianie słupków błędów dla punktów serii wykresu
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Zapisywanie prezentacji
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Co się dzieje ze słupkami błędów podczas eksportu prezentacji do PDF lub obrazów?**

Są renderowane jako część wykresu i zachowywane podczas konwersji wraz z resztą formatowania wykresu, pod warunkiem użycia kompatybilnej wersji lub renderera.

**Czy słupki błędów można łączyć ze znacznikami i etykietami danych?**

Tak. Słupki błędów są oddzielnym elementem i są kompatybilne ze znacznikami i etykietami danych; jeśli elementy nakładają się, może być konieczne dostosowanie formatowania.

**Gdzie mogę znaleźć listę właściwości i klas do pracy ze słupkami błędów w API?**

W dokumentacji API: klasa [ErrorBarsFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/errorbarsformat/) oraz powiązane klasy [ErrorBarType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/errorbartype/) i [ErrorBarValueType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/errorbarvaluetype/).