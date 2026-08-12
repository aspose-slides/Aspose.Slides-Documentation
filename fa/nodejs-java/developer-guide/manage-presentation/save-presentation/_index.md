---
title: ذخیرهٔ ارائه‌ها در JavaScript
linktitle: ذخیرهٔ ارائه
type: docs
weight: 80
url: /fa/nodejs-java/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیرهٔ ارائه
- ذخیرهٔ اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌ شده
- قالب Strict Office Open XML
- حالت Zip64
- تجدید تصویر بند انگشتی
- ذخیره پیشرفت
- Node.js
- JavaScript
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را با استفاده از Aspose.Slides برای Node.js از طریق Java ذخیره کنید—به PowerPoint یا OpenDocument صادر کنید در حالی که چیدمان‌ها، قلم‌ها و افکت‌ها حفظ می‌شوند."
---
## **مروری کلی**

[Open Presentations in JavaScript](/slides/fa/nodejs-java/open-presentation/) توضیح داد که چگونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) برای باز کردن یک ارائه استفاده کنید. این مقاله نحوه ایجاد و ذخیرهٔ ارائه‌ها را شرح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) محتوای یک ارائه را در خود دارد. چه از ابتدا یک ارائه ایجاد کنید و چه یک ارائه موجود را اصلاح کنید، پس از اتمام می‌خواهید آن را ذخیره کنید. با Aspose.Slides برای Node.js می‌توانید به **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیرهٔ یک ارائه را توضیح می‌دهد.

## **ذخیرهٔ ارائه‌ها به فایل‌ها**

یک ارائه را با فراخوانی متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) به یک فایل ذخیره کنید. نام فایل و فرمت ذخیره را به متد پاس بدهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // انجام برخی کارها در اینجا...

    // ذخیرهٔ ارائه به یک فایل.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیرهٔ ارائه‌ها به جریان‌ها**

می‌توانید یک ارائه را به یک جریان ذخیره کنید؛ کافی است یک خروجی جریان را به متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) پاس بدهید. یک ارائه می‌تواند به انواع مختلفی از جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را به یک جریان فایل ذخیره می‌کنیم.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // ذخیرهٔ ارائه به جریان.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **ذخیرهٔ ارائه‌ها با نوع نمایش از پیش تعریف‌شده**

