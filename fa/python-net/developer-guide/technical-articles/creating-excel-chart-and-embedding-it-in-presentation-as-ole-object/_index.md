---
title: ایجاد نمودارهای Excel و جاسازی آن‌ها در ارائه‌ها به‌عنوان اشیاء OLE
type: docs
weight: 50
url: /fa/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شی OLE
- PowerPoint
- ارائه
- Python
- Python از طریق .NET
- Aspose.Slides
description: "یک نمودار Excel با Aspose.Cells for Python via .NET ایجاد کنید و کتاب کار را در یک ارائه PowerPoint با Aspose.Slides جاسازی کنید، به همراه پیش‌نمایش نمودار."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه یک نمودار ستونی Excel را با Aspose.Cells for Python via .NET ایجاد کنید و کتاب کار آن را در یک ارائه PowerPoint با Aspose.Slides for Python via .NET جاسازی کنید. کتاب کار جاسازی شده هم داده‌های منبع و هم نمودار را شامل می‌شود. یک پیش‌نمایش PNG جداگانه، نمودار را روی اسلاید قبل از فعال شدن شی OLE نمایش می‌دهد.

نتیجه یک شیء Excel جاسازی شده است، نه یک نمودار بومی PowerPoint. ویرایش کتاب کار از طریق OLE نیاز به یک برنامه دسکتاپ دارد که از فعال‌سازی OLE پشتیبانی کرده و یک نصب سازگار Excel داشته باشد.

## **پیش‌نیازها**

پکیج‌های `aspose-cells-python` و `aspose-slides` را در محیط Python خود نصب کنید. برای تولید ارائه با این کتابخانه‌ها نیازی به Microsoft Office نیست.

فایلی به‌عنوان ورودی لازم نیست: مثال داده‌ها و نمودار را در حافظه ایجاد می‌کند، سپس `OutputChart.pptx` را در پوشه کاری فعلی می‌نویسد. هنگام اجرا خارج از حالت ارزیابی، لایسنس‌های هر دو محصول را اعمال کنید.

## **نحوه کار ایمبدینگ**

1. یک کتاب کار با یک برگه داده و یک برگه نمودار ایجاد کنید.
2. برگه نمودار را فعال کنید تا کتاب کار روی نمودار باز شود.
3. محدوده نمایش OLE کتاب کار را تنظیم کنید و نمودار را به PNG رندر کنید.
4. کتاب کار را به صورت XLSX در حافظه ذخیره کنید و آن بایت‌ها را در یک اسلاید جاسازی کنید.
5. PNG را به عنوان پیش‌نمایش شی OLE اختصاص دهید و ارائه را به صورت PPTX ذخیره کنید.

محدوده نمایش کتاب کار و چارچوب اسلاید نقش‌های متفاوتی دارند. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) شروع/پایان ردیف و ستون را به صورت صفرمحور می‌گیرد. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) به جای آن، ردیف بالا، ستون چپ، ردیف پایین و ستون راست را می‌گیرد. مثال از شاخص ردیف 55 و شاخص ستون 25 به عنوان مرزهای پایین‑راست استفاده می‌کند؛ این مقادیر تنها انتخاب‌های چیدمان هستند، نه تعداد ردیف‌ها یا ستون‌های داده.

چارچوب اسلاید بر حسب نقطه (points) است. مثال آن را درون اسلاید قرار می‌دهد و وسط‌چین می‌کند در حالی که نسبت تصویر PNG حفظ می‌شود، به‌جای کشیدن پیش‌نمایش برای پر کردن اسلاید.

## **ایجاد و درج نمودار**

مثال کامل زیر، `DataSheet` را با چهار ردیف و پنج ستون مقدار پر می‌کند. هر ردیف تبدیل به یک سری نمودار می‌شود. قبل از ذخیره کتاب کار، `ChartSheet` به‌عنوان برگه فعال انتخاب می‌شود.

