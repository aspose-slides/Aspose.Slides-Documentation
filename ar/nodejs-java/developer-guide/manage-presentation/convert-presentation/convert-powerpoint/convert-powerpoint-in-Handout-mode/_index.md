---
title: تحويل العروض التقديمية في وضع النشرة في JavaScript
type: docs
weight: 150
url: /ar/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- وضع النشرة
- نشرة
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل العروض التقديمية في وضع النشرة في JavaScript"
---

## **تصدير وضع النشرة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء نشرات للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تفعيل هذا الوضع عن طريق ضبط طريقة `setSlidesLayoutOptions` في فئات [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/), و[TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/).

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح الموضوعة على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.
```js
// تحميل عرض تقديمي.
let presentation = new asposeSlides.Presentation("sample.pptx");

// تحديد خيارات التصدير.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقياً
slidesLayoutOptions.setPrintSlideNumbers(true);                                // طباعة أرقام الشرائح
slidesLayoutOptions.setPrintFrameSlide(true);                                  // طباعة إطار حول الشرائح
slidesLayoutOptions.setPrintComments(false);                                   // بدون تعليقات

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// تصدير العرض التقديمي إلى PDF مع التخطيط المحدد.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="warning" %}} 
ضع في اعتبارك أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF، HTML، TIFF، وعند العرض كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد صور الشرائح المصغرة لكل صفحة في وضع النشرة؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) حتى 9 صور مصغرة لكل صفحة بترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب الصور المصغرة بدقة بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/); لا يدعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج النشرة؟**

نعم. استخدم طريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/).