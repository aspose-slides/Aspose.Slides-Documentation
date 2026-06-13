---
title: کلون اسلایدهای ارائه در جاوا
linktitle: کلون اسلایدها
type: docs
weight: 35
url: /fa/java/clone-slides/
keywords:
- کلون اسلاید
- کپی اسلاید
- ذخیره اسلاید
- پاورپوینٹ
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "اسلایدهای PowerPoint را به سرعت با Aspose.Slides برای Java تکثیر کنید. مثال‌های واضح کد ما را دنبال کنید تا ایجاد PPT را در چند ثانیه خودکار کنید و کار دستی را از بین ببرید."
---
## **مقدمه**

کلون‌سازی فرایندی است که نسخه‌ای دقیق یا تکثیر کاملاً مشابه از یک شیء را ایجاد می‌کند. Aspose.Slides for Java همچنین امکان ایجاد یک نسخه یا کلون از هر اسلاید را فراهم می‌کند و سپس آن اسلاید کلون شده را به ارائهٔ جاری یا هر ارائهٔ دیگری که باز است، وارد می‌کند. فرآیند کلون‌سازی اسلاید یک اسلاید جدید ایجاد می‌کند که می‌تواند توسط توسعه‌دهندگان بدون تغییر اسلاید اصلی اصلاح شود. چندین روش ممکن برای کلون‌سازی یک اسلاید وجود دارد:

- کلون‌سازی در انتهای یک ارائه.
- کلون‌سازی در موقعیتی دیگر درون یک ارائه.
- کلون‌سازی در انتهای یک ارائهٔ دیگر.
- کلون‌سازی در موقعیتی دیگر در یک ارائهٔ دیگر.
- کلون‌سازی در موقعیت خاصی در یک ارائهٔ دیگر.

در Aspose.Slides for Java، (مجموعه‌ای از اشیاء [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) نمایش داده می‌شود) متدهای [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) و [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) را برای انجام انواع فوق کلون‌سازی اسلاید فراهم می‌کند.

## **کلون‌سازی یک اسلاید در انتهای یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائهٔ جاری، در انتهای اسلایدهای موجود استفاده کنید، از متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) طبق مراحل زیر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) نمایش داده می‌شود، فراخوانی کنید و اسلایدی که می‌خواهید کلون شود را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) پاس بدهید.
1. فایل ارائهٔ اصلاح‌شده را بنویسید.

در مثال زیر، ما اسلایدی (که در اولین موقعیت – ایندکس صفر – ارائه قرار داشت) را به انتهای ارائه کلون کردیم.

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // اسلاید مورد نظر را به انتهای مجموعه اسلایدها در همان ارائه کلون کنید
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // ارائهٔ اصلاح‌شده را روی دیسک ذخیره کنید
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون‌سازی یک اسلاید در موقعیت دیگری درون یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائهٔ جاری، اما در موقعیتی متفاوت استفاده کنید، از متد [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. کلاس را با ارجاع به مجموعه **Slides** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) نمایش داده می‌شود، فراخوانی کنید و اسلایدی که می‌خواهید کلون شود همراه با اندیس موقعیت جدید را به عنوان پارامتر به متد [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) پاس بدهید.
1. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.

در مثال زیر، ما اسلایدی (که در ایندکس صفر – موقعیت 1 – ارائه قرار داشت) را به ایندکس 1 – موقعیت 2 – ارائه کلون کردیم.

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // اسلاید مورد نظر را به انتهای مجموعه اسلایدها در همان ارائه کلون کنید
    ISlideCollection slds = pres.getSlides();

    // اسلاید مورد نظر را به اندیس مشخص شده در همان ارائه کلون کنید
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // ارائهٔ اصلاح‌شده را روی دیسک ذخیره کنید
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون‌سازی یک اسلاید در انتهای یک ارائهٔ دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه بردارید و در انتهای اسلایدهای موجود یک ارائهٔ دیگر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه‌ای است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ مقصد است که اسلاید به آن اضافه می‌شود.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection) را با ارجاع به مجموعه **Slides** که توسط شیء Presentation ارائهٔ مقصد نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) نمایش داده می‌شود، فراخوانی کنید و اسلایدی از ارائهٔ منبع را به عنوان پارامتر به این متد پاس بدهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، ما اسلایدی (از اولین ایندکس ارائهٔ منبع) را به انتهای ارائهٔ مقصد کلون کردیم.

