---
title: منطقة رسم المخطط
type: docs
url: /ar/net/chart-plot-area/
keywords: "منطقة رسم المخطط عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "الحصول على العرض والارتفاع لمنطقة رسم المخطط. ضبط وضع التخطيط. عرض PowerPoint في C# أو .NET"
---

## **الحصول على العرض والارتفاع لمنطقة رسم المخطط**
Aspose.Slides for .NET توفر واجهة برمجة تطبيقات بسيطة لـ .

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط مع البيانات الافتراضية.
1. استدعاء الطريقة IChart.ValidateChartLayout() قبل للحصول على القيم الفعلية.
1. يُحصل على الموضع الفعلي X (اليسار) لعنصر المخطط نسبةً إلى الزاوية اليسرى العليا للمخطط.
1. يُحصل على أعلى العنصر الفعلي للمخطط نسبةً إلى الزاوية اليسرى العليا للمخطط.
1. يُحصل على العرض الفعلي لعنصر المخطط.
1. يُحصل على الارتفاع الفعلي لعنصر المخطط.
```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// حفظ العرض التقديمي مع المخطط
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```


## **ضبط وضع تخطيط منطقة رسم المخطط**
Aspose.Slides for .NET توفر واجهة برمجة تطبيقات بسيطة لضبط وضع تخطيط منطقة رسم المخطط. تم إضافة الخاصية **LayoutTargetType** إلى الفئات **ChartPlotArea** و **IChartPlotArea**. إذا تم تعريف تخطيط منطقة الرسم يدويا، تحدد هذه الخاصية ما إذا كان يتم تخطيط المنطقة من الداخل (بدون المحاور وعناوين المحاور) أو من الخارج (مع المحاور وعناوين المحاور). هناك قيمتان ممكنتان معرفتان في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم منطقة الرسم يحدد حجم المنطقة نفسه، بدون علامات التحديد وعناوين المحاور.
- **LayoutTargetType.Outer** - يحدد أن حجم منطقة الرسم يحدد حجم المنطقة، وعلامات التحديد، وعناوين المحاور.

الكود النموذجي موضح أدناه.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**بأي وحدات تُرجع القيم ActualX، ActualY، ActualWidth، وActualHeight؟**

وحدات النقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف منطقة الرسم (Plot Area) عن منطقة المخطط (Chart Area) من حيث المحتوى؟**

منطقة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما تشمل منطقة المخطط العناصر المحيطة (العنوان، المفتاح، إلخ). في المخططات ثلاثية الأبعاد، تشمل منطقة الرسم أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم X، Y، العرض، والارتفاع لمنطقة الرسم عندما يكون التخطيط يدويًا؟**

هي كسور (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع، يتم إلغاء التمركز التلقائي وتُستخدم الكسور التي تحددها.

**لماذا تغير موقع منطقة الرسم بعد إضافة/نقل المفتاح؟**

المفتاح يقع في منطقة المخطط خارج منطقة الرسم لكنه يؤثر على التخطيط والمساحة المتاحة، لذا قد تتحرك منطقة الرسم عندما يكون التمركز التلقائي مفعلاً. (هذا سلوك قياسي للمخططات في PowerPoint.)