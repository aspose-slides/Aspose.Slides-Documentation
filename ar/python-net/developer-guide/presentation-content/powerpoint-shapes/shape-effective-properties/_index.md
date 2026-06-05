---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية باستخدام Python
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/python-net/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام الإضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيف يحسب Aspose.Slides للـ Python عبر .NET ويطبق خصائص الشكل الفعّالة لتقديم عروض PowerPoint بدقة."
---
## **نظرة عامة**

تشرح هذه المقالة الفرق بين الخصائص **المحلية** و **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً في مستوى تنسيق معين، مثل:

1. خصائص الجزء على الشريحة.
1. أنماط نص الشكل النموذجية على تخطيط أو شريحة رئيسية، عندما يحتوي شكل إطار نص الجزء على واحدة.
1. إعدادات النص العامة في العرض التقديمي.

يمكن تعريف القيم المحلية أو حذفها في أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما يُعرض"، فإنها تحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها عن طريق استدعاء الطريقة `get_effective` على كائن التنسيق المحلي.

يوضح المثال التالي كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مع إطار نص وعلى الأقل جزء واحد.

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
تمثل بيانات التنسيق الفعّال التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة مؤقتًا داخليًا، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iportionformateffectivedata/). قد يؤدي استدعاء `get_effective` مرة أخرى بعد تغيير التنسيق الأصلي أو الموروث إلى تحديث البيانات المؤقتة، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى الاحتفاظ بالقيم الفعّالة لاستخدامها لاحقًا، انسخ الخصائص المطلوبة مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة للكاميرا. النوع [ICameraEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/icameraeffectivedata/) يمثل كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعّالة. يتم كشف مثيل [ICameraEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/icameraeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/).

يوضح عينة الشفرة التالية كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لجهاز الإضاءة**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لجهاز الإضاءة. النوع [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ilightrigeffectivedata/) يمثل كائنًا غير قابل للتغيير يحتوي على خصائص جهاز الإضاءة الفعّالة. يتم كشف مثيل [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ilightrigeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/).

يوضح عينة الشفرة التالية كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لحافة الشكل**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لحافة الشكل. النوع [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapebeveleffectivedata/) يمثل كائنًا غير قابل للتغيير يحتوي على خصائص الحافة الفعّالة للوجه لشكلٍ ما. يتم كشف مثيل [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapebeveleffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/).

يوضح عينة الشفرة التالية كيفية الحصول على الخصائص الفعّالة للحافة العلوية لشكلٍ ما. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. النوع [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/itextframeformateffectivedata/) يحتوي على خصائص تنسيق إطار النص الفعّالة.

يوضح عينة الشفرة التالية كيفية الحصول على خصائص تنسيق إطار النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مع إطار نص.

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

## **الحصول على الخصائص الفعّالة لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. النوع [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/itextstyleeffectivedata/) يحتوي على خصائص نمط النص الفعّالة.

يوضح عينة الشفرة التالية كيفية الحصول على خصائص نمط النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) مع إطار نص.

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

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الشيفرة التالية كيفية تغير ارتفاع الخط الفعّال لجزء بعد تعيين قيم ارتفاع الخط المحلي على مستويات مختلفة من بنية العرض التقديمي.

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

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. النوع [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ifillformateffectivedata/) يحتوي على خصائص تنسيق التعبئة الفعّالة. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنظيم الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

وبالتالي، تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يوضح عينة الشفرة التالية كيفية الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/).

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

**هل تُعيد `get_effective` لقطةً؟**

ليس دائماً. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، لكن قد يتم تخزين بعض كائنات البيانات الفعّالة مؤقتًا داخليًا. قد يعيد استدعاء `get_effective` لاحقًا حساب التنسيق وتحديث البيانات المخزنة، لذا لا يجب اعتبار الكائن الذي تم الحصول عليه مسبقًا كنسخة ثابتة.

**متى يجب قراءة الخصائص الفعّالة مرة أخرى؟**

استدعِ `get_effective` مرة أخرى بعد تغيير التنسيق المحلي أو أنماط الوالد، أو تنسيق التخطيط، أو تنسيق الرئيس، أو الإعدادات الافتراضية على مستوى العرض التقديمي. سيعيد الاستدعاء التالي تقييم شجرة التنسيق ويعيد النتيجة الفعّالة الحالية.

**هل يؤثر تعديل أو إزالة شريحة تخطيط/رئيسية على الخصائص الفعّالة التي تم استرجاعها مسبقًا؟**

نعم، لكن التغيير يظهر في الاستدعاء التالي لـ `get_effective`. إذا تم تعديل أو إزالة مصدر تنسيق الوالد، قد تصبح البيانات الفعّالة المسترجعة سابقًا قديمة. بمجرد استدعاء `get_effective` مرة أخرى، تعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى الناتجة.

**هل يمكن تعديل القيم عبر كائنات البيانات الفعّالة؟**

لا. كائنات البيانات الفعّالة تعرض القيم المحسوبة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلي، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل ولا في التخطيط/الرئيس ولا في الإعدادات العامة؟**

يُحدد القيمة الفعّالة عبر الآلية الافتراضية، والتي تشمل الإعدادات الافتراضية لـ PowerPoint وAspose.Slides. تصبح القيمة التي تم حلها جزءًا من البيانات الفعّالة الحالية.

**من قيمة الخط الفعّالية، هل يمكنني معرفة المستوى الذي قدم الحجم أو نوع الخط؟**

ليس مباشرة. تُعيد البيانات الفعّالة القيمة النهائية. لتحديد المصدر، افحص القيم المحلية في الجزء، الفقرة، إطار النص، وأنماط النص على مستويات التخطيط، الرئيس، والعرض التقديمي لترى أين تظهر التعريف الصريح الأول.

**لماذا تبدو القيم الفعّالة أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية انتهت لتكون النهائية (لم يكن هناك حاجة للوراثة من مستوى أعلى). في مثل هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالة، ومتى أكتفي بالخصائص المحلية؟**

استخدم البيانات الفعّالة عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق جميع وراثات التنسيق، مثل مطابقة الألوان أو الهوامش أو الأحجام. إذا كنت تحتاج إلى الاحتفاظ بهذه القيم بغض النظر عن تغييرات التنسيق المستقبلية، انسخ الخصائص المطلوبة إلى كائنك الخاص. إذا كنت تحتاج إلى تعديل التنسيق على مستوى محدد، عدل الخصائص المحلية ثم، إذا لزم الأمر، اقرِئ البيانات الفعّالة مرة أخرى للتحقق من النتيجة.