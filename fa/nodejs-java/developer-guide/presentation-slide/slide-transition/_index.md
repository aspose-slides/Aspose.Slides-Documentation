---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها با استفاده از JavaScript
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/nodejs-java/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال پیشرفته اسلاید
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "اعمال انتقال‌های اسلاید، پیکربندی پیشرفت خودکار اسلاید، و سفارشی‌سازی انتقال Morph و دیگر اثرات انتقال با Aspose.Slides برای Node.js از طریق Java."
---
## **نمای کلی**

انتقالات اسلاید کنترل می‌کند که اسلایدها در یک نمایش اسلاید چگونه ظاهر می‌شوند. با Aspose.Slides برای Node.js از طریق Java، می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت را با کلیک ماوس یا زمان‌سنج تنظیم کنید و گزینه‌های خاص یک اثر را تنظیم کنید. این مقاله از مثال‌های JavaScript برای اعمال انتقال‌ها، تنظیم دقیق مدت زمان انتقال، مدیریت زمان‌بندی اسلاید و ایجاد یک انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [ارائه](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) دسترسی پیدا کنید. با استفاده از [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) مقدار از شمارش [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) را تعیین کنید، سپس ارائه را ذخیره کنید.

مثال زیر انتقال Circle را به اسلاید اول و انتقال Comb را به اسلاید دوم اعمال می‌کند. یک فایل `input.pptx` با حداقل دو اسلاید استفاده کنید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **انتقال چرخ**

`[setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes)` متد `[WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/)` تعداد بخش‌های شعاعی که اسلاید مقصد را نشان می‌دهند کنترل می‌کند. نوع انتقال اسلاید را به Wheel از `[TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)` با استفاده از `[setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType)` تنظیم کنید پیش از دسترسی به `[getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue)` به عنوان `[WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/)`.

این مثال دو جفت اسلاید یکسان ایجاد می‌کند: یک اسلاید سیاه که به دنبال یک اسلاید با مستطیل طلایی می‌آید. اسلایدهای مقصد از تعداد spoke برابر ۱ و ۸ استفاده می‌کنند، با سرعت یکسانی که از طریق `[setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed)` تنظیم شده و مدت زمان صریح ۸۰۰۰ میلی‌ثانیه که از طریق `[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration)` تنظیم شده تا تفاوت به‌راحتی قابل مشاهده باشد.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پرزنتیشن خروجی را در PowerPoint باز کنید و نمایش اسلاید را اجرا کنید. از اسلاید ۱ به اسلاید ۲، سپس از اسلاید ۳ به اسلاید ۴ پیش بروید. در پخش PowerPoint، شمارش spoke تأیید شده ۱ اسلاید را با یک حرکت ساعت‌گرد نشان می‌دهد؛ شمارش تأیید شده ۸ آن را از طریق هشت بخش شعاعی به‌صورت همزمان نشان می‌دهد. محتوای مقصد و زمان‌بندی انتقال یکسان هستند، بنابراین تفاوت در تعداد بخش‌های نمایان است.

## **افزودن انتقال پیشرفته اسلاید**

می‌توانید مدت زمانی که یک اسلاید روی صفحه می‌ماند و اینکه آیا یک کلیک ماوس نمایش اسلاید را پیش می‌برد تنظیم کنید. متدهای زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) امکان پیشرفت توسط کلیک ماوس را به بیننده می‌دهد.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) به‌صورت خودکار پیشرفت را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) تاخیر قبل از پیشرفت خودکار را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشرفت کلیکی و زمان‌بندی‌شده را فعال کنید تا بیننده بتواند با یک کلیک ادامه دهد یا صبر کند تا تایمر فعال شود. برای استفاده فقط از تایمر، `false` را به `[setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick)` پاس دهید. تاخیر زمان‌بندی زمان پیشرفت نمایش اسلاید را کنترل می‌کند؛ این مقدار مدت زمان اثر بصری انتقال را تعیین نمی‌کند.

این مثال افکت‌های مختلفی را به سه اسلاید اول اختصاص می‌دهد و پیشرفت خودکار را پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیش ببرند. از یک فایل `input.pptx` با حداقل سه اسلاید استفاده کنید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

