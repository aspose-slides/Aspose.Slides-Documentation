---
title: مدیریت انتقال اسلایدها در ارائه‌ها بر روی اندروید
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "انتقال‌های اسلاید را اعمال کنید، پیشرفت خودکار اسلایدها را پیکربندی کنید و با Aspose.Slides برای اندروید از طریق Java، مورف و سایر اثرهای انتقال را سفارشی‌سازی نمایید."
---
## **نمای کلی**

انتقالات اسلاید نحوه نمایش اسلایدها در یک نمایش اسلاید را کنترل می‌کند. با استفاده از Aspose.Slides برای Android از طریق Java، می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت اسلاید را با کلیک ماوس یا زمان‌سنج تنظیم کنید و گزینه‌های خاص یک اثر را تغییر دهید. این مقاله با مثال‌های Java نحوه اعمال انتقال‌ها، تنظیم دقیق زمان‌های انتقال، مدیریت زمان اسلاید و ایجاد انتقال Morph بین دو اسلاید را نشان می‌دهد. مثال‌ها همچنین نحوه ذخیره تنظیمات در فایل PPTX را نمایش می‌دهند.

## **اضافه کردن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) با مقداری از شمارش [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) استفاده کنید، سپس ارائه را ذخیره کنید.

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

## **Wheel Transition**

متد [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) از [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) تعداد بخش‌های شعاعی که اسلاید مقصد را آشکار می‌کنند تنظیم می‌کند. ابتدا نوع انتقال اسلاید را به Wheel از [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) با استفاده از [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) تنظیم کنید، سپس از [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) به عنوان [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) استفاده کنید.

این مثال دو جفت اسلاید مشابه ایجاد می‌کند: یک اسلاید سیاه و پس از آن اسلایدی با یک مستطیل طلائی. اسلایدهای مقصد از شمارش اسپوک ۱ و ۸ استفاده می‌کنند، با سرعت یکسان تنظیم شده توسط [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) و مدت زمان صریح ۸۰۰۰ میلی‌ثانیه که با [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) تنظیم شده تا تفاوت به راحتی قابل مشاهده باشد.

```java
import android.graphics.Color;
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
    int gold = Color.rgb(255, 215, 0);
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

خروجی را در PowerPoint باز کنید و نمایش اسلاید را اجرا کنید. از اسلاید ۱ به اسلاید ۲ پیش بروید، سپس از اسلاید ۳ به اسلاید ۴. در پخش PowerPoint، شمارش اسپوک ۱ اسلاید را با یک حرکت ساعت‌گرد نشان می‌دهد؛ شمارش ۸ اسلاید را با هشت بخش شعاعی به‌صورت همزمان نشان می‌دهد. محتویات مقصد و زمان‌بندی انتقال یکسان‌اند، پس تفاوت فقط در تعداد بخش‌های آشکارسازی است.

## **Fade Through Black with the Reveal Transition**

نوع انتقال اسلاید مقصد را به Reveal تنظیم کنید، سپس متد [setThroughBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) را بر روی تنظیمات [IRevealTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/) آن صدا بزنید. مثال یک اسلاید منبع فیروزه‌ای و یک اسلاید مقصد مرجانی ایجاد می‌کند، سپس هر دو را کلون می‌کند. هر جفت از همان انتقال Reveal دو ثانیه‌ای استفاده می‌کند. فقط جفت دوم از طریق سیاه محو می‌شود.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    int[] backgrounds = { Color.rgb(0, 128, 128), Color.rgb(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پرزنتیشن ذخیره شده را در PowerPoint باز کنید و نمایش اسلاید را شروع کنید. از اسلاید ۱ به اسلاید ۲ پیش بروید تا فیروزه‌ای مستقیماً به مرجانی محو شود. سپس از اسلاید ۳ به اسلاید ۴ بروید. صفحه به‌طور موقت تقریباً به‌سیاه می‌شود قبل از اینکه اسلاید مرجانی ظاهر شود. هر دو اسلاید پس‌زمینه اصلی خود را حفظ می‌کنند.

رودرهای زیر فریم‌های PowerPoint را در فواصل نیم‌ثانیه نشان می‌دهند. برای دیدن اثر، فریم میانی هر ردیف را با هم مقایسه کنید.

![پخش PowerPoint با حذف محو شدن به‌سیاه (بالا) و فعال شدن آن (پایین). فقط ردیف پایین از نزدیک به‌سیاه می‌گذرد.](reveal-through-black.png)

## **Add Advanced Slide Transition**

می‌توانید مدت زمان نمایش اسلاید بر روی صفحه و اینکه آیا کلیک ماوس پیشرفت نمایش اسلاید را انجام می‌دهد تنظیم کنید. متدهای زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) امکان پیشرفت با کلیک ماوس را می‌دهد.
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) پیشرفت خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) تاخیر پیشرفت خودکار را بر حسب میلی‌ثانیه مشخص می‌نماید.

هر دو پیشرفت کلیک و زمانی را فعال کنید تا بیننده بتواند با کلیک یا انتظار برای زمان‌سنج به اسلاید بعدی برود. برای استفاده فقط از زمان‌سنج، مقدار `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) بدهید. تاخیر زمان پیشرفته را کنترل می‌کند؛ این مقدار مدت زمان اثر بصری انتقال را تنظیم نمی‌کند.

