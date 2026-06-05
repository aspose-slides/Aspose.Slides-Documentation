---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية باستخدام بايثون
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/python-net/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز الإضاءة
- شكل منحدر
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "اكتشف كيف تحسب وتطبق Aspose.Slides لبايثون عبر .NET الخصائص الفعّالة للشكل لتحقيق عرض PowerPoint دقيق."
---
## **نظرة عامة**

هذه المقالة توضح الفرق بين الخصائص **المحلية** و **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق معين، مثل:

1. خصائص الجزء على الشريحة.
1. أنماط نص الشكل النموذجي على تخطيط أو شريحة رئيسية، عندما يكون لدى شكل إطار النص للجزء واحد.
1. إعدادات النص العالمية في العرض التقديمي.

يمكن تعريف القيم المحلية أو حذفها في أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما يتم عرضه"، فهي تحل سلسلة الوراثة وتُرجِع القيم **الفعّالة**. يمكنك الحصول عليها عبر استدعاء الطريقة `get_effective` على كائن التنسيق المحلي.

يعرض المثال التالي كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) يحتوي على إطار نص وعلى الأقل جزء واحد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
تمثل بيانات التنسيق الفعّالية التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالية، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iportionformateffectivedata/)، داخلياً. استدعاء `get_effective` مرة أخرى بعد تغيير التنسيق الأب أو الموروث يمكن أن ينعش البيانات المخزنة مؤقتاً، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقاً الحالة السابقة. إذا كنت بحاجة إلى الاحتفاظ بالقيم الفعّالية لإعادة استخدامها لاحقاً، فانسخ الخصائص المطلوبة مثل ارتفاع الخط، لون التعبئة، نمط الخط أو المحاذاة إلى كائن بيانات خاص بك.
{{% /alert %}}

## **الحصول على خصائص الكاميرا الفعّالة**

تسمح لك Aspose.Slides بالحصول على خصائص الكاميرا الفعّالة. النوع [ICameraEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/icameraeffectivedata/) يمثل كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعّالة. يتم الكشف عن مثيل [ICameraEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/icameraeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/).

يعرض المقتطف البرمجي التالي كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **الحصول على خصائص جهاز الإضاءة الفعّال**

تسمح لك Aspose.Slides بالحصول على خصائص جهاز الإضاءة الفعّال. النوع [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ilightrigeffectivedata/) يمثل كائنًا غير قابل للتغيير يحتوي على خصائص جهاز الإضاءة الفعّالة. يتم الكشف عن مثيل [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ilightrigeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/).

يعرض المقتطف البرمجي التالي كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **الحصول على خصائص السطح المنحدر (Bevel) الفعّالة**

تسمح لك Aspose.Slides بالحصول على خصائص السطح المنحدر (Bevel) الفعّالية للشكل. النوع [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapebeveleffectivedata/) يمثل كائنًا غير قابل للتغيير يحتوي على خصائص الانخفاض الوجهية الفعّالة للشكل. يتم الكشف عن مثيل [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapebeveleffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/).

يعرض المقتطف البرمجي التالي كيفية الحصول على الخصائص الفعّالة للسطح المنحدر العلوي للشكل. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **الحصول على خصائص إطار النص الفعّالة**

باستخدام Aspose.Slides، يمكنك الحصول على خصائص إطار النص الفعّالية. النوع [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/itextframeformateffectivedata/) يحتوي على خصائص تنسيق إطار النص الفعّالي.

يعرض المقتطف البرمجي التالي كيفية الحصول على خصائص تنسيق إطار النص الفعّالية. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) يحتوي على إطار نص.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **الحصول على خصائص نمط النص الفعّالة**

باستخدام Aspose.Slides، يمكنك الحصول على خصائص نمط النص الفعّالية. النوع [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/itextstyleeffectivedata/) يحتوي على خصائص نمط النص الفعّالية.

