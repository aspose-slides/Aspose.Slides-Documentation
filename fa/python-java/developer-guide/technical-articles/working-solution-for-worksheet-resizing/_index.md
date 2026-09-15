---
title: راه‌حل عملی برای تغییر اندازه برگه کاری
type: docs
weight: 20
url: /fa/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- برگه کاری
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "رفع تغییر اندازه OLE برگه کاری Excel در ارائه‌ها: دو روش برای حفظ سازگاری فریم‌های شی—مقیاس‌بندی فریم یا برگه—در فرمت‌های PPT و PPTX."
---
{{% alert color="info" title="توجه" %}}

مشاهده شده است که صفحات کاری Excel که به‌عنوان اشیای OLE در یک ارائه PowerPoint از طریق مؤلفه‌های Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاس نامشخصی تغییر اندازه می‌دهند. این رفتار تفاوت بصری قابل‌توجهی بین حالت قبل و بعد از فعال‌سازی شی OLE در ارائه ایجاد می‌کند. ما این مشکل را به‌طور دقیق بررسی کرده و راه‌حلی ارائه کرده‌ایم که در این مقاله پوشش داده شده است.

{{% /alert %}}

## **پیش‌زمینه**

در مقاله [Manage OLE](/slides/fa/python-java/manage-ole/) توضیح دادیم چگونه یک فریم OLE را به ارائه PowerPoint با استفاده از Aspose.Slides for Python via Java اضافه کنیم. برای رفع [object preview issue](/slides/fa/python-java/object-preview-issue-when-adding-oleobjectframe/)، یک تصویر از ناحیه صفحه کاری انتخاب‌شده به فریم شی OLE اختصاص دادیم. در ارائه خروجی، وقتی بر روی فریم شی OLE که تصویر صفحه کاری را نشان می‌دهد دوبار کلیک کنید، کتاب‌کار Excel فعال می‌شود. کاربران نهایی می‌توانند تغییرات دلخواه خود را در کتاب‌کار واقعی Excel انجام دهند و سپس با کلیک خارج از کتاب‌کار فعال‌شده به اسلاید بازگردند. اندازه فریم شی OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازه فریم شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت خواهد بود.

## **دلیل تغییر اندازه**

از آنجا که کتاب‌کار Excel اندازهٔ پنجره خود را دارد، سعی می‌کند پس از اولین فعال‌سازی اندازهٔ اصلی خود را حفظ کند. از سوی دیگر، فریم شی OLE اندازهٔ خاص خود را دارد. طبق گفته مایکروسافت، زمانی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح در فرآیند جاسازی، اندازه را مذاکره می‌کنند. تغییر اندازه بر اساس تفاوت‌های بین اندازهٔ پنجره Excel و اندازه و موقعیت فریم شی OLE رخ می‌دهد.

## **راه‌حل کاری**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌بندی اندازهٔ فریم OLE در ارائه PowerPoint برای مطابقت با ارتفاع و عرض تعداد ردیف‌ها و ستون‌های موردنظر در فریم OLE.
- ثابت نگه داشتن اندازهٔ فریم OLE و مقیاس‌بندی اندازهٔ ردیف‌ها و ستون‌های مشارکت‌کننده برای تناسب با اندازهٔ فریم OLE انتخاب‌شده.

### **مقیاس‌بندی اندازهٔ فریم OLE**

در این روش، نحوه تنظیم اندازهٔ فریم OLE کتاب‌کار Excel جاسازی‌شده به‌گونه‌ای که با مجموع اندازهٔ ردیف‌ها و ستون‌های مشارکت‌کننده در برگه Excel مطابق باشد، را یاد می‌گیریم.

فرض کنید یک برگه Excel قالب داریم و می‌خواهیم آن را به‌عنوان فریم OLE به ارائه اضافه کنیم. در این سناریو، ابتدا اندازهٔ فریم شی OLE بر اساس مجموع ارتفاع ردیف‌ها و عرض ستون‌های مشارکت‌کننده در کتاب‌کار محاسبه می‌شود. سپس اندازهٔ فریم OLE را به این مقدار محاسبه‌شده تنظیم می‌کنیم. برای جلوگیری از پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین تصویری از بخش‌های مطلوب ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.

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

    # اندازه نمایش داده شده را وقتی کتاب‌کار به‌عنوان شی OLE در PowerPoint استفاده می‌شود تنظیم کنید.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # عرض و ارتفاع تصویر OLE را بر حسب نقطه دریافت کنید.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # از کتاب‌کار تغییر یافته استفاده کنید.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # تصویر OLE را به منابع ارائه اضافه کنید.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # فریم شی OLE را ایجاد کنید.
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

