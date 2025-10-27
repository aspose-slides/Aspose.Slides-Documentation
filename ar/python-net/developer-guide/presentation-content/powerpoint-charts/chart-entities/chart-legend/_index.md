---
title: تخصيص وسيلة إيضاح المخطط في العروض التقديمية باستخدام Python
linktitle: وسيلة إيضاح المخطط
type: docs
url: /ar/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-legend/
keywords:
- وسيلة إيضاح المخطط
- موضع الوسيلة
- حجم الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تخصيص وسائط إيضاح المخططات باستخدام Aspose.Slides for Python عبر .NET لتحسين عروض PowerPoint وOpenDocument مع تنسيق وسيلة إيضاح مخصص."
---

## **نظرة عامة**

يوفر Aspose.Slides for Python تحكمًا كاملًا في وسائط إيضاح المخططات بحيث يمكنك جعل تسميات البيانات واضحة وجاهزة للعرض. يمكنك إظهار أو إخفاء الوسيلة، اختيار موضعها على الشريحة، وضبط التخطيط لمنع التداخل مع منطقة الرسم. تسمح لك الواجهة البرمجية بتنسيق النص والعلامات، ضبط الهوامش والخلفية، وتنسيق الحدود والملء لتتناسب مع السمة الخاصة بك. يمكن للمطورين أيضًا الوصول إلى إدخالات الوسيلة الفردية لإعادة تسميتها أو تصفيتها، مما يضمن عرض السلاسل الأكثر صلة فقط. بفضل هذه الإمكانات، تظل المخططات قابلة للقراءة، متسقة، ومتوافقة مع معايير تصميم العرض التقديمي الخاص بك.

## **تحديد موضع الوسيلة**

باستخدام Aspose.Slides، يمكنك التحكم بسرعة في مكان ظهور وسيلة إيضاح المخطط وكيفية تناسبها مع تخطيط الشريحة. تعرف على كيفية وضع الوسيلة بدقة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على إشارة إلى الشريحة.
1. إضافة مخطط إلى الشريحة.
1. ضبط خصائص الوسيلة.
1. حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، نحدد موضع وحجم وسيلة إيضاح المخطط:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على إشارة إلى الشريحة.
    slide = presentation.slides[0]

    # إضافة مخطط عمودي مجمع إلى الشريحة.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # ضبط خصائص الوسيلة.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # حفظ العرض التقديمي على القرص.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين حجم خط الوسيلة**

يجب أن تكون وسيلة إيضاح المخطط قابلة للقراءة كما البيانات التي تشرحها. يوضح هذا القسم كيفية ضبط حجم خط الوسيلة لتتناسب مع طباعة العرض وتحسين إمكانية الوصول.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إنشاء مخطط.
1. ضبط حجم الخط.
1. حفظ العرض التقديمي على القرص.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين حجم الخط لعنصر وسيلة الإيضاح**

يتيح Aspose.Slides ضبط مظهر وسائط إيضاح المخططات من خلال تنسيق الإدخالات الفردية. يوضح المثال أدناه كيفية استهداف عنصر وسيلة محدد وضبط خصائصه دون تغيير باقي الوسيلة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إنشاء مخطط.
1. الوصول إلى إدخال وسيلة.
1. ضبط خصائص الإدخال.
1. حفظ العرض التقديمي على القرص.

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

**هل يمكنني تمكين الوسيلة بحيث يخصص المخطط مساحة لها تلقائيًا بدلاً من تغطيتها؟**

نعم. استخدم وضع عدم التراكب ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); في هذه الحالة، ستصغر منطقة الرسم لتستوعب الوسيلة.

**هل يمكنني إنشاء تسميات وسيلة متعددة الأسطر؟**

نعم. تُلتف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ وتدعم فواصل الأسطر القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل الوسيلة تتبع مخطط ألوان سمة العرض التقديمي؟**

لا تقم بتعيين ألوان/ملء/خطوط صريحة للوسيلة أو نصها. ستورث تلك القيم من السمة وتُحدّث بشكل صحيح عندما يتغير التصميم.