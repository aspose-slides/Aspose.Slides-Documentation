---
title: مدیریت OLE در ارائه‌ها با استفاده از Python
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/python-java/manage-ole/
keywords:
- شیء OLE
- اتصال و جاسازی اشیاء
- افزودن OLE
- جاسازی OLE
- افزودن شیء
- جاسازی شیء
- افزودن فایل
- جاسازی فایل
- شیء پیوندی
- فایل پیوندی
- تغییر OLE
- آیکون OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیاء OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق Java. جا‌سازی، به‌روزرسانی و استخراج محتویات OLE را به‌صورت یکپارچه انجام دهید."
---
## **معرفی**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیائی که در یک برنامه ساخته شده‌اند، از طریق لینک یا جاسازی در برنامه دیگری قرار گیرند.

{{% /alert %}}

در نظر بگیرید یک نمودار در MS Excel ایجاد شده است. سپس این نمودار در یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شیء OLE در نظر گرفته می‌شود.

- یک شیء OLE ممکن است به‌صورت یک آیکون ظاهر شود. در این حالت، وقتی بر روی آیکون دوبار کلیک کنید، نمودار در برنامه مربوطه (Excel) باز می‌شود، یا از شما خواسته می‌شود برنامه‌ای برای باز یا ویرایش شیء انتخاب کنید.
- یک شیء OLE می‌تواند محتوای واقعی خود، مانند محتوای یک نمودار، را نمایش دهد. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را در داخل PowerPoint اصلاح کنید.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/fa/python-java/) به شما امکان می‌دهد اشیاء OLE را به عنوان فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/)) در اسلایدها وارد کنید.

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به‌صورت فریم شیء OLE در اسلاید جاسازی کنید. می‌توانید به این شکل عمل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع به یک اسلاید را بر اساس شاخص آن دریافت کنید.
3. فایل Excel را به‌صورت یک آرایه بایت بخوانید.
4. فریم [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) را به اسلاید اضافه کنید و آرایه بایت و سایر اطلاعات مربوط به شیء OLE را بدهید.
5. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

در مثال زیر، ما یک نمودار از فایل Excel را به‌عنوان فریم شیء OLE در اسلاید اضافه کرده‌ایم.

**توجه** که سازنده [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleembeddeddatainfo/) یک پسوند شیء قابل جاسازی را به‌عنوان پارامتر دوم دریافت می‌کند. این پسوند به PowerPoint کمک می‌کند تا نوع فایل را به‌درستی تشخیص داده و برنامه مناسب برای باز کردن این شیء OLE را انتخاب کند.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # آماده‌سازی داده‌ها برای شیء OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # اضافه‌کردن فریم شیء OLE به اسلاید.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **افزودن فریم‌های شیء OLE پیوندی**

Aspose.Slides for Python via Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) با پیوند به فایل به‌جای داده‌های جاسازی‌شده اضافه کنید.

این کد پایتون نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) با فایل Excel پیوندی به یک اسلاید اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # افزودن فریم شیء OLE با فایل Excel پیوندی.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به سادگی آن را پیدا یا دسترسی پیدا کنید:

1. ارائه‌ای که شیء OLE جاسازی شده دارد، با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.
3. شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) را دسترسی پیدا کنید. در مثال ما از PPTX قبلی استفاده کردیم که فقط یک شکل در اسلاید اول دارد. سپس بررسی کردیم که شیء یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) است. این همان فریم شیء OLE موردنظر برای دسترسی بود.
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.

در مثال زیر، یک فریم شیء OLE (شیء نمودار Excel جاسازی‌شده در اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # دریافت داده‌های فایل جاسازی‌شده.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # دریافت پسوند فایل جاسازی‌شده.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **دسترسی به خصوصیات فریم شیء OLE پیوندی**

Aspose.Slides به شما امکان می‌دهد خصوصیات فریم شیء OLE پیوندی را دسترسی پیدا کنید.

این کد پایتون نشان می‌دهد چگونه بررسی کنید که آیا یک شیء OLE پیوندی است و سپس مسیر فایل پیوندی را دریافت کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # بررسی می‌کند که آیا شیء OLE پیوندی است.
        if ole_frame.isObjectLink():
            # چاپ مسیر کامل به فایل پیوندی.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # چاپ مسیر نسبی به فایل پیوندی در صورت موجود بودن.
            # فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **تغییر داده‌های شیء OLE**

{{% alert color="info" title="Note" %}}

در این بخش، مثال کد زیر از [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به سادگی آن را دسترسی پیدا کنید و داده‌های آن را به این شکل اصلاح کنید:

1. ارائه‌ای که شیء OLE جاسازی شده دارد، با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.
3. شکل فریم شیء OLE را دسترسی پیدا کنید. در مثال ما از PPTX قبلی استفاده کردیم که یک شکل در اسلاید اول دارد. سپس بررسی کردیم که شیء یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) است. این همان فریم شیء OLE موردنظر برای دسترسی بود.
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.
5. یک شیء [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.
6. ورق کار (Worksheet) موردنظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.
7. Workbook به‌روزشده را در یک جریان (stream) ذخیره کنید.
8. داده‌های شیء OLE را از جریان تغییر دهید.

در مثال زیر، یک فریم شیء OLE (شیء نمودار Excel جاسازی‌شده در اسلاید) دسترسی پیدا می‌شود و داده‌های فایل آن اصلاح می‌شود تا داده‌های نمودار به‌روزرسانی شوند.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # داده‌های شیء OLE را به‌عنوان یک شیء Workbook بخوانید.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # داده‌های Workbook را اصلاح کنید.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # داده‌های شیء فریم OLE را تغییر دهید.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **جاسازی انواع دیگر فایل‌ها در اسلایدها**

به‌جز نمودارهای Excel، Aspose.Slides for Python via Java به شما امکان می‌دهد انواع دیگر فایل‌ها را به اسلایدها جاسازی کنید. به‌عنوان مثال می‌توانید HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربر روی شیء وارد شده دوبار کلیک کند، به‌صورت خودکار در برنامه مرتبط باز می‌شود یا از او درخواست می‌شود برنامه مناسب را برای باز کردن انتخاب کند.

این کد پایتون نشان می‌دهد چگونه HTML و ZIP را در یک اسلاید جاسازی کنید:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم نوع فایل برای اشیاء جاسازی شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides for Python via Java به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده را تنظیم کنید و به‌این ترتیب داده‌های فریم OLE یا پسوند آن را به‌روز کنید.

این کد پایتون نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده را به `zip` تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # تغییر نوع فایل به ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم تصویر آیکون و عنوان برای اشیاء جاسازی شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی شامل تصویر آیکون به‌طور خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به‌عنوان عناصر در پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با استفاده از Aspose.Slides for Python via Java تنظیم کنید.

این کد پایتون نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # افزودن تصویر به منابع ارائه.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # تنظیم عنوان و تصویر برای پیش‌نمایش OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **جلوگیری از تغییر اندازه و جابجایی فریم شیء OLE**

پس از افزودن یک شیء OLE پیوندی به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیغامی برای به‌روزرسانی پیوندها مشاهده کنید. کلیک بر روی دکمه «Update Links» ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE پیوندی به‌روز می‌کند و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی داده‌های شیء، متد [setUpdateAutomatic](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) کلاس [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) را به `False` تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخراج فایل‌های جاسازی شده**

Aspose.Slides for Python via Java به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها را به‌عنوان اشیاء OLE استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) که شامل اشیاء OLE موردنظر برای استخراج است، ایجاد کنید.
2. در تمام اشکال (shapes) ارائه حلقه بزنید و اشکال [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) را دسترسی پیدا کنید.
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های OLE استخراج کنید و بر روی دیسک بنویسید.

این کد پایتون نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیاء OLE استخراج کنید:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا محتویات OLE هنگام صادر کردن اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه بر روی اسلاید قابل مشاهده است رندر می‌شود — آیکون/تصویر جایگزین (پیشنمایش). محتوای «زنده» OLE در هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر موردنظر در PDF صادرشده حفظ شود.

**چگونه می‌توانم یک شیء OLE را در اسلاید قفل کنم تا کاربران نتوانند آن را جابجا یا ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides قفل‌های سطح شکل را فراهم می‌کند [/slides/fa/python-java/applying-protection-to-presentation/]. این قفل‌گذاری رمزنگاری نیست، اما به‌طور مؤثر از ویرایش‌های اتفاقی و جابجایی جلوگیری می‌کند.

**چرا یک شیء Excel پیوندی هنگام باز کردن ارائه «پرش» می‌کند یا اندازه‌اش تغییر می‌یابد؟**

PowerPoint ممکن است پیش‌نمایش OLE پیوندی را تازه کند. برای داشتن ظاهری ثابت، روش‌های موجود در [Working Solution for Worksheet Resizing](/slides/fa/python-java/working-solution-for-worksheet-resizing/) را دنبال کنید — یا چارچوب را به محدوده متناسب کنید، یا محدوده را به چارچوب ثابت مقیاس‌بندی کنید و تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیاء OLE پیوندی در فرمت PPTX حفظ می‌شوند؟**

در PPTX اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی‌تر PPT یافت می‌شوند. برای قابلیت حمل، از مسیرهای مطلق قابل اعتماد/URIهای قابل دسترس یا جاسازی استفاده کنید.