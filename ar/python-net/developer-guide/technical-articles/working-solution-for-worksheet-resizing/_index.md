---
title: حل عملي لإعادة تحجيم ورقة العمل
type: docs
weight: 40
url: /ar/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة المعاينة
- إعادة تحجيم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إصلاح تعديل حجم OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على تناسق إطارات الكائن—توسيع الإطار أو الورقة—عبر تنسيقي PPT و PPTX."
---
{{% alert color="info" title="Note" %}}
قد يتم تغيير حجم أوراق عمل Excel المضمنة ككائنات OLE في عرض تقديمي لـ PowerPoint باستخدام مكونات Aspose بشكل غير متوقع بعد التنشيط الأول. يتسبب هذا السلوك في اختلاف بصري واضح بين كائن OLE قبل وبعد التنشيط. يوضح هذا المقال المشكلة ويصف طريقتين للتعامل معها.
{{% /alert %}}

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/python-net/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض تقديمي لـ PowerPoint باستخدام Aspose.Slides for Python via .NET. لمعالجة [مشكلة معاينة الكائن](/slides/ar/python-net/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة لمنطقة ورقة العمل المحددة إلى إطار كائن OLE. في العرض المخرجي، عند النقر المزدوج على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين إجراء أي تغييرات مرغوبة على مصنف Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج مصنف Excel النشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيتفاوت عامل تغيير الحجم بناءً على حجم إطار كائن OLE ومصنف Excel المضمن.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel له حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التنشيط الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عند تنشيط مصنف Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية التضمين. يحدث تغيير الحجم بناءً على الفروقات بين حجم نافذة Excel وحجم وإحداثيات إطار كائن OLE.

## **حل عملي**

هناك حلّان متاحان لتجنب تأثير تغيير الحجم.

- قِم بتوسيع إطار OLE في عرض PowerPoint ليتطابق مع الارتفاع والعرض الإجمالي للصفوف والأعمدة المحددة.
- حافظ على حجم إطار OLE ثابتًا وقم بتوسيع الصفوف والأعمدة المحددة لتناسبه.

### **تحجيم حجم إطار OLE**

تحدد هذه الطريقة حجم إطار OLE ليتطابق مع الارتفاع والعرض الإجمالي للصفوف والأعمدة المحددة في ورقة Excel المضمنة.

يقوم المثال بتحميل مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقة العمل الأولى باستخدام فهارس تبدأ من الصفر. يحدد [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) النطاق المعروض. يتم عرض المعاينة بدقة 96 DPI، وتُحول أبعاد البكسل إلى نقاط باستخدام 72 نقطة لكل بوصة. يدمج [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) المصنف المعدل في إطار بهذه الأبعاد. تُعيّن المعاينة عبر [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) لاستبدال عنصر العنصر النائب "EMBEDDED OLE OBJECT" في العرض المحفوظ.

يحدد المساعد للمعاينة [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) إلى النطاق المحدد ويزيل الهوامش والرؤوس والتذييلات. مع تمكين [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) يتم توليد [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) للنطاق كصورة PNG. يعيد المساعد وضع مؤشر تدفق الصورة قبل إرجاعه للاستخدام في العرض.

```py
import io
import aspose.cells as cells

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

المثال الكامل أدناه يجمع بين المساعدات وتضمين المصنف ويحفظ العرض باسم `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # تعيين الحجم المعروض عندما يتم استخدام ملف المصنف ككائن OLE في PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # الحصول على عرض وارتفاع صورة OLE بالنقاط.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # نحتاج إلى استخدام المصنف المعدل.
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

### **تحجيم نطاق الخلايا**

تقوم هذه الطريقة بتوسيع ارتفاعات الصفوف المحددة وعرض الأعمدة المحددة لتتناسب مع حجم إطار OLE مخصص.

يقوم المثال بتحميل مصنف Excel موجود ويختار أول 10 صفوف و13 عمودًا من ورقة العمل الأولى باستخدام فهارس تبدأ من الصفر. يحدد [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) النطاق المعروض، ويقوم المساعد أدناه بتوسيع ذلك النطاق ليتناسب مع إطار عرضه 400 نقطة وارتفاعه 100 نقطة. بعد حفظ المصنف المعدل إلى تدفق، يدمجه [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) بالحجم المحدد. تُعيّن المعاينة التي تم توليدها بدقة 96 DPI عبر [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/)، لذا يعرض العرض المحفوظ الخلايا المحددة بدلاً من العنصر النائب الافتراضي.

تحسب أداة التوسيع نسب العرض والارتفاع المنفصلة للنطاق المحدد، مع الحفاظ على نسب عرض الأعمدة وارتفاع الصفوف. تُحول الأبعاد المحسوبة من نقاط إلى بوصات قبل تطبيقها باستخدام [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) و[Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). يجب أن يكون للنطاق المحدد عرض وارتفاع غير صفريين.

```py
import aspose.cells as cells

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

يولد هذا المساعد للمعاينة النطاق المعاد تحجيمه باستخدام [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). يقتصر [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) على ذلك النطاق، ويزيل الهوامش والرؤوس والتذييلات، ويُعيد تدفق PNG موضعه في بدايته.

```py
import io
import aspose.cells as cells

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

المثال الكامل أدناه يجمع بين المساعدات وتضمين المصنف ويحفظ العرض باسم `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # تعيين الحجم المعروض عندما يتم استخدام ملف المصنف ككائن OLE في PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # توسيع نطاق الخلايا ليتناسب مع حجم الإطار.
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

## **الخلاصة**

{{% alert color="info" title="Note" %}}
هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. اختر النهج الأنسب لمتطلباتك وحالتك. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.
{{% /alert %}}

## **الأسئلة الشائعة**

**لماذا يتغير حجم ورقة Excel المضمنة عند تفعيلها لأول مرة في PowerPoint؟**

يحدث ذلك لأن Excel يحاول الحفاظ على حجم النافذة الأصلي عند التنشيط، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يؤدي إلى تغيير الحجم.

**هل يمكن منع هذه المشكلة بالكامل؟**

نعم. من خلال تحجيم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تحجيم نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب فيه.

**أي طريقة تحجيم يجب أن أختار، تحجيم إطار OLE أم تحجيم نطاق الخلايا؟**

اختر **تحجيم إطار OLE** إذا كنت تريد الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **تحجيم نطاق الخلايا** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك.

**هل ستعمل هذه الحلول إذا كان عرضي مبنيًا على قالب؟**

نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الأساليب؟**

لا. يمكنك جعل إطار كائن OLE بأي حجم طالما قمت بضبط المعامل المناسب.

**هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟**

نعم. من خلال التقاط صورة للنطاق المستهدف في Excel وتعيينها كصورة عنصر نائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.