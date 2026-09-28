---
title: قالب‌بندی متن ارائه در PHP
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/php-java/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله حروف
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی autofit
- لنگر قاب متن
- تب‌گذاری متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java قالب‌بندی و استایل کنید. قلم‌ها، رنگ‌ها، تراز و موارد بیشتر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java قالب‌بندی کنید. این راهنما رنگ پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار Autofit، موقعیت متن، توقف‌های تب و تنظیمات زبان را پوشش می‌دهد.

مگر آنکه خلاف آن ذکر شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل به‌صورت صفر‑مبنا هستند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌کنند، از جمله قالب‌بندی بولد به ارث‌برده:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن دقیق یا مطابقت‌های عبارت‌منظم، به [جستجو و جایگزینی متن](/slides/fa/php-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#getHighlightColor) برای بخش‌های متنی منفرد.

مثال زیر یک برجسته خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح در بخش‌های منفرد بر این پیش‌فرض اولویت دارند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // رنگ برجسته را برای تمام پاراگراف تنظیم کنید.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نحوه تنظیم رنگ پس‌زمینه برای **بخش‌های متنی با قلم بولد** را نشان می‌دهد:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // رنگ برجسته را برای بخش متن تنظیم کنید.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متنی**

از [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setAlignment) برای تنظیم تراز پاراگراف درون یک فریم متن استفاده کنید. مقدار می‌تواند centered، left-aligned، right-aligned، justified و ... باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // تراز پاراگراف را به مرکز تنظیم کنید.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگ اختصاص داده‌شده به [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#getFillFormat) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار آلفای ARGB در مقیاس ۰‑۲۵۵ است، نه درصد شفافیت.

کد زیر نحوه اعمال شفافیت به **کل پاراگراف** را نشان می‌دهد:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // رنگ پر کردن متن را به رنگ شفاف تنظیم کنید.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نحوه اعمال شفافیت به **بخش‌های متنی با قلم بولد** را نشان می‌دهد:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // شفافیت بخش متن را تنظیم کنید.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصلهٔ حروف برای متن**

از [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setSpacing) برای افزایش یا کاهش فاصله بین حروف در یک جعبه متن استفاده کنید. مثال‌ها ۳ پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کنند.

کد PHP زیر نشان می‌دهد چگونه فاصلهٔ حروف را در **کل پاراگراف** گسترش دهید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // توضیح: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // فاصله حروف را گسترش دهید.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصلهٔ حروف در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصلهٔ حروف را در **بخش‌های متنی با قلم بولد** گسترش دهید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // توجه: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
            $portion->getPortionFormat()->setSpacing(3); // فاصله حروف را گسترش دهید.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصلهٔ حروف در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی Kerning برای قلم‌های خاص**

در برخی موارد، متن رندر شده توسط Aspose.Slides ممکن است کمی فشرده‌تر از همان متن در PowerPoint به‌نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های kerning را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم حاوی اطلاعات kerning معتبر باشد و kerning در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر به PowerPoint، می‌توانید kerning را برای بخش‌های متنی که از قلم موردنظر استفاده می‌کنند، غیرفعال کنید. مقدار [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) را بزرگتر از اندازهٔ واقعی قلم تنظیم کنید. این مثال به پروندهٔ "presentation.pptx" که در اولین اسلاید یک جعبه متن به‌عنوان اولین شکل دارد، نیاز دارد. نام‌های قلم مؤثر، شامل قلم‌های به‌ارث‌برده، بررسی می‌شوند و آستانهٔ ۱۰۰ پوینت برای بخش‌هایی که از Roboto استفاده می‌کنند، تنظیم می‌شود. این کار kerning را برای بخش‌های مطابق با اندازهٔ قلم زیر ۱۰۰ پوینت غیرفعال می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای متن مطابقت‌یافته زیر آستانه، این تنظیم از kerning جلوگیری می‌کند و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت تأثیر این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) یا در بخش‌های منفرد از طریق [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به ۱۲ پوینت Times New Roman با فرمت بولد، ایتالیک و زیرخط نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح در بخش‌های منفرد بر این پیش‌فرض‌ها اولویت دارد:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // ویژگی‌های قلم را برای پاراگراف تنظیم کنید.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال زیر قلم ۱۳ پوینت Times New Roman، فرمت ایتالیک و زیرخط نقطه‌دار را بر بخش‌هایی که قالب‌بندی مؤثرشان بولد است، اعمال می‌کند:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // ویژگی‌های قلم را برای بخش متنی تنظیم کنید.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
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

از [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setTextVerticalType) برای تنظیم جهت پیش‌تعریف‌شدهٔ متن درون یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به [TextVerticalType::Vertical270](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه ضد ساعت‌گرد** می‌چرخاند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متنی**

از [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setRotationAngle) برای تنظیم زاویهٔ چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متن را داخل شکل به میزان ۳ درجه ساعت‌گرد می‌چرخاند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصلهٔ خط پاراگراف‌ها**

Aspose.Slides متدهای [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setSpaceWithin) را برای کنترل فاصلهٔ پاراگراف ارائه می‌دهد. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* برای تعیین فاصلهٔ خط به‌صورت درصدی از ارتفاع خط، از مقدار مثبت استفاده کنید.
* برای تعیین فاصلهٔ خط به‌صورت پوینت، از مقدار منفی استفاده کنید.

مثال زیر فاصلهٔ داخلی اولین پاراگراف را به ۲۰۰٪ از ارتفاع خط (دو برابر) تنظیم می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصلهٔ خط درون پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیا را ترکیب می‌کنند، مفید هستند. توابع زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/) هستند و بنابراین بر تمام پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) قواعد شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند جایگاه بسته شدن متن و نقطه‌گذاری شرق آسیا را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) قواعد شکست خط شرق آسیا را کنترل می‌کند، از جمله محدودیت‌های کاراکتر در ابتدای و انتهای خط.

