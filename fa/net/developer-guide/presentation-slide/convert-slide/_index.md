---
title: تبدیل اسلایدهای ارائه به تصاویر در .NET
linktitle: اسلاید به تصویر
type: docs
weight: 41
url: /fa/net/convert-slide/
keywords:
- تبدیل اسلاید
- صدور اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به‌عنوان تصویر
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به Bitmap
- اسلاید به TIFF
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدها را از فرمت‌های PPT، PPTX و ODP به تصاویر در C# با استفاده از Aspose.Slides برای .NET تبدیل کنید — رندر سریع و با کیفیت بالا همراه با مثال‌های واضح کد."
---
## **مقدمه**

Aspose.Slides for .NET به شما امکان می‌دهد اسلایدهای ارائه PowerPoint و OpenDocument را به راحتی به فرمت‌های تصویری مختلف تبدیل کنید، از جمله BMP، PNG، JPG (JPEG)، GIF و سایر فرمت‌ها.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل مورد نظر را تعریف کنید و اسلایدهایی که می‌خواهید صادر کنید را با استفاده از انتخاب کنید:
    - رابط [ITiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/itiffoptions/) ، یا
    - رابط [IRenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/irenderingoptions/) .
2. تصویر اسلاید را با فراخوانی متد [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) تولید کنید.

در .NET، یک [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) شیئی است که به شما امکان کار با تصاویری تعریف‌شده توسط داده‌های پیکسل را می‌دهد. می‌توانید از یک نمونه از این کلاس برای ذخیره تصاویر در دامنه وسیعی از فرمت‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به Bitmap و ذخیره تصاویر در PNG**

می‌توانید یک اسلاید را به شیء Bitmap تبدیل کنید و مستقیماً در برنامه خود استفاده کنید. به‌جای آن، می‌توانید اسلاید را به Bitmap تبدیل کنید و سپس تصویر را در JPEG یا هر فرمت دلخواه دیگری ذخیره کنید.

این کد C# نشان می‌دهد که چگونه اولین اسلاید یک ارائه را به شیء Bitmap تبدیل کنید و سپس تصویر را در فرمت PNG ذخیره کنید:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // اسلاید اول ارائه را به یک بیت‌مپ تبدیل کنید.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // تصویر را با فرمت PNG ذخیره کنید.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است به تصویری با اندازهٔ خاصی نیاز داشته باشید. با استفاده از یک overload از متد [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/)، می‌توانید یک اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این کد نمونه نشان می‌دهد که چگونه این کار را انجام دهید:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // اسلاید اول ارائه را به یک بیت‌مپ با اندازهٔ مشخص تبدیل کنید.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // تصویر را با فرمت JPEG ذخیره کنید.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **تبدیل اسلایدهای حاوی نکات و نظرات به تصاویر**

برخی از اسلایدها ممکن است شامل نکات و نظرات باشند.

Aspose.Slides دو رابط —[ITiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/irenderingoptions/)—را فراهم می‌کند که به شما امکان کنترل رندر اسلایدهای ارائه به تصاویر را می‌دهد. هر دو رابط شامل ویژگی `SlidesLayoutOptions` هستند که به شما اجازه می‌دهد رندر نکات و نظرات روی اسلاید را هنگام تبدیل به تصویر تنظیم کنید.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای نکات و نظرات در تصویر حاصل را مشخص کنید.

این کد C# نشان می‌دهد که چگونه یک اسلاید حاوی نکات و نظرات را تبدیل کنید:

```cs
float scaleX = 2;
float scaleY = scaleX;

// یک فایل ارائه بارگذاری کنید.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // گزینه‌های رندرینگ را ایجاد کنید.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // موقعیت نکات را تنظیم کنید.
            CommentsPosition = CommentsPositions.Right,      // موقعیت نظرات را تنظیم کنید.
            CommentsAreaWidth = 500,                         // عرض ناحیه نظرات را تنظیم کنید.
            CommentsAreaColor = Color.AntiqueWhite           // رنگ ناحیه نظرات را تنظیم کنید.
        }
    };

    // اسلاید اول ارائه را به تصویر تبدیل کنید.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // تصویر را با فرمت GIF ذخیره کنید.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، ویژگی [NotesPosition](https://reference.aspose.com/slides/fa/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) نمی‌تواند به `BottomFull` تنظیم شود (برای تعیین موقعیت نکات) زیرا متن یک نکته ممکن است بسیار بزرگ باشد و نتواند در اندازهٔ تصویر مشخص شده جا بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

رابط [ITiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/itiffoptions/) کنترل بیشتری بر تصویر TIFF حاصل ارائه می‌دهد و به شما اجازه می‌دهد پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر را مشخص کنید.

این کد C# فرآیند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای تولید تصویر سیاه‑سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شود:

```cs
// یک فایل ارائه بارگذاری کنید.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // اولین اسلاید را از ارائه دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // اندازه تصویر را تنظیم کنید.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // قالب پیکسل را تنظیم کنید (سیاه و سفید).
        DpiX = 300,                                        // وضوح افقی را تنظیم کنید.
        DpiY = 300                                         // وضوح عمودی را تنظیم کنید.
    };

    // اسلاید را به تصویر با گزینه‌های مشخص شده تبدیل کنید.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // تصویر را با فرمت TIFF ذخیره کنید.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید و به‌صورت مؤثر کل ارائه را به مجموعه‌ای از تصاویر تبدیل نمایید.

این کد نمونه نشان می‌دهد که چگونه تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید در C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // ارائه را اسلاید به اسلاید به تصاویر رندر کنید.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // کنترل اسلایدهای مخفی (اسلایدهای مخفی رندر نشوند).
        if (presentation.Slides[i].Hidden)
            continue;

        // اسلاید را به تصویر تبدیل کنید.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // تصویر را با فرمت JPEG ذخیره کنید.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **رندر ایموجی‌های رنگی**

{{% alert title="Note" color="warning" %}} 
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، فونت‌های ایموجی استفاده‌شده در ارائه باید بر روی سیستمی که تبدیل را انجام می‌دهد نصب و در دسترس باشند. به‌عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به‌صورت تک‌رنگ در تصاویر خروجی نمایش داده شوند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides از رندر اسلایدهای دارای انیمیشن پشتیبانی می‌کند؟**  
خیر، متد `GetImage` تنها یک تصویر ثابت از اسلاید ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا اسلایدهای مخفی می‌توانند به‌عنوان تصویر صادر شوند؟**  
بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی پردازش شوند. فقط مطمئن شوید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را همراه با سایه‌ها و افکت‌ها ذخیره کرد؟**  
بله، Aspose.Slides از رندر سایه‌ها، شفافیت و سایر افکت‌های گرافیکی هنگام ذخیره اسلایدها به‌صورت تصویر پشتیبانی می‌کند.