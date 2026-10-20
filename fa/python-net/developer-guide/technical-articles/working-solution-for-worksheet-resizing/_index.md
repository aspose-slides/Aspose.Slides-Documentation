---
title: راه‌حل عملی برای تغییر اندازه برگه کاری
type: docs
weight: 40
url: /fa/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- اکسل
- برگه کاری
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "رفع تغییر اندازه OLE برگه کاری Excel در ارائه‌ها: دو روش برای حفظ ثبات فریم‌های شیء—مقیاس‌گذاری فریم یا برگه—در فرمت‌های PPT و PPTX."
---
{{% alert color="info" title="Note" %}}
برگه‌های Excel که به عنوان اشیاء OLE در یک ارائه PowerPoint با استفاده از اجزای Aspose جاسازی می‌شوند، ممکن است پس از اولین فعال‌سازی به‌طور غیرمنتظره‌ای اندازه‌شان تغییر کند. این رفتار تفاوت بصری قابل‌مشاهده‌ای بین شیء OLE قبل و بعد از فعال‌سازی ایجاد می‌کند. این مقاله مشکل را توضیح می‌دهد و دو روش برای رفع آن را شرح می‌دهد.
{{% /alert %}} 

## **پیش‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/python-net/manage-ole/)، ما توضیح دادیم که چگونه یک فریم OLE را به یک ارائه PowerPoint با استفاده از Aspose.Slides برای Python از طریق .NET اضافه کنیم. برای رفع [مسئله پیش‌نمایش شیء](/slides/fa/python-net/object-preview-issue-when-adding-oleobjectframe/)، یک تصویر از ناحیه انتخاب شده برگه کاری به فریم شیء OLE اختصاص دادیم. در ارائه خروجی، هنگامی که فریم شیء OLE که تصویر برگه کاری را نمایش می‌دهد، دوبار کلیک می‌شود، کتاب‌کار Excel فعال می‌شود. کاربران نهایی می‌توانند هر تغییر موردنظر خود را در کتاب‌کار واقعی Excel اعمال کرده و سپس با کلیک کردن خارج از کتاب‌کار فعال شده به اسلاید بازگردند. اندازه فریم شیء OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. عامل تغییر اندازه بسته به اندازه فریم شیء OLE و کتاب‌کار Excel جاسازی‌شده متفاوت خواهد بود.

## **دلیل تغییر اندازه**

از آنجا که کتاب‌کار Excel اندازهٔ پنجرهٔ خاص خود را دارد، سعی می‌کند پس از اولین فعال‌سازی، اندازهٔ اصلی خود را حفظ کند. از سوی دیگر، فریم شیء OLE اندازهٔ خاص خود را دارد. بر اساس گفته مایکروسافت، هنگامی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای اطمینان از حفظ نسبت‌های صحیح به‌عنوان بخشی از فرآیند جاسازی، اندازه را مذاکره می‌کنند. تغییر اندازه بر اساس اختلاف بین اندازهٔ پنجرهٔ Excel و اندازه و موقعیت فریم شیء OLE رخ می‌دهد.

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌گذاری فریم OLE در ارائه PowerPoint به‌طوری که ارتفاع و عرض کلی ردیف‌ها و ستون‌های انتخاب‌شده را تطبیق دهد.
- حجم فریم OLE را ثابت نگه داشته و ردیف‌ها و ستون‌های انتخاب‌شده را مقیاس‌گذاری کنید تا درون آن جای بگیرد.

### **مقیاس‌گذاری اندازه فریم OLE**

این روش اندازه فریم OLE را به‌گونه‌ای تنظیم می‌کند که ارتفاع و عرض کلی ردیف‌ها و ستون‌های انتخاب‌شده در برگه‌ی Excel جاسازی‌شده را مطابقت دهد.

