---
title: تبدیل اسلایدهای ارائه به تصویر در اندروید
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "اسلایدهای PPT، PPTX و ODP را با استفاده از Aspose.Slides برای اندروید به تصویر تبدیل کنید—رندرینگ سریع و با کیفیت بالا همراه با مثال‌های واضح کد جاوا."
---
## **معرفی**

Aspose.Slides for Android via Java به شما امکان می‌دهد اسلایدهای ارائه PowerPoint و OpenDocument را به فرمت‌های تصویر مختلف از جمله BMP، PNG، JPG (JPEG)، GIF و دیگران به‌راحتی تبدیل کنید.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل موردنظر را تعریف کنید و اسلایدهای موردنظر برای استخراج را با استفاده از:
    - رابط [ITiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiffoptions/) یا
    - رابط [IRenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irenderingoptions/) انتخاب کنید.
2. تصویر اسلاید را با فراخوانی متد [getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage--) تولید کنید.

در Aspose.Slides for Android via Java، یک [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) یک رابط است که به شما امکان کار با تصاویر تعریف‌شده توسط داده‌های پیکسل را می‌دهد. می‌توانید از این رابط برای ذخیره تصاویر در طیف وسیعی از فرمت‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصاویر در PNG**

می‌توانید یک اسلاید را به شیء بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده کنید. همچنین می‌توانید اسلاید را به بیت‌مپ تبدیل کرده و سپس تصویر را در JPEG یا هر فرمت دلخواه دیگر ذخیره کنید.

این کد نشان می‌دهد چگونه اولین اسلاید یک ارائه را به شیء بیت‌مپ تبدیل و سپس تصویر را در فرمت PNG ذخیره کنید:

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

## **تبدیل اسلایدها به تصویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویری با اندازه خاص دریافت کنید. با استفاده از یک overload از متد [getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) می‌توانید اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این نمونه کد نشان می‌دهد چگونه این کار را انجام دهید:

```java 
Size imageSize = new Size(1820, 1040);

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

## **تبدیل اسلایدهای حاوی یادداشت‌ها و نظرات به تصویر**

برخی اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو رابط—[ITiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irenderingoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد رندرینگ اسلایدهای ارائه به تصویر را کنترل کنید. هر دو رابط شامل متد `setSlidesLayoutOptions` هستند که امکان پیکربندی رندرینگ یادداشت‌ها و نظرات بر روی اسلاید هنگام تبدیل به تصویر را می‌دهند.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات را در تصویر نهایی تعیین کنید.

این کد نشان می‌دهد چگونه یک اسلاید همراه با یادداشت‌ها و نظرات را تبدیل کنید:

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
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // رنگ ناحیه نظرات را تنظیم کنید.

    // گزینه‌های رندرینگ را ایجاد کنید.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // اسلاید اول ارائه را به تصویر تبدیل کنید.
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
در هر فرایند تبدیل اسلاید به تصویر، متد [setNotesPosition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) نمی‌تواند مقدار `BottomFull` را اعمال کند (برای تعیین موقعیت یادداشت) زیرا متن یک یادداشت ممکن است بسیار بزرگ باشد و نتواند در اندازه تصویر مشخص شده جا بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصویر با استفاده از گزینه‌های TIFF**

رابط [ITiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiffoptions/) کنترل بیشتری بر تصویر TIFF خروجی فراهم می‌کند و به شما اجازه می‌دهد پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر را مشخص کنید.

این کد یک فرایند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی تصویر سیاه‑سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شوند:

```java 
// فایل ارائه را بارگیری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // اولین اسلاید را از ارائه دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // اندازه تصویر را تنظیم کنید.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // فرمت پیکسل را تنظیم کنید (سیاه و سفید).
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

## **تبدیل تمام اسلایدها به تصویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصویر تبدیل کنید و به‌این‌ترتیب کل ارائه را به مجموعه‌ای از تصاویر تبدیل نمایید.

این نمونه کد نشان می‌دهد چگونه تمام اسلایدهای یک ارائه را در Java به تصویر تبدیل کنید:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // ارائه را به‌صورت اسلاید به اسلاید به تصاویر رندر کنید.
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

## **پرسش‌های متداول**

**آیا Aspose.Slides قابلیت رندرینگ اسلایدهای دارای انیمیشن را پشتیبانی می‌کند؟**

خیر، متد `getImage` فقط تصویر ایستایی از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای مخفی را به تصویر صادر کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای معمولی پردازش شوند. فقط کافی است اطمینان حاصل کنید که در حلقه پردازش گنجانده شوند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides رندرینگ سایه‌ها، شفافیت و سایر اثرات گرافیکی را هنگام ذخیره اسلایدها به صورت تصویر پشتیبانی می‌کند.