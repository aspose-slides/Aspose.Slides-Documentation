---
title: Sesuaikan Legenda Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Legenda Diagram
type: docs
url: /id/nodejs-java/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides untuk Node.js via Java untuk mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides untuk Node.js via Java menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, memformat entri legenda tertentu, serta menyembunyikan atau memulihkan entri yang dipilih.

FAQ mencakup perilaku terkait, termasuk memesan ruang untuk legenda, menampilkan label multiline, dan mewarisi pemformatan dari tema presentasi.

## **Penempatan Legenda**

Gunakan metode legend [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), dan [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) untuk menentukan posisi dan ukuran legenda sebagai pecahan dimensi diagram.

Contoh ini membuat presentasi dan menambahkan diagram kolom berkelompok dengan data default ke slide pertama. Membagi offset dan dimensi legenda yang diinginkan dengan lebar dan tinggi diagram mengubahnya menjadi nilai relatif: legenda dipindahkan 50 poin dari sudut kiri atas diagram dan berukuran 100 × 100 poin.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Ekspresikan posisi dan ukuran legenda relatif terhadap diagram.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Ukuran Font Legenda**

Gunakan legend [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) untuk mengakses pemformatan teksnya dan gunakan [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) untuk mengatur ukuran font dalam poin.

Contoh ini membuat diagram dengan data default dan mengatur teks legenda menjadi 20 poin. Ia juga menonaktifkan batas otomatis untuk sumbu vertikal dan mengatur rentangnya dari -5 hingga 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Ukuran Font Entri Legenda Individu**

Gunakan koleksi yang dikembalikan oleh legend [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) untuk mengakses pemformatan entri tertentu. Indeks entri dimulai dari nol, jadi indeks `1` mengacu pada entri kedua.

Contoh ini membuat diagram kolom berkelompok yang data defaultnya mencakup setidaknya dua seri. Ia memformat entri legenda kedua dengan teks tebal, miring, dan berwarna biru berukuran 20 poin.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menyembunyikan Entri Legenda Individu**

Untuk mengecualikan seri tambahan dari legenda sementara data tetap terlihat, panggil [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) dengan `true` melalui [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Ini hanya menyembunyikan entri legenda yang dipilih; tidak menghapus seri atau poin data. Memanggil [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) dengan `false`, sebaliknya, menyembunyikan seluruh legenda.

Contoh di bawah ini membuat diagram kolom berkelompok dengan beberapa seri menggunakan data default. Ia menyembunyikan entri legenda seri kedua (indeks `1`) dan menyimpan presentasi. Kemudian entri dipulihkan dengan memanggil [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) dengan `false` dan menyimpan salinan kedua. Kolom tetap terlihat di kedua file.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Pulihkan entri yang sama tanpa mengubah data diagram.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perbandingan di bawah menunjukkan diagram yang sama dengan semua entri terlihat dan dengan entri kedua disembunyikan. Kolom seri kedua tetap tidak berubah.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

Pada diagram kolom, batang, dan garis, entri legenda mengidentifikasi seri. Untuk diagram pai, mereka mengidentifikasi titik data individual (irisan), sehingga gunakan [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) pada irisan yang dipilih. API mendokumentasikan metode titik data ini untuk tipe diagram `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, dan `BarOfPie`. Jangan mengasumsikan berlaku untuk diagram donat, yang tidak termasuk dalam daftar tersebut.

## **FAQ**

**Apakah saya dapat membuat diagram memesan ruang untuk legenda alih-alih menimpanya?**

Ya. Panggil [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) dengan `false` untuk memesan ruang bagi legenda alih-alih membiarkannya menimpa area plot.

**Apakah saya dapat membuat label legenda multiline?**

Ya. Label panjang dapat membungkus ketika lebar yang tersedia tidak cukup. Anda juga dapat menggunakan karakter baris baru dalam nama seri untuk meminta pemisahan baris.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Biarkan warna, isian, dan font legenda tidak disetel sehingga dapat mewarisi pemformatan tema. Pemformatan eksplisit akan menggantikan pengaturan tema yang bersangkutan.