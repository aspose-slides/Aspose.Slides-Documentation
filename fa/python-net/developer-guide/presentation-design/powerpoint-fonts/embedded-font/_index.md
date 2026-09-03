---
title: تعبیه فونت‌ها در ارائه‌ها با پایتون
linktitle: فونت‌های تعبیه‌شده
type: docs
weight: 40
url: /fa/python-net/embedded-font/
keywords:
- افزودن فونت
- تعبیه فونت
- تعبیهٔ فونت
- دریافت فونت تعبیه‌شده
- افزودن فونت تعبیه‌شده
- حذف فونت تعبیه‌شده
- فشرده‌سازی فونت تعبیه‌شده
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "مدیریت فونت‌های تعبیه‌شده در PowerPoint با Aspose.Slides برای پایتون از طریق .NET. با استفاده از پایتون، فونت‌ها را اضافه، دریافت، حذف و فشرده کنید تا ظاهر متن حفظ شود و حجم فایل کاهش یابد."
---
## **مقدمه**

فونت‌های تعبیه‌شده داده‌های قلم را داخل یک ارائهٔ PowerPoint ذخیره می‌کنند. وقتی یک مشاهده‌گر فونت‌های تعبیه‌شده را پشتیبانی می‌کند، می‌تواند متن را با استفاده از آن فونت‌ها نمایش دهد حتی اگر روی سیستم هدف نصب نشده باشند. این کمک می‌کند تا شکست خطوط، فاصله‌های متن و چیدمان اسلاید حفظ شود.

Aspose.Slides for Python via .NET به شما امکان بازیابی، افزودن و حذف فونت‌های تعبیه‌شده را از طریق ویژگی [fonts_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/fonts_manager/) یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) می‌دهد. همچنین می‌توانید اندازهٔ دادهٔ فونت‌های تعبیه‌شده را با حذف کاراکترهایی که ارائه از آن استفاده نمی‌کند، کاهش دهید.

مثال‌های زیر با فایل‌های PPTX کار می‌کند. پیش از تعبیه یک فونت، اطمینان حاصل کنید که دادهٔ فونت برای Aspose.Slides در دسترس است و مجوز آن اجازهٔ تعبیه را می‌دهد.

## **دریافت و حذف فونت‌های تعبیه‌شده**

از [get_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) برای فهرست کردن فونت‌های ذخیره‌شده در یک ارائه استفاده کنید. برای حذف یکی، یک فونت از آن فهرست را به [remove_embedded_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/remove_embedded_font/) پاس می‌دهید و سپس ارائه را ذخیره می‌کنید.

مثال زیر فونت‌های تعبیه‌شده در `EmbeddedFonts.pptx` را فهرست می‌کند و اگر Calibri موجود باشد آن را حذف می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

حذف یک فونت تعبیه‌شده دادهٔ فونت ذخیره‌شده را حذف می‌کند؛ اما فونتی که به متن اختصاص داده شده است را تغییر نمی‌دهد. اگر فونت بر روی سیستم هدف نصب شده باشد، متن می‌تواند همچنان از آن استفاده کند. در غیر این صورت، رندرینگ ممکن است نیاز به [جایگزینی فونت](/slides/fa/python-net/font-substitution/) داشته باشد که می‌تواند بر چینش تأثیر بگذارد.

## **بازرسی داده‌های فونت و مجوزهای تعبیه**

از کلاس [FontsManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/) برای بررسی فونت‌ها پیش از تعبیه استفاده کنید. با فراخوانی [get_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_fonts/) می‌توانید فونت‌های استفاده‌شده در ارائه را به‌دست آورید. برای هر فونت، یک شیء [FontData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontdata/) و مقدار مورد نیاز [FontStyleType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontstyletype/) را به [get_font_bytes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_font_bytes/) می‌گذارید. این متد دادهٔ باینری آن سبک فونت را برمی‌گرداند یا `None` وقتی فونت یا سبک درخواستی موجود نباشد. به `get_font_embedding_level` نتیجهٔ `None` پاس ندهید، زیرا این متد یک آرایه بایت می‌خواهد.

