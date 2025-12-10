---
title: تغييرات API العامة وغير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.2.0
linktitle: Aspose.Slides لـ .NET 15.2.0
type: docs
weight: 140
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- ترحيل
- الكود القديم
- الكود الحديث
- النهج القديم
- النهج الحديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات API العامة والتغييرات المكسورة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد كل الفئات [مضاف](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) أو [مزال](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) والطرق والخصائص وما إلى ذلك، بالإضافة إلى التغييرات الأخرى التي تم إدخالها مع Aspose.Slides for .NET 15.2.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم إضافة طرق AddDataPointForDoughnutSeries**
تمت إضافة النسختين المتجاوزتين من طريقة IChartDataPointCollection.AddDataPointForDoughnutSeries() لإضافة نقاط البيانات إلى سلاسل من نوع مخطط الدونات.
#### **تم توريث فئة Aspose.Slides.SmartArt.SmartArtShape من فئة Aspose.Slides.GeometryShape**
تم توريث فئة Aspose.Slides.SmartArt.SmartArtShape من فئة Aspose.Slides.GeometryShape. هذا التغيير يحسن نموذج الكائنات في Aspose.Slides ويضيف ميزات جديدة إلى فئة SmartArtShape.
#### **تم إضافة طرق لإزالة نقطة بيانات المخطط وفئة المخطط حسب الفهرس**
تمت إضافة طريقة IChartDataPointCollection.RemoveAt(int index) لإزالة نقطة بيانات المخطط حسب فهرستها.
تمت إضافة طريقة IChartCategoryCollection.RemoveAt(int index) لإزالة فئة المخطط حسب فهرستها.
#### **تم إضافة قيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType**
تمت إضافة قيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType كجزء من إصلاح مشكلة التسلسل.
#### **تم إضافة طريقة System.Drawing.Color GetAutomaticSeriesColor() إلى Aspose.Slides.Charts.IChartSeries**
طريقة GetAutomaticSeriesColor تُرجع لونًا تلقائيًا للسلسلة بناءً على فهرس السلسلة ونمط المخطط. يُستخدم هذا اللون افتراضيًا إذا كان FillType يساوي NotDefined.

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