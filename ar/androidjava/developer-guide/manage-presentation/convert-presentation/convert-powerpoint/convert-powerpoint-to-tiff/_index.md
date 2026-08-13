---
title: تحويل عروض PowerPoint إلى TIFF على Android
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/androidjava/convert-powerpoint-to-tiff/
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
- حفظ PPT كـ TIFF
- حفظ PPTX كـ TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides للأندرويد، مع أمثلة كود Java."
---
## **المقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صور نقطية مضغوط بدون فقدان يُستخدم على نطاق واسع، معروف بجودته الاستثنائية وحفظه التفصيلي للرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) بسهولة إلى صور TIFF عالية الجودة، مما يضمن أن عروضك التقديمية تحتفظ بأقصى درجات الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

يعرض هذا الشيفرة كيفية تحويل عرض PowerPoint إلى TIFF:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // حفظ العرض التقديمي كملف TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

تسمح الطريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) في الفئة [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/) بتحديد الخوارزمية المستخدمة عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) مضبوطة على `CCITT4` أو `CCITT3`.

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

يعرض هذا الشيفرة كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

النتيجة:

![TIFF بالأبيض والأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الطُرُق المتوفرة في فئة [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/). على سبيل المثال، تسمح طريقة [setImageSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) بتحديد حجم الصورة الناتجة.

يعرض هذا الشيفرة كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // تحديد نوع الضغط.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    أنواع الضغط:
        Default - يحدد مخطط الضغط الافتراضي (LZW).
        None - يحدد عدم وجود ضغط.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // يعتمد العمق على نوع الضغط ولا يمكن تعيينه يدويًا.

    // تحديد DPI للصورة.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تحديد حجم الصورة.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **تحويل عرض تقديمي إلى TIFF بتنسيق بكسل مخصص للصورة**

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ضمن فئة [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/)، يمكنك تحديد تنسيق البكسل المفضل للصورة TIFF الناتجة.

يعرض هذا الشيفرة كيفية تحويل عرض PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    يحتوي ImagePixelFormat على القيم التالية (كما هو مذكور في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مفهرس.
        Format4bppIndexed - 4 بت لكل بكسل، مفهرس.
        Format8bppIndexed - 8 بت لكل بكسل، مفهرس.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */
    
    // حفظ العرض التقديمي كملف TIFF بالتنسيق البكسلي المحدد.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
تحقق من أداة تحويل PowerPoint إلى ملصق المجانية من Aspose عبر الرابط [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل يمكنني تحويل شريحة واحدة بدلاً من عرض PowerPoint كامل إلى TIFF؟

نعم. يتيح لك Aspose.Slides تحويل الشرائح الفردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

### هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

### هل يتم حفظ الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟

لا، TIFF هو تنسيق صورة ثابت. لذلك، لا يتم حفظ الرسوم المتحركة وتأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.