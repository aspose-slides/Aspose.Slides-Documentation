---
title: قالب‌بندی متن ارائه در PHP
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/php-java/text-formatting/
keywords:
- ترازبندی پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله‌گذاری کاراکترها
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی خود‌تناسبی
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java. قلم‌ها، رنگ‌ها، ترازبندی و موارد دیگر را سفارشی کنید."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java قالب‌بندی کنید. این مقاله به رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌بندی پاراگراف، رفتار خودکار‑تطبیق، لنگر متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

مگر آنکه به طور دیگری اشاره شود، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اسلاید اول آن یک جعبه متن است و اولین پاراگراف آن متنی که در زیر نشان داده شده را دارد. هر دو اندیس اسلاید و شکل به صورت صفر‑مبنای هستند. مثال‌هایی که قسمت‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌کنند، از جمله قالب‌بندی بولد به‌ارث‌برده:

![متن نمونه](sample_text.png)

برای یافتن و برجسته کردن متن به شکل تحت‌اللفظی یا تطبیق‌های عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/php-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ پیش‌زمینه پیش‌فرض یک پاراگراف استفاده کنید، یا برای قسمت‌های متنی جداگانه از [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) استفاده کنید.

مثال زیر یک پس‌زمینه خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های پس‌زمینه صریح روی قسمت‌های جداگانه نسبت به این پیش‌فرض اولویت دارند:

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

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **قسمت‌های متنی با قلم بولد** تنظیم کنید:

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
            // رنگ برجسته را برای قسمت متن تنظیم کنید.
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

## **ترازی پاراگراف‌های متن**

از [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) برای تنظیم ترازبندی پاراگراف درون یک قاب متن استفاده کنید. مقدار می‌تواند مرکز، چپ‌تراز، راست‌تراز، هم‌تراز و غیره باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ترازبندی پاراگراف را به مرکز تنظیم کنید.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف ترازبندی شده](aligned_paragraph.png)

## **تراز قلم‌ها درون یک خط**

از [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) برای تراز عمودی قسمت‌های متنی با اندازه‌های قلم متفاوت درون یک خط استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و ترازبندی را در هر یک از خطوط آن کنترل می‌کند.

مثال خودکار زیر چهار جعبه متن با برچسب روی یک اسلاید ایجاد می‌کند. هر پاراگراف همان متن را با اندازه‌های ۱۸، ۳۶ و ۵۴ پوینت دارد که تراز قلم متفاوتی دارد. از Arial استفاده می‌کند، autofit و بسته‌بندی را غیرفعال می‌کند و قاب‌های متن را به اندازه کافی بزرگ نگه می‌دارد تا یک خط جا بگیرد.

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

![مقایسه تراز پایه، بالا، مرکز و پایین قلم با اندازه‌های ترکیبی](font_alignment.png)

