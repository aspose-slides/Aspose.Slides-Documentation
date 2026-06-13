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
- ذخیره اسلاید به عنوان تصویر
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
description: "تبدیل اسلایدها از فرمت‌های PPT، PPTX و ODP به تصاویر در C# با استفاده از Aspose.Slides برای .NET—رندر سریع و با کیفیت بالا همراه با مثال‌های کد واضح."
---
## **مقدمه**

Aspose.Slides for .NET به شما امکان می‌دهد اسلایدهای ارائه PowerPoint و OpenDocument را به سادگی به انواع فرمت‌های تصویری شامل BMP، PNG، JPG (JPEG)، GIF و … تبدیل کنید.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل مورد نظر را تعریف کنید و اسلایدهایی که می‌خواهید صادر کنید را با استفاده از:
    - رابط [ITiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/itiffoptions/) یا
    - رابط [IRenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/irenderingoptions/) انتخاب کنید.
2. تصویر اسلاید را با فراخوانی متد [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) تولید کنید.

در .NET، کلاس [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) شی‌ای است که به شما امکان کار با تصاویری را می‌دهد که توسط داده‌های پیکسل تعریف شده‌اند. می‌توانید از یک نمونه از این کلاس برای ذخیره تصاویر در دامنه وسیعی از فرمت‌ها (BMP، JPG، PNG و ...) استفاده کنید.

## **تبدیل اسلایدها به Bitmap و ذخیره تصویرها به فرمت PNG**

می‌توانید اسلاید را به یک شیء bitmap تبدیل کنید و مستقیماً در برنامهٔ خود استفاده کنید. به‌علاوه، می‌توانید اسلاید را به bitmap تبدیل کرده و سپس تصویر را در فرمت JPEG یا هر فرمت دلخواه دیگر ذخیره کنید.

این کد C# نشان می‌دهد چگونه اسلاید اول یک ارائه را به شیء bitmap تبدیل کرده و سپس تصویر را به فرمت PNG ذخیره کنید:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // اسلاید اول ارائه را به یک bitmap تبدیل می‌کند.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // تصویر را با فرمت PNG ذخیره می‌کند.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویری با اندازهٔ خاص به دست آورید. با استفاده از یک overload از متد [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/)، می‌توانید اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این نمونه کد نشان می‌دهد چگونه این کار را انجام دهید:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // اسلاید اول ارائه را به یک bitmap با اندازهٔ مشخص تبدیل می‌کند.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // تصویر را با فرمت JPEG ذخیره می‌کند.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **تبدیل اسلایدهای دارای یادداشت‌ها و نظرات به تصویر**

برخی اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو رابط — [ITiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/irenderingoptions/) — فراهم می‌کند که به شما امکان کنترل رندرینگ اسلایدهای ارائه به تصویر را می‌دهد. هر دو رابط شامل ویژگی `SlidesLayoutOptions` هستند که به شما اجازه می‌دهد رندرینگ یادداشت‌ها و نظرات روی اسلاید را هنگام تبدیل به تصویر پیکربندی کنید.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) می‌توانید موقعیت مورد نظرتان برای نمایش یادداشت‌ها و نظرات در تصویر نهایی را تعیین کنید.

این کد C# نشان می‌دهد چگونه اسلایدی با یادداشت‌ها و نظرات را تبدیل کنید:

```cs
float scaleX = 2;
float scaleY = scaleX;

// بارگذاری یک فایل ارائه.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // ایجاد گزینه‌های رندرینگ.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // تنظیم موقعیت یادداشت‌ها.
            CommentsPosition = CommentsPositions.Right,      // تنظیم موقعیت نظرات.
            CommentsAreaWidth = 500,                         // تنظیم عرض ناحیه نظرات.
            CommentsAreaColor = Color.AntiqueWhite           // تنظیم رنگ ناحیه نظرات.
        }
    };

    // تبدیل اولین اسلاید ارائه به تصویر.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // ذخیره تصویر با فرمت GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، ویژگی [NotesPosition](https://reference.aspose.com/slides/fa/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) نمی‌تواند به مقدار `BottomFull` تنظیم شود (برای تعیین موقعیت یادداشت‌ها) زیرا متن یک یادداشت ممکن است بسیار بزرگ باشد و نتواند در اندازهٔ مشخص شدهٔ تصویر جا بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

رابط [ITiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/itiffoptions/) کنترل بیشتری بر تصویر TIFF حاصل ارائه می‌دهد، به شما اجازه می‌دهد پارامترهایی مانند اندازه، وضوح، پالت رنگ و … را مشخص کنید.

این کد C# نشان می‌دهد یک فرآیند تبدیل که در آن گزینه‌های TIFF برای خروجی تصویر سیاه‑سفید با وضوح 300 DPI و اندازهٔ 2160 × 2800 استفاده می‌شود:

```cs
// بارگذاری یک فایل ارائه.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // دریافت اولین اسلاید از ارائه.
    ISlide slide = presentation.Slides[0];

    // پیکربندی تنظیمات تصویر TIFF خروجی.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // تنظیم اندازه تصویر.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // تنظیم فرمت پیکسل (سیاه و سفید).
        DpiX = 300,                                        // تنظیم وضوح افقی.
        DpiY = 300                                         // تنظیم وضوح عمودی.
    };

    // تبدیل اسلاید به تصویر با گزینه‌های مشخص شده.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // ذخیره تصویر با فرمت TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصویر تبدیل کنید، به‌طوری که کل ارائه به مجموعه‌ای از تصاویر تبدیل شود.

این نمونه کد نشان می‌دهد چگونه تمام اسلایدهای یک ارائه را به تصویر تبدیل کنید در C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // ارائه را به صورت اسلاید به اسلاید به تصویر تبدیل می‌کند.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // کنترل اسلایدهای مخفی (اسلایدهای مخفی رندر نشوند).
        if (presentation.Slides[i].Hidden)
            continue;

        // تبدیل اسلاید به تصویر.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // ذخیره تصویر با فرمت JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **سوالات متداول**

**1. آیا Aspose.Slides از رندرینگ اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر، متد `GetImage` فقط تصویر ثابت اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**2. آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی پردازش شوند. فقط مطمئن شوید که در حلقه پردازش گنجانده شده‌اند.

**3. آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides از رندرینگ سایه‌ها، شفافیت و سایر افکت‌های گرافیکی هنگام ذخیره اسلایدها به عنوان تصویر پشتیبانی می‌کند.