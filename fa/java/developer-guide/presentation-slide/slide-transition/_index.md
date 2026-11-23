---
title: مدیریت انتقال اسلایدها در ارائه‌ها با استفاده از Java
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/java/slide-transition/
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
- Java
- Aspose.Slides
description: "اعمال انتقال اسلایدها، پیکربندی پیشرفت خودکار اسلاید و سفارشی‌سازی انتقال‌های Morph و سایر افکت‌های انتقال با Aspose.Slides برای Java."
---
## **بررسی اجمالی**

انتقالات اسلاید کنترل می‌کند که اسلایدها در حین نمایش اسلاید چگونه ظاهر شوند. با Aspose.Slides برای Java، می‌توانید یک اثر انتقال برای هر اسلاید انتخاب کنید، پیشرفت را با کلیک ماوس یا تایمر تنظیم کنید و گزینه‌های خاص هر اثر را تنظیم نمایید. این مقاله از مثال‌های Java برای اعمال انتقال‌ها، تنظیم دقیق مدت زمان انتقال، مدیریت زمان‌بندی اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند که چگونه تنظیمات را در فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید و به تنظیمات انتقال اسلاید از طریق [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) با مقدار از شمارشگر [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) استفاده کنید و سپس ارائه را ذخیره کنید.

مثال زیر انتقال Circle را به اولین اسلاید و انتقال Comb را به دومین اسلاید اعمال می‌کند. از یک فایل `input.pptx` که حداقل شامل دو اسلاید است استفاده کنید.

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

## **انتقال Wheel**

متد [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) از [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) تعداد بخش‌های شعاعی که اسلاید مقصد را نشان می‌دهند، کنترل می‌کند. نوع انتقال اسلاید را به Wheel از [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) با استفاده از [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) تنظیم کنید، سپس قبل از دسترسی به [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) به عنوان [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) اقدام کنید.

این مثال دو جفت اسلاید یکسان ایجاد می‌کند: یک اسلاید سیاه به دنبال اسلایدی با یک مستطیل طلایی. اسلایدهای مقصد از تعداد 1 و 8 شعاع استفاده می‌کنند، با همان سرعت که از طریق [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) تنظیم شده و مدت زمان صریح 8 000 میلی‌ثانیه از طریق [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) برای مشاهده واضح تفاوت تنظیم می‌شود.

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

نمایش ارائه خروجی در PowerPoint را باز کنید و اسلاید شو را اجرا کنید. از اسلاید 1 به اسلاید 2 پیش بروید، سپس از اسلاید 3 به اسلاید 4. در پخش PowerPoint، تعداد 1 شعاع باعث می‌شود اسلاید با یک حرکت ساعتگرد آشکار شود؛ تعداد 8 شعاع اسلاید را همزمان از طریق هشت بخش شعاعی نشان می‌دهد. محتوا و زمان‌بندی انتقال مقصد یکسان هستند، بنابراین تفاوت تنها در تعداد بخش‌های آشکارسازی است.

## **Fade Through Black با انتقال Reveal**

نوع انتقال اسلاید مقصد را به Reveal تنظیم کنید، سپس متد [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) را بر روی تنظیمات [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/) فراخوانی کنید. مثال یک اسلاید مبدا به رنگ فیروزه‌ای و یک اسلاید مقصد به رنگ مرجانی ایجاد می‌کند، سپس هر دو را کلون می‌گیرد. هر جفت از همان انتقال Reveal دو ثانیه‌ای استفاده می‌کند. فقط جفت دوم از طریق سیاه محو می‌شود.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
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

پرزنتیشن ذخیره‌شده را در PowerPoint باز کنید و اسلاید شو را آغاز کنید. از اسلاید 1 به اسلاید 2 پیش بروید تا تغییر رنگ فیروزه‌ای مستقیم به مرجانی را ببینید. سپس از اسلاید 3 به اسلاید 4 پیش بروید. صفحه به‌ طور موقت تقریباً سیاه می‌شود قبل از اینکه اسلاید مرجانی ظاهر شود. هر دو اسلاید پس‌زمینه اصلی خود را حفظ می‌کنند.

ردیف‌های زیر فریم‌های PowerPoint را در فواصل نیم‌ثانیه نشان می‌دهند. برای مشاهده اثر، فریم میانی هر ردیف را با هم مقایسه کنید.

