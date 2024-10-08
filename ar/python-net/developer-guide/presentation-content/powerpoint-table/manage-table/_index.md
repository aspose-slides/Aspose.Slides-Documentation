---
title: إدارة الجدول
type: docs
weight: 10
url: /ar/python-net/manage-table/
keywords: "جدول, إنشاء جدول, الوصول إلى جدول, نسبة عرض الجدول إلى ارتفاعه, عرض تقديمي للباوربوينت, بايثون, Aspose.Slides for Python via .NET"
description: "إنشاء وإدارة الجدول في عروض PowerPoint التقديمية باستخدام بايثون"

---

الجدول في PowerPoint هو وسيلة فعالة لعرض وتمثيل المعلومات. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) بسيطة وسهلة الفهم.

توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) وواجهة [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) وفئة [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) وواجهة [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) وأنواع أخرى لتمكينك من إنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. حدد مصفوفة من `columnWidth`.
4. حدد مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) إلى الشريحة من خلال طريقة `add_table(x, y, column_widths, row_heights)` .
6. مرر عبر كل [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) لتطبيق التنسيق على الحدود العليا والسفلى واليمنى واليسرى.
7. دمج الخليتين الأوليين من الصف الأول للجدول.
8. الوصول إلى [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) .
9. أضف بعض النص إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) .
10. احفظ العرض التقديمي المعدل.

يوضح لك هذا الكود بلغة بايثون كيفية إنشاء جدول في عرض تقديمي:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# أنشئ مثيلاً لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعاتها
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # إضافة شكل جدول إلى الشريحة
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # تعيين تنسيق الحدود لكل خلية
    for row in range(len(tbl.rows)):
        for cell in range(len(tbl.rows[row])):
            tbl.rows[row][cell].cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_top.width = 5

            tbl.rows[row][cell].cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            tbl.rows[row][cell].cell_format.border_bottom.width =5

            tbl.rows[row][cell].cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            tbl.rows[row][cell].cell_format.border_left.width = 5

            tbl.rows[row][cell].cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_right.width = 5
        

    # دمج الخلايا 1 & 2 من الصف 1
    tbl.merge_cells(tbl.rows[0][0], tbl.rows[1][1], False)

    # إضافة نص إلى الخلية المدمجة
    tbl.rows[0][0].text_frame.text = "الخلايا المدمجة"

    # حفظ العرض التقديمي على القرص
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **الترقيم في الجدول القياسي**

في الجدول القياسي، يكون ترقيم الخلايا بسيطًا وصفرًا. يتم فهرسة أول خلية في الجدول كـ 0،0 (العمود 0، الصف 0).

على سبيل المثال، يتم ترقيم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

يوضح لك هذا الكود بلغة بايثون كيفية تحديد الترقيم للخلايا في جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# أنشئ مثيلاً لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعاتها
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # إضافة شكل جدول إلى الشريحة
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # تعيين تنسيق الحدود لكل خلية
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # حفظ العرض التقديمي على القرص
    pres.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى جدول موجود**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة التي تحتوي على الجدول من خلال فهرسها.
3. أنشئ كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) واضبطه على null.
4. مرر عبر جميع كائنات [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تعتقد أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال الموجودة فيها. عندما يتم التعرف على شكل كجدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) . ولكن إذا كانت الشريحة التي تتعامل معها تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه من خلال `alternative_text` .

5. استخدم كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.
6. احفظ العرض التقديمي المعدل.

يوضح لك هذا الكود بلغة بايثون كيفية الوصول إلى جدول موجود والعمل معه:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# أنشئ مثيلاً لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation(path + "UpdateExistingTable.pptx") as pres:
    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # تهيئة جدول null
    tbl = None

    # التكرار عبر الأشكال وتعيين مرجع إلى الجدول الذي تم العثور عليه
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # تعيين النص للعمود الأول من الصف الثاني
    tbl.rows[0][1].text_frame.text = "جديد"

    # حفظ العرض التقديمي المعدل على القرص
    pres.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **محاذاة النص في الجدول**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) من الجدول.
5. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) .
6. محاذاة النص عموديًا.
7. احفظ العرض التقديمي المعدل.

يوضح لك هذا الكود بلغة بايثون كيفية محاذاة النص في جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# ينشئ مثيلاً لفئة Presentation
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى
    slide = presentation.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعاتها
    dblCols =  [120, 120, 120, 120] 
    dblRows =  [100, 100, 100, 100] 

    # إضافة شكل الجدول إلى الشريحة
    tbl = slide.shapes.add_table(100, 50, dblCols, dblRows)
    tbl.rows[1][0].text_frame.text = "10"
    tbl.rows[2][0].text_frame.text = "20"
    tbl.rows[3][0].text_frame.text = "30"

    # الوصول إلى إطار النص
    txtFrame = tbl.rows[0][0].text_frame

    # إنشاء كائن الفقرة لإطار النص
    paragraph = txtFrame.paragraphs[0]

    # إنشاء كائن الجزء للفقرة
    portion = paragraph.portions[0]
    portion.text = "نص هنا"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # محاذاة النص عموديًا
    cell = tbl.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # حفظ العرض التقديمي على القرص
    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تنسيق النص على مستوى الجدول**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) من الشريحة.
4. تعيين `font_height` للنص.
5. تعيين `alignment` و `margin_right` .
6. تعيين `text_vertical_type` .
7. احفظ العرض التقديمي المعدل.

يوضح لك هذا الكود بلغة بايثون كيفية تطبيق خيارات التنسيق المفضلة لديك على النص في جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# ينشئ مثيلاً لفئة Presentation
with slides.Presentation() as presentation:
    someTable = presentation.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # تعيين ارتفاع خط الخلايا في الجدول
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.set_text_format(portionFormat)

    # تعيين محاذاة النص للخلايا في الجدول والهوامش اليمنى في استدعاء واحد
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.set_text_format(paragraphFormat)

    # تعيين نوع النص العمودي للخلايا في الجدول
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.set_text_format(textFrameFormat)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص أنماط الجدول حتى تتمكن من استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح لك هذا الكود بلغة بايثون كيفية الحصول على خصائص النمط من نمط جدولي محفوظ مسبقًا:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **قفل نسبة عرض الجدول إلى ارتفاعه**

نسبة العرض إلى الارتفاع لشكل هندسي هي نسبة أحجامه في أبعاد مختلفة. وفرت Aspose.Slides خاصية `aspect_ratio_locked` للسماح لك بقفل إعداد نسبة العرض إلى الارتفاع للجداول وغيرها من الأشكال.

يوضح لك هذا الكود بلغة بايثون كيفية قفل نسبة العرض للجدول:

```c#
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])
    print("تم تعيين قفل نسبة العرض إلى الارتفاع: {0}".format(table.shape_lock.aspect_ratio_locked))

    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked

    print("تم تعيين قفل نسبة العرض إلى الارتفاع: {0}".format(table.shape_lock.aspect_ratio_locked))

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```