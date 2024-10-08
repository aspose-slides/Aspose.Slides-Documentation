---
title: منطقة تخطيط الرسم البياني
type: docs
url: /ar/python-net/chart-plot-area/
keywords: "منطقة تخطيط الرسم البياني، عرض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "احصل على عرض وارتفاع منطقة تخطيط الرسم البياني. حدد وضع التخطيط. عرض PowerPoint في Python"
---

## **احصل على عرض وارتفاع منطقة تخطيط الرسم البياني**
يوفر Aspose.Slides لـ Python عبر .NET واجهة برمجة تطبيقات بسيطة لـ.

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. الوصول إلى الشريحة الأولى.
1. أضف الرسم البياني ببيانات افتراضية.
1. استدعِ الطريقة IChart.ValidateChartLayout() قبل الحصول على القيم الفعلية.
1. احصل على الموقع الفعلي X (الأيسر) لعنصر الرسم البياني بالنسبة لزاوية الرسم البياني العلوية اليسرى.
1. احصل على الجزء العلوي الفعلي لعنصر الرسم البياني بالنسبة لزاوية الرسم البياني العلوية اليسرى.
1. احصل على عرض العنصر الفعلي للرسم البياني.
1. احصل على ارتفاع العنصر الفعلي للرسم البياني.

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
	
	# احفظ العرض التقديمي مع الرسم البياني
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```


## **حدد وضع التخطيط لمنطقة تخطيط الرسم البياني**
يوفر Aspose.Slides لـ Python عبر .NET واجهة برمجة تطبيقات بسيطة لتحديد وضع التخطيط لمنطقة تخطيط الرسم البياني. تمت إضافة خاصية **LayoutTargetType** إلى **ChartPlotArea** و **IChartPlotArea** classes. إذا تم تعريف تخطيط منطقة التخطيط يدويًا، فإن هذه الخاصية تحدد ما إذا كان يجب تخطيط منطقة التخطيط حسب داخلها (لا تشمل المحاور وعلامات المحاور) أو خارجها (تشمل المحاور وعلامات المحاور). هناك قيمتان ممكنتان محددتان في **LayoutTargetType** enum.

- **LayoutTargetType.Inner** - تحدد أن حجم منطقة التخطيط يجب أن يحدد حجم منطقة التخطيط، لا تشمل علامات النقر وعلامات المحاور.
- **LayoutTargetType.Outer** - تحدد أن حجم منطقة التخطيط يجب أن يحدد حجم منطقة التخطيط وعلامات النقر وعلامات المحاور.

تم تقديم كود عينة أدناه.

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