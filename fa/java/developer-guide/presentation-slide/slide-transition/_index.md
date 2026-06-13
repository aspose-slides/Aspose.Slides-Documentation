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
- انتقال اسلاید پیشرفته
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید انتقال‌های اسلاید را در Aspose.Slides برای جاوا سفارشی کنید، با راهنمایی گام به گام برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه انتقال اسلایدها را در ارائه‌ها با Aspose.Slides مدیریت کنید. نشان می‌دهد چگونه انواع انتقال را به اسلایدها اعمال کنید، رفتار انتقال را مانند پیشروی با کلیک یا پس از زمان مشخص تنظیم کنید، پیشروی خودکار را بررسی و غیرفعال کنید، از انتقال Morph و انواع آن استفاده کنید و گزینه‌های اثر انتقال را تنظیم کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را بارگذاری یا ایجاد کنید، تنظیمات انتقال را برای اسلایدهای انتخاب شده اصلاح کنید و نتیجه را به صورت فایل PPTX ذخیره کنید. مقاله همچنین به سؤالات رایج درباره سرعت انتقال، صداهای انتقال، اعمال همان انتقال به چندین اسلاید و بررسی انتقال فعلی روی یک اسلاید پاسخ می‌دهد.

## **افزودن انتقال اسلاید**
برای ایجاد یک اثر انتقال اسلاید ساده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. یک نوع انتقال اسلاید را از یکی از افکت‌های انتقال ارائه‌شده توسط Aspose.Slides for Java از طریق مقدار enum TransitionType به اسلاید اعمال کنید.
1. فایل ارائه‌ی اصلاح‌شده را بنویسید.

```java
// ایجاد یک شی از کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // اعمال انتقال نوع دایره‌ای بر اسلاید 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // اعمال انتقال نوع شانه‌ای بر اسلاید 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // ذخیره ارائه بر روی دیسک
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن انتقال پیشرفته اسلاید**
در بخش قبلی فقط یک اثر انتقال ساده بر اسلاید اعمال شد. اکنون برای بهتر و کنترل‌شده‌تر کردن این اثر ساده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. یک نوع انتقال اسلاید را از یکی از افکت‌های انتقال ارائه‌شده توسط Aspose.Slides for Java به اسلاید اعمال کنید.
1. می‌توانید انتقال را روی «پیشروی با کلیک»، پس از یک بازه زمانی مشخص یا هر دو تنظیم کنید.
1. اگر انتقال اسلاید روی «پیشروی با کلیک» فعال باشد، انتقال فقط وقتی که کسی کلیک کند پیش می‌رود. علاوه بر این، اگر ویژگی Advance After Time تنظیم شده باشد، انتقال به‌صورت خودکار پس از گذشت زمان مشخص پیش می‌رود.
1. ارائه‌ی اصلاح‌شده را به‌عنوان یک فایل ارائه بنویسید.

```java
// ایجاد یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // اعمال انتقال نوع دایره‌ای بر اسلاید 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تنظیم زمان انتقال به 3 ثانیه
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // اعمال انتقال نوع شانه‌ای بر اسلاید 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // تنظیم زمان انتقال به 5 ثانیه
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // اعمال انتقال نوع زوم بر اسلاید 3
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
{{% alert color="primary" %}} 

Aspose.Slides for Java اکنون از [Morph Transition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMorphTransition) پشتیبانی می‌کند. این‌ها انتقال Morph جدیدی هستند که در PowerPoint 2019 معرفی شد.

{{% /alert %}} 

انتقال Morph به شما امکان می‌دهد حرکت نرم از یک اسلاید به اسلاید بعدی را انیمیشن کنید. این مقاله مفهوم را توضیح می‌دهد و نحوه استفاده از انتقال Morph را نشان می‌دهد. برای استفاده مؤثر از انتقال Morph، نیاز به دو اسلاید دارید که حداقل یک شیء مشترک داشته باشند. ساده‌ترین راه این است که اسلاید را کپی کنید و سپس شیء را در اسلاید دوم به مکان دیگری منتقل کنید.

قطعه کد زیر نشان می‌دهد چگونه یک کپی از اسلاید با متنی به ارائه اضافه کنید و انتقال [morph type](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TransitionType) را به اسلاید دوم اختصاص دهید.

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
enum جدید [TransitionMorphType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TransitionMorphType) اضافه شده است. این enum انواع مختلف انتقال اسلاید Morph را نمایندگی می‌کند.

enum TransitionMorphType سه عضو دارد:

- ByObject: انتقال Morph با در نظر گرفتن شکل‌ها به‌عنوان اشیای جداپذیر انجام می‌شود.
- ByWord: انتقال Morph با انتقال متن به‌صورت کلمات (در صورت امکان) انجام می‌شود.
- ByChar: انتقال Morph با انتقال متن به‌صورت کاراکترها (در صورت امکان) انجام می‌شود.

قطعه کد زیر نشان می‌دهد چگونه انتقال Morph را به اسلاید اختصاص دهید و نوع Morph را تغییر دهید:

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
Aspose.Slides for Java از تنظیم اثرهای انتقال مانند از سیاه، از چپ، از راست و غیره پشتیبانی می‌کند. برای تنظیم اثر انتقال، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- مرجع اسلاید را دریافت کنید.
- اثر انتقال را تنظیم کنید.
- ارائه را به‌صورت [PPTX](https://docs.fileformat.com/presentation/pptx/) فایل بنویسید.

در مثال زیر، ما اثرهای انتقال را تنظیم کرده‌ایم.

```java
// ایجاد یک نمونه از کلاس Presentation
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

## **پرسش‌های متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. با استفاده از تنظیم [TransitionSpeed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/transitionspeed/) سرعت انتقال را تنظیم کنید (مثلاً آهستہ/متوسط/سریع) با متد [setSpeed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSpeed-int-).

**آیا می‌توانم صدا به یک انتقال وصل کنم و آن را حلقه‌دار کنم؟**

بله. می‌توانید صدا را برای انتقال جاسازی کنید و رفتار آن را از طریق تنظیماتی مانند حالت صدا و حلقه‌دار شدن کنترل کنید (مثلاً [setSound](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)، [setSoundMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-)، [setSoundLoop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)، به‌علاوهٔ متادیتاهایی مانند [setSoundIsBuiltIn](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) و [setSoundName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**سریع‌ترین روش برای اعمال یک انتقال یکسان به تمام اسلایدها چیست؟**

نوع انتقال دلخواه را به تنظیمات انتقال هر اسلاید اعمال کنید؛ انتقال‌ها به‌صورت جداگانه برای هر اسلاید ذخیره می‌شوند، بنابراین اعمال همان نوع به تمام اسلایدها نتیجه‌ی یکدستی می‌دهد.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر روی یک اسلاید تنظیم شده است؟**

تنظیمات انتقال اسلاید را بررسی کنید ([transition settings](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslide/#getSlideShowTransition--)) و نوع انتقال آن را بخوانید ([transition type](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowtransition/#setType-int-))؛ این مقدار دقیقاً نشان می‌دهد که کدام اثر اعمال شده است.