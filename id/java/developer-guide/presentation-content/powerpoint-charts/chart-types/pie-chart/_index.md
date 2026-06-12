---
title: Sesuaikan Diagram Lingkaran dalam Presentasi Menggunakan Java
linktitle: Diagram Lingkaran
type: docs
url: /id/java/pie-chart/
keywords:
- diagram lingkaran
- kelola diagram
- sesuaikan diagram
- opsi diagram
- pengaturan diagram
- opsi plot
- warna irisan
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram lingkaran di Java dengan Aspose.Slides, dapat diekspor ke PowerPoint, meningkatkan penceritaan data Anda dalam hitungan detik."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram lingkaran di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram lingkaran standar.

Contoh-contoh berfokus pada langkah-langkah kustomisasi diagram yang praktis seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram bawaan dengan kategori dan nilai kustom, serta menyimpan presentasi yang diperbarui.

## **Opsi Plot Kedua untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides for Java kini mendukung opsi plot kedua untuk diagram Pie of Pie atau Bar of Pie. Pada topik ini, kami akan menunjukkan cara menentukan opsi tersebut menggunakan Aspose.Slides. Untuk menentukan properti, lakukan hal berikut:

1. Buat objek kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Tambahkan diagram pada slide.
3. Tentukan opsi plot kedua dari diagram.
4. Tuliskan presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur berbagai properti diagram Pie of Pie.

```java
// Buat sebuah instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Tambahkan diagram pada slide
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Atur properti yang berbeda
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Tulis presentasi ke disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Pewarnaan Irisan Diagram Lingkaran Otomatis**

Aspose.Slides for Java menyediakan API sederhana untuk mengatur pewarnaan otomatis iris diagram lingkaran. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Atur Judul diagram.
5. Atur seri pertama untuk Menampilkan Nilai.
6. Atur indeks lembar data diagram.
7. Mendapatkan lembar kerja data diagram.
8. Hapus seri dan kategori yang dihasilkan secara default.
9. Tambahkan kategori baru.
10. Tambahkan seri baru.

Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```java
// Buat sebuah instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Tambahkan diagram dengan data default
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Mengatur Judul diagram
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Atur seri pertama untuk Menampilkan Nilai
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

Ya, perpustakaan [mendukung](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/) plot sekunder untuk diagram lingkaran, termasuk tipe 'Pie of Pie' dan 'Bar of Pie'.

**Bisakah saya mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getImage-int-float-float-) (misalnya PNG) tanpa seluruh presentasi.