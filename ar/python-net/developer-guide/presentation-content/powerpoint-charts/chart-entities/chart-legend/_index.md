---
title: تخصيص وسائط المخططات في العروض التقديمية باستخدام Python
linktitle: وسائط المخطط
type: docs
url: /ar/python-net/chart-legend/
keywords:
- وسائط المخطط
- موضع الوسيط
- حجم الخط
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تخصيص وسائط المخططات باستخدام Aspose.Slides for Python عبر .NET لتحسين عروض PowerPoint و OpenDocument مع تنسيق وسائط مخصص."
---

## **نظرة عامة**

يوفر Aspose.Slides for Python تحكمًا كاملاً في وسائط توضيح المخططات حتى تتمكن من جعل تسميات البيانات واضحة وجاهزة للعرض. يمكنك إظهار أو إخفاء الوسيط، واختيار موقعه على الشريحة، وضبط التخطيط لمنع التداخل مع منطقة الرسم. تتيح لك واجهة برمجة التطبيقات تنسيق النص والعلامات، وضبط الحشو والخلفية بدقة، وتنسيق الحدود والملء لتتناسب مع النمط الخاص بك. يمكن للمطورين أيضًا الوصول إلى عناصر الوسيط الفردية لإعادة تسميتها أو تصفيتها، مما يضمن عرض السلاسل الأكثر صلة فقط. مع هذه القدرات، تظل مخططاتك قابلة للقراءة ومتسقة ومتوافقة مع معايير تصميم العرض التقديمي.

## **تحديد موقع الوسيط**

باستخدام Aspose.Slides، يمكنك التحكم بسرعة في موقع ظهور وسائط توضيح المخطط وكيفية ملائمتها لتخطيط الشريحة. تعرف على كيفية وضع الوسيط بدقة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة.
1. إضافة مخطط إلى الشريحة.
1. تعيين خصائص الوسيط.
1. حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، نقوم بتعيين موضع وحجم وسائط المخطط:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء مثال من فئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على مرجع إلى الشريحة.
    slide = presentation.slides[0]

    # إضافة مخطط عمودي مجمع إلى الشريحة.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # تعيين خصائص وسيلة الإيضاح.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```


## **ضبط حجم خط الوسيط**

يجب أن يكون وسيط المخطط قابلًا للقراءة كما البيانات التي يوضحها. يوضح هذا القسم كيفية تعديل حجم خط الوسيط لتتطابق مع خطوط العرض التقديمي وتحسين إمكانية الوصول.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. إنشاء مخطط.
1. ضبط حجم الخط.
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


## **ضبط حجم الخط لمدخل وسيط معين**

يتيح لك Aspose.Slides ضبط مظهر وسائط المخطط بدقة عن طريق تنسيق العناصر الفردية. يوضح المثال أدناه كيفية استهداف عنصر وسيط معين وتعيين خصائصه دون تغيير باقي الوسيط.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. إنشاء مخطط.
1. الوصول إلى مدخل وسيط.
1. تعيين خصائص المدخل.
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


## **الأسئلة الشائعة**

**هل يمكنني تفعيل الوسيط بحيث يقوم المخطط تلقائيًا بتخصيص مساحة له بدلاً من تغطيته؟**

نعم. استخدم وضع عدم التغطية ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/)=`false`); في هذه الحالة، ستقلص منطقة الرسم لتستوعب الوسيط.

**هل يمكنني إنشاء تسميات متعددة الأسطر للوسيط؟**

نعم. تُلف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ وتدعم فواصل السطر القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل الوسيط يتبع نظام ألوان نمط العرض التقديمي؟**

لا تقم بتعيين ألوان/ملء/خطوط صريحة للوسيط أو نصه. سيُورث ذلك من النمط وسيتم تحديثه بشكل صحيح عند تغيير التصميم.