---
title: Aspose.Slides for .NET 15.2.0'da Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve geri uyumsuz değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for .NET 15.2.0 API'si ile tanıtılan tüm [added](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) veya [removed](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) sınıfları, metodları, özellikleri ve benzeri öğeleri listeler.

{{% /alert %}} 
## **Public API Değişiklikleri**
#### **AddDataPointForDoughnutSeries Metodları Eklendi**
IChartDataPointCollection.AddDataPointForDoughnutSeries() metodunun iki aşırı yüklemesi, Doughnut grafik türündeki serilere veri noktaları eklemek için eklendi.
#### **Aspose.Slides.SmartArt.SmartArtShape Sınıfı Aspose.Slides.GeometryShape Sınıfından Türetilmiştir**
Aspose.Slides.SmartArt.SmartArtShape sınıfı, Aspose.Slides.GeometryShape sınıfından türetilmiştir. Bu değişiklik, Aspose.Slides nesne modelini iyileştirir ve SmartArtShape sınıfına yeni özellikler ekler.
#### **İndeks ile Grafik Veri Noktası ve Grafik Kategorisi Kaldırma Metodları Eklendi**
IChartDataPointCollection.RemoveAt(int index) metodu, grafik veri noktasını indeksiyle kaldırmak için eklendi.
IChartCategoryCollection.RemoveAt(int index) metodu, grafik kategorisini indeksiyle kaldırmak için eklendi.
#### **PptXPptY Değeri Aspose.Slides.Animation.PropertyType Sıralamasına Eklendi**
Serileştirme sorunu düzeltmesi kapsamında, PptXPptY değeri Aspose.Slides.Animation.PropertyType sıralamasına eklendi.
#### **System.Drawing.Color GetAutomaticSeriesColor() Metodu Aspose.Slides.Charts.IChartSeries'e Eklendi**
GetAutomaticSeriesColor metodu, seri indeksine ve grafik stiline göre serinin otomatik rengini döndürür. FillType NotDefined ise bu renk varsayılan olarak kullanılır.

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