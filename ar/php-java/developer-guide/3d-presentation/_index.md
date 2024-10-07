---
title: تقديم ثلاثي الأبعاد
type: docs
weight: 232
url: /php-java/3d-presentation/
keywords:
- ثلاثي الأبعاد
- باوربوينت ثلاثي الأبعاد
- تقديم ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- تقديم باوربوينت
- PHP
- Aspose.Slides لـ PHP عبر Java
description: "تقديم باوربوينت ثلاثي الأبعاد بلغة PHP"
---

## نظرة عامة
منذ إصدار Aspose.Slides Java 20.9، أصبح من الممكن إنشاء محتوى ثلاثي الأبعاد في العروض التقديمية. باوربوينت ثلاثي الأبعاد هو وسيلة لإضفاء الحيوية على العروض التقديمية. عرض الأشياء الموجودة في العالم الحقيقي 
بمحتوى ثلاثي الأبعاد، عرض نموذج ثلاثي الأبعاد لمشروعك التجاري المستقبلي، نموذج ثلاثي الأبعاد لمبنى أو ديكوره الداخلي، نموذج ثلاثي الأبعاد لشخصية لعبة، 
أو مجرد تمثيل ثلاثي الأبعاد لبياناتك.

يمكن إنشاء نماذج باوربوينت ثلاثية الأبعاد من أشكال ثنائية الأبعاد، من خلال تطبيق تأثيرات مثل: دوران ثلاثي الأبعاد، عمق ثلاثي الأبعاد وبروز، تدرج ثلاثي الأبعاد، نص ثلاثي الأبعاد، إلخ.
يمكن العثور على قائمة الميزات ثلاثية الأبعاد المطبقة على الأشكال في **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**.
يمكن الحصول على مثيل من الفئة بواسطة:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)**، لإنشاء نموذج ثلاثي الأبعاد في باوربوينت.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)**، لإنشاء نص ثلاثي الأبعاد 
(WordArt).

يمكن استخدام جميع التأثيرات المطبقة في **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** لكل من الأشكال والنصوص.
دعنا نلقي نظرة سريعة على الأساليب الرئيسية في **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. في المثال التالي
نقوم بإنشاء شكل مستطيل ثنائي الأبعاد مع نص عليه. من خلال الحصول على عرض الكاميرا على الشكل، نغير دورانه ونجعله يبدو كنموذج ثلاثي الأبعاد. إعداد إضاءة مسطحة 
واتجاهها نحو أعلى النموذج ثلاثي الأبعاد، لإضفاء المزيد من الحجم على النموذج. المواد المتغيرة، ارتفاع البروز واللون تجعل النموذج ثلاثي الأبعاد يبدو أكثر حيوية.  
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

إليك النموذج ثلاثي الأبعاد الناتج:

![todo:image_alt_text](img_01_01.png)

## دوران ثلاثي الأبعاد
يمكن عمل دوران النموذج ثلاثي الأبعاد في باوربوينت عبر قائمة:

![todo:image_alt_text](img_02_01.png)

لدوران النموذج ثلاثي الأبعاد باستخدام واجهة برمجة تطبيقات Aspose.Slides، استخدم **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)**
الطريقة، اضبط دوران الكاميرا بالنسبة للشكل ثلاثي الأبعاد:

``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... اضبط معلمات المشهد ثلاثي الأبعاد الأخرى

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```

## عمق ثلاثي الأبعاد وبروز
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)**
و**[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** تستخدم لإنشاء بروز على الشكل:

``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
# ... اضبط معلمات المشهد ثلاثي الأبعاد الأخرى

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```

في باوربوينت، يتم تعيين عمق الشكل عبر:

![todo:image_alt_text](img_02_02.png)

## تدرج ثلاثي الأبعاد
يمكن أن يجلب التدرج ثلاثي الأبعاد المزيد من الحجم لشكل باوربوينت ثلاثي الأبعاد:

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

إليك كيف يبدو ذلك:

![todo:image_alt_text](img_02_03.png)

يمكنك أيضًا إنشاء تدرج صورة:
``` php
$shape->getFillFormat()->setFillType(FillType::Picture);

$image = Images->fromFile("image.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
# ... إعداد 3D: shape.ThreeDFormat.Camera، shape.ThreeDFormat.LightRig، shape.ThreeDFormat.Extrusion* الخصائص

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```

إليك النتيجة:

![todo:image_alt_text](img_02_04.png)

## نص ثلاثي الأبعاد (WordArt)
لإنشاء نص ثلاثي الأبعاد (WordArt)، اتبع ما يلي:
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
# إعداد تأثير تحويل "قوس لأعلى" لنص الـ WordArt
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

إليك النتيجة:

![todo:image_alt_text](img_02_05.png)

## غير مدعوم - قادم قريبًا
الميزات التالية في باوربوينت ثلاثي الأبعاد غير مدعومة بعد:
- حافة
- مادة
- محيط
- إضاءة