---
title: سفارشی‌سازی فونت‌های پاورپوینت در پایتون
linktitle: فونت سفارشی
type: docs
weight: 20
url: /fa/python-net/custom-font/
keywords:
- فونت
- فونت سفارشی
- فونت خارجی
- بارگذاری فونت
- مدیریت فونت‌ها
- پوشه فونت
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "فونت‌های سفارشی را در اسلایدهای پاورپوینت با Aspose.Slides برای پایتون از طریق .NET تعبیه کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار بمانند."
---
## **بررسی کلی**

Aspose.Slides برای Python به شما امکان می‌دهد تا در زمان اجرا فونت‌های سفارشی را فراهم کنید به‌گونه‌ای که ارائه‌ها حتی زمانی که فونت‌های مورد نیاز بر روی سیستم میزبان نصب نشده‌اند، به‌درستی رندر شوند. هنگام خروجی به PDF یا تصاویر، می‌توانید پوشه‌های فونت یا داده‌های فونت در حافظه را ارائه دهید تا چیدمان متن، معیارهای گلیف و تایپوگرافی حفظ شود. این کار رندرینگ سمت سرور را در محیط‌های مختلف پیش‌بینی‌پذیر می‌کند، وابستگی‌های سیستم‌عامل به فونت‌ها را حذف می‌نماید و از تبدیل‌های ناخواسته یا بازآرایی جلوگیری می‌کند. این مقاله نشان می‌دهد چگونه منابع فونت را ثبت کنید.

یک تم ارائه می‌تواند خانواده‌های فونت مختلفی را برای سیستم‌های نوشتاری جداگانه ارجاع دهد. این نگاشت‌ها فقط نام‌های فونت را ذخیره می‌کنند اما فونت‌ها را نصب یا بارگذاری نمی‌کنند. برای مدیریت این نگاشت‌ها، به [Script-Specific Theme Fonts](/slides/fa/python-net/script-specific-font-mappings/) مراجعه کنید و از گزینه‌های بارگذاری زیر استفاده کنید تا فونت‌های ارجاع داده شده برای رندرینگ سازگار در دسترس باشند.

Aspose.Slides به شما اجازه می‌دهد تا فونت‌های زیر را با استفاده از متدهای `load_external_font` و `load_external_fonts` کلاس [FontsLoader](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/) بارگذاری کنید:

- فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType).
- فونت‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد تا فونت‌های استفاده‌شده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این مورد بر خروجی‌های صادراتی—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد نهایی در محیط‌های مختلف یک‌دست به نظر برسند. فونت‌ها از پوشه‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.
2. متد ایستا [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/load_external_fonts/) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/اکسپورت کنید.
4. متد [FontsLoader.clear_cache](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/clear_cache/) را فراخوانی کنید تا کش فونت‌ها پاک شود.

مثال کد زیر فرایند بارگذاری فونت را نشان می‌دهد:

```py
import aspose.slides as slides

# پوشه‌هایی که شامل فایل‌های فونت سفارشی هستند را تعریف کنید.
font_folders = ["fonts", "external_fonts"]

# فونت‌های سفارشی را از پوشه‌های مشخص شده بارگذاری کنید.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # ارائه را رندر/صادرات کنید (مثلاً به PDF، تصاویر یا سایر فرمت‌ها) با استفاده از فونت‌های بارگذاری‌شده.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# پس از اتمام کار، کش فونت‌ها را پاک کنید.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/load_external_fonts/) پوشه‌های اضافی به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب مقداردهی اولیه فونت‌ها را تغییر نمی‌دهد.
فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/) بارگذاری شده‌اند.
{{%/alert %}}

## **به‌دست آوردن پوشه فونت‌های سفارشی**

Aspose.Slides روش `get_font_folders` را برای دریافت پوشه‌های فونت فراهم می‌کند. این متد هم پوشه‌های اضافه‌شده از طریق `load_external_fonts` و هم پوشه‌های فونت سیستم را بازمی‌گرداند.

این کد Python نشان می‌دهد چگونه از `get_font_folders` استفاده کنید:

```python
import aspose.slides as slides

# این فراخوانی پوشه‌هایی را که برای فایل‌های فونت بررسی می‌شوند برمی‌گرداند.
# این شامل پوشه‌هایی است که از طریق متد load_external_fonts اضافه شده‌اند و پوشه‌های فونت سیستم نیز می‌باشد.
font_folders = slides.FontsLoader.get_font_folders()
```

## **مشخص‌کردن فونت‌های سفارشی برای یک ارائه**

Aspose.Slides ویژگی `document_level_font_sources` را فراهم می‌کند که به شما اجازه می‌دهد فونت‌های خارجی را برای استفاده در یک ارائه مشخص کنید.

مثال Python زیر نشان می‌دهد چگونه از `document_level_font_sources` استفاده کنید:

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
    # فونت‌های CustomFont1، CustomFont2، و فونت‌های موجود در پوشه‌های assets\\fonts و global\\fonts (و زیرپوشه‌های آن‌ها) برای ارائه در دسترس هستند.
    # ...
    print(len(presentation.slides))
```

## **بارگذاری فونت‌های خارجی از داده‌های باینری**

Aspose.Slides متد `load_external_font` را برای بارگذاری فونت‌های خارجی از داده‌های باینری فراهم می‌کند.

مثال Python زیر بارگذاری یک فونت از آرایه بایتی را نشان می‌دهد:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# بارگذاری فونت‌های خارجی از آرایه‌های بایتی.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # فونت‌های خارجی برای طول عمر این نمونه ارائه در دسترس هستند.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **سؤالات متداول**

### آیا فونت‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟

بله. فونت‌های متصل توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

### آیا فونت‌های سفارشی به‌صورت خودکار در فایل PPTX نهایی جاسازی می‌شوند؟

خیر. ثبت یک فونت برای رندرینگ برابر با جاسازی آن در PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه نگه داشته شود، باید از ویژگی‌های [embedding features](/slides/fa/python-net/embedded-font/) صریح استفاده کنید.

### آیا می‌توانم رفتار بازگشت (fallback) را کنترل کنم وقتی یک فونت سفارشی برخی گلیف‌ها را ندارد؟

بله. می‌توانید [font substitution](/slides/fa/python-net/font-substitution/)، [replacement rules](/slides/fa/python-net/font-replacement/) و [fallback sets](/slides/fa/python-net/fallback-font/) را پیکربندی کنید تا دقیقاً تعیین کنید هنگام عدم وجود گلیف درخواستی، چه فونتی استفاده شود.

### آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟

بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایت بارگذاری کنید. این کار هرگونه وابستگی به پوشه‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

### در مورد مجوزها چه می‌شود—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول اطمینان از رعایت قوانین مجوز فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. همیشه قبل از توزیع خروجی‌ها، شرایط استفاده (EULA) فونت را بررسی کنید.