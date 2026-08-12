---
title: جستجو و جایگزینی متن در ارائه‌های پاورپوینت با پایتون
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/python-net/search-and-replace-text/
keywords:
- جستجوی متن
- برجسته‌سازی متن
- جایگزینی متن
- عبارت منظم
- قاب متن
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های پاورپوینت با Aspose.Slides برای Python از طریق .NET."
---
## **مروری کلی**

Aspose.Slides برای Python از طریق .NET می‌تواند متن را در یک فریم متنی منفرد یا در سرتاسر یک ارائه جستجو، برجسته و جایگزین کند. این قابلیت‌ها برای بازنگری، سانسور، بررسی اصطلاحات، پاک‌سازی قالب و سایر جریان‌های کاری خودکار پردازش اسناد مفید هستند.

در مثال‌های اول زیر، از فایلی به نام "sample.pptx" استفاده می‌کنیم که شامل یک جعبه متن در اسلاید اول است و متن زیر را دارد:

![متن نمونه](sample_text.png)

## **انتخاب محدوده جستجو**

از متدهای موجود در [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) برای محدود کردن عملیات به یک فریم متنی استفاده کنید. از متدهای موجود در [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای پردازش تمام متن‌های قابل اعمال در ارائه استفاده کنید.

| عملیات | یک فریم متنی | کل ارائه |
|---|---|---|
| برجسته‌سازی متن به صورت دقیق | [TextFrame.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/highlight_text/) |
| برجسته‌سازی تطبیق‌های عبارت منظم | [TextFrame.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/highlight_regex/) |
| جایگزینی متن به صورت دقیق | [TextFrame.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/replace_text/) |
| جایگزینی تطبیق‌های عبارت منظم | [TextFrame.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/replace_regex/) |

## **پیکربندی مطابقت متن**

برای عملیات متن دقیق، از [TextSearchOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/) برای کنترل مطابقت استفاده کنید:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/whole_words_only/) تطبیق‌ها را به کلمات کامل محدود می‌کند.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/case_sensitive/) تعیین می‌کند که آیا حروف باید با همان حالت (حروف بزرگ/کوچک) مطابقت داشته باشند.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/include_notes/) یادداشت‌های اسلاید را در جستجو، جایگزینی و عملیات برجسته‌سازی در سطح ارائه گنجانده می‌شود.

عملیات عبارات منظم از یک رشته الگو استفاده می‌کنند، بنابراین قوانین مطابقت مانند حساسیت به حروف و مرزهای کلمه توسط عبارت تعریف می‌شوند.

## **برجسته‌سازی متن**

از متد [TextFrame.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_text/) برای برجسته‌سازی تطبیق‌های متن دقیق در یک فریم متنی استفاده کنید. برای کنترل جستجو، [TextSearchOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/) را به آن پاس دهید.

کد زیر تمام وقوع‌های کاراکترهای **"try"** را برجسته می‌کند و سپس فقط کلمه کامل **"to"** را برجسته می‌سازد.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # هر رخداد "try" را در فریم متن برجسته کنید.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # فقط کلمه کامل "to" را برجسته کنید.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![متن برجسته شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [TextFrame.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_regex/) تطبیق‌های متنی یافت‌شده توسط یک عبارت منظم را در یک فریم متنی برجسته می‌کند.

کد زیر تمام کلماتی که شامل هفت کاراکتر یا بیشتر هستند را برجسته می‌کند:

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

![متن برجسته شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در سراسر یک ارائه**

از [Presentation.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/highlight_text/) و [Presentation.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/highlight_regex/) برای جستجوی تمام فریم‌های متنی قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک اصطلاح دقیق و تمام آدرس‌های ایمیل را برجسته می‌کند:

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

## **جایگزینی متن در یک فریم متنی**

از [TextFrame.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_text/) برای متن دقیق و از [TextFrame.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_regex/) برای جایگزینی مبتنی بر الگو استفاده کنید. این متدها متن مطابقت یافته را در فریم متنی موجود به‌روزرسانی می‌کنند و قالب‌بندی بخش‌های اطراف را حفظ می‌نمایند، به‌جای بازسازی فریم متنی از یک رشته ساده.

مثال زیر یک گونهٔ املایی را استانداردسازی کرده و سپس برچسب‌های نسخه را جایگزین می‌کند:

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

اگر یک تطبیق بخش‌هایی با قالب‌بندی‌های متفاوت را پوشش دهد، خروجی را بررسی کنید تا تأیید کنید کدام قالب‌بندی باید بر متن جایگزین اعمال شود.

## **جایگزینی متن در سراسر یک ارائه**

از [Presentation.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/replace_text/) و [Presentation.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/replace_regex/) برای اعمال همان عملیات در سرتاسر ارائه استفاده کنید. این روش برای پاک‌سازی قالب، به‌روزرسانی اصطلاحات و سانسور مفید است.

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

## **سؤالات متداول**

**چگونه می‌توانم فقط یک جعبه متن را به جای کل ارائه جستجو کنم؟**

فریم متنی شکل را دریافت کنید و متدهای [TextFrame.highlight_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_text/), یا [TextFrame.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_regex/) را بر روی آن فریم متنی فراخوانی کنید. متدهای سطح ارائه تمام فریم‌های متنی قابل اعمال را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت دهم؟**

[TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/whole_words_only/) و [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/case_sensitive/) را به `True` تنظیم کنید و این گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن دقیق پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود الگو تعریف کنید.

**آیا جستجو و جایگزینی می‌تواند متن در یادداشت‌های اسلاید را شامل شود؟**

بله. هنگام استفاده از عملیات متن دقیق در سطح ارائه، [TextSearchOptions.include_notes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textsearchoptions/include_notes/) را به `True` تنظیم کنید.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[TextFrame.replace_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_text/) و [TextFrame.replace_regex](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/replace_regex/) متن مطابقت یافته را در فریم متنی موجود تغییر می‌دهند و قالب‌بندی بخش‌های اطراف را حفظ می‌کنند. اگر یک تطبیق بخش‌هایی با قالب‌بندی‌های متفاوت را در بر بگیرد، نتیجه را بررسی کنید تا اطمینان حاصل کنید که جایگزینی از سبک مورد نظر استفاده می‌کند.