---
title: تبدیل اسلایدهای ارائه به تصویر در جاوا
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/java/convert-slide/
keywords:
- تبدیل اسلاید
- صادرات اسلاید
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
description: "اسلایدها را از فرمت‌های PPT، PPTX و ODP به تصاویر در جاوا با استفاده از Aspose.Slides—رندرینگ سریع و با کیفیت بالا با مثال‌های کد واضح."
---
## **مقدمه**

Aspose.Slides for Java به شما امکان می‌دهد به سادگی اسلایدهای ارائه PowerPoint و OpenDocument را به قالب‌های تصویری مختلفی مانند BMP، PNG، JPG (JPEG)، GIF و غیره تبدیل کنید.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات موردنظر تبدیل را تعریف کنید و اسلایدهایی که می‌خواهید صادر کنید را با استفاده از:
    - رابط [ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/)، یا
    - رابط [IRenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irenderingoptions/) انتخاب کنید.
2. با فراخوانی متد [getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) تصویر اسلاید را تولید کنید.

در Aspose.Slides for Java، رابط [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) یک اینترفیس است که به شما اجازه می‌دهد با تصاویری که توسط داده‌های پیکسل تعریف می‌شوند کار کنید. می‌توانید با استفاده از این اینترفیس تصاویر را در طیف وسیعی از قالب‌ها (BMP، JPG، PNG و غیره) ذخیره کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصاویر در قالب PNG**

می‌توانید اسلاید را به یک شیء بیت‌مپ تبدیل کنید و مستقیم در برنامه خود استفاده کنید. یا می‌توانید اسلاید را به بیت‌مپ تبدیل کرده و سپس تصویر را در قالب JPEG یا هر قالب دلخواه دیگری ذخیره کنید.

این کد نشان می‌دهد که چگونه اولین اسلاید یک ارائه را به شیء بیت‌مپ تبدیل کرده و سپس تصویر را در قالب PNG ذخیره کنید:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // اسلاید اول ارائه را به یک بیت‌مپ تبدیل کنید.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // تصویر را در قالب PNG ذخیره کنید.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویری با اندازهٔ معینی دریافت کنید. با استفاده از یک overload از متد [getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)، می‌توانید اسلاید را به تصویری با ابعاد خاص (عرض و ارتفاع) تبدیل کنید.

این مثال کد نشان می‌دهد که چگونه این کار را انجام دهید:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // اسلاید اول ارائه را با اندازه مشخص به یک بیت‌مپ تبدیل کنید.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // تصویر را در قالب JPEG ذخیره کنید.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها با یادداشت‌ها و نظرات به تصاویر**

برخی اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو اینترفیس—[ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irenderingoptions/)—ارائه می‌کند که به شما امکان کنترل رندرینگ اسلایدهای ارائه به تصاویر را می‌دهد. هر دو اینترفیس شامل متد `setSlidesLayoutOptions` هستند که به شما اجازه می‌دهند رندرینگ یادداشت‌ها و نظرات روی اسلاید را هنگام تبدیل به تصویر پیکربندی کنید.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات در تصویر نهایی مشخص کنید.

این کد نشان می‌دهد که چگونه اسلایدی با یادداشت‌ها و نظرات را تبدیل کنید:

```java 
float scaleX = 2;
float scaleY = scaleX;

// فایل ارائه را بارگیری کنید.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // موقعیت یادداشت‌ها را تنظیم کنید.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // موقعیت نظرات را تنظیم کنید.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // عرض ناحیه نظرات را تنظیم کنید.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // رنگ ناحیه نظرات را تنظیم کنید.

    // گزینه‌های رندرینگ را ایجاد کنید.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // اسلاید اول ارائه را به یک تصویر تبدیل کنید.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // تصویر را در قالب GIF ذخیره کنید.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، متد [setNotesPosition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) نمی‌تواند مقدار `BottomFull` را اعمال کند (برای تعیین موقعیت یادداشت) زیرا متن یک یادداشت ممکن است بسیار بزرگ باشد و نتواند در اندازهٔ تصویر مشخص شده جا بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

رابط [ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) کنترل بیشتری بر تصویر TIFF خروجی فراهم می‌کند، به شما اجازه می‌دهد پارامترهایی مانند اندازه، رزولوشن، پالت رنگ و موارد دیگر را مشخص کنید.

این کد یک فرآیند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی یک تصویر سیاه‑سفید با رزولوشن 300 DPI و اندازه 2160 × 2800 استفاده می‌شوند:

```java 
// فایل ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // اسلاید اول را از ارائه دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // اندازه تصویر را تنظیم کنید.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // قالب پیکسل را تنظیم کنید (سیاه و سفید).
    tiffOptions.setDpiX(300);                                        // رزولوشن افقی را تنظیم کنید.
    tiffOptions.setDpiY(300);                                        // رزولوشن عمودی را تنظیم کنید.

    // اسلاید را با گزینه‌های مشخص به تصویر تبدیل کنید.
    IImage image = slide.getImage(tiffOptions);

    try {
        // تصویر را در قالب TIFF ذخیره کنید.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
پشتیبانی از TIFF در نسخه‌های پیش از JDK 9 تضمین نشده است.
{{% /alert %}} 

## **تبدیل همه اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید و در نتیجه کل ارائه را به مجموعه‌ای از تصاویر تبدیل نمایید.

این مثال کد نشان می‌دهد که چگونه تمام اسلایدهای یک ارائه را در Java به تصاویر تبدیل کنید:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // ارائه را به صورت اسلاید به اسلاید به تصاویر رندر کنید.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // کنترل اسلایدهای مخفی (اسلایدهای مخفی رندر نشوند).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // اسلاید را به تصویر تبدیل کنید.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // تصویر را در قالب JPEG ذخیره کنید.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
} 
```

## **رندر رنگی ایموجی‌ها**

{{% alert title="Note" color="warning" %}} 
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، قلم‌های ایموجی مورد استفاده در ارائه باید بر روی سیستمی که تبدیل را انجام می‌دهد نصب و قابل دسترس باشند. به عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این قلم موجود نباشد، ایموجی‌ها ممکن است به صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides رندر اسلایدهای با انیمیشن را پشتیبانی می‌کند؟**  
خیر، متد `getImage` فقط تصویر استاتیک اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**  
بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی پردازش شوند. فقط کافی است در حلقه پردازش گنجانده شوند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**  
بله، Aspose.Slides رندرینگ سایه‌ها، شفافیت و سایر افکت‌های گرافیکی را هنگام ذخیره اسلایدها به عنوان تصویر پشتیبانی می‌کند.