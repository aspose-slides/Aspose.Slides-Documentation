---
title: التغييرات العامة لواجهة برمجة التطبيقات والغير متوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 14.10.0
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- الترحيل
- شفرة قديمة
- شفرة حديثة
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسِّرة في Aspose.Slides for .NET لتتمكن من ترحيل حلول عروض PowerPoint (PPT, PPTX) و ODP بسلاسة."
---

{{% alert color="primary" %}} 

تقوم هذه الصفحة بسرد جميع الفئات، والطرق، والخصائص وما إلى ذلك التي تم [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) بها، وكذلك التغييرات الأخرى المقدمة مع Aspose.Slides for .NET 14.10.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تم إضافة نوع الحقل Aspose.Slides.FieldType.Footer**
#### **تم حذف عنصر التعداد ShapeElementFillSource.Own**
#### **تمت إضافة طرق لإزالة نقاط بيانات المخطط والفئات**
الطرق التالية التي تسمح بإزالة نقطة بيانات المخطط من مجموعة نقاط بيانات المخطط تمّت إضافتها:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

الطريقة التالية التي تسمح بإزالة فئة المخطط من المجموعة المحتوية تمّت إضافتها:

IChartCategory.Remove()

``` csharp
 using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);
    chart.ChartData.Categories[0].Remove(); //remove with ChartCategory.Remove()
    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //remove with ChartCategoryCollection.Remove()
    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//remove with ChartDataPoint.Remove()
        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }
    pres.Save(outPath, SaveFormat.Pptx);
}
``` 
#### **تمت إزالة خصائص Aspose.Slides.ParagraphFormat القديمة**
الخصائص BulletChar، BulletColor، BulletColorFormat، BulletFont، BulletHeight، BulletType، IsBulletHardColor، IsBulletHardFont، NumberedBulletStartWith، NumberedBulletStyle تمّت إزالتها. كانت قد تم وضع علامة قديمة عليها منذ فترة طويلة.
#### **تمت إزالة المنشئين غير المفيدين والقدامى**
المنشئين التاليين تمّت إزالتهم:

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