این مثال اثرهای مختلف را به سه اسلاید اول اختصاص می‌دهد و پس از ۳، ۵ و ۷ ثانیه به‌صورت خودکار پیشرفت را فعال می‌کند. کلیک ماوس نیز می‌تواند این اسلایدها را پیش ببرد. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

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

برای بررسی اینکه آیا پیشرفت زمان‌دار فعال است یا نه، متد [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) را صدا بزنید. تنها داشتن مقدار تاخیر نشان‌دهنده فعال بودن تایمر نیست.

مثال بعدی فایل ذخیره‌شده در بالا را باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای همان اسلایدها کلیک ماوس را فعال می‌کند و تنظیمات به‌روز شده را ذخیره می‌نماید.

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

## **Control Transition Timing Precisely**

از [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) برای تعیین دقیق طول یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید این تنظیمات را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/) نمایان می‌سازد:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | مدت زمان خود اثر انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | تاخیر پیشرفت خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال کردن این زمان‌سنج، مقدار `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) بدهید. |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | یک دسته سرعت از قبل تعریف‌شده در [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) (Slow, Medium یا Fast) انتخاب می‌کند. زمانی که مدت زمان صریحی مشخص نشده باشد استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) فقط بر اثر انتقال تأثیر می‌گذارد؛ مدت زمان نمایش اسلاید را تعیین نمی‌کند. تاخیر پیشرفت خودکار را جداگانه تنظیم کنید. وقتی مدت زمان صریحی تنظیم نشده باشد، Aspose.Slides مدت زمان اثر را از نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) محاسبه می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![نوارهای جداگانه مدت زمان انتقال ۷۵۰ ms و تنظیم پیشرفت خودکار ۵۰۰۰ ms را نشان می‌دهند.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*مثال مشترک برای هر اسلاید یک انتقال Fade ۷۵۰ ms اعمال می‌کند و پیشرفت خودکار ۵۰۰۰ ms را به‌صورت جداگانه فعال می‌سازد. مدت زمان انتقال فقط اثر را کنترل می‌کند؛ پیشرفت زمان خروج از اسلاید را. این نوارها تنظیمات شماتیک هستند، نه یک جدول زمان‌بندی ترکیبی دقیق.*
<!-- visual-explanation:slide-transition:end -->

### **Apply the Same Duration to Every Slide**

برای حفظ سرعت ثابت، همان اثر و مدت زمان دقیق را به تمام اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت ۷۵۰ میلی‌ثانیه می‌دهد. پیشرفت خودکار را پس از ۵۰۰۰ میلی‌ثانیه فعال می‌کند و پیشرفت با کلیک ماوس را غیرفعال می‌نماید، سپس نتیجه را به‌صورت PPTX ذخیره می‌کند.

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

### **Set Different Durations for Individual Slides**

اسلایدهای مختلف می‌توانند مدت زمان اثر متفاوتی داشته باشند. به‌عنوان مثال، برای اسلاید عنوان یک انتقال کوتاه و برای اسلاید معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه برای اسلاید اول و ۱۲۰۰ میلی‌ثانیه برای اسلاید دوم تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

### **Coordinate Transitions with Animated Output**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/androidjava/convert-powerpoint-to-animated-gif/)، یک [HTML5 presentation](/slides/fa/androidjava/export-to-html5/) یا یک [video](/slides/fa/androidjava/convert-powerpoint-to-video/)، مدت زمان دقیق انتقال‌ها را پیش از خروجی‌گیری تنظیم کنید تا با ریتم موردنظر مطابقت داشته باشد. به‌عنوان مثال، یک محو شدن ۶۰۰ میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به‌صورت جداگانه تنظیم کنید تا زمان کافی برای گفتار یا محتوا فراهم شود.

برای GIF و ویدئو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: ۶۰۰ میلی‌ثانیه برابر با ۱۸ فریم در ۳۰ فریم بر ثانیه است. در HTML5، انتقال‌های متحرک را در تنظیمات خروجی فعال کنید. فرمت خروجی انتخابی خود را برای پشتیبانی از اثرها و گزینه‌های زمان‌بندی بررسی کنید و خروجی را پیش‌نمایش کنید تا همزمانی را تأیید نمایید.

### **Read an Existing Transition Duration**

قبل از تغییر انتقال، متد [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) را صدا بزنید تا مشخص شود آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به معنای عدم تنظیم مدت زمان صریح است؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه نشان می‌دهد. این مقدار تنظیم‌شده با مدت زمان پخش محاسبه‌شده متفاوت است: Aspose.Slides مدت زمان را بر پایه نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) محاسبه می‌کند. تنظیم نوع انتقال می‌تواند مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

## **Morph Transition**

انتقال Morph تغییرات بین اشیاء در اسلایدهای متوالی را به‌صورت انیمیشن نشان می‌دهد. برای ایجاد یک اثر Morph ساده، یک اسلاید را کلون کنید، موقعیت یا اندازه یک شیء را در کلون تغییر دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار به‌صورت خودکار اشیائی که باید بین حالت اصلی و تغییر یافته انیمیشن شوند، مطابقت می‌دهد.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در نسخه کلون شده تغییر می‌دهد. سپس برای اسلاید دوم Morph را از شمارش [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایشگر ارائه که از Morph پشتیبانی می‌کند باز کنید تا اثر را در طول نمایش اسلاید مشاهده کنید.

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

## **Morph Transition Types**

شمارش [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) نحوه مطابقت و انیمیشن محتوا را در Morph تعیین می‌کند:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) هر شکل را به‌عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات (در صورت امکان) انیمیشن می‌کند.
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق کاراکترها (در صورت امکان) انیمیشن می‌کند.

از [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) برای انتخاب Morph قبل از دسترسی به [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) استفاده کنید. سپس مقدار بازگشتی این متد رابط [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/) را می‌دهد که با متد [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) حالت مطابقت را انتخاب می‌کند.

این مثال ارائه‌ای که در بخش قبلی ایجاد شد را باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph مبتنی بر کلمه تنظیم می‌کند.

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

## **Set Transition Effects**

برخی انتقال‌ها گزینه‌های اضافی مانند جهت یا اینکه اثر از صفحه سیاه شروع شود را افشا می‌کنند. گزینه‌های موجود بستگی به انتقال انتخاب‌شده با [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) دارد. ابتدا نوع را تنظیم کنید، سپس از رابط مناسب از طریق [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. با استفاده از [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) از طریق [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) تنظیم می‌شود تا انتقال از صفحه سیاه آغاز شود.

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

## **FAQ**

**آیا می‌توان سرعت پخش یک انتقال اسلاید را کنترل کرد؟**

بله. وقتی به مدت زمان دقیق اثر بر حسب میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) استفاده کنید. وقتی یک دسته سرعت پیش‌تعریف‌شده در [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) (Slow, Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده، از [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) استفاده کنید. این تنظیمات اثر انتقال را مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توان صدا را به یک انتقال پیوست کرد و حلقه‌دار کرد؟**

بله. صداهای جاسازی‌شده را با [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) انتساب دهید، حالت شروع صدا را از شمارش [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) با مقدار StartSound به [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) بدهید و با [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) مقدار `true` را تنظیم کنید. صدا تا رویداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سریع‌ترین راه برای اعمال همان انتقال به تمام اسلایدها چیست؟**

در حلقه‌ای بر روی مجموعه [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) ارائه پیمایش کنید و برای هر اسلاید متد [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) را با همان مقدار صدا بزنید. هر تنظیم زمان‌بندی و گزینه اثر را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

متد [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) را بر روی نتیجه [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید صدا بزنید. این متد مقداری از شمارش [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) برمی‌گرداند؛ مقدار None به این معنی است که هیچ اثر انتقالی اعمال نشده است.