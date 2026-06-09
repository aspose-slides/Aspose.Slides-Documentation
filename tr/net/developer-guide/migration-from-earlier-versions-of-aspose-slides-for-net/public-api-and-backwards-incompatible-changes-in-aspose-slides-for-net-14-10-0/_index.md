---
title: Aspose.Slides for .NET 14.10.0'da Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for .NET'te genel API güncellemelerini ve kırılım değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 
Bu sayfa, Aspose.Slides for .NET 14.10.0 API ile tanıtılan eklenen veya kaldırılan sınıfları, yöntemleri, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Public API Chages**
#### **Aspose.Slides.FieldType.Footer Field Type Has Been Added**
Footer alan türü, bu türde alanlar oluşturma olanağını sağlamak ve geçerli sunum serileştirmesi için eklenmiştir.
#### **Enum Element ShapeElementFillSource.Own Has Been Deleted**
ShapeElementFillSource.Own enum ögesi yinelenen olduğu için silinmiştir. ShapeElementFillSource.Own yerine ShapeElementFillSource.Shape kullanın.
#### **Methods for Chart Data Points, Categories Removing Have Been Added**
Aşağıdaki yöntemler, bir grafik veri noktasını veri noktası koleksiyonundan kaldırmanıza olanak tanır ve eklenmiştir:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Aşağıdaki yöntem, bir grafik kategorisini içeren koleksiyondan kaldırmanıza olanak tanır ve eklenmiştir:

IChartCategory.Remove()

``` csharp

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
    pres.Save(outPath, SaveFormat.Pptx);
}
``` 
#### **Obsolete Aspose.Slides.ParagraphFormat Properties Have Been Removed**
BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle özellikleri kaldırıldı. Uzun süredir kullanımdan kaldırılmışlardı.
#### **Unuseful and Obsolete Constructors Have Been Removed**
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