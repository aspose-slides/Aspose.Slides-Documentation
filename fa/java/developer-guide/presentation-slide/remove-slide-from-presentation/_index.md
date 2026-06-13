---
title: حذف اسلایدها از ارائه‌ها در جاوا
linktitle: حذف اسلاید
type: docs
weight: 30
url: /fa/java/remove-slide-from-presentation/
keywords:
- حذف اسلاید
- حذف اسلاید
- حذف اسلاید بدون استفاده
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "به‌سادگی اسلایدها را از ارائه‌های پاورپوینت و OpenDocument با Aspose.Slides برای جاوا حذف کنید. مثال‌های واضح کد دریافت کنید و جریان کاری خود را ارتقا دهید."
---
## **مقدمه**

اگر یک اسلاید (یا محتوای آن) غیر ضروری شد، می‌توانید آن را حذف کنید. Aspose.Slides کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را فراهم می‌کند که [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) را در بر می‌گیرد، که مخزن تمام اسلایدهای یک ارائه است. با استفاده از اشاره‌گرها (مرجع یا ایندکس) برای یک شیء [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) شناخته‌شده، می‌توانید اسلایدی که می‌خواهید حذف کنید را مشخص کنید. 

## **حذف اسلاید با مرجع**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلایدی که می‌خواهید حذف کنید را از طریق شناسه یا ایندکس آن دریافت کنید.
1. اسلاید مرجع شده را از ارائه حذف کنید.
1. ارائه‌ی تغییر یافته را ذخیره کنید. 

این کد جاوا به شما نشان می‌دهد چگونه یک اسلاید را از طریق مرجع آن حذف کنید:

```java
// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("demo.pptx");
try {
    // اسلایدی را با استفاده از ایندکس آن در مجموعه اسلایدها دسترسی می‌کند
    ISlide slide = pres.getSlides().get_Item(0);
    
    // یک اسلاید را از طریق مرجع آن حذف می‌کند
    pres.getSlides().remove(slide);
    
    // ارائهٔ تغییر یافته را ذخیره می‌کند
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **حذف اسلاید با ایندکس**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. اسلاید را از ارائه از طریق موقعیت ایندکس آن حذف کنید.
1. ارائه‌ی تغییر یافته را ذخیره کنید. 

این کد جاوا به شما نشان می‌دهد چگونه یک اسلاید را از طریق ایندکس آن حذف کنید:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("demo.pptx");
try {
    // یک اسلاید را از طریق ایندکس اسلاید آن حذف می‌کند
    pres.getSlides().removeAt(0);
    
    // ارائهٔ تغییر یافته را ذخیره می‌کند
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **حذف اسلایدهای طرح‌بندی استفاده‌نشده**

Aspose.Slides متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (از کلاس [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) ) را فراهم می‌کند تا به شما امکان حذف اسلایدهای طرح‌بندی ناخواسته و استفاده‌نشده را بدهد. این کد جاوا به شما نشان می‌دهد چگونه یک اسلاید طرح‌بندی را از یک ارائه پاورپوینت حذف کنید:

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

Aspose.Slides متد [removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (از کلاس [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) ) را فراهم می‌کند تا به شما امکان حذف اسلایدهای مستر ناخواسته و استفاده‌نشده را بدهد. این کد جاوا به شما نشان می‌دهد چگونه یک اسلاید مستر را از یک ارائه پاورپوینت حذف کنید:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **سؤالات متداول**

**بعد از حذف یک اسلاید، ایندکس‌های اسلایدها چه اتفاقی می‌افتد؟**

پس از حذف، [collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/) مجدداً ایندکس می‌شود: هر اسلاید پس از آن یک موقعیت به سمت چپ حرکت می‌کند، بنابراین شماره‌های ایندکس قبلی قدیمی می‌شوند. اگر به مرجعی ثابت نیاز دارید، به جای ایندکس، شناسه پایدار هر اسلاید را استفاده کنید.

**آیا شناسه یک اسلاید متفاوت از ایندکس آن است و هنگام حذف اسلایدهای همسایه تغییر می‌کند؟**

بله. ایندکس موقعیت اسلاید است و هنگام افزودن یا حذف اسلایدها تغییر می‌کند. شناسه اسلاید یک شناسه ثابت است و وقتی اسلایدهای دیگر حذف می‌شوند، تغییر نمی‌کند.

**حذف یک اسلاید چطور بر بخش‌های اسلاید تأثیر می‌گذارد؟**

اگر اسلاید به بخشی تعلق داشته باشد، آن بخش تنها یک اسلاید کمتر خواهد داشت. ساختار بخش به همان شکل باقی می‌ماند؛ اگر بخشی خالی شد، می‌توانید [remove or reorganize sections](/slides/fa/java/slide-section/) را انجام دهید.

**زمانی که یک اسلاید حذف می‌شود، یادداشت‌ها و نظرات الصاق‌شده به آن چه می‌شود؟**

[Notes](/slides/fa/java/presentation-notes/) و [comments](/slides/fa/java/presentation-comments/) به آن اسلاید خاص وابسته‌اند و همراه با آن حذف می‌شوند. محتویات اسلایدهای دیگر تحت تأثیر قرار نمی‌گیرد.

**حذف اسلایدها چگونه با پاک‌سازی طرح‌بندی‌ها/مسترهای استفاده‌نشده متفاوت است؟**

حذف اسلایدها اسلایدهای عادی خاصی را از مجموعه حذف می‌کند. پاک‌سازی طرح‌بندی‌ها/مسترهای استفاده‌نشده، اسلایدهای طرح‌بندی یا مستری را که هیچ‌کسی به آن‌ها ارجاع نمی‌دهد، حذف می‌کند، که باعث کاهش حجم فایل می‌شود بدون آنکه محتوای اسلایدهای باقی‌مانده تغییر کند. این دو عمل مکمل یکدیگر هستند: معمولاً ابتدا حذف می‌کنید و سپس پاک‌سازی را انجام می‌دهید.