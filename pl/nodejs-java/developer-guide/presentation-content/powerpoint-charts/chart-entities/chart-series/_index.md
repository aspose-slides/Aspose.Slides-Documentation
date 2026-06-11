---
title: Zarządzaj danymi serii wykresu w prezentacjach przy użyciu JavaScript
linktitle: Serie danych
type: docs
url: /pl/nodejs-java/chart-series/
keywords:
- seria wykresu
- nakładanie serii
- kolor serii
- kolor kategorii
- nazwa serii
- punkt danych
- luka serii
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu w JavaScript dla PowerPoint (PPT/PPTX) z praktycznymi przykładami kodu i najlepszymi praktykami, aby ulepszyć swoje prezentacje danych."
---
## **Przegląd**

Ten artykuł opisuje rolę [ChartSeries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/) w Aspose.Slides, koncentrując się na tym, jak dane są strukturalizowane i wizualizowane w prezentacjach. Te obiekty zapewniają podstawowe elementy definiujące poszczególne zestawy punktów danych, kategorie i parametry wyglądu wykresu. Pracując z [ChartSeries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/), programiści mogą płynnie integrować źródła danych i zachować pełną kontrolę nad sposobem wyświetlania informacji, co skutkuje dynamicznymi, opartymi na danych prezentacjami jasno przekazującymi wnioski i analizy.

Seria to wiersz lub kolumna liczb wykreślona na wykresie.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii wykresu**

Za pomocą metody [ChartSeries.getOverlap](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#getOverlap) możesz określić, w jakim stopniu słupki i kolumny powinny się nakładać na wykresie 2D (zakres: -100 do 100). Ta właściwość ma zastosowanie do wszystkich serii w grupie serii nadrzędnej: jest to projekcja odpowiedniej właściwości grupy. Dlatego właściwość jest tylko do odczytu.

Użyj właściwości odczytu/zapisu `ParentSeriesGroup.getOverlap`, aby ustawić preferowaną wartość dla `Overlap`.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Dodaj wykres kolumnowy grupowany na slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu.
1. Uzyskaj dostęp do `ParentSeriesGroup` serii wykresu i ustaw preferowaną wartość nakładania dla serii.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten kod JavaScript pokazuje, jak ustawić nakładanie dla serii wykresu:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje wykres
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Ustawia nakładanie serii
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Zapisuje plik prezentacji na dysku
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zmień kolor serii**

Aspose.Slides dla Node.js przez Java umożliwia zmianę koloru serii w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Uzyskaj dostęp do serii, której kolor chcesz zmienić.
1. Ustaw preferowany typ wypełnienia i kolor wypełnienia.
1. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript pokazuje, jak zmienić kolor serii:
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zmień kolor kategorii serii**

Aspose.Slides dla Node.js przez Java umożliwia zmianę koloru kategorii serii w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Uzyskaj dostęp do kategorii serii, której kolor chcesz zmienić.
1. Ustaw preferowany typ wypełnienia i kolor wypełnienia.
1. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript pokazuje, jak zmienić kolor kategorii serii:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zmień nazwę serii** 

Domyślnie nazwy w legendzie wykresu pochodzą z zawartości komórek nad każdą kolumną lub wierszem danych. 

W naszym przykładzie (obraz przykładowy), 

* kolumny to *Series 1, Series 2,* i *Series 3*;
* wiersze to *Category 1, Category 2, Category 3,* i *Category 4.* 

Aspose.Slides dla Node.js przez Java umożliwia aktualizację lub zmianę nazwy serii w danych wykresu i legendzie.

Ten kod JavaScript pokazuje, jak zmienić nazwę serii w danych wykresu `ChartDataWorkbook`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ten kod JavaScript pokazuje, jak zmienić nazwę serii w legendzie za pomocą `Series`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw kolor wypełnienia serii wykresu**

Aspose.Slides dla Node.js przez Java umożliwia ustawienie automatycznego koloru wypełnienia dla serii wykresu w obszarze wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj referencję do slajdu według jego indeksu.
1. Dodaj wykres z domyślnymi danymi o wybranym typie (w poniższym przykładzie użyliśmy `ChartType.ClusteredColumn`).
1. Uzyskaj dostęp do serii wykresu i ustaw kolor wypełnienia na Automatic.
1. Zapisz prezentację do pliku PPTX.

Ten kod JavaScript pokazuje, jak ustawić automatyczny kolor wypełnienia dla serii wykresu:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Tworzy wykres kolumnowy grupowany
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Ustawia format wypełnienia serii na automatyczny
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Zapisuje plik prezentacji na dysku
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw odwrócone kolory wypełnienia serii wykresu**

Aspose.Slides umożliwia ustawienie odwróconego koloru wypełnienia dla serii wykresu w obszarze wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj referencję do slajdu według jego indeksu.
1. Dodaj wykres z domyślnymi danymi o wybranym typie (w poniższym przykładzie użyliśmy `ChartType.ClusteredColumn`).
1. Uzyskaj dostęp do serii wykresu i ustaw kolor wypełnienia na invert.
1. Zapisz prezentację do pliku PPTX.

Ten kod JavaScript demonstruje operację:
```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Dodaje nowe serie i kategorie
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Pobiera pierwszą serię wykresu i wypełnia jej dane.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw odwracanie serii przy wartości ujemnej**

Aspose.Slides umożliwia ustawienie odwróceń za pomocą metody `ChartDataPoint.setInvertIfNegative`. Gdy odwrócenie jest ustawione przy użyciu właściwości, punkt danych odwraca swoje kolory, gdy otrzyma wartość ujemną. 

Ten kod JavaScript demonstruje operację:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Wyczyść dane określonych punktów danych**

Aspose.Slides dla Node.js przez Java umożliwia wyczyszczenie danych `DataPoints` dla określonej serii wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu poprzez jego indeks.
3. Uzyskaj referencję do wykresu poprzez jego indeks.
4. Iteruj przez wszystkie `DataPoints` wykresu i ustaw `XValue` oraz `YValue` na null.
5. Wyczyść wszystkie`DataPoints` dla określonej serii wykresu.
6. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten kod JavaScript demonstruje operację:
```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw szerokość luki serii**

Aspose.Slides dla Node.js przez Java umożliwia ustawienie szerokości luki serii za pomocą właściwości **`GapWidth`** w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Uzyskaj dostęp do dowolnej serii wykresu.
1. Ustaw właściwość `GapWidth`.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten kod JavaScript pokazuje, jak ustawić szerokość luki serii:
```javascript
// Tworzy pustą prezentację
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu prezentacji
    var slide = pres.getSlides().get_Item(0);
    // Dodaje wykres z domyślnymi danymi
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Ustawia indeks arkusza danych wykresu
    var defaultWorksheetIndex = 0;
    // Pobiera arkusz danych wykresu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Dodaje serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Dodaje kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Pobiera drugą serię wykresu
    var series = chart.getChartData().getSeries().get_Item(1);
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
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy istnieje limit liczby serii, które może zawierać pojedynczy wykres?**

Aspose.Slides nie narzuca stałego limitu liczby dodawanych serii. Praktyczny limit ustalany jest przez czytelność wykresu oraz dostępność pamięci w aplikacji.

**Co zrobić, gdy kolumny w grupie są zbyt blisko siebie lub zbyt daleko od siebie?**

Dostosuj ustawienie Gap Width dla tej serii (lub jej grupy serii nadrzędnej). Zwiększenie wartości zwiększa odstęp między kolumnami, a zmniejszenie go przybliża kolumny do siebie.