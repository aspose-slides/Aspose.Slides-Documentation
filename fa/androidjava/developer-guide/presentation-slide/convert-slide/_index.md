---
title: تبدیل اسلایدهای ارائه به تصاویر در اندروید
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
description: "اسلایدها را از فرمت‌های PPT، PPTX و ODP به تصاویر تبدیل کنید با استفاده از Aspose.Slides برای Android—رندرینگ سریع و با کیفیت بالا همراه با مثال‌های واضح کد Java."
---
## **معرفی**

Aspose.Slides for Android via Java به شما امکان می‌دهد به‌راحتی اسلایدهای ارائه PowerPoint و OpenDocument را به فرمت‌های مختلف تصویری از جمله BMP، PNG، JPG (JPEG)، GIF و سایر تبدیل کنید.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل موردنظر را تعریف کنید و اسلایدهایی که می‌خواهید صادر کنید را با استفاده از موارد زیر انتخاب کنید:
    - رابط [ITiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiffoptions/)، یا
    - رابط [IRenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irenderingoptions/)
2. تصویر اسلاید را با فراخوانی متد [getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage--) تولید کنید.

در Aspose.Slides برای Android از طریق Java، [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) یک رابط است که به شما امکان کار با تصاویری تعریف‌شده توسط داده‌های پیکسل را می‌دهد. می‌توانید از این رابط برای ذخیره تصاویر در طیف وسیعی از فرمت‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به Bitmap و ذخیره تصاویر در PNG**

می‌توانید یک اسلاید را به شیء bitmap تبدیل کنید و مستقیماً در برنامه خود از آن استفاده کنید. همچنین می‌توانید اسلاید را به bitmap تبدیل کرده و سپس تصویر را در JPEG یا هر فرمت دلخواه دیگری ذخیره کنید.

این کد نحوه تبدیل اولین اسلاید یک پرزنتیشن به شیء bitmap و سپس ذخیره تصویر به فرمت PNG را نشان می‌دهد:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تبدیل اولین اسلاید در ارائه به بیت‌مپ.
    IImage image = presentation.getSlides().get_Item(0).getImage();
    try {
        // ذخیره تصویر با فرمت PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویر با اندازه‌ای خاص دریافت کنید. با استفاده از یک overload از متد [getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-)، می‌توانید یک اسلاید را به تصویر با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این کد نمونه نشان می‌دهد چگونه این کار را انجام دهید:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // تبدیل اولین اسلاید در ارائه به بیت‌مپ با اندازه مشخص.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // ذخیره تصویر با فرمت JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدهای حاوی یادداشت و نظرات به تصاویر**

برخی از اسلایدها ممکن است شامل یادداشت و نظرات باشند.

Aspose.Slides دو رابط—[ITiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irenderingoptions/)—را فراهم می‌کند که به شما امکان کنترل رندر اسلایدهای پرزنتیشن به تصاویر را می‌دهد. هر دو رابط شامل متد `setSlidesLayoutOptions` هستند که به شما اجازه می‌دهد رندر یادداشت‌ها و نظرات بر روی یک اسلاید هنگام تبدیل به تصویر را پیکربندی کنید.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات در تصویر خروجی را تعیین کنید.

این کد نشان می‌دهد چگونه یک اسلاید حاوی یادداشت و نظرات را به تصویر تبدیل کنید:

```java 
float scaleX = 2;
float scaleY = scaleX;

// یک فایل ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // تنظیم موقعیت یادداشت‌ها.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // تنظیم موقعیت نظرات.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // تنظیم عرض ناحیه نظرات.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // تنظیم رنگ ناحیه نظرات.

    // ایجاد گزینه‌های رندر.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // تبدیل اولین اسلاید ارائه به تصویر.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // ذخیره تصویر با فرمت GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، متد [setNotesPosition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) نمی‌تواند مقدار `BottomFull` (برای تعیین موقعیت یادداشت‌ها) را اعمال کند زیرا متن یک یادداشت ممکن است بیش از حد بزرگ باشد و نتواند در اندازه تصویر مشخص شده جای بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

رابط [ITiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiffoptions/) کنترل بیشتری بر تصویر TIFF خروجی فراهم می‌کند، با اجازه تعیین پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر.

این کد فرایند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی یک تصویر سیاه‑سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شود:

```java 
// یک فایل ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // اولین اسلاید را از ارائه دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // تنظیم اندازه تصویر.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // تنظیم فرمت پیکسل (سیاه و سفید).
    tiffOptions.setDpiX(300);                                        // تنظیم وضوح افقی.
    tiffOptions.setDpiY(300);                                        // تنظیم وضوح عمودی.

    // تبدیل اسلاید به تصویر با گزینه‌های مشخص‌شده.
    IImage image = slide.getImage(tiffOptions);

    try {
        // ذخیره تصویر با فرمت TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل همه اسلایدها به تصاویر**

Aspose.Slides به شما اجازه می‌دهد تمام اسلایدهای یک پرزنتیشن را به تصاویر تبدیل کنید، به‌گونه‌ای که کل پرزنتیشن به یک سری تصویر تبدیل می‌شود.

این کد نمونه نشان می‌دهد چگونه تمام اسلایدهای یک پرزنتیشن را به تصاویر در Java تبدیل کنید:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // ارائه را اسلاید به اسلاید به تصاویر رندر کنید.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // کنترل اسلایدهای مخفی (رندر نشدن اسلایدهای مخفی).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // اسلاید را به تصویر تبدیل کنید.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // تصویر را با فرمت JPEG ذخیره کنید.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **رندر ایموجی‌های رنگی**

{{% alert title="Note" color="warning" %}} 
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای پرزنتیشن به تصاویر، فونت‌های ایموجی مورد استفاده در پرزنتیشن باید روی سیستمی که تبدیل را انجام می‌دهد نصب و در دسترس باشند. به‌عنوان مثال، اگر پرزنتیشن از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به‌صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **سؤالات متداول**

**آیا Aspose.Slides از رندر اسلایدهای دارای انیمیشن پشتیبانی می‌کند؟**

خیر، متد `getImage` فقط یک تصویر ثابت از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصاویر صادر کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی پردازش شوند. کافی است اطمینان حاصل کنید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides هنگام ذخیره اسلایدها به‌صورت تصاویر، از رندر سایه‌ها، شفافیت و سایر افکت‌های گرافیکی پشتیبانی می‌کند.