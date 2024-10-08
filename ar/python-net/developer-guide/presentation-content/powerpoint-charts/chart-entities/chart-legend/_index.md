---
title:legenda الرسم البياني
type: docs
url: /ar/python-net/chart-legend/
keywords: "legenda الرسم البياني، حجم خط legenda، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "تعيين موضع وحجم الخط لlegenda الرسم البياني في عروض PowerPoint في بايثون"
---

## **موضع legenda**
لتعيين خصائص legenda. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- الحصول على مرجع للشريحة.
- إضافة رسم بياني على الشريحة.
- تعيين خصائص legenda.
- كتابة العرض التقديمي كملف PPTX.

في المثال الموضح أدناه، قمنا بتعيين الموضع والحجم للlegenda الرسم البياني.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation
with slides.Presentation() as presentation:

    # الحصول على مرجع للشريحة
    slide = presentation.slides[0]

    # إضافة رسم بياني عمودي مجمع على الشريحة
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # تعيين خصائص legenda
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # كتابة العرض التقديمي إلى القرص
    presentation.save("Legend_out.pptx", slides.export.SaveFormat.PPTX)
```



## **تعيين حجم خط legenda**
تتيح Aspose.Slides لـ بايثون عبر .NET للمطورين تعيين حجم خط legenda. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة `Presentation`.
- إنشاء الرسم البياني الافتراضي.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.legend.text_format.portion_format.font_height = 20
	chart.axes.vertical_axis.is_automatic_min_value = False
	chart.axes.vertical_axis.min_value = -5
	chart.axes.vertical_axis.is_automatic_max_value = False
	chart.axes.vertical_axis.max_value = 10

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين حجم خط legenda الفردية**
تتيح Aspose.Slides لـ بايثون عبر .NET للمطورين تعيين حجم خط عناصر legenda الفردية. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة `Presentation`.
- إنشاء الرسم البياني الافتراضي.
- الوصول إلى عنصر legenda.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw
 
 
with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	tf = chart.legend.entries[1].text_format

	tf.portion_format.font_bold = 1
	tf.portion_format.font_height = 20
	tf.portion_format.font_italic = 1
	tf.portion_format.fill_format.fill_type = slides.FillType.SOLID 
	tf.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```