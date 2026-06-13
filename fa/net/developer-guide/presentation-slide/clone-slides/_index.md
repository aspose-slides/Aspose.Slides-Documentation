---
title: کلون اسلایدهای ارائه در .NET
linktitle: کلون اسلایدها
type: docs
weight: 40
url: /fa/net/clone-slides/
keywords:
- کلون اسلاید
- کپی اسلاید
- ذخیره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به سرعت اسلایدهای PowerPoint را با Aspose.Slides برای .NET تکرار کنید. مثال‌های کد واضح ما را دنبال کنید تا ایجاد فایل PPT را در ثانیه‌ها خودکار کنید و کارهای دستی را حذف کنید."
---
## **معرفی**

کلونینگ (تکثیر) فرآیند ساخت یک نسخهٔ دقیق یا کپی از یک شیء است. Aspose.Slides همچنین به شما اجازه می‌دهد هر اسلایدی را کپی (کلون) کنید و سپس اسلاید کلون‌شده را در ارائهٔ جاری یا هر ارائهٔ دیگری که باز است، وارد کنید. کلونینگ اسلاید یک اسلاید جدید ایجاد می‌کند که توسعه‌دهندگان می‌توانند بدون تأثیر بر اسلاید اصلی، آن را اصلاح کنند. چندین روش برای کلون کردن یک اسلاید وجود دارد:

- کلون کردن در انتهای یک ارائه.
- کلون کردن در موقعیت دیگری درون یک ارائه.
- کلون کردن در انتهای ارائه‌ای دیگر.
- کلون کردن در موقعیت دیگری در ارائه‌ای دیگر.
- کلون کردن در موقعیت خاصی در ارائه‌ای دیگر.

در Aspose.Slides برای .NET، مجموعهٔ اسلایدها (یک مجموعه شامل اشیاء [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/) ) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) در دسترس است، متدهای [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) و [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/insertclone/) را برای انجام عملیات کلون‌سازی اسلاید که در بالا توصیف شد، فراهم می‌کند.

## **کلون کردن یک اسلاید در انتهای یک ارائه**

اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه، در انتهای اسلایدهای موجود استفاده کنید، مطابق مراحل زیر از متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) را با ارجاع به مجموعهٔ Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) در دسترس است، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) در دسترس است، فراخوانی کنید و اسلایدی که باید کلون شود را به‌عنوان پارامتر به متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) پاس دهید.
1. فایل ارائهٔ اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید (قرار گرفته در موقعیت اول – ایندکس صفر – ارائه) را به انتهای ارائه کلون کردیم.

```c#
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // کلون اسلاید مورد نظر به انتهای مجموعه اسلایدها در همان ارائه
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // نوشتن ارائه اصلاح‌شده به دیسک
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **کلون کردن یک اسلاید به موقعیت دیگری درون یک ارائه**

اگر می‌خواهید یک اسلاید را کلون کنید و سپس در همان فایل ارائه، اما در موقعیت متفاوتی استفاده کنید، از متد [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/insertclone/methods/1) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. کلاس را با ارجاع به مجموعهٔ **Slides** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) در دسترس است، نمونه‌سازی کنید.
1. متد [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/insertclone/methods/1) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) در دسترس است، فراخوانی کنید و اسلایدی که باید کلون شود را همراه با ایندکس موقعیت جدید به‌عنوان پارامتر به متد [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/insertclone/methods/1) پاس دهید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

در مثال زیر، یک اسلاید (قرار گرفته در ایندکس صفر – موقعیت 1 – ارائه) را به ایندکس 1 – موقعیت 2 – ارائه کلون کردیم.

```c#
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // کلون اسلاید مورد نظر به انتهای مجموعه اسلایدها در همان ارائه
    ISlideCollection slds = pres.Slides;

    // کلون اسلاید مورد نظر به ایندکس مشخص شده در همان ارائه
    slds.InsertClone(2, pres.Slides[1]);

    // نوشتن ارائه اصلاح‌شده به دیسک
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **کلون کردن یک اسلاید در انتهای ارائه‌ای دیگر**

اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در انتهای اسلایدهای موجود یک ارائهٔ دیگر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائه‌ای است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائهٔ مقصد است که اسلاید به آن اضافه می‌شود.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) را با ارجاع به مجموعهٔ **Slides** که توسط شیء Presentation ارائهٔ مقصد در دسترس است، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) در دسترس است، فراخوانی کنید و اسلاید از ارائه منبع را به‌عنوان پارامتر به متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید (از ایندکس اول ارائه منبع) را به انتهای ارائهٔ مقصد کلون کردیم.

