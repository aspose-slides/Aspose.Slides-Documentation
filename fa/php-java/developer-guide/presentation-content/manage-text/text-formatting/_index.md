---
title: قالب‌بندی متن ارائه در PHP
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/php-java/text-formatting/
keywords:
- برجسته‌سازی متن
- عبارت منظم
- همترازی پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکتر
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی Autofit
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java قالب‌بندی و استایل دهید. قلم‌ها، رنگ‌ها، همترازی و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه می‌توان متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java قالب‌بندی کرد. مواردی چون برجسته‌سازی، رنگ‌های پس‌زمینه، شفافیت، فاصله بین کاراکترها، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار Autofit، لنگر متن، ایستگاه‌های تب و تنظیمات زبان پوشش داده می‌شوند.

در مثال‌های زیر، از فایلی به نام "sample.pptx" استفاده می‌کنیم که شامل یک جعبه متن در اسلاید اول با متن زیر است:

![متن نمونه](sample_text.png)

## **برجسته‌سازی متن**

از متد [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/)`::highlightText` وقتی نیاز به برجسته‌سازی متنی دارید که با یک نمونه خاص در یک قاب متن مطابقت دارد، استفاده کنید. این متد رنگ برجسته را بر روی تکه‌های متن مطابق اعمال می‌کند و می‌تواند با [TextHighlightingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/texthighlightingoptions/) برای کنترل نحوه جستجو، برای مثال برای مطابقت فقط با کلمات کامل، استفاده شود.

مثال کد زیر تمام وقوع‌های کاراکترهای **"try"** را برجسته می‌کند و سپس فقط کلمه کامل **"to"** را برجسته می‌سازد.

```php
$presentation = new Presentation("sample.pptx");
try {
    // اولین شکل را از اولین اسلاید دریافت کنید.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // کلمه "try" را در شکل برجسته کنید.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // کلمه "to" را در شکل برجسته کنید.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![متن برجسته‌شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/)`::highlightRegex` متون مطابق با یک عبارت منظم را برجسته می‌کند.

مثال کد زیر تمام کلماتی را که شامل **هفت کاراکتر یا بیشتر** هستند برجسته می‌کند:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // تمام کلماتی که هفت یا بیشتر کاراکتر داشته باشند را برجسته کنید.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![متن برجسته‌شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **تنظیم رنگ پس‌زمینه متن**

از فرمت پیش‌فرض Portion در [ParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) برای بخش‌های متن جداگانه بهره ببرید.

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **کل پاراگراف** تنظیم شود:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // رنگ برجسته را برای کل پاراگراف تنظیم کنید.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نحوه تنظیم رنگ پس‌زمینه برای **بخش‌های متنی با قلم بولد** را نشان می‌دهد:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // رنگ برجسته را برای بخش متن تنظیم کنید.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **همترازی پاراگراف‌های متنی**

از متد [ParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/)`::setAlignment` برای تنظیم همترازی پاراگراف درون یک قاب متن استفاده کنید. مقدار می‌تواند Centered، Left، Right، Justified و ... باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** همترازی کنیم:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // همترازی پاراگراف را به مرکز تنظیم کنید.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف همترازی شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق جزء آلفای رنگ اختصاص داده‌شده به فرمت پر رنگ [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار کانال آلفا ARGB در مقیاس 0‑255 است، نه درصد شفافیت.

مثال کد زیر نحوه اعمال شفافیت به **کل پاراگراف** را نشان می‌دهد:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // رنگ پر متن را به یک رنگ شفاف تنظیم کنید.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال کد زیر نحوه اعمال شفافیت به **بخش‌های متنی با قلم بولد** را نشان می‌دهد:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // شفافیت بخش متن را تنظیم کنید.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله بین کاراکترها برای متن**

از متد [BasePortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/)`::setSpacing` برای گسترش یا فشرده‌سازی فاصله بین کاراکترها در یک جعبه متن استفاده کنید.

کد PHP زیر نشان می‌دهد چگونه فاصله کاراکترها در **کل پاراگراف** گسترش یابد:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // نکته: برای فشردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // فاصله کاراکتر را گسترش دهید.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله کاراکترها در **بخش‌های متنی با قلم بولد** گسترش یابد:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // نکته: برای فشردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
            $portion->getPortionFormat()->setSpacing(3); // فاصله کاراکتر را گسترش دهید.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصله کاراکترها در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن Kerning برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود، ممکن است کمی تنگ‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های Kerning را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم شامل اطلاعات معتبر Kerning باشد و Kerning در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید Kerning را برای بخش‌های متنی که از قلم تحت تأثیر استفاده می‌کنند، غیرفعال کنید. مقدار متد [BasePortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` را به مقداری به‌صورت قابل توجه بزرگتر از اندازه واقعی قلم تنظیم کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

این تنظیم از اعمال Kerning بر روی بخش‌های متنی مطابقت‌دار جلوگیری می‌کند و می‌تواند به همسویی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق فرمت پیش‌فرض Portion در [ParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/) یا برای هر Portion به‌صورت جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) تنظیم شوند.