مثال یک کتاب‌کار Excel موجود را بارگیری می‌کند و اولین 10 ردیف و 13 ستون از برگهٔ اول آن را با استفاده از اندیس‌های صفر-پایه انتخاب می‌نماید. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) بازهٔ نمایش داده‌شده را تعریف می‌کند. پیش‌نمایش با 96 DPI رندر می‌شود و ابعاد پیکسلی آن با 72 نقطه در اینچ به نقطه تبدیل می‌شود. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) کتاب‌کار اصلاح‌شده را در فریمی با آن ابعاد جاسازی می‌کند. پیش‌نمایش از طریق [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) برای جایگزینی متن نگهدارنده «EMBEDDED OLE OBJECT» در ارائه ذخیره‌شده اختصاص داده می‌شود.

کمک‌کننده پیش‌نمایش [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) را به بازهٔ انتخاب‌شده تنظیم می‌کند و حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌نماید. با فعال‌سازی [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/)، [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) بازه را به صورت تصویر PNG رندر می‌کند. کمک‌کننده قبل از بازگرداندن برای استفاده در ارائه، جریان تصویر را به ابتدای خود باز می‌گرداند.

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

مثال کامل زیر helperها را با جاسازی کتاب‌کار ترکیب می‌کند و ارائه را به‌عنوان `output.pptx` ذخیره می‌نماید.

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

    # تنظیم اندازه‌ی نمایش‌داده‌شده وقتی فایل کتاب‌کار به‌عنوان شیء OLE در PowerPoint استفاده می‌شود.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # دریافت عرض و ارتفاع تصویر OLE به‌واحد نقطه.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # ما باید از کتاب‌کار اصلاح‌شده استفاده کنیم.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # اضافه کردن تصویر OLE به منابع ارائه.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # ایجاد فریم شیء OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **مقیاس‌گذاری اندازهٔ محدودهٔ سلول**

این روش ارتفاع ردیف‌های انتخاب‌شده و عرض ستون‌های انتخاب‌شده را مقیاس‌گذاری می‌کند تا با یک اندازهٔ سفارشی فریم OLE مطابقت داشته باشد.

مثال یک کتاب‌کار Excel موجود را بارگیری کرده و اولین 10 ردیف و 13 ستون از برگهٔ اول آن را با استفاده از اندیس‌های صفر-پایه انتخاب می‌کند. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) بازهٔ نمایش داده‌شده را تعریف می‌کند و helper زیر آن بازه را برای متناسب شدن با فریمی به عرض 400 نقطه و ارتفاع 100 نقطه مقیاس‌گذاری می‌کند. پس از ذخیره‌سازی کتاب‌کار اصلاح‌شده به یک جریان، [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) آن را با اندازهٔ مشخص شده جاسازی می‌کند. پیش‌نمایشی که با 96 DPI رندر شده از طریق [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) اختصاص می‌یابد، بنابراین ارائه ذخیره‌شده سلول‌های انتخاب‌شده را به‌جای نگهدارندهٔ پیش‌فرض نمایش می‌دهد.

helper مقیاس‌گذاری نسبت‌های عرض و ارتفاع جداگانه برای بازهٔ انتخاب‌شده را محاسبه می‌کند، در حالی که عرض نسبی ستون‌ها و ارتفاع نسبی ردیف‌ها را حفظ می‌کند. ابعاد محاسبه‌شده را از نقطه به اینچ تبدیل می‌کند قبل از اعمال آنها با [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) و [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). بازهٔ انتخاب‌شده باید عرض و ارتفاع غیرصفر داشته باشد.

