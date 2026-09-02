---
title: اتوماسیون بومی‌سازی ارائه در PHP
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/php-java/presentation-localization/
keywords:
- تغییر زبان
- بررسی املایی
- سرکوب بررسی املایی
- زبان تصحیح
- شناسه‌ زبان
- متن چندزبانه
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "در PHP با Aspose.Slides زبان‌های تصحیح را برای متن ارائهٔ PowerPoint و OpenDocument تنظیم کنید، شامل پیش‌فرض‌ها و پاراگراف‌های چندزبانه."
---
## **مرور کلی**

Aspose.Slides for PHP via Java به شما امکان پیکربندی داده‌های متادیتای تصحیح متون برای بخش‌های متنی جداگانه را می‌دهد. از [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) برای تعیین زبان تصحیح، از [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setSpellCheck) برای فعال یا غیرفعال کردن بررسی املایی و از [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setProofDisabled) برای کنترل حالت کلی «بدون تصحیح» استفاده کنید. چون این تنظیمات در سطح بخش (portion) اعمال می‌شوند، یک پاراگراف می‌تواند شامل چندین زبان و قوانین تصحیح متفاوت باشد.

این مقاله توضیح می‌دهد چگونه به متن خاصی زبان اختصاص دهید، زبان پیش‌فرض برای متن جدید را با [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) تنظیم کنید، پاراگراف‌های چندزبانه بسازید، بین `SpellCheck` و `ProofDisabled` انتخاب کنید و تنظیمات مورد نظر را هنگام استفاده از [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) حفظ کنید. این ویژگی‌ها متادیتای مربوط به برنامه‌های ارائه را ذخیره می‌کنند؛ آن‌ها متن را ترجمه نمی‌کنند، بررسی املایی بر پایهٔ واژه‌نامه را انجام نمی‌دهند و کلمات غلط املایی را بر نمی‌گردانند.

## **تنظیم زبان تصحیح برای متن**

