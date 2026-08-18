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
description: "اسلایدهای PowerPoint را با Aspose.Slides برای اندروید تکثیر کنید. مثال‌های واضح کد Java ما را دنبال کنید تا ایجاد PPT را در ثانیه‌ها خودکار کنید و کار دستی را حذف نمایید."
---
## **معرفی**

کلونینگ فرایند ساخت یک نسخه دقیق یا تکثیر چیزی است. Aspose.Slides for Android via Java همچنین امکان ساخت یک کپی یا کلون از هر اسلاید را فراهم می‌کند و سپس آن اسلاید کلون‌شده را به ارائه فعلی یا هر ارائه دیگری که باز است، وارد می‌نماید. فرآیند کلون‌کردن اسلاید یک اسلاید جدید ایجاد می‌کند که می‌تواند توسط توسعه‌دهندگان بدون تغییر اسلاید اصلی اصلاح شود. چندین روش برای کلون کردن اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگری درون ارائه.
- کلون در انتها در ارائه دیگری.
- کلون در موقعیت دیگری در ارائه دیگری.
- کلون در موقعیت مشخصی در ارائه دیگری.

در Aspose.Slides for Android via Java، (مجموعه‌ای از اشیاء [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlide) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) نمایان می‌شود) متدهای [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) را برای انجام انواع کلون‌کردن اسلاید ذکر شده فراهم می‌کند.

## **کلون یک اسلاید در انتهای یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کرده و سپس آن را در همان فایل ارائه در انتهای اسلایدهای موجود استفاده کنید، از متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) بر اساس مراحل زیر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) نمایان می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) نمایان شده است فراخوانی کنید و اسلایدی که باید کلون شود را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) پاس بدهید.
1. فایل ارائه اصلاح‌شده را بنویسید.

در مثال زیر، ما اسلایدی (که در موقعیت اول – شاخص صفر – ارائه قرار داشته) را به انتهای ارائه کلون کرده‌ایم.

```java
import com.aspose.slides.*;

// ایجاد نمونه‌ای از کلاس Presentation که نشانگر یک فایل ارائه است
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // کلون اسلاید موردنظر را به انتهای مجموعه اسلایدها در همان ارائه اضافه کنید
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // ارائه اصلاح‌شده را روی دیسک ذخیره کنید
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون یک اسلاید به موقعیت دیگری درون یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کرده و سپس آن را در همان فایل ارائه اما در موقعیتی متفاوت استفاده کنید، از متد [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. کلاس را با ارجاع به مجموعه **Slides** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) نمایان می‌شود، نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) نمایان شده است فراخوانی کنید و اسلایدی که باید کلون شود را به همراه شاخص موقعیت جدید به عنوان پارامتر به متد [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) پاس بدهید.
1. فایل ارائه اصلاح‌شده را به صورت PPTX بنویسید.

در مثال زیر، ما اسلایدی (که در شاخص 1 – موقعیت 2 – ارائه قرار داشته) را به شاخص 2 – موقعیت 3 – ارائه کلون کرده‌ایم.

```java
import com.aspose.slides.*;

// ایجاد نمونه‌ای از کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // دریافت مجموعه اسلایدها در همان ارائه
    ISlideCollection slds = pres.getSlides();

    // کلون اسلاید موردنظر را به شاخص مشخص در همان ارائه اضافه کنید
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // ارائه اصلاح‌شده را روی دیسک ذخیره کنید
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون یک اسلاید در انتهای ارائه دیگری**
اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در ارائه دیگری، در انتهای اسلایدهای موجود استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که شامل ارائه‌ای است که اسلاید از آن کلون خواهد شد، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که شامل ارائه مقصدی است که اسلاید به آن اضافه خواهد شد، ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection) را با ارجاع به مجموعه **Slides** که توسط شیء Presentation ارائه مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را فراخوانی کنید و اسلاید از ارائه منبع را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) پاس بدهید.
1. فایل ارائه مقصد اصلاح‌شده را بنویسید.

در مثال زیر، ما اسلایدی (از شاخص اول ارائه منبع) را به انتهای ارائه مقصد کلون کرده‌ایم.

```java
import com.aspose.slides.*;

// ایجاد نمونه‌ای از کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // ایجاد نمونه‌ای از کلاس Presentation برای PPTX مقصد (جایی که اسلاید کلون می‌شود)
    Presentation destPres = new Presentation();
    try {
        // کلون اسلاید موردنظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // ذخیره ارائه مقصد روی دیسک
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون یک اسلاید به موقعیت دیگری در ارائه دیگری**
اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در ارائه دیگری، در موقعیت خاصی استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که شامل ارائه منبعی است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که شامل ارائه‌ای است که اسلاید به آن اضافه می‌شود، ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء Presentation ارائه مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) نمایان شده است فراخوانی کنید و اسلاید از ارائه منبع را به همراه موقعیت دلخواه به عنوان پارامتر به متد [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) پاس بدهید.
1. فایل ارائه مقصد اصلاح‌شده را بنویسید.

در مثال زیر، ما اسلایدی (از شاخص صفر ارائه منبع) را به شاخص 1 (موقعیت 2) ارائه مقصد کلون کرده‌ایم.

```java
import com.aspose.slides.*;

