---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام PHP
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/php-java/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- تدرج رمادي
- ثنائي اللون
- صبغة
- HSL
- استبدال اللون
- ضبابية
- شفافية
- تأثير ألفا
- سلسلة تأثير
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

تمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) الخاص بالإطار وادخل إلى [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/). تُعيد [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) التي تُتيح لك إلحاق، تعداد، فحص، إزالة، وتطهير التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

يوضح هذا المقال سير عمل كامل للسطوع والتباين، تحويلات اللون، الضبابية، الشفافية، سلاسل التأثير المرتبة، القيم الفعالة، الإزالة، والتحقق من دورة حفظ PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مورد الصورة والصورة التي تعرضه كائنان مختلفان:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) يخزن أو يشير إلى بيانات الصورة المصدر التي يملكها العرض.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) ينتمي إلى تعبئة الصورة ويشير إلى مورد الصورة مع تخزين مجموعة تحويل الصورة.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) هو شكل الشريحة الذي يملك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القطع، وتنسيق الإطار.

لذلك، لا تُغيّر عمليات تحويل الصورة البايتات في [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/). عندما يتم تمرير نفس `PPImage` إلى [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) أكثر من مرة، يحصل كل إطار صورة جديد على `Picture` خاص به ومجموعة تحويل خاصة به. تطبيق التحويل إلى تدرج الرمادي على إطار واحد لا يجعل الأطر الأخرى رمادية، رغم أن جميعها تعيد استخدام مورد الصورة المضمّن نفسه.

نموذج `Picture::getImageTransform` نفسه يُستخدم أيضًا من قبل تعبئات الصور الأخرى، مثل شكل أو خلفية شريحة. الأمثلة أدناه تركز على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعلمات**

الطرق الموضحة تستخدم النطاقات الدلالية والوحدات التالية. حافظ على القيم ضمن هذه النطاقات حتى لو لم ترفض نسخة المكتبة معينة القيم الخارجة عن النطاق فورًا؛ قد تقوم صيغة العرض الهدف بتطبيع، حذف، أو رفض البيانات غير الصالحة أثناء الحفظ أو عندما يفتح PowerPoint الملف.

| العملية | المعلمات | النطاق والوحدة الصالحة |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | لا شيء | لا معلمات رقمية. يبقى الألفا دون تغيير. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | لونان للبيكسلات الداكنة والفاتحة. قنوات RGB وalpha في `java.awt.Color` تتراوح من `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجة؛ `amount` من `-100` إلى `100`، نسبة مئوية. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجة؛ `saturation` و`luminance` من `-100` إلى `100`، نسبة مئوية. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | لون الاستبدال يستخدم قيم القنوات من `0` إلى `255`. قيم alpha الحالية لا تُغيّر. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` غير سالب ويُقاس بالنقاط؛ `grow` هو منطقية تحدد ما إذا كان المحتوى الضبابي قد يمتد خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادي: `0` يعني شفافية كاملة و`100` يحافظ على قيمة alpha الحالية. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` إلى `100`، نسبة مئوية للشفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` إلى `100`، نسبة مئوية لحد الفاصل alpha. القيم الأقل تصبح شفافة؛ القيم عند أو فوق الحد تصبح غير شفافة. |

للتعديل الثابت على alpha، الشفافية والعتامة متكاملتان. على سبيل المثال، 35 % شفافية تُعادل مقدار تعديل alpha قدره 65 %.

## **تطبيق السطوع والتباين**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) تُعيد عملية [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/). تُزود إعداداته السلمية عند إنشاء العملية. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) تُعيد قيمًا محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15 % والتباين بنسبة 20 %، ثم يعرض معاينة دون تعديل الصورة المضمَّنة:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` هو تأثير السطوع والتباين القياسي في DrawingML. عندما يجب أن تظل هذه الإعدادات قابلة للتحرير بعد جولة حفظ PPTX، أعد فتح العرض المحفوظ وتحقق من كل من نوع العملية وقيمها الفعالة.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمسة إطارات ويطبق تدرج رمادي، ثنائي اللون، صبغة، تعديل HSL، واستبدال اللون.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) يحتوي على معلمتين للون يمكن تحريرهما بشكل مستقل: `color1` يحدد اللون للبيكسلات الداكنة، بينما `color2` يحدد اللون للبيكسلات الفاتحة. هذا يجعله مثالًا مفيدًا لتأثير إعداداته أكثر تعقيدًا من قيمة سلمية واحدة.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) يستبدل لون كل بيكسل بلون ثابت مع الحفاظ على alpha. وهو مختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/)، الذي يطابق لون مصدر بلون هدف ويكشف عن صيغ اللون المصدر والهدف.

