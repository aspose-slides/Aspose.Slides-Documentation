---
title: حذف اسلایدها از ارائه‌ها در اندروید
linktitle: حذف اسلاید
type: docs
weight: 30
url: /fa/androidjava/remove-slide-from-presentation/
keywords:
- حذف اسلاید
- حذف اسلاید
- حذف اسلاید استفاده نشده
- پاورپوینت
- سند باز
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "به راحتی اسلایدها را از ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Android حذف کنید. نمونه‌های واضح کد Java دریافت کنید و جریان کاری خود را ارتقا دهید."
---
## **معرفی**

اگر یک اسلاید (یا محتوای آن) زائد شود، می‌توانید آن را حذف کنید. Aspose.Slides کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را ارائه می‌دهد که [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) را در بر می‌گیرد، که مخزنی برای تمام اسلایدهای یک ارائه است. با استفاده از نشانگرها (مرجع یا اندیس) برای یک شیء [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) شناخته‌شده، می‌توانید اسلایدی که می‌خواهید حذف کنید را مشخص کنید.

## **حذف یک اسلاید بر اساس مرجع**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلایدی که می‌خواهید حذف کنید را از طریق شناسه یا اندیس آن دریافت کنید.
1. اسلاید مرجع را از ارائه حذف کنید.
1. ارائه‌ی تغییر یافته را ذخیره کنید. 

این کد Java نشان می‌دهد چگونه یک اسلاید را از طریق مرجع آن حذف کنید:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("demo.pptx");
try {
    // اسلاید را از طریق ایندکس آن در مجموعه اسلایدها دسترسی می‌کند
    ISlide slide = pres.getSlides().get_Item(0);
    
    // اسلاید را از طریق مرجع آن حذف می‌کند
    pres.getSlides().remove(slide);
    
    // ارائه تغییر یافته را ذخیره می‌کند
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **حذف یک اسلاید بر اساس اندیس**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. اسلاید را از ارائه از طریق موقعیت اندیس آن حذف کنید.
1. ارائه‌ی تغییر یافته را ذخیره کنید. 

این کد Java نشان می‌دهد چگونه یک اسلاید را از طریق اندیس آن حذف کنید:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("demo.pptx");
try {
    // اسلاید را از طریق ایندکس آن حذف می‌کند
    pres.getSlides().removeAt(0);
    
    // ارائه تغییر یافته را ذخیره می‌کند
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **حذف اسلایدهای طرح‌بندی استفاده‌نشده**

Aspose.Slides متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (از کلاس [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) ) را ارائه می‌دهد تا به شما امکان حذف اسلایدهای طرح‌بندی ناخواسته و استفاده‌نشده را بدهد. این کد Java نشان می‌دهد چگونه یک اسلاید طرح‌بندی را از یک ارائه PowerPoint حذف کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف اسلایدهای مستر استفاده‌نشده**

Aspose.Slides متد [removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (از کلاس [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) ) را ارائه می‌دهد تا به شما امکان حذف اسلایدهای مستر ناخواسته و استفاده‌نشده را بدهد. این کد Java نشان می‌دهد چگونه یک اسلاید مستر را از یک ارائه PowerPoint حذف کنید:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **سوالات متداول**

**پس از حذف یک اسلاید، ایندکس‌های اسلایدها چه اتفاقی می‌افتد؟**

پس از حذف، [collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidecollection/) مجدداً ایندکس می‌شود: هر اسلاید بعدی یک موقعیت به سمت چپ جابه‌جا می‌شود، بنابراین شماره‌های قبلی ایندکس منسوخ می‌شوند. اگر به یک مرجع ثابت نیاز دارید، به‌جای ایندکس، شناسهٔ پایدار هر اسلاید را استفاده کنید.

**آیا شناسهٔ اسلاید با ایندکس آن متفاوت است و آیا هنگام حذف اسلایدهای همجوار تغییر می‌کند؟**

بله. ایندکس موقعیت اسلاید است و با اضافه یا حذف اسلایدها تغییر می‌کند. شناسهٔ اسلاید یک شناسهٔ پایدار است و هنگام حذف سایر اسلایدها تغییر نمی‌کند.

**حذف یک اسلاید چه تاثیری بر بخش‌های اسلاید دارد؟**

اگر اسلاید بخشی از یک بخش باشد، آن بخش تنها یک اسلاید کمتر خواهد داشت. ساختار بخش حفظ می‌شود؛ اگر بخشی خالی شود، می‌توانید [حذف یا سازماندهی مجدد بخش‌ها](/slides/fa/androidjava/slide-section/) را در صورت نیاز انجام دهید.

**چه اتفاقی برای یادداشت‌ها و نظرات پیوست شده به اسلاید هنگام حذف آن می‌افتد؟**

[Notes](/slides/fa/androidjava/presentation-notes/) و [comments](/slides/fa/androidjava/presentation-comments/) به آن اسلاید خاص وابسته‌اند و همراه با آن حذف می‌شوند. محتویات اسلایدهای دیگر تحت تأثیر قرار نمی‌گیرند.

**حذف اسلایدها چه تفاوتی با پاک‌سازی طرح‌ها/مسترهای استفاده‌نشده دارد؟**

حذف اسلایدهای عادی خاصی را از مجموعه حذف می‌کند. پاک‌سازی طرح‌ها/مسترهای استفاده‌نشده اسلایدهای طرح یا مستری را که هیچ شی‌ای به آن‌ها ارجاع نمی‌دهد حذف می‌کند، که باعث کاهش حجم فایل می‌شود بدون آنکه محتویات اسلایدهای باقی‌مانده تغییر کند. این اقدامات مکمل یکدیگر هستند: معمولاً ابتدا حذف می‌شود، سپس پاک‌سازی انجام می‌شود.