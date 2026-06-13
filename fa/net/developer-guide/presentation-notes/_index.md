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
## **نمای کلی**

Aspose.Slides امکان حذف اسلایدهای یادداشت را از یک ارائه فراهم می‌کند. در این موضوع، این ویژگی را معرفی می‌کنیم، شامل چگونگی حذف یادداشت‌ها و نحوه اعمال استایل بر اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلایدی حذف کرده و همچنین استایل‌گذاری بر یادداشت‌های موجود انجام دهید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

## **حذف یادداشت‌ها از یک اسلاید**

یادداشت‌های یک اسلاید خاص می‌تواند همان‌طور که در مثال زیر نشان داده شده است حذف شود:

```c#
// یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// حذف یادداشت‌های اسلاید اول
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// ذخیره ارائه بر روی دیسک
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **حذف یادداشت‌ها از تمام اسلایدها**

یادداشت‌های تمام اسلایدهای یک ارائه می‌تواند همان‌طور که در مثال زیر نشان داده شده است حذف شود:

```c#
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است 
Presentation presentation = new Presentation("AccessSlides.pptx");

// حذف یادداشت‌های تمام اسلایدها
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// ذخیره ارائه بر روی دیسک
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **افزودن استایل به یادداشت‌ها**

ویژگی NotesStyle به رابط [IMasterNotesSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasternotesslide) و کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/masternotesslide) به ترتیب اضافه شده است. این ویژگی سبک متن یادداشت‌ها را تعیین می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```c#
// یک شیء Presentation ایجاد می‌کند که نمایانگر فایل ارائه است
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // دریافت سبک متن MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //تنظیم گلوله نماد برای پاراگراف‌های سطح اول
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // ذخیرهٔ فایل PPTX بر روی دیسک
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **سؤالات متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید قابل دسترسی هستند: هر اسلاید یک [NotesSlideManager](https://reference.aspose.com/slides/fa/net/aspose.slides/notesslidemanager/) و یک [property](https://reference.aspose.com/slides/fa/net/aspose.slides/notesslidemanager/notesslide/) دارد که شیء یادداشت‌ها را برمی‌گرداند، یا `null` اگر یادداشتی وجود نداشته باشد.

**آیا پشتیبانی از یادداشت‌ها در نسخه‌های مختلف PowerPoint که کتابخانه با آن‌ها کار می‌کند متفاوت است؟**

این کتابخانه بر روی طیف گسترده‌ای از فرمت‌های Microsoft PowerPoint (از نسخه 97 تا جدیدتر) و ODP هدف‌گذاری شده است؛ یادداشت‌ها در این فرمت‌ها پشتیبانی می‌شوند بدون اینکه به نسخه نصب‌شده PowerPoint وابسته باشد.