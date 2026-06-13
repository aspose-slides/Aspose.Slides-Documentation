---
title: دسترسی به اسلایدهای ارائه در JavaScript
linktitle: دسترسی به اسلاید
type: docs
weight: 20
url: /fa/nodejs-java/access-slide-in-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "چگونگی دسترسی و مدیریت اسلایدها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js را بیاموزید. با مثال‌های کد، بهره‌وری را افزایش دهید."
---
## **نمای کلی**

این مقاله نحوه دسترسی و مدیریت اسلایدها در یک ارائه با استفاده از Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه اسلایدها را بر اساس اندیس صفر‑مبنای خود از مجموعه اسلایدها بازیابی کنید و چگونه با استفاده از متد `getSlideById` به اسلایدی با شناسهٔ یکتا دسترسی پیدا کنید.

همچنین یاد می‌گیرید چگونه موقعیت یک اسلاید را با استفاده از متد `setSlideNumber` تغییر دهید و چگونه شمارهٔ شروع اسلاید برای یک ارائه را با متد `setFirstSlideNumber` تعیین کنید. مثال‌ها بارگذاری یک ارائه، دریافت ارجاع به اسلایدها، به‌روزرسانی ترتیب یا شماره‌گذاری اسلایدها و ذخیرهٔ ارائهٔ اصلاح‌شده را نشان می‌دهند.

## **دسترسی به اسلاید بر اساس اندیس**

تمام اسلایدهای یک ارائه به صورت عددی بر اساس موقعیت اسلاید از صفر مرتب می‌شوند. اسلاید اول از طریق اندیس 0 قابل دسترسی است؛ اسلاید دوم از طریق اندیس 1؛ و غیره.

کلاس Presentation که نمایانگر یک فایل ارائه است، تمام اسلایدها را به شکل یک مجموعهٔ [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) (مجموعه‌ای از اشیاء [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/)) در اختیار می‌گذارد. این کد JavaScript نشان می‌دهد چگونه یک اسلاید را از طریق اندیس آن دسترسی پیدا کنید:

```javascript
// یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // با استفاده از اندیس اسلاید، به اسلاید دسترسی می‌یابد
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **دسترسی به اسلاید بر اساس شناسه**

هر اسلاید در یک ارائه دارای یک شناسهٔ یکتا است. می‌توانید از متد [getSlideById](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ارائه می‌شود) برای هدف‌گذاری آن شناسه استفاده کنید. این کد JavaScript نشان می‌دهد چگونه یک شناسهٔ اسلاید معتبر فراهم کنید و از طریق متد [getSlideById](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSlideById-long-) به آن اسلاید دسترسی پیدا کنید:

```javascript
// یک شیء Presentation را ایجاد می‌کند که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // یک شناسه اسلاید را دریافت می‌کند
    var id = pres.getSlides().get_Item(0).getSlideId();
    // با استفاده از شناسهٔ آن، به اسلاید دسترسی می‌یابد
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **تغییر موقعیت اسلاید**

Aspose.Slides به شما اجازه می‌دهد موقعیت یک اسلاید را تغییر دهید. برای مثال می‌توانید مشخص کنید که اسلاید اول به اسلاید دوم تبدیل شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلایدی که می‌خواهید موقعیت آن را تغییر دهید، از طریق اندیس آن دریافت کنید.  
3. موقعیت جدیدی برای اسلاید از طریق ویژگی [setSlideNumber](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#setSlideNumber-int-) تعیین کنید.  
4. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد JavaScript عملی را نشان می‌دهد که در آن اسلاید در موقعیت 1 به موقعیت 2 منتقل می‌شود:

```javascript
// یک شیء Presentation را ایجاد می‌کند که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // اسلایدی که موقعیت آن تغییر خواهد کرد را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // موقعیت جدید اسلاید را تنظیم می‌کند
    sld.setSlideNumber(2);
    // ذخیرهٔ ارائهٔ اصلاح‌شده
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

اسلاید اول به دوم تبدیل شد؛ اسلاید دوم به اولین اسلاید تبدیل شد. وقتی موقعیت یک اسلاید را تغییر می‌دهید، سایر اسلایدها به‌صورت خودکار تنظیم می‌شوند.

## **تنظیم شماره اسلاید**

با استفاده از ویژگی [setFirstSlideNumber](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ارائه می‌شود)، می‌توانید شمارهٔ جدیدی برای اولین اسلاید در یک ارائه تعیین کنید. این عملیات باعث می‌شود شماره‌های دیگر اسلایدها مجدداً محاسبه شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.  
2. شمارهٔ اسلاید را دریافت کنید.  
3. شمارهٔ اسلاید را تنظیم کنید.  
4. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد JavaScript عملی را نشان می‌دهد که در آن شمارهٔ اولین اسلاید به 10 تنظیم می‌شود:

```javascript
// یک شیء Presentation را ایجاد می‌کند که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // شماره اسلاید را دریافت می‌کند
    var firstSlideNumber = pres.getFirstSlideNumber();
    // شماره اسلاید را تنظیم می‌کند
    pres.setFirstSlideNumber(10);
    // ذخیرهٔ ارائهٔ اصلاح‌شده
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

اگر مایل هستید اسلاید اول را نادیده بگیرید، می‌توانید شماره‌گذاری را از اسلاید دوم آغاز کنید (و شماره‌گذاری اسلاید اول را مخفی کنید) به این شکل:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // شمارهٔ اولین اسلاید ارائه را تنظیم می‌کند
    // شماره اسلایدها را برای تمام اسلایدها نمایش می‌دهد
    // شماره اسلاید اولین اسلاید را مخفی می‌کند
    // ارائهٔ اصلاح‌شده را ذخیره می‌کند
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **سؤال‌های متداول**

**آیا شمارهٔ اسلایدی که کاربر می‌بیند با اندیس صفر‑مبنای مجموعه مطابقت دارد؟**

شمارهٔ نشان‌داده‌شده بر روی اسلاید می‌تواند از مقدار دلخواهی (مثلاً 10) شروع شود و نیازی به مطابقت با اندیس ندارد؛ این رابطه توسط تنظیم «شمارهٔ اولین اسلاید» ارائه کنترل می‌شود.

**آیا اسلایدهای مخفی بر ایندکس‌گذاری تأثیر می‌گذارند؟**

بله. یک اسلاید مخفی همچنان در مجموعه باقی می‌ماند و در ایندکس‌گذاری شمرده می‌شود؛ «مخفی» فقط به نمایش اشاره دارد، نه به موقعیت آن در مجموعه.

**آیا اندیس یک اسلاید وقتی اسلایدهای دیگر اضافه یا حذف می‌شوند تغییر می‌کند؟**

بله. اندیس‌ها همیشه order فعلی اسلایدها را منعکس می‌کنند و هنگام درج، حذف یا جابجایی اسلایدها بازمحاسبه می‌شوند.