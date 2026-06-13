---
title: کلون اسلایدهای ارائه در اندروید
linktitle: کلون اسلایدها
type: docs
weight: 35
url: /fa/androidjava/clone-slides/
keywords:
- کلون اسلاید
- کپی اسلاید
- ذخیره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint را با Aspose.Slides برای Android کپی کنید. با دنبال کردن مثال‌های واضح کد Java ما، ایجاد خودکار فایل‌های PPT را در چند ثانیه انجام دهید و کار دستی را حذف کنید."
---
## **مقدمه**

کلونینگ فرایند ساخت یک نسخه دقیق یا تکرار چیزی است. Aspose.Slides برای Android از طریق Java نیز امکان ساخت یک نسخه یا کلون از هر اسلاید و سپس قرار دادن آن اسلاید کلون‌شده در ارائه جاری یا هر ارائه دیگری که باز است را فراهم می‌کند. فرایند کلونینگ اسلاید یک اسلاید جدید ایجاد می‌کند که می‌تواند توسط توسعه‌دهندگان بدون تغییر اسلاید اصلی اصلاح شود. چند روش ممکن برای کلون کردن اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگر داخل ارائه.
- کلون در انتهای یک ارائه دیگر.
- کلون در موقعیت دیگر در یک ارائه دیگر.
- کلون در موقعیت خاصی در یک ارائه دیگر.

در Aspose.Slides برای Android از طریق Java، (یک مجموعه از اشیاء [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlide) ) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ارائه می‌شود، متدهای [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) را برای انجام انواع کلونینگ اسلاید فوق فراهم می‌کند.

## **کلون کردن یک اسلاید در انتهای یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه در انتهای اسلایدهای موجود استفاده کنید، از متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) طبق مراحل زیر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ارائه می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) در دسترس است، فراخوانی کنید و اسلایدی که باید کلون شود را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائه تغییر یافته را بنویسید.

در مثال زیر، اسلایدی که در موقعیت اول (شاخص صفر) ارائه قرار داشت را به انتهای ارائه کلون کردیم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // اسلاید دلخواه را به انتهای مجموعه اسلایدهای همان ارائه کلون کنید
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // ارائه تغییر یافته را روی دیسک بنویسید
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون کردن یک اسلاید در موقعیت دیگر داخل یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه اما در موقعیت متفاوتی استفاده کنید، از متد [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ارائه می‌شود، کلاس را نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) در دسترس است، فراخوانی کنید و اسلایدی که باید کلون شود را همراه با شاخص موقعیت جدید به عنوان پارامتر به این متد پاس دهید.
1. ارائه تغییر یافته را به صورت فایل PPTX بنویسید.

در مثال زیر، اسلایدی که در شاخص صفر (موقعیت 1) ارائه قرار داشت را به شاخص 1 (موقعیت 2) ارائه کلون کردیم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // اسلاید دلخواه را به انتهای مجموعه اسلایدهای همان ارائه کلون کنید
    ISlideCollection slds = pres.getSlides();

    // اسلاید دلخواه را به اندیس مشخص شده در همان ارائه کلون کنید
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // ارائه تغییر یافته را روی دیسک بنویسید
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون کردن یک اسلاید در انتهای یک ارائه دیگر**
اگر نیاز دارید اسلایدی را از یک ارائه بردارید و در فایل ارائه دیگری، در انتهای اسلایدهای موجود، استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه‌ای است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه مقصد است که اسلاید به آن اضافه می‌شود.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection) را با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) که توسط شیء Presentation ارائه مقصد در دسترس است، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) را که توسط شیء [ISSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) در دسترس است، فراخوانی کنید و اسلایدی را که از ارائه منبع می‌آید به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائه مقصد تغییر یافته را بنویسید.

در مثال زیر، اسلایدی که از شاخص اول ارائه منبع بود را به انتهای ارائه مقصد کلون کردیم.

