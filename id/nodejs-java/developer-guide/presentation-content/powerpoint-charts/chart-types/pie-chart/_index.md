---
title: Sesuaikan Diagram Lingkaran dalam Presentasi Menggunakan JavaScript
linktitle: Diagram Lingkaran
type: docs
url: /id/nodejs-java/pie-chart/
keywords:
- diagram lingkaran
- mengelola diagram
- menyesuaikan diagram
- opsi diagram
- pengaturan diagram
- opsi plot
- warna irisan
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram lingkaran dalam JavaScript dengan Aspose.Slides untuk Node.js, dapat diekspor ke PowerPoint, meningkatkan penceritaan data Anda dalam hitungan detik."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan diagram lingkaran di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram lingkaran standar.

Contoh-contoh berfokus pada langkah-langkah praktis penyesuaian diagram seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram default dengan kategori dan nilai khusus, serta menyimpan presentasi yang diperbarui.

## **Opsi Plot Kedua untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides untuk Node.js via Java kini mendukung opsi plot kedua untuk diagram Pie of Pie atau Bar of Pie. Dalam topik ini, kami akan menunjukkan cara menentukan opsi tersebut menggunakan Aspose.Slides. Untuk menentukan properti, lakukan hal berikut:

1. Instansiasi objek kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Tambahkan diagram pada slide.
3. Tentukan opsi plot kedua dari diagram.
4. Tulis presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur berbagai properti diagram Pie of Pie.

```javascript
// Buat instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Tambahkan diagram pada slide
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Atur properti yang berbeda
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Tulis presentasi ke disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Warna Irisan Diagram Lingkaran Otomatis**

Aspose.Slides untuk Node.js via Java menyediakan API sederhana untuk mengatur warna irisan diagram lingkaran otomatis. Kode contoh menerapkan pengaturan properti tersebut.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Atur Judul diagram.
5. Atur seri pertama untuk Menampilkan Nilai.
6. Atur indeks lembar data diagram.
7. Mendapatkan lembar kerja data diagram.
8. Hapus seri dan kategori yang dihasilkan secara default.
9. Tambahkan kategori baru.
10. Tambahkan seri baru.

Tulis presentasi yang dimodifikasi ke file PPTX.

```javascript
// Buat instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Tambahkan diagram dengan data default
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Mengatur Judul diagram
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Atur seri pertama untuk Menampilkan Nilai
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Mengatur indeks lembar data diagram
    var defaultWorksheetIndex = 0;
    // Mendapatkan lembar kerja data diagram
    var fact = chart.getChartData().getChartDataWorkbook();
    // Hapus seri dan kategori yang dihasilkan secara default
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Menambahkan kategori baru
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Menambahkan seri baru
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah variasi 'Pie of Pie' dan 'Bar of Pie' didukung?**

Ya, perpustakaan [mendukung](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/) plot sekunder untuk diagram lingkaran, termasuk tipe 'Pie of Pie' dan 'Bar of Pie'.

**Apakah saya dapat mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getImage) (misalnya PNG) tanpa keseluruhan presentasi.