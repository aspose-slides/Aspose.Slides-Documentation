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
- نوع نمای از پیش تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- پایتون
- جاوا
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را در پایتون از طریق جاوا با Aspose.Slides به فایل‌ها یا جریان‌ها ذخیره کنید و خروجی PPTX و گزارش‌گیری پیشرفت را پیکربندی کنید."
---
## **نمای کلی**

پس از ایجاد یک ارائه یا [باز کردن یک ارائه موجود](/slides/fa/python-java/open-presentation/)، از روش [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای نوشتن نتیجه استفاده کنید. Aspose.Slides برای Python از طریق Java می‌تواند یک ارائه را در قالب PowerPoint، OpenDocument، PDF و سایر فرمت‌ها به یک فایل یا جریان ذخیره کند. بخش‌های زیر عملیات ذخیره‌سازی استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **ذخیره ارائه‌ها به فایل‌ها**

برای ذخیره یک ارائه در یک فایل، مسیر خروجی و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) را به روش [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) بدهید. مقدار فرمت نوع فایلی را که Aspose.Slides ایجاد می‌کند تعیین می‌کند.

مثال زیر یک ارائه ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # محتواي ارائه را در اینجا اضافه یا ویرایش کنید.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ذخیره ارائه‌ها در قالب اصلی خود**

در یک برنامه پردازش دسته‌ای، ممکن است قالب ورودی از قبل شناخته نشده باشد. پس از بارگذاری یک فایل، قالب اصلی آن را از روش [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSourceFormat) بخوانید. مقدار حاصل [SourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sourceformat/) را به [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/#toSaveFormat) پاس دهید تا مقدار مربوط به [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) به دست آید، سپس از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای نوشتن ارائهٔ اصلاح‌شده استفاده کنید.

مثال کامل زیر هر فایل در یک پوشهٔ ورودی را پردازش می‌کند، عنوان آن را به‌روزرسانی می‌نماید و با همان فرمتی که از آن بارگذاری شده است در یک پوشهٔ خروجی ذخیره می‌کند:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/#toSaveFormat) قالب‌های PPT، PPTX، ODP، PPTM، PPSX، PPSM، POTX، POTM، PPS، POT، OTP، FODP و XML PowerPoint را به قالب‌های ذخیره‌سازی مربوطهٔ ارائه تبدیل می‌کند. این متد تنها قالب‌های منبع ارائه را نگاشت می‌کند؛ برای انتخاب قالب‌های خروجی مانند PDF، HTML، TIFF یا تصاویر هدف‌گذاری نشده است. ارسال مقدار [SourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sourceformat/) پشتیبانی‌نشده یا نامعتبر منجر به بروز [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) می‌شود.

فایل‌های قدیمی PPT، PPS و POT از همان کانتینر باینری استفاده می‌کنند. وقتی چنین ارائه‌ای از یک جریان بدون پسوند فایل بارگذاری می‌شود، ممکن است فایل PPS یا POT به‌عنوان PPT شناخته شود. اگر نیاز به حفظ این زیرنوع‌های قدیمی باشد، نام فایل اصلی یا فرادادهٔ قالب را به‌طور جداگانه نگه داشته و هنگام انتخاب نام فایل و قالب خروجی از آن استفاده کنید.

## **ذخیره ارائه‌ها به جریان‌ها**

برای نوشتن یک ارائه بدون تکیه بر مسیر فایل نهایی، یک جریان قابل نوشتن و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) را به متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید. این رویکرد زمانی مفید است که خروجی باید از یک سرویس وب بازگردانده شود، در پایگاه داده ذخیره گردد یا در حافظه پردازش شود.

مثال زیر یک ارائهٔ جدید را به یک جریان فایل ذخیره می‌کند:

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

