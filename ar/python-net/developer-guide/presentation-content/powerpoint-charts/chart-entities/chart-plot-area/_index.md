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
description: "اكتشف كيفية تخصيص مناطق رسم المخططات في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. حسّن مظهر الشرائح بسهولة."
---

## **الحصول على عرض وارتفاع مساحة رسم المخطط**
توفر Aspose.Slides لـ Python عبر .NET واجهة برمجة تطبيقات بسيطة لـ .

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. استدعاء الطريقة IChart.ValidateChartLayout() قبل الحصول على القيم الفعلية.
5. الحصول على الموقع الفعلي X (اليسار) لعنصر المخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط.
6. الحصول على الجزء العلوي الفعلي لعنصر المخطط بالنسبة إلى الزاوية اليسرى العليا للمخطط.
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


## **تحديد وضع تخطيط مساحة رسم المخطط**
توفر Aspose.Slides لـ Python عبر .NET واجهة برمجة تطبيقات بسيطة لتعيين وضع تخطيط مساحة رسم المخطط. تم إضافة الخاصية **LayoutTargetType** إلى الفئات **ChartPlotArea** و **IChartPlotArea**. إذا تم تعريف تخطيط مساحة الرسم يدويًا، تحدد هذه الخاصية ما إذا كان سيتم تخطيط المساحة من الداخل (بدون المحاور وعناوين المحاور) أو من الخارج (بما في ذلك المحاور وعناوين المحاور). هناك قيمتان محتملتان معرفتان في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم مساحة الرسم يحدد حجم المساحة، دون إشمال العلامات والمحاور وعناوينها.
- **LayoutTargetType.Outer** - يحدد أن حجم مساحة الرسم يحدد حجم المساحة، بالإضافة إلى العلامات والمحاور وعناوينها.

الكود العيني موضح أدناه.
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

**بأي وحدة يتم إرجاع actual_x و actual_y و actual_width و actual_height؟**  
بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف يختلف Plot Area عن Chart Area من حيث المحتوى؟**  
Plot Area هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما Chart Area تشمل العناصر المحيطة (العنوان، الوسيلة الإيضاحية، إلخ). في المخططات ثلاثية الأبعاد، تشمل Plot Area أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير X و Y والعرض والارتفاع في Plot Area عندما يكون التخطيط يدويًا؟**  
تكون كسورًا (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم تعطيل التموضع التلقائي وتُستخدم الكسور التي تم تحديدها.

**لماذا تغير موقع Plot Area بعد إضافة/تحريك الوسيلة الإيضاحية؟**  
الوسيلة الإيضاحية تقع في مساحة المخطط خارج Plot Area لكنها تؤثر على التخطيط والمساحة المتاحة، لذا قد يتحرك Plot Area عندما يكون التموضع التلقائي مفعلاً. (هذا سلوك قياسي في مخططات PowerPoint.)