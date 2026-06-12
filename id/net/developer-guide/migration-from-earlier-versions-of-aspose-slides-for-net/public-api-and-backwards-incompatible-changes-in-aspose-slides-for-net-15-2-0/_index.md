---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 15.2.0
linktitle: Aspose.Slides untuk .NET 15.2.0
type: docs
weight: 140
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan lain‑lain yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) serta perubahan lain yang diperkenalkan dengan API Aspose.Slides for .NET 15.2.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Metode AddDataPointForDoughnutSeries Telah Ditambahkan**
Dua overload dari metode IChartDataPointCollection.AddDataPointForDoughnutSeries() telah ditambahkan untuk menambahkan titik data ke dalam seri tipe grafik Donat.
#### **Kelas Aspose.Slides.SmartArt.SmartArtShape Telah Diturunkan dari Kelas Aspose.Slides.GeometryShape**
Kelas Aspose.Slides.SmartArt.SmartArtShape telah diturunkan dari kelas Aspose.Slides.GeometryShape. Perubahan ini meningkatkan model objek Aspose.Slides dan menambahkan fitur baru ke kelas SmartArtShape.
#### **Metode untuk Menghapus Titik Data Grafik dan Kategori Grafik berdasarkan Indeks Telah Ditambahkan**
Metode IChartDataPointCollection.RemoveAt(int index) telah ditambahkan untuk menghapus titik data grafik berdasarkan indeksnya.
Metode IChartCategoryCollection.RemoveAt(int index) telah ditambahkan untuk menghapus kategori grafik berdasarkan indeksnya.
#### **Nilai PptXPptY Telah Ditambahkan ke Enumerasi Aspose.Slides.Animation.PropertyType**
Nilai PptXPptY telah ditambahkan ke enumerasi Aspose.Slides.Animation.PropertyType dalam rangka memperbaiki masalah serialisasi.
#### **Metode System.Drawing.Color GetAutomaticSeriesColor() Telah Ditambahkan ke Aspose.Slides.Charts.IChartSeries**
Metode GetAutomaticSeriesColor mengembalikan warna otomatis untuk seri berdasarkan indeks seri dan gaya grafik. Warna ini digunakan secara default jika FillType bernilai NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

```