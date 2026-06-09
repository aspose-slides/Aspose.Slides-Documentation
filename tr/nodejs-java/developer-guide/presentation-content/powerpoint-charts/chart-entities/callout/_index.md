---
title: Sunum Grafikleri İçin Çağrı Balonlarını JavaScript ile Yönetme
linktitle: Çağrı Balonu
type: docs
url: /tr/nodejs-java/callout/
keywords:
- grafik çağrı balonu
- çağrı balonu kullanımı
- veri etiketi
- etiket biçimi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da çağrı balonlarını oluşturun ve biçimlendirin, kısa kod örnekleriyle PPT ve PPTX ile uyumlu olarak sunum iş akışlarını otomatikleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik veri etiketleri için çağrı balonlarıyla nasıl çalışılacağını açıklar. `setShowLabelAsDataCallout` yönteminin etiketleri çağrı balonu olarak görüntülemek için nasıl kullanılacağını, bir halka grafiği için çağrı balonu ile ilgili etiket ayarlarının nasıl yapılandırılacağını ve çağrı balonları ile görünümlerinin sunumlar PDF, HTML5, SVG ve raster görüntü formatlarına aktarıldığında korunduğunu belirtir.

## **Çağrı Balonlarını Kullanma**

Yeni [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) ve [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) yöntemleri, [DataLabelFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datalabelformat) sınıfına eklenmiştir. Bu yöntemler, belirtilen grafiğin veri etiketinin veri çağrı balonu olarak mı yoksa veri etiketi olarak mı görüntüleneceğini belirler.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Halka Grafiği için Çağrı Balonu Ayarlama**

Aspose.Slides for Node.js via Java, bir Halka grafiği için seri veri etiketi çağrı balonu şekli ayarlamayı destekler. Aşağıda örnek bir kod verilmiştir.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Sunum PDF, HTML5, SVG veya görüntülere dönüştürüldüğünde çağrı balonları korunur mu?**

Evet. Çağrı balonları grafik render'ının bir parçasıdır, bu nedenle [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/tr/nodejs-java/export-to-html5/), [SVG](/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/) veya [raster görüntüler](/slides/tr/nodejs-java/convert-powerpoint-to-png/) olarak dışa aktardığınızda, slayt biçimlendirmesiyle birlikte korunurlar.

**Özel yazı tipleri çağrı balonlarında çalışır mı ve dışa aktarımda görünümleri korunabilir mi?**

Evet. Aspose.Slides, sunuma [yazı tipi gömmeyi](/slides/tr/nodejs-java/embedded-font/) destekler ve [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) gibi dışa aktarımlarda yazı tipi gömmeyi kontrol eder, böylece çağrı balonları farklı sistemlerde aynı görünüme sahip olur.