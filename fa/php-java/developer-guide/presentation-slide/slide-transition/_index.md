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
description: "انتقال‌های اسلاید را اعمال کنید، پیشرفت خودکار اسلایدها را پیکربندی کنید و اثرات Morph و سایر اثرات انتقال را با Aspose.Slides برای PHP از طریق Java سفارشی کنید."
---
## **نمای کلی**

انتقال‌های اسلاید نحوه نمایش اسلایدها را در طول یک نمایش اسلاید کنترل می‌کنند. با Aspose.Slides برای PHP از طریق Java می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت را با کلیک ماوس یا زمان‌سنج پیکربندی کنید و گزینه‌های خاص به یک اثر را تنظیم نمایید. این مقاله از مثال‌های PHP برای اعمال انتقال‌ها، تنظیم دقیق زمان‌برداری انتقال، مدیریت زمان اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) با مقداری از شمارشگر [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) استفاده کنید، سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را برای اسلاید اول و یک انتقال Comb را برای اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد، استفاده کنید.

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

متد [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) تعداد بخش‌های شعاعی که اسلاید مقصد را نشان می‌دهند، کنترل می‌کند. برای انتخاب Wheel از [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) از [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) استفاده کنید، سپس برای دسترسی به تنظیمات [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) از [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) فراخوانی کنید.

مثال دو جفت اسلاید مشابه ایجاد می‌کند. هر جفت با یک اسلاید سیاه شروع می‌شود و با اسلایدی که توسط یک مستطیل طلایی پوشش داده شده به پایان می‌رسد. اسلاید ۲ از یک قسمت (spoke) استفاده می‌کند و اسلاید ۴ از هشت قسمت. هر دو انتقال با سرعت کند یکسانی تنظیم شده‌اند که با [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) تنظیم می‌شود و مدت زمان صریح ۸۰۰۰ میلی‌ثانیه‌ای با [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) تعیین می‌شود.

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

نمایش ارائه ذخیره‌شده را در PowerPoint باز کنید و نمایش اسلاید را آغاز کنید. از اسلاید ۱ به اسلاید ۲ پیش بروید تا یک حرکت ساعت‌گرد تک‌دور را مشاهده کنید. سپس از اسلاید ۳ به اسلاید ۴ پیش بروید تا هشت بخش شعاعی به طور همزمان مستطیل را نمایش دهند.

## **Fade Through Black با انتقال Reveal**

نوع انتقال اسلاید مقصد را به Reveal تنظیم کنید، سپس متد [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) را بر روی تنظیمات [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/) فراخوانی کنید. مثال یک اسلاید منبع رنگ فیروزه‌ای و یک اسلاید مقصد رنگ مرجانی ایجاد می‌کند، سپس هر دو را کلون می‌کند. هر جفت از یک انتقال Reveal دو ثانیه‌ای یکسان استفاده می‌کند. تنها جفت دوم با عبور از سیاه (fade through black) انجام می‌شود.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نمایش ارائه ذخیره‌شده را در PowerPoint باز کنید و نمایش اسلاید را آغاز کنید. از اسلاید ۱ به اسلاید ۲ پیش بروید تا فیروزه‌ای مستقیماً به مرجانی تبدیل شود. سپس از اسلاید ۳ به اسلاید ۴ پیش بروید؛ صفحه برای لحظه‌ای تقریباً سیاه می‌شود قبل از اینکه اسلاید مرجانی ظاهر شود. هر دو اسلاید رنگ پس‌زمینه اصلی خود را حفظ می‌کنند.

تصاویر زیر فریم‌هایی از PowerPoint با فاصله نیم‌ثانیه‌ای را نشان می‌دهند. برای مشاهده اثر، فریم میانی هر ردیف را مقایسه کنید.

![پخش PowerPoint با غیرفعال (بالا) و فعال (پایین) کردن fade through black. تنها ردیف پایین از رنگ تقریباً سیاه عبور می‌کند.](reveal-through-black.png)

## **افزودن انتقال پیشرفته اسلاید**

