---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام PHP
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/php-java/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- السطوع
- التباين
- تدرج الرمادي
- ثنائية اللون
- تلوين
- HSL
- استبدال اللون
- ضبابية
- شفافية
- تأثير ألفا
- سلسلة التأثير
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

تمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [Picture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picture/) الخاص بالإطار واطلب [Picture::getImageTransform](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picture/getimagetransform/). المجموعة المرتجعة من النوع [ImageTransformOperationCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/) تتيح لك إلحاق، تعداد، فحص، إزالة، وإفراغ التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

توضح هذه المقالة سير عمل كامل للسطوع والتباين، تحويلات اللون، الضبابية، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مورد الصورة والصورة التي تعرضه كائنان مختلفان:

- [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) يخزن أو يشير إلى بيانات الصورة المصدر التي تملكها العرض التقديمي.
- [Picture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picture/) ينتمي إلى تعبئة صورة ويشير إلى مورد صورة بينما يخزن مجموعة تحويل الصورة.
- [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) هو شكل الشريحة الذي يمتلك تعبئة الصورة ذات الصلة، والهندسة، وإعدادات الاقتصاص، وتنسيقات المستوى الإطاري الأخرى.

لذلك، لا تُغيّر عمليات تحويل الصورة البايتات في [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/). عندما يتم تمرير نفس `PPImage` إلى [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addpictureframe/) أكثر من مرة، يحصل كل إطار صورة جديد على `Picture` خاص به ومجموعة تحويل خاصة به. تطبيق التحويل إلى تدرج الرمادي على إطار واحد لا يجعل الأطر الأخرى تدرج رمادي، حتى وإن كانت جميعها تعيد استخدام نفس مورد الصورة المضمن.

نفس نموذج `Picture::getImageTransform` يُستخدم أيضًا من قبل تعبئات الصور الأخرى، مثل الشكل أو خلفية الشريحة. تركز الأمثلة أدناه على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعلمات**

تستخدم الطرق الموضحة النطاقات الدلالية والوحدات التالية. احتفظ بالقيم ضمن هذه النطاقات حتى إذا لم يرفض إصدار مكتبة معين كل قيمة خارجة عن النطاق فورًا؛ قد يقوم تنسيق العرض المستهدف بتطبيع أو حذف أو رفض البيانات غير الصالحة أثناء الحفظ أو عندما يفتح PowerPoint الملف.

