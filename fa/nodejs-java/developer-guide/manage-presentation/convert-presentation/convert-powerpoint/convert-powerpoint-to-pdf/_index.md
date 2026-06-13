---
title: تبدیل PPT و PPTX به PDF در JavaScript [ویژگی‌های پیشرفته گنجانده شده]
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
- ذخیره PowerPoint به عنوان PDF
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "PowerPoint PPT/PPTX را با استفاده از Aspose.Slides برای Node.js به PDFهای با کیفیت بالا و قابل جستجو تبدیل کنید، با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX، ODP و غیره) به فرمت PDF در JavaScript مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را روی اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) پاس می‌دهید و سپس ارائه را با استفاده از متد `save` به PDF ذخیره می‌کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) متد `save` را فراهم می‌کند که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{%  alert title="توجه"  color="warning"   %}} 

Aspose.Slides برای Node.js از طریق Java اطلاعات API و شماره نسخه خود را در اسناد خروجی قرار می‌دهد. برای مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.

{{% /alert %}}

Aspose.Slides به شما امکان تبدیل را می‌دهد:

* کل ارائه‌ها به PDF
* اسلایدهای خاص از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد فایل‌های PDF تولید شده به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه و پانویس
* گلوله‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با استفاده از تنظیمات بهینه و حداکثر سطوح کیفیت به PDF تبدیل کند.

این کد نشان می‌دهد چگونه یک ارائه (PPT، PPTX، ODP و غیره) را به PDF تبدیل کنید:

```js
// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PowerPoint یا OpenDocument است.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // ارائه را به صورت PDF ذخیره کنید.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose یک [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) رایگان آنلاین ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست انجام دهید تا پیاده‌سازی زندهٔ روند توصیف‌شده در اینجا را ببینید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/)—را فراهم می‌کند که به شما امکان سفارشی‌سازی PDF خروجی، قفل کردن PDF با رمز عبور یا تعیین نحوه پیشرفت فرآیند تبدیل را می‌دهد.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت مورد علاقه خود برای تصاویر رستری را تعریف کنید، نحوهٔ مدیریت متافایل‌ها را مشخص کنید، سطح فشرده‌سازی متن را تعیین کنید، DPI تصاویر را تنظیم کنید و موارد دیگر.

مثال کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با چند گزینه سفارشی تبدیل کنید.

```js
// یک شیء از کلاس PdfOptions ایجاد کنید.
let pdfOptions = new aspose.slides.PdfOptions();

// کیفیت تصاویر JPG را تنظیم کنید.
pdfOptions.setJpegQuality(java.newByte(90));

// DPI تصاویر را تنظیم کنید.
pdfOptions.setSufficientResolution(300);

// رفتار متا‌فایل‌ها را تنظیم کنید.
pdfOptions.setSaveMetafilesAsPng(true);

// سطح فشرده‌سازی متن برای محتوا متنی را تنظیم کنید.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// حالت انطباق PDF را تعریف کنید.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PowerPoint یا OpenDocument است.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // ارائه را به عنوان یک سند PDF ذخیره کنید.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه دارای اسلایدهای مخفی باشد، می‌توانید از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PdfOptions) استفاده کنید تا اسلایدهای مخفی به‌عنوان صفحات در PDF خروجی گنجانده شوند.

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF تبدیل کنید در حالی که اسلایدهای مخفی گنجانده شده‌اند:

```js
// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PowerPoint یا OpenDocument است.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // یک شیء از کلاس PdfOptions ایجاد کنید.
    let pdfOptions = new aspose.slides.PdfOptions();

    // اسلایدهای مخفی را اضافه کنید.
    pdfOptions.setShowHiddenSlides(true);

    // ارائه را به صورت PDF ذخیره کنید.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تبدیل PowerPoint به PDF محافظت‌شده با رمز عبور**

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF محافظت‌شده با رمز عبور تبدیل کنید با استفاده از پارامترهای حفاظت موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PdfOptions):

```js
// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PowerPoint یا OpenDocument است.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // یک شیء از کلاس PdfOptions ایجاد کنید.
    let pdfOptions = new aspose.slides.PdfOptions();

    // یک گذرواژه PDF و مجوزهای دسترسی تنظیم کنید.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // ارائه را به صورت PDF ذخیره کنید.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **شناسایی جایگزینی فونت‌ها**

