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
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "به سرعت اسلایدهای PowerPoint را با Aspose.Slides برای Node.js کپی کنید. نمونه‌های کد ما را دنبال کنید تا ایجاد PPT را در ثانیه‌ها خودکار کرده و کار دستی را حذف کنید."
---
## **معرفی**

کلون‌کردن فرآیند ساخت یک نسخه دقیق یا تکثیر چیزی است. Aspose.Slides برای Node.js از طریق Java همچنین امکان ساخت یک کپی یا کلون از هر اسلاید را فراهم می‌کند و سپس آن اسلاید کلون‌شده را به ارائهٔ جاری یا هر ارائهٔ دیگری که باز است، درج می‌نماید. فرآیند کلون‌کردن اسلاید یک اسلاید جدید خلق می‌کند که برنامه‌نویسان می‌توانند بدون تغییر اسلاید اصلی، آن را اصلاح کنند. چندین روش ممکن برای کلون‌کردن اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگری درون همان ارائه.
- کلون در انتهای یک ارائهٔ دیگر.
- کلون در موقعیت دیگری در یک ارائهٔ دیگر.
- کلون در موقعیت مشخصی در یک ارائهٔ دیگر.

در Aspose.Slides برای Node.js از طریق Java، (مجموعه‌ای از [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide) objects) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) عرضه می‌شود، متدهای [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) و [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) را برای انجام انواع کلون‌کردن اسلاید ارائه می‌دهد.

## **کلون در انتهای یک ارائه**
اگر می‌خواهید اسلایدی را کلون کنید و سپس در همان فایل ارائه در انتهای اسلایدهای موجود استفاده کنید، مطابق گام‌های زیر از متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) فراهم شده است، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) ارائه شده است، فراخوانی کنید و اسلایدی که باید کلون شود را به عنوان پارامتر به این متد پاس بدهید.
1. فایل ارائهٔ اصلاح‌شده را بنویسید.

در مثال زیر، اسلایدی که در موقعیت اول (شاخص صفر) ارائه قرار دارد، به انتهای ارائه کلون شده است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation که یک فایل ارائه را نشان می‌دهد
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // اسلاید موردنظر را به انتهای مجموعه اسلایدهای همان ارائه کلون کنید
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // ارائهٔ اصلاح‌شده را در دیسک ذخیره کنید
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون در موقعیت دیگری درون ارائه**
اگر می‌خواهید اسلایدی را کلون کنید و سپس در همان فایل ارائه اما در موقعیتی متفاوت استفاده کنید، از متد [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. کلاس را با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) فراهم شده است، نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) عرضه شده است، فراخوانی کنید و اسلایدی که باید کلون شود همراه با اندیس موقعیت جدید را به عنوان پارامتر به این متد پاس بدهید.
1. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.

