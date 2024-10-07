---
title: جدول بيانات الرسم البياني
type: docs
url: /python-net/chart-data-table/
keywords: "خصائص الخط، جدول بيانات الرسم البياني، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "تعيين خصائص الخط لجدول بيانات الرسم البياني في عروض PowerPoint باستخدام بايثون"
---

## **تعيين خصائص الخط لجدول بيانات الرسم البياني**
توفر Aspose.Slides لبايثون عبر .NET دعمًا لتغيير لون الفئات في لون السلسلة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. إضافة الرسم البياني إلى الشريحة.
1. تعيين جدول الرسم البياني.
1. تعيين ارتفاع الخط.
1. حفظ العرض المعدل.

 أدناه مثال توضيحي.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```