### **تطبيق حد السطوع**

يمكن أن يجعل حد السطوع العلامات الخفيفة على صفحة ممسوحة ضوئيًا أسهل للتمييز عن الخلفية. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) يحافظ على تدرجات الرمادي الوسيطة. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) يطابق السطوع إلى أسود أو أبيض، بينما [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) يُطبق حدًا للشفافية.

حد السطوع يتراوح من 0 % إلى 100 % شاملًا. البيكسلات التي تحت الحد تصبح سوداء. البيكسلات عند أو فوق الحد تصبح بيضاء. رفع الحد يجعل المزيد من التدرجات سوداء لأن المزيد منها يقع تحت القطع.

حمِّل [grayscale-swatches.png](grayscale-swatches.png) إلى الدليل الذي يحتوي على سكريبت PHP. كل تسمية تعرض مستوى الرمادي الأصلي على مقياس من 0 إلى 255. يضع المثال الأصلي بجوار نسختين ويحفظ حد كل نسخة في العرض.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

افتح العرض الناتج في PowerPoint لمقارنة الإطارات الثلاثة. العينة الموسومة بـ 96 لديها تقريبًا 38 % سطوع (96 من 255). تتحول إلى أبيض عند حد 20 % وإلى أسود عند حد 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **إضافة ضبابية، شفافية، وتأثيرات Alpha**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) يؤثر على جميع قنوات اللون، بما فيها alpha. اضبط `grow` إلى `true` عندما قد يمتد الحافة الضبابية خارج حدود الصورة الأصلية.

للشفافية الموحدة، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). فهو يضرب كل قيمة alpha موجودة، لذلك تظل البيكسلات شبه الشفافة مختلفة نسبيًا. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) يخصص قيمة alpha واحدة لكل البيكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) يحول alpha إلى مستويين بناءً على حد.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تشمل عمليات alpha الخالية من المعلمات الأخرى [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/)، التي تجعل كل alpha غير صفري غير شفاف تمامًا؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/)، التي تجعل كل alpha أقل من 100 % شفافة تمامًا؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/)، التي تغير alpha إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `add...Effect` تُلحق عملية جديدة إلى نهاية المجموعة. يستخدم المُعالج المجموعة كخط أنابيب مرتب: مخرج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، نفس العمليات بترتيب مختلف قد تُنتج صورة مختلفة.

على سبيل المثال، تطبيق تدرج رمادي ثم صبغة يزيل أولًا المعلومات اللونية ثم يُعيد تلوين نتيجة السطوع. تطبيق الصبغة ثم تدرج رمادي يزيل الصبغة مرة أخرى. بالمثل، استبدال alpha يمكن أن يتجاوز قيم alpha التي حسبتها عمليات سابقة، بينما تعديل alpha يحافظ على اختلافاتها النسبية.

المثال التالي يبني سلسلة مكوّنة من أربع عمليات، يحفظها كـ PPTX، يفتح العرض مرة أخرى، يتحقق من كل من أنواع العمليات وترتيبها، ويعرض النتيجة المعادة الفتح:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، alpha، والضبابية بسلاسل منفصلة. يمكن دمجها، لكن الجمع قد لا يكون دائمًا مفيدًا. استبدال لون ثابت يزيل تباين RGB الناتج عن تأثيرات لون سابقة؛ تدرج رمادي بعد ثنائي اللون يزيل اللونين المختارين؛ وعمليات alpha السقفية، الأرضية، الاستبدال أو ذات المستوى الثنائي يمكن أن تُهمل تفاصيل alpha التي أُنشئت مسبقًا. بناء السلسلة وفقًا لتسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها كأعلام تنسيق غير مرتبة.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*في هذا التصوير التوضيحي لـ Aspose.Slides for .NET 26.11، صبغة 220° بنسبة 25 % لا تغير الصورة ذات التدرج الرمادي. تطبيق الصبغة نفسها قبل التدرج الرمادي يُنتج نغمات مختلفة.*
<!-- visual-explanation:image-transform-effects:end -->

## **فحص القيم القابلة للتحرير والفعالة**

العملية القابلة للتحرير هي الكائن المخزن في `Picture::getImageTransform`. بناءً على التأثير، قد يكشف عن أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) يكشف عن قيم `radius` و `grow` القابلة للكتابة، و[AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) يكشف عن `amount` القابل للكتابة، و[AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) يكشف عن `threshold` القابل للكتابة. تأثيرات اللون مثل [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) تكشف عن كائنات [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) قابلة للتعديل.

