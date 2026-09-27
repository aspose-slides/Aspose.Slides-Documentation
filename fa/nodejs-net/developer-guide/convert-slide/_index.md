---
title: تبدیل اسلایدهای ارائه به تصویر در Node.js از طریق .NET
linktitle: اسلاید به تصویر
type: docs
weight: 40
url: /fa/nodejs-net/convert-slide/
keywords:
- تبدیل اسلاید
- اسلاید به تصویر
- اسلاید به PNG
- ذخیره اسلاید به عنوان تصویر
- رندر اسلاید
- تصویر بندانگشتی اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "اسلایدهای ارائه‌های PPTX، PPT و ODP را به‌عنوان تصویر PNG در جاوااسکریپت با Aspose.Slides برای Node.js از طریق .NET رندر می‌کند، با ضریب مقیاس یا با اندازه دقیق بر حسب پیکسل."
---
## **بررسی کلی**

Aspose.Slides برای Node.js از طریق .NET اسلایدها را از ارائه‌های PowerPoint و OpenDocument به‌صورت تصویر رندر می‌کند، برای مثال برای نمایش پیش‌نمایش اسلایدها در یک صفحه وب. این مقاله دو روش انتخاب اندازه تصویر را نشان می‌دهد: یک ضریب مقیاس نسبت به اندازه اسلاید، و یک اندازه دقیق بر حسب پیکسل. هر دو مثال فایل‌های PNG را ذخیره می‌کنند.

مثال‌ها انتظار یک ارائه به نام `sample.pptx` در پوشه پروژه که در [نصب](/slides/fa/nodejs-net/installation/) تنظیم کرده‌اید، را دارند. هر ارائه PowerPoint ای قابل استفاده است. هر مثال را به عنوان یک فایل `.js` در پوشه پروژه ذخیره کنید و آن را از همان پوشه با `node` اجرا کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای Node.js از طریق .NET مرجع API خاص خود را ندارد. این کتابخانه API Aspose.Slides برای .NET را با نام‌های camelCase بازتاب می‌دهد، بنابراین پیوندهای API در این مقاله به کلاس‌ها و اعضای متناظر در [مرجع API Aspose.Slides برای .NET](https://reference.aspose.com/slides/fa/net/) هدایت می‌شوند.
{{% /alert %}}

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. ارائه را با سازنده [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/presentation/) باز کنید.
1. یک اسلاید را از مجموعه [slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) با استفاده از `get(index)` دریافت کنید. ایندکس‌ها از ۰ شروع می‌شوند.
1. اسلاید را با `getImageWithScale` یا `getImageWithImageSize` رندر کنید. در مرجع API .NET، هر دو نسخه‌ای از [Slide.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage/) هستند. آن‌ها یک شیء تصویر را برمی‌گردانند که به [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) مربوط است.
1. تصویر را با متد [save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/save/) و مقدار [ImageFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/) ذخیره کنید، سپس متد `dispose` آن را فراخوانی کنید.

## **تبدیل هر اسلاید به تصویر PNG**

`getImageWithScale` یک ضریب مقیاس افقی و عمودی می‌گیرد. در مقیاس ۱، یک نقطه از اسلاید به یک پیکسل از تصویر تبدیل می‌شود. مثال زیر هر اسلاید را با مقیاس ۲ رندر می‌کند:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// مقیاس ۱ یک پیکسل را برای هر نقطه رندر می‌کند؛ ۲ عرض و ارتفاع را دو برابر می‌کند.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

این اسکریپت برای هر اسلاید یک فایل می‌نویسد، `slide_1.png`، `slide_2.png` و به‌ همین ترتیب، به‌صورت عددی از ۱ شروع می‌شود. برای یک ارائه 16:9 با اسلایدهای 960 × 540 نقطه، هر تصویر 1920 × 1080 پیکسل است. اسلایدهای مخفی نیز رندر می‌شوند؛ برای صرف‌نظر کردن از آن‌ها، ویژگی [hidden](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/hidden/) اسلاید را بررسی کنید. هر تصویر در بلوک `finally` خودش آزاد (dispose) می‌شود، که قبل از رندر اسلاید بعدی آن را آزاد می‌کند. بدون لایسنس، تصاویر همچنین نشانگر آب‌نشان ارزیابی دارند؛ برای جزئیات به [Licensing](/slides/fa/nodejs-net/licensing/) مراجعه کنید.

## **تبدیل یک اسلاید به تصویر با اندازه مشخص**

`getImageWithImageSize` یک شیء با `width` و `height` بر حسب پیکسل می‌گیرد. مثال زیر اسلاید اول را با عرض 1280 پیکسل رندر می‌کند و ارتفاع را از اندازه اسلاید محاسبه می‌کند، به‌طوری که تصویر نسبت ابعاد اسلاید را حفظ کند:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

خاصیت [slideSize.size](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesize/size/) عرض و ارتفاع اسلاید را بر حسب نقطه برمی‌گرداند. برای یک ارائه 16:9، اسکریپت `Saved a 1280 x 720 image` را چاپ می‌کند و `slide_1_1280px.png` را می‌نویسد؛ برای یک ارائه 4:3، تصویر 1280 × 960 پیکسل است.

## **سؤالات متداول**

**چرا تصویر حاصل از `getImage` بدون آرگومان‌ها این‌چقدر کوچک است؟**

بدون آرگومان، `getImage` اسلاید را در ۲۰٪ از اندازه آن بر حسب نقطه رندر می‌کند، بنابراین یک اسلاید 960 × 540 نقطه به تصویر 192 × 108 پیکسل تبدیل می‌شود. برای انتخاب اندازه از `getImageWithScale` یا `getImageWithImageSize` استفاده کنید.

**چگونه JPEG یا فرمت‌های تصویر دیگر را ذخیره کنم؟**

مقدار دیگری از `ImageFormat` را به متد `save` تصویر بدهید، برای مثال `image.save("slide_1.jpg", ImageFormat.Jpeg)`. فرمت از مقدار `ImageFormat` می‌آید، نه از پسوند فایل، بنابراین دو مورد را هماهنگ نگه دارید.

**چرا متن در تصاویر روی لینوکس متفاوت به نظر می‌رسد؟**

Aspose.Slides تنها می‌تواند از فونت‌های نصب شده بر روی دستگاهی که اسלایدها را رندر می‌کند، استفاده کند. زمانی که یک ارائه از فونتی استفاده می‌کند که موجود نیست، مانند Calibri بر روی یک سرور لینوکس معمولی، Aspose.Slides به جای آن از یک فونت نصب شده دیگر استفاده می‌کند که ممکن است ظاهر متن و نقطه شکست خطوط را تغییر دهد. فونت‌هایی که ارائه‌های شما استفاده می‌کنند را نصب کنید تا همان تصاویر را همانند ویندوز دریافت کنید.

**چرا `getThumbnailWithImageSize` با TypeError شکست می‌خورد؟**

README بسته از `getThumbnailWithImageSize` استفاده می‌کند، اما بسته هیچ متدی با نام `getThumbnail` ندارد. به جای آن از `getImageWithImageSize` استفاده کنید؛ این متد همان آرگومان `{ width, height }` را می‌گیرد.