---
title: مدیریت OLE در ارائه‌ها با استفاده از Python
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/python-net/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی اشیاء
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
description: "مدیریت اشیاء OLE را در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET بهینه کنید. محتویات OLE را به‌صورت یکپارچه جاسازی، به‌روزرسانی و صادر کنید."
---
## **مقدمه**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** یک فناوری مایکروسافت است که امکان لینک یا جاسازی داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند را در برنامه‌ای دیگر فراهم می‌کند.

{{% /alert %}}

به عنوان مثال، نموداری که در Microsoft Excel ایجاد شده و بر روی یک اسلاید PowerPoint قرار می‌گیرد، یک شیء OLE است.

- یک شیء OLE ممکن است به شکل یک آیکون ظاهر شود. دوبار کلیک کردن روی آیکون، شیء را در برنامه مرتبط (مثلاً Excel) باز می‌کند یا شما را برای انتخاب برنامه‌ای جهت باز یا ویرایش آن دعوت می‌کند.
- یک شیء OLE ممکن است محتویات خود را نمایش دهد (مثلاً یک نمودار). در این حالت PowerPoint شیء جاسازی‌شده را فعال می‌کند، رابط نمودار را بارگذاری می‌کند و اجازه می‌دهد داده‌های نمودار را مستقیماً در PowerPoint ویرایش کنید.

Aspose.Slides for Python به شما امکان می‌دهد اشیاء OLE را به اسلایدها به عنوان فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/)) اضافه کنید.

## **افزودن اشیاء OLE به اسلایدها**

اگر قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به‌عنوان فریم شیء OLE در اسلاید جاسازی کنید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به اسلاید مراجعه کنید.
1. فایل Excel را به یک آرایه بایت بخوانید.
1. یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) به اسلاید اضافه کنید و آرایه بایت و جزئیات دیگر شیء OLE را فراهم کنید.
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک نمودار از فایل Excel به‌عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) در اسلاید جاسازی می‌شود.

**توجه:** سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) پسوند فایل شیء قابل جاسازی را به‌عنوان پارامتر دوم دریافت می‌کند. PowerPoint از این پسوند برای تشخیص نوع فایل و انتخاب برنامه مناسب جهت باز کردن شیء OLE استفاده می‌کند.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # آماده‌سازی داده‌ها برای شیء OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # افزودن یک فریم شیء OLE به اسلید.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **افزودن اشیاء OLE لینک‌شده**

Aspose.Slides for Python به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) اضافه کنید که به فایل لینک می‌شود به‌جای اینکه داده‌های آن را جاسازی کند.

مثال زیر به زبان Python نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) لینک‌شده به یک فایل Excel را به اسلاید اضافه کنید:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # افزودن یک فریم شیء OLE با فایل Excel لینک‌شده.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به اشیاء OLE**

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به‌صورت زیر به آن دسترسی پیدا کنید:

1. ارائه‌ای که شامل شیء OLE جاسازی‌شده است را با ایجاد یک نمونه از کلاس Presentation بارگذاری کنید.
1. با استفاده از ایندکس، به اسلاید مراجعه کنید.
1. به شکل OleObjectFrame دسترسی پیدا کنید.
1. پس از دریافت فریم شیء OLE، عملیات مورد نیاز را بر روی آن انجام دهید.

مثال زیر به فریم شیء OLE—یک نمودار Excel جاسازی‌شده—دسترسی پیدا می‌کند و داده‌های فایل آن را بازیابی می‌کند. در این مثال، از یک PPTX استفاده می‌شود که یک شکل تنها در اسلاید اول دارد.

```py
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

### **دسترسی به ویژگی‌های شیء OLE لینک‌شده**

Aspose.Slides به شما امکان می‌دهد به ویژگی‌های فریم شیء OLE لینک‌شده دسترسی پیدا کنید.

مثال زیر به زبان Python بررسی می‌کند آیا یک شیء OLE لینک‌شده است و در صورت مثبت، مسیر فایل لینک‌شده را بازیابی می‌کند:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # بررسی کنید که آیا شیء OLE لینک‌شده است.
        if ole_frame.is_object_link:
            # چاپ مسیر کامل فایل لینک‌شده.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # چاپ مسیر نسبی فایل لینک‌شده، اگر موجود باشد.
            # فقط ارائه‌های .ppt می‌توانند مسیر نسبی داشته باشند.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **تغییر داده‌های شیء OLE**

{{% alert color="primary" %}}

در این بخش، مثال کد زیر از [Aspose.Cells for Python via .NET](/cells/python-net/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به آن دسترسی پیدا کنید و داده‌هایش را به‌صورت زیر تغییر دهید:

1. با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ارائه را بارگذاری کنید.
1. اسلاید هدف را با ایندکس دریافت کنید.
1. به شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) دسترسی پیدا کنید.
1. پس از دریافت فریم شیء OLE، عملیات مورد نیاز را بر روی آن انجام دهید.
1. یک شیء `Workbook` ایجاد کنید و داده‌های OLE را بخوانید.
1. `Worksheet` مطلوب را باز کنید و داده‌ها را ویرایش کنید.
1. `Workbook` به‌روزشده را به یک جریان (stream) ذخیره کنید.
1. داده‌های شیء OLE را با استفاده از آن جریان جایگزین کنید.

در مثال زیر، یک فریم شیء OLE (یک نمودار Excel جاسازی‌شده) دسترسی پیدا می‌کند و داده‌های فایل آن برای به‌روزرسانی نمودار تغییر می‌یابد. نمونه از یک PPTX پیش‌ساخته استفاده می‌کند که یک شکل تنها در اسلاید اول دارد.

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
            # داده‌های Workbook را تغییر دهید.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # داده‌های شیء فریم OLE را تغییر دهید.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **جاسازی فایل‌ها در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides for Python به شما اجازه می‌دهد انواع دیگر فایل‌ها را در اسلایدها جاسازی کنید. به عنوان مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربر بر روی شیء درج‌شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامه مرتبط باز می‌شود یا از او برای انتخاب برنامه مناسب درخواست می‌شود.

این کد Python نشان می‌دهد چگونه فایل‌های HTML و ZIP را در یک اسلاید جاسازی کنید:

```py
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

