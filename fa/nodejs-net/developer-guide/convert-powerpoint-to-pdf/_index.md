---
title: تبدیل PowerPoint به PDF در Node.js از طریق .NET
linktitle: PowerPoint به PDF
type: docs
weight: 30
url: /fa/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint به PDF
- تبدیل PowerPoint به PDF
- PPTX به PDF
- PPT به PDF
- ODP به PDF
- ذخیره ارائه به صورت PDF
- PDF/A
- PdfOptions
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل ارائه‌های PPTX، PPT و ODP به PDF در JavaScript با Aspose.Slides برای Node.js از طریق .NET و ایجاد فایل‌های PDF/A بایگانی با PdfOptions."
---
## **نمای کلی**

Aspose.Slides for Node.js via .NET ارائه‌های PowerPoint و OpenDocument را بدون نیاز به Microsoft PowerPoint به PDF تبدیل می‌کند. هر اسلاید قابل مشاهده به یک صفحه PDF با همان اندازه اسلاید تبدیل می‌شود و متن به شکل قابل انتخاب و جستجو باقی می‌ماند. این مقاله تبدیل پیش‌فرض و تبدیل به PDF/A را با استفاده از [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) نشان می‌دهد.

مثال‌ها انتظار دارند ارائه‌ای به نام `sample.pptx` در پوشه پروژه وجود داشته باشد که در [Installation](/slides/fa/nodejs-net/installation/) راه‌اندازی کرده‌اید. هر ارائه PowerPoint‌ای مناسب است. هر مثال را به عنوان یک فایل `.js` در پوشه پروژه ذخیره کنید و آن را با `node` از همان پوشه اجرا کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET سند مرجعی برای خود ندارد. این کتابخانه API Aspose.Slides for .NET را با نام‌های camelCase بازتاب می‌دهد، بنابراین لینک‌های API در این مقاله به کلاس‌ها و اعضای متناظر در [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/fa/net/) هدایت می‌شوند.
{{% /alert %}}

## **Convert a Presentation to PDF**

برای تبدیل یک ارائه به PDF، مراحل زیر را دنبال کنید:

1. ارائه را با پاس دادن مسیر آن به سازنده [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/presentation/) باز کنید. همان کد برای فایل‌های PPTX، PPT و ODP کار می‌کند.
2. متد [save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) را با مسیر خروجی و `SaveFormat.Pdf` فراخوانی کنید.
3. در یک بلوک `finally` متد `dispose` را صدا بزنید تا منابع .NET مربوط به ارائه آزاد شوند.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

اسکریپت `sample.pdf` را در پوشه پروژه می‌نویسد. تبدیل از تنظیمات پیش‌فرض استفاده می‌کند: هر اسلایدی که مخفی نیست به یک صفحه تبدیل می‌شود، به ترتیب اسلایدها. بدون لایسنس، هر صفحه همچنین نشانگر آب‌رنگ ارزیابی را نمایش می‌دهد؛ برای جزئیات به [Licensing](/slides/fa/nodejs-net/licensing/) مراجعه کنید.

## **Convert a Presentation to PDF/A**

برای کنترل خروجی، یک شیء [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) را به عنوان سومین آرگومان متد `save` بگذارید. مثال زیر ویژگی [compliance](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/compliance/) را به `PdfCompliance.PdfA2b` تنظیم می‌کند که فایلی PDF/A-2b تولید می‌کند. PDF/A استاندارد ISO برای بایگانی طولانی‌مدت است: در میان قوانین دیگر، این استاندارد می‌طلبد که هر فونتی که سند استفاده می‌کند در فایل تعبیه شود.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

اسکریپت `sample-pdfa.pdf` را با همان صفحات تبدیل پیش‌فرض می‌نویسد. برای تأیید اینکه یک فایل معیار را برآورده می‌کند، آن را با یک اعتبارسنج PDF/A مانند [veraPDF](https://verapdf.org/) بررسی کنید. مقادیر دیگر [PdfCompliance](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfcompliance/) استانداردهای دیگری مانند `PdfA1b`، `PdfA2a` یا `PdfUa` برای دسترسی‌پذیری را انتخاب می‌کنند.

## **FAQ**

**چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانده کنم؟**

اسلایدهای مخفی به‌صورت پیش‌فرض نادیده گرفته می‌شوند. ویژگی [showHiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/showhiddenslides/) را در `PdfOptions` به `true` تنظیم کنید و گزینه‌ها را به `save` پاس بدهید.

**آیا می‌توانم PDF را با رمز عبور محافظت کنم؟**

بله. قبل از فراخوانی `save`، ویژگی [password](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/password/) را در `PdfOptions` تنظیم کنید. سپس برنامه‌خوان‌های PDF قبل از باز کردن فایل از کاربر رمز عبور می‌خواهند.

**آیا می‌توانم فقط برخی از اسلایدها را تبدیل کنم؟**

بله. یک آرایه از موقعیت‌های اسلاید را به‌عنوان چهارمین آرگومان `save` بگذارید. موقعیت‌ها از 1 شروع می‌شوند و اگر نیازی به گزینه‌ها ندارید می‌توانید آرگومان سوم را `null` بگذارید: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` یک PDF حاوی اسلایدهای اول و سوم ایجاد می‌کند.

**چرا متن هنگام تبدیل در لینوکس متفاوت به نظر می‌رسد؟**

Aspose.Slides تنها می‌تواند از فونت‌هایی استفاده کند که بر روی ماشینی که تبدیل انجام می‌دهد نصب شده‌اند. وقتی یک ارائه از فونتی استفاده می‌کند که موجود نیست، مثلاً Calibri بر روی یک سرور لینوکس معمولی، Aspose.Slides به جای آن از فونتی نصب‌شده دیگر استفاده می‌کند که می‌تواند ظاهر متن و نقطه شکست خطوط را تغییر دهد. برای دریافت همان نتایج همانند ویندوز، فونت‌های مورد استفاده در ارائه‌های خود را نصب کنید.

**آیا می‌توانم PDF را به‌جای فایل به صورت Buffer دریافت کنم؟**

بله. `presentation.saveToBuffer(SaveFormat.Pdf)` PDF را به‌صورت یک شیء `Buffer` در Node.js برمی‌گرداند که هنگام ارسال نتیجه در پاسخ HTTP مفید است. همچنین می‌توانید `PdfOptions` را به‌عنوان دومین آرگومان به آن پاس بدهید.