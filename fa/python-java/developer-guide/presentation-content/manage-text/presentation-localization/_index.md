---
title: خودکارسازی بومی‌سازی ارائه در پایتون از طریق جاوا
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/python-java/presentation-localization/
keywords:
- تغییر زبان
- بررسی املا
- سرکوب بررسی املا
- زبان تصحیح
- شناسه زبان
- متن چندزبانه
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "تنظیم زبان‌های تصحیح برای متن ارائه‌های PowerPoint و OpenDocument در پایتون از طریق جاوا با Aspose.Slides، شامل مقادیر پیش‌فرض و پاراگراف‌های چندزبانه."
---
## **نمای کلی**

Aspose.Slides for Python via Java به شما امکان تنظیم متادیتا تصحیح برای بخش‌های متنی جداگانه را می‌دهد. برای شناسایی زبان تصحیح از [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) استفاده کنید، برای فعال یا غیرفعال کردن بررسی املا از [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpellCheck) و برای کنترل حالت کلی «بدون تصحیح» از [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setProofDisabled) استفاده نمایید. از آنجا که این تنظیمات در سطح بخش اعمال می‌شوند، یک پاراگراف می‌تواند حاوی چندین زبان و قوانین تصحیح متفاوت باشد.

این مقاله توضیح می‌دهد که چگونه یک زبان را به متن خاصی اختصاص دهید، زبان پیش‌فرض برای متن جدید را با [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) تنظیم کنید، پاراگراف‌های چندزبانه بسازید، بین [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpellCheck) و [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setProofDisabled) انتخاب کنید و تنظیمات موردنظر را هنگام استفاده از [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) حفظ کنید. این ویژگی‌ها متادیتای مورد نیاز برنامه‌های ارائه را ذخیره می‌کنند؛ آن‌ها متن را ترجمه، املا را با استفاده از فرهنگ‌نامه بررسی یا کلمات غلط املایی را بر نمی‌گردانند.

## **تنظیم زبان تصحیح برای متن**

یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد یا بارگذاری کنید، بخش متنی موردنیاز را از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getPortionFormat) به دست آورید و شناسه زبان آن را اختصاص دهید. مثال زیر یک شکل می‌سازد، انگلیسی بریتانیایی را به عنوان زبان تصحیح تنظیم می‌کند و نتیجه را با [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم زبان پیش‌فرض برای متن جدید**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعیین زبان تصحیح که Aspose.Slides به متن تازه ایجاد شده اختصاص می‌دهد استفاده کنید. این تنظیم زمانی مفید است که اکثر یا تمام متن‌های جدید در یک ارائه از یک زبان استفاده کنند. این تنظیم متادیتای زبان متن‌های که قبلاً زبان صریح داشته‌اند را تغییر نمی‌دهد.

مثال زیر یک ارائه می‌سازد که متن جدید آن از قوانین تصحیح آلمانی استفاده می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استفاده از چند زبان در یک پاراگراف**

یک [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) شامل مجموعه‌ای از بخش‌های متنی است. برای هر زبان یک [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) جداگانه ایجاد کنید و به‌صورت مستقل [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) آن را تنظیم کنید.

این مثال یک پاراگراف با بخش‌های انگلیسی و فرانسوی می‌سازد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **فعال یا غیرفعال کردن بررسی املا برای بخش‌های جداگانه**

[PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) ویژگی‌های متنی مشترک تعریف‌شده توسط [BasePortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/) را به ارث می‌برد. از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getPortionFormat) به قالب بخش دسترسی پیدا کنید و با استفاده از [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpellCheck) کنترل کنید که آیا برنامه ارائه بتواند املا را برای آن بخش بررسی کند یا نه. مقدار پیش‌فرض `False` است: `True` اجازه بررسی املا را می‌دهد، در حالی که `False` آن را غیرفعال می‌کند.

