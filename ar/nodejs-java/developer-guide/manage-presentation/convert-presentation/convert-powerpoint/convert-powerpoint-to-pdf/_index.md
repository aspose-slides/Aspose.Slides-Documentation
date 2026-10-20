---
title: تحويل PPT و PPTX إلى PDF في JavaScript [متضمنة ميزات متقدمة]
linktitle: PowerPoint إلى PDF
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

تحويل عروض PowerPoint وOpenDocument (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF باستخدام JavaScript يوفّر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة وحفظ تخطيط وتنسيق العرض. يشرح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، اختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالصيغات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [العرض](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [حفظ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). فئة [العرض](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) تُظهر طريقة [حفظ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) التي تُستَخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides لـ Node.js عبر Java يدرج معلومات واجهة برمجة التطبيقات ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، تقوم Aspose.Slides بملء حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على شكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

Aspose.Slides يتيح لك:

* تحويل العروض بالكامل إلى PDF
* تحويل شرائح محددة من العرض إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تطابق العروض الأصلية بدقة. تُرَسم العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، تحاول Aspose.Slides تحويل العرض المزوَّد إلى PDF باستخدام إعدادات مثلى بأعلى مستويات الجودة.

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
Aspose يقدم محولًا مجانيًا عبر الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية التحويل من العرض إلى PDF. يمكنك تجربة هذا المحول للحصول على تنفيذ حي للإجراء الموضح هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—تتيح لك تخصيص PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، تحديد كيفية معالجة ملفات الميتا، ضبط مستوى ضغط النص، تكوين DPI للصور، والمزيد.

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

### **اختيار ضغط الصورة تلقائيًا**

عند احتواء عرض على العديد من الصور أو لقطات الشاشة، يمكن لتقليل حجم PDF المُصدَّر أن يسهل إرساله بالبريد أو تحميله. استدعِ [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) مع `true` لاختيار خوارزمية الضغط الأنسب لكل صورة تلقائيًا أثناء تصدير PDF.

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

تختار هذه الخيار خوارزمية ضغط لكل صورة. خفض القيمة المرسلة إلى [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) يقلل من جودة صورة JPEG، في حين أن خفض القيمة المرسلة إلى [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) يسمح بخفض دقة الصور، مما قد يقلل من التفاصيل. تمكين اختيار الضغط التلقائي لا يقلل من أي من هذين الإعدادين بحد ذاته.

يتطلب اختيار خوارزميات ضغط الصور وقت معالجة إضافي وذاكرة. يعتمد تقليل الحجم على صور العرض وإعدادات التصدير؛ لا يُضمن تقليل ثابت لكل عرض.

### **الحفاظ على ملفات OLE المضمّنة كمرفقات PDF**

إذا كان العرض يحتوي على كتاب عمل Excel مضمّن، قد ترغب في أن يتمكن متلقي PDF من الوصول إلى بيانات الكتاب بالإضافة إلى مشاهدة الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) مع `true` للحفاظ على ملفات OLE المضمّنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يُرَسم صورة معاينة أو أيقونة كائن OLE على صفحة PDF، لكن ملفه المضمّن لا يُضمَّن كمرفق. ضبط الخيار على `true` يضيف بيانات الملف كذلك. تظل المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمتلقين فتح أو حفظ الملف المضمّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

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

1. افتح PDF المُصدَّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **المرفقات** في العارض وحدد موقع كتاب العمل المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يمنع الملفات المضمَّنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى، بما في ذلك كتب عمل Excel. هذه متطلبات المعايير، غير أنها ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال الإعداد الافتراضي للامتثال للـ PDF ولا يُظهر تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

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

المثال التالي يصدر عرضًا إلى PDF يتطلب كلمة المرور `password` للفتح. تصاريح الوصول تسمح بالطباعة، بما فيها الطباعة بجودة عالية.

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

### **اكتشاف استبدال الخطوط**

توفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) تحت فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) تمكّنك من اكتشاف استبدال الخطوط أثناء عملية التحويل من العرض إلى PDF.

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
لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [استبدال الخط](/slides/ar/nodejs-java/font-substitution/).
{{% /alert %}} 

