---
title: تحويل عروض PowerPoint التقديمية إلى وضع Handout باستخدام JavaScript
linktitle: وضع Handout
type: docs
weight: 150
url: /ar/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع Handout
- ملخص
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل العروض التقديمية إلى ملخصات. ضبط عدد الشرائح لكل صفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides لـ Node.js، مع مثال على الشيفرة. جرّبه مجانًا."
---
## **مقدمة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء ملخصات للطباعة في وضع Handout. يتيح لك هذا الوضع تكوين كيفية ظهور شرائح متعددة على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تفعيل هذا الوضع عن طريق تعيين طريقة `setSlidesLayoutOptions` في الفئات [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/), و[TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/).

## **تصدير وضع Handout**

لتكوين وضع Handout، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح الموضوعة على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع Handout.

```js
// تحميل عرض تقديمي.
let presentation = new asposeSlides.Presentation("sample.pptx");

// تعيين خيارات التصدير.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقيًا
slidesLayoutOptions.setPrintSlideNumbers(true);                                // طباعة أرقام الشرائح
slidesLayoutOptions.setPrintFrameSlide(true);                                  // طباعة إطار حول الشرائح
slidesLayoutOptions.setPrintComments(false);                                   // لا توجد تعليقات

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// تصدير العرض التقديمي إلى PDF مع التخطيط المختار.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
تذكر أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور. 
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد صور الشرائح المصغرة لكل صفحة في وضع Handout؟**

تدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/handouttype/) حتى 9 صور مصغرة للشرائح لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب الصور المصغرة بدقة بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/handouttype/)؛ ولا يتم دعم تخطيطات عشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج Handout؟**

نعم. استخدم طريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/).