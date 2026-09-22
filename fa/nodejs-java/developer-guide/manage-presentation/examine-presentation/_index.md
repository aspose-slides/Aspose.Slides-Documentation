---
title: بازیابی و به‌روزرسانی اطلاعات ارائه در JavaScript
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
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا در ارائه‌های PowerPoint و OpenDocument را با استفاده از JavaScript برای درک سریع‌تر و بررسی هوشمندانه‌تر محتوا بررسی کنید."
---
## **نمای کلی**

Aspose.Slides می‌تواند فرمت یک ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این برای زمانی که نیاز به دسته‌بندی فایل‌ها، ساخت یک فهرست موجودی یا بررسی خصوصیات قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه دارید، مفید است.

این مقاله بازرسی سبک‌وزن را از طریق [PresentationFactory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/) و [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/) و همچنین به‌روزرسانی‌های هدفمند را از طریق [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/) نشان می‌دهد.

## **بررسی فرمت یک ارائه**

اگر قبلاً یک ارائه بارگذاری شده دارید، برای تشخیص پس از بارگذاری و محدودیت‌های جریانات قدیمی PPT، PPS و POT به [Determine the Original Presentation Format](/slides/fa/nodejs-java/detect-presentation-source-format/) مراجعه کنید.

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) برای بازرسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) استفاده کنید. روش [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/getloadformat/) فرمت شناسایی‌شده را گزارش می‌کند، مانند PPTX، PPT یا ODP.

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

## **ساخت یک فهرست سبک‌وزن از ارائه‌ها**

هنگامی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به یک فهرست فشرده برای اعتبارسنجی، فهرست‌گذاری یا سیستم مدیریت اسناد نیاز داشته باشید. در این حالت، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) برای به‌دست‌آوردن یک شیء [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/) استفاده کنید و سپس [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) را برای خواندن متادیتای سند صدا بزنید. این رویکرد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد نمی‌کند یا نیاز به پیمایش کامل مدل شیء ارائه ندارید.

ویژگی‌های گسترده‌ای که توسط [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/) افشا می‌شوند، مقادیر فهرست زیر را ارائه می‌دهند:

| متد | مقدار موجودی |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getSlides) | تعداد کل اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | تعداد اسلایدهای مخفی. |
| [getNotes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getNotes) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | تعداد کل پاراگراف‌ها، در صورت موجود بودن. |
| [getWords](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getWords) | تعداد کل کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | تعداد کل کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) می‌خواند و یک فهرست فشرده چاپ می‌کند. همچنین [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) را با [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) ترکیب می‌کند تا گروه‌های محتوا مانند فونت‌ها، قالب‌ها و عناوین اسلایدها را نمایش دهد.

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

هر [HeadingPair](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/headingpair/) یک نام گروه را از طریق [HeadingPair.getName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/headingpair/#getName) و تعداد موارد در آن گروه را از طریق [HeadingPair.getCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/headingpair/#getCount) فراهم می‌کند. روش [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) یک آرایه تخت و مرتب برمی‌گرداند، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر HeadingPair را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های فرمت**

ویژگی‌های فهرست که توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) برگردانده می‌شوند، متادیتای موجود در سند منبع را نشان می‌دهند. Aspose.Slides برای این فراخوانی، مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را دوباره محاسبه کند. ویژگی‌های گمشده با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، ویژگی‌های سند را به‌روز نکرده باشد.

