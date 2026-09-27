---
title: ایجاد ارائه‌ها در Node.js از طریق .NET
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/nodejs-net/create-presentation/
keywords:
  - ایجاد ارائه
  - ارائه جدید
  - ایجاد پاورپوینت
  - ایجاد PPTX
  - افزودن جعبه متن
  - افزودن اسلاید
  - اندازه اسلاید
  - صفحه عریض
  - PowerPoint
  - ارائه
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "ایجاد ارائه‌های پاورپوینت در جاوااسکریپت با Aspose.Slides برای Node.js از طریق .NET: افزودن جعبه متن و اسلایدها، تنظیم اندازه اسلاید 16:9، و ذخیره نتیجه به‌عنوان PPTX."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه یک ارائه با Aspose.Slides برای Node.js از طریق .NET ایجاد کنید، یک جعبهٔ متن به اسلاید اول اضافه کنید و نتیجه را به‌صورت فایل PPTX ذخیره کنید. همچنین نحوه افزودن اسلایدهای بیشتر و تغییر ارائه به اسلایدهای widescreen (16:9) را توضیح می‌دهد.

مثال‌ها نیاز به پروژه‌ای دارند که مطابق بخش [Installation](/slides/fa/nodejs-net/installation/) تنظیم شده باشد. هر مثال را به‌عنوان یک فایل `.js` در پوشهٔ پروژه ذخیره کرده و با `node` از همان پوشه اجرا کنید، برای مثال `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET مرجع API مخصوص خود را ندارد. این کتابخانه مرجع API Aspose.Slides برای .NET را با نام‌های camelCase بازتاب می‌دهد، بنابراین لینک‌های API در این مقاله به کلاس‌ها و اعضای متناظر در [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/fa/net/) ارجاع می‌شود.
{{% /alert %}}

## **ایجاد یک ارائه با جعبه متن**

برای ایجاد یک ارائه و قرار دادن جعبهٔ متن بر روی اسلاید اول، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید. یک ارائهٔ جدید از پیش شامل یک اسلاید خالی است.
1. آن اسلاید را از مجموعهٔ [slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) دریافت کنید. در این بسته مجموعه‌ها با `get(index)` خوانده می‌شوند و ایندکس‌ها از 0 شروع می‌شوند.
1. با متد [addAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/shapecollection/addautoshape/) یک مستطیل اضافه کنید و متن آن را با استفاده از [text](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/text/) در [textFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/textframe/) تنظیم کنید.
1. ارائه را با متد [save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) و مقدار `SaveFormat.Pptx` ذخیره کنید.
1. `dispose` را در یک بلوک `finally` فراخوانی کنید تا منابع .NET مرتبط با ارائه آزاد شوند.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // موقعیت (x, y) و اندازه (عرض، ارتفاع) بر حسب پوینت است.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

این اسکریپت `new-presentation.pptx` را در پوشهٔ پروژه می‌نویسد. فایل شامل یک اسلاید با یک مستطیل پر شده است که گوشهٔ بالای چپ آن 50 پوینت از لبه‌های چپ و بالا فاصله دارد. مستطیل 400 پوینت عرض و 100 پوینت ارتفاع دارد و متن آن به‌صورت مرکز چینش شده است. یک پوینت برابر 1/72 اینچ است. بدون لایسنس، Aspose.Slides همچنین یک واترمارک ارزیابی به اسلاید اضافه می‌کند؛ برای جزئیات به بخش [Licensing](/slides/fa/nodejs-net/licensing/) مراجعه کنید.

## **افزودن اسلایدها**

یک ارائهٔ جدید شامل یک اسلاید است. برای افزودن اسلایدهای بیشتر، یک اسلاید قالب را به متد [addEmptySlide](https://reference.aspose.com/slides/fa/net/aspose.slides/slidecollection/addemptyslide/) از مجموعهٔ `slides` پاس کنید. متد [getByType](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutslidecollection/getbytype/) از مجموعهٔ [layoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/layoutslides/) اولین قالب از نوع داده شده‌ی [SlideLayoutType](https://reference.aspose.com/slides/fa/net/aspose.slides/slidelayouttype/) را برمی‌گرداند.

مثال زیر دو اسلاید با قالب Blank اضافه می‌کند:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اسکریپت `Slide count: 3` را چاپ کرده و `three-slides.pptx` را می‌نویسد. اسلایدهای جدید پس از اولین اسلاید افزوده می‌شوند و هیچ شکل (shape)ی ندارند. یک ارائهٔ جدید همیشه دارای قالب Blank است، اما اگر ارائه‌ای را از فایل باز کنید ممکن است قالب مورد نظر موجود نباشد؛ در این صورت `getByType` مقدار `null` برمی‌گرداند، بنابراین قبل از استفاده نتیجه را بررسی کنید.

## **تنظیم اندازه اسلاید**

یک ارائهٔ جدید از اسلایدهای 4:3 با ابعاد 720 × 540 پوینت (10 × 7.5 اینچ) استفاده می‌کند. برای ایجاد اسلایدهای widescreen به‌جای آن، متد [setSize](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesize/setsize/) از ویژگی [slideSize](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slidesize/) را با مقدار [SlideSizeType](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesizetype/) و [SlideSizeScaleType](https://reference.aspose.com/slides/fa/net/aspose.slides/slidesizescaletype/) صدا بزنید. نوع مقیاس تعیین می‌کند Aspose.Slides چه کاری با اشکالی که از قبل روی اسلایدها هستند انجام دهد؛ `DoNotScale` آن‌ها را به همان حالت فعلی باقی می‌گذارد که برای ارائه‌ای که هنوز محتوا ندارد گزینهٔ مناسب است.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اسکریپت `Slide size: 960 x 540 points` را چاپ می‌کند که برابر 13.33 × 7.5 اینچ است و `widescreen.pptx` را می‌نویسد. `SlideSizeType.OnScreen16x9` همان نسبت تصویر 16:9 را دارد اما کوچکتر است: 720 × 405 پوینت.

## **پرسش‌های متداول**

**واحدهای اندازه‌گیری موقعیت‌ها و ابعاد چیست؟**

در پوینت مقداردهی می‌شود. یک اینچ برابر 72 پوینت است، بنابراین اسلاید پیش‌فرض 4:3 برابر 720 × 540 پوینت و اسلاید widescreen 16:9 برابر 960 × 540 پوینت است.

**کدام فرمت‌ها را می‌توان برای ذخیرهٔ یک ارائهٔ جدید استفاده کرد؟**

هر مقدار از перечисление [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) قابل استفاده است، برای مثال `SaveFormat.Ppt` برای PowerPoint 97–2003، `SaveFormat.Odp` برای OpenDocument یا `SaveFormat.Pdf`. برای خروجی PDF، به بخش [Convert PowerPoint to PDF](/slides/fa/nodejs-net/convert-powerpoint-to-pdf/) مراجعه کنید.

**چرا فایل ارائهٔ ذخیره‌شده متن «Evaluation only» دارد؟**

بدون لایسنس، Aspose.Slides یک واترمارک ارزیابی به اسلایدهای ذخیره‌شده اضافه می‌کند. برای حذف آن، همان‌طور که در بخش [Licensing](/slides/fa/nodejs-net/licensing/) توضیح داده شده است، لایسنس اعمال کنید.

**چرا باید `dispose` را فراخوانی کنم؟**

شیء `Presentation` توسط یک شیء .NET پشتیبانی می‌شود که حافظه و منابع دیگری را در خود نگه می‌دارد. فراخوانی `dispose` این منابع را بلافاصله پس از پایان استفاده از ارائه آزاد می‌کند و انجام این کار در یک بلوک `finally` تضمین می‌کند که حتی در صورت بروز خطا نیز منابع آزاد شوند.