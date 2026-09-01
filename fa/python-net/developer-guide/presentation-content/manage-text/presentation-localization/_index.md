---
title: اتوماتیک‌سازی بومی‌سازی ارائه با پایتون
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/python-net/presentation-localization/
keywords:
- تغییر زبان
- بررسی املایی
- سرکوب بررسی املایی
- زبان اصلاح
- شناسه زبان
- متن چندزبانه
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "تنظیم زبان‌های اصلاح برای متن ارائه PowerPoint و OpenDocument در پایتون با Aspose.Slides، شامل پیش‌فرض‌ها و پاراگراف‌های چندزبانه."
---
## **بررسی کلی**

Aspose.Slides for Python via .NET به شما امکان پیکربندی فرادادهٔ اصلاح برای بخش‌های متنی جداگانه را می‌دهد. برای شناسایی زبان اصلاح از [BasePortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/language_id/) استفاده کنید، برای اجازه یا سرکوب بررسی‌های املایی از [BasePortionFormat.spell_check](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/spell_check/) و برای کنترل حالت کلی عدم اصلاح از [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/proof_disabled/) استفاده کنید. چون این تنظیمات در سطح بخش اعمال می‌شوند، یک پاراگراف می‌تواند شامل چند زبان و قوانین اصلاح متفاوت باشد.

این مقاله توضیح می‌دهد چگونه یک زبان را به متن خاصی اختصاص دهید، زبان پیش‌فرض برای متن جدید را با [LoadOptions.default_text_language](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/default_text_language/) تنظیم کنید، پاراگراف‌های چندزبانه بسازید، بین `spell_check` و `proof_disabled` انتخاب کنید و هنگام استفاده از [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) تنظیمات مورد نظر را حفظ کنید. این ویژگی‌ها فراداده‌ای را برای برنامه‌های ارائه ذخیره می‌کنند؛ آنها متن را ترجمه، چک‌کردن املایی مبتنی بر فرهنگ‌لغت انجام یا کلمات نادرست را بر نمی‌گردانند.

## **تنظیم زبان اصلاح برای متن**

یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) را ایجاد یا بارگیری کنید، به بخش متنی مورد نیاز از طریق [Portion.portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/portion_format/) دسترسی پیدا کنید و شناسهٔ زبان آن را اختصاص دهید. مثال زیر یک شکل ایجاد می‌کند، انگلیسی بریتانیایی را به عنوان زبان اصلاح تنظیم می‌کند و نتیجه را با [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) ذخیره می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زبان پیش‌فرض برای متن جدید**

از [LoadOptions.default_text_language](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/default_text_language/) برای تعیین زبان اصلاحی که Aspose.Slides به متن تازه ایجاد شده اختصاص می‌دهد، استفاده کنید. این تنظیم در مواقعی مفید است که اکثر یا تمام متن‌های جدید یک ارائه از یک زبان استفاده می‌کنند. این تنظیم فرادادهٔ زبان متن‌هایی که قبلاً شناسهٔ صریح داشته‌اند را تغییر نمی‌دهد.

مثال زیر یک ارائه ایجاد می‌کند که متن جدید آن از قواعد اصلاحی آلمانی استفاده می‌کند:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **استفاده از چند زبان در یک پاراگراف**

یک [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) شامل مجموعه‌ای از بخش‌های متنی است. برای هر زبان یک [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) جداگانه ایجاد کنید و `language_id` آن را به‌صورت مستقل تنظیم کنید.

این مثال یک پاراگراف با بخش‌های انگلیسی و فرانسوی ایجاد می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **فعال یا غیرفعال کردن بررسی املایی برای بخش‌های جداگانه**

[PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) ویژگی‌های متنی مشترکی را که توسط [BasePortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/) تعریف شده‌اند ارث می‌برد. از طریق [Portion.portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/portion_format/) به قالب یک بخش دسترسی پیدا کنید و [BasePortionFormat.spell_check](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/spell_check/) را تنظیم کنید تا تعیین کنید برنامهٔ ارائه آیا می‌تواند املا را برای آن بخش بررسی کند یا نه. مقدار پیش‌فرض `False` است: `True` اجازهٔ بررسی املایی می‌دهد، در حالی که `False` آن را سرکوب می‌کند.

