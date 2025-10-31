---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية باستخدام بايثون
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/python-net/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- مجموعة الإضاءة
- شكل القَطْع
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: اكتشف كيف تحسب وتطبّق Aspose.Slides للبايثون عبر .NET الخصائص الفعّالة للأشكال بدقة لتوفير عرض PowerPoint وOpenDocument متقن.
---

## **نظرة عامة**

في هذا الموضوع، ستتعلّم مفاهيم الخصائص **الفعّالة** و**المحلية**. عندما يتم تعيين القيم مباشرةً على المستويات التالية:

1. في خصائص جزء النص على الشريحة.
2. في نمط نص الشكل النموذجي على تخطيط الشريحة أو الشريحة الأساسية (إذا كان لإطار النص ذلك).
3. في إعدادات النص العامة للعرض التقديمي.

تُسمى تلك القيم **قِيَم محلية**. في أي مستوى، يمكن تعريف القيم **المحلية** أو تركها غير معرفة. عندما يحتاج التطبيق إلى تحديد كيفية ظهور جزء النص، يستخدم القيم **الفعّالة**. يمكنك الحصول على القيم الفعّالة باستدعاء طريقة `get_effective` على التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعّالة لتنسيق إطار النص وتنسيق جزء النص.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **الحصول على خصائص الكاميرا الفعّالة**

Aspose.Slides للبايثون عبر .NET يسمح لك باسترجاع خصائص الكاميرا الفعّالة. الفئة [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) تمثّل كائنًا غير قابل للتغيير يحتوي على هذه الخصائص. يتم توفير مثال من [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفّر القيم الفعّالة لفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

المثال التالي يوضح كيفية الحصول على خصائص الكاميرا الفعّالة:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= خصائص الكاميرا الفعّالة =")
	print("النوع:", str(three_d_effective_data.camera.camera_type))
	print("زاوية مجال الرؤية:", str(three_d_effective_data.camera.field_of_view_angle))
	print("التقريب:", str(three_d_effective_data.camera.zoom))
```

## **الحصول على خصائص مجموعة الإضاءة الفعّالة**

Aspose.Slides للبايثون عبر .NET يسمح لك باسترجاع الخصائص الفعّالة لمجموعة الإضاءة. الفئة [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) تمثّل كائنًا غير قابل للتغيير يحتوي على هذه الخصائص. يتم توفير مثال من [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفّر القيم الفعّالة لفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

المثال التالي يوضح كيفية الحصول على خصائص مجموعة الإضاءة الفعّالة:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= خصائص مجموعة الإضاءة الفعّالة =")
	print("النوع:", str(three_d_effective_data.light_rig.light_type))
	print("الاتجاه:", str(three_d_effective_data.light_rig.direction))
```

## **الحصول على خصائص القطع (Bevel) الفعّالة للشكل**

Aspose.Slides للبايثون عبر .NET يسمح لك باسترجاع الخصائص الفعّالة لقطعة الشكل. الفئة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) تمثّل كائنًا غير قابل للتغيير يحتوي على خصائص واجهة الشكل (القطعة). يتم توفير مثال من [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفّر القيم الفعّالة لفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

المثال التالي يوضح كيفية الحصول على الخصائص الفعّالة لقطعة الشكل:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= خصائص القطعة العلوية الفعّالة =")
	print("النوع:", str(three_d_effective_data.bevel_top.bevel_type))
	print("العرض:", str(three_d_effective_data.bevel_top.width))
	print("الارتفاع:", str(three_d_effective_data.bevel_top.height))
```

## **الحصول على خصائص إطار النص الفعّالة**

باستخدام Aspose.Slides للبايثون عبر .NET، يمكنك استرجاع الخصائص الفعّالة لإطار النص. الفئة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) تحتوي على خصائص تنسيق إطار النص الفعّالة.

المثال التالي يوضح كيفية الحصول على خصائص تنسيق إطار النص الفعّالة:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("نوع التثبيت:", str(text_frame_format_effective_data.anchoring_type))
	print("نوع الملاءمة الذاتية:", str(text_frame_format_effective_data.autofit_type))
	print("نوع النص العمودي:", str(text_frame_format_effective_data.text_vertical_type))
	print("الهوامش")
	print("   اليسار:", str(text_frame_format_effective_data.margin_left))
	print("   الأعلى:", str(text_frame_format_effective_data.margin_top))
	print("   اليمين:", str(text_frame_format_effective_data.margin_right))
	print("   الأسفل:", str(text_frame_format_effective_data.margin_bottom))
```

## **الحصول على خصائص نمط النص الفعّالة**

باستخدام Aspose.Slides للبايثون عبر .NET، يمكنك استرجاع الخصائص الفعّالة لنمط النص. الفئة [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) تحتوي على خصائص نمط النص الفعّالة.

المثال التالي يوضح كيفية الحصول على خصائص نمط النص الفعّالة:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= تنسيق الفقرة الفعّال للمستوى #{str(i)} =")

        print("العمق:", str(effectiveStyleLevel.depth))
        print("المسافة البادئة:", str(effectiveStyleLevel.indent))
        print("المحاذاة:", str(effectiveStyleLevel.alignment))
        print("محاذاة الخط:", str(effectiveStyleLevel.font_alignment))
```

## **الحصول على ارتفاع الخط الفعّال**

باستخدام Aspose.Slides للبايثون عبر .NET، يمكنك استرجاع ارتفاع الخط الفعّال. يُظهر المثال أدناه كيف يتغيّر ارتفاع الخط الفعّال لجزء النص عندما تقوم بتعيين قيم ارتفاع الخط المحلية على مستويات مختلفة في بنية العرض التقديمي.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)

    shape.add_text_frame("")
    paragraph = shape.text_frame.paragraphs[0]

    portion0 = slides.Portion("Sample text with first portion")
    portion1 = slides.Portion(" and second portion.")

    paragraph.portions.add(portion0)
    paragraph.portions.add(portion1)

    print("ارتفاع الخط الفعّال مباشرةً بعد الإنشاء:")
    print("الجزء #0:", portion0.portion_format.get_effective().font_height)
    print("الجزء #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("ارتفاع الخط الفعّال بعد تعيين ارتفاع الخط الافتراضي للعرض التقديمي بالكامل:")
    print("الجزء #0:", portion0.portion_format.get_effective().font_height)
    print("الجزء #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("ارتفاع الخط الفعّال بعد تعيين ارتفاع الخط الافتراضي للفقرة:")
    print("الجزء #0:", portion0.portion_format.get_effective().font_height)
    print("الجزء #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("ارتفاع الخط الفعّال بعد تعيين ارتفاع الخط للجزء #0:")
    print("الجزء #0:", portion0.portion_format.get_effective().font_height)
    print("الجزء #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("ارتفاع الخط الفعّال بعد تعيين ارتفاع الخط للجزء #1:")
    print("الجزء #0:", portion0.portion_format.get_effective().font_height)
    print("الجزء #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```

## **الحصول على تنسيق التعبئة الفعّال للجدول**

باستخدام Aspose.Slides للبايثون عبر .NET، يمكنك استرجاع تنسيق التعبئة الفعّال لأجزاء منطقية مختلفة في الجدول. الفئة [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) تحتوي على خصائص تنسيق التعبئة الفعّالة. لاحظ أن تنسيق الخلية له أولوية أعلى دائمًا من تنسيق الصف، والصف له أولوية أعلى من تنسيق العمود، والعمود له أولوية أعلى من الجدول بأكمله.

لذلك تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) في النهاية لرسم الجدول. يوضح المثال التالي كيفية الحصول على تنسيق التعبئة الفعّال لمستويات الجدول المختلفة:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	table = presentation.slides[0].shapes[0]

	table_format_effective = table.table_format.get_effective()
	row_format_effective = table.rows[0].row_format.get_effective()
	column_format_effective = table.columns[0].column_format.get_effective()
	cell_format_effective = table[0, 0].cell_format.get_effective()

	table_fill_format_effective = table_format_effective.fill_format
	row_fill_format_effective = row_format_effective.fill_format
	column_fill_format_effective = column_format_effective.fill_format
	cell_fill_format_effective = cell_format_effective.fill_format
