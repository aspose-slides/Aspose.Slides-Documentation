---
title: تصدير الرسم البياني
type: docs
weight: 90
url: /ar/python-net/export-chart/
keywords:
- رسم بياني
- صورة الرسم البياني
- استخراج صورة الرسم البياني
- PowerPoint
- عرض تقديمي
- بايثون
- Aspose.Slides لـ بايثون
description: "الحصول على صور الرسوم البيانية من عروض PowerPoint في بايثون"
---

## **الحصول على صورة الرسم البياني**
تقدم Aspose.Slides لـ بايثون عبر .NET الدعم لاستخراج صورة لرسم بياني محدد. مثال على ذلك موضح أدناه. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```