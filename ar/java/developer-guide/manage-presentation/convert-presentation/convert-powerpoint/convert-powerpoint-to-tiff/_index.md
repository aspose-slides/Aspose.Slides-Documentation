---
title: تحويل PowerPoint إلى TIFF
type: docs
weight: 90
url: /java/convert-powerpoint-to-tiff/
keywords: "تحويل عرض PowerPoint, PowerPoint إلى TIFF, PPT إلى TIFF, PPTX إلى TIFF, Java, Aspose.Slides"
description: "تحويل عرض PowerPoint إلى TIFF في Java"

---

**TIFF** (تنسيق ملفات الصور الموسومة) هو تنسيق صورة نقطية وغير ضائع وعالي الجودة. يستخدم المحترفون TIFF لأغراض التصميم والتصوير والنشر المكتبي. على سبيل المثال، إذا كنت ترغب في الحفاظ على الطبقات والإعدادات في تصميمك أو صورتك، قد ترغب في حفظ عملك كملف صورة TIFF.

يسمح لك Aspose.Slides بتحويل الشرائح في PowerPoint مباشرة إلى TIFF.

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على [محول PowerPoint إلى ملصق مجاني من Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **تحويل PowerPoint إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) المكشوفة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. الصور الناتجة بتنسيق TIFF تتوافق مع الحجم الافتراضي للشرائح.

يوضح لك هذا الكود بلغة Java كيفية تحويل PowerPoint إلى TIFF:

```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("presentation.pptx");
try {
    // يحفظ العرض التقديمي كـ TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل PowerPoint إلى TIFF بالأبيض والأسود**

في Aspose.Slides 23.10، أضاف Aspose.Slides خاصية جديدة ([BwConversionMode](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) إلى فئة [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/) للسماح لك بتحديد الخوارزمية التي يتم اتباعها عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يتم تطبيقه فقط عندما يتم تعيين خاصية [CompressionType](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) إلى `CCITT4` أو `CCITT3`.

يوضح لك هذا الكود بلغة Java كيفية تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود:

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تحويل PowerPoint إلى TIFF بحجم مخصص**

إذا كنت بحاجة إلى صورة TIFF بأبعاد محددة، يمكنك تحديد الأرقام المفضلة لديك من خلال الخصائص المقدمة تحت [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/). باستخدام خاصية [ImageSize](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) على سبيل المثال، يمكنك تعيين حجم للصورة الناتجة.

يوضح لك هذا الكود بلغة Java كيفية تحويل PowerPoint إلى صور TIFF بحجم مخصص:

```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("presentation.pptx");
try {
    // ينشئ كائن TiffOptions
    TiffOptions opts = new TiffOptions();
    
    // يحدد نوع الضغط
    // القيم الممكنة هي:
    // Default - يحدد مخطط الضغط الافتراضي (LZW).
    // None - يحدد عدم وجود ضغط.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // العمق – يعتمد على نوع الضغط ولا يمكن تعيينه يدويًا.
    
    // يحدد DPI للصورة
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // يحدد حجم الصورة
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // يحفظ العرض التقديمي بتنسيق TIFF بالحجم المحدد
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```

## **تحويل PowerPoint إلى TIFF بتنسيق بكسل صورة مخصص**

باستخدام خاصية [PixelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) تحت فئة [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/)، يمكنك تحديد تنسيق البكسل المفضل لديك للصورة الناتجة بتنسيق TIFF.

يوضح لك هذا الكود بلغة Java كيفية تحويل PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * يحتوي ImagePixelFormat على القيم التالية (كما هو موضح في الوثائق):
     * Format1bppIndexed; // 1 بت لكل بكسل، مؤشّر.
     * Format4bppIndexed; // 4 بت لكل بكسل، مؤشّر.
     * Format8bppIndexed; // 8 بت لكل بكسل، مؤشّر.
     * Format24bppRgb;    // 24 بت لكل بكسل، RGB.
     * Format32bppArgb;   // 32 بت لكل بكسل، ARGB.
     */
    
    // يحفظ العرض التقديمي بتنسيق TIFF بحجم الصورة المحدد
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```