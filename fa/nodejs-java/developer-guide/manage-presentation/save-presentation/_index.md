---
title: ذخیره ارائه‌ها در جاوا اسکریپت
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
- فرمت Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره
- Node.js
- JavaScript
- Aspose.Slides
description: "ذخیره ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌ها در جاوا اسکریپت با Aspose.Slides و پیکربندی خروجی PPTX و گزارش پیشرفت."
---
## **بررسی کلی**

پس از اینکه یک ارائه ایجاد کردید یا [یک ارائه موجود را باز کنید](/slides/fa/nodejs-java/open-presentation/)، از روش [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) برای نوشتن نتیجه استفاده کنید. Aspose.Slides برای Node.js از طریق Java می‌تواند یک ارائه را به صورت فایل یا جریان در قالب‌های PowerPoint، OpenDocument، PDF و سایر فرمت‌ها ذخیره کند. بخش‌های زیر عملیات ذخیره استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **ذخیره ارائه‌ها به فایل‌ها**

برای ذخیره یک ارائه به فایل، مسیر خروجی و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) را به روش [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) پاس دهید. مقدار فرمت نوع فایلی را که Aspose.Slides ایجاد می‌کند تعیین می‌کند.

مثال زیر یک ارائه ایجاد می‌کند و آن را به عنوان فایل PPTX ذخیره می‌گردد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // محتوای ارائه را اینجا اضافه یا اصلاح کنید.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب اصلی خود**

برای مثال‌های تشخیص فایل و جریان، رفتار ارائه‌های تازه ایجاد شده، و تمایز بین قالب منبع و خروجی، به صفحه [Determine the Original Presentation Format](/slides/fa/nodejs-java/detect-presentation-source-format/) مراجعه کنید.

در یک برنامه پردازش دسته‌ای، قالب ورودی ممکن است از پیش مشخص نباشد. پس از بارگذاری یک فایل، قالب اصلی آن را از روش [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSourceFormat) بخوانید. مقدار [SourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sourceformat/) به‌دست آمده را به [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/#toSaveFormat) پاس دهید تا مقدار [SaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) متناظر به‌دست آید و سپس از [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) برای نوشتن ارائه تغییر یافته استفاده کنید.

مثال کامل زیر هر فایل را در یک پوشه ورودی پردازش می‌کند، عنوان آن را به‌روزرسانی می‌کند و در قالبی که از آن بارگذاری شده است به پوشه خروجی ذخیره می‌گردد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/#toSaveFormat) فرمت‌های PPT، PPTX، ODP، PPTM، PPSX، PPSM، POTX، POTM، PPS، POT، OTP، FODP و XML PowerPoint را به فرمت‌های ذخیره‌سازی متناظرشان نگاشت می‌کند. این متد فقط فرمت‌های منبع ارائه را نگاشت می‌کند؛ برای انتخاب فرم‌های خروجی مانند PDF، HTML، TIFF یا تصاویر هدف‌گذاری نشده است. ارسال مقدار [SourceFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sourceformat/) نامعتبر یا پشتیبانی‌نشده منجر به خطا می‌شود.

فایل‌های قدیمی PPT، PPS و POT از همان کانتینر باینری استفاده می‌کنند. وقتی چنین ارائه‌ای بدون پسوند فایل از یک جریان بارگذاری شود، ممکن است یک فایل PPS یا POT به‌عنوان PPT شناسایی شود. اگر حفظ این زیرنوع‌های قدیمی ضرورت دارد، نام فایل یا فرمت متادیتای اصلی را به‌صورت جداگانه نگه دارید و هنگام انتخاب نام و فرمت فایل خروجی از آن استفاده کنید.

## **ذخیره ارائه‌ها در جریان‌ها**

برای نوشتن یک ارائه بدون نیاز به مسیر نهایی فایل، یک جریان قابل نوشتن و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) را به روش [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) پاس دهید. این روش زمانی مفید است که خروجی باید از یک سرویس وب برگردانده شود، در پایگاه داده ذخیره شود یا در حافظه پردازش گردد.

مثال زیر یک ارائه جدید را به یک جریان فایل ذخیره می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