```

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أنني حصلت على "لقطة" وليس على "كائن حي"، ومتى يجب علي قراءة الخصائص الفعّالة مرة أخرى؟**

كائنات EffectiveData هي لقطات غير قابلة للتغيير للقيم المحسوبة في وقت الاستدعاء. إذا قمت بتغيير الإعدادات المحلية أو الموروثة للشكل، احصل على البيانات الفعّالة مرة أخرى للحصول على القيم المحدثة.

**هل يؤثر تعديل الشريحة النموذجية/الرئيسية على الخصائص الفعّالة التي تم استرجاعها مسبقًا؟**

نعم، ولكن فقط بعد قراءتها مرة أخرى. كائن EffectiveData المسترجع مسبقًا لا يُحدّث نفسه—اطلبه مرة أخرى بعد تعديل النموذج أو الشريحة الرئيسية.

**هل يمكنني تعديل القيم عبر EffectiveData؟**

لا. EffectiveData للقراءة فقط. أجرِ التغييرات في كائنات التنسيق المحلية (الشكل/النص/3D، إلخ)، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم تُحدد خاصية على مستوى الشكل، ولا على مستوى النموذج/الرئيسية، ولا في الإعدادات العامة؟**

تُحدّد القيمة الفعّالة عبر الآلية الافتراضية (الافتراضات في PowerPoint/Aspose.Slides). تلك القيمة المحسوبة تُصبح جزءًا من لقطة EffectiveData.

**من قيمة الخط الفعّالة، هل يمكنني معرفة أي مستوى قدّم الحجم أو نوع الخط؟**

ليس مباشرة. EffectiveData تُعيد القيمة النهائية فقط. لتحديد المصدر، تحقق من القيم المحلية في الجزء/الفقرة/إطار النص والأنماط النصية في النموذج/الرئيسية/العرض التقديمي لترى أين ظهرت التعريف الأول.

**لماذا تبدو قيم EffectiveData أحيانًا متطابقة مع القيم المحلية؟**

لأن القيمة المحلية انتهت إلى كونها النهائية (لم يُطلب توريث من مستوى أعلى). في هذه الحالات، تكون القيمة الفعّالة مطابقة للقيمة المحلية.

**متى يجب استخدام الخصائص الفعّالة، ومتى أكتفي بالخصائص المحلية؟**

استخدم EffectiveData عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق كل الوراثة (مثلاً لتطابق الألوان أو الهوامش أو الأحجام). إذا كنت تريد تعديل التنسيق على مستوى معين، عدل الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.