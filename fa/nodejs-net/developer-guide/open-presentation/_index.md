---
title: باز کردن ارائه‌ها در Node.js از طریق .NET
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/nodejs-net/open-presentation/
keywords:
- باز کردن ارائه
- باز کردن PowerPoint
- باز کردن PPTX
- باز کردن PPT
- باز کردن ODP
- بارگذاری ارائه
- ارائه از Buffer
- تعداد اسلاید
- تبدیل ارائه
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ارائه‌های PPTX، PPT و ODP را در JavaScript با Aspose.Slides برای Node.js از طریق .NET باز کنید: از مسیر فایل یا Buffer بارگذاری کنید، تعداد اسلایدها را بخوانید و در قالب دیگری ذخیره کنید."
---
## **بررسی کلی**

Aspose.Slides for Node.js via .NET فایل‌های ارائه PowerPoint و OpenDocument مانند PPTX، PPT و ODP را از مسیر فایل یا از یک `Buffer` در Node.js باز می‌کند. این مقاله هر دو روش را نشان می‌دهد، تعداد اسلایدها را می‌خواند و ارائه باز شده را در قالب دیگری ذخیره می‌کند.

مثال‌ها انتظار دارند که پرونده ارائه‌ای به نام `sample.pptx` در پوشه پروژه‌ای که در [نصب](/slides/fa/nodejs-net/installation/) تنظیم کرده‌اید موجود باشد. هر ارائه PowerPoint‌ای کار می‌کند. هر مثال را به صورت یک فایل `.js` در پوشه پروژه ذخیره کنید و با `node` از همان پوشه اجرا کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET مرجع API اختصاصی خود را ندارد. این کتابخانه API Aspose.Slides برای .NET را با نام‌های camelCase بازتاب می‌دهد، بنابراین پیوندهای API در این مقاله به کلاس‌ها و اعضای متناظر در [مرجع API Aspose.Slides برای .NET](https://reference.aspose.com/slides/net/) منتهی می‌شوند.
{{% /alert %}}

## **باز کردن یک ارائه از فایل**

برای باز کردن یک ارائه، مسیر آن را به سازنده [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) پاس دهید. Aspose.Slides قالب را بر اساس محتوای فایل نه پسوند شناسایی می‌کند، بنابراین همان کد فایل‌های PPTX، PPT و ODP را باز می‌کند. مسیر نسبی نسبت به پوشه کاری فعلی که هنگام اجرای اسکریپت همان پوشه پروژه است، حل می‌شود.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

اسکریپت تعداد اسلایدهای موجود در `sample.pptx` را چاپ می‌کند، برای مثال `Slide count: 9`. خصوصیت `count` در مجموعه‌ی [اسلایدها](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) شامل اسلایدهای مخفی نیز می‌شود. همان‌طور که نشان داده شده، `dispose` را در یک بلوک `finally` صدا بزنید تا منابع .NET پشت ارائه حتی در صورت بروز خطا آزاد شوند.

## **باز کردن یک ارائه از Buffer**

زمانی که ارائه از یک پایگاه داده، آپلود HTTP یا منبع دیگری که بایت‌ها را می‌دهد می‌آید، یک `Buffer` در Node.js را به عنوان آرگومان دوم سازنده پاس دهید و آرگومان اول را `null` قرار دهید. مثال زیر `sample.pptx` را به یک buffer می‌خواند تا به عنوان چنین منبعی عمل کند:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

اسکریپت همان تعداد اسلاید را مانند مثال قبلی چاپ می‌کند. آرگومان دوم باید یک `Buffer` باشد. برای هر نوع دیگر، مانند `Uint8Array`، سازنده خطایی نمی‌دهد؛ به جای آن یک ارائه جدید با یک اسلاید خالی ایجاد می‌کند. ابتدا انواع باینری دیگر را با `Buffer.from` تبدیل کنید.

## **ذخیره یک ارائه در قالب دیگر**

برای تبدیل یک ارائه به قالب ارائه دیگری، آن را باز کنید و با مقدار متفاوتی از [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) ذخیره کنید. مثال زیر قالبی را که Aspose.Slides تشخیص داده است (خاصیت [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/)) چاپ می‌کند و ارائه را به‌صورت یک ارائه OpenDocument ذخیره می‌نماید:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

اسکریپت `Source format: Pptx` را چاپ می‌کند و فایلی به نام `sample.odp` می‌نویسد که حاوی همان اسلایدهاست. `sourceFormat` می‌تواند `Ppt`، `Pptx` یا `Odp` برگرداند. برای ذخیره به‌صورت PDF یا به‌صورت تصویر، به [Convert PowerPoint to PDF](/slides/fa/nodejs-net/convert-powerpoint-to-pdf/) و [Convert Slides to Images](/slides/fa/nodejs-net/convert-slide/) مراجعه کنید.

## **FAQ**

**چگونه یک ارائه محافظت شده با رمز عبور را باز کنم؟**

یک شیء [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) ایجاد کنید، خصوصیت [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) آن را تنظیم کنید و شی را به عنوان آرگومان سوم سازنده پاس دهید: `new Presentation("protected.pptx", null, loadOptions)`. بدون رمز عبور صحیح، سازنده خطای `Error` می‌اندازد.

**چرا سازنده یک `Error` با پیام خالی پرتاب می‌کند؟**

زمانی که سازنده `Presentation` در .NET شکست می‌خورد، برای مثال به دلیل عدم وجود فایل، عدم صحت ارائه یا نیاز به رمز عبور متفاوت، جاوااسکریپت یک `Error` دریافت می‌کند که پیام آن خالی است. پیش از باز کردن یک فایل، وجود آن نسبت به پوشه کاری را بررسی کنید، برای مثال با `fs.existsSync`.

**کدام قالب‌ها را می‌توانم باز کنم؟**

قالب‌های ارائه PowerPoint و OpenDocument شامل PPT، PPTX، PPS، POT، POTX، PPTM، ODP، OTP و FODP.