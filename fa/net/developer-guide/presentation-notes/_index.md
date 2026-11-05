---
title: مدیریت یادداشت‌های ارائه در .NET
linktitle: یادداشت‌های ارائه
type: docs
weight: 110
url: /fa/net/presentation-notes/
keywords:
- یادداشت‌ها
- اسلاید یادداشت
- افزودن یادداشت
- حذف یادداشت
- سبک یادداشت
- یادداشت‌های اصلی
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای .NET سفارشی کنید. به‌صورت یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **بررسی کلی**

Aspose.Slides امکان حذف اسلایدهای یادداشت را از یک ارائه فراهم می‌کند. در این مطلب به معرفی این ویژگی، شامل چگونگی حذف یادداشت‌ها و اعمال سبک به اسلایدهای یادداشت در یک ارائه می‌پردازیم. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلایدی حذف کنید و همچنین به یادداشت‌های موجود سبک اعمال کنید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

برای خواندن یا تغییر ابعاد صفحه یادداشت‌ها، تغییر جهت و بررسی رفتار خروجی، به [اندازه صفحه یادداشت‌ها](/slides/fa/net/notes-size/) مراجعه کنید.

## **حذف یادداشت‌ها از یک اسلاید**
یادداشت‌های یک اسلاید خاص می‌تواند همان‌طور که در مثال زیر نشان داده شده است حذف شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
Presentation presentation = new Presentation("AccessSlides.pptx");

// حذف یادداشت‌های اسلاید اول
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// ذخیرهٔ ارائه بر روی دیسک
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **حذف یادداشت‌ها از تمام اسلایدها**
یادداشت‌های تمام اسلایدهای یک ارائه می‌تواند همان‌طور که در مثال زیر نشان داده شده است حذف شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است 
Presentation presentation = new Presentation("AccessSlides.pptx");

// حذف یادداشت‌های تمام اسلایدها
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// ذخیرهٔ ارائه بر روی دیسک
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **افزودن سبک یادداشت‌ها**
صفت NotesStyle به رابط [IMasterNotesSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasternotesslide) و کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/masternotesslide) اضافه شده است. این صفت سبک متن یادداشت‌ها را مشخص می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```c#
using Aspose.Slides;

// یک شیء کلاس Presentation ایجاد می‌کند که نمایانگر فایل ارائه است
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // دریافت سبک متن MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //تنظیم نماد بولت برای پاراگراف‌های سطح اول
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // ذخیره فایل PPTX بر روی دیسک
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **سوالات متداول**

### کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟
یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی پیدا می‌کنند: هر اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/net/aspose.slides/notesslidemanager/) و یک [property](https://reference.aspose.com/slides/fa/net/aspose.slides/notesslidemanager/notesslide/) است که شیء یادداشت‌ها را برمی‌گرداند، یا `null` اگر هیچ یادداشتی وجود نداشته باشد.

### آیا در پشتیبانی از یادداشت‌ها بین نسخه‌های مختلف PowerPoint که کتابخانه با آن‌ها کار می‌کند تفاوتی وجود دارد؟
این کتابخانه هدف‌گذاری بر روی طیف وسیعی از فرمت‌های Microsoft PowerPoint (97 به بعد) و ODP را دارد؛ یادداشت‌ها در این فرمت‌ها بدون نیاز به یک نسخه نصب‌شده از PowerPoint پشتیبانی می‌شوند.