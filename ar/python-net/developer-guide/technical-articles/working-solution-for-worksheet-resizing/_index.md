---
title: حل عملي لإعادة تحجيم ورقة العمل
type: docs
weight: 40
url: /ar/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة المعاينة
- تحجيم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إصلاح إعادة تحجيم كائن OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على إطارات الكائن متسقة—إما تعديل حجم الإطار أو تعديل حجم الورقة—عبر صيغ PPT و PPTX."
---

{{% alert color="primary" %}} 

لقد لوحظ أن أوراق عمل Excel المدمجة ككائنات OLE في عرض PowerPoint عبر مكونات Aspose يتم تغيير حجمها إلى مقياس غير معروف بعد التفعيل الأول. هذا السلوك يخلق فرقًا بصريًا ملحوظًا في العرض بين حالتي ما قبل وما بعد تفعيل كائن OLE. لقد حققنا في هذه المشكلة بالتفصيل وقدمنا حلاً مغطى في هذه المقالة.

{{% /alert %}} 

## **Background**

في المقالة [إدارة OLE](/slides/ar/python-net/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides for Python عبر .NET. لمعالجة [مشكلة معاينة الكائن](/slides/ar/python-net/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المختارة إلى إطار كائن OLE. في العرض الناتج، عند النقر مزدوجًا على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات يرونها مناسبة على مصنف Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج مصنف Excel النشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيختلف عامل إعادة الحجم بناءً على حجم إطار كائن OLE ومصنف Excel المدمج. 

## **Cause of Resizing**

نظرًا لأن مصنف Excel له حجم نافذته الخاص، فإنه يحاول الاحتفاظ بحجمه الأصلي عند التفعيل الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تنشيط مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية الدمج. يحدث إعادة التحجيم بناءً على الاختلافات بين حجم نافذة Excel وحجم موضع وإطار كائن OLE.

## **Working Solution**

هناك حلّان محتملان لتجنب تأثير إعادة التحجيم.

- تعديل حجم إطار OLE في عرض PowerPoint ليتطابق مع الارتفاع والعرض للعدد المرغوب من الصفوف والأعمدة في إطار OLE.
- الحفاظ على حجم إطار OLE ثابتًا وتعديل حجم الصفوف والأعمدة المشاركة لتتناسب مع حجم إطار OLE المحدد.

### **Scale the OLE Frame Size**

في هذا النهج، سنتعلم كيفية تعيين حجم إطار OLE لمصنف Excel المدمج ليتطابق مع الحجم التراكمي للصفوف والأعمدة المشاركة في ورقة العمل.

افترض أن لدينا ورقة Excel نموذجية ونرغب في إضافتها إلى عرض كم إطار OLE. في هذا السيناريو، سيتم حساب حجم إطار كائن OLE أولاً بناءً على الارتفاعات التراكمية للصفوف والعروض التراكمية للأعمدة المشاركة في المصنف. ثم سنقوم بتعيين حجم إطار OLE إلى هذه القيمة المحسوبة. لتجنب ظهور رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنقوم أيضًا بالتقاط صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف وتعيينها كصورة لإطار OLE.
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

    # تحديد الحجم المعروض عندما يتم استخدام ملف المصنف ككائن OLE في PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # الحصول على عرض وارتفاع صورة OLE بالنقاط.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # نحتاج إلى استخدام المصنف المُعدَّل.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # إضافة صورة OLE إلى موارد العرض التقديمي.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # إنشاء إطار كائن OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **Scale the Cell Range Size**

في هذا النهج، سنتعلم كيفية تعديل ارتفاعات الصفوف المشاركة وعرض الأعمدة المشاركة لتتناسب مع حجم إطار OLE مخصص.

افترض أن لدينا ورقة Excel نموذجية ونرغب في إضافتها إلى عرض كم إطار OLE. في هذا السيناريو، سنحدد حجم إطار OLE ونقوم بتعديل حجم الصفوف والأعمدة التي تشارك في منطقة إطار OLE. ثم سنحفظ المصنف إلى تدفق لتطبيق التغييرات ونحوّله إلى مصفوفة بايت لإضافته إلى إطار OLE. لتجنب ظهور رسالة "EMBEDDED OLE OBJECT" الحمراء لإطار OLE في PowerPoint، سنقوم أيضًا بالتقاط صورة للأجزاء المطلوبة من الصفوف والأعمدة في المصنف وتعيينها كصورة لإطار OLE.
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

    # تحديد الحجم المعروض عندما يتم استخدام ملف المصنف ككائن OLE في PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # تحجيم نطاق الخلايا ليتناسب مع حجم الإطار.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # نحتاج إلى استخدام المصنف المعدل.
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


## **Conclusion**

{{% alert color="primary" %}}

هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات المحددة وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة، سواءً تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

{{% /alert %}}