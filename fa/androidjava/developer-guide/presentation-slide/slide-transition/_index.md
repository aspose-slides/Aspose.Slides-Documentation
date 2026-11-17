---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها در اندروید
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
description: "انتقال اسلایدها را اعمال کنید، پیشرفت خودکار اسلاید را پیکربندی کنید و اثرات Morph و سایر افکت‌های انتقال را با Aspose.Slides برای Android از طریق Java سفارشی کنید."
---
## **بررسی کلی**

انتقال‌های اسلاید تعیین می‌کنند اسلایدها در حین نمایش اسلاید چگونه ظاهر می‌شوند. با Aspose.Slides برای Android از طریق Java، می‌توانید برای هر اسلاید یک افکت انتقال انتخاب کنید، پیشرفت را با کلیک ماوس یا زمان‌سنج تنظیم کنید و گزینه‌های خاص افکت را تنظیم نمایید. این مقاله از مثال‌های Java برای اعمال انتقال‌ها، تنظیم دقیق زمان‌بندی انتقال، مدیریت زمان اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند چگونه تنظیمات را در فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بارگذاری کنید و به تنظیمات انتقال اسلاید از طریق [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) با مقدار از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) استفاده کنید، سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را برای اولین اسلاید و یک انتقال Comb را برای دومین اسلاید اعمال می‌کند. از فایلی به نام `input.pptx` با حداقل دو اسلاید استفاده کنید.

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

## **انتقال چرخ‌دار**

متد [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) از [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) تعداد بخش‌های شعاعی که اسلاید مقصد را نشان می‌دهند کنترل می‌کند. پیش از دسترسی به [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) به عنوان [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/)، نوع انتقال اسلاید را به Wheel از [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) با استفاده از [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) تنظیم کنید.

این مثال دو جفت اسلاید یکسان ایجاد می‌کند: یک اسلاید سیاه به دنبال اسلایدی با یک مستطیل طلایی. اسلایدهای مقصد از تعداد ستون‌های ۱ و ۸ استفاده می‌کنند، با سرعت یکسان تنظیم‌شده از طریق [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) و مدت زمان صریح ۸٬۰۰۰ میلی‌ثانیه تنظیم‌شده از طریق [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) تا تفاوت به راحتی قابل مشاهده باشد.

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

خروجی ارائه را در PowerPoint باز کنید و نمایش اسلاید را اجرا کنید. از اسلاید ۱ به اسلاید ۲، سپس از اسلاید ۳ به اسلاید ۴ پیش بروید. در پخش PowerPoint، شمارش ستون ۱ اسلاید را با یک اسکن ساعت‌گرد نشان می‌دهد؛ شمارش ۸ اسلاید را همزمان با هشت بخش شعاعی نشان می‌دهد. محتوا و زمان‌بندی انتقال مقصد یکسان است، بنابراین تفاوت فقط در تعداد بخش‌های نمایش است.

## **افزودن انتقال پیشرفته اسلاید**

می‌توانید مدت زمان حضور اسلاید روی صفحه و این‌که آیا کلیک ماوس نمایش اسلاید را پیش می‌برد تنظیم کنید. روش‌های زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) اجازه می‌دهد بیننده با کلیک ماوس پیش برود.
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) پیشرفت خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) تاخیر پیشرفت خودکار را به میلی‌ثانیه تعیین می‌کند.

هر دو پیشرفت کلیک و زمان‌دار را فعال کنید تا بیننده یا با کلیک یا با انتظار برای زمان‌سنج ادامه دهد. برای استفاده فقط از زمان‌سنج، مقدار `false` را به [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) بدهید. تاخیر زمان پیشرفت را تعیین می‌کند؛ مدت زمان افکت بصری را تنظیم نمی‌کند.

این مثال افکت‌های مختلفی را به سه اسلاید اول اختصاص می‌دهد و پیشرفت خودکار را پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک ماوس نیز می‌تواند این اسلایدها را پیش ببرد. از فایلی به نام `input.pptx` با حداقل سه اسلاید استفاده کنید.

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

