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
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به سرعت اسلایدهای PowerPoint را با Aspose.Slides برای جاوا تکرار کنید. مثال‌های کد واضح ما را برای خودکارسازی ایجاد فایل PPT در ثانیه‌ها دنبال کنید و کارهای دستی را حذف کنید."
---
## **مقدمه**

کلون کردن فرآیند ایجاد یک نسخه دقیق یا بازتولید از چیزی است. Aspose.Slides for Java همچنین امکان ایجاد یک کپی یا کلون از هر اسلاید و سپس وارد کردن آن اسلاید کلون شده به ارائه جاری یا هر ارائه دیگری که باز است را فراهم می‌کند. فرآیند کلون اسلاید یک اسلاید جدید ایجاد می‌کند که می‌تواند توسط توسعه‌دهندگان بدون تغییر اسلاید اصلی اصلاح شود. چندین روش مختلف برای کلون اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگری درون ارائه.
- کلون در انتهای ارائه دیگری.
- کلون در موقعیت دیگری در ارائه دیگری.
- کلون همراه با اسلاید اصلی آن به ارائه دیگری.

در Aspose.Slides for Java، (مجموعه‌ای از اشیای [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide)) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ارائه می‌شود، متدهای [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) را برای انجام انواع کلون اسلایدهای ذکر شده فراهم می‌کند.

## **کلون اسلاید در انتهای یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه در انتهای اسلایدهای موجود استفاده کنید، از متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) مطابق مراحل زیر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) در دسترس است، مثال‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) فراهم شده است را فراخوانی کنید و اسلایدی که باید کلون شود را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائه اصلاح شده را بنویسید.

در مثال زیر، یک اسلاید (در موقعیت اولین – ایندکس صفر – ارائه) را به انتهای ارائه کلون کردیم.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // کلون اسلاید مورد نظر به انتهای مجموعه اسلایدها در همان ارائه
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // نوشتن ارائه اصلاح‌شده به دیسک
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون اسلاید در موقعیت دیگری درون یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه اما در موقعیت متفاوتی استفاده کنید، از متد [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. کلاس را با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) در دسترس است، مثال‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) فراهم شده است را فراخوانی کنید و اسلایدی که باید کلون شود را به همراه ایندکس موقعیت جدید به عنوان پارامتر به این متد پاس دهید.
1. ارائه اصلاح شده را به عنوان یک فایل PPTX بنویسید.

در مثال زیر، یک اسلاید (در ایندکس 1 – موقعیت 2 – ارائه) را به ایندکس 2 – موقعیت 3 – ارائه کلون کردیم.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // دریافت مجموعه اسلایدها در ارائه
    ISlideCollection slds = pres.getSlides();

    // کلون اسلاید مورد نظر به ایندکس مشخص در همان ارائه
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // نوشتن ارائه اصلاح‌شده به دیسک
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **کلون اسلاید در انتهای یک ارائه دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در ارائه دیگری، در انتهای اسلایدهای موجود استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه‌ای است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه مقصد است که اسلاید به آن اضافه خواهد شد.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection) را با ارجاع به مجموعه [**Slides**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) که توسط شیء Presentation ارائه مقصد در دسترس است، مثال‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) فراهم شده است را فراخوانی کنید و اسلاید از ارائه مبدأ را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائه مقصد اصلاح شده را بنویسید.

در مثال زیر، یک اسلاید (از ایندکس اول ارائه مبدأ) را به انتهای ارائه مقصد کلون کردیم.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود)
    Presentation destPres = new Presentation();
    try {
        // کلون اسلاید مورد نظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // نوشتن ارائه مقصد به دیسک
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون اسلاید در موقعیت دیگری در ارائه‌ای دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در یک ارائه دیگر، در موقعیت خاصی استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه مبدأ است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه‌ای است که اسلاید به آن اضافه خواهد شد.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) را با ارجاع به مجموعه Slides که توسط شیء Presentation ارائه مقصد در دسترس است، مثال‌سازی کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) فراهم شده است را فراخوانی کنید و اسلاید از ارائه مبدأ را به همراه موقعیت مطلوب به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائه مقصد اصلاح شده را بنویسید.

