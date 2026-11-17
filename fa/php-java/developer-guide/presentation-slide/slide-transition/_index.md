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
- انتقال Morph
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "انتقال‌های اسلاید را اعمال کنید، پیشرفت خودکار اسلاید را پیکربندی کنید، و انتقال Morph و سایر اثرهای انتقال را با Aspose.Slides برای PHP از طریق Java سفارشی‌سازی کنید."
---
## **بررسی کلی**

انتقال‌های اسلاید کنترل می‌کنند که اسلایدها در طول یک نمایش اسلاید چگونه ظاهر شوند. با Aspose.Slides برای PHP از طریق Java، می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت را با کلیک ماوس یا تایمر پیکربندی کنید و گزینه‌های خاص یک اثر را تنظیم کنید. این مقاله از مثال‌های PHP برای اعمال انتقال‌ها، تنظیم مدت زمان دقیق انتقال، مدیریت زمان اسلاید و ایجاد یک انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نحوه ذخیره تنظیمات در فایل PPTX را نشان می‌دهند.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) با مقداری از شمارشگر [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) استفاده کنید، سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را به اسلاید اول و یک انتقال Comb را به اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

## **انتقال Wheel**

متد [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) تعداد بخش‌های شعاعی که اسلاید مقصد را نشان می‌دهند کنترل می‌کند. برای انتخاب Wheel از [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) از [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) استفاده کنید، سپس برای دسترسی به تنظیمات [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) را فراخوانی کنید.

مثال دو جفت اسلاید یکسان ایجاد می‌کند. هر جفت با یک اسلاید سیاه شروع می‌شود و با اسلایدی که مستطیل طلایی بر آن پوشانده شده خاتمه می‌یابد. اسلاید 2 از یک spoke استفاده می‌کند و اسلاید 4 از هشت spoke. هر دو انتقال از همان سرعت آهسته استفاده می‌کنند که با [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) تنظیم می‌شود، و مدت زمان صریح ۸٬۰۰۰ میلی‌ثانیه که با [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) تنظیم می‌شود.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ارائه ذخیره‌شده را در PowerPoint باز کنید و نمایش اسلاید را شروع کنید. از اسلاید 1 به اسلاید 2 پیش بروید تا یک حرکت تک ساعتگرد را ببینید. سپس از اسلاید 3 به اسلاید 4 پیش بروید تا هشت بخش شعاعی همزمان مستطیل یکسان را نشان دهند.

## **افزودن انتقال پیشرفته اسلاید**

