---
title: منطقة رسم المخطط
type: docs
url: /ar/net/chart-plot-area/
keywords: "منطقة رسم المخطط عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "احصل على عرض وارتفاع منطقة رسم المخطط. تعيين وضع التخطيط. عرض PowerPoint في C# أو .NET"
---

## **احصل على عرض وارتفاع منطقة رسم المخطط**
توفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة لـ .

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. الوصول إلى الشريحة الأولى.
1. أضف مخططًا ببيانات افتراضية.
1. استدعاء الدالة IChart.ValidateChartLayout() قبل الحصول على القيم الفعلية.
1. الحصول على الموقع الفعلي لـ X (يسار) عنصر المخطط بالنسبة للزاوية العليا اليسرى من المخطط.
1. الحصول على الجزء العلوي الفعلي لعنصر المخطط بالنسبة للزاوية العليا اليسرى من المخطط.
1. الحصول على العرض الفعلي لعنصر المخطط.
1. الحصول على الارتفاع الفعلي لعنصر المخطط.

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




## **تعيين وضع تخطيط منطقة رسم المخطط**
توفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة لتعيين وضع تخطيط منطقة رسم المخطط. تمت إضافة خاصية **LayoutTargetType** إلى فصول **ChartPlotArea** و **IChartPlotArea**. إذا تم تعريف تخطيط منطقة الرسم يدويًا، فإن هذه الخاصية تحدد ما إذا كان يجب تخطيط منطقة الرسم من الداخل (لا يشمل المحاور وعلامات المحاور) أو من الخارج (يشمل المحاور وعلامات المحاور). هناك قيمتان ممكنتان تم تعريفهما في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - تحدد أنه يجب أن يحدد حجم منطقة الرسم حجم منطقة الرسم، دون احتساب علامات الدرج والمحاور.
- **LayoutTargetType.Outer** - تحدد أنه يجب أن يحدد حجم منطقة الرسم حجم منطقة الرسم، مع علامات الدرج والمحاور.

الكود النموذجي مذكور أدناه.

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