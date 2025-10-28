---
title: تخصيص مساحات الرسم البياني في عروض PowerPoint باستخدام Python
linktitle: مساحة الرسم
type: docs
url: /ar/python-net/chart-plot-area/
keywords:
- مخطط
- مساحة الرسم
- عرض مساحة الرسم
- ارتفاع مساحة الرسم
- حجم مساحة الرسم
- وضع التخطيط
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية تخصيص مساحات الرسم البياني في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET. حسّن مظهر الشرائح بسهولة."
---

## **الحصول على العرض والارتفاع لمساحة رسم المخطط**
توفر Aspose.Slides for Python عبر .NET واجهة برمجة تطبيقات بسيطة لـ .

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. استدعاء الطريقة IChart.ValidateChartLayout() قبل الحصول على القيم الفعلية.
5. الحصول على الموقع الفعلي لمحور X (الجانب الأيسر) لعنصر المخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط.
6. الحصول على الموقع الفعلي لأعلى عنصر المخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط.
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




## **تعيين وضع التخطيط لمساحة رسم المخطط**
توفر Aspose.Slides for Python عبر .NET واجهة برمجة تطبيقات بسيطة لتعيين وضع التخطيط لمساحة رسم المخطط. تمت إضافة الخاصية **LayoutTargetType** إلى فئتي **ChartPlotArea** و **IChartPlotArea**. إذا تم تحديد تخطيط مساحة الرسم يدويًا، تحدد هذه الخاصية ما إذا كان سيتم تخطيط مساحة الرسم من داخلها (دون تضمين المحاور وعناوين المحاور) أو من خارجها (مع تضمين المحاور وعناوين المحاور). هناك قيمتان محتملتان معرفة في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم مساحة الرسم سيحدد حجم مساحة الرسم دون تضمين علامات التدرج وعناوين المحاور.
- **LayoutTargetType.Outer** - يحدد أن حجم مساحة الرسم سيحدد حجم مساحة الرسم، بما في ذلك علامات التدرج وعناوين المحاور.

الكود التالي مثال توضيحي.

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

## **FAQ**

**بأي وحدات تُرجع القيم actual_x و actual_y و actual_width و actual_height؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف مساحة الرسم عن مساحة المخطط من حيث المحتوى؟**

مساحة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما تشمل مساحة المخطط العناصر المحيطة (العنوان، الأسطورة، إلخ). في المخططات ثلاثية الأبعاد، تشمل مساحة الرسم أيضًا الجدران/القاع والمحاور.

**كيف يتم تفسير قيم X و Y والعرض والارتفاع لمساحة الرسم عندما يكون التخطيط يدويًا؟**

تُعطى كنسب (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم تعطيل الوضع التلقائي وتُستخدم النسب التي تحددها.

**لماذا تغير موقع مساحة الرسم بعد إضافة/تحريك الأسطورة؟**

الأسطورة تقع في مساحة المخطط خارج مساحة الرسم ولكنها تؤثر على التخطيط والمساحة المتاحة، لذا قد تتحرك مساحة الرسم عندما يكون الوضع التلقائي مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)