---
title: تخصيص مناطق الرسم لمخططات العروض التقديمية في .NET
linktitle: منطقة الرسم
type: docs
url: /ar/net/chart-plot-area/
keywords:
- مخطط
- منطقة الرسم
- عرض منطقة الرسم
- ارتفاع منطقة الرسم
- حجم منطقة الرسم
- وضع التخطيط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية تخصيص مناطق رسم المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides for .NET. حسّن مظهر الشرائح بسهولة."
---

## **الحصول على العرض والارتفاع لمنطقة رسم المخطط**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لـ .

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. استدعاء طريقة IChart.ValidateChartLayout() للحصول على القيم الفعلية.
1. الحصول على الموقع الفعلي X (اليسار) لعنصر المخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط.
1. الحصول على الجزء العلوي الفعلي لعنصر المخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط.
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





## **تعيين وضع التخطيط لمنطقة رسم المخطط**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لتعيين وضع التخطيط لمنطقة رسم المخطط. تم إضافة الخاصية **LayoutTargetType** إلى الفئات **ChartPlotArea** و **IChartPlotArea**. إذا تم تعريف تخطيط منطقة الرسم يدويًا، تحدد هذه الخاصية ما إذا كان يجب تخطيط المنطقة الداخلي (بدون المحور وعناوين المحور) أو الخارجي (مع المحور وعناوين المحور). هناك قيمتان محتملتان معرفتان في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم منطقة الرسم يحدد حجم المنطقة، بدون علامات الفواصل وعناوين المحور.
- **LayoutTargetType.Outer** - يحدد أن حجم منطقة الرسم يحدد حجم المنطقة، مع علامات الفواصل وعناوين المحور.

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


## **الأسئلة الشائعة**

**بأي وحدات يتم إرجاع ActualX وActualY وActualWidth وActualHeight؟**

بالنقاط؛ إنّ البوصة الواحدة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف منطقة الرسم عن منطقة المخطط من حيث المحتوى؟**

منطقة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ أما منطقة المخطط فتشمل العناصر المحيطة (العنوان، مفتاح الرسم، إلخ). في المخططات ثلاثية الأبعاد، تشمل منطقة الرسم أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم X وY والعرض والارتفاع لمنطقة الرسم عندما يكون التخطيط يدويًا؟**

هي كسور (0–1) من حجم المخطط الكلي؛ في هذا الوضع يتم إلغاء التحديد التلقائي وتُستخدم الكسور التي تحددها.

**لماذا تغير موقع منطقة الرسم بعد إضافة/نقل المفتاح؟**

المفتاح يقع في منطقة المخطط خارج منطقة الرسم لكنه يؤثر على التخطيط والمساحة المتاحة، لذلك قد تتغير مكان منطقة الرسم عندما يكون التحديد التلقائي مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)