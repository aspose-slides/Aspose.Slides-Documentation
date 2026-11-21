---
title: تحويل عروض PowerPoint إلى وضع Handout باستخدام JavaScript
linktitle: وضع Handout
type: docs
weight: 150
url: /ar/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع handout
- handout
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل العروض التقديمية إلى كتيبات. ضبط عدد الشرائح في الصفحة، الاحتفاظ بالملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides لـ Node.js، مع مثال على الشيفرة. جرّبه مجانًا."
---
## **المقدمة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء كتيبات للطباعة في وضع Handout. يسمح لك هذا الوضع بتكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات والفعاليات الأخرى. يمكنك تمكين هذا الوضع عن طريق تعيين طريقة `setSlidesLayoutOptions` في فئات [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/), و[TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/).

لتحديد أبعاد واتجاه صفحة الكتيب قبل التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/nodejs-java/notes-size/).

## **تصدير وضع الكتيب**

لتكوين وضع Handout، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح الموضوعة على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع Handout.

```js
const asposeSlides = require("aspose.slides.via.java");

// تحميل عرض تقديمي.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقياً
slidesLayoutOptions.setPrintSlideNumbers(true);                                // طباعة أرقام الشرائح
slidesLayoutOptions.setPrintFrameSlide(true);                                  // طباعة إطار حول الشرائح
slidesLayoutOptions.setPrintComments(false);                                   // لا تعليقات

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
تذكّر أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد صور الشرائح المصغرة في الصفحة في وضع Handout؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/handouttype/) حتى 9 صور مصغرة لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب الصور المصغرة بدقة بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/handouttype/)، ولا يتم دعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج الـ Handout؟**

نعم. استخدم طريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/).