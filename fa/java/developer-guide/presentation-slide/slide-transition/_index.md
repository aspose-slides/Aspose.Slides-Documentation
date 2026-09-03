---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها با استفاده از جاوا
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/java/slide-transition/
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
- Java
- Aspose.Slides
description: "انتقال‌های اسلاید را اعمال کنید، پیشرفت خودکار اسلاید را پیکربندی کنید و انتقال‌های مورف و سایر اثرات انتقال را با Aspose.Slides برای Java سفارشی کنید."
---
## **نمای کلی**

انتقال اسلایدها نحوه نمایش اسلایدها را در طول یک نمایش اسلاید کنترل می‌کند. با Aspose.Slides for Java می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشروی را بر اساس کلیک ماوس یا زمان‌سنج تنظیم کنید و گزینه‌های خاص یک اثر را تنظیم نمایید. این مقاله از مثال‌های Java برای اعمال انتقال‌ها، تنظیم مدت زمان دقیق انتقال، مدیریت زمان اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. این مثال‌ها همچنین نشان می‌دهند که چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، ارائه‌ای را با کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [getSlideShowTransition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) دسترسی پیدا کنید. با استفاده از [setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setType-int-) و یک مقدار از شمارش‌نامه [TransitionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitiontype/) مقدار را تنظیم کنید، سپس ارائه را ذخیره نمایید.

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

می‌توانید مدت زمان ماندن اسلاید روی صفحه و این که آیا یک کلیک ماوس نمایش اسلاید را پیش می‌برد تنظیم کنید. روش‌های زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) به بیننده اجازه می‌دهد با کلیک ماوس پیشروی کند.
- [setAdvanceAfter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) پیشرفت خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) تاخیر قبل از پیشرفت خودکار را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشروی کلیکی و زمان‌دار را فعال کنید تا بیننده بتواند با یک کلیک ادامه دهد یا صبر کند تا زمان‌سنج اجرا شود. برای استفاده فقط از زمان‌سنج، `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) پاس دهید. تاخیر زمان‌سنج زمان پیشرفت نمایش اسلاید را کنترل می‌کند؛ اما مدت زمان اثر بصری انتقال را تنظیم نمی‌کند.

این مثال اثرهای متفاوتی را به اولین سه اسلاید اختصاص می‌دهد و پیشرفت خودکار را پس از 3، 5 و 7 ثانیه به ترتیب فعال می‌کند. کلیک ماوس نیز می‌تواند این اسلایدها را پیش ببرد. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

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

برای بررسی اینکه آیا پیشرفت زمان‌دار فعال است، [getAdvanceAfter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) را فراخوانی کنید. فقط داشتن مقدار تاخیر ذخیره‌شده نشانگر فعال بودن زمان‌سنج نیست.

مثال بعدی فایلی که در بالا ذخیره شد را باز می‌کند، هر زمان‌سنج فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس را فعال می‌کند و تنظیمات بروز شده را ذخیره می‌نماید.

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

از [setDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setDuration-int-) برای تعیین طول دقیق یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید این تنظیمات را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/) در اختیار می‌گذارد:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | مدت زمان خود اثر انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | تاخیر قبل از پیشرفت خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این زمان‌سنج، `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) پاس دهید. |
| [setSpeed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitionspeed/) انتخاب می‌کند: Slow، Medium یا Fast. زمانی استفاده می‌شود که مدت زمان دقیق مشخص نشده باشد. |

[setDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setDuration-int-) فقط اثر انتقال را کنترل می‌کند؛ مدت زمان ماندن اسلاید روی صفحه را تعیین نمی‌کند. تاخیر پیشرفت خودکار را جداگانه تنظیم کنید. هنگامی که مدت زمان صریحی تنظیم نشود، Aspose.Slides مدت زمان اثر را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#getSpeed--) تعیین می‌کند.

### **اعمال همان مدت زمان به هر اسلاید**

برای حفظ ریتم ثابت، همان اثر و همان مدت زمان دقیق را به هر اسلاید اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitiontype/) انتخاب می‌کند و برای هر انتقال مدت زمان 750 میلی‌ثانیه اختصاص می‌دهد. به طور جداگانه پیشرفت خودکار را پس از 5 000 میلی‌ثانیه فعال می‌کند و پیشرفت با کلیک ماوس را غیرفعال می‌سازد، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // پیکربندی پیشرفت خودکار به طور مستقل از مدت زمان اثر.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تنظیم مدت‌های متفاوت برای اسلایدهای جداگانه**

اسلایدهای مختلف می‌توانند مدت زمان اثر متفاوتی داشته باشند. به عنوان مثال، برای اسلاید عنوان از یک انتقال کوتاه و برای معرفی بخش از یک انتقال طولانی‌تر استفاده کنید. این مثال برای اسلاید اول 500 میلی‌ثانیه و برای اسلاید دوم 1 200 میلی‌ثانیه تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

