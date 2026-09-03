---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها با استفاده از JavaScript
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/nodejs-java/slide-transition/
keywords:
- انتقال اسلاید
- اضافه کردن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال اسلاید پیشرفته
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "با Aspose.Slides برای Node.js از طریق Java، انتقال‌های اسلاید را اعمال کنید، پیشرفت خودکار اسلایدها را پیکربندی کنید و اثرهای Morph و سایر اثرهای انتقال را سفارشی‌سازی کنید."
---
## **نمای کلی**

انتقال اسلایدها نحوه نمایش اسلایدها در حین ارائه را کنترل می‌کند. با Aspose.Slides برای Node.js از طریق Java، می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت را با کلیک ماوس یا تایمر تنظیم کنید و گزینه‌های خاص یک اثر را تنظیم نمایید. این مقاله از مثال‌های JavaScript برای اعمال انتقال‌ها، تنظیم دقیق مدت زمان انتقال، مدیریت زمان اسلاید و ایجاد یک انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نحوه ذخیره تنظیمات در یک فایل PPTX را نشان می‌دهند.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید و از طریق [getSlideShowTransition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) به تنظیمات انتقال اسلاید دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setType) با مقداری از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitiontype/) استفاده کنید و سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را به اسلاید اول و یک انتقال Comb را به اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

## **افزودن انتقال اسلاید پیشرفته**

می‌توانید مدت زمان نمایش اسلاید روی صفحه و اینکه آیا کلیک ماوس پیشرفت اسلایدشو را فعال می‌کند یا خیر، تنظیم کنید. متدهای زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) اجازه می‌دهد بیننده با کلیک ماوس پیش برود.
- [setAdvanceAfter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پیشرفت خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) تاخیر پیشرفت خودکار را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشرفت با کلیک و زمان‌بندی را فعال کنید تا بیننده بتواند با کلیک ادامه دهد یا صبر کند تا تایمر پایان یابد. برای استفاده فقط از تایمر، مقدار `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) بگذارید. تاخیر زمان‌بندی زمانی را که اسلایدشو پیش می‌رود کنترل می‌کند؛ اما مدت زمان اثر بصری انتقال را تنظیم نمی‌کند.

این مثال اثرهای متفاوتی را به اولین سه اسلاید اختصاص می‌دهد و پیشرفت خودکار را پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیش ببرند. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

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

برای بررسی اینکه آیا پیشرفت زمان‌بندی شده فعال است یا خیر، متد [getAdvanceAfter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) را فراخوانی کنید. فقط داشتن یک تاخیر ذخیره‌شده نشان‌دهنده فعال بودن تایمر نیست.

مثال بعدی فایلی که در بالا ذخیره شد را باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای این اسلایدها کلیک ماوس را فعال می‌سازد و تنظیمات به‌روز شده را ذخیره می‌کند.

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

از [setDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setDuration) برای تعیین دقیق طول یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید این تنظیمات را از طریق [SlideShowTransition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/) در اختیار می‌گذارد:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | مدت زمان اثر انتقال را به میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | تاخیر پیشرفت خودکار اسلاید را به میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این تایمر مقدار `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) بدهید. |
| [setSpeed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitionspeed/) را انتخاب می‌کند: Slow، Medium یا Fast. وقتی مدت زمان دقیقی مشخص نشده باشد استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setDuration) فقط بر اثر انتقال تاثیر می‌گذارد؛ طول زمان نمایش اسلاید را تعیین نمی‌کند. تاخیر پیشرفت خودکار را به‌صورت جداگانه تنظیم کنید. وقتی مدت زمان صریحی تنظیم نشود، Aspose.Slides مدت زمان اثر را بر پایه نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) محاسبه می‌کند.

### **اعمال همان مدت زمان بر تمام اسلایدها**

برای حفظ سرعت یکنواخت، همان اثر و همان مدت زمان دقیق را بر تمام اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت ۷۵۰ میلی‌ثانیه می‌دهد. به‌طور جداگانه پیشرفت خودکار پس از ۵۰۰۰ میلی‌ثانیه را فعال و پیشرفت با کلیک ماوس را غیرفعال می‌کند، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // پیکربندی پیشرفت خودکار به طور مستقل از مدت زمان اثر.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای جداگانه**

اسلایدهای مختلف می‌توانند مدت زمان اثر متفاوتی داشته باشند. برای مثال، می‌توانید یک انتقال کوتاه برای اسلاید عنوان و یک انتقال طولانی‌تر برای معرفی بخش استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه را برای اسلاید اول و ۱۲۰۰ میلی‌ثانیه را برای اسلاید دوم تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

### **هماهنگ‌سازی انتقال‌ها با خروجی انیمیشن‌دار**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/nodejs-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/nodejs-java/export-to-html5/)، یا [video](/slides/fa/nodejs-java/convert-powerpoint-to-video/)، قبل از خروجی‌گیری مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با سرعت موردنظر هم‌خوانی داشته باشند. برای مثال، می‌توانید یک محو شدن ۶۰۰ میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به‌صورت جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن فراهم شود.

