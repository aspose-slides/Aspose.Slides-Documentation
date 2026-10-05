---
title: مدیریت OLE در ارائه‌ها با استفاده از Python
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/python-java/manage-ole/
keywords:
- شیء OLE
- پیونددهی و جاسازی شئ
- افزودن OLE
- جاسازی OLE
- افزودن شئ
- جاسازی شئ
- افزودن فایل
- جاسازی فایل
- شئ لینک‌شده
- فایل لینک‌شده
- تغییر OLE
- نماد OLE
- عنوان OLE
- استخراج OLE
- استخراج شئ
- استخراج فایل
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیاء OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق Java. جاسازی، به‌روزرسانی و صادر کردن محتوای OLE به‌صورت یکپارچه."
---
## **مقدمه**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که امکان قرار دادن داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند، در برنامهٔ دیگر از طریق لینک یا جاسازی را فراهم می‌کند.
{{% /alert %}}

یک نمودار ایجاد شده در MS Excel را در نظر بگیرید. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به‌عنوان یک شیء OLE محسوب می‌شود.

- یک شیء OLE ممکن است به‌صورت یک نماد نمایش داده شود. در این حالت، وقتی روی نماد دوبار کلیک می‌کنید، نمودار در برنامه مرتبط خود (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای برای باز کردن یا ویرایش شیء انتخاب کنید.
- یک شیء OLE ممکن است محتوای واقعی خود را نمایش دهد، مانند محتوای یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را درون PowerPoint ویرایش کنید.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) امکان وارد کردن اشیاء OLE به اسلایدها به‌صورت چارچوب‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)) را فراهم می‌کند.

## **افزودن چارچوب‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به‌عنوان یک چارچوب شیء OLE در اسلاید جاسازی کنید با استفاده از Aspose.Slides for Python via Java؛ می‌توانید این کار را به این شیوه انجام دهید:

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.
3. فایل Excel را به‌عنوان یک آرایه بایت بخوانید.
4. چارچوب [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) را به اسلاید اضافه کنید که حاوی آرایه بایت و سایر اطلاعات مربوط به شیء OLE است.
5. ارائهٔ تغییر یافته را به‌صورت فایل PPTX بنویسید.

در مثال زیر، یک نمودار از فایل Excel را به اسلاید به‌عنوان چارچوب شیء OLE اضافه کردیم با استفاده از Aspose.Slides for Python via Java.  
**توجه** داشته باشید که سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) یک پسوند شیء جاسازی‌شدنی را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد نوع فایل را به‌درستی تفسیر کند و برنامهٔ مناسب برای باز کردن این شیء OLE را انتخاب کند.

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

    # آماده‌سازی داده برای شیء OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # افزودن چارچوب شیء OLE به اسلاید.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **افزودن چارچوب‌های شیء OLE لینک‌شده**

Aspose.Slides for Python via Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) با لینک به فایل به‌جای دادهٔ جاسازی‌شده اضافه کنید.

این کد Python نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) با فایل Excel لینک‌شده به اسلاید اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # افزودن چارچوب شیء OLE با فایل Excel لینک‌شده.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به چارچوب‌های شیء OLE**

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به راحتی آن را پیدا یا دسترسی پیدا کنید به این روش:

1. یک ارائه حاوی شیء OLE جاسازی‌شده را با ایجاد یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده‌ای استفاده کردیم که تنها یک شکل در اسلاید اول دارد. سپس بررسی کردیم که شیء یک [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) است. این همان چارچوب شیء OLE مورد نظر برای دسترسی بود.
4. پس از دسترسی به چارچوب شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.

در مثال زیر، یک چارچوب شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) و دادهٔ فایل آن مورد دسترسی قرار می‌گیرد.

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

### **دسترسی به ویژگی‌های چارچوب شیء OLE لینک‌شده**

Aspose.Slides به شما امکان دسترسی به ویژگی‌های چارچوب شیء OLE لینک‌شده را می‌دهد.

این کد Python نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE لینک‌شده است و سپس مسیر فایل لینک‌شده را به دست آورید:

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

        # بررسی اینکه آیا شیء OLE لینک‌شده است.
        if ole_frame.isObjectLink():
            # چاپ مسیر کامل فایل لینک‌شده.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # چاپ مسیر نسبی فایل لینک‌شده در صورت وجود.
            # فقط ارائه‌های PPT می‌توانند مسیر نسبی را شامل شوند.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **تغییر دادهٔ شیء OLE**

{{% alert color="info" title="Note" %}}
در این بخش، مثال کد زیر از [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) استفاده می‌کند.
{{% /alert %}}

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به راحتی به آن دسترسی پیدا کنید و دادهٔ آن را به این صورت اصلاح کنید:

1. یک ارائه حاوی شیء OLE جاسازی‌شده را با ایجاد یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.
3. به شکل چارچوب شیء OLE دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده‌ای استفاده کردیم که یک شکل در اسلاید اول دارد. سپس بررسی کردیم که شیء یک [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) است. این همان چارچوب شیء OLE مورد نظر برای دسترسی بود.
4. پس از دسترسی به چارچوب شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.
5. یک شیء [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) ایجاد کنید و به دادهٔ OLE دسترسی پیدا کنید.
6. شیت مورد نظر [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) را انتخاب کنید و داده‌ها را اصلاح کنید.
7. [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) به‌روزرسانی‌شده را در یک استریم ذخیره کنید.
8. دادهٔ شیء OLE را از استریم تغییر دهید.

در مثال زیر، یک چارچوب شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) دسترسی پیدا می‌شود و دادهٔ فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شود.

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

        # دادهٔ شیء OLE را به‌عنوان یک شیء Workbook بخوانید.
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

        # دادهٔ شیء چارچوب OLE را تغییر دهید.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **جاسازی انواع دیگر فایل‌ها در اسلایدها**

به‌جز نمودارهای Excel، Aspose.Slides for Python via Java به شما امکان می‌دهد انواع دیگر فایل‌ها را به اسلایدها جاسازی کنید. به‌عنوان مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌صورت اشیاء وارد کنید. وقتی کاربر روی شیء وارد شده دوبار کلیک می‌کند، به‌طور خودکار در برنامهٔ مرتبط باز می‌شود یا از کاربر درخواست می‌شود برنامهٔ مناسبی برای باز کردن انتخاب کند.

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

## **تنظیم نوع فایل برای اشیای جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز به جایگزینی اشیای OLE قدیمی با اشیای جدید یا جایگزینی یک شیء OLE نامحSupported با شیء پشتیبانی‌شده داشته باشید. Aspose.Slides for Python via Java به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده را تنظیم کنید و بدین‌سویق دادهٔ چارچوب OLE یا پسوند آن را به‌روز کنید.

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

## **تنظیم تصویر نماد و عنوان برای اشیای جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی شامل یک تصویر نماد به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر نماد و عنوان را با استفاده از Aspose.Slides for Python via Java تنظیم کنید.

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

## **جلوگیری از تغییر اندازه و موقعیت چارچوب شیء OLE**

پس از افزودن یک شیء OLE لینک‌شده به اسلاید ارائه، هنگام باز کردن ارائه در PowerPoint ممکن است پیامی مشاهده کنید که از شما می‌خواهد لینک‌ها را به‌روز کنید. کلیک بر دکمه «Update Links» می‌تواند اندازه و موقعیت چارچوب شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE لینک‌شده به‌روز می‌کند و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی دادهٔ شیء، متد [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) کلاس [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) را با `False` فراخوانی کنید:

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

Aspose.Slides for Python via Java به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها به‌عنوان اشیای OLE را به این شکل استخراج کنید:

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید که شامل اشیای OLE مورد نظر برای استخراج باشد.
2. در تمام شکل‌ها در ارائه حلقه بزنید و به شکل‌های [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) دسترسی پیدا کنید.
3. دادهٔ فایل‌های جاسازی‌شده از چارچوب‌های شیء OLE را استخراج کنید و روی دیسک بنویسید.

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

## **سوالات متداول**

**آیا محتوای OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه روی اسلاید قابل مشاهده است رندر می‌شود — نماد/تصویر جایگزین (پیشنمایش). محتوای «زنده» OLE در زمان رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر مورد انتظار در PDF خروجی حفظ شود.

برای همچنین نگهداری فایل جاسازی‌شده به‌عنوان ضمیمه PDF، متد [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) را با `True` صدا بزنید. این گزینه به‌صورت پیش‌فرض غیرفعال است. برای مثال و دستورالعمل‌های بررسی ضمیمه، به [Preserve Embedded OLE Files as PDF Attachments](/slides/fa/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) مراجعه کنید.

**چگونه می‌توانم یک شیء OLE را در اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابجا یا ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides قابلیت [قفل‌های سطح شکل](/slides/fa/python-java/applying-protection-to-presentation/) را فراهم می‌کند. این رمزنگاری نیست، اما به‌طور مؤثر از ویرایش‌های ناخواسته و جابه‌جایی جلوگیری می‌کند.

**چرا یک شیء Excel لینک‌شده هنگام باز کردن ارائه «پرش» می‌کند یا اندازه‌اش تغییر می‌یابد؟**

PowerPoint ممکن است پیش‌نمایش OLE لینک‌شده را تازه کند. برای داشتن ظاهری پایدار، شیوه‌های موجود در [Working Solution for Worksheet Resizing](/slides/fa/python-java/working-solution-for-worksheet-resizing/) را دنبال کنید — یا چارچوب را با محدوده منطبق کنید، یا محدوده را به یک چارچوب ثابت مقیاس‌دهی کنید و یک تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیای OLE لینک‌شده در فرمت PPTX حفظ می‌شوند؟**

در PPTX، اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در فرمت قدیمی‌تر PPT یافت می‌شوند. برای قابلیت حمل، مسیرهای مطلق قابل اطمینان/URIهای قابل دسترس یا جاسازی را ترجیح دهید.