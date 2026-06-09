---
title: JavaScript Kullanarak Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serisi
type: docs
url: /tr/nodejs-java/chart-series/
keywords:
- grafik serileri
- seri örtüşmesi
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) için JavaScript'te grafik serilerini yönetmeyi, pratik kod örnekleri ve en iyi uygulamalarla verilerinizi daha etkili sunumlar haline getirmeyi öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde [ChartSeries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/) öğesinin rolünü, verilerin sunumlarda nasıl yapılandırıldığını ve görselleştirildiğini odaklanarak açıklar. Bu nesneler, bir grafikteki bireysel veri noktası kümelerini, kategorileri ve görünüm parametrelerini tanımlayan temel unsurları sağlar. [ChartSeries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/) ile çalışarak, geliştiriciler veri kaynaklarını sorunsuz bir şekilde entegre edebilir ve bilgilerin nasıl görüntüleneceği üzerinde tam kontrol sağlayabilir; bu da içgörü ve analizleri net bir şekilde ileten dinamik, veri odaklı sunumlar oluşturur.

Bir seri, bir grafikte çizilen sayıların satırı veya sütunudur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Chart Serisi Örtüşmesini Ayarla**

With the [ChartSeries.getOverlap](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getOverlap) method, you can specify how much bars and columns should overlap on a 2D chart (range: -100 to 100). This property applies to all series of the parent series group: this is a projection of the appropriate group property. Therefore, this property is read-only.

Use the `ParentSeriesGroup.getOverlap` read/write property to set your preferred value for `Overlap`.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) class.
1. Add a clustered column chart on a slide.
1. Access the first chart series.
1. Access the chart series' `ParentSeriesGroup` and set your preferred overlap value for the series.
1. Write the modified presentation to a PPTX file.

This JavaScript code shows you how to set the overlap for a chart series:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Grafiği ekler
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Seri örtüşmesini ayarlar
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Sunum dosyasını diske yazar
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Seri Rengini Değiştir**

Aspose.Slides for Node.js via Java allows you to change a series' color this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) class.
1. Add chart on the slide.
1. Access the series whose color you want to change.
1. Set your preferred fill type and fill color.
1. Save the modified presentation.

This JavaScript code shows you how to change a series' color:

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

## **Seri Kategorisinin Rengini Değiştir**

Aspose.Slides for Node.js via Java allows you to change a series category's color this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) class.
1. Add chart on the slide.
1. Access the series category whose color you want to change.
1. Set your preferred fill type and fill color.
1. Save the modified presentation.

This code in JavaScript shows you how to change a series category's color:

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

## **Seri Adını Değiştir** 

Varsayılan olarak, bir grafiğin lejand adları, her sütun veya satırın üzerindeki hücrelerin içeriğidir. 

In our example (sample image), 

* the columns are *Series 1, Series 2,* and *Series 3*;
* the rows are *Category 1, Category 2, Category 3,* and *Category 4.* 

Aspose.Slides for Node.js via Java allows you to update or change a series name in its chart data and legend.

This JavaScript code shows you how to change a series' name in its chart data `ChartDataWorkbook`:

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

This JavaScript code shows you how to change a series name in its legend through `Series`:

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

## **Grafik Serisi Dolgu Rengini Ayarla**

Aspose.Slides for Node.js via Java allows you to set the automatic fill color for chart series inside a plot area this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data based on your preferred type (in the example below, we used `ChartType.ClusteredColumn`).
1. Access the chart series and set the fill color to Automatic.
1. Save the presentation to a PPTX file.

This JavaScript code shows you how to set the automatic fill color for a chart series:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Kümelenmiş sütun grafiği oluşturur
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Seri dolgu biçimini otomatik olarak ayarlar
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Sunum dosyasını diske yazar
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grafik Serisi Ters Dolgu Renklerini Ayarla**

Aspose.Slides allows you to set the invert fill color for chart series inside a plot area this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data based on your preferred type (in the example below, we used `ChartType.ClusteredColumn`).
1. Access the chart series and set the fill color to invert.
1. Save the presentation to a PPTX file.

This JavaScript code demonstrates the operation:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Yeni serileri ve kategorileri ekler
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // İlk grafik serisini alır ve seri verilerini doldurur.
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

## **Değer Negatif Olduğunda Seriyi Ters Çevir**

Aspose.Slides allows you to set inverts through the`ChartDataPoint.setInvertIfNegative` method. When an invert is set using the properties, the data point inverts its colors when it gets a negative value. 

This JavaScript code demonstrates the operation:

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

## **Belirli Veri Noktalarının Verisini Temizle**

Aspose.Slides for Node.js via Java allows you to clear the `DataPoints` data for a specific chart series this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) class.
2. Obtain the reference of a slide through its index.
3. Obtain the reference of a chart through its index.
4. Iterate through all the chart `DataPoints` and set `XValue` and `YValue` to null.
5. Clear all `DataPoints` for specific chart series.
6. Write the modified presentation to a PPTX file.

This JavaScript code demonstrates the operation:

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

## **Seri Boşluk Genişliğini Ayarla**

Aspose.Slides for Node.js via Java allows you to set a series' Gap Width through the **`GapWidth`** property this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set the `GapWidth` property.
1. Write the modified presentation to a PPTX file.

This code in JavaScript shows you how to set a series' Gap Width:

```javascript
// Boş bir sunum oluşturur
var pres = new aspose.slides.Presentation();
try {
    // Sunumun ilk slaytına erişir
    var slide = pres.getSlides().get_Item(0);
    // Varsayılan verilerle bir grafik ekler
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Grafik veri sayfasının indeksini ayarlar
    var defaultWorksheetIndex = 0;
    // Grafik veri çalışma sayfasını alır
    var fact = chart.getChartData().getChartDataWorkbook();
    // Serileri ekler
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Kategorileri ekler
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // İkinci grafik serisini alır
    var series = chart.getChartData().getSeries().get_Item(1);
    // Seri verilerini doldurur
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // GapWidth değerini ayarlar
    series.getParentSeriesGroup().setGapWidth(50);
    // Sunumu diske kaydeder
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Tek bir grafiğin içerebileceği seri sayısında bir sınırlama var mı?**

Aspose.Slides, eklediğiniz seri sayısı için sabit bir üst sınır koymaz. Uygulamanızın belleği ve grafiğin okunabilirliği pratik sınırı belirler.

**Kümelenmiş sütunlar çok yakın veya çok uzak olduğunda ne yapmalı?**

O serinin (veya üst seri grubunun) Gap Width ayarını değiştirin. Değeri artırmak sütunlar arasındaki boşluğu genişletirken, azaltmak onları birbirine yaklaştırır.