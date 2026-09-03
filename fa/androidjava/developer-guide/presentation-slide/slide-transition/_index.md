---
title: مدیریت انتقال اسلایدها در ارائه‌ها برای اندروید
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "انتقال اسلایدها را اعمال کنید، پیشرفت خودکار اسلایدها را پیکربندی کنید و اثرات Morph و سایر انتقال‌ها را با Aspose.Slides برای اندروید از طریق Java سفارشی کنید."
---
## **بررسی کلی**

انتقال‌های اسلاید کنترل می‌کنند که اسلایدها چگونه در طول نمایش اسلاید ظاهر شوند. با Aspose.Slides برای Android از طریق Java می‌توانید برای هر اسلاید افکت انتقالی را انتخاب کنید، پیشرفت را با کلیک ماوس یا تایمر تنظیم کنید و گزینه‌های خاص هر افکت را تنظیم نمایید. این مقاله از مثال‌های Java برای اعمال انتقال‌ها، تنظیم دقیق مدت زمان انتقال، مدیریت زمان‌بندی اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید و از طریق [getSlideShowTransition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) به تنظیمات انتقال اسلاید دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) با مقداری از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitiontype/) استفاده کنید، سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را به اسلاید اول و یک انتقال Comb را به اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **افزودن انتقال پیشرفته اسلاید**

می‌توانید مدت زمانی که یک اسلاید روی صفحه می‌ماند و این که آیا کلیک ماوس پیشرفت نمایش را آغاز می‌کند، پیکربندی کنید. روش‌های زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) امکان پیشرفت با کلیک ماوس را برای بیننده فراهم می‌کند.
- [setAdvanceAfter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) پیشرفت خودکار را فعال می‌سازد.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) تاخیر قبل از پیشرفت خودکار را برحسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشرفت با کلیک و زمان‌دار را فعال کنید تا بیننده بتواند با کلیک یا انتظار برای تایمر به اسلاید بعدی برود. برای استفاده فقط از تایمر، مقدار `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) بدهید. تاخیر زمان پیشرفت را تعیین می‌کند؛ این مقدار مدت زمان افکت بصری انتقال را تعیین نمی‌کند.

این مثال افکت‌های مختلفی را به سه اسلاید اول اختصاص می‌دهد و پیشرفت خودکار را پس از 3، 5 و 7 ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیش ببرند. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

برای بررسی اینکه آیا پیشرفت زمان‌دار فعال است یا نه، [getAdvanceAfter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) را فراخوانی کنید. فقط داشتن مقدار تاخیر نشانگر فعال بودن تایمر نیست.

مثال بعدی فایلی که در بالا ذخیره شد را باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌سازد. برای آن اسلایدها کلیک ماوس فعال می‌شود و تنظیمات به‌روز شده ذخیره می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل دقیق زمان‌بندی انتقال**

از [setDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) برای مشخص کردن دقیق طول یک افکت انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) تنظیمات این موارد را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/) در دسترس می‌گذارد:

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | مدت زمان خود افکت انتقال را برحسب میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | تاخیر پیشرفت خودکار اسلاید را برحسب میلی‌ثانیه تعیین می‌کند. برای فعال‌سازی این تایمر، مقدار `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) بدهید. |
| [setSpeed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | یک دسته‌بندی سرعت پیش‌فرض از [TransitionSpeed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitionspeed/) (Slow, Medium یا Fast) را انتخاب می‌کند. زمانی که مدت زمان دقیق مشخص نشده باشد استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) تنها بر افکت انتقال تأثیر می‌گذارد؛ مدت زمانی که اسلاید قابل مشاهده باشد را تعیین نمی‌کند. تاخیر پیشرفت خودکار را به‌طور جداگانه تنظیم کنید. وقتی مدت زمان صریحی تنظیم نشده باشد، Aspose.Slides مدت زمان افکت را از نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) محاسبه می‌کند.

### **اعمال همان مدت زمان بر تمام اسلایدها**

برای حفظ سرعت ثابت، همان افکت و همان مدت زمان دقیق را بر تمام اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت زمان 750 میلی‌ثانیه می‌دهد. به صورت جداگانه پیشرفت خودکار پس از 5,000 میلی‌ثانیه را فعال و پیشرفت با کلیک ماوس را غیرفعال می‌کند، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // پیکربندی پیشرفت خودکار به‌طور مستقل از مدت زمان اثر.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای منفرد**

اسلایدهای مختلف می‌توانند مدت زمان‌های افکت متفاوت داشته باشند. به عنوان مثال، می‌توانید برای اسلاید عنوان یک انتقال کوتاه و برای اسلاید معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال برای اسلاید اول 500 میلی‌ثانیه و برای اسلاید دوم 1,200 میلی‌ثانیه تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **همگام‌سازی انتقال‌ها با خروجی انیمیشنی**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/androidjava/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/androidjava/export-to-html5/) یا [video](/slides/fa/androidjava/convert-powerpoint-to-video/)، مدت زمان دقیق انتقال‌ها را قبل از خروجی تنظیم کنید تا با سرعت موردنظر هماهنگ باشد. به عنوان مثال، برای صحنه‌ها یک Fade 600 میلی‌ثانیه‌ای استفاده کنید و تاخیر پیشرفت هر اسلاید را جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن داشته باشد.

