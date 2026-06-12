---
title: Sesuaikan Diagram 3D dalam Presentasi di .NET
linktitle: Diagram 3D
type: docs
url: /id/net/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram 3-D di Aspose.Slides untuk .NET, dengan dukungan file PPT dan PPTX—tingkatkan presentasi Anda hari ini."
---
## **Ringkasan**

Artikel ini menjelaskan cara menyesuaikan diagram 3D di Aspose.Slides dengan mengonfigurasi pengaturan `Rotation3D` seperti `RotationX`, `RotationY`, `DepthPercents`, dan `RightAngleAxes`. Panduan ini meliputi pembuatan presentasi, menambahkan diagram 3D dengan data default, menerapkan pengaturan tampilan 3D yang diperlukan, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Atur Properti RotationX, RotationY, dan DepthPercents pada Diagram 3D**
Aspose.Slides untuk .NET menyediakan API sederhana untuk mengatur properti-properti ini. Artikel berikut akan membantu Anda cara mengatur properti berbeda seperti Rotasi X, Y, **DepthPercents**, dll. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Atur properti Rotation3D.
5. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```c#
// Buat instance kelas Presentation
Presentation presentation = new Presentation();
           
// Akses slide pertama
ISlide slide = presentation.Slides[0];

// Tambahkan diagram dengan data default
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Mengatur indeks lembar data diagram
int defaultWorksheetIndex = 0;

// Mendapatkan worksheet data diagram
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Tambahkan seri
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Tambahkan Kategori
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Atur properti Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Ambil seri diagram kedua
IChartSeries series = chart.ChartData.Series[1];

// Sekarang mengisi data seri
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Atur nilai OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Tulis presentasi ke disk
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jenis diagram mana yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100% Stacked Column 3D, serta tipe 3D terkait yang ditampilkan melalui enumerasi [ChartType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/) di referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster dari diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar melalui [chart API](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getimage/) atau [render seluruh slide](/slides/id/net/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau pixel‑perfect atau ingin menyematkan diagram ke dalam dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembuatan dan rendering diagram 3D besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil optimal, pertahankan efek 3D seminimal mungkin, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output dengan ukuran yang sesuai (resolusi dan dimensi) agar cocok dengan tampilan atau kebutuhan cetak target.