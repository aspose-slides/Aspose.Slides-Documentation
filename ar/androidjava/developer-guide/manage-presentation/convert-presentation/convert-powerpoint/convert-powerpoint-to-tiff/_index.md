---
title: تحويل PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/androidjava/convert-powerpoint-to-tiff/
keywords: "تحويل عرض PowerPoint، PowerPoint إلى TIFF، PPT إلى TIFF، PPTX إلى TIFF، Java، Aspose.Slides"
description: "تحويل عرض PowerPoint إلى TIFF في Java"

---

**TIFF** (تنسيق ملف الصورة الملصقة) هو تنسيق صورة نقطية بدون فقدان وجودة عالية. يستخدم المحترفون TIFF لأغراض التصميم والتصوير والنشر المكتبي. على سبيل المثال، إذا كنت ترغب في الحفاظ على الطبقات والإعدادات في تصميمك أو صورتك، قد ترغب في حفظ عملك كملف صورة TIFF.

تسمح لك Aspose.Slides بتحويل الشرائح في PowerPoint مباشرة إلى TIFF.

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على [محول PowerPoint إلى ملصق المجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) من Aspose.

{{% /alert %}}

## **تحويل PowerPoint إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) المعروضة من قبل فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. الصور الناتجة عن TIFF تتوافق مع الحجم الافتراضي للشرائح.

يعرض لك هذا الكود Java كيفية تحويل PowerPoint إلى TIFF:

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("presentation.pptx");
try {
    // حفظ العرض التقديمي كـ TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل PowerPoint إلى TIFF بالأبيض والأسود**

في Aspose.Slides 23.10، أضافت Aspose.Slides خاصية جديدة ([BwConversionMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) إلى فئة [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) للسماح لك بتحديد الخوارزمية التي يتم اتباعها عند تحويل شريحة الملونة أو الصورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يتم تطبيقه فقط عندما تكون الخاصية [CompressionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) مُعينة إلى `CCITT4` أو `CCITT3`.

يعرض لك هذا الكود Java كيفية تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود:

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

إذا كنت بحاجة إلى صورة TIFF بأبعاد محددة، يمكنك تحديد الأبعاد المفضلة لديك من خلال الخصائص المتاحة تحت [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/). باستخدام خاصية [ImageSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) على سبيل المثال، يمكنك تعيين حجم للصورة الناتجة.

يعرض لك هذا الكود Java كيفية تحويل PowerPoint إلى صور TIFF بحجم مخصص:

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("presentation.pptx");
try {
    // إنشاء كائن من فئة TiffOptions
    TiffOptions opts = new TiffOptions();
    
    // تعيين نوع الضغط
    // القيم الممكنة هي:
    // Default - تحديد مخطط الضغط الافتراضي (LZW).
    // None - تحديد عدم وجود ضغط.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // العمق - يعتمد على نوع الضغط ولا يمكن تعيينه يدويًا.
    
    // تعيين DPI للصورة
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // تعيين حجم الصورة
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // حفظ العرض التقديمي بتنسيق TIFF بالحجم المحدد
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```


## **تحويل PowerPoint إلى TIFF بتنسيق بكسل صورة مخصص**

باستخدام خاصية [PixelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) تحت فئة [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/)، يمكنك تحديد تنسيق بكسل مفضل لديك للصورة الناتجة بتنسيق TIFF.

يعرض لك هذا الكود Java كيفية تحويل PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * يحتوي ImagePixelFormat على القيم التالية (كما هو مذكور في الوثائق):
     * Format1bppIndexed; // 1 بت لكل بكسل، مفهرس.
     * Format4bppIndexed; // 4 بت لكل بكسل، مفهرس.
     * Format8bppIndexed; // 8 بت لكل بكسل، مفهرس.
     * Format24bppRgb;    // 24 بت لكل بكسل، RGB.
     * Format32bppArgb;   // 32 بت لكل بكسل، ARGB.
     */
    
    // حفظ العرض التقديمي بتنسيق TIFF مع حجم الصورة المحدد
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```