---
title: راه‌حل عملی برای تغییر اندازه ورق کاری
type: docs
weight: 20
url: /fa/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- ورق کاری
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "رفع مشکل تغییر اندازه OLE ورق کاری Excel در ارائه‌ها: دو روش برای حفظ یکنواختی فریم‌های شی—مقیاس‌بندی فریم یا شیت—در فرمت‌های PPT و PPTX."
---
{{% alert color="info" title="Note" %}}

ورق‌های Excel که به‌عنوان اشیاء OLE در ارائه PowerPoint با استفاده از مؤلفه‌های Aspose تعبیه می‌شوند، ممکن است پس از اولین فعال‌سازی به‌صورت غیرمنتظره اندازه خود را تغییر دهند. این رفتار تفاوت بصری مشهودی بین شی OLE قبل و بعد از فعال‌سازی ایجاد می‌کند. این مقاله مشکل را توضیح می‌دهد و دو روش برای رفع آن را شرح می‌دهد.

{{% /alert %}}

## **پیش‌زمینه**

در مقاله [Manage OLE](/slides/fa/python-java/manage-ole/) توضیح دادیم که چگونه یک فریم OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides for Python via Java اضافه کنیم. برای رفع [object preview issue](/slides/fa/python-java/object-preview-issue-when-adding-oleobjectframe/) تصویری از ناحیه انتخاب‌شده ورق کاری را به فریم شی OLE اختصاص دادیم. در ارائه خروجی، هنگامی که فریم شی OLE که تصویر ورق کاری را نمایش می‌دهد دو بار کلیک می‌شود، کتاب‌کار Excel فعال می‌شود. کاربران نهایی می‌توانند هر تغییر دلخواهی را در کتاب‌کار واقعی انجام دهند و سپس با کلیک خارج از کتاب‌کار فعال به اسلاید بازگردند. اندازه فریم شی OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. ضریب تغییر اندازه بسته به اندازه فریم شی OLE و کتاب‌کار Excel تعبیه‌شده متفاوت خواهد بود.

## **دلیل تغییر اندازه**

از آنجا که کتاب‌کار Excel دارای اندازه پنجره خودش است، سعی می‌کند پس از اولین فعال‌سازی اندازهٔ اصلی خود را حفظ کند. از سوی دیگر، فریم شی OLE اندازهٔ خود را دارد. بر اساس گفته مایکروسافت، هنگامی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح در فرآیند تعبیه، اندازه را مذاکره می‌کنند. تغییر اندازه بر اساس اختلافات بین اندازهٔ پنجره Excel و اندازه و موقعیت فریم شی OLE رخ می‌دهد.

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌بندی فریم OLE در ارائه PowerPoint برای مطابقت با کل ارتفاع و عرض ردیف‌ها و ستون‌های انتخاب‌شده.
- حفظ اندازه ثابت فریم OLE و مقیاس‌بندی ردیف‌ها و ستون‌های انتخاب‌شده برای جا شدن در داخل آن.

### **مقیاس‌بندی اندازه فریم OLE**

این رویکرد اندازه فریم OLE را طوری تنظیم می‌کند که کل ارتفاع و عرض ردیف‌ها و ستون‌های انتخاب‌شده در ورق کاری Excel تعبیه‌شده را مطابقت دهد.

مثال یک کتاب‌کار Excel موجود را بارگذاری می‌کند و اولین ۱۰ ردیف و ۱۳ ستون اولین ورق کاری آن را با استفاده از شاخص‌های صفر-پایه انتخاب می‌نماید. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) محدودهٔ نمایش داده‌شده را تعریف می‌کند. پیش‌نمایش با ۹۶ DPI رندر می‌شود و ابعاد پیکسلی آن با استفاده از ۷۲ پوینت بر اینچ به پوینت تبدیل می‌شود. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) کتاب‌کار اصلاح‌شده را در یک فریم با آن ابعاد تعبیه می‌کند. پیش‌نمایش از طریق [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) اختصاص یافته تا جایگزین متن نگه‌دارندهٔ «EMBEDDED OLE OBJECT» در ارائهٔ ذخیره‌شده شود.

کمک‌کنندهٔ پیش‌نمایش [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) را برای محدودهٔ انتخاب‌شده تنظیم می‌کند و حاشیه‌ها، سرصفحه‌ها و پاصفحه‌ها را حذف می‌نماید. با فعال بودن [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea)، [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) محدوده را به‌صورت تصویر PNG رندر می‌کند. این کمک‌کننده یک جریان ورودی جدید حاوای تصویر PNG برمی‌گرداند که در ابتدای خود موقعیت‌گذاری شده تا در ارائه استفاده شود.

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

    # اندازهٔ نمایش داده‌شده را زمانی که کتاب‌کار به‌عنوان شی OLE در PowerPoint استفاده می‌شود تنظیم کنید.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # عرض و ارتفاع تصویر OLE را بر حسب پوینت دریافت کنید.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # از کتاب‌کار اصلاح‌شده استفاده کنید.
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

### **مقیاس‌بندی اندازه بازه سلولی**

