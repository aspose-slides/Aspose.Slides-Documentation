---
title: Sesuaikan Diagram 3D dalam Presentasi Menggunakan Java
linktitle: Diagram 3D
type: docs
url: /id/java/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram 3-D di Aspose.Slides untuk Java, dengan dukungan file PPT dan PPTX—tingkatkan presentasi Anda hari ini."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan diagram 3D di Aspose.Slides dengan mengonfigurasi pengaturan `Rotation3D` seperti `RotationX`, `RotationY`, `DepthPercents`, dan `RightAngleAxes`. Artikel ini memandu pembuatan presentasi, menambahkan diagram 3D dengan data default, menerapkan pengaturan tampilan 3D yang diperlukan, dan menyimpan presentasi yang dimodifikasi sebagai file PPTX.

## **Set Properti RotationX, RotationY, dan DepthPercents dari Diagram 3D**
Aspose.Slides untuk Java menyediakan API sederhana untuk mengatur properti ini. Artikel berikut akan membantu Anda cara mengatur berbagai properti seperti **X,Y Rotation, DepthPercents** dll. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
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
    
    // Mengambil worksheet data diagram
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
    
    // Simpan presentasi ke disk
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Tipe diagram mana yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100% Stacked Column 3D, serta tipe 3D terkait yang ditampilkan melalui kelas [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/) di referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster dari diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar melalui [chart API](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getImage-int-float-float-) atau [render seluruh slide](/slides/id/java/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau pixel-perfect atau ingin menyematkan diagram ke dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembuatan dan render diagram 3D besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil optimal, gunakan efek 3D secara minimal, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output berukuran sesuai (resolusi dan dimensi) untuk mencocokkan tampilan atau kebutuhan cetak target.