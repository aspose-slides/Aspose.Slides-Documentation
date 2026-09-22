---
title: تشخیص قالب اصلی ارائه در پایتون
linktitle: قالب منبع
type: docs
weight: 35
url: /fa/python-net/detect-presentation-source-format/
keywords:
- قالب منبع
- تشخیص قالب ارائه
- پاورپوینت
- OpenDocument
- ارائه
- PPT
- PPTX
- پایتون
- Aspose.Slides
description: "قالب اصلی یک ارائه بارگذاری‌شده را در پایتون با Aspose.Slides برای پایتون از طریق .NET بخوانید، APIهای تشخیص را مقایسه کنید و با فایل‌ها، جریان‌ها و قالب‌های قدیمی کار کنید."
---
## **بررسی کلی**

پس از بارگذاری یک ارائه، ویژگی فقط‑خواندنی [Presentation.source_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/source_format/) را برای تعیین قالب اصلی آن بخوانید. از آن زمانی که پردازش بعدی به قالبی که نمونهٔ فعلی از آن بارگذاری شده وابسته است، استفاده کنید.

قالب منبع با [SaveFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) انتخاب‌شده برای فایل خروجی متفاوت است. ذخیره‌سازی به قالب دیگر، قالب منبع نمونهٔ موجود را تغییر نمی‌دهد.

## **خواندن قالب منبع یک فایل**

این مثال به فایلی به نام `sample.pptx` موجود نیاز دارد. فایل را بارگذاری کرده و سیاست پردازش برنامه را با استفاده از [Presentation.source_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/source_format/) انتخاب می‌کند، نه با نام فایل. مسیر ورودی را تغییر دهید تا قالب‌های دیگر را امتحان کنید. مثال سیاست انتخاب‌شده را چاپ می‌کند؛ پیام‌ها را با منطق برنامهٔ خود جایگزین کنید.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **شناسایی مقادیر پشتیبانی‌شده**

تعداد [SourceFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sourceformat/) قالب‌های ارائهٔ زیر را متمایز می‌کند. پسوندهای زیر پسوندهای متعارف هستند و بازسازی نام فایل اصلی نیستند.

| مقدار SourceFormat | پسوند | قالب |
| --- | --- | --- |
| `PPT` | `.ppt` | ارائهٔ PowerPoint 97–2003 |
| `PPTX` | `.pptx` | ارائهٔ Office Open XML |
| `PPTM` | `.pptm` | ارائهٔ Office Open XML با ماکرو |
| `PPS` | `.pps` | نمایش اسلاید PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | نمایش اسلاید Office Open XML |
| `PPSM` | `.ppsm` | نمایش اسلاید Office Open XML با ماکرو |
| `POT` | `.pot` | قالب PowerPoint 97–2003 |
| `POTX` | `.potx` | قالب Office Open XML |
| `POTM` | `.potm` | قالب Office Open XML با ماکرو |
| `ODP` | `.odp` | ارائهٔ OpenDocument |
| `OTP` | `.otp` | قالب ارائهٔ OpenDocument |
| `FODP` | `.fodp` | ارائهٔ OpenDocument XML همسطح |
| `XML` | `.xml` | ارائهٔ PowerPoint XML |

## **خواندن قالب منبع یک جریان**

این مثال به فایلی به نام `sample.pps` موجود نیاز دارد. خواندن بایت‌های آن به یک جریان حافظه ورودی را شبیه‌سازی می‌کند که بدون نام فایل دریافت می‌شود، مانند مقدار یک پایگاه داده یا آرایه بایتی بارگذاری‌شده. سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) فقط جریان را دریافت می‌کند.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT، PPS و POT از همان قالب باینری زیرساختی استفاده می‌کنند. هنگام بارگذاری از مسیر فایل، پسوند می‌تواند به تمایز نمایش اسلاید یا قالب کمک کند. بدون نام فایل، محتوای قدیمی PPS و POT ممکن است به عنوان `SourceFormat.PPT` گزارش شود؛ مثال PPS در بالا `PPT` را گزارش می‌دهد.

اگر برنامهٔ شما نیاز به حفظ این تمایز داشته باشد، نام فایل اصلی یا فرادادهٔ زیرنوع را به‌صورت جداگانه نگه دارید. پسوند یک راهنمای مفید برای این زیرنوع‌های قدیمی است، اما نباید تنها معیار شناسایی محتوای ارائهٔ دلخواه باشد.

## **مقایسهٔ تشخیص قبل و بعد از بارگذاری**

از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) و [PresentationInfo.load_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/load_format/) زمانی که نیاز به بازرسی فایل پیش از بارگذاری کامل مدل شیء ارائه دارید استفاده کنید. زمانی که نمونهٔ موجود است، از [Presentation.source_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/source_format/) استفاده کنید.

این مثال به `sample.pptx` نیاز دارد و برای هر دو بررسی `PPTX` را چاپ می‌کند. در تولید، API مناسب به مرحلهٔ پردازش خود انتخاب کنید؛ یک ارائهٔ از قبل بارگذاری‌شده نیازی به بازرسی دوم فقط برای دریافت قالب منبع خود ندارد.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

