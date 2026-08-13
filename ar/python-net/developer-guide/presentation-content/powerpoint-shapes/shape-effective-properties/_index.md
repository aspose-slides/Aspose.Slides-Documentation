---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية باستخدام بايثون
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/python-net/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام الإضاءة
- شكل مشطوف
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية استخدام Aspose.Slides للبايثون عبر .NET لتمييز تنسيق الشكل المحلي والوراثي والفعّال في عروض PowerPoint التقديمية."
---
## **فهم الخصائص المحلية والوراثية والفعّالة**

يمكن أن يأتي تنسيق PowerPoint من عدة أماكن. القيمة المخزنة مباشرةً على الكائن هي **local value**. إذا لم يتم تعيين هذه القيمة، يراجع PowerPoint مصادر التنسيق الأم، مثل الإعداد الافتراضي للفقرة، نمط النص، تخطيط أو شريحة رئيسية، موضوع، أو الإعدادات الافتراضية على مستوى العرض. تلك القيم هي **inherited values**. القيمة التي تبقى بعد حل كامل التسلسل الهرمي هي **effective value**، والتي تُستخدم لتصريف الكائن.

على سبيل المثال، قد لا تحدد جزء النص ارتفاع الخط الخاص به. فإن قيمة **local** الخاصة به في [font_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ibaseportionformat/font_height/) تكون `float("nan")`، مما يعني "غير محدد هنا". يمكن للجزء أن يرث الارتفاع من الفقرة الخاصة به، أو نمط النص الافتراضي للعرض، أو مصدر آخر قابل للتطبيق. استدعاء [get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iportionformat/get_effective/) على تنسيق الجزء يُعيد الارتفاع النهائي المحلول.

استخدم نوعي بيانات التنسيق لأغراض مختلفة:

- قراءة أو تغيير كائن تنسيق محلي، مثل [IPortionFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iportionformat/)، عندما تحتاج إلى التحكم في مكان تعريف القيمة.
- قراءة كائن بيانات فعّالة، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iportionformateffectivedata/)، عندما تحتاج إلى النتيجة النهائية المُعرضة. البيانات الفعّالة للقراءة فقط.

## **قارن القيم المحلية والوراثية والفعّالة**

المثال الكامل التالي ينشئ شكلاً ويطبق ارتفاعات الخط على مستويات العرض، الفقرة، والجزء. كل خطوة تُطبع القيم المعرفة على تلك المستويات والقيمة الفعّالة الناتجة لنفس جزء النص. كما يوضح لماذا يجب قراءة البيانات الفعّالة مرة أخرى بعد تغييرات التنسيق.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # قراءة البيانات الفعّالة بعد التغييرات السابقة.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # تعريف القيم الوراثية على مستويين مختلفين.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # قيمة محلية على الجزء تتجاوز كلا القيمتين الوراثيتين.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # تغيير قيمة وراثية لا يتجاوز قيمة محلية موجودة.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # مسح القيمة المحلية. الآن الجزء يرث من الفقرة مرة أخرى.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # مسح قيمة الفقرة. الآن الإعداد الافتراضي للعرض يوفر النتيجة.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

الأولوية في هذا المثال هي تنسيق الجزء المحلي، ثم تنسيق الفقرة، ثم الإعداد الافتراضي للعرض. يمكن للكائنات الأخرى أن تكون لها سلاسل وراثة مختلفة، لكن المبدأ هو نفسه: القيمة الصريحة الأكثر تحديدًا تفوز، و[get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iportionformat/get_effective/) يُعيد النتيجة النهائية.

## **الحصول على خصائص النص الفعّالة**

تنسيق النص مقسم عبر عدة كائنات:

- يَحلّ [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/ar/python-net/aspose.slides/itextframeformat/get_effective/) خصائص إطار النص مثل الهوامش، التثبيت، الضبط التلقائي، واتجاه النص العمودي.
- يَحلّ [ITextStyle.get_effective()](https://reference.aspose.com/slides/ar/python-net/aspose.slides/itextstyle/get_effective/) تنسيق الفقرة لكل مستوى من أنماط النص.
- يَحلّ [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iparagraphformat/get_effective/) خصائص الفقرة مثل المحاذاة، الإزاحة، والنقاط.
- يَحلّ [IPortionFormat.get_effective()](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iportionformat/get_effective/) خصائص الحرف مثل ارتفاع الخط، نوع الخط، اللون، الغامق، والمائل.

في المثال التالي، يجب أن يحتوي `text-formatting.pptx` على شريحة واحدة على الأقل وعلى [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) واحد بإطار نص غير فارغ. يمكن أن يظهر AutoShape في أي موضع داخل مجموعة الأشكال؛ يبحث الكود عن كائن مناسب ويُتحقق منه قبل الاستخدام.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **الحصول على خصائص 3D الفعّالة**

يُعيد [IThreeDFormat.get_effective()](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformat/get_effective/) كائنًا واحدًا من نوع [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/) يجمع جميع إعدادات 3D المحلولة. تُظهر خصائصه [camera](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/camera/)، [light_rig](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/light_rig/)، [bevel_top](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/)، و[bevel_bottom](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) البيانات الفعّالة المقابلة. قراءة هذه الإعدادات ذات الصلة معًا يُسهّل فهم المظهر النهائي ثلاثي الأبعاد للشكل.

في هذا المثال، يجب أن يحتوي `shape-3d.pptx` على شكل واحد على الأقل في شريحته الأولى. طبق إعدادات كاميرا 3D أو الإضاءة أو الحواف على ذلك الشكل إذا رغبت في أن تحتوي النتيجة على قيم غير القيم الافتراضية.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **الحصول على تنسيق الجدول الفعّال**

يمكن أن يأتي تنسيق الجدول من نمط الجدول ومن التنسيقات المطبقة على الجدول بأكمله، أو عمود، أو صف، أو خلية فردية. في حالة التعارض بين التعبئات المعرفة صراحةً، تكون الأولوية للخلية، ثم الصف، ثم العمود، ثم الجدول بأكمله. التنسيق الفعّال للخلية هو التنسيق النهائي المستخدم لرسم تلك الخلية.

في هذا المثال، يجب أن يحتوي `table-formatting.pptx` على جدول واحد على الأقل في الشريحة الأولى. يجب أن يحتوي الجدول على صف واحد على الأقل وعمود واحد على الأقل. يبحث الكود عن [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/) بدلاً من افتراض أن `shapes[0]` هو جدول.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

إذا كنت بحاجة إلى اللون بدلاً من نوع التعبئة فقط، فابدأ بالتحقق من [fill_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ifillformateffectivedata/fill_type/) الفعّال، ثم اقرأ الخاصية التي تنطبق على ذلك النوع، على سبيل المثال، [solid_fill_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) للتعبئة الصلبة.

## **إعادة قراءة البيانات الفعّالة بعد التغييرات**

تصف البيانات الفعّالة تسلسل تنسيق الهرمي في الوقت الذي يتم فيه حله. استدعِ `get_effective` مرة أخرى بعد تعديل أي شيء يمكن أن يشارك في هذا الهرم، بما في ذلك:

- تنسيق الكائن المحلي؛
- الإعدادات الافتراضية للفقرة أو إطار النص؛
- نمط جدول، جدول، عمود، صف، أو تنسيق خلية؛
- تنسيق التخطيط أو الشريحة الرئيسية؛
- بيانات الموضوع أو الإعدادات الافتراضية على مستوى العرض؛
- التخطيط أو الشريحة الرئيسية المعينة إلى الشريحة.

لا تحتفظ بكائن بيانات فعّالة كلقطة دائمة. قد يقوم Aspose.Slides بتخزين بعض البيانات الفعّالة مؤقتًا داخليًا، ويمكن لاستدعاء `get_effective` لاحقًا تجديد تلك البيانات. إذا كنت بحاجة إلى مقارنة القيم قبل وبعد التغيير، انسخ القيم العددية التي تحتاجها، مثل ارتفاع الخط، اللون، المحاذاة، أو عرض الحافة، إلى متغيراتك الخاصة قبل إجراء التغيير.

لتغيير قيمة، حدّث كائن التنسيق المحلي المناسب ثم استدعِ `get_effective` للتحقق من النتيجة. كائنات البيانات الفعّالة نفسها للقراءة فقط.

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أي مستوى وفر قيمة فعّالة؟**

تحتوي البيانات الفعّالة على القيمة النهائية، لا مصدرها. افحص الكائنات المحلية المعنية بدءًا من المستوى الأكثر تحديدًا إلى الخارج. بالنسبة للنص، قد يشمل ذلك الجزء، الفقرة، إطار النص، التخطيط، الشريحة الرئيسية، الموضوع، والإعدادات الافتراضية للعرض. القيم غير المعرفة مثل `float("nan")` أو `None` تشير إلى أن البحث يستمر إلى مستوى آخر.

**ماذا يحدث عندما لا يحدد أي مستوى خاصية؟**

يقوم Aspose.Slides بحل الإعداد الافتراضي المناسب لـ PowerPoint أو للمكتبة. تظهر تلك القيمة المحلولة في البيانات الفعّالة على الرغم من عدم تعريف أي كائن محلي لها صراحةً.

**لماذا قد تكون القيمة الفعّالة مساوية أحيانًا للقيمة المحلية؟**

الفوز بالقيمة المحلية في حساب الوراثة. هذا متوقع عندما يتم تعيين الخاصية صراحةً على الكائن ولا تتجاوزها قاعدة أكثر تحديدًا.

**متى يجب أن أستخدم البيانات المحلية بدلًا من البيانات الفعّالة؟**

استخدم البيانات المحلية لتفقد أو تعديل مستوى تنسيق محدد. استخدم البيانات الفعّالة عندما تحتاج إلى المظهر النهائي بعد حساب الوراثة، قواعد الموضوع، والأنماط المطبقة. يُظهر [مثال المقارنة الكامل](#compare-local-inherited-and-effective-values) كلاهما في نفس سير العمل.