تراز قلم از معیارهای قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهده حروف ممکن است دقیقاً هم‌سطح نباشند. این مثال شامل یک حرف بزرگ و یک حروف پایین‌رونده است تا تفاوت بین تراز پایه و تراز پایین را نشان دهد. در دسترس بودن قلم و جایگزینی، کاراکترهای استفاده‌شده و اختلاف در اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد قاب، حاشیه‌ها، فاصله بین خطوط، بسته‌بندی و autofit نیز بر چیدمان تأثیر دارند؛ برای مقایسه حالت‌ها از همان قلم‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) است که ترازبندی افقی پاراگراف را کنترل می‌کند و از [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) که بلوک متن را به صورت عمودی داخل شکل موقعیت می‌دهد. قالب‌بندی سوپرسکریپت و ساب اسکریپت از طریق [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) قسمت‌های جداگانه را نسبت به پایه جابه‌جا می‌کند، نه اینکه تراز قلم برای خطوط پاراگراف تنظیم شود.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص داده شده به [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس ۰‑۲۵۵ است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت را به **کل پاراگراف** اعمال کنید:

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

    // رنگ پر کردن متن را به یک رنگ شفاف تنظیم کنید.
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

مثال کد زیر نشان می‌دهد چگونه شفافیت را به **قسمت‌های متنی با قلم بولد** اعمال کنید:

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
            // شفافیت قسمت متن را تنظیم کنید.
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

## **تنظیم فاصله کاراکتر برای متن**

از [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) برای گسترش یا فشرده‌سازی فاصله بین کاراکترها در یک جعبه متن استفاده کنید. مثال‌ها ۳ پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کنند.

کد PHP زیر نشان می‌دهد چگونه فاصله کاراکترها را در **کل پاراگراف** گسترش دهید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // نکته: برای فشرده‌سازی فاصله کاراکترها از مقادیر منفی استفاده کنید.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // فاصله کاراکترها را گسترش دهید.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله کاراکترها را در **قسمت‌های متنی با قلم بولد** گسترش دهید:

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
            // نکته: برای فشرده‌سازی فاصله کاراکترها از مقادیر منفی استفاده کنید.
            $portion->getPortionFormat()->setSpacing(3); // فاصله کاراکترها را گسترش دهید.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصله کاراکترها در قسمت‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ برای برخی قلم‌ها را نادیده بگیرد، حتی زمانی که قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای قسمت‌های متنی که از قلم موردنظر استفاده می‌کنند غیرفعال کنید. [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) را به مقداری بزرگ‌تر از اندازه واقعی قلم تنظیم کنید. این مثال به نصب "presentation.pptx" که اولین شکل آن یک جعبه متن است در اسلاید اول نیاز دارد. نام‌های قلم مؤثر را بررسی می‌کند، از جمله قلم‌های به‌ارث‌برگی، و آستانه ۱۰۰ پوینت را برای قسمت‌هایی که از Roboto استفاده می‌کنند تنظیم می‌کند. این کار کرنینگ را برای قسمت‌های منطبق که اندازه قلم زیر ۱۰۰ پوینت دارند غیرفعال می‌کند:

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

برای متنی که زیر آستانه قرار دارد، این تنظیم کرنینگ را جلوگیری می‌کند و می‌تواند به هم‌راستا کردن رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) یا روی قسمت‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به ۱۲ پوینت Times New Roman با قالب بولد، ایتالیک، و زیرخط نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح روی قسمت‌های جداگانه نسبت به این پیش‌فرض‌ها اولویت دارد.

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

مثال زیر ۱۳ پوینت Times New Roman، قالب ایتالیک، و زیرخط نقطه‌دار را بر روی قسمت‌هایی که قالب مؤثر آنها بولد است اعمال می‌کند:

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
            // ویژگی‌های قلم را برای قسمت متن تنظیم کنید.
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

از [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) هنگام بازآفرینی تایپوگرافی قالب یا بررسی تفاوت‌های ارتفاع کاراکتر استفاده کنید. در PowerPoint، فعال‌سازی نرمال‌سازی کاراکترهای جداگانه را به صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل مشاهده یکسانی درون قسمت متن داشته باشند. این تضمین نمی‌کند ارتفاع متن‌ها در قلم‌های مختلف برابر باشد.

خاصیت را به [NullableBool::True or False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) تنظیم کنید تا نرمال‌سازی را به‌صورت صریح فعال یا غیرفعال کنید. `NullableBool::NotDefined` تنظیم محلی را خالی می‌گذارد تا قسمت مقدار را از مثالاً، از [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) پاراگراف به ارث برد. این به معنای `False` نیست. از [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) استفاده کنید و `getNormaliseHeight` را در داده‌های قالب‌بندی مؤثر برگردانده‌شده بخوانید تا مقدار بولی نهایی به دست آید.

مثال خودکار زیر به نصب **Arial** نیاز دارد. دو بلوک متن ایجاد می‌کند که شامل حروف بزرگ، حروف کوچک، حروف پایین‌رونده و نویسه‌های لهجه‌دار یکسان با اندازه ۵۴ پوینت هستند. هر دو پاراگراف به‌صورت پیش‌فرض نرمال‌سازی را فعال می‌کنند. قسمت بالایی به‌صراحت آن را غیرفعال می‌کند؛ قسمت پایین آن را به ارث می‌برد. اندازه‌های قاب، حاشیه‌ها و فاصله پاراگراف یکسان هستند، با بسته‌بندی و autofit غیرفعال برای حفظ سازگاری مقایسه. مثال `False: false` و `NotDefined: true` را چاپ می‌کند، سپس «text_height_normalization.pptx» را ذخیره می‌نماید.

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