برای بررسی این‌که پیشرفت زمان‌دار فعال است یا نه، متد [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) را صدا بزنید. فقط ذخیره شدن تاخیر نشان‌دهندۀ فعال بودن زمان‌سنج نیست.

مثال بعدی فایلی که در بالا ذخیره شد را باز می‌کند، هر زمان‌سنج فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس فعال می‌شود و تنظیمات به‌روز ذخیره می‌شود.

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

از [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) برای تعیین دقیق طول یک افکت انتقال به میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید این تنظیمات را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/) در اختیار می‌گذارد:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | مدت زمان خود افکت انتقال را به میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | تاخیر پیشرفت خودکار اسلاید را به میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این زمان‌سنج، مقدار `true` را به [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) بدهید. |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) (Slow, Medium یا Fast) را انتخاب می‌کند. وقتی مدت زمان صریح تعیین نشده باشد، استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) فقط افکت انتقال را کنترل می‌کند؛ مدت زمان باقی ماندن اسلاید روی صفحه را تعیین نمی‌کند. تاخیر پیشرفت خودکار را جداگانه تنظیم کنید. وقتی مدت زمان صریح تنظیم نشده باشد، Aspose.Slides مدت زمان افکت را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) محاسبه می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![نوارهای جداکننده مدت زمان انتقال ۷۵۰ میلی‌ثانیه و تنظیم پیشرفت خودکار ۵٬۰۰۰ میلی‌ثانیه را نشان می‌دهند.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*مثال مشترک به هر اسلاید یک انتقال Fade با مدت ۷۵۰ میلی‌ثانیه می‌دهد و به‌صورت جداگانه پیشرفت خودکار را پس از ۵٬۰۰۰ میلی‌ثانیه فعال می‌کند. مدت زمان انتقال فقط افکت را کنترل می‌کند؛ پیشرفت زمان خروج از اسلاید را تعیین می‌کند. این نوارها تنظیمات شماتیک هستند، نه یک خط زمان ترکیبی اندازه‌گیری‌شده.*  
<!-- visual-explanation:slide-transition:end -->

### **اعمال همان مدت زمان بر تمام اسلایدها**

برای حفظ یکنواختی، همان افکت و مدت زمان دقیق را بر همه اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) انتخاب می‌کند و برای هر انتقال مدت ۷۵۰ میلی‌ثانیه تعیین می‌کند. پیشرفت خودکار را پس از ۵٬۰۰۰ میلی‌ثانیه فعال می‌کند و پیشرفت با کلیک ماوس را غیرفعال می‌سازد، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // پیشرفت خودکار را به طور مستقل از مدت افکت تنظیم کنید.
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

اسلایدهای مختلف می‌توانند مدت زمان افکت متفاوتی داشته باشند. به عنوان مثال، برای اسلاید عنوان یک انتقال کوتاه و برای معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه برای اولین اسلاید و ۱٬۲۰۰ میلی‌ثانیه برای دومین اسلاید تنظیم می‌کند. از فایلی به نام `input.pptx` با حداقل دو اسلاید استفاده کنید.

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

### **هماهنگ‌سازی انتقال‌ها با خروجی‌های متحرک**

هنگام آماده‌سازی یک [GIF متحرک](/slides/fa/androidjava/convert-powerpoint-to-animated-gif/)، یک [ارائه HTML5](/slides/fa/androidjava/export-to-html5/) یا یک [ویدیو](/slides/fa/androidjava/convert-powerpoint-to-video/)، قبل از خروجی‌گیری دقیق مدت زمان انتقال‌ها را تنظیم کنید تا با سرعت موردنظر هم‌پوشانی داشته باشند. به عنوان مثال، از یک افکت Fade ۶۰۰ میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به‌صورت جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن در اختیار باشد.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت افکت هماهنگ کنید: ۶۰۰ میلی‌ثانیه معادل ۱۸ فریم در ۳۰ فریم بر ثانیه است. در HTML5، انتقال‌های متحرک را در تنظیمات خروجی فعال کنید. فرمت خروجی انتخابی را برای افکت‌ها و گزینه‌های زمان‌بندی پشتیبانی‌شده بررسی کنید و پیش‌نمایش خروجی را برای تأیید هم‌زمانی ببینید.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، متد [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) را فراخوانی کنید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معناست که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده به میلی‌ثانیه را نشان می‌دهد. این مقدار تنظیم‌نشده برابر با مدت زمان پخش محاسبه‌شده نیست: Aspose.Slides طول مدت را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) تعیین می‌کند. تنظیم نوع انتقال می‌تواند مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