این تنظیم برای بخش‌های متنی جداگانه اعمال می‌شود. بنابراین بخش‌های مختلف در یک پاراگراف می‌توانند مقادیر متفاوتی داشته باشند. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) و [setSpellCheck](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpellCheck) مقاصد تکمیلی دارند: [setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) زبان تصحیح را شناسایی می‌کند، در حالی که [setSpellCheck](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpellCheck) تعیین می‌کند که آیا بررسی املا برای بخش مجاز است یا نه.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setProofDisabled) نیز کنترل تصحیح را بر عهده دارد، اما وضعیت گسترده‌تر «عدم تصحیح» را به‌صورت یک [NullableBool](https://reference.aspose.com/slides/fa/python-java/aspose.slides/nullablebool/) نشان می‌دهد. وقتی به یک سوئیچ Boolean مستقیم برای بررسی املا نیاز دارید، از [setSpellCheck](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpellCheck) استفاده کنید. وقتی می‌خواهید متادیتای «بدون تصحیح» ارائه را حفظ یا به‌طور صریح کنترل کنید—از جمله وضعیت [NullableBool.NotDefined](https://reference.aspose.com/slides/fa/python-java/aspose.slides/nullablebool/#NotDefined)—از [setProofDisabled](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setProofDisabled) بهره بگیرید. اگر هر دو ویژگی را تنظیم کنید، مقادیر آن‌ها را سازگار نگه داشته و ترکیب [setSpellCheck](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpellCheck) برابر `True` با [setProofDisabled](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setProofDisabled) برابر [NullableBool.True](https://reference.aspose.com/slides/fa/python-java/aspose.slides/nullablebool/#True) را انجام ندهید.

این ویژگی‌ها متادیتای تصحیح را که توسط PowerPoint و برنامه‌های ارائه دیگر استفاده می‌شود تنظیم می‌کنند. Aspose.Slides از آن‌ها برای اجرای بررسی املا بر پایهٔ فرهنگ‌نامه یا برگرداندن فهرست کلمات غلط املایی استفاده نمی‌کند.

مثال کامل زیر یک ارائه ورودی می‌سازد، آن را بارگذاری می‌کند، تنظیمات مختلف بررسی املا و زبان‌های تصحیح را به دو بخش در همان پاراگراف اختصاص می‌دهد، نتیجه را ذخیره می‌کند، دوباره باز می‌کند و مقادیر ذخیره‌شده را تأیید می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) بخش‌های مجاور که قالب یکسان دارند را ترکیب می‌کند. تنها تفاوت در [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpellCheck) کافی نیست تا این بخش‌ها جدا بمانند؛ پس از ترکیب، بخش حاصل مقدار [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpellCheck) اولین بخش را حفظ می‌کند. اگر بخش‌ها به تنظیمات مختلف بررسی املا نیاز دارند، قبل از اختصاص این تنظیمات، [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) را صدا بزنید یا مرزهای بخش‌های حاصل را بررسی کرده و پس از آن تنظیمات را دوباره اعمال کنید. بخش‌هایی که مقدار [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) متفاوتی دارند، به‌دلیل تفاوت قالب‌بندی زبان تصحیح، جدا می‌مانند.

## **پرسش‌های متداول**

**آیا شناسه زبان متن را ترجمه می‌کند؟**

خیر. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) متادیتای تصحیح برای املا و گرامر را ذخیره می‌کند؛ محتوی متن را تغییر نمی‌دهد. متن را جداگانه ترجمه کنید و سپس شناسه زبان مناسب را برای هر بخش ترجمه‌شده تنظیم نمایید.

**آیا زبان تصحیح بر قلم‌ها، هجاگذاری یا شکستن خطوط تأثیر می‌گذارد؟**

خیر. شناسه زبان فقط برای تصحیح استفاده می‌شود. رندر و چیدمان متن عمدتاً به [قلم‌ها](/slides/fa/python-java/powerpoint-fonts/)، سیستم نوشتاری و تنظیمات قاب متن وابسته است. برای رندر قابل‌اعتماد، قلم‌های موردنیاز را فراهم کنید، [جایگزینی قلم](/slides/fa/python-java/font-substitution/) را پیکربندی کنید یا [قلم‌ها را تعبیه](/slides/fa/python-java/embedded-font/) کنید.

**آیا یک پاراگراف می‌تواند چندین زبان تصحیح داشته باشد؟**

بله. همان‌طور که در مثال پاراگراف چندزبانه نشان داده شد، هر زبان را به بخش جداگانه‌ای اختصاص دهید.

**کدامیک را باید استفاده کنم: [setDefaultTextLanguage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) یا [setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId)؟**

وقتی می‌خواهید یک مقدار پیش‌فرض برای متن تازه ایجاد شده داشته باشید، از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) استفاده کنید. وقتی یک بخش خاص نیاز به زبان تصحیح صریح دارد یا یک پاراگراف شامل چندین زبان است، از [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) استفاده کنید.