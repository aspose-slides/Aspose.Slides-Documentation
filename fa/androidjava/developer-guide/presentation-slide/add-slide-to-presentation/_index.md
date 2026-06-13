---
title: "افزودن اسلایدها به ارائه‌ها در اندروید"
linktitle: "افزودن اسلاید"
type: docs
weight: 10
url: /fa/androidjava/add-slide-to-presentation/
keywords:
- افزودن اسلاید
- ایجاد اسلاید
- اسلاید خالی
- PowerPoint
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "به آسانی اسلایدها را به ارائه‌های PowerPoint و OpenDocument خود با Aspose.Slides for Android via Java اضافه کنید—درج اسلاید ساده، کارآمد و در عرض چند ثانیه."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد اسلایدها را به ارائه‌های PowerPoint به صورت برنامه‌نویسی اضافه کنید. یک ارائه شامل اسلایدهای Master/Layout و اسلایدهای معمولی است و اسلایدهای معمولی بر اساس یک شاخص صفر‑پایه مرتب می‌شوند. هر اسلاید یک شناسه یکتا دارد و فایل‌های ارائه بدون اسلاید پشتیبانی نمی‌شوند.

این مقاله توضیح می‌دهد چگونه یک شیء `Presentation` ایجاد کنید، به مجموعه اسلایدهای آن دسترسی پیدا کنید، یک اسلاید خالی اضافه کنید، با اسلاید تازه اضافه شده کار کنید و ارائه به‌روز شده را ذخیره کنید. همچنین نکات مرتبط مانند درج اسلاید در موقعیت خاص، استفاده از Layoutها و درک اسلاید خالی که در یک ارائه جدید ایجاد می‌شود را پوشش می‌دهد.

## **افزودن اسلاید به یک ارائه**

قبل از صحبت در مورد افزودن اسلایدها به فایل‌های ارائه، برخی حقایق درباره اسلایدها را بررسی می‌کنیم. هر فایل ارائه PowerPoint شامل اسلاید **Master / Layout** و سایر اسلایدهای **Normal** است. این بدان معنی است که یک فایل ارائه حتماً یک یا چند اسلاید دارد. مهم است بدانید که فایل‌های ارائه بدون اسلاید توسط Aspose.Slides for Android via Java پشتیبانی نمی‌شوند. هر اسلاید یک Id یکتا دارد و تمام اسلایدهای Normal به ترتیب مشخص شده توسط شاخص صفر‑پایه مرتب می‌شوند.

Aspose.Slides for Android via Java به توسعه‌دهندگان اجازه می‌دهد اسلایدهای خالی به ارائه خود اضافه کنند. برای افزودن یک اسلاید خالی به ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
- با تنظیم مرجع به خاصیت [Slides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) (مجموعه‌ای از اشیاء Slide محتوا) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ارائه می‌شود، کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection) را نمونه‌سازی کنید.
- با فراخوانی متد [**addEmptySlide**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection) در دسترس است، یک اسلاید خالی به انتهای مجموعه اسلایدهای محتوا اضافه کنید.
- برخی کارها را با اسلاید خالی تازه اضافه شده انجام دهید.
- در نهایت، فایل ارائه را با استفاده از شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) بنویسید.

```java
// یک شیء از کلاس Presentation ایجاد کنید که فایل ارائه را نشان می‌دهد
Presentation pres = new Presentation();
try {
    // یک شیء از کلاس SlideCollection ایجاد کنید
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // یک اسلاید خالی به مجموعه Slides اضافه کنید
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // بر روی اسلاید تازه اضافه شده کاری انجام دهید

    // فایل PPTX را بر روی دیسک ذخیره کنید
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم یک اسلاید جدید را در موقعیت خاصی درج کنم، نه فقط در انتها؟**

بله. کتابخانه از مجموعه اسلایدها و عملیات [insert](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) پشتیبانی می‌کند، بنابراین می‌توانید اسلاید را در شاخص مورد نیاز اضافه کنید نه تنها در انتها.

**آیا هنگام افزودن اسلاید بر پایه یک Layout، تم/استایل‌ها حفظ می‌شوند؟**

بله. یک Layout قالب‌بندی خود را از Master به ارث می‌برد و اسلاید جدید نیز از Layout انتخاب شده و Master مرتبط با آن ارث می‌گیرد.

**کدام اسلاید در یک ارائه جدید «خالی» قبل از افزودن اسلایدها وجود دارد؟**

یک ارائه تازه ایجاد شده در حال حاضر شامل یک اسلاید خالی با شاخص صفر است. این نکته در هنگام محاسبه شاخص‌های درج مهم است.

**چگونه می‌توانم «Layout» مناسب برای یک اسلاید جدید را انتخاب کنم اگر Master گزینه‌های زیادی داشته باشد؟**

به‌طور کلی LayoutSlide که ساختار مورد نیاز را داشته باشد (مانند [Title and Content, Two Content, etc.](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidelayouttype/)) انتخاب کنید. اگر چنین Layoutی وجود نداشته باشد، می‌توانید آن را به Master اضافه کنید ([add it to the master](/slides/fa/androidjava/slide-layout/)) و سپس استفاده کنید.