---
title: ذخیره ارائه‌ها در پایتون
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/python-net/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به استریم
- نوع نمای پیش‌تعریف‌شده
- فرمت Strict Office Open XML
- حالت Zip64
- تازه‌سازی تصویر کوچک
- پیشروی ذخیره‌سازی
- پایتون
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را در پایتون با Aspose.Slides به فایل‌ها یا استریم‌ها ذخیره کنید و گزینه‌های خروجی PPTX را پیکربندی کنید."
---
## **مرور کلی**

بعد از اینکه یک ارائه ایجاد کردید یا [یک ارائه موجود را باز کنید](/slides/fa/python-net/open-presentation/)، از متد [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ipresentation/save/) برای نوشتن نتیجه استفاده کنید. Aspose.Slides for Python via .NET می‌تواند یک ارائه را به صورت فایل یا استریم در قالب‌های PowerPoint، OpenDocument، PDF و سایر فرمت‌ها ذخیره کند. بخش‌های زیر عملیات ذخیره‌سازی استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **ذخیره ارائه‌ها به فایل‌ها**

برای ذخیره یک ارائه به فایل، مسیر خروجی و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) را به متد [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ipresentation/save/) پاس بدهید. مقدار فرمت نوع فایلی که Aspose.Slides ایجاد می‌کند را تعیین می‌کند.

مثال زیر یک ارائه ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # افزودن یا تغییر محتوای ارائه در اینجا.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **ذخیره ارائه‌ها در قالب اصلی خود**

برای مثال‌های تشخیص فایل و استریم، رفتار ارائه‌های تازه ایجاد شده، و تمایز بین قالب منبع و خروجی، به [Determine the Original Presentation Format](/slides/fa/python-net/detect-presentation-source-format/) مراجعه کنید.

در یک برنامه پردازش دسته‌ای، قالب ورودی ممکن است از پیش شناخته شده نباشد. پس از بارگذاری یک فایل، قالب اصلی آن را از ویژگی [Presentation.source_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/source_format/) بخوانید. مقدار [SourceFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sourceformat/) حاصل را به [SlideUtil.to_save_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/to_save_format/) پاس دهید تا مقدار متناظر [SaveFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) به دست آید و سپس از [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ipresentation/save/) برای نوشتن ارائه اصلاح‌شده استفاده کنید.

مثال کامل زیر هر فایل در یک پوشه ورودی را پردازش می‌کند، عنوان آن را به‌روزرسانی می‌کند و در قالبی که از آن بارگذاری شده به پوشه خروجی ذخیره می‌نماید:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/to_save_format/) قالب‌های PPT، PPTX، ODP، PPTM، PPSX، PPSM، POTX، POTM، PPS، POT، OTP، FODP و XML PowerPoint را به فرمت‌های ذخیره‌سازی معادل آنها تبدیل می‌کند. این متد فقط قالب‌های منبع ارائه را تبدیل می‌کند؛ هدف آن انتخاب قالب‌های خروجی مانند PDF، HTML، TIFF یا تصاویر نیست. ارسال مقدار [SourceFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sourceformat/) غیرقابلیت یا نامعتبر باعث رخ دادن یک استثنا می‌شود.

فایل‌های PPT، PPS و POT قدیمی از یک ساختار باینری یکسان استفاده می‌کنند. وقتی چنین ارائه‌ای از یک استریم بدون پسوند فایل بارگذاری شود، ممکن است یک فایل PPS یا POT به‌عنوان PPT شناسایی شود. اگر نیاز به حفظ این زیرنوع‌های قدیمی باشد، نام فایل یا فراداده قالب اصلی را به طور جداگانه نگه دارید و هنگام انتخاب نام فایل و قالب خروجی از آن استفاده کنید.

## **ذخیره ارائه‌ها به استریم‌ها**

برای نوشتن یک ارائه بدون اتکا به مسیر نهایی فایل، یک استریم [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) قابل نوشتن و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) را به متد [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ipresentation/save/) پاس دهید. این روش زمانی مفید است که خروجی باید از یک سرویس وب بازگردانده شود، در پایگاه داده ذخیره شود یا در حافظه پردازش گردد.

مثال زیر یک ارائه جدید را در یک استریم فایل ذخیره می‌کند:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **ذخیره ارائه‌ها با نوع نمای از پیش تعریف‌شده**

می‌توانید نمایی را که PowerPoint به‌صورت اولیه یک ارائه ذخیره‌شده را باز می‌کند، مشخص کنید. قبل از ذخیره، ویژگی [ViewProperties.last_view](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/last_view/) را به مقدار [ViewType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewtype/) تنظیم کنید.

مثال زیر نمای Slide Master را به عنوان نمای اولیه تنظیم می‌کند:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **ذخیره ارائه‌ها در فرمت Strict Office Open XML**

برای ایجاد یک فایل PPTX که با پروفایل Strict از Office Open XML سازگار باشد، یک نمونه از [PptxOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/) ایجاد کنید و ویژگی [conformance](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/conformance/) آن را روی `Conformance.ISO_29500_2008_STRICT` تنظیم کنید. سپس گزینه‌ها را به متد [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ipresentation/save/) پاس دهید.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **ذخیره ارائه‌ها در فرمت Office Open XML با حالت Zip64**

