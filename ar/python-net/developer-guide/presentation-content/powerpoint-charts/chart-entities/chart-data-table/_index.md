---
title: تخصيص جداول بيانات المخطط في بايثون
linktitle: جدول بيانات المخطط
type: docs
url: /ar/python-net/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تخصيص جداول بيانات المخطط في بايثون للملفات PPT و PPTX و ODP باستخدام Aspose.Slides لتعزيز الكفاءة والجاذبية في العروض التقديمية."
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
توفر Aspose.Slides للـ Python عبر .NET دعمًا لتغيير لون الفئات في لون السلسلة.

1. إنشاء كائن فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. إضافة مخطط إلى الشريحة.
1. تعيين جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

مثال عينة أدناه موضح.
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


## **الأسئلة المتكررة**

**هل يمكنني إظهار مفاتيح وسيلة الإيضاح الصغيرة بجانب القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/)، ويمكنك تفعيلها أو إيقافها.

**هل سيظل جدول البيانات محفوظًا عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برندر المخطط كجزء من الشريحة، لذا فإن الـ[PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/python-net/convert-powerpoint-to-html/)/[image](/slides/ar/python-net/convert-powerpoint-to-png/) المُصدّر يتضمن المخطط مع جدول بياناته.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. بالنسبة لأي مخطط تم تحميله من عرض تقديمي أو قالب موجود، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات في ملف ما والتي لديها جدول البيانات مفعّل؟**

افحص خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) ثم تكرار عبر الشرائح لتحديد المخططات التي تم تفعيلها.