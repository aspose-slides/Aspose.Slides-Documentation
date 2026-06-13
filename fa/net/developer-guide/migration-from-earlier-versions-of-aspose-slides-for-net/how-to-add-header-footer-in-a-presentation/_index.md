---
title: چگونه سرصفحه‌ها و پاصفحه‌ها را به ارائه‌ها در .NET اضافه کنیم
linktitle: افزودن سرصفحه و پاصفحه
type: docs
weight: 20
url: /fa/net/how-to-add-header-footer-in-a-presentation/
keywords:
- انتقال
- افزودن سرصفحه
- افزودن پاصفحه
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
description: "بیاموزید چگونه در ارائه‌های PowerPoint (PPT، PPTX) و ODP در .NET، سرصفحه‌ها و پاصفحه‌ها را با استفاده از APIهای Aspose.Slides قدیمی و مدرن اضافه کنید."
---
{{% alert color="primary" %}} 

یک [Aspose.Slides برای .NET API](/slides/fa/net/) جدید منتشر شده است و اکنون این محصول واحد قابلیت تولید اسناد PowerPoint از ابتدا و ویرایش اسناد موجود را پشتیبانی می‌کند.

{{% /alert %}} 
## **پشتیبانی از کدهای قدیمی**
برای استفاده از کدهای قدیمی که با نسخه‌های Aspose.Slides برای .NET قبل از 13.x توسعه یافته‌اند، نیاز است برخی تغییرات جزئی در کد خود انجام دهید تا کد همانند قبل کار کند. تمام کلاس‌هایی که در نسخه‌های قدیمی Aspose.Slides برای .NET تحت فضای نام‌های Aspose.Slide و Aspose.Slides.Pptx موجود بودند، اکنون در یک فضای نام واحد Aspose.Slides ترکیب شده‌اند. لطفاً به قطعه کد ساده زیر برای افزودن سرصفحه و پاصفحه به ارائه در API قدیمی Aspose.Slides نگاهی بیندازید و مراحل انتقال به API ترکیبی جدید را دنبال کنید.
## **رویکرد قدیمی Aspose.Slides برای .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

// تنظیم ویژگی‌های قابل مشاهده سرصفحه و پاصفحه
// به‌روزرسانی فیلدهای تاریخ و زمان
// نمایش مکان‌گیر تاریخ و زمان
// نمایش مکان‌گیر پاصفحه
// نمایش شماره اسلاید
// تنظیم قابلیت مشاهده سرصفحه و پاصفحه در اسلاید عنوان
// نوشتن ارائه به دیسک
sourcePres.UpdateSlideNumberFields = true;
sourcePres.UpdateDateTimeFields = true;
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;
sourcePres.HeaderFooterManager.IsFooterVisible = true;
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);
sourcePres.Write("NewSource.pptx");
```

```c#
//ایجاد ارائه
Presentation pres = new Presentation();

//دریافت اولین اسلاید
Slide sld = pres.GetSlideByPosition(1);

//دسترسی به سرصفحه / پاصفحه اسلاید
HeaderFooter hf = sld.HeaderFooter;

//تنظیم قابلیت مشاهده شماره صفحه
hf.PageNumberVisible = true;

//تنظیم قابلیت مشاهده پاصفحه
hf.FooterVisible = true;

//تنظیم قابلیت مشاهده سرصفحه
hf.HeaderVisible = true;

//تنظیم قابلیت مشاهده تاریخ و زمان
hf.DateTimeVisible = true;

//تنظیم قالب تاریخ و زمان
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//تنظیم متن سرصفحه
hf.HeaderText = "Header Text";

//تنظیم متن پاصفحه
hf.FooterText = "Footer Text";

//نوشتن ارائه در دیسک
pres.Write("HeadFoot.ppt");
```



## **رویکرد جدید Aspose.Slides برای .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //تنظیم ویژگی‌های قابل مشاهده سرصفحه و پاصفحه
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //به‌روزرسانی فیلدهای تاریخ و زمان
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //نمایش مکان‌گیر تاریخ و زمان
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //نمایش مکان‌گیر پاصفحه
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //تنظیم قابلیت مشاهده سرصفحه و پاصفحه در اسلاید عنوان
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //نوشتن ارائه در دیسک
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```