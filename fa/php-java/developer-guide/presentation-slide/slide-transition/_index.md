---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها با استفاده از PHP
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/php-java/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال اسلاید پیشرفته
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "انتقال‌های اسلاید را اعمال کنید، پیشروی خودکار اسلایدها را پیکربندی کنید و اثرهای مورف و سایر اثرهای انتقال را با Aspose.Slides برای PHP از طریق Java شخصی‌سازی کنید."
---
## **نمای کلی**

انتقال‌های اسلاید نحوه ظاهر شدن اسلایدها را در طول یک نمایش اسلاید کنترل می‌کنند. با Aspose.Slides for PHP via Java می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشروی را با کلیک ماوس یا تایمر تنظیم کنید و گزینه‌های خاص هر اثر را تنظیم نمایید. این مقاله از مثال‌های PHP برای اعمال انتقال‌ها، تعیین دقیق مدت زمان انتقال، مدیریت زمان اسلاید و ایجاد یک انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند که چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید و از طریق [getSlideShowTransition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getSlideShowTransition) به تنظیمات انتقال اسلاید دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setType) با مقداری از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitiontype/) استفاده کنید و سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را بر روی اولین اسلاید و یک انتقال Comb را بر روی اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **افزودن انتقال پیشرفته اسلاید**

می‌توانید مدت زمانی که اسلاید روی صفحه می‌ماند و اینکه آیا کلیک ماوس باعث پیشروی نمایش اسلاید می‌شود یا نه را تنظیم کنید. روش‌های زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) اجازه می‌دهد بیننده با کلیک ماوس پیشروی کند.
- [setAdvanceAfter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پیشروی خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) زمان تاخیر پیشروی خودکار را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشروی با کلیک و پیشروی زمان‌دار را فعال کنید تا بیننده یا با کلیک یا با انتظار برای تایمر به اسلاید بعدی برود. برای استفاده فقط از تایمر، `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) پاس دهید. این تاخیر زمان پیشرفت نمایش را کنترل می‌کند؛ مدت زمان اثر انتقال بصری را تعیین نمی‌کند.

این مثال اثرهای متفاوتی را به سه اسلاید اول اختصاص می‌دهد و پیشروی خودکار را پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک ماوس نیز می‌تواند این اسلایدها را پیش بَرَد. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

برای بررسی اینکه آیا پیشروی زمان‌دار فعال است یا نه، [getAdvanceAfter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) را صدا بزنید. تنها ذخیره‌سازی تاخیر نشانگر فعال بودن تایمر نیست.

مثال بعدی فایلی که در مثال قبلی ذخیره شد را باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشروی خودکار را برای اسلایدهایی که تاخیر بیشتر از دو ثانیه دارند غیرفعال می‌کند. برای این اسلایدها کلیک ماوس را فعال می‌سازد و تنظیمات به‌روز شده را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **کنترل دقیق زمان‌بندی انتقال**

با استفاده از [setDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setDuration) می‌توانید مدت زمان دقیق یک اثر انتقال را بر حسب میلی‌ثانیه تعیین کنید. روش [getSlideShowTransition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید این تنظیمات را از طریق [SlideShowTransition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/) در اختیار می‌گذارد:

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setDuration) | مدت زمان خود اثر انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | تاخیر پیشروی خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال کردن این تایمر `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پاس دهید. |
| [setSpeed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setSpeed) | یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitionspeed/) را انتخاب می‌کند: Slow، Medium یا Fast. زمانی که مدت زمان دقیق مشخص نشده باشد استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setDuration) فقط اثر انتقال را کنترل می‌کند؛ مدت زمان دیده شدن اسلاید را تعیین نمی‌کند. تاخیر پیشروی خودکار را به‌صورت جداگانه تنظیم کنید. هنگامی که مدت زمان صریحی تنظیم نشود، Aspose.Slides مدت زمان اثر را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#getSpeed) تعیین می‌کند.

### **اعمال همان مدت زمان بر تمام اسلایدها**

برای حفظ سرعت یکنواخت، همان اثر و مدت زمان دقیق را بر تمام اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت زمان ۷۵۰ میلی‌ثانیه می‌دهد. به‌طور جداگانه پیشروی خودکار پس از ۵۰۰۰ میلی‌ثانیه فعال و پیشروی با کلیک ماوس غیرفعال می‌شود، سپس نتیجه به‌صورت PPTX ذخیره می‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // پیکربندی پیشرفت خودکار به صورت مستقل از مدت زمان اثر.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای جداگانه**

