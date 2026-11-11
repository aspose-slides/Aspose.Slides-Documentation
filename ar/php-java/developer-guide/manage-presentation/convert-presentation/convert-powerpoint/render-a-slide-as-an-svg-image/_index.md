---
title: تحويل شرائح العرض التقديمي إلى صور SVG في PHP
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
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

SVG هو تنسيق صورة قائم على XML قابل للتوسع يعمل جيدًا للنشر على الويب، وعارض الشرائح، وسير عمل إمكانية الوصول، ومعالجة ما بعد التنفيذ الآلية. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، أو متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

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

يستخدم اسم الملف [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) يتحكم في تصيير SVG. لإطارات النص، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) تشمل إطار النص في منطقة التصيير، و[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) يحدد ما إذا كان يتم تطبيق دوران الإطار. اضبط [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) على `true` عندما يجب تصيير النص بدون الروابط الأحرفية.

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

## **التحكم في النص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان النص يبقى كنص أو يتحول إلى رسومات متجهية، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية على موازنة التناسق البصري، قابلية اختيار النص، واعتمادية الخطوط في SVG المُصدَّر.

### **تحويل كل النص إلى رسومات متجهية**

اضبط [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) على `true` لكتابة كل نص الشريحة كرسوم متجهية. هذا يلغي اعتماد الخطوط ويجعل النتيجة البصرية أكثر تناسقًا عبر المتصفحات، لكن النص لن يكون قابلًا للاختيار أو للبحث كنص SVG.

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

### **اختر طريقة معالجة الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) للخطوط التي تُحمَّل خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط في SVG، أو `Vectorize` لتصوير النص الذي يستخدم خطوطًا خارجية فقط كرسومات. تحقق من تراخيص الخط قبل تضمينه.

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

## **تقليل حجم الصورة المدمجة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) لتقليل دقة الصور المدمجة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) لحذف المناطق المقتصة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) للتحكم في جودة ترميز JPEG. تُقلِّل هذه الإعدادات حجم الملف على حساب جودة الصورة أو البيانات المحتفظ بها.

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

## **التحكم في دقة تحويل ملفات الميتا إلى نقطية**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) يحدد الحد الأدنى لدقة تحويل ملفات الميتا إلى نقطية أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى نقطية. لا يحدد قيمة DPI عالمية للـ SVG ولا يجبر كل كائن في الشريحة على أن يصبح صورة نقطية.

حمّل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF ذات خطوط قطرية متقاربة. المثال التالي يصدر شريحته الأولى بثلاث دقات نقطية عبر [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). جميع إعدادات التصدير الأخرى تبقى متطابقة لتسهيل المقارنة.

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

في الناتج، تحول ملف EMF إلى صورة PNG مدمجة واحدة في كل SVG. القياسات التالية تخص العرض المرفق؛ ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| دقة نقطية لملف الميتا (DPI) | أبعاد PNG المدمجة | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تُظهر نفس منطقة الصورة النقطية المدمجة بنفس حجم العرض المكبر. الخطوط القطرية تُظهر بكسلة ملحوظة عند 72 DPI وحواف أكثر سلاسة عند الدقات الأعلى، بينما يزداد حجم ملف SVG. زيادة القيمة لا تحسن بالضرورة كل التفاصيل ولا تغير كل صورة مُصدَّرة.

![تفاصيل الخط القطري المكبرة عند 72 و 150 و 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) يتحكم في تقليل دقة الصورة وقد يخفى تأثير تعديل دقة تحويل ملفات الميتا إلى نقطية. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) يتحكم في جودة ترميز JPEG، وليس في دقة تحويل ملفات الميتا إلى نقطية.

## **تعيين معرفات ثابتة للأشكال والنص**

قدِّم رداً برمجيًا للتنسيق إلى [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) لتعيين [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) لكل شكل SVG. يمكن للرد البرمجي أيضًا تعيين قيم [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) لعناصر `tspan` النصية.

لا يستطيع PhpJavaBridge استدعاء رد PHP من `writeAsSvg` عندما يعمل في وضع التدفق. ضع منطق التنسيق في فئة مساعدة Java صغيرة، ثُمّ قم بترجمتها، وأضف ملف JAR الناتج إلى مسار جسر الفئة. يمكن للمساعدة استخدام [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId)، وهو ثابت طوال عمر الشكل، ومُعدِّد قابل للتكرار لفواصل النص. راجع [تنفيذ Java لـ `StableSvgIdController`](/slides/ar/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) للحصول على رمز المساعدة.

بعد إضافة الفئة المترجمة `com.example.slides.StableSvgIdController` إلى مسار جسر الفئة، أنشئ كائنًا منها من PHP وعينه إلى `SVGOptions`:

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

في رد تنسيق، استدعِ [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) مع قيمة [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) لإضافة معالج حدث JavaScript إلى شكل مُصدَّر. عيِّن الرد البرمجي باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) وحدد وظيفة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

كما هو الحال مع المعرفات الثابتة، نفِّذ الرد البرمجي في مساعدة Java عندما يستخدم PhpJavaBridge وضع التدفق. [تنفيذ Java لـ `SvgEventController`](/slides/ar/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) يعين معرفًا ومعالج `OnClick` إلى شكل اسمه `ActionButton`. ترجم تلك المساعدة، أضفها إلى مسار جسر الفئة باسم `com.example.slides.SvgEventController`، واستخدمها من PHP كما يلي:

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

يمكن للصفحة المضيفة تعريف وظيفة JavaScript التي يشير إليها المعالج. يتيح تعيين المعرفات ومعالجات الأحداث للعارضين، وتحسينات إمكانية الوصول، وغير ذلك من سير عمل SVG التفاعلية.

## **الأسئلة الشائعة**

**متى يجب أن أستخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) بدلًا من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) عندما يجب أن يكون كل النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل SVG أصغر؟**

ابدأ بضغط الصور المدمجة، حذف المناطق المقتصة من الصورة، واختيار ملفات خطوط مرتبطة عندما يمكن للبيئة المستهدفة تقديمها. اختبر النتيجة لأن انخفاض دقة الصورة، انخفاض جودة JPEG، وتحويل النص إلى متجه كل منها له مقايضات جودة وحجم مختلفة.

**هل يمكنني تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر رد تنسيق، ثم اختر العناصر SVG المطابقة في أداة ما بعد المعالجة أو سكريبت المتصفح.