در مثال زیر، اسلایدی که در شاخص 1 (موقعیت 2) ارائه قرار دارد، به شاخص 2 (موقعیت 3) انتقال پیدا کرده است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation که یک فایل ارائه را نشان می‌دهد
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // اسلاید موردنظر را به انتهای مجموعه اسلایدهای همان ارائه کلون کنید
    var slds = pres.getSlides();
    // اسلاید موردنظر را به اندیس مشخص شده در همان ارائه کلون کنید
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // ارائهٔ اصلاح‌شده را در دیسک ذخیره کنید
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون در انتهای یک ارائهٔ دیگر**
اگر نیاز دارید اسلایدی را از یک ارائه بخوانید و در یک ارائهٔ دیگر، در انتهای اسلایدهای موجود، استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ مبداء باشد.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ مقصد باشد.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection) را با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) که توسط شیء Presentation ارائهٔ مقصد فراهم شده است، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) ارائه شده است، فراخوانی کنید و اسلاید مبداء را به عنوان پارامتر به این متد پاس بدهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، اسلایدی که از شاخص اول ارائهٔ مبداء بوده، به انتهای ارائهٔ مقصد کلون شده است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه مبداء
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید باید کلون شود)
    var destPres = new aspose.slides.Presentation();
    try {
        // اسلاید موردنظر را از ارائه مبداء به انتهای مجموعه اسلایدهای ارائه مقصد کلون کنید
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // ارائهٔ مقصد را بر روی دیسک ذخیره کنید
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون در موقعیت دیگری در یک ارائهٔ دیگر**
اگر نیاز دارید اسلایدی را از یک ارائه بخوانید و در یک ارائهٔ دیگر، در موقعیت مشخصی استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ مبداء باشد.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ مقصد باشد.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء Presentation ارائهٔ مقصد فراهم شده است، نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) ارائه شده است، فراخوانی کنید و اسلاید مبداء را همراه با موقعیت دلخواه به عنوان پارامتر به این متد پاس بدهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، اسلایدی که از شاخص صفر ارائهٔ مبداء بود، به شاخص 1 (موقعیت 2) ارائهٔ مقصد منتقل شده است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه مبداء
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید باید کلون شود)
    var destPres = new aspose.slides.Presentation();
    try {
        // اسلاید موردنظر را از ارائه مبداء به انتهای مجموعه اسلایدهای ارائه مقصد کلون کنید
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // ارائهٔ مقصد را بر روی دیسک ذخیره کنید
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون در موقعیت مشخصی در یک ارائهٔ دیگر**
اگر نیاز دارید اسلایدی همراه با اسلاید مستر را از یک ارائه بخوانید و در یک ارائهٔ دیگر استفاده کنید، ابتدا باید اسلاید مستر موردنظر را از ارائهٔ مبداء به ارائهٔ مقصد کلون کنید. سپس برای کلون‌کردن اسلاید با مستر، باید از مستر کلون‌شدهٔ مقصد استفاده کنید. متد [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) انتظار دارد مستر اسلاید از ارائهٔ مقصد باشد نه مبداء. برای کلون‌کردن اسلاید با مستر، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ مبداء باشد.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ مقصد باشد.
1. به اسلایدی که باید کلون شود به همراه مستر آن دسترسی پیدا کنید.
1. کلاس [MasterSlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterSlideCollection) را با ارجاع به مجموعه Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ارائهٔ مقصد فراهم شده است، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را که توسط شیء [MasterSlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterSlideCollection) عرضه شده است، فراخوانی کنید و مستر مبداء را به عنوان پارامتر به این متد پاس بدهید.
1. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ارائهٔ مقصد فراهم شده است، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) عرضه شده است، فراخوانی کنید و اسلاید مبداء به همراه مستر مقصد را به عنوان پارامتر به این متد پاس بدهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، اسلایدی همراه با مستر (در شاخص صفر ارائهٔ مبداء) به انتهای ارائهٔ مقصد، با استفاده از مستر مبداء کلون شده است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه مبداء
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    var destPres = new aspose.slides.Presentation();
    try {
        // نمونه‌سازی ISlide از مجموعه اسلایدهای ارائه مبداء همراه با
        // اسلاید مستر
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // کلون اسلاید مستر موردنظر از ارائه مبداء به مجموعه مسترها در
        // ارائه مقصد
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // کلون اسلاید موردنظر از ارائه مبداء با مستر موردنظر به انتهای
        // مجموعه اسلایدهای ارائه مقصد
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // ذخیرهٔ ارائه مقصد روی دیسک
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون در انتهای یک بخش مشخص**
اگر می‌خواهید اسلایدی را کلون کنید و سپس در همان فایل ارائه اما در بخش متفاوتی استفاده کنید، متد [**addClone**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) را که توسط کلاس [**SlideCollection**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection) ارائه می‌شود، به کار ببرید. Aspose.Slides برای Node.js از طریق Java امکان کلون‌کردن اسلاید از بخش اول و سپس درج آن در بخش دوم همان ارائه را فراهم می‌کند.

کد زیر نشان می‌دهد چگونه اسلایدی را کلون کرده و کلون را در یک بخش مشخص وارد کنید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // ذخیرهٔ ارائه مقصد روی دیسک
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **اطمینان از تطابق اندازه اسلاید**

هنگام کلون‌کردن اسلایدها به ارائه‌ای دیگر، اطمینان حاصل کنید که اندازهٔ اسلاید ارائهٔ مقصد با مبداء یکسان باشد. اگر اندازه‌ها متفاوت باشند، Aspose.Slides به‌صورت خودکار شکل‌های کلون‌شده را بازنشانی نمی‌کند؛ مختصات و ابعاد اصلی آن‌ها حفظ می‌شود که ممکن است محتوا به‌صورت نامرتب یا خارج از مرزهای اسلاید نمایش داده شود.

قبل از کلون‌کردن مستر و اسلاید می‌توانید اندازهٔ اسلاید ارائهٔ مقصد را برای تطابق با مبداء تنظیم کنید:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

این کار را پیش از کلون‌کردن مستر و اسلاید انجام دهید.

## **سوالات متداول**

**آیا یادداشت‌های سخنران و نظرات مرورگر کلون می‌شوند؟**

بله. صفحهٔ یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آن‌ها را داشته باشید، پس از درج [آنها را حذف کنید](/slides/fa/nodejs-java/presentation-notes/).

**نمودارها و منابع داده‌ای آن‌ها چگونه مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های داخلی کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار OLE-ادغام‌شده) لینک داشته باشد، این لینک به‌عنوان یک [شیء OLE](/slides/fa/nodejs-java/manage-ole/) حفظ می‌شود. پس از انتقال بین فایل‌ها، موجودیت داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در یک شاخص اسلاید خاص درج کرده و آن را به یک [بخش](/slides/fa/nodejs-java/slide-section/) انتخابی منتقل کنید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل نمایید.