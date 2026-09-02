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
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌سرعت اسلایدهای پاورپوینت را با Aspose.Slides برای .NET کپی کنید. با دنبال کردن مثال‌های کد واضح ما می‌توانید ایجاد فایل PPT را در ثانیه‌ها خودکار کنید و کارهای دستی را از بین ببرید."
---
## **مقدمه**

کلونینگ فرآیند ایجاد یک کپی دقیق یا نسخه‌ی مشابه از چیزی است. Aspose.Slides همچنین اجازه می‌دهد تا هر اسلایدی را کپی (کلون) کنید و سپس اسلاید کلون شده را در ارائهٔ فعلی یا هر ارائهٔ باز دیگری وارد کنید. کلونینگ اسلاید یک اسلاید جدید ایجاد می‌کند که توسعه‌دهندگان می‌توانند بدون تأثیر بر اسلاید اصلی، آن را اصلاح کنند. چند روش برای کلون کردن یک اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگری درون یک ارائه.
- کلون در انتهای ارائهٔ دیگر.
- کلون در موقعیت دیگری در ارائهٔ دیگر.
- کلون همراه با اسلاید اصلی آن به ارائهٔ دیگر.

در Aspose.Slides for .NET، مجموعه اسلایدها (یک مجموعه از اشیاء [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/) ) که توسط شی [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ارائه می‌شود، متدهای [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) و [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/insertclone/) را برای انجام عملیات کلونینگ اسلاید که در بالا توصیف شده‌اند، فراهم می‌کند.

## **کلون یک اسلاید در انتهای ارائه**

اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه در انتهای اسلایدهای موجود استفاده کنید، از متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) طبق مراحل زیر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) را با ارجاع به مجموعه Slides که توسط شی [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) نمایان می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) که توسط شی [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) ارائه شده است، فراخوانی کنید و اسلایدی که باید کلون شود را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائهٔ اصلاح‌شده را بنویسید.

در مثال زیر، ما یک اسلاید (در موقعیت اول – ایندکس صفر – ارائه) را به انتهای ارائه کلون کرده‌ایم.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // کلون اسلاید موردنظر به انتهای مجموعه اسلایدها در همان ارائه
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // نوشتن ارائهٔ اصلاح‌شده به دیسک
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **کلون یک اسلاید به موقعیت دیگری درون یک ارائه**
اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه اما در موقعیت متفاوتی استفاده کنید، از متد [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/insertclone/methods/1) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با ارجاع به مجموعه **Slides** که توسط شی [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) نمایان می‌شود، کلاس را نمونه‌سازی کنید.
1. متد [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/insertclone/methods/1) که توسط شی [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) ارائه شده است، فراخوانی کنید و اسلایدی که باید کلون شود را به همراه ایندکس موقعیت جدید به عنوان پارامتر به این متد پاس دهید.
1. ارائهٔ اصلاح‌شده را به شکل فایل PPTX بنویسید.

