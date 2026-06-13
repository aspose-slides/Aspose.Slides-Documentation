---
title: ذخیره ارائه‌ها در JavaScript
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/nodejs-java/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- Node.js
- JavaScript
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را با استفاده از Aspose.Slides برای Node.js از طریق Java ذخیره کنید—به PowerPoint یا OpenDocument صادر کنید و طرح‌بندی‌ها، قلم‌ها و افکت‌ها را حفظ کنید."
---
## **بررسی کلی**

[Open Presentations in JavaScript](/slides/fa/nodejs-java/open-presentation/) نحوه استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) برای باز کردن یک ارائه را توضیح داد. این مقاله نحوه ساخت و ذخیره‌سازی ارائه‌ها را شرح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) محتویات یک ارائه را در خود دارد. چه برای ساخت یک ارائه از ابتدا و چه برای تغییر یک ارائه موجود، پس از اتمام کار باید آن را ذخیره کنید. با Aspose.Slides برای Node.js می‌توانید به **file** یا **stream** ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را بیان می‌کند.

## **ذخیره ارائه‌ها در فایل‌ها**

با فراخوانی متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) یک ارائه را در فایل ذخیره کنید. نام فایل و فرمت ذخیره را به متد پاس دهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```js
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // در اینجا کاری انجام دهید...

    // ارائه را به یک فایل ذخیره کنید.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در جریان‌ها**

می‌توانید با پاس دادن یک جریان خروجی به متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) یک ارائه را در یک جریان ذخیره کنید. یک ارائه می‌تواند به انواع مختلف جریان‌ها نوشته شود. در مثال زیر یک ارائه جدید ایجاد کرده و آن را در یک جریان فایل ذخیره می‌کنیم.

```js
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // ارائه را به جریان ذخیره کنید.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

Aspose.Slides به شما اجازه می‌دهد نمای اولیه‌ای که PowerPoint هنگام باز شدن ارائه تولیدشده استفاده می‌کند را از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/) تنظیم کنید. از متد [setLastView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#setLastView) با مقداری از شمارش‌گر [ViewType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewtype/) استفاده کنید.

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما اجازه می‌دهد یک ارائه را در قالب Strict Office Open XML ذخیره کنید. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/) استفاده کنید و هنگام ذخیره ویژگی conformance آن را تنظیم کنید. اگر [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد کرده و آن را در قالب Strict Office Open XML ذخیره می‌کند.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
let presentation = new aspose.slides.Presentation();
try {
    // ارائه را در قالب Strict Office Open XML ذخیره کنید.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Office Open XML حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت 4 GB (2^32 بایت) برای اندازهٔ غیرفشرده هر فایل، اندازهٔ فشرده هر فایل و اندازهٔ کل آرشیو اعمال می‌کند و همچنین تعداد فایل‌ها را به 65 535 (2^16‑1) محدود می‌سازد. افزونه‌های فرمت ZIP64 این محدودیت‌ها را به 2^64 افزایش می‌دهند.

متد [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) به شما امکان می‌دهد هنگام ذخیرهٔ یک فایل Office Open XML تصمیم بگیرید که از افزونه‌های فرمت ZIP64 استفاده شود یا نه.

این متد می‌تواند با حالت‌های زیر استفاده شود:

- [IfNecessary](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#IfNecessary) فقط در صورتی که ارائه از محدودیت‌های بالا عبور کند از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#Never) هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- [Always](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#Always) همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به‌صورت PPTX با فعال‌سازی افزونه‌های ZIP64 ذخیره کنید:

```js
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
هنگامی که با [Zip64Mode.Never](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#Never) ذخیره می‌کنید، اگر ارائه نتواند در فرمت ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) تولید تصویر بندانگشتی را هنگام ذخیرهٔ یک ارائه به PPTX کنترل می‌کند:

- اگر به `true` تنظیم شود، تصویر بندانگشتی در زمان ذخیره‌سازی به‌روزرسانی می‌شود. این حالت پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر بندانگشتی فعلی حفظ می‌شود. اگر ارائه تصویر بندانگشتی نداشته باشد، هیچ‌کدام تولید نمی‌شود.

در کد زیر، ارائه بدون به‌روزرسانی تصویر بندانگشتی به PPTX ذخیره می‌شود.

```js
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

## **ذخیره‌گذاری پیشرفت به‌صورت درصد**

گزارش‌گیری پیشرفت ذخیره‌سازی از طریق متد [setProgressCallback](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) بر روی [SaveOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/) و زیرکلاس‌های آن پیکربندی می‌شود. یک پروکسی Java که رابط [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) را پیاده‌سازی می‌کند ارائه کنید؛ در طول استخراج، این بازگشت‌خوان به‌صورت دوره‌ای به‌روزرسانی‌های درصدی دریافت می‌کند.

کدهای زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده کنید.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // از مقدار درصد پیشرفت در اینجا استفاده کنید.
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
Aspose یک برنامهٔ رایگان **PowerPoint Splitter** (https://products.aspose.app/slides/fa/splitter) ساخته است که با API خودش کار می‌کند. این برنامه به شما اجازه می‌دهد یک ارائه را به چندین فایل تقسیم کنید و اسلایدهای انتخاب‌شده را به‌صورت فایل‌های جدید PPTX یا PPT ذخیره کنید.
{{% /alert %}}

## **سؤالات متداول**

**آیا «ذخیره سریع» (ذخیرهٔ افزایشی) پشتیبانی می‌شود تا فقط تغییرات نوشته شوند؟**

نه. ذخیره‌سازی هر بار فایل مقصد کامل را ایجاد می‌کند؛ «ذخیره سریع» افزایشی پشتیبانی نمی‌شود.

**آیا ذخیرهٔ یک شیء Presentation از چندین جریان همزمان ایمن است؟**

نه. یک شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) **thread‑safe** نیست؛ آن را فقط از یک جریان ذخیره کنید.

**هنگام ذخیره‌سازی چه اتفاقی برای هایپرلینک‌ها و فایل‌های لینک‌شده خارجی می‌افتد؟**

[Hyperlinks](/slides/fa/nodejs-java/manage-hyperlinks/) حفظ می‌شوند. فایل‌های لینک‌شده خارجی (مثلاً ویدیوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند—اطمینان حاصل کنید مسیرهای مرجع همچنان قابل دسترسی باشند.

**آیا می‌توان متاداده‌های سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کرد؟**

بله. **document properties** استاندارد (/slides/fa/nodejs-java/presentation-properties/) پشتیبانی می‌شوند و هنگام ذخیره به فایل نوشته خواهند شد.