```c#
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید کلون می‌شود)
    using (Presentation destPres = new Presentation())
    {
        // کلون اسلاید مورد نظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // نوشتن ارائه مقصد به دیسک
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **کلون کردن یک اسلاید به موقعیت دیگری در ارائه‌ای دیگر**

اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و در موقعیت خاصی از ارائهٔ دیگری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائهٔ منبع است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائه‌ای است که اسلاید به آن اضافه می‌شود.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) را با ارجاع به مجموعهٔ Slides که توسط شیء Presentation ارائهٔ مقصد در دسترس است، نمونه‌سازی کنید.
1. متد [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/insertclone/methods/1) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) در دسترس است، فراخوانی کنید و اسلاید از ارائه منبع را همراه با موقعیت موردنظر به‌عنوان پارامتر به متد [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/insertclone/methods/1) پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید (از ایندکس صفر ارائه منبع) را به ایندکس 1 (موقعیت 2) ارائهٔ مقصد کلون کردیم.

```c#
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید کلون می‌شود)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // نوشتن ارائه مقصد به دیسک
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **کلون کردن یک اسلاید در موقعیت خاصی در ارائه‌ای دیگر**

اگر نیاز دارید اسلایدی را همراه با اسلاید اصلی (master slide) از یک ارائه کلون کنید و در ارائهٔ دیگری استفاده کنید، ابتدا باید اسلاید اصلی موردنظر را از ارائه منبع به ارائه مقصد کلون کنید. سپس برای کلون کردن اسلاید با اسلاید اصلی، از متد **AddClone(ISlide, IMasterSlide)** استفاده می‌شود که یک اسلاید اصلی از ارائه مقصد می‌گیرد، نه از منبع. برای کلون کردن اسلاید با اسلاید اصلی، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائهٔ منبع است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائهٔ مقصد است که اسلاید به آن کلون می‌شود.
1. به اسلایدی که باید کلون شود همراه با اسلاید اصلی دسترسی پیدا کنید.
1. کلاس [IMasterSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection) را با ارجاع به مجموعهٔ Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ارائهٔ مقصد در دسترس است، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) را که توسط شیء [IMasterSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection) در دسترس است، فراخوانی کنید و اسلاید اصلی از فایل PPTX منبع را به‌عنوان پارامتر به متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) پاس دهید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) را با تنظیم ارجاع به مجموعهٔ Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ارائهٔ مقصد در دسترس است، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) را که توسط شیء [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) در دسترس است، فراخوانی کنید و اسلاید از ارائه منبع به همراه اسلاید اصلی را به‌عنوان پارامتر به متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید همراه با اسلاید اصلی (قرار گرفته در ایندکس صفر ارائه منبع) را با استفاده از اسلاید اصلی از اسلاید منبع به انتهای ارائهٔ مقصد کلون کردیم.

```c#
// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // نمونه‌سازی کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    using (Presentation destPres = new Presentation())
    {

        // نمونه‌سازی ISlide از مجموعه اسلایدهای ارائه منبع همراه با
        // اسلاید اصلی
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // کلون اسلاید اصلی موردنظر از ارائه منبع به مجموعهٔ اسلایدهای اصلی در
        // ارائه مقصد
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // کلون اسلاید اصلی موردنظر از ارائه منبع به مجموعهٔ اسلایدهای اصلی در
        // ارائه مقصد
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // کلون اسلاید موردنظر از ارائه منبع همراه با اسلاید اصلی موردنظر به انتهای
        // مجموعهٔ اسلایدها در ارائه مقصد
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // کلون اسلاید اصلی موردنظر از ارائه منبع به مجموعهٔ اسلایدهای اصلی در // Destination presentation
        // ذخیرهٔ ارائه مقصد به دیسک
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **کلون کردن یک اسلاید در انتهای یک بخش مشخص**

با Aspose.Slides برای .NET، می‌توانید یک اسلاید را از یک بخش از یک ارائه کلون کنید و آن اسلاید را در یک بخش دیگر از همان ارائه وارد نمایید. در این حالت باید از متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) از رابط [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) استفاده کنید.

این کد C# نشان می‌دهد چگونه یک اسلاید را کلون کنید و اسلاید کلون‌شده را در یک بخش مشخص وارد کنید:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // برای کلون
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا یادداشت‌های سخنران و نظرات مرورگر کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آن‌ها را داشته باشید، پس از درج [حذف آن‌ها](/slides/fa/net/presentation-notes/) کنید.

**نمودارها و منابع داده‌ای آن‌ها چگونه مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های توکار کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار OLE‑embedded) لینک داشته باشد، این لینک به عنوان یک [شیء OLE](/slides/fa/net/manage-ole/) حفظ می‌شود. پس از جابه‌جایی بین فایل‌ها، دسترسی داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در ایندکس اسلاید مشخصی درج کنید و آن را به یک [بخش](/slides/fa/net/slide-section/) دلخواه منتقل کنید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل کنید.