می‌توانید مدت زمان نمایش یک اسلاید روی صفحه و این که آیا کلیک ماوس پیشرفت نمایش اسلاید را فعال می‌کند یا نه را تنظیم کنید. متدهای زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) اجازه می‌دهد کاربر با کلیک ماوس پیش بروید.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پیشرفت خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) تاخیر پیش از پیشرفت خودکار را به میلی‌ثانیه تعیین می‌کند.

هر دو پیشرفت کلیک و زمان‌دار را فعال کنید تا کاربر با کلیک یا انتظار برای زمان‌سنج بتواند جلو برود. برای استفاده فقط از زمان‌سنج، مقدار `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ارسال کنید. تاخیر زمان پیشرفت را کنترل می‌کند؛ مدت زمان اثر بصری انتقال را تنظیم نمی‌کند.

این مثال اثرهای متفاوتی را برای سه اسلاید اول اختصاص می‌دهد و پیشرفت خودکار پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیش ببرند. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد، استفاده کنید.

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

برای بررسی اینکه پیشرفت زمان‌دار فعال است یا نه، متد [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) را فراخوانی کنید. فقط داشتن مقدار تاخیر به تنهایی نشانگر فعال بودن زمان‌سنج نیست.

مثال بعدی فایل ذخیره‌شده در بالا را باز می‌کند، هر زمان‌سنج فعال شده را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند، غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس فعال می‌شود و تنظیمات به‌روز ذخیره می‌گردند.

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

از [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) برای تعیین دقیق طول یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید این تنظیمات را از طریق [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) در اختیار می‌گذارد:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | مدت زمان خود اثر انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | تاخیر پیش از پیشرفت خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این زمان‌سنج مقدار `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) بدهید. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | یک دسته سرعت پیش‌فرض از [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) را انتخاب می‌کند: Slow، Medium یا Fast. وقتی مدت زمان صریحی مشخص نشده باشد، از این مقدار استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) فقط بر اثر انتقال تأثیر می‌گذارد؛ مدت زمان باقی ماندن اسلاید روی صفحه را تعیین نمی‌کند. تاخیر پیشرفت خودکار را به‌طور جداگانه تنظیم کنید. وقتی مدت زمان صریحی تعیین نشود، Aspose.Slides مدت زمان اثر را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) محاسبه می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![نوارهای جداگانه مدت زمان ۷۵۰‑ms انتقال و تنظیم ۵۰۰۰‑ms پیشرفت خودکار را نشان می‌دهند.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*مثال مشترک به هر اسلاید یک انتقال Fade ۷۵۰‑ms می‌دهد و پیشرفت خودکار را به طور جداگانه در ۵۰۰۰ ms فعال می‌کند. مدت زمان انتقال فقط اثر را کنترل می‌کند؛ پیشرفت زمان خروج از اسلاید را تعیین می‌کند. این نوارها تنظیمات شماتیک هستند نه یک خط زمان ترکیبی اندازه‌گیری شده.*  
<!-- visual-explanation:slide-transition:end -->

### **اعمال همان مدت زمان به همه اسلایدها**

برای هماهنگی ثابت، همان اثر و مدت زمان دقیق را به همه اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت زمان ۷۵۰ میلی‌ثانیه می‌دهد. پیشرفت خودکار پس از ۵۰۰۰ میلی‌ثانیه فعال می‌شود و پیشرفت با کلیک ماوس غیرفعال می‌شود، سپس نتیجه به صورت PPTX ذخیره می‌شود.

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

        // پیکربندی پیشرفت خودکار به‌طور مستقل از مدت زمان اثر.
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

اسلایدهای مختلف می‌توانند مدت زمان اثر متفاوتی داشته باشند. به عنوان مثال، از یک انتقال کوتاه برای اسلاید عنوان و یک انتقال طولانی برای مقدمه بخش استفاده کنید. این مثال برای اسلاید اول ۵۰۰ میلی‌ثانیه و برای اسلاید دوم ۱٬۲۰۰ میلی‌ثانیه تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد، استفاده کنید.

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

### **همگام‌سازی انتقال‌ها با خروجی‌های پویا**

هنگامی که یک [GIF انیمیشنی](/slides/fa/php-java/convert-powerpoint-to-animated-gif/)، [ارائه HTML5](/slides/fa/php-java/export-to-html5/)، یا [ویدئو](/slides/fa/php-java/convert-powerpoint-to-video/) آماده می‌کنید، قبل از خروجی‌گیری مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با سرعت‌پیس‌بندی موردنظر مطابقت داشته باشد. به عنوان مثال، یک fade ۶۰۰‑ms بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به‌صورت جداگانه تنظیم کنید تا برای روایت یا محتوای آن زمان کافی باشد.

برای GIF و ویدئو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: ۶۰۰ میلی‌ثانیه معادل ۱۸ فریم در ۳۰ فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. قالب خروجی انتخاب‌شده را برای اثرات و گزینه‌های زمان‌بندی پشتیبانی‌شده بررسی کنید و خروجی را پیش‌نمایش کنید تا همگام‌سازی تأیید شود.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، با فراخوانی [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) بررسی کنید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معناست که مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی نشان‌دهنده مدت زمان ذخیره‌شده بر حسب میلی‌ثانیه است. مقدار تنظیم‌نشده معادل مدت زمان محاسبه‌شده پخش نیست؛ Aspose.Slides مدت زمان را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) تعیین می‌کند. تنظیم یک نوع انتقال می‌تواند مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

