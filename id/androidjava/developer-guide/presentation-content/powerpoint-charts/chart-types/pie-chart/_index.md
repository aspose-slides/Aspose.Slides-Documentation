---
title: "Kustomisasi Diagram Lingkaran dalam Presentasi di Android"
linktitle: "Diagram Lingkaran"
type: docs
url: /id/androidjava/pie-chart/
keywords:
- "diagram lingkaran"
- "kelola diagram"
- "kustomisasi diagram"
- "opsi diagram"
- "pengaturan diagram"
- "opsi plot"
- "warna irisan"
- "PowerPoint"
- "presentasi"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Pelajari cara membuat dan menyesuaikan diagram lingkaran di Java dengan Aspose.Slides untuk Android, dapat diekspor ke PowerPoint, meningkatkan penceritaan data Anda dalam hitungan detik."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram lingkaran di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram lingkaran standar.

Contoh-contoh berfokus pada langkah-langkah penyesuaian diagram praktis seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram default dengan kategori dan nilai khusus, serta menyimpan presentasi yang diperbarui.

## **Opsi Plot Sekunder untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides untuk Android via Java kini mendukung opsi plot sekunder untuk diagram Pie of Pie atau Bar of Pie. Pada topik ini, kami akan menunjukkan cara menentukan opsi tersebut menggunakan Aspose.Slides. Untuk menentukan properti, lakukan hal berikut:

1. Buat instance objek kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Tambahkan diagram pada slide.
1. Tentukan opsi plot sekunder diagram.
1. Tuliskan presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur properti yang berbeda untuk diagram Pie of Pie.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Tambahkan diagram ke slide
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Atur properti yang berbeda
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Simpan presentasi ke disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Warna Irisan Diagram Lingkaran Otomatis**

Aspose.Slides untuk Android via Java menyediakan API sederhana untuk mengatur warna iris otomatis pada diagram lingkaran. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Atur Judul diagram.
1. Atur seri pertama agar Menampilkan Nilai.
1. Atur indeks lembar data diagram.
1. Mendapatkan lembar kerja data diagram.
1. Hapus seri dan kategori yang dihasilkan secara default.
1. Tambahkan kategori baru.
1. Tambahkan seri baru.

Tuliskan presentasi yang dimodifikasi ke file PPTX.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Tambahkan diagram dengan data default
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Mengatur Judul diagram
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Atur seri pertama agar Menampilkan Nilai
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Mengatur indeks lembar data diagram
    int defaultWorksheetIndex = 0;

    // Mendapatkan lembar kerja data diagram
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Hapus seri dan kategori yang dihasilkan secara default
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Menambahkan kategori baru
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Menambahkan seri baru
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah variasi 'Pie of Pie' dan 'Bar of Pie' didukung?**

Ya, perpustakaan ini [mendukung](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/charttype/) plot sekunder untuk diagram lingkaran, termasuk tipe 'Pie of Pie' dan 'Bar of Pie'.

**Apakah saya dapat mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (seperti PNG) tanpa seluruh presentasi.