| العملية | المعلمات | النطاق والوحدة الصالحة |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | من `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن بدون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | لا شيء | لا معلمات رقمية. لا يتغيّر ألفا. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | لونان للبكسلات الداكنة والفاتحة. قنوات RGB وألفا في `java.awt.Color` تستخدم `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ `amount` من `-100` إلى `100`، نسبة مئوية. |
| [addHSLEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ التشبع والإنارة من `-100` إلى `100`، نسبة مئوية. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | اللون البديل يستخدم قيم القنوات من `0` إلى `255`. قيم ألفا الحالية لا تتغيّر. |
| [addBlurEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` غير سالب ويقاس بالنقاط؛ `grow` هو قيمة منطقية تتحكم فيما إذا كان المحتوى الضبابي قد يمتد خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادية: `0` شفاف تمامًا و`100` يحافظ على ألفا الحالي. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | من `0` إلى `100`، نسبة مئوية للشفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | من `0` إلى `100`، نسبة مئوية للعتبة ألفا. القيم الأقل تصبح شفافة؛ القيم عند أو فوق العتبة تصبح غير شفافة. |

بالنسبة لتعديل ألفا الثابت، الشفافية والعتامة متكاملتان. على سبيل المثال، 35% شفافية تعادل تعديل ألفا بمقدار 65%.

## **تطبيق السطوع والتباين**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) يُعيد عملية [Luminance](https://reference.aspose.com/slides/ar/php-java/aspose.slides/luminance/). تُحدد الإعدادات العددية عند إنشاء العملية. [Luminance::getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/luminance/geteffective/) يُعيد القيم المقروءة فقط التي يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15% والتباين بنسبة 20%، ثم يعرض معاينة دون تعديل الصورة المضمنة:

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

`Luminance` هو تأثير السطوع والتباين القياسي في DrawingML. عندما يجب أن تبقى هذه الإعدادات قابلة للتحرير بعد جولة PPTX، أعد فتح العرض المولّد وتحقق من كل من نوع العملية وقيمها الفعّالة.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تُعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمس إطارات ويطبق تدرج رمادي، ثنائية اللون، تلوين، تعديل HSL، واستبدال اللون.

[Duotone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/duotone/) يحتوي على معلمتين لونيّتين قابلتين للتحرير بشكل مستقل: `color1` يطابق البكسلات الداكنة، بينما `color2` يطابق البكسلات الفاتحة. هذا يجعله مثالًا مفيدًا لتأثير إعداداته أكثر تعقيدًا من قيمة عددية واحدة.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) يستبدل لون كل بكسل بلون ثابت مع الحفاظ على ألفا. وهو مختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/)، الذي يطابق لون مصدر إلى لون آخر ويظهر صيغتي اللون المصدر والهدف.

## **إضافة الضبابية والشفافية وتأثيرات ألفا**

[addBlurEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) يؤثر على جميع قنوات اللون، بما فيها ألفا. اضبط `grow` إلى `true` عندما قد يمتد الحافة الضبابية خارج حدود الصورة الأصلية.

لتحقق شفافية موحدة، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). فهو يضرب كل قيمة ألفا موجودة، لذا تبقى البكسلات شبه الشفافة نسبياً مختلفة. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) يعيّن قيمة ألفا واحدة لجميع البكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) يحول ألفا إلى مستويين بناءً على عتبة.

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

تشمل عمليات ألفا الأخرى التي لا تحتاج إلى معلمات [addAlphaCeilingEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/)، التي تجعل كل ألفا غير الصفر كاملًا غير شفاف؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/)، التي تجعل كل ألفا أقل من 100% شفافية تمامًا؛ و[addAlphaInverseEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/)، التي تغير ألفا إلى `100% - alpha`.

## **إنشاء سلسلة تأثير مرتبة**

كل طريقة `add...Effect` تُلحق عملية جديدة إلى نهاية المجموعة. يستخدم المُعالج المجموعة كخط أنابيب مرتب: مخرج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، قد ينتج عن نفس العمليات بترتيب مختلف صورة مختلفة.

على سبيل المثال، تطبيق تدرج رمادي ثم تلوين يزيل أولاً المعلومات اللونية ثم يُعيد تلوين نتيجة الإنارة. تطبيق تلوين ثم تدرج رمادي يزيل التلوين مرة أخرى. وبالمثل، يمكن لاستبدال ألفا أن يتجاوز قيم ألفا التي حسبتها عمليات سابقة، بينما يظل تعديل ألفا يحافظ على الفروق النسبية بينها.

المثال التالي يبني سلسلة من أربع عمليات، يحفظها كـ PPTX، يفتح العرض مرة أخرى، يتحقق من كل من أنواع العمليات وترتيبها، ثم يعرض النتيجة المفتوحة:

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

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، ألفا، والضبابية بسلاسل منفصلة. يمكن دمجها، لكن الجمع قد لا يكون دائمًا مفيدًا. استبدال لون ثابت يزيل تباين RGB الناتج عن تأثيرات اللون السابقة؛ تدرج رمادي بعد ثنائية اللون يزيل اللونين المختارين؛ وعملية سقف ألفا أو أرضية ألفا أو الاستبدال أو المستوى الثنائي يمكنها إهمال تفاصيل ألفا التي أنشئت سابقًا. ابنِ السلسلة وفق تسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها كعلامات تنسيق غير مرتبة.

## **فحص القيم القابلة للتحرير والفعّالة**

العملية القابلة للتحرير هي الكائن المخزن في `Picture::getImageTransform`. حسب التأثير، قد تكشف عن أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [Blur](https://reference.aspose.com/slides/ar/php-java/aspose.slides/blur/) ي exposing قيم `radius` و `grow` القابلة للكتابة، و[AlphaModulateFixed](https://reference.aspose.com/slides/ar/php-java/aspose.slides/alphamodulatefixed/) ي exposing `amount` القابل للكتابة، و[AlphaBiLevel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/alphabilevel/) ي exposing `threshold` القابل للكتابة. تأثيرات اللون مثل [Duotone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/duotone/) تكشف عن كائنات [ColorFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colorformat/) القابلة للتعديل.

بعض العمليات، بما في ذلك [Luminance](https://reference.aspose.com/slides/ar/php-java/aspose.slides/luminance/)، [HSL](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hsl/)، [Tint](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tint/)، و[AlphaReplace](https://reference.aspose.com/slides/ar/php-java/aspose.slides/alphareplace/)، لا تكشف عن المتغيرات العددية التي أنشئت بها كخصائص قابلة للكتابة. لتغيير هذه الإعدادات، احذف العملية وأضف بديلًا في الموقع المطلوب.

البيانات الفعّالة التي تُعيدها `getEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل الألوان المعتمدة على السمات وقراءة القيم المُطَبَّقة التي يستخدمها المُعالج، لكنها ليست سطح تحرير آخر. المثال التالي يعدّد السلسلة ويفحص القيم الفعّالة حيث توفر API ما لها:

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

التأثيرات التي لا تحتاج إلى معلمات مثل تدرج رمادي، سقف ألفا، وعكس ألفا لا يزال لها كائن بيانات فعّالة، لكن لا توجد إعدادات عددية لطباعة. وجودها وموقعها في المجموعة هو المعلومات الهامة.

## **إزالة أو إفراغ تحويلات الصورة**

استخدم [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/removeat/) لإزالة عملية واحدة وفق الفهرس. نظرًا لتغيير الفهارس بعد الإزالة، ابحث عن الهدف أولاً وأزله بعد العد. استخدم [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagetransformoperationcollection/clear/) لإزالة السلسلة بالكامل.

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

إزالة أو إفراغ التحويلات يغيّر تنسيق الصورة فقط. لا يحذف، أو يُعيد ضغط، أو يُغيّر مورد [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) المُعاد استخدامه.

## **مراعاة تنسيقات العرض وأهداف التصدير**

تنشأ تحويلات الصورة في DrawingML، لذا يعتبر PPTX التنسيق القابل للتحرير المفضل لسلاسل التأثير. حتى مع PPTX، ليس كل عملية لها قابلية نقلية مطابقة:

- عمليات DrawingML القياسية مثل السطوع، تدرج رمادي، ثنائية اللون، التلوين، HSL، الضبابية، وعملية ألفا الشائعة لديها أفضل فرص للبقاء بعد جولة PPTX. دائمًا أعد فتح الملف المُولد وتفحص المجموعة عندما تكون المحافظة مطلبًا.
- تنسيق PPT الثنائي يسبق نموذج تأثير DrawingML الكامل. قد يتجاهل حفظ إلى PPT عمليات غير مدعومة، يقلل السلسلة إلى مجموعة فرعية مدعومة، أو يقرب المظهر. لا تستخدم PPT كتنسيق تحقق لسلسلة قابلة للتحرير معقدة.
- التحويل إلى PNG أو JPEG أو TIFF أو PDF أو SVG أو HTML أو أي مخرج بصري آخر يطبق السلسلة المدعومة على المظهر المُرَسَم. تلك المخرجات لا تحتوي على `ImageTransformOperationCollection` قابل للتحرير؛ تنسيقات النقطية تُسطّح النتيجة إلى بكسلات، وتصديرات المستند أو المتجه تخزن تمثيلًا خاصًا بها للعرض.
- التأثيرات لا تجعل الصورة المرتبطة ذاتيًا مكتفية. ما زال عرض صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض.

قد يُظهر مستهلكو العروض المختلفون الحالات الحدية بشكل مختلف، خاصةً عندما تُدمج عدة عمليات ألفا أو تكميم لون. للاختبار المضمون، اختبر كلًا من جولة التحرير النهائية وتنسيق التصدير النهائي باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة المتكررة**

**هل تُغيّر تأثيرات تحويل الصورة بيانات الصورة المضمنة؟**

لا. العمليات تنتمي إلى `Picture` المستخدمة في تعبئة الصورة. تبقى بايتات `PPImage` الأساسية دون تغيير.

**هل مشاركة إطارين صورة يعيدان استخدام نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `PPImage` تجنّب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يملك `Picture` ومجموعة تحويل صورة منفصلة.

**هل يمكن دمج تأثيرات اللون والضبابية وألفا؟**

نعم. تقبل المجموعة جميعها في سلسلة مرتبة واحدة. ضع في اعتبارك ما يفعله كل عملية على ناتج السابقة لأن عمليات الاستبدال والعتبة قد تُزيل تفاصيل اللون أو ألفا السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

تمثل البيانات الفعّالة القيم المحسوبة المستخدمة في العرض، بما فيها الألوان المحسومة. حرّر العملية المخزنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلًا بمعلمات إنشاء جديدة.

**أي تنسيق يجب أن أستخدمه للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن لتنسيق PPT القديم تمثيل نموذج تأثير DrawingML بالكامل، وتنسيقات التصدير النهائية تحافظ على المظهر فقط دون عمليات تحويل قابلة للتحرير.