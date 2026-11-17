---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها با استفاده از Java
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/java/slide-transition/
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
- Java
- Aspose.Slides
description: "انتقال‌های اسلاید را اعمال کنید، پیشرفت خودکار اسلایدها را تنظیم کنید و اثرات Morph و سایر اثرات انتقال را با Aspose.Slides برای Java سفارشی کنید."
---
## **بررسی کلی**

انتقال‌های اسلاید کنترل می‌کنند که اسلایدها در طول یک نمایش اسلاید چگونه ظاهر می‌شوند. با Aspose.Slides برای Java، می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت را با کلیک موس یا زمان‌سنج پیکربندی کنید و گزینه‌های خاص هر اثر را تنظیم کنید. این مقاله با استفاده از مثال‌های Java، انتقال‌ها را اعمال می‌کند، مدت زمان دقیق انتقال‌ها را تنظیم می‌کند، زمان‌بندی اسلایدها را مدیریت می‌کند و یک انتقال Morph بین دو اسلاید ایجاد می‌کند. مثال‌ها همچنین نشان می‌دهند چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) دسترسی پیدا کنید. با استفاده از [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) و مقدار از شمارش [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) یک مقدار تنظیم کنید، سپس ارائه را ذخیره کنید.

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

## **انتقال چرخ**

متد [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) از [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) تعداد بخش‌های شعاعی که اسلاید مقصد را افشا می‌کند، کنترل می‌کند. نوع انتقال اسلاید را به Wheel از [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) با استفاده از [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) تنظیم کنید، سپس قبل از دسترسی به [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) به عنوان [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) فراخوانی کنید.

این مثال دو جفت اسلاید مشابه ایجاد می‌کند: یک اسلاید سیاه به دنبال اسلایدی با مستطیل طلایی. اسلایدهای مقصد از شمارش گوشه‌های 1 و 8 استفاده می‌کنند، با سرعت یکسان تنظیم شده از طریق [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) و مدت زمان صریح 8 000 میلی‌ثانیه تنظیم شده از طریق [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) تا تفاوت به‌راحتی قابل مشاهده باشد.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پیشنمایش ارائه خروجی را در PowerPoint باز کنید و نمایش اسلایدها را اجرا کنید. از اسلاید 1 به اسلاید 2 پیش بروید، سپس از اسلاید 3 به اسلاید 4. در پخش PowerPoint، شمارش 1 تایید شده اسلاید را با یک چرخش ساعتگرد نشان می‌دهد؛ شمارش 8 تأیید شده اسلاید را همزمان از طریق هشت بخش شعاعی افشا می‌کند. محتوا و زمان‌بندی انتقال مقصد یکسان است، بنابراین تفاوت فقط در تعداد بخش‌های افشا است.

## **افزودن انتقال اسلاید پیشرفته**

می‌توانید مدت زمان ماندن یک اسلاید روی صفحه و این‌که آیا کلیک ماوس نمایش اسلاید را پیش می‌برد تنظیم کنید. روش‌های زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) اجازه می‌دهد بیننده با کلیک ماوس پیش برود.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) پیشرفت خودکار را فعال می‌سازد.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) تاخیر پیش از پیشرفت خودکار را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشرفت کلیک و زمان‌دار را فعال کنید تا بیننده بتواند با کلیک یا انتظار برای زمان‌سنج ادامه دهد. برای استفاده فقط از زمان‌سنج، `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) بدهید. تاخیر زمان‌سنج زمانی که نمایش اسلایدها پیش می‌رود را کنترل می‌کند؛ این مقدار زمان اثر بصری انتقال را تعیین نمی‌کند.

این مثال اثرهای مختلف را به سه اسلاید اول تخصیص می‌دهد و پیشرفت خودکار را پس از 3، 5 و 7 ثانیه به ترتیب فعال می‌کند. کلیک ماوس نیز می‌تواند این اسلایدها را پیش ببرد. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

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

برای بررسی اینکه آیا پیشرفت زمان‌دار فعال است یا نه، [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) را فراخوانی کنید. یک تاخیر ذخیره‌شده به تنهایی نشان‌دهندۀ فعال بودن زمان‌سنج نیست.

مثال بعدی فایلی که در بالا ذخیره شد را باز می‌کند، هر زمان‌سنج فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس فعال می‌شود و تنظیمات به‌روزرسانی‌شده ذخیره می‌شود.

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

از [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) برای تعیین طول دقیق یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید این تنظیمات را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) ارائه می‌دهد:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | مدت زمان اثر انتقال را خود به میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | تاخیر پیش از پیشرفت خودکار اسلاید را به میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این زمان‌سنج، `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) بدهید. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | یک دسته سرعت پیش‌فرض را از [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) انتخاب می‌کند: Slow, Medium یا Fast. وقتی مدت زمان دقیق تعیین نشده باشد، استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) فقط اثر انتقال را کنترل می‌کند؛ مدت زمان ماندن اسلاید روی صفحه را تعیین نمی‌کند. تاخیر پیشرفت خودکار را جداگانه تنظیم کنید. وقتی مدت زمان صریحی تعیین نشده باشد، Aspose.Slides مدت زمان اثر را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) محاسبه می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **اعمال همان مدت زمان به هر اسلاید**

