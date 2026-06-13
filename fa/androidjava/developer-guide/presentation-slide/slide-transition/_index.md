---
title: مدیریت انتقال اسلایدها در ارائه‌ها در اندروید
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
description: "کشف کنید چگونه می‌توانید انتقال اسلایدها را در Aspose.Slides برای اندروید از طریق جاوا سفارشی کنید، با راهنمای گام به گام برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان انتقال اسلایدها را در ارائه‌ها با استفاده از Aspose.Slides مدیریت کرد. نحوه اعمال انواع انتقال بر روی اسلایدها، پیکربندی رفتار انتقال مانند پیشروی با کلیک یا پس از زمان معین، بررسی و غیرفعال‌سازی پیشروی خودکار، استفاده از انتقال Morph و انواع آن، و تنظیم گزینه‌های اثر انتقال را نشان می‌دهد. مثال‌ها نشان می‌دهند چگونه یک ارائه را بارگذاری یا ایجاد کنید، تنظیمات انتقال را برای اسلایدهای انتخاب شده اصلاح کنید و نتیجه را به‌صورت فایل PPTX ذخیره کنید. مقاله همچنین به سؤالات رایج درباره سرعت انتقال، صداهای انتقال، اعمال یک انتقال یکسان بر چندین اسلاید و بررسی انتقال فعلی یک اسلاید پاسخ می‌دهد.

## **افزودن انتقال اسلاید**
برای ایجاد یک اثر انتقال ساده بر روی اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
2. یک نوع انتقال اسلاید را از میان اثرهای انتقال ارائه شده توسط Aspose.Slides برای Android از طریق Java با استفاده از enum TransitionType بر روی اسلاید اعمال کنید.
3. فایل ارائه تغییر یافته را بنویسید.

```java
// نمونه‌ای از کلاس Presentation را برای بارگذاری فایل ارائه منبع ایجاد کنید
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // اعمال انتقال نوع دایره‌ای بر روی اسلاید 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // اعمال انتقال نوع شانه‌ای بر روی اسلاید 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // نوشتن ارائه به دیسک
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن انتقال پیشرفته اسلاید**
در بخش قبلی فقط یک اثر انتقال ساده بر روی اسلاید اعمال کردیم. اکنون برای بهتر و قابل کنترل‌تر کردن آن اثر انتقال، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
2. یک نوع انتقال اسلاید را از میان اثرهای انتقال ارائه شده توسط Aspose.Slides برای Android از طریق Java اعمال کنید.
3. می‌توانید انتقال را به حالت پیشروی با کلیک، پس از یک بازه زمانی خاص یا هر دو تنظیم کنید.
4. اگر انتقال اسلاید برای پیشروی با کلیک فعال باشد، انتقال تنها زمانی پیش می‌رود که کاربر کلیک ماوس کند. علاوه بر این، اگر ویژگی Advance After Time تنظیم شود، انتقال به‌صورت خودکار پس از گذشت زمان مشخص پیش می‌رود.
5. ارائه تغییر یافته را به‌عنوان یک فایل ارائه ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // انتقال نوع دایره‌ای را روی اسلاید 1 اعمال کنید
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تنظیم زمان انتقال به ۳ ثانیه
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // انتقال نوع شانه‌ای را روی اسلاید 2 اعمال کنید
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // تنظیم زمان انتقال به ۵ ثانیه
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // انتقال نوع زوم را روی اسلاید 3 اعمال کنید
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // تنظیم زمان انتقال به ۷ ثانیه
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // نوشتن ارائه به دیسک
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **انتقال Morph**
{{% alert color="primary" %}} 

Aspose.Slides برای Android از طریق Java اکنون از [Morph Transition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMorphTransition) پشتیبانی می‌کند. این‌ها انتقال morph جدیدی هستند که در PowerPoint 2019 معرفی شد.

{{% /alert %}} 

انتقال Morph به شما امکان می‌دهد حرکت روانی از یک اسلاید به اسلاید بعدی را انیمیت کنید. این مقاله مفهوم و نحوه استفاده از انتقال Morph را توضیح می‌دهد. برای استفاده مؤثر از انتقال Morph، به دو اسلاید با حداقل یک شیء مشترک نیاز دارید. ساده‌ترین روش این است که اسلاید را تکثیر کنید و سپس شیء را در اسلاید دوم به مکان دیگری منتقل کنید.

کد زیر نشان می‌دهد چگونه یک کپی از اسلاید را با متن اضافه کنید و برای اسلاید دوم یک انتقال از نوع [morph type](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TransitionType) تنظیم کنید.

```java
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
یک enum جدید به نام [TransitionMorphType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TransitionMorphType) افزوده شده است. این enum انواع مختلفی از انتقال اسلاید Morph را نشان می‌دهد.

enum TransitionMorphType دارای سه عضو است:

- ByObject: انتقال Morph با در نظر گرفتن اشکال به‌عنوان اشیاء غیرقابل تقسیم انجام می‌شود.
- ByWord: انتقال Morph با انتقال متن به‌صورت کلمه به کلمه در صورت امکان انجام می‌شود.
- ByChar: انتقال Morph با انتقال متن به‌صورت حرف به حرف در صورت امکان انجام می‌شود.

کد زیر نشان می‌دهد چگونه انتقال morph را به اسلاید تنظیم کرده و نوع morph را تغییر دهید:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم اثرات انتقال**
Aspose.Slides برای Android از طریق Java از تنظیم اثرات انتقال مانند از سیاه، از چپ، از راست و غیره پشتیبانی می‌کند. برای تنظیم اثر انتقال، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
- مرجع اسلاید را دریافت کنید.
- تنظیم اثر انتقال.
- ارائه را به‌صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید.

در مثال زیر، اثرات انتقال تنظیم شده‌اند.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تنظیم اثر
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // نوشتن ارائه به دیسک
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. سرعت انتقال را با استفاده از تنظیم [TransitionSpeed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitionspeed/) (به عنوان مثال، آهسته/متوسط/سریع) تنظیم کنید.

**آیا می‌توانم صدای یک انتقال را ضمیمه کرده و آن را به‌صورت حلقه پخش کنم؟**

بله. می‌توانید صدا را برای انتقال جاسازی کنید و رفتار آن را از طریق تنظیماتی مانند حالت صدا و حلقه‌گذاری (به عنوان مثال، [setSound](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)، [setSoundMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-)، [setSoundLoop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)، به‌علاوه متادیتاهایی مانند [setSoundIsBuiltIn](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) و [setSoundName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)) استفاده کنید.

**سریع‌ترین روش برای اعمال یک انتقال یکسان بر تمام اسلایدها چیست؟**

نوع انتقال موردنظر را بر روی تنظیمات انتقال هر اسلاید پیکربندی کنید؛ انتقال‌ها به‌صورت جداگانه برای هر اسلاید ذخیره می‌شوند، بنابراین اعمال یک نوع انتقال یکسان بر تمام اسلایدها نتیجهٔ سازگاری دارد.

**چگونه می‌توانم بررسی کنم که در حال حاضر کدام انتقال بر یک اسلاید تنظیم شده است؟**

تنظیات انتقال اسلاید را بررسی کنید ([baseSlide#getSlideShowTransition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--)) و نوع انتقال آن را بخوانید ([slideshowtransition#setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setType-int-))؛ این مقدار دقیقاً نشان می‌دهد کدام اثر اعمال شده است.