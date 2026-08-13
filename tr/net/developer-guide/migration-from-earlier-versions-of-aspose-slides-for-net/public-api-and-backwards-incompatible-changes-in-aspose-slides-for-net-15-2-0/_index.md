---
title: Aspose.Slides for .NET 15.2.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}}

Bu sayfa, Aspose.Slides for .NET 15.2.0 API'sı ile tanıtılan [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}}
## **Public API Değişiklikleri**
#### **AddDataPointForDoughnutSeries Metodları Eklendi**
IChartDataPointCollection.AddDataPointForDoughnutSeries() metodunun iki aşırı yüklemesi, Doughnut grafik türünün serilerine veri noktaları eklemek için eklendi.
#### **Aspose.Slides.SmartArt.SmartArtShape Sınıfı Aspose.Slides.GeometryShape Sınıfından Kalıtıldı**
Aspose.Slides.SmartArt.SmartArtShape sınıfı Aspose.Slides.GeometryShape sınıfından kalıtıldı. Bu değişiklik, Aspose.Slides nesne modelini geliştirir ve SmartArtShape sınıfına yeni özellikler ekler.
#### **İndeksle Grafik Veri Noktasını ve Grafik Kategorisini Kaldırma Metodları Eklendi**
IChartDataPointCollection.RemoveAt(int index) metodu, grafik veri noktasını indeksine göre kaldırmak için eklendi.
IChartCategoryCollection.RemoveAt(int index) metodu, grafik kategorisini indeksine göre kaldırmak için eklendi.
#### **PptXPptY Değeri Aspose.Slides.Animation.PropertyType Enumeration'ına Eklendi**
PptXPptY değeri, bir serileştirme sorunu düzeltmesi kapsamında Aspose.Slides.Animation.PropertyType enumeration'ına eklendi.
#### **System.Drawing.Color GetAutomaticSeriesColor() Metodu Aspose.Slides.Charts.IChartSeries'e Eklendi**
GetAutomaticSeriesColor metodu, seri indeksi ve grafik stiline göre serinin otomatik bir rengini döndürür. FillType NotDefined olduğunda bu renk varsayılan olarak kullanılır.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```