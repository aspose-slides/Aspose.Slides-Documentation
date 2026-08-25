---
title: تحويل عروض PowerPoint إلى TIFF في PHP
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/php-java/convert-powerpoint-to-tiff/
keywords:
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى TIFF
- عرض تقديمي إلى TIFF
- شريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- حفظ PPT كـ TIFF
- حفظ PPTX كـ TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- PHP
- Aspose.Slides
description: "تعرف على كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides للغة PHP عبر Java، مع أمثلة على الشيفرة."
---
## **مقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوطة يُستخدم على نطاق واسع، ويُعرف بجودته الاستثنائية والحفاظ الدقيق على الرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن بقاء عروضك التقديمية بأقصى مستوى من الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض تقديمي كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

هذا المثال يوضح كيفية تحويل عرض تقديمي PowerPoint إلى TIFF:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
$presentation = new Presentation("presentation.pptx");
try {
    // حفظ العرض التقديمي كملف TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

طريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/#setBwConversionMode) في فئة [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/) تتيح لك تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/#getCompressionType) مضبوطة على `CCITT4` أو `CCITT3`.

{{% alert color="info" title="ملاحظة" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/#setBwConversionMode) هو إعداد على مستوى التصدير يختار خوارزمية تحويل البكسل للصورة TIFF الكاملة. لتحديد كيف يجب أن يظهر شكل فردي عندما يكون وضع العرض بالأبيض والأسود مفعّلاً، استخدم [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#setBlackWhiteMode). راجع [Control Black-and-White Rendering for Shapes](/slides/ar/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![A presentation slide](slide_black_and_white.png)

هذا المثال يوضح كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك ضبط القيم المطلوبة باستخدام الطرق المتاحة في فئة [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/). على سبيل المثال، طريقة [setImageSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/#getImageSize) تتيح لك تحديد حجم الصورة الناتجة.

هذا المثال يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صور TIFF بحجم مخصص:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // ضبط نوع الضغط.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    أنواع الضغط:
        Default - يحدد مخطط الضغط الافتراضي (LZW).
        None - يعني عدم وجود ضغط.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // العمق يعتمد على نوع الضغط ولا يمكن ضبطه يدويًا.

    // ضبط DPI الصورة.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // ضبط حجم الصورة.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **تحويل عرض تقديمي إلى TIFF بصيغة بكسل مخصصة**

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/#getPixelFormat) من فئة [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/)، يمكنك تحديد صيغة البكسل المفضلة للصورة TIFF الناتجة.

هذا المثال يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صورة TIFF بصيغة بكسل مخصصة:

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو مذكور في الوثائق):
        Format1bppIndexed - بت واحد لكل بكسل، مفهرس.
        Format4bppIndexed - 4 بتات لكل بكسل، مفهرس.
        Format8bppIndexed - 8 بتات لكل بكسل، مفهرس.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */

    // حفظ العرض التقديمي كملف TIFF بالحجم المحدد للصورة.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="نصيحة" color="info" %}}
اكتشف أداة Aspose المجانية لتحويل PowerPoint إلى ملصق عبر الإنترنت: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل شريحة فردية بدلاً من تحويل العرض التقديمي بالكامل إلى TIFF؟**

نعم. تتيح لك Aspose.Slides تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا تفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم حفظ الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذا لا يتم حفظ الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.