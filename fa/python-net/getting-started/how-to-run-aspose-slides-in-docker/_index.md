---
title: "نحوه اجرا کردن Aspose.Slides در Docker"
linktitle: "Aspose.Slides در Docker"
type: docs
weight: 150
url: /fa/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- "Aspose.Slides در Docker"
- "کانتینر Docker"
- "فایل Docker"
- "لینوکس"
- libgdiplus
- ICU
- OpenSSL
- "فونت‌ها"
- "پاورپوینت"
- OpenDocument
- "ارائه"
- "پایتون"
- Aspose.Slides
description: "اجرای Aspose.Slides برای Python از طریق .NET در Docker: یک Dockerfile کارا، کتابخانه‌های بومی مورد نیاز بسته، تنظیمات فونت و مجوزدهی درون یک کانتینر."
---
## **نمای کلی**

Aspose.Slides for Python via .NET در کانتینرهای لینوکس اجرا می‌شود، اما بسته یک wrapper پایتون است که دور یک runtime باندل شده **.NET Core 3.1** می‌چرخد. این runtime به سه کتابخانه بومی نیاز دارد که تصاویر لاغر پایتون ارائه نمی‌دهند و نسبت به نسخه‌هایشان حساس است. این مقاله یک Dockerfile کارا ارائه می‌دهد، دلیل وجود هر وابستگی را توضیح می‌دهد و نشان می‌دهد چگونه فونت‌ها و یک لایسنس اضافه شوند.

## **Dockerfile کاری**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

ساخت و اجرا:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **دلیل استفاده از تصویر پایه Debian 11**

چرخ `aspose.slides` یک runtime **.NET Core 3.1** را باندل می‌کند و این runtime پیش از نسخه‌های کتابخانه‌ای است که در نسخه‌های فعلی Debian توزیع می‌شوند. در Debian 12 و 13 کانتینر با موفقیت ساخته می‌شود ولی هنگام اولین فراخوانی `Presentation()` شکست می‌خورد:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

پیام گمراه‌کننده است — ICU در این تصاویر نصب شده است، اما ICU 72 یا 76 است و .NET Core 3.1 فقط نسخه‌های اصلی قدیمی‌تر را تشخیص می‌دهد. Debian 12 همچنین OpenSSL 3 را تحویل می‌دهد که منجر به شکست دوم می‌شود:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` بر پایه Debian 11 است که هر دو نسخه‌ای که runtime باندل شده انتظار دارد را فراهم می‌کند:

| Package | Version on Debian 11 | چرا نیاز است |
|---|---|---|
| `libgdiplus` | 6.0.4 | پیاده‌سازی GDI+ برای رندر کردن شکل‌ها، متن و تصویر |
| `libicu67` | 67.1 | داده‌های بومی‌سازی. نسخه‌های اصلی جدیدتر توسط .NET Core 3.1 شناسایی نمی‌شوند |
| `libssl1.1` | 1.1.1w | رمزنگاری. در Debian 11 پیش‌نصب است؛ در Debian 12+ وجود ندارد |
| `libfontconfig1` | — | کشف فونت‌ها |

`libssl1.1` از پیش در تصویر پایه وجود دارد، بنابراین نیازی به افزودن آن به `apt-get install` نیست.

اگر مجبور به استفاده از تصویر پایه جدیدتر شوید، مقدار `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` را تنظیم کنید تا نیاز به ICU را نادیده بگیرید. این کار قالب‌بندی مبتنی بر فرهنگ را غیرفعال می‌کند و **مشکل OpenSSL** را حل نمی‌کند، بنابراین Debian 11 همچنان گزینهٔ ساده‌تری است.

## **فونت‌ها**

تصاویر لاغر هیچ فونتی ندارند. بدون حداقل یک فونت نصب‌شده، متن در خروجی PDF، تصویر و HTML به صورت جعبه‌های خالی نمایش داده می‌شود. `fonts-dejavu-core` یک نقطهٔ شروع عمومی و کوچک است.

برای تطبیق ظاهر نهایی ارائه، فونت‌هایی که آن استفاده می‌کند را درون تصویر کپی کنید و Aspose.Slides را به سمت آن‌ها هدایت کنید:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **مجوزدهی داخل یک کانتینر**

فایل لایسنس را داخل تصویر نبنویسید — هر کسی که تصویر را می‌کشید لایسنس را دریافت می‌کند. به جای آن در زمان اجرا آن را Mount کنید:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

بدون لایسنس کتابخانه در حالت ارزیابی اجرا می‌شود که یک واترمارک اضافه می‌کند و تعداد اسلایدهای پردازش‌شده را محدود می‌نماید. برای جزئیات بیشتر به [مجوزدهی](/slides/fa/python-net/licensing/) مراجعه کنید.

## **حافظه**

رندرسازی به PDF یا تصویر نسبت به خواندن فایل حافظه بیشتری مصرف می‌کند. کانتینرهایی با محدودیت حافظه تنگ می‌توانند توسط OOM killer قبل از اتمام تبدیل خاتمه یابند؛ این معمولاً به شکل ناپدید شدن پردازش بدون traceback پایتون ظاهر می‌شود. اگر این رخ داد، قبل از بررسی کد، محدودیت حافظهٔ کانتینر را افزایش دهید.