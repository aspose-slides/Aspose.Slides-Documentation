---
title: تعیین قالب اصلی ارائه در پایتون از طریق جاوا
linktitle: قالب منبع
type: docs
weight: 35
url: /fa/python-java/detect-presentation-source-format/
keywords:
- قالب منبع
- شناسایی قالب ارائه
- PowerPoint
- OpenDocument
- ارائه
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "قالب اصلی یک ارائه بارگذاری‌شده را در پایتون از طریق جاوا با Aspose.Slides برای پایتون از طریق جاوا بخوانید، APIهای شناسایی را مقایسه کنید و با فایل‌ها، جریان‌ها و قالب‌های قدیمی کار کنید."
---
## **نمای کلی**

پس از بارگذاری یک ارائه، متد [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSourceFormat) را فراخوانی کنید تا قالب اصلی آن را تعیین کنید. از آن استفاده کنید وقتی پردازش بعدی به قالبی که نمونهٔ فعلی از آن بارگذاری شده وابسته است.

قالب منبع متفاوت از [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) انتخاب‌شده برای فایل خروجی است. ذخیره‌سازی به قالب دیگری، قالب منبع نمونه موجود را تغییر نمی‌دهد.

مثال‌ها به Aspose.Slides برای Python از طریق Java و یک محیط اجرا (runtime) جاوا سازگار نیاز دارند. هر مثال JVM را در صورتی که هنوز اجرا نشده باشد، راه‌اندازی می‌کند.

## **خواندن قالب منبع یک فایل**

این مثال به یک فایل `sample.pptx` موجود نیاز دارد. فایل را بارگذاری می‌کند و سیاست پردازش برنامه را با استفاده از [Presentation.getSourceFormat] به‌جای نام فایل انتخاب می‌کند. مسیر ورودی را برای آزمایش قالب‌های دیگر تغییر دهید. مثال مقدار سیاست منتخب را چاپ می‌کند؛ پیام‌ها را با منطق برنامه خود جایگزین کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **شناسایی مقادیر پشتیبانی‌شده**

کلاس [SourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sourceformat/) ثابت‌های عدد صحیحی را تعریف می‌کند که قالب‌های ارائه زیر را متمایز می‌کند. پسوندهای زیر، پسوندهای مرسوم هستند و بازسازی نام فایل اصلی نیستند.

| مقدار SourceFormat | پسوند | قالب |
| --- | --- | --- |
| `Ppt` | `.ppt` | ارائه PowerPoint 97–2003 |
| `Pptx` | `.pptx` | ارائه Office Open XML |
| `Pptm` | `.pptm` | ارائه Office Open XML با ماکرو |
| `Pps` | `.pps` | نمایش اسلاید PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | نمایش اسلاید Office Open XML |
| `Ppsm` | `.ppsm` | نمایش اسلاید Office Open XML با ماکرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML با ماکرو |
| `Odp` | `.odp` | ارائه OpenDocument |
| `Otp` | `.otp` | قالب ارائه OpenDocument |
| `Fodp` | `.fodp` | ارائه Flat XML ODF |
| `Xml` | `.xml` | ارائه PowerPoint XML |

## **خواندن قالب منبع از یک جریان**

این مثال به یک فایل `sample.pps` موجود نیاز دارد. خواندن بایت‌های آن به یک جریان حافظه، ورودی بدون نام فایل را شبیه‌سازی می‌کند، مثلاً مقداری از پایگاه داده یا آرایه بایتی بارگذاری‌شده. سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) تنها جریان را می‌پذیرد. پایتون بایت‌های فایل را می‌خواند و JPype آنها را به آرایه بایتی جاوا برای جریان حافظهٔ جاوا تبدیل می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT، PPS و POT از همان قالب باینری زیرساختی استفاده می‌کنند. هنگام بارگذاری با مسیر فایل، پسوند می‌تواند برای متمایز کردن نمایش اسلاید یا قالب مفید باشد. بدون نام فایل، محتوای PPS و POT قدیمی ممکن است به‌عنوان `SourceFormat.Ppt` گزارش شود؛ مثال PPS فوق مقدار عددی `SourceFormat.Ppt` را چاپ می‌کند.

اگر برنامهٔ شما باید این تمایز را حفظ کند، نام فایل اصلی یا فرادادهٔ زیرنوع را به‌صورت جداگانه نگه دارید. پسوند یک اشارهٔ مفید برای این زیرنوع‌های قدیمی است، اما نباید تنها معیار شناسایی محتوای ارائهٔ دلخواه باشد.

## **مقایسه تشخیص قبل و بعد از بارگذاری**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) و [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#getLoadFormat) زمانی استفاده کنید که نیاز به بازرسی فایل قبل از بارگذاری کامل مدل شیء ارائه دارید. وقتی نمونهٔ ارائه از پیش وجود دارد، از [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSourceFormat) استفاده کنید.

این مثال به `sample.pptx` نیاز دارد و مقادیر عددی `LoadFormat.Pptx` و `SourceFormat.Pptx` را به ترتیب چاپ می‌کند. در محیط تولید، API متناسب با مرحلهٔ پردازش خود را انتخاب کنید؛ یک ارائهٔ قبلاً بارگذاری‌شده نیازی به بازرسی دوم فقط برای به‌دست‌آوردن قالب منبع ندارد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

