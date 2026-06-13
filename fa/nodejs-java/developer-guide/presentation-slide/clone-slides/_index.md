---
title: کلون اسلایدهای ارائه در جاوااسکریپت
linktitle: کلون اسلایدها
type: docs
weight: 35
url: /fa/nodejs-java/clone-slides/
keywords:
- کلون اسلاید
- کپی اسلاید
- ذخیره اسلاید
- پاورپوینت
- سند باز
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "به سرعت اسلایدهای پاورپوینت را با Aspose.Slides برای Node.js تکثیر کنید. مثال‌های کد ما را دنبال کنید تا ایجاد PPT را در ثانیه‌ها خودکار کنید و کارهای دستی را حذف کنید."
---
## **مقدمه**

کلون کردن فرآیند ایجاد یک کپی دقیق یا نسخهٔ مشابه از چیزی است. Aspose.Slides برای Node.js از طریق Java همچنین امکان ایجاد یک کپی یا کلون از هر اسلایدی را فراهم می‌کند و سپس آن اسلاید کلون‌شده را به ارائهٔ فعلی یا هر ارائهٔ دیگری که باز است، درج می‌کند. فرآیند کلون‌سازی اسلاید یک اسلاید جدید ایجاد می‌کند که می‌تواند توسط توسعه‌دهندگان بدون تغییر اسلاید اصلی، اصلاح شود. چند روش مختلف برای کلون کردن یک اسلاید وجود دارد:

- کلون در انتها درون یک ارائه.
- کلون در موقعیت دیگری درون ارائه.
- کلون در انتها در یک ارائهٔ دیگر.
- کلون در موقعیت دیگری در یک ارائهٔ دیگر.
- کلون در موقعیت خاصی در یک ارائهٔ دیگر.

در Aspose.Slides برای Node.js از طریق Java، (مجموعه‌ای از اشیاء [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) نمایان می‌شود) متدهای [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) و [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) را برای انجام انواع کلون‌سازی اسلاید فوق‌الذکر فراهم می‌کند

## **کلون در انتها درون یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه در انتهای اسلایدهای موجود استفاده کنید، متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را طبق مراحل زیر به کار ببرید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) نمایان می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) نمایان می‌شود، فراخوانی کنید و اسلایدی که باید کلون شود را به‌عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) پاس دهید.
1. فایل ارائهٔ اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید (که در اولین موقعیت – ایندکس صفر – ارائه قرار داشت) را به انتهای ارائه کلون کرده‌ایم.

```javascript
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // کلون اسلاید موردنظر به انتهای مجموعه اسلایدها در همان ارائه
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // نوشتن ارائهٔ اصلاح‌شده به دیسک
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون در موقعیت دیگری درون ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه اما در موقعیت متفاوتی استفاده کنید، از متد [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. کلاس را با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) نمایان می‌شود، نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) نمایان می‌شود، فراخوانی کنید و اسلایدی که باید کلون شود را به همراه ایندکس موقعیت جدید به‌عنوان پارامتر به متد [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) پاس دهید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

در مثال زیر، یک اسلاید (که در ایندکس صفر – موقعیت 1 – ارائه قرار داشت) را به ایندکس 1 – موقعیت 2 – ارائه کلون کرده‌ایم.

```javascript
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // کلون اسلاید موردنظر به انتهای مجموعه اسلایدها در همان ارائه
    var slds = pres.getSlides();
    // کلون اسلاید موردنظر به ایندکس مشخص در همان ارائه
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // نوشتن ارائهٔ اصلاح‌شده به دیسک
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون در انتها در یک ارائهٔ دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در فایل ارائهٔ دیگری، در انتهای اسلایدهای موجود استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که شامل ارائه‌ای است که اسلاید از آن کلون خواهد شد، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که شامل ارائهٔ مقصد است که اسلاید به آن اضافه خواهد شد، ایجاد کنید.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection) را با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) که توسط شیء Presentation ارائهٔ مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) نمایان می‌شود، فراخوانی کنید و اسلاید از ارائهٔ منبع را به‌عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید (از ایندکس اول ارائهٔ منبع) را به انتهای ارائهٔ مقصد کلون کرده‌ایم.

