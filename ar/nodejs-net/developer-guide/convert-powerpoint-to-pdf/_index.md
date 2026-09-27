---
title: تحويل PowerPoint إلى PDF في Node.js عبر .NET
linktitle: PowerPoint إلى PDF
type: docs
weight: 30
url: /ar/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint إلى PDF
- تحويل PowerPoint إلى PDF
- PPTX إلى PDF
- PPT إلى PDF
- ODP إلى PDF
- حفظ العرض التقديمي كـ PDF
- PDF/A
- PdfOptions
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل عروض PPTX وPPT وODP إلى PDF باستخدام JavaScript مع Aspose.Slides for Node.js عبر .NET، وإنشاء ملفات PDF/A الأرشيفية باستخدام PdfOptions."
---
## **نظرة عامة**

Aspose.Slides for Node.js via .NET يحول عروض PowerPoint وOpenDocument إلى PDF دون الحاجة إلى Microsoft PowerPoint. كل شريحة مرئية تصبح صفحة PDF واحدة بحجم الشريحة نفسه، ويظل النص قابلًا للتحديد والبحث. تُظهر هذه المقالة التحويل الافتراضي وتحويلًا إلى PDF/A باستخدام [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/).

الأمثلة تتوقع وجود عرض تقديمي باسم `sample.pptx` في مجلد المشروع الذي قمت بإعداده في [Installation](/slides/ar/nodejs-net/installation/). يمكن استخدام أي عرض PowerPoint. احفظ كل مثال كملف `.js` في مجلد المشروع وشغله من ذلك المجلد باستخدام `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET لا يمتلك مرجع API خاص به. فهو يعكس API الخاص بـ Aspose.Slides for .NET بأسماء camelCase، لذا روابط API في هذه المقالة تُوجه إلى الفئات والأعضاء المقابلة في [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ar/net/).
{{% /alert %}}

## **تحويل عرض تقديمي إلى PDF**

لتحويل عرض تقديمي إلى PDF، اتبع الخطوات التالية:

1. افتح العرض التقديمي بتمرير مساره إلى المُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/presentation/). نفس الكود يعمل مع ملفات PPTX وPPT وODP.
1. استدعِ طريقة [save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) مع مسار الإخراج و`SaveFormat.Pdf`.
1. استدعِ `dispose` داخل كتلة `finally` لتحرير موارد .NET التي تدعم العرض التقديمي.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

النص البرمجي يكتب `sample.pdf` إلى مجلد المشروع. يستخدم التحويل الإعدادات الافتراضية: كل شريحة غير مخفية تصبح صفحة، وفق ترتيب الشرائح. بدون ترخيص، تُظهر كل صفحة علامة مائية لتقييم الترخيص؛ راجع [Licensing](/slides/ar/nodejs-net/licensing/).

## **تحويل عرض تقديمي إلى PDF/A**

للتحكم في المخرجات، مرّر كائن [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) كالمعامل الثالث في `save`. المثال التالي يضبط الخاصية [compliance](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/compliance/) إلى `PdfCompliance.PdfA2b`، مما يُنتج ملف PDF/A-2b. PDF/A هو المعيار ISO للأرشفة طويلة الأمد: من بين قواعد أخرى، يتطلب تضمين كل خط يستخدمه المستند داخل الملف.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

النص البرمجي يكتب `sample-pdfa.pdf` بنفس الصفحات التي ينتجها التحويل الافتراضي. لتأكيد أن الملف يطابق المعيار، افحصه باستخدام أداة تحقق PDF/A مثل [veraPDF](https://verapdf.org/). قيم أخرى من [PdfCompliance](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfcompliance/) تختار معايير أخرى، مثل `PdfA1b` أو `PdfA2a` أو `PdfUa` لإمكانية الوصول.

## **FAQ**

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

الشرائح المخفية تُتخطى بشكل افتراضي. اضبط خاصية [showHiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/showhiddenslides/) لـ `PdfOptions` إلى `true` ومرّر الخيارات إلى `save`.

**هل يمكنني حماية PDF بكلمة مرور؟**

نعم. اضبط خاصية [password](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/password/) لـ `PdfOptions` قبل استدعاء `save`. ثم يطلب قارئ PDF كلمة المرور قبل فتح الملف.

**هل يمكنني تحويل بعض الشرائح فقط؟**

نعم. مرّر مصفوفة من مواضع الشرائح كمُعامل رابع في `save`. المواضع تبدأ من 1، ويمكن أن يكون المُعامل الثالث `null` إذا لم تحتاج إلى خيارات: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` يكتب PDF يحتوي على الشريحة الأولى والثالثة.

**لماذا يبدو النص مختلفًا عند التحويل على لينكس؟**

Aspose.Slides يمكنه فقط استخدام الخطوط المثبتة على الجهاز الذي يُجري التحويل. عندما يستخدم العرض تقديمي خطًا غير موجود، مثل Calibri على خادم لينكس شائع، يستخدم Aspose.Slides خطًا مثبتًا بدلاً منه، مما قد يغيّر مظهر النص ومكان فواصل الأسطر. قم بتثبيت الخطوط التي تستخدمها عروضك لت obten نفس النتيجة كما على ويندوز.

**هل يمكنني الحصول على PDF كـ Buffer بدلاً من ملف؟**

نعم. `presentation.saveToBuffer(SaveFormat.Pdf)` تُعيد PDF ككائن `Buffer` في Node.js، وهو مناسب عندما ترسل النتيجة في استجابة HTTP. كما يقبل `PdfOptions` كمُعامل ثاني.