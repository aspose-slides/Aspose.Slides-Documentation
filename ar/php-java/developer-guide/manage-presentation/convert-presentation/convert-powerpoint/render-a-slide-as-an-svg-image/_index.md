---
title: "تصدير شرائح العرض التقديمي كصور SVG في PHP"
linktitle: "شريحة إلى SVG"
type: docs
weight: 50
url: /ar/php-java/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint إلى SVG"
- "العرض التقديمي إلى SVG"
- "شريحة إلى SVG"
- "PPT إلى SVG"
- "PPTX إلى SVG"
- "خيارات تصدير SVG"
- "SVG تفاعلي"
- "PowerPoint"
- "عرض تقديمي"
- "PHP"
- "Aspose.Slides"
description: "تصدير شرائح PowerPoint كصور SVG في PHP والتحكم بالخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صور قائم على XML قابل للتوسيع يعمل بشكل جيد للنشر على الويب، وعارض الشرائح، وسير عمل إمكانية الوصول، والمعالجة التلقائية بعد الإجراء. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/) عندما يجب أن يكون ملف SVG المُصدَّر مضغوطًا، متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كملف SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق باستخدام [Slide.writeAsSvg](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#writeAsSvg). المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

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

تستخدم اسم الملف [Slide.getSlideNumber](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getSlideNumber) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.writeAsSvg](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#writeAsSvg) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/) يتحكم في عرض SVG. بالنسبة لإطارات النص، يتم تضمين إطار النص في مساحة العرض عبر [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setUseFrameSize)، وتحدد [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setUseFrameRotation) ما إذا كان سيتم تطبيق دوران الإطار. اضبط [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) إلى `true` عندما يجب عرض النص بدون الروابط الأحرفية.

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

## **التحكم في النصوص والخطوط**

### **تحويل كل النص إلى رسومات متجهية**

اضبط [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setVectorizeText) إلى `true` لكتابة جميع نصوص الشرائح كرسومات متجهية. هذا يلغي الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لن يكون قابلًا للتحديد أو البحث كالنص SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لتصوير النص الذي يستخدم خطوطًا خارجية كرسومات فقط. تحقق من ترخيص الخط قبل تضمينه.

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

## **تقليل حجم الصور المدمجة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setPicturesCompression) لتقليل دقة الصور المدمجة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) لإهمال المناطق المقصوصة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setJpegQuality) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو البيانات المحتفظ بها.

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

## **تخصيص معرفات ثابتة للأشكال والنصوص**

قدّم رد اتصال تنسيق إلى [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setShapeFormattingController) لتعيين [SvgShape.setId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgshape/#setId) لكل شكل SVG. يمكن لرد الاتصال أيضًا تعيين قيم [SvgTSpan.setId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgtspan/#setId) على عناصر النص `tspan`.

PhpJavaBridge لا يمكنه استدعاء رد اتصال PHP من `writeAsSvg` عندما يعمل في وضع التدفق. ضع منطق التنسيق في فئة مساعدة Java صغيرة، قم بتجميعها، وأضف ملف JAR الناتج إلى مسار الفئة للجسر. يمكن للمساعدة استخدام [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getOfficeInteropShapeId)، وهو ثابت طوال عمر الشكل، وعدّاد قابل للتكرار لتحديد الفواصل النصية. راجع [Java implementation of `StableSvgIdController`](/slides/ar/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) للحصول على رمز المساعدة.

بعد إضافة الفئة المجمّعة `com.example.slides.StableSvgIdController` إلى مسار الفئة للجسر، أنشئ كائنًا منها من PHP وعيّنها إلى `SVGOptions`:

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

في رد اتصال التنسيق، استدعِ [SvgShape.setEventHandler](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgshape/#setEventHandler) مع قيمة [SvgEvent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgevent/) لإضافة معالج حدث JavaScript إلى شكل مُصدَّر. عيّن رد الاتصال عبر [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setShapeFormattingController) وعرّف وظيفة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

كما هو الحال مع المعرفات الثابتة، نفّذ رد الاتصال في مساعدة Java عندما يستخدم PhpJavaBridge وضع التدفق. [Java implementation of `SvgEventController`](/slides/ar/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) يعيّن معرفًا ومعالج `OnClick` إلى شكل يُدعى `ActionButton`. قم بتجميع تلك المساعدة، أضفها إلى مسار الفئة للجسر كـ `com.example.slides.SvgEventController`، واستخدمها من PHP كما يلي:

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

يمكن للصفحة المضيفة تعريف وظيفة JavaScript التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يتيح عارضات الشرائح، تحسينات إمكانية الوصول، وسير عمل SVG تفاعلية أخرى.

## **الأسئلة المتكررة**

**متى يجب استعمال [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setVectorizeText) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#setVectorizeText) عندما يجب أن يكون جميع النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgexternalfontshandling/) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل ملف SVG أصغر؟**

ابدأ بضغط الصور المدمجة، حذف المناطق المقصوصة من الصور، واختيار ملفات خطوط مرتبطة عندما تستطيع البيئة المستهدفة تقديمها. اختبر النتيجة لأن انخفاض دقة الصورة، انخفاض جودة JPEG، والنص المتجه لكل منها تأثير مختلف على الجودة والحجم.

**هل يمكن تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر رد اتصال تنسيق، ثم حدد العناصر المطابقة في أداة المعالجة اللاحقة أو سكريبت المتصفح.