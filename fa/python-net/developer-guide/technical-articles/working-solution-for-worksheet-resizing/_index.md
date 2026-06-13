---
title: راه‌حل عملی برای تغییر اندازه برگه کاری
type: docs
weight: 40
url: /fa/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- تصویر پیش‌نمایش
- تغییر اندازه تصویر
- Excel
- برگه کاری
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "رفع مشکل تغییر اندازه OLE برگه کاری اکسل در ارائه‌ها: دو روش برای حفظ ثابت بودن چارچوب‌های شی - مقیاس‌بندی چارچوب یا برگه - در فرمت‌های PPT و PPTX."
---
{{% alert color="primary" %}} 

مشاهده شده است که برگه‌های اکسل که به عنوان اشیاء OLE در یک ارائه پاورپوینت از طریق کامپوننت‌های Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار تفاوت بصری قابل‌توجهی در ارائه بین وضعیت پیش از فعال‌سازی و پس از فعال‌سازی شی OLE ایجاد می‌کند. ما این مشکل را به‌تفصیل بررسی کرده و راه‌حلی ارائه داده‌ایم که در این مقاله پوشش داده شده است.

{{% /alert %}} 

## **پیش‌زمینه**

در مقاله [مدیریت OLE](/slides/fa/python-net/manage-ole/)، توضیح دادیم چگونه می‌توان یک چارچوب OLE را به یک ارائه پاورپوینت اضافه کرد با استفاده از Aspose.Slides برای Python via .NET. برای رفع [مشکل پیش‌نمایش شیء](/slides/fa/python-net/object-preview-issue-when-adding-oleobjectframe/)، تصویری از ناحیه انتخاب‌شده برگه کاری را به چارچوب شی OLE اختصاص دادیم. در ارائه خروجی، وقتی بر روی چارچوب شی OLE که تصویر برگه کاری را نشان می‌دهد دوبار کلیک می‌کنید، کتاب‌کار اکسل فعال می‌شود. کاربران نهایی می‌توانند هر تغییری که می‌خواهند در کتاب‌کار واقعی اکسل اعمال کنند و سپس با کلیک خارج از کتاب‌کار فعال‌شده به اسلاید بازگردند. اندازه چارچوب شی OLE هنگام بازگشت کاربر به اسلاید تغییر خواهد کرد. ضریب تغییر اندازه بسته به اندازه چارچوب شی OLE و کتاب‌کار اکسل جاسازی‌شده متفاوت است. 

## **دلیل تغییر اندازه**

از آنجا که کتاب‌کار اکسل دارای اندازه پنجره خاص خود است، سعی می‌کند پس از اولین فعال‌سازی اندازه اصلی خود را حفظ کند. از سوی دیگر، چارچوب شی OLE اندازه خاص خود را دارد. بر اساس گفته مایکروسافت، زمانی که کتاب‌کار اکسل فعال می‌شود، اکسل و پاورپوینت برای اطمینان از حفظ نسبت‌های صحیح در فرآیند جاسازی، درباره‌ اندازه مذاکره می‌کنند. تغییر اندازه بر اساس اختلاف بین اندازه پنجره اکسل و اندازه و موقعیت چارچوب شی OLE انجام می‌شود.

## **راه‌حل عملی**

دو راه‌حل ممکن برای جلوگیری از اثر تغییر اندازه وجود دارد.

- مقیاس‌بندی اندازه چارچوب OLE در ارائه پاورپوینت به‌گونه‌ای که ارتفاع و عرض تعداد ردیف‌ها و ستون‌های موردنظر در چارچوب OLE مطابقت داشته باشد.  
- ثابت نگه داشتن اندازه چارچوب OLE و مقیاس‌بندی اندازه ردیف‌ها و ستون‌های مشارکت‌کننده به‌طوری که در داخل اندازه انتخاب‌شده چارچوب OLE جا بگیرند.

### **مقیاس‌بندی اندازه چارچوب OLE**

