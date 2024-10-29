---
title: واجهة البرمجة العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.10.0
type: docs
weight: 120
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع [المضاف](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) أو [المزال](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) الفئات، الطرق، الخصائص وما إلى ذلك، والتغييرات الأخرى التي تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 14.10.0.

{{% /alert %}} 
## **تغييرات واجهة البرمجة العامة**
#### **تم إضافة نوع حقل Aspose.Slides.FieldType.Footer**
تم إضافة نوع حقل Footer لتنفيذ إمكانية إنشاء حقول من هذا النوع ولتسلسل العروض المعتمدة بشكل صحيح.
#### **تم حذف عنصر enum ShapeElementFillSource.Own**
تم حذف عنصر enum ShapeElementFillSource.Own باعتباره مكرراً. استخدم ShapeElementFillSource.Shape بدلاً من ShapeElementFillSource.Own.
#### **تم إضافة طرق لإزالة نقاط بيانات الرسم البياني والفئات**
تمت إضافة الطرق التالية، التي تسمح بإزالة نقطة بيانات الرسم البياني من مجموعة نقاط بيانات الرسم البياني:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

تمت إضافة الطريقة التالية، التي تسمح بإزالة فئة الرسم البياني من المجموعة المحتوية:

IChartCategory.Remove()

``` csharp

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

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **تمت إزالة خصائص Aspose.Slides.ParagraphFormat المهملة**
تمت إزالة الخصائص BulletChar، BulletColor، BulletColorFormat، BulletFont، BulletHeight، BulletType، IsBulletHardColor، IsBulletHardFont، NumberedBulletStartWith، NumberedBulletStyle. لقد تم وضع علامة عليها كمتهملة منذ فترة طويلة.
#### **تمت إزالة المنشئات غير المفيدة والمهملة**
تمت إزالة المنشئات التالية:

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