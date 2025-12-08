---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية باستخدام Python
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/python-net/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام إضاءة
- شكل القطع
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "اكتشف كيف تحسب Aspose.Slides for Python عبر .NET وتطبق الخصائص الفعّالة للأشكال لتحقيق عرض دقيق في PowerPoint وOpenDocument."
---

## **نظرة عامة**

في هذا الموضوع، ستتعلم مفاهيم الخصائص **الفعّالة** و **المحلية**. عندما يتم تعيين القيم مباشرةً على المستويات التالية:

1. في خصائص جزء النص على الشريحة.
2. في نمط نص الشكل النموذجي على الشريحة النموذجية أو الشريحة الرئيسية (إذا كان لإطار النص واحدًا).
3. في إعدادات النص العالمية للعرض التقديمي.

تُسمى تلك القيم **قيمة محلية**. في أي مستوى، يمكن تعريف **القيم المحلية** أو حذفها. عندما تحتاج التطبيق إلى تحديد كيفية ظهور جزء النص، يستخدم القيم **الفعّالة**. يمكنك الحصول على القيم الفعّالة باستدعاء الطريقة `get_effective` على التنسيق المحلي.

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

تتيح لك Aspose.Slides for Python via .NET استرجاع خصائص الكاميرا الفعّالة. تمثل الفئة [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتغيير يحتوي على هذه الخصائص. يتم توفير نسخة من [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)، التي تقدم القيم الفعّالة لفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

المثال التالي يوضح كيفية الحصول على خصائص الكاميرا الفعّالة:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective camera properties =")
	print("Type:", str(three_d_effective_data.camera.camera_type))
	print("Field of view:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```


## **الحصول على خصائص إضاءة الضوء الفعّالة**

تتيح لك Aspose.Slides for Python via .NET استرجاع الخصائص الفعّالة لمدى الإضاءة. تمثل الفئة [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتغيير يحتوي على هذه الخصائص. يتم توفير نسخة من [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)، التي تقدم القيم الفعّالة لفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

المثال التالي يوضح كيفية الحصول على خصائص إضاءة الضوء الفعّالة:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```


## **الحصول على خصائص القطع الشكلية الفعّالة**

تتيح لك Aspose.Slides for Python via .NET استرجاع الخصائص الفعّالة للقطع الشكلية. تمثل الفئة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص القطع (الانحدار) للوجه. يتم توفير نسخة من [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)، التي تقدم القيم الفعّالة لفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

المثال التالي يوضح كيفية الحصول على الخصائص الفعّالة للقطع الشكلية:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective shape's top face relief properties =")
	print("Type:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Width:", str(three_d_effective_data.bevel_top.width))
	print("Height:", str(three_d_effective_data.bevel_top.height))
```


## **الحصول على خصائص إطار النص الفعّالة**

باستخدام Aspose.Slides for Python via .NET، يمكنك استرجاع الخصائص الفعّالة لإطار النص. تحتوي الفئة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) على خصائص تنسيق إطار النص الفعّالة.

المثال التالي يوضح كيفية الحصول على خصائص تنسيق إطار النص الفعّلة:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Anchoring type:", str(text_frame_format_effective_data.anchoring_type))
	print("Autofit type:", str(text_frame_format_effective_data.autofit_type))
	print("Text vertical type:", str(text_frame_format_effective_data.text_vertical_type))
	print("Margins")
	print("   Left:", str(text_frame_format_effective_data.margin_left))
	print("   Top:", str(text_frame_format_effective_data.margin_top))
	print("   Right:", str(text_frame_format_effective_data.margin_right))
	print("   Bottom:", str(text_frame_format_effective_data.margin_bottom))
```


## **الحصول على خصائص نمط النص الفعّالة**

باستخدام Aspose.Slides for Python via .NET، يمكنك استرجاع الخصائص الفعّالة لنمط النص. تحتوي الفئة [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) على خصائص نمط النص الفعّالة.

المثال التالي يوضح كيفية الحصول على خصائص نمط النص الفعّالة:
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Effective paragraph formatting for style level #{str(i)} =")

        print("Depth:", str(effectiveStyleLevel.depth))
        print("Indent:", str(effectiveStyleLevel.indent))
        print("Alignment:", str(effectiveStyleLevel.alignment))
        print("Font alignment:", str(effectiveStyleLevel.font_alignment))
```


## **الحصول على ارتفاع الخط الفعّال**

باستخدام Aspose.Slides for Python via .NET، يمكنك استرجاع ارتفاع الخط الفعّال. يوضح المثال أدناه كيف يتغيّر ارتفاع الخط الفعّال لجزء النص عندما تُعيّن قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي.
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

    print("Effective font height just after creation:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Effective font height after setting entire presentation default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **الحصول على تنسيق تعبئة الجدول الفعّال**

باستخدام Aspose.Slides for Python via .NET، يمكنك استرجاع تنسيق التعبئة الفعّال لأجزاء منطقية مختلفة من الجدول. تحتوي الفئة [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) على خصائص تنسيق التعبئة الفعّالة. لاحظ أن تنسيق الخلية له أولوية أعلى دائمًا من تنسيق الصف، والصف له أولوية أعلى من العمود، والعمود له أولوية أعلى من الجدول بأكمله.

لذلك تُستخدم في النهاية خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) لرسم الجدول. يوضح المثال التالي كيفية الحصول على تنسيق التعبئة الفعّال للمستويات المختلفة للجدول:
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


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أنني حصلت على «لقطة» بدلاً من «كائن حي»، ومتى ينبغي علي قراءة الخصائص الفعّالة مرة أخرى؟**

كائنات EffectiveData هي لقطات غير قابلة للتغيير للقيم المحسوبة في وقت الاستدعاء. إذا غيرت الإعدادات المحلية أو الموروثة للشكل، استرجع البيانات الفعّالة مرة أخرى للحصول على القيم المحدثة.

**هل يؤثر تغيير الشريحة النموذجية/الرئيسية على الخصائص الفعّالة التي تم استرجاعها بالفعل؟**

نعم، لكن فقط بعد أن تقرأها مرة أخرى. كائن EffectiveData الذي تم الحصول عليه لا يُحدّث نفسه—اطلبه مرة أخرى بعد تغيير النموذج أو الشريحة الرئيسية.

**هل يمكنني تعديل القيم عبر EffectiveData؟**

لا. EffectiveData للقراءة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلي (الشكل/النص/3D، إلخ)، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا على مستوى النموذج/الرئيسية، ولا في الإعدادات العالمية؟**

تُحدّد القيمة الفعّالة عبر آلية الافتراض (الافتراضات الخاصة بـ PowerPoint/Aspose.Slides). تصبح تلك القيمة المحلولة جزءًا من لقطة EffectiveData.

**من قيمة الخط الفعّالة، هل يمكنني معرفة أي مستوى قدم الحجم أو الخط؟**

ليس مباشرة. تُعيد EffectiveData القيمة النهائية. لتحديد المصدر، افحص القيم المحلية على الجزء/الفقرة/إطار النص وأنماط النص على النموذج/الرئيسية/العرض التقديمي لتعرف أين تظهر أول تعريف صريح.

**لماذا تبدو قيم EffectiveData أحيانًا مماثلة للقيم المحلية؟**

لأن القيمة المحلية انتهت لتكون النهائية (لم تكن هناك حاجة إلى وراثة من مستوى أعلى). في هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالة، ومتى يجب العمل فقط بالقيم المحلية؟**

استخدم EffectiveData عندما تحتاج إلى النتيجة «كما تم عرضها» بعد تطبيق جميع الوراثات (مثلاً لتوافق الألوان، المسافات البادئة، أو الأحجام). إذا أردت تعديل التنسيق على مستوى محدد، غيّر الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.