برای GIF و ویدئو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: ۶۰۰ میلی‌ثانیه برابر است با ۱۸ فریم در ۳۰ فریم بر ثانیه. در HTML5، انتقال‌های انیمیشن‌دار را در تنظیمات خروجی فعال کنید. فرمت خروجی انتخابی را برای پشتیبانی از اثرها و گزینه‌های زمان‌بندی بررسی کنید و خروجی را پیش‌نمایش کنید تا از هم‌زمانی اطمینان حاصل شود.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، متد [getDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#getDuration) را فراخوانی کنید تا بررسی کنید آیا مقدار صریح ذخیره شده است یا خیر. مقدار `-1` به این معناست که مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده بر حسب میلی‌ثانیه را نشان می‌دهد. این مقدار تنظیم نشده، مدت زمان محاسبه‌شده پخش نیست: Aspose.Slides از نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) برای تعیین آن استفاده می‌کند. تنظیم نوع انتقال می‌تواند مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

انتقال Morph تغییرات بین اشیا در اسلایدهای پی در پی را انیمیشن می‌کند. برای ایجاد یک اثر Morph ساده، یک اسلاید را کلون کنید، یک شی را روی کلون جابجا یا تغییر اندازه دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار اشیاء متناظر را برای انیمیشن بین حالت اصلی و تغییر یافته فراهم می‌آورد.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در نسخه کلون شده تغییر می‌دهد. سپس Morph را از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitiontype/) برای اسلاید دوم انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایشگر ارائه‌ای که از Morph پشتیبانی می‌کند باز کنید تا اثر را در حین اسلاید شو ببینید.

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

شمارش‌گر [TransitionMorphType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitionmorphtype/) نحوه مطابقت و انیمیشن محتوای Morph را کنترل می‌کند:

- [ByObject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) هر شکل را به عنوان یک شی کلی در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات (در صورت امکان) انیمیشن می‌کند.
- [ByChar](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق حروف (در صورت امکان) انیمیشن می‌کند.

برای انتخاب Morph قبل از دسترسی به [getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#getValue) از [setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setType) استفاده کنید. مقدار بازگشتی سپس یک شی [MorphTransition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/morphtransition/) را می‌دهد که متد [setMorphType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/morphtransition/#setMorphType) برای انتخاب حالت مطابقت استفاده می‌شود.

این مثال ارائه‌ای را که در بخش قبلی ایجاد شد باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph بر پایه کلمه تنظیم می‌کند.

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

## **تنظیم اثرهای انتقال**

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا اینکه آیا اثر از یک صفحه سیاه شروع می‌شود را افشا می‌کنند. گزینه‌های در دسترس به انتقال انتخاب‌شده با [setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setType) بستگی دارند. ابتدا نوع را تنظیم کنید، سپس از شی انتقال مناسب که از [getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#getValue) دریافت می‌کنید استفاده نمایید.

مثال زیر یک انتقال Cut را به اولین اسلاید `input.pptx` اعمال می‌کند. از طریق [OptionalBlackTransition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/optionalblacktransition/) متد [setFromBlack](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) را صدا می‌زند تا انتقال از یک صفحه سیاه شروع شود.

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

## **سؤالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. وقتی به مدت زمان دقیق اثر بر حسب میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setDuration) استفاده کنید. وقتی یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitionspeed/) (Slow، Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده، از [setSpeed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) استفاده کنید. این تنظیمات اثر انتقال را مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال وصل کنم و آن را حلقه‌دار کنم؟**

بله. با استفاده از [setSound](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setSound) صدای جاسازی‌شده را اختصاص دهید، مقدار `StartSound` از شمارش‌گر [TransitionSoundMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) بدهید و با مقدار `true` برای [setSoundLoop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) حلقه‌پذیر شدن صدا را فعال کنید. صدا تا رویداد صوتی بعدی در اسلاید شو تکرار می‌شود.

**سریع‌ترین راه برای اعمال یک انتقال یکسان به تمام اسلایدها چیست؟**

در مجموعه [getSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSlides) ارائه حلقه بزنید و برای هر اسلاید متد [setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#setType) را با همان مقدار صدا بزنید. هر گزینه زمان‌بندی و اثر را در همان حلقه تنظیم کنید تا رفتار بین اسلایدها یکنواخت بماند.

**چگونه می‌توانم بررسی کنم که چه انتقالی هم‌اکنون روی یک اسلاید تنظیم شده است؟**

متد [getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/#getType) را بر روی نتیجه‌ی [getSlideShowTransition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید صدا بزنید. این متد یک مقدار از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitiontype/) برمی‌گرداند؛ مقدار None به این معناست که هیچ اثر انتقالی اعمال نشده است.