برای حفظ سرعت یکنواخت، همان اثر و مدت زمان دقیق را بر تمام اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت 750 میلی‌ثانیه می‌دهد. به‌طور جداگانه پیشرفت خودکار را پس از 5 000 میلی‌ثانیه فعال می‌کند و پیشرفت با کلیک ماوس را غیرفعال می‌سازد، سپس نتیجه را به‌صورت PPTX ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // پیکربندی پیشرفت خودکار به صورت مستقل از مدت زمان اثر.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تنظیم مدت زمان‌های مختلف برای اسلایدهای جداگانه**

اسلایدهای مختلف می‌توانند مدت زمان اثر متفاوت داشته باشند. به‌عنوان مثال، برای اسلاید عنوان یک انتقال کوتاه و برای اسلاید معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال مدت 500 میلی‌ثانیه را برای اسلاید اول و 1 200 میلی‌ثانیه را برای اسلاید دوم تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

هنگام آماده‌سازی یک [animated GIF](/slides/fa/java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/java/export-to-html5/)، یا [video](/slides/fa/java/convert-powerpoint-to-video/)، مدت زمان دقیق انتقال‌ها را پیش از خروجی تنظیم کنید تا با سرعت هدف هماهنگ شود. به‌عنوان مثال، یک تا‌ن‌سونی 600 میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن فراهم شود.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت اثر هماهنگ کنید: 600 میلی‌ثانیه معادل 18 فریم در 30 فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. قالب خروجی انتخاب‌شده را برای اثرات و گزینه‌های زمان‌بندی پشتیبانی‌شده بررسی کنید و پیش‌نمایش خروجی را برای تأیید همگام‌سازی انجام دهید.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) را فراخوانی کنید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معناست که مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه نشان می‌دهد. این مقدار تنظیم نشده محاسبه‌شده برای پخش نیست: Aspose.Slides مدت زمان را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) تعیین می‌کند. تنظیم نوع انتقال می‌تواند یک مدت زمان اولیه ایجاد کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

انتقال Morph تغییرات بین اشیاء روی اسلایدهای متوالی را انیمیشن می‌کند. برای ایجاد یک اثر ساده Morph، یک اسلاید را کلون کنید، یک شی را روی کلون جابه‌جا یا تغییر اندازه دهید و overgang Morph را به اسلاید دوم اعمال کنید. این کار به اشیاء مربوطه اجازه می‌دهد بین حالت اصلی و حالت تغییر یافته انیمیشن شوند.

مثال زیر یک اسلاید با مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را روی کلون تغییر می‌دهد. سپس Morph را از شمارش [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) برای اسلاید دوم انتخاب می‌کند. فایل ذخیره‌شده را در یک مرورگر ارائه‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در زمان نمایش اسلاید ببینید.

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

شمارش [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) نحوه تطبیق و انیمیشن محتوای Morph را کنترل می‌کند:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) هر شکل را به‌عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات (در صورت امکان) انیمیشن می‌کند.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق حروف (در صورت امکان) انیمیشن می‌کند.

از [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) برای انتخاب Morph قبل از دسترسی به [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) استفاده کنید. مقدار سپس رابط [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) را فراهم می‌کند که متد [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) حالت مطابقت را انتخاب می‌کند.

این مثال ارائه‌ای که در بخش قبلی ساخته شد را باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph مبتنی بر کلمه تنظیم می‌کند.

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

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا این‌که اثر از صفحه سیاه شروع شود را در اختیار می‌گذارند. گزینه‌های موجود بستگی به انتقالی دارد که با [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) انتخاب شده است. ابتدا نوع را تنظیم کنید، سپس رابط مناسب را از طریق [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از طریق [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) متد [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) را فراخوانی می‌کند تا انتقال از صفحه سیاه شروع شود.

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

## **سوالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. هنگام نیاز به مدت زمان دقیق اثر به میلی‌ثانیه، از [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) استفاده کنید. وقتی یک دسته سرعت پیش‌فرض از [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) (Slow, Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده است، از [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) استفاده کنید. این تنظیمات اثر انتقال را به‌طور مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صوتی به یک انتقال وصل کنم و حلقه‌ای پخش شود؟**

بله. صوت تعبیه‌شده را با [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) انتساب دهید، حالت StartSound را از شمارش [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) به [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) بدهید و با `true` به [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) فعال کنید. صدا تا رویداد صوتی بعدی در نمایش اسلایدها حلقه می‌شود.

**سریع‌ترین راه برای اعمال یک انتقال یکسان به همه اسلایدها چیست؟**

در حلقه‌ای بر روی مجموعه [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) ارائه پیمایش کنید و برای هر اسلاید متد [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) را با همان مقدار صدا بزنید. هر تنظیم زمان‌بندی و گزینه اثر را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

روی نتیجه [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید، متد [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) را فراخوانی کنید. این مقدار از شمارش [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) برمی‌گردد؛ مقدار None به این معناست که هیچ اثر انتقالی اعمال نشده است.