- **PPTX:** این فرمت ویژگی‌های سند گسترش‌یافته‌ای برای شمارش اسلاید، یادداشت، اسلاید مخفی، پاراگراف, کلمه و رسانه‌های چندرسانه‌ای، همچنین جفت‌های سرعنوان و عناوین بخش‌ها فراهم می‌کند. در دسترس بودن آن بستگی دارد به این که کدام ویژگی‌ها توسط تولید‌کننده سند نوشته شده باشند.
- **PPT:** این فرمت باینری می‌تواند ویژگی‌های خلاصه‌سند مربوطه را ذخیره کند. اگر ویژگی‌ای موجود نباشد یا توسط تولید‌کننده سند به‌روز نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند و نه محاسبه آن از اسلایدها.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند تعداد صفحه، پاراگراف و کلمه را فراهم می‌کند، اما این مقادیر به همه ویژگی‌های گسترش‌یافته مخصوص PowerPoint映 نمی‌شوند. متادیتای اسلایدهای مخفی، اسلایدهای یادداشت، چندرسانه‌ای، جفت‌های سرعنوان و عناوین بخش ممکن است در دسترس نباشند و ویژگی‌های فهرست ممکن است مقادیر پیش‌فرض را برگردانند. مقدار صفر یا آرایه خالی را به‌عنوان اثبات قطعی عدم وجود محتوا در نظر نگیرید.

برای فهرست‌ها و چک‌های اولیه از روش متادیتای سبک‌وزن استفاده کنید. وقتی نتیجه باید تغییرات در حافظه را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری کرده و مدل شیء زنده آن را بررسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌های برگشت‌داده‌شده توسط [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) همچنین می‌توانند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) تغییر یابند. تغییرات را با [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) اعمال کنید و سپس ارائه متصل را با [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) بنویسید.

تصویر زیر ویژگی‌های سند اصلی را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائه PowerPoint](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر می‌دهد و نتیجه را در یک فایل جدید می‌نویسد:

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

![ویژگی‌های سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، به مقالات زیر مراجعه کنید:

- [Password-Protect Presentations](/slides/fa/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/nodejs-java/write-protected-presentation/)

## **سؤال‌های متداول**

**چگونه می‌توانم بررسی کنم که آیا فونت‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getfontsmanager/) استفاده کنید. برای به‌دست‌آوردن فونت‌های جاسازی‌شده از [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) و برای به‌دست‌آوردن فونت‌های استفاده‌شده توسط ارائه از [FontsManager.getFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getfonts/) فراخوانی کنید. دو نتیجه را مقایسه کنید تا فونت‌های مورد نیاز برای رندر ولی جاگذاری نشده را بیابید.

**چگونه می‌توانم به‌سرعت تشخیص دهم که آیا فایل اسلایدهای مخفی دارد و تعداد آن‌ها چقدر است؟**

زمانی که متادیتای ذخیره‌شده سند کافی باشد، از طریق [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) و [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) را بخوانید. این برای یک فهرست سبک‌وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد، متادیتای ذخیره‌شده ممکن است گمشده یا منسوخ باشد، یا نیاز به تأیید مقادیر زنده داشته باشید؛ در این صورت به جای آن، از طریق [Presentation.getSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslides/) پیمایش کنید و روش [Slide.getHidden](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/gethidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که آیا اندازه و جهت سفارشی اسلاید استفاده شده است و آیا از پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslidesize/) را صدا بزنید. با استفاده از [SlideSize.getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/gettype/)، [SlideSize.getSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/getsize/)، و [SlideSize.getOrientation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/getorientation/) تنظیمات فعلی را با پیش‌تنظیم و ابعاد مورد انتظار مقایسه کنید.

**آیا روش سریعی برای مشاهده این‌که آیا نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/) را پیدا کنید و [ChartData.getDataSourceType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) را صدا بزنید. برای یک کتاب‌کار خارجی، [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) را فراخوانی کنید. نوع منبع داده و مسیر، یک ارجاع خارجی را شناسایی می‌کنند، اما برای تأیید در دسترس بودن هدف، بررسی منبع جداگانه‌ای لازم است.

**چگون می‌توانم اسلایدهای 'حجم‌دار' که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ ویژگی تک‌بعدی برای پیچیدگی وجود ندارد. از طریق [Presentation.getSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslides/) و مجموعه [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getShapes) هر اسلاید پیمایش کنید. از شمارش اشکال و حضور تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای‌ها به‌عنوان سیگنال‌های ارزیابی استفاده کنید و یک رندر یا خروجی نمونه‌برداری را اندازه‌گیری کنید قبل از اینکه اسلاید را به‌عنوان گلوگاه عملکردی تأیید شده در نظر بگیرید.