کتاب کار به‌صورت صریح به XLSX ذخیره می‌شود، مطابق با پسوند `xlsx` که به [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) داده می‌شود. PNG مستقیماً از جریان خود بارگذاری می‌شود بدون تبدیل به bitmap میانی. اختصاص آن از طریق [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) جایگزین نماینده پیش‌فرض OLE می‌شود.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# رندر پیش‌نمایش نمودار و سریالیزه کردن کتاب کار قابل ویرایش به‌صورت جداگانه.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # پیش‌نمایش را درون اسلاید قرار بده بدون تغییر نسبت تصویر.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **نتیجه مورد انتظار**

`OutputChart.pptx` حاوی یک اسلاید با یک کتاب کار Excel جاسازی شده و پیش‌نمایش نمودار است. کتاب کار شامل داده‌های اصلی و یک نمودار ستونی با چهار سری است. پیش‌نمایش در وسط اسلاید قرار گرفته و نسبت‌ها را حفظ می‌کند.

![نمودار ستونی Excel که به عنوان پیش‌نمایش یک کتاب کار امبد شده نمایش داده می‌شود](excel-chart-ole-preview.png)

در یک محیط دسکتاپ PowerPoint سازگار که Excel در دسترس باشد، با دوبار کلیک روی شیء آن را فعال و کتاب کار جاسازی شده را ویرایش کنید. فعال‌سازی و ویرایش بسته به پشتیبانی OLE برنامه میزبان و تنظیمات امنیتی آن است.

## **سوالات متداول**

**چرا تصویر پیش‌نمایش لازم است؟**

کتاب کار جاسازی شده و پیش‌نمایش اسلاید آن محتواهای جداگانه‌ای هستند. برای اینکه اسلاید نمودار را به جای جایگزین پیش‌فرض "EMBEDDED OLE OBJECT" نمایش دهد، یک تصویر نمودار فراهم کنید. به [مسئله پیش‌نمایش شیء هنگام افزودن OleObjectFrame](/slides/fa/python-net/object-preview-issue-when-adding-oleobjectframe/) مراجعه کنید.

**آیا پیش‌نمایش به‌صورت خودکار هنگام تغییر کتاب کار در کد به‌روز می‌شود؟**

پیش‌نمایش را به‌عنوان یک تصویر ثابت در نظر بگیرید. هنگام به‌روزرسانی داده‌های کتاب کار به‌صورت برنامه‌نویسی، تصویر نمودار را مجدداً تولید کنید و همانند کتاب کار جاسازی شده، پیش‌نمایش را نیز جایگزین کنید.

**آیا می‌توانم به‌جای XLSX از XLS استفاده کنم؟**

بله. کتاب کار را با فرمت XLS ذخیره کنید و از `xls` به‌عنوان پسوند داده‌های جاسازی شده استفاده کنید. پسوند باید با فرمت واقعی کتاب کار مطابقت داشته باشد؛ فقط تغییر پسوند داده را تبدیل نمی‌کند.

**چرا ممکن است پس از فعال‌سازی اندازه شیء تغییر کند؟**

برنامه میزبان می‌تواند ارائه شیء OLE را هنگام فعال‌سازی کتاب کار به‌روزرسانی کند. هر دو محدوده نمایش OLE کتاب کار و ابعاد چارچوب اسلاید مهم هستند. به [تغییر اندازه خودکار اشیاء OLE در ارائه‌های PowerPoint](/slides/fa/python-net/working-solution-for-worksheet-resizing/) مراجعه کنید.

## **بخش‌های مرتبط**

- [تغییر اندازه خودکار اشیاء OLE در ارائه‌های PowerPoint](/slides/fa/python-net/working-solution-for-worksheet-resizing/)
- [مسئله پیش‌نمایش شیء هنگام افزودن OleObjectFrame](/slides/fa/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [مدیریت اشیاء OLE](/slides/fa/python-net/manage-ole/)