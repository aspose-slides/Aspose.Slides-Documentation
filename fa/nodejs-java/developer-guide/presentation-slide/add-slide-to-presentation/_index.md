---
title: اضافه کردن اسلایدها به ارائه‌ها در جاوااسکریپت
linktitle: اضافه کردن اسلاید
type: docs
weight: 10
url: /fa/nodejs-java/add-slide-to-presentation/
keywords:
- افزودن اسلاید
- ایجاد اسلاید
- اسلاید خالی
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "به راحتی اسلایدها را به ارائه‌های PowerPoint و OpenDocument خود با استفاده از Aspose.Slides برای Node.js از طریق Java اضافه کنید — درج اسلاید بدون درز و کارآمد در عرض چند ثانیه."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد اسلایدها را به ارائه‌های PowerPoint به صورت برنامه‌نویسی اضافه کنید. یک ارائه شامل اسلایدهای Master/Layout و اسلایدهای Normal است و اسلایدهای Normal بر اساس یک شاخص صفر مبنا مرتب می‌شوند. هر اسلاید یک شناسه یکتا دارد و فایل‌های ارائه بدون اسلاید توسط Aspose.Slides پشتیبانی نمی‌شوند.

این مقاله توضیح می‌دهد چگونه یک شیء `Presentation` ایجاد کنید، به مجموعه اسلایدهای آن دسترسی پیدا کنید، یک اسلاید خالی اضافه کنید، با اسلاید تازه اضافه‌شده کار کنید و ارائه به‌روز شده را ذخیره کنید. همچنین به نکات مرتبطی چون درج اسلایدها در موقعیت خاص، استفاده از Layoutها و درک اسلاید خالی موجود در یک ارائه تازه ایجاد شده می‌پردازد.

## **اضافه کردن اسلاید به ارائه**

قبل از گفتگو درباره افزودن اسلایدها به فایل‌های ارائه، برخی حقایق درباره اسلایدها را بررسی می‌کنیم. هر فایل ارائه PowerPoint شامل اسلاید **Master / Layout** و سایر اسلایدهای **Normal** است. این به این معنی است که یک فایل ارائه حداقل یک اسلاید دارد. مهم است بدانید فایل‌های ارائه بدون اسلاید توسط Aspose.Slides for Node.js via Java پشتیبانی نمی‌شوند. هر اسلاید یک Id یکتا دارد و تمام اسلایدهای Normal بر اساس شاخص صفر مبنا مرتب می‌شوند.

Aspose.Slides for Node.js via Java به توسعه‌دهندگان اجازه می‌دهد اسلایدهای خالی به ارائه خود اضافه کنند. برای افزودن یک اسلاید خالی در ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
- کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection) را با تنظیم ارجاع به ویژگی [Slides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) (مجموعه‌ای از اشیاء Slide محتوا) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ارائه می‌شود، نمونه‌سازی کنید.
- با فراخوانی متد [**addEmptySlide**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection) در دسترس است، یک اسلاید خالی به انتهای مجموعه اسلایدهای محتوا اضافه کنید.
- برخی کارها را با اسلاید خالی تازه اضافه‌شده انجام دهید.
- در نهایت، فایل ارائه را با استفاده از شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) بنویسید.

```javascript
// نمونه‌سازی کلاس Presentation که نمایانگر فایل ارائه است
var pres = new aspose.slides.Presentation();
try {
    // نمونه‌سازی کلاس SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // اضافه کردن یک اسلاید خالی به مجموعه Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // انجام برخی کارها بر روی اسلاید تازه اضافه‌شده
    // ذخیره فایل PPTX به دیسک
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم اسلاید جدیدی را در موقعیت خاصی نه فقط در انتها درج کنم؟**

بله. کتابخانه از مجموعه‌های اسلاید و عملیات‌های [insert](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/insertclone/) پشتیبانی می‌کند، به این ترتیب می‌توانید اسلاید را در شاخص موردنیاز اضافه کنید نه فقط در انتها.

**آیا قالب/استایل‌ها هنگام افزودن اسلاید بر پایه یک Layout حفظ می‌شوند؟**

بله. یک Layout قالب‌بندی خود را از Master به ارث می‌برد و اسلاید جدید نیز از Layout انتخاب‌شده و Master مرتبط با آن ارث می‌برد.

**کدام اسلاید در یک ارائه «خالی» جدید قبل از افزودن اسلایدها وجود دارد؟**

یک ارائه تازه ایجاد شده از پیش شامل یک اسلاید خالی با شاخص صفر است. این نکته هنگام محاسبه شاخص‌های درج مهم است.

**چگونه می‌توانم «Layout» مناسب برای اسلاید جدید را انتخاب کنم اگر Master گزینه‌های متعددی داشته باشد؟**

معمولاً [LayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) که ساختار موردنیاز (مانند Title and Content، Two Content و غیره) را داشته باشد انتخاب می‌کنید. اگر چنین Layoutی موجود نباشد، می‌توانید آن را به Master اضافه کنید ([add it to the master](/slides/fa/nodejs-java/slide-layout/)) و سپس استفاده کنید.