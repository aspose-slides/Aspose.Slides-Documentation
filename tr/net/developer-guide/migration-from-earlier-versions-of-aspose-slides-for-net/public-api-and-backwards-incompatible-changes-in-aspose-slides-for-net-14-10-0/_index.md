---
title: Aspose.Slides for .NET 14.10.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
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
Bu sayfa, Aspose.Slides for .NET 14.10.0 API'siyle tanıtılan [added](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) veya [removed](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **Aspose.Slides.FieldType.Footer Alan Türü Eklendi**
Footer alan türü, bu türde alanlar oluşturma olanağını sağlamak ve geçerli sunum serileştirmesi için eklenmiştir.
#### **ShapeElementFillSource.Own Enum Elemanı Silindi**
ShapeElementFillSource.Own enum öğesi, yinelenmiş olduğu için silinmiştir. ShapeElementFillSource.Own yerine ShapeElementFillSource.Shape kullanın.
#### **Grafik Veri Noktaları ve Kategorileri Kaldırma Yöntemleri Eklendi**
Aşağıdaki yöntemler, bir grafik veri noktası koleksiyonundan veri noktasını kaldırmaya olanak tanır ve eklenmiştir:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Aşağıdaki yöntem, bir grafik kategorisini içeren koleksiyondan kaldırmaya olanak tanır ve eklenmiştir:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //ChartCategory.Remove() ile kaldır

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //ChartCategoryCollection.Remove() ile kaldır

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//ChartDataPoint.Remove() ile kaldır

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **Kullanım Dışı Aspose.Slides.ParagraphFormat Özellikleri Kaldırıldı**
BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith ve NumberedBulletStyle özellikleri kaldırıldı. Bu özellikler uzun zaman önce kullanım dışı olarak işaretlenmişti.
#### **Kullanılamaz ve Kullanım Dışı Yapıcılar Kaldırıldı**
Aşağıdaki yapıcılar kaldırıldı:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)