مقایسه زیر از ارائه ذخیره‌شده استخراج شد. ردیف بالایی نرمال‌سازی غیرفعال (`False`) دارد؛ ردیف پایین تنظیم فعال شده را به ارث می‌برد (`NotDefined` → `True`). برای بازتولید این ظاهر Arial را نصب نگه دارید.

![متن ۵۴ پوینت Arial با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی به‌ارث‌برده فعال در پایین](text_height_normalization.png)

نرمال‌سازی ارتفاع کاراکترها را بدون تغییر مقدار [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) اختصاص‑یافته که اندازه قلم را به پوینت مشخص می‌کند، تغییر می‌دهد. پاراگراف [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) فاصله خط را کنترل می‌کند، در حالی که قاب‑متن [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) نحوه تنظیم متن یا مخزن آن را برای پر شدن تعیین می‌کند. این تنظیمات مقاصد متفاوتی دارند و می‌توانند بر چیدمان کلی تأثیر بگذارند. برای اطلاعات بیشتر درباره قالب‌بندی پاراگراف و ارث‌بری، به [Manage Paragraph](/slides/fa/php-java/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف خط‌کشی**

از [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) روی یک قسمت متن استفاده کنید تا اصلاحات، عبارات لغو‌شده یا قیمت‌های قبلی را بدون حذف متن اصلی نشان دهید. آن را به [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) تنظیم کنید تا یک یا دو خط از روی متن بکشید.

برای حذف خط‌کشی، [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None) را پاس می‌دهید. این به‌صورت صریح اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی پیرامون خط‌کشی را مشخص کرده باشد. در مقابل، [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) تنظیم محلی را تعریف‌نشده می‌گذارد و اجازه می‌دهد قسمت قالب‌بندی را از مثالاً از پاراگراف به ارث ببرد. این تضمین نمی‌کند خط‌کشی حذف شده باشد. برای خواندن قالب‌بندی حاصل، از جمله مقادیر ارث‌بری، از [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) استفاده کنید.

مثال خودکار زیر سه مقایسه قیمت ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت جاری دارد، بنابراین فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول خط‌کشی را اعمال می‌کند و سپس حذف می‌کند؛ سایر ردیف‌ها خط‌کشی تک و دو خطی را حفظ می‌کنند. تغییر این تنظیم متن و قالب‌بندی‌های دیگر آن را حفظ می‌کند، از جمله قیمت قبلی بولد.

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

    // اعمال خط‌کشی، سپس به طور صریح آن را از اولین قیمت قبلی حذف کنید.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه، از بالا به پایین: بدون خط‌کشی، خط‌کشی تک‌خطی و خط‌کشی دوخطی.

![قیمت‌های قبلی بدون خط‌کشی، با خط‌کشی تک‌خطی و با خط‌کشی دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) برای تنظیم جهت پیش‌تعریف‌شده متن درون یک شکل استفاده کنید.

مثال کد زیر جهت متن در شکل را به [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه ضد ساعت‌گرد** می‌چرخاند:

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

## **نمایش اعداد در کنار هم در متن عمودی**

برای نگه‌ داشتن یک عدد دو رقمی در یک برچسب ژاپنی عمودی، هر دو رقم را در یک قسمت متن قرار داده و [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) را روی آن قسمت فراخوانی کنید. مثال از [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) و ۴۰ پوینت MS Gothic برای هر دو برچسب استفاده می‌کند. فقط مقدار [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) که به قسمت عددی پاس داده می‌شود متفاوت است.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

در PowerPoint، برچسب چپ (`True`) اعداد را به صورت عمودی و کنار هم بین 和 و 年 نشان می‌دهد. در برچسب راست (`False`) جفت اعداد ۹۰ درجه ساعت‌گرد چرخانده می‌شود. کاراکترهای ژاپنی اطراف در هر دو برچسب به وضعیت عمودی خود باقی می‌مانند.

![مقایسه برچسب‌های تاریخ عمودی در PowerPoint با اعداد عمودی در سمت چپ و اعداد چرخانده در سمت راست](vertical_date.png)

## **تنظیم چرخش سفارشی برای قاب‌های متن**

از [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) برای تنظیم زاویه چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) استفاده کنید.

مثال کد زیر قاب متن را به اندازه ۳ درجه ساعت‌گرد درون شکل می‌چرخاند:

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

## **تنظیم فاصله خط پاراگراف‌ها**

Aspose.Slides ارائه می‌دهد [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) برای کنترل فاصله پاراگراف. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* از یک مقدار مثبت برای تعیین فاصله خط به عنوان درصدی از ارتفاع خط استفاده کنید.
* از یک مقدار منفی برای تعیین فاصله خط به پوینت استفاده کنید.

مثال زیر فاصله داخل اولین پاراگراف را به ۲۰۰٪ از ارتفاع خط (فاصله‌گذاری دوبرابر) تنظیم می‌کند:

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

![فاصله خط داخل پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متن باریک و ارائه‌هایی که متن لاتین و شرق‌آسیایی را ترکیب می‌کنند مفید است. روش‌های زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) هستند، بنابراین بر یک پاراگراف کامل اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) قوانین شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند مکان بسته شدن متن شرق‌آسیایی و علامت‌نگاری‌های مجاور را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) قوانین شکست خط شرق‌آسیایی را کنترل می‌کند، شامل محدودیت‌های مربوط به کاراکترهای ابتدای و انتهای خط.