این تنظیم برای بخش‌های متنی جداگانه اعمال می‌شود. بنابراین بخش‌های مختلف در یک پاراگراف می‌توانند مقادیر متفاوتی داشته باشند. [BasePortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/language_id/) و `spell_check` مقاصد تکمیلی دارند: `language_id` زبان اصلاح را شناسایی می‌کند، در حالی که `spell_check` تعیین می‌کند آیا بررسی املایی برای بخش مجاز است یا خیر.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/proof_disabled/) نیز بر اصلاح تاثیر دارد، اما حالت گسترده‌تر «عدم اصلاح» را به‌صورت یک [NullableBool](https://reference.aspose.com/slides/fa/python-net/aspose.slides/nullablebool/) نمایش می‌دهد. وقتی نیاز به یک سوئیچ Boolean مستقیم برای بررسی املایی دارید، از `spell_check` استفاده کنید. وقتی نیاز به حفظ یا کنترل صریح متادیتای عدم اصلاح ارائه، از جمله حالت `NOT_DEFINED` آن دارید، از `proof_disabled` استفاده کنید. اگر هر دو ویژگی را تنظیم کنید، مقادیرشان باید سازگار باشد؛ ترکیب `spell_check = True` با `proof_disabled = slides.NullableBool.TRUE` مجاز نیست.

این ویژگی‌ها فرادادهٔ اصلاحی را که توسط PowerPoint و سایر برنامه‌های ارائه مورد استفاده قرار می‌گیرد پیکربندی می‌کنند. Aspose.Slides از آنها برای اجرای چک‌کردن املایی مبتنی بر فرهنگ‌لغت یا بازگرداندن لیستی از کلمات نادرست استفاده نمی‌کند.

مثال کامل زیر یک ارائهٔ ورودی ایجاد می‌کند، آن را بارگیری می‌کند، تنظیمات مختلف بررسی املا و زبان‌های اصلاح را به دو بخش در همان پاراگراف اختصاص می‌دهد، نتیجه را ذخیره می‌کند، دوباره باز می‌کند و مقادیر ذخیره‌شده را تأیید می‌کند:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) بخش‌های مجاور که قالب یکسان دارند را ترکیب می‌کند. تنها اختلاف در `spell_check` باعث نگه‌داشتن جدا بودن این بخش‌ها نمی‌شود؛ پس از ترکیب، بخش حاصل مقدار `spell_check` بخش اول را حفظ می‌کند. اگر بخش‌ها نیاز به تنظیمات متفاوت بررسی املا داشته باشند، قبل از اختصاص این تنظیمات `join_portions_with_same_formatting` را فراخوانی کنید یا مرزهای بخش‌های حاصل را بررسی کرده و پس از آن تنظیمات را دوباره اعمال کنید. بخش‌هایی که مقدار `language_id` متفاوت دارند به دلیل تفاوت قالب زبان اصلاحی، جدا می‌مانند.

## **FAQ**

**آیا شناسهٔ زبان متن را ترجمه می‌کند؟**

نه. [BasePortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/language_id/) فرادادهٔ اصلاحی برای املا و دستور زبان را ذخیره می‌کند؛ محتویات متن را تغییر نمی‌دهد. متن را جداگانه ترجمه کنید و سپس شناسهٔ زبان مناسب را برای هر بخش ترجمه‌شده تنظیم کنید.

**آیا زبان اصلاح بر قلم‌ها، شکستن واژه یا بسته‌بندی خطوط تأثیر دارد؟**

نه. شناسهٔ زبان برای اصلاح است. رندر و چیدمان متن عمدتاً به [قلم‌ها](/slides/fa/python-net/powerpoint-fonts/)، سیستم نوشتاری و تنظیمات فریم متن وابسته است. برای رندر قابل اعتماد، قلم‌های مورد نیاز را فراهم کنید، [جایگزینی قلم](/slides/fa/python-net/font-substitution/) را پیکربندی کنید یا [قلم‌ها را جاگذاری](/slides/fa/python-net/embedded-font/) کنید.

**آیا یک پاراگراف می‌تواند از چند زبان اصلاح استفاده کند؟**

بله. همان‌طور که در مثال پاراگراف چندزبانه نشان داده شد، هر زبان را به یک بخش جداگانه اختصاص دهید.

**کدامیک را باید استفاده کنم: `default_text_language` یا `language_id`؟**

وقتی می‌خواهید برای متن تازه‌ساخته‌شده پیش‌فرض تعیین کنید، از [LoadOptions.default_text_language](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/default_text_language/) استفاده کنید. وقتی یک بخش خاص نیاز به زبان اصلاح صریح دارد یا پاراگراف شامل چند زبان است، از [BasePortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/language_id/) استفاده کنید.