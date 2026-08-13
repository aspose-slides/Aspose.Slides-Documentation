---
title: تحويل عروض PowerPoint إلى TIFF باستخدام Java
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/java/convert-powerpoint-to-tiff/
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
- Java
- Aspose.Slides
description: "تعلم كيف تحول عروض PowerPoint (PPT, PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لـ Java، مع أمثلة على الشيفرة."
---
## **المقدمة**

TIFF (**Tagged Image File Format**) هو صيغة صورة نقطية غير مضغوطة تُستخدم على نطاق واسع، وتُعرف بجودتها الاستثنائية وحفظ التفاصيل الدقيقة للرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون صيغة TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن أن عروضك التقديمية تحتفظ بأقصى قدر من الوضوح البصري.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض تقديمي كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

هذا الكود يوضح كيفية تحويل عرض تقديمي إلى TIFF:

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

طريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) في فئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/) تسمح لك بتحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) مضبوطة على `CCITT4` أو `CCITT3`.

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

هذا الكود يوضح كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

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

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك ضبط القيم المطلوبة باستخدام الطرق المتاحة في [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/). على سبيل المثال، تسمح طريقة [setImageSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) بتحديد حجم الصورة الناتجة.

هذا الكود يوضح كيفية تحويل عرض تقديمي إلى صور TIFF بحجم مخصص:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

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
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **تحويل عرض تقديمي إلى TIFF بتنسيق بكسل مخصص**

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) من فئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/)، يمكنك تحديد تنسيق البكسل المفضل للصورة TIFF الناتجة.

هذا الكود يوضح كيفية تحويل عرض تقديمي إلى صورة TIFF بتنسيق بكسل مخصص:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو مذكور في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مُفهرس.
        Format4bppIndexed - 4 بت لكل بكسل، مُفهرس.
        Format8bppIndexed - 8 بت لكل بكسل، مُفهرس.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */
    
    // حفظ العرض التقديمي كملف TIFF بالتنسيق البكسلي المحدد.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="نصيحة" color="info" %}}
تحقق من [محول PowerPoint إلى ملصق مجاني من Aspose](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل يمكنني تحويل شريحة منفردة بدلاً من عرض PowerPoint كامل إلى TIFF؟

نعم. يتيح Aspose.Slides لك تحويل شرائح فردية من عروض PowerPoint وعروض OpenDocument إلى صور TIFF بشكل منفصل.

### هل هناك حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى صيغة TIFF.

### هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟

لا، TIFF هو صيغة صورة ثابتة. لذلك لا يتم الحفاظ على الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.