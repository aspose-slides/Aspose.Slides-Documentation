---
title: "سفارشی‌سازی قلم‌های پاورپوینت در پایتون از طریق جاوا"
linktitle: "قلم سفارشی"
type: docs
weight: 20
url: /fa/python-java/custom-font/
keywords:
- "قلم"
- "قلم سفارشی"
- "قلم خارجی"
- "بارگذاری قلم"
- "مدیریت قلم‌ها"
- "پوشه قلم"
- "پاورپوینت"
- "OpenDocument"
- "ارائه"
- "پایتون"
- "جاوا"
- "Aspose.Slides"
description: "قلم‌ها را در اسلایدهای پاورپوینت با Aspose.Slides برای پایتون از طریق جاوا سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و یکدست باشند."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد از قلم‌های سفارشی در ارائه‌ها بدون نیاز به نصب آنها بر روی سیستم‌عامل استفاده کنید. می‌توانید قلم‌ها را از پوشه‌های سفارشی بارگذاری کنید، قلم‌ها را برای یک ارائه خاص از طریق منابع قلم در سطح سند فراهم کنید، یا قلم‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

قلم‌های بارگذاری‌شده هنگام رندر یا خروجی گرفتن از ارائه، برای مثال به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده، مورد استفاده قرار می‌گیرند. این کار به حفظ یک‌دست بودن خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین نحوه بررسی پوشه‌های قلم مورد استفاده توسط Aspose.Slides و نحوه پاک‌سازی کش قلم پس از کار با قلم‌های خارجی را توضیح می‌دهد.

ثبت قلم‌های سفارشی برای رندرینگ جدا از تعبیه‌ی قلم‌ها در فایل PPTX است. اگر لازم باشد قلم داخل خود ارائه ذخیره شود، باید از ویژگی‌های صریح تعبیه قلم استفاده کنید.

یک تم ارائه می‌تواند برای سیستم‌های نوشتاری مختلف خانواده‌های قلم متفاوتی را ارجاع دهد. این نگاشت‌ها نام قلم‌ها را ذخیره می‌کنند اما فایل‌های قلم را نصب یا بارگذاری نمی‌کنند. به [قلم‌های تم مخصوص اسکریپت](/slides/fa/python-java/script-specific-font-mappings/) مراجعه کنید تا این نگاشت‌ها را مدیریت کنید، و از گزینه‌های بارگذاری زیر برای در دسترس قرار دادن قلم‌های ارجاع‌شده به‌منظور رندرینگ یک‌دست استفاده کنید.

{{% alert color="info" title="Note" %}}

Aspose.Slides به شما اجازه می‌دهد این قلم‌ها را با استفاده از روش [loadExternalFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/#loadExternalFonts) بارگذاری کنید:

* قلم‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.

* قلم‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.

{{% /alert %}}

## **بارگذاری قلم‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد قلم‌هایی که در یک ارائه استفاده می‌شوند را بدون نصب بر روی سیستم بارگذاری کنید. این کار بر خروجی‌های صادراتی—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—تاثیر دارد تا اسناد تولیدی در محیط‌های مختلف یک‌دست به نظر برسند. قلم‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های قلم را مشخص کنید.
2. متد ایستاتیک [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/#loadExternalFonts) را فراخوانی کنید تا قلم‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/صادر کنید.
4. برای پاک‌سازی کش قلم، متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/#clearCache) را فراخوانی کنید.

مثال کد زیر فرآیند بارگذاری قلم را نشان می‌دهد:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# پوشه‌هایی را که شامل فایل‌های قلم سفارشی هستند تعریف کنید.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# قلم‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # ارائه را با استفاده از قلم‌های بارگذاری‌شده رندر/صادرات کنید.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # پس از اتمام کار، کش قلم را پاک کنید.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/#loadExternalFonts) پوشه‌های اضافی را به مسیرهای جستجوی قلم اضافه می‌کند، اما ترتیب مقداردهی اولیه قلم‌ها را تغییر نمی‌دهد.
قلم‌ها به‌صورت زیر مقداردهی اولیه می‌شوند:

1. مسیر پیش‌فرض قلم‌های سیستم‌عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های قلم سفارشی**
Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/#getFontFolders) را فراهم می‌کند تا به شما امکان پیدا کردن پوشه‌های قلم را بدهد. این متد پوشه‌هایی را که از طریق متد [loadExternalFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/#loadExternalFonts) اضافه شده‌اند و پوشه‌های قلم سیستمی را برمی‌گرداند.

این کد پایتون نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/#getFontFolders) استفاده کنید:

```python
from asposeslides.api import FontsLoader

# پوشه‌هایی را که از طریق loadExternalFonts اضافه شده‌اند و پوشه‌های قلم سیستمی دریافت کنید.
font_folders = FontsLoader.getFontFolders()
```

## **مشخص کردن قلم‌های سفارشی استفاده‌شده با یک ارائه**
Aspose.Slides متد [getDocumentLevelFontSources](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) را فراهم می‌کند تا بتوانید قلم‌های خارجی که با ارائه استفاده خواهند شد را مشخص کنید.

این کد پایتون نشان می‌دهد چگونه از متد [getDocumentLevelFontSources](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) استفاده کنید:

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # با ارائه کار کنید.
    # CustomFont1، CustomFont2 و قلم‌ها از assets/fonts و global/fonts
    # و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند.
    pass
finally:
    presentation.dispose()
```

## **مدیریت قلم‌ها به‌صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/#loadExternalFont) را فراهم می‌کند تا بتوانید قلم‌های خارجی را از داده‌های باینری بارگذاری کنید.

این کد پایتون فرآیند بارگذاری قلم از آرایه بایت را نشان می‌دهد:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # قلم‌های خارجی در طول زمان‌حیات ارائه بارگذاری می‌شوند.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **سئوالات متداول**

**آیا قلم‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**

بله. قلم‌های متصل توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

**آیا قلم‌های سفارشی به‌صورت خودکار در فایل PPTX نهایی تعبیه می‌شوند؟**

خیر. ثبت قلم برای رندرینگ همانند تعبیه آن در PPTX نیست. اگر نیاز دارید قلم داخل فایل ارائه ذخیره شود، باید از ویژگی‌های صریح تعبیه استفاده کنید.

**آیا می‌توانم رفتار جایگزینی را هنگام عدم وجود برخی گلیف‌ها در قلم سفارشی کنترل کنم؟**

بله. می‌توانید [font substitution](/slides/fa/python-java/font-substitution/)، [replacement rules](/slides/fa/python-java/font-replacement/) و [fallback sets](/slides/fa/python-java/fallback-font/) را پیکربندی کنید تا دقیقاً مشخص کنید که در صورت عدم وجود گلیف مورد درخواست، از کدام قلم استفاده شود.

**آیا می‌توانم قلم‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟**

بله. می‌توانید به پوشه‌های قلم خود اشاره کنید یا قلم‌ها را از آرایه بایت بارگذاری کنید. این کار وابستگی به دایرکتوری‌های قلم سیستم در تصویر کانتینر را حذف می‌کند.

**در مورد مجوزها چه می‌شود—آیا می‌توانم هر قلم سفارشی را بدون محدودیت تعبیه کنم؟**

شما مسؤول رعایت مجوزهای قلم هستید. شرایط متفاوت است؛ برخی مجوزها تعبیه یا استفاده تجاری را ممنوع می‌کند. همیشه قبل از توزیع خروجی‌ها، قرارداد استفاده (EULA) قلم را بررسی کنید.