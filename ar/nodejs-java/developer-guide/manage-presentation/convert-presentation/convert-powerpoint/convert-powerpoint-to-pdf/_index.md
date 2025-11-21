---
title: تحويل PPT و PPTX إلى PDF في JavaScript [متضمنة الميزات المتقدمة]
linktitle: تحويل PPT و PPTX إلى PDF
type: docs
weight: 40
url: /ar/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- PowerPoint إلى PDF
- العرض التقديمي إلى PDF
- PPT إلى PDF
- تحويل PPT إلى PDF
- تحويل PPTX إلى PDF
- ODP إلى PDF
- تحويل ODP إلى PDF
- حفظ PowerPoint كملف PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- JavaScript
- Node.js
- Aspose.Slides لـ Node.js عبر Java
description: "تعرف على كيفية تحويل عروض PPT و PPTX و ODP إلى PDF في JavaScript باستخدام Aspose.Slides. تنفيذ ميزات متقدمة مثل الحماية بكلمة مرور، معايير الامتثال، وخيارات مخصصة للحصول على مستندات PDF عالية الجودة ومتاحة."
---

## **نظرة عامة**

تحويل عروض PowerPoint وOpenDocument (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام JavaScript يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق عرضك التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإضافة الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ثم احفظ العرض بتنسيق PDF باستخدام طريقة `save`. تُظهر الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

تقوم Aspose.Slides لـ Node.js عبر Java بإدراج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، تقوم Aspose.Slides بملء حقل التطبيق بـ "*Aspose.Slides*" وحقل منتج PDF بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

تتيح لك Aspose.Slides تحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

تقوم Aspose.Slides بتصدير العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق بشكل كبير مع العروض الأصلية. يتم عرض العناصر والسمات بدقة في عملية التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* الرصاصات
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، تحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثلى بأعلى مستويات الجودة.

This code shows you how to convert a presentation (PPT, PPTX, ODP, etc.) to PDF:
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

تقدم Aspose أداة تحويل مجانية عبر الإنترنت **محول PowerPoint إلى PDF** توضح عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذه الأداة لتطبيق عملي للإجراءات الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)— التي تتيح لك تخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وضبط مستوى ضغط النص، وتكوين DPI للصور، وأكثر من ذلك.

The code example below demonstrates how to convert a PowerPoint presentation to PDF with several custom options.
```js
// إنشاء كائن من فئة PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// تعيين جودة صور JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// تعيين DPI للصور.
pdfOptions.setSufficientResolution(300);

// تعيين سلوك ملفات الميتا.
pdfOptions.setSaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// تعريف وضع الامتثال PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) من الفئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) لتضمين الشرائح المخفية كصفحات في ملف PDF الناتج.

This JavaScript code shows how to convert a PowerPoint presentation to PDF with hidden slides included:
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من فئة PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // إضافة الشرائح المخفية.
    pdfOptions.setShowHiddenSlides(true);

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

This JavaScript code demonstrates how to convert a PowerPoint presentation into a password-protected PDF using the protection parameters from the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) class:
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن من فئة PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // تعيين كلمة مرور PDF وأذونات الوصول.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **اكتشاف استبدال الخطوط**

توفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)، مما يتيح لك اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

This JavaScript code shows how to detect font substitutions:
```js
// تعيين رد نداء التحذير في خيارات PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// حفظ العرض التقديمي كملف PDF.
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

لمزيد من المعلومات حول استلام ردود النداء لاستبدال الخطوط أثناء عملية العرض، راجع [الحصول على ردود النداء للتحذير لاستبدال الخطوط](/slides/ar/nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

لمزيد من المعلومات حول استبدال الخطوط، راجع المقالة [استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/).

{{% /alert %}} 

## **تحويل الشرائح المحددة في PowerPoint إلى PDF**

This JavaScript code demonstrates how to convert only specific slides from a PowerPoint presentation to PDF:
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // تعيين مصفوفة أرقام الشرائح.
    let slides = java.newArray("int", [1, 3]);

    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

```js
const slideWidth = 612;
const slideHeight = 792;

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدل.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // تعيين حجم الشريحة المخصص.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // استنساخ الشريحة الأولى من العرض التقديمي الأصلي.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // حفظ العرض التقديمي المعاد تحجيمه إلى PDF مع الملاحظات.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

```js
// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // تكوين خيارات PDF باستخدام تخطيط الملاحظات.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي إلى PDF مع الملاحظات.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **معايير الوصول والامتثال لملفات PDF**

تتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات إمكانية الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أيٍ من هذه المعايير المطلوبة: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

This JavaScript code demonstrates a PowerPoint-to-PDF conversion process that produces multiple PDFs based on different compliance standards:
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


{{% alert title="ملاحظة" color="warning" %}} 

تدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء التحويلات [PDF إلى HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)، [PDF إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). كما يتم دعم عمليات تحويل PDF إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—.

{{% /alert %}} 

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، تدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك المرور على ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل من الممكن حماية PDF المحول باستخدام كلمة مرور؟**

بالطبع. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `setShowHiddenSlides` في الفئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صور عالية في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `setJpegQuality` و`setSufficientResolution` في الفئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) لضمان صور عالية الجودة في ملف PDF الخاص بك.

**هل تدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، تتيح لك Aspose.Slides تصدير ملفات PDF التي تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والحفظ.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ Node.js عبر Java](/slides/ar/nodejs-java/)
- [مرجع API لـ Aspose.Slides لـ Node.js عبر Java](https://reference.aspose.com/slides/nodejs-java/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)