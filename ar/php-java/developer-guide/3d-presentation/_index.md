---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام PHP
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/php-java/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض تقديمي ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد للأشكال والنص في PowerPoint باستخدام PHP مع Aspose.Slides. قم بتكوين الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides لـ PHP عبر Java إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد على طراز PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، التدرجات أو ملء الصورة، والنص ثلاثي الأبعاد.

{{% alert color="primary" %}}
هذه المقالة تتناول تأثيرات تنسيق ثلاثية الأبعاد على أشكال PowerPoint والنص. لا تتعلق بإدراج أو تعديل ملفات نموذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في الناتج الثنائي الأبعاد.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم فئة [الشكل](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) وطريقة [Shape::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getThreeDFormat--) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة كائن [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/) الذي يتحكم في مشهد ثلاثي الأبعاد لهذا الشكل.

للنص، استخدم فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/) وطريقة [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . يطبق ذلك تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم الإعدادات هي:

| الطريقة أو الإعداد | ما الذي يتحكم به | متى يستخدم |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getCamera--) | نقطة المشهد، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق للدوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getLightRig--) | إعداد ضوء مسبق، الاتجاه، ودوران الضوء. | تغيير طريقة ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [setMaterial](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setMaterial-byte-) | مادة السطح، مثل مسطّح، مطفي، بلاستيك، أو معدن. | اجعل الشكل نفسه يبدو أكثر تسطيحًا، نعومة، لمعانًا، أو ميتالياً. |
| [setExtrusionHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | المدى الذي يمتد فيه الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى جسم ثلاثي الأبعاد سميك يُرى بوضوح. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getExtrusionColor--) | لون الجوانب المُبثقة. | جعل العمق مرئيًا أو توافق لون الجوانب مع تعبئة الوجه الأمامي. |
| [setDepth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setDepth-double-) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خصوصًا مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getBevelBottom--) | حدود مرتفعة أو مستديرة على الوجهين الأمامي والخلفي. | إضافة حافة ناعمة أو مصقولة بدلاً من وجه مسطّح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getContourColor--) و [setContourWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setContourWidth-double-) | الحد الخارجي حول الكائن ثلاثي الأبعاد. | تسليط الضوء على حدود الكائن في المخرجات المعروضة. |

## **إنشاء شكل ثلاثي الأبعاد**

شكل عادةً يحتاج إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بأقناع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيقًا ثلاثيًا الأبعاد، يحفظ العرض التقديمي كملف PPTX، ويعرض الشريحة كصورة PNG.

```php
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

الصورة المُصدرة للعرض تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مُظهر مع نص أبيض ثلاثي الأبعاد على الوجه الأمامي](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة 3-D Rotation. قيم الدوران X و Y و Z تتوافق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة دوران 3-D في PowerPoint مع إبراز قيم الدوران X و Y و Z](img_02_01.png)

في Aspose.Slides، قم بتعيين نوع الكاميرا والدوران عبر [ThreeDFormat::getCamera](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل الثنائي الأبعاد على الشريحة. إنه يغيّر منظور ثلاثي الأبعاد الذي تستخدمه PowerPoint وAspose.Slides عند العرض.

## **إضافة البثق والعمق**

البثق يجعل الشكل يبدو سميكًا عن طريق إطالته خلف الوجه الأمامي. في PowerPoint، يتحكم عمق الإعداد في هذه السماكة المرئية، وتتحكم إعدادات اللون في لون الجوانب.

![ضوابط العمق في PowerPoint المرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

اضبط [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) لتحديد السماكة و[ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getExtrusionColor--) لتحديد لون الجوانب:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

استخدم [ThreeDFormat::setDepth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#setDepth-double-) عندما تحتاج إلى التعامل مباشرة مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة والمادة وتأثيرات النص. في العديد من حالات الأشكال، تكون `setExtrusionHeight` الإعداد أوضح لأنه يعبر مباشرة عن البثق المرئي.

## **استخدام التعبئات المتدرجة أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي ولا يزال بإمكانك استخدام نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تعبئة متدرجة على الشكل ولون بثق أغمق على الجوانب:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

المخرجات المعروضة تحافظ على التدرج على الوجه الأمامي وتعرض البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مع تعبئة تدرج أزرق إلى برتقالي وبثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

الصورة تُعرض على الوجه الأمامي، بينما يُعرض البثق كأسطح جانبية ثلاثية الأبعاد:

![مستطيل ثلاثي الأبعاد مع تعبئة صورة على الوجه الأمامي وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الأحرف نفسها إلى البثق والمادة والإضاءة وإعدادات الكاميرا.

المثال التالي ينشئ نصًا مع تعبئة نمط، يطبق تحويل WordArt، ويضبط إعدادات ثلاثية الأبعاد على [TextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/):

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

النص يُعرض كحروف ثلاثية الأبعاد منحنية ومبثقة:

![نص ثلاثي الأبعاد مُعرض مع تحويل WordArt مقوّس، تعبئة نمط برتقالي، وبثق داكن](img_02_05.png)

## **سلوك التصدير والعرض**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى تنسيقات PowerPoint مثل PPTX. عند العرض أو التصدير إلى تنسيقات ثابتة التخطيط، يتم تحويل مشهد ثلاثي الأبعاد إلى نقطية أو رسمه في المخرج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تقوم بعرض الشرائح إلى [PNG](/slides/ar/php-java/convert-powerpoint-to-png/)، أو تصدير إلى [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، أو تصدير إلى [HTML](/slides/ar/php-java/convert-powerpoint-to-html/)، أو إنشاء إطارات لـ [video conversion](/slides/ar/php-java/convert-powerpoint-to-video/).

ضع هذه النقاط في الاعتبار:

- الصور والملفات PDF المصدرة ليست تفاعلية. لا يمكن للمستخدم دوران الكائن بعد التصدير.
- المظهر النهائي يعتمد على دمج الكاميرا، نظام الإضاءة، المادة، البثق، التعبئة، وتوسيع الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [effective shape properties](/slides/ar/php-java/shape-effective-properties/).
- بعض تنسيقات الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك التنسيقات، يتم عرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **FAQ**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

Aspose.Slides ينشئ ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث يدعم ذلك التنسيق.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**

النموذج ثلاثي الأبعاد هو كائن ثلاثي الأبعاد مستقل يُدرج في العرض التقديمي. التأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. هذه المقالة تغطي التأثيرات ثلاثية الأبعاد.

**ما الإعدادات المطلوبة لشكل ثلاثي الأبعاد مرئي؟**

على الأقل، عيّن دوران الكاميرا وإما البثق أو العمق. عمليًا، يُفضّل أيضًا تعيين نظام الإضاءة والمادة حتى تظهر الوجوه بأضواء وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**

نعم. استخدم [Shape::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getThreeDFormat--) لجسم الشكل و[TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#getThreeDFormat--) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات الفيديو؟**

نعم. Aspose.Slides يعرض تأثيرات ثلاثية الأبعاد عند إنشاء صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات تُستخدم لتحويل الفيديو. يحتوي الإخراج المصدّر على الشكل المرئي، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

**هل يمكنني قراءة القيم النهائية ثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [Shape Effective Properties](/slides/ar/php-java/shape-effective-properties/) لقراءة الكاميرا النهائية، نظام الإضاءة، الحافة، والقيم الثلاثية الأبعاد ذات الصلة.