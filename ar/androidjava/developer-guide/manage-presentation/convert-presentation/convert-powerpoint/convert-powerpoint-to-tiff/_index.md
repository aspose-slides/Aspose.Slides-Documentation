---
title: تحويل عروض PowerPoint إلى TIFF على نظام Android
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
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لنظام Android، مع أمثلة شفرة Java."
---
## **مقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوطة يُستخدم على نطاق واسع، يُعرف بجودته الاستثنائية وحفظ التفاصيل الدقيقة للرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأقصى قدر من الوضوح البصري.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام الطريقة [save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) المقدمة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint بالكامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

يظهر هذا المثال كيفية تحويل عرض PowerPoint إلى TIFF:

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

## **تحويل عرض تقديمي إلى TIFF أبيض وأسود**

تسمح الطريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) في الفئة [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/) لك بتحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF أبيض وأسود. لاحظ أن هذا الإعداد يطبق فقط عندما تكون الطريقة [setCompressionType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) مضبوطة على `CCITT4` أو `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) هو إعداد على مستوى التصدير يختار خوارزمية تحويل البكسل لصورة TIFF الكاملة. لتحديد كيف يجب أن تظهر شكل فردي عندما يكون وضع العرض أبيض وأسود مفعلاً، استخدم [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). انظر [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

يظهر هذا المثال كيفية تحويل الشريحة الملونة إلى TIFF أبيض وأسود:

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

![TIFF أبيض وأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك ضبط القيم المطلوبة باستخدام الطرق المتوفرة في الفئة [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/). على سبيل المثال، تسمح لك الطريقة [setImageSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) بتحديد حجم الصورة الناتجة.

يظهر هذا المثال كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

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

    // العمق يعتمد على نوع الضغط ولا يمكن تعيينه يدويًا.

    // تعيين DPI للصورة.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تعيين حجم الصورة.
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

## **تحويل عرض تقديمي إلى TIFF بتنسيق بكسل صورة مخصص**

باستخدام الطريقة [setPixelFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) من الفئة [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/)، يمكنك تحديد تنسيق البكسل المفضل لديك للصورة TIFF الناتجة.

يظهر هذا المثال كيفية تحويل عرض PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو موضح في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مؤشر.
        Format4bppIndexed - 4 بت لكل بكسل، مؤشر.
        Format8bppIndexed - 8 بت لكل بكسل، مؤشر.
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
تحقق من [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online) من Aspose.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل شريحة فردية بدلاً من عرض PowerPoint كامل إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم حفظ حركات PowerPoint وتأثيرات الانتقال عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك، لا يتم حفظ الحركات أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.