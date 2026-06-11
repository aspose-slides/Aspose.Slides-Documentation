---
title: Wykres
type: docs
weight: 60
url: /pl/php-java/examples/elements/chart/
keywords:
- wykres
- dodaj wykres
- uzyskaj dostęp do wykresu
- usuń wykres
- aktualizuj wykres
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz i dostosowuj wykresy w PHP przy użyciu Aspose.Slides: dodawaj dane, formatuj serie, osie i etykiety, zmieniaj typy oraz eksportuj — działa z PPT, PPTX i ODP."
---
Przykłady dodawania, odczytywania, usuwania i aktualizacji różnych typów wykresów przy użyciu **Aspose.Slides for PHP via Java**. Poniższe fragmenty kodu demonstrują podstawowe operacje na wykresach.

## **Dodaj wykres**

Ta metoda dodaje prosty wykres obszarowy do pierwszego slajdu.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dodaj prosty wykres kolumnowy do slajdu.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uzyskaj dostęp do wykresu**

Pobierz wykres ze zbioru kształtów.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszego wykresu na slajdzie.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń wykres**

Poniższy kod usuwa wykres ze slajdu.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszym kształtem na slajdzie jest wykres.
        $chart = $slide->getShapes()->get_Item(0);

        // Usuń wykres.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Aktualizuj dane wykresu**

Możesz zmienić właściwości wykresu, takie jak tytuł.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszym kształtem na slajdzie jest wykres.
        $chart = $slide->getShapes()->get_Item(0);

        // Zmień tytuł wykresu.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```