```py
import aspose.cells as cells

# <param name="width">عرض مورد انتظار بازه سلول به نقطه.</param>
# <param name="height">ارتفاع مورد انتظار بازه سلول به نقطه.</param>
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

این helper پیش‌نمایش بازهٔ تغییر اندازه داده‌شده را با استفاده از [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) رندر می‌کند. [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) را به آن بازه محدود می‌نماید، حاشیه‌ها، سرصفحه‌ها و پاورقی‌ها را حذف می‌کند و یک جریان PNG که در ابتدا قرار دارد را برمی‌گرداند.

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

مثال کامل زیر helperها را با جاسازی کتاب‌کار ترکیب می‌کند و ارائه را به‌عنوان `output.pptx` ذخیره می‌نماید.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">عرض مورد انتظار بازه سلول به نقطه.</param>
# <param name="height">ارتفاع مورد انتظار بازه سلول به نقطه.</param>
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

    # تنظیم اندازه‌ی نمایش‌داده‌شده وقتی فایل کتاب‌کار به‌عنوان شیء OLE در PowerPoint استفاده می‌شود.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # مقیاس‌گذاری بازه سلول برای متناسب شدن با اندازه فریم.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # ما باید از کتاب‌کار اصلاح‌شده استفاده کنیم.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # اضافه کردن تصویر OLE به منابع ارائه.
            ole_image = presentation.images.add_image(image_stream)

            # ایجاد فریم شیء OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **نتیجه‌گیری**

{{% alert color="info" title="Note" %}}
دو رویکرد برای رفع مشکل تغییر اندازه برگه وجود دارد. رویکردی را انتخاب کنید که بهترین تطابق را با نیازها و موارد استفاده شما داشته باشد. هر دو رویکرد به‌طور یکسان کار می‌کنند، چه ارائه‌ها از یک الگو ساخته شده باشند و چه از ابتدا. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازهٔ فریم شیء OLE وجود ندارد.
{{% /alert %}}

## **سوالات متداول**

**چرا یک برگه‌کار Excel جاسازی‌شده هنگام اولین فعال‌سازی در PowerPoint اندازه‌اش را تغییر می‌دهد؟**

این به این دلیل رخ می‌دهد که Excel سعی می‌کند هنگام فعال‌سازی، اندازهٔ اصلی پنجره را حفظ کند، در حالی که فریم شیء OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel برای حفظ نسبت ابعاد مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل پیشگیری کرد؟**

بله. با مقیاس‌گذاری فریم OLE به‌گونه‌ای که متناسب با اندازهٔ محدودهٔ سلول‌های Excel باشد یا مقیاس‌گذاری محدودهٔ سلول‌ها به‌گونه‌ای که با اندازهٔ دلخواه فریم OLE متناسب شود، می‌توانید از تغییر اندازه ناخواسته جلوگیری کنید.

**کدام روش مقیاس‌گذاری را باید استفاده کنم، مقیاس‌گذاری فریم OLE یا مقیاس‌گذاری محدودهٔ سلول؟**

اگر می‌خواهید اندازهٔ اصلی سطرها و ستون‌های Excel را حفظ کنید، **OLE frame scaling** را انتخاب کنید. اگر به یک اندازهٔ ثابت برای فریم OLE در ارائه خود نیاز دارید، **cell range scaling** را انتخاب کنید.

**آیا این راه‌حل‌ها در صورتی که ارائه من بر پایه یک الگو باشد، کار می‌کنند؟**

بله. هر دو راه‌حل برای ارائه‌هایی که از الگوها ایجاد شده‌اند و همچنین از ابتدا ساخته می‌شوند، کار می‌کنند.

**آیا محدودیتی برای اندازهٔ فریم OLE هنگام استفاده از این روش‌ها وجود دارد؟**

خیر. می‌توانید فریم شیء OLE را به هر اندازه‌ای بسازید تا زمانی که مقیاس را به‌طور مناسب تنظیم کنید.

**آیا راهی برای جلوگیری از متن نگهدارنده «EMBEDDED OLE OBJECT» در PowerPoint وجود دارد؟**

بله. با گرفتن یک تصویر از محدودهٔ سلول هدف در Excel و تنظیم آن به‌عنوان تصویر نگهدارنده فریم OLE، می‌توانید به‌جای نگهدارندهٔ پیش‌فرض یک تصویر پیش‌نمایش سفارشی نمایش دهید.