یک آرشیو ZIP استاندارد اندازه فشرده‌شده و غیرفشرده هر ورودی، اندازه کل آرشیو و تعداد ورودی‌ها را محدود می‌کند. از آنجا که یک فایل PPTX یک آرشیو ZIP است، یک ارائه بسیار بزرگ می‌تواند از این محدودیت‌ها فراتر رود. افزونه‌های ZIP64 این محدودیت‌های اندازه و تعداد ورودی را افزایش می‌دهند.

از ویژگی [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) برای کنترل اینکه آیا Aspose.Slides افزونه‌های ZIP64 را می‌نویسد یا نه استفاده کنید:

- `IF_NECESSARY` فقط زمانی که ارائه از محدودیت‌های استاندارد ZIP عبور کند، از ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- `NEVER` افزونه‌های ZIP64 را غیرفعال می‌کند.
- `ALWAYS` همیشه افزونه‌های ZIP64 را می‌نویسد.

مثال زیر همیشه افزونه‌های ZIP64 را برای ارائه خروجی فعال می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
If `Zip64Mode.NEVER` استفاده شود و ارائه نتواند در محدودیت‌های استاندارد ZIP جا بگیرد، عملیات ذخیره یک [PptxException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxexception/) را ایجاد می‌کند.
{{% /alert %}}

## **ذخیره ارائه‌ها در فرمت Office Open XML با سطوح فشرده‌سازی**

برای خروجی PPTX، می‌توانید سرعت ذخیره‌سازی را نسبت به حجم فایل با تنظیم ویژگی [PptxOptions.compression_level](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/compression_level/) متعادل کنید. شمارش [CompressionLevel](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/) این مقادیر را ارائه می‌دهد:

- `NONE` داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- `LEVEL1` سریع‌ترین فشرده‌سازی و بزرگ‌ترین خروجی فشرده را فراهم می‌کند.
- `LEVEL2` تا `LEVEL5` به‌صورت پیش‌رونده خروجی کوچکتر را نسبت به سرعت ذخیره ترجیح می‌دهند.
- `LEVEL6` سرعت ذخیره و حجم فایل را متعادل می‌کند. این سطح پیش‌فرض است.
- `LEVEL7` و `LEVEL8` بیشتر خروجی کوچکتر را نسبت به سرعت ذخیره ترجیح می‌دهند.
- `LEVEL9` قوی‌ترین فشرده‌سازی را ارائه می‌دهد و بیشترین زمان پردازش را می‌طلبد.

مثال زیر یک ارائه را بدون فشرده‌سازی ذخیره می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

مثال زیر از حداکثر سطح فشرده‌سازی استفاده می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **ذخیره ارائه‌ها بدون تازه‌سازی تصویر کوچک**

هنگامی که یک ارائه به صورت PPTX ذخیره می‌شود، ویژگی [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) تصویر کوچک سند آن را کنترل می‌کند:

- `True` تصویر کوچک را در حین عملیات ذخیره بازتولید می‌کند. این مقدار پیش‌فرض است.
- `False` تصویر کوچک موجود را حفظ می‌کند. اگر ارائه تصویر کوچکی نداشته باشد، Aspose.Slides یکی تولید نمی‌کند.

مثال زیر یک ارائه را بدون تازه‌سازی تصویر کوچک آن ذخیره می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
غیرفعال کردن تازه‌سازی تصویر کوچک می‌تواند زمان مورد نیاز برای ذخیره فایل PPTX را کاهش دهد.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose یک [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) رایگان ارائه می‌دهد که با API Aspose.Slides ساخته شده است. این ابزار اسلایدهای انتخاب‌شده از یک ارائه را به‌صورت فایل‌های جداگانه PPT یا PPTX ذخیره می‌کند.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا Aspose.Slides از ذخیره‌سازی افزایشی یا “ذخیره‌سازی سریع” پشتیبانی می‌کند؟**

خیر. هر عملیات ذخیره یک فایل خروجی کامل می‌نویسد و فقط بخش‌های تغییر یافته را به‌روز نمی‌کند.

**آیا چندین رشته می‌توانند همان نمونه Presentation را ذخیره کنند؟**

خیر. یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) [thread-safe نیست](/slides/fa/python-net/multithreading/). هر نمونه باید فقط توسط یک رشته در هر زمان دسترسی و ذخیره شود.

**هنگامی که یک ارائه را ذخیره می‌کنم، چه اتفاقی برای پیوندهای فراخوانی و فایل‌های لینک‌خورده خارجی می‌افتد؟**

[Hyperlinks](/slides/fa/python-net/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های لینک‌خورده خارجی را کپی نمی‌کند، بنابراین ارائه ذخیره‌شده باید همچنان قادر به دسترسی به مکان‌های آن‌ها باشد.

**آیا می‌توانم فراداده‌های سند مانند نویسنده، عنوان، شرکت و تاریخ ایجاد را ذخیره کنم؟**

بله. قبل از ذخیره، [document properties](/slides/fa/python-net/presentation-properties/) مناسب را تنظیم کنید و Aspose.Slides آنها را در فایل خروجی می‌نویسد.