در مثال زیر، یک اسلاید (از ایندکس صفر ارائه مبدأ) را به ایندکس 1 (موقعیت 2) ارائه مقصد کلون کردیم.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود)
    Presentation destPres = new Presentation();
    try {
        // کلون اسلاید مورد نظر از ارائه منبع به ایندکس مشخص در ارائه مقصد
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // نوشتن ارائه مقصد به دیسک
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون اسلاید همراه با اسلاید اصلی آن به ارائه‌ای دیگر**
اگر نیاز دارید یک اسلاید همراه با اسلاید اصلی آن را از یک ارائه کلون کنید و در ارائه دیگری استفاده کنید، ابتدا باید اسلاید اصلی مطلوب را از ارائه مبدأ به ارائه مقصد کلون کنید. سپس برای کلون اسلاید همراه با اسلاید اصلی، باید از آن اسلاید اصلی استفاده کنید. متد [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) انتظار دارد که اسلاید اصلی از ارائه مقصد باشد نه مبدأ. برای کلون اسلاید همراه با اسلاید اصلی، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه مبدأ است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید که شامل ارائه مقصد است که اسلاید به آن کلون می‌شود.
1. به اسلایدی که باید کلون شود همراه با اسلاید اصلی دسترسی پیدا کنید.
1. کلاس [IMasterSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMasterSlideCollection) را با ارجاع به مجموعه Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ارائه مقصد در دسترس است، مثال‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را که توسط شیء [IMasterSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IMasterSlideCollection) فراهم شده است فراخوانی کنید و اسلاید اصلی از PPTX مبدأ را به عنوان پارامتر به این متد پاس دهید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) را با تنظیم ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ارائه مقصد در دسترس است، مثال‌سازی کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) فراهم شده است فراخوانی کنید و اسلاید از ارائه مبدأ را به همراه اسلاید اصلی به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائه مقصد اصلاح شده را بنویسید.

در مثال زیر، یک اسلاید همراه با اسلاید اصلی (در ایندکس صفر ارائه مبدأ) را به انتهای ارائه مقصد با استفاده از اسلاید اصلی مبدأ کلون کردیم.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // نمونه‌سازی کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    Presentation destPres = new Presentation();
    try {
        // نمونه‌سازی ISlide از مجموعه اسلایدها در ارائه منبع به همراه
        // اسلاید اصلی
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // کلون اسلاید اصلی مورد نظر از ارائه منبع به مجموعه اسلایدهای اصلی در
        // ارائه مقصد
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // کلون اسلاید مورد نظر از ارائه منبع با اسلاید اصلی مورد نظر به انتهای
        // مجموعه اسلایدها در ارائه مقصد
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // ذخیره ارائه مقصد به دیسک
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **کلون اسلاید در انتهای یک بخش مشخص**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه اما در بخش متفاوتی استفاده کنید، متد [**addClone**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) که توسط رابط [**ISlideCollection**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlideCollection) ارائه می‌شود را استفاده کنید. Aspose.Slides for Java امکان کلون اسلایدی از بخش اول و سپس وارد کردن آن اسلاید کلون شده به بخش دوم همان ارائه را فراهم می‌کند.

کد زیر نشان می‌دهد که چگونه اسلایدی را کلون کنید و اسلاید کلون شده را به یک بخش مشخص وارد کنید.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // ذخیره ارائه مقصد به دیسک
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **اطمینان از تطابق اندازه اسلاید**

هنگام کلون اسلایدها به ارائه‌ای دیگر، مطمئن شوید که ارائه مقصد همان اندازه اسلاید را داشته باشد که در مبدأ داشته است. اگر اندازه اسلایدها متفاوت باشد، Aspose.Slides به‌طور خودکار مقیاس اشکال کلون شده را تغییر نمی‌دهد؛ مختصات و ابعاد اصلی آنها حفظ می‌شود که ممکن است محتوا به‌نظر نادرست یا خارج از مرزهای اسلاید بیاید.

می‌توانید قبل از کلون کردن اسلاید و اسلاید اصلی، اندازه اسلاید ارائه مقصد را برای مطابقت با مبدأ تنظیم کنید:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

این کار را قبل از کلون کردن اسلاید اصلی و اسلاید انجام دهید.

## **سوالات متداول**

**آیا یادداشت‌های گوینده و نظرات مرورگرها کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شود. اگر نمی‌خواهید آنها را نگه دارید، پس از وارد کردن، [آنها را حذف کنید](/slides/fa/java/presentation-notes/) .

**نمودارها و منابع داده آنها چگونه مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های جاسازی‌شده کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار OLE جاسازی‌شده) لینک شده باشد، این لینک به عنوان یک [شیء OLE](/slides/fa/java/manage-ole/) حفظ می‌شود. پس از جابه‌جایی بین فایل‌ها، در دسترس بودن داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در ایندکس اسلاید مشخصی وارد کنید و آن را به یک [بخش](/slides/fa/java/slide-section/) انتخابی منتقل کنید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن انتقال دهید.