## **انتقال مورف**

انتقال Morph تغییرات بین اشیاء در اسلایدهای متوالی را انیمیت می‌کند. برای ایجاد یک افکت ساده Morph، یک اسلاید را کلون کنید، یک شیء را در کلون جابه‌جا یا اندازه‌اش تغییر دهید و انتقال Morph را برای اسلاید دوم اعمال کنید. این کار به اشیای مرتبط اجازه می‌دهد بین وضعیت اصلی و اصلاح‌شده انیمیشن شوند.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در کلون تغییر می‌دهد. سپس Morph را از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) برای اسلاید دوم انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایشگر ارائه‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در نمایش اسلاید مشاهده کنید.

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

## **انواع انتقال مورف**

شمارش‌گر [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) تعیین می‌کند Morph چگونه محتوا را مطابقت داده و انیمیت می‌کند:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) هر شکل را به عنوان یک شیء کلی در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) متن را با مطابقت کلمات (در صورت امکان) انیمیت می‌کند.
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) متن را با مطابقت کاراکترها (در صورت امکان) انیمیت می‌کند.

از [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) برای انتخاب Morph قبل از دسترسی به [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) استفاده کنید. مقدار سپس رابط [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/) را فراهم می‌کند که متد [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) حالت مطابقت را انتخاب می‌کند.

این مثال ارائه‌ای را که در بخش قبلی ایجاد شد باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph مبتنی بر کلمه تنظیم می‌کند.

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

## **تنظیم افکت‌های انتقال**

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا اینکه افکت از صفحه سیاه آغاز شود را در اختیار می‌گذارند. گزینه‌های موجود به انتقال انتخاب‌شده با [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) بستگی دارد. ابتدا نوع را تنظیم کنید، سپس از رابط مناسب از طریق [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) استفاده کنید.

مثال زیر یک انتقال Cut را برای اولین اسلاید `input.pptx` اعمال می‌کند. از طریق [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) متد [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) را فراخوانی می‌کند تا انتقال از صفحه سیاه آغاز شود.

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

## **سؤالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. زمانی که به مدت دقیق افکت به میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) استفاده کنید. وقتی یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) (Slow, Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده، از [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) استفاده کنید. این تنظیمات افکت انتقال را به‌صورت مستقل از تاخیر پیشرفت خودکار کنترل می‌کند.

**آیا می‌توانم صدا به یک انتقال اضافه کنم و آن را حلقه‌دار کنم؟**

بله. با [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) صدا را جاسازی کنید، مقدار StartSound از شمارش‌گر [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) بدهید و با [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) مقدار `true` را تنظیم کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید ادامه می‌یابد.

**سریع‌ترین روش برای اعمال یک انتقال یکسان بر تمام اسلایدها چیست؟**

در مجموعه [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) ارائه حلقه بزنید و برای هر اسلاید متد [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) را با همان مقدار فراخوانی کنید. هر تنظیم زمان‌بندی و گزینه افکت را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که در حال حاضر چه انتقالی بر روی یک اسلاید تنظیم شده است؟**

متد [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) را بر نتیجهٔ [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) اسلاید صدا بزنید. این متد مقداری از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) برمی‌گرداند؛ مقدار None به این معنی است که هیچ افکت انتقالی اعمال نشده است.