---
title: حل عملي لإعادة تحجيم ورقة العمل
type: docs
weight: 20
url: /ar/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة معاينة
- تغيير حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إصلاح تغيير حجم ورقة عمل Excel OLE في العروض التقديمية: طريقتان للحفاظ على إطارات الكائن متسقة—إما تعديل حجم الإطار أو الورقة—في صيغ PPT و PPTX."
---
{{% alert color="info" title="Note" %}}

قد يتم تغيير حجم أوراق عمل Excel المضمنة ككائنات OLE في عرض PowerPoint باستخدام مكونات Aspose بشكل غير متوقع بعد تنشيطها الأول. يخلق هذا السلوك فرقًا بصريًا واضحًا بين كائن OLE قبل وبعد التنشيط. توضح هذه المقالة المشكلة وتصف طريقتين لمعالجتها.

{{% /alert %}}

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/python-java/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض PowerPoint باستخدام Aspose.Slides للغة Python عبر Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/python-java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة للمنطقة المحددة من ورقة العمل إلى إطار كائن OLE. في العرض الناتج، عندما تنقر نقرة مزدوجة على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تنشيط مصنف Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على مصنف Excel الفعلي ثم العودة إلى الشريحة بالنقر خارج مصنف Excel المنشط. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيتفاوت معامل إعادة التحجيم اعتمادًا على حجم إطار كائن OLE ومصنف Excel المضمن.

## **سبب إعادة التحجيم**

نظرًا لأن مصنف Excel له حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التنشيط الأول. من ناحية أخرى، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تنشيط مصنف Excel، يتفاوض كل من Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية التضمين. يحدث إعادة التحجيم بناءً على الفروقات بين حجم نافذة Excel وحجم وإزاحة إطار كائن OLE.

## **الحل العملي**

هناك حلّان محتملان لتجنب تأثير إعادة التحجيم.

- ضبط إطار OLE في عرض PowerPoint ليتطابق مع الارتفاع والعرض الكليين للصفوف والأعمدة المحددة.
- الحفاظ على حجم إطار OLE ثابتًا وتكبير الصفوف والأعمدة المحددة لتناسبه.

### **تحجيم حجم إطار OLE**

تحدد هذه الطريقة حجم إطار OLE ليتطابق مع الارتفاع والعرض الكليين للصفوف والأعمدة المحددة في ورقة Excel المضمنة.

يقوم المثال بتحميل مصنف Excel موجود وتحديد الصفوف العشرة الأولى و13 عمودًا من ورقته الأولى باستخدام فهارس صفرية. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) يحدد النطاق المعروض. يتم إنشاء المعاينة بدقة 96 DPI، وتُحول أبعاد البكسل إلى نقاط باستخدام 72 نقطة لكل بوصة. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) يضمّن المصنف المعدل في إطار بهذه الأبعاد. يتم تعيين المعاينة عبر [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) لاستبدال عنصر نائب "EMBEDDED OLE OBJECT" في العرض المحفوظ.

يقوم المساعد المعاين بتحديد [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) للنطاق المحدد وإزالة الهوامش والرؤوس والتذييلات. مع تمكين [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea)، يقوم [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) بإنتاج النطاق كصورة PNG. يُعيد المساعد تيار إدخال جديد يحتوي على صورة PNG، مُوضعًا في بدايته لاستخدامه في العرض.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # تحديد الحجم المعروض عندما يتم استخدام المصنف ككائن OLE في PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # الحصول على عرض وارتفاع صورة OLE بالنقاط.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # استخدام المصنف المعدل.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # إضافة صورة OLE إلى موارد العرض التقديمي.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # إنشاء إطار كائن OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **تحجيم حجم نطاق الخلايا**

تقوم هذه الطريقة بتكبير ارتفاعات الصفوف المحددة وعرض الأعمدة المحددة لتتناسب مع حجم إطار OLE مخصص.

يقوم المثال بتحميل مصنف Excel موجود وتحديد الصفوف العشرة الأولى و13 عمودًا من ورقته الأولى باستخدام فهارس صفرية. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) يحدد النطاق المعروض، ويقوم المساعد scale_cell_range بتكبير ذلك النطاق ليناسب إطار عرضه 400 نقطة وارتفاعه 100 نقطة. بعد حفظ المصنف المعدل إلى تيار، يضمّن [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame)ه بالحجم المحدد. يتم تعيين معاينة تم إنتاجها بدقة 96 DPI عبر [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)، بحيث يعرض العرض المحفوظ الخلايا المحددة بدلاً من العنصر النائب الافتراضي.

يحسب المساعد الخاص بالتحجيم نسب العرض والارتفاع المنفصلة للنطاق المحدد، مع الحفاظ على عرض الأعمدة النسبي وارتفاع الصفوف النسبي. يحول الأبعاد المحسوبة من نقاط إلى بوصات قبل تطبيقها باستخدام [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) و[Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). يجب أن يكون للنطاق المحدد عرض وارتفاع غير صفرية.

يقوم هذا المساعد المعاين بإنتاج النطاق المعدل باستخدام [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). يحدد [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) لهذا النطاق، ويزيل الهوامش والرؤوس والتذييلات، ويعيد تيار PNG مُوضعًا في بدايته.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpime.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpime.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # العرض المتوقع للعرض والارتفاع لنطاق الخلايا بالنقاط.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # تعيين الحجم المعروض عندما يتم استخدام المصنف ككائن OLE في PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # تحجيم نطاق الخلايا ليتناسب مع حجم الإطار.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # استخدام المصنف المعدل.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # إضافة صورة OLE إلى موارد العرض التقديمي.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # إنشاء إطار كائن OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **الخلاصة**

{{% alert color="info" title="Note" %}} 

هناك طريقتان لإصلاح مشكلة تغيير حجم ورقة العمل. اختر الطريقة التي تناسب متطلباتك وحالة الاستخدام. كلتا الطريقتين تعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

{{% /alert %}}

## **الأسئلة الشائعة**

**لماذا يتغير حجم ورقة عمل Excel المضمنة عند تنشيطها لأول مرة في PowerPoint؟**

يحدث ذلك لأن Excel تحاول الحفاظ على حجم النافذة الأصلي عند التنشيط، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على النسبة البانية، مما قد يؤدي إلى إعادة التحجيم.

**هل يمكن منع مشكلة إعادة التحجيم هذه تمامًا؟**

نعم. من خلال تحجيم إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو تحجيم النطاق ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع إعادة التحجيم غير المرغوب فيها.

**أي طريقة تحجيم يجب أن أستخدمها، تحجيم إطار OLE أم تحجيم نطاق الخلايا؟**

اختر **OLE frame scaling** إذا كنت تريد الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **cell range scaling** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك.

**هل ستعمل هذه الحلول إذا كان عرضي يعتمد على قالب؟**

نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟**

لا. يمكنك جعل إطار كائن OLE بأي حجم طالما قمت بضبط التحجيم بشكل مناسب.

**هل هناك طريقة لتجنب نص العنصر النائب "EMBEDDED OLE OBJECT" في PowerPoint؟**

نعم. من خلال التقاط لقطة لنطاق خلايا Excel المستهدف وتعيينها كصورة عنصر نائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **مقالات ذات صلة**

[إنشاء مخطط Excel وتضمينه في عرض تقديمي ككائن OLE](/slides/ar/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)