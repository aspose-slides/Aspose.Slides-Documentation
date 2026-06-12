---
title: Kelola Penanda Data Grafik dalam Presentasi di .NET
linktitle: Penanda Data
type: docs
url: /id/net/chart-data-marker/
keywords:
- grafik
- titik data
- penanda
- opsi penanda
- ukuran penanda
- tipe isian
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menyesuaikan penanda data grafik di Aspose.Slides untuk .NET, meningkatkan dampak presentasi pada format PPT dan PPTX dengan contoh kode C# yang jelas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan penanda data diagram di Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, mengakses sebuah seri dan titik datanya, menerapkan isian gambar pada penanda di tingkat titik data, menyesuaikan ukuran penanda, dan menyimpan presentasi yang telah diperbarui. Artikel ini juga mencatat bahwa bentuk penanda standar tersedia melalui enumerasi `MarkerStyleType` dan bahwa tampilan penanda dipertahankan saat mengekspor diagram ke format raster atau SVG.

## **Atur Opsi Penanda Diagram**
Penanda dapat diatur pada titik data diagram dalam seri tertentu. Untuk mengatur opsi penanda diagram, ikuti langkah-langkah di bawah ini:

- Instansiasikan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
- Buat diagram default.
- Atur gambar.
- Ambil seri diagram pertama.
- Tambah titik data baru.
- Tulis presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur opsi penanda diagram pada tingkat titik data.

```c#
// Buat instance kelas Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Membuat diagram default
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Mendapatkan indeks worksheet data diagram default
int defaultWorksheetIndex = 0;

// Mendapatkan worksheet data diagram
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Hapus seri demo
chart.ChartData.Series.Clear();

// Tambahkan seri baru
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Atur gambar
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Atur gambar
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Ambil seri diagram pertama
IChartSeries series = chart.ChartData.Series[0];

// Tambahkan titik baru (1:3) di sana.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Mengubah penanda seri diagram
series.Marker.Size = 15;

// Simpan presentasi ke disk
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Bentuk penanda apa yang tersedia secara default?**

Bentuk standar tersedia (lingkaran, persegi, wajik, segitiga, dll.); daftar tersebut didefinisikan oleh enumerasi [MarkerStyleType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/markerstyletype/). Jika Anda memerlukan bentuk yang tidak standar, gunakan penanda dengan isian gambar untuk meniru visual khusus.

**Apakah penanda dipertahankan saat mengekspor diagram ke gambar atau SVG?**

Ya. Saat merender diagram ke [format raster](/slides/id/net/convert-powerpoint-to-png/) atau menyimpan [bentuk sebagai SVG](/slides/id/net/render-a-slide-as-an-svg-image/), penanda mempertahankan tampilan dan pengaturannya, termasuk ukuran, isian, dan outline.