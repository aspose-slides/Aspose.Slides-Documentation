---
title: تبدیل اسلایدهای ارائه به تصاویر در جاوااسکریپت
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/nodejs-java/convert-slide/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "اسلایدها را از فرمت‌های PPT، PPTX و ODP به تصاویر در جاوااسکریپت با استفاده از Aspose.Slides برای Node.js via Java تبدیل کنید — رندر سریع، با کیفیت بالا و همراه با مثال‌های واضح کد."
---
## **معرفی**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد به راحتی اسلایدهای ارائه PowerPoint و OpenDocument را به فرمت‌های تصویر مختلف از جمله BMP، PNG، JPG (JPEG)، GIF و سایر فرمت‌ها تبدیل کنید.

برای تبدیل اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل مورد نظر را تعریف کنید و اسلایدهایی که می‌خواهید استخراج کنید را با استفاده از یکی از موارد زیر انتخاب کنید:
    - کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/)
    - کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/)
2. تصویر اسلاید را با فراخوانی متد [getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage) تولید کنید.

در Aspose.Slides for Node.js via Java، یک [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) یک کلاس است که به شما امکان کار با تصاویری را می‌دهد که توسط داده‌های پیکسلی تعریف شده‌اند. می‌توانید از این کلاس برای ذخیره‌سازی تصاویر در طیف وسیعی از فرمت‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصاویر به صورت PNG**

می‌توانید اسلاید را به یک شی بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده کنید. به‌طور جایگزین، می‌توانید اسلاید را به بیت‌مپ تبدیل کرده و سپس تصویر را به فرمت JPEG یا هر فرمت دلخواه دیگر ذخیره کنید.

کد JavaScript زیر نشان می‌دهد چگونه اولین اسلاید یک ارائه را به یک شی بیت‌مپ تبدیل کرده و سپس تصویر را به فرمت PNG ذخیره کنید:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // اولین اسلاید ارائه را به یک بیت‌مپ تبدیل کنید.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // تصویر را در فرمت PNG ذخیره کنید.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویر با اندازهٔ خاصی دریافت کنید. با استفاده از یک overload از متد [getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage) می‌توانید اسلاید را به تصویر با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این نمونه کد این کار را نشان می‌دهد:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // اولین اسلاید ارائه را به یک بیت‌مپ با اندازهٔ مشخص تبدیل کنید.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // تصویر را در فرمت JPEG ذخیره کنید.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدهای حاوی یادداشت‌ها و نظرات به تصاویر**

برخی از اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو کلاس—[TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) و [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/)—را فراهم می‌کند که به شما امکان کنترل رندر اسلایدهای ارائه به تصاویر را می‌دهند. هر دو کلاس شامل متد `setSlidesLayoutOptions` هستند که به شما اجازه می‌دهد رندر یادداشت‌ها و نظرات بر روی اسلاید هنگام تبدیل به تصویر را تنظیم کنید.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات در تصویر نهایی مشخص کنید.

کد JavaScript زیر نشان می‌دهد چگونه اسلایدی همراه با یادداشت‌ها و نظرات را تبدیل کنید:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // موقعیت یادداشت‌ها را تنظیم کنید.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // موقعیت نظرات را تنظیم کنید.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // عرض ناحیه نظرات را تنظیم کنید.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // رنگ ناحیه نظرات را تنظیم کنید.

    // گزینه‌های رندر را ایجاد کنید.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // اولین اسلاید ارائه را به تصویر تبدیل کنید.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // تصویر را در فرمت GIF ذخیره کنید.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، متد [setNotesPosition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) نمی‌تواند `BottomFull` (برای مشخص کردن موقعیت یادداشت‌ها) را اعمال کند، زیرا متن یک یادداشت ممکن است بسیار بزرگ باشد و نتواند در اندازهٔ تصویر تعیین‌شده جای بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) کنترل بیشتری بر تصویر TIFF حاصل فراهم می‌آورد، به‌طوری که می‌توانید پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر را مشخص کنید.

این کد JavaScript یک فرآیند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی یک تصویر سیاه‑سفید با وضوح 300 DPI و اندازهٔ 2160 × 2800 استفاده می‌شود:

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
    tiffOptions.setDpiX(300);                                                          // وضوح افقی را تنظیم کنید.
    tiffOptions.setDpiY(300);                                                          // وضوح عمودی را تنظیم کنید.

    // اسلاید را با گزینه‌های مشخص شده به تصویر تبدیل کنید.
    let image = slide.getImage(tiffOptions);
    try {
        // تصویر را در فرمت TIFF ذخیره کنید.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
پشتیبانی از TIFF در نسخه‌های قبلی JDK 9 تضمین نشده است.
{{% /alert %}} 

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید و به‌طور مؤثری کل ارائه را به مجموعه‌ای از تصاویر تبدیل نمایید.

این نمونه کد نشان می‌دهد چگونه تمام اسلایدهای یک ارائه را به تصاویر در JavaScript تبدیل کنید:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // ارائه را به صورت اسلاید به اسلاید به تصاویر تبدیل کنید.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // اسلایدهای مخفی را کنترل کنید (اسلایدهای مخفی رندر نشوند).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // اسلاید را به تصویر تبدیل کنید.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // تصویر را در فرمت JPEG ذخیره کنید.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
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
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، فونت‌های ایموجی مورد استفاده در ارائه باید بر روی سیستمی که تبدیل را انجام می‌دهد نصب و در دسترس باشند. به‌عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به‌صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **سؤالات متداول**

**آیا Aspose.Slides از رندر اسلایدهای دارای انیمیشن پشتیبانی می‌کند؟**

خیر، متد `getImage` فقط یک تصویر ثابت از اسلاید ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا اسلایدهای پنهان می‌توانند به عنوان تصویر صادر شوند؟**

بله، اسلایدهای پنهان می‌توانند همانند اسلایدهای معمولی پردازش شوند. فقط مطمئن شوید که در حلقهٔ پردازش گنجانده شوند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides از رندر سایه‌ها، شفافیت و سایر افکت‌های گرافیکی هنگام ذخیره اسلایدها به عنوان تصویر پشتیبانی می‌کند.