// ایجاد نمونه‌ای از کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // ایجاد نمونه‌ای از کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود)
    Presentation destPres = new Presentation();
    try {
        // کلون اسلاید موردنظر از ارائه منبع به شاخص مشخص در ارائه مقصد
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // ذخیره ارائه مقصد روی دیسک
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون یک اسلاید در موقعیت مشخصی در ارائه دیگری**
اگر نیاز دارید یک اسلاید با اسلاید اصلی را از یک ارائه کلون کنید و در ارائه دیگری استفاده کنید، ابتدا باید اسلاید اصلی موردنظر را از ارائه منبع به ارائه مقصد کلون کنید. سپس برای کلون اسلاید با اسلاید اصلی، باید از آن اسلاید اصلی استفاده کنید. متد [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) یک اسلاید اصلی از ارائه مقصد را انتظار دارد نه از ارائه منبع. برای کلون اسلاید با اسلاید اصلی، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که شامل ارائه منبعی است که اسلاید از آن کلون می‌شود، ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که شامل ارائه مقصدی است که اسلاید به آن کلون می‌شود، ایجاد کنید.
1. به اسلایدی که باید کلون شود همراه با اسلاید اصلی دسترسی پیدا کنید.
1. کلاس [IMasterSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMasterSlideCollection) را با ارجاع به مجموعه Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ارائه مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را که توسط شیء [IMasterSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMasterSlideCollection) نمایان شده است فراخوانی کنید و اسلاید اصلی از PPTX منبع را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) پاس بدهید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) را با تنظیم مرجع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ارائه مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getSlides--) نمایان شده است فراخوانی کنید و اسلاید از ارائه منبع به همراه اسلاید اصلی را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) پاس بدهید.
1. فایل ارائه مقصد اصلاح‌شده را بنویسید.

در مثال زیر، ما اسلایدی با اسلاید اصلی (در شاخص صفر ارائه منبع) را به انتهای ارائه مقصد با استفاده از اسلاید اصلی از اسلاید منبع کلون کرده‌ایم.

```java
import com.aspose.slides.*;

// ایجاد نمونه‌ای از کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // ایجاد نمونه‌ای از کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    Presentation destPres = new Presentation();
    try {
        // ایجاد ISlide از مجموعه اسلایدها در ارائه منبع همراه با
        // اسلاید اصلی
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // کلون اسلاید اصلی موردنظر از ارائه منبع به مجموعهٔ اسلایدهای اصلی در
        // ارائه مقصد
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // کلون اسلاید موردنظر از ارائه منبع با اسلاید اصلی موردنظر به انتهای
        // مجموعهٔ اسلایدها در ارائه مقصد
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // ذخیرهٔ ارائه مقصد روی دیسک
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون یک اسلاید در انتهای یک بخش مشخص**
اگر می‌خواهید یک اسلاید را کلون کرده و سپس آن را در همان فایل ارائه اما در بخش دیگری استفاده کنید، از متد [**addClone**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) که توسط رابط [**ISlideCollection**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlideCollection) ارائه می‌شود، استفاده کنید. Aspose.Slides for Android via Java امکان کلون یک اسلاید از بخش اول و سپس وارد کردن آن اسلاید کلون‌شده به بخش دوم همان ارائه را فراهم می‌کند.

قطعه کد زیر نشان می‌دهد چگونه یک اسلاید را کلون کرده و اسلاید کلون‌شده را به یک بخش مشخص وارد کنید.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// ذخیرهٔ ارائه مقصد روی دیسک
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **اطمینان از هم‌خوانی اندازه اسلاید**

هنگام کلون اسلایدها به ارائه دیگری، مطمئن شوید اندازه اسلاید ارائه مقصد با منبع یکسان باشد. اگر اندازه‌های اسلاید متفاوت باشد، Aspose.Slides به‌ طور خودکار شکل‌های کلون‌شده را مقیاس‌بندی نمی‌کند—مختصات و ابعاد اصلی آنها حفظ می‌شود که ممکن است محتوا به‌ صورت نامنظم ظاهر شود یا از مرزهای اسلاید خارج شود.

قبل از کلون کردن اسلاید اصلی و اسلاید می‌توانید اندازه اسلاید ارائه مقصد را برای تطبیق با منبع تنظیم کنید:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

این کار را قبل از کلون کردن اسلاید اصلی و اسلاید انجام دهید.

## **سوالات متداول**

**آیا یادداشت‌های گوینده و نظرات بازبین کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات بازبینی در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها را داشته باشید، پس از درج [آنها را حذف کنید](/slides/fa/androidjava/presentation-notes/).

**چگونه نمودارها و منابع داده‌ای آنها مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های توکار کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار توکار OLE) لینک داشته باشد، آن لینک به عنوان یک [شیء OLE](/slides/fa/androidjava/manage-ole/) حفظ می‌شود. پس از انتقال بین فایل‌ها، امکان دسترسی به داده‌ها و رفتار به‌روزرسانی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در شاخص اسلاید خاصی درج کنید و آن را در یک [بخش](/slides/fa/androidjava/slide-section/) انتخاب شده قرار دهید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل کنید.