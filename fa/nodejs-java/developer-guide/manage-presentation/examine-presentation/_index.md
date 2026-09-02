---
title: دریافت و به‌روزرسانی اطلاعات ارائه در جاوااسکریپت
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/nodejs-java/examine-presentation/
keywords:
- فرمت ارائه
- ویژگی‌های ارائه
- ویژگی‌های سند
- دریافت ویژگی‌ها
- خواندن ویژگی‌ها
- تغییر ویژگی‌ها
- اصلاح ویژگی‌ها
- به‌روزرسانی ویژگی‌ها
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- پاورپوینت
- سند باز
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های پاورپوینت و سند باز با استفاده از جاوااسکریپت بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندانه‌تری داشته باشید."
---
## **مرور کلی**

Aspose.Slides می‌تواند فرمت یک ارائه را شناسایی کرده و متاداده‌های سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این کار زمانی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت فهرست یا بررسی ویژگی‌ها قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه داشته باشید.

این مقاله بازرسی سبک وزن را از طریق [PresentationFactory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/) و [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/) نشان می‌دهد و همچنین به‌روزرسانی‌های هدفمند را از طریق [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/) توضیح می‌دهد.

## **بررسی فرمت ارائه**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) برای بازرسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) استفاده کنید. متد [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/getloadformat/) قالب شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **ساخت فهرست سبک وزن ارائه**

زمانی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به یک فهرست فشرده برای اعتبارسنجی، فهرست‌گذاری یا سامانه مدیریت اسناد نیاز داشته باشید. در این سناریو، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) برای دریافت یک شیء [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/) استفاده کنید و سپس متد [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) را برای خواندن متاداده‌های سند فراخوانی کنید. این رویکرد هیچ نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه ندارید.

ویژگی‌های گسترش‌‌یافته‌ای که توسط [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/) ارائه می‌شود، مقادیر فهرست زیر را فراهم می‌کند:

| متد | مقدار فهرست |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getSlides) | کل تعداد اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | تعداد اسلایدهای مخفی. |
| [getNotes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getNotes) | تعداد اسلایدهایی که شامل یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | کل تعداد پاراگراف‌ها، در صورت موجود بودن. |
| [getWords](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getWords) | کل تعداد کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | کل تعداد کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) می‌خواند و یک فهرست فشرده را چاپ می‌کند. همچنین با ترکیب [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) و [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) گروه‌های محتوایی مانند قلم‌ها، تم‌ها و عناوین اسلایدها را نمایش می‌دهد.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

هر [HeadingPair](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/headingpair/) یک نام گروه را از طریق [HeadingPair.getName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/headingpair/#getName) و تعداد آیتم‌های آن گروه را از طریق [HeadingPair.getCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/headingpair/#getCount) ارائه می‌دهد. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) یک آرایه صاف و مرتب برمی‌گرداند، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر HeadingPair را مصرف کنید.

### **متاداده‌های ذخیره‌شده و محدودیت‌های فرمت**

ویژگی‌های فهرست‌دیده‌شده که توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) برگردانده می‌شوند، متاداده‌های موجود در سند منبع را نشان می‌دهند. Aspose.Slides این مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را برای این فراخوانی مجدداً محاسبه کند. ویژگی‌های گمشده با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منقضی شوند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده بود، ویژگی‌های سند را به‌روز نکرده باشد.

- **PPTX:** این فرمت ویژگی‌های مستند گسترش‌یافته برای تعداد اسلاید، یادداشت، اسلاید مخفی، پاراگراف، کلمه و چندرسانه‌ای، همچنین جفت‌های سرعنوان و عناوین بخش‌ها را فراهم می‌آورد. در دسترس بودن آن‌ها به این بستگی دارد که تولیدکننده سند چه ویژگی‌هایی را نوشته است.
- **PPT:** فرمت باینری می‌تواند ویژگی‌های خلاصه‑سند متناظر را ذخیره کند. اگر ویژگی‌ایAbsent باشد یا توسط تولیدکننده سند به‌روز نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند نه این‌که آن را از اسلایدها محاسبه کند.
- **ODP:** متاداده‌های OpenDocument آمار کلی سند مانند تعداد صفحه، پاراگراف و کلمه را فراهم می‌کند، اما این مقادیر با هر ویژگی گسترش‌یافته خاص PowerPoint تطابق ندارند. متاداده‌های اسلاید مخفی، اسلاید یادداشت، چندرسانه‌ای، جفت سرعنوان و عناوین بخش ممکن است در دسترس نباشند و ویژگی‌های فهرست ممکن است مقادیر پیش‌فرض برگردانند. صفر بودن مقدار یا آرایه‌ی خالی را به‌عنوان اثبات قطعی عدم وجود محتوا در نظر نگیرید.

