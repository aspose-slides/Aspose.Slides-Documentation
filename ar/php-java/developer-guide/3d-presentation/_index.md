---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام PHP
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/php-java/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في PHP باستخدام Aspose.Slides. ضبط الكاميرا والإضاءة والمواد والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for PHP عبر Java إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف، الإضاءة، الخامة، التعبئة بالتدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
تتناول هذه المقالة تأثيرات تنسيق ثلاثية الأبعاد على أشكال PowerPoint والنص. ليست حول إدراج أو تحرير ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بتطبيق تلك التأثيرات الثلاثية الأبعاد على المخرجات ثنائية الأبعاد.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة الكائن [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/)، الذي يتحكم في المشهد ثلاثي الأبعاد لذلك الشكل.

بالنسبة للنص، استخدم طريقة [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). يطبق هذا تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم أعضاء API هي:

| عضو API | ما الذي يتحكم فيه | متى يستخدم |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | نقطة المشاهدة، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق للدوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | إعداد مسبق للإضاءة، الاتجاه، ودوران الضوء. | تغيير كيفية ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | مادة السطح، مثل مسطح، غير لامع، بلاستيك أو معدن. | جعل الشكل نفسه يبدو أكثر تسطيحًا، ناعمًا، لامعًا أو معدنيًا. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | المسافة التي يمد فيها الشكل إلى الخلف من وجهه الأمامي. | تحويل الشكل المسطح إلى كائن ثلاثي الأبعاد سميك يُرى. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | لون الجوانب المُبثقة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الجزء الأمامي. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | عمق ثلاثي الأبعاد إضافي يُستخدم في تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مقلوبة بدلًا من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) و [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | الحد الخارجي حول الكائن ثلاثي الأبعاد. | تأكيد حدود الكائن في المخرجات المُصوَّرة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الإضاءة.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيق ثلاثي الأبعاد. قيم دوران الكاميرا بوحدات الدرجة، وارتفاع البثق هو 100 نقطة. يعرض المثال الشريحة كصورة PNG بمقاس ضعف الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

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

تُظهر صورة الشريحة المصدرة المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق تم عرضه مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **تدوير شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من لوحة 3‑D Rotation. قيم الدوران X وY وZ تتوافق مع الدوران الذي تحدده من خلال API الكاميرا.

![لوحة PowerPoint 3‑D Rotation مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، يمكن الوصول إلى الكاميرا عبر [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera). ينشئ هذا المثال مستطيلًا، يختار عرضًا أماميًا أرثوغرافيًا، ويضبط دورانات X وY وZ إلى 20 و30 و40 درجة على التوالي. يكوّن الشكل في الذاكرة دون حفظ ملف:

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

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائي الأبعاد على الشريحة. بل يغيّر وجهة النظر ثلاثية الأبعاد التي يستخدمها PowerPoint وAspose.Slides أثناء العرض.

### **نسخ توجيه الكاميرا من شكل قالب**

لمطابقة توجيه شكل القالب، اقرأ إعداد الكاميرا المسبق باستخدام [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) وزوايا الدوران باستخدام [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). يفتح المثال `template.pptx` وينسخ توجيه الكاميرا من الشكل الأول على الشريحة الأولى إلى الشكل الثاني. كلا الشكلين يحتويان بالفعل على إضاءة ثلاثية الأبعاد، ولا يحتوي الشكل الثاني على دوران كاميرا صريح.

الزوايا بوحدات الدرجة. الفهرس `0` هو خط العرض، الفهرس `1` هو خط الطول، والفهرس `2` هو الثورة. مرّرها إلى [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) بهذا الترتيب. إذا أعاد المصدر `null`، فهذا يعني أنه لا يوجد دوران صريح، لذا اترك زوايا الشكل الثاني غير مضبوطة. دوران صريح بـ `(0, 0, 0)` يعيد ثلاثة أصفار ويجب نسخه.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

عند إعادة فتح `camera-copy.pptx` في PowerPoint، يكون السهم على اليمين لديه نفس إعداد الكاميرا والدوران مثل المستطيل على اليسار. كلا الشكلين يستخدمان نفس الإضاءة وعمق البثق.

![مستطيل أزرق ثلاثي الأبعاد وسهم يميني باتجاه كاميرا مماثل، يُعرَض من الأعلى واليمين](camera-orientation.png)

## **إضافة البثق والعمق**

يضيف البثق سماكة إلى الشكل بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم عنصر العمق في هذه السماكة المرئية، ويتحكم عنصر اللون في لون الجوانب.

![تحكمات عمق PowerPoint مرتبطة بلون البثق وخصائص ارتفاع البثق](img_02_02.png)

استخدم [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) لتعيين السماكة و[ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) للوصول إلى لون الجوانب. يمنح هذا المثال مستطيلًا بارتفاع بثرق 100 نقطة مع جوانب أرجوانية ويدور الكاميرا لإظهار سماكته. يكوّن الشكل في الذاكرة دون حفظ ملف:

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

تضبط طريقة [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) عمق الشكل ثلاثي الأبعاد. تتحكم طريقة [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام التعبئات المتدرجة أو الصورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي وما زلت تستخدم نفس إعدادات الكاميرا، الإضاءة، المادة والبثق.

هذا المثال يطبق تدرج أزرق إلى برتقالي على الوجه الأمامي ولون برتقالي داكن على البثق بارتفاع 150 نقطة. يحدد توقفات التدرج عند 0 و100 لتحديد بداية ونهاية التدرج. قيم دوران الكاميرا بوحدات الدرجة. تُعرض الشريحة كصورة PNG بمقاس ضعف الأبعاد الافتراضية:

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

تحتفظ المخرجات المصدرة بالتدرج على الوجه الأمامي وتعرض البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد تم عرضه بتدرج أزرق‑برتقالي وتبعيل برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال وجود ملف موجود باسم "image.jpg" في دليل العمل. يمدّ الصورة لملء المستطيل، يطبق بثرقًا بارتفاع 150 نقطة، ويضبط دوران الكاميرا بوحدات الدرجة. يكوّن الشكل في الذاكرة دون حفظ أو عرض ملف:

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

تُعرض الصورة على الوجه الأمامي، بينما يُعرض البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد تم عرضه بتعبئة صورة على الوجه الأمامي وبثرق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تؤثر تنسيقات ثلاثية الأبعاد على جسم الشكل. أما تنسيقات ثلاثية الأبعاد على النص فتؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الأحرف نفسها إلى بثرق، مادة، إضاءة وإعدادات كاميرا.

المثال التالي ينشئ نصًا بنمط شبكة برتقالي‑أبيض، يطبق قوسًا صعوديًا، ويكوّن إعدادات ثلاثية الأبعاد عبر [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). ارتفاع البثرق والعمق بوحدات النقاط، ودوران الضوء بوحدات الدرجة. يتم إخفاء تعبئة الشكل والحد لتظهر الأحرف فقط. يُصدّر المثال صورة PNG بمقاس ضعف أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

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

يُعرض النص كحروف ثلاثية الأبعاد منحنية ومبثقة:

![نص ثلاثي الأبعاد تم عرضه بتحويل WordArt مقوس، تعبئة بنمط برتقالي، وبثرق داكن](img_02_05.png)

## **إبقاء النص مستويًا على شكل ثلاثي الأبعاد**

للحفاظ على قابلية قراءة النص مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، استدعِ [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) عبر [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat). عندما تكون القيمة `true` يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `false` يشارك النص في المشهد ويتبع توجيهه ثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق ثلاثي الأبعاد الخاص بالشكل: الكاميرا، والإضاءة، والمادة، والبثرق ما زالت مُعَدّة عبر [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat). وهو مختلف عن الدوران العادي. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) يدور الشكل في مستوى الشريحة، بينما [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) يتحكم في دوران النص داخل إطار الحدود الخاص به. إبقاء النص خارج المشهد ثلاثي الأبعاد لا يُعيد تعيين أي من هذين الزاويتين.

المثال الذاتي التالي ينشئ مستطيلًا أزرقًا مع نص ويستنسخه بجانب الأصلي. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ الاختلاف فقط في إعداد النص: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بوحدات الدرجة، وارتفاع البثرق 40 نقطة. يحفظ المثال العرض التقديمي كملف PPTX ويعرض شريحة المقارنة كصورة PNG بمقاس ضعف الأبعاد الافتراضية.

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

على اليسار، يتبع النص توجيه ثلاثي الأبعاد. على اليمين، يبقى مستويًا وأسهل قراءة. كلا المستطيلين يحتفظان بالبثرق المرئي نفسه وتوجيه ثلاثي الأبعاد.

![مستطيلان ثلاثيان جنبًا إلى جنب: النص يتبع توجيه ثلاثي الأبعاد على اليسار ويظل مستويًا على اليمين](keep_text_flat.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند حفظه بصيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ثابتة، يُرَسَّم المشهد ثلاثي الأبعاد أو يُدمج في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تعرِض الشرائح إلى [PNG](/slides/ar/php-java/convert-powerpoint-to-png/)، أو تصدر إلى [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، أو تصدر إلى [HTML](/slides/ar/php-java/convert-powerpoint-to-html/)، أو تُولِّد إطارات للتحويل إلى [فيديو](/slides/ar/php-java/convert-powerpoint-to-video/).

احرص على مراعاة النقاط التالية:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمستخدم تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، وإضاءة الإضاءة، والمادة، والبثرق، والتعبئة، وتدرج حجم الشريحة.
- إذا احتجت إلى فحص القيم التي تم توريثها أو القيم المستندة إلى السمة، اقرأ [خصائص الشكل الفعّالة](/slides/ar/php-java/shape-effective-properties/).
- لا تستطيع بعض صيغ الإخراج تخزين تنسيق ثلاثي الأبعاد القابل للتحرير في PowerPoint. في تلك الصيغ، يُعرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

ينشئ Aspose.Slides ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد منفصل يُدرج في العرض التقديمي. بينما التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. تغطي هذه المقالة التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة لظهور شكل ثلاثي الأبعاد؟**

يجب على الأقل ضبط دوران الكاميرا وإما البثق أو العمق. عمليًا، يُفضَّل أيضًا ضبط إضاءة الإضاءة والمادة حتى تكون الوجوه المُصوَّرة ذات إضاءات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟**

نعم. استخدم [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) لجسم الشكل و[TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) للنص.

**هل تظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. يقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، ناتج PDF، ناتج HTML، والإطارات المستخدمة للتحويل إلى فيديو. يحتوي الناتج المصدّر على المظهر المعروض، وليس كائنًا ثلاثيًا قابلًا للتحرير.

**هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق التوريث وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [خصائص الشكل الفعّالة](/slides/ar/php-java/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة الإضاءة، والحافة، والقيم الثلاثية الأبعاد ذات الصلة.