---
title: دسترسی به اسلایدهای ارائه در جاوا
linktitle: دسترسی به اسلاید
type: docs
weight: 20
url: /fa/java/access-slide-in-presentation/
keywords:
- دسترسی به اسلاید
- شاخص اسلاید
- شناسه اسلاید
- موقعیت اسلاید
- تغییر موقعیت
- ویژگی‌های اسلاید
- شماره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه اسلایدها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Java دسترسی و مدیریت کنید. با مثال‌های کد بهره‌وری خود را افزایش دهید."
---
## **بررسی کلی**

این مقاله نحوه دسترسی و مدیریت اسلایدها در یک ارائه با استفاده از Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه اسلایدها را بر اساس شاخص صفر‑پایه از مجموعه اسلایدها بازیابی کنید و چگونه با استفاده از متد `getSlideById` به اسلایدی با شناسهٔ یکتا دسترسی پیدا کنید.

همچنین می‌آموزید که با استفاده از متد `setSlideNumber` موقعیت یک اسلاید را تغییر دهید و با متد `setFirstSlideNumber` شمارهٔ شروع اسلایدها را برای یک ارائه تعیین کنید. مثال‌ها بارگذاری یک ارائه، دریافت مراجع اسلایدها، به‌روزرسانی ترتیب یا شماره‌گذاری اسلایدها و ذخیرهٔ ارائهٔ اصلاح‌شده را نشان می‌دهند.

## **دسترسى به اسلاید بر اساس شاخص**

تمام اسلایدهای یک ارائه به صورت عددی بر اساس موقعیت اسلاید از صفر شروع می‌شوند. اسلاید اول از طریق شاخص 0 قابل دسترسی است؛ اسلاید دوم از طریق شاخص 1؛ و غیره.

کلاس Presentation که نمایانگر یک فایل ارائه است، تمام اسلایدها را به صورت یک مجموعهٔ [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) (مجموعه‌ای از اشیای [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/)) ارائه می‌دهد. این کد جاوا نشان می‌دهد چگونه از طریق شاخص به یک اسلاید دسترسی پیدا کنید:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("demo.pptx");
try {
    // یک اسلاید را با استفاده از شاخص اسلاید آن دسترسی می‌یابد
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **دسترسى به اسلاید بر حسب شناسه**

هر اسلاید در یک ارائه یک شناسهٔ یکتا دارد. می‌توانید با استفاده از متد [getSlideById](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlideById-long-) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ارائه می‌شود) به این شناسه مراجعه کنید. این کد جاوا نشان می‌دهد چگونه یک شناسهٔ اسلاید معتبر ارائه دهید و از طریق متد [getSlideById](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlideById-long-) به آن اسلاید دسترسی پیدا کنید:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("demo.pptx");
try {
    // شناسه یک اسلاید را دریافت می‌کند
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // اسلاید را از طریق شناسهٔ آن دسترسی می‌یابد
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **تغییر موقعیت اسلاید**

Aspose.Slides به شما امکان تغییر موقعیت یک اسلاید را می‌دهد. برای مثال می‌توانید تعیین کنید که اسلاید اول به اسلاید دوم تبدیل شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلایدی که می‌خواهید موقعیت آن را تغییر دهید، از طریق شاخص آن دریافت کنید.  
1. موقعیت جدید را برای اسلاید از طریق ویژگی [setSlideNumber](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#setSlideNumber-int-) تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد جاوا عملی را نشان می‌دهد که در آن اسلاید در موقعیت 1 به موقعیت 2 منتقل می‌شود:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("Presentation.pptx");
try {
    // اسلایدی را که موقعیت آن تغییر خواهد کرد دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);
    
    // موقعیت جدید را برای اسلاید تنظیم می‌کند
    sld.setSlideNumber(2);
    
    // ارائهٔ اصلاح‌شده را ذخیره می‌کند
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

اسلاید اول به اسلاید دوم تبدیل شد؛ اسلاید دوم به اسلاید اول. وقتی موقعیت یک اسلاید را تغییر می‌دهید، سایر اسلایدها به‌صورت خودکار تنظیم می‌شوند.

## **تنظیم شماره اسلاید**

با استفاده از ویژگی [setFirstSlideNumber](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ارائه می‌شود)، می‌توانید شمارهٔ جدیدی برای اسلاید اول یک ارائه تعیین کنید. این عملیات باعث محاسبهٔ مجدد شماره‌های سایر اسلایدها می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.  
1. شماره اسلاید را دریافت کنید.  
1. شماره اسلاید را تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد جاوا عملی را نشان می‌دهد که در آن شمارهٔ اسلاید اول به 10 تنظیم می‌شود:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // شماره اسلاید را دریافت می‌کند
    int firstSlideNumber = pres.getFirstSlideNumber();

    // شماره اسلاید را تنظیم می‌کند
    pres.setFirstSlideNumber(10);
    
    // ارائهٔ اصلاح‌شده را ذخیره می‌کند
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

اگر ترجیح می‌دهید اسلاید اول را حذف نکنید، می‌توانید شماره‌گذاری را از اسلاید دوم شروع کنید (و شماره‌گذاری اسلاید اول را مخفی کنید) به این شکل:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // شماره اسلاید اول ارائه را تنظیم می‌کند
    presentation.setFirstSlideNumber(0);

    // شماره اسلایدها را برای همه اسلایدها نمایش می‌دهد
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // شماره اسلاید برای اولین اسلاید را مخفی می‌کند
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // ارائهٔ اصلاح‌شده را ذخیره می‌کند
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **سوالات متداول**

**آیا شماره اسلایدی که کاربر می‌بیند با شاخص صفر‑پایهٔ مجموعه مطابقت دارد؟**  
عدد نشان‌داده‌شده بر روی اسلاید می‌تواند از مقدار دلخواهی (مثلاً 10) شروع شود و نیازی به تطابق با شاخص ندارد؛ این رابطه توسط تنظیمات [first slide number](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ارائه کنترل می‌شود.

**آیا اسلایدهای مخفی بر ترتیب شاخص‌ها تأثیر می‌گذارند؟**  
بله. یک اسلاید مخفی در مجموعه باقی می‌ماند و در شمارش شاخص‌ها محاسبه می‌شود؛ “مخفی” فقط به نمایش مربوط می‌شود، نه به موقعیت آن در مجموعه.

**آیا شاخص یک اسلاید هنگام افزودن یا حذف اسلایدهای دیگر تغییر می‌کند؟**  
بله. شاخص‌ها همیشه ترتیب جاری اسلایدها را بازتاب می‌دهند و هنگام وارد کردن، حذف یا جابجایی اسلایدها مجدداً محاسبه می‌شوند.