---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.10.0
linktitle: Aspose.Slides لـ .NET 14.10.0
type: docs
weight: 120
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- الهجرة
- كود تقليدي
- كود حديث
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint PPT، PPTX و ODP الخاصة بك."
---
{{% alert color="info" %}} 

تُظهر هذه الصفحة جميع الفئات، والطرق، والخصائص وما إلى ذلك التي تم [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) والتغييرات الأخرى التي تم إدخالها مع Aspose.Slides لـ .NET 14.10.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تم إضافة نوع الحقل Aspose.Slides.FieldType.Footer**
تم إضافة نوع حقل Footer لتوفير إمكانية إنشاء حقول من هذا النوع ولتحسين تسلسل العرض التقديمي الصحيح.
#### **تم حذف عنصر التعداد ShapeElementFillSource.Own**
تم حذف عنصر التعداد ShapeElementFillSource.Own لأنه مكرر. استخدم ShapeElementFillSource.Shape بدلاً من ShapeElementFillSource.Own.
#### **تم إضافة طرق لإزالة نقاط بيانات المخطط والفئات**
تم إضافة الطرق التالية التي تسمح بإزالة نقطة بيانات المخطط من مجموعة نقاط بيانات المخطط:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

تم إضافة الطريقة التالية التي تسمح بإزالة فئة مخطط من المجموعة المحتوية:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //إزالة باستخدام ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //إزالة باستخدام ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//إزالة باستخدام ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **تم إزالة الخصائص القديمة Aspose.Slides.ParagraphFormat**
تم إزالة الخصائص BulletChar وBulletColor وBulletColorFormat وBulletFont وBulletHeight وBulletType وIsBulletHardColor وIsBulletHardFont وNumberedBulletStartWith وNumberedBulletStyle. تم وضع علامة عليها بأنها غير صالحة منذ فترة طويلة.
#### **تم إزالة البُنى غير المفيدة والقديمة**
تم إزالة البُنى التالية:

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