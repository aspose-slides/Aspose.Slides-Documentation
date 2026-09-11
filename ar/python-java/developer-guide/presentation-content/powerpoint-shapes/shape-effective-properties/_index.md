---
title: الحصول على الخصائص الفعّالة للأشكال من العروض التقديمية في بايثون عبر جافا
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/python-java/shape-effective-properties/
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
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية استخدام Aspose.Slides لبايثون عبر جافا لتفريق تنسيق الشكل المحلي، الموروث، والفعّال في عروض PowerPoint التقديمية."
---
## **فهم الخصائص المحلية، الموروثة، والفعّالة**

يمكن أن يأتي تنسيق PowerPoint من عدة مصادر. القيمة المخزنة مباشرة على الكائن هي **القيمة المحلية**. إذا لم تُحدد هذه القيمة، يبحث PowerPoint في مصادر التنسيق الأب، مثل القيمة الافتراضية للفقرة، نمط النص، تخطيط الشريحة أو الشريحة الرئيسة، السمة، أو القيم الافتراضية على مستوى العرض. تلك القيم هي **القيم الموروثة**. القيمة التي تبقى بعد حل كامل التسلسل الهرمي هي **القيمة الفعّالة** — القيمة المستخدمة لعرض الكائن.

على سبيل المثال، قد لا تحدد قطعة النص ارتفاع الخط الخاص بها. تكون قيمتها المحلية [getFontHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#getFontHeight) هي `float("nan")`، مما يعني "لم يتم تحديدها هنا". يمكن للقطعة أن ترث ارتفاعًا من الفقرة، أو نمط النص الافتراضي للعرض، أو مصدر آخر مناسب. استدعاء [getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#getEffective) على تنسيق القطعة يُعيد الارتفاع النهائي المحلول.

استخدم نوعي بيانات التنسيق لأغراض مختلفة:

- قراءة أو تعديل كائن تنسيق محلي، مثل [PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/)، عندما تحتاج إلى التحكم في مكان تعريف القيمة.
- قراءة كائن بيانات فعّالة، مثل `PortionFormatEffectiveData`، عندما تحتاج إلى النتيجة النهائية المعروضة. البيانات الفعّالة للقراءة فقط.

## **قارن القيم المحلية، الموروثة، والفعّالة**

المثال الكامل التالي يُنشئ شكلاً ويطبّق ارتفاعات الخط على مستويات العرض، الفقرة، والقطعة. كل خطوة تُطبع القيم المحددة في تلك المستويات والقيمة الفعّالة الناتجة لنفس قطعة النص. كما يُظهر لماذا يجب قراءة البيانات الفعّالة مرة أخرى بعد تغييرات التنسيق.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # قراءة البيانات الفعّالة بعد التغييرات السابقة.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # تعريف القيم الموروثة على مستويين مختلفين.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # القيمة المحلية على القطعة تتجاوز القيمتين الموروثتين.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # تغيير قيمة موروثة لا يتجاوز القيمة المحلية الحالية.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # مسح القيمة المحلية. الآن تُورث القطعة من الفقرة مرة أخرى.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # مسح قيمة الفقرة. الآن يُزود العرض التقديمي الافتراضي النتيجة.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الأولوية في هذا المثال هي تنسيق القطعة المحلي، ثم تنسيق الفقرة، ثم القيمة الافتراضية للعرض. يمكن لكائنات أخرى أن يكون لها سلاسل وراثة مختلفة، لكن المبدأ هو نفسه: القيمة الصريحة الأكثر تحديدًا تفوز، و[getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#getEffective) يُعيد النتيجة النهائية.

## **الحصول على خصائص النص الفعّالة**

تنقسم تنسيقات النص عبر عدة كائنات:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getEffective) يُحلّ خصائص إطار النص مثل الهوامش، التثبيت، الملاءمة التلقائية، واتجاه النص العمودي.
- [TextStyle.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textstyle/#getEffective) يُحلّ تنسيق الفقرة لكل مستوى من مستويات نمط النص.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraphformat/#getEffective) يُحلّ خصائص الفقرة مثل المحاذاة، المسافة البادئة، والرصاصات.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#getEffective) يُحلّ خصائص الحرف مثل ارتفاع الخط، نوع الخط، اللون، السُمك، والمائل.

للمثال التالي، يجب أن يحتوي `text-formatting.pptx` على شريحة واحدة على الأقل وعلى [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) واحد بإطار نص غير فارغ. يمكن أن يظهر الـ AutoShape في أي موقع داخل مجموعة الأشكال؛ يبحث الكود عن كائن مناسب ويُعَدل قبل الاستخدام.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **الحصول على خصائص ثلاثية الأبعاد الفعّالة**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getEffective) يُعيد كائن `ThreeDFormatEffectiveData` يجمع جميع إعدادات الـ 3D المحلولة. طرقه `getCamera` و`getLightRig` و`getBevelTop` و`getBevelBottom` تُظهر البيانات الفعّالة المقابلة. قراءة هذه الإعدادات ذات الصلة معًا يُسهل فهم المظهر النهائي الثلاثي الأبعاد للشكل.

