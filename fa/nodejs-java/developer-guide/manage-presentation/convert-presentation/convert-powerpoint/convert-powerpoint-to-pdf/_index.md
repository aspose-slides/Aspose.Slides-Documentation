---
title: تبدیل PPT و PPTX به PDF در JavaScript [شامل ویژگی‌های پیشرفته]
linktitle: PowerPoint به PDF
type: docs
weight: 40
url: /fa/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- PowerPoint به PDF
- ارائه به PDF
- PPT به PDF
- تبدیل PPT به PDF
- PPTX به PDF
- تبدیل PPTX به PDF
- ذخیره PowerPoint به‌صورت PDF
- ذخیره PPT به‌صورت PDF
- ذخیره PPTX به‌صورت PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint PPT/PPTX را با استفاده از Aspose.Slides برای Node.js به PDFهای با کیفیت بالا و قابل جستجو تبدیل کنید، همراه با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX، ODP و غیره) به فرمت PDF در JavaScript مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نحوه تبدیل ارائه‌ها به اسناد PDF، استفاده از گزینه‌های مختلف برای کنترل کیفیت تصویر، شامل کردن اسلایدهای مخفی، محافظت از فایل‌های PDF با رمز عبور، شناسایی جایگزینی فونت، انتخاب اسلایدهای خاص برای تبدیل و اعمال استانداردهای سازگاری بر اسناد خروجی را نشان می‌دهد.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) پاس دهید و سپس ارائه را با متد [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) متد [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) را که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود، در اختیار می‌گذارد.

{{% alert color="info" title="Note" %}}

Aspose.Slides برای Node.js عبر Java اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، فیلد Application با "*Aspose.Slides*" و فیلد PDF Producer با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌شود. **Note** که شما نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* تبدیل کل ارائه‌ها به PDF
* تبدیل اسلایدهای خاص از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای خروجی تا حد امکان مشابه ارائه‌های اصلی باشند. عناصر و ویژگی‌ها در تبدیل به‌دقت رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای ابرمتنی
* سربرگ‌ها و پاورقی‌ها
* نقاط گلوله‌ای
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و حداکثر کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با تنظیمات خروجی پیش‌فرض به PDF ذخیره می‌کند.

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

Aspose یک [**تبدیل‌کننده PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) آنلاین رایگان ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این تبدیل‌کننده یک آزمایش زنده از روش شرح داده شده انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی — خصوصیات موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — را فراهم می‌کند تا بتوانید PDF خروجی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را با PDF 1.5، کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، متافایل‌ها به صورت PNG ذخیره و فشرده‌سازی متن Flate صادر می‌کند.

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

### **حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست PDF**

اگر ارائه شامل یک کتاب‌کار Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF نیز به داده‌های کتاب‌کار دسترسی داشته باشند و اسلایدها را مشاهده کنند. با فراخوانی [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) با مقدار `true` می‌توانید فایل‌های OLE جاسازی‌شده را به‌عنوان پیوست در PDF نهایی حفظ کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شی OLE روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست شامل نمی‌شود. تنظیم گزینه روی `true` علاوه بر پیش‌نمایش، داده‌های فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری است؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شی OLE تبدیل به یک ورک‌شیت تعاملی Excel در صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که قبلاً شامل یک کتاب‌کار Excel جاسازی‌شده است، بارگذاری می‌کند و آن را با کتاب‌کار پیوست به PDF صادر می‌کند.

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

1. PDF صادرشده را در یک نمایشگر که از پیوست‌های فایل پشتیبانی می‌کند (مانند Adobe Acrobat Reader) باز کنید.
2. در پنل **Attachments** نمایشگر، کتاب‌کار جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کرده و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا در صورت اجازه نمایشگر مستقیماً باز کنید. پیش‌نمایش روی صفحه PDF جداگانه از پیوست است.

{{% alert color="info" title="Note" %}}

استانداردهای PDF/A محدودیت‌هایی بر روی پیوست‌ها اعمال می‌کنند: PDF/A-1 فایل‌های جاسازی‌شده را ممنوع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را مجاز می‌داند و PDF/A-3 انواع دیگر فایل‌ها از جمله کتاب‌کارهای Excel را اجازه می‌دهد. این محدودیت‌ها بخشی از استانداردهاست و نه محدودیت خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض سازگاری PDF استفاده می‌کند و استخراج PDF/A را نشان نمی‌دهد.

{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) از کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) اسلایدهای مخفی را به‌عنوان صفحات در PDF نهایی گنجانید.

مثال زیر یک ارائه را به PDF صادر می‌کند و اسلایدهای مخفی را نیز شامل می‌شود.

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

