---
title: تحويل عروض PowerPoint التقديمية إلى TIFF في جافا
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
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides للجافا، مع أمثلة على الكود."
---
## **مقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوط يُستخدم على نطاق واسع، ويُعرف بجودته الاستثنائية وحفظه التفصيلي للرسومات. غالبًا ما يختار المصممون، والمصورون، والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة اللون والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن بقاء عروضك التقديمية بأعلى مستوى من الدقة البصرية. 

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) المقدمة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) يمكنك بسرعة تحويل عرض تقديمي كامل إلى TIFF. تتوافق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

يُظهر هذا المثال كيفية تحويل عرض تقديمي PowerPoint إلى TIFF:

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // حفظ العرض التقديمي كملف TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

تسمح لك الطريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) في الفئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/) بتحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون الطريقة [setCompressionType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) مُعيّنة إلى `CCITT4` أو `CCITT3`.

{{% alert color="info" title="ملاحظة" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) هو إعداد على مستوى التصدير يحدد خوارزمية تحويل البكسلات للصورة TIFF كاملة. لتحديد كيفية ظهور شكلٍ فردي عندما يكون وضع العرض بالأبيض والأسود مفعّلاً، استخدم [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). راجع **التحكم في عرض أبيض وأسود للأشكال** (/java/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.

{{% /alert %}}

لنفترض أن لدينا ملفًا باسم "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

يُظهر هذا المثال كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

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

إذا كنت بحاجة إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الطرق المتوفرة في الفئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/). على سبيل المثال، تسمح الطريقة [setImageSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) بتحديد حجم الصورة الناتجة.

يُظهر هذا المثال كيفية تحويل عرض تقديمي PowerPoint إلى صور TIFF بحجم مخصص:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
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

    // يعتمد العمق على نوع الضغط ولا يمكن تعيينه يدويًا.

    // تعيين DPI الصورة.
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

## **تحويل عرض تقديمي إلى TIFF مع تنسيق بكسل مخصص للصورة**

باستخدام الطريقة [setPixelFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) من الفئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/) يمكنك تحديد تنسيق البكسل المفضّل للصورة TIFF الناتجة.

يُظهر هذا المثال كيفية تحويل عرض تقديمي PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat يحتوي على القيم التالية (حسب ما هو مذكور في المستندات):
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

تحقق من **محول PowerPoint إلى بوستر مجاني** من Aspose عبر الرابط التالي: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل شريحة فردية بدلاً من عرض تقديمي كامل إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض تقديمية بأي حجم إلى تنسيق TIFF.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا يتم حفظ الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.