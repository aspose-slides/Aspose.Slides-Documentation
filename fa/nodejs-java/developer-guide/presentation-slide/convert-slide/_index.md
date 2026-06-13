---
title: تبدیل اسلایدهای ارائه به تصویر در JavaScript
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/nodejs-java/convert-slide/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "اسلایدها را از فرمت‌های PPT، PPTX و ODP به تصویر در JavaScript تبدیل کنید با استفاده از Aspose.Slides برای Node.js via Java — رندر سریع و با کیفیت بالا با مثال‌های کد واضح."
---
## **مقدمه**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد به راحتی اسلایدهای ارائه PowerPoint و OpenDocument را به قالب‌های مختلف تصویر تبدیل کنید، از جمله BMP، PNG، JPG (JPEG)، GIF و دیگران.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل مورد نظر را تعریف کنید و اسلایدهای مورد نظر برای صادرات را با استفاده از زیر انتخاب کنید:
    - کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) یا
    - کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/) .
2. تصویر اسلاید را با فراخوانی متد [getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage) تولید کنید.

در Aspose.Slides برای Node.js via Java، کلاس [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) کلاسی است که به شما امکان می‌دهد با تصاویری که بر پایه داده‌های پیکسل تعریف شده‌اند کار کنید. می‌توانید از این کلاس برای ذخیره‌سازی تصاویر در انواع مختلف قالب‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصاویر در PNG**

می‌توانید یک اسلاید را به شیء بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده کنید. همچنین می‌توانید اسلاید را به بیت‌مپ تبدیل کنید و سپس تصویر را در JPEG یا هر قالب دلخواه دیگری ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه اولین اسلاید یک ارائه را به شیء بیت‌مپ تبدیل کرده و سپس تصویر را در قالب PNG ذخیره کنید:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // اسلاید اول ارائه را به بیت‌مپ تبدیل کنید.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // تصویر را در قالب PNG ذخیره کنید.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها به تصویر با اندازه‌های سفارشی**

ممکن است به تصویر با اندازه‌ای خاص نیاز داشته باشید. با استفاده از یک overload از متد [getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage)، می‌توانید یک اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این کد نمونه نشان می‌دهد چگونه این کار را انجام دهید:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // اسلاید اول ارائه را با اندازه مشخص به بیت‌مپ تبدیل کنید.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // تصویر را در قالب JPEG ذخیره کنید.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدهای دارای یادداشت و نظرات به تصویر**

برخی اسلایدها ممکن است شامل یادداشت و نظرات باشند.

Aspose.Slides دو کلاس—[TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) و [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد رندر اسلایدهای ارائه به تصویر را کنترل کنید. هر دو کلاس شامل متد `setSlidesLayoutOptions` هستند که به شما امکان می‌دهد رندر یادداشت‌ها و نظرات روی یک اسلاید هنگام تبدیل به تصویر را پیکربندی کنید.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود را برای یادداشت‌ها و نظرات در تصویر خروجی مشخص کنید.

این کد JavaScript نشان می‌دهد چگونه یک اسلاید با یادداشت و نظرات را تبدیل کنید:

```js
const scaleX = 2;
const scaleY = scaleX;

// یک فایل ارائه را بارگذاری کنید.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // موقعیت یادداشت‌ها را تنظیم کنید.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // موقعیت نظرات را تنظیم کنید.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // عرض ناحیه نظرات را تنظیم کنید.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // رنگ ناحیه نظرات را تنظیم کنید.

    // گزینه‌های رندرینگ را ایجاد کنید.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // اسلاید اول ارائه را به تصویر تبدیل کنید.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // تصویر را در قالب GIF ذخیره کنید.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، متد [setNotesPosition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) نمی‌تواند مقدار `BottomFull` را اعمال کند (برای مشخص کردن موقعیت یادداشت) زیرا متن یادداشت ممکن است بسیار بزرگ باشد و نتواند در اندازه تصویر مشخص شده جا بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) کنترل بیشتری بر تصویر TIFF خروجی فراهم می‌کند با این امکان که پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر را مشخص کنید.

این کد JavaScript یک فرآیند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی یک تصویر سیاه‑سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شود:

```js
// یک فایل ارائه را بارگذاری کنید.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // اولین اسلاید را از ارائه دریافت کنید.
    let slide = presentation.getSlides().get_Item(0);

    // تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // اندازه تصویر را تنظیم کنید.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // فرمت پیکسل را تنظیم کنید (سیاه و سفید).
    tiffOptions.setDpiX(300);                                                          // رزولوشن افقی را تنظیم کنید.
    tiffOptions.setDpiY(300);                                                          // رزولوشن عمودی را تنظیم کنید.

    // اسلاید را با گزینه‌های مشخص به تصویر تبدیل کنید.
    let image = slide.getImage(tiffOptions);
    try {
        // تصویر را در قالب TIFF ذخیره کنید.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
پشتیبانی از TIFF در نسخه‌های قبل از JDK 9 تضمین نمی‌شود.
{{% /alert %}} 

## **تبدیل تمام اسلایدها به تصویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصویر تبدیل کنید، به‌طوری که کل ارائه به مجموعه‌ای از تصاویر تبدیل می‌شود.

این کد نمونه نشان می‌دهد چگونه تمام اسلایدهای یک ارائه را در JavaScript به تصویر تبدیل کنید:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // ارائه را اسلاید به اسلاید به تصویر رندر کنید.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // اسلایدهای مخفی را کنترل کنید (اسلایدهای مخفی رندر نشوند).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // اسلاید را به تصویر تبدیل کنید.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // تصویر را در قالب JPEG ذخیره کنید.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا Aspose.Slides از رندر اسلایدها با انیمیشن پشتیبانی می‌کند؟**

خیر، متد `getImage` تنها یک تصویر ثابت از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای معمولی پردازش شوند. فقط مطمئن شوید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides هنگام ذخیره اسلایدها به عنوان تصویر از رندر سایه‌ها، شفافیت و سایر افکت‌های گرافیکی پشتیبانی می‌کند.