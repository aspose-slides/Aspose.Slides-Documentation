---
title: تحويل PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/php-java/convert-powerpoint-to-tiff/
keywords: "تحويل عرض PowerPoint, PowerPoint إلى TIFF, PPT إلى TIFF, PPTX إلى TIFF, Java, Aspose.Slides"
description: "تحويل عرض PowerPoint إلى TIFF "

---

**TIFF** (تنسيق ملف الصورة المتقدمة) هو تنسيق صورة نقطية غير مضغوطة وعالية الجودة. يستخدم المحترفون TIFF لأغراض التصميم والتصوير والنشر المكتبي. على سبيل المثال، إذا كنت ترغب في الحفاظ على الطبقات والإعدادات في تصميمك أو صورتك، فقد ترغب في حفظ عملك كملف صورة TIFF.

تتيح لك Aspose.Slides تحويل الشرائح في PowerPoint مباشرة إلى TIFF.

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) من Aspose.

{{% /alert %}}

## **تحويل PowerPoint إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save-java.lang.String-int-) التي تم توفيرها بواسطة فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint بالكامل إلى TIFF. تتوافق صور TIFF الناتجة مع الحجم الافتراضي للشرائح.

يوضح لك هذا الكود PHP كيفية تحويل PowerPoint إلى TIFF:

```php
// ينشئ كائن Presentation يمثل ملف عرض
  $pres = new Presentation("presentation.pptx");
  try {
    # يحفظ العرض كملف TIFF
    $pres->save("tiff-image.tiff", SaveFormat::Tiff);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل PowerPoint إلى TIFF بالأبيض والأسود**

في Aspose.Slides 23.10، أضافت Aspose.Slides خاصية جديدة ([BwConversionMode](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setBwConversionMode-int-)) إلى فئة [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) للسماح لك بتحديد الخوارزمية التي تتبع عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يتم تطبيقه فقط عندما يتم تعيين خاصية [CompressionType](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setCompressionType-int-) إلى `CCITT4` أو `CCITT3`.

يوضح لك هذا الكود PHP كيفية تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود:

```php
  $tiffOptions = new TiffOptions();
  $tiffOptions->setCompressionType(TiffCompressionTypes.CCITT4);
  $tiffOptions->setBwConversionMode(BlackWhiteConversionMode->Dithering);
  $presentation = new Presentation("sample.pptx");
  try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **تحويل PowerPoint إلى TIFF بحجم مخصص**

إذا كنت بحاجة إلى صورة TIFF بأبعاد محددة، يمكنك تحديد الأرقام المفضلة لديك من خلال الخصائص المتاحة ضمن [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/). باستخدام خاصية [ImageSize](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) على سبيل المثال، يمكنك تعيين حجم للصورة الناتجة.

يوضح لك هذا الكود PHP كيفية تحويل PowerPoint إلى صور TIFF بحجم مخصص:

```php
// ينشئ كائن Presentation يمثل ملف عرض
  $pres = new Presentation("presentation.pptx");
  try {
    # ينشئ كائن TiffOptions
    $opts = new TiffOptions();
    # يحدد نوع الضغط
    # القيم المتاحة هي:
    # Default - يحدد نظام الضغط الافتراضي (LZW).
    # None - يحدد عدم الضغط.
    # CCITT3
    # CCITT4
    # LZW
    # RLE
    $opts->setCompressionType(TiffCompressionTypes.Default);
    # العمق – يعتمد على نوع الضغط ولا يمكن تعيينه يدويًا.
    # يحدد DPI للصورة
    $opts->setDpiX(200);
    $opts->setDpiY(100);
    # يحدد حجم الصورة
    $opts->setImageSize(new Java("java.awt.Dimension", 1728, 1078));
    $options = $opts->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # يحفظ العرض إلى TIFF بالحجم المحدد
    $pres->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل PowerPoint إلى TIFF بتنسيق بكسل صورة مخصص**

باستخدام خاصية [PixelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setPixelFormat-int-) تحت فئة [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) ، يمكنك تحديد تنسيق البكسل المفضل لديك للصورة TIFF الناتجة.

يوضح لك هذا الكود PHP كيفية تحويل PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```php
// ينشئ كائن Presentation يمثل ملف عرض
  $pres = new Presentation("presentation.pptx");
  try {
    $options = new TiffOptions();
    $options->setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /* تحتوي ImagePixelFormat على القيم التالية (كما هو مذكور في الوثائق):
    Format1bppIndexed; // 1 بت لكل بكسل، مؤرخ.
    Format4bppIndexed; // 4 بت لكل بكسل، مؤرخ.
    Format8bppIndexed; // 8 بت لكل بكسل، مؤرخ.
    Format24bppRgb;    // 24 بت لكل بكسل، RGB.
    Format32bppArgb;   // 32 بت لكل بكسل، ARGB.
     */
    # يحفظ العرض إلى TIFF بحجم الصورة المحدد
    $pres->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```