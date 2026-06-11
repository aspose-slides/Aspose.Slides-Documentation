---
title: Dostosowywanie osi wykresów w prezentacjach przy użyciu PHP
linktitle: Oś wykresu
type: docs
url: /pl/php-java/chart-axis/
keywords:
- oś wykresu
- pionowa oś
- pozioma oś
- dostosowanie osi
- manipulacja osią
- zarządzanie osią
- właściwości osi
- wartość maksymalna
- wartość minimalna
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Poznaj sposób użycia Aspose.Slides for PHP via Java do dostosowywania osi wykresów w prezentacjach PowerPoint przeznaczonych do raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu w Aspose.Slides. Pokazuje, jak uzyskać rzeczywiste wartości osi, zamienić dane między osiami, ukryć pionową lub poziomą oś w wykresach liniowych, zmienić typ osi kategorii, ustawić format daty dla wartości osi kategorii, obrócić tytuł osi, ustawić pozycję osi oraz wyświetlić etykietę jednostki na osi wartości.

## **Uzyskanie maksymalnych wartości na pionowej osi wykresów**
Aspose.Slides for PHP via Java umożliwia pobranie minimalnych i maksymalnych wartości na pionowej osi. Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Pobierz rzeczywistą maksymalną wartość na osi.
1. Pobierz rzeczywistą minimalną wartość na osi.
1. Pobierz rzeczywistą jednostkę główną osi.
1. Pobierz rzeczywistą jednostkę poboczną osi.
1. Pobierz rzeczywistą skalę jednostki głównej osi.
1. Pobierz rzeczywistą skalę jednostki pobocznej osi.

Ten przykładowy kod — implementacja powyższych kroków — pokazuje, jak uzyskać wymagane wartości:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Zapisuje prezentację
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zamiana danych między osiami**
Aspose.Slides umożliwia szybkie zamienienie danych między osiami — dane przedstawione na pionowej osi (y) przenoszone są na poziomą oś (x) i odwrotnie.

Ten kod PHP pokazuje, jak wykonać zamianę danych między osiami na wykresie:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Przełącza wiersze i kolumny
    $chart->getChartData()->switchRowColumn();
    # Zapisuje prezentację
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wyłączenie pionowej osi w wykresach liniowych**

Ten kod PHP pokazuje, jak ukryć pionową oś w wykresie liniowym:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wyłączenie poziomej osi w wykresach liniowych**

Ten kod pokazuje, jak ukryć poziomą oś w wykresie liniowym:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zmiana osi kategorii**

Korzystając z właściwości **CategoryAxisType**, możesz określić preferowany typ osi kategorii (**date** lub **text**). Ten kod demonstruje operację:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ustawienie formatu daty dla wartości osi kategorii**
Aspose.Slides for PHP via Java umożliwia ustawienie formatu daty dla wartości osi kategorii. Operacja jest pokazana w tym kodzie PHP:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Ustawienie kąta obrotu tytułu osi wykresu**
Aspose.Slides for PHP via Java umożliwia ustawienie kąta obrotu tytułu osi wykresu. Ten kod PHP demonstruje operację:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustawienie pozycji osi na osi kategorii lub wartości**
Aspose.Slides for PHP via Java umożliwia ustawienie pozycji osi w osi kategorii lub wartości. Ten kod PHP pokazuje, jak wykonać to zadanie:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Włączenie wyświetlania etykiety jednostki na osi wartości wykresu**
Aspose.Slides for PHP via Java umożliwia skonfigurowanie wykresu tak, aby wyświetlał etykietę jednostki na osi wartości wykresu. Ten kod PHP demonstruje operację:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Osie oferują [ustawienie przecięcia](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/setcrosstype/): możesz wybrać przecięcie w zerze, w maksymalnej kategorii/wartości lub w konkretnej wartości liczbowej. Jest to przydatne przy przesuwaniu osi X w górę lub w dół lub do podkreślenia linii bazowej.

**Jak mogę ustawić położenie etykiet znaczników względem osi (obok, na zewnątrz, wewnątrz)?**

Ustaw [pozycję etykiety](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/setmajortickmark/) na „cross”, „outside” lub „inside”. Ma to wpływ na czytelność i pomaga zaoszczędzić miejsce, szczególnie w małych wykresach.