Aspose.Slides به شما امکان می‌دهد نمای اولیه‌ای که PowerPoint هنگام باز شدن ارائهٔ تولید شده استفاده می‌کند، از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/) تنظیم کنید. از متد [setLastView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#setLastView) با یک مقدار از enumeration [ViewType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewtype/) استفاده کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیرهٔ ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما امکان می‌دهد یک ارائه را در قالب Strict Office Open XML ذخیره کنید. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/) استفاده کنید و هنگام ذخیره، ویژگی conformance آن را تنظیم کنید. اگر [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در قالب Strict Office Open XML ذخیره می‌نماید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // ذخیرهٔ ارائه در قالب Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیرهٔ ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ گیگابایت (۲^۳۲ بایت) بر اندازهٔ فشرده‌نشده هر فایل، اندازهٔ فشرده هر فایل و مجموع اندازهٔ آرشیو اعمال می‌کند و همچنین تعداد فایل‌ها را به ۶۵٬۵۳۵ (۲^۱۶‑۱) محدود می‌سازد. افزونه‌های فرمت ZIP64 این محدودیت‌ها را به ۲^۶۴ افزایش می‌دهند.

متد [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) به شما اجازه می‌دهد هنگام ذخیرهٔ یک فایل Office Open XML، زمانی که باید از افزونه‌های فرمت ZIP64 استفاده کنید را انتخاب کنید.

این متد می‌تواند با حالت‌های زیر استفاده شود:

- [IfNecessary](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#IfNecessary) فقط در صورتی که ارائه محدودیت‌های فوق را تجاوز کند، از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#Never) هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- [Always](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#Always) همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نحوهٔ ذخیرهٔ یک ارائه به شکل فایل PPTX با فعال‌سازی افزونه‌های فرمت ZIP64 را نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
هنگامی که با [Zip64Mode.Never](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#Never) ذخیره می‌کنید، اگر نتوان ارائه را در قالب ZIP32 ذخیره کرد، یک [PptxException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیرهٔ ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

هنگام کار با ارائه‌های بزرگ، می‌توانید سطح فشرده‌سازی را تنظیم کنید تا بین اندازهٔ فایل و زمان پردازش تعادل برقرار شود. بسته به نیازهای شما ممکن است پردازش سریع‌تر یا فایل خروجی کوچکتر ترجیح داده شود.

Aspose.Slides متد [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) را فراهم می‌کند که به شما اجازه می‌دهد سطح فشرده‌سازی مورد استفاده هنگام ذخیرهٔ یک ارائه در قالب Office Open XML را مشخص کنید.

سطوح فشرده‌سازی موجود عبارتند از:

- [**None**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#None): هیچ فشرده‌سازی‌ای اعمال نمی‌شود. فایل‌ها همان‌گونه ذخیره می‌شوند.
- [**Level1**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level1): سریع‌ترین فشرده‌سازی با کمترین نسبت فشرده‌سازی.
- [**Level2**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level2): فشرده‌سازی سریع‌تر با نسبت کمی بهتر نسبت به **Level1**.
- [**Level3**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level3): فشرده‌سازی بهتر از **Level2** با تأثیر متوسط بر زمان پردازش.
- [**Level4**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level4): فشرده‌سازی بهتر از **Level3**.
- [**Level5**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level5): فشرده‌سازی بهبود یافته نسبت به **Level4** با زمان پردازش بیشتر.
- [**Level6**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level6): فشرده‌سازی استاندارد که تعادل خوبی بین سرعت پردازش و اندازهٔ فایل ارائه می‌دهد. این **سطح فشرده‌سازی پیش‌فرض** است.
- [**Level7**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level7): فشرده‌سازی بهتر از **Level6** با پردازش کندتر.
- [**Level8**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level8): فشرده‌سازی بهتر از **Level7**.
- [**Level9**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level9): حداکثر فشرده‌سازی. کوچک‌ترین حجم فایل را تولید می‌کند اما طولانی‌ترین زمان پردازش را می‌طلبد.

مثال زیر نشان می‌دهد چگونه یک ارائه را به صورت فایل PPTX *بدون فشرده‌سازی* ذخیره کنید:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

این مثال چگونگی ذخیرهٔ یک ارائه به عنوان فایل PPTX با *حداکثر فشرده‌سازی* را نشان می‌دهد:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **ذخیرهٔ ارائه‌ها بدون تازه‌سازی تصویر بند انگشتی**

متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) کنترل می‌کند که آیا هنگام ذخیرهٔ یک ارائه به PPTX تصویر بند انگشتی تولید شود یا نه:

- اگر به `true` تنظیم شود، تصویر بند انگشتی در هنگام ذخیره تازه‌سازی می‌شود. این حالت پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر بند انگشتی فعلی حفظ می‌شود. اگر ارائه هیچ تصویر بند انگشتی نداشته باشد، تصویری تولید نمی‌شود.

در کد زیر، ارائه بدون تازه‌سازی تصویر بند انگشتی به PPTX ذخیره می‌شود.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
این گزینه به کاهش زمان مورد نیاز برای ذخیرهٔ یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

## **ذخیرهٔ به‌روزرسانی‌های پیشرفت به درصد**

گزارش‌گذاری پیشرفت ذخیره‌سازی از طریق متد [setProgressCallback](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) روی [SaveOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/) و زیرکلاس‌های آن پیکربندی می‌شود. یک پروکسی Java که رابط [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) را پیاده‌سازی می‌کند ارائه دهید؛ در طول خروجی، این callback به‌صورت دوره‌ای به‌روزرسانی‌های درصدی دریافت می‌کند.

کدهای زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده کنید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // از مقدار درصد پیشرفت اینجا استفاده کنید.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose یک برنامهٔ رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید، با ذخیرهٔ اسلایدهای انتخابی به صورت فایل‌های جدید PPTX یا PPT.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا «ذخیره سریع» (ذخیره افزایشی) پشتیبانی می‌شود تا فقط تغییرات نوشته شوند؟**

خیر. هر بار ذخیره‌سازی، فایل هدف کامل ایجاد می‌شود؛ ذخیره‌سازی افزایشی «ذخیره سریع» پشتیبانی نمی‌شود.

**آیا ذخیرهٔ یک شیء Presentation از چندین نخ همزمان ایمن است؟**

خیر. یک شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) **ایمن برای استفاده از چندین نخ نیست**؛ آن را از یک نخ ذخیره کنید.

**هنگام ذخیره‌سازی، چه اتفاقی برای پیوندهای فراگیر و فایل‌های خارجی لینک‌شده می‌افتد؟**

[Hyperlinks](/slides/fa/nodejs-java/manage-hyperlinks/) حفظ می‌شوند. فایل‌های خارجی لینک‌شده (مثلاً ویدئوها با مسیرهای نسبی) به طور خودکار کپی نمی‌شوند؛ اطمینان حاصل کنید مسیرهای ارجاعی در دسترس باقی بمانند.

**آیا می‌توان متادیتاهای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کرد؟**

بله. [ویژگی‌های سند](/slides/fa/nodejs-java/presentation-properties/) استاندارد پشتیبانی می‌شوند و هنگام ذخیره به فایل نوشته می‌شوند.