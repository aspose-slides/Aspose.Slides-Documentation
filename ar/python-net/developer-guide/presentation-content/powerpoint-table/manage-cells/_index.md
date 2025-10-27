---
title: إدارة خلايا الجدول في العروض التقديمية باستخدام بايثون
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-net/manage-cells/
keywords:
- table cell
- merge cells
- remove border
- split cell
- image in cell
- background color
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "إدارة خلايا الجدول بسهولة في PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. إتقان الوصول إلى الخلايا وتعديلها وتنسيقها بسرعة لتحقيق أتمتة سلسة للشرائح."
---

## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع خلايا الجدول في العروض التقديمية باستخدام Aspose.Slides. ستتعلم كيفية اكتشاف الخلايا المدمجة، مسح أو تخصيص حدود الخلية، وفهم كيفية ترقيم PowerPoint للخلايا بعد عمليات الدمج والتقسيم حتى تتمكن من توقع الفهرسة في التخطيطات المعقدة. كما تُظهر المقالة مهام تنسيق شائعة—مثل تغيير تعبئة خلفية الخلية—وتوضح كيفية وضع صورة مباشرة داخل خلية جدول باستخدام إعدادات تعبئة الصورة. كل سيناريو مصحوب بأمثلة بايثون مختصرة تُنشئ أو تعدل الجداول ثم تحفظ العرض المحدث، بحيث يمكنك تعديل الشفرات لتناسب شرائحك بسرعة.

## **تحديد الخلايا المدمجة في الجدول**

غالبًا ما تحتوي الجداول على خلايا مدمجة للرؤوس أو لتجميع البيانات ذات الصلة. في هذا القسم، سترى كيفية تحديد ما إذا كانت خلية معينة تنتمي إلى منطقة مدمجة وكيفية الإشارة إلى الخلية الرئيسية (أعلى اليسار) حتى تتمكن من قراءة أو تنسيق الكتلة بأكملها بشكل متسق.

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على الجدول من الشريحة الأولى.
1. التكرار عبر صفوف الجدول وأعمدته للعثور على الخلايا المدمجة.
1. طباعة رسالة عند العثور على خلايا مدمجة.

الشفرة بايثون التالية تحدد الخلايا المدمجة في العرض التقديمي:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Assuming the first shape on the first slide is a table.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **إزالة حدود خلايا الجدول**

أحيانًا تشوش حدود الجدول على المحتوى أو تخلق فوضى بصرية. يوضح هذا القسم كيفية إزالة الحدود من الخلايا المحددة—أو من جوانب معينة من الخلية—حتى تحصل على تخطيط أنظف ويتماشى بشكل أفضل مع تصميم شريحتك.

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على الشريحة عبر فهرستها.
1. تعريف مصفوفة بعرض الأعمدة.
1. تعريف مصفوفة بارتفاع الصفوف.
1. إضافة جدول إلى الشريحة باستخدام طريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
1. التكرار عبر كل خلية لمسح الحدود العليا والسفلى واليسرى واليمنى.
1. حفظ العرض المعدل كملف PPTX.

الشفرة بايثون التالية تُظهر كيفية إزالة الحدود من خلايا الجدول:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Clear the border fill for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Save the PPTX file to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **الترقيم في الخلايا المدمجة**

إذا دمجت زوجين من الخلايا—على سبيل المثال، (1, 1) × (2, 1) و(1, 2) × (2, 2)—فإن الجدول الناتج سيحافظ على نفس ترقيم الخلايا كما لو لم يكن هناك دمج. الشفرة بايثون التالية توضح هذا السلوك:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Merge cells (1,1) and (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Merge cells (1, 2) and (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

الإخراج:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **الترقيم في الخلايا المقسمة**

في المثال السابق، عندما تم دمج خلايا الجدول، لم يتغير الترقيم في الخلايا الأخرى. هذه المرة، ننشئ جدولًا عاديًا (بدون خلايا مدمجة) ثم نقسم الخلية (1, 1) لإنتاج جدول خاص. انتبه إلى ترقيم هذا الجدول—قد يبدو غير مألوف. ومع ذلك، هذا هو طريقة ترقيم Microsoft PowerPoint لخلايا الجدول، ويتبع Aspose.Slides نفس السلوك.

الشفرة بايثون التالية تُظهر هذا السلوك:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Split cell (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

الإخراج:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **تغيير لون خلفية خلية الجدول**

مثال بايثون التالي يوضح كيفية تغيير لون خلفية خلية الجدول:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Create a new table.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Set the background color for a cell.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **إدراج صور في خلايا الجدول**

يُظهر هذا القسم كيفية إدراج صورة داخل خلية جدول في Aspose.Slides. يغطي تطبيق تعبئة صورة على الخلية المستهدفة وتكوين خيارات العرض مثل التمدد أو التكرار.

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة عبر فهرستها.
1. تعريف مصفوفة بعرض الأعمدة.
1. تعريف مصفوفة بارتفاع الصفوف.
1. إضافة جدول إلى الشريحة باستخدام طريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
1. تحميل الصورة من ملف.
1. إضافة الصورة إلى صور العرض للحصول على كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
1. تعيين خاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للخلية إلى `PICTURE`.
1. تطبيق الصورة على خلية الجدول واختيار وضع التعبئة (مثل `STRETCH`).
1. حفظ العرض كملف PPTX.

الشفرة بايثون التالية تُظهر كيفية وضع صورة داخل خلية جدول عند إنشاء الجدول:

```python
import aspose.slides as slides

# Instantiate a Presentation object.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Load the image and add it to the presentation to obtain a PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Apply the image to the first table cell.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Save the presentation to disk.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يمكنني تعيين سمك خطوط وأنماط مختلفة لأوجه الخلية الواحدة؟**  
نعم. حدود [القمة](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)، [القاع](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)، [اليسار](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)، و[اليمين](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) لها خصائص منفصلة، لذا يمكن أن يختلف السمك والنمط لكل جانب. هذا يتماشى منطقيًا مع التحكم في الحدود لكل جانب داخل الخلية كما هو موضح في المقالة.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**  
السلوك يعتمد على [وضع التعبئة](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (تمدد/تكرار). عند التمدد، تتكيف الصورة مع الخلية الجديدة؛ وعند التكرار، تُعاد حساب البلاطات. المقالة تشير إلى أوضاع عرض الصورة في الخلية.

**هل يمكنني تعيين ارتباط تشعبي لكل محتوى الخلية؟**  
يتم تعيين [الروابط التشعبية](/slides/ar/python-net/manage-hyperlinks/) على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، يمكنك ربط الجزء أو كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**  
نعم. يدعم إطار النص داخل الخلية [الأجزاء](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) ذات تنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.