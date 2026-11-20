---
title: قالب‌بندی متن ارائه در PHP
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/php-java/text-formatting/
keywords:
- هم‌راستایی پاراگراف
- استایل متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکترها
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی Autofit
- لنگر قاب متن
- تب بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP via Java. قلم‌ها، رنگ‌ها، هم‌راستایی و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP via Java قالب‌بندی کنید. این مقاله رنگ‌های پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار خودتنظیم، نگاشت متن، توقف‌های تب و تنظیمات زبان را پوشش می‌دهد.

Unless stated otherwise, the examples use [sample.pptx](sample.pptx). اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن حاوی متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل از صفر شروع می‌شوند. مثال‌هایی که بخش‌های ضخیم را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌کنند، از جمله قالب‌بندی ضخیم ارث‌بری شده:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن به‌صورت دقیق یا تطابق‌های عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/php-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ برجسته پیش‌فرض برای یک پاراگراف استفاده کنید، یا از [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) برای بخش‌های متن جداگانه استفاده کنید.

مثال زیر برجستهٔ خاکستری روشن را به عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجستهٔ صریح بر بخش‌های جداگانه اولویت دارند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // رنگ برجسته را برای کل پاراگراف تنظیم کنید.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **قسمت‌های متنی با قلم ضخیم** تنظیم کنید:

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

![قسمت‌های متن خاکستری](gray_text_portions.png)

## **هم‌راستای کردن پاراگراف‌های متن**

از [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) برای تنظیم هم‌راستایی پاراگراف داخل یک چارچوب متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

مثال زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** هم‌راستای کنید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // هم‌راستایی پاراگراف را به مرکز تنظیم کنید.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف هم‌راستای شده](aligned_paragraph.png)

## **هم‌راستای کردن قلم‌ها درون یک خط**

از [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) برای هم‌راستایی عمودی بخش‌های متنی با اندازه‌های قلم متفاوت درون یک خط استفاده کنید. این تنظیم برای تمام پاراگراف اعمال می‌شود و هم‌راستایی هر خط را کنترل می‌کند.

مثال زیر چهار جعبه متن برچسب‌دار روی یک اسلاید ایجاد می‌کند. هر پاراگراف متنی با همان محتوا در اندازه‌های 18 ، 36 و 54 پوینت دارد و هم‌راستایی قلم متفاوت است. از Arial استفاده می‌کند، autofit و wrapping را غیرفعال می‌سازد و چارچوب‌های متن را به اندازه‌ای بزرگ می‌گذارد که فقط یک خط جا گیرد.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![مقایسه منطبق‌سازی قلم در خط پایه، بالا، مرکز و پایین با اندازه‌های مختلف قلم](font_alignment.png)

