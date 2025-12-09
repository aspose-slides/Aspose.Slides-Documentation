---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET 14.10.0
linktitle: Aspose.Slides لـ .NET 14.10.0
type: docs
weight: 120
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسّرة في Aspose.Slides لـ .NET لتحديث حلول عروض PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

هذه الصفحة تُدرج جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) أو [مزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) فيها، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 14.10.0 API.

{{% /alert %}} 
## **التغييرات العامة للواجهة البرمجية**
#### **تم إضافة نوع الحقل Aspose.Slides.FieldType.Footer**
تم إضافة نوع الحقل Footer لتوفير إمكانية إنشاء حقول من هذا النوع ولتحسين تسلسل العرض التقديمي.
#### **تم حذف عنصر التعداد ShapeElementFillSource.Own**
تم حذف العنصر ShapeElementFillSource.Own لأنه مكرر. استخدم ShapeElementFillSource.Shape بدلًا من ShapeElementFillSource.Own.
#### **تم إضافة أساليب لإزالة نقاط بيانات المخطط والفئات**
تم إضافة الأساليب التالية التي تسمح بإزالة نقطة بيانات من مجموعة نقاط بيانات المخطط:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

وتم إضافة الأسلوب التالي الذي يسمح بإزالة فئة من المجموعة المحتواة:

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
#### **تم إزالة خصائص Aspose.Slides.ParagraphFormat المهجورة**
تم إزالة الخصائص BulletChar، BulletColor، BulletColorFormat، BulletFont، BulletHeight، BulletType، IsBulletHardColor، IsBulletHardFont، NumberedBulletStartWith، NumberedBulletStyle. كانت هذه الخصائص مُعلَّمة كمهجورة منذ فترة طويلة.
#### **تم إزالة البُنَاءات غير المفيدة والمهجورة**
تم إزالة البُنَاءات التالية:

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