از روش متاداده سبک وزن برای فهرست‌ها و بررسی‌های اولیه استفاده کنید. زمانی که نتیجه باید تغییرات در حافظه را بازتاب دهد یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری کرده و مدل شیء زنده آن را بازرسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌های بازگردانده‌شده توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) می‌توانند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) نیز تغییر کنند. تغییرات را با [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) اعمال کنید و سپس ارائه بایند شده را با [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائه پاورپوینت را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائه پاورپوینت](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر داده و نتیجه را در فایلی جدید می‌نویسد:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

تصویر زیر ویژگی‌های سند تغییر یافته ارائه پاورپوینت را نمایش می‌دهد.

![ویژگی‌های سند تغییر یافته ارائه پاورپوینت](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، مقالات زیر را ببینید:

- [حفاظت با رمز عبور از ارائه‌ها](/slides/fa/nodejs-java/password-protected-presentation/)
- [حفاظت نوشتاری از ارائه‌ها](/slides/fa/nodejs-java/write-protected-presentation/)

## **سؤالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getfontsmanager/) استفاده کنید. برای به‌دست آوردن قلم‌های جاسازی‌شده متد [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) را صدا بزنید و برای به‌دست آوردن قلم‌های مورد استفاده در ارائه متد [FontsManager.getFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getfonts/) را فراخوانی کنید. دو نتیجه را مقایسه کنید تا قلم‌هایی که برای رندر لازم هستند اما جاسازی نشده‌اند پیدا کنید.

**چگونه می‌توانم به‌سرعت تشخیص دهم فایل اسلایدهای مخفی دارد و چند تا؟**

هنگامی که متاداده‌های ذخیره‌شده سند کافی باشند، از [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) از طریق [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) و [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) استفاده کنید. این روش برای فهرست سبک وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد، ممکن است متاداده‌های ذخیره‌شده مفقود یا منقضی شده باشند یا نیاز به تأیید مقادیر زنده داشته باشید؛ در این صورت از [Presentation.getSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslides/) پیمایش کنید و برای هر اسلاید متد [Slide.getHidden](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/gethidden/) را بررسی کنید.

**آیا می‌توانم تشخیص دهم اندازه و جهت سفارشی اسلاید استفاده شده است و آیا از پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و متد [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslidesize/) را صدا بزنید. از [SlideSize.getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/gettype/)، [SlideSize.getSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/getsize/) و [SlideSize.getOrientation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/getorientation/) برای مقایسه تنظیمات جاری با پیش‌تنظیمات و ابعاد مورد انتظار استفاده کنید.

**آیا راه سریعی برای دیدن این که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/) را پیدا کنید و متد [ChartData.getDataSourceType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) را فراخوانی کنید. برای یک کتاب‌کار خارجی، متد [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) را صدا بزنید. نوع منبع داده و مسیر، یک ارجاع خارجی را شناسایی می‌کند، اما تأیید در دسترس بودن هدف نیاز به بررسی منبع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ ویژگی تک‌آهنگی برای پیچیدگی وجود ندارد. از [Presentation.getSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslides/) و از مجموعه [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getShapes) هر اسلاید پیمایش کنید. از شمارش شکل‌ها و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای به‌عنوان سیگنال‌های غربالگری استفاده کنید و قبل از تصمیم‌گیری قطعی دربارهٔ یک اسلاید به‌عنوان گلوگاه عملکرد، یک رندر نماینده یا خروجی را اندازه‌گیری کنید.