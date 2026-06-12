---
title: Sesuaikan Diagram 3D dalam Presentasi di Android
linktitle: Diagram 3D
type: docs
url: /id/androidjava/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram 3-D di Aspose.Slides untuk Android via Java, dengan dukungan file PPT dan PPTX - tingkatkan presentasi Anda hari ini."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan diagram 3D di Aspose.Slides dengan mengonfigurasi pengaturan `Rotation3D` seperti `RotationX`, `RotationY`, `DepthPercents`, dan `RightAngleAxes`. Artikel ini memandu Anda membuat presentasi, menambahkan diagram 3D dengan data default, menerapkan pengaturan tampilan 3D yang diperlukan, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Atur Properti RotationX, RotationY, dan DepthPercents pada Diagram 3D**
Aspose.Slides untuk Android via Java menyediakan API sederhana untuk mengatur properti‑properti ini. Artikel berikut akan membantu Anda mengatur berbagai properti seperti **Rotasi X,Y, DepthPercents** dll. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Atur properti Rotation3D.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

```java
Presentation pres = new Presentation();
try {
    // Akses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Tambahkan diagram dengan data default
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Mengatur indeks lembar data diagram
    int defaultWorksheetIndex = 0;
    
    // Mengambil lembar kerja data diagram
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Tambahkan seri
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Tambahkan Kategori
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Atur properti Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Ambil seri diagram kedua
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Atur nilai OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Tulis presentasi ke disk
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jenis diagram apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100% Stacked Column 3D, serta tipe 3D terkait yang tersedia melalui kelas [ChartType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/charttype/) dalam referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster dari diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar melalui [API grafik](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) atau [render seluruh slide](/slides/id/androidjava/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau pixel‑perfect atau ingin menyematkan diagram ke dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembuatan dan render diagram 3D yang besar?**

Kinerja bergantung pada volume data dan kompleksitas visual. Untuk hasil optimal, minimalkan efek 3D, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke ukuran output yang sesuai (resolusi dan dimensi) untuk mencocokkan kebutuhan tampilan atau cetak target.