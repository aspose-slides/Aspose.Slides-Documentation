---
title: ذخیره ارائه‌ها در Python از طریق Java
linktitle: ذخیره ارائه
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
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- Python
- Java
- Aspose.Slides
description: "PowerPoint و OpenDocument را در Python از طریق Java با Aspose.Slides به فایل‌ها یا جریان‌ها ذخیره کنید و خروجی PPTX و گزارش پیشرفت را پیکربندی کنید."
---
## **مرور کلی**

پس از اینکه یک ارائه ایجاد کردید یا [یک ارائه موجود را باز کردید](/slides/fa/python-java/open-presentation/)، از متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای نوشتن نتیجه استفاده کنید. Aspose.Slides برای Python از طریق Java می‌تواند یک ارائه را در قالب PowerPoint، OpenDocument، PDF و سایر فرمت‌ها به یک فایل یا جریان ذخیره کند. بخش‌های زیر عملیات ذخیره‌سازی استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **ذخیره ارائه‌ها در فایل‌ها**

برای ذخیره یک ارائه در یک فایل، مسیر خروجی و مقدار یک [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) را به متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید. مقدار فرمت تعیین می‌کند که Aspose.Slides چه نوع فایلی ایجاد کند.

مثال زیر یک ارائه ایجاد می‌کند و آن را به‌صورت فایل PPTX ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # محتوای ارائه را اینجا اضافه یا تغییر دهید.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ذخیره ارائه‌ها در قالب اصلی خود**

برای مثال‌های تشخیص فایل و جریان، رفتار ارائه‌های جدید ایجاد‌شده و تمایز بین قالب‌های منبع و خروجی، به [Determine the Original Presentation Format](/slides/fa/python-java/detect-presentation-source-format/) مراجعه کنید.

