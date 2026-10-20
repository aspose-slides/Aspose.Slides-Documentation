---
title: تبدیل PPT و PPTX به PDF در JavaScript [ویژگی‌های پیشرفته گنجانده شده]
linktitle: پاورپوینت به PDF
type: docs
weight: 40
url: /fa/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- پاورپوینت به PDF
- ارائه به PDF
- PPT به PDF
- تبدیل PPT به PDF
- PPTX به PDF
- تبدیل PPTX به PDF
- ذخیره پاورپوینت به عنوان PDF
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- صادر کردن PPT به PDF
- صادر کردن PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "پاورپوینت PPT/PPTX را به PDFهای با کیفیت بالا و قابل جستجو با استفاده از Aspose.Slides برای Node.js تبدیل کنید، همراه با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های پاورپوینت و OpenDocument (PPT، PPTX، ODP و غیره) به قالب PDF در JavaScript مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید، و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل‌های پاورپوینت به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [کلاس Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) پاس دهید و سپس با استفاده از متد [ذخیره](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) ارائه را به PDF ذخیره کنید. کلاس [کلاس Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) متد [ذخیره](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای Node.js از طریق Java اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان تبدیل را می‌دهد:

* کل ارائه‌ها به PDF
* اسلایدهای خاصی از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و تضمین می‌کند PDF‌های حاصل به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پاورقی‌ها
* نقطه‌گذاری‌ها
* جدول‌ها

## **تبدیل پاورپوینت به PDF**

فرآیند استاندارد تبدیل پاورپوینت به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را به PDF تبدیل کند با استفاده از تنظیمات بهینه در بالاترین سطوح کیفیت.

