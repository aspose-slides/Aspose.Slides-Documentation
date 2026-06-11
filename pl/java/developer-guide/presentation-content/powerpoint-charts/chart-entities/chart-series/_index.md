---
title: Zarządzanie seriami danych wykresu w prezentacjach przy użyciu Javy
linktitle: Serie danych
type: docs
url: /pl/java/chart-series/
keywords:
- seria wykresu
- nakładanie serii
- kolor serii
- kolor kategorii
- nazwa serii
- punkt danych
- przerwa serii
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresów w Javie dla PowerPoint (PPT/PPTX) przy użyciu praktycznych przykładów kodu i najlepszych praktyk, aby ulepszyć prezentacje danych."
---
## **Przegląd**

Ten artykuł opisuje rolę [ChartSeries](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartseries/) w Aspose.Slides, koncentrując się na tym, jak dane są strukturyzowane i wizualizowane w prezentacjach. Obiekty te zapewniają podstawowe elementy definiujące poszczególne zestawy punktów danych, kategorie oraz parametry wyglądu wykresu. Pracując z [ChartSeries](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartseries/), programiści mogą płynnie integrować źródła danych i zachować pełną kontrolę nad sposobem wyświetlania informacji, co skutkuje dynamicznymi, opartymi na danych prezentacjami jasno przekazującymi wnioski i analizy.

Seria to wiersz lub kolumna liczb wykreślona na wykresie.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii wykresu**

Za pomocą właściwości [IChartSeriesOverlap](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/properties/overlap) można określić, jak bardzo słupki i kolumny powinny nakładać się na wykresie 2D (zakres: -100 do 100). Właściwość ta ma zastosowanie do wszystkich serii w grupie nadrzędnej serii: jest to projekcja odpowiedniej właściwości grupy. Dlatego właściwość ta jest tylko do odczytu.

Użyj właściwości odczytu/zapisu `ParentSeriesGroup.Overlap`, aby ustawić preferowaną wartość `Overlap`.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Dodaj wykres słupkowy grupowy na slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu.
1. Uzyskaj dostęp do `ParentSeriesGroup` serii wykresu i ustaw preferowaną wartość nakładania dla serii.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
Presentation pres = new Presentation();
try {
    // Dodaje wykres
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Ustawia nakładanie serii
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Zapisuje plik prezentacji na dysku
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zmień kolor serii**

Aspose.Slides for Java umożliwia zmianę koloru serii w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Uzyskaj dostęp do serii, której kolor chcesz zmienić.
1. Ustaw preferowany typ wypełnienia i kolor wypełnienia.
1. Zapisz zmodyfikowaną prezentację.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zmień kolor kategorii serii**

Aspose.Slides for Java umożliwia zmianę koloru kategorii serii w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Uzyskaj dostęp do kategorii serii, której kolor chcesz zmienić.
1. Ustaw preferowany typ wypełnienia i kolor wypełnienia.
1. Zapisz zmodyfikowaną prezentację.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zmień nazwę serii**

Domyślnie nazwy legendy wykresu pochodzą z zawartości komórek powyżej każdej kolumny lub wiersza danych.

W naszym przykładzie (obraz przykładowy),

* kolumny to *Series 1, Series 2,* i *Series 3*;
* wiersze to *Category 1, Category 2, Category 3,* i *Category 4.*

Aspose.Slides for Java umożliwia aktualizację lub zmianę nazwy serii w danych wykresu i legendzie.

Ten kod Java pokazuje, jak zmienić nazwę serii w danych wykresu `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ten kod Java pokazuje, jak zmienić nazwę serii w legendzie za pomocą`Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw wypełnienie serii wykresu**

Aspose.Slides for Java umożliwia ustawienie automatycznego koloru wypełnienia serii wykresu w obszarze wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Pobierz referencję slajdu po jego indeksie.
1. Dodaj wykres z domyślnymi danymi, wybierając preferowany typ (w poniższym przykładzie użyliśmy `ChartType.ClusteredColumn`).
1. Uzyskaj dostęp do serii wykresu i ustaw kolor wypełnienia na Automatic.
1. Zapisz prezentację do pliku PPTX.

```java
Presentation pres = new Presentation();
try {
    // Tworzy wykres słupkowy grupowy
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Ustawia format wypełnienia serii na automatyczny
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Zapisuje plik prezentacji na dysku
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Aspose.Slides umożliwia ustawienie odwróconego koloru wypełnienia serii wykresu w obszarze wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Pobierz referencję slajdu po jego indeksie.
1. Dodaj wykres z domyślnymi danymi, wybierając preferowany typ (w poniższym przykładzie użyliśmy `ChartType.ClusteredColumn`).
1. Uzyskaj dostęp do serii wykresu i ustaw kolor wypełnienia na invert.
1. Zapisz prezentację do pliku PPTX.

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Dodaje nowe serie i kategorie
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Pobiera pierwszą serię wykresu i wypełnia jej dane.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw serię, aby odwracała się przy wartości ujemnej**

Aspose.Slides umożliwia ustawienie odwrócenia za pomocą właściwości`IChartDataPoint.InvertIfNegative` oraz `ChartDataPoint.InvertIfNegative`. Gdy odwrócenie jest ustawione przy użyciu tych właściwości, punkt danych odwraca swoje kolory przy otrzymaniu wartości ujemnej.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Wyczyść dane konkretnych punktów**

Aspose.Slides for Java umożliwia wyczyszczenie danych `DataPoints` dla konkretnej serii wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Pobierz referencję slajdu po jego indeksie.
3. Pobierz referencję wykresu po jego indeksie.
4. Przejdź po wszystkich `DataPoints` wykresu i ustaw `XValue` oraz `YValue` na null.
5. Wyczyść wszystkie`DataPoints` dla konkretnej serii wykresu.
6. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw szerokość przerwy serii**

Aspose.Slides for Java umożliwia ustawienie szerokości przerwy serii poprzez właściwość **`GapWidth`** w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Uzyskaj dostęp do dowolnej serii wykresu.
1. Ustaw właściwość `GapWidth`.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
// Tworzy pustą prezentację 
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu prezentacji
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodaje wykres z domyślnymi danymi
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Ustawia indeks arkusza danych wykresu
    int defaultWorksheetIndex = 0;
    
    // Pobiera arkusz danych wykresu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Dodaje serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Dodaje kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Pobiera drugą serię wykresu
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Wypełnia dane serii
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ustawia wartość GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Zapisuje prezentację na dysku
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy istnieje limit liczby serii, które może zawierać pojedynczy wykres?**

Aspose.Slides nie nakłada stałego limitu na liczbę dodawanych serii. Praktyczne ograniczenie wynika z czytelności wykresu oraz dostępnej pamięci aplikacji.

**Co zrobić, gdy kolumny w klastrze są ze sobą zbyt blisko lub zbyt oddalone?**

Reguluj ustawienie `GapWidth` dla tej serii (lub jej grupy nadrzędnej). Zwiększenie wartości powiększa odstęp między kolumnami, a zmniejszenie go zbliża kolumny do siebie.