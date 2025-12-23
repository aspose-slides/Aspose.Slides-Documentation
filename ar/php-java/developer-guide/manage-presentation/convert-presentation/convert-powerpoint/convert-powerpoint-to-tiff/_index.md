---
title: تحويل عروض PowerPoint إلى TIFF في PHP
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/php-java/convert-powerpoint-to-tiff/
keywords:
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى TIFF
- العرض التقديمي إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- حفظ PPT ك TIFF
- حفظ PPTX ك TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- PHP
- Aspose.Slides
description: "تعرف على كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لـ PHP عبر Java، مع أمثلة على الشفرة."
---

## **نظرة عامة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوط يُستخدم على نطاق واسع بفضل جودته الاستثنائية والحفاظ المفصل على الرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) بسهولة مباشرةً إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأعلى مستوى من الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

هذا المثال يوضح كيفية تحويل عرض PowerPoint إلى TIFF:
```php
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، وغيرها).
$presentation = new Presentation("presentation.pptx");
try {
    // حفظ العرض التقديمي كملف TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```


## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

طريقة [setBwConversionMode](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setBwConversionMode) في فئة [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) تتيح لك تحديد الخوارزمية المستخدمة عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getCompressionType) مضبوطة على `CCITT4` أو `CCITT3`.

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

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

![TIFF بالأبيض والأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت بحاجة إلى صورة TIFF بأبعاد معينة، يمكنك ضبط القيم المطلوبة باستخدام الطرق المتاحة في فئة [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/). على سبيل المثال، تسمح لك طريقة [setImageSize](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getImageSize) بتحديد حجم الصورة الناتجة.

هذا المثال يوضح كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:
```php
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT, PPTX, ODP, إلخ).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // تحديد نوع الضغط.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    أنماط الضغط:
        Default - يحدد مخطط الضغط الافتراضي (LZW).
        None - يحدد عدم وجود ضغط.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // يعتمد العمق على نوع الضغط ولا يمكن تعيينه يدويًا.

    // تحديد DPI الصورة.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // تحديد حجم الصورة.
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

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getPixelFormat) من فئة [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/)، يمكنك تحديد صيغة البكسل المفضلة للصورة TIFF الناتجة.

هذا المثال يوضح كيفية تحويل عرض PowerPoint إلى صورة TIFF بصيغة بكسل مخصصة:
```php
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو موضح في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مفهرسة.
        Format4bppIndexed - 4 بت لكل بكسل، مفهرسة.
        Format8bppIndexed - 8 بت لكل بكسل، مفهرسة.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */

    // حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="نصيحة" color="primary" %}}

تحقق من أداة Aspose المجانية لتحويل PowerPoint إلى ملصق: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **الأسئلة المتداولة**

**هل يمكنني تحويل شريحة فردية بدلاً من تحويل العرض التقديمي بالكامل إلى TIFF؟**

نعم. تسمح لك Aspose.Slides بتحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا تفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم حفظ الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا يتم حفظ الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطة ثابتة فقط من كل شريحة.