---
title: Kelola Label Data Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Label Data
type: docs
url: /id/nodejs-java/chart-data-label/
keywords:
- diagram
- label data
- presisi data
- persentase
- jarak label
- lokasi label
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data diagram dalam presentasi PowerPoint menggunakan JavaScript dan Aspose.Slides untuk Node.js via Java agar slide lebih menarik."
---
## **Pendahuluan**

Label data pada diagram menunjukkan detail tentang seri data diagram atau titik data individu. Mereka memungkinkan pembaca dengan cepat mengidentifikasi seri data dan juga membuat diagram lebih mudah dipahami.

## **Atur Presisi Data pada Label Data Diagram**

Kode JavaScript ini menunjukkan cara mengatur presisi data pada label data diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tampilkan Persentase sebagai Label**

Aspose.Slides untuk Node.js melalui Java memungkinkan Anda menetapkan label persentase pada diagram yang ditampilkan. Kode JavaScript ini mendemonstrasikan operasinya:

```javascript
// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // Menyimpan presentasi yang berisi diagram
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Tanda Persentase dengan Label Data Diagram**

Kode JavaScript ini menunjukkan cara mengatur tanda persentase untuk label data diagram:

```javascript
// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan referensi slide melalui indeksnya
    var slide = pres.getSlides().get_Item(0);
    // Membuat diagram PercentsStackedColumn pada slide
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // Mengatur NumberFormatLinkedToSource menjadi false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // Mendapatkan worksheet data diagram
    var workbook = chart.getChartData().getChartDataWorkbook();
    // Menambahkan seri baru
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // Mengatur warna isi seri
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Mengatur properti LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Menambahkan seri baru
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // Mengatur tipe isi dan warna
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // Menulis presentasi ke disk
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Jarak Label dari Sumbu**

Kode JavaScript ini menunjukkan cara mengatur jarak label dari sumbu kategori saat Anda mengerjakan diagram yang dipetakan dari sumbu:

```javascript
// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan referensi slide
    var sld = pres.getSlides().get_Item(0);
    // Membuat diagram pada slide
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // Mengatur jarak label dari sumbu
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // Menulis presentasi ke disk
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sesuaikan Lokasi Label**

Saat Anda membuat diagram yang tidak bergantung pada sumbu apa pun seperti diagram pai, label data diagram dapat berada terlalu dekat dengan tepinya. Dalam kasus seperti itu, Anda harus menyesuaikan lokasi label data agar garis penghubung dapat ditampilkan dengan jelas.

Kode JavaScript ini menunjukkan cara menyesuaikan lokasi label pada diagram pai:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![Diagram pai dengan label disesuaikan](pie-chart-adjusted-label.png)

## **Tanya Jawab**

**Bagaimana saya dapat mencegah label data saling tumpang tindih pada diagram yang padat?**

Gabungkan penempatan label otomatis, garis penghubung, dan mengecilkan ukuran font; jika diperlukan, sembunyikan beberapa bidang (misalnya kategori) atau tampilkan label hanya untuk titik ekstrem/kunci.

**Bagaimana saya dapat menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**

Filter titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai yang hilang berdasarkan aturan yang ditetapkan.

**Bagaimana saya dapat memastikan gaya label yang konsisten saat mengekspor ke PDF/gambar?**

Tentukan secara eksplisit font (jenis, ukuran) dan pastikan font tersebut tersedia di sisi rendering untuk menghindari fallback.