---
title: تحويل عروض PowerPoint في وضع النشرة باستخدام PHP
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحويل العروض التقديمية إلى نشرات باستخدام PHP. تعيين عدد الشرائح لكل صفحة، الاحتفاظ بالملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides for PHP، مع مثال على الشيفرة. جرّبه مجانًا."
---

## **تصدير وضع النشرة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى تنسيقات مختلفة، بما في ذلك إنشاء نشرة للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الأحداث. يمكنك تمكين هذا الوضع عن طريق ضبط طريقة `setSlidesLayoutOptions` في الفئات [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/), و[TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/).

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/handoutlayoutingoptions/) الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.
```php
// تحميل عرض تقديمي.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقياً
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // طباعة أرقام الشرائح
$slidesLayoutOptions->setPrintFrameSlide(true);                      // طباعة إطار حول الشرائح
$slidesLayoutOptions->setPrintComments(false);                       // لا تعليقات

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```


{{% alert color="warning" %}} 
ضع في اعتبارك أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض تنسيقات الإخراج، مثل PDF وHTML وTIFF، وعند العرض كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد المصغرات الشرائح في الصفحة في وضع النشرة؟**

يدعم Aspose.Slides [presets](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) حتى 9 مصغرات في الصفحة مع ترتيب أفقي أو عمودي: 1, 2, 3, 4 (أفقي/عمودي), 6 (أفقي/عمودي) و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح في الصفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بدقة من قبل فئة [HandoutType](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/)؛ ولا يتم دعم تخطيطات عشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج النشرة؟**

نعم. قم بتمكين الشرائح المخفية باستخدام طريقة `setShowHiddenSlides` في إعدادات التصدير للتنسيق المستهدف، مثل [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/).