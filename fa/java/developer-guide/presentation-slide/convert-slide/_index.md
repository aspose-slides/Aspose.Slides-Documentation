---
title: تبدیل اسلایدهای ارائه به تصاویر در جاوا
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
description: "اسلایدها را از فرمت‌های PPT، PPTX و ODP به تصاویر در جاوا با استفاده از Aspose.Slides تبدیل کنید—رندر سریع و با کیفیت بالا همراه با مثال‌های کد واضح."
---
## **مقدمه**

Aspose.Slides for Java به شما امکان می‌دهد اسلایدهای ارائه PowerPoint و OpenDocument را به راحتی به فرمت‌های مختلف تصویری تبدیل کنید، از جمله BMP، PNG، JPG (JPEG)، GIF و سایر فرمت‌ها.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات دلخواه تبدیل را تعریف کنید و اسلایدهای مورد نظر برای استخراج را با استفاده از موارد زیر انتخاب کنید:
    - اینترفیس [ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) ، یا
    - اینترفیس [IRenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irenderingoptions/) .
2. تصویر اسلاید را با فراخوانی متد [getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) تولید کنید.

در Aspose.Slides for Java، [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) یک اینترفیس است که به شما امکان کار با تصاویر تعریف‌شده بر اساس داده‌های پیکسل را می‌دهد. می‌توانید از این اینترفیس برای ذخیره‌سازی تصاویر در طیف وسیعی از فرمت‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصویرها به فرمت PNG**

می‌توانید یک اسلاید را به یک شیء بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده کنید. به‌طور جایگزین، می‌توانید اسلاید را به بیت‌مپ تبدیل کرده و سپس تصویر را در قالب JPEG یا هر قالب دلخواه دیگری ذخیره کنید.

این کد نشان می‌دهد که چگونه اولین اسلاید یک ارائه را به شیء بیت‌مپ تبدیل کنید و سپس تصویر را در قالب PNG ذخیره کنید:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // اسلاید اول ارائه را به بیت‌مپ تبدیل کنید.
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

ممکن است نیاز داشته باشید تصویری با اندازهٔ خاص دریافت کنید. با استفاده از یک overload از متد [getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)، می‌توانید اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این کد نمونه نشان می‌دهد که چگونه این کار را انجام دهید:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // اسلاید اول ارائه را به بیت‌مپ با اندازه مشخص تبدیل کنید.
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

## **تبدیل اسلایدهای حاوی یادداشت و نظرات به تصاویر**

برخی اسلایدها ممکن است حاوی یادداشت‌ها و نظرات باشند.

Aspose.Slides دو اینترفیس——[ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) و [IRenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irenderingoptions/)——را فراهم می‌کند که به شما اجازه می‌دهد رندر اسلایدهای ارائه به تصویر را کنترل کنید. هر دو اینترفیس شامل متد `setSlidesLayoutOptions` هستند که امکان پیکربندی رندر یادداشت‌ها و نظرات روی اسلاید هنگام تبدیل به تصویر را می‌دهند.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات در تصویر نهایی مشخص کنید.

این کد نشان می‌دهد که چگونه یک اسلاید را همراه با یادداشت‌ها و نظرات تبدیل کنید:

```java 
float scaleX = 2;
float scaleY = scaleX;

// یک فایل ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // مکان یادداشت‌ها را تنظیم کنید.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // مکان نظرات را تنظیم کنید.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // عرض ناحیه نظرات را تنظیم کنید.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // رنگ ناحیه نظرات را تنظیم کنید.

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

در هر فرآیند تبدیل اسلاید به تصویر، متد [setNotesPosition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) نمی‌تواند مقدار `BottomFull` را اعمال کند (برای تعیین موقعیت یادداشت) زیرا متن یادداشت ممکن است بسیار بزرگ باشد و نتواند در اندازهٔ مشخص‌شده تصویر جا بگیرد.

{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

اینترفیس [ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) کنترل بیشتری بر روی تصویر TIFF خروجی فراهم می‌کند، به شما اجازه می‌دهد پارامترهایی مانند اندازه، وضوح، پلت رنگ و موارد دیگر را تعیین کنید.

این کد یک فرآیند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی یک تصویر سیاه‌سفید با وضوح 300 DPI و اندازهٔ 2160 × 2800 استفاده می‌شود:

```java 
// یک فایل ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // اسلاید اول را از ارائه دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // اندازه تصویر را تنظیم کنید.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // فرمت پیکسل را تنظیم کنید (سیاه و سفید).
    tiffOptions.setDpiX(300);                                        // وضوح افقی را تنظیم کنید.
    tiffOptions.setDpiY(300);                                        // وضوح عمودی را تنظیم کنید.

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

پشتیبانی از Tiff در نسخه‌های قدیمی‌تر از JDK 9 تضمین نشده است.

{{% /alert %}} 

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید و به‌صورت مؤثری کل ارائه را به یک سری تصویر تبدیل کنید.

این کد نمونه نشان می‌دهد که چگونه تمام اسلایدهای یک ارائه را در جاوا به تصاویر تبدیل کنید:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // ارائه را به صورت اسلاید به اسلاید به تصاویر رندر کنید.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // اسلایدهای مخفی را کنترل کنید (اسلایدهای مخفی رندر نشوند).
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

**آیا Aspose.Slides از رندر اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر، متد `getImage` فقط یک تصویر ثابت از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر استخراج کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی پردازش شوند. فقط مطمئن شوید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides از رندر سایه‌ها، شفافیت و سایر افکت‌های گرافیکی هنگام ذخیره اسلایدها به عنوان تصویر پشتیبانی می‌کند.