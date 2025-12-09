---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.2.0
linktitle: Aspose.Slides لـ .NET 15.2.0
type: docs
weight: 140
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
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
description: "مراجعة تحديثات API العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

تُظهر هذه الصفحة جميع الفئات أو الطرق أو الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) مع Aspose.Slides for .NET 15.2.0 API.

{{% /alert %}} 
## **التغييرات في API العامة**
#### **تم إضافة طرق AddDataPointForDoughnutSeries**
تمت إضافة التحميلين الزائدين لطريقة IChartDataPointCollection.AddDataPointForDoughnutSeries() لإضافة نقاط البيانات إلى سلاسل نوع مخطط الدونات.
#### **تم توريث الفئة Aspose.Slides.SmartArt.SmartArtShape من الفئة Aspose.Slides.GeometryShape**
تم توريث الفئة Aspose.Slides.SmartArt.SmartArtShape من الفئة Aspose.Slides.GeometryShape. يُحسن هذا التغيير نموذج كائنات Aspose.Slides ويضيف ميزات جديدة إلى فئة SmartArtShape.
#### **تم إضافة طرق لإزالة نقطة بيانات المخطط وفئة المخطط بواسطة الفهرس**
تمت إضافة طريقة IChartDataPointCollection.RemoveAt(int index) لإزالة نقطة بيانات المخطط وفقًا لفهرستها. وتمت إضافة طريقة IChartCategoryCollection.RemoveAt(int index) لإزالة فئة المخطط وفقًا لفهرستها.
#### **تم إضافة القيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType**
تمت إضافة القيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType في إطار إصلاح مشكلة التسلسل.
#### **تم إضافة طريقة System.Drawing.Color GetAutomaticSeriesColor() إلى Aspose.Slides.Charts.IChartSeries**
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