می‌توانید نمایی را که PowerPoint هنگام باز کردن یک ارائه ذخیره‌شده به‌طور پیش‌فرض نمایش می‌دهد، مشخص کنید. قبل از ذخیره از روش [ViewProperties.setLastView](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/#setLastView) همراه با یک مقدار [ViewType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewtype/) استفاده کنید.

مثال زیر نمای Slide Master را به‌عنوان نمای اولیه تنظیم می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

برای ایجاد یک فایل PPTX که با پروفایل Strict بسته Office Open XML سازگار باشد، یک نمونه [PptxOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/) ایجاد کنید و از روش [setConformance](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/#setConformance) با مقدار [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) استفاده کنید. سپس گزینه‌ها را به روش [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) پاس دهید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک آرشیو ZIP استاندارد اندازه فشرده‌شده و غیر فشرده‌شده هر ورودی، مجموع اندازه آرشیو و تعداد ورودی‌ها را محدود می‌کند. چون یک فایل PPTX در واقع یک آرشیو ZIP است، یک ارائه بسیار بزرگ می‌تواند این محدودیت‌ها را پشت سر بگذارد. افزونه‌های ZIP64 محدودیت‌های مربوط به اندازه و تعداد ورودی را افزایش می‌دهند.

از روش [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) برای کنترل نوشتن افزونه‌های ZIP64 استفاده کنید:

- [IfNecessary](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#IfNecessary) فقط زمانی که ارائه از محدودیت‌های استاندارد ZIP فراتر رود، از ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#Never) افزونه‌های ZIP64 را غیرفعال می‌کند.
- [Always](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#Always) همیشه افزونه‌های ZIP64 را می‌نویسد.

مثال زیر همیشه برای ارائه خروجی افزونه‌های ZIP64 را فعال می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
اگر [Zip64Mode.Never](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zip64mode/#Never) استفاده شود و ارائه نتواند در محدودیت‌های استاندارد ZIP جا بگیرد، عملیات ذخیره یک [PptxException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxexception/) را می‌اندازد.
{{% /alert %}}

## **ذخیره ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

برای خروجی PPTX می‌توانید با استفاده از روش [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) سرعت ذخیره را در برابر حجم فایل متعادل کنید. کلاس [CompressionLevel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/) این مقادیر را ارائه می‌دهد:

- [None](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#None) داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- [Level1](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level1) سریع‌ترین فشرده‌سازی و بزرگ‌ترین خروجی را فراهم می‌کند.
- [Level2](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level2) تا [Level5](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level5) به‌صورت تدریجی خروجی کوچکتر را نسبت به سرعت ذخیره ترجیح می‌دهد.
- [Level6](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level6) سرعت ذخیره و حجم فایل را متعادل می‌کند. این سطح پیش‌فرض است.
- [Level7](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level8) بیشتر بر خروجی کوچکتر نسبت به سرعت ذخیره تأکید می‌کنند.
- [Level9](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compressionlevel/#Level9) قوی‌ترین فشرده‌سازی را ارائه می‌دهد و بیشترین زمان پردازش را می‌طلبد.

مثال زیر یک ارائه را بدون فشرده‌سازی ذخیره می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

مثال زیر از حداکثر سطح فشرده‌سازی استفاده می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

هنگامی که یک ارائه به‌صورت PPTX ذخیره می‌شود، روش [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) کنترل‌کننده تصویر بندانگشتی سند است:

- `true` در حین عملیات ذخیره تصویر بندانگشتی را دوباره می‌سازد. این مقدار پیش‌فرض است.
- `false` تصویر بندانگشتی موجود را حفظ می‌کند. اگر ارائه تصویر بندانگشتی نداشته باشد، Aspose.Slides هیچ‌کدام تولید نمی‌کند.

مثال زیر یک ارائه را بدون به‌روزرسانی تصویر بندانگشتی ذخیره می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
غیرفعال‌سازی به‌روزرسانی تصویر بندانگشتی می‌تواند زمان مورد نیاز برای ذخیره یک فایل PPTX را کاهش دهد.
{{% /alert %}}

## **به‌روزرسانی پیشرفت ذخیره به درصد**

برای نظارت بر عملیات ذخیره، رابط [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) را با یک پراکسی Java پیاده‌سازی کنید و پیاده‌سازی را به روش [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) پاس دهید. سپس Aspose.Slides متد [IProgressCallback.reporting](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/#reporting-double-) را با مقادیر پیشرفت در طول خروجی فراخوانی می‌کند.

مثال زیر پیشرفت خروجی PDF را در کنسول گزارش می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose یک [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) رایگان ارائه می‌دهد که با API Aspose.Slides ساخته شده است. این ابزار اسلایدهای انتخاب‌شده را از یک ارائه به صورت فایل‌های PPT یا PPTX جداگانه ذخیره می‌کند.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا Aspose.Slides از ذخیره افزایشی یا «ذخیره سریع» پشتیبانی می‌کند؟**

خیر. هر عملیات ذخیره یک فایل خروجی کامل می‌نویسد و فقط بخش‌های تغییر یافته را به‌روزرسانی نمی‌کند.

**آیا چندین نخ می‌توانند همان نمونه Presentation را ذخیره کنند؟**

خیر. یک نمونه [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) [ایمن برای چندنخی نیست](/slides/fa/nodejs-java/multithreading/). هر نمونه باید فقط توسط یک نخ در هر زمان دسترسی پیدا کرده و ذخیره شود.

**چه اتفاقی برای لینک‌های فراملی و فایل‌های لینک‌خورده خارجی می‌افتد وقتی یک ارائه را ذخیره می‌کنم؟**

[لینک‌های فراملی](/slides/fa/nodejs-java/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های لینک‌خورده خارجی را کپی نمی‌کند، بنابراین ارائه ذخیره‌شده باید همچنان به مکان‌های آن‌ها دسترسی داشته باشد.

**آیا می‌توانم متاداده‌های سند مانند نویسنده، عنوان، شرکت و تاریخ ایجاد را ذخیره کنم؟**

بله. قبل از ذخیره، ویژگی‌های مناسب [document properties](/slides/fa/nodejs-java/presentation-properties/) را تنظیم کنید و Aspose.Slides آن‌ها را در فایل خروجی می‌نویسد.