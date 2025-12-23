---
title: إنشاء عروض تقديمية ثلاثية الأبعاد في PHP
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/php-java/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- تدوير ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- استخراج ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية في PHP باستخدام Aspose.Slides بسهولة. تصدير سريع إلى صيغ PowerPoint و OpenDocument للاستخدام المتنوع."
---

## **نظرة عامة**
منذ إصدار Aspose.Slides Java 20.9 أصبح من الممكن إنشاء رسومات ثلاثية الأبعاد في العروض التقديمية. PowerPoint 3D هو طريقة لإضفاء الحيوية على العروض. اعرض كائنات العالم الحقيقي باستخدام عرض ثلاثي الأبعاد، أو قدم نموذجًا ثلاثيًا لمشروع عملك المستقبلي، أو نموذجًا ثلاثيًا للمبنى أو داخله، أو نموذجًا ثلاثيًا لشخصية اللعبة، أو مجرد تمثيل ثلاثي الأبعاد لبياناتك.

يمكن إنشاء نماذج PowerPoint 3D من الأشكال ثنائية الأبعاد عن طريق تطبيق هذه التأثيرات عليها: تدوير ثلاثي الأبعاد، عمق ثلاثي الأبعاد واستخراج، تدرج ثلاثي الأبعاد، نص ثلاثي الأبعاد، إلخ. يمكن العثور على قائمة ميزات 3D المطبقة على الأشكال في الفئة **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. يمكن الحصول على نسخة من الفئة عبر:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)** طريقة لإنشاء نموذج PowerPoint ثلاثي الأبعاد.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** طريقة لإنشاء نص ثلاثي الأبعاد (WordArt).

جميع التأثيرات المطبقة في **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** يمكن استخدامها لكل من الأشكال والنص. دعونا نلقي نظرة سريعة على الطرق الرئيسية في فئة **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. في المثال التالي نُنشئ شكلًا مستطيلاً ثنائي الأبعاد مع نص عليه. من خلال الحصول على منظور الكاميرا على الشكل، نُغيّر دورانه لجعله يُظهر كأنّه نموذج ثلاثي الأبعاد. ضبط إضاءة مسطحة واتجاهها إلى أعلى النموذج الثلاثي الأبعاد يضيف حجمًا أكبر للنموذج. تعديل المواد، ارتفاع الاستخراج واللون يجعل النموذج الثلاثي الأبعاد يبدو أكثر حيوية.
``` php 
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("sandbox_3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


هذا هو نموذج 3D الناتج:

![todo:image_alt_text](img_01_01.png)

## **تدوير 3D**
يمكن إجراء تدوير نموذج 3D في PowerPoint عبر القائمة:

![todo:image_alt_text](img_02_01.png)

لتدوير نموذج 3D باستخدام Aspose.Slides API، استخدم طريقة **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)**، ثم اضبط دوران الكاميرا بالنسبة إلى الشكل ثلاثي الأبعاد:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... اضبط باقي معلمات المشهد ثلاثي الأبعاد

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


## **عمق 3D واستخراج**
طريقة **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** و **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** تُستخدم لإنشاء استخراج على الشكل:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
# ... اضبط باقي معلمات المشهد ثلاثي الأبعاد

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


في PowerPoint، يتم تعيين عمق الشكل عبر:

![todo:image_alt_text](img_02_02.png)

## **تدرج 3D**
يمكن لتدرج 3D أن يضيف حجمًا أكبر إلى شكل PowerPoint ثلاثي الأبعاد:
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getFillFormat()->setFillType(FillType::Gradient);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 255, 140, 0));

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->dispose();
```


هذا هو الشكل:

![todo:image_alt_text](img_02_03.png)
  
يمكنك أيضًا إنشاء تدرج صورة:
``` php
$shape->getFillFormat()->setFillType(FillType::Picture);

$image = Images->fromFile("image.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
# ... إعداد ثلاثي الأبعاد: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* الخصائص

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


هذا هو النتيجة:

![todo:image_alt_text](img_02_04.png)

## **نص 3D (WordArt)**
لإنشاء نص ثلاثي الأبعاد (WordArt)، اتبع الخطوات التالية:
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getFillFormat()->setFillType(FillType::NoFill);
$shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
$shape->getTextFrame()->setText("3D Text");

$portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
$portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new java("java.awt.Color", 255, 140, 0));
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);
$textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
# إعداد تأثير تحويل WordArt "Arch Up"
$textFrameFormat->setTransform(TextShapeType::ArchUp);

$textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
$textFrameFormat->getThreeDFormat()->setDepth(3);
$textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
$textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
$textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
$textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("text3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("text3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


هذا هو النتيجة:

![todo:image_alt_text](img_02_05.png)

## **الأسئلة الشائعة**

**هل سيتم حفظ تأثيرات ثلاثية الأبعاد عند تصدير العرض إلى صور/PDF/HTML؟**

نعم. يقوم محرك Slides ثلاثي الأبعاد بتطبيق تأثيرات ثلاثية الأبعاد عند التصدير إلى الصيغ المدعومة ([images](/slides/ar/php-java/convert-powerpoint-to-png/), [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/ar/php-java/convert-powerpoint-to-html/), إلخ).

**هل يمكنني استرجاع القيم "الفعّالة" (النهائية) لمعلمات 3D التي تأخذ في الاعتبار القوالب والوراثة وغيرها؟**

نعم. توفر Slides واجهات برمجة تطبيقات ل[قراءة القيم الفعّالة](/slides/ar/php-java/shape-effective-properties/) (بما في ذلك للـ 3D—الإضاءة، الحواف، إلخ) حتى تتمكن من رؤية الإعدادات النهائية المطبقة.

**هل تعمل تأثيرات 3D عند تحويل العرض إلى فيديو؟**

نعم. عند [إنشاء إطارات للفيديو](/slides/ar/php-java/convert-powerpoint-to-video/)، يتم تطبيق تأثيرات 3D بنفس الطريقة كما هي في [الصور المصدرة](/slides/ar/php-java/convert-powerpoint-to-png/).