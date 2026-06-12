---
title: Perubahan API Publik dan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 15.8.0
linktitle: Aspose.Slides untuk .NET 15.8.0
type: docs
weight: 190
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) kelas, metode, properti, dan sebagainya, serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 15.8.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Properti DoughnutHoleSize Telah Ditambahkan ke IChartSeries dan ChartSeries**
Menentukan ukuran lubang pada diagram donat.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```