در یک برنامهٔ پردازش دسته‌ای، قالب ورودی ممکن است از پیش شناخته‌شده نباشد. پس از بارگذاری یک فایل، قالب اصلی آن را از متد [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSourceFormat) بخوانید. مقدار حاصل [SourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sourceformat/) را به [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/#toSaveFormat) پاس دهید تا مقدار متناظر [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) به دست آید و سپس از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای نوشتن ارائهٔ اصلاح‌شده استفاده کنید.

مثال کامل زیر هر فایلی را در یک پوشهٔ ورودی پردازش می‌کند، عنوان آن را به‌روز می‌نماید و در قالبی که از آن بارگذاری شده بود به یک پوشهٔ خروجی ذخیره می‌کند:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/#toSaveFormat) قالب‌های PPT، PPTX، ODP، PPTM، PPSX، PPSM، POTX، POTM، PPS، POT، OTP، FODP و PowerPoint XML را به فرمت‌های ذخیره‌سازی مربوطهٔ ارائه تبدیل می‌کند. این متد فقط قالب‌های منبع ارائه را نگاشت می‌کند؛ برای انتخاب فرمت‌های خروجی مانند PDF، HTML، TIFF یا تصاویر مورد استفاده قرار نمی‌گیرد. پاس دادن یک مقدار [SourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sourceformat/) پشتیبانی‌نشده یا نامعتبر باعث بروز یک [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) می‌شود.

فایل‌های Legacy PPT، PPS و POT از یک مخزن باینری یکسان استفاده می‌کنند. وقتی چنین ارائه‌ای بدون پسوند فایل از یک جریان بارگذاری شود، ممکن است یک فایل PPS یا POT به‌عنوان PPT شناسایی شود. اگر نگهداری این زیرنوع‌های قدیمی لازم باشد، نام فایل یا فرادادهٔ قالب اصلی را جداگانه ذخیره کنید و هنگام انتخاب نام و قالب خروجی از آن استفاده نمایید.

## **ذخیره ارائه‌ها در جریان‌ها**

برای نوشتن یک ارائه بدون اتکا به مسیر نهایی فایل، یک جریان قابل نوشتن و مقدار یک [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) را به متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید. این رویکرد هنگامی مفید است که خروجی باید از یک سرویس وب برگردانده شود، در پایگاه داده ذخیره گردد یا در حافظه پردازش شود.

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

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

می‌توانید نمایی که PowerPoint هنگام باز کردن اولیهٔ یک ارائهٔ ذخیره‌شده استفاده می‌کند را مشخص کنید. قبل از ذخیره، از متد [ViewProperties.setLastView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#setLastView) همراه با یک مقدار [ViewType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewtype/) استفاده کنید.

مثال زیر نمای Slide Master را به‌عنوان نمای اولیهٔ باز شدن تنظیم می‌کند:

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

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

برای ایجاد یک فایل PPTX که با پروفایل Strict استاندارد Office Open XML سازگار باشد، یک نمونهٔ [PptxOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/) ایجاد کنید و با متد [setConformance](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setConformance) مقدار [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) را تنظیم کنید. سپس این گزینه‌ها را به متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید.

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

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک آرشیو ZIP استاندارد اندازهٔ فشرده‌ و غیر فشردهٔ هر ورودی، اندازهٔ کل آرشیو و تعداد ورودی‌ها را محدود می‌کند. از آنجا که فایل PPTX یک آرشیو ZIP است، یک ارائهٔ بسیار بزرگ می‌تواند از این محدودیت‌ها عبور کند. افزونه‌های Zip64 این محدودیت‌ها را افزایش می‌دهند.

از متد [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setZip64Mode) برای کنترل اینکه آیا Aspose.Slides افزونه‌های Zip64 بنویسد یا نه، استفاده کنید:

- [IfNecessary](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#IfNecessary) تنها زمانی که ارائه از محدودیت‌های ZIP استاندارد عبور کند، از Zip64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#Never) افزونه‌های Zip64 را غیرفعال می‌کند.
- [Always](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#Always) همیشه افزونه‌های Zip64 را می‌نویسد.

مثال زیر همواره برای ارائهٔ خروجی افزونه‌های Zip64 را فعال می‌کند:

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

{{% alert color="warning" title="Warning" %}}
اگر از [Zip64Mode.Never](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#Never) استفاده شود و ارائه نتواند در محدودیت‌های استاندارد ZIP جا بگیرد، عملیات ذخیره‌سازی یک [PptxException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxexception/) را پرتاب می‌کند.
{{% /alert %}}

## **ذخیره ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

برای خروجی PPTX می‌توانید با استفاده از متد [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setCompressionLevel) سرعت ذخیره‌سازی را در مقابل حجم فایل متعادل کنید. کلاس [CompressionLevel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/) این مقادیر را فراهم می‌کند:

- [None](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#None) داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- [Level1](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level1) سریع‌ترین فشرده‌سازی و بزرگ‌ترین خروجی فشرده را تولید می‌کند.
- [Level2](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level2) تا [Level5](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level5) به‌تدریج خروجی کوچک‌تر را نسبت به سرعت ذخیره‌سازی ترجیح می‌دهند.
- [Level6](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level6) تعادل بین سرعت ذخیره‌سازی و حجم فایل را برقرار می‌کند. این سطح پیش‌فرض است.
- [Level7](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level8) بیشتر به خروجی کوچک‌تر نسبت به سرعت ذخیره‌سازی اهمیت می‌دهند.
- [Level9](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level9) قوی‌ترین فشرده‌سازی را فراهم می‌کند و زمان پردازش بیشتری می‌طلبد.

مثال زیر ارائه‌ای را بدون فشرده‌سازی ذخیره می‌کند:

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

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

هنگامی که یک ارائه به‌صورت PPTX ذخیره می‌شود، متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) کنترل‌کنندهٔ تصویر بندانگشتی سند است:

- `True` در طول عملیات ذخیره‌سازی تصویر بندانگشتی را بازتولید می‌کند. این مقدار پیش‌فرض است.
- `False` تصویر بندانگشتی موجود را حفظ می‌کند. اگر ارائه تصویر بندانگشتی نداشته باشد، Aspose.Slides تصویر جدیدی تولید نمی‌کند.

مثال زیر ارائه‌ای را بدون به‌روزرسانی تصویر بندانگشتی ذخیره می‌کند:

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

{{% alert color="info" title="Note" %}}
غیرفعال کردن به‌روزرسانی تصویر بندانگشتی می‌تواند زمان لازم برای ذخیره یک فایل PPTX را کاهش دهد.
{{% /alert %}}

## **گزارش پیشرفت ذخیره‌سازی به صورت درصد**

برای نظارت بر عملیات ذخیره‌سازی، یک هندلر پیشرفت Python را از طریق `jpype.JProxy` ثبت کنید و آن را به متد [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setProgressCallback) پاس دهید. سپس Aspose.Slides هنگام خروجی‌گیری، متد `reporting` هندلر را با مقادیر پیشرفت فراخوانی می‌کند.

مثال زیر پیشرفت خروجی PDF را در کنسول گزارش می‌کند:

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

{{% alert color="info" title="Note" %}}
Aspose یک [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) رایگان فراهم می‌کند که با API Aspose.Slides ساخته شده است. این ابزار اسلایدهای انتخابی را از یک ارائه به‌صورت فایل‌های جداگانهٔ PPT یا PPTX ذخیره می‌کند.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا Aspose.Slides از ذخیره‌سازی افزایشی یا «ذخیره‌سازی سریع» پشتیبانی می‌کند؟**

خیر. هر عملیات ذخیره‌سازی یک فایل خروجی کامل می‌نویسد و فقط بخش‌های تغییر یافته را به‑روز نمی‌کند.

**آیا چند نخ می‌توانند همزمان همان شیء Presentation را ذخیره کنند؟**

خیر. یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) **ایمن برای چندنخی نیست** (/slides/fa/python-java/multithreading/). هر شیء باید فقط از یک نخ در هر زمان دسترسی و ذخیره شود.

**هنگام ذخیرهٔ یک ارائه، چه اتفاقی برای پیوندهای فراگیر و فایل‌های خارجی لینک‌دار می‌افتد؟**

[Hyperlinks](/slides/fa/python-java/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های خارجی را کپی نمی‌کند، بنابراین ارائهٔ ذخیره‌شده باید همچنان قادر به دسترسی به مکان‌های آن‌ها باشد.

**آیا می‌توانم متادیتای سند مانند نویسنده، عنوان، شرکت و تاریخ ایجاد را ذخیره کنم؟**

بله. قبل از ذخیره، ویژگی‌های مناسب [document properties](/slides/fa/python-java/presentation-properties/) را تنظیم کنید و Aspose.Slides آن‌ها را در فایل خروجی می‌نویسد.