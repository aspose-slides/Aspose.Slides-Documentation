---
title: تحويل عروض PowerPoint التقديمية إلى وضع Handout باستخدام PHP
linktitle: وضع Handout
type: docs
weight: 150
url: /ar/php-java/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع Handout
- مستند
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحويل العروض إلى مستندات Handout باستخدام PHP. ضبط عدد الشرائح لكل صفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides للـ PHP، مع مثال شفرة. جرّبها مجانًا."
---
## **مقدمة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى تنسيقات مختلفة، بما في ذلك إنشاء مستندات للطبعة في وضع Handout. يتيح لك هذا الوضع تكوين كيفية ظهور شرائح متعددة على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق ضبط طريقة `setSlidesLayoutOptions` في فئات [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/htmloptions/)، و[TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/).

لتعيين أبعاد صفحة المستند وتوجيهها قبل التصدير، راجع [Notes Page Size](/slides/ar/php-java/notes-size/).

## **تصدير وضع Handout**

لتكوين وضع Handout، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الكود يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع Handout.

```php
// تحميل عرض تقديمي.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقيًا
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // طباعة أرقام الشرائح
$slidesLayoutOptions->setPrintFrameSlide(true);                      // طباعة إطار حول الشرائح
$slidesLayoutOptions->setPrintComments(false);                       // بدون تعليقات

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
تذكر أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض تنسيقات الإخراج، مثل PDF وHTML وTIFF، وعند التحويل إلى صور.
{{% /alert %}} 

## **الأسئلة المتكررة**

**ما هو الحد الأقصى لعدد صور مصغرة للشرائح في الصفحة في وضع Handout؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/php-java/aspose.slides/handouttype/) حتى 9 صور مصغرة لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب الصور المصغرة بدقة من خلال فئة [HandoutType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/handouttype/)؛ لا يتم دعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في مخرجات Handout؟**

نعم. فعّل الشرائح المخفية باستخدام طريقة `setShowHiddenSlides` في إعدادات التصدير للصيغة الهدف، مثل [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/).