مثال زیر یک ارائه را بارگیری می‌کند و همه اسلایدهای قابل مشاهده را با استفاده از تنظیمات خروجی پیش‌فرض به PDF ذخیره می‌کند.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose یک مبدل رایگان آنلاین **مبدل رایگان آنلاین پاورپوینت به PDF**[**مبدل رایگان آنلاین پاورپوینت به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمون برای پیاده‌سازی زندهٔ روش شرح داده شده در اینجا اجرا کنید.
{{% /alert %}}

## **تبدیل پاورپوینت به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خاصیت‌هایی تحت کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF حاصل را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل پاورپوینت به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت دلخواه خود برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، پیکسل در اینچ (DPI) برای تصاویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند با کیفیت JPEG تنظیم‌شده روی ۹۰، وضوح تصویر تنظیم‌شده روی ۳۰۰ DPI، متافایل‌ها به‌صورت PNG ذخیره می‌شوند و فشرده‌سازی متن فلِیت.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **انتخاب خودکار فشرده‌سازی تصویر**

وقتی یک ارائه شامل تعداد زیادی عکسی یا اسکرین‌شات باشد، کاهش حجم PDF صادرشده می‌تواند ارسال ایمیل یا دانلود را آسان‌تر کند. با فراخوانی [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) با مقدار `true` می‌توان به‌طور خودکار مناسب‌ترین الگوریتم فشرده‌سازی را برای هر تصویر در طول صادرات PDF انتخاب کرد.

مثال زیر یک ارائه موجود را بارگیری می‌کند، انتخاب خودکار فشرده‌سازی تصویر را فعال می‌سازد و آن را به عنوان یک سند PDF ذخیره می‌کند. تمام تنظیمات دیگر صادرات PDF مقادیر پیش‌فرض خود را حفظ می‌کنند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

این گزینه الگوریتم فشرده‌سازی را برای هر تصویر انتخاب می‌کند. کاهش مقدار پاس‌ شده به [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) باعث کاهش کیفیت تصویر JPEG می‌شود، در حالی که کاهش مقدار پاس‌ شده به [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) اجازه می‌دهد تصویر به وضوح کمتر کاهش نمونه‌برداری شود که می‌تواند جزئیات را کاهش دهد. فعال‌سازی انتخاب خودکار فشرده‌سازی به خودی خود هیچ‌یک از این تنظیمات را کاهش نمی‌دهد.

انتخاب الگوریتم‌های فشرده‌سازی تصویر نیاز به زمان پردازش و حافظه بیشتری دارد. کاهش حجم به تصاویر ارائه و تنظیمات صادرات بستگی دارد؛ کاهش ثابت برای هر ارائه تضمین نمی‌شود.

### **حفظ فایل‌های OLE Embedded به‌عنوان پیوست PDF**

اگر یک ارائه شامل یک کارنامه Excel جاسازی‌شده باشد، ممکن است بخواهید گیرندگان PDF به داده‌های کارنامه دسترسی داشته باشند و همچنین اسلایدها را ببینند. با فراخوانی [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) با مقدار `true` می‌توانید فایل‌های OLE جاسازی‌شده را به‌عنوان پیوست در PDF حاصل حفظ کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شی OLE بر روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست شامل نمی‌شود. تنظیم گزینه به `true` به‌علاوه داده‌های فایل را شامل می‌شود. پیش‌نمایش به‌عنوان یک نمای بصری باقی می‌ماند؛ پیوست به گیرندگان امکان باز یا ذخیره فایل جاسازی‌شده به‌صورت جداگانه را می‌دهد. شی OLE به یک کاربرگ Excel تعاملی در صفحه PDF تبدیل نمی‌شود.

مثال زیر یک ارائه را که قبلاً شامل یک کارنامه Excel جاسازی‌شده است بارگیری می‌کند و آن را به PDF با پیوست کارنامه صادر می‌کند.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

برای بررسی نتیجه:
1. PDF صادرشده را در یک نمایشگر که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader باز کنید.
2. پنل **پیوست‌ها** نمایشگر را باز کنید و کارنامه جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌ها را بررسی کنید، یا اگر نمایشگر اجازه دهد مستقیماً باز کنید. پیش‌نمایش بر روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی بر پیوست‌ها اعمال می‌کنند: PDF/A-1 فایل‌های جاسازی‌شده را ممنوع می‌سازد، PDF/A-2 فقط اجازه پیوست‌های PDF/A را می‌دهد و PDF/A-3 انواع دیگر فایل‌ها، از جمله کارنامه‌های Excel را مجاز می‌داند. این‌ها الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل پاورپوینت به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) از کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) برای گنجاندن اسلایدهای مخفی به‌عنوان صفحات در PDF حاصل استفاده کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند، به‌طوری که هر اسلاید مخفی نیز شامل می‌شود.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل پاورپوینت به PDF با حفاظت رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن به رمز عبور `password` نیاز دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا را می‌دهند.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) فراهم می‌کند تا بتوانید جایگزینی فونت‌ها را در طول فرآیند تبدیل ارائه به PDF تشخیص دهید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. یک هشدار فقط زمانی چاپ می‌شود که یک فونت در دسترس نباشد و در طول صادرات جایگزین شود.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
برای اطلاعات بیشتر درباره جایگزینی فونت، مقالهٔ [جایگزینی فونت](/slides/fa/nodejs-java/font-substitution/) را ببینید.
{{% /alert %}}

### **مدیریت فونت‌های بدون وزن بولد اختصاصی**

یک ارائه می‌تواند قالب‌بندی بولد را بر متن اعمال کند حتی اگر فونت آن وزن بولد اختصاصی نداشته باشد. متن می‌تواند از طریق بولد مصنوعی که گلیف‌های عادی را به‌صورت مصنوعی ضخیم می‌کند، به‌نظر بولد بیاید. وقتی این متن بیش از حد سنگین به‌نظر برسد یا با ظاهر موردنظر در PDF تفاوت داشته باشد، سعی کنید [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) را با مقدار `true` فراخوانی کنید. این گزینه متن تحت تأثیر را به‌صورت bitmap در طول صادرات PDF رندر می‌کند و می‌تواند ظاهر آن را برای برخی فونت‌ها بهبود بخشد. مقدار پیش‌فرض آن `false` است.

ارائه نمونه شامل دو جعبهٔ متن است: یکی با متن عادی و دیگری با قالب‌بندی بولد بر روی همان فونت که وزن بولد اختصاصی ندارد. مثال زیر ارائه را بارگیری می‌کند، رستر‌سازی سبک‌های فونت پشتیبانی‌نشده را فعال می‌کند و آن را به PDF صادر می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

پیشنمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط ضخیم‌تری دارد. با فعال شدن گزینه، خطوط آن سبک‌تر هستند؛ متن عادی تغییر نمی‌کند. نتایج را قبل از انتخاب تنظیم برای ارائه خود مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF با رستر‌سازی سبک فونت پشتیبانی‌نشده غیرفعال](unsupported-bold-disabled.png) | ![PDF با رستر‌سازی سبک فونت پشتیبانی‌نشده فعال](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه تنها متن بولد را به bitmap تبدیل می‌کند: این متن قابل انتخاب، کپی یا جستجو به‌عنوان متن بدون OCR نیست و لبه‌های آن در بزرگ‌نمایی ۸۰۰٪ نرم‌تر به‌نظر می‌رسند. متن عادی قابل جستجو می‌ماند. با غیرفعال بودن گزینه، هر دو رشته به‌عنوان متن باقی می‌مانند.

این گزینه متن قالب‌بندی‌شده به‌صورت بولد را رستر می‌کند وقتی فونت آن وزن بولد اختصاصی ندارد. [جایگزینی فونت](/slides/fa/nodejs-java/font-substitution/) در عوض یک فونت دیگر را زمانی که اصلی در دسترس نیست، انتخاب می‌کند.

## **تبدیل اسلایدهای انتخاب‌شده از پاورپوینت به PDF**

مثال زیر اسلایدهای ۱ و ۳ را از یک ارائه به PDF صادر می‌کند. شماره‌های اسلاید در این آرایه از یک شروع می‌شوند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **تبدیل پاورپوینت به PDF با اندازه سفارشی اسلاید**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائه جدید با اندازه اسلاید ۶۱۲ × ۷۹۲ پوینت (۸.۵ × ۱۱ اینچ) کپی می‌کند. محتویات اسلاید را برای مناسب شدن مقیاس می‌دهد و اسلاید تک را به PDF صادر می‌کند.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // حذف اسلاید خالی که ارائه جدید با آن ایجاد شد.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل پاورپوینت به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند و یادداشت‌های گوینده هر اسلاید را زیر اسلاید قرار می‌دهد. برای مشاهده نتیجه از یک ارائه حاوی یادداشت‌های گوینده استفاده کنید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **استانداردهای دسترسی و انطباق برای PDF**

Aspose.Slides به شما امکان استفاده از فرآیند تبدیل را می‌دهد که با [راهنمای دسترس‌پذیری محتوا وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند پاورپوینت را به PDF صادر کنید با استفاده از هر یک از این استانداردهای انطباق: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرآیند تبدیل پاورپوینت به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف انطباق، چندین PDF تولید می‌کند:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما امکان تبدیل فایل‌های PDF به فرمت‌های محبوب را می‌دهد. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)، [PDF به JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات‌های تبدیل PDF به فرمت‌های ویژه—[PDF به SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)— نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **توجه:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر فردی به‌عنوان محتوای جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان آثار جانبی علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل ارائه می‌شود.

## **پرسش‌های متداول**

**آیا می‌توانم چندین فایل پاورپوینت را به‌صورت انبوه به PDF تبدیل کنم؟**  
بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود پیمایشی انجام داده و فرآیند تبدیل را اعمال کنید.

**آیا امکان محافظت رمز عبور برای PDF تبدیل‌شده وجود دارد؟**  
بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) برای تنظیم یک رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانده کنم؟**  
با فراخوانی [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) با مقدار `true` در کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) می‌توانید اسلایدهای مخفی را در PDF نهایی گنجانده کنید.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**  
بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) و [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما تضمین شوند.

**آیا Aspose.Slides از استانداردهای سازگاری PDF/A پشتیبانی می‌کند؟**  
بله، Aspose.Slides به شما امکان صادر کردن PDFهایی که با [استانداردهای مختلف](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) سازگار هستند، از جمله PDF/A1a، PDF/A1b و PDF/UA، را می‌دهد تا اسناد شما نیازهای دسترس‌پذیری و آرشیو را برآورده کنند.

## **منابع بیشتر**

- [مستندات Aspose.Slides برای Node.js از طریق Java](/slides/fa/nodejs-java/)
- [مرجع API Aspose.Slides برای Node.js از طریق Java](https://reference.aspose.com/slides/nodejs-java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)