در این روش، نحوه تنظیم اندازه چارچوب OLE کتاب‌کار اکسل جاسازی‌شده را طوری که مطابق با اندازه تجمعی ردیف‌ها و ستون‌های مشارکت‌کننده در برگه کاری باشد، یاد می‌گیریم.

فرض کنید یک برگه کاری الگو داریم و می‌خواهیم آن را به‌عنوان چارچوب OLE به یک ارائه اضافه کنیم. در این سناریو، ابتدا اندازه چارچوب شی OLE بر اساس ارتفاع تجمعی ردیف‌ها و عرض تجمعی ستون‌های مشارکت‌کننده در کتاب‌کار محاسبه می‌شود. سپس اندازه چارچوب OLE را روی این مقدار محاسبه‌شده تنظیم می‌کنیم. برای حذف پیام قرمز «EMBEDDED OLE OBJECT» برای چارچوب OLE در پاورپوینت، همچنین عکسی از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به‌عنوان تصویر چارچوب OLE تنظیم می‌کنیم.

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

    # اندازه نمایش داده شده را وقتی فایل کتاب‌کار به عنوان شی OLE در PowerPoint استفاده می‌شود تنظیم می‌کند.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # عرض و ارتفاع تصویر OLE را به نقطه (points) دریافت می‌کند.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # ما باید از کتاب‌کار تغییر یافته استفاده کنیم.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # تصویر OLE را به منابع ارائه اضافه می‌کند.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # قاب شی OLE را ایجاد می‌کند.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **مقیاس‌بندی اندازه بازه سلول‌ها**

در این روش، نحوه مقیاس‌بندی ارتفاع ردیف‌های مشارکت‌کننده و عرض ستون‌های مشارکت‌کننده به‌گونه‌ای که با یک اندازه سفارشی چارچوب OLE مطابقت داشته باشد، یاد می‌گیریم.

فرض کنید یک برگه کاری الگو داریم و می‌خواهیم آن را به‌عنوان چارچوب OLE به یک ارائه اضافه کنیم. در این سناریو، اندازه چارچوب OLE را تنظیم می‌کنیم و اندازه ردیف‌ها و ستون‌های مشارکت‌کننده در ناحیه چارچوب OLE را مقیاس‌بندی می‌کنیم. سپس کتاب‌کار را به‌صورت جریان (stream) ذخیره می‌کنیم تا تغییرات اعمال شوند و به‌صورت آرایه بایت برای افزودن به چارچوب OLE تبدیل می‌کنیم. برای حذف پیام قرمز «EMBEDDED OLE OBJECT» برای چارچوب OLE در پاورپوینت، همچنین عکسی از بخش‌های موردنظر ردیف‌ها و ستون‌ها در کتاب‌کار می‌گیریم و آن را به‌عنوان تصویر چارچوب OLE تنظیم می‌کنیم.

```py
# <param name="width">عرض مورد انتظار بازه سلولی به نقطه.</param>
# <param name="height">ارتفاع مورد انتظار بازه سلولی به نقطه.</param>
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

    # اندازه نمایش داده شده را وقتی فایل کتاب‌کار به عنوان شی OLE در PowerPoint استفاده می‌شود تنظیم می‌کند.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # محدوده سلولی را برای متناسب شدن با اندازه قاب مقیاس‌بندی می‌کند.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # ما باید از کتاب‌کار تغییر یافته استفاده کنیم.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # تصویر OLE را به منابع ارائه اضافه می‌کند.
            ole_image = presentation.images.add_image(image_stream)

            # قاب شی OLE را ایجاد می‌کند.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **نتیجه‌گیری**

{{% alert color="primary" %}}

دو رویکرد برای رفع مشکل تغییر اندازه برگه کاری وجود دارد. انتخاب رویکرد مناسب بستگی به نیازها و موارد استفاده خاص دارد. هر دو رویکرد به‌یک شکل کار می‌کنند، چه ارائه‌ها از قالبی ساخته شوند و چه از ابتدا. علاوه بر این، در این راه‌حل هیچ محدودیتی برای اندازه چارچوب شی OLE وجود ندارد.

{{% /alert %}}