---
title: Zarządzanie etykietami danych wykresu w prezentacjach przy użyciu Javy
linktitle: Etykieta danych
type: docs
url: /pl/java/chart-data-label/
keywords:
- wykres
- etykieta danych
- precyzja danych
- procent
- odległość etykiety
- położenie etykiety
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Naucz się dodawać i formatować etykiety danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides for Java, aby uzyskać bardziej angażujące slajdy."
---
## **Wprowadzenie**

Etykiety danych na wykresie wyświetlają szczegóły dotyczące serii danych wykresu lub pojedynczych punktów danych. Umożliwiają czytelnikom szybkie rozpoznanie serii danych i ułatwiają zrozumienie wykresów.

## **Ustaw precyzję danych w etykietach wykresu**

Ten kod w języku Java pokazuje, jak ustawić precyzję danych w etykiecie wykresu:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Wyświetl procenty jako etykiety**
Aspose.Slides for Java umożliwia ustawienie etykiet procentowych na wyświetlanych wykresach. Ten kod w języku Java demonstruje tę operację:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // Zapisuje prezentację zawierającą wykres
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw znak procenta w etykietach danych wykresu**
Ten kod w języku Java pokazuje, jak ustawić znak procenta dla etykiety danych wykresu:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Pobiera referencję slajdu przez jego indeks
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Tworzy wykres PercentsStackedColumn na slajdzie
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // Ustawia NumberFormatLinkedToSource na false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // Pobiera arkusz danych wykresu
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // Dodaje nową serię
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // Ustawia kolor wypełnienia serii
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Ustawia właściwości LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Dodaje nową serię
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // Ustawia typ i kolor wypełnienia
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // Zapisuje prezentację na dysk
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw odległość etykiety od osi**
Ten kod w języku Java pokazuje, jak ustawić odległość etykiety od osi kategorii, gdy pracujesz z wykresem tworzonym na podstawie osi:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Pobiera referencję slajdu
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tworzy wykres na slajdzie
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // Ustawia odległość etykiety od osi
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // Zapisuje prezentację na dysk
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dostosuj położenie etykiety**

Gdy tworzysz wykres, który nie opiera się na żadnej osi, taki jak wykres kołowy, etykiety danych wykresu mogą znajdować się zbyt blisko jego krawędzi. W takim przypadku należy dostosować położenie etykiety danych, aby linie pomocnicze były wyświetlane wyraźnie.

Ten kod w języku Java pokazuje, jak dostosować położenie etykiety na wykresie kołowym:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**

Połącz automatyczne rozmieszczanie etykiet, linie pomocnicze oraz zmniejszoną wielkość czcionki; w razie potrzeby ukryj niektóre pola (np. kategorię) lub wyświetlaj etykiety tylko dla punktów skrajnych/kluczowych.

**Jak mogę wyłączyć etykiety tylko dla wartości zerowych, ujemnych lub pustych?**

Przefiltruj punkty danych przed włączeniem etykiet i wyłącz wyświetlanie dla wartości 0, wartości ujemnych lub brakujących zgodnie z określoną regułą.

**Jak zapewnić spójny styl etykiet przy eksportowaniu do PDF/obrazów?**

Jawnie ustaw czcionki (rodzina, rozmiar) i zweryfikuj, czy czcionka jest dostępna po stronie renderowania, aby uniknąć zastępowania.