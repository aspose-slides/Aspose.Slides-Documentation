---
title: تخصيص وسوم المخططات في العروض التقديمية باستخدام بايثون
linktitle: وسم المخطط
type: docs
url: /ar/python-net/chart-legend/
keywords:
- وسم المخطط
- موضع الوسم
- حجم الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "خصص وسوم المخططات باستخدام Aspose.Slides لبايثون عبر .NET لتحسين عروض PowerPoint وOpenDocument مع تنسيق وسوم مخصص."
---

## **نظرة عامة**

يوفر Aspose.Slides لبايثون تحكمًا كاملاً في وسوم المخططات حتى تتمكن من جعل تسميات البيانات واضحة وجاهزة للعرض. يمكنك إظهار أو إخفاء الوسم، اختيار موقعه على الشريحة، وضبط التخطيط لمنع التداخل مع منطقة الرسم. تتيح لك API تنسيق النص والعلامات، تعديل الحشو والخلفية بدقة، وتنسيق الحدود والملء لتطابق السمة الخاصة بك. يمكن للمطورين أيضًا الوصول إلى عناصر الوسم الفردية لإعادة تسميتها أو تصفيتها، مما يضمن عرض السلاسل الأكثر صلة فقط. مع هذه الإمكانات، تظل مخططاتك قابلة للقراءة، ومتسقة، ومتوافقة مع معايير تصميم عرضك التقديمي.

## **موضع الوسم**

باستخدام Aspose.Slides، يمكنك التحكم بسرعة في موضع ظهور وسوم المخططات وكيفية توافقها مع تخطيط الشريحة. تعلّم كيفية وضع الوسم بدقة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة.
3. إضافة مخطط إلى الشريحة.
4. تعيين خصائص الوسم.
5. حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، نحدد موضع وحجم وسم المخطط:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء نسخة من الفئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على مرجع إلى الشريحة.
    slide = presentation.slides[0]

    # إضافة مخطط عمودي مجمّع إلى الشريحة.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # تعيين خصائص الوسم.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط حجم خط الوسم**

يجب أن يكون وسم المخطط قابلًا للقراءة كما البيانات التي يوضحها. يوضح هذا القسم كيفية تعديل حجم خط الوسم لتتماشى مع طباعة عرضك التقديمي وتحسين إمكانية الوصول.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إنشاء مخطط.
3. تعيين حجم الخط.
4. حفظ العرض التقديمي إلى القرص.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط حجم الخط لعنصر وسم**

يتيح لك Aspose.Slides ضبط مظهر وسوم المخططات بدقة من خلال تنسيق العناصر الفردية. يوضح المثال أدناه كيفية استهداف عنصر وسم معين وتعيين خصائصه دون تغيير باقي الوسم.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إنشاء مخطط.
3. الوصول إلى عنصر من وسوم المخطط.
4. تعيين خصائص العنصر.
5. حفظ العرض التقديمي إلى القرص.

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

## **الأسئلة الشائعة**

**هل يمكنني تمكين الوسم بحيث يخصص المخطط مساحة له تلقائيًا بدلاً من تراكبه؟**

نعم. استخدم وضع غير التراكب ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`)؛ في هذه الحالة، ستصغر منطقة الرسم لتستوعب الوسم.

**هل يمكنني إنشاء تسميات وسوم متعددة الأسطر؟**

نعم. تُلف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ وتدعم فواصل الأسطر الإجباريّة عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل الوسم يتبع نظام ألوان سمة العرض التقديمي؟**

لا تُحدد ألوانًا/ملءً/خطوطًا صريحة للوسم أو نصه. سيتورّث ذلك من السمة وسيتم تحديثه بشكل صحيح عند تغيير التصميم.