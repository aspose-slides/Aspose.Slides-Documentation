---
title: ایجاد نمودارهای Excel و جاسازی آن‌ها در ارائه‌ها به‌عنوان اشیاء OLE
type: docs
weight: 30
url: /fa/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شیء OLE
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: یک نمودار Excel را با Aspose.Cells برای Python از طریق Java ایجاد کنید و کتاب‌کار را در یک ارائه PowerPoint با Aspose.Slides جاسازی کنید، شامل پیش‌نمایش نمودار.
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه یک نمودار ستونی اکسل با Aspose.Cells برای Python از طریق Java ایجاد کرده و کتاب‌کار آن را در یک ارائه PowerPoint با Aspose.Slides برای Python از طریق Java جاسازی کنید. کتاب‌کار جاسازی‌شده شامل داده‌های منبع و نمودار است. یک پیش‌نمایش PNG جداگانه نمودار را بر روی اسلاید قبل از فعال‌سازی شی OLE نمایش می‌دهد.

نتیجه یک شیء Excel جاسازی‌شده است، نه یک نمودار بومی PowerPoint. ویرایش کتاب‌کار از طریق OLE به یک برنامه دسکتاپ که از فعال‌سازی OLE پشتیبانی می‌کند و یک نصب Excel سازگار نیاز دارد.

## **پیش‌نیازها**

پکیج‌های Python `aspose-cells` و `aspose-slides-java` و یک محیط اجرایی Java سازگار را نصب کنید. هر دو پکیج را قبل از شروع JVM وارد کنید تا کتابخانه‌های Java آن‌ها برای JPype در دسترس باشند. برای تولید ارائه با این کتابخانه‌ها Microsoft Office لازم نیست.

هیچ فایل ورودی‌ای لازم نیست: مثال داده‌ها و نمودار را در حافظه ایجاد می‌کند، سپس `OutputChart.pptx` را در پوشهٔ کاری فعلی می‌نویسد. هنگام اجرای برنامه خارج از حالت ارزیابی، برای هر دو محصول لایسنس اعمال کنید.

## **نحوهٔ کار جاسازی**

1. یک کتاب‌کار با یک کاربرگ داده و یک شیت نمودار ایجاد کنید.
2. شیت نمودار را فعال کنید تا کتاب‌کار بر روی نمودار باز شود.
3. محدوده نمایش OLE کتاب‌کار را تنظیم کرده و نمودار را به PNG رندر کنید.
4. کتاب‌کار را به صورت XLSX در حافظه ذخیره کنید و آن بایت‌ها را در یک اسلاید جاسازی کنید.
5. PNG را به عنوان پیش‌نمایش شیء OLE اختصاص دهید و ارائه را به صورت PPTX ذخیره کنید.

محدوده نمایش کتاب‌کار و قاب اسلاید نقش‌های متفاوتی دارند. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) شاخص‌های ردیف و ستون شروع/پایان را به صورت صفر-محور می‌گیرد. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) در عوض ردیف بالایی، ستون چپ، ردیف پایینی و ستون راست را می‌گیرد. در این مثال، شاخص ردیف 55 و شاخص ستون 25 به عنوان مرزهای پایین‑راست استفاده شده‌اند؛ این مقادیر انتخاب‌های چیدمانی هستند، نه تعداد ردیف‌ها یا ستون‌های داده.

قاب اسلاید از نقاط (points) استفاده می‌کند. این مثال آن را در داخل اسلاید قرار می‌دهد و در مرکز می‌چسباند در حالی که نسبت تصویری PNG را حفظ می‌کند، به‌جای کشیدن پیش‌نمایش برای پر کردن کل اسلاید.

## **ایجاد و جاسازی نمودار**

مثال کامل زیر `DataSheet` را با چهار ردیف و پنج ستون مقادیر پر می‌کند. هر ردیف تبدیل به یک سری نموداری می‌شود. قبل از ذخیره کتاب‌کار، `ChartSheet` به عنوان شیت فعال انتخاب می‌شود.