می‌توانید مدت زمانی که یک اسلاید روی صفحه باقی می‌ماند و اینکه آیا کلیک ماوس نمایش اسلاید را پیش می‌برد را پیکربندی کنید. متدهای زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) به بیننده اجازه می‌دهد با کلیک ماوس پیش برود.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پیشرفت خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) تأخیر پیش از پیشرفت خودکار را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشرفت با کلیک و زمان‌بندی را فعال کنید تا بیننده بتواند با کلیک ادامه دهد یا منتظر تایمر بماند. برای استفاده تنها از تایمر، مقدار `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) پاس دهید. این تأخیر زمان پیشرفت نمایش اسلاید را تعیین می‌کند؛ اما مدت زمان اثر انتقال بصری را تنظیم نمی‌کند.

این مثال اثرهای متفاوتی را به سه اسلاید اول اختصاص می‌دهد و پیشرفت خودکار را پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیش ببرند. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

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

برای بررسی اینکه آیا پیشرفت زمان‌بندی‌شده فعال است یا نه، [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) را فراخوانی کنید. یک تأخیر ذخیره‌شده به تنهایی نشانگر فعال بودن تایمر نیست.

مثال بعدی فایلی که در بالا ذخیره شد را باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تأخیر بیش از دو ثانیه دارند غیرفعال می‌سازد. برای آن اسلایدها کلیک ماوس را فعال می‌کند و تنظیمات به‌روزشده را ذخیره می‌کند.

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

از [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) برای تعیین طول دقیق یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید این تنظیمات را از طریق [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) افشا می‌کند:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | مدت زمان خود اثر انتقال را به میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | مدت زمان تأخیر پیش از پیشرفت خودکار اسلاید را به میلی‌ثانیه تنظیم می‌کند. برای فعال کردن این تایمر، `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پاس دهید. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | یک دسته سرعت پیش‌تعریف‌شده را از [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium یا Fast انتخاب می‌کند. زمانی که مدت زمان صریحی مشخص نشده باشد استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) فقط اثر انتقال را کنترل می‌کند؛ مدت زمان باقی ماندن اسلاید را تعیین نمی‌کند. تأخیر پیشرفت خودکار را جداگانه تنظیم کنید. زمانی که مدت زمان صریحی تنظیم نشده باشد، Aspose.Slides مدت زمان اثر را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) تعیین می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![نوارهای جداگانه مدت زمان انتقال ۷۵۰ میلی‌ثانیه و تنظیم پیشرفت خودکار ۵۰۰۰ میلی‌ثانیه را نشان می‌دهند.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*مثال مشترک به هر اسلاید یک انتقال Fade به مدت ۷۵۰ میلی‌ثانیه می‌دهد و پیشرفت خودکار را به صورت جداگانه در ۵۰۰۰ میلی‌ثانیه فعال می‌کند. مدت زمان انتقال اثر را کنترل می‌کند؛ پیشرفت زمان خروج اسلاید را تعیین می‌کند. این نوارها تنظیمات شماتیک هستند، نه یک جدول زمانی ترکیبی اندازه‌گیری‌شده.*
<!-- visual-explanation:slide-transition:end -->

### **اعمال همان مدت زمان به هر اسلاید**

برای حفظ ضربان یکنواخت، همان اثر و مدت زمان دقیق را به هر اسلاید اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت زمان ۷۵۰ میلی‌ثانیه می‌دهد. پیشرفت خودکار را پس از ۵۰۰۰ میلی‌ثانیه به صورت جداگانه فعال می‌کند و پیشرفت با کلیک ماوس را غیرفعال می‌کند، سپس نتیجه را به عنوان PPTX ذخیره می‌کند.

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

        // پیشرفت خودکار را به‌صورت مستقل از مدت زمان اثر تنظیم کنید.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای تک‌تک**

اسلایدهای مختلف می‌توانند مدت زمان‌های اثر متفاوتی داشته باشند. به عنوان مثال، برای اسلاید عنوان یک انتقال کوتاه و برای معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه برای اسلاید اول و ۱٬۲۰۰ میلی‌ثانیه برای اسلاید دوم تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

### **هماهنگی انتقال‌ها با خروجی‌های متحرک**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/php-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/php-java/export-to-html5/)، یا [video](/slides/fa/php-java/convert-powerpoint-to-video/)، مدت زمان دقیق انتقال‌ها را قبل از خروجی تنظیم کنید تا با ضربان مورد نظر مطابقت داشته باشد. برای مثال، از یک افکت Fade به مدت ۶۰۰ میلی‌ثانیه بین صحنه‌ها استفاده کنید و تأخیر پیشرفت هر اسلاید را به صورت جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن فراهم شود.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: ۶۰۰ میلی‌ثانیه معادل ۱۸ فریم در ۳۰ فریم بر ثانیه است. در HTML5، انتقال‌های متحرک را در تنظیمات خروجی فعال کنید. اثرات و گزینه‌های زمانی پشتیبانی‌شده توسط فرمت خروجی انتخابی را بررسی کنید و برای تأیید همگامی، خروجی را پیش‌نمایش کنید.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) را فراخوانی کنید تا تعیین کنید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معنی است که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده به میلی‌ثانیه را نشان می‌دهد. مقدار تنظیم‌نشده، مدت زمان محاسبه‌شده پخش نیست: Aspose.Slides مدت زمان را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) تعیین می‌کند. تنظیم نوع انتقال می‌تواند مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

انتقال Morph تغییرات بین اشیاء در اسلایدهای متوالی را متحرک می‌کند. برای ایجاد یک اثر ساده Morph، یک اسلاید را کلون کنید، یک شیء را در کلون جابه‌جا یا اندازه‌اش را تغییر دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار اشیاء مربوطه را قادر می‌سازد تا بین حالت اصلی و حالت تغییر یافته خود متحرک شوند.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در کلون تغییر می‌دهد. سپس برای اسلاید دوم Morph را از شمارشگر [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) انتخاب می‌کند. فایل ذخیره‌شده را در یک مشاهده‌گر ارائه که از Morph پشتیبانی می‌کند باز کنید تا اثر را در طول نمایش اسلاید مشاهده کنید.

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

شمارشگر [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) تعیین می‌کند که Morph چگونه محتوا را مطابقت داده و متحرک کند:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) هر شکل را به عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات (در صورت امکان) متحرک می‌کند.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق کاراکترها (در صورت امکان) متحرک می‌کند.

قبل از دسترسی به [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue)، از [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) برای انتخاب Morph استفاده کنید. سپس مقدار حاصل یک شیء [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) را فراهم می‌کند که متد [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) حالت مطابقت را انتخاب می‌کند.

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

## **تنظیم افکت‌های انتقال**

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا اینکه اثر از صفحه‌سیاه شروع شود را ارائه می‌دهند. گزینه‌های موجود بستگی به انتقال انتخاب‌شده با [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) دارد. ابتدا نوع را تنظیم کنید، سپس از شیء انتقال مناسب با [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) از طریق [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) استفاده می‌کند تا انتقال از صفحه‌سیاه آغاز شود.

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

بله. وقتی به مدت زمان دقیق اثر به میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) استفاده کنید. وقتی یک دسته‌بندی پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow، Medium یا Fast کافی است و هیچ مدت زمان صریحی تنظیم نشده، از [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) استفاده کنید. این تنظیمات اثر انتقال را به طور مستقل از تأخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال متصل کنم و آن را به‌صورت حلقه‌ای پخش کنم؟**

بله. صداهای جاسازی‌شده را با [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) اختصاص دهید، مقدار StartSound از شمارشگر [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) پاس دهید و با `true` [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) را فعال کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید به‌صورت حلقه‌ای پخش می‌شود.

**سریع‌ترین راه برای اعمال یک انتقال مشابه به تمام اسلایدها چیست؟**

از طریق حلقه بر روی مجموعه [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) ارائه عبور کنید و برای هر اسلاید [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) را با همان مقدار فراخوانی کنید. هر تنظیم زمانی و گزینهٔ اثر را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

بر روی نتیجهٔ [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید، متد [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) را فراخوانی کنید. این متد مقداری از شمارشگر [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) بر می‌گرداند؛ None به این معنی است که هیچ اثر انتقالی اعمال نشده است.