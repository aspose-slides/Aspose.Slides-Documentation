---
title: إدارة جداول العروض التقديمية باستخدام Python
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/python-net/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى جدول
- نسبة العرض إلى الارتفاع
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "إنشاء وتعديل الجداول في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET. اكتشف أمثلة شيفرة بسيطة لتبسيط سير عمل الجداول."
---

## **نظرة عامة**

الجدول في PowerPoint هو وسيلة فعّالة لعرض المعلومات. المعلومات المرتبة في شبكة من الخلايا (صفوف وأعمدة) تكون واضحة وسهلة الفهم.

توفر Aspose.Slides الفئة [جدول](https://reference.aspose.com/slides/python-net/aspose.slides/table/) والفئة [خلية](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) وأنواع أخرى ذات صلة لمساعدتك على إنشاء وتحديث وإدارة الجداول في أي عرض تقديمي.

## **إنشاء جداول من الصفر**

يوضح هذا القسم كيفية إنشاء جدول من الصفر في Aspose.Slides بإضافة شكل جدول إلى شريحة، وتحديد صفوفه وأعمدته، وتعيين أحجام دقيقة. ستشاهد أيضًا كيفية ملء الخلايا بالنص، وضبط المحاذاة والحدود، وتخصيص مظهر الجدول.

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة بواسطة فهرسها.
3. تعريف مصفوفة لعروض الأعمدة.
4. تعريف مصفوفة لارتفاعات الصفوف.
5. إضافة [جدول](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
6. iterating over each [خلية](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) وتنسيق حدودها العلوية والسفلية واليمينية واليسارية.
7. دمج الخليتين الأوليين في الصف الأول من الجدول.
8. الوصول إلى [إطار النص](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الخاص بـ [خلية](https://reference.aspose.com/slides/python-net/aspose.slides/cell/).
9. إضافة نص إلى [إطار النص](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية إنشاء جدول في عرض تقديمي:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تعريف عروض الأعمدة وارتفاعات الصفوف.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # إضافة شكل جدول إلى الشريحة.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # تعيين تنسيق الحد لكل خلية.
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
        
    # دمج الخلايا من (صف 0، عمود 0) إلى (صف 1، عمود 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # إضافة نص إلى الخلية المدمجة.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **الترقيم في الجداول القياسية**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ومبنيًا على الصفر. تُرقم الخلية الأولى في الجدول كـ (0, 0) (العمود 0، الصف 0).

على سبيل المثال، في جدول يضم 4 أعمدة و4 صفوف، يتم ترقيم الخلايا كما يلي:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

المثال التالي بلغة Python يوضح كيفية الإشارة إلى الخلايا باستخدام هذا الترقيم القائم على الصفر:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **الوصول إلى جدول موجود**

يشرح هذا القسم كيفية定位 والعمل مع جدول موجود في عرض تقديمي باستخدام Aspose.Slides. ستتعلم كيفية العثور على الجدول في شريحة، والوصول إلى صفوفه وأعمدته وخلياته، وتحديث المحتوى أو التنسيق.

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول بواسطة فهرسها.
3. تكرار جميع كائنات [شكل](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) حتى يتم العثور على الجدول.
4. استخدام كائن [جدول](https://reference.aspose.com/slides/python-net/aspose.slides/table/) للعمل مع الجدول.
5. حفظ العرض التقديمي المعدل.

{{% alert color="info" %}}
إذا احتوت الشريحة على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه عبر خاصية `alternative_text`.
{{% /alert %}}

المثال التالي بلغة Python يوضح كيفية الوصول إلى جدول موجود والعمل معه:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation لتحميل ملف PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    table = None

    # تكرار الأشكال والإشارة إلى أول جدول يتم العثور عليه.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # تعيين نص الخلية الأولى في الصف الأول.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # حفظ العرض التقديمي المعدل إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **محاذاة النص في الجداول**

يوضح هذا القسم كيفية التحكم في محاذاة النص داخل خلايا الجدول باستخدام Aspose.Slides. ستتعلم ضبط المحاذاة الأفقية والعمودية للخلايا للحفاظ على وضوح المحتوى وتناسقه.

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
3. إضافة كائن [جدول](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
4. الوصول إلى كائن [خلية](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) من الجدول.
5. محاذاة النص عموديًا.
6. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية محاذاة النص داخل جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # تعريف عروض الأعمدة وارتفاعات الصفوف.
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

يوضح هذا القسم كيفية تطبيق تنسيق النص على مستوى الجدول في Aspose.Slides بحيث يرث كل خلية نمطًا موحدًا. ستتعلم ضبط حجم الخط، والمحاذاة، والهوامش بصورة شاملة.

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
3. إضافة [جدول](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
4. تعيين حجم الخط (ارتفاع الخط) للنص.
5. تعيين محاذاة الفقرة والهوامش.
6. تعيين اتجاه النص العمودي.
7. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تطبيق تنسيقاتك المفضلة على النص داخل جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # تعيين حجم الخط لجميع خلايا الجدول.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # تعيين نص محاذى إلى اليمين وهوامش يمينية لجميع خلايا الجدول.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # تعيين الاتجاه العمودي للنص لجميع خلايا الجدول.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق أنماط الجداول المدمجة**

يسمح لك Aspose.Slides بتنسيق الجداول باستخدام الأنماط المدمجة مباشرة في الشيفرة. يوضح المثال إنشاء جدول، تطبيق نمط مدمج، وحفظ النتيجة—طريقة فعّالة لضمان تنسيق موحد واحترافي.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **قفل نسبة العرض إلى الارتفاع للجداول**

نسبة العرض إلى الارتفاع للشكل هي نسبة أبعاده. توفر Aspose.Slides الخاصية `aspect_ratio_locked`، والتي تسمح لك بقفل نسبة العرض إلى الارتفاع للجداول والأشكال الأخرى.

المثال التالي بلغة Python يوضح كيفية قفل نسبة العرض إلى الارتفاع لجدول:

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

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. الجدول يفضي الخاصية [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/)، والفقرات لها [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). باستخدامهما معًا يتم ضمان الترتيب الصحيح للنص وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تعديل حجم جدول في الملف النهائي؟**

استخدم [قفل الأشكال](/slides/ar/python-net/applying-protection-to-presentation/) لتعطيل التحريك، تعديل الحجم، التحديد، إلخ. تُطبق هذه الأقفال أيضًا على الجداول.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [ملء صورة](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمديد أو تجانب).