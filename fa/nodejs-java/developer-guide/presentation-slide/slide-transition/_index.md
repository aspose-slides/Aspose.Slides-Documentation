---
title: مدیریت انتقال اسلایدها در ارائه‌ها با استفاده از JavaScript
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "سفارشی‌سازی انتقال اسلایدها در JavaScript با Aspose.Slides برای Node.js از طریق Java، با راهنمای گام‌به‌گام برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه انتقال اسلایدها را در ارائه‌ها با استفاده از Aspose.Slides مدیریت کنید. نشان می‌دهد چگونه انواع انتقال را به اسلایدها اعمال کنید، رفتار انتقال را مانند پیشروی با کلیک یا پس از زمان مشخص تنظیم کنید، پیشرفت خودکار را بررسی و غیرفعال کنید، از انتقال Morph و انواع آن استفاده کنید و گزینه‌های اثر انتقال را تنظیم کنید. نمونه‌ها نشان می‌دهند چگونه یک ارائه را بارگذاری یا ایجاد کنید، تنظیمات انتقال را برای اسلایدهای انتخاب شده تغییر دهید و نتیجه را به صورت فایل PPTX ذخیره کنید. همچنین این مقاله به سؤالات رایج درباره سرعت انتقال، صداهای انتقال، اعمال همان انتقال بر روی چندین اسلاید و بررسی انتقال فعلی تنظیم شده بر روی یک اسلاید پاسخ می‌دهد.

## **افزودن انتقال اسلاید**
برای ایجاد یک اثر انتقال اسلاید ساده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. یک نوع انتقال اسلاید را بر روی اسلاید از میان اثرهای انتقال ارائه‌شده توسط Aspose.Slides برای Node.js از طریق Java با استفاده از enum TransitionType اعمال کنید.
1. فایل ارائه‌ی اصلاح‌شده را بنویسید.

```javascript
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // اعمال انتقال نوع دایره بر روی اسلاید 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // اعمال انتقال نوع شانه بر روی اسلاید 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // نوشتن ارائه بر روی دیسک
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن انتقال پیشرفته اسلاید**
در بخش بالا، فقط یک اثر انتقال ساده بر روی اسلاید اعمال کردیم. حال برای بهبود و کنترل بهتر آن اثر انتقال ساده، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. یک نوع انتقال اسلاید را بر روی اسلاید از میان اثرهای انتقال ارائه‌شده توسط Aspose.Slides برای Node.js از طریق Java اعمال کنید.
1. همچنین می‌توانید انتقال را به پیشروی با کلیک، پس از دوره زمانی مشخص یا هر دو تنظیم کنید.
1. اگر انتقال اسلاید برای پیشروی با کلیک فعال باشد، فقط زمانی که کاربر کلیک کند، پیشرفت می‌کند. علاوه بر این، اگر ویژگی Advance After Time تنظیم شود، انتقال به‌طور خودکار پس از گذشت زمان مشخص پیشرفت می‌کند.
1. فایل ارائه‌ی اصلاح‌شده را به عنوان یک فایل ارائه ذخیره کنید.

```javascript
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // اعمال انتقال نوع دایره بر روی اسلاید 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // تنظیم زمان انتقال به 3 ثانیه
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // اعمال انتقال نوع شانه بر روی اسلاید 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // تنظیم زمان انتقال به 5 ثانیه
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // اعمال انتقال نوع زوم بر روی اسلاید 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // تنظیم زمان انتقال به 7 ثانیه
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // نوشتن ارائه بر روی دیسک
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Transition**
{{% alert color="primary" %}} 

Aspose.Slides برای Node.js از طریق Java اکنون پشتیبانی از [Morph Transition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MorphTransition) را دارد. این‌ها نمایانگر انتقال مورف جدیدی هستند که در PowerPoint 2019 معرفی شد.

{{% /alert %}} 

انتقال Morph به شما امکان می‌دهد حرکت صاف از یک اسلاید به اسلاید بعدی را انیمیت کنید. این مقاله مفهوم و نحوه استفاده از انتقال Morph را توضیح می‌دهد. برای استفاده مؤثر از انتقال Morph، نیاز به دو اسلاید دارید که حداقل یک شیء مشترک داشته باشند. ساده‌ترین روش این است که اسلاید را تکثیر کنید و سپس شیء را در اسلاید دوم به مکان دیگری منتقل کنید.

کد زیر نشان می‌دهد چگونه یک کپی از اسلاید با متنی اضافه کنید و انتقال [morph type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TransitionType) را به اسلاید دوم اختصاص دهید.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **انواع انتقال Morph**
enum جدید [TransitionMorphType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TransitionMorphType) اضافه شده است. این enum انواع مختلف انتقال اسلاید Morph را نمایندگی می‌کند.

enum TransitionMorphType دارای سه عضو است:

- ByObject: انتقال Morph با در نظر گرفتن اشکال به عنوان اشیاء ناگسستنی انجام می‌شود.
- ByWord: انتقال Morph با انتقال متن به صورت کلمات (در صورت امکان) انجام می‌شود.
- ByChar: انتقال Morph با انتقال متن به صورت حروف (در صورت امکان) انجام می‌شود.

کد زیر نشان می‌دهد چگونه انتقال Morph را به اسلاید اختصاص داده و نوع Morph را تغییر دهید:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم اثرات انتقال**
Aspose.Slides برای Node.js از طریق Java امکان تنظیم اثرات انتقال مانند از رنگ سیاه، از سمت چپ، از سمت راست و غیره را فراهم می‌کند. برای تنظیم اثر انتقال، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
- مرجع اسلاید را دریافت کنید.
- تنظیم اثر انتقال.
- فایل ارائه را به عنوان یک [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.

در مثال زیر، ما اثرات انتقال را تنظیم کرده‌ایم.

```javascript
// ایجاد یک نمونه از کلاس Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // تنظیم اثر
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // نوشتن ارائه بر روی دیسک
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**آیا می‌توانم سرعت پخش انتقال اسلاید را کنترل کنم؟**

بله. سرعت انتقال را با استفاده از تنظیم [speed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/setspeed/) و گزینه [TransitionSpeed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/transitionspeed/) (مثلاً slow/medium/fast) تنظیم کنید.

**آیا می‌توانم صوتی را به یک انتقال وصل کرده و آن را حلقه‌ای کنم؟**

بله. می‌توانید صدا را برای انتقال جاسازی کنید و رفتار آن را از طریق تنظیماتی مانند حالت صدا و حلقه (مثلاً [setSound](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/setsound/)، [setSoundMode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/)، [setSoundLoop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/))، به‌علاوه متادیتاهایی مانند [setSoundIsBuiltIn](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) و [setSoundName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/setsoundname/) کنترل کنید.

**سریع‌ترین راه برای اعمال همان انتقال بر روی تمام اسلایدها چیست؟**

نوع انتقال موردنظر را در تنظیمات انتقال هر اسلاید پیکربندی کنید؛ انتقال‌ها به‌صورت جداگانه برای هر اسلاید ذخیره می‌شوند، بنابراین اعمال همان نوع بر تمام اسلایدها نتایج یکسانی می‌دهد.

**چگونه می‌توانم بررسی کنم که در حال حاضر چه انتقالی روی یک اسلاید تنظیم شده است؟**

تنظیمات [transition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید را بررسی کنید و مقدار [type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowtransition/gettype/) آن را بخوانید؛ این مقدار دقیقاً نشان می‌دهد چه اثری اعمال شده است.