```java
// یک نمونه از کلاس Presentation برای بارگذاری فایل ارائه منبع ایجاد کنید
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // یک نمونه از کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود) ایجاد کنید
    Presentation destPres = new Presentation();
    try {
        // اسلاید مورد نظر را از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد کلون کنید
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // ارائه مقصد را روی دیسک ذخیره کنید
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون‌سازی یک اسلاید در موقعیت دیگری در یک ارائهٔ دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه بردارید و در موقعیت خاصی از یک ارائهٔ دیگر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ منبع است.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ مقصد است.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء Presentation ارائهٔ مقصد نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) نمایش داده می‌شود، فراخوانی کنید و اسلایدی از ارائهٔ منبع همراه با موقعیت دلخواه را به عنوان پارامتر به این متد پاس بدهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، ما اسلایدی (از ایندکس صفر ارائهٔ منبع) را به ایندکس 1 (موقعیت 2) ارائهٔ مقصد کلون کردیم.

```java
// یک نمونه از کلاس Presentation برای بارگذاری فایل ارائهٔ منبع ایجاد کنید
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // یک نمونه از کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید باید کلون شود) ایجاد کنید
    Presentation destPres = new Presentation();
    try {
        // اسلاید مورد نظر را از ارائهٔ منبع به انتهای مجموعه اسلایدها در ارائهٔ مقصد کلون کنید
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // ارائهٔ مقصد را روی دیسک ذخیره کنید
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون‌سازی یک اسلاید در موقعیت خاصی در یک ارائهٔ دیگر**
اگر نیاز دارید اسلایدی همراه با اسلاید اصلی (master) از یک ارائه بردارید و در ارائهٔ دیگری استفاده کنید، ابتدا باید اسلاید اصلی مورد نظر را از ارائهٔ منبع به ارائهٔ مقصد کلون کنید. سپس برای کلون‌سازی اسلاید با اسلاید اصلی، از متد [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.IMasterSlide-boolean-) که یک اسلاید اصلی از ارائهٔ مقصد می‌خواهد، استفاده کنید. برای کلون‌سازی اسلاید همراه با اسلاید اصلی، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ منبع است.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائهٔ مقصد است.
1. به اسلایدی که باید کلون شود به همراه اسلاید اصلی آن دسترسی پیدا کنید.
1. کلاس [IMasterSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMasterSlideCollection) را با ارجاع به مجموعه Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ارائهٔ مقصد نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) را که توسط شیء [IMasterSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMasterSlideCollection) نمایش داده می‌شود، فراخوانی کنید و اسلاید اصلی از فایل PPTX منبع را که می‑خواهید کلون شود، به عنوان پارامتر به این متد پاس بدهید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) را با تنظیم ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ارائهٔ مقصد نمایش داده می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) نمایش داده می‌شود، فراخوانی کنید و اسلایدی از ارائهٔ منبع که باید کلون شود و اسلاید اصلی را به عنوان پارامتر به این متد پاس بدهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، ما اسلایدی همراه با اسلاید اصلی (که در ایندکس صفر ارائهٔ منبع قرار داشت) را با استفاده از اسلاید اصلی منبع به انتهای ارائهٔ مقصد کلون کردیم.

```java
// یک نمونه از کلاس Presentation برای بارگذاری فایل ارائهٔ منبع ایجاد کنید
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // یک نمونه از کلاس Presentation برای ارائهٔ مقصد (جایی که اسلاید باید کلون شود) ایجاد کنید
    Presentation destPres = new Presentation();
    try {
        // یک نمونه از ISlide را از مجموعه اسلایدها در ارائهٔ منبع به همراه
        // اسلاید اصلی
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // اسلاید اصلی مورد نظر را از ارائهٔ منبع به مجموعهٔ اسلایدهای اصلی در
        // ارائهٔ مقصد
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // اسلاید اصلی مورد نظر را از ارائهٔ منبع به مجموعهٔ اسلایدهای اصلی در
        // ارائهٔ مقصد
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // اسلاید مورد نظر را از ارائهٔ منبع همراه با اسلاید اصلی دلخواه به انتهای
        // مجموعهٔ اسلایدها در ارائهٔ مقصد
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // ارائهٔ مقصد را روی دیسک ذخیره کنید
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون‌سازی یک اسلاید در انتهای بخشی مشخص**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائهٔ جاری، اما در بخشی متفاوت استفاده کنید، از متد [**addClone**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) که توسط رابط [**ISlideCollection**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection) ارائه می‌شود، استفاده کنید. Aspose.Slides for Java امکان کلون‌سازی اسلایدی از بخش اول و سپس وارد کردن آن کلون به بخش دوم همان ارائه را فراهم می‌کند.

کد زیر نشان می‌دهد چگونه یک اسلاید را کلون کنید و اسلاید کلون‌شده را به یک بخش مشخص وارد کنید.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// ارائهٔ مقصد را روی دیسک ذخیره کنید
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا یادداشت‌های گوینده و نظرات مرورگر کلون می‌شوند؟**

بله. صفحهٔ یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها را داشته باشید، بعد از درج، آن‌ها را [remove them](/slides/fa/java/presentation-notes/) کنید.

**چگونه نمودارها و منابع داده‌ای آن‌ها مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های جاسازی‌شده کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار OLE‑embedded) لینک شده باشد، این لینک به عنوان یک [OLE object](/slides/fa/java/manage-ole/) حفظ می‌شود. پس از جابه‌جایی بین فایل‌ها، دسترس‌پذیری داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در ایندکس اسلاید خاصی وارد کنید و آن را به یک [section](/slides/fa/java/slide-section/) انتخابی منتقل کنید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل نمایید.