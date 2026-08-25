---
title: تحويل عروض PowerPoint إلى TIFF باستخدام JavaScript
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرّف على كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لـ Node.js، مع أمثلة كود JavaScript."
---
## **مقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير فقدانية واسع الاستخدام معروف بجودته الاستثنائية وحفظ التفاصيل الدقيقة للرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن أن عروضك التقديمية تحتفظ بأعلى درجة من الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) المقدمة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

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

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

طريقة [setBwConversionMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) في الفئة [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/) تسمح لك بتحديد الخوارزمية المستخدمة عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد ينطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) مُعيَّنة إلى `CCITT4` أو `CCITT3`.

{{% alert color="info" title="ملاحظة" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) هو إعداد على مستوى التصدير يختار خوارزمية تحويل البكسلات لصورة TIFF الكاملة. لتحديد كيفية ظهور شكل فردي عندما يكون وضع العرض بالأبيض والأسود مفعّلاً، استخدم [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). راجع [Control Black-and-White Rendering for Shapes](/slides/ar/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

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

![TIFF بالأبيض والأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الطرق المتاحة في [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/). على سبيل المثال، طريقة [setImageSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setImageSize) تسمح لك بتحديد حجم الصورة الناتجة.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // تعيين نوع الضغط.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    أنواع الضغط:
        Default - يحدد مخطط الضغط الافتراضي (LZW).
        None - يحدد عدم وجود ضغط.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // يتم التحكم في عمق اللون بواسطة تنسيق البكسل (انظر المثال أدناه)؛ CCITT3 و CCITT4 دائمًا ينتجان 1 بت لكل بكسل.

    // تعيين DPI الصورة.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // تعيين حجم الصورة.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **تحويل عرض تقديمي إلى TIFF بصيغة بكسل مخصصة**

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) من الفئة [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/)، يمكنك تحديد صيغة البكسل المفضلة لديك للصورة TIFF الناتجة.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    يحتوي ImagePixelFormat على القيم التالية (كما هو مذكور في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مفهرس.
        Format4bppIndexed - 4 بت لكل بكسل، مفهرس.
        Format8bppIndexed - 8 بت لكل بكسل، مفهرس.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */

    /// حفظ العرض التقديمي كملف TIFF بالحجم المحدد للصورة.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="نصيحة" color="info" %}}
تحقق من [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online) الخاص بـ Aspose.
{{% /alert %}}

## **الأسئلة المتداولة**

**هل يمكنني تحويل شريحة واحدة بدلاً من عرض PowerPoint كامل إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم الاحتفاظ برسوميات وانتقالات PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا يتم الاحتفاظ بالرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.