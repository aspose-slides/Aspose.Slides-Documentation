---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات في JavaScript
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PDF
- العرض التقديمي إلى PDF
- الشريحة إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- حفظ العرض التقديمي كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- ملاحظات المتحدث
- PDF مع الملاحظات
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل صيغ PPT و PPTX إلى PDF مع الملاحظات في JavaScript باستخدام Aspose.Slides لـ Node.js. الحفاظ على التخطيطات وملاحظات المتحدث لعروض تقديمية احترافية."
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى تنسيق PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيتناول هذا الدليل الخطوات اللازمة ويقدم أمثلة على الشيفرة لمساعدتك على إنجاز هذه المهمة بكفاءة. بحلول نهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

لتحديد أبعاد واتجاه صفحة الملاحظات قبل التصدير، راجع [Notes Page Size](/slides/ar/nodejs-java/notes-size/).

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `save` في الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم ببساطة بتحميل العرض، وتكوين خيارات التخطيط باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كملف PDF. المقتطف البرمجي التالي يوضح كيفية تحويل عرض تجريبي إلى PDF في عرض شريحة الملاحظات.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// تكوين خيارات PDF لتصيير ملاحظات المتحدث.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // تصيير ملاحظات المتحدث أسفل الشريحة.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// حفظ العرض التقديمي كملف PDF مع ملاحظات المتحدث.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
قد ترغب في تجربة أداة Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ar/conversion) على الإنترنت.
{{% /alert %}}