Aspose.Slides متد [setWarningCallback](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PdfOptions) فراهم می‌کند که به شما امکان شناسایی جایگزینی فونت‌ها را در طول فرآیند تبدیل ارائه به PDF می‌دهد.

این کد JavaScript نشان می‌دهد چگونه جایگزینی فونت‌ها را شناسایی کنید:

```js
// تنظیم تابع هشدار در گزینه‌های PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PowerPoint یا OpenDocument است.
let presentation = new aspose.slides.Presentation("sample.pptx");

// ارائه را به صورت PDF ذخیره کنید.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

برای اطلاعات بیشتر در مورد جایگزینی فونت، مقالهٔ [Font Substitution](/slides/fa/nodejs-java/font-substitution/) را ببینید.

{{% /alert %}} 

## **تبدیل اسلایدهای منتخب در PowerPoint به PDF**

این کد JavaScript نشان می‌دهد چگونه تنها اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```js
// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PowerPoint یا OpenDocument است.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // آرایه‌ای از شماره اسلایدها را تنظیم کنید.
    let slides = java.newArray("int", [1, 3]);

    // ارائه را به صورت PDF ذخیره کنید.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF با اندازه اسلاید مشخص تبدیل کنید:

```js
const slideWidth = 612;
const slideHeight = 792;

// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PowerPoint یا OpenDocument است.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// یک ارائه جدید با اندازه اسلاید تنظیم‌شده ایجاد کنید.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // اندازه اسلاید سفارشی را تنظیم کنید.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // اولین اسلاید را از ارائه اصلی کپی کنید.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // ارائه تغییر یافته را به یک PDF با یادداشت‌ها ذخیره کنید.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

این کد JavaScript نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF که شامل یادداشت‌هاست تبدیل کنید:

```js
// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PowerPoint یا OpenDocument است.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // گزینه‌های PDF را با قالب‌بندی یادداشت‌ها پیکربندی کنید.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // ارائه را به یک PDF با یادداشت‌ها ذخیره کنید.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **استانداردهای دسترسی و انطباق برای PDF**

Aspose.Slides به شما امکان استفاده از یک روش تبدیل که با [راهنمای دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد را می‌دهد. می‌توانید یک سند PowerPoint را به PDF صادر کنید با استفاده از هر یک از این استانداردهای انطباق: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد JavaScript نشان می‌دهد یک فرآیند تبدیل PowerPoint به PDF که چند PDF بر اساس استانداردهای انطباق مختلف تولید می‌کند:

```js
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به فرمت‌های محبوب تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/nodejs-java/conversion/pdf-to-html/)، [PDF به JPG](https://products.aspose.com/slides/fa/nodejs-java/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/nodejs-java/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/fa/nodejs-java/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/nodejs-java/conversion/pdf-to-tiff/)—هم نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **Note:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوا نگهداری نمی‌شوند و ممکن است به عنوان artifacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل فراهم می‌شود.

## **FAQ**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌ای بر روی فایل‌های خود پیمایش کنید و فرآیند تبدیل را اعمال کنید.

**آیا امکان محافظت از PDF تبدیل‌شده با رمز عبور وجود دارد؟**

مطمئناً. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PdfOptions) برای تنظیم رمز عبور و تعریف سطوح دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF شامل کنم؟**

از متد `setShowHiddenSlides` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PdfOptions) برای گنجاندن اسلایدهای مخفی در PDF خروجی استفاده کنید.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند `setJpegQuality` و `setSufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PdfOptions) کیفیت بالای تصاویر را در PDF خود تضمین کنید.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با استانداردهای مختلفی از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و به‌این ترتیب نیازهای دسترسی و آرشیو اسناد شما را برآورده می‌سازد.

## **منابع بیشتر**

- [مستندات Aspose.Slides برای Node.js از طریق Java](/slides/fa/nodejs-java/)
- [مرجع API Aspose.Slides برای Node.js از طریق Java](https://reference.aspose.com/slides/fa/nodejs-java/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)