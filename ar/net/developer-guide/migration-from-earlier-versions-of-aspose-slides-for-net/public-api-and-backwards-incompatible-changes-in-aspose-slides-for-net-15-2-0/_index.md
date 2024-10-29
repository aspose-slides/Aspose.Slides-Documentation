---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.2.0
type: docs
weight: 140
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [المضاف](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) أو [المremoved](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) الفصول، والأساليب، والخصائص وما إلى ذلك، وغيرها من التغييرات المقدمة مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 15.2.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة طرق AddDataPointForDoughnutSeries**
تمت إضافة الاتجاهين من IChartDataPointCollection.AddDataPointForDoughnutSeries() لإضافة نقاط بيانات إلى سلسلة من نوع الرسم البياني Doughnut.
#### **تم وراثة فئة Aspose.Slides.SmartArt.SmartArtShape من فئة Aspose.Slides.GeometryShape**
تم وراثة فئة Aspose.Slides.SmartArt.SmartArtShape من فئة Aspose.Slides.GeometryShape. تعزز هذه التغيير نموذج كائن Aspose.Slides وتضيف ميزات جديدة إلى فئة SmartArtShape.
#### **تمت إضافة طرق لإزالة نقطة بيانات الرسم البياني وفئة الرسم البياني حسب الفهرس**
تمت إضافة طريقة IChartDataPointCollection.RemoveAt(int index) لإزالة نقطة بيانات الرسم البياني حسب فهرسها.
تمت إضافة طريقة IChartCategoryCollection.RemoveAt(int index) لإزالة فئة الرسم البياني حسب فهرسها.
#### **تمت إضافة قيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType**
تمت إضافة قيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType في نطاق إصلاح مشكلة تسلسل.
#### **تمت إضافة طريقة System.Drawing.Color GetAutomaticSeriesColor() إلى Aspose.Slides.Charts.IChartSeries**
تعيد طريقة GetAutomaticSeriesColor لونًا تلقائيًا للسلسلة استنادًا إلى فهرس السلسلة ونمط الرسم البياني. يُستخدم هذا اللون بشكل افتراضي إذا كانت FillType تساوي NotDefined.

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