یک شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد یا بارگذاری کنید، بخش متنی مورد نیاز را از طریق [Portion::getPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#getPortionFormat) دریافت کنید و شناسهٔ زبان آن را تنظیم کنید. مثال زیر یک شکل ایجاد می‌کند، انگلیسی بریتانیایی را به عنوان زبان تصحیح تنظیم می‌گیرد و نتیجه را با [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) ذخیره می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم زبان پیش‌فرض برای متن جدید**

از [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای مشخص کردن زبان تصحیحی که Aspose.Slides به متنی که تازه ایجاد می‌شود اختصاص می‌دهد، استفاده کنید. این تنظیم زمانی مفید است که اکثر یا تمام متون جدید در یک ارائه از یک زبان استفاده کنند. این تنظیم متادیتای زبان متن‌های پیش‌اکنون دارای شناسهٔ صریح را تغییر نمی‌دهد.

مثال زیر یک ارائه ایجاد می‌کند که متن‌های جدید آن از قوانین تصحیح آلمانی پیروی می‌کنند:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **استفاده از چند زبان در یک پاراگراف**

یک [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) شامل مجموعه‌ای از بخش‌های متنی است. برای هر زبان یک [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) جداگانه ایجاد کنید و `LanguageId` آن را به‌طور مستقل تنظیم نمایید.

این مثال یک پاراگراف با بخش‌های انگلیسی و فرانسوی ایجاد می‌کند:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **فعال یا غیرفعال کردن بررسی املایی برای بخش‌های جداگانه**

[PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) ویژگی‌های متنی مشترک تعریف‌شده توسط [BasePortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/) را به ارث می‌برد. قالب یک بخش را از طریق [Portion::getPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#getPortionFormat) دریافت کنید و با استفاده از [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setSpellCheck) تعیین کنید که آیا برنامهٔ ارائه می‌تواند املای آن بخش را بررسی کند یا نه. مقدار پیش‌فرض `false` است: `true` اجازهٔ بررسی املایی را می‌دهد، در حالی که `false` آن را سرکوب می‌کند.

این تنظیم برای بخش‌های متنی جداگانه اعمال می‌شود. بنابراین بخش‌های مختلف در یک پاراگراف می‌توانند مقادیر متفاوتی داشته باشند. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) و `setSpellCheck` مقاصد تکمیلی دارند: `setLanguageId` زبان تصحیح را شناسایی می‌کند، در حالی که `setSpellCheck` تعیین می‌کند آیا بررسی املایی برای بخش مجاز است یا خیر.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setProofDisabled) نیز بر تصحیح تأثیر می‌گذارد، اما حالت گستردهٔ «بدون تصحیح» را به صورت یک [NullableBool](https://reference.aspose.com/slides/fa/php-java/aspose.slides/nullablebool/) نشان می‌دهد. زمانی که به‌دنبال یک سوئیچ بولی مستقیم برای بررسی املایی هستید، از `setSpellCheck` استفاده کنید. وقتی نیاز به حفظ یا کنترل صریح متادیتای «بدون تصحیح» ارائه دارید—از جمله حالت `NotDefined`—از `setProofDisabled` استفاده نمایید. اگر هر دو ویژگی را تنظیم کردید، مقادیرشان را سازگار نگه دارید؛ `setSpellCheck(true)` را با `setProofDisabled(NullableBool::True)` ترکیب نکنید.

این ویژگی‌ها متادیتای تصحیح را برای PowerPoint و دیگر برنامه‌های ارائه تنظیم می‌کنند. Aspose.Slides از آن‌ها برای اجرای بررسی املایی مبتنی بر واژه‌نامه یا برگرداندن فهرست کلمات غلط املایی استفاده نمی‌کند.

مثال کامل زیر یک ارائهٔ ورودی ایجاد می‌کند، آن را می‌خواند، تنظیمات مختلف بررسی املایی و زبان‌های تصحیح را به دو بخش در همان پاراگراف اختصاص می‌دهد، نتیجه را ذخیره می‌کند، مجدداً باز می‌کند و مقادیر ذخیره‌شده را تأیید می‌کند:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) بخش‌های مجاور که قالب‌بندی یکسان دارند را ترکیب می‌کند. تنها تفاوت در `SpellCheck` کافی نیست تا این بخش‌ها جدا بمانند؛ پس از ترکیب، بخش حاصل مقدار `SpellCheck` اولین بخش را حفظ می‌کند. اگر بخش‌ها به تنظیمات متفاوت بررسی املایی نیاز داشته باشند، قبل از اختصاص این تنظیمات، `joinPortionsWithSameFormatting` را فراخوانی کنید یا مرزهای بخش‌های نتیجه‌گیری را بررسی کرده و پس از آن تنظیمات را دوباره اعمال کنید. بخش‌هایی با مقادیر مختلف `LanguageId` به دلیل متفاوت بودن قالب‌بندی زبان تصحیح، جدا می‌مانند.

## **سوالات متداول**

**آیا شناسهٔ زبان متن را ترجمه می‌کند؟**

خیر. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) متادیتای تصحیح را برای املایی و دستوری ذخیره می‌کند؛ محتویات متن را تغییر نمی‌دهد. متن را جداگانه ترجمه کنید و سپس شناسهٔ زبان مناسب را برای هر بخش ترجمه‌شده تنظیم کنید.

**آیا زبان تصحیح بر فونت‌ها، هجاگذاری یا بسته‌بندی خطوط تاثیر می‌گذارد؟**

خیر. شناسهٔ زبان فقط برای تصحیح استفاده می‌شود. رندر و چیدمان متن عمدتاً به [فونت‌های](/slides/fa/php-java/powerpoint-fonts/) موجود، سیستم نوشتاری و تنظیمات چارچوب متن وابسته است. برای رندر قابل اعتماد، فونت‌های مورد نیاز را فراهم کنید، [جایگزینی فونت](/slides/fa/php-java/font-substitution/) را پیکربندی کنید یا [فونت‌ها را جاسازی](/slides/fa/php-java/embedded-font/) کنید.

**آیا یک پاراگراف می‌تواند چندین زبان تصحیح داشته باشد؟**

بله. همان‌طور که در مثال پاراگراف چندزبانه نشان داده شد، هر زبان را به یک بخش جداگانه اختصاص دهید.

**کدامیک را باید استفاده کنم: `setDefaultTextLanguage` یا `setLanguageId`؟**

وقتی می‌خواهید برای متنی که تازه ایجاد می‌شود مقدار پیش‌فرضی داشته باشید، از [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) استفاده کنید. وقتی یک بخش خاص به زبان تصحیح صریحی نیاز دارد یا پاراگراف شامل چندین زبان است، از [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) استفاده کنید.