اسلایدهای مختلف می‌توانند مدت زمان‌های اثر متفاوتی داشته باشند. برای مثال، از یک انتقال کوتاه برای اسلاید عنوان و یک انتقال طولانی‌تر برای مقدمه بخش استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه را برای اسلاید اول و ۱۲۰۰ میلی‌ثانیه را برای اسلاید دوم تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **هم‌آهنگی انتقال‌ها با خروجی‌های انیمیشنی**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/php-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/php-java/export-to-html5/)، یا [video](/slides/fa/php-java/convert-powerpoint-to-video/)، قبل از خروجی‌گیری مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با ریتم موردنظر همخوانی داشته باشد. برای مثال، از یک افکت Fade با ۶۰۰ میلی‌ثانیه بین صحنه‌ها استفاده کنید و تاخیر پیشروی هر اسلاید را به‌صورت جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن داشته باشد.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: ۶۰۰ میلی‌ثانیه معادل ۱۸ فریم در ۳۰ فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. فرمت خروجی انتخابی را برای پشتیبانی از اثرها و گزینه‌های زمان‌بندی بررسی کنید و خروجی را پیش‌نمایش کنید تا هم‌زمانی را تأیید کنید.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال [getDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#getDuration) را صدا بزنید تا مشخص شود آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` بدین معنی است که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه نشان می‌دهد. مقدار تنظیم نشده همان مدت زمان محاسبه‌شده پخش نیست؛ Aspose.Slides برای تعیین آن از نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#getSpeed) استفاده می‌کند. تنظیم نوع انتقال می‌تواند مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **انتقال Morph**

انتقال Morph تغییرات بین اشیاء در اسلایدهای متوالی را انیمیشن می‌دهد. برای ایجاد یک اثر Morph ساده، یک اسلاید را کلون کنید، یک شیء را در نسخهٔ کلون شده جابه‌جا یا تغییر اندازه دهید و انتقال Morph را بر اسلاید دوم اعمال کنید. این کار اشیاء متناظر را برای انیمیشن بین حالت اولیه و تغییر یافته فراهم می‌کند.

مثال زیر یک اسلاید با یک مستطیل متن ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در نسخهٔ کلون شده تغییر می‌دهد. سپس Morph را از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitiontype/) برای اسلاید دوم انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایشگر ارائه که Morph را پشتیبانی می‌کند باز کنید تا اثر را در هنگام نمایش اسلاید ببینید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **انواع انتقال Morph**

شمارش‌گر [TransitionMorphType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitionmorphtype/) تعیین می‌کند Morph چگونه محتوا را مطابقت داده و انیمیشن می‌دهد:

- [ByObject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitionmorphtype/#ByObject) هر شکل را به‌عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitionmorphtype/#ByWord) متن را با مطابقت کلمات (در صورت امکان) انیمیشن می‌کند.
- [ByChar](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitionmorphtype/#ByChar) متن را با مطابقت کاراکترها (در صورت امکان) انیمیشن می‌کند.

برای انتخاب Morph قبل از دسترسی به [getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#getValue) از [setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setType) استفاده کنید. مقدار بازگردانده شده یک شیء [MorphTransition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/morphtransition/) است که متد [setMorphType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/morphtransition/#setMorphType) حالت مطابقت را انتخاب می‌کند.

این مثال ارائهٔ ایجاد‌شده در بخش قبلی را باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph بر پایهٔ کلمه تنظیم می‌نماید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **تنظیم اثرهای انتقال**

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا اینکه اثر از یک صفحهٔ سیاه شروع شود را در اختیار می‌گذارند. گزینه‌های موجود به انتقال انتخاب‌شده با [setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setType) بستگی دارند. ابتدا نوع را تنظیم کنید، سپس از شیء انتقال مناسب که از [getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#getValue) به‌دست می‌آید، استفاده کنید.

مثال زیر یک انتقال Cut را به اولین اسلاید `input.pptx` اعمال می‌کند. از [setFromBlack](https://reference.aspose.com/slides/fa/php-java/aspose.slides/optionalblacktransition/#setFromBlack) از طریق کلاس [OptionalBlackTransition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/optionalblacktransition/) استفاده می‌کند تا انتقال از یک صفحهٔ سیاه شروع شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. زمانی که به مدت دقیق اثر بر حسب میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setDuration) استفاده کنید. زمانی که یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitionspeed/) (Slow، Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده، از [setSpeed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setSpeed) استفاده کنید. این تنظیمات اثر انتقال را مستقل از تاخیر پیشروی خودکار کنترل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال اضافه کنم و آن را حلقه‌دار کنم؟**

بله. با استفاده از [setSound](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setSound) صدای تعبیه‌شده را تخصیص دهید، مقدار StartSound از شمارش‌گر [TransitionSoundMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setSoundMode) پاس دهید و با مقدار `true` به [setSoundLoop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setSoundLoop) حلقه صدا را فعال کنید. صدا تا رویداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سریع‌ترین روش برای اعمال یک انتقال یکسان بر تمام اسلایدها چیست؟**

در مجموعهٔ [getSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlides) ارائه حلقه بزنید و برای هر اسلاید [setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#setType) را با همان مقدار فراخوانی کنید. هر تنظیم زمان‌بندی و گزینهٔ اثر را در همان حلقه قرار دهید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

بر روی نتیجهٔ [getSlideShowTransition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید، متد [getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/#getType) را صدا بزنید. این متد مقدار از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitiontype/) را بر می‌گرداند؛ مقدار None به این معنی است که هیچ اثر انتقالی اعمال نشده است.