این قوانین جایگزین [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) که بسته‌بندی خودکار را درون یک قاب متن فعال می‌کند، نمی‌شوند. آنها بر چیدمان هنگام بسته‌بندی تأثیر می‌گذارند؛ کاراکترهای خط‌شکنی را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید را درون پاراگراف، بدون در نظر گرفتن عرض موجود، ایجاد می‌کند.

مثال خودکار زیر یک بلوک متن باریک شامل متن چینی و لاتین ایجاد می‌کند. هر دو گزینه شکست خط را به‌صورت صریح تنظیم می‌کند و «line_breaking.pptx» را ذخیره می‌نماید. برای آزمایش هر یک از قواعد، مقدار مربوطه را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. مثال از Arial ۲۴ پوینت و SimSun با عرض قاب ۱۶۰ پوینت و حاشیه افقی صفر استفاده می‌کند. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) با [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازه متن و ابعاد قاب ثابت بمانند.

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

## **کنترل علائم نگارشی معلق**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) به علائم نگارشی مجاز اجازه می‌دهد که از لبه راست خط متن فراتر بروند به‌جای این‌که در خط بعدی قرار گیرند. این تنظیم بر کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خودکار زیر علائم نگارشی معلق را در یک قاب متن با عرض ۱۰۰ پوینت فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌نماید. با Arial ۲۴ پوینت و حاشیه افقی صفر، نقطه نهایی پس از «sentence» می‌ماند و فراتر از لبه راست متن گسترش می‌یابد. برای مقایسه، ویژگی را به [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه در یک خط جداگانه قرار می‌گیرد. بسته‌بندی فعال و autofit غیرفعال است تا عرض در دسترس ثابت بماند.

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

هر علامت نگارشی نمی‌تواند معلق باشد. [شرایط قلم و چیدمان توضیح داده‌شده در بالا](#control-line-breaking) نیز برای این مقایسه اعمال می‌شوند: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل مشاهده را حذف کند.

## **تنظیم نوع Autofit برای قاب‌های متن**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند متن چگونه رفتار کند وقتی از مرزهای مخزن خود فراتر رود. از آن برای کنترل اینکه متن کوچکتر شود، سرریز شود یا به‌صورت خودکار شکل را تغییر اندازه دهد استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود تغییر اندازه دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند.

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

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهده اینکه چگونه عرض متن یا شکل نتیجه را تغییر می‌دهد، به [Count Rendered Lines](/slides/fa/php-java/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشان‌دهنده سرریز شدن متن از مخزن آن نیست.

## **تنظیم لنگر قاب‌های متن**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) تعیین می‌کند متن به‌صورت عمودی داخل یک شکل چگونه موقعیت یابد، به عنوان مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌دهد و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

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

## **تنظیم تب‌بندی متن**

از [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) و [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصله پیش‌فرض تب را به ۱۰۰ پوینت تنظیم می‌کند و یک توقف تب چپ‌تراز در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب باشد تأثیر می‌گذارد.

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

## **تنظیم زبان تصحیح**

Aspose.Slides ارائه می‌دهد [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)، که به شما امکان تنظیم زبان تصحیح برای یک قسمت متن را می‌دهد. زبان تصحیح زبانی را که برای بررسی املایی و گرامری در PowerPoint استفاده می‌شود تعیین می‌کند.

مثال زیر به «presentation.pptx» که اولین شکل آن یک جعبه متن در اسلاید اول است و حداقل یک پاراگراف دارد، نیاز دارد. محتوای اولین پاراگراف را با «1。」» جایگزین می‌کند، SimSun را به عنوان قلم آن تنظیم می‌کند و زبان تصحیح چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه را در «proofing_language.pptx» ذخیره می‌کند:

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

    // شناسه زبان تصحیح را تنظیم کنید.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **کپی متادیتای زبان**

هنگام کپی متن چندزبانه از یک قالب، هر دو [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) و [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) را حفظ کنید. مثال خودکار زیر یک قسمت منبع با زبان انگلیسی ایالات متحده و زبان جایگزین فرانسوی ایجاد می‌کند و متن و شناسه‌ها را به یک قسمت در ارائه جدید کپی می‌نماید.

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

برای آزمایش منبع بدون زبان جایگزین، اختصاص "fr-FR" را حذف کنید. شناسه جایگزین سپس `null` می‌شود و همان عبارت کپی عدم حضور آن را حفظ می‌کند بدون اضافه کردن مقدار پیش‌فرض، حتی اگر مقصد قبلاً زبان جایگزین داشته باشد.

این شناسه‌ها به‌صورت متادیتای زبان ذخیره می‌شوند. حفظ آن‌ها تعیین نمی‌کند کدام دیکشنری PowerPoint برای بررسی املایی یا گرامری انتخاب می‌کند.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی ایالات متحده ایجاد می‌کند، یک جعبه متن اضافه می‌کند و `en-US` را برای اولین قسمت متن آن چاپ می‌کند.

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

    // زبان اولین قسمت را بررسی کنید.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle) استفاده کنید.

مثال زیر قلم بولد ۱۴ پوینت را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالایی در یک ارائه جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌نماید. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر اینکه قالب‌بندی خاص‌تری آنها را نادیده بگیرد.

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

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثر قلم **All Caps** باعث می‌شود متن بر روی اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر ابتدا با حروف کوچک وارد شده باشد. وقتی چنین قسمتی از متن را با Aspose.Slides بازیابی کنید، کتابخانه متن را دقیقاً همان‌گونه که وارد شده است برمی‌گرداند. برای تطبیق با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) را بررسی کنید و وقتی مقدار `All` است، رشته بازگشتی را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» که اولین شکل آن یک جعبه متن در اسلاید اول است، نیاز دارد. اولین قسمت اولین پاراگراف آن شامل «Hello, Aspose!» با اثر All Caps است، همان‌طور که در زیر نشان داده شده.

![اثر All Caps](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

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

## **پرسش‌های متداول**

**چگونه متن در جدول یک اسلاید را اصلاح کنم؟**

برای اصلاح متن در جدولی روی اسلاید، از [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) استفاده کنید. در سلول‌ها پیمایش کنید و هر سلول را از طریق [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) و قالب‌بندی پاراگراف از طریق [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) به‌روزرسانی کنید.

**چگونه یک رنگ گرادیان به متن در اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) استفاده کنید. [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) را به [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) تنظیم کنید و نقاط توقف گرادیان، جهت و شفافیت را پیکربندی کنید.