---
title: مدیریت OLE در ارائه‌ها با استفاده از پایتون
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/python-java/manage-ole/
keywords:
- شیء OLE
- پیونددهی و جاسازی شیء
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
description: "بهینه‌سازی مدیریت اشیاء OLE در PowerPoint و فایل‌های OpenDocument با Aspose.Slides برای پایتون از طریق جاوا. OLE را به‌صورت یکپارچه جاسازی، به‌روزرسانی و صادر کنید."
---
## **مقدمه**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که امکان قرار دادن داده‌ها و اشیاء ایجاد‌شده در یک برنامه را در برنامهٔ دیگر از طریق لینک‌گذاری یا جاسازی می‌دهد.

{{% /alert %}}

به یک نمودار که در MS Excel ایجاد شده، فکر کنید. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شیء OLE در نظر گرفته می‌شود.

- یک شیء OLE ممکن است به شکل یک آیکون ظاهر شود. در این صورت، وقتی روی آیکون دوبار کلیک می‌کنید، نمودار در برنامهٔ مرتبط (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای برای باز کردن یا ویرایش شیء انتخاب کنید.
- یک شیء OLE ممکن است محتویات واقعی خود را نمایش دهد، مانند محتویات یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را داخل PowerPoint اصلاح کنید.

[Aspose.Slides برای پایتون از طریق جاوا](https://products.aspose.com/slides/fa/python-java/) به شما امکان می‌دهد OLE Objects را به اسلایدها به‌عنوان فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/)) وارد کنید.

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به‌عنوان فریم شیء OLE در یک اسلاید جاسازی کنید با استفاده از Aspose.Slides برای پایتون از طریق جاوا. می‌توانید به این روش عمل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.
1. فایل Excel را به صورت آرایه‌ای از بایت‌ها بخوانید.
1. فریم [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) را به اسلاید اضافه کنید که شامل آرایه بایت و سایر اطلاعات مربوط به شیء OLE باشد.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک نمودار از فایل Excel به‌عنوان فریم شیء OLE به اسلاید اضافه شد با استفاده از Aspose.Slides برای پایتون از طریق جاوا.  
**توجه** این سازنده [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleembeddeddatainfo/) یک پسوند شیء قابل جاسازی را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد تا نوع فایل را به‌درستی تشخیص داده و برنامهٔ مناسب برای باز کردن این شیء OLE را انتخاب کند.

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

    # افزودن فریم شیء OLE به اسلاید.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **افزودن فریم‌های شیء OLE پیوندی**

Aspose.Slides برای پایتون از طریق جاوا به شما اجازه می‌دهد تا یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) را بدون جاسازی داده، فقط با یک پیوند به فایل اضافه کنید.

این کد پایتون نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) با یک فایل اکسل پیوندی به یک اسلاید اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # اضافه کردن فریم شیء OLE با فایل اکسل پیوندی.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به سادگی آن را پیدا یا دسترسی پیدا کنید به این روش:

1. یک ارائه را که شامل شیء OLE جاسازی‌شده است، با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید را با استفاده از شاخص آن دریافت کنید.
3. فریم شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) را دسترسی پیدا کنید. در مثال ما، PPTX قبلاً ایجاد‌شده که فقط یک شکل در اسلاید اول دارد استفاده کردیم. سپس بررسی کردیم که شیء یک [OleObjectFrame] است. این فریم OLE مطلوب برای دسترسی بود.
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی روی آن انجام دهید.

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شوند.

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

### **دسترسی به ویژگی‌های فریم شیء OLE پیوندی**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های فریم شیء OLE پیوندی را دسترسی پیدا کنید.

این کد پایتون نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE پیوندی است و سپس مسیر فایل پیوندی را به‌دست آورید:

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

        # بررسی کنید آیا شیء OLE پیوندی است.
        if ole_frame.isObjectLink():
            # چاپ مسیر کامل فایل پیوندی.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # چاپ مسیر نسبی فایل پیوندی اگر موجود باشد.
            # فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **تغییر داده‌های شیء OLE**

{{% alert color="info" title="Note" %}}

در این بخش، مثال کد زیر از [Aspose.Cells برای پایتون از طریق جاوا](https://products.aspose.com/cells/python-java/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به سادگی آن شیء را دسترسی پیدا کنید و داده‌های آن را به این روش اصلاح کنید:

1. یک ارائه را که شامل شیء OLE جاسازی‌شده است، با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.
3. فریم شکل شیء OLE را دسترسی پیدا کنید. در مثال ما، PPTX قبلاً ایجاد‌شده که یک شکل در اسلاید اول دارد استفاده کردیم. سپس بررسی کردیم که شیء یک [OleObjectFrame] است. این فریم OLE مطلوب برای دسترسی بود.
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی روی آن انجام دهید.
5. یک شیء [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) ایجاد کنید و به دادهٔ OLE دسترسی پیدا کنید.
6. برگهٔ [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) مورد نظر را دسترسی کنید و داده‌ها را اصلاح کنید.
7. [Workbook] به‌روزرسانی‌شده را در یک جریان ذخیره کنید.
8. دادهٔ شیء OLE را از جریان تغییر دهید.

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) دسترسی پیدا می‌شود و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شوند.

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

        # خواندن داده‌های شیء OLE به عنوان یک شیء Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # اصلاح داده‌های Workbook.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # تغییر داده‌های شیء فریم OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **جاسازی انواع دیگر فایل در اسلایدها**

به‌جز نمودارهای Excel، Aspose.Slides برای پایتون از طریق جاوا به شما اجازه می‌دهد انواع دیگر فایل‌ها را به اسلایدها جاسازی کنید. به عنوان مثال می‌توانید فایل‌های HTML، PDF و ZIP را به عنوان اشیاء وارد کنید. وقتی کاربر روی شیء وارد شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامهٔ مربوطه باز می‌شود یا از کاربر خواسته می‌شود برنامهٔ مناسب برای باز کردن آن را انتخاب کند.

این کد پایتون نشان می‌دهد چگونه HTML و ZIP را به یک اسلاید جاسازی کنید:

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

## **تنظیم نوع فایل برای اشیاء جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides برای پایتون از طریق جاوا به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده را تنظیم کنید، به‌طوری که بتوانید دادهٔ فریم OLE یا پسوند آن را به‌روز کنید.

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

## **تنظیم تصاویر آیکون و عناوین برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، یک پیش‌نمایش متشکل از تصویر آیکون به‌طور خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با Aspose.Slides برای پایتون از طریق جاوا تنظیم کنید.

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

    # یک تصویر به منابع ارائه اضافه کنید.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # یک عنوان و تصویر را برای پیش‌نمایش OLE تنظیم کنید.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **جلوگیری از تغییر اندازه و موقعیت فریم شیء OLE**

پس از افزودن یک شیء OLE پیوندی به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیغامی مبنی بر به‌روزرسانی پیوندها مشاهده کنید. کلیک بر دکمه «Update Links» ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE پیوندی به‌روزرسانی می‌کند و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی دادهٔ شیء، متد [setUpdateAutomatic](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) کلاس [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) را به `False` تنظیم کنید:

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

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides برای پایتون از طریق جاوا به شما اجازه می‌دهد فایل‌های جاسازی‌شده در اسلایدها به‌عنوان اشیاء OLE را به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) که شامل اشیاء OLE مورد نظر برای استخراج است، ایجاد کنید.
2. در تمام اشکال ارائه حلقه بزنید و اشکال [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) را دسترسی پیدا کنید.
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های شیء OLE استخراج کنید و روی دیسک بنویسید.

این کد پایتون نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید به‌عنوان اشیاء OLE استخراج کنید:

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

**آیا محتوای OLE هنگام استخراج اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه بر روی اسلاید قابل مشاهده است رندر می‌شود—آیکون/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در زمان رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر مورد انتظار در PDF استخراج‌شده تضمین شود.

**چگونه می‌توان یک شیء OLE را در اسلاید قفل کرد تا کاربران نتوانند آن را در PowerPoint جابه‌جا یا ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides [قفل‌های سطح شکل](/slides/fa/python-java/applying-protection-to-presentation/) را فراهم می‌کند. این قفل‌گذاری رمزگذاری نیست، اما به‌طور مؤثر از ویرایش‌های ناخواسته و جابه‌جایی جلوگیری می‌کند.

**چرا یک شیء Excel پیوندی «پرش» می‌کند یا اندازه‌اش هنگام باز کردن ارائه تغییر می‌یابد؟**

PowerPoint ممکن است پیش‌نمایش OLE پیوندی را تازه کند. برای ظاهر ثابت، روش‌های [راه‌حل کاری برای تغییر اندازه شیت](/slides/fa/python-java/working-solution-for-worksheet-resizing/) را دنبال کنید—یا فریم را به بازهٔ داده‌ها متناسب کنید، یا بازه را به فریم ثابت مقیاس‌بندی کنید و تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیاء OLE پیوندی در قالب PPTX حفظ می‌شوند؟**

در PPTX، اطلاعات «مسیر نسبی» در دسترس نیست—فقط مسیر کامل موجود است. مسیرهای نسبی در قالب قدیمی PPT یافت می‌شوند. برای قابلیت حمل، مسیرهای مطلق قابل اعتماد/URI‌های قابل دسترس یا جاسازی را ترجیح دهید.