---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 40
url: /ar/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة المعاينة
- تغيير حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إصلاح تغيير حجم ورقة عمل Excel OLE في العروض التقديمية: طريقتان للحفاظ على إطارات الكائن متسقة — إما بتحجيم الإطار أو الورقة — عبر صيغ PPT و PPTX."
---

{{% alert color="primary" %}} 
تمت ملاحظة أن أوراق عمل Excel المدمجة ككائنات OLE في عرض PowerPoint عبر مكونات Aspose يتم تغيير حجمها إلى مقياس غير معروف بعد التفعيل الأول. يخلق هذا السلوك اختلافًا بصريًا واضحًا في العرض بين حالتي ما قبل التفعيل وما بعده لكائن OLE. لقد حققنا في هذه المشكلة بشكل مفصل وقدمنا حلاً، وهو ما تم تغطيته في هذه المقالة.
{{% /alert %}} 

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/python-net/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides for Python عبر .NET. لمعالجة [مشكلة معاينة الكائن](/slides/ar/python-net/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المختارة إلى إطار كائن OLE. في العرض الناتج، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تفعيل دفتر عمل Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على دفتر عمل Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج دفتر العمل المفعل. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. عامل تغيير الحجم سيختلف حسب حجم إطار كائن OLE ودفتر عمل Excel المدمج. 

## **سبب تغيير الحجم**

نظرًا لأن دفتر عمل Excel له حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تفعيل دفتر عمل Excel، تتفاوض Excel وPowerPoint على الحجم لضمان المحافظة على النسب الصحيحة كجزء من عملية التضمين. يحدث تغيير الحجم بناءً على الاختلافات بين حجم نافذة Excel وحجم وموقع إطار كائن OLE. 

## **الحل العملي**

هناك حلان محتملان لتجنب تأثير تغيير الحجم.

- تحجيم حجم إطار OLE في عرض PowerPoint ليتطابق مع ارتفاع وعرض عدد الصفوف والأعمدة المطلوب في إطار OLE.  
- الحفاظ على حجم إطار OLE ثابتًا وتحجيم حجم الصفوف والأعمدة المشاركة لتناسب حجم إطار OLE المحدد.  

### **تحجيم حجم إطار OLE**

في هذا النهج، سنتعلم كيفية ضبط حجم إطار OLE لدفتر عمل Excel المدمج ليتطابق مع الحجم التراكمي للصفوف والأعمدة المشاركة في ورقة العمل Excel.

لنفترض أن لدينا ورقة Excel نموذجية ونريد إضافتها إلى عرض تقديمي كإطار OLE. في هذا السيناريو، سيُحسب أولاً حجم إطار كائن OLE بناءً على مجموع ارتفاعات الصفوف وعروض الأعمدة للصفوف والأعمدة المشاركة في دفتر العمل. ثم، سنضبط حجم إطار OLE على هذه القيمة المحسوبة. لتجنب ظهور رسالة الحمراء "EMBEDDED OLE OBJECT" لإطار OLE في PowerPoint، سنقوم أيضًا بالتقاط صورة للأجزاء المطلوبة من الصفوف والأعمدة في دفتر العمل وتعيينها كصورة لإطار OLE.
```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # تعيين الحجم المعروض عند استخدام ملف دفتر العمل ككائن OLE في PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # الحصول على عرض وارتفاع صورة OLE بالنقاط.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # نحتاج إلى استخدام دفتر العمل المعدل.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # إضافة صورة OLE إلى موارد العرض التقديمي.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Create the OLE object frame.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **تحجيم نطاق الخلايا**

في هذا النهج، سنتعلم كيفية تحجيم ارتفاعات الصفوف المشاركة وعرض الأعمدة المشاركة ليتطابق مع حجم إطار OLE مخصص.

لنفترض أن لدينا ورقة Excel نموذجية ونريد إضافتها إلى عرض تقديمي كإطار OLE. في هذا السيناريو، سنحدد حجم إطار OLE ونحجم الصفوف والأعمدة التي تشارك في منطقة إطار OLE. ثم سنحفظ دفتر العمل إلى تدفق لتطبيق التغييرات ونحولها إلى مصفوفة بايت لإضافتها إلى إطار OLE. لتجنب ظهور رسالة الحمراء "EMBEDDED OLE OBJECT" لإطار OLE في PowerPoint، سنقوم أيضًا بالتقاط صورة للأجزاء المطلوبة من الصفوف والأعمدة في دفتر العمل وتعيينها كصورة لإطار OLE.
```py
# <param name="width">العرض المتوقع لنطاق الخلايا بالنقاط.</param>
# <param name="height">الارتفاع المتوقع لنطاق الخلايا بالنقاط.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # تحديد الحجم المعروض عند استخدام ملف دفتر العمل ككائن OLE في PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # تعديل نطاق الخلايا ليتناسب مع حجم الإطار.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # نحتاج إلى استخدام دفتر العمل المعدل.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # إضافة صورة OLE إلى موارد العرض التقديمي.
            ole_image = presentation.images.add_image(image_stream)

            # إنشاء إطار كائن OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الخلاصة**

{{% alert color="primary" %}}
هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات الخاصة وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.
{{% /alert %}}