للمثال، يجب أن يحتوي `shape-3d.pptx` على شكل واحد على الأقل في الشريحة الأولى. طبّق إعدادات كاميرا ثلاثية الأبعاد أو إضاءة أو حواف على ذلك الشكل إذا أردت أن يحتوي الناتج على قيم غير القيم الافتراضية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **الحصول على تنسيق الجدول الفعّال**

يمكن أن يأتي تنسيق الجدول من نمط الجدول ومن التنسيقات المطبقة على الجدول بأكمله أو العمود أو الصف أو الخلية الفردية. في حالة التعارض بين التعبئات المعرفة صراحةً، تكون الأولوية للخلية، ثم الصف، ثم العمود، ثم الجدول بأكمله. التنسيق الفعّال للخلية هو التنسيق النهائي المستخدم لرسم تلك الخلية.

للمثال، يجب أن يحتوي `table-formatting.pptx` على جدول واحد على الأقل في الشريحة الأولى. يجب أن يحتوي الجدول على صف واحد على الأقل وعمود واحد على الأقل. يبحث الكود عن [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) بدلًا من افتراض أن `getShapes().get_Item(0)` هو جدول.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

إذا كنت تحتاج إلى اللون بدلاً من مجرد نوع التعبئة، تحقق أولاً من `getFillType` الفعّال، ثم اقرأ الطريقة التي تنطبق على ذلك النوع — على سبيل المثال، `getSolidFillColor` لتعبئة صلبة.

## **إعادة قراءة البيانات الفعّالة بعد التغييرات**

البيانات الفعّالة تصف هرمية التنسيق في الوقت الذي يتم فيه حلها. استدعِ [getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#getEffective) مرة أخرى بعد تغيير أي شيء يمكن أن يشارك في تلك الهرمية، بما في ذلك:

- تنسيق الكائن المحلي؛
- القيم الافتراضية للفقرة أو إطار النص؛
- نمط الجدول أو تنسيق الجدول أو العمود أو الصف أو الخلية؛
- تنسيق التخطيط أو الشريحة الرئيسة؛
- بيانات السمة أو القيم الافتراضية على مستوى العرض؛
- التخطيط أو الشريحة الرئيسة المعينة لشريحة معينة.

لا تحتفظ بكائن بيانات فعّالة كلقطة ثابتة. قد تقوم Aspose.Slides بتخزين بعض البيانات الفعّالة مؤقتًا داخليًا، ويمكن لاستدعاء [getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#getEffective) لاحقًا تحديث تلك البيانات. إذا كنت بحاجة لمقارنة القيم قبل وبعد التغيير، انسخ القيم العددية التي تحتاجها — مثل ارتفاع الخط أو اللون أو المحاذاة أو عرض الحافة — إلى متغيراتك الخاصة قبل إجراء التغيير.

لتغيير قيمة، حدّث كائن التنسيق المحلي المناسب ثم استدعِ [getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#getEffective) للتحقق من النتيجة. كائنات البيانات الفعّالة نفسها للقراءة فقط.

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أي مستوى زود القيمة الفعّالة؟**

تحتوي البيانات الفعّالة على القيمة النهائية فقط، لا مصدرها. افحص الكائنات المحلية القابلة للتطبيق بدءًا من المستوى الأكثر تحديدًا إلى الخارج. بالنسبة للنص، قد يشمل ذلك القطعة، الفقرة، إطار النص، التخطيط، الشريحة الرئيسة، السمة، والقيم الافتراضية للعرض. القيم غير المعرفة مثل `float("nan")` أو `None` تدل على أن البحث ينتقل إلى مستوى آخر.

**ماذا يحدث عندما لا يحدد أي مستوى خاصية معينة؟**

تحل Aspose.Slides القيمة الافتراضية المناسبة في PowerPoint أو في المكتبة. تظهر تلك القيمة المحلّولة في البيانات الفعّالة رغم عدم تعريف كائن محلي لها صراحةً.

**لماذا تكون القيمة الفعّالة أحيانًا مساوية للقيمة المحلية؟**

فازت القيمة المحلية في حساب الوراثة. هذا متوقع عندما تُحدد الخاصية صراحةً على الكائن ولا يتجاوزها قاعدة أكثر تحديدًا.

**متى يجب استخدام البيانات المحلية بدلًا من البيانات الفعّالة؟**

استخدم البيانات المحلية لتفحص أو تعدّل مستوى تنسيق معين. استخدم البيانات الفعّالة عندما تحتاج إلى المظهر النهائي بعد تطبيق الوراثة وقواعد السمة والأنماط المطبقة. يوضح مثال [المقارنة الكامل](#compare-local-inherited-and-effective-values) كلا الاستخدامين في نفس سير العمل.