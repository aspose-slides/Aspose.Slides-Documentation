---
title: إدارة جداول العروض التقديمية باستخدام Python
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/python-net/developer-guide/presentation-content/powerpoint-table/manage-table/
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
description: "إنشاء وتعديل الجداول في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET. اكتشف أمثلة كود بسيطة لتبسيط سير عمل الجداول."
---

## **نظرة عامة**

الجدول في PowerPoint طريقة فعّالة لتقديم المعلومات. المعلومات المرتبة في شبكة من الخلايا (الصفوف والأعمدة) تكون مباشرة وسهلة الفهم.

توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) وفئة [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) وأنواع أخرى ذات صلة لمساعدتك في إنشاء وتحديث وإدارة الجداول في أي عرض تقديمي.

## **إنشاء جداول من الصفر**

يوضح هذا القسم كيفية إنشاء جدول من الصفر في Aspose.Slides عن طريق إضافة شكل جدول إلى شريحة، تعريف صفوفه وأعمدته، وتحديد أحجام دقيقة. ستتعرف أيضًا على كيفية ملء الخلايا بالنص، تعديل المحاذاة والحدود، وتخصيص مظهر الجدول.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة عبر فهرستها.
3. تعريف مصفوفة لعروض الأعمدة.
4. تعريف مصفوفة لارتفاعات الصفوف.
5. إضافة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
6. التكرار عبر كل [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) وتنسيق حدودها العليا والسفلى واليمنى واليسرى.
7. دمج الخليتين الأوليين في الصف الأول للجدول.
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) لخلية معينة.
9. إضافة نص إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يظهر كيفية إنشاء جدول في عرض تقديمي:

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

في جدول قياسي، يكون ترقيم الخلايا بسيطًا وصفرًا أساسًا. تُرقم الخلية الأولى في الجدول كـ (0, 0) (العمود 0، الصف 0).

على سبيل المثال، في جدول يحتوي على 4 أعمدة و4 صفوف، تكون الخلايا مرقمة كما يلي:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

المثال التالي بلغة Python يوضح كيفية الإشارة إلى الخلايا باستخدام هذا الترقيم الصفري:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **الوصول إلى جدول موجود**

يوضح هذا القسم كيفية العثور على جدول موجود في عرض تقديمي والعمل معه باستخدام Aspose.Slides. ستتعلم كيفية العثور على الجدول على الشريحة، الوصول إلى صفوفه وأعمدته وخلاياه، وتحديث المحتوى أو التنسيق.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول عبر فهرستها.
3. التكرار عبر جميع كائنات [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) حتى يتم العثور على الجدول.
4. استخدام كائن [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) للعمل مع الجدول.
5. حفظ العرض التقديمي المعدل.

{{% alert color="info" %}}
إذا احتوت الشريحة على عدة جداول، فمن الأفضل البحث عن الجدول المطلوب عبر خاصية `alternative_text` الخاصة به.
{{% /alert %}}

المثال التالي بلغة Python يوضح كيفية الوصول إلى جدول موجود والعمل معه:

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

يوضح هذا القسم كيفية التحكم في محاذاة النص داخل خلايا الجدول باستخدام Aspose.Slides. ستتعلم ضبط المحاذاة الأفقية والعمودية للخلايا للحفاظ على وضوح المحتوى واتساقه.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة عبر فهرستها.
3. إضافة كائن [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
4. الوصول إلى كائن [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) من الجدول.
5. محاذاة النص عموديًا.
6. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية محاذاة النص في جدول:

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

يوضح هذا القسم كيفية تطبيق تنسيق النص على مستوى الجدول في Aspose.Slides بحيث يرث كل خلية نمطًا موحدًا. ستتعلم ضبط حجم الخط، المحاذاة، والهوامش عالميًا.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة عبر فهرستها.
3. إضافة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
4. ضبط حجم الخط (ارتفاع الخط) للنص.
5. ضبط محاذاة الفقرات والهوامش.
6. ضبط توجيه النص العمودي.
7. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تطبيق خيارات التنسيق المفضلة على نص داخل جدول:

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

تتيح لك Aspose.Slides تنسيق الجداول باستخدام أنماط مسبقة التعريف مباشرةً في الكود. يوضح المثال إنشاء جدول، تطبيق نمط مدمج، وحفظ النتيجة—طريقة فعّالة لضمان تنسيق متسق ومحترف.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **قفل نسبة الأبعاد للجداول**

نسبة أبعاد الشكل هي نسبة أبعاده. توفر Aspose.Slides خاصية `aspect_ratio_locked` التي تسمح بقفل نسبة الأبعاد للجداول والأشكال الأخرى.

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

نعم. يعرض الجدول خاصية [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) ، وللفقرات خاصية [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). يضمن استخدامهما معًا الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكن منع المستخدمين من تحريك أو تغيير حجم جدول في الملف النهائي؟**

استخدم [قفل الأشكال](/slides/ar/python-net/applying-protection-to-presentation/) لتعطيل التحريك، تغيير الحجم، التحديد، إلخ. تُطبق هذه الأقفال أيضًا على الجداول.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [ملء صورة](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) لخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمديد أو تكرار).