### **مقیاس‌بندی اندازهٔ بازهٔ سلول‌ها**

در این روش، نحوه مقیاس‌بندی ارتفاع ردیف‌های مشارکت‌کننده و عرض ستون‌های مشارکت‌کننده برای مطابقت با یک اندازهٔ سفارشی فریم OLE را می‌آموزیم.

فرض کنید یک برگه Excel قالب داریم و می‌خواهیم آن را به‌عنوان فریم OLE به ارائه اضافه کنیم. در این سناریو، اندازهٔ فریم OLE را تنظیم می‌کنیم و اندازهٔ ردیف‌ها و ستون‌هایی که در ناحیه فریم OLE مشارکت دارند را مقیاس‌بندی می‌کنیم. سپس کتاب‌کار را به‌صورت جریان ذخیره می‌کنیم تا تغییرات اعمال شود و آن را به‌یک آرایه بایت تبدیل می‌کنیم تا به فریم OLE اضافه شود. برای جلوگیری از پیام قرمز «EMBEDDED OLE OBJECT» برای فریم OLE در PowerPoint، همچنین تصویری از بخش‌های مطلوب ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و به‌عنوان تصویر فریم OLE تنظیم می‌کنیم.

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
    # عرض و ارتفاع مورد انتظار بازهٔ سلول بر حسب نقاط است.
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

    # اندازهٔ نمایش داده‌شده را هنگام استفاده از کتاب‌کار به‌عنوان شی OLE در PowerPoint تنظیم کنید.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # بازهٔ سلول را برای تناسب با اندازهٔ فریم مقیاس‌بندی کنید.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # از کتاب‌کار تغییر یافته استفاده کنید.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # تصویر OLE را به منابع ارائه اضافه کنید.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # فریم شی OLE را ایجاد کنید.
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

## **نتیجه‌گیری**

{{% alert color="info" title="توجه" %}} 

دو رویکرد برای رفع مشکل تغییر اندازه صفحه کاری وجود دارد. انتخاب رویکرد مناسب بستگی به نیازها و مورد استفاده خاص دارد. هر دو رویکرد به‌یک‌شکل عمل می‌کنند، چه ارائه‌ها از قالب ساخته شوند و چه از ابتدا. علاوه بر این، هیچ محدودیتی برای اندازهٔ فریم شی OLE در این راه‌حل وجود ندارد.

{{% /alert %}}

## **سوالات متداول**

**چرا یک صفحه کاری Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازهٔ خود را تغییر می‌دهد؟**

این به دلیل این است که Excel سعی می‌کند اندازهٔ اصلی پنجره خود را هنگام فعال‌سازی حفظ کند، در حالی که فریم شی OLE در PowerPoint ابعاد خود را دارد. PowerPoint و Excel برای حفظ نسبت ابعاد مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را کاملاً جلوگیری کرد؟**

بله. با مقیاس‌بندی فریم OLE برای متناسب شدن با اندازهٔ بازهٔ سلول‌های Excel یا مقیاس‌بندی بازهٔ سلول‌ها برای متناسب شدن با اندازهٔ فریم OLE موردنظر، می‌توان از تغییر اندازه ناخواسته جلوگیری کرد.

**کدام روش مقیاس‌بندی را باید استفاده کنم، مقیاس‌بندی فریم OLE یا مقیاس‌بندی بازهٔ سلول‌ها؟**

اگر می‌خواهید اندازهٔ ردیف‌ها و ستون‌های اصلی Excel را حفظ کنید، **مقیاس‌بندی فریم OLE** را انتخاب کنید. اگر به یک اندازهٔ ثابت برای فریم OLE در ارائه خود احتیاج دارید، **مقیاس‌بندی بازهٔ سلول‌ها** را انتخاب کنید.

**آیا این راه‌حل‌ها در صورتی که ارائه من بر پایه قالب باشد کار می‌کند؟**

بله. هر دو راه‌حل برای ارائه‌های ساخته‌شده از قالب‌ها و همچنین از ابتدا کار می‌کنند.

**آیا محدودیتی برای اندازهٔ فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید فریم شی OLE را به هر اندازه‌ای تنظیم کنید، به‌شرط آن که مقیاس را به‌درستی تنظیم کنید.

**آیا راهی برای جلوگیری از متن جایگزین «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک عکس از بازهٔ سلول هدف در Excel و تنظیم آن به‌عنوان تصویر جایگزین فریم OLE، می‌توانید یک تصویر پیش‌نمایش سفارشی به‌جای متن پیش‌فرض نمایش دهید.

## **مقالات مرتبط**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/fa/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)