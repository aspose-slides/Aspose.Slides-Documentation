---
title: إدارة جداول العرض التقديمي باستخدام بايثون
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/python-net/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى الجدول
- نسبة الأبعاد
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتحرير الجداول في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجدول الخاص بك."
---

## **نظرة عامة**

يُعد الجدول في PowerPoint وسيلة فعّالة لعرض المعلومات. المعلومات المُرتبة في شبكة من الخلايا (صفوف وأعمدة) تكون واضحة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)، الفئة [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) وأنواع أخرى ذات صلة لمساعدتك في إنشاء وتحديث وإدارة الجداول في أي عرض تقديمي.

## **إنشاء جداول من الصفر**

توضح هذه الفقرة كيفية إنشاء جدول من الصفر في Aspose.Slides عن طريق إضافة شكل جدول إلى شريحة، تعريف صفوفه وأعمدته، وتحديد أحجام دقيقة. كما ستتعرف على كيفية تعبئة الخلايا بالنص، ضبط المحاذاة والحدود، وتخصيص مظهر الجدول.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة حسب فهرستها.
3. تعريف مصفوفة لعرض الأعمدة.
4. تعريف مصفوفة لارتفاع الصفوف.
5. إضافة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
6. تكرار كل [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) وتنسيق حدوده العليا، السفلى، اليمنى واليسرى.
7. دمج الخليتين الأوليين في الصف الأول للجدول.
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بـ [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/).
9. إضافة نص إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

مثال بايثون التالي يوضح كيفية إنشاء جدول في عرض تقديمي:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
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
        
    # Merge cells from (row 0, col 0) to (row 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Add text to the merged cell.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Save the presentation to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **الترقيم في الجداول القياسية**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ويعتمد على الصفر. تُعد الخلية الأولى في الجدول ذات الفهرس (0, 0) (العمود 0، الصف 0).

على سبيل المثال، في جدول يحتوي على 4 أعمدة و4 صفوف، تُرقم الخلايا على النحو التالي:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

مثال بايثون التالي يوضح كيفية الإشارة إلى الخلايا باستخدام هذا الترميز الصفري:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **الوصول إلى جدول موجود**

تشرح هذه الفقرة كيفية تحديد جدول موجود والعمل معه داخل عرض تقديمي باستخدام Aspose.Slides. ستتعلم كيفية العثور على الجدول داخل شريحة، الوصول إلى صفوفه وأعمدته وخلاياه، وتحديث المحتوى أو التنسيق.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول حسب فهرستها.
3. تكرار جميع كائنات [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) حتى تجد الجدول.
4. استخدام كائن [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) للعمل مع الجدول.
5. حفظ العرض التقديمي المعدل.

{{% alert color="info" %}}

إذا احتوت الشريحة على عدة جداول، من الأفضل البحث عن الجدول المطلوب عبر الخاصية `alternative_text`.

{{% /alert %}}

مثال بايثون التالي يوضح كيفية الوصول إلى جدول موجود والعمل معه:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class to load a PPTX file.
with slides.Presentation("sample.pptx") as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    table = None

    # Iterate through shapes and reference the first table found.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Set the text of the first cell in the first row.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Save the modified presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **محاذاة النص في الجداول**

تُظهر هذه الفقرة كيفية التحكم في محاذاة النص داخل خلايا الجدول باستخدام Aspose.Slides. ستتعلم ضبط المحاذاة الأفقية والعمودية للخلايا للحفاظ على وضوح المحتوى واتساقه.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة حسب فهرستها.
3. إضافة كائن [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
4. الوصول إلى كائن [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) داخل الجدول.
5. محاذاة النص عموديًا.
6. حفظ العرض التقديمي المعدل.

مثال بايثون التالي يوضح كيفية محاذاة النص داخل جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Center the text and set vertical orientation.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Save the presentation to disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق تنسيق النص على مستوى الجدول**

توضح هذه الفقرة كيفية تطبيق تنسيق نص على مستوى الجدول في Aspose.Slides بحيث يرث كل خلية نمطًا موحدًا. ستتعلم ضبط حجم الخط، المحاذاة، والهوامش بشكل عام.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة حسب فهرستها.
3. إضافة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
4. ضبط حجم الخط (ارتفاع الخط) للنص.
5. ضبط محاذاة الفقرة والهوامش.
6. ضبط الاتجاه العمودي للنص.
7. حفظ العرض التقديمي المعدل.

مثال بايثون التالي يوضح كيفية تطبيق تنسيقاتك المفضلة على النص داخل جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Set the font size for all table cells.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Set right-aligned text and a right margin for all table cells.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Set the vertical text orientation for all table cells.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق أنماط الجداول المدمجة**

تتيح لك Aspose.Slides تنسيق الجداول باستخدام أنماط مُعرَّفة مسبقًا مباشرة في الشيفرة. يوضح المثال إنشاء جدول، تطبيق نمط مدمج، وحفظ النتيجة—طريقة فعّالة لضمان تنسيق موحد ومهني.

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

مثال بايثون التالي يوضح كيفية قفل نسبة الأبعاد لجدول:

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

## **FAQ**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يكشف الجدول عن خاصية [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/)، وتملك الفقرات خاصية [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). يضمن استخدام كلاهما الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم جدول في الملف النهائي؟**

استخدم [قفل الأشكال](/slides/ar/python-net/applying-protection-to-presentation/) لتعطيل التحريك، تغيير الحجم، التحديد، إلخ. تُطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [ملء صورة](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) لخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمتد أو تجانب).