کد زیر قلم و سبک متن برای **کل پاراگراف** را تنظیم می‌کند: اندازه قلم، Bold، Italic، زیرخط نقطه‌ای و قلم Times New Roman را برای همه Portionها در پاراگراف اعمال می‌کند.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // ویژگی‌های قلم را برای پاراگراف تنظیم کنید.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال کد زیر ویژگی‌های مشابه را برای **بخش‌های متنی با قلم بولد** اعمال می‌کند:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // ویژگی‌های قلم را برای بخش متن تنظیم کنید.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از متد [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` برای تعیین جهت‌گیری پیش‌فرض متن درون یک شکل استفاده کنید.

کد زیر جهت‌گیری متن در شکل را به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه ضد‌ساعت‌گرد** می‌چرخاند:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای قاب‌های متن**

از متد [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/)`::setRotationAngle` برای تنظیم زاویه چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) استفاده کنید.

کد زیر قاب متن را داخل شکل به میزان ۳ درجه ساعتگرد می‌چرخاند:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides متدهای [ParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`، `ParagraphFormat::setSpaceBefore` و `ParagraphFormat::setSpaceWithin` را برای کنترل فاصله پاراگراف ارائه می‌دهد. این متدها به شکل زیر استفاده می‌شوند:

* استفاده از مقدار مثبت برای تعیین فاصله خط به‌عنوان درصدی از ارتفاع خط.
* استفاده از مقدار منفی برای تعیین فاصله خط بر حسب نقاط.

کد زیر نشان می‌دهد چگونه فاصله خط را درون پاراگراف مشخص کنیم:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصله خطوط در پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای قاب‌های متن**

متد [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/)`::setAutofitType` تعیین می‌کند که متن هنگام تجاوز از مرزهای محفظه‌اش چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، بیش از حد پر شود یا به‌صورت خودکار اندازه شکل تغییر کند، استفاده کنید.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم لنگر قاب‌های متن**

متد [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/)`::setAnchoringType` نحوه موقعیت‌گذاری عمودی متن داخل یک شکل را تعریف می‌کند، برای مثال در بالا، وسط یا پایین.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم تب‌بندی متن**

از متد [ParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` و مجموعه تب‌های آن برای پیکربندی ایستگاه‌های تب در یک پاراگراف استفاده کنید.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان اصلاح‌خط**

Aspose.Slides متد [BasePortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/)`::setLanguageId` را فراهم می‌کند که به شما امکان می‌دهد زبان اصلاح‌خط برای یک Portion متن را تنظیم کنید. زبان اصلاح‌خط تعیین می‌کند کدام زبان برای بررسی املا و گرامر در PowerPoint استفاده شود.

کد زیر نشان می‌دهد چگونه زبان اصلاح‌خط برای یک Portion متن تنظیم شود:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // شناسهٔ زبان اصلاح‌خط را تنظیم کنید.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از متد [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` برای تعریف زبان پیش‌فرض متنی که در زمان بارگذاری یا ایجاد یک ارائه ایجاد می‌شود، استفاده کنید.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل مستطیلی جدید با متن اضافه کنید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // زبان اولین قسمت را بررسی کنید.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از سبک متن پیش‌فرض [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) استفاده کنید.

کد زیر نشان می‌دهد چگونه یک قلم بولد با اندازه ۱۴ پوینت به‌عنوان پیش‌فرض برای تمام متن‌های اسلایدها در یک ارائه جدید تنظیم شود.

```php
$presentation = new Presentation();
try {
    // دریافت فرمت پاراگراف سطح بالایی.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **استخراج متن با اثر All‑Caps**

در PowerPoint، اعمال اثر **All Caps** باعث می‌شود متن روی اسلاید با حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. وقتی چنین Portion متنی را با Aspose.Slides بازیابی می‌کنید، کتابخانه دقیقاً همان متن را که وارد شده برمی‌گرداند. برای تطبیق با متنی که نمایش داده می‌شود، مقدار [TextCapType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textcaptype/) را بررسی کنید و هنگامی که مقدار `All` باشد، رشتهٔ بازگردانده‌شده را به حروف بزرگ تبدیل کنید.

بگذارید بگوییم یک جعبه متن در اسلاید اول فایل sample2.pptx داریم.

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن با اثر **All Caps** استخراج شود:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **سوالات متداول**

**چگونه متن در جدول یک اسلاید را ویرایش کنیم؟**

برای ویرایش متن در جدول یک اسلاید، از [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق فریم متن [Cell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cell/) و قالب‌بندی پاراگراف [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) به‌روزرسانی نمایید.

**چگونه رنگ گرادیان به متن در یک اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از فرمت پر [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) استفاده کنید. نوع پر را در [FillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) به [FillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) `Gradient` تنظیم کنید و ایستگاه‌های گرادیان، جهت و شفافیت را پیکربندی کنید.