---
title: دسترسی به اسلایدهای ارائه در اندروید
linktitle: دسترسی به اسلاید
type: docs
weight: 20
url: /fa/androidjava/access-slide-in-presentation/
keywords:
- دسترسی به اسلاید
- اندیس اسلاید
- شناسه اسلاید
- موقعیت اسلاید
- تغییر موقعیت
- ویژگی‌های اسلاید
- شماره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه اسلایدها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای اندروید دسترسی و مدیریت کنید. بهره‌وری را با مثال‌های کد Java افزایش دهید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه می‌توانید اسلایدها را در یک ارائه با استفاده از Aspose.Slides دسترسی داشته باشید و مدیریت کنید. این مطلب نشان می‌دهد چگونه اسلایدها را بر اساس ایندکس صفر‑پایه از مجموعه اسلایدها بازیابی کنید و چگونه با استفاده از متد `getSlideById` یک اسلاید را بر اساس شناسهٔ منحصر به فرد آن دسترسی پیدا کنید.

همچنین خواهید آموخت چگونه موقعیت یک اسلاید را با استفاده از متد `setSlideNumber` تغییر دهید و چگونه شمارهٔ شروع اسلاید برای یک ارائه را با متد `setFirstSlideNumber` تعریف کنید. مثال‌ها بارگذاری یک ارائه، دریافت ارجاع به اسلایدها، به‑روزرسانی ترتیب یا شماره‌گذاری اسلایدها و ذخیرهٔ ارائهٔ تغییر یافته را نشان می‌دهند.

## **دسترسی به اسلاید بر اساس ایندکس**

تمام اسلایدهای یک ارائه به صورت عددی بر اساس موقعیت اسلاید از صفر ترتیب داده می‌شوند. اسلاید اول از طریق ایندکس 0 قابل دسترسی است؛ اسلاید دوم از طریق ایندکس 1؛ و غیره.

کلاس Presentation که نمایانگر یک فایل ارائه است، تمام اسلایدها را به عنوان مجموعه‌ای از [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) (مجموعه‌ای از اشیاء [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/)) در دسترس قرار می‌دهد. این کد Java نشان می‌دهد چگونه می‌توانید یک اسلاید را از طریق ایندکس آن دسترسی پیدا کنید:

```java
// یک شیء Presentation را که نمایانگر یک فایل ارائه است، ایجاد می‌کند
Presentation pres = new Presentation("demo.pptx");
try {
    // اسلایدی را با استفاده از اندیس اسلاید آن دسترسی می‌یابد
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **دسترسی به اسلاید بر اساس شناسه**

هر اسلاید در یک ارائه یک شناسهٔ یکتا دارد. می‌توانید از متد [getSlideById](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ارائه می‌شود) برای هدف‌گذاری آن شناسه استفاده کنید. این کد Java نشان می‌دهد چگونه یک شناسهٔ اسلاید معتبر فراهم کنید و آن اسلاید را از طریق متد [getSlideById](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlideById-long-) دسترسی پیدا کنید:

```java
// یک شیء Presentation را که نمایانگر یک فایل ارائه است، ایجاد می‌کند
Presentation pres = new Presentation("demo.pptx");
try {
    // شناسهٔ اسلاید را دریافت می‌کند
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // از طریق شناسهٔ اسلاید به آن دسترسی می‌یابد
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **تغییر موقعیت اسلاید**

Aspose.Slides به شما امکان می‌دهد موقعیت یک اسلاید را تغییر دهید. به عنوان مثال، می‌توانید مشخص کنید که اسلاید اول به اسلاید دوم تبدیل شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید (که می‌خواهید موقعیت آن را تغییر دهید) را از طریق ایندکس آن دریافت کنید
1. موقعیت جدیدی برای اسلاید از طریق ویژگی [setSlideNumber](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#setSlideNumber-int-) تنظیم کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد Java عملی را نشان می‌دهد که در آن اسلاید در موقعیت 1 به موقعیت 2 منتقل می‌شود: 

```java
// یک شیء Presentation را که نمایانگر یک فایل ارائه است، ایجاد می‌کند
Presentation pres = new Presentation("Presentation.pptx");
try {
    // اسلایدی را که موقعیت آن تغییر خواهد کرد، دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // موقعیت جدید برای اسلاید تنظیم می‌شود
    sld.setSlideNumber(2);
    
    // ارائهٔ تغییر یافته ذخیره می‌شود
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

اسلاید اول به اسلاید دوم تبدیل شد؛ اسلاید دوم به اسلاید اول. وقتی موقعیت یک اسلاید را تغییر می‌دهید، سایر اسلایدها به‌صورت خودکار تنظیم می‌شوند.

## **تنظیم شمارهٔ اسلاید**

با استفاده از ویژگی [setFirstSlideNumber](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ارائه می‌شود)، می‌توانید شمارهٔ جدیدی برای اولین اسلاید در یک ارائه تعیین کنید. این عمل باعث بازمحاسبهٔ شمارهٔ سایر اسلایدها می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. شمارهٔ اسلاید را دریافت کنید.
1. شمارهٔ اسلاید را تنظیم کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد Java عملی را نشان می‌دهد که در آن شمارهٔ اولین اسلاید به 10 تنظیم می‌شود: 

```java
// یک شیء Presentation را که نمایانگر یک فایل ارائه است، ایجاد می‌کند
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // شمارهٔ اسلاید اول را دریافت می‌کند
    int firstSlideNumber = pres.getFirstSlideNumber();

    // شمارهٔ اسلاید را تنظیم می‌کند
    pres.setFirstSlideNumber(10);
    
    // ارائهٔ تغییر یافته ذخیره می‌شود
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

اگر ترجیح می‌دهید اسلاید اول را رد کنید، می‌توانید شماره‌گذاری را از اسلاید دوم شروع کنید (و شماره‌گذاری اسلاید اول را مخفی کنید) به این روش:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // شمارهٔ اولین اسلاید ارائه را تنظیم می‌کند
    presentation.setFirstSlideNumber(0);

    // شمارهٔ اسلایدها را برای همه اسلایدها نمایش می‌دهد
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // شمارهٔ اسلاید را برای اولین اسلاید مخفی می‌کند
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // ارائهٔ تغییر یافته را ذخیره می‌کند
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **سوالات متداول**

**آیا شمارهٔ اسلایدی که کاربر می‌بیند با ایندکس صفر‑پایهٔ مجموعه مطابقت دارد؟**  
شماره‌ای که بر روی اسلاید نشان داده می‌شود می‌تواند از مقدار دلخواهی (مثلاً 10) شروع شود و نیازی به مطابقت با ایندکس ندارد؛ رابطه توسط تنظیم [first slide number](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ارائه کنترل می‌شود.

**آیا اسلایدهای مخفی بر ایندکس‌گذاری تأثیر می‌گذارند؟**  
بله. یک اسلاید مخفی در مجموعه باقی می‌ماند و در ایندکس‌گذاری شمرده می‌شود؛ «مخفی» به نمایش اشاره دارد، نه به موقعیت آن در مجموعه.

**آیا ایندکس یک اسلاید هنگام افزودن یا حذف اسلایدهای دیگر تغییر می‌کند؟**  
بله. ایندکس‌ها همیشه ترتیب فعلی اسلایدها را نشان می‌دهند و در هنگام درج، حذف و جابجایی اسلایدها بازمحاسبه می‌شوند.