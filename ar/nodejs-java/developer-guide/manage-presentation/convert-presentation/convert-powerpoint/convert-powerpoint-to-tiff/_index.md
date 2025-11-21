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
- PowerPoint إلى TIFF
- OpenDocument إلى TIFF
- العرض التقديمي إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- ODP إلى TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) وOpenDocument (ODP) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لـ Node.js عبر Java. دليل خطوة بخطوة مع أمثلة على الشيفرة مضمّن."
---

## **نظرة عامة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوط واسع الاستخدام ومعروف بجودته الاستثنائية والحفاظ الدقيق على الرسومات. غالبًا ما يختار المصممون والمصورون وناشرو الحاسوب TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأعلى درجة من الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) المقدمة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى TIFF:
```js
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // حفظ العرض التقديمي كملف TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```


## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

تتيح الطريقة [setBwConversionMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) في الفئة [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [setCompressionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) مُعَدة على القيمة `CCITT4` أو `CCITT3`.

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

يعرض هذا الكود JavaScript كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:
```js
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

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك ضبط القيم المطلوبة باستخدام الطرق المتاحة في [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/). على سبيل المثال، تسمح طريقة [setImageSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setImageSize) لك بتحديد حجم الصورة الناتجة.

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:
```js
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي (PPT, PPTX, ODP, إلخ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // ضبط نوع الضغط.
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

    // عمق الصورة يعتمد على نوع الضغط ولا يمكن ضبطه يدويًا.

    // ضبط DPI الصورة.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // ضبط حجم الصورة.
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


## **تحويل عرض تقديمي إلى TIFF بتنسيق بكسل مخصص للصورة**

باستخدام طريقة [setPixelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) من الفئة [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/)، يمكنك تحديد تنسيق البكسل المفضل لديك للصورة TIFF الناتجة.

يعرض هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:
```js
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat يحتوي على القيم التالية (كما هو مذكور في الوثائق):
        Format1bppIndexed - 1 بت لكل بكسل، مفهرس.
        Format4bppIndexed - 4 بت لكل بكسل، مفهرس.
        Format8bppIndexed - 8 بت لكل بكسل، مفهرس.
        Format24bppRgb    - 24 بت لكل بكسل، RGB.
        Format32bppArgb   - 32 بت لكل بكسل، ARGB.
    */

    /// حفظ العرض التقديمي كملف TIFF مع حجم الصورة المحدد.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Tip" color="primary" %}}
تحقق من [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل شريحة واحدة بدلاً من عرض PowerPoint كامل إلى TIFF?**

نعم. يتيح لك Aspose.Slides تحويل الشرائح الفردية من عروض PowerPoint وعروض OpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، فإن TIFF هو تنسيق صورة ثابت. لذلك لا يتم حفظ الرسوم المتحركة ولا تأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.