---
title: حل عملي لتغيير حجم ورقة العمل
type: docs
weight: 20
url: /ar/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- صورة المعاينة
- تغيير حجم الصورة
- Excel
- ورقة عمل
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إصلاح تغيير حجم OLE لورقة عمل Excel في العروض التقديمية: طريقتان للحفاظ على اتساق إطارات الكائن - إما ضبط مقياس الإطار أو الورقة - عبر صيغ PPT و PPTX."
---
{{% alert color="info" title="ملاحظة" %}}
تمت ملاحظة أن أوراق عمل Excel المضمنة ككائنات OLE في عرض تقديمي PowerPoint عبر مكوّنات Aspose يتم تغيير حجمها إلى مقياس غير محدد بعد التفعيل الأول. يخلق هذا السلوك فرقًا بصريًا ملحوظًا في العرض بين حالتي ما قبل و ما بعد تفعيل كائن OLE. لقد قمنا بالتحقيق في هذه المشكلة بالتفصيل وتقديم حل، وهو ما يتم تغطيته في هذه المقالة.
{{% /alert %}}

## **الخلفية**

في المقالة [إدارة OLE](/slides/ar/python-java/manage-ole/)، شرحنا كيفية إضافة إطار OLE إلى عرض تقديمي PowerPoint باستخدام Aspose.Slides for Python via Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/python-java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة للمنطقة المحددة من ورقة العمل إلى إطار كائن OLE. في العرض الناتج، عند النقر مزدوجًا على إطار كائن OLE الذي يعرض صورة ورقة العمل، يتم تفعيل دفترة Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة على دفترة Excel الفعلية ثم العودة إلى الشريحة بالنقر خارج دفترة Excel المُفعّلة. سيتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة. سيتفاوت عامل تغيير الحجم بناءً على حجم إطار كائن OLE ودفترة Excel المضمنة.

## **سبب تغيير الحجم**

نظرًا لأن دفترة Excel لها حجم نافذة خاص بها، فإنها تحاول الاحتفاظ بحجمها الأصلي عند التفعيل الأول. من ناحية أخرى، يحتوي إطار كائن OLE على حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تفعيل دفترة Excel، يتفاوض Excel وPowerPoint على الحجم لضمان الحفاظ على النسب الصحيحة كجزء من عملية التضمين. يحدث تغيير الحجم بناءً على الفروقات بين حجم نافذة Excel وحجم ومكان إطار كائن OLE.

## **الحل العملي**

هناك حلّان ممكنان لتجنب تأثير تغيير الحجم.

- ضبط مقياس حجم إطار OLE في عرض PowerPoint ليتطابق مع ارتفاع وعرض عدد الصفوف والأعمدة المطلوبة في إطار OLE.
- الحفاظ على حجم إطار OLE ثابتًا وتغيير مقياس حجم الصفوف والأعمدة المشاركة لتناسب حجم إطار OLE المحدد.

### **ضبط مقياس حجم إطار OLE**

في هذا النهج، سنتعلم كيفية تعيين حجم إطار OLE لدفترة Excel المضمنة ليتطابق مع الحجم التراكمي للصفوف والأعمدة المشاركة في ورقة العمل.

لنفترض أن لدينا ورقة Excel نموذجية ونريد إضافتها إلى عرض تقديمي كإطار OLE. في هذا السيناريو، سيُحسب أولاً حجم إطار كائن OLE بناءً على الارتفاعات التراكمية للصفوف وعروض الأعمدة المشاركة في الدفتر. ثم سنقوم بتعيين حجم إطار OLE إلى هذه القيمة المحسوبة. لتجنب رسالة “EMBEDDED OLE OBJECT” الحمراء لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في الدفتر ونعينها كصورة لإطار OLE.

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

    # تعيين الحجم المعروض عندما يُستخدم دفتر العمل ككائن OLE في PowerPoint.
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

        # استخدام دفتر العمل المعدل.
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

