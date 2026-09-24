---
title: تخصيص جداول بيانات المخططات في العروض التقديمية بلغة Python
linktitle: جدول البيانات
type: docs
url: /ar/python-net/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بتخصيص خطوط جدول بيانات المخطط، والحدود، ومفاتيح الأسطورة في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة Python عبر .NET."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يتيح لك عرض جدول بيانات المخطط وتخصيص تنسيق النص والحدود ومفاتيح الأسطورة. يشرح هذا المقال كيفية تمكين الجدول، تنسيق نصه، التحكم في كل نوع من الحدود، وإظهار أو إخفاء مفاتيح الأسطورة. تقوم الأمثلة بحفظ المخططات التي تم تكوينها في ملفات PPTX.

## **تعيين خصائص الخط**

لعرض جدول بيانات المخطط، اضبط [has_data_table](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/has_data_table/) على `True`. استخدم [chart_data_table](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/chart_data_table/) للوصول إلى الجدول وتكوين تنسيق النص.

1. حمّل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. أضف مخطط أعمدة مجمع إلى الشريحة الأولى.
1. فعّل جدول بيانات المخطط.
1. فعّل النص الغامق باستخدام [font_bold](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/font_bold/) واضبط [font_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/font_height/) على `20` للنص بحجم 20 نقطة.
1. احفظ العرض التقديمي المعدل.

المثال التالي يتطلب وجود `test.pptx` في دليل العمل مع شريحة واحدة على الأقل. يضيف مخططًا ببيانات افتراضية في الموضع (50, 50)، بعرض 600 نقطة وارتفاع 400 نقطة. يحتوي الملف `output.pptx` المحفوظ على المخطط مع تمكين جدول البيانات وتطبيق إعدادات الخط المحددة.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تخصيص حدود جدول البيانات**

تمكين الجدول باستخدام [Chart.has_data_table](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/has_data_table/) والوصول إليه عبر [Chart.chart_data_table](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/chart_data_table/). يمكنك التحكم في ثلاثة أنواع من الحدود بشكل مستقل:

- [has_border_horizontal](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datatable/has_border_horizontal/) يتحكم في حدود الخلايا الأفقية.
- [has_border_vertical](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datatable/has_border_vertical/) يتحكم في حدود الخلايا العمودية.
- [has_border_outline](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datatable/has_border_outline/) يتحكم في الحد الخارجي للجدول.

اضبط كل خاصية على `True` لعرض حدودها أو على `False` لإخفائها. المثال التالي ينشئ مخطط أعمدة مجمع ببيانات افتراضية، يعرض الحدود الأفقية والحد الخارجي، ويخفي الحدود العمودية. لا يتطلب ملف إدخال. يتم تحديد موضع وحجم المخطط بالنقاط.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

المقارنة أدناه تستخدم نفس بيانات المخطط وإعداد مفتاح الأسطورة في جميع الحالات الأربعة. بدءًا من تمكين جميع الحدود، كل نسخة متبقية تعطل خاصية حد واحدة فقط. النسخة السفلية اليسرى تتطابق مع إعدادات الحدود في المثال.

![جداول بيانات المخطط مع تمكين جميع الحدود، بدون حدود أفقية، بدون حدود عمودية، ومن دون الحد الخارجي](data-table-borders.png)

## **إظهار أو إخفاء مفاتيح الأسطورة**

مفاتيح الأسطورة هي علامات ملونة صغيرة بجوار أسماء السلاسل في جدول البيانات. تساعد القارئ على مطابقة كل صف في الجدول مع سلسلة المخطط. اضبط [show_legend_key](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datatable/show_legend_key/) على `True` لعرض هذه العلامات أو على `False` لإخفائها.

الأسطورة المنفصلة للمخطط تتحكم بها الخاصية [Chart.has_legend](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/has_legend/). هذه الإعدادات مستقلة: إخفاء الأسطورة المنفصلة لا يخفي المفاتيح داخل جدول البيانات، وإخفاء مفاتيح الجدول لا يخفي الأسطورة المنفصلة.

المثال التالي ينشئ مخططًا ببيانات افتراضية، يفعّل جدول البيانات، ويظهر مفاتيح الأسطورة داخله مع إخفاء الأسطورة المنفصلة. جميع حدود الجدول مفعلة صراحة. لا يلزم وجود عرض تقديمي كمدخل. لإخفاء مفاتيح الجدول فقط، غير `data_table.show_legend_key` إلى `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

المقارنة أدناه تُظهر نفس الجدول بمفاتيح أسطورة مفعلة ومخفاة. تظل جميع الحدود مفعلة، وتظل الأسطورة المنفصلة للمخطط مخفية في الحالتين.

![جداول بيانات المخطط مع مفاتيح الأسطورة معروضة على اليسار ومخفاة على اليمين](data-table-legend-keys.png)

## **الأسئلة المتكررة**

**هل يمكنني إظهار مفاتيح الأسطورة في جدول بيانات المخطط؟**

نعم. ضع [show_legend_key] على `True` لعرض مفاتيح الأسطورة أو على `False` لإخفائها.

**هل سيبقى جدول البيانات محفوظًا عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. Aspose.Slides يقوم برندر المخطط وجدول البيانات المعروض كجزء من الشريحة عند التصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، أو [images](/slides/ar/python-net/convert-powerpoint-to-png/).

**هل يمكنني العمل مع جداول البيانات في المخططات التي تم تحميلها من قالب؟**

نعم. للمخطط المحمّل من عرض تقديمي أو قالب موجود، استخدم [has_data_table] للتحقق أو تغيير ما إذا كان جدول البيانات معروضًا.

**كيف يمكنني العثور على المخططات التي لديها جدول بيانات مفعل؟**

قم بالتجوال عبر الأشكال في كل شريحة، حدد المخططات، وتفقد خاصية [has_data_table] الخاصة بها. قيمة `True` تشير إلى أن جدول البيانات مفعَّل.