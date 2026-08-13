---
title: نحوه افزودن سرصفحه‌ها و پاورقی‌ها به ارائه‌ها در .NET
linktitle: افزودن سرصفحه و پاورقی
type: docs
weight: 20
url: /fa/net/how-to-add-header-footer-in-a-presentation/
keywords:
- مهاجرت
- افزودن سرصفحه
- افزودن پاورقی
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نحوه افزودن سرصفحه‌ها و پاورقی‌ها در ارائه‌های PowerPoint (PPT، PPTX) و ODP در .NET را با استفاده از هر دو API قدیمی و مدرن Aspose.Slides بیاموزید."
---
{{% alert color="info" %}} 
یک [Aspose.Slides for .NET API](/slides/fa/net/) جدید منتشر شده است و اکنون این محصول واحد قابلیت تولید اسناد PowerPoint از صفر و ویرایش اسناد موجود را دارد.
{{% /alert %}} 
## **پشتیبانی از کدهای پیشین**
برای استفاده از کدهای پیشین که با نسخه‌های Aspose.Slides برای .NET پیش از 13.x توسعه یافته‌اند، باید مقداری تغییر کوچک در کد خود اعمال کنید و کد همان‌طور که قبلاً عمل می‌کرد، کار خواهد کرد. تمام کلاس‌هایی که در Aspose.Slides برای .NET قدیمی تحت فضای نام‌های Aspose.Slide و Aspose.Slides.Pptx وجود داشتند، اکنون در یک فضای نام واحد Aspose.Slides ادغام شده‌اند. لطفاً به قطعه کد ساده زیر برای افزودن سرصفحه و پاورقی به ارائه در API قدیمی Aspose.Slides نگاهی بیندازید و مراحل توصیف‌شده برای مهاجرت به API جدید ادغام‌شده را دنبال کنید.
## **رویکرد قدیمی Aspose.Slides برای .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//تنظیم ویژگی‌های نمایانی سرصفحه و پاورقی
//به‌روزرسانی فیلدهای تاریخ و زمان
//نمایش جای‌گذاری تاریخ و زمان
//نمایش جای‌گذاری پاورقی
//نمایش شماره اسلاید
//تنظیم نمایانی سرصفحه و پاورقی بر روی اسلاید عنوان
//نوشتن ارائه بر روی دیسک
sourcePres.UpdateSlideNumberFields = true;
sourcePres.UpdateDateTimeFields = true;
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;
sourcePres.HeaderFooterManager.IsFooterVisible = true;
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//ایجاد ارائه
Presentation pres = new Presentation();

//دریافت اولین اسلاید
Slide sld = pres.GetSlideByPosition(1);

//دسترسی به سرصفحه / پاورقی اسلاید
HeaderFooter hf = sld.HeaderFooter;

//تنظیم نمایانی شماره صفحه
hf.PageNumberVisible = true;

//تنظیم نمایانی پاورقی
hf.FooterVisible = true;

//تنظیم نمایانی سرصفحه
hf.HeaderVisible = true;

//تنظیم نمایانی تاریخ و زمان
hf.DateTimeVisible = true;

//تنظیم قالب تاریخ و زمان
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//تنظیم متن سرصفحه
hf.HeaderText = "Header Text";

//تنظیم متن پاورقی
hf.FooterText = "Footer Text";

//نوشتن ارائه به دیسک
pres.Write("HeadFoot.ppt");
```


## **رویکرد جدید Aspose.Slides برای .NET 13.x**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //تنظیم ویژگی‌های نمایانی سرصفحه و پاورقی
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //به‌روزرسانی فیلدهای تاریخ و زمان
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //نمایش جای‌گذاری تاریخ و زمان
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //نمایش جای‌گذاری پاورقی
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //تنظیم نمایانی سرصفحه و پاورقی بر روی اسلاید عنوان
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //نوشتن ارائه به دیسک
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```