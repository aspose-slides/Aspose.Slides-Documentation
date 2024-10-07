---
title: إدارة الصفوف والأعمدة
type: docs
weight: 20
url: /python-net/manage-rows-and-columns/
keywords: "جدول، الصفوف والأعمدة، عرض PowerPoint، بايثون، Aspose.Slides لـ Python عبر .NET"
description: "إدارة الصفوف والأعمدة في الجداول بعروض PowerPoint باستخدام بايثون"
---

لتمكينك من إدارة الصفوف والأعمدة في جدول ضمن عرض PowerPoint، توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) وواجهة [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) والعديد من الأنواع الأخرى.

## **تعيين الصف الأول كعنوان**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أنشئ كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) واضبطه على null.
4. قم بالتكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) للعثور على الجدول المعني.
5. اضبط الصف الأول للجدول كعنوان له.

هذا الكود في بايثون يوضح لك كيفية تعيين الصف الأول من الجدول كعنوان له:

```python
import aspose.slides as slides

# Instantiates the Presentation class
with slides.Presentation("table.pptx") as pres:
    # Accesses the first slide
    sld = pres.slides[0]

    # Initializes the null TableEx
    tbl = None

    # Iterates through the shapes and sets a reference to the table
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Sets the first row of a table as its header 
    tbl.first_row = True
    
    # Saves the presentation to disk
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **نسخ صف أو عمود من الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. عرّف مصفوفة من `columnWidth`.
4. عرّف مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) إلى الشريحة من خلال طريقة `add_table(x, y, column_widths, row_heights)`.
6. قم بنسخ صف الجدول.
7. قم بنسخ عمود الجدول.
8. احفظ العرض المعدل.

هذا الكود في بايثون يوضح لك كيفية نسخ صف أو عمود من جدول PowerPoint:

```python
 import aspose.slides as slides

# Instantiates the Presentation class
with slides.Presentation() as presentation:

    # Accesses the first slide
    sld = presentation.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Adds a table shape to the slide
    table = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Adds some text to the row 1 cell 1
    table.rows[0][0].text_frame.text = "الصف 1 خلية 1"

    # Adds some text to the row 1 cell 2
    table.rows[1][0].text_frame.text = "الصف 1 خلية 2"

    # Clones Row 1 at the end of table
    table.rows.add_clone(table.rows[0], False)

    # Adds some text to the row 2 cell 1
    table.rows[0][1].text_frame.text = "الصف 2 خلية 1"

    # Adds some text to the row 2 cell 2
    table.rows[1][1].text_frame.text = "الصف 2 خلية 2"

    # Clones Row 2 as 4th row of table
    table.rows.insert_clone(3,table.rows[1], False)

    # Clones first column at the end
    table.columns.add_clone(table.columns[0], False)

    # Clones 2nd column at 4th column index
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Saves the presentation to disk
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة صف أو عمود من الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. عرّف مصفوفة من `columnWidth`.
4. عرّف مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) إلى الشريحة من خلال طريقة `add_table(x, y, column_widths, row_heights)`.
6. قم بإزالة صف الجدول.
7. قم بإزالة عمود الجدول.
8. احفظ العرض المعدل.

هذا الكود في بايثون يوضح لك كيفية إزالة صف أو عمود من جدول:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    colWidth =  [100, 50, 30] 
    rowHeight =  [30, 50, 30] 

    table = slide.shapes.add_table(100, 100, colWidth, rowHeight)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)
    pres.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تنسيق النص على مستوى صف الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. احصل على كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) المعني من الشريحة.
4. اضبط `font_height` لخلية الصف الأول.
5. اضبط `alignment` و`margin_right` لخلية الصف الأول.
6. اضبط `text_vertical_type` لخلية الصف الثاني.
7. احفظ العرض المعدل.

هذا الكود في بايثون يوضح لك العملية.

```python
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    
    slide = presentation.slides[0]

    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Sets first row cells' font height
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.rows[0].set_text_format(portionFormat)

    # Sets first row cells' text alignment and right margin
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.rows[0].set_text_format(paragraphFormat)

    # Sets the second row cells' text vertical type
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.rows[1].set_text_format(textFrameFormat)
	
    # Saves the presentation to Disk
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تنسيق النص على مستوى عمود الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. احصل على كائن [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) المعني من الشريحة.
4. اضبط `font_height` لخلية العمود الأول.
5. اضبط `alignment` و`margin_right` لخلية العمود الأول.
6. اضبط `text_vertical_type` لخلية العمود الثاني.
7. احفظ العرض المعدل.

هذا الكود في بايثون يوضح لك العملية:

```python
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as pres:
    slide = pres.slides[0]
    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Sets first column cells' font height
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.columns[0].set_text_format(portionFormat)

    # Sets first column cells' text alignment and right margin 
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.columns[0].set_text_format(paragraphFormat)

    # Sets second column cells' text vertical type
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.columns[1].set_text_format(textFrameFormat)

    # Saves the presentation to Disk
    pres.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرجاع خصائص النمط لجدول بحيث يمكنك استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. هذا الكود في بايثون يوضح لك كيفية الحصول على خصائص النمط من نمط جدول محدد مسبقًا:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```