نتایج از ثابت‌های کلاس‌های مختلف استفاده می‌کنند: [LoadFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sourceformat/). مقدار عددی آنها را مقایسه نکنید و فرض نکنید هر قالب نتایج تشخیص یکسانی دارد. PowerPoint XML می‌تواند قبل از بارگذاری به‌عنوان `LoadFormat.Unknown` گزارش شود و پس از بارگذاری به‌عنوان `SourceFormat.Xml`.

## **حفظ قالب منبع و قالب خروجی جداگانه**

این مثال به `sample.pptx` نیاز دارد و `converted.odp` را می‌نویسد. مقدار عددی `SourceFormat.Pptx` را هم قبل و هم بعد از ذخیرهٔ نمونهٔ اصلی چاپ می‌کند. تنها نمونهٔ جدید بارگذاری‌شده از خروجی ODP، `Odp` را گزارش می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

ارائه‌ای که از ابتدا با `Presentation()` ساخته می‌شود، `SourceFormat.Pptx` را گزارش می‌دهد. این ارائه فایل ورودی ندارد: این مقدار پیش‌فرض برای یک نمونهٔ تازه‌ساخت است و نشانگر بارگذاری فایل PPTX نیست. اگر این تمایز برای برنامهٔ شما مهم است، به‌طور جداگانه ردیابی کنید که آیا نمونه ساخته شده یا بارگذاری شده است.

## **نقشه‌برداری قالب منبع به پسوند**

مثال زیر به `sample.pptx` نیاز دارد. هر مقدار currently supported [SourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sourceformat/) را به یک پسوند مرسوم تبدیل می‌کند، بدون تجزیه نام فایل ورودی. مکان بازگشتی از اختصاص ساکت پسوند به مقدار ناشناخته جلوگیری می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

این نگاشت فایل را تبدیل نمی‌کند و زیرنوع PPS/POT از دست رفته در بارگذاری جریان را بازنشانی نمی‌کند. برای ذخیرهٔ واقعی، به‌صورت صریح یک [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) انتخاب کنید یا از تبدیل نشان‌داده شده در [Save Presentations in Their Original Format](/slides/fa/python-java/save-presentation/#save-presentations-in-their-original-format) استفاده کنید.

## **تأیید قالب‌ها با ذخیره و باز کردن مجدد**

این مثال خودکفا یک ارائه ایجاد می‌کند و سه فایل را در پوشهٔ کاری می‌نویسد، فایل‌های هم‌نام را بازنویسی می‌کند. هر خروجی هم از طریق مسیر و هم از طریق یک جریان حافظه مجدداً باز می‌شود. برای PPTX و ODP، هر دو مسیر قالب ذخیره‌شده را گزارش می‌کنند. برای PPS، بارگذاری با مسیر `Pps` را گزارش می‌کند، در حالی که بارگذاری همان بایت‌ها بدون نام فایل `Ppt` را گزارش می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

جدول زیر شناسایی قالب منبع برای ارائه‌های با پسوندهای مطابق را خلاصه می‌کند. نام‌ها ثابت‌ها را نشان می‌دهند؛ مثال‌های پایتون مقدار عددی آنها را چاپ می‌کنند:

| قالب ذخیره‌شده | SourceFormat از مسیر فایل | SourceFormat از جریان بدون نام |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | به ترتیب `Pptx`، `Pptm` | همانند مسیر فایل |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | به ترتیب `Ppsx`، `Ppsm` | همانند مسیر فایل |
| POT | `Pot` | `Ppt` |
| POTX, POTM | به ترتیب `Potx`، `Potm` | همانند مسیر فایل |
| ODP, OTP | به ترتیب `Odp`، `Otp` | همانند مسیر فایل |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتوای PPS/POT در جریان‌های بدون نام به‌عنوان `Ppt` شناسایی می‌شود. جدول شناسایی قالب را توصیف می‌کند، نه حفظ تمام ویژگی‌های ارائه هنگام تبدیل.

## **سوالات متداول**

**آیا ذخیره‌سازی به ODP قالب منبع یک ارائه بارگذاری‌شده از PPTX را تغییر می‌دهد؟**

خیر. نمونهٔ موجود همچنان `Pptx` را گزارش می‌دهد. نمونه‌ای که از فایل ODP ذخیره‌شده بارگذاری می‌شود، `Odp` را گزارش می‌کند.

**آیا یک جریان همیشه می‌تواند یک ارائهٔ قدیمی، نمایش اسلاید یا قالب را متمایز کند؟**

خیر. PPT، PPS و POT قالب باینری مشترکی دارند. وقتی این تمایز لازم است، نام فایل یا فرادادهٔ زیرنوع را به‌صورت جداگانه نگه دارید.

**کدام API را باید استفاده کنم اگر ارائه قبلاً بارگذاری شده باشد؟**

متد [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSourceFormat) را بخوانید. برای بازرسی قبل از بارگذاری، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) استفاده کنید.