```java
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید باید کلون شود)
    Presentation destPres = new Presentation();
    try {
        // اسلاید دلخواه را از ارائه منبع به انتهای مجموعه اسلایدهای ارائه مقصد کلون کنید
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // ارائه مقصد را روی دیسک بنویسید
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون کردن یک اسلاید در موقعیت دیگر در یک ارائه دیگر**
اگر نیاز دارید اسلایدی را از یک ارائه بردارید و در موقعیت خاصی از یک ارائه دیگر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه منبع است.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه‌ای است که اسلاید به آن اضافه می‌شود.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء Presentation ارائه مقصد در دسترس است، نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) در دسترس است، فراخوانی کنید و اسلایدی که از ارائه منبع می‌آید را همراه با موقعیت مورد نظر به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائه مقصد تغییر یافته را بنویسید.

در مثال زیر، اسلایدی که از شاخص صفر ارائه منبع بود را به شاخص 1 (موقعیت 2) ارائه مقصد کلون کردیم.

```java
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید باید کلون شود)
    Presentation destPres = new Presentation();
    try {
        // اسلاید دلخواه را از ارائه منبع به انتهای مجموعه اسلایدهای ارائه مقصد کلون کنید
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // ارائه مقصد را روی دیسک بنویسید
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون کردن یک اسلاید در موقعیت مشخص در یک ارائه دیگر**
اگر نیاز دارید اسلایدی همراه با اسلاید مستر را از یک ارائه بردارید و در ارائه دیگری استفاده کنید، ابتدا باید اسلاید مستر دلخواه را از ارائه منبع به ارائه مقصد کلون کنید. سپس باید از آن اسلاید مستر برای کلون کردن اسلاید با مستر استفاده کنید. متد [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) انتظار دارد که اسلاید مستر از ارائه مقصد باشد نه از منبع. برای کلون کردن اسلاید با مستر، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه منبع است.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه مقصد است.
1. به اسلایدی که باید کلون شود به همراه اسلاید مستر دسترسی پیدا کنید.
1. کلاس [IMasterSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMasterSlideCollection) را با ارجاع به مجموعه Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ارائه مقصد در دسترس است، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را که توسط شیء [IMasterSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMasterSlideCollection) در دسترس است، فراخوانی کنید و مستر مورد نظر از PPTX منبع را به عنوان پارامتر به این متد پاس دهید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) را با تنظیم ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ارائه مقصد در دسترس است، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) در دسترس است، فراخوانی کنید و اسلایدی که از ارائه منبع می‌آید به همراه اسلاید مستر را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائه مقصد تغییر یافته را بنویسید.

در مثال زیر، اسلایدی همراه با مستر (که در شاخص صفر ارائه منبع قرار داشت) را با استفاده از مستری که از اسلاید منبع دریافت شد، به انتهای ارائه مقصد کلون کردیم.

```java
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    Presentation destPres = new Presentation();
    try {
        // نمونه‌سازی ISlide از مجموعه اسلایدهای ارائه منبع همراه با
        // اسلاید مستر
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // کلون اسلاید مستر دلخواه از ارائه منبع به مجموعه مسترها در
        // ارائه مقصد
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // کلون اسلاید مستر دلخواه از ارائه منبع به مجموعه مسترها در
        // ارائه مقصد
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // کلون اسلاید دلخواه را از ارائه منبع با مستر دلخواه به انتهای
        // مجموعه اسلایدهای ارائه مقصد
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // ذخیره ارائه مقصد روی دیسک
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون کردن یک اسلاید در انتهای بخش مشخصی**
اگر می‌خواهید اسلایدی را کلون کنید و سپس در همان فایل ارائه اما در بخش متفاوتی استفاده کنید، از متد [**addClone**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) که توسط رابط [**ISlideCollection**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection) ارائه می‌شود، استفاده کنید. Aspose.Slides برای Android از طریق Java امکان کلون یک اسلاید از بخش اول و سپس درج آن اسلاید کلون‌شده در بخش دوم همان ارائه را فراهم می‌کند.

قطعه کد زیر نشان می‌دهد که چگونه یک اسلاید را کلون کنید و اسلاید کلون‌شده را در یک بخش مشخص وارد کنید.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// ذخیره ارائه مقصد روی دیسک
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **سوالات متداول**

**آیا یادداشت‌های سخنران و نظرات مرورگر نیز کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها را داشته باشید، پس از درج [حذف کنید](/slides/fa/androidjava/presentation-notes/).

**چگونه چارچوب‌ها و منابع داده آنها مدیریت می‌شوند؟**

شیء چارچوب، قالب‌بندی و داده‌های داخلی آن کپی می‌شود. اگر چارچوب به منبع خارجی (مثلاً یک کتاب‌کار OLE داخلی) مرتبط باشد، این ارتباط به عنوان یک [شیء OLE](/slides/fa/androidjava/manage-ole/) حفظ می‌شود. پس از جابه‌جایی بین فایل‌ها، در دسترس بودن داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در شاخص اسلاید خاصی درج کنید و آن را به یک [بخش](/slides/fa/androidjava/slide-section/) انتخابی منتقل کنید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل نمایید.