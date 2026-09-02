---
title: جستجو و جایگزینی متن در ارائه‌های پاورپوینت با پایتون
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/python-net/search-and-replace-text/
keywords:
- متن جستجو
- متن برجسته
- متن جایگزین
- عبارت منظم
- چارچوب متنی
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های پاورپوینت با Aspose.Slides برای پایتون از طریق .NET."
---
## **مروری کلی**

Aspose.Slides برای Python از طریق .NET می‌تواند متن را در یک چارچوب متنی منفرد یا در کل ارائه جستجو، برجسته و جایگزین کند. این قابلیت‌ها برای بازبینی، محو، بررسی اصطلاحات، پاک‌سازی قالب و سایر گردش‌کارهای خودکار پردازش سند مفید هستند.

در مثال‌های اولیه زیر، ما از فایلی به نام "sample.pptx" استفاده می‌کنیم که شامل یک جعبه متن واحد در اسلاید اول با متن زیر است:

![متن نمونه](sample_text.png)

## **محدوده جستجو را انتخاب کنید**

از متدهای موجود در [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) برای محدود کردن عملیاتی به یک چارچوب متنی استفاده کنید. از متدهای موجود در [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای پردازش تمام متن‌های قابل اعمال در ارائه استفاده کنید.

| عملیات | یک چارچوب متنی | کل ارائه |
|---|---|---|
| Highlight literal text | [TextFrame.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/highlight_text/) |
| Highlight regular-expression matches | [TextFrame.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/highlight_regex/) |
| Replace literal text | [TextFrame.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/replace_text/) |
| Replace regular-expression matches | [TextFrame.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/replace_regex/) |

## **پیکربندی مطابقت متن**

برای عملیات‌های متن به‌صورت متنی، از [TextSearchOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/) برای کنترل مطابقت استفاده کنید:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/whole_words_only/) مطابقت‌ها را به کلمات کامل محدود می‌کند.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/case_sensitive/) تعیین می‌کند که آیا حروف بزرگ و کوچک باید مطابق باشند.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/include_notes/) یادداشت‌های اسلاید را در عملیات‌های جستجو، جایگزینی و برجسته‌سازی در سطح ارائه شامل می‌شود.

عملیات‌های عبارات منظم از یک رشته الگو استفاده می‌کنند، بنابراین قوانین مطابقت مانند حساسیت به حروف و مرزهای کلمه توسط عبارت تعریف می‌شوند.

## **شناسایی مالک یک چارچوب متنی**

گردش‌کارهای عمومی پردازش متن اغلب یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) را هنگام جستجو، جایگزینی، اعتبارسنجی یا استخراج متن دریافت می‌کنند. از [TextFrame.parent_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_shape/) و [TextFrame.parent_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_cell/) برای تعیین اینکه کدام شیء ارائه مالک چارچوب متنی است استفاده کنید.

مقادیر مورد انتظار بسته به مالک متفاوت است:

| مالک چارچوب متنی | `parent_shape` | `parent_cell` |
|---|---|---|
| یک AutoShape یا شکل دیگر حاوی متن | شیء مالک [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) | `None` |
| یک سلول جدول | `None` | شیء مالک [Cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/cell/) |

هر دو ویژگی فقط‑خواندنی هستند و خواندن آنها چارچوب متنی را جابجا یا مالک آن را تغییر نمی‌دهد. کدهای عمومی باید هر دو مقدار را برای `None` بررسی کرده و امکان عدم وجود هر دو مالک را مدیریت کنند.

مثال زیر از [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/get_all_text_frames/) برای پیمایش چارچوب‌های متنی در یک ارائه استفاده می‌کند. برای اشکال، نام شکل، نوع زمان‌اجرای پایتون و اسلاید حامل گزارش می‌شود. برای سلول‌های جدول، مختصات ستون و ردیف صفر‑مبنا و اسلاید حامل گزارش می‌شود.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

