---
title: "تخصيص مناطق رسم المخططات في العروض التقديمية باستخدام بايثون"
linktitle: "منطقة الرسم"
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
description: "اكتشف كيفية تخصيص مناطق رسم المخططات في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. حسّن مظهر الشرائح بسهولة."
---

## **الحصول على العرض والارتفاع لمنطقة رسم المخطط**
توفر Aspose.Slides لبايثون عبر .NET واجهة برمجة تطبيقات بسيطة.

1. إنشاء مثيل من الفئة[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. استدعاء الطريقة IChart.ValidateChartLayout() للحصول على القيم الفعلية.
5. الحصول على الموقع الفعلي X (اليسار) لعنصر المخطط بالنسبة إلى الزاوية العلوية اليسرى للمخطط.
6. الحصول على الطرف العلوي الفعلي لعنصر المخطط بالنسبة إلى الزاوية العلوية اليسرى للمخطط.
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
	
	# حفظ العرض التقديمي مع المخطط
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **ضبط وضع التخطيط لمنطقة رسم المخطط**
توفر Aspose.Slides لبايثون عبر .NET واجهة برمجة تطبيقات بسيطة لضبط وضع التخطيط لمنطقة رسم المخطط. تمت إضافة الخاصية **LayoutTargetType** إلى الفئات **ChartPlotArea** و **IChartPlotArea**. إذا تم تعريف تخطيط منطقة الرسم يدويًا، تحدد هذه الخاصية ما إذا كان يجب تخطيط منطقة الرسم من الداخل (دون تضمين المحاور وتسميات المحاور) أو من الخارج (مع تضمين المحاور وتسميات المحاور). هناك قيمتان محتملتان محددتان في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم منطقة الرسم سيحدد حجم المنطقة دون تضمين علامات الفواصل وتسميات المحاور.
- **LayoutTargetType.Outer** - يحدد أن حجم منطقة الرسم سيحدد حجم المنطقة، وعلامات الفواصل، وتسميات المحاور.

الكود النموذجي موضح أدناه.

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

**بأي وحدات يتم إرجاع actual_x و actual_y و actual_width و actual_height؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف منطقة الرسم عن منطقة المخطط من حيث المحتوى؟**

منطقة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما تشمل منطقة المخطط العناصر المحيطة (العنوان، المفتاح، إلخ). في المخططات ثلاثية الأبعاد، تشمل منطقة الرسم أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم X و Y والعرض والارتفاع لمنطقة الرسم عندما يكون التخطيط يدويًا؟**

هي كسور (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم إيقاف التحديد التلقائي وتُستخدم الكسور التي تحددها.

**لماذا تغير موضع منطقة الرسم بعد إضافة/تحريك المفتاح؟**

المفتاح يقع في منطقة المخطط خارج منطقة الرسم ولكنه يؤثر على التخطيط والمساحة المتاحة، لذا قد تتحرك منطقة الرسم عندما يكون التحديد التلقائي مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)