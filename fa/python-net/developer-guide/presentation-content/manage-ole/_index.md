---
title: مدیریت OLE در ارائه‌ها با Python
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/python-net/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی شیء
- افزودن OLE
- جاسازی OLE
- افزودن شیء
- جاسازی شیء
- افزودن فایل
- جاسازی فایل
- شیء لینک‌شده
- فایل لینک‌شده
- تغییر OLE
- آیکون OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیای OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET. به‌صورت یکپارچه OLE را جاسازی، به‌روز رسانی و صادر کنید."
---
## **مقدمه**

{{% alert color="info" title="Note" %}}
**OLE (Object Linking & Embedding)** یک فناوری مایکروسافت است که به داده‌ها و اشیایی که در یک برنامه ساخته شده‌اند اجازه می‌دهد در برنامه‌ای دیگر لینک یا جاسازی شوند.
{{% /alert %}}

به عنوان مثال، یک نمودار ایجاد شده در Microsoft Excel و قرار داده شده بر روی یک اسلاید PowerPoint یک شیء OLE است.

- یک شیء OLE ممکن است به شکل یک آیکن ظاهر شود. دو بار کلیک روی آیکن، شیء را در برنامه مرتبط (مثلاً Excel) باز می‌کند یا از شما می‌خواهد برنامه‌ای برای باز کردن یا ویرایش آن انتخاب کنید.
- یک شیء OLE ممکن است محتویات خود را نمایش دهد (مثلاً یک نمودار). در این حالت، PowerPoint شیء جاسازی‌شده را فعال می‌کند، رابط نمودار را بارگذاری می‌کند و به شما اجازه می‌دهد داده‌های نمودار را داخل PowerPoint ویرایش کنید.

Aspose.Slides برای Python به شما امکان می‌دهد اشیای OLE را به اسلایدها به عنوان چارچوب‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)) وارد کنید.

## **افزودن اشیای OLE به اسلایدها**

اگر قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به عنوان یک چارچوب شیء OLE در یک اسلاید با استفاده از Aspose.Slides برای Python جاسازی کنید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید بر اساس ایندکس آن دریافت کنید.
1. فایل Excel را به یک آرایه بایت بخوانید.
1. یک [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) به اسلاید اضافه کنید و آرایه بایت و سایر جزئیات شیء OLE را فراهم کنید.
1. ارائه اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

در مثال زیر، یک نمودار از یک فایل Excel به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) در یک اسلاید جاسازی می‌شود.

**تذکر:** سازنده‌ی [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) پسوند فایل شیء قابل جاسازی را به عنوان پارامتر دوم می‌گیرد. PowerPoint از این پسوند برای شناسایی نوع فایل و انتخاب برنامه مناسب برای باز کردن شیء OLE استفاده می‌کند.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # داده‌ها را برای شیء OLE آماده کنید.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # یک چارچوب شیء OLE به اسلاید اضافه کنید.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **افزودن اشیای OLE لینک‌شده**

Aspose.Slides برای Python به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) اضافه کنید که به یک فایل لینک می‌شود به‌جای جاسازی داده‌های آن.

مثال زیر به زبان Python نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) لینک‌شده به یک فایل Excel را بر روی اسلاید اضافه کنیم:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # یک چارچوب شیء OLE را با یک فایل Excel لینک‌شده اضافه کنید.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به اشیای OLE**

اگر یک شیء OLE قبلاً در یک اسلاید جاسازی شده باشد، می‌توانید به آن به شکل زیر دسترسی داشته باشید:

1. ارائه‌ای که شامل شیء OLE جاسازی‌شده است را با ایجاد یک نمونه از کلاس Presentation بارگذاری کنید.
2. یک مرجع به اسلاید بر اساس ایندکس آن دریافت کنید.
3. به شکل OleObjectFrame دسترسی پیدا کنید.
4. پس از به دست آوردن چارچوب شیء OLE، هر عملیات مورد نیاز را بر روی آن انجام دهید.

