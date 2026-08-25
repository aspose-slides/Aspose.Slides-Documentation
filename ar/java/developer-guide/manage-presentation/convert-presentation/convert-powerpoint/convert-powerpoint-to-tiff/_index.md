---
title: تحويل عروض PowerPoint إلى TIFF في Java
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/java/convert-powerpoint-to-tiff/
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
- Java
- Aspose.Slides
description: "تعرف على كيفية تحويل عروض PowerPoint (PPT, PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides للغة Java، مع أمثلة على الشيفرة."
---
## **المقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صور نقطية غير ضائع يُستخدم على نطاق واسع، يُعرف بجودته الاستثنائية وحفظه التفصيلي للرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT, PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن بقاء عروضك التقديمية بأقصى درجات الوضوح البصري.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) المتوفرة في فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض تقديمي كامل إلى TIFF. الصور الناتجة تتوافق مع حجم الشريحة الافتراضي.

هذا الكود يوضح كيفية تحويل عرض تقديمي PowerPoint إلى TIFF:

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

تتيح الطريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) في فئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/) تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) مضبوطة على `CCITT4` أو `CCITT3`.

{{% alert color="info" title="ملاحظة" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) هو إعداد على مستوى التصدير يحدد خوارزمية تحويل البكسل للصورة الكاملة بصيغة TIFF. لتعريف كيفية ظهور شكل فردي عندما يكون وضع العرض بالأبيض والأسود مفعّلًا، استخدم [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). راجع [Control Black-and-White Rendering for Shapes](/slides/ar/java/shape-formatting/#control-black-and-white-rendering-for-shapes) للأمثلة.
{{% /alert %}}

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

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الطرق المتوفرة في فئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/). على سبيل المثال، تسمح طريقة [setImageSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) بتحديد حجم الصورة الناتجة.

هذا الكود يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صور TIFF بحجم مخصص:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // تعيين نوع الضغط.
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

    // العمق يعتمد على نوع الضغط ولا يمكن تعيينه يدويًا.

    // تعيين DPI للصورة.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تعيين حجم الصورة.
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

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) من فئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/)، يمكنك تحديد تنسيق البكسل المفضل للصور الناتجة بصيغة TIFF.

هذا الكود يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat يحتوي على القيم التالية (حسب الوثائق):
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

{{% alert title="نصيحة" color="info" %}}
تحقق من أداة Aspose المجانية لتحويل PowerPoint إلى ملصق عبر الإنترنت: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **التعليمات المتكررة**

**هل يمكنني تحويل شريحة فردية بدلاً من تحويل العرض التقديمي بالكامل إلى TIFF؟**

نعم. يتيح Aspose.Slides تحويل الشرائح الفردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى صيغة TIFF.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا تُحافظ الرسوم المتحركة ولا تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.