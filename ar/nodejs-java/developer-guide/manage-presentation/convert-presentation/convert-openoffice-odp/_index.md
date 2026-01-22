---
title: تحويل عروض OpenDocument في JavaScript
linktitle: تحويل OpenDocument
type: docs
weight: 10
url: /ar/nodejs-java/convert-openoffice-odp/
keywords:
- تحويل ODP
- ODP إلى صورة
- ODP إلى GIF
- ODP إلى HTML
- ODP إلى JPG
- ODP إلى MD
- ODP إلى PDF
- ODP إلى PNG
- ODP إلى PPT
- ODP إلى PPTX
- ODP إلى TIFF
- ODP إلى فيديو
- ODP إلى Word
- ODP إلى XPS
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ل Node.js يتيح لك تحويل ODP إلى PDF و HTML وتنسيقات الصور بسهولة. عزّز تطبيقاتك بتحويل عروض تقديمية سريع ودقيق."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) يسمح لك بتحويل عروض OpenDocument (ODP) إلى صيغ متعددة (HTML ، PDF ، TIFF ، SWF ، XPS ، إلخ). واجهة برمجة التطبيقات المستخدمة لتحويل ملفات ODP إلى صيغ مستندات أخرى هي نفسها المستخدمة لعمليات تحويل PowerPoint (PPT و PPTX).

على سبيل المثال ، إذا كنت بحاجة إلى تحويل عرض ODP إلى PDF ، يمكنك القيام بذلك كما يلي:
```js
let presentation = null;
try {
  presentation = new aspose.slides.Presentation("presentation.odp");
  presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **الأسئلة الشائعة**

**ماذا لو تغير تنسيق ملف ODP بعد التحويل؟**

تستخدم ODP و PowerPoint نماذج عرض مختلفة ، وبعض العناصر — مثل الجداول أو الخطوط المخصصة أو أنماط التعبئة — قد لا يتم عرضها بنفس الشكل تمامًا. يُنصح بمراجعة الناتج وتعديل التخطيط أو التنسيق في الكود إذا لزم الأمر.

**هل أحتاج إلى تثبيت OpenOffice أو LibreOffice لاستخدام تحويل ODP؟**

لا ، Aspose.Slides مكتبة مستقلة ولا تتطلب تثبيت OpenOffice أو LibreOffice على نظامك.

**هل يمكنني تخصيص صيغة الإخراج أثناء تحويل ODP (مثل تعيين خيارات PDF)؟**

نعم ، يوفر Aspose.Slides خيارات غنية لتخصيص الإخراج. على سبيل المثال ، عند الحفظ إلى PDF ، يمكنك التحكم في الضغط وجودة الصورة وعرض النص والمزيد عبر فئة [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**هل Aspose.Slides مناسب للمعالجة على الخادم أو السحابة لـ ODP؟**

بالطبع. تم تصميم Aspose.Slides للعمل في بيئات سطح المكتب والخادم على حد سواء ، بما في ذلك المنصات السحابية مثل Azure و AWS وحاويات Docker ، دون أي تبعيات واجهة مستخدم.