---
title: إنشاء عروض تقديمية ثلاثية الأبعاد على Android
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/androidjava/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- استخراج ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية في Java باستخدام Aspose.Slides للـ Android بسهولة. تصدير سريع إلى صيغ PowerPoint و OpenDocument للاستخدام المتنوع."
---

## **Overview**
منذ Aspose.Slides Java 20.9 أصبح من الممكن إنشاء رسومات ثلاثية الأبعاد في العروض التقديمية. PowerPoint 3D هو طريقة لإضفاء الحيوية على العروض. اعرض الأجسام الواقعية باستخدام عرض ثلاثي الأبعاد، أو قدم نموذجًا ثلاثيًا لمشروع عملك المستقبلي، أو نموذجًا ثلاثيًا للمبنى أو داخله، أو نموذجًا ثلاثيًا لشخصية لعبة، أو مجرد تمثيل ثلاثي الأبعاد لبياناتك.

يمكن إنشاء نماذج PowerPoint 3D من أشكال ثنائية الأبعاد عن طريق تطبيق تأثيرات مثل: دوران ثلاثي الأبعاد، عمق واستخراج ثلاثي الأبعاد، تدرج لون ثلاثي الأبعاد، نص ثلاثي الأبعاد، إلخ. يمكن العثور على قائمة ميزات 3D المطبقة على الأشكال في الفئة **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**. يمكن الحصول على كائن الفئة عبر:

- طريقة **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)** لإنشاء نموذج PowerPoint 3D.
- طريقة **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** لإنشاء نص ثلاثي الأبعاد (WordArt).

جميع التأثيرات المطبقة في **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)** يمكن استخدامها لكل من الأشكال والنص. لنلقِ نظرة سريعة على الأساليب الرئيسية لفئة **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**. في المثال التالي ننشئ شكلاً مستطيلاً ثنائي الأبعاد مع نص عليه. من خلال الحصول على عرض الكاميرا على الشكل، نغيّر دواره لجعله يبدو كنموذج ثلاثي الأبعاد. ضبط إضاءة مسطحة واتجاهها إلى أعلى النموذج ثلاثي الأبعاد يضيف المزيد من الحجم للنموذج. تغير المواد، ارتفاع الاستخراج واللون يجعل النموذج الثلاثي الأبعاد يبدو أكثر حيوية.  
``` java 
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("sandbox_3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```


إليك النموذج الثلاثي الأبعاد الناتج:

![todo:image_alt_text](img_01_01.png)

## **3D Rotation**
يمكن إجراء دوران النموذج الثلاثي الأبعاد في PowerPoint عبر القائمة:

![todo:image_alt_text](img_02_01.png)

لتحريك النموذج الثلاثي الأبعاد باستخدام Aspose.Slides API، استخدم طريقة **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)**، ثم عيّن دوران الكاميرا نسبةً إلى الشكل الثلاثي الأبعاد:
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... تعيين معلمات المشهد ثلاثي الأبعاد الأخرى

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


## **3D Depth and Extrusion**
تُستخدم الطريقتان **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** و**[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** لإنشاء الاستخراج على الشكل:
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... تعيين معلمات المشهد ثلاثي الأبعاد الأخرى

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


في PowerPoint، يتم تعيين عمق الشكل عبر:

![todo:image_alt_text](img_02_02.png)

## **3D Gradient**
يمكن لتدرج اللون الثلاثي الأبعاد إضافة المزيد من الحجم إلى الشكل الثلاثي الأبعاد في PowerPoint:
``` java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getFillFormat().setFillType(FillType.Gradient);
shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.dispose();
```


هكذا يبدو الشكل:

![todo:image_alt_text](img_02_03.png)
  
يمكنك أيضًا إنشاء تدرج صورة:
``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... إعداد 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* الخصائص

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


النتيجة:

![todo:image_alt_text](img_02_04.png)

## **3D Text (WordArt)**
لإنشاء نص ثلاثي الأبعاد (WordArt)، اتبع الخطوات التالية:
``` java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getFillFormat().setFillType(FillType.NoFill);
shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
shape.getTextFrame().setText("3D Text");

Portion portion = (Portion)shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
// set the "Arch Up" WordArt transform effect
textFrameFormat.setTransform(TextShapeType.ArchUp);

textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
textFrameFormat.getThreeDFormat().setDepth(3);
textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("text3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("text3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```


النتيجة:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**هل يتم الحفاظ على تأثيرات 3D عند تصدير العرض إلى صور/PDF/HTML؟**

نعم. محرك Slides 3D يُعيد رسم تأثيرات 3D عند التصدير إلى الصيغ المدعومة ([الصور](/slides/ar/androidjava/convert-powerpoint-to-png/)، [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، إلخ).

**هل يمكنني استرجاع القيم "النهائية" (effective) لمعلمات 3D التي تأخذ في الاعتبار السمات والوراثة وغيرها؟**

نعم. توفر Slides واجهات برمجة تطبيقات لقراءة القيم الفعّالة ([read effective values](/slides/ar/androidjava/shape-effective-properties/)) (بما في ذلك إضاءة 3D، الحواف، إلخ) بحيث يمكنك رؤية الإعدادات النهائية المطبقة.

**هل تعمل تأثيرات 3D عند تحويل العرض إلى فيديو؟**

نعم. عند [إنشاء إطارات للفيديو](/slides/ar/androidjava/convert-powerpoint-to-video/)، يتم رسم تأثيرات 3D كما هو الحال عند [تصدير الصور](/slides/ar/androidjava/convert-powerpoint-to-png/).