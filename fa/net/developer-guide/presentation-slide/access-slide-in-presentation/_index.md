---
title: دسترسی به اسلایدهای ارائه در .NET
linktitle: دسترسی به اسلاید
type: docs
weight: 20
url: /fa/net/access-slide-in-presentation/
keywords:
- دسترسی به اسلاید
- شاخص اسلاید
- شناسه اسلاید
- موقعیت اسلاید
- تغییر موقعیت
- ویژگی‌های اسلاید
- شماره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه اسلایدها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET دسترسی پیدا کنید و مدیریت کنید. بهره‌وری را با مثال‌های کد افزایش دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه اسلایدها را در یک ارائه با استفاده از Aspose.Slides دسترسی پیدا کرده و مدیریت کنید. این مقاله نشان می‌دهد چگونه اسلایدها را بر اساس شاخص صفر مبتنی از مجموعه `Slides` بازیابی کنید و چگونه یک اسلاید را با شناسه یکتا آن با استفاده از متد `GetSlideById` دسترسی پیدا کنید.

همچنین یاد خواهید گرفت چگونه موقعیت یک اسلاید را با تنظیم ویژگی `SlideNumber` تغییر دهید و چگونه شماره شروع اسلاید برای یک ارائه را با ویژگی `FirstSlideNumber` تعریف کنید. مثال‌ها بارگذاری یک ارائه، دریافت مراجع اسلاید، به‌روزرسانی ترتیب یا شماره‌گذاری اسلاید و ذخیره ارائهٔ اصلاح‌شده را به نمایش می‌گذارند.

## **دسترسی به اسلاید بر اساس شاخص**

تمام اسلایدهای یک ارائه به صورت عددی بر اساس موقعیت اسلاید از ۰ مرتب می‌شوند. اسلاید اول از طریق شاخص ۰ قابل دسترسی است؛ اسلاید دوم از طریق شاخص ۱؛ و غیره.

کلاس Presentation که نمایانگر یک فایل ارائه است، تمام اسلایدها را به عنوان یک مجموعه [ISlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection) (مجموعه‌ای از اشیای [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/) ) افشا می‌کند. این کد C# نشان می‌دهد چگونه از طریق شاخص به یک اسلاید دسترسی پیدا کنید:

```c#
// یک شی Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند
Presentation presentation = new Presentation("AccessSlides.pptx");

// مرجع یک اسلاید را از طریق شاخص آن دریافت می‌کند
ISlide slide = presentation.Slides[0];
```

## **دسترسی به اسلاید بر اساس شناسه**

هر اسلاید در یک ارائه دارای یک شناسه یکتا است. می‌توانید از متد [GetSlideById](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/getslidebyid) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ارائه می‌شود) برای هدف قرار دادن آن شناسه استفاده کنید. این کد C# نشان می‌دهد چگونه یک شناسه اسلاید معتبر فراهم کرده و از طریق متد [GetSlideById](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/getslidebyid) به آن اسلاید دسترسی پیدا کنید:

```c#
// یک شی Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند
Presentation presentation = new Presentation("AccessSlides.pptx");

// شناسه اسلاید را دریافت می‌کند
uint id = presentation.Slides[0].SlideId;

// با استفاده از شناسه آن به اسلاید دسترسی پیدا می‌کند
IBaseSlide slide = presentation.GetSlideById(id);
```

## **تغییر موقعیت اسلاید**
Aspose.Slides به شما امکان می‌دهد موقعیت یک اسلاید را تغییر دهید. برای مثال می‌توانید مشخص کنید اسلاید اول به اسلاید دوم تبدیل شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. مرجع اسلاید (که می‌خواهید موقعیت آن را تغییر دهید) را از طریق شاخص آن دریافت کنید.
1. موقعیت جدیدی برای اسلاید از طریق ویژگی [SlideNumber](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/slidenumber/) تنظیم کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد C# عملی را نشان می‌دهد که در آن اسلاید در موقعیت ۱ به موقعیت ۲ منتقل می‌شود:

```c#
 // یک شی Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند
 using (Presentation pres = new Presentation("ChangePosition.pptx"))
 {
     // اسلایدی را که موقعیت آن تغییر خواهد کرد دریافت می‌کند
     ISlide sld = pres.Slides[0];

     // موقعیت جدیدی برای اسلاید تنظیم می‌کند
     sld.SlideNumber = 2;

     // ارائهٔ تغییر یافته را ذخیره می‌کند
     pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
 }
```

اسلاید اول به اسلاید دوم تبدیل شد؛ اسلاید دوم به اسلاید اول تبدیل شد. هنگامی که موقعیت یک اسلاید را تغییر می‌دهید، سایر اسلایدها به‌طور خودکار تنظیم می‌شوند.

## **تنظیم شماره اسلاید**
با استفاده از ویژگی [FirstSlideNumber](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/firstslidenumber/) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ارائه می‌شود) می‌توانید شماره جدیدی برای اسلاید اول در یک ارائه مشخص کنید. این عملیات باعث محاسبهٔ مجدد شماره‌های دیگر اسلایدها می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. شماره اسلاید را دریافت کنید.
1. شماره اسلاید را تنظیم کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد C# عملی را نشان می‌دهد که در آن شماره اسلاید اول به ۱۰ تنظیم می‌شود:

```c#
// یک شی Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // شماره اسلاید را دریافت می‌کند
    int firstSlideNumber = presentation.FirstSlideNumber;

    // شماره اسلاید را تنظیم می‌کند
    presentation.FirstSlideNumber=10;
    
    // ارائهٔ تغییر یافته را ذخیره می‌کند
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

اگر ترجیح می‌دهید اسلاید اول را رد کنید، می‌توانید شماره‌گذاری را از اسلاید دوم شروع کنید (و شماره‌گذاری برای اسلاید اول را مخفی کنید) به این شکل:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // شماره اولین اسلاید ارائه را تنظیم می‌کند
    presentation.FirstSlideNumber = 0;

    // شماره اسلایدها را برای تمام اسلایدها نشان می‌دهد
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // شماره اسلاید را برای اسلاید اول مخفی می‌کند
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // ارائهٔ تغییر یافته را ذخیره می‌کند
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **سؤالات متداول**

**آیا شماره اسلایدی که کاربر می‌بیند با شاخص صفر مبتنی مجموعه مطابقت دارد؟**

شماره‌ای که بر روی اسلاید نشان داده می‌شود می‌تواند از مقدار دلخواهی (مثلاً ۱۰) شروع شود و نیازی به مطابقت با شاخص ندارد؛ این رابطه توسط تنظیم «شماره اسلاید اول» ارائه کنترل می‌شود.

**آیا اسلایدهای مخفی بر شاخص‌بندی تأثیر می‌گذارند؟**

بله. یک اسلاید مخفی در مجموعه باقی می‌ماند و در شاخص‌بندی شمارش می‌شود؛ «مخفی» فقط به نمایش مرتبط است، نه به موقعیت آن در مجموعه.

**آیا شاخص یک اسلاید هنگام افزودن یا حذف اسلایدهای دیگر تغییر می‌کند؟**

بله. شاخص‌ها همیشه ترتیب فعلی اسلایدها را منعکس می‌کنند و در زمان درج، حذف یا جابه‌جایی اسلایدها دوباره محاسبه می‌شوند.