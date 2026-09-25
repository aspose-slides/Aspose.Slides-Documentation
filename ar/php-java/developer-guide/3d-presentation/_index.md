---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام PHP
linktitle: عرض تقديمي ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/php-java/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض
- PHP
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في PHP باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبروز، والتعبئات، والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for PHP عبر Java إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنصوص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، والبروز، والحواف المائلة، والإضاءة، والمواد، وتعبئات التدرج أو الصور، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
يتناول هذا المقال تأثيرات تنسيق ثلاثية الأبعاد على أشكال PowerPoint والنص. لا يتعلق بإدراج أو تعديل ملفات نماذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بعرض هذه التأثيرات ثلاثية الأبعاد في الناتج ثنائي الأبعاد المُصدَّر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم الطريقة [Shape::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getThreeDFormat--) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة كائنًا من النوع [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/)، الذي يتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

للنص، استخدم الطريقة [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . يطبق هذا تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم أعضاء API هي:

| عضو API | ما الذي يتحكم فيه | متى يتم استخدامه |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getCamera--) | نقطة العرض، نوع الكاميرا المُعد مسبقًا، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getLightRig--) | إعداد الضوء المسبق، الاتجاه، ودوران الضوء. | تغيير مظهر الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setMaterial-byte-) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | جعل الشكل الهندسي نفسه يبدو مسطحًا أكثر، أو ناعمًا، أو لامعًا، أو معدنيًا. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | المسافة التي يمتد فيها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى جسم ثلاثي الأبعاد سميك بشكل مرئي. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getExtrusionColor--) | لون الجوانب البارزة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الواجهة الأمامية. |
| [getDepth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setDepth-double-) | عمق ثلاثي الأبعاد إضافي يُستخدم في تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحواف والمواد. |
| [getBevelTop](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getBevelBottom--) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة مُنعّمة أو مصبوبة بدلاً من وجه حاد مسطح. |
| [getContourColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setContourWidth-double-) | الحد الخارجي حول الكائن ثلاثي الأبعاد. | التأكيد على حدود الكائن في المخرجات المعروضة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا الأبعاد بشكلٍ مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البروز.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجانبين قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات البروز أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البروز هو 100 نقطة. يُظهر المثال الشريحة كصورة PNG بمقاس ضعف الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الصورة المعروضة تظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مُعروض مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من لوحة 3-D Rotation. قيم دوران X و Y و Z تتطابق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة 3-D Rotation في PowerPoint مع إبراز قيم الدوران X و Y و Z](img_02_01.png)

في Aspose.Slides، يمكن الوصول إلى الكاميرا عبر [ThreeDFormat::getCamera](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getCamera--). هذا المثال ينشئ مستطيلًا، يختار عرضًا أماميًا أرثوغرافيًا، ويضبط دورانات X و Y و Z إلى 20 و30 و40 درجة على التوالي. يكوّن الشكل في الذاكرة دون حفظ ملف:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائي الأبعاد على الشريحة. يغيّر منظور ثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides عند العرض.

## **إضافة بروز وعمق**

البروز يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم عنصر التحكم في العمق في هذا السماكة المرئية، وتتحكم خاصية اللون في لون الجوانب.

![عناصر تحكم العمق في PowerPoint مرتبطة بخصائص لون البروز وارتفاع البروز](img_02_02.png)

استخدم [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) لتعيين السماكة و[ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getExtrusionColor--) للوصول إلى لون الجوانب. يعطي هذا المثال للمستطيل بروزًا بطول 100 نقطة مع جوانب أرجوانية ويدور الكاميرا لإظهار سماكته. يكوّن الشكل في الذاكرة دون حفظ ملف:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

طريقة [ThreeDFormat::setDepth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setDepth-double-) تحدد عمق الشكل الثلاثي الأبعاد. طريقة [setExtrusionHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) تتحكم في ارتفاع تأثير البروز، كما هو موضح في هذا المثال.

## **استخدام تعبئات التدرج أو الصورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون ثابت أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي ومع ذلك استخدام نفس إعدادات الكاميرا والإضاءة والمادة والبروز.

هذا المثال يطبق تدرجًا أزرق إلى برتقالي على الوجه الأمامي ولونًا برتقاليًا داكنًا على البروز بطول 150 نقطة. يتوقف التدرج عند 0 و100 لتحديد بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُعرض الشريحة كصورة PNG بمقاس ضعف الأبعاد الافتراضية:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

المخرجات المعروضة تحتفظ بالتدرج على الوجه الأمامي وتعرض البروز بشكل منفصل:

![مستطيل ثلاثي الأبعاد مُعروض مع تعبئة تدرج أزرق إلى برتقالي وبروز برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال وجود ملف موجود باسم "image.jpg" في دليل العمل. يمدّد الصورة لملء المستطيل، يطبّق بروزًا بطول 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يكوّن الشكل في الذاكرة دون حفظ أو عرض ملف:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

يتم عرض الصورة على الوجه الأمامي، بينما يُعرض البروز كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مُعروض مع تعبئة صورة على الوجه الأمامي وبروز برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الحروف نفسها إلى البروز، المادة، الإضاءة، وإعدادات الكاميرا.

المثال التالي ينشئ نصًا بنمط شبكة برتقالية-بيضاء، يطبق قوسًا صاعدًا، ويكوّن إعدادات ثلاثية الأبعاد عبر [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#getThreeDFormat--). ارتفاع البروز والعمق بالنقاط، ودوران الإضاءة بالدرجات. تعبئة الشكل والحد الخارجي مخفيان بحيث يكون النص هو المرئي فقط. يُظهر المثال صورة PNG بمقاس ضعف أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النص يُعرض كحروف ثلاثية الأبعاد منحنية ومبروز:

![نص ثلاثي الأبعاد مُعرض مع تحويل WordArt مقوس، تعبئة بنمط برتقالي، وبروز داكن](img_02_05.png)

## **إبقاء النص مسطحًا على شكل ثلاثي الأبعاد**

لإبقاء النص قابلًا للقراءة مع الحفاظ على مظهر الشكل الثلاثي الأبعاد، استخدم [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) عبر [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getTextFrameFormat--). عندما تكون القيمة `true`، يبقى النص خارج المشهد الثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع توجيه ثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق ثلاثي الأبعاد للشكل: لا تزال الكاميرا والإضاءة والمادة والبروز مكوّنة عبر [Shape::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getThreeDFormat--). وهو مختلف أيضًا عن الدوران العادي. [Shape::setRotation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#setRotation-float-) يدور الشكل في مستوى الشريحة، بينما [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) يتحكم في دوران النص داخل مربع حدوده. إبقاء النص خارج المشهد الثلاثي الأبعاد لا يعيد ضبط أي من هذين الزاويتين.

المثال التالي المستقل ينشئ مستطيلًا أزرقًا مع نص ويستنسخه بجانب الأصلي. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ الفرق فقط في إعداد النص: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البروز 40 نقطة. يحفظ المثال العرض التقديمي كملف PPTX ويعرض شريحة المقارنة كصورة PNG بمقاس ضعف الأبعاد الافتراضية.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

على اليسار، يتبع النص اتجاه ثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل قراءة. كلا المستطيلين يحتفظان بنفس البروز المرئي والاتجاه الثلاثي الأبعاد.

![مستطيلات ثلاثية الأبعاد جنبًا إلى جنب: النص يتبع الاتجاه ثلاثي الأبعاد على اليسار ويبقى مسطحًا على اليمين](keep_text_flat.png)

## **سلوك التصدير والعرض**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ثابتة التخطيط، يتم تحويل المشهد ثلاثي الأبعاد إلى رستر أو يُرسم في الإخراج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تقوم بعرض الشرائح إلى [PNG](/slides/ar/php-java/convert-powerpoint-to-png/)، أو تصدير إلى [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، أو تصدير إلى [HTML](/slides/ar/php-java/convert-powerpoint-to-html/)، أو توليد إطارات لتحويل الفيديو عبر [video conversion](/slides/ar/php-java/convert-powerpoint-to-video/).

- الصور وملفات PDF المصدَّرة ليست تفاعلية. لا يمكن للمستخدم تدوير الكائن بعد التصدير.  
- المظهر النهائي يعتمد على مزيج الكاميرا، وإضاءة rig، والمادة، والبروز، والتعبئة، وتكبير الشريحة.  
- إذا كنت بحاجة إلى فحص القيم الموروثة أو التي تعتمد على السمة، اقرأ [effective shape properties](/slides/ar/php-java/shape-effective-properties/).  
- بعض صيغ الإخراج لا تستطيع تخزين تنسيق ثلاثي الأبعاد القابل للتحرير في PowerPoint. في هذه الصيغ، يتم عرض النتيجة بصريًا بدلاً من الحفاظ عليها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**  
إن Aspose.Slides ينشئ ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعله الصور أو ملفات PDF أو صفحات HTML تفاعلية بحيث يمكن للمشاهد تدويرها. في PPTX يبقى تنسيق ثلاثي الأبعاد قابلًا للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين النموذج الثلاثي الأبعاد والتأثير الثلاثي الأبعاد؟**  
النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد منفصل يُدرج في العرض التقديمي. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البروز، الحافة، الإضاءة، والمادة. يتناول هذا المقال التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة لظهور شكل ثلاثي الأبعاد واضح؟**  
على الأقل، عيّن دوران الكاميرا وإما البروز أو العمق. عمليًا، يُفضَّل أيضًا تعيين إضاءة rig والمادة للحصول على إضاءات وظلال واضحة على الأسطح.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كلٍ من الأشكال والنص؟**  
نعم. استخدم [Shape::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getThreeDFormat--) لجسم الشكل و[TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#getThreeDFormat--) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**  
نعم. يقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنشاء صور الشرائح، أو إخراج PDF، أو إخراج HTML، وإطارات الفيديو. يحتوي الإخراج المصدَّر على المظهر المصور، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

**هل يمكنني قراءة القيم النهائية الثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات السمة؟**  
نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [Shape Effective Properties](/slides/ar/php-java/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة rig، والحافة، والقيم الثلاثية الأبعاد ذات الصلة.