### **ضبط مقياس حجم نطاق الخلايا**

في هذا النهج، سنتعلم كيفية ضبط ارتفاعات الصفوف المشاركة وعروض الأعمدة المشاركة لتتطابق مع حجم إطار OLE مخصص.

لنفترض أن لدينا ورقة Excel نموذجية ونريد إضافتها إلى عرض تقديمي كإطار OLE. في هذا السيناريو، سنحدد حجم إطار OLE ونضبط حجم الصفوف والأعمدة التي تشارك في مساحة إطار OLE. ثم سنحفظ الدفتر إلى تدفق لتطبيق التغييرات ونحوّله إلى مصفوفة بايت لإضافته إلى إطار OLE. لتجنب رسالة “EMBEDDED OLE OBJECT” الحمراء لإطار OLE في PowerPoint، سنلتقط أيضًا صورة للأجزاء المطلوبة من الصفوف والأعمدة في الدفتر ونعينها كصورة لإطار OLE.

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


def scale_cell_range(cell_range, width, height):
    # العرض والارتفاع المتوقع لنطاق الخلايا بوحدات النقاط.
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

    # تعيين الحجم المعروض عندما يُستخدم دفتر العمل ككائن OLE في PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # ضبط نطاق الخلايا ليتناسب مع حجم الإطار.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # استخدام دفتر العمل المعدل.
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

{{% alert color="info" title="ملاحظة" %}} 
هناك نهجان لإصلاح مشكلة تغيير حجم ورقة العمل. يعتمد اختيار النهج المناسب على المتطلبات الخاصة وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة، سواء تم إنشاء العروض من قالب أو من الصفر. بالإضافة إلى ذلك، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.
{{% /alert %}}

## **الأسئلة المتداولّة**

**لماذا تتغير حجم ورقة عمل Excel المضمنة عند تفعيلها لأول مرة في PowerPoint؟**

يحدث هذا لأن Excel تحاول الحفاظ على حجم النافذة الأصلي عند التفعيل، بينما يمتلك إطار كائن OLE في PowerPoint أبعادًا خاصة به. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يؤدي إلى تغيير الحجم.

**هل يمكن منع مشكلة تغيير الحجم بالكامل؟**

نعم. من خلال ضبط مقياس إطار OLE ليتناسب مع حجم نطاق خلايا Excel أو ضبط مقياس نطاق الخلايا ليتناسب مع حجم إطار OLE المطلوب، يمكنك منع تغيير الحجم غير المرغوب فيه.

**أي طريقة مقياس يجب أن أستخدمها، مقياس إطار OLE أم مقياس نطاق الخلايا؟**

اختر **مقياس إطار OLE** إذا كنت تريد الحفاظ على أحجام الصفوف والأعمدة الأصلية في Excel. اختر **مقياس نطاق الخلايا** إذا كنت تريد حجمًا ثابتًا لإطار OLE في عرضك التقديمي.

**هل ستعمل هذه الحلول إذا كان عرضي التقديمي يعتمد على قالب؟**

نعم. كلا الحلين يعملان للعروض التي تم إنشاؤها من قوالب وللعروض التي تم إنشاؤها من الصفر.

**هل هناك حد لحجم إطار OLE عند استخدام هذه الطرق؟**

لا. يمكنك جعل إطار كائن OLE بأي حجم طالما قمت بضبط المقياس بشكل ملائم.

**هل هناك طريقة لتجنب نص العنصر النائب “EMBEDDED OLE OBJECT” في PowerPoint؟**

نعم. عبر التقاط لقطة لنطاق خلايا Excel المستهدف وتعيينها كصورة عنصر نائب لإطار OLE، يمكنك عرض صورة معاينة مخصصة بدلاً من العنصر النائب الافتراضي.

## **المقالات ذات الصلة**

[إنشاء مخطط Excel وتضمينه في عرض تقديمي ككائن OLE](/slides/ar/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)