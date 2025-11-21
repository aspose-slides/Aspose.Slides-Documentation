---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة إلى الخلف في Aspose.Slides for .NET 15.2.0
linktitle: Aspose.Slides لـ .NET 15.2.0
type: docs
weight: 140
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- الترحيل
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint (PPT، PPTX) و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات، والطرق، والخصائص، وما إلى ذلك من [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) والتغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.2.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تمت إضافة طرق AddDataPointForDoughnutSeries**
تمت إضافة التحميلين لطريقة IChartDataPointCollection.AddDataPointForDoughnutSeries() لإضافة نقاط البيانات إلى سلسلة من نوع مخطط الدونات.
#### **تم توريث الفئة Aspose.Slides.SmartArt.SmartArtShape من الفئة Aspose.Slides.GeometryShape**
تم توريث الفئة Aspose.Slides.SmartArt.SmartArtShape من الفئة Aspose.Slides.GeometryShape. يُحسن هذا التغيير نموذج الكائنات في Aspose.Slides ويضيف ميزات جديدة إلى الفئة SmartArtShape.
#### **تمت إضافة طرق لإزالة نقطة بيانات المخطط وفئة المخطط حسب الفهرس**
تمت إضافة طريقة IChartDataPointCollection.RemoveAt(int index) لإزالة نقطة بيانات المخطط وفقًا لفهرستها.
تمت إضافة طريقة IChartCategoryCollection.RemoveAt(int index) لإزالة فئة المخطط وفقًا لفهرستها.
#### **تمت إضافة القيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType**
تمت إضافة القيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType في سياق إصلاح مشكلة التسلسل.
#### **تمت إضافة طريقة System.Drawing.Color GetAutomaticSeriesColor() إلى Aspose.Slides.Charts.IChartSeries**
تعيد طريقة GetAutomaticSeriesColor لونًا تلقائيًا للسلسلة بناءً على فهرس السلسلة ونمط المخطط. يُستخدم هذا اللون بشكل افتراضي إذا كان FillType يساوي NotDefined.

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