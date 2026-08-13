---
title: مدیریت انتقال اسلایدها در ارائه‌ها با استفاده از جاوا
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
description: "کشف کنید چگونه می‌توانید انتقال اسلایدها را در Aspose.Slides برای جاوا سفارشی کنید، همراه با راهنمای گام‌به‌گام برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان انتقال‌های اسلاید در ارائه‌ها را با استفاده از Aspose.Slides مدیریت کرد. نشان می‌دهد چگونه انواع انتقال را به اسلایدها اعمال کنید، رفتار انتقال مانند پیشروی با کلیک یا پس از زمان مشخص را پیکربندی کنید، پیشروی خودکار را بررسی و غیرفعال کنید، از انتقال Morph و انواع آن استفاده کنید و گزینه‌های افکت انتقال را تنظیم کنید. مثال‌ها نحوه بارگذاری یا ایجاد یک ارائه، تغییر تنظیمات انتقال برای اسلایدهای انتخاب شده و ذخیره نتیجه به عنوان فایل PPTX را نشان می‌دهند. مقاله همچنین به سؤالات رایج درباره سرعت انتقال، صداهای انتقال، اعمال همان انتقال برای چندین اسلاید و بررسی انتقال فعلی تنظیم شده بر روی یک اسلاید پاسخ می‌دهد.

## **افزودن انتقال اسلاید**
برای ایجاد یک اثر ساده انتقال اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. یک نوع Slide Transition را از یکی از افکت‌های انتقال ارائه‌شده توسط Aspose.Slides برای Java از طریق enum TransitionType به اسلاید اعمال کنید.
1. فایل ارائه تغییر یافته را بنویسید.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // اعمال انتقال نوع دایره‌ای بر روی اسلاید 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // اعمال انتقال نوع شانه‌ای بر روی اسلاید 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // ذخیره ارائه بر روی دیسک
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن انتقال پیشرفته اسلاید**
در بخش فوق، ما فقط یک اثر ساده انتقال را بر روی اسلاید اعمال کردیم. اکنون برای بهبود و کنترل بهتر این اثر ساده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. یک نوع Slide Transition را از یکی از افکت‌های انتقال ارائه‌شده توسط Aspose.Slides برای Java اعمال کنید.
1. همچنین می‌توانید انتقال را به حالت Advance On Click، پس از یک دوره زمان خاص یا هر دو تنظیم کنید.
1. اگر انتقال اسلاید برای Advance On Click فعال باشد، انتقال تنها زمانی که کاربر کلیک کند پیش می‌رود. علاوه بر این، اگر ویژگی Advance After Time تنظیم شود، انتقال به طور خودکار پس از گذشت زمان تعیین‌شده پیش می‌رود.
1. ارائه تغییر یافته را به عنوان یک فایل ارائه بنویسید.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // اعمال انتقال نوع دایره‌ای بر روی اسلاید 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تنظیم زمان انتقال به 3 ثانیه
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // اعمال انتقال نوع شانه‌ای بر روی اسلاید 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // تنظیم زمان انتقال به 5 ثانیه
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // اعمال انتقال نوع بزرگ‌نمایی بر روی اسلاید 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // تنظیم زمان انتقال به 7 ثانیه
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // ذخیره ارائه بر روی دیسک
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **انتقال Morph**
{{% alert color="info" %}} 

Aspose.Slides برای Java هم‌اکنون از [Morph Transition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMorphTransition) پشتیبانی می‌کند. این‌ها انتقال Morph جدیدی هستند که در PowerPoint 2019 معرفی شده‌اند.

{{% /alert %}} 

انتقال Morph به شما اجازه می‌دهد حرکت صاف از یک اسلاید به اسلاید بعدی را انیمیت کنید. این مقاله مفهوم و نحوه استفاده از انتقال Morph را توضیح می‌دهد. برای استفاده مؤثر از انتقال Morph، به دو اسلاید با حداقل یک شیء مشترک نیاز دارید. ساده‌ترین راه این است که اسلاید را تکثیر کنید و سپس شیء را در اسلاید دوم به مکان دیگری جابجا کنید.

قطعه کد زیر نشان می‌دهد چگونه یک کلون از اسلاید با برخی متن را به ارائه اضافه کنید و یک انتقال از نوع [morph type](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TransitionType) را به اسلاید دوم اختصاص دهید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **انواع انتقال Morph**
enum جدید [TransitionMorphType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TransitionMorphType) اضافه شده است. این enum نمایانگر انواع مختلف انتقال اسلاید Morph است.

enum TransitionMorphType سه عضو دارد:

- ByObject: انتقال Morph با در نظر گرفتن اشکال به عنوان اشیای غیرقابل تقسیم انجام می‌شود.
- ByWord: انتقال Morph به‌صورت انتقال متن به‌صورت کلمات انجام می‌شود، در صورت امکان.
- ByChar: انتقال Morph به‌صورت انتقال متن به‌صورت کاراکترها انجام می‌شود، در صورت امکان.

قطعه کد زیر نشان می‌دهد چگونه انتقال Morph را به اسلاید اختصاص دهید و نوع Morph را تغییر دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم افکت‌های انتقال**
Aspose.Slides برای Java از تنظیم افکت‌های انتقال مانند از سیاه، از چپ، از راست و غیره پشتیبانی می‌کند. برای تنظیم افکت انتقال، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- مرجع اسلاید را دریافت کنید.
- افکت انتقال را تنظیم کنید.
- ارائه را به عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) نویسید.

در مثال زیر، ما افکت‌های انتقال را تنظیم کرده‌ایم.

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد کنید
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تنظیم اثر
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // نوشتن ارائه بر روی دیسک
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

### آیا می‌توانم سرعت پخش انتقال اسلاید را کنترل کنم؟

بله. سرعت انتقال را با استفاده از تنظیم [TransitionSpeed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitionspeed/) (مثلاً slow/medium/fast) تنظیم کنید.

### آیا می‌توانم صدا را به انتقال وصل کنم و آن را حلقه‌دار کنم؟

بله. می‌توانید صدا را برای انتقال جاسازی کنید و رفتار را از طریق تنظیماتی مانند حالت صدا و حلقه‌دار شدن (مثلاً [setSound](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)، [setSoundMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-)، [setSoundLoop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)، به‌اضافه metadataهایی مثل [setSoundIsBuiltIn](httpsuilder.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) و [setSoundName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)) انجام دهید.

### سریع‌ترین روش برای اعمال یکسان همان انتقال به تمام اسلایدها چیست؟

نوع انتقال موردنظر را بر روی تنظیمات انتقال هر اسلاید پیکربندی کنید؛ انتقال‌ها به‌صورت جداگانه در هر اسلاید ذخیره می‌شوند، بنابراین اعمال یک نوع یکسان بر تمام اسلایدها نتیجهٔ یکدست خواهد داد.

### چگونه می‌توانم بررسی کنم که در حال حاضر چه انتقالی بر روی یک اسلاید تنظیم شده است؟

تنظیمات انتقال اسلاید را بررسی کنید و نوع انتقال را با خواندن [transition type](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setType-int-) بخوانید؛ این مقدار دقیقاً نشان می‌دهد چه اثری اعمال شده است.