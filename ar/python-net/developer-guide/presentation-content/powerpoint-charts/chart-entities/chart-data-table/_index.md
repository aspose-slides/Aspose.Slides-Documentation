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
description: "تخصيص جداول بيانات المخطط في بايثون لـ PPT و PPTX و ODP باستخدام Aspose.Slides لتعزيز الكفاءة والجاذبية في العروض التقديمية."
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
توفر Aspose.Slides for Python عبر .NET دعمًا لتغيير لون الفئات في لون السلسلة.

1. إنشاء كائن فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إضافة مخطط إلى الشريحة.
3. تعيين جدول المخطط.
4. تعيين ارتفاع الخط.
5. حفظ العرض التقديمي المعدل.

يتم تقديم مثال عينة أدناه.
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

**هل يمكنني عرض مفاتيح أسطورة صغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [مفاتيح الأسطورة](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/)، ويمكنك تمكينها أو تعطيلها.

**هل سيتم الحفاظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides بتصيير المخطط كجزء من الشريحة، لذا فإن [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/python-net/convert-powerpoint-to-html/)/[image](/slides/ar/python-net/convert-powerpoint-to-png/) المصدّر يتضمن المخطط مع جدول بياناته.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. لأي مخطط يتم تحميله من عرض تقديمي أو قالب موجود، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [مُظهرًا](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) باستخدام خصائص المخطط.

**كيف يمكنني العثور سريعًا على المخططات في ملف ما التي تم تمكين جدول البيانات لها؟**

افحص خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [مُظهرًا](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) وتكرّر عبر الشرائح لتحديد المخططات التي تم تمكينه فيها.