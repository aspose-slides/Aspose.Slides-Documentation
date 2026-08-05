---
title: تحويل عروض PowerPoint التقديمية إلى وضع النشرة باستخدام PHP
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/php-java/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحويل العروض التقديمية إلى نشرات باستخدام PHP. ضبط عدد الشرائح لكل صفحة، الاحتفاظ بالملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides لـ PHP، مع كود مثال. جرّبه مجانًا."
---
## **المقدمة**

Aspose.Slides توفر القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء نسخ مطبوعة في وضع النشرة. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق تعيين طريقة `setSlidesLayoutOptions` في فئات [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/htmloptions/)، و[TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/).

## **تصدير وضع النشرة**

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/handoutlayoutingoptions/)، الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معلمات العرض.

أدناه مثال على الكود يُظهر كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.

```php
// تحميل عرض تقديمي.
$presentation = new Presentation("sample.pptx");

// تعيين خيارات التصدير.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقيًا
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // طباعة أرقام الشرائح
$slidesLayoutOptions->setPrintFrameSlide(true);                      // طباعة إطار حول الشرائح
$slidesLayoutOptions->setPrintComments(false);                       // لا تعليقات

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// تصدير العرض التقديمي إلى PDF بالتنسيق المختار.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
ضع في الاعتبار أن طريقة `setSlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF، HTML، TIFF، وعند العرض كصور.
{{% /alert %}} 

## **الأسئلة المتكررة**

**ما هو الحد الأقصى لعدد مصغرات الشرائح لكل صفحة في وضع النشرة؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/php-java/aspose.slides/handouttype/) حتى 9 مصغرات لكل صفحة بترتيب أفقي أو رأسي: 1، 2، 3، 4 (أفقي/رأسي)، 6 (أفقي/رأسي)، و9 (أفقي/رأسي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بدقة بواسطة فئة [HandoutType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/handouttype/); لا تُدعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في مخرجات النشرة؟**

نعم. تمكين الشرائح المخفية باستخدام طريقة `setShowHiddenSlides` في إعدادات التصدير لصيغة الهدف، مثل [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/).