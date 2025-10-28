---
title: إدارة خلايا الجدول في العروض التقديمية باستخدام بايثون
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-net/manage-cells/
keywords:
- خلية جدول
- دمج الخلايا
- إزالة الحدود
- تقسيم الخلية
- صورة داخل الخلية
- لون الخلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة خلايا الجدول بسهولة في PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. إتقان الوصول إلى الخلايا وتعديلها وتنسيقها بسرعة لأتمتة الشرائح بسلاسة."
---

## **نظرة عامة**

توضح هذه المقالة كيفية التعامل مع خلايا الجدول في العروض التقديمية باستخدام Aspose.Slides. ستتعلم كيفية اكتشاف الخلايا المدمجة، ومسح أو تخصيص حدود الخلية، وفهم كيفية ترقيم PowerPoint للخلايا بعد عمليات الدمج والتقسيم بحيث يمكنك توقع الفهارس في التخطيطات المعقدة. كما تُظهر المقالة مهام تنسيق شائعة—مثل تغيير تعبئة خلفية الخلية—وتوضح كيفية وضع صورة مباشرة داخل خلية جدول باستخدام إعدادات تعبئة الصورة. كل سيناريو يرافقه أمثلة بايثون مختصرة تُنشئ أو تعدل الجداول ثم تحفظ العرض المحدث، لتتمكن من تعديل الشيفرات لتناسب شرائحك بسرعة.

## **تحديد خلايا الجدول المدمجة**

غالبًا ما تحتوي الجداول على خلايا مدمجة للرؤوس أو لتجميع البيانات ذات الصلة. في هذا القسم، ستتعرف على طريقة تحديد ما إذا كانت خلية معينة تنتمي إلى منطقة مدمجة وكيفية الإشارة إلى الخلية الرئيسية (أعلى اليسار) لتتمكن من قراءة أو تنسيق الكتلة بالكامل بصورة متسقة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على الجدول من الشريحة الأولى.
1. التجول في صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
1. طباعة رسالة عندما يتم العثور على خلايا مدمجة.

الكود التالي بايثون يحدد الخلايا المدمجة في عرض تقديمي:

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

في بعض الأحيان تُشتت حدود الجدول الانتباه عن المحتوى أو تُنشئ فوضى بصرية. يوضح هذا القسم كيفية إزالة الحدود من خلايا مختارة—أو من جوانب محددة للخلية—حتى تحصل على تخطيط أنظف وتنسق بشكل أفضل مع تصميم الشريحة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على الشريحة حسب مؤشرها.
1. تعريف مصفوفة لعروض الأعمدة.
1. تعريف مصفوفة لارتفاعات الصفوف.
1. إضافة جدول إلى الشريحة باستخدام طريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
1. التجول في كل خلية لمسح حدود الأعلى، الأسفل، اليسار، واليمين.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بايثون يوضح كيفية إزالة حدود خلايا الجدول:

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

إذا قمت بدمج زوجين من الخلايا—مثلاً (1, 1) × (2, 1) و(1, 2) × (2, 2)—ستحتفظ الجدول الناتج بنفس ترقيم الخلايا كما لو لم يتم الدمج. الكود التالي بايثون يوضح هذا السلوك:

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

الناتج:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **الترقيم في الخلايا المقسمة**

في المثال السابق، عندما تم دمج خلايا الجدول، لم يتغير ترقيم الخلايا الأخرى. هذه المرة، نقوم بإنشاء جدول عادي (بدون خلايا مدمجة) ثم نقسم الخلية (1, 1) لننتج جدولًا خاصًا. انتبه إلى ترقيم هذا الجدول—قد يبدو غير مألوف. ومع ذلك، هذا هو طريقة ترقيم Microsoft PowerPoint لخلايا الجدول، وتلتزم Aspose.Slides بالسلوك نفسه.

الكود التالي بايثون يوضح هذا السلوك:

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

الناتج:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **تغيير لون خلفية خلية الجدول**

المثال التالي بايثون يوضح كيفية تغيير لون خلفية خلية الجدول:

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

هذا القسم يوضح كيفية إدراج صورة داخل خلية جدول في Aspose.Slides. يتناول تطبيق تعبئة صورة على الخلية المستهدفة وإعداد خيارات العرض مثل التمدد أو التبليط.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة حسب مؤشرها.
1. تعريف مصفوفة لعروض الأعمدة.
1. تعريف مصفوفة لارتفاعات الصفوف.
1. إضافة جدول إلى الشريحة باستخدام طريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
1. تحميل الصورة من ملف.
1. إضافة الصورة إلى مجموعة الصور في العرض للحصول على كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
1. ضبط خاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للخلية إلى `PICTURE`.
1. تطبيق الصورة على خلية الجدول واختيار نمط تعبئة (مثل `STRETCH`).
1. حفظ العرض كملف PPTX.

الكود التالي بايثون يوضح كيفية وضع صورة داخل خلية جدول أثناء إنشاء الجدول:

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

## **الأسئلة الشائعة**

**هل يمكنني تعيين سماكة وأنماط خطوط مختلفة لجوانب مختلفة من خلية واحدة؟**

نعم. حدود الـ[أعلى](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)، [الأسفل](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)، [اليسار](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)، و[اليمين](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) لها خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب. هذا يتبع من التحكم في الحدود حسب الجانب الموضح في المقالة.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين الصورة كخلفية للخلية؟**

السلوك يعتمد على [وضع التعبئة](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (تمدد/تبليط). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ ومع التبليط، يُعاد حساب البلاط. يذكر المقال أوضاع عرض الصورة داخل الخلية.

**هل يمكنني ربط ارتباط تشعبي بجميع محتويات الخلية؟**

[الارتباطات التشعبية](/slides/ar/python-net/manage-hyperlinks/) تُحدد على مستوى النص (الجزء) داخل إطار النص بالخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، يمكنك ربط الجزء أو كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار النص بالخلية الـ[أجزاء](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) التي يمكن تنسيقها بشكل مستقل—عائلة الخط، النمط، الحجم واللون.