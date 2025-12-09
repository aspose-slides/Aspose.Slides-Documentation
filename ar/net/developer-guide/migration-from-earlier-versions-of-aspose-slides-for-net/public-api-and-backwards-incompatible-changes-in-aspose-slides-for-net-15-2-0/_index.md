---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 15.2.0
linktitle: Aspose.Slides لـ .NET 15.2.0
type: docs
weight: 140
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات الفاصلة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint بصيغ PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات أو الأساليب أو الخصائص [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) أو [مُزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) وما إلى ذلك، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.2.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تمت إضافة أساليب AddDataPointForDoughnutSeries**
تمت إضافة التحميلين لطريقة IChartDataPointCollection.AddDataPointForDoughnutSeries() لإضافة نقاط البيانات إلى سلاسل نوع المخطط الدونات.
#### **تم توريث الفئة Aspose.Slides.SmartArt.SmartArtShape من الفئة Aspose.Slides.GeometryShape**
هذا التغيير يحسن نموذج الكائنات Aspose.Slides ويضيف ميزات جديدة إلى فئة SmartArtShape.
#### **تمت إضافة أساليب لإزالة نقطة بيانات المخطط وفئة المخطط حسب الفهرس**
تمت إضافة طريقة IChartDataPointCollection.RemoveAt(int index) لإزالة نقطة بيانات المخطط حسب الفهرس الخاص بها.
تمت إضافة طريقة IChartCategoryCollection.RemoveAt(int index) لإزالة فئة المخطط حسب الفهرس الخاص بها.
#### **تمت إضافة القيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType**
تمت إضافة القيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType في إطار إصلاح مشكلة التسلسل.
#### **تمت إضافة طريقة System.Drawing.Color GetAutomaticSeriesColor() إلى Aspose.Slides.Charts.IChartSeries**
تُعيد طريقة GetAutomaticSeriesColor لونًا تلقائيًا للسلسلة بناءً على فهرس السلسلة ونمط المخطط. يُستخدم هذا اللون بشكل افتراضي إذا كان FillType يساوي NotDefined.

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