### **تبدیل PowerPoint به PDF محافظت‌شده با رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن نیاز به رمز عبور `password` دارد. دسترسی‌ها اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهند.

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

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) ارائه می‌دهد که به شما امکان می‌دهد در زمان تبدیل ارائه به PDF، جایگزینی فونت‌ها را شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که فونت در دسترس نباشد و جایگزین شود.

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

برای اطلاعات بیشتر درباره جایگزینی فونت، مقاله [Font Substitution](/slides/fa/nodejs-java/font-substitution/) را ببینید.

{{% /alert %}} 

### **بررسی فونت‌های بدون نوع‌قلم Bold اختصاصی**

یک ارائه می‌تواند قالب‌بندی بولد را بر متنی اعمال کند حتی اگر فونت آن نوع‌قلم بولد اختصاصی نداشته باشد. متن همچنان می‌تواند به‌صورت بولد ظاهر شود از طریق بولد مصنوعی که گلیف‌های معمول را ضخیم می‌کند. وقتی متن به‌نظر بیش از حد سنگین می‌آید یا با ظاهر موردنظر در PDF تفاوت دارد، می‌توانید با فراخوانی [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) با مقدار `true` این رفتار را فعال کنید. این گزینه متن تحت تأثیر را هنگام صادرات به PDF به بیت‌مپ رندر می‌کند و می‌تواند ظاهر آن را برای برخی فونت‌ها بهبود بخشد. مقدار پیش‌فرض `false` است.

ارائه نمونه دو جعبه متن دارد: یکی با متن عادی و دیگری با قالب‌بندی بولد برای همان فونت که نوع‌قلم بولد اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رسترایز کردن سبک‌های فونت پشتیبانی‌نشده را فعال می‌کند و آن را به PDF صادر می‌نماید:

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

پیش‌نمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط سنگین‌تری دارد. با فعال کردن گزینه، خطوط آن سبک‌تر می‌شوند؛ متن عادی بدون تغییر می‌ماند. قبل از انتخاب تنظیم برای ارائه‌تان نتایج را مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال کردن گزینه تنها متن بولد را به بیت‌مپ تبدیل می‌کند: بدون OCR نمی‌توان آن را انتخاب، کپی یا جستجو کرد و لبه‌های آن در بزرگ‌نمایی 800٪ نرم‌تر به نظر می‌رسند. متن عادی همچنان قابل جستجوست. با غیرفعال بودن گزینه، هر دو رشته به‌صورت متن باقی می‌مانند.

این گزینه متن قالب‌بندی‌شده به‌صورت بولد را زمانی که فونت آن نوع‌قلم بولد اختصاصی نداشته باشد رستر می‌کند. [Font substitution](/slides/fa/nodejs-java/font-substitution/) به‌جای آن هنگام عدم دسترسی به فونت اصلی، یک فونت دیگر را انتخاب می‌کند.

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره اسلایدها در این آرایه به‌صورت یک‌پایه هستند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

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

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

مثال زیر اسلاید اول را از یک ارائه به یک ارائه جدید با اندازه اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید را برای تناسب مقیاس می‌دهد و اسلاید منفرد را به PDF صادر می‌کند.

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

    // اسلاید خالی که ارائه جدید با آن ایجاد شده بود را حذف کنید.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند و یادداشت‌های سخنران هر اسلاید را زیر اسلاید قرار می‌دهد. برای مشاهده نتیجه از ارائه‌ای که شامل یادداشت‌های سخنران باشد، استفاده کنید.

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

## **دسترس‌پذیری و استانداردهای سازگاری برای PDF**

Aspose.Slides به شما امکان می‌دهد از روشی استفاده کنید که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF با هر یک از این استانداردهای سازگاری صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف سازگاری چند PDF تولید می‌کند:

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

Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)، [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) و [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی — [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **Note:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artefact علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **سؤال‌های متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌ای روی فایل‌های خود پیمایش کنید و فرآیند تبدیل را اعمال نمایید.

**آیا می‌توانم PDF تبدیل‌شده را با رمز عبور محافظت کنم؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) برای تنظیم رمز عبور و تعریف دسترسی‌ها هنگام تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

در کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) متد [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) را با `true` فراخوانی کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) و [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما حفظ شوند.

**آیا Aspose.Slides استانداردهای سازگاری PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با [استانداردهای مختلف](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و تضمین می‌کند اسناد شما نیازهای دسترس‌پذیری و بایگانی را برآورده کنند.

## **منابع بیشتر**

- [مستندات Aspose.Slides برای Node.js عبر Java](/slides/fa/nodejs-java/)
- [مرجع API Aspose.Slides برای Node.js عبر Java](https://reference.aspose.com/slides/nodejs-java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)