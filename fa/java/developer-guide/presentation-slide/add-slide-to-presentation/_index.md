---
title: افزودن اسلایدها به ارائه‌ها در جاوا
linktitle: افزودن اسلاید
type: docs
weight: 10
url: /fa/java/add-slide-to-presentation/
keywords:
- افزودن اسلاید
- ایجاد اسلاید
- اسلاید خالی
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به راحتی اسلایدها را به ارائه‌های PowerPoint و OpenDocument خود با استفاده از Aspose.Slides for Java اضافه کنید—درج اسلاید بدون درز و کارآمد در چند ثانیه."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد اسلایدها را به صورت برنامه‌نویسی به ارائه‌های PowerPoint اضافه کنید. یک ارائه شامل اسلایدهای Master/Layout و اسلایدهای Normal است و اسلایدهای Normal بر اساس یک ایندکس صفر-پایه مرتب می‌شوند. هر اسلاید دارای یک شناسه یکتا است و فایل‌های ارائه بدون اسلاید توسط این کتابخانه پشتیبانی نمی‌شوند.

این مقاله توضیح می‌دهد چطور یک شیء `Presentation` ایجاد کنید، به مجموعه اسلایدهای آن دسترسی پیدا کنید، یک اسلاید خالی اضافه کنید، با اسلاید تازه افزوده کار کنید و ارائه به‌روز شده را ذخیره کنید. همچنین نکات مرتبطی مانند درج اسلاید در موقعیت خاص، استفاده از Layoutها و درک اسلاید خالی موجود در یک ارائه تازه ایجاد شده را پوشش می‌دهد.

## **اضافه کردن اسلاید به یک ارائه**

قبل از صحبت درباره افزودن اسلایدها به فایل‌های ارائه، برخی facts درباره اسلایدها را بررسی می‌کنیم. هر فایل ارائه PowerPoint شامل اسلاید **Master / Layout** و دیگر اسلایدهای **Normal** است. این بدین معنی است که یک فایل ارائه حداقل یک اسلاید دارد. مهم است بدانید که فایل‌های ارائه بدون اسلاید توسط Aspose.Slides for Java پشتیبانی نمی‌شوند. هر اسلاید دارای یک Id یکتا است و تمام اسلایدهای Normal بر اساس ایندکس صفر‑پایه‌ ای که تعیین می‌شود، مرتب می‌شوند.

Aspose.Slides for Java به توسعه‌دهندگان امکان می‌دهد اسلایدهای خالی را به ارائه خود اضافه کنند. برای افزودن یک اسلاید خالی به ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
- با تنظیم مرجع به ویژگی [Slides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) (مجموعه اشیای Slide محتوا) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) بازگشت داده می‌شود، کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection) را نمونه‌سازی کنید.
- با فراخوانی متد [**addEmptySlide**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection) در دسترس است، یک اسلاید خالی به انتهای مجموعه اسلایدهای محتوا اضافه کنید.
- برخی عملیات مورد نیاز را بر روی اسلاید خالی تازه افزوده انجام دهید.
- در نهایت، فایل ارائه را با استفاده از شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) بنویسید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر فایل ارائه است
Presentation pres = new Presentation();
try {
    // نمونه‌سازی کلاس SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // افزودن یک اسلاید خالی به مجموعه Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // انجام برخی عملیات بر روی اسلاید تازه افزوده

    // ذخیره فایل PPTX به دیسک
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**آیا می‌توانم اسلاید جدید را در یک موقعیت خاص، نه فقط در انتها، درج کنم؟**

بله. کتابخانه از عملیات‌های collection اسلایدها و [insert](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) پشتیبانی می‌کند، بنابراین می‌توانید اسلاید را در ایندکس مورد نیاز اضافه کنید نه فقط در انتها.

**آیا تم/استایل‌ها هنگام افزودن اسلاید بر پایه یک layout حفظ می‌شوند؟**

بله. یک layout قالب‌بندی خود را از master ارث می‌برد و اسلاید جدید نیز از layout انتخاب شده و master مرتبط با آن ارث می‌گیرد.

**کدام اسلاید در یک ارائه «خالی» جدید قبل از افزودن اسلایدها وجود دارد؟**

یک ارائه تازه ایجاد شده به‌طور پیش‌فرض شامل یک اسلاید خالی با ایندکس صفر است. این نکته برای محاسبه ایندکس‌های درج اهمیت دارد.

**چگونه می‌توانم «layout» مناسب برای اسلاید جدید را انتخاب کنم اگر master گزینه‌های متعددی داشته باشد؟**

به طور کلی، [LayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslide/) که با ساختار مورد نیاز (مانند [Title and Content, Two Content, etc.](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidelayouttype/)) منطبق است، انتخاب کنید. اگر چنین layoutی وجود نداشت، می‌توانید آن را به master اضافه کنید ([add it to the master](/slides/fa/java/slide-layout/)) و سپس استفاده کنید.