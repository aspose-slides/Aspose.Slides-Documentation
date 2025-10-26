---
title: الحصول على الخصائص الفعّالة للأشكال من العروض التقديمية باستخدام بايثون
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- إضاءة ثلاثية الأبعاد
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides for Python عبر .NET بحساب وتطبيق الخصائص الفعّالة للأشكال لضمان عرض دقيق في PowerPoint وOpenDocument."
---

## **نظرة عامة**

في هذا الموضوع، ستتعلم مفهومي **الخصائص الفعّالة** و**الخصائص المحلية**. عندما يتم تعيين القيم مباشرةً على المستويات التالية:

1. في خصائص جزء النص على الشريحة.
2. في نمط النص للشكل النموذجي على تخطيط أو شريحة رئيسية (إذا كان لإطار النص واحد).
3. في إعدادات النص العامة للعرض التقديمي.

تُسمى تلك القيم **قِيَم محلية**. في أي مستوى، قد تُعرّف القيم **المحلية** أو تُترك غير مُعرّفة. عندما يحتاج التطبيق إلى تحديد كيفية ظهور جزء النص، يستخدم القيم **الفعّالة**. يمكنك الحصول على القيم الفعّالة عن طريق استدعاء طريقة `get_effective` على التنسيق المحلي.

يعرض المثال التالي كيفية الحصول على القيم الفعّالة لتنسيق إطار النص وتنسيق جزء النص.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **الحصول على الخصائص الفعّالة للكاميرا**

