---
title: تخصيص مناطق رسم المخططات في العروض التقديمية .NET
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
توفر Aspose.Slides for .NET واجهة برمجية بسيطة لـ .

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. الوصول إلى الشريحة الأولى
3. إضافة مخطط ببيانات افتراضية
4. استدعاء الطريقة IChart.ValidateChartLayout() قبل الحصول على القيم الفعلية
5. الحصول على الموقع الفعلي X (اليسار) لعنصر المخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط
6. الحصول على الجزء العلوي الفعلي لعنصر المخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط
7. الحصول على العرض الفعلي لعنصر المخطط
8. الحصول على الارتفاع الفعلي لعنصر المخطط
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
توفر Aspose.Slides for .NET واجهة برمجية بسيطة لتعيين وضع التخطيط لمنطقة رسم المخطط. تم إضافة الخاصية **LayoutTargetType** إلى الفئات **ChartPlotArea** و **IChartPlotArea**. إذا تم تعريف تخطيط منطقة الرسم يدوياً، تحدد هذه الخاصية ما إذا كان سيتم تخطيط المنطقة من الداخل (بدون المحاور وتسميات المحاور) أو من الخارج (مع المحاور وتسميات المح axes). هناك قيمتين ممكنتين معرفتين في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم منطقة الرسم يحدد حجم المنطقة نفسها، دون تضمين علامات الفواصل وتسميات المحاور.
- **LayoutTargetType.Outer** - يحدد أن حجم منطقة الرسم يحدد حجم المنطقة، وعلامات الفواصل، وتسميات المحاور.

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


## **الأسئلة المتكررة**
**بأي وحدة يتم إرجاع قيم ActualX و ActualY و ActualWidth و ActualHeight؟**

بالنقاط؛ 1 إنش = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف منطقة الرسم عن منطقة المخطط من حيث المحتوى؟**

منطقة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما منطقة المخطط تشمل العناصر المحيطة (العنوان، الأسطورة، إلخ). في المخططات ثلاثية الأبعاد، تشمل منطقة الرسم أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم X و Y والعرض والارتفاع لمنطقة الرسم عندما يكون التخطيط يدوياً؟**

تُعتبر هذه القيم كسُكّات (من 0 إلى 1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم تعطيل التحديد التلقائي وتُستخدم القيم التي تحددها.

**لماذا تغير موقع منطقة الرسم بعد إضافة/نقل الأسطورة؟**

تقع الأسطورة في منطقة المخططات خارج منطقة الرسم لكنها تؤثر على التخطيط والمساحة المتاحة، لذا قد تتحرك منطقة الرسم عندما يكون التحديد التلقائي مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)