### **هماهنگی انتقال‌ها با خروجی انیمیشنی**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/java/export-to-html5/) یا [video](/slides/fa/java/convert-powerpoint-to-video/)، قبل از صادرات مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با ریتم مورد نظر هماهنگ باشد. به عنوان مثال، یک fade 600 میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به‌صورت جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن فراهم شود.

برای GIF و ویدئو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: 600 میلی‌ثانیه معادل 18 فریم با 30 فریم در ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات صادرات فعال کنید. تأثیرات پشتیبانی‌شده و گزینه‌های زمانی قالب خروجی را بررسی کنید و خروجی را پیش‌نمایش کنید تا همزمانی تأیید شود.

### **خواندن مدت زمان یک انتقال موجود**

قبل از تغییر انتقال، [getDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#getDuration--) را فراخوانی کنید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به معنی عدم تنظیم مدت زمان صریح است؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه نشان می‌دهد. مقدار تنظیم‌نشده همان مدت زمان محاسبه‌شده پخش نیست: Aspose.Slides از نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#getSpeed--) برای تعیین آن استفاده می‌کند. تنظیم نوع انتقال می‌تواند یک مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اولیه را بررسی کنید.

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

انتقال Morph تغییرات بین اشیاء اسلایدهای متوالی را انیمیشن می‌دهد. برای ایجاد یک اثر Morph ساده، یک اسلاید را کلون کنید، یک شیء را روی کلون جابجا یا اندازه‌اش را تغییر دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار به اشیاء مرتبط اجازه می‌دهد بین حالت اصلی و تغییر یافته خود انیمیشن شوند.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را روی کلون تغییر می‌دهد. سپس برای اسلاید دوم Morph را از شمارش‌نامه [TransitionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitiontype/) انتخاب می‌کند. فایل ذخیره‌شده را در یک برنامهٔ نمایش ارائه‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در طول نمایش اسلاید مشاهده کنید.

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

شمارش‌نامه [TransitionMorphType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitionmorphtype/) تعیین می‌کند Morph چگونه محتوا را مطابقت داده و انیمیشن می‌دهد:

- [ByObject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitionmorphtype/#ByObject) هر شکل را به عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات، در صورت امکان، انیمیشن می‌دهد.
- [ByChar](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق کاراکترها، در صورت امکان، انیمیشن می‌دهد.

قبل از دسترسی به [getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#getValue--) برای انتخاب Morph، از [setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setType-int-) استفاده کنید. مقدار سپس رابط [IMorphTransition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imorphtransition/) را فراهم می‌کند که متد [setMorphType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imorphtransition/#setMorphType-int-) حالت مطابقت را انتخاب می‌نماید.

این مثال ارائهٔ ساخته‌شده در بخش قبلی را باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph بر پایهٔ کلمه تنظیم می‌کند.

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

## **تنظیم اثرات انتقال**

برخی انتقال‌ها گزینه‌های اضافی مانند جهت یا این که اثر از صفحهٔ سیاه شروع شود را فراهم می‌کنند. گزینه‌های موجود به انتقال انتخاب‌شده با [setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setType-int-) بستگی دارد. ابتدا نوع را تنظیم کنید، سپس از رابط مناسب حاصل از [getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#getValue--) استفاده نمایید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از طریق [IOptionalBlackTransition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioptionalblacktransition/) متد [setFromBlack](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) را فراخوانی می‌کند تا انتقال از صفحهٔ سیاه شروع شود.

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

بله. زمانی که به مدت دقیق اثر به میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setDuration-int-) استفاده کنید. وقتی یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitionspeed/) (Slow، Medium یا Fast) کافی باشد و مدت زمان صریح تنظیم نشده باشد، از [setSpeed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) استفاده کنید. این تنظیمات اثر انتقال را مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال پیوست کنم و حلقه‌ای پخش شود؟**

بله. با [setSound](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) صدای جاسازی‌شده را اختصاص دهید، مقدار StartSound از شمارش‌نامه [TransitionSoundMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) پاس دهید و با `true` به [setSoundLoop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) فعال کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سرعت‌ترین روش برای اعمال یک انتقال یکسان به همه اسلایدها چیست؟**

در حلقه‌ای تمام اسلایدهای موجود در مجموعه‌ی [getSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlides--) ارائه را پیمایش کنید و برای هر اسلاید متد [setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#setType-int-) را با همان مقدار فراخوانی کنید. گزینه‌های زمان‌بندی و اثر را در همان حلقه تنظیم کنید تا رفتار در همه اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که در حال حاضر چه انتقالی روی یک اسلاید تنظیم شده است؟**

روی نتیجه‌ی [getSlideShowTransition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید، متد [getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideshowtransition/#getType--) را صدا بزنید. این متد مقداری از شمارش‌نامه [TransitionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitiontype/) برمی‌گرداند؛ None به معنی عدم اعمال هر اثر انتقالی است.