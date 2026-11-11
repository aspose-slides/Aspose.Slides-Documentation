---
title: عرض شرائح العروض التقديمية كصور SVG في PHP
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- عرض تقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- SVG تفاعلي
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في PHP والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML وقابل للتوسيع يعمل جيدًا للنشر على الويب، وعارض الشرائح، وتدفقات العمل المتعلقة بإمكانية الوصول، ومعالجة ما بعد التصدير الآلية. تصدر Aspose.Slides كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) عندما يحتاج SVG المُصدَّر إلى أن يكون مضغوطًا، متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق باستخدام [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

يستخدم اسم الملف [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) عندما يحتاج عارض الشرائح أو صفحة الويب إلى هذا الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) يتحكم في عرض SVG. لإطارات النص، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) يضمن تضمين إطار النص في مساحة العرض، و[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) يحدد ما إذا كان يتم تطبيق تدوير الإطار. عيّن [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) إلى `true` عندما يجب عرض النص بدون الحروف المتصلة.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **التحكم في قص نهايات الخط عند رؤوس السهام**

SVG 1.1 لا يحتوي على إعداد لتحديد موضع إيقاف الخط تحت رأس السهم. بشكل افتراضي، تقوم Aspose.Slides بتقليل طول الخط المُصدَّر بحيث لا يبرز ضربة القلم عبر العلامة. استدعِ [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) مع `true` لرسم الضربة حتى النقطة الأصلية لنهاية الخط. يؤثر هذا الإعداد فقط على إخراج SVG. يبقى الخط في موضعه وطوله على الشريحة.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

المقارنة تُظهر رأس السهم المثلث على الخط بعرض 10 نقاط. مع تمكين القص، تكون القمة حادة. مع تعطيل القص، تبرز الضربة عبر جوانب العلامة المائلة وتترك طرفًا مسطحًا.

![مثلث 10‑نقاط مكبر مع قمة حادة عندما يكون القص مفعَّلًا وطرف مسطح عندما يكون القص معطلًا](line-end-cropping.png)

في الخطوط الأخرى من المثال، يكون الضربة البارزة أقل وضوحًا على المثلث بعرض نقطتين. يغطي الماس المملوء نهاية الضربة في كلا العرضين.

## **التحكم بالنص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان النص يبقى كنص أو يتحول إلى رسومات متجهة، وكيفية تضمين أو الإشارة إلى الخطوط الخارجية. تساعدك الخيارات التالية على موازنة الاتساق البصري، وإمكانية تحديد النص، واعتمادية الخطوط في SVG المُصدَّر.

### **تحويل كل النص إلى متجهات**

عيّن [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) إلى `true` لكتابة كل نص الشريحة كرسومات متجهة. يُزيل هذا الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لم يعد قابلًا للتحديد أو البحث كـ SVG نص.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **اختر طريقة معاملة الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، أو `Embed` لتضمين بيانات الخط في SVG، أو `Vectorize` لعرض النص الذي يستخدم خطوطًا خارجية كرسومات فقط. تحقق من ترخيص الخط قبل تضمينه.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **تقليل حجم الصور المضمنة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) لتقليل دقة الصور المضمنة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) لحذف المناطق المقطوعة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب الدقة أو بيانات الصورة المحتفظ بها.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **التحكم في دقة تحويل ملفات الميتافايل إلى نقطية**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) يحدد الحد الأدنى لدقة تحويل الميتافايلات إلى نقطية أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى نقطية. لا يحدد DPI عالميًا لـ SVG ولا يجبر كل كائن على الشريحة على أن يصبح صورة نقطية.

حمّل [metafile-rasterization.pptx](metafile-rasterization.pptx) الذي يحتوي على صورة EMF بخطوط مائلة متقاربة. المثال التالي يصدر الشريحة الأولى في ثلاث دقات تحويل عبر [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). تبقى جميع إعدادات التصدير الأخرى متطابقة لتسهيل المقارنة.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

في الناتج، تحولت EMF إلى صورة PNG مضمَّنة في كل SVG. القياسات التالية تتعلق بالعرض التقديمي المرفق؛ وهي ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| DPI لتقليل ملفات الميتا | أبعاد PNG المضمن | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تُظهر نفس المنطقة من الصورة النقطية المضمَّنة بالحجم المعروض المكبر نفسه. تُظهر الخطوط المائلة بكسرة واضحة عند 72 DPI وحوافًا أكثر سلاسة عند الدقات الأعلى، بينما يزداد حجم ملف SVG. زيادة القيمة لا تحسن كل التفاصيل بالضرورة ولا تغير كل صورة مُصدَّرة.

![تفاصيل الخط المائل مكبرة عند 72 و150 و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) يتحكم في تقليل دقة الصورة ويمكن أن يُخفي تأثير تغيير دقة تحويل الميتافايل إلى نقطية. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) يتحكم في جودة ترميز JPEG، وليس في دقة تحويل الميتافايل إلى نقطية.

## **تعيين معرفات ثابتة للأشكال والنص**

قدِّم رد نداء تنسيق إلى [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) لتعيين [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) لكل شكل SVG. يمكن لرد النداء أيضًا تعيين قيم [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) لعناصر النص `tspan`.

PhpJavaBridge لا يستطيع استدعاء رد نداء PHP من `writeAsSvg` عندما يعمل في وضع التدفق. ضع منطق التنسيق في فئة مساعد Java صغيرة، اجمعها، وأضف ملف JAR النتيجة إلى مسار جسر الفئة. يمكن للمساعد استخدام [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId)، وهو ثابت طوال عمر الشكل، وعدادًا قابلاً للتكرار لتحديد النصوص. راجع [Java implementation of `StableSvgIdController`](/slides/ar/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) للحصول على شفرة المساعد.

بعد إضافة الفئة المجمَّعة `com.example.slides.StableSvgIdController` إلى مسار جسر الفئة، أنشئ كائنًا منها في PHP وعينه إلى `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **إضافة معالجات أحداث SVG**

في رد نداء التنسيق، استدعِ [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) بقيمة [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) لإضافة معالج حدث JavaScript إلى شكل مُصدَّر. عيّن رد النداء باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) وعرف دالة JavaScript في الصفحة أو مستند SVG المستضيف للنتيجة.

كما هو الحال مع المعرفات الثابتة، نفِّذ رد النداء في مساعد Java عندما يستخدم PhpJavaBridge وضع التدفق. [Java implementation of `SvgEventController`](/slides/ar/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) يعيّن معرفًا ومعالج `OnClick` إلى شكل اسمه `ActionButton`. اجمع هذا المساعد، أضفه إلى مسار جسر الفئة كـ `com.example.slides.SvgEventController`، واستخدمه من PHP كما هو موضح:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

يمكن للصفحة المضيفة تعريف دالة JavaScript التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يُمكِّن عارضات الشرائح، تحسينات إمكانية الوصول، وسير العمل التفاعلي للـ SVG.

## **الأسئلة المتكررة**

**متى يجب استخدام [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) عندما يُرغب في تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل حجم SVG أصغر؟**

ابدأ بضغط الصور المضمنة، حذف المناطق المقتطعة من الصور، واختيار ملفات خطوط مرتبطة عندما يكون بيئة الهدف قادرة على خدمتها. اختبر النتيجة لأن خفض دقة الصورة، خفض جودة JPEG، وتحويل النص إلى متجهات لكل منها تبادلات مختلفة بين الجودة والحجم.

**هل يمكن تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر رد نداء التنسيق، ثم حدد العناصر المطابقة في أداة ما بعد المعالجة أو في سكريبت المتصفح.