کتاب‌کار به‌صورت صریح به عنوان XLSX ذخیره می‌شود، به‌طوری که پسوند `xlsx` که به [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) پاس داده می‌شود مطابقت داشته باشد. جریان‌های بایت‌آرایه‌ای جاوا کتاب‌کار و تصویر را در حافظه نگه می‌دارند و آرایه‌های بایتی مورد نیاز APIهای جاوا را فراهم می‌کنند. PNG مستقیماً از بایت‌های خود بدون تبدیل بیتی‌مپ میانه‌ای بارگیری می‌شود. اختصاص آن از طریق [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) جایگزین تصویر پیش‌فرض OLE می‌شود.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # پیش‌نمایش نمودار را رندر کنید و کتاب‌کار قابل ویرایش را به‌صورت جداگانه سریال‌سازی کنید.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # پیش‌نمایش را در اسلاید جاگذاری کنید بدون تغییر نسبت ابعاد.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **نتیجهٔ مورد انتظار**

`OutputChart.pptx` شامل یک اسلاید با یک کتاب‌کار Excel جاسازی‌شده و یک پیش‌نمایش نمودار است. کتاب‌کار شامل داده‌های اصلی و یک نمودار ستونی با چهار سری است. پیش‌نمایش در مرکز اسلاید قرار گرفته و نسبت‌های خود را حفظ می‌کند.

![نمودار ستونی اکسل نمایش داده شده به‌عنوان پیش‌نمایش کتاب‌کار جاسازی‌شده](excel-chart-ole-preview.png)

در یک محیط دسکتاپ PowerPoint سازگار که Excel در دسترس باشد، روی شیء دوبار کلیک کنید تا کتاب‌کار جاسازی‌شده فعال و ویرایش شود. فعال‌سازی و ویرایش به پشتیبانی OLE برنامهٔ میزبان و تنظیمات امنیتی آن وابسته است.

## **سوالات متداول**

**چرا تصویر پیش‌نمایش مورد نیاز است؟**

کتاب‌کار جاسازی‌شده و پیش‌نمایش اسلاید آن محتواهای جداگانه‌ای هستند. یک تصویر نمودار فراهم کنید تا اسلاید به‌جای جای‌گیر پیش‌فرض "EMBEDDED OLE OBJECT"، نمودار را نمایش دهد. See [Object Preview Issue when Adding OleObjectFrame](/slides/fa/python-java/object-preview-issue-when-adding-oleobjectframe/).

**آیا پیش‌نمایش به‌صورت خودکار هنگام تغییر کتاب‌کار در کد به‌روز می‌شود؟**

پیش‌نمایش را به‌عنوان یک تصویر ثابت در نظر بگیرید. هنگام به‌روزرسانی داده‌های کتاب‌کار به‌صورت برنامه‌نویسی، تصویر نمودار را دوباره تولید کنید و پیش‌نمایش و همچنین داده‌های کتاب‌کار جاسازی‌شده را جایگزین کنید.

**آیا می‌توانم به‌جای XLSX از XLS استفاده کنم؟**

بله. کتاب‌کار را با فرمت XLS ذخیره کنید و از پسوند `xls` به‌عنوان پسوند دادهٔ جاسازی‌شده استفاده کنید. پسوند باید با فرمت واقعی کتاب‌کار مطابقت داشته باشد؛ صرفاً تغییر پسوند باعث تبدیل داده‌ها نمی‌شود.

**چرا ممکن است پس از فعال‌سازی اندازهٔ شیء تغییر کند؟**

برنامهٔ میزبان می‌تواند هنگام فعال‌سازی کتاب‌کار، نمایش شیء OLE را به‌روز کند. هر دو محدوده نمایش OLE کتاب‌کار و ابعاد قاب اسلاید مهم هستند. ببینید [Working Solution for Chart Resizing in PPTX](/slides/fa/python-java/working-solution-for-chart-resizing-in-pptx/).

## **بخش‌های مرتبط**

- [راه‌حل کارا برای تغییر اندازهٔ نمودار در PPTX](/slides/fa/python-java/working-solution-for-chart-resizing-in-pptx/)
- [مسئله پیش‌نمایش شیء هنگام افزودن OleObjectFrame](/slides/fa/python-java/object-preview-issue-when-adding-oleobjectframe/)