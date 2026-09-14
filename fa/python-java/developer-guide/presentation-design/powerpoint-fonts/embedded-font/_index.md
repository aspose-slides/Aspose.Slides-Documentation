---
title: جاسازی قلم‌ها در ارائه‌ها در پایتون از طریق جاوا
linktitle: قلم‌های جاسازی‌شده
type: docs
weight: 40
url: /fa/python-java/embedded-font/
keywords:
- افزودن قلم
- جاسازی قلم
- جاسازی قلم
- دریافت قلم جاسازی‌شده
- افزودن قلم جاسازی‌شده
- حذف قلم جاسازی‌شده
- فشرده‌سازی قلم جاسازی‌شده
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "قلم‌های جاسازی‌شده در PowerPoint را با Aspose.Slides برای Python از طریق Java مدیریت کنید. قلم‌ها را اضافه، بازیابی، حذف و فشرده‌سازی کنید تا ظاهر متن حفظ شود و حجم فایل کاهش یابد."
---
## **معرفی**

جاسازی قلم‌ها داده‌های قلم را داخل یک ارائه PowerPoint ذخیره می‌کند. وقتی یک مشاهده‌گر از قلم‌های جاسازی‌شده پشتیبانی کند، می‌تواند متن را با استفاده از آن قلم‌ها نمایش دهد حتی اگر در سیستم مقصد نصب نشده باشند. این به حفظ شکست خطوط، فاصله‌بندی متن و قالب اسلاید کمک می‌کند.

Aspose.Slides برای Python از طریق Java به شما امکان بازیابی، افزودن و حذف قلم‌های جاسازی‌شده را از طریق کلاس [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) که توسط [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getFontsManager) برگردانده می‌شود، می‌دهد. همچنین می‌توانید با حذف کاراکترهایی که ارائه از آن‌ها استفاده نمی‌کند، اندازه داده‌های قلم‌های جاسازی‌شده را کاهش دهید.

مثال‌های زیر با فایل‌های PPTX کار می‌کنند. پیش از جاسازی یک قلم، اطمینان حاصل کنید که داده‌های قلم برای Aspose.Slides در دسترس است و مجوز آن اجازهٔ جاسازی را می‌دهد.

## **دریافت و حذف قلم‌های جاسازی‌شده**

از [getEmbeddedFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) برای فهرست کردن قلم‌های ذخیره‌شده در یک ارائه استفاده کنید. برای حذف یک قلم، یک قلم از آن فهرست را به [removeEmbeddedFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) پاس دهید، سپس ارائه را ذخیره کنید.

مثال زیر قلم‌های جاسازی شده در `EmbeddedFonts.pptx` را فهرست می‌کند و اگر قلم Calibri موجود باشد آن را حذف می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

حذف یک قلم جاسازی‌شده، داده‌های ذخیره‌شدهٔ آن قلم را حذف می‌کند؛ این کار قلم اختصاص‌یافته به متن را تغییر نمی‌دهد. اگر قلم در سیستم هدف نصب باشد، متن می‌تواند همچنان از آن استفاده کند. در غیر این صورت، رندر ممکن است به جایگزینی قلم نیاز داشته باشد که می‌تواند بر قالب‌بندی تأثیر بگذارد.

## **بررسی داده‌های قلم و مجوزهای جاسازی**

از کلاس [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) برای بررسی قلم‌ها پیش از جاسازی آن‌ها استفاده کنید. با فراخوانی [FontsManager.getFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getFonts) قلم‌های استفاده‌شده در ارائه را بازیابی کنید. برای هر قلم، یک شیء [FontData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontdata/) و مقدار مورد نیاز [FontStyleType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontstyletype/) را به [FontsManager.getFontBytes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getFontBytes) پاس دهید. این متد دادهٔ باینری آن سبک قلم را برمی‌گرداند، یا `None` زمانی که قلم یا سبک درخواست‌شده در دسترس نباشد. نتایج `None` را به [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) پاس ندهید، زیرا این متد به آرایه بایت نیاز دارد.

`EmbeddingLevel` یک شمارش پرچم است که محدودیت‌های جاسازی ذخیره‌شده در قلم را گزارش می‌کند:

- `Installable` اجازهٔ جاسازی و نصب دائمی روی سیستم دیگر را می‌دهد، مشروط بر مجوز قلم.
- `Restricted` جلوی جاسازی را می‌گیرد مگر اینکه اجازه از مالک قانونی قلم دریافت شود وقتی که این تنها پرچم مجوز استفاده باشد.
- `PreviewPrint` اجازهٔ استفاده موقت برای مشاهده و چاپ را می‌دهد؛ سند حاوی قلم باید فقط‑خواندنی باشد.
- `Editable` اجازهٔ استفاده موقت را می‌دهد و امکان ویرایش و ذخیرهٔ سند را فراهم می‌کند.
- `NoSubsetting` محدودیتی اضافی است که فقط جاسازی زیرمجموعه‌ای از گلیف‌ها را ممنوع می‌کند. وقتی این پرچم موجود باشد، باید تمام کاراکترها جاسازی شوند.
- `BitmapOnly` محدودیتی اضافی است که فقط ضربه‌های بیت‌مپ را برای جاسازی مجاز می‌کند، نه داده‌های خطوط خارجی. اگر قلم هیچ ضربهٔ بیت‌مپ نداشته باشد، نمی‌تواند جاسازی شود.