این رویکرد ارتفاع ردیف‌های انتخاب‌شده و عرض ستون‌های انتخاب‌شده را طوری مقیاس‌بندی می‌کند که با اندازهٔ سفارشی فریم OLE مطابقت داشته باشد.

مثال یک کتاب‌کار Excel موجود را بارگذاری می‌کند و اولین ۱۰ ردیف و ۱۳ ستون اولین ورق کاری آن را با استفاده از شاخص‌های صفر-پایه انتخاب می‌نماید. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) محدودهٔ نمایش داده‌شده را تعریف می‌کند و کمک‌کنندهٔ scale_cell_range آن محدوده را برای متناسب شدن با فریمی به عرض ۴۰۰ پوینت و ارتفاع ۱۰۰ پوینت مقیاس‌بندی می‌کند. پس از ذخیرهٔ کتاب‌کار اصلاح‌شده در یک جریان، [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) آن را با اندازهٔ مشخص‌شده تعبیه می‌کند. پیش‌نمایشی که با ۹۶ DPI رندر شده از طریق [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) اختصاص یافته تا در ارائهٔ ذخیره‌شده به‌جای نگه‌دارندهٔ پیش‌فرض نشان داده شود.

کمک‌کنندهٔ مقیاس‌بندی نسبت‌های عرض و ارتفاع جداگانه‌ای برای محدودهٔ انتخاب‌شده محاسبه می‌کند تا عرض نسبی ستون‌ها و ارتفاع نسبی ردیف‌ها حفظ شود. ابعاد محاسبه‌شده را قبل از اعمال با [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) و [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) از پوینت به اینچ تبدیل می‌کند. محدودهٔ انتخاب‌شده باید عرض و ارتفاع غیرصفر داشته باشد.

این کمک‌کنندهٔ پیش‌نمایش بازهٔ تغییر اندازه‌داده‌شده را با استفاده از [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) رندر می‌کند. [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) را به همان محدوده محدود می‌نماید، حاشیه‌ها، سرصفحه‌ها و پاصفحه‌ها را حذف می‌کند و یک جریان PNG که در ابتدای خود موقعیت‌گذاری شده برمی‌گرداند.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

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
    # عرض و ارتفاع مورد انتظار بازهٔ سلولی بر حسب پوینت است.
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

    # اندازهٔ نمایش داده‌شده را زمانی که کتاب‌کار به‌عنوان شی OLE در PowerPoint استفاده می‌شود تنظیم کنید.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # بازهٔ سلولی را برای متناسب شدن با اندازهٔ فریم مقیاس‌بندی کنید.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # از کتاب‌کار اصلاح‌شده استفاده کنید.
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

{{% alert color="info" title="Note" %}} 

دو رویکرد برای رفع مشکل تغییر اندازهٔ ورق کاری وجود دارد. رویکردی را انتخاب کنید که بهترین تطابق را با نیازها و سناریوی استفاده شما داشته باشد. هر دو رویکرد به‌یک‌نحو کار می‌کنند، چه ارائه‌ها از قالب ایجاد شوند و چه از ابتدا. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازهٔ فریم شی OLE وجود ندارد.

{{% /alert %}}

## **سوالات متداول**

**چرا یک ورق کاری Excel تعبیه‌شده هنگام اولین فعال‌سازی در PowerPoint اندازه‌اش تغییر می‌کند؟**

این به این دلیل است که Excel سعی می‌کند اندازهٔ اصلی پنجره را حفظ کند، در حالی که فریم شی OLE در PowerPoint ابعاد مخصوص خود را دارد. PowerPoint و Excel برای حفظ نسبت تصویر مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟**

بله. با مقیاس‌بندی فریم OLE برای متناسب شدن با اندازهٔ بازهٔ سلولی Excel یا مقیاس‌بندی بازهٔ سلولی برای متناسب شدن با اندازهٔ دلخواه فریم OLE، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌بندی را باید استفاده کنم، مقیاس‌بندی فریم OLE یا مقیاس‌بندی بازهٔ سلولی؟**

اگر می‌خواهید اندازهٔ ردیف‌ها و ستون‌های اصلی Excel را حفظ کنید، **مقیاس‌بندی فریم OLE** را انتخاب کنید. اگر نیاز به اندازهٔ ثابت برای فریم OLE در ارائه‌تان دارید، **مقیاس‌بندی بازهٔ سلولی** را انتخاب کنید.

**آیا این راه‌حل‌ها در صورتی که ارائه من بر پایهٔ یک قالب باشد کار می‌کنند؟**

بله. هر دو راه‌حل برای ارائه‌های ایجاد‌شده از قالب‌ها و همچنین از ابتدا کار می‌کنند.

**آیا محدودیتی برای اندازهٔ فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید فریم شی OLE را به هر اندازه‌ای تنظیم کنید، به‌شرط اینکه مقیاس را به‌درستی تنظیم کنید.

**آیا راهی برای حذف متن نگه‌دارندهٔ «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک تصویر از بازهٔ سلولی هدف Excel و تنظیم آن به‌عنوان تصویر نگه‌دارندهٔ فریم OLE، می‌توانید به‌جای نگه‌دارندهٔ پیش‌فرض، یک تصویر پیش‌نمایش سفارشی نمایش دهید.

## **مقالات مرتبط**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/fa/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)