تتيح لك Aspose.Slides for Python عبر .NET استرداد الخصائص الفعّالة للكاميرا. تمثل الفئة [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتغيير يحتوي على هذه الخصائص. يتم كشف مثيل من [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

يعرض المثال التالي كيفية الحصول على الخصائص الفعّالة للكاميرا:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= الخصائص الفعّالة للكاميرا =")
	print("النوع:", str(three_d_effective_data.camera.camera_type))
	print("زاوية مجال الرؤية:", str(three_d_effective_data.camera.field_of_view_angle))
	print("التكبير:", str(three_d_effective_data.camera.zoom))
```

## **الحصول على الخصائص الفعّالة لإضاءة المشهد**

تتيح لك Aspose.Slides for Python عبر .NET استرداد الخصائص الفعّالة لتجهيز إضاءة المشهد. تمثل الفئة [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتغيير يحتوي على هذه الخصائص. يتم كشف مثيل من [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

يعرض المثال التالي كيفية الحصول على الخصائص الفعّالة لإضاءة المشهد:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= الخصائص الفعّالة لإضاءة المشهد =")
	print("النوع:", str(three_d_effective_data.light_rig.light_type))
	print("الاتجاه:", str(three_d_effective_data.light_rig.direction))
```

## **الحصول على الخصائص الفعّالة لحافة الشكل**

تتيح لك Aspose.Slides for Python عبر .NET استرداد الخصائص الفعّالة لحافة الشكل. تمثل الفئة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص الوجه (الحافة) للشكل. يتم كشف مثيل من [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لفئة [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

يعرض المثال التالي كيفية الحصول على الخصائص الفعّالة لحافة الشكل:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= الخصائص الفعّالة لوجه الحافة العلوي للشكل =")
	print("النوع:", str(three_d_effective_data.bevel_top.bevel_type))
	print("العرض:", str(three_d_effective_data.bevel_top.width))
	print("الارتفاع:", str(three_d_effective_data.bevel_top.height))
```

## **الحصول على الخصائص الفعّالة لإطار النص**

باستخدام Aspose.Slides for Python عبر .NET، يمكنك استرداد الخصائص الفعّالة لإطار النص. تحتوي الفئة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) على الخصائص الفعّالية لتنسيق إطار النص.

يعرض المثال التالي كيفية الحصول على الخصائص الفعّالية لتنسيق إطار النص:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("نوع التثبيت:", str(text_frame_format_effective_data.anchoring_type))
	print("نوع الملاءمة التلقائية:", str(text_frame_format_effective_data.autofit_type))
	print("نوع النص الرأسي:", str(text_frame_format_effective_data.text_vertical_type))
	print("الهوامش")
	print("   اليسار:", str(text_frame_format_effective_data.margin_left))
	print("   الأعلى:", str(text_frame_format_effective_data.margin_top))
	print("   اليمين:", str(text_frame_format_effective_data.margin_right))
	print("   الأسفل:", str(text_frame_format_effective_data.margin_bottom))
```

## **الحصول على الخصائص الفعّالة لنمط النص**

باستخدام Aspose.Slides for Python عبر .NET، يمكنك استرداد الخصائص الفعّالة لنمط النص. تحتوي الفئة [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) على خصائص نمط النص الفعّالية.

يعرض المثال التالي كيفية الحصول على الخصائص الفعّالية لنمط النص:

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

باستخدام Aspose.Slides for Python عبر .NET، يمكنك استرداد ارتفاع الخط الفعّال. يوضح المثال أدناه كيف يتغيّر ارتفاع الخط الفعّال لجزء النص عندما تقوم بتعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من هيكل العرض التقديمي.

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

## **الحصول على تنسيق تعبئة الجدول الفعّال**

باستخدام Aspose.Slides for Python عبر .NET، يمكنك استرداد تنسيق التعبئة الفعّال لأجزاء منطقية مختلفة من الجدول. تحتوي الفئة [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) على خصائص تنسيق التعبئة الفعّالية. لاحظ أن تنسيق الخلية دائمًا له أولوية أعلى من تنسيق الصف، والصف له أولوية أعلى من العمود، والعمود له أولوية أعلى من كامل الجدول.

وبالتالي تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) في النهاية لرسم الجدول. يعرض المثال التالي كيفية الحصول على تنسيق التعبئة الفعّال للمستويات المختلفة للجدول:

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

**كيف يمكنني معرفة أنني حصلت على "لقطة" بدلاً من "كائن حي"، ومتى يجب أن أقرأ الخصائص الفعّالة مرة أخرى؟**

كائنات EffectiveData هي لقطات ثابتة للقيم المحسوبة وقت الاستدعاء. إذا قمت بتغيير الإعدادات المحلية أو الموروثة للشكل، استرجع البيانات الفعّالة مرة أخرى للحصول على القيم المحدثة.

**هل يؤثر تغيير الشريحة التخطيطية/الرئيسية على الخصائص الفعّالة التي تم استردادها بالفعل؟**

نعم، ولكن فقط بعد قراءتها مرة أخرى. كائن EffectiveData المسترجع مسبقًا لا يُحدّث نفسه—اطلبه مرة أخرى بعد تغيير التخطيط أو الشريحة الرئيسية.

**هل يمكن تعديل القيم عبر EffectiveData؟**

لا. EffectiveData للقراءة فقط. أجرِ التغييرات في كائنات التنسيق المحلي (الشكل/النص/3D، إلخ)، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل ولا في التخطيط/الرئيسية ولا في الإعدادات العامة؟**

يتم تحديد القيمة الفعّالة عبر الآلية الافتراضية (قواعد PowerPoint/أو Aspose.Slides الافتراضية). تلك القيمة المحسومة تصبح جزءًا من لقطة EffectiveData.

**من قيمة الخط الفعّالة، هل يمكنني معرفة أي مستوى قدّم الحجم أو نوع الخط؟**

ليس مباشرة. تُعيد EffectiveData القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية على الجزء/الفقرة/إطار النص ومن أنماط النص في التخطيط/الرئيسية/العرض التقديمي لمعرفة أين ظهرت التعريف الأول صراحةً.

**لماذا تبدو قيم EffectiveData أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية كانت النهائية (لم يتطلب الأمر وراثة من مستوى أعلى). في هذه الحالات تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالة، ومتى أكتفي بالخصائص المحلية؟**

استخدم EffectiveData عندما تحتاج إلى النتيجة "كما تُظهر" بعد تطبيق جميع وراثات التنسيق (مثلاً لمزامنة الألوان أو الهوامش أو الأحجام). إذا كنت بحاجة لتغيير التنسيق في مستوى محدد، عدّل الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.