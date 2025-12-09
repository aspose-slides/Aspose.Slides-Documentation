---
title: تخصيص جداول بيانات المخطط في بايثون
linktitle: جدول البيانات
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
description: "تخصيص جداول بيانات المخطط في بايثون لملفات PPT و PPTX و ODP باستخدام Aspose.Slides لتعزيز الكفاءة وجاذبية العروض التقديمية."
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
توفر Aspose.Slides for Python عبر .NET دعمًا لتغيير لون الفئات في لون السلسلة.

1. إنشاء كائن من فئة [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إضافة مخطط إلى الشريحة.
3. تعيين جدول المخطط.
4. تعيين ارتفاع الخط.
5. حفظ العرض المعدل.

فيما يلي مثال توضيحي.
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


## **الأسئلة الشائعة**

**هل يمكنني إظهار مفاتيح وسيلة إيضاح صغيرة بجانب القيم في جدول بيانات المخطط؟**
نعم. يدعم جدول البيانات [مفاتيح وسيلة الإيضاح](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/)، ويمكنك تشغيلها أو إيقافها.

**هل سيبقى جدول البيانات محفوظًا عند تصدير العرض إلى PDF أو HTML أو صور؟**
نعم. تقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذا فإن الـ[PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/python-net/convert-powerpoint-to-html/)/[image](/slides/ar/python-net/convert-powerpoint-to-png/) المُصدَّر يتضمن المخطط مع جدول بياناته.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**
نعم. بالنسبة لأي مخطط تم تحميله من عرض أو قالب موجود، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات في ملف ما التي تم تمكين جدول البيانات لها؟**
افحص خاصية كل مخطط التي تُظهر ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) وتجوَّل عبر الشرائح لتحديد المخططات التي تم تمكينه فيها.