---
title: إدارة جداول العرض التقديمي باستخدام Python
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/python-net/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى جدول
- نسبة الأبعاد
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتحرير الجداول في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Python عبر .NET. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجداول الخاص بك."
---
## **المقدمة**

الجدول في PowerPoint طريقة فعّالة لعرض المعلومات. المعلومات المرتبة في شبكة من الخلايا (صفوف وأعمدة) تكون بسيطة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/) والفئة [Cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/) وأنواع أخرى ذات صلة لمساعدتك على إنشاء الجداول وتحديثها وإدارتها في أي عرض تقديمي.

## **إنشاء جداول من الصفر**

يوضح هذا القسم كيفية إنشاء جدول من الصفر في Aspose.Slides عن طريق إضافة شكل جدول إلى شريحة، وتعريف صفوفه وأعمدته، وتحديد الأحجام بدقة. ستتعرف أيضًا على كيفية ملء الخلايا بالنص، وضبط المحاذاة والحدود، وتخصيص مظهر الجدول.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة عبر فهرسها.
3. تعريف مصفوفة لعروض الأعمدة.
4. تعريف مصفوفة لارتفاعات الصفوف.
5. إضافة [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/) إلى الشريحة.
6. تكرار كل [Cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/) وتنسيق حدها العلوي والسفلي واليمين واليسار.
7. دمج خلايا الصفين الأولين والعمودين الأولين في خلية واحدة.
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) الخاص بـ [Cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/).
9. إضافة نص إلى [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدّل.

المثال التالي بلغة Python يوضح كيفية إنشاء جدول في عرض تقديمي:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تعريف عرض الأعمدة وارتفاع الصفوف.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # إضافة شكل جدول إلى الشريحة.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # تعيين تنسيق الحدود لكل خلية.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # دمج الخلايا من (الصف 0، العمود 0) إلى (الصف 1، العمود 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # إضافة نص إلى الخلية المدمجة.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **الترقيم في الجداول القياسية**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ويبدأ من الصفر. تُعد الخلية الأولى في الجدول ذات الفهرس (0, 0) (العمود 0، الصف 0).

على سبيل المثال، في جدول يضم 4 أعمدة و4 صفوف، يتم ترقيم الخلايا كما يلي:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

المثال التالي بلغة Python يوضح كيفية الإشارة إلى الخلايا باستخدام هذا الترقيم الصفري:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة جدول بـ 4 أعمدة و 4 صفوف.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى جدول موجود**

يشرح هذا القسم كيفية تحديد جدول موجود في عرض تقديمي والعمل معه باستخدام Aspose.Slides. ستتعلم كيفية العثور على الجدول في شريحة، والوصول إلى صفوفه وأعمدته وخلاياه، وتحديث المحتوى أو التنسيق.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول عبر فهرسها.
3. تكرار جميع كائنات [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) حتى تجد الجدول.
4. استخدام كائن [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/) للعمل مع الجدول.
5. حفظ العرض التقديمي المعدّل.

{{% alert color="info" title="ملاحظة" %}}
إذا كانت الشريحة تحتوي على عدة جداول، من الأفضل البحث عن الجدول المطلوب عبر خاصية `alternative_text`.
{{% /alert %}}

المثال التالي بلغة Python يوضح كيفية الوصول إلى جدول موجود والعمل معه:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتحميل ملف PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    table = None

    # تكرار الأشكال والإشارة إلى أول جدول تم العثور عليه.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # تعيين نص أول خلية في الصف الأول.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # حفظ العرض التقديمي المعدّل إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **العثور على الخلية التي تملك إطار نص**

عند استقبال كود معالجة النص العام لكائن [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) من جدول، استخدم خاصية [TextFrame.parent_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_cell/) لاسترجاع الـ [Cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/) المالك. بالنسبة لإطار نص خلية جدول، يتم تعيين [TextFrame.parent_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_cell/) وتكون [TextFrame.parent_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_shape/) `None`، رغم أن الجدول نفسه يعتبر شكلًا.

تتوفر إحداثيات الخلية عبر خاصيتي القراءة فقط [Cell.first_column_index](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/first_column_index/) و[Cell.first_row_index](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/first_row_index/). الخاصية [TextFrame.parent_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/parent_cell/) أيضًا للقراءة فقط: توفر التنقل إلى المالك دون تغيير الملكية. تأكد دائمًا من أن الخلية المرجعة ليست `None` قبل استخدامها.

للحصول على مثال كامل يحدد مالكي خلايا الجداول والأشكال، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/python-net/search-and-replace-text/).

## **محاذاة النص في الجداول**

يعرض هذا القسم كيفية التحكم في موضع النص داخل خلايا الجدول باستخدام Aspose.Slides. ستتعلم كيفية تثبيت النص عموديًا داخل الخلية وتغيير اتجاه النص.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة عبر فهرسها.
3. إضافة كائن [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/) إلى الشريحة.
4. الوصول إلى كائن [Cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides/cell/) من الجدول.
5. توسيط النص عموديًا في الخلية وتعيين اتجاه النص.
6. حفظ العرض التقديمي المعدّل.

المثال التالي بلغة Python يوضح كيفية محاذاة النص في جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تعريف عرض الأعمدة وارتفاع الصفوف.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # إضافة شكل جدول إلى الشريحة.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # توسيط النص وتعيين الاتجاه العمودي.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تنسيق النص على مستوى الجدول**

يعرض هذا القسم كيفية تطبيق تنسيق النص على مستوى الجدول في Aspose.Slides بحيث يرث كل خلية نمطًا موحدًا. ستتعلم كيفية تعيين حجم الخط، والمحاذاة، والهوامش عالميًا.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة عبر فهرسها.
3. إضافة كائن [Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/) إلى الشريحة.
4. تعيين حجم الخط (ارتفاع الخط) للنص.
5. تعيين محاذاة الفقرات والهوامش.
6. تعيين اتجاه النص العمودي.
7. حفظ العرض التقديمي المعدّل.

المثال التالي بلغة Python يوضح كيفية تطبيق خيارات التنسيق المفضلة على النص داخل جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن من فئة Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # تعيين حجم الخط لجميع خلايا الجدول.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # تعيين نص محاذى لليمين وهامش يميني لجميع خلايا الجدول.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # تعيين اتجاه النص العمودي لجميع خلايا الجدول.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق أنماط الجداول المدمجة**

تتيح Aspose.Slides تنسيق الجداول باستخدام أنماط مسبقة التعريف مباشرة في الكود. يوضح المثال إنشاء جدول، تطبيق نمط مدمج، وحفظ النتيجة—طريقة فعّالة لضمان تنسيق ثابت ومحترف.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **قفل نسبة الأبعاد للجداول**

نسبة أبعاد الشكل هي نسبة أبعادها. توفر Aspose.Slides الخاصية `aspect_ratio_locked` التي تسمح بقفل نسبة الأبعاد للجداول وغيرها من الأشكال.

المثال التالي بلغة Python يوضح كيفية قفل نسبة الأبعاد لجدول:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يمكن تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يتيح الجدول خاصية [right_to_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/right_to_left/)، وتملك الفقرات خاصية [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraphformat/right_to_left/). يمنح استخدام كلا الخاصيتين ترتيبًا وعرضًا صحيحًا للـ RTL داخل الخلايا.

**كيف يمكن منع المستخدمين من نقل أو تغيير حجم جدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/python-net/applying-protection-to-presentation/) لتعطيل النقل، تغيير الحجم، التحديد، وغيرها. تُطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المحدد (تمديد أو تجانب).