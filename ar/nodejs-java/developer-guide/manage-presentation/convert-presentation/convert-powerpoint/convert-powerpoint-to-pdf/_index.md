---
title: تحويل PPT و PPTX إلى PDF في JavaScript [تشمل الميزات المتقدمة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل العرض
- PowerPoint إلى PDF
- العرض إلى PDF
- PPT إلى PDF
- تحويل PPT إلى PDF
- PPTX إلى PDF
- تحويل PPTX إلى PDF
- حفظ PowerPoint كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث باستخدام Aspose.Slides لـ Node.js، مع أمثلة شيفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يقدِّم تحويل عروض PowerPoint وعروض OpenDocument (PPT، PPTX، ODP، إلخ) إلى صيغة PDF باستخدام JavaScript عدة مزايا، بما في ذلك التوافق عبر مختلف الأجهزة والحفاظ على تخطيط وتنسيق عرضك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات متعددة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرر اسم الملف كوسيطة إلى فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. تُظهر فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides for Node.js عبر Java بإدراج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بقيمة "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح لك Aspose.Slides بتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يقوم Aspose.Slides بتصدير العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق عن كثب مع العروض الأصلية. يتم عرض العناصر والسمات بدقة في عملية التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية تحويل PowerPoint إلى PDF القياسية الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

```js
// إنشاء فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // حفظ العرض كملف PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

توفر Aspose محولًا مجانيًا عبر الإنترنت لـ [**PowerPoint إلى PDF**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) يوضح عملية تحويل العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذا المحول لتطبيق عملي للإجراءات الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة — خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pdfoptions/) — تمكّنك من تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية تنفيذ عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى ضغط للنص، وتكوين DPI للصور، وأكثر.

يوضح المثال البرمجي أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.

```js
// إنشاء فئة PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// تعيين جودة الصور JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// تعيين DPI للصور.
pdfOptions.setSufficientResolution(300);

// تعيين سلوك ملفات الميتا.
pdfOptions.setSaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// تعريف وضع الامتثال PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// إنشاء فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // حفظ العرض كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام الطريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) من فئة [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PdfOptions) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```js
// إنشاء فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // إنشاء فئة PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // إضافة الشرائح المخفية.
    pdfOptions.setShowHiddenSlides(true);

    // حفظ العرض كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرورusing معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PdfOptions):

```js
// إنشاء فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // إنشاء فئة PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // تعيين كلمة مرور PDF وأذونات الوصول.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // حفظ العرض كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **اكتشاف استبدال الخطوط**

يوفر Aspose.Slides الطريقة [setWarningCallback](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PdfOptions)، مما يتيح لك اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

يعرض هذا الكود JavaScript كيفية اكتشاف استبدال الخطوط:

```js
// تعيين رد النداء التحذيري في خيارات PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// إنشاء فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// حفظ العرض كملف PDF.
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

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/nodejs-java/font-substitution/).

{{% /alert %}} 

## **تحويل الشرائح المختارة في PowerPoint إلى PDF**

يعرض هذا الكود JavaScript كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:

```js
// إنشاء فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // تعيين مصفوفة أرقام الشرائح.
    let slides = java.newArray("int", [1, 3]);

    // حفظ العرض كملف PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:

```js
const slideWidth = 612;
const slideHeight = 792;

// إنشاء فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدَّل.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // تعيين حجم الشريحة المخصص.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // استنساخ الشريحة الأولى من العرض الأصلي.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // حفظ العرض المُعدَّل كملف PDF مع الملاحظات.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:

```js
// إنشاء فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // تكوين خيارات PDF مع تخطيط الملاحظات.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض كملف PDF مع الملاحظات.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **معايير الوصول والامتثال لملفات PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الكود JavaScript عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:

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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء تحويلات [PDF إلى HTML](https://products.aspose.com/slides/ar/nodejs-java/conversion/pdf-to-html/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/nodejs-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/nodejs-java/conversion/pdf-to-png/). كما يتم دعم عمليات تحويل PDF إلى صيغ متخصصة أخرى — [PDF إلى SVG](https://products.aspose.com/slides/ar/nodejs-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/nodejs-java/conversion/pdf-to-tiff/) —.

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد تُعد كعناصر زائد؛ يتم توفير النص البديل فقط للكائن بالكامل.

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides تحويل دفعات من ملفات PPT أو PPTX إلى PDF. يمكنك تكرار العملية عبر ملفاتك وتطبيق التحويل برمجيًا.

**هل من الممكن حماية PDF المحول بكلمة مرور؟**

بالتأكيد. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PdfOptions) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم الطريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PdfOptions) لتضمين الشرائح المخفية في PDF الناتج.

**هل يستطيع Aspose.Slides الحفاظ على جودة الصور العالية في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `setJpegQuality` و`setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PdfOptions) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، لضمان تلبية وثائقك لمتطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ Node.js عبر Java](/slides/ar/nodejs-java/)
- [مرجع API لـ Aspose.Slides لـ Node.js عبر Java](https://reference.aspose.com/slides/ar/nodejs-java/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/ar/conversion)