---
title: تبدیل اسلایدهای ارائه به تصویر در جاوا
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/java/convert-slide/
keywords:
- تبدیل اسلاید
- صادر کردن اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- اسلاید به TIFF
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "تبدیل اسلایدها از PPT، PPTX و ODP به تصاویر در جاوا با استفاده از Aspose.Slides—رندر سریع و با کیفیت بالا با مثال‌های کد واضح."
---
## **مقدمه**

Aspose.Slides for Java به شما امکان می‌دهد تا به راحتی اسلایدهای ارائه PowerPoint و OpenDocument را به قالب‌های تصویری مختلفی مانند BMP، PNG، JPG (JPEG)، GIF و سایر فرمت‌ها تبدیل کنید.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل مورد نظر را تعریف کنید و اسلایدهایی که می‌خواهید صادر کنید را با استفاده از زیر انتخاب کنید:
    - رابط [ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) ، یا
    - رابط [IRenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irenderingoptions/) .
2. تصویر اسلاید را با فراخوانی متد [getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) تولید کنید.

در Aspose.Slides for Java، یک [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) یک رابط است که به شما اجازه می‌دهد با تصاویری که توسط داده‌های پیکسل تعریف شده‌اند کار کنید. می‌توانید از این رابط برای ذخیره‌سازی تصاویر در انواع فرمت‌های گسترده (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصاویر در PNG**

می‌توانید یک اسلاید را به شیء بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده کنید. به‌عنوان گزینه دیگر، می‌توانید اسلاید را به بیت‌مپ تبدیل کنید و سپس تصویر را در قالب JPEG یا هر فرمتی که ترجیح می‌دهید ذخیره کنید.

این کد نشان می‌دهد که چگونه اولین اسلاید یک ارائه را به شیء بیت‌مپ تبدیل کرده و سپس تصویر را در قالب PNG ذخیره کنید:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تبدیل اولین اسلاید در ارائه به یک بیت‌مپ.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // ذخیره تصویر در قالب PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویری با اندازه خاص دریافت کنید. با استفاده از یک overload از متد [getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)، می‌توانید اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این کد نمونه نشان می‌دهد که چگونه این کار را انجام دهید:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تبدیل اولین اسلاید در ارائه به یک بیت‌مپ با اندازه مشخص.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // ذخیره تصویر در قالب JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدهای حاوی یادداشت‌ها و نظرات به تصاویر**

برخی اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو رابط —[ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irenderingoptions/)—را فراهم می‌کند که به شما امکان می‌دهد رندرینگ اسلایدهای ارائه به تصاویر را کنترل کنید. هر دو رابط شامل متد `setSlidesLayoutOptions` هستند که به شما اجازه می‌دهد رندرینگ یادداشت‌ها و نظرات یک اسلاید را هنگام تبدیل به تصویر پیکربندی کنید.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات را در تصویر خروجی تعیین کنید.

این کد نشان می‌دهد که چگونه اسلایدی با یادداشت‌ها و نظرات را تبدیل کنید:

```java 
float scaleX = 2;
float scaleY = scaleX;

// بارگذاری فایل ارائه.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // تنظیم موقعیت یادداشت‌ها.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // تنظیم موقعیت نظرات.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // تنظیم عرض ناحیه نظرات.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // تنظیم رنگ ناحیه نظرات.

    // ایجاد گزینه‌های رندرینگ.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // تبدیل اولین اسلاید ارائه به یک تصویر.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // ذخیره تصویر در قالب GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، متد [setNotesPosition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) نمی‌تواند مقدار `BottomFull` (برای تعیین موقعیت یادداشت‌ها) را اعمال کند، زیرا متن یک یادداشت ممکن است بیش از حد بزرگ باشد و نتواند در اندازه تصویر مشخص شده جای بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

رابط [ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) کنترل بیشتری بر روی تصویر TIFF خروجی فراهم می‌کند؛ به شما امکان می‌دهد پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر را مشخص کنید.

این کد یک فرآیند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی تصویر سیاه‑سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شود:

```java 
// بارگذاری فایل ارائه.
Presentation presentation = new Presentation("sample.pptx");
try {
    // دریافت اولین اسلاید از ارائه.
    ISlide slide = presentation.getSlides().get_Item(0);

    // پیکربندی تنظیمات تصویر خروجی TIFF.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // تنظیم اندازه تصویر.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // تنظیم فرمت پیکسل (سیاه و سفید).
    tiffOptions.setDpiX(300);                                        // تنظیم وضوح افقی.
    tiffOptions.setDpiY(300);                                        // تنظیم وضوح عمودی.

    // تبدیل اسلاید به تصویر با گزینه‌های مشخص شده.
    IImage image = slide.getImage(tiffOptions);

    try {
        // ذخیره تصویر در قالب TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
پشتیبانی از Tiff در نسخه‌های پیش از JDK 9 تضمین نمی‌شود.
{{% /alert %}} 

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما اجازه می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید، به‌طوری که به‌صورت مؤثر کل ارائه به مجموعه‌ای از تصاویر تبدیل می‌شود.

این کد نمونه نشان می‌دهد که چگونه تمام اسلایدهای یک ارائه را به تصاویر در جاوا تبدیل کنید:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
        // رندر ارائه به تصاویر، اسلاید به اسلاید.
        for (int i = 0 ; i < presentation.getSlides().size(); i++)
        {
            // کنترل اسلایدهای مخفی (اسلایدهای مخفی رندر نمی‌شوند).
            if (presentation.getSlides().get_Item(i).getHidden())
                continue;

            // تبدیل اسلاید به تصویر.
            IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

            try {
                // ذخیره تصویر در قالب JPEG.
                image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
            } finally {
                image.dispose();
            }
        }
    } finally {
        presentation.dispose();
    } 
```

## **رندرینگ ایموجی‌های رنگی**

{{% alert title="Note" color="warning" %}} 
برای رندرینگ صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، فونت‌های ایموجی استفاده‌شده در ارائه باید بر روی سیستم انجام‌دهنده تبدیل نصب و در دسترس باشند. به‌عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به‌صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides از رندرینگ اسلایدها با انیمیشن پشتیبانی می‌کند؟**

خیر، متد `getImage` فقط تصویر ثابت اسلاید را ذخیره می‌کند و انیمیشن‌ها را نادیده می‌گیرد.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر استخراج کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای معمولی پردازش شوند. فقط اطمینان حاصل کنید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides هنگام ذخیره اسلایدها به عنوان تصاویر از رندرینگ سایه‌ها، شفافیت و سایر جلوه‌های گرافیکی پشتیبانی می‌کند.