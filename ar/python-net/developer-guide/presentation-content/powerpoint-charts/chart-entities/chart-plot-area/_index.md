---
title: تخصيص مناطق الرسم البياني للشرائح التقديمية في بايثون
linktitle: منطقة الرسم
type: docs
url: /ar/python-net/chart-plot-area/
keywords:
- مخطط
- منطقة الرسم
- عرض منطقة الرسم
- ارتفاع منطقة الرسم
- حجم منطقة الرسم
- وضع التخطيط
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية تخصيص مناطق الرسم البياني للشرائح التقديمية في PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. حسّن مظهر الشرائح بسهولة."
---

## **احصل على عرض وارتفاع منطقة الرسم البياني**
Aspose.Slides للبايثون عبر .NET توفر واجهة برمجة تطبيقات بسيطة لـ .

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. استدعاء الطريقة IChart.ValidateChartLayout() قبل للحصول على القيم الفعلية.
5. الحصول على الموقع الفعلي X (اليسار) لعنصر المخطط بالنسبة إلى الزاوية اليسرى العلوية للمخطط.
6. الحصول على الأعلى الفعلي لعنصر المخطط بالنسبة إلى الزاوية اليسرى العلوية للمخطط.
7. الحصول على العرض الفعلي لعنصر المخطط.
8. الحصول على الارتفاع الفعلي لعنصر المخطط.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Save presentation with chart
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين وضع التخطيط لمنطقة الرسم البياني**
Aspose.Slides للبايثون عبر .NET توفر واجهة برمجة تطبيقات بسيطة لتعيين وضع التخطيط لمنطقة الرسم البياني. تم إضافة الخاصية **LayoutTargetType** إلى الفئات **ChartPlotArea** و **IChartPlotArea**. إذا تم تعريف تخطيط منطقة الرسم يدويًا، تحدد هذه الخاصية ما إذا كان سيتم تخطيط المنطقة من الداخل (دون تضمين المحاور وتسمية المحاور) أو من الخارج (متضمنة المحاور وتسمية المحاور). هناك قيمتين محتملتين معرّفتين في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم منطقة الرسم سيحدد حجم المنطقة نفسها، دون تضمين علامات المحور وتسميات المحور.
- **LayoutTargetType.Outer** - يحدد أن حجم منطقة الرسم سيحدد حجم المنطقة، علامات المحور، وتسميات المحور.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**بأي وحدات تُرجع القيم actual_x و actual_y و actual_width و actual_height؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات الإحداثيات في Aspose.Slides.

**كيف تختلف منطقة الرسم عن منطقة المخطط من حيث المحتوى؟**

منطقة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، الخطوط الاتجاهية، إلخ)؛ بينما تشمل منطقة المخطط العناصر المحيطة (العنوان، وسيلة الإيضاح، إلخ). في المخططات ثلاثية الأبعاد، تشمل منطقة الرسم أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم X و Y والعرض والارتفاع لمنطقة الرسم عندما يكون التخطيط يدويًا؟**

هي كسور (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع، يتم إيقاف التموقع التلقائي وتُستخدم الكسور التي تحددها.

**لماذا تغير موقع منطقة الرسم بعد إضافة/نقل وسيلة الإيضاح؟**

تقع وسيلة الإيضاح في منطقة المخطط خارج منطقة الرسم لكنها تؤثر على التخطيط والمساحة المتاحة، لذا قد يتحرك منطقة الرسم عندما يكون التموقع التلقائي فعالاً. (هذا سلوك قياسي لمخططات PowerPoint.)