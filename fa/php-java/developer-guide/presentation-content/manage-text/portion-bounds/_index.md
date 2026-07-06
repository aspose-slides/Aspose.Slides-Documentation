---
title: دریافت محدوده‌های بخش متن از ارائه‌ها در PHP
linktitle: محدوده‌های بخش
type: docs
weight: 47
url: /fa/php-java/portion-bounds/
keywords:
- محدوده‌های بخش متن
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه محدوده‌های بخش متن را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java بازیابی کنید."
---
## **بررسی کلی**

یک بخش متن نمایانگر یک تکه خاص از متن داخل یک پاراگراف است و به شما امکان می‌دهد به صورت مستقل بر روی آن تکه نسبت به محتوای اطراف کار کنید. در Aspose.Slides، بخش‌ها می‌توانند زمانی استفاده شوند که نیاز به دریافت محدودهٔ یک تکه متن داشته باشید، قالب‌بندی را تنها بر روی بخشی از پاراگراف اعمال کنید، یا رفتار متن را در سطحی جزئی‌تر کنترل کنید.

این مقاله نشان می‌دهد چگونه با استفاده از [Portion::getRect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/getrect/) مستطیل محدودهٔ یک بخش را به دست آورید. همچنین نشان می‌دهد چگونه با استفاده از [Portion::getCoordinates](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/getcoordinates/) مختصات ابتدای یک بخش را دریافت کنید. علاوه بر این، سناریوهای معمول مرتبط با بخش‌ها را برجسته می‌کند، مانند اعمال یک پیوند به یک تکه متن منفرد، درک نحوه حل‌وفصل قالب‌بندی از طریق بخش، پاراگراف، فریم متن و ارث‌برداری تم، و مدیریت مواردی که فونت مشخص‌شده در دسترس نیست.

## **دریافت محدودیت‌های یک بخش متن**

از [Portion::getRect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/getrect/) برای دریافت مستطیل محدودهٔ یک بخش متن استفاده کنید:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **دریافت مختصات یک بخش متن**

از [Portion::getCoordinates](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/getcoordinates/) برای دریافت مختصات ابتدای یک بخش متن استفاده کنید:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم یک پیوند را فقط بر روی بخش کوچکی از متن در یک پاراگراف واحد اعمال کنم؟**

بله، می‌توانید [یک پیوند را اختصاص دهید](/slides/fa/php-java/manage-hyperlinks/) به یک بخش جداگانه؛ فقط همان تکه قابل کلیک خواهد بود، نه کل پاراگراف.

**نحو inheritance سبک چگونه کار می‌کند: یک بخش چه چیزی را Override می‌کند و چه چیزی از پاراگراف یا فریم متن گرفته می‌شود؟**

ویژگی‌های سطح بخش بالاترین اولویت را دارند. اگر ویژگی‌ای در [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) تنظیم نشده باشد، Aspose.Slides آن را از [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) می‌گیرد. اگر در آنجا نیز تنظیم نشده باشد، Aspose.Slides از سبک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) یا [theme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/theme/) استفاده می‌کند.

**اگر فونت مشخص‌شده برای یک بخش در دستگاه یا سرور هدف موجود نباشد، چه می‌شود؟**

[قوانین جایگزینی فونت](/slides/fa/php-java/font-selection-sequence/) اعمال می‌شود. متن ممکن است بازچیدمان شود: معیارها، تقسیم‌بندی و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق اهمیت دارد.

**آیا می‌توانم شفافیت پر کردن متن یا گرادیان مخصوص به بخش را به‌صورت مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر کردن و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) می‌تواند متفاوت از قطعات همسایه باشد.