مثال زیر به چارچوب شیء OLE — یک نمودار Excel جاسازی‌شده — دسترسی پیدا می‌کند و داده‌های فایل آن را بازیابی می‌کند. در این مثال، از یک فایل PPTX که یک شکل تنها در اسلاید اول دارد استفاده می‌کنیم.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # دریافت داده‌های فایل جاسازی‌شده.
        file_data = ole_frame.embedded_data.embedded_file_data

        # دریافت پسوند فایل جاسازی‌شده.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **دسترسی به خصوصیات شیء OLE لینک‌شده**

Aspose.Slides به شما امکان می‌دهد به خصوصیات یک چارچوب شیء OLE لینک‌شده دسترسی پیدا کنید.

مثال زیر به زبان Python بررسی می‌کند آیا یک شیء OLE لینک‌شده است و در صورت لینک‌شده، مسیر فایل لینک‌شده را بازیابی می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # بررسی کنید آیا شیء OLE لینک‌شده است.
        if ole_frame.is_object_link:
            # مسیر کامل فایل لینک‌شده را چاپ کنید.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # مسیر نسبی فایل لینک‌شده را در صورت وجود چاپ کنید.
            # فقط ارائه‌های .ppt می‌توانند مسیر نسبی داشته باشند.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **تغییر داده‌های شیء OLE**

{{% alert color="info" title="Note" %}}
در این بخش، مثال کد زیر از [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/) استفاده می‌کند.
{{% /alert %}}

اگر یک شیء OLE قبلاً در یک اسلاید جاسازی شده باشد، می‌توانید به آن دسترسی پیدا کنید و داده‌های آن را به شکل زیر تغییر دهید:

1. ارائه را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بارگذاری کنید.
2. اسلاید هدف را بر اساس ایندکس آن دریافت کنید.
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) دسترسی پیدا کنید.
4. پس از به دست آوردن چارچوب شیء OLE، عملیات مورد نیاز را بر روی آن انجام دهید.
5. یک شیء `Workbook` ایجاد کنید و داده‌های OLE را بخوانید.
6. `Worksheet` مورد نظر را باز کنید و داده‌ها را ویرایش کنید.
7. `Workbook` به‌روز شده را به یک جریان (stream) ذخیره کنید.
8. داده‌های شیء OLE را با استفاده از آن جریان جایگزین کنید.

در مثال زیر، یک چارچوب شیء OLE (یک نمودار Excel جاسازی‌شده) دسترسی پیدا می‌کند و داده‌های فایل آن برای به‌روزرسانی نمودار تغییر می‌یابد. نمونه از یک PPTX که قبلاً ایجاد شده و شامل یک شکل در اسلاید اول است استفاده می‌کند.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # داده‌های شیء OLE را به عنوان یک شیء Workbook بخوانید.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # داده‌های کتاب کار را تغییر دهید.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # داده‌های شیء چارچوب OLE را تغییر دهید.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **جاسازی فایل‌ها در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides برای Python به شما امکان می‌دهد انواع دیگر فایل‌ها را در اسلایدها جاسازی کنید. برای مثال، می‌توانید فایل‌های HTML، PDF و ZIP را به عنوان اشیاء وارد کنید. وقتی کاربر دو بار روی یک شیء وارد شده کلیک می‌کند، به‌صورت خودکار در برنامه مرتبط باز می‌شود یا از او خواسته می‌شود برنامه مناسب را انتخاب کند.

این کد Python نشان می‌دهد چگونه فایل‌های HTML و ZIP را در یک اسلاید جاسازی کنیم:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم نوع فایل برای اشیای جاسازی‌شده**

در هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیای OLE قدیمی را با اشیای جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides برای Python به شما اجازه می‌دهد نوع فایل یک شیء جاسازی‌شده را تنظیم کنید تا بتوانید داده‌های چارچوب OLE یا پسوند فایل آن را به‌روز کنید.

این کد Python نشان می‌دهد چگونه نوع فایل شیء OLE جاسازی‌شده را به `zip` تنظیم کنیم:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # تغییر نوع فایل به ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تصاویر آیکن و عناوین برای اشیای جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایش مبتنی بر آیکن به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی در پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکن و عنوان را با استفاده از Aspose.Slides برای Python تنظیم کنید.

این کد Python نشان می‌دهد چگونه تصویر آیکن و عنوان را برای یک شیء جاسازی‌شده تنظیم کنیم:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # یک تصویر به منابع ارائه اضافه کنید.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # عنوان و تصویر برای پیش‌نمایش OLE تنظیم کنید.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **جلوگیری از تغییر اندازه و جابجایی چارچوب‌های شیء OLE**

بعد از افزودن یک شیء OLE لینک‌شده به اسلاید، PowerPoint ممکن است هنگام باز کردن ارائه از شما بخواهد لینک‌ها را به‌روزرسانی کنید. انتخاب گزینه «به‌روزرسانی لینک‌ها» می‌تواند اندازه و موقعیت چارچوب شیء OLE را تغییر دهد زیرا PowerPoint پیش‌نمایش را با داده‌های شیء لینک‌شده تازه می‌کند. برای جلوگیری از این درخواست، ویژگی `update_automatic` کلاس [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) را به `False` تنظیم کنید:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides برای Python به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها به عنوان اشیای OLE را به‌صورت زیر استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) که شامل اشیای OLE موردنظر برای استخراج است، ایجاد کنید.
2. روی تمام شکل‌ها در ارائه پیمایش کنید و اشکال OLEObjectFrame را شناسایی کنید.
3. داده‌های فایل جاسازی‌شده هر [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) را بازیابی کرده و بر روی دیسک بنویسید.

کد Python زیر نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیای OLE استخراج کنیم:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **سوالات متداول**

**آیا محتوای OLE هنگام استخراج اسلایدها به PDF/تصاویر رندر می‌شود؟**

چیزی که بر روی اسلاید قابل مشاهده است رندر می‌شود — آیکن/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش دلخواه خود را تنظیم کنید تا ظاهر مورد انتظار در PDF خروجی تضمین شود.

برای حفظ فایل جاسازی‌شده به‌عنوان پیوست PDF، [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) را به `True` تنظیم کنید. این گزینه به‌صورت پیش‌فرض غیرفعال است. برای مثال و دستورالعمل‌های بررسی پیوست، صفحه [حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست‌های PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) را ببینید.

**چگونه می‌توانم یک شیء OLE را در اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint حرکت یا ویرایش دهند؟**

قفل کردن شکل: Aspose.Slides [قفل‌های سطح شکل](/slides/fa/python-net/applying-protection-to-presentation/) را فراهم می‌کند. این یک رمزگذاری نیست، اما به‌طور مؤثر از ویرایش‌ها و جابجایی‌های ناخواسته جلوگیری می‌کند.

**چرا یک شیء Excel لینک‌شده هنگام باز کردن ارائه «پرش» می‌کند یا اندازه‌اش تغییر می‌یابد؟**

PowerPoint ممکن است پیش‌نمایش OLE لینک‌شده را تازه کند. برای ظاهر ثابت، راهکارهای [راهکار عملی برای تغییر اندازه Worksheet](/slides/fa/python-net/working-solution-for-worksheet-resizing/) را دنبال کنید — یا چارچوب را به دامنه مطابقت دهید، یا دامنه را به یک چارچوب ثابت مقیاس کنید و تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیای OLE لینک‌شده در قالب PPTX حفظ می‌شوند؟**

در PPTX، اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل حفظ می‌شود. مسیرهای نسبی در قالب قدیمی PPT یافت می‌شوند. برای قابلیت جابجایی، بهتر است از مسیرهای مطلق قابل اطمینان/URIهای دسترس‌پذیر یا جاسازی استفاده کنید.