برای GIF و ویدئو، نرخ فریم خروجی را با مدت زمان افکت هماهنگ کنید: 600 میلی‌ثانیه برابر با 18 فریم در 30 فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. گزینه‌های پشتیبانی‌شده توسط قالب خروجی را بررسی کنید و خروجی را پیش‌نمایش کنید تا همزمانی تضمین شود.

### **خواندن مدت زمان موجود انتقال**

قبل از تغییر انتقال، [getDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) را فراخوانی کنید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` نشان می‌دهد که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را برحسب میلی‌ثانیه نشان می‌دهد. این مقدار unset نیست؛ طول زمان محاسبه‌شده توسط پخش توسط Aspose.Slides بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) تعیین می‌شود. تنظیم نوع انتقال می‌تواند یک مقدار پیش‌فرض ایجاد کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **انتقال Morph**

انتقال Morph تغییرات بین اشیا را در اسلایدهای متوالی انیمیشن می‌کند. برای ایجاد یک افکت Morph ساده، اسلایدی را کپی کنید، شیء‌ای را روی نسخه کپی شده جابجا یا تغییر اندازه دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار به اشیا مربوطه اجازه می‌دهد بین حالت اصلی و حالت تغییر یافته انیمیشن شوند.

مثال زیر یک اسلاید با یک مستطیل متن ایجاد می‌کند، اسلاید را کپی می‌کند و موقعیت و اندازه مستطیل را در کپی تغییر می‌دهد. سپس برای اسلاید دوم Morph را از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitiontype/) انتخاب می‌کند. فایل ذخیره‌شده را در یک پیش‌نمایش‌کنندهٔ ارائه که از Morph پشتیبانی می‌کند باز کنید تا اثر را در حین نمایش اسلاید مشاهده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **انواع انتقال Morph**

شمارش‌گر [TransitionMorphType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitionmorphtype/) تعیین می‌کند Morph چگونه محتوا را مطابقت داده و انیمیشن می‌کند:

- [ByObject](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) هر شکل را به‌عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات (در صورت امکان) انیمیشن می‌کند.
- [ByChar](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق کاراکترها (در صورت امکان) انیمیشن می‌کند.

از [setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) برای انتخاب Morph قبل از دسترسی به [getValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#getValue--) استفاده کنید. سپس مقدار حاصل این متد رابط [IMorphTransition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imorphtransition/) را فراهم می‌کند که متد [setMorphType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) حالت مطابقت را انتخاب می‌کند.

این مثال ارائه‌ای که در بخش قبلی ایجاد شد را باز می‌کند و اسلاید دوم را برای انیمیشن Morph مبتنی بر کلمه تنظیم می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **تنظیم اثرهای انتقال**

برخی از انتقال‌ها گزینه‌های اضافی‌ای مانند جهت یا این که اثر از صفحهٔ سیاه شروع شود را در اختیار می‌گذارند. گزینه‌های موجود به نوع انتقالی که با [setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) انتخاب می‌کنید بستگی دارد. ابتدا نوع را تنظیم کنید، سپس از رابط مناسب که از [getValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#getValue--) برگشت می‌دهد استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از طریق [IOptionalBlackTransition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioptionalblacktransition/) متد [setFromBlack](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) را فراخوانی می‌کند تا انتقال از صفحهٔ سیاه آغاز شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. زمانی که به مدت دقیق افکت برحسب میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) استفاده کنید. وقتی یک دسته‌بندی سرعت پیش‌فرض از [TransitionSpeed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitionspeed/) (Slow, Medium یا Fast) کافی است و نیازی به مدت زمان صریح نیست، از [setSpeed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) بهره بگیرید. این تنظیمات بر افکت انتقال مستقل از تاخیر پیشرفت خودکار عمل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال وصل کنم و آن را به‌صورت حلقه‌ای پخش کنم؟**

بله. با [setSound](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) صدا را درون‌ساخته کنید، مقدار `StartSound` از شمارش‌گر [TransitionSoundMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) بدهید و با [setSoundLoop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) مقدار `true` را تنظیم کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سریع‌ترین راه برای اعمال یک انتقال یکسان به تمام اسلایدها چیست؟**

در حلقه‌ای به تمام اسلایدهای موجود در مجموعهٔ [getSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlides--) بروید و برای هر اسلاید متد [setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) را با همان مقدار فراخوانی کنید. هر تنظیم زمان‌بندی و گزینهٔ افکت را در همان حلقه اعمال کنید تا رفتار در تمام اسلایدها یکسان باشد.

**چگونه می‌توانم بررسی کنم که در حال حاضر کدام انتقال بر یک اسلاید تنظیم شده است؟**

متد [getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideshowtransition/#getType--) را بر روی نتیجهٔ [getSlideShowTransition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید فراخوانی کنید. این متد یک مقدار از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitiontype/) برمی‌گرداند؛ مقدار `None` به این معنی است که هیچ افکت انتقالی اعمال نشده است.