این قواعد جایگزین [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setWrapText) نمی‌شوند؛ این متد بسته‌بندی خودکار را درون فریم متن فعال می‌کند. آن‌ها چیدمان را هنگام بسته شدن تأثیر می‌گذارند؛ کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید را درون پاراگراف مستقل از عرض موجود ایجاد می‌کند.

مثال زیر یک بلوک متنی باریک شامل متن چینی و لاتین ایجاد می‌کند. هر دو گزینهٔ شکست خط به‌صورت صریح تنظیم شده و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر قاعده، مقدار مربوطه را تغییر دهید و تنظیمات دیگر را ثابت بمانید. مثال از Arial ۲۴ پوینت و SimSun با عرض فریم ۱۶۰ پوینت و حاشیهٔ افقی صفر استفاده می‌کند. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setAutofitType) با [TextAutofitType::None](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد فریم ثابت بماند.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **کنترل نقطه‌گذاری معلق**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) به علامت‌های نگارشی مجاز اجازه می‌دهد تا فراتر از لبهٔ راست خط متن extend شوند به‌جای این‌که در خط بعدی قرار گیرند. این ویژگی بر تمام پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال زیر نقطه‌گذاری معلق را در یک فریم متنی ۱۰۰ پوینت عرض فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌نماید. با Arial ۲۴ پوینت و حاشیهٔ افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و از لبهٔ راست متن فراتر می‌رود. برای مقایسه مقدار را به [NullableBool::False](https://reference.aspose.com/slides/fa/php-java/aspose.slides/nullablebool/) تنظیم کنید: در این حالت نقطه در خط جداگانه‌ای قرار می‌گیرد. بسته‌بندی فعال و Autofit غیرفعال شده تا عرض موجود ثابت بماند.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

همهٔ علامت‌های نگارشی قابل معلق شدن نیستند. نتیجهٔ قابل مشاهده به در دسترس بودن قلم و چیدمان بستگی دارد: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات Autofit می‌تواند تفاوت قابل مشاهده را از بین ببرد.

## **تنظیم نوع Autofit برای فریم‌های متنی**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند که متن هنگام تجاوز از مرزهای محفظهٔ خود چگونه رفتار کند. از این ویژگی برای کنترل اینکه متن کوچک شود، overflow داشته باشد یا شکل به‌طور خودکار اندازه‌بندی شود، استفاده کنید. مثال زیر شکل را برای تنظیم به اندازهٔ متن تغییر اندازه می‌دهد و نتیجه در «autofit_type.pptx» ذخیره می‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ تغییرات عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/php-java/manage-paragraph/) مراجعه کنید. شمارش خطوط به تنهایی نشان نمی‌دهد که متن از محفظهٔ خود عبور کرده است یا نه.

## **تنظیم نقطهٔ لنگر فریم‌های متنی**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setAnchoringType) تعیین می‌کند متن به صورت عمودی داخل شکل در چه مقاومی (بالا، وسط یا پایین) قرار گیرد. مثال زیر متن را به پایین‌ترین شکل اولین شکل لنگر می‌کند و نتیجه در «text_anchor.pptx» ذخیره می‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم تب‌گذاری متن**

از [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) و [ParagraphFormat::getTabs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#getTabs) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ پیش‌فرض تب را به ۱۰۰ پوینت تنظیم کرده و یک توقف تب چپ‌تراز در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است، تأثیر می‌گذارد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

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

## **تنظیم زبان اصلاحات**

Aspose.Slides متد [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) را ارائه می‌دهد که به شما امکان می‌دهد زبان اصلاح برای یک بخش متنی را تنظیم کنید. زبان اصلاح تعیین می‌کند چه زبانی برای بررسی املا و دستور زبان در PowerPoint استفاده شود.

مثال زیر به پروندهٔ «presentation.pptx» که در اولین اسلاید یک جعبه متن به‌عنوان اولین شکل دارد و حداقل یک پاراگراف دارد، نیاز دارد. ابتدا محتوای اولین پاراگراف را با «1。」» جایگزین می‌کند، قلم آن را به SimSun تنظیم می‌کند و زبان اصلاح چینی ساده («zh-CN») را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // شناسهٔ زبان اصلاح را تنظیم کنید.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که در هنگام بارگذاری یا ایجاد یک ارائه تولید می‌شود، استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی (US) ایجاد می‌کند، یک جعبه متن اضافه می‌کند و `en-US` را برای اولین بخش متنی آن چاپ می‌کند.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // یک شکل مستطیل جدید با متن اضافه کنید.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // زبان بخش اول را بررسی کنید.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **تنظیم سبک متنی پیش‌فرض**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDefaultTextStyle) استفاده کنید.

مثال زیر قلم بولد ۱۴ پوینت را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌نماید. متن‌ها می‌توانند این پیش‌فرض‌ها را به ارث ببرند مگر اینکه قالب‌بندی خاص‌تری آن‌ها را مغیّر کند.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // دریافت قالب پاراگراف سطح بالا.
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

در PowerPoint، اعمال افکت **All Caps** بر قلم باعث می‌شود متن روی اسلاید به‌صورت حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. وقتی چنین بخشی را با Aspose.Slides بازیابی می‌کنید، کتابخانه دقیقاً همان متنی را برمی‌گرداند که وارد شده است. برای مطابقت با متنی که نمایش داده می‌شود، [TextCapType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textcaptype/) را بررسی کنید و در صورتی که مقدار آن `All` بود، رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» که در اولین اسلاید یک جعبه متن به‌عنوان اولین شکل دارد، نیاز دارد. بخش اول اولین پاراگراف شامل «Hello, Aspose!» با افکت All Caps است، همان‌طور که در زیر نشان داده شده است.

![افکت All Caps](all_caps_effect.png)

کد زیر نحوه استخراج متنی را که اثر **All Caps** بر آن اعمال شده نشان می‌دهد:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

**چگونه متن در جدول یک اسلاید را تغییر دهم؟**

برای تغییر متن در جدول یک اسلاید، از [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/) استفاده کنید. سلول‌ها را مرور کنید و هر سلول را از طریق [Cell::getTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cell/#getTextFrame) و قالب‌بندی پاراگراف‌ها از طریق [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getParagraphFormat) به‌روزرسانی کنید.

**چگونه رنگ گرادیان را بر متن یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان بر متن، از [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#getFillFormat) استفاده کنید. [FillFormat::setFillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/#setFillType) را به [FillType::Gradient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) تنظیم کرده و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.