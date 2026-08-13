---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.2.0"
linktitle: "Aspose.Slides لـ .NET 15.2.0"
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides for .NET لتتمكن من ترحيل حلول عروض PowerPoint PPT و PPTX و ODP بسلاسة."
---
{{% alert color="info" %}} 

تُدرج هذه الصفحة جميع الفئات أو الطرق أو الخصائص وغيرها، والتي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) مع Aspose.Slides for .NET 15.2.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تمت إضافة طرق AddDataPointForDoughnutSeries**
تمت إضافة النسختان الزائديتان لطريقة IChartDataPointCollection.AddDataPointForDoughnutSeries() لإضافة نقاط البيانات إلى سلسلة من نوع مخطط الدونات.
#### **تم وراثة صنف Aspose.Slides.SmartArt.SmartArtShape من صنف Aspose.Slides.GeometryShape**
تم وراثة الصنف Aspose.Slides.SmartArt.SmartArtShape من الصنف Aspose.Slides.GeometryShape. يُحسّن هذا التغيير نموذج كائنات Aspose.Slides ويضيف ميزات جديدة إلى الصنف SmartArtShape.
#### **تمت إضافة طرق لإزالة نقطة بيانات المخطط وفئة المخطط حسب الفهرس**
تمت إضافة طريقة IChartDataPointCollection.RemoveAt(int index) لإزالة نقطة بيانات المخطط بناءً على فهرستها.
تمت إضافة طريقة IChartCategoryCollection.RemoveAt(int index) لإزالة فئة المخطط بناءً على فهرستها.
#### **تمت إضافة القيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType**
تمت إضافة القيمة PptXPptY إلى تعداد Aspose.Slides.Animation.PropertyType في نطاق إصلاح مشكلة التسلسل.
#### **تمت إضافة طريقة System.Drawing.Color GetAutomaticSeriesColor() إلى Aspose.Slides.Charts.IChartSeries**
تُعيد طريقة GetAutomaticSeriesColor لونًا تلقائيًا للسلسلة بناءً على فهرس السلسلة ونمط المخطط. يُستخدم هذا اللون افتراضيًا إذا كان FillType يساوي NotDefined.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```