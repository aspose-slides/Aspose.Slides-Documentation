---
title: تخصيص وسوم المخطط في العروض التقديمية باستخدام بايثون
linktitle: وسوم المخطط
type: docs
url: /ar/python-net/chart-legend/
keywords:
- وسوم المخطط
- موضع الوسم
- حجم الخط
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تخصيص وسوم المخطط باستخدام Aspose.Slides for Python عبر .NET لتحسين عروض PowerPoint و OpenDocument مع تنسيق وسوم مخصص."
---

## **نظرة عامة**

توفر مكتبة Aspose.Slides for Python تحكمًا كاملاً في وسوم المخطط بحيث يمكنك جعل تسميات البيانات واضحة وجاهزة للعرض. يمكنك إظهار أو إخفاء الوسم، اختيار موقعه على الشريحة، وضبط التخطيط لمنع التداخل مع منطقة الرسم. تسمح لك الواجهة البرمجية بتنسيق النص والعلامات، تعديل الحشو والخلفية بدقة، وتنسيق الحدود والملئ لتتناسب مع موضوعك. يمكن للمطورين أيضًا الوصول إلى إدخالات الوسم الفردية لإعادة تسميتها أو تصفيتها، مما يضمن عرض السلاسل الأكثر صلة فقط. مع هذه الإمكانيات، تبقى المخططات قابلة للقراءة، ومتسقة، ومتوافقة مع معايير تصميم العرض التقديمي الخاص بك.

## **موضع الوسم**

باستخدام Aspose.Slides، يمكنك بسرعة التحكم في مكان ظهور وسوم المخطط وكيفية تناسبها مع تخطيط الشريحة. تعلّم كيفية وضع الوسم بدقة.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة.
1. إضافة مخطط إلى الشريحة.
1. تعيين خصائص الوسم.
1. حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، نحدد موضع وحجم وسم المخطط:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على مرجع إلى الشريحة.
    slide = presentation.slides[0]

    # إضافة مخطط أعمدة مدمجة إلى الشريحة.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # تعيين خصائص الوسم.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين حجم خط الوسم**

يجب أن يكون وسوم المخطط مقروءًا تمامًا مثل البيانات التي يشرحها. يوضح هذا القسم كيفية تعديل حجم خط الوسم لتطابق طباعة العرض التقديمي وتحسين إمكانية الوصول.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إنشاء مخطط.
1. تعيين حجم الخط.
1. حفظ العرض التقديمي إلى القرص.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين حجم الخط لإدخال وسم معين**

تتيح لك Aspose.Slides ضبط مظهر وسوم المخطط من خلال تنسيق الإدخالات الفردية. يوضح المثال أدناه كيفية استهداف عنصر وسم محدد وتعيين خصائصه دون تغيير بقية الوسوم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إنشاء مخطط.
1. الوصول إلى إدخال وسم.
1. تعيين خصائص الإدخال.
1. حفظ العرض التقديمي إلى القرص.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يمكنني تمكين الوسم بحيث يخصص المخطط مساحة له تلقائيًا بدلاً من تغطيته؟**

نعم. استخدم وضع عدم التراكب ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); في هذه الحالة، ستصغر منطقة الرسم لتستوعب الوسم.

**هل يمكنني إنشاء وسوم متعددة الأسطر؟**

نعم. تُلفّ التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ وتدعم الفواصل القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل الوسم يتبع مخطط ألوان موضوع العرض التقديمي؟**

لا تقم بتعيين ألوان/ملء/خطوط صريحة للوسم أو نصه. سيتوارث ذلك من الموضوع وبالتالي سيتحدّث تلقائيًا عند تغيير التصميم.