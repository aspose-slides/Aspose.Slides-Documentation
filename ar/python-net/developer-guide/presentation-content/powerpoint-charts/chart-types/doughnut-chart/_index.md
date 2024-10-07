---
title: مخطط الدونات
type: docs
weight: 30
url: /python-net/doughnut-chart/
keywords: "مخطط الدونات, فتحة مركزية, تقديم PowerPoint, بايثون, Aspose.Slides لـ Python عبر .NET"
description: "حدد الفتحة المركزية في مخطط الدونات في تقديم PowerPoint في بايثون"
---

## **حدد الفتحة المركزية في مخطط الدونات**
لتحديد حجم الفتحة في مخطط الدونات. يرجى اتباع الخطوات التالية:

- أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- أضف مخطط الدونات على الشريحة.
- حدد حجم الفتحة في مخطط الدونات.
- اكتب العرض التقديمي على القرص.

في المثال المعطى أدناه، قمنا بتعيين حجم الفتحة في مخطط الدونات.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # كتابة العرض التقديمي على القرص
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```