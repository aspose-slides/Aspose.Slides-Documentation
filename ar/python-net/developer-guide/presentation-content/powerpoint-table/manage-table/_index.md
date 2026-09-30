---
title: إدارة جداول العروض التقديمية باستخدام بايثون
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
description: "إنشاء وتعديل الجداول في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجداول الخاص بك."
---
## **المقدمة**

تُنظِّم الجداول في PowerPoint المعلومات في صفوف وأعمدة، مما يسهل قراءتها ومقارنة القيم.

توفر Aspose.Slides الفئات [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) و[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) وأنواعًا أخرى لتتيح لك إنشاء الجداول وتحديثها وإدارتها في العروض التقديمية.

## **إنشاء جدول من الصفر**

قم بإنشاء جدول عن طريق تحديد موقعه وعرض الأعمدة وارتفاع الصفوف. بعد إضافته إلى شريحة، يمكنك تنسيق حدود الخلايا، دمج الخلايا، وإدراج النص.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع إلى الشريحة باستخدام فهرسها.
3. عرّف قائمة بعروض الأعمدة بالنقاط.
4. عرّف قائمة بارتفاعات الصفوف بالنقاط.
5. أضف كائنًا [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة عبر الطريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
6. تجوّل عبر كل [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) لتطبيق تنسيق على الحدود العليا والسفلى واليمين واليسار.
7. ادمج الخلية الأولى والثانية في الصف الأول للجدول.
8. الوصول إلى الخلية المدمجة عبر خاصية [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) .
9. عيّن النص في الخلية المدمجة.
10. احفظ العرض التقديمي المعدل.

المثال أدناه ينشئ جدولًا به ثلاثة أعمدة وخمس صفوف عند (100, 50) نقطة. يطبق حدودًا حمراء بعرض 5 نقاط، يدمج الخليتين الأوليين في الصف الأول، ويحفظ النتيجة باسم `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **الترقيم في جدول قياسي**

في جدول قياسي، تكون مؤشرات الخلايا تبدأ من الصفر وتستخدم الترتيب (العمود، الصف). تُعطى الخلية الأولى الفهرس (0, 0). في بايثون، يمكن الوصول إلى خلية عبر `table.rows[row_index][column_index]`; يأتي فهرس الصف أولًا في هذه الصيغة.

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ينشئ هذا المثال جدول 4 × 4 الموضح أعلاه، بعرض أعمدة وارتفاع صفوف بقيمة 70 نقطة وحدود خلايا حمراء بعرض 5 نقاط. تُظهر الإحداثيات مؤشرات الخلايا؛ يترك المثال الخلايا فارغة ويحفظ الجدول باسم `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى جدول موجود**

تُخزن الجداول في مجموعة الأشكال الخاصة بالشريحة. تجوّل عبر الأشكال لتحديد جدول، ثم استخدم الفئة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) لقراءة خلاياه أو تعديلها.

1. حمِّل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع إلى الشريحة التي تحتوي على الجدول باستخدام فهرسها.
3. تجوّل عبر كائنات [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) وتوقف عند العثور على جدول. إذا احتوت الشريحة على عدة جداول، استخدم [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) لتحديد الجدول المطلوب.
4. حدّث النص في الخلية المستهدفة.
5. احفظ العرض التقديمي المعدل.

يفتح المثال أدناه الملف `UpdateExistingTable.pptx` ويعثر على أول جدول في الشريحة الأولى. يعيّن الخلية في العمود 0، الصف 1 إلى `New` ويحفظ النتيجة باسم `table1_out.pptx`. يجب أن يحتوي الإدخال على شريحة واحدة على الأقل، ويجب أن يحتوي أول جدول في تلك الشريحة على عمود واحد على الأقل وصفين على الأقل.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