![نوارهای جداگانه مدت زمان انتقال ۷۵۰‑ms و تنظیم پیشرفت خودکار ۵,۰۰۰‑ms را شناسایی می‌کنند.](reveal-through-black.png)

## **افزودن انتقال اسلاید پیشرفته**

می‌توانید زمان ماندن اسلاید روی صفحه و این که آیا کلیک ماوس اسلاید شو را پیش می‌برد یا نه را تنظیم کنید. متدهای زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) اجازه می‌دهد کاربر با کلیک ماوس پیش برود.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) پیشرفت خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) تاخیر پیشرفت خودکار را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشرفت کلیک و زمان‌دار را فعال کنید تا کاربر بتواند با کلیک یا انتظار برای تایمر ادامه دهد. برای استفاده فقط از تایمر، `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) پاس بدهید. تاخیر زمان پیشرفت را کنترل می‌کند؛ این مقدار زمان نمایش اثر بصری را تعیین نمی‌کند.

این مثال اثرهای مختلف را به اولین سه اسلاید اختصاص می‌دهد و پیشرفت خودکار را پس از 3، 5 و 7 ثانیه به ترتیب فعال می‌کند. کلیک ماوس نیز می‌تواند این اسلایدها را پیش ببرد. از یک فایل `input.pptx` که حداقل شامل سه اسلاید است استفاده کنید.

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

برای بررسی فعال بودن پیشرفت زمان‌دار، متد [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) را فراخوانی کنید. وجود یک تاخیر ذخیره‌شده لزوماً نشان‌دهنده فعال بودن تایمر نیست.

مثال بعدی فایلی را که در بالا ذخیره شد باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس فعال می‌شود و تنظیمات به‌روزشده ذخیره می‌شوند.

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

از [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) برای تعیین دقیق طول یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید این تنظیمات را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) در اختیار می‌گذارد:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | مدت زمان اثر انتقال را به میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | تاخیر پیشرفت خودکار اسلاید را به میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این تایمر، `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) بدهید. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | یک دسته سرعت پیش‌فرض از [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium یا Fast را انتخاب می‌کند. زمانی که مدت زمان دقیقی تعیین نشده باشد استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) فقط اثر انتقال را کنترل می‌کند؛ این مقدار طول ماندن اسلاید روی صفحه را تعیین نمی‌کند. تاخیر پیشرفت خودکار را به‌ طور جداگانه تنظیم کنید. وقتی هیچ مدت زمان صریحی تنظیم نشود، Aspose.Slides مدت زمان اثر را بر پایه نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) تعیین می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![نوارهای جداگانه مدت زمان انتقال ۷۵۰‑ms و تنظیم پیشرفت خودکار ۵,۰۰۰‑ms را شناسایی می‌کنند.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*مثال مشترک برای هر اسلاید یک انتقال Fade به مدت ۷۵۰ ms اعمال می‌کند و به‌ طور جداگانه پیشرفت خودکار را بعد از ۵,۰۰۰ ms فعال می‌کند. مدت زمان انتقال فقط اثر را کنترل می‌کند؛ پیشرفت زمان خروج از اسلاید را تنظیم می‌کند. این نوارها تنظیمات شماتیک هستند، نه یک خط زمانی ترکیبی اندازه‌گیری‌شده.* 
<!-- visual-explanation:slide-transition:end -->

### **اعمال همان مدت زمان به همه اسلایدها**

برای حفظ ریتم یکنواخت، همان اثر و همان مدت زمان دقیق را به همه اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت زمان 750 میلی‌ثانیه می‌دهد. پیشرفت خودکار را بعد از 5 000 میلی‌ثانیه فعال کرده و پیشرفت توسط کلیک ماوس را غیرفعال می‌کند، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

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

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای جداگانه**

اسلایدهای مختلف می‌توانند مدت زمان اثر متفاوت داشته باشند. برای مثال، یک انتقال کوتاه برای اسلاید عنوان و یک انتقال طولانی‌تر برای معرفی بخش. این مثال 500 میلی‌ثانیه برای اسلاید اول و 1 200 میلی‌ثانیه برای اسلاید دوم تنظیم می‌کند. از یک فایل `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

هنگام آماده‌سازی یک [animated GIF](/slides/fa/java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/java/export-to-html5/)، یا [video](/slides/fa/java/convert-powerpoint-to-video/)، مدت زمان دقیق انتقال‌ها را قبل از خروجی تنظیم کنید تا با ریتم موردنظر همخوانی داشته باشد. برای مثال، یک محو 600 میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به‌ طور جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن داشته باشید.

برای GIF و ویدئو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: 600 میلی‌ثانیه معادل 18 فریم در سرعت 30 فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. گزینه‌های پشتیبانی‌شده توسط قالب خروجی را بررسی کنید و خروجی را پیش‌نمایش کنید تا هماهنگی تأیید شود.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، متد [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) را فراخوانی کنید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معنی است که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را به میلی‌ثانیه نشان می‌دهد. مقدار تنظیم‌نشده برابر با مدت زمان محاسبه‌شده پخش نیست: Aspose.Slides مدت زمان را بر پایه نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) تعیین می‌کند. تنظیم نوع انتقال می‌تواند یک مدت زمان اولیه ایجاد کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

انتقال Morph تغییرات بین اشیا را در اسلایدهای متوالی انیمیشن می‌کند. برای ایجاد یک اثر ساده Morph، یک اسلاید را کلون کنید، یک شیء را روی کلون جابجا یا تغییر اندازه دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار اشیاء مربوطه را بین حالت اصلی و تغییر یافته انیمیشن می‌دهد.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در کلون تغییر می‌دهد. سپس Morph را از شمارشگر [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) برای اسلاید دوم انتخاب می‌کند. فایل ذخیره‌شده را در یک برنامه نمایش ارائه که از Morph پشتیبانی می‌کند باز کنید تا اثر را در طول اسلاید شو ببینید.

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

شمارشگر [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) تعیین می‌کند Morph چگونه محتوا را مطابقت داده و انیمیشن می‌کند:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) هر شکل را به عنوان یک شیء کلی در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات (در صورت امکان) انیمیشن می‌کند.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق حروف (در صورت امکان) انیمیشن می‌کند.

از [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) برای انتخاب Morph قبل از دسترسی به [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) استفاده کنید. سپس مقدار به رابط [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) باز می‌گردد که متد [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) مود مطابقت را انتخاب می‌کند.

این مثال ارائه‌ای را که در بخش قبلی ایجاد شد باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph بر مبنای کلمه تنظیم می‌کند.

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

برخی انتقال‌ها گزینه‌های اضافی مانند جهت یا این که اثر از صفحه سیاه شروع شود را نمایان می‌کنند. گزینه‌های در دسترس به انتقال انتخاب‌شده با [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) بستگی دارد. ابتدا نوع را تنظیم کنید، سپس از رابط مناسب از طریق [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) استفاده کنید.

مثال زیر یک انتقال Cut را به اولین اسلاید `input.pptx` اعمال می‌کند. از طریق [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) متد [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) را فراخوانی می‌کند تا انتقال از صفحه سیاه شروع شود.

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

بله. وقتی به مدت زمان دقیق اثر به میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) استفاده کنید. وقتی یک دسته سرعت پیش‌فرض از [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) (Slow, Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده، از [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) استفاده کنید. این تنظیمات اثر انتقال را به‌ طور مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال پیوست کنم و حلقه‌ای پخش کنم؟**

بله. صدا داخلی را با [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) اختصاص دهید، مقدار StartSound از شمارشگر [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) بدهید و با `true` متد [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) را فعال کنید. صدا تا رویداد صوتی بعدی در اسلاید شو حلقه می‌زند.

**سریع‌ترین راه برای اعمال یک انتقال یکسان به همه اسلایدها چیست؟**

از حلقه‌ای برای پیمایش مجموعه [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) ارائه استفاده کنید و برای هر اسلاید متد [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) را با همان مقدار فراخوانی کنید. هر تنظیم زمان و اثر را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که در حال حاضر چه انتقالی بر روی یک اسلاید تنظیم شده است؟**

متد [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) را بر روی نتیجه [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید فراخوانی کنید. این مقدار از شمارشگر [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) باز می‌گردد؛ مقدار None نشان می‌دهد هیچ اثر انتقالی اعمال نشده است.