برای بررسی اینکه آیا پیشرفت زمان‌بندی‌شده فعال است، `[getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter)` را فراخوانی کنید. فقط داشتن یک تاخیر ذخیره‌شده نشان‌دهنده فعال بودن تایمر نیست.

مثال بعدی فایلی را که در بالا ذخیره شد باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. کلیک‌های ماوس را برای آن اسلایدها فعال می‌کند و تنظیمات به‌روزشده را ذخیره می‌نماید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل دقیق زمان‌بندی انتقال**

از `[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration)` برای مشخص کردن طول دقیق یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد `[getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition)` اسلاید این تنظیمات را از طریق `[SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/)` در اختیار می‌گذارد:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | مدت زمان اثر انتقال را به‌صورت میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | تاخیر قبل از پیشرفت خودکار اسلاید را به‌صورت میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این زمان‌سنج `true` را به `[setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter)` پاس دهید. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | یک دسته‌بندی سرعت پیش‌تعریف شده از `[TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/)` (Slow، Medium یا Fast) را انتخاب می‌کند. زمانی استفاده می‌شود که مدت زمان دقیق مشخص نشده باشد. |

`[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration)` فقط اثر انتقال را کنترل می‌کند؛ مدت زمانی که اسلاید روی صفحه می‌ماند را تعیین نمی‌کند. تاخیر پیشرفت خودکار را جداگانه پیکربندی کنید. وقتی مدت زمان صریحی تنظیم نشده باشد، Aspose.Slides مدت زمان اثر را بر اساس نوع انتقال و مقدار `[getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)` تعیین می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![نوارهای جداکننده مدت زمان انتقال 750 میلی‌ثانیه و تنظیم پیشرفت خودکار 5,000 میلی‌ثانیه را نشان می‌دهند.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*مثال مشترک به هر اسلاید یک انتقال Fade به مدت 750 میلی‌ثانیه می‌دهد و به‌صورت جداگانه پیشرفت خودکار را پس از 5,000 میلی‌ثانیه فعال می‌کند. مدت زمان انتقال اثر را کنترل می‌کند؛ پیشرفت زمان خروج اسلاید را تعیین می‌کند. این نوارها تنظیمات شماتیک هستند، نه یک خط زمانی ترکیبی اندازه‌گیری شده.*  
<!-- visual-explanation:slide-transition:end -->

### **اعمال همان مدت زمان بر تمام اسلایدها**

برای حفظ سرعت یکنواخت، همان اثر و دقیقاً همان مدت زمان را بر تمام اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، از `[TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)` Fade را انتخاب می‌کند و به هر انتقال مدت زمان ۷۵۰ میلی‌ثانیه می‌دهد. به‌صورت جداگانه پیشرفت خودکار را پس از 5,000 میلی‌ثانیه فعال کرده و پیشرفت با کلیک ماوس را غیرفعال می‌کند، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // پیشرفت خودکار را به‌ طور مستقل از مدت زمان اثر پیکربندی کنید.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای منفرد**

اسلایدهای مختلف می‌توانند مدت زمان اثر متفاوتی داشته باشند. برای مثال، می‌توانید یک انتقال کوتاه برای اسلاید عنوان و یک انتقال طولانی‌تر برای معرفی بخش استفاده کنید. این مثال برای اسلاید اول 500 میلی‌ثانیه و برای اسلاید دوم 1,200 میلی‌ثانیه تنظیم می‌کند. از یک فایل `input.pptx` با حداقل دو اسلاید استفاده کنید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **هماهنگ‌سازی انتقال‌ها با خروجی انیمیشنی**

هنگام تهیه یک [animated GIF](/slides/fa/nodejs-java/convert-powerpoint-to-animated-gif/)، یک [HTML5 presentation](/slides/fa/nodejs-java/export-to-html5/)، یا یک [video](/slides/fa/nodejs-java/convert-powerpoint-to-video/)، قبل از خروجی مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با سرعت مورد نظر هماهنگ باشد. برای مثال، از یک محو شدن 600 میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به‌صورت جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوا داشته باشد.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: 600 میلی‌ثانیه معادل 18 فریم در 30 فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. گزینه‌های اثر و زمان‌بندی پشتیبانی‌شده توسط قالب خروجی مورد نظر را بررسی کنید و خروجی را پیش‌نمایش کنید تا همگام‌سازی را تأیید کنید.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، `[getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration)` را صدا بزنید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معناست که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه مشخص می‌کند. این مقدار تنظیم‌نشده همان مدت زمان پخش محاسبه‌شده نیست: Aspose.Slides بر اساس نوع انتقال و مقدار `[getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)` آن را تعیین می‌کند. تنظیم نوع انتقال می‌تواند یک مدت زمان اولیه ایجاد کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **انتقال Morph**

انتقال Morph تغییرات بین اشیاء در اسلایدهای متوالی را انیمیشن می‌دهد. برای ایجاد یک اثر ساده Morph، یک اسلاید را کلون کنید، یک شیء را در کلون جابه‌جا یا اندازه‌اش را تغییر دهید و انتقال Morph را بر اسلاید دوم اعمال کنید. این کار اشیاء مربوطه را برای انیمیشن بین حالت اصلی و تغییر یافته فراهم می‌کند.

مثال زیر یک اسلاید با یک مستطیل متن ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در کلون تغییر می‌دهد. سپس برای اسلاید دوم Morph را از شمارش `[TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)` انتخاب می‌کند. فایل ذخیره‌شده را در یک برنامه‌ی نمایش ارائه‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در طول نمایش اسلاید ببینید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **انواع انتقال Morph**

شمارش `[TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/)` تعیین می‌کند Morph چگونه محتوا را تطبیق داده و انیمیشن می‌دهد:

- `[ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject)` هر شکل را به‌عنوان یک شیء کامل در نظر می‌گیرد.
- `[ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord)` متن را با تطبیق کلمات (در صورت امکان) انیمیشن می‌کند.
- `[ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar)` متن را با تطبیق کاراکترها (در صورت امکان) انیمیشن می‌کند.

برای انتخاب Morph قبل از دسترسی به `[getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue)` از `[setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType)` استفاده کنید. مقدار دریافت‌شده یک شیء `[MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/)` است که متد `[setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType)` حالت تطبیق را انتخاب می‌کند.

این مثال ارائه‌ی ساخته‌شده در بخش قبلی را باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph بر پایه کلمه تنظیم می‌کند.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **تنظیم افکت‌های انتقال**

برخی انتقال‌ها گزینه‌های اضافی مانند جهت یا این‌که اثر از صفحه سیاه شروع شود را در اختیار می‌گذارند. گزینه‌های موجود به انتقالی که با `[setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType)` انتخاب شده بستگی دارد. ابتدا نوع را تنظیم کنید، سپس از شیء انتقال مناسب که از `[getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue)` دریافت می‌کنید استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از `[setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack)` از طریق `[OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/)` استفاده می‌کند تا انتقال از صفحه سیاه شروع شود.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. وقتی به مدت دقیق اثر بر حسب میلی‌ثانیه نیاز دارید، از `[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration)` استفاده کنید. وقتی یک دسته‌بندی سرعت پیش‌تعریف‌شده از `[TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/)` (Slow، Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده، از `[setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed)` استفاده کنید. این تنظیمات اثر انتقال را به‌طور مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال اضافه کنم و آن را حلقه‌ای کنم؟**

بله. با `[setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound)` صدا را جاسازی کنید، حالت شروع صدا را از شمارش `[TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/)` به `[setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode)` پاس دهید و با `true` `[setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop)` را فعال کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید حلقه خواهد زد.

**سریع‌ترین راه برای اعمال یک انتقال مشابه به همه اسلایدها چیست؟**

در حلقه‌ای که بر روی مجموعه `[getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides)` ارائه پیمایش می‌کنید، برای هر اسلاید `[setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType)` را با همان مقدار صدا بزنید. هر تنظیم زمان‌بندی و گزینه اثر را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

روی نتیجهٔ `[getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition)` اسلاید `[getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType)` را فراخوانی کنید. این متد یک مقدار از شمارش `[TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)` را برمی‌گرداند؛ مقدار `None` به این معناست که هیچ اثر انتقالی اعمال نشده است.