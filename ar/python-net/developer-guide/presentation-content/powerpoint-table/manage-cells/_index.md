---
title: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-net/manage-cells/
keywords: "جدول، خلايا مدمجة، خلايا مقسمة، صورة في خلية جدول، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "خلايا جدول في عروض PowerPoint التقديمية باستخدام بايثون"
---

## **تحديد خلية جدول مدمجة**
1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على الجدول من الشريحة الأولى.
3. تمر عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. اطبع رسالة عند العثور على خلايا مدمجة.

يظهر لك هذا الكود بلغة بايثون كيفية تحديد خلايا الجدول المدمجة في عرض تقديمي:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "SomePresentationWithTable.pptx") as pres:
    table = pres.slides[0].shapes[0] # بافتراض أن #0.Shape#0 هو جدول
    for i in range(len(table.rows)):
        for j in range(len(table.columns)):
            currentCell = table.rows[i][j]
            if currentCell.is_merged_cell:
                print("الخانة 01 هي جزء من خلية مدمجة مع RowSpan=2 و ColSpan=3 بدءًا من الخانة 45.".format(
                    i, j, currentCell.row_span, currentCell.col_span, currentCell.first_row_index, currentCell.first_column_index))
```

## **إزالة حدود خلايا الجدول**
1. أنشئ مثيلاً من فئة `Presentation` .
2. احصل على مرجع للشريحة من خلال فهرسها.
3. عرّف مصفوفة من الأعمدة بعرض.
4. عرّف مصفوفة من الصفوف بارتفاع.
5. أضف جدولًا إلى الشريحة من خلال الطريقة `AddTable` .
6. تمر عبر كل خلية لإزالة الحدود العليا والسفلى واليمنى واليسرى.
7. احفظ العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود بلغة بايثون كيفية إزالة الحدود من خلايا الجدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# أنشئ مثيلاً من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
   # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعها
    dblCols = [ 50, 50, 50, 50 ]
    dblRows = [ 50, 30, 30, 30, 30 ]

    # إضافة شكل جدول إلى الشريحة
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # تعيين تنسيق الحدود لكل خلية
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # كتابة ملف PPTX إلى القرص
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **التعداد في خلايا مدمجة**
إذا دمجنا زوجين من الخلايا (1, 1) x (2, 1) و(1, 2) x (2, 2)، فإن الجدول الناتج سيكون مرقمًا. يوضح لك هذا الكود بلغة بايثون العملية:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# أنشئ مثيلاً من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى
    sld = presentation.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعها
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

    # دمج الخلايا (1, 1) x (2, 1)
    tbl.merge_cells(tbl.rows[1][1], tbl.rows[2][1], False)

    # دمج الخلايا (1, 2) x (2, 2)
    tbl.merge_cells(tbl.rows[1][2], tbl.rows[2][2], False)

    presentation.save("MergeCells_out.pptx", slides.export.SaveFormat.PPTX)
```

ثم نقوم بدمج الخلايا أكثر بدمج (1, 1) و(1, 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في وسطه:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# أنشئ مثيلاً من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى
    slide = presentation.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعها
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70]

    # إضافة شكل جدول إلى الشريحة
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # تعيين تنسيق الحدود لكل خلية
    for row in table.rows:
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

    # دمج الخلايا (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # دمج الخلايا (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # دمج الخلايا (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][1], table.rows[1][2], True)

    # كتابة ملف PPTX إلى القرص
    presentation.save("MergeCells1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **التعداد في الخلية المقسمة**
في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير الترقيم أو النظام العددي في الخلايا الأخرى.

هذه المرة، نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1،1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، والذي قد يعتبر غريبًا. ومع ذلك، هذه هي الطريقة التي تعد بها Microsoft PowerPoint خلايا الجدول وAspose.Slides تفعل الشيء نفسه.

يظهر لك هذا الكود بلغة بايثون العملية التي وصفناها:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# أنشئ مثيلاً من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى
    slide = presentation.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعها
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # إضافة شكل جدول إلى الشريحة
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # تعيين تنسيق الحدود لكل خلية
    for row in table.rows:
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

    # دمج الخلايا (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # دمج الخلايا (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # تقسيم الخلية (1، 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # كتابة ملف PPTX إلى القرص
    presentation.save("CellSplit_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير لون خلفية خلية الجدول**

يظهر لك هذا الكود بلغة بايثون كيفية تغيير لون خلفية خلية جدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    dblCols = [ 150, 150, 150, 150 ]
    dblRows = [ 50, 50, 50, 50, 50 ]

    # إنشاء جدول جديد
    table = slide.shapes.add_table(50, 50, dblCols, dblRows)

    # تعيين لون الخلفية لخلية
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة صورة داخل خلية جدول**
1. أنشئ مثيلاً من فئة `Presentation` .
2. احصل على مرجع للشريحة من خلال فهرسها.
3. عرّف مصفوفة من الأعمدة بعرض.
4. عرّف مصفوفة من الصفوف بارتفاع.
5. أضف جدولًا إلى الشريحة من خلال الطريقة `AddTable` .
6. أنشئ كائن `Bitmap` للاحتفاظ بملف الصورة.
7. أضف الصورة البتوماتية إلى كائن `IPPImage` .
8. عيّن `FillFormat` لخلية الجدول إلى `Picture` .
9. أضف الصورة إلى الخلية الأولى في الجدول.
10. احفظ العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود بلغة بايثون كيفية وضع صورة داخل خلية جدول عند إنشاء الجدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# أنشئ مثيلاً من فئة Presentation
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى
    islide = presentation.slides[0]

    # تعريف الأعمدة بعرضها والصفوف بارتفاعها
    dblCols =  [150, 150, 150, 150] 
    dblRows =  [100, 100, 100, 100, 90] 

    # إضافة شكل جدول إلى الشريحة
    tbl = islide.shapes.add_table(50, 50, dblCols, dblRows)

    # إنشاء كائن صورة بتوماتية للاحتفاظ بملف الصورة
    image = draw.Bitmap(path + "aspose-logo.jpg")

    # إنشاء كائن IPPImage باستخدام كائن البتوم
    imgx1 = presentation.images.add_image(image)

    # إضافة الصورة إلى أول خلية في الجدول
    tbl.rows[0][0].cell_format.fill_format.fill_type = slides.FillType.PICTURE
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture.image = imgx1

    # حفظ ملف PPTX إلى القرص
    presentation.save("Image_In_TableCell_out.pptx", slides.export.SaveFormat.PPTX)
```