لإعادة تحجيم صف في جدول موجود وفهم لماذا قد يتجاوز ارتفاعه الفعلي الحد الأدنى المطلوب، راجع [Control Row Height](/slides/ar/python-net/manage-rows-and-columns/#control-row-height).

## **العثور على الخلية التي تملك إطار نص**

عند استلام كود معالجة النص العام كائن [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) من جدول، استخدم خاصية [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) لاسترداد الـ[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) المالكة. بالنسبة لإطار نص خلية جدول، تكون [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) مُعيَّنة وتكون [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) تساوي `None`، رغم أن الجدول نفسه يُعد شكلًا.

إحداثيات الخلية متاحة عبر خاصيتي [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) و[Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) للقراءة فقط. كذلك تكون [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) للقراءة فقط: توفر التنقل إلى المالك لكنها لا تغيّر الملكية. تأكد دائمًا من فحص الخلية المسترجعة للتحقق من أنها ليست `None` قبل استخدامها.

للحصول على مثال كامل يحدد مالكي خلية الجدول والشكل، بما في ذلك الأشكال المرتبطة بعناصر SmartArt، راجع [Search and Replace Text](/slides/ar/python-net/search-and-replace-text/).

## **محاذاة النص في جدول**

يمكنك التحكم في تثبيت النص عموديًا واتجاهه داخل خلايا الجدول الفردية. المثال في هذا القسم يوسّط النص داخل الخلية الأولى ويدوره بزاوية 270 درجة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع إلى الشريحة باستخدام فهرسها.
3. أضف كائنًا [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) إلى الشريحة.
4. الوصول إلى كائن [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) من الجدول.
5. الوصول إلى أول [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وتعيين نصه ولونه.
6. تعيين خاصيات الخلية [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) و[text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) .
7. احفظ العرض التقديمي المعدل.

ينشئ هذا المثال جدولًا 4 × 4 بعرض أعمدة 120 نقطة وارتفاع صفوف 100 نقطة. ينسق النص في الخلية (0, 0)، يضيف قيمًا إلى الخلايا المتبقية في الصف الأول، ويحفظ النتيجة باسم `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تنسيق النص على مستوى الجدول**

استخدم [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) لتطبيق تنسيق النص على جميع خلايا الجدول. تدعم الإصدارات المتعددة تنسيق الجزء والفقرة وإطار النص، لذا يمكنك تعيين هذه الخصائص دون الحاجة إلى التكرار عبر الخلايا الفردية.

1. حمّل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع إلى الشريحة باستخدام فهرسها.
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) من الشريحة.
4. تعيين [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) للنص.
5. تعيين [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) و[margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) .
6. تعيين [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) .
7. احفظ العرض التقديمي المعدل.

يفتح المثال أدناه الملف `table.pptx`، الذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل. يعيّن حجم الخط إلى 25 نقطة، يضبط محاذاة الفقرات إلى اليمين مع هامش يميني قدره 20 نقطة، ويجعل النص عموديًا. يُحفظ العرض التقديمي المُنسق باسم `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على خصائص نمط الجدول**

استخدم [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) لقراءة أو تعيين نمط مسبق للجدول. يطبق هذا المثال [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) على جدول واحد، يطبع اسم النمط المسبق، ويعيّن نفس النمط لجدول ثانٍ. تُحفظ كلا الجدولين في `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **قفل نسبة أبعاد الجدول**

نسبة أبعاد الجدول هي نسبة عرضه إلى ارتفاعه. استخدم [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) لقفل هذه النسبة للجدول.

يفتح المثال أدناه الملف `pres.pptx`، الذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل. يطبع حالة القفل الحالية، يُفعِّل قفل نسبة الأبعاد، يطبع الحالة المحدثة (`True`)، ويحفظ النتيجة باسم `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يوفر الجدول خاصية [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) ، وتحتوي الفقرات على [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). يضمن استخدامهما معًا الترتيب الصحيح للـRTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/python-net/applying-protection-to-presentation/) لتعطيل التحريك، تغيير الحجم، التحديد، إلخ. تُطبق هذه الأقفال على الجداول أيضًا.

**هل يتم دعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) لخلية؛ ستغطّي الصورة مساحة الخلية وفقًا للوضع المختار (تمدد أو تجانب).