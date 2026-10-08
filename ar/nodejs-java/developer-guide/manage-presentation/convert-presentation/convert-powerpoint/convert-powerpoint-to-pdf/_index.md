---
title: تحويل PPT و PPTX إلى PDF في JavaScript [مميزات متقدمة متضمنة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- PowerPoint إلى PDF
- عرض تقديمي إلى PDF
- PPT إلى PDF
- تحويل PPT إلى PDF
- PPTX إلى PDF
- تحويل PPTX إلى PDF
- حفظ PowerPoint كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث باستخدام Aspose.Slides لـ Node.js، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يُعد تحويل عروض PowerPoint وعروض OpenDocument (PPT و PPTX و ODP وغيرها) إلى صيغة PDF باستخدام JavaScript له عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، وتحديد شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغة التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، قم بتمرير اسم الملف كمعامل إلى فئة [العرض التقديمي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). تعرض فئة [العرض التقديمي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) طريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java يُدرج معلومات API وإصدارها في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل التطبيق بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكن إخبار Aspose.Slides بتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* عرض كامل إلى PDF
* شرائح محددة من العرض إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق إلى حد كبير مع العروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمل عرضًا ويحفظ جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

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
Aspose يقدم محولًا مجانيًا عبر الإنترنت لـ [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية التحويل من العرض إلى PDF. يمكنك تجربة هذا المحول لإجراء اختبار عملي للإجراءات الموضحة هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد جودة الصور النقطية المفضلة لديك، وتحديد كيفية التعامل مع ملفات الميتا، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وأكثر من ذلك.

المثال التالي يصدر عرضًا إلى PDF 1.5 مع جودة JPEG مضبوطة على 90، ودقة الصورة إلى 300 DPI، وحفظ ملفات الميتا كـ PNG، وضغط نص Flate.

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

### **الحفاظ على ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على مصنف Excel مضمّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات المصنف وكذلك مشاهدة الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) مع `true` للحفاظ على ملفات OLE المضمنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة المعاينة أو الأيقونة الخاصة بكائن OLE على صفحة PDF، لكن الملف المضمن لا يُدرج كمرفق. ضبط الخيار على `true` يضيف بيانات الملف أيضًا. تظل المعاينة تمثيلًا بصريًا؛ يتيح المرفق للمستلمين فتح أو حفظ الملف المضمن منفصلًا. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضًا يحتوي بالفعل على مصنف Excel مضمّن ويصدّره إلى PDF مع إرفاق المصنف.

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

للتحقق من النتيجة:

1. افتح PDF المصدر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وابحث عن المصنف المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يمنع الملفات المضمَّنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى، بما في ذلك مصنفات Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال الافتراضي ولا يوضح تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا إلى PDF، متضمنًا أي شرائح مخفية.

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

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

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

### **اكتشاف استبدالات الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)، مما يتيح لك اكتشاف استبدالات الخطوط أثناء عملية التحويل من العرض إلى PDF.

المثال التالي يصدر عرضًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يُطبع التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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
لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/nodejs-java/font-substitution/).
{{% /alert %}} 

### **معالجة الخطوط التي لا تمتلك نوعًا غامقًا مخصصًا**

يمكن للعرض تطبيق تنسيق غامق للنص حتى عندما لا يمتلك الخط نوعًا غامقًا مخصصًا. لا يزال النص يبدو غامقًا من خلال "التغليظ الصناعي"، الذي يثخّن الحروف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرّب استدعاء [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) مع `true`. هذا الخيار يرسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسّن مظهره لبعض الخطوط. القيمة الافتراضية هي `false`.

العرض التجريبي يحتوي على مربعين نصيين: أحدهما بنص عادي والآخر بنص غامق لنفس الخط الذي لا يمتلك نوعًا غامقًا مخصصًا. المثال التالي يحمل العرض، يُفعّل تحويل الخطوط غير المدعومة إلى نقطية، ويصدّره إلى PDF:

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

المعاينات التالية تُظهر النتيجة مع تعطيل الخيار ومع تفعيل الخيار. في هذا المثال، النص الغامق يكون بخطوط سميكة مع تعطيل الخيار. مع تفعيل الخيار، تصبح خطوطه أخف؛ يبقى النص العادي دون تغيير. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطَّل (`false`، الافتراضي) | الخيار مفعَّل (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

في هذا المثال، يؤدي تفعيل الخيار إلى تحويل النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه أكثر نعومة عند تكبير 800٪. يظل النص العادي قابلًا للبحث. مع تعطيل الخيار، يبقى كلا السلسلتين نصًا.

هذا الخيار يُحوِّل النص المُنسَّق كغامق عندما لا يمتلك الخط نوعًا غامقًا مخصصًا. بدلاً من ذلك، تُختار [استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/) خطًا آخر عندما يكون الأصلي غير متوفر.

## **تحويل شرائح مختارة من PowerPoint إلى PDF**

المثال التالي يصدر الشرائح 1 و 3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من 1، ويجب أن يحتوي العرض المدخل على ما لا يقل عن ثلاث شرائح.

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

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يُعيد تحجيم محتوى الشريحة ليتناسب ويصدّر الشريحة الوحيدة إلى PDF.

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

    // إزالة الشريحة الفارغة التي تم إنشاء العرض الجديد معها.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

المثال التالي يصدر عرضًا إلى PDF، مع وضع ملاحظات المتحدث أسفل كل شريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **إمكانية الوصول ومعايير الامتثال لملفات PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل يتوافق مع [إرشادات قابلية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الكود عملية تحويل من PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:

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
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء تحويلات [PDF إلى HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)، [PDF إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). كما تدعم عمليات تحويل PDF إلى صيغ متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)— أيضًا.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والمخططات والصيغ كشكل واحد. لا تُحفظ عناصر المسار الفردية كمحتوى منفصل وقد تُصنّف كملحقات؛ يتم توفير النص البديل فقط للشكل الكامل.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك iterating عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) مع `true` في فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) و[setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) في فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a و PDF/A1b و PDF/UA، مما يضمن أن مستنداتك تلبي متطلبات إمكانية الوصول والحفظ.

## **موارد إضافية**

- [توثيق Aspose.Slides for Node.js via Java](/slides/ar/nodejs-java/)
- [مرجع API لـ Aspose.Slides for Node.js via Java](https://reference.aspose.com/slides/nodejs-java/)
- [محولات مجانية عبر الإنترنت من Aspose](https://products.aspose.app/slides/conversion)