در مثال زیر، ما یک اسلاید (در ایندکس 1 – موقعیت 2 – ارائه) را به ایندکس 2 – موقعیت 3 – ارائه کلون کرده‌ایم.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // کلون اسلاید موردنظر به انتهای مجموعه اسلایدها در همان ارائه
    ISlideCollection slds = pres.Slides;

    // کلون اسلاید موردنظر به ایندکس مشخص‌شده در همان ارائه
    slds.InsertClone(2, pres.Slides[1]);

    // نوشتن ارائهٔ اصلاح‌شده به دیسک
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **کلون یک اسلاید در انتهای ارائهٔ دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه گرفته و در انتهای اسلایدهای موجود یک ارائهٔ دیگر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائه‌ای است که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائهٔ مقصد است که اسلاید به آن اضافه می‌شود.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) را با ارجاع به مجموعه **Slides** که توسط شی Presentation ارائهٔ مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) را که توسط شی [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) ارائه شده است، فراخوانی کنید و اسلایدی که از ارائهٔ منبع آمده است را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، ما یک اسلاید (از ایندکس اول ارائهٔ منبع) را به انتهای ارائهٔ مقصد کلون کرده‌ایم.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود)
    using (Presentation destPres = new Presentation())
    {
        // کلون اسلاید موردنظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // نوشتن ارائه مقصد به دیسک
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **کلون یک اسلاید به موقعیت دیگری در ارائهٔ دیگر**
اگر نیاز دارید یک اسلاید را از یک ارائه گرفته و در موقعیت خاصی از ارائهٔ دیگر استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائهٔ منبع است.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائهٔ مقصد است.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) را با ارجاع به مجموعه Slides که توسط شی Presentation ارائهٔ مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/insertclone/methods/1) را که توسط شی [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) ارائه شده است، فراخوانی کنید و اسلایدی که از ارائهٔ منبع می‌آید را به همراه موقعیت موردنظر به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، ما یک اسلاید (از ایندکس صفر ارائهٔ منبع) را به ایندکس 1 (موقعیت 2) ارائهٔ مقصد کلون کرده‌ایم.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // نوشتن ارائه مقصد به دیسک
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **کلون یک اسلاید همراه با اسلاید اصلی آن به ارائهٔ دیگر**
اگر نیاز دارید یک اسلاید به همراه اسلاید اصلی آن را از یک ارائه گرفته و در ارائهٔ دیگری استفاده کنید، ابتدا باید اسلاید اصلی موردنظر را از ارائهٔ منبع به ارائهٔ مقصد کلون کنید. سپس برای کلون کردن اسلاید با اسلاید اصلی، باید از همان اسلاید اصلی در مقصد استفاده کنید. متد **AddClone(ISlide, IMasterSlide)** انتظار دارد اسلاید اصلی از ارائهٔ مقصد باشد، نه از منبع. برای کلونینگ اسلاید با اسلاید اصلی، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائهٔ منبع است.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل ارائهٔ مقصد است.
1. به اسلایدی که باید کلون شود همراه با اسلاید اصلی آن دسترسی پیدا کنید.
1. کلاس [IMasterSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection) را با ارجاع به مجموعه Masters که توسط شی [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ارائهٔ مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) را که توسط شی [IMasterSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection) ارائه شده است، فراخوانی کنید و اسلاید اصلی از PPTX منبع را به عنوان پارامتر به این متد پاس دهید.
1. کلاس [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) را با تنظیم ارجاع به مجموعه Slides که توسط شی [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ارائهٔ مقصد نمایان می‌شود، نمونه‌سازی کنید.
1. متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) را که توسط شی [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) ارائه شده است، فراخوانی کنید و اسلاید از ارائهٔ منبع به همراه اسلاید اصلی را به عنوان پارامتر به این متد پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، ما یک اسلاید با اسلاید اصلی (در ایندکس صفر ارائهٔ منبع) را به انتهای ارائهٔ مقصد با استفاده از اسلاید اصلی منبع کلون کرده‌ایم.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // نمونه‌سازی کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    using (Presentation destPres = new Presentation())
    {

        // نمونه‌سازی ISlide از مجموعه اسلایدها در ارائه منبع همراه با
        // اسلاید اصلی
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // کلون اسلاید اصلی موردنظر از ارائه منبع به مجموعه اسلایدهای اصلی در
        // ارائه مقصد
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // کلون اسلاید اصلی موردنظر از ارائه منبع به مجموعه اسلایدهای اصلی در
        // ارائه مقصد
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // کلون اسلاید موردنظر از ارائه منبع با اسلاید اصلی موردنظر به انتهای
        // مجموعه اسلایدها در ارائه مقصد
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // کلون اسلاید اصلی موردنظر از ارائه منبع به مجموعه اسلایدهای اصلی در // ارائه مقصد
        // ذخیرهٔ ارائه مقصد به دیسک
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **کلون یک اسلاید در انتهای بخش مشخصی**

با Aspose.Slides for .NET می‌توانید یک اسلاید را از یک بخش از ارائه کلون کنید و آن اسلاید را در بخش دیگری از همان ارائه وارد کنید. در این حالت باید از متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/methods/addclone/index) از اینترفیس [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) استفاده کنید.

این کد C# نشان می‌دهد چگونه یک اسلاید را کلون کنید و اسلاید کلون‌شده را در بخش مشخصی وارد کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **اطمینان از تطابق اندازه اسلاید**

هنگام کلون کردن اسلایدها به ارائهٔ دیگر، اطمینان حاصل کنید اندازهٔ اسلاید ارائهٔ مقصد با منبع یکسان باشد. اگر اندازه‌ها متفاوت باشند، Aspose.Slides به‌طور خودکار مقیاس اشکال کلون‌شده را تغییر نمی‌دهد؛ مختصات و ابعاد اولیه حفظ می‌شوند که ممکن است محتوا به‌نظر ناهماهنگ برسد یا از محدودهٔ اسلاید فراتر رود.

قبل از کلون کردن اسلایدها و اسلاید اصلی می‌توانید اندازهٔ اسلاید ارائهٔ مقصد را همانند منبع تنظیم کنید:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

این کار را پیش از کلون کردن اسلاید اصلی و اسلاید انجام دهید.

## **پرسش‌های متداول**

**آیا یادداشت‌های سخنران و نظرات مرورگر کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آن‌ها را داشته باشید، پس از درج [آن‌ها را حذف کنید](/slides/fa/net/presentation-notes/).

**چگونه نمودارها و منابع داده آن‌ها مدیریت می‌شوند؟**

شیء نمودار، فرمت‌بندی و داده‌های جاسازی شده کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کاربرگ OLE) لینک شده باشد، این لینک به‌عنوان یک [شیء OLE](/slides/fa/net/manage-ole/) حفظ می‌شود. پس از جابجایی بین فایل‌ها، در دسترس بودن داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌ها را برای کلون کنترل کنم؟**

بله. می‌توانید کلون را در ایندکس اسلاید خاصی درج کنید و آن را در یک [بخش](/slides/fa/net/slide-section/) انتخابی قرار دهید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل کنید.