### **معالجة الخطوط بدون نوع مائل مخصص**

يمكن للعرض تطبيق تنسيق غامق للنص حتى عندما لا يمتلك الخط نوعًا مائلًا مخصصًا. لا يزال النص يظهر غامقًا عبر التسمك الاصطناعي، الذي يزيد من سماكة الأحرف العادية. عندما يبدو هذا النص ثقيلاً جدًا أو يختلف عن الشكل المقصود في PDF، جرّب استدعاء [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) مع `true`. هذا الخيار يرسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يُحسّن مظهره لبعض الخطوط. قيمته الافتراضية `false`.

العرض التجريبي يحتوي على صندوقي نص: أحدهما بنص عادي والآخر بنص غامق لنفس الخط الذي لا يمتلك نوعًا مائلًا مخصصًا. المثال التالي يحمل العرض، يُفعِّل تحويل الأنماط الخطية غير المدعومة إلى نقطية، ثم يصدره إلى PDF:

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

المعاينات التالية تُظهر النتيجة مع الخيار معطَّل ومع الخيار مفعَّل. في هذا المثال، يصبح النص الغامق ذو خطوط أثقل عندما يكون الخيار معطَّل. مع تفعيل الخيار، تصبح خطوطه أخف؛ يبقى النص العادي دون تغيير. قارن النتائج قبل اختيار الإعداد المناسب لعرضك.

| الخيار معطَّل (`false`، الافتراضي) | الخيار مفعَّل (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

في هذا المثال، يُحوِّل تفعيل الخيار النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حوافه أطرًا أكثر نعومة عند تكبير 800 %. يظل النص العادي قابلًا للبحث. عندما يكون الخيار معطَّلًا، يظل كلا السلسلتين نصًا.

هذا الخيار يُحوِّل النص المُنسَّق كغامق إلى نقطية عندما لا يمتلك الخط نوعًا مائلًا مخصصًا. [استبدال الخط](/slides/ar/nodejs-java/font-substitution/) يختار بدلاً من ذلك خطًا آخر عندما يكون الخط الأصلي غير متوفر.

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

المثال التالي يصدر الشرائح 1 و3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تُحسب من الواحد، ويجب أن يحتوي العرض المُدخَل على ثلاثة شرائح على الأقل على الأقل.

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

المثال التالي ينسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يُقَّمِم محتوى الشريحة ليتناسب ويصدر الشريحة الوحيدة إلى PDF.

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

المثال التالي يصدر عرضًا إلى PDF، موضعًا ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **معايير إمكانية الوصول والامتثال لـ PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل يتوافق مع [إرشادات محتوى الويب لإمكانية الوصول (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يعرض هذا الشيفرة عملية تحويل من PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء تحويلات [PDF إلى HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)، [PDF إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). تدعم عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—أيضًا.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt، المخططات، والمعادلات ككائن واحد. لا تُحفظ عناصر المسار الفردية كمحتوى منفصل وقد تُصنَّف كقطع فنية؛ يُقدَّم النص البديل فقط للكائن الكامل.

## **الأسئلة الشائعة**

**هل يمكنني تحويل ملفات PowerPoint متعددة إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لملفات PPT أو PPTX المتعددة إلى PDF. يمكنك التكرار عبر ملفاتك وتطبيق عملية التحويل برمجياً.

**هل من الممكن حماية PDF المحول بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) مع `true` في فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صورة عالية في PDF؟**

نعم، يمكنك التحكم بجودة الصورة باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) و[setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) في فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تفي بمتطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ Node.js عبر Java](/slides/ar/nodejs-java/)
- [مرجع API لـ Aspose.Slides لـ Node.js عبر Java](https://reference.aspose.com/slides/nodejs-java/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)