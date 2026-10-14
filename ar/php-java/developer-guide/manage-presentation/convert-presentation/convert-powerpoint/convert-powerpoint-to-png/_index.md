---
title: تحويل شرائح PowerPoint إلى PNG في PHP
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/php-java/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- PHP
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint التقديمية إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides للـ PHP عبر Java، مما يضمن نتائج دقيقة ومؤتمتة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل شرائح العرض إلى صور PNG باستخدام Aspose.Slides للـ PHP عبر Java. يمكنك تحميل العروض بالتنسيقات مثل PPT و PPTX و ODP، معالجة كل شريحة، وحفظها كصورة PNG منفصلة.

تظهر الأمثلة أدناه معالجة العرض بالمقياس الافتراضي، زيادة المقياس، تحديد أبعاد الإخراج بالبكسل، واختيار نمط معالجة التدرج اللوني.

## **تحويل PowerPoint إلى PNG**

حمِّل عرضًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وابدأ بالوصول إلى شرائحه عبر مجموعة [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). يقوم المثال بمعالجة كل شريحة باستخدام [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) بدون معاملات لإنشاء صورة مصغرة. ثم يستدعي [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) مع [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) لحفظ كل شريحة معالجة كصورة PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="ملاحظة" %}}

التح overload بدون معلمات لـ [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) يعالج بالمقياس 0.2. على سبيل المثال، شريحة قياسها 720 × 540 نقطة تنتج مصغرة بحجم 144 × 108 بكسل. للتحكم بأبعاد الإخراج، استخدم التح overload مع عوامل المقياس أو بحجم صورة صريح كما هو موضح أدناه.

{{% /alert %}}

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

مرّر عوامل المقياس الأفقي والعمودي إلى [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) للتحكم بأبعاد الصورة المعالجة. في هذا المثال، كلا العاملين يساويان 2، لذا شريحة قياسها 720 — 540 نقطة تنتج صورة بحجم 1440 — 1080 بكسل. عوامل المقياس المتساوية تحافظ على نسبة أبعاد الشريحة. يتم حفظ كل صورة بصيغة PNG باستخدام [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

لتحديد أبعاد الإخراج بالبكسل، مرّر حجمًا إلى [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) بدلاً من عوامل المقياس. يعالج هذا المثال كل شريحة بحجم 960 — 720 بكسل ويحفظ النتيجة باستخدام [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). اختر الأبعاد التي تتطابق مع نسبة أبعاد الشريحة لتجنب تمدد الصورة.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **اختيار نمط معالجة التدرج اللوني**

افترض أن شريحة تحتوي على تعبئات متدرجة، لكن الانتقالات في PNG المُصدَّر تبدو أخف أو مختلفة عن ما تراه في PowerPoint. يمكنك استخدام طريقة [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) الموروثة من [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) لاختيار كيفية معالجة التدرجات.

حمِّل الملف [gradient-styles.pptx](gradient-styles.pptx) وضعه في دليل عمل التطبيق. يحتوي الشريحة الأولى على تدرجين خطيين: من السيان إلى البرتقالي في الأعلى ومن الأزرق إلى الأصفر في الأسفل. لكل تدرج نقطتا توقف عند 0% و 100%.

المثال التالي يحمِّل هذا العرض ويعالج الشريحة الأولى بنفس الطريقة في كلا الوضعين باستخدام [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

الصور أدناه تظهر الناتج من نفس الشريحة، مع كلا التدرجين في كل صورة:

| الافتراضي | PowerPointUI |
| --- | --- |
| ![تدرج من السيان إلى البرتقالي ومن الأزرق إلى الأصفر مع الافتراضي](gradient-Default.png) | ![نفس التدرجات مع PowerPointUI](gradient-PowerPointUI.png) |

في هذا المثال، ينتج الوضع **الافتراضي** ألوانًا وسطية أخف، بينما ينتج **PowerPointUI** ألوانًا وسطية أغمق. يعتمد الاختلاف على الألوان ونقاط التوقف في التدرج.

اختر **الافتراضي** عندما يكون ناتج Aspose.Slides القياسي مناسبًا لك. جرّب **PowerPointUI** عندما تكون الأولوية لمطابقة المظهر في PowerPoint. قارن كلا الناتجين مع النتيجة المستهدفة؛ لا يُفضل أي من الوضعين عالميًا.

## **الأسئلة الشائعة**

**كيف يمكنني تصدير شكل معين، مثل مخطط أو صورة، بدلًا من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة لأشكال فردية](/slides/ar/php-java/create-shape-thumbnails/)، مما يتيح لك معالجة الشكل كصورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم. استخدم نسخة عرض منفصلة لكل خيط أو عملية؛ [لا تشارك نسخة واحدة عبر الخيوط](/slides/ar/php-java/multithreading/).

**ما هي قيود التقييم عند التصدير إلى PNG؟**

وضع التقييم يضيف علامة مائية إلى الصور الناتجة ويطبق [قيود أخرى](/slides/ar/php-java/licensing/) حتى يتم تطبيق ترخيص.