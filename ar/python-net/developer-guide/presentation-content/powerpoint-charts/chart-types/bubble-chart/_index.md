---
title: رسم بياني فقاعة
type: docs
url: /ar/python-net/bubble-chart/
keywords: "رسم بياني فقاعة، حجم الرسم البياني، عرض تقديمي لـ PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "حجم الرسم البياني الفقاعة في عروض PowerPoint التقديمية باستخدام Python"
---

## **تغيير حجم رسم بياني فقاعة**
توفر Aspose.Slides لـ Python عبر .NET دعمًا لتغيير حجم رسم بياني الفقاعة. تم إضافة خصائص **ChartSeries.bubble_size_scale** و **ChartSeriesGroup.bubble_size_scale**. أدناه مثال توضيحي.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **تمثيل البيانات كأحجام لرسم بياني فقاعة**
تمت إضافة خاصية **bubble_size_representation** إلى فئات ChartSeries و ChartSeriesGroup. تحدد **bubble_size_representation** كيفية تمثيل قيم حجم الفقاعة في الرسم البياني الفقاعة. القيم الممكنة هي: **BubbleSizeRepresentationType.AREA** و **BubbleSizeRepresentationType.WIDTH**. بناءً عليه، تم إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق الممكنة لتمثيل البيانات كأحجام لرسم بياني فقاعة. الكود التوضيحي موضح أدناه.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```