هم‌راستایی قلم از متریک‌های قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهدهٔ حروف به‌طور دقیق هم‌سطح نمی‌شوند. مثال هم حرف بزرگ و هم حرف پایین‌دسته (descender) را شامل می‌شود تا تفاوت بین پایه و پایین‌دسته را نشان دهد. دسترس‌پذیری قلم و جایگزینی، کاراکترهای استفاده‌شده و اختلاف در اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد چارچوب، حاشیه‌ها، فاصله خطوط، wrapping و autofit نیز بر چیدمان تأثیر دارند؛ برای مقایسهٔ حالت‌ها از همان قلم‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) است که هم‌راستایی افقی پاراگراف را کنترل می‌کند، و از [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) که بلوک متن را عمودی درون شکل موقعیت می‌دهد. قالب‌بندی سوپرسکریت و ساب‌اسکرِیت از طریق [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) بخش‌های جداگانه را نسبت به خط پایه جابجا می‌کند، نه این‌که هم‌راستایی قلم برای خطوط پاراگراف تنظیم شود.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگ اختصاص داده‌شده به [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را برای **کل پاراگراف** اعمال کنید:

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

کد زیر نشان می‌دهد چگونه شفافیت را برای **قسمت‌های متنی با قلم ضخیم** اعمال کنید:

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

![قسمت‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله حروف برای متن**

از [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) برای گسترش یا فشردن فاصله بین حروف در یک جعبه متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کند؛ مقادیر منفی متن را فشرده می‌کند.

کد PHP زیر نشان می‌دهد چگونه فاصله حروف را در **کل پاراگراف** گسترش دهید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // توجه: برای فشرده‌سازی فاصلهٔ حروف از مقادیر منفی استفاده کنید.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // فاصلهٔ حروف را گسترش دهید.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصله حروف در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله حروف را در **قسمت‌های متنی با قلم ضخیم** گسترش دهید:

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
            // توجه: برای فشرده‌سازی فاصلهٔ حروف از مقادیر منفی استفاده کنید.
            $portion->getPortionFormat()->setSpacing(3); // فاصلهٔ حروف را گسترش دهید.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصله حروف در قسمت‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متن رندر شده توسط Aspose.Slides ممکن است کمی تنگ‌تر از متن مشابه در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ برخی قلم‌ها را نادیده می‌گیرد، حتی اگر قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی به PowerPoint، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم تحت تأثیر هستند غیرفعال کنید. مقدار [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) را بزرگ‌تر از اندازهٔ واقعی قلم تنظیم کنید. این مثال به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. نام‌های قلم مؤثر (از جمله قلم‌های ارث‌بری‌شده) را بررسی می‌کند و آستانهٔ 100 پوینت برای بخش‌هایی که از Roboto استفاده می‌کنند تنظیم می‌کند؛ این باعث غیرفعال شدن کرنینگ برای بخش‌های مطابق با اندازهٔ قلم زیر 100 پوینت می‌شود:

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

برای متن‌های مطابق با آستانه، این تنظیم کرنینگ را جلوگیری می‌کند و می‌تواند به هم‌راستایی خروجی Aspose.Slides با نمایش PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند از سطح پاراگراف از طریق [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) یا بر روی بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به Times New Roman 12 پوینت با قالب‌بندی ضخیم، ایتالیک و زیرخط نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح بر بخش‌های جداگانه بر پیش‌فرض‌ها ارجیح دارد:

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

مثال زیر Times New Roman 13 پوینت، قالب‌بندی ایتالیک و زیرخط نقطه‌ای را بر بخش‌هایی که قالب‌بندی مؤثرشان ضخیم است اعمال می‌کند:

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
            // ویژگی‌های قلم را برای بخش متن تنظیم کنید.
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

![ویژگی‌های قلم برای قسمت‌های متن](font_properties_for_text_portions.png)

## **کنترل نرمال‌سازی ارتفاع متن**

از [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) هنگام بازتولید تایپوگرافی قالب یا بررسی تفاوت‌های ارتفاع حروف استفاده کنید. در PowerPoint، فعال‌سازی نرمال‌سازی حروف را به‌صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل مشاهدهٔ یکنواختی داشته باشند؛ این تضمین نمی‌کند که ارتفاع متن در قلم‌های مختلف برابر باشد.

مقدار ویژگی را به [NullableBool::True یا False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) تنظیم کنید تا صریحاً نرمال‌سازی را فعال یا غیرفعال کنید. `NullableBool::NotDefined` تنظیم محلی را خالی می‌گذارد تا بخش مقدار را از مثالاً [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) پاراگراف به ارث ببرد. این به معنی `False` نیست. از [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) استفاده کنید و `getNormaliseHeight` را در داده‌های قالب‌بندی مؤثر خوانده تا مقدار Boolean حل شده را به دست آورید.

مثال زیر که به **Arial** نیاز دارد، دو بلوک متن شامل حروف بزرگ، حروف کوچک، حروف پایین‌دسته و کاراکترهای لهجه‌دار در 54 پوینت ایجاد می‌کند. هر دو پاراگراف به‌صورت پیش‌فرض نرمال‌سازی را فعال دارند. بخش بالا صراحتاً آن را غیرفعال می‌کند؛ بخش پایین آن را ارث می‌برد. اندازه‌های چارچوب، حاشیه‌ها و فاصله پاراگراف یکسان هستند و wrapping و autofit غیرفعال‌اند تا مقایسه ثابت بماند. مثال `False: false` و `NotDefined: true` را چاپ می‌کند و «text_height_normalization.pptx» را ذخیره می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مقایسهٔ زیر از ارائهٔ ذخیره‌شده استخراج شده است. ردیف بالا نرمال‌سازی غیرفعال (`False`) و ردیف پایین ارث‌بری فعال (`NotDefined` → `True`) دارد. برای بازتولید این ظاهر، Arial باید نصب باشد.

![متن Arial با اندازهٔ 54 پوینت با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی ارث‌بری فعال در پایین](text_height_normalization.png)

نرمال‌سازی ارتفاع حروف را بدون تغییر مقدار [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) که اندازهٔ قلم را در پوینت مشخص می‌کند، تغییر می‌دهد. [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) فاصله خطوط را کنترل می‌کند، در حالی که [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) نحوهٔ تنظیم متن یا محفظهٔ آن را برای جا شدن تعیین می‌کند. این تنظیمات اهداف متفاوتی دارند و می‌توانند به‌طور مستقل بر کل چیدمان تأثیر بگذارند. برای اطلاعات بیشتر دربارهٔ قالب‌بندی پاراگراف و ارث‌بری، به [مدیریت پاراگراف](/slides/fa/php-java/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف خط‌خورده**

از [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) بر یک بخش متنی برای نمایش اصلاحات، عبارات لغو شده یا قیمت‌های قبلی بدون حذف متن اصلی استفاده کنید. برای یک یا دو خط بر متن، آن را به [TextStrikethroughType::Single یا Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) تنظیم کنید.

برای حذف خط‌خورده، [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None) را عبور دهید. این به صراحت اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی پیرامون خط‌خورده را مشخص کند. برعکس، [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) تنظیم محلی را تعریف‌نشده می‌گذارد تا بخش قالب‌بندی را از مثالاً پاراگراف به ارث ببرد. این تضمین نمی‌کند که خط‌خورده حذف شود. برای خواندن قالب‌بندی نهایی، از [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) استفاده کنید تا مقادیر ارث‌بری‌شده هم دربرگیرند.

مثال زیر سه مقایسه قیمت ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت فعلی دارد؛ بنابراین فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول خط‌خورده را اعمال و سپس حذف می‌کند؛ سایر ردیف‌ها خط‌خوردهٔ تک و دو خطی را حفظ می‌کنند. تغییر این تنظیم متن و قالب‌بندی‌های دیگر، از جمله ضخامت، را حفظ می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // خط‌خورده را اعمال کنید، سپس به‌صورت صریح آن را از اولین قیمت قبلی حذف نمایید.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه، از بالا به پایین: بدون خط‌خورده، خط‌خوردهٔ تک و خط‌خوردهٔ دوخطی.

![قیمت‌های قبلی بدون خط‌خورده، با خط‌خوردهٔ تک و با خط‌خوردهٔ دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) برای تنظیم یک جهت پیش‌تعریف‌شدهٔ متن درون یک شکل استفاده کنید.

مثال زیر جهت متن در شکل را به [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/) تنظیم می‌کند؛ که متن را **90 درجه در جهت ساعت‌گرد** می‌چرخاند:

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

## **تنظیم چرخش سفارشی برای چارچوب‌های متن**

از [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) برای تنظیم زاویهٔ چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) استفاده کنید.

کد زیر چارچوب متن را داخل شکل 3 درجه ساعت‌گرد می‌چرخاند:

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

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides توابع [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) را برای کنترل فاصله پاراگراف فراهم می‌کند. این ویژگی‌ها به صورت زیر استفاده می‌شوند:

* برای مشخص کردن فاصله خطوط به‌عنوان درصدی از ارتفاع خط، از مقدار مثبت استفاده کنید.
* برای مشخص کردن فاصله خطوط به پوینت، از مقدار منفی استفاده کنید.

مثال زیر فاصله درون اولین پاراگراف را به 200٪ از ارتفاع خط (فاصلهٔ دو برابر) تنظیم می‌کند:

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

![فاصله خطوط درون پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و آسیای شرقی را ترکیب می‌کنند مفید است. متدهای زیر به کلاس [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) تعلق دارند، بنابراین بر تمام پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) قوانین شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل شکست متن و علائم نگارشی آسیای شرقی را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) قوانین شکست خط آسیای شرقی را کنترل می‌کند، از جمله محدودیت‌های کاراکترها در ابتدا یا انتهای خط.

این قوانین جایگزین [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) نیستند که بسته شدن خودکار درون چارچوب متن را فعال می‌کند. آن‌ها بر چیدمان وقتی wrapping رخ می‌دهد تأثیر می‌گذارند؛ کاراکترهای شکست خط را وارد نمی‌کنند. شکست خط صریح یک خط جدید درون پاراگراف ایجاد می‌کند، صرف نظر از عرض موجود.

مثال زیر یک بلوک متن باریک حاوی متن چینی و لاتین ایجاد می‌کند. هر دو گزینهٔ شکست خط صریحاً تنظیم می‌شود و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر قانون، مقدار مربوطه را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. مثال از Arial 24 پوینت و SimSun با عرض چارچوب 160 پوینت و حاشیهٔ افقی صفر استفاده می‌کند. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) با [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد چارچوب ثابت بمانند.

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

## **کنترل علامت‌گذاری معلق**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) به علائم نگارشی مجاز اجازه می‌دهد تا فراتر از لبهٔ راست خط متن امتداد یابند به‌جای آن‌که در خط بعدی جای بگیرند. این ویژگی برای تمام پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال زیر علامت‌گذاری معلق را در یک چارچوب متن با عرض 100 پوینت فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌نماید. با Arial 24 پوینت و حاشیهٔ افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و از لبهٔ راست متن فراتر می‌رود. برای مقایسه مقدار را به [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطهٔ نهایی در یک خط جداگانه قرار می‌گیرد. wrapping فعال و autofit غیرفعال شده‌اند تا عرض در دسترس ثابت بماند.

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

همهٔ علائم نگارشی قابلیت معلق شدن ندارند. شرایط قلم و چیدمان توضیح داده‌شده در [کنترل شکست خط](#control-line-breaking) نیز در این مقایسه صدق می‌کند: تغییر قلم، عرض در دسترس، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل مشاهده را از بین ببرد.

## **تنظیم نوع خودتنظیم برای چارچوب‌های متن**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند متن هنگام تجاوز از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، خارج شود یا شکل به‌طور خودکار اندازه‌اش را تغییر دهد استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود اندازه‌اش را تغییر دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند.

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

برای شمارش خطوط پس از بسته شدن خودکار و مشاهدهٔ چگونگی تغییر عرض متن یا شکل، به [شمارش خطوط رندر شده](/slides/fa/php-java/manage-paragraph/) مراجعه کنید. شمارش خطوط به تنهایی نشان‌دهندهٔ خروجی متن از محفظه نیست.

## **تنظیم نقطه لنگر چارچوب‌های متن**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) تعریف می‌کند متن چطور به‌صورت عمودی داخل یک شکل موقعیت یابد، به‌عنوان مثال در بالا، میانه یا پایین. مثال زیر متن را به پایین اولین شکل لنگرش می‌دهد و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

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

## **تنظیم تب‌های متن**

از [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) و [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ تب پیش‌فرض را به 100 پوینت تنظیم می‌کند و یک توقف تب چپ‌الاین را در 30 پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است تأثیر می‌گذارد.

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

## **تنظیم زبان تصحیح املایی**

Aspose.Slides متد [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) را فراهم می‌کند که به شما امکان می‌دهد زبان تصحیح املایی برای یک بخش متنی را تنظیم کنید. زبان تصحیح املایی تعیین می‌کند PowerPoint از کدام زبان برای بررسی املایی و گرامری استفاده می‌کند.

مثال زیر به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید و حداقل یک پاراگراف نیاز دارد. محتوای اولین پاراگراف را با «1。」» جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌کند و زبان تصحیح املایی چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

    // تنظیم شناسهٔ زبان تصحیح املایی.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **کپی متادیتای زبان**

هنگام کپی متن چندزبانه از یک قالب، هر دو [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) و [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) را حفظ کنید. مثال زیر یک بخش منبع با زبان انگلیسی آمریکایی به‌عنوان زبان اصلی و فرانسوی به‌عنوان زبان جایگزین ایجاد می‌کند و متن و شناسه‌ها را به یک بخش در یک ارائهٔ جدید کپی می‌کند.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // اگر منبع زبان جایگزینی نداشته باشد، null مقدار مقصد را پاک می‌کند.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای آزمایش منبع بدون زبان جایگزین، اختصاص `"fr-FR"` را حذف کنید. شناسهٔ جایگزین سپس `null` خواهد بود و همان عبارت کپی عدم وجود را حفظ می‌کند بدون افزودن مقدار پیش‌فرض، حتی اگر مقصد پیش‌تر زبان جایگزین داشته باشد.

این شناسه‌ها متادیتای زبان هستند. حفظ آن‌ها تعیین‌کنندهٔ این نیست که PowerPoint از کدام فرهنگ‌نامه برای بررسی املایی یا گرامری استفاده می‌کند.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که در حین بارگذاری یا ایجاد یک ارائه ایجاد می‌شود استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متنی انگلیسی آمریکایی ایجاد می‌کند، یک جعبه متن اضافه می‌کند و `en-US` را برای اولین بخش متنی‌اش چاپ می‌کند.

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

    // زبان اولین بخش را بررسی کنید.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle) استفاده کنید.

مثال زیر یک قلم 14 پوینت ضخیم را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌نماید. متن می‌تواند این پیش‌فرض‌ها را ارث‌بری کند مگر اینکه قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند.

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

## **استخراج متن با افکت تمام حروف بزرگ**

در PowerPoint، اعمال افکت **All Caps** باعث می‌شود متن روی اسلاید به‌صورت حروف بزرگ نمایش داده شود حتی اگر ابتدا با حروف کوچک وارد شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides دریافت می‌کنید، کتابخانه متن دقیقاً همان‌طور که وارد شده برمی‌گرداند. برای تطبیق با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) را بررسی کنید و زمانی که مقدار `All` باشد، رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. اولین پاراگراف اولین بخش آن شامل «Hello, Aspose!» با افکت All Caps است، همان‌طور که در زیر نشان داده شده است.

![افکت تمام حروف بزرگ](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن را با افکت **All Caps** استخراج کنید:

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

## **FAQ**

**چگونه متن در یک جدول در اسلاید را ویرایش کنم؟**

برای ویرایش متن در یک جدول در اسلاید، از [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) استفاده کنید. در سلول‌ها تکرار کنید و هر سلول را از طریق [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) به‌روزرسانی کنید و قالب‌بندی پاراگراف را از طریق [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) تغییر دهید.

**چگونه یک رنگ گرادیان به متن در یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) استفاده کنید. [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) را به [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.