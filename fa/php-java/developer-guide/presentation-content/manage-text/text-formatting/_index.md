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
- فاصله کاراکتر
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی خودکار اندازه
- لنگر قاب متن
- تب‌گذاری متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قالب‌بندی و سبک دادن به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java. قلم‌ها، رنگ‌ها، تراز و موارد بیشتر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java فرمت‌بندی کنید. این مقاله شامل رنگ‌های پس‌زمینه، شفافیت، فاصله بین کاراکترها، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار خودکار اندازه‌گیری، تثبیت متن، توقف‌های تب و تنظیمات زبان می‌شود.

در مثال‌های زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که حاوی یک جعبه متن در اسلاید اول با متن زیر است:

![متن نمونه](sample_text.png)

برای یافتن و برجسته کردن متن دقیق یا مطابقت‌های عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/php-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا برای بخش‌های متنی جداگانه از [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#getHighlightColor) استفاده کنید.

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **تمام پاراگراف** تنظیم شود:

```php
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

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **بخش‌های متنی با فونت بولد** تنظیم شود:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
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

## **تراز کردن پاراگراف‌های متن**

از [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setAlignment) برای تنظیم تراز پاراگراف داخل یک فریم متن استفاده کنید. مقدار می‌تواند وسط، چپ، راست، توجیه‌شده و ... باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // تنظیم تراز پاراگراف به مرکز.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص داده شده به [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#getFillFormat) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار کانال آلفای ARGB در مقیاس 0 تا 255 است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت به **تمام پاراگراف** اعمال شود:

```php
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

مثال کد زیر نشان می‌دهد چگونه شفافیت به **بخش‌های متنی با فونت بولد** اعمال شود:

```php
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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
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

## **تنظیم فاصله کاراکترها برای متن**

از [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setSpacing) برای افزایش یا کاهش فاصله بین کاراکترها در یک جعبه متن استفاده کنید.

کد PHP زیر نشان می‌دهد چگونه فاصله کاراکترها در **تمام پاراگراف** گسترش یابد:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // فاصله کاراکتر را گسترش دهید.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله کاراکترها در **بخش‌های متنی با فونت بولد** گسترش یابد:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
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

### **غیرفعال‌سازی کرنینگ برای فونت‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است اندکی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ را برای برخی فونت‌ها نادیده می‌گیرد، حتی اگر فونت حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندری به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از فونت مورد تأثیر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) را به عددی به‌طور قابل توجهی بزرگ‌تر از اندازه واقعی فونت تنظیم کنید:

```php
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

این تنظیم از اعمال کرنینگ به بخش‌های متنی مطابق جلوگیری می‌کند و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای فونت‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) یا در بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای **تمام پاراگراف** تنظیم می‌کند: اندازه قلم، بولد، ایتالیک، زیرخط نقطه‌دار و قلم Times New Roman را برای تمام بخش‌های پاراگراف اعمال می‌کند.

```php
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

کد زیر ویژگی‌های مشابه را برای **بخش‌های متنی با فونت بولد** اعمال می‌کند:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
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

از [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setTextVerticalType) برای تنظیم جهت‌گیری متنی پیش‌تعریف‌شده درون یک شکل استفاده کنید.

مثال کد زیر جهت‌گیری متن را در شکل به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه خلاف جهت ساعت** می‌چرخاند:

```php
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

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setRotationAngle) برای تنظیم زاویه چرخش سفارشی یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) استفاده کنید.

مثال کد زیر فریم متن را داخل شکل به میزان ۳ درجه ساعت‌گرد می‌چرخاند:

```php
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

Aspose.Slides متدهای [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setSpaceWithin) را برای کنترل فاصله پاراگراف‌ها ارائه می‌دهد. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله خط به‌صورت درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله خط برحسب نقاط (points) استفاده کنید.

مثال کد زیر نشان می‌دهد چگونه فاصله خط را درون پاراگراف مشخص کنید:

```php
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

![فاصله خط درون پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متن**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند که متن هنگام عبور از مرزهای محفظه خود چگونه رفتار کند. از آن برای کنترل این که آیا متن کوچک شود، اضافه شود یا شکل را به‌صورت خودکار تغییر اندازه دهد، استفاده کنید.

```php
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

## **تنظیم لنگر فریم‌های متن**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setAnchoringType) تعیین می‌کند که متن به صورت عمودی داخل یک شکل چگونه موقعیت‌یابی شود، مثلاً در بالا، وسط یا پایین.

```php
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

## **تنظیم تب متن**

از [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) و [ParagraphFormat::getTabs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#getTabs) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید.

```php
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

## **تنظیم زبان اصلاح**

Aspose.Slides متد [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) را ارائه می‌دهد که به شما امکان تنظیم زبان اصلاح برای یک بخش متنی را می‌دهد. زبان اصلاح تعیین می‌کند که برای بررسی املا و گرامر در PowerPoint از چه زبانی استفاده شود.

مثال کد زیر نشان می‌دهد چگونه زبان اصلاح را برای یک بخش متنی تنظیم کنید:

```php
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

    // شناسه زبان اصلاح را تنظیم کنید.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که در هنگام بارگذاری یا ایجاد یک ارائه ایجاد می‌شود، استفاده کنید.

```php
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

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getDefaultTextStyle) استفاده کنید.

مثال کد زیر نشان می‌دهد چگونه یک قلم بولد پیش‌فرض با اندازه ۱۴ pt برای تمام متن‌ها در تمام اسلایدهای یک ارائه جدید تنظیم شود.

```php
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

در PowerPoint، اعمال افکت **All Caps** باعث می‌شود متن حتی اگر به‌صورت حروف کوچک وارد شده باشد، در اسلاید به شکل حروف بزرگ نشان داده شود. زمانی که چنین بخش متنی را با Aspose.Slides دریافت می‌کنید، کتابخانه متن را دقیقاً همان‌گونه که وارد شده است برمی‌گرداند. برای مطابقت با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textcaptype/) را بررسی کنید و وقتی مقدار `All` است، رشته برگردانده‌شده را به حروف بزرگ تبدیل کنید.

فرض کنید یک جعبه متن زیر در اسلاید اول فایل sample2.pptx داریم.

![افکت تمام حروف بزرگ](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن با افکت **All Caps** اعمال‌شده استخراج شود:

```php
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

**چگونه متن در یک جدول در اسلاید را اصلاح کنیم؟**

برای اصلاح متن در یک جدول در اسلاید، از [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/) استفاده کنید. سلول‌ها را پیاپی پیمایش کنید و هر سلول را از طریق [Cell::getTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cell/#getTextFrame) و قالب‌بندی پاراگراف را از طریق [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getParagraphFormat) به‌روزرسانی کنید.

**چگونه رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#getFillFormat) استفاده کنید. [FillFormat::setFillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/#setFillType) را به [FillType::Gradient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.