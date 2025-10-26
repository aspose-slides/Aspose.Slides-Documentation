---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام بايثون
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/python-net/developer-guide/presentation-content/powerpoint-table/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة الحد
- تقسيم خلية
- صورة في خلية
- لون خلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة خلايا الجداول بسهولة في PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. إتقان الوصول إلى الخلايا وتعديلها وتنسيقها بسرعة لأتمتة الشرائح بسلاسة."
---

## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع خلايا الجداول في العروض التقديمية باستخدام Aspose.Slides. ستتعرف على كيفية اكتشاف الخلايا المدمجة، وإزالة أو تخصيص حدود الخلية، وفهم كيفية ترقيم PowerPoint للخلايا بعد عمليات الدمج والتقسيم بحيث يمكنك توقع الفهارس في التخطيطات المعقدة. كما تُظهر المقالة مهام التنسيق الشائعة — مثل تغيير تعبئة خلفية الخلية — وتوضح كيفية وضع صورة مباشرة داخل خلية جدول باستخدام إعدادات تعبئة الصورة. يرافق كل سيناريو أمثلة مختصرة بلغة Python تُنشئ أو تُعدل الجداول ثم تحفظ العرض المحدث، بحيث يمكنك تعديل الشيفرات لتناسب شرائحك بسرعة.

## **تحديد خلايا الجداول المدمجة**

غالبًا ما تحتوي الجداول على خلايا مدمجة للرؤوس أو لتجميع البيانات ذات الصلة. في هذا القسم، ستتعرف على كيفية تحديد ما إذا كانت خلية معينة تنتمي إلى منطقة مدمجة وكيفية الإشارة إلى الخلية الرئيسة (الزاوية العليا اليسرى) بحيث يمكنك قراءة أو تنسيق الكتلة بأكملها بشكل متسق.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على الجدول من الشريحة الأولى.
3. التنقل عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. طباعة رسالة عندما يتم العثور على خلايا مدمجة.

الكود التالي بلغة Python يحدد الخلايا المدمجة في عرض تقديمي:

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

## **إزالة حدود خلايا الجداول**

أحيانًا تشوش حدود الجداول على المحتوى أو تخلق فوضى بصرية. يوضح هذا القسم كيفية إزالة الحدود من الخلايا المختارة — أو من جوانب معينة من الخلية — بحيث يمكنك الحصول على تخطيط أنظف وتناسق أفضل مع تصميم شريحتك.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على الشريحة بحسب الفهرس.
3. تعريف مصفوفة بعرض الأعمدة.
4. تعريف مصفوفة بارتفاع الصفوف.
5. إضافة جدول إلى الشريحة باستخدام طريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. التنقل عبر كل خلية لإزالة الحدود العلوية والسفلية واليسرى واليمنى.
7. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية إزالة الحدود من خلايا الجدول:

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

إذا دمجت زوجين من الخلايا — على سبيل المثال، (1, 1) × (2, 1) و (1, 2) × (2, 2) — سيبقى ترقيم الجدول كما هو كما لو لم يتم الدمج. يوضح الكود التالي هذا السلوك:

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

المخرجات:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **الترقيم في الخلايا المقسمة**

في المثال السابق، عندما تم دمج خلايا الجدول، لم يتغير ترقيم الخلايا الأخرى. هذه المرة، ننشئ جدولًا عاديًا (بدون خلايا مدمجة) ثم نقسم الخلية (1, 1) لإنتاج جدول خاص. انتبه إلى ترقيم هذا الجدول — قد يبدو غير مألوف. ومع ذلك، هذا هو أسلوب ترقيم خلايا الجداول في Microsoft PowerPoint، ويتبع Aspose.Slides نفس السلوك.

الكود التالي يوضح هذا السلوك:

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

المخرجات:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **تغيير لون خلفية خلية الجدول**

يظهر المثال التالي بلغة Python كيفية تغيير لون خلفية خلية جدول:

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

## **إدراج صور في خلايا الجداول**

يعرض هذا القسم كيفية إدراج صورة داخل خلية جدول في Aspose.Slides. يغطي تطبيق تعبئة صورة على الخلية المستهدفة وتكوين خيارات العرض مثل التمدد أو التكرار.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة بحسب الفهرس.
3. تعريف مصفوفة بعرض الأعمدة.
4. تعريف مصفوفة بارتفاع الصفوف.
5. إضافة جدول إلى الشريحة باستخدام طريقة [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. تحميل الصورة من ملف.
7. إضافة الصورة إلى مجموعة صور العرض للحصول على كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
8. تعيين خاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للخلية إلى `PICTURE`.
9. تطبيق الصورة على الخلية واختيار وضع التعبئة (مثل `STRETCH`).
10. حفظ العرض كملف PPTX.

الكود التالي يوضح كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:

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

**هل يمكنني تعيين سماكة وأنماط خطوط مختلفة لجوانب خلية واحدة؟**

نعم. حدود [الأعلى](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[الأسفل](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[اليسار](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[اليمين](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) لها خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب. هذا يتماشى منطقيًا مع التحكم في حدود كل جانب للخلية كما هو موضح في المقالة.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [وضع التعبئة](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (تمدد/تكرار). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ مع التكرار، يُعاد حساب التجانب. تتناول المقالة أوضاع عرض الصورة داخل الخلية.

**هل يمكنني ربط كل محتوى خلية برابط تشعبي؟**

يتم تعيين [الارتباطات التشعبية](/slides/ar/python-net/manage-hyperlinks/) على مستوى النص (الجزء) داخل إطار النص للخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، يمكنك ربط الجزء أو كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار النص في الخلية الـ[الأقسام](/slides/ar/python-net/manage-hyperlinks/) (الوحدات) ذات تنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.