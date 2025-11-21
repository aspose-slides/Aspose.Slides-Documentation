---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.10.0
linktitle: Aspose.Slides لـ .NET 14.10.0
type: docs
weight: 120
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- الترحيل
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET لتتمكن من ترحيل حلول عروض PowerPoint PPT، PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

هذه الصفحة تُظهر جميع الفئات، والطرق، والخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) مع Aspose.Slides for .NET 14.10.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تمت إضافة نوع الحقل Aspose.Slides.FieldType.Footer**
تمت إضافة نوع الحقل Footer للسماح بإنشاء حقول من هذا النوع ولضمان تسلسل عرض تقديمي صالح.
#### **تم حذف عنصر التعداد ShapeElementFillSource.Own**
تم حذف عنصر التعداد ShapeElementFillSource.Own لأنه مكرر. استخدم ShapeElementFillSource.Shape بدلاً من ShapeElementFillSource.Own.
#### **تمت إضافة طرق لإزالة نقاط بيانات المخطط والفئات**
تمت إضافة الطُرُق التالية التي تسمح بإزالة نقطة بيانات من مجموعة نقاط بيانات المخطط:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

تمت إضافة الطريقة التالية التي تسمح بإزالة فئة مخطط من المجموعة المحتوية:

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
#### **تمت إزالة الخصائص القديمة Aspose.Slides.ParagraphFormat**
تمت إزالة الخصائص BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle. كانت مُعلَّمة كقديمة منذ وقت طويل.
#### **تمت إزالة المُنشئات غير المفيدة والقديمة**
تمت إزالة المُنشئات التالية:

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