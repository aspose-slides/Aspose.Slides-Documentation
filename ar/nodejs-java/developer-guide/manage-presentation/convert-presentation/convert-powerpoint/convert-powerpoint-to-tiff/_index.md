---
title: تحويل عروض PowerPoint إلى TIFF باستخدام JavaScript
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لـ Node.js، مع أمثلة كود JavaScript."
---
## **مقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوط يُستخدم على نطاق واسع، معروف بجودته الاستثنائية والحفاظ الدقيق على الرسومات. غالبًا ما يختار المصممون والمصورون وناشروا سطح المكتب TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأقصى درجة من الوضوح البصري.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض تقديمي كامل إلى TIFF. صور TIFF الناتجة تتطابق مع حجم الشريحة الافتراضي.

هذا كود JavaScript يوضح كيفية تحويل عرض تقديمي PowerPoint إلى TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // حفظ العرض التقديمي كملف TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **تحويل عرض تقديمي إلى TIFF أبيض وأسود**

الطريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) في فئة [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/) تسمح لك بتحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF أبيض وأسود. لاحظ أن هذا الإعداد ينطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) مضبوطة على `CCITT4` أو `CCITT3`.

{{% alert color="info" title="ملاحظة" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) هو إعداد على مستوى التصدير يختار خوارزمية تحويل البكسل للصور TIFF الكاملة. لتعريف كيفية ظهور شكل معين عند تفعيل وضع العرض بالأبيض والأسود، استخدم [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). راجع [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![A presentation slide](slide_black_and_white.png)

هذا كود JavaScript يوضح كيفية تحويل الشريحة الملونة إلى TIFF أبيض وأسود:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

النتيجة:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت بحاجة إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الطرق المتاحة في فئة [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/). على سبيل المثال، تسمح لك طريقة [setImageSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setImageSize) بتحديد حجم الصورة الناتجة.

هذا كود JavaScript يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صور TIFF بحجم مخصص:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // ضبط نوع الضغط.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    أنوع الضغط:
        Default - يحدد مخطط الضغط الافتراضي (LZW).
        None - يحدد عدم وجود ضغط.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // يتم التحكم في عمق اللون من خلال تنسيق البكسل (انظر المثال أدناه)؛ CCITT3 و CCITT4 ينتجان دائمًا بت واحد لكل بكسل.

    // ضبط DPI للصورة.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // ضبط حجم الصورة.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي بصيغة TIFF بالحجم المحدد.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **تحويل عرض تقديمي إلى TIFF بصيغة بكسل مخصصة**

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) من فئة [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/)، يمكنك تحديد صيغة البكسل المفضلة لديك للصورة TIFF الناتجة.

هذا كود JavaScript يوضح كيفية تحويل عرض تقديمي PowerPoint إلى صورة TIFF بصيغة بكسل مخصصة:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو موضح في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مفهرس.
        Format4bppIndexed - 4 بت لكل بكسل، مفهرس.
        Format8bppIndexed - 8 بت لكل بكسل، مفهرس.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */

    /// احفظ العرض التقديمي بصيغة TIFF مع حجم الصورة المحدد.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="نصيحة" color="info" %}}
تحقق من [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online) المجاني من Aspose.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل شريحة واحدة بدلاً من entire PowerPoint presentation إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا تفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بحجم أي حجم إلى تنسيق TIFF.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك، لا يتم الحفاظ على الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.