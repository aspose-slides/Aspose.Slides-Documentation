---
title: سفارشی‌سازی قلم‌های پاورپوینت در پایتون
linktitle: قلم سفارشی
type: docs
weight: 20
url: /fa/python-net/custom-font/
keywords:
- قلم
- قلم سفارشی
- قلم خارجی
- بارگیری قلم
- مدیریت قلم‌ها
- پوشه قلم
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "قلم‌های سفارشی را در اسلایدهای پاورپوینت با Aspose.Slides برای پایتون از طریق .NET تعبیه کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار بمانند."
---
## **نمای کلی**

Aspose.Slides for Python به شما امکان می‌دهد تا در زمان اجرا فونت‌های سفارشی را فراهم کنید به طوری که ارائه‌ها حتی زمانی که فونت‌های مورد نیاز بر روی سیستم میزبان نصب نیستند، به درستی رندر شوند. در هنگام صادرات به PDF یا تصاویر، می‌توانید پوشه‌های فونت یا داده‌های فونت در حافظه را برای حفظ چیدمان متن، معیارهای گلیف و تایپوگرافی فراهم کنید. این کار رندر سمت سرور را در محیط‌های مختلف قابل پیش‌بینی می‌کند، وابستگی‌های فونت در سطح سیستم‌عامل را حذف می‌سازد و از بازگشت‌های ناخواسته یا بازچیدمان جلوگیری می‌کند. این مقاله نشان می‌دهد چگونه منبع‌های فونت را ثبت کنید.

Aspose.Slides به شما اجازه می‌دهد تا فونت‌های زیر را با استفاده از متدهای `load_external_font` و `load_external_fonts` کلاس [FontsLoader](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/) بارگذاری کنید:

- فونت‌های TrueType (.ttf) و مجموعه TrueType (.ttc). به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.
- فونت‌های OpenType (.otf). به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های استفاده شده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این موضوع بر خروجی‌های صادراتی—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد حاصل در محیط‌های مختلف یکسان به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.
2. متد ایستا [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/load_external_fonts/) را صدا بزنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/صادر کنید.
4. برای پاک‌کردن کش فونت‌ها، [FontsLoader.clear_cache](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/clear_cache/) را فراخوانی کنید.

مثال کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```py
import aspose.slides as slides

# پوشه‌هایی که شامل فایل‌های قلم سفارشی هستند را تعریف کنید.
font_folders = [ external_font_folder1, external_font_folder2 ]

# قلم‌های سفارشی را از پوشه‌های مشخص شده بارگذاری کنید.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # ارائه را با استفاده از قلم‌های بارگذاری‌شده رندر/صادرات کنید (مثلاً به PDF، تصاویر یا سایر فرمت‌ها).
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# پس از اتمام کار کش قلم‌ها را پاک کنید.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/load_external_fonts/) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت را تغییر نمی‌دهد.  
فونت‌ها به ترتیب زیر اولیه می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم عامل.  
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/) بارگذاری شده‌اند.  
{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**

Aspose.Slides متد `get_font_folders` را فراهم می‌کند تا پوشه‌های فونت را دریافت کنید. این متد هم پوشه‌هایی را که از طریق `load_external_fonts` اضافه شده‌اند و هم پوشه‌های فونت سیستم را برمی‌گرداند.

این کد پایتون نشان می‌دهد چگونه از `get_font_folders` استفاده شود:

```python
import aspose.slides as slides

# این فراخوانی پوشه‌هایی که برای فایل‌های قلم بررسی می‌شوند را برمی‌گرداند.
# این شامل پوشه‌هایی است که از طریق متد load_external_fonts اضافه شده‌اند و پوشه‌های قلم سیستم می‌شود.
font_folders = slides.FontsLoader.get_font_folders()
```

## **مشخص کردن فونت‌های سفارشی برای یک ارائه**

Aspose.Slides ویژگی `document_level_font_sources` را ارائه می‌دهد که به شما اجازه می‌دهد فونت‌های خارجی را برای استفاده در یک ارائه مشخص کنید.

مثال پایتون زیر نحوه استفاده از `document_level_font_sources` را نشان می‌دهد:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # کار با ارائه.
    # CustomFont1، CustomFont2، و قلم‌ها از پوشه‌های assets\fonts و global\fonts (و زیرپوشه‌های آنها) برای ارائه در دسترس هستند.
    # ...
    print(len(presentation.slides))
```

## **بارگذاری فونت‌های خارجی از داده‌های باینری**

Aspose.Slides متد `load_external_font` را برای بارگذاری فونت‌های خارجی از داده‌های باینری فراهم می‌کند.

مثال پایتون زیر بارگذاری یک فونت از آرایه بایت را نشان می‌دهد:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# بارگذاری قلم‌های خارجی از آرایه‌های بایت.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # قلم‌های خارجی برای طول عمر این نمونه‌ی ارائه در دسترس هستند.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **پرسش‌های متداول**

**آیا قلم‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**  
بله. قلم‌های متصل توسط رندرر در تمام فرمت‌های صادراتی استفاده می‌شوند.

**آیا قلم‌های سفارشی به‌صورت خودکار در فایل PPTX نهایی جاسازی می‌شوند؟**  
خیر. ثبت یک قلم برای رندر کردن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید قلم داخل فایل ارائه باشد، باید از ویژگی‌های واضح [embedding features](/slides/fa/python-net/embedded-font/) استفاده کنید.

**آیا می‌توانم رفتار fallback را زمانی که یک قلم سفارشی برخی گلیف‌ها را ندارد، کنترل کنم؟**  
بله. می‌توانید [font substitution](/slides/fa/python-net/font-substitution/)، [replacement rules](/slides/fa/python-net/font-replacement/) و [fallback sets](/slides/fa/python-net/fallback-font/) را پیکربندی کنید تا دقیقاً تعیین کنید هنگام عدم وجود گلیف درخواست‌شده چه قلمی استفاده شود.

**آیا می‌توانم در محیط‌های Linux/Docker بدون نصب سیستم‌عامل از قلم‌ها استفاده کنم؟**  
بله. می‌توانید به پوشه‌های قلم خود اشاره کنید یا قلم‌ها را از آرایه بایت بارگذاری کنید. این کار هرگونه وابستگی به دایرکتوری‌های قلم سیستم در تصویر کانتینر را حذف می‌کند.

**در مورد لایسنس—آیا می‌توانم هر قلم سفارشی را بدون محدودیت جاسازی کنم؟**  
شما مسئول رعایت قوانین لایسنس قلم‌ها هستید. شرایط متفاوت است؛ برخی لایسنس‌ها جاسازی یا استفاده تجاری را منع می‌کنند. همیشه پیش از توزیع خروجی‌ها، قرارداد کاربری نهایی (EULA) قلم را بررسی کنید.