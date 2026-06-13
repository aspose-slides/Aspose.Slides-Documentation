---
title: حذف اسلایدها از ارائه‌ها در JavaScript
linktitle: حذف اسلاید
type: docs
weight: 30
url: /fa/nodejs-java/remove-slide-from-presentation/
keywords:
- حذف اسلاید
- حذف اسلاید
- حذف اسلاید استفاده‌نشده
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "به‌راحتی اسلایدها را از ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js حذف کنید. مثال‌های کد واضح دریافت کنید و جریان کاری خود را ارتقا دهید."
---
## **مقدمه**

اگر یک اسلاید (یا محتویات آن) زائد شود، می‌توانید آن را حذف کنید. Aspose.Slides کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را فراهم می‌کند که [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) را در بر می‌گیرد و مخزنی برای تمام اسلایدهای یک ارائه است. با استفاده از اشاره‌گرها (مرجع یا اندیس) برای یک شیء [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/) شناخته‌شده، می‌توانید اسلایدی که می‌خواهید حذف کنید را مشخص کنید.

## **حذف اسلاید بر اساس مرجع**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلایدی که می‌خواهید حذف کنید را از طریق شناسه یا اندیس آن دریافت کنید.  
1. اسلاید مرجع‌داده‌شده را از ارائه حذف کنید.  
1. ارائه تغییر یافته را ذخیره کنید.  

این کد JavaScript نحوه حذف یک اسلاید از طریق مرجع آن را نشان می‌دهد:

```javascript
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // یک اسلاید را از طریق ایندکس آن در مجموعه اسلایدها دسترسی می‌یابد
    var slide = pres.getSlides().get_Item(0);
    // یک اسلاید را از طریق مرجع آن حذف می‌کند
    pres.getSlides().remove(slide);
    // ارائه تغییر یافته را ذخیره می‌کند
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **حذف اسلاید بر اساس اندیس**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.  
1. اسلاید را از ارائه از طریق موقعیت اندیس آن حذف کنید.  
1. ارائه تغییر یافته را ذخیره کنید.  

این کد JavaScript نحوه حذف یک اسلاید از طریق اندیس آن را نشان می‌دهد:

```javascript
// یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // یک اسلاید را از طریق ایندکس اسلاید آن حذف می‌کند
    pres.getSlides().removeAt(0);
    // ارائه تغییر یافته را ذخیره می‌کند
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **حذف اسلاید چیدمان استفاده‌نشده**

Aspose.Slides متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) (از کلاس [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/)) را فراهم می‌کند تا بتوانید اسلایدهای چیدمان ناخواسته و استفاده‌نشده را حذف کنید. این کد JavaScript نشان می‌دهد چگونه یک اسلاید چیدمان را از یک ارائه PowerPoint حذف کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف اسلاید مستر استفاده‌نشده**

Aspose.Slides متد [removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (از کلاس [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/)) را فراهم می‌کند تا بتوانید اسلایدهای مستر ناخواسته و استفاده‌نشده را حذف کنید. این کد JavaScript نشان می‌دهد چگونه یک اسلاید مستر را از یک ارائه PowerPoint حذف کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**پس از حذف یک اسلاید، ایندکس‌های اسلایدها چه می‌شود؟**

پس از حذف، [collection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) مجدداً ایندکس‌بندی می‌شود: هر اسلاید بعدی یک موقعیت به سمت چپ جابه‌جا می‌شود، بنابراین شماره‌های ایندکس قبلی منسوخ می‌شوند. اگر به مرجعی ثابت نیاز دارید، به جای ایندکس از شناسه دائمی هر اسلاید استفاده کنید.

**آیا شناسه اسلاید متفاوت از ایندکس آن است و آیا با حذف اسلایدهای همسایه تغییر می‌کند؟**

بله. ایندکس موقعیت اسلاید است و هنگام افزودن یا حذف اسلایدها تغییر می‌کند. شناسه اسلاید یک شناسه دائمی است و هنگام حذف اسلایدهای دیگر تغییر نمی‌کند.

**حذف یک اسلاید چگونه بر بخش‌های اسلاید تأثیر می‌گذارد؟**

اگر اسلاید به بخشی تعلق داشته باشد، آن بخش به سادگی یک اسلاید کمتر خواهد داشت. ساختار بخش حفظ می‌شود؛ اگر بخشی خالی شد، می‌توانید [بخش‌ها را حذف یا بازسازماندهی کنید](/slides/fa/nodejs-java/slide-section/) همان‌طور که نیاز است.

**چه اتفاقی برای یادداشت‌ها و نظراتی که به یک اسلاید پیوست شده‌اند رخ می‌دهد وقتی اسلاید حذف می‌شود؟**

[Notes](/slides/fa/nodejs-java/presentation-notes/) و [comments](/slides/fa/nodejs-java/presentation-comments/) به آن اسلاید خاص مرتبط هستند و همراه با آن حذف می‌شوند. محتوا در اسلایدهای دیگر تحت‌تاثیر قرار نمی‌گیرد.

**حذف اسلایدها با تمیز کردن چیدمان‌ها/مسترهای استفاده‌نشده چه تفاوتی دارد؟**

حذف اسلایدها اسلایدهای معمولی خاصی را از ارائه حذف می‌کند. تمیز کردن چیدمان‌ها/مسترهای استفاده‌نشده اسلایدهای چیدمان یا مستری را که هیچ‌کس به آن‌ها ارجاع نمی‌دهد، حذف می‌کند و باعث کاهش حجم فایل می‌شود بدون این که محتوای اسلایدهای باقی‌مانده تغییر کند. این دو عملیات مکمل یکدیگر هستند: معمولاً ابتدا اسلایدها را حذف می‌کنید، سپس تمیز کردن را انجام می‌دهید.