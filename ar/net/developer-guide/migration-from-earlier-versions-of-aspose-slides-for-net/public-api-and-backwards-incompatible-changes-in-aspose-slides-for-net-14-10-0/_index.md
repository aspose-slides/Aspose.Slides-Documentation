---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.10.0
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
description: "استعراض التحديثات العامة لواجهة برمجة التطبيقات والتغييرات المتعارضة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تُدرج جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [تمت الإضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) أو [تمت الإزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) لها، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 14.10.0 API.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة نوع الحقل Aspose.Slides.FieldType.Footer**
#### **تم حذف عنصر التعداد ShapeElementFillSource.Own**
تم حذف عنصر التعداد ShapeElementFillSource.Own لأنه مكرر. استخدم ShapeElementFillSource.Shape بدلاً من ShapeElementFillSource.Own.
#### **تمت إضافة طرق لإزالة نقاط بيانات المخطط والفئات**
الطرق التالية، التي تسمح بإزالة نقطة بيانات المخطط من مجموعة نقاط البيانات، قد تم إضافتها:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

الطريقة التالية، التي تسمح بإزالة فئة مخطط من المجموعة المحتوية، قد تم إضافتها:

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
#### **تم حذف خصائص Aspose.Slides.ParagraphFormat القديمة**
تم حذف الخصائص BulletChar و BulletColor و BulletColorFormat و BulletFont و BulletHeight و BulletType و IsBulletHardColor و IsBulletHardFont و NumberedBulletStartWith و NumberedBulletStyle. كانت مُعلَّمة كعَتيقة منذ زمن طويل.
#### **تم حذف البناة غير المفيدة والقديمة**
المنشئات التالية تم حذفها:

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