می‌توانید نمایی را که PowerPoint در ابتدا برای باز کردن ارائهٔ ذخیره‌شده استفاده می‌کند، مشخص کنید. قبل از ذخیره، از متد [ViewProperties.setLastView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#setLastView) همراه با مقدار [ViewType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewtype/) استفاده کنید.

مثال زیر نمای Slide Master را به‌عنوان نمای اولیه تنظیم می‌کند:

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

برای ایجاد یک فایل PPTX که با پروفایل Strict از Office Open XML سازگار باشد، یک نمونهٔ [PptxOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/) ایجاد کنید و از متد [setConformance](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setConformance) آن با مقدار [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) استفاده کنید. سپس گزینه‌ها را به متد [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید.

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

یک آرشيف ZIP استاندارد اندازهٔ فشرده و غیر فشرده هر ورودی، حجم کلی آرشيف و تعداد ورودی‌ها را محدود می‌کند. چون یک فایل PPTX یک آرشيف ZIP است، یک ارائهٔ بسیار بزرگ می‌تواند از این محدودیت‌ها فراتر رود. افزونه‌های Zip64 این محدودیت‌های مربوط به حجم و تعداد ورودی‌ها را افزایش می‌دهند.

از متد [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setZip64Mode) برای کنترل اینکه آیا Aspose.Slides افزونه‌های ZIP64 را می‌نویسد استفاده کنید:

- [IfNecessary](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#IfNecessary) فقط زمانی ZIP64 را به‌کار می‌برد که ارائه از محدودیت‌های استاندارد ZIP فراتر رود. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#Never) افزونه‌های ZIP64 را غیرفعال می‌کند.
- [Always](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#Always) همیشه افزونه‌های ZIP64 را می‌نویسد.

مثال زیر همیشه افزونه‌های ZIP64 را برای ارائهٔ خروجی فعال می‌کند:

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
اگر [Zip64Mode.Never](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zip64mode/#Never) استفاده شود و ارائه نتواند در محدودیت‌های استاندارد ZIP جا بگیرد، عملیات ذخیره یک [PptxException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxexception/) پرتاب می‌کند.
{{% /alert %}}

## **ذخیره ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

برای خروجی PPTX، می‌توانید سرعت ذخیره‌سازی و اندازهٔ فایل را با استفاده از متد [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setCompressionLevel) متعادل کنید. کلاس [CompressionLevel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/) این مقادیر را ارائه می‌دهد:

- [None](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#None) داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- [Level1](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level1) سریع‌ترین فشرده‌سازی و بزرگ‌ترین خروجی فشرده را ارائه می‌دهد.
- [Level2](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level2) تا [Level5](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level5) به‌تدریج خروجی کوچکتر را نسبت به سرعت ذخیره ترجیح می‌دهند.
- [Level6](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level6) سرعت ذخیره و اندازهٔ فایل را متعادل می‌کند. این سطح پیش‌فرض است.
- [Level7](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compressionlevel/#Level8) بیشتر خروجی کوچکتر را نسبت به سرعت ذخیره ترجیح می‌دهند.
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

مثال زیر از بالاترین سطح فشرده‌سازی استفاده می‌کند:

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

زمانی که یک ارائه به فرمت PPTX ذخیره می‌شود، متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) تصویر بندانگشت سند را کنترل می‌کند:

- `True` تصویر بندانگشت را در طول عملیات ذخیره بازسازی می‌کند. این مقدار پیش‌فرض است.
- `False` تصویر بندانگشت موجود را حفظ می‌کند. اگر ارائه تصویری بندانگشت نداشته باشد، Aspose.Slides یک تصویر جدید تولید نمی‌کند.

مثال زیر یک ارائه را بدون به‌روزرسانی تصویر بندانگشت ذخیره می‌کند:

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
غیرفعال کردن به‌روزرسانی تصویر بندانگشت می‌تواند زمان مورد نیاز برای ذخیرهٔ فایل PPTX را کاهش دهد.
{{% /alert %}}

## **به‌روزرسانی‌های پیشرفت ذخیره به درصد**

برای نظارت بر عملیات ذخیره، یک هندلر پیشرفت پایتون را از طریق `jpype.JProxy` ثبت کنید و آن را به متد [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setProgressCallback) پاس دهید. سپس Aspose.Slides در طول خروجی‌گیری، متد `reporting` هندلر را با مقادیر پیشرفت فراخوانی می‌کند.

مثال زیر پیشرفت خروجی PDF را به کنسول گزارش می‌دهد:

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
Aspose یک [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) رایگان ارائه می‌دهد که با API Aspose.Slides ساخته شده است. این ابزار اسلایدهای انتخاب‌شده را از یک ارائه به‌صورت فایل‌های جداگانهٔ PPT یا PPTX ذخیره می‌کند.
{{% /alert %}}

## **سؤال‌های متداول**

**آیا Aspose.Slides از ذخیره افزایشی یا «ذخیره سریع» پشتیبانی می‌کند؟**

خیر. هر عملیات ذخیره یک فایل خروجی کامل می‌نویسد و فقط بخش‌های تغییر یافته را به‌روزرسانی نمی‌کند.

**آیا چندین رشته می‌توانند همان نمونهٔ Presentation را ذخیره کنند؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) [thread-safe نیست](/slides/fa/python-java/multithreading/). دسترسی و ذخیره هر نمونه فقط از یک رشته در هر زمان انجام شود.

**وقتی یک ارائه را ذخیره می‌کنم، چه اتفاقی برای پیوندها و فایل‌های لینک‌شده خارجی می‌افتد؟**

[Hyperlinks](/slides/fa/python-java/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های لینک‌شده خارجی را کپی نمی‌کند، بنابراین ارائهٔ ذخیره‌شده باید همچنان قادر به دسترسی به مکان‌های آن‌ها باشد.

**آیا می‌توانم متادیتای سند مانند نویسنده، عنوان، شرکت و تاریخ ایجاد را ذخیره کنم؟**

بله. قبل از ذخیره، [خواص سند](/slides/fa/python-java/presentation-properties/) مناسب را تنظیم کنید و Aspose.Slides آن‌ها را در فایل خروجی می‌نویسد.