نتایج دارای انواع شمارشی متفاوتی هستند: [LoadFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sourceformat/). آنها را با تبدیل مقادیر عددی به‌هم مقایسه نکنید و فرض نکنید هر قالب نتایج تشخیص یکسانی دارد. در بررسی ذخیره‌‑و‑بازگشایی زیر، PowerPoint XML قبل از بارگذاری به عنوان `LoadFormat.UNKNOWN` و بعد از بارگذاری به عنوان `SourceFormat.XML` گزارش شد.

## **جداسازی قالب منبع و خروجی**

این مثال به `sample.pptx` نیاز دارد و `converted.odp` را می‌نویسد. قبل و بعد از ذخیرهٔ نمونهٔ اصلی هر دو بار `PPTX` را چاپ می‌کند. تنها نمونهٔ جدیدی که از خروجی ODP بارگذاری می‌شود، `ODP` را گزارش می‌دهد.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

یک ارائهٔ ساخته‌شده از نو با `slides.Presentation()` گزارش می‌دهد `SourceFormat.PPTX`. این ارائه ورودی ندارد: این مقدار پیش‌فرض برای یک نمونهٔ تازه ایجاد‌شده است، نه مدرکی بر بارگذاری فایل PPTX. اگر تمایز ایجاد یا بارگذاری برای برنامهٔ شما مهم است، این اطلاعات را به‌جدا پیگیری کنید.

## **نقشه‌برداری قالب منبع به پسوند**

این مثال به `sample.pptx` نیاز دارد. هر مقدار [SourceFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sourceformat/) که هم‌اکنون پشتیبانی می‌شود را به پسوند متعارف متناظر می‌کند، بدون تجزیهٔ نام فایل ورودی. اگر مقدار شناسایی‌نشده باشد، از اختصاص ساکن یک پسوند به‌صورت بی‌صدا اجتناب می‌کند.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

این نگاشت فایلی را تبدیل یا زیرنوع PPS/POT قدیمی که در هنگام بارگذاری جریان از دست رفته است، بازنمی‌سازد. برای ذخیرهٔ واقعی، به‌طور صریح یک [SaveFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) انتخاب کنید یا از تبدیل نشان‌داده‌شده در [Save Presentations in Their Original Format](/slides/fa/python-net/save-presentation/#save-presentations-in-their-original-format) استفاده کنید.

## **تأیید قالب‌ها با ذخیره‌سازی و بازگشایی**

این مثال خود‑کفایت یک ارائه ایجاد می‌کند و سه فایل را در پوشهٔ کاری می‌نویسد، به‌گونه‌ای که فایل‌های با همان نام بازنویسی می‌شوند. هر خروجی هم از طریق مسیر و هم از طریق یک جریان حافظه باز می‌شود. برای PPTX و ODP هر دو مسیر قالب ذخیره‌شده را گزارش می‌کنند. برای PPS، بارگذاری از مسیر `PPS` گزارش می‌شود، در حالی که بارگذاری همان بایت‌ها بدون نام فایل `PPT` گزارش می‌شود.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

همان بررسی برای تمام قالب‌های فهرست‌شده در بالا، نتایج زیر را برای ارائه‌های تولیدشده با پسوندهای متناظر نشان می‌دهد:

| قالب ذخیره‌شده | SourceFormat از مسیر فایل | SourceFormat از جریان بدون نام |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` به ترتیب | همان‌طور که مسیر فایل |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` به ترتیب | همان‌طور که مسیر فایل |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` به ترتیب | همان‌طور که مسیر فایل |
| ODP, OTP | `ODP`, `OTP` به ترتیب | همان‌طور که مسیر فایل |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

در این بررسی‌ها، تنها نرمال‌سازی قالب منبع، تبدیل PPS/POT به `PPT` برای جریان‌های بدون نام بود. جدول شناسایی قالب را توصیف می‌کند، نه حفظ تمام ویژگی‌های ارائه در طول تبدیل.

## **سؤالات متداول**

**آیا ذخیره‌سازی به ODP قالب منبع ارائه‌ای که از PPTX بارگذاری شده است را تغییر می‌دهد؟**

خیر. نمونهٔ موجود همچنان `PPTX` را گزارش می‌کند. نمونه‌ای که از فایل ODP ذخیره‌شده بارگذاری می‌شود، `ODP` را گزارش می‌کند.

**آیا یک جریان همیشه می‌تواند ارائهٔ قدیمی، نمایش اسلاید و قالب را متمایز کند؟**

خیر. PPT، PPS و POT قالب باینری مشترکی دارند. وقتی این تمایز لازم است، نام فایل یا فرادادهٔ زیرنوع را به‌صورت جداگانه نگه دارید.

**کدام API را باید استفاده کنم اگر ارائه قبلاً بارگذاری شده باشد؟**

[Presentation.source_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/source_format/) را بخوانید. برای بازرسی پیش از بارگذاری، از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) استفاده کنید.