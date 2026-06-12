---
title: Kustomisasi Grafik 3D dalam Presentasi Menggunakan JavaScript
linktitle: Grafik 3D
type: docs
url: /id/nodejs-java/3d-chart/
keywords:
- grafik 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan grafik 3-D di Aspose.Slides untuk Node.js via Java, dengan dukungan untuk file PPT dan PPTX—tingkatkan presentasi Anda hari ini."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan grafik 3D di Aspose.Slides dengan mengonfigurasi pengaturan `Rotation3D` seperti `RotationX`, `RotationY`, `DepthPercents`, dan `RightAngleAxes`. Artikel ini memandu pembuatan presentasi, penambahan grafik 3D dengan data default, penerapan pengaturan tampilan 3D yang diperlukan, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Atur properti RotationX, RotationY, dan DepthPercents pada Grafik 3D**

Aspose.Slides for Node.js via Java menyediakan API sederhana untuk mengatur properti‑properti ini. Artikel berikut ini akan membantu Anda mengatur properti yang berbeda seperti **Rotasi X,Y, DepthPercents** dll. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
1. Akses slide pertama.
1. Tambahkan grafik dengan data default.
1. Atur properti Rotation3D.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Akses slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Tambah grafik dengan data default
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Mengatur indeks lembar data grafik
    var defaultWorksheetIndex = 0;
    // Mendapatkan lembar kerja data grafik
    var fact = chart.getChartData().getChartDataWorkbook();
    // Tambah seri
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Tambah Kategori
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Atur properti Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Ambil seri grafik kedua
    var series = chart.getChartData().getSeries().get_Item(1);
    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Atur nilai OverLap
    series.getParentSeriesGroup().setOverlap(100);
    // Tulis presentasi ke disk
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Tipe grafik apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari grafik kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100% Stacked Column 3D, beserta tipe 3D terkait yang tersedia melalui enumerasi [ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/) dalam referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster dari grafik 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor grafik ke gambar melalui [chart API](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getImage) atau [render seluruh slide](/slides/id/nodejs-java/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna bila Anda memerlukan pratinjau pixel‑perfect atau ingin menyematkan grafik ke dalam dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembangunan dan rendering grafik 3D yang besar?**

Kinerja bergantung pada volume data dan kompleksitas visual. Untuk hasil optimal, minimalkan efek 3D, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output dengan ukuran yang sesuai (resolusi dan dimensi) agar cocok dengan tampilan atau kebutuhan cetak target.