[EmbeddingLevel](https://reference.aspose.com/slides/fa/python-net/aspose.slides/embeddinglevel/) یک شمارش پرچمی است که محدودیت‌های تعبیه ذخیره‌شده در فونت را گزارش می‌دهد:

- `INSTALLABLE` اجازهٔ تعبیه و نصب دائمی روی سیستم دیگر را می‌دهد، مشروط بر مجوز فونت.
- `RESTRICTED` تعبیه را ممنوع می‌کند مگر آنکه اجازه از مالک قانونی فونت دریافت شود، زمانی که تنها پرچم مجوز استفاده باشد.
- `PREVIEW_PRINT` اجازهٔ استفاده موقت برای مشاهده و چاپ را می‌دهد؛ سند حاوی فونت باید فقط‑خواندنی باشد.
- `EDITABLE` اجازهٔ استفاده موقت و امکان ویرایش و ذخیرهٔ سند را می‌دهد.
- `NO_SUBSETTING` محدودیتی اضافی است که تعبیه تنها زیرمجموعه‌ای از گلیف‌ها را منع می‌کند. هنگامی که این پرچم موجود باشد، تمام کاراکترها تعبیه می‌شوند.
- `BITMAP_ONLY` محدودیتی اضافی است که فقط ضربات بیت‌مپ را برای تعبیه مجاز می‌کند، نه دادهٔ خطوط outlines. اگر فونت هیچ ضربهٔ بیت‌مپ نداشته باشد، نمی‌تواند تعبیه شود.

چهار مقدار اول مجوز استفاده را توصیف می‌کنند، در حالی که `NO_SUBSETTING` و `BITMAP_ONLY` می‌توانند با آن‌ها ترکیب شوند. با عملیات بیتی این اصلاح‌کننده‌ها را بررسی کنید. چون `INSTALLABLE` صفر است، بیت‌های مجوز استفاده را ماسک کرده و نتیجه را با `INSTALLABLE` مقایسه کنید. فونت‌های فعلی باید حداکثر یک بیت مجوز استفاده داشته باشند. برای سازگاری با فونت‌های قدیمی که بیش از یک بیت تنظیم کرده‌اند، تابع کمکی زیر کم‌ترین محدودیت را انتخاب می‌کند: ابتدا `EDITABLE`، سپس `PREVIEW_PRINT`، سپس `RESTRICTED`.

مثال زیر داده‌های معمولی، بولد، ایتالیک و بولد‑ایتالیک موجود برای هر فونت برگشتی از `get_fonts` را بررسی می‌کند. سبک‌های غیرقابل دسترس، فونت‌های محدود، فونت‌های فقط‑بیت‌مپ، فونت‌هایی که فقط برای پیش‌نمایش و چاپ محدود هستند (چون خروجی ویرایشی می‌ماند) و فونت‌های پیشاپیش تعبیه‌شده را نادیده می‌گیرد. اگر هر سبک موجود دارای `NO_SUBSETTING` باشد، تمام کاراکترهای آن خانوادهٔ فونت تعبیه می‌شود.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

این بازرسی محدودیت‌های کدگذاری‌شده در هر فایل فونت را گزارش می‌دهد. این کار مجوزی نمی‌دهد، ثابت نمی‌کند که فونت را به‌طور قانونی به‌دست آورده‌اید، یا بررسی توافق‌نامهٔ مجوز فونت پیش از توزیع یک نسخهٔ تعبیه‌شده را جایگزین نمی‌کند.

## **افزودن فونت‌های تعبیه‌شده**

از [add_embedded_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/add_embedded_font/) برای تعبیه یک فونت استفاده کنید. بارگذاری‌های مختلف این متد یا یک شیء [FontData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontdata/) یا یک آرایه بایت حاوی دادهٔ فونت را می‌پذیرند. شمارش [EmbedFontCharacters](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/embedfontcharacters/) تعیین می‌کند که کدام کاراکترها گنجانده شوند:

- [ALL](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/embedfontcharacters/) تمام کاراکترهای فونت را تعبیه می‌کند. از این گزینه زمانی استفاده کنید که گیرندگان نیاز به ویرایش ارائه و وارد کردن متنی جدید داشته باشند.
- [ONLY_USED](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/embedfontcharacters/) فقط کاراکترهای استفاده‌شده در ارائه را برای کاهش حجم فایل تعبیه می‌کند. برای ارائهٔ نهایی که عمدتاً برای نمایش است، این گزینه را برگزینید.

مثال زیر با استفاده از [get_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_fonts/) فونت‌های استفاده‌شده در `Fonts.pptx` را دریافت می‌کند و آنهایی که پیشاپیش تعبیه نشده‌اند را تعبیه می‌نماید. فونت‌های مورد افزودن باید روی ماشینی که کد اجرا می‌شود در دسترس باشند. فونت‌های تعبیه‌شدهٔ موجود مجموعه کاراکترهای فعلی خود را حفظ می‌کنند.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **فشرده‌سازی فونت‌های تعبیه‌شده**

[compress_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) دادهٔ فونت تعبیه‌شده را با حذف کاراکترهای استفاده‌نشده کاهش می‌دهد. این متد بر روی فونت‌های پیشاپیش تعبیه‌شده عمل می‌کند، بنابراین میزان کاهش حجم به مقدار دادهٔ فونتی که در ارائه استفاده نشده است بستگی دارد.

مثال زیر فونت‌های موجود در `EmbeddedFonts.pptx` را فشرده می‌کند و نتیجه را به‌صورت یک فایل جداگانه ذخیره می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

اگر ممکن است گیرندگان بعداً نیاز به افزودن متن داشته باشند، فایل اصلی را نگه دارید. کاراکترهایی که در طول فشرده‌سازی حذف می‌شوند، دیگر از فونت تعبیه‌شده در دسترس نخواهند بود، حتی اگر در ابتدا تمام کاراکترها را تعبیه کرده باشید.

## **سؤالات متداول**

**چگونه می‌توانم بررسی کنم که آیا یک فونت تعبیه‌شده هنگام رندرینگ همچنان جایگزین می‌شود یا نه؟**

در محیطی که ارائه را رندر می‌کنید، [get_substitutions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_substitutions/) را فراخوانی کنید تا ببینید Aspose.Slides کدام فونت‌ها را جایگزین خواهد کرد. همچنین تنظیمات [جایگزینی فونت](/slides/fa/python-net/font-substitution/) و قوانین [بازگشت فونت](/slides/fa/python-net/fallback-font/) را بررسی کنید. بازگشت برای کاراکترهای مفقود شده به کار می‌رود، بنابراین تعبیه یک فونت مسألهٔ کاراکترهایی را که خود فونت شاملشان نمی‌شود، حل نمی‌کند.

**آیا باید فونت‌های رایج مانند Arial و Calibri را تعبیه کنم؟**

تصمیم را بر پایهٔ محیط هدف بگیرید. اگر فونت‌های مورد نیاز بر روی هر دستگاهی که ارائه را باز یا رندر می‌کند موجود باشد، تعبیه آن‌ها ممکن است حجم فایل را بی‌دلیل افزایش دهد. اگر گیرندگان یا سرورها ممکن است این فونت‌ها را نداشته باشند، تعبیه آن‌ها می‌تواند به حفظ ظاهر موردنظر کمک کند، مشروط بر این که مجوزهایشان اجازهٔ این کار را بدهد.