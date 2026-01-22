---
title: "تحويل PPT و PPTX إلى PDF في JavaScript [متضمنة ميزات متقدمة]"
linktitle: "PowerPoint إلى PDF"
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
- PPTX إلى PDF
- تحويل PPTX إلى PDF
- حفظ PowerPoint كملف PDF
- حفظ PPT كملف PDF
- حفظ PPTX كملف PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث باستخدام Aspose.Slides لـ Node.js، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

تحويل عروض PowerPoint وOpenDocument (PPT ، PPTX ، ODP ، إلخ) إلى تنسيق PDF باستخدام JavaScript يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، تضمين الشرائح المخفية، حماية ملفات PDF بكلمة مرور، اكتشاف استبدال الخطوط، اختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصياغات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) تكشف عن طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

يقوم Aspose.Slides for Node.js via Java بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل التطبيق بـ "*Aspose.Slides*" وحقل مُنتِج PDF بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يمكّنك Aspose.Slides من تحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من عرض إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق تقريبًا العروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الارتباطات التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض هذا الكود كيفية تحويل عرض (PPT ، PPTX ، ODP ، إلخ) إلى PDF:
```js
// إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

يقدم Aspose محولًا مجانيًا عبر الإنترنت لملف [**PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية التحويل من العرض إلى PDF. يمكنك إجراء اختبار باستخدام هذا المحول لتجربة التنفيذ الفعلي للإجراء المذكور هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة — خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — تتيح لك تخصيص PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، تحديد طريقة معالجة ملفات الميتا، تعيين مستوى ضغط للنص، تكوين DPI للصور، والمزيد.

يوضح مثال الكود أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```js
// إنشاء كائن فئة PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// تعيين جودة صور JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// تعيين DPI للصور.
pdfOptions.setSufficientResolution(300);

// تعيين سلوك ملفات الميتافايل.
pdfOptions.setSaveMetafilesAsPng(true);

// تعيين مستوى ضغط النص للمحتوى النصي.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// تعريف وضع التوافق مع PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // حفظ العرض التقديمي كملف PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) من فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) لتضمين الشرائح المخفية كصفحات في ملف PDF الناتج.

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```js
// إنشاء كائن الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن الفئة PdfOptions.
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

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions):
```js
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // إنشاء كائن الفئة PdfOptions.
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

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) تمكّنك من اكتشاف استبدال الخطوط أثناء عملية التحويل من العرض إلى PDF.

يعرض هذا الكود JavaScript كيفية اكتشاف استبدال الخطوط:
```js
// تعيين رد نداء التحذير في خيارات PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument file.
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

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/nodejs-java/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح مختارة في PowerPoint إلى PDF**

يعرض هذا الكود JavaScript كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```js
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
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

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```js
const slideWidth = 612;
const slideHeight = 792;

// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// إنشاء عرض تقديمي جديد بحجم شريحة معدل.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // تعيين حجم الشريحة المخصص.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // استنساخ الشريحة الأولى من العرض التقديمي الأصلي.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // حفظ العرض التقديمي المعدل كملف PDF مع الملاحظات.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشرائح**

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```js
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint أو OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // تكوين خيارات PDF مع تخطيط الملاحظات.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي كملف PDF مع الملاحظات.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **معايير الوصول والامتثال لملفات PDF**

يتيح لك Aspose.Slides استخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يعرض هذا الكود JavaScript عملية تحويل من PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:
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

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى تنسيقات شائعة. يمكنك تنفيذ تحويلات [PDF إلى HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)، [PDF إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). تدعم عمليات تحويل PDF إلى تنسيقات متخصصة أيضًا — [PDF إلى SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/).

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك التكرار عبر ملفاتك وتطبيق عملية التحويل برمجياً.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالتأكيد. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `setJpegQuality` و`setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، ما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for Node.js via Java](/slides/ar/nodejs-java/)
- [مرجع API لـ Aspose.Slides for Node.js via Java](https://reference.aspose.com/slides/nodejs-java/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)