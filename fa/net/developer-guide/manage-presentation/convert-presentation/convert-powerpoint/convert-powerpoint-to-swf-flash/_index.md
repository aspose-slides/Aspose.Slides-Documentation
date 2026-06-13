---
title: تبدیل ارائه‌های PowerPoint به SWF Flash در .NET
linktitle: PowerPoint به SWF
type: docs
weight: 80
url: /fa/net/convert-powerpoint-to-swf-flash/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به SWF
- ارائه به SWF
- اسلاید به SWF
- PPT به SWF
- PPTX به SWF
- PowerPoint به Flash
- ارائه به Flash
- اسلاید به Flash
- PPT به Flash
- PPTX به Flash
- ذخیره PPT به عنوان SWF
- ذخیره PPTX به عنوان SWF
- خروجی PPT به SWF
- خروجی PPTX به SWF
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تبدیل PowerPoint (PPT/PPTX) به SWF Flash در .NET با Aspose.Slides. نمونه‌های کد C# به صورت گام به گام، خروجی با کیفیت سریع، بدون خودکارسازی PowerPoint."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به فرمت SWF تبدیل کنید. این مقاله نشان می‌دهد چگونه یک ارائه را با متد [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) به فایل SWF ذخیره کنید و چگونه صادرات را با [SwfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/swfoptions/) پیکربندی کنید، از جمله تنظیمات نمایشگر و طرح نکات یا نظرات.

## **تبدیل ارائه‌ها به Flash**

متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/save/index) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ارائه می‌شود می‌تواند برای تبدیل کل ارائه به یک سند SWF استفاده شود. همچنین می‌توانید با استفاده از کلاس [SWFOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/swfoptions) و رابط [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/inotescommentslayoutingoptions) نظرات را در SWF تولید شده گنجانید. مثال زیر نشان می‌دهد چگونه یک ارائه را با استفاده از گزینه‌های ارائه شده توسط کلاس SWFOptions به سند SWF تبدیل کنید.

```c#
 // یک شی Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // در حال ذخیره‌سازی ارائه و صفحات یادداشت‌ها
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **سوالات متداول**

**آیا می‌توانم اسلایدهای مخفی را در SWF گنجانم؟**

بله. گزینهٔ [ShowHiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.export/swfoptions/showhiddenslides/) را در [SwfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/swfoptions/) فعال کنید. به طور پیش‌فرض، اسلایدهای مخفی صادر نمی‌شوند.

**چگونه می‌توانم فشرده‌سازی و اندازه نهایی SWF را کنترل کنم؟**

از پرچم [Compressed](https://reference.aspose.com/slides/fa/net/aspose.slides.export/swfoptions/compressed/) (به طور پیش‌فرض فعال) استفاده کنید و مقدار [JpegQuality](https://reference.aspose.com/slides/fa/net/aspose.slides.export/swfoptions/jpegquality/) را تنظیم کنید تا بین اندازه فایل و کیفیت تصویر تعادل برقرار شود.

**'ViewerIncluded' برای چه منظوری است و چه زمانی باید آن را غیرفعال کنم؟**

[ViewerIncluded](https://reference.aspose.com/slides/fa/net/aspose.slides.export/swfoptions/viewerincluded/) یک رابط کاربری پخش‌کننده توکار (کنترل‌های ناوبری، پنل‌ها، جستجو) اضافه می‌کند. اگر قصد استفاده از پخش‌کنندهٔ خود را دارید یا به یک چارچوب SWF بدون رابط کاربری نیاز دارید، آن را غیرفعال کنید.

**چه می‌شود اگر یک فونت منبع در ماشین صادر کننده موجود نباشد؟**

Aspose.Slides فونت را با فونتی که از طریق [DefaultRegularFont](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/defaultregularfont/) در [SwfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/) مشخص کرده‌اید جایگزین می‌کند تا از بازگشت ناخواسته جلوگیری شود.