بعض العمليات، بما فيها [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/)، [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/)، [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/)، و[AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/)، لا تكشف عن القيم السلمية التي أنشئت كخصائص قابلة للكتابة. لتغيير تلك الإعدادات، قم بإزالة العملية وإضافة بديل في الموضع المطلوب.

البيانات الفعالة التي تُرجِعها `getEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل ألوان تعتمد على السمة وقراءة القيم المُطبقة التي يستخدمها المُعالج، لكنها ليست سطح تحرير آخر. المثال التالي يُعدد السلسلة ويفحص القيم الفعالة حيث توفر ال API ما يتطلبه:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

التأثيرات الخالية من المعلمات مثل تدرج رمادي، السقف alpha، والعكس alpha ما زالت لها كائن بيانات فعال، ولكن لا توجد إعدادات سلمية للطباعة. وجودها وموقعها في المجموعة هو المعلومات المهمة.

## **إزالة أو تنظيف تحويلات الصورة**

استخدم [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) لإزالة عملية واحدة حسب الفهرس. لأن الفهارس تنزاح بعد الإزالة، ابحث عن الهدف أولاً وأزله بعد التعداد. استخدم [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) لإزالة السلسلة بأكملها.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

إزالة أو تنظيف التحويلات يغيّر تنسيق الصورة فقط. لا يحذف، يُعيد ضغط، أو يغيّر مورد [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) المُعاد استخدامه.

## **النظر في صيغ العرض وأهداف التصدير**

تنشأ تحويلات الصورة في DrawingML، لذا يُفضَّل صيغة PPTX القابلة للتعديل لسلاسل التأثير. حتى مع PPTX، لا كل عملية تتمتع بنفس القابلية للنقل:

- عمليات DrawingML القياسية مثل السطوع، تدرج رمادي، ثنائي اللون، الصبغة، HSL، الضبابية، والعمليات alpha الشائعة لديها أفضل فرصة للبقاء بعد جولة حفظ PPTX. يُفضَّل دائمًا إعادة فتح الملف المُولَّد وفحص المجموعة عندما تكون المحافظة مطلوبة.
- صيغة PPT الثنائية تسبق نموذج تأثير DrawingML الكامل. الحفظ إلى PPT قد يحذف عمليات غير مدعومة، أو يحدِّد السلسلة إلى مجموعة فرعية مدعومة، أو يُقَرِّب المظهر. لا تستخدم PPT كصيغة تحقق لسلسلة تحرير معقدة.
- التصدير إلى PNG، JPEG، TIFF، PDF، SVG، HTML أو أي مخرجات بصرية أخرى يُطبق السلسلة المدعومة على المظهر المُرَسَم. تلك المخرجات لا تحتوي على `ImageTransformOperationCollection` قابل للتحرير؛ الصيغ النقطية تُسطّح النتيجة إلى بكسلات، والصادرات المستندية أو المتجهة تخزن تمثيلها الخاص للعرض.
- التأثيرات لا تجعل الصورة المرتبطة مكتملة ذاتيًا. لا يزال عرض صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض.

قد يعرض مستهلكو العروض المختلفون الحالات الطرفية بطرق مختلفة، خاصةً عندما تُدمج عدة عمليات alpha أو تقليل ألوان. للمخرجات الحرجة، اختبر كلًا من جولة الحفظ القابلة للتحرير والتصدير النهائي باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة الشائعة**

**هل تعدّل تأثيرات تحويل الصورة بيانات الصورة المضمَّنة؟**

لا. العمليات تنتمي إلى `Picture` المستخدمة في تعبئة الصورة. تبقى بايتات `PPImage` الأساسية دون تغيير.

**هل يشارك إطارا صورة يستخدمان نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `PPImage` تجنّب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يمتلك `Picture` ومجموعة تحويل صورة منفصلة.

**هل يمكن دمج تأثيرات اللون، الضبابية، وalpha؟**

نعم. تقبل المجموعة جميعها في سلسلة مرتبة واحدة. ضع في اعتبارك ما يفعله كل عملية على ناتج العملية السابقة لأن عمليات الاستبدال والحد قد تُهمل تفاصيل اللون أو alpha السابقة.

**لماذا القيم الفعالة للقراءة فقط؟**

البيانات الفعالة تمثل قيمًا محسوبة تُستخدم في العرض، بما فيها الألوان المحلولة. حرِّر العملية المخزنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلًا بمعلمات إنشاء جديدة.

**أي صيغة يجب استخداميها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. الصيغة القديمة PPT لا يمكنها تمثيل نموذج تأثير DrawingML الكامل، وتُحافظ صيغ التصدير الرسومية على المظهر فقط دون عمليات تحويل قابلة للتحرير.