يعرض المقتطف البرمجي التالي كيفية الحصول على خصائص نمط النص الفعّالية. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) يحتوي على إطار نص.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **الحصول على قيمة ارتفاع الخط الفعّال**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الكود التالي كيف يتغير ارتفاع الخط الفعّال للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات بنية العرض التقديمي المختلفة.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على تنسيق التعبئة الفعّال لجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء الجدول المختلفة. النوع [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ifillformateffectivedata/) يحتوي على خصائص تنسيق التعبئة الفعّالية. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

وبالتالي يتم استخدام خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يعرض المقتطف البرمجي التالي كيفية الحصول على تنسيق التعبئة الفعّال لأجزاء الجدول المختلفة. يفترض أن الشكل الأول في الشريحة الأولى هو [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **الأسئلة الشائعة**

**هل تُعيد `get_effective` لقطة ثابتة؟**

ليس دائماً. تمثل البيانات الفعّالية التنسيق المحسوب بعد تطبيق الوراثة، لكن قد يتم تخزين بعض كائنات البيانات الفعّالية داخلياً. قد يعيد استدعاء `get_effective` لاحقاً حساب التنسيق وإنعاش البيانات المخزنة مؤقتاً، لذا لا ينبغي اعتبار الكائن المسترجع مسبقاً صورة ثابتة مستقرة.

**متى يجب قراءة الخصائص الفعّالة مرة أخرى؟**

استدعِ `get_effective` مرة أخرى بعد تغيير التنسيق المحلي، أو أنماط الأب، أو تنسيق التخطيط، أو تنسيق الرئيسي، أو الإعدادات الافتراضية على مستوى العرض التقديمي. سيعيد الاستدعاء التالي تقييم شجرة التنسيق ويُرجِع النتيجة الفعّالية الحالية.

**هل يؤثر تعديل أو إزالة شريحة تخطيط/رئيسية على الخصائص الفعّالة التي تم استرجاعها مسبقاً؟**

نعم، لكن التغيّر يُظهر نفسه في استدعاء `get_effective` التالي. إذا تغير مصدر تنسيق أب أو أُزيل، قد تصبح البيانات الفعّالية المستخرجة مسبقاً قديمة. بمجرد استدعاء `get_effective` مرة أخرى، تقوم Aspose.Slides بإعادة تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى.

**هل يمكنني تعديل القيم عبر كائنات البيانات الفعّالية؟**

لا. تُظهر كائنات البيانات الفعّالية القيم المحسوبة فقط. يجب إجراء التغييرات في كائنات التنسيق المحلي، ثم الحصول على القيم الفعّالية مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل ولا في التخطيط/الرئيسية ولا في الإعدادات العالمية؟**

يُحدد القيمة الفعّالية بواسطة آلية القيم الافتراضية، والتي تشمل القيم الافتراضية لـ PowerPoint وAspose.Slides. تصبح القيمة المُحلَّلة جزءاً من البيانات الفعّالية الحالية.

**من قيمة الخط الفعّالية، هل يمكنني معرفة المستوى الذي قدم الحجم أو نوع الخط؟**

ليس مباشرة. تُعيد البيانات الفعّالية القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية في الجزء، الفقرة، إطار النص، وأنماط النص على مستويات التخطيط، والرئيسية، والعرض التقديمي لتحديد أول تعريف صريح.

**لماذا تبدو القيم الفعّالية أحياناً مطابقة للقيم المحلية؟**

لأن القيمة المحلية أصبحت هي النهائية (لم يُستدعَ مستوى أعلى للوراثة). في هذه الحالة تتطابق القيمة الفعّالية مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالية ومتى أكتفي بالخصائص المحلية؟**

استخدم البيانات الفعّالية عندما تحتاج إلى النتيجة "كما يتم عرضها" بعد تطبيق جميع وراثات التنسيق، مثل محاذاة الألوان أو الهوامش أو الأحجام. إذا رغبت في حفظ تلك القيم بغض النظر عن تغييرات التنسيق المستقبلية، انسخ الخصائص المطلوبة إلى كائن خاص بك. إذا كنت تحتاج إلى تعديل التنسيق على مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالية مرة أخرى للتحقق من النتيجة.