انتقال Morph تغییرات بین اشیاء روی اسلایدهای متوالی را انیمیشن می‌دهد. برای ایجاد یک اثر ساده Morph، اسلایدی را کلون کنید، شیء‌ای را روی کلون جابه‌جا یا اندازه‌اش را تغییر دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار به انتقال اجازه می‌دهد تا اشیاء مرتبط را بین حالت اولیه و تغییر یافته انیمیشن کند.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در کلون تغییر می‌دهد. سپس Morph را از شمارشگر [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) برای اسلاید دوم انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایش‌دهنده‌ای که از Morph پشتیبانی می‌کند باز کنید تا اثر را در طول نمایش اسلاید مشاهده کنید.

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

شمارشگر [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) تعیین می‌کند Morph چگونه محتوا را مطابق‌سازی و انیمیشن می‌دهد:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) هر شکل را به عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات (در صورت امکان) انیمیشن می‌کند.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق حروف (در صورت امکان) انیمیشن می‌کند.

از [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) برای انتخاب Morph پیش از دسترسی به [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) استفاده کنید. سپس مقدار بازگشتی یک شیء [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) است که متد [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) حالت تطبیق را انتخاب می‌کند.

این مثال ارائه ایجاد‌شده در بخش قبلی را باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph مبتنی بر واژه تنظیم می‌کند.

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

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا این که اثر از صفحه سیاه شروع شود را در اختیار می‌گذارند. گزینه‌های موجود بسته به انتقالی که با [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) انتخاب شده‌اند، متفاوت است. ابتدا نوع را تنظیم کنید، سپس شیء انتقال مناسب را از [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) دریافت کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از طریق [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) متد [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) را فراخوانی می‌کند تا انتقال از صفحه سیاه شروع شود.

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

## **سؤالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. وقتی به مدت دقیق اثر بر حسب میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) استفاده کنید. وقتی یک دسته سرعت پیش‌فرض از [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) کافی است و مدت زمان صریحی تنظیم نشده، از [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) بهره ببرید. این تنظیمات اثر انتقال را به‌صورت مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال وصل کنم و حلقه‌دار کنم؟**

بله. صدا را با [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) اضافه کنید، مقدار `StartSound` از شمارشگر [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) بفرستید و با `true` به [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) فعال کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سریع‌ترین راه برای اعمال یک انتقال یکسان به همه اسلایدها چیست؟**

در حلقه‌ای بر روی مجموعه [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) ارائه، برای هر اسلاید متد [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) را با مقدار یکسان فراخوانی کنید. هر تنظیمات زمان‌بندی و اثر را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر یک اسلاید تنظیم شده است؟**

متد [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) را بر روی نتیجه‌ی [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید فراخوانی کنید. این مقدار از شمارشگر [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) برمی‌گرداند؛ مقدار None به این معناست که هیچ اثر انتقالی اعمال نشده است.