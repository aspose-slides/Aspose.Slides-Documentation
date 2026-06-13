---
title: استخراج پیشرفته متن از ارائه‌ها در PHP
linktitle: استخراج متن
type: docs
weight: 90
url: /fa/php-java/extract-text-from-presentation/
keywords:
- استخراج متن
- استخراج متن از اسلاید
- استخراج متن از ارائه
- استخراج متن از پاورپوینت
- استخراج متن از OpenDocument
- استخراج متن از PPT
- استخراج متن از PPTX
- استخراج متن از ODP
- بازیابی متن
- بازیابی متن از اسلاید
- بازیابی متن از ارائه
- بازیابی متن از پاورپوینت
- بازیابی متن از OpenDocument
- بازیابی متن از PPT
- بازیابی متن از PPTX
- بازیابی متن از ODP
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "به سرعت متن را از ارائه‌های پاورپوینت و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java استخراج کنید. راهنمای ساده و گام‌به‌گاه ما را دنبال کنید تا زمان صرفه‌جویی کنید."
---
## **مرور کلی**

استخراج متن از ارائه‌ها کاری رایج اما اساسی برای توسعه‌دهندگانی است که با محتوای اسلایدها کار می‌کنند. چه با فایل‌های Microsoft PowerPoint با فرمت PPT یا PPTX کار کنید و چه ارائه‌های OpenDocument (ODP)، دسترسی و بازیابی داده‌های متنی می‌تواند برای تحلیل، خودکارسازی، ایندکس‌گذاری یا اهداف مهاجرت محتوا حیاتی باشد.

این مقاله راهنمای جامع را در مورد نحوه استخراج مؤثر متن از فرمت‌های مختلف ارائه، از جمله PPT، PPTX و ODP، با استفاده از Aspose.Slides برای PHP از طریق Java ارائه می‌دهد. شما یاد خواهید گرفت که چگونه به‌صورت سیستماتیک بر عناصر ارائه پیمایش کنید تا محتوای متنی مورد نیاز خود را به‌دقت بازیابی کنید.

## **استخراج متن از یک اسلاید**

Aspose.Slides برای PHP از طریق Java کلاس [SlideUtil](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/) را فراهم می‌کند. این کلاس چندین متد استاتیک بارگذاری‌شده برای استخراج تمام متن از یک ارائه یا اسلاید در اختیار می‌گذارد. برای استخراج متن از یک اسلاید در ارائه، از متد [getAllTextBoxes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/#getAllTextBoxes) استفاده کنید. این متد شیئی از نوع [BaseSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/) را به عنوان پارامتر می‌پذیرد. هنگام اجرا، متد تمام اسلاید را برای متن اسکن می‌کند و آرایه‌ای از اشیائی از نوع [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) برمی‌گرداند که قالب‌بندی متن را نیز حفظ می‌کند.

کد زیر تمام متن اسلاید اول ارائه را استخراج می‌کند:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **استخراج متن از یک ارائه**

برای اسکن متن از تمام ارائه، از متد استاتیک [getAllTextFrames](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/#getAllTextFrames) ارائه‌شده توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/) استفاده کنید. این متد دو پارامتر می‌پذیرد:

1. اولین پارامتر، شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) است که نمای PowerPoint یا OpenDocument را که می‌خواهید متن آن استخراج شود، نمایش می‌دهد.  
1. دومین پارامتر، مقدار `boolean` است که نشان می‌دهد آیا اسلایدهای مستر نیز در زمان اسکن متن از ارائه گنجانده شوند یا نه.

این متد آرایه‌ای از اشیائی از نوع [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) برمی‌گرداند که شامل اطلاعات قالب‌بندی متن نیز می‌شود. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه، شامل اسلایدهای مستر، اسکن می‌کند:

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **استخراج متنی دسته‌بندی‌شده و سریع**

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/) نیز روش‌هایی برای استخراج تمام متن از ارائه‌ها فراهم می‌کند:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textextractionarrangingmode/) حالت سازماندهی نتیجه استخراج متن را مشخص می‌کند و می‌تواند به مقادیر زیر تنظیم شود:
- `Unarranged` - متن خام بدون توجه به موقعیت آن در اسلاید.  
- `Arranged` - متن به همان ترتیبی که در اسلاید قرار دارد، سازماندهی می‌شود.

حالت **Unarranged** می‌تواند وقتی سرعت مهم است، مورد استفاده قرار گیرد؛ این حالت سریع‌تر از حالت **Arranged** است.

کلاس [PresentationText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationtext/) نمایانگر متن خام استخراج‌شده از ارائه است. متد `getSlidesText` آن آرایه‌ای از اشیائی برمی‌گرداند که هر شیء متن اسلاید مربوطه را نشان می‌دهد. هر شیء بازگشتی دارای متدهای زیر است:

- `getText` - متن داخل شکل‌های اسلاید.  
- `getMasterText` - متن داخل شکل‌های اسلاید مستری که به این اسلاید مرتبط است.  
- `getLayoutText` - متن داخل شکل‌های اسلاید لایه‌بندی که به این اسلاید مرتبط است.  
- `getNotesText` - متن داخل شکل‌های اسلاید یادداشت‌ها که به این اسلاید مرتبط است.  
- `getCommentsText` - متن داخل نظرات مرتبط با این اسلید.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **پرسش‌های متداول**

**استخراج متن از ارائه‌های بزرگ با Aspose.Slides چقدر سریع است؟**

Aspose.Slides برای عملکرد بالا بهینه‌سازی شده است و حتی می‌تواند [ارائه‌های بزرگ](/slides/fa/php-java/open-presentation/) را پردازش کند، بنابراین برای سناریوهای پردازش زمان واقعی یا دسته‌ای مناسب است.

**آیا Aspose.Slides می‌تواند متن را از جداول و نمودارها درون ارائه‌ها استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، از جمله جداول و اشیاء مرتبط با نمودارها، استخراج کند تا بتوانید محتوای متنی را در ساختارهای معمول ارائه تجزیه و تحلیل کنید.

**آیا برای استخراج متن از ارائه‌ها نیاز به لایسنس خاص Aspose.Slides دارم؟**

می‌توانید متن را با نسخه آزمایشی رایگان Aspose.Slides استخراج کنید، اگرچه این نسخه دارای [محدودیت‌های خاص](/slides/fa/php-java/licensing/) است، مانند پردازش تعداد محدودی اسلاید. برای استفاده بدون محدودیت و پردازش ارائه‌های بزرگ‌تر، خرید لایسنس کامل توصیه می‌شود.