```javascript
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود)
    var destPres = new aspose.slides.Presentation();
    try {
        // کلون اسلاید موردنظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // نوشتن ارائه مقصد به دیسک
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون در موقعیت دیگری در یک ارائهٔ دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در فایل ارائهٔ دیگری، در موقعیت خاصی استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که شامل ارائهٔ منبع است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که شامل ارائه‌ای است که اسلاید به آن اضافه می‌شود، ایجاد کنید.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء Presentation ارائهٔ مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) نمایان می‌شود، فراخوانی کنید و اسلاید از ارائهٔ منبع را به همراه موقعیت موردنظر به‌عنوان پارامتر به متد [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید (از ایندکس صفر ارائهٔ منبع) را به ایندکس 1 (موقعیت 2) ارائهٔ مقصد کلون کرده‌ایم.

```javascript
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود)
    var destPres = new aspose.slides.Presentation();
    try {
        // کلون اسلاید موردنظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // نوشتن ارائه مقصد به دیسک
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون در موقعیت خاص در یک ارائهٔ دیگر**
اگر نیاز دارید یک اسلاید همراه با اسلاید مادر را از یک ارائه کلون کنید و در ارائهٔ دیگری استفاده کنید، ابتدا باید اسلاید مادر موردنظر را از ارائهٔ منبع به ارائهٔ مقصد کلون کنید. سپس باید از آن اسلاید مادر برای کلون اسلاید همراه با اسلاید مادر استفاده کنید. متد [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) انتظار دارد اسلاید مادر از ارائهٔ مقصد باشد، نه از ارائهٔ منبع. برای کلون اسلاید همراه با اسلاید مادر، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که شامل ارائهٔ منبع است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که شامل ارائهٔ مقصد است که اسلاید به آن کلون می‌شود، ایجاد کنید.
1. به اسلایدی که باید کلون شود به همراه اسلاید مادر دسترسی پیدا کنید.
1. کلاس [MasterSlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterSlideCollection) را با ارجاع به مجموعه Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ارائهٔ مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را که توسط شیء [MasterSlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterSlideCollection) نمایان می‌شود، فراخوانی کنید و اسلاید مادر از فایل PPTX منبع که باید کلون شود را به‌عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) پاس دهید.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) را با تنظیم ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ارائهٔ مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) نمایان می‌شود، فراخوانی کنید و اسلاید از ارائهٔ منبع که باید کلون شود و اسلاید مادر را به‌عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید همراه با اسلاید مادر (در ایندکس صفر ارائهٔ منبع) را به انتهای ارائهٔ مقصد با استفاده از اسلاید مادر از اسلاید منبع کلون کرده‌ایم.

```javascript
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    var destPres = new aspose.slides.Presentation();
    try {
        // نمونه‌سازی ISlide از مجموعه اسلایدها در ارائه منبع همراه با
        // اسلاید مادر
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // کلون اسلاید مادر موردنظر از ارائه منبع به مجموعهٔ اسلایدهای مادر در
        // ارائه مقصد
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // کلون اسلاید مادر موردنظر از ارائه منبع به مجموعهٔ اسلایدهای مادر در
        // ارائه مقصد
        var iSlide = masters.addClone(SourceMaster);
        // کلون اسلاید موردنظر از ارائه منبع با اسلاید مادر موردنظر به انتهای
        // مجموعهٔ اسلایدها در ارائه مقصد
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // ذخیرهٔ ارائه مقصد به دیسک
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون در انتها در بخش مشخصی**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه اما در بخش متفاوتی استفاده کنید، متد [**addClone**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) را که توسط کلاس [**SlideCollection**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection) نمایان می‌شود، به‌کار ببرید. Aspose.Slides برای Node.js از طریق Java امکان کلون اسلاید از بخش اول و سپس درج آن اسلاید کلون‌شده در بخش دوم همان ارائه را فراهم می‌کند.

کد نمونه زیر نشان می‌دهد چگونه یک اسلاید را کلون کنید و اسلاید کلون‌شده را در یک بخش مشخص درج کنید.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // ذخیرهٔ ارائه مقصد به دیسک
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **سوالات متداول**

**آیا یادداشت‌های سخنران و نظرات مرورگر کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات مرور در کلون گنجانده می‌شوند. اگر نمی‌خواهید آن‌ها را داشته باشید، پس از درج، [آن‌ها را حذف کنید](/slides/fa/nodejs-java/presentation-notes/).

**نمودارها و منابع داده آن‌ها چگونه مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های جاسازی‌شده کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار OLE جاسازی‌شده) لینک شده باشد، آن لینک به‌صورت یک [OLE object](/slides/fa/nodejs-java/manage-ole/) حفظ می‌شود. پس از جابجایی بین فایل‌ها، در دسترس بودن داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در یک ایندکس اسلاید خاص وارد کنید و آن را در یک [section](/slides/fa/nodejs-java/slide-section/) انتخابی قرار دهید. اگر بخش هدف وجود نداشت، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل کنید.