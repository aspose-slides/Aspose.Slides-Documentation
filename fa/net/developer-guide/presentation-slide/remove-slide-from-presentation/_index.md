---
title: حذف اسلایدها از ارائه‌ها در .NET
linktitle: حذف اسلاید
type: docs
weight: 30
url: /fa/net/remove-slide-from-presentation/
keywords:
- حذف اسلاید
- حذف اسلاید
- حذف اسلاید استفاده‌نشده
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به راحتی اسلایدها را از ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET حذف کنید. نمونه‌های واضح کد C# دریافت کنید و گردش کار خود را ارتقا دهید."
---
## **معرفی**

اگر یک اسلاید (یا محتوای آن) زائد شود، می‌توانید آن را حذف کنید. Aspose.Slides کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را فراهم می‌کند که [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) را در بر می‌گیرد؛ این یک مخزن برای تمامی اسلایدهای یک ارائه است. با استفاده از اشاره‌گرها (مرجع یا اندیس) برای یک شیء [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/) شناخته شده، می‌توانید اسلایدی که می‌خواهید حذف کنید را مشخص کنید.

## **حذف اسلاید بر اساس مرجع**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. مرجع اسلایدی که می‌خواهید حذف کنید را از طریق شناسه یا اندیس آن دریافت کنید.
1. اسلاید مرجع را از ارائه حذف کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

```c#
 // یک شیء Presentation را ایجاد می‌کند که نمایندهٔ یک فایل ارائه است
 using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
 {
 
     // یک اسلاید را از طریق ایندکس آن در مجموعه اسلایدها دسترسی می‌یابد
     ISlide slide = pres.Slides[0];
 
     // یک اسلاید را از طریق مرجع آن حذف می‌کند
     pres.Slides.Remove(slide);
 
     // ارائهٔ اصلاح‌شده را ذخیره می‌کند
     pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **حذف اسلاید بر اساس اندیس**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. اسلاید را از ارائه با استفاده از موقعیت اندیس آن حذف کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

```c#
 // یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
 using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
 {
 
     // یک اسلاید را از طریق ایندکس آن حذف می‌کند
     pres.Slides.RemoveAt(0);
 
     // ارائهٔ اصلاح‌شده را ذخیره می‌کند
     pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **حذف اسلایدهای طرح‌بندی استفاده‌نشده**

Aspose.Slides متد [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (از کلاس [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/)) را فراهم می‌کند تا به شما امکان حذف اسلایدهای طرح‌بندی ناخواسته و استفاده‌نشده را بدهد. این کد C# نشان می‌دهد چگونه یک اسلاید طرح‌بندی را از یک ارائه PowerPoint حذف کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **حذف اسلایدهای اصلی استفاده‌نشده**

Aspose.Slides متد [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (از کلاس [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/)) را فراهم می‌کند تا به شما امکان حذف اسلایدهای اصلی ناخواسته و استفاده‌نشده را بدهد. این کد C# نشان می‌دهد چگونه یک اسلاید اصلی را از یک ارائه PowerPoint حذف کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**بعد از حذف یک اسلاید، ایندکس‌های اسلایدها چه می‌شوند؟**

پس از حذف، [مجموعه](https://reference.aspose.com/slides/fa/net/aspose.slides/slidecollection/) دوباره ایندکس می‌شود: هر اسلاید بعدی یک موقعیت به سمت چپ جابه‌جا می‌شود، بنابراین شماره‌های ایندکس قبلی منسوخ می‌شوند. اگر به یک مرجع ثابت نیاز دارید، به جای ایندکس، شناسه دائم هر اسلاید را استفاده کنید.

**آیا شناسهٔ اسلاید متفاوت از ایندکس آن است و آیا هنگام حذف اسلایدهای همسایه تغییر می‌کند؟**

بله. ایندکس موقعیت اسلاید است و زمانی که اسلایدها اضافه یا حذف شوند تغییر می‌کند. شناسهٔ اسلاید یک شناسهٔ پایدار است و هنگام حذف سایر اسلایدها تغییر نمی‌کند.

**حذف یک اسلاید بر بخش‌های اسلایدها چه تأثیری دارد؟**

اگر اسلاید متعلق به یک بخش باشد، آن بخش به سادگی یک اسلاید کمتر خواهد داشت. ساختار بخش همچنان باقی می‌ماند؛ اگر بخشی خالی شد، می‌توانید [بخش‌ها را حذف یا بازنگری کنید](/slides/fa/net/slide-section/) همان‌طور که نیاز است.

**هنگامی که یک اسلاید حذف می‌شود، یادداشت‌ها و نظرات ضمیمهٔ آن چه می‌شود؟**

[یادداشت‌ها](/slides/fa/net/presentation-notes/) و [نظرات](/slides/fa/net/presentation-comments/) به آن اسلاید خاص وابسته هستند و همراه با آن حذف می‌شوند. محتوای اسلایدهای دیگر تحت تأثیر قرار نمی‌گیرد.

**حذف اسلایدها چگونه با پاک‌سازی طرح‌ها/استادهای استفاده‌نشده متفاوت است؟**

حذف اسلایدها، اسلایدهای معمولی خاصی را از مجموعه حذف می‌کند. پاک‌سازی طرح‌ها/استادهای استفاده‌نشده، اسلایدهای طرح یا استاد را که هیچ ارجاعی به آن‌ها ندارند حذف می‌کند، باعث کاهش حجم فایل می‌شود بدون این‌که محتوای اسلایدهای باقی‌مانده تغییر کند. این دو عمل مکمل یکدیگرند: معمولاً ابتدا حذف می‌کنید، سپس پاک‌سازی را انجام می‌دهید.