برای محتوای SmartArt، از طریق [SmartArtNode.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartartnode/shapes/) به اشکال پیمایش کنید و به هر [ISmartArtShape.text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/ismartartshape/text_frame/) دسترسی پیدا کنید. چارچوب متنی می‌تواند از طریق [TextFrame.parent_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_shape/) به شکل مرتبط خود ردیابی شود، در حالی که [TextFrame.parent_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_cell/) برابر `None` است. بنابراین شاخه شکل در مثال همچنین متن از گره‌های SmartArt را مدیریت می‌کند.

## **برجسته‌سازی متن**

از متد [TextFrame.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_text/) برای برجسته‌سازی تطابق‌های متن به‌صورت متنی در یک چارچوب متنی استفاده کنید. برای کنترل جستجو، یک [TextSearchOptions] را به‌عنوان آرگومان پاس دهید.

کد زیر تمام رخدادهای کاراکترهای **"try"** را برجسته می‌کند و سپس تنها کلمه کامل **"to"** را برجسته می‌نماید.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # برجسته‌سازی همهٔ موارد "try" در قاب متن.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # فقط کلمهٔ کامل "to" را برجسته کن.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![متن برجسته‌شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [TextFrame.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_regex/) متن‌های مطابق با یک عبارت منظم را در یک چارچوب متنی برجسته می‌کند.

کد زیر تمام کلماتی که دارای هفت یا بیشتر کاراکتر هستند را برجسته می‌کند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

نتیجه:

![متن برجسته‌شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در تمام ارائه**

از [Presentation.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/highlight_text/) و [Presentation.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/highlight_regex/) برای جستجو در تمام چارچوب‌های متنی قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک عبارت متنی و تمام آدرس‌های ایمیل را برجسته می‌کند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **جایگزینی متن در یک چارچوب متنی**

از [TextFrame.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_text/) برای متن به‌صورت متنی و از [TextFrame.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_regex/) برای جایگزینی مبتنی بر الگو استفاده کنید. این متدها متن مطابق را در چارچوب متنی موجود به‌روزرسانی می‌کنند و قالب‌بخشی بخش‌های اطراف را حفظ می‌نمایند، به جای بازسازی چارچوب متنی از یک رشته ساده.

مثال زیر یک گونهٔ املا را استانداردسازی می‌کند و سپس برچسب‌های نسخه را جایگزین می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

اگر یک مطابقت بخش‌هایی با قالب‌بندی متفاوت را در بر داشته باشد، خروجی را بررسی کنید تا تأیید شود کدام قالب‌بندی باید برای متن جایگزین اعمال شود.

## **جایگزینی متن در تمام ارائه**

از [Presentation.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/replace_text/) و [Presentation.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/replace_regex/) برای اعمال همان عملیات‌ها در سرتاسر ارائه استفاده کنید. این کار برای پاک‌سازی قالب، به‌روزرسانی اصطلاحات و محو اطلاعات مفید است.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **سوالات متداول**

**چگونه می‌توانم فقط یک جعبه متن را به جای کل ارائه جستجو کنم؟**

چارچوب متنی شکل را دریافت کنید و بر روی آن [TextFrame.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_text/)، [TextFrame.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_regex/)، [TextFrame.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_text/)، یا [TextFrame.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_regex/) را فراخوانی کنید. متدهای سطح ارائه تمام چارچوب‌های متنی قابل اعمال را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ و کوچک صحیح مطابقت دهم؟**

[TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/whole_words_only/) و [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/case_sensitive/) را به `True` تنظیم کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن به‌صورت متنی پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود الگو تعریف کنید.

**آیا جستجو و جایگزینی می‌تواند متن در یادداشت‌های اسلاید را شامل شود؟**

بله. هنگام استفاده از یک عملیات متن به‌صورت متنی در سطح ارائه، [TextSearchOptions.include_notes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/include_notes/) را به `True` تنظیم کنید.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[TextFrame.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_text/) و [TextFrame.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_regex/) متن مطابق را در چارچوب متنی موجود تغییر می‌دهند و قالب‌بندی بخش‌های اطراف را حفظ می‌کنند. اگر یک تطابق بخش‌هایی با قالب‌بندی متفاوت را در بر داشته باشد، نتیجه را بررسی کنید تا اطمینان حاصل شود جایگزینی از سبک مورد نظر استفاده می‌کند.