## **تنظیم نوع فایل برای اشیاء جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides for Python به شما اجازه می‌دهد نوع فایل یک شیء جاسازی‌شده را تنظیم کنید تا بتوانید داده‌های فریم OLE یا پسوند فایل آن را به‌روزرسانی کنید.

این کد Python نشان می‌دهد چگونه نوع فایل شیء OLE جاسازی‌شده را به `zip` تنظیم کنید:

```py
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

## **تنظیم تصویر آیکون و عنوان برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایش بر پایه آیکون به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید تصویر و متن خاصی را در پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با Aspose.Slides for Python تنظیم کنید.

این کد Python نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # یک تصویر به منابع ارائه اضافه کنید.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # عنوان و تصویر را برای پیش نمایش OLE تنظیم کنید.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **جلوگیری از تغییر اندازه و موقعیت فریم‌های شیء OLE**

پس از افزودن یک شیء OLE لینک‌شده به اسلاید، ممکن است PowerPoint هنگام باز کردن ارائه از شما بخواهد لینک‌ها را به‌روزرسانی کند. انتخاب «Update Links» می‌تواند اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint پیش‌نمایش را با داده‌های شیء لینک‌شده تازه می‌کند. برای جلوگیری از این درخواست، خصوصیت `update_automatic` کلاس [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) را روی `False` تنظیم کنید:

```py
ole_frame.update_automatic = False
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides for Python به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها به‌عنوان اشیاء OLE را به‌صورت زیر استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) که شامل اشیاء OLE مورد نظر برای استخراج است، ایجاد کنید.
1. تمام شکل‌ها را در ارائه پیمایش کنید و شکل‌های OLEObjectFrame را شناسایی کنید.
1. داده‌های فایل جاسازی‌شده را از هر [OLEObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) بازیابی کنید و روی دیسک بنویسید.

کد Python زیر نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید به‌عنوان اشیاء OLE استخراج شوند:

```py
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

**آیا محتوای OLE هنگام خروجی به PDF/تصاویر رندر می‌شود؟**

آنچه روی اسلاید دیده می‌شود رندر می‌شود—آیکون/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در زمان رندر اجرا نمی‌شود. اگر لازم است، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر مورد انتظار در PDF خروجی حفظ شود.

**چگونه می‌توانم یک شیء OLE را در اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابه‌جا یا ویرایش کنند؟**

قفل کردن شکل: Aspose.Slides قابلیت [قفل‌های سطح شکل](/slides/fa/python-net/applying-protection-to-presentation/) را فراهم می‌کند. این رمزنگاری نیست، اما به‌طور مؤثری از ویرایش‌های ناخواسته و جابه‌جایی جلوگیری می‌کند.

**چرا یک شیء Excel لینک‌شده «پرش» می‌کند یا هنگام باز کردن ارائه اندازه‌اش تغییر می‌یابد؟**

PowerPoint ممکن است پیش‌نمایش OLE لینک‌شده را تازه کند. برای داشتن ظاهر ثابت، روش‌های موجود در [راه‌حل کاری برای تغییر اندازه Worksheet](/slides/fa/python-net/working-solution-for-worksheet-resizing/) را دنبال کنید—یا فریم را با محدوده منطبق کنید، یا محدوده را به فریم ثابت مقیاس دهید و تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیاء OLE لینک‌شده در فرمت PPTX حفظ می‌شوند؟**

در PPTX اطلاعات «مسیر نسبی» موجود نیست—فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در فرمت قدیمی PPT موجود هستند. برای قابلیت حمل، بهتر است از مسیرهای مطلق قابل اطمینان/URIهای قابل دسترسی یا جاسازی استفاده کنید.

---
title: مدیریت OLE در ارائه‌ها با استفاده از Python
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/python-net/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی اشیاء
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
description: "مدیریت اشیاء OLE را در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET بهینه کنید. محتویات OLE را به‌صورت یکپارچه جاسازی، به‌روزرسانی و صادر کنید."
---