چهار مقدار اول مجوز استفاده را توصیف می‌کنند، در حالی که `NoSubsetting` و `BitmapOnly` می‌توانند با آن ترکیب شوند. با عملیات بیتی این اصلاح‌کننده‌ها را بررسی کنید. چون `Installable` برابر صفر است، بیت‌های مجوز استفاده را ماسک کنید و نتیجه را با `Installable` مقایسه کنید نه اینکه آن را به عنوان یک پرچم بررسی کنید. قلم‌های فعلی باید حداکثر یک بیت مجوز استفاده تنظیم کنند. برای سازگاری با قلم‌های قدیمی که بیش از یک بیت تنظیم می‌کنند، ابزار کمکی زیر کم‌ترین محدودیت را انتخاب می‌کند: ابتدا `Editable`، سپس `PreviewPrint` و در نهایت `Restricted`.

مثال زیر داده‌های عادی، بولد، ایتالیک و بولد‑ایتالیک موجود برای هر قلم برگردانده شده توسط `getFonts` را بررسی می‌کند. سبک‌های در دسترس نیستند، قلم‌های محدود، قلم‌های فقط‑Bitmap، قلم‌های محدود به پیش‌نمایش و چاپ (چون خروجی همچنان قابل ویرایش است) و قلم‌های از پیش جاسازی‌شده نادیده گرفته می‌شوند. اگر هر سبک در دسترس دارای `NoSubsetting` باشد، تمام کاراکترهای آن خانوادهٔ قلم جاسازی می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این بازرسی محدودیت‌های کدگذاری‌شده در هر فایل قلم را گزارش می‌دهد. این کار مجوزی اعطا نمی‌کند، ثابت نمی‌کند که قلم را به‌صورت قانونی به دست آورده‌اید و جایگزین بررسی توافق‌نامهٔ مجوز قلم قبل از توزیع یک نسخهٔ جاسازی‌شده نمی‌شود.

## **افزودن قلم‌های جاسازی‌شده**

از [addEmbeddedFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) برای جاسازی یک قلم استفاده کنید. بارگذاری‌های آن می‌توانند یا یک شیء [FontData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontdata/) یا یک آرایه بایت حاوی داده‌های قلم را بپذیرند. شمارش [EmbedFontCharacters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/embedfontcharacters/) کنترل می‌کند که چه کاراکترهایی شامل شوند:

- `All` تمام کاراکترهای قلم را جاسازی می‌کند. از این گزینه زمانی استفاده کنید که دریافت‌کنندگان نیاز به ویرایش ارائه و وارد کردن متن جدید داشته باشند.
- `OnlyUsed` فقط کاراکترهای استفاده‌شده در ارائه را جاسازی می‌کند تا حجم فایل کاهش یابد. این گزینه را برای ارائهٔ نهایی که عمدتاً برای مشاهده است، انتخاب کنید.

مثال زیر با استفاده از [getFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getFonts) قلم‌های استفاده‌شده در `Fonts.pptx` را بازیابی می‌کند و آن‌هایی را که هنوز جاسازی نشده‌اند اضافه می‌کند. قلم‌های مورد نیاز باید بر روی ماشینی که کد اجرا می‌شود موجود باشند. قلم‌های جاسازی‌شدهٔ موجود مجموعهٔ کاراکترهای فعلی خود را حفظ می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **فشرده‌سازی قلم‌های جاسازی‌شده**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#compressEmbeddedFonts) داده‌های قلم جاسازی‌شده را با حذف کاراکترهای استفاده‌نشده کاهش می‌دهد. این عملیات بر روی قلم‌هایی که قبلاً جاسازی شده‌اند انجام می‌شود، بنابراین میزان کاهش حجم به میزان داده‌های قلم استفاده‌نشده در ارائه بستگی دارد.

مثال زیر قلم‌های موجود در `EmbeddedFonts.pptx` را فشرده می‌کند و نتیجه را به‌عنوان یک فایل جداگانه ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اگر ممکن است دریافت‌کنندگان بعداً نیاز به افزودن متن داشته باشند، فایل اصلی را نگه دارید. کاراکترهای حذف‌شده در حین فشرده‌سازی دیگر از قلم جاسازی‌شده در دسترس نخواهند بود، حتی اگر در ابتدا تمام کاراکترها را جاسازی کرده باشید.

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا یک قلم جاسازی‌شده همچنان در هنگام رندر جایگزین می‌شود؟**

در محیطی که ارائه را رندر می‌کنید، [getSubstitutions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getSubstitutions) را فراخوانی کنید تا ببینید Aspose.Slides چه قلم‌هایی را جایگزین می‌کند. همچنین تنظیمات جایگزینی قلم و قواعد پیش‌پوشش (fallback) را بررسی کنید. پیش‌پوشش کاراکترهای گمشده را مدیریت می‌کند، بنابراین جاسازی یک قلم مشکلات کاراکترهایی را که خود قلم شاملشان نیست، حل نمی‌کند.

**آیا باید قلم‌های رایج مانند Arial و Calibri را جاسازی کنم؟**

تصمیم را بر اساس محیط هدف بگیرید. اگر قلم‌های مورد نیاز بر روی هر ماشین که ارائه را باز یا رندر می‌کند موجود باشد، جاسازی آن‌ها ممکن است حجم غیرضروری به فایل اضافه کند. اگر دریافت‌کنندگان یا سرورها ممکن است آن قلم‌ها را نداشته باشند، جاسازی آن‌ها می‌تواند به حفظ ظاهر مورد نظر کمک کند، به شرطی که مجوزهایشان اجازهٔ این کار را بدهد.