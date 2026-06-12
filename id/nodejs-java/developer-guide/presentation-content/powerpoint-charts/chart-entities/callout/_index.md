---
title: Kelola Callout dalam Diagram Presentasi Menggunakan JavaScript
linktitle: Callout
type: docs
url: /id/nodejs-java/callout/
keywords:
- callout diagram
- gunakan callout
- label data
- format label
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan atur gaya callout di Aspose.Slides untuk Node.js via Java dengan contoh kode singkat, kompatibel dengan PPT dan PPTX untuk mengotomatiskan alur kerja presentasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan callout untuk label data diagram di Aspose.Slides. Ini menunjukkan cara menggunakan metode `setShowLabelAsDataCallout` untuk menampilkan label sebagai callout, cara mengonfigurasi pengaturan label yang terkait dengan callout untuk diagram donat, dan mencatat bahwa callout dan tampilannya dipertahankan ketika presentasi diekspor ke format PDF, HTML5, SVG, dan gambar raster.

## **Menggunakan Callout**

Metode baru [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) dan [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) telah ditambahkan ke kelas [DataLabelFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datalabelformat). Metode‑metode ini menentukan apakah label data diagram yang ditentukan akan ditampilkan sebagai callout data atau sebagai label data.

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

## **Mengatur Callout untuk Diagram Donat**

Aspose.Slides untuk Node.js via Java menyediakan dukungan untuk mengatur bentuk callout label data seri pada diagram Donat. Contoh sampel di bawah ini diberikan.

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

## **FAQ**

**Apakah callout dipertahankan saat mengonversi presentasi ke PDF, HTML5, SVG, atau gambar?**

Ya. Callout merupakan bagian dari proses rendering diagram, sehingga saat Anda mengekspor ke [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/id/nodejs-java/export-to-html5/), [SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/), atau [raster images](/slides/id/nodejs-java/convert-powerpoint-to-png/), mereka dipertahankan bersama dengan format slide.

**Apakah font khusus berfungsi dalam callout, dan dapat tampilannya dipertahankan saat ekspor?**

Ya. Aspose.Slides mendukung [embedding fonts](/slides/id/nodejs-java/embedded-font/) ke dalam presentasi dan mengontrol penyematan font selama ekspor seperti [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), memastikan callout terlihat sama di berbagai sistem.