---
title: Perubahan API Publik dan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 16.1.0
linktitle: Aspose.Slides untuk .NET 16.1.0
type: docs
weight: 220
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang merusak di Aspose.Slides untuk .NET guna memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}}
Halaman ini menampilkan semua [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) kelas, metode, properti, dan sebagainya, serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 16.1.0.
{{% /alert %}}
## **Perubahan API Publik**

#### **Properti RotationAngle Telah Ditambahkan ke Antarmuka IChartTextBlockFormat dan ITextFrameFormat**
Properti RotationAngle telah ditambahkan ke antarmuka Aspose.Slides.Charts.IChartTextBlockFormat dan Aspose.Slides.ITextFrameFormat. Properti ini menentukan rotasi khusus yang diterapkan pada teks di dalam kotak pembatas.

``` csharp

 using (Presentation pres = new Presentation())
{
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
IChartSeries series = chart.ChartData.Series[0];
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;
pres.Save("out.pptx", SaveFormat.Pptx);
}
```
#### **OdpException Dipindahkan dari Aspose.Slides.Odp ke Namespace Aspose.Slides**