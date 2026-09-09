---
title: ذخیرهٔ ارائه‌ها در پایتون از طریق جاوا
linktitle: ذخیرهٔ ارائه
type: docs
weight: 80
url: /fa/python-java/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- تازه‌سازی بندانگشتی
- پیشرفت ذخیره‌سازی
- پایتون
- جاوا
- Aspose.Slides
description: "ذخیرهٔ ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌ها در پایتون از طریق جاوا با Aspose.Slides، و پیکربندی خروجی PPTX و گزارش پیشرفت."
---
## **نمای کلی**

بعد از ایجاد یک ارائه یا [باز کردن یک ارائه موجود](/slides/fa/python-java/open-presentation/)، از روش [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای نوشتن نتایج استفاده کنید. Aspose.Slides for Python via Java می‌تواند ارائه را در فرمت‌های PowerPoint، OpenDocument، PDF و دیگر فرمت‌ها به فایل یا جریان ذخیره کند. بخش‌های زیر عملیات ذخیره‌سازی استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **ذخیرهٔ ارائه‌ها در فایل‌ها**

برای ذخیرهٔ یک ارائه در فایل، مسیر خروجی و مقدار یک [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) را به روش [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید. مقدار فرمت نوع فایلی را که Aspose.Slides ایجاد می‌کند تعیین می‌کند.

مثال زیر یک ارائه ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # افزودن یا اصلاح محتویات ارائه در اینجا.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ذخیرهٔ ارائه‌ها در فرمت اصلی‌شان**

در یک برنامهٔ پردازش دسته‌ای، ممکن است فرمت ورودی از قبل شناخته نشود. پس از بارگذاری یک فایل، فرمت اصلی آن را از طریق روش [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSourceFormat) بخوانید. مقدار حاصل از [SourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sourceformat/) را به [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/#toSaveFormat) پاس دهید تا مقدار متناظر [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) به دست آید، سپس با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) ارائهٔ اصلاح‌شده را بنویسید.

مثال کامل زیر هر فایلی را در یک پوشهٔ ورودی پردازش می‌کند، عنوان آن را به‌روز می‌کند و در پوشهٔ خروجی با همان فرمت بارگذاری شده ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/#toSaveFormat) فرمت‌های PPT، PPTX، ODP، PPTM، PPSX، PPSM، POTX، POTM، PPS، POT، OTP، FODP و PowerPoint XML را به فرمت‌های متناظر ذخیرهٔ ارائه مپ می‌کند. این متد فقط فرمت‌های منبع ارائه را مپ می‌کند؛ برای انتخاب فرمت‌های خروجی مانند PDF، HTML، TIFF یا تصاویر در نظر گرفته نشده است. عبور یک مقدار [SourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sourceformat/) پشتیبانی‌نشده یا نامعتبر منجر به وقوع یک [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) می‌شود.

فایل‌های قدیمی PPT، PPS و POT از همان کانتینر باینری استفاده می‌کنند. وقتی چنین نمایه‌ای از یک جریان بدون پسوند فایل بارگذاری می‌شود، ممکن است یک فایل PPS یا POT به‌عنوان PPT شناسایی شود. اگر نیاز به حفظ این زیرنوع‌های قدیمی باشد، نام فایل یا متادیتای فرمت اصلی را به‌طور جداگانه نگه داشته و هنگام انتخاب نام فایل و فرمت خروجی از آن استفاده کنید.

## **ذخیرهٔ ارائه‌ها در جریان‌ها**

برای نوشتن یک ارائه بدون اتکا به مسیر فایل نهایی، یک جریان قابل نوشتن و مقدار یک [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) را به روش [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید. این رویکرد زمانی مفید است که خروجی باید از یک سرویس وب بازگردانده شود، در پایگاه داده ذخیره گردد یا در حافظه پردازش شود.

مثال زیر یک ارائهٔ جدید را در یک جریان فایل ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **ذخیرهٔ ارائه‌ها با یک نوع نمای از پیش تعریف شده**

می‌توانید نمایی را که PowerPoint هنگام باز کردن اولیهٔ یک ارائه ذخیره‌شده استفاده می‌کند، مشخص کنید. قبل از ذخیره‌سازی، از روش [ViewProperties.setLastView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#setLastView) همراه با یک مقدار [ViewType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewtype/) استفاده کنید.

مثال زیر نمای Slide Master را به عنوان نمای اولیه تنظیم می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ذخیرهٔ ارائه‌ها در فرمت Strict Office Open XML**

برای ایجاد یک فایل PPTX که با پروفایل Strict استاندارد Office Open XML همخوانی داشته باشد، یک نمونهٔ [PptxOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/) ایجاد کنید و از روش [setConformance](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setConformance) آن با مقدار [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) استفاده نمایید. سپس گزینه‌ها را به روش [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **ذخیرهٔ ارائه‌ها در فرمت Office Open XML با حالت Zip64**

یک آرشیو ZIP استاندارد اندازهٔ فشرده‌شده و غیر فشردهٔ هر ورودی، اندازهٔ کل آرشیو و تعداد ورودی‌ها را محدود می‌کند. از آنجایی که فایل PPTX یک آرشیو ZIP است، یک ارائهٔ بسیار بزرگ می‌تواند این محدودیت‌ها را نقض کند. افزونه‌های ZIP64 این محدودیت‌ها را افزایش می‌دهند.

از روش [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setZip64Mode) برای کنترل نوشتن افزونه‌های ZIP64 توسط Aspose.Slides استفاده کنید:

- [IfNecessary](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#IfNecessary) فقط هنگام عبور از محدودیت‌های ZIP استاندارد از ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#Never) افزونه‌های ZIP64 را غیرفعال می‌کند.
- [Always](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#Always) همیشه افزونه‌های ZIP64 را می‌نویسد.

مثال زیر همیشه برای ارائه خروجی افزونه‌های ZIP64 را فعال می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="هشدار" %}}
اگر از [Zip64Mode.Never](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#Never) استفاده شود و ارائه نتواند در محدودیت‌های ZIP استاندارد جا بگیرد، عملیات ذخیره یک [PptxException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxexception/) را پرتاب می‌کند.
{{% /alert %}}

## **ذخیرهٔ ارائه‌ها در فرمت Office Open XML با سطوح فشرده‌سازی**

برای خروجی PPTX، می‌توانید با استفاده از روش [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setCompressionLevel) سرعت ذخیره‌سازی را در مقابل حجم فایل تعادل دهید. کلاس [CompressionLevel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/) این مقادیر را فراهم می‌کند:

- [None](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#None) داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- [Level1](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level1) سریع‌ترین فشرده‌سازی و بزرگ‌ترین خروجی فشرده را فراهم می‌کند.
- [Level2](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level2) تا [Level5](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level5) به‌صورت پیش‌رونده خروجی کوچکتر را نسبت به سرعت ذخیره‌سازی ترجیح می‌دهند.
- [Level6](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level6) بین سرعت ذخیره‌سازی و حجم فایل تعادل می‌یابد. این سطح پیش‌فرض است.
- [Level7](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level8) بیشتر خروجی کوچکتر نسبت به سرعت ذخیره را ترجیح می‌دهند.
- [Level9](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level9) قوی‌ترین فشرده‌سازی را ارائه می‌دهد و بیشترین زمان پردازش را می‌طلبد.

مثال زیر یک ارائه را بدون فشرده‌سازی ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

مثال زیر از حداکثر سطح فشرده‌سازی استفاده می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **ذخیرهٔ ارائه‌ها بدون تازه‌سازی بندانگشتی**

زمانی که یک ارائه به صورت PPTX ذخیره می‌شود، روش [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) کنترل‌کنندهٔ بندانگشتی سند است:

- `True` هنگام عملیات ذخیره‌سازی بندانگشت را دوباره تولید می‌کند. این مقدار پیش‌فرض است.
- `False` بندانگشت موجود را حفظ می‌کند. اگر ارائه بندانگشتی نداشته باشد، Aspose.Slides بندانگشتی جدیدی تولید نمی‌کند.

مثال زیر یک ارائه را بدون تازه‌سازی بندانگشتی ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="یادداشت" %}}
غیرفعال کردن تازه‌سازی بندانگشت می‌تواند زمان لازم برای ذخیرهٔ یک فایل PPTX را کاهش دهد.
{{% /alert %}}

## **گزارش پیشرفت ذخیره به صورت درصد**

برای مانیتور کردن عملیات ذخیره، یک هندلر پیشرفت پایتون را از طریق `jpype.JProxy` ثبت کنید و آن را به روش [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setProgressCallback) پاس دهید. Aspose.Slides سپس متد `reporting` هندلر را با مقادیر پیشرفت در طول صادرات فراخوانی می‌کند.

مثال زیر پیشرفت صادرات PDF را در کنسول گزارش می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="یادداشت" %}}
Aspose یک برنامهٔ رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) ارائه می‌دهد که با API Aspose.Slides ساخته شده است. این برنامه اسلایدهای انتخاب‌شده را از یک ارائه به صورتی فایل‌های جداگانه PPT یا PPTX ذخیره می‌کند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides از ذخیره افزایشی یا «ذخیره سریع» پشتیبانی می‌کند؟**

خیر. هر عملیات ذخیره یک فایل خروجی کامل می‌نویسد نه اینکه فقط بخش‌های تغییر یافته را به‌روز کند.

**آیا چندین ریسه می‌توانند یک نمونهٔ Presentation را ذخیره کنند؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) [thread-safe نیست](/slides/fa/python-java/multithreading/). هر نمونه باید فقط از یک ریسه در هر زمان دسترسی و ذخیره شود.

**چه اتفاقی برای پیوندهای فراخوانی و فایل‌های پیوندی خارجی هنگام ذخیرهٔ یک ارائه می‌افتد؟**

[Hyperlinks](/slides/fa/python-java/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های پیوندی خارجی را کپی نمی‌کند، بنابراین ارائه ذخیره‌شده باید همچنان قادر به دسترسی به مکان‌های آن‌ها باشد.

**آیا می‌توانم متادیتای سند مانند نویسنده، عنوان، شرکت و تاریخ ایجاد را ذخیره کنم؟**

بله. قبل از ذخیره، [document properties](/slides/fa/python-java/presentation-properties/) مناسب را تنظیم کنید و Aspose.Slides آن‌ها را در فایل خروجی می‌نویسد.