---
title: إنشاء عروض تقديمية ثلاثية الأبعاد في Java
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "إنشاء عروض تقديمية تفاعلية ثلاثية الأبعاد في Java باستخدام Aspose.Slides بسهولة. تصدير سريع إلى صيغ PowerPoint و OpenDocument للاستخدام المتنوع."
---

## نظرة عامة
منذ إصدار Aspose.Slides Java 20.9 أصبح من الممكن إنشاء محتوى ثلاثي الأبعاد في العروض التقديمية. PowerPoint 3D هو طريقة لإضفاء الحيوية على العروض. عرض الأجسام الواقعية باستخدام عرض ثلاثي الأبعاد، توضيح نموذج ثلاثي الأبعاد لمشروع عملك المستقبلي، نموذج ثلاثي الأبعاد للمبنى أو داخله، نموذج ثلاثي الأبعاد لشخصية لعبة، أو مجرد تمثيل ثلاثي الأبعاد لبياناتك.

يمكن إنشاء نماذج PowerPoint 3D من أشكال ثنائية الأبعاد عن طريق تطبيق تأثيرات مثل: تدوير ثلاثي الأبعاد، العمق والاستخراج ثلاثي الأبعاد، تدرج ثلاثي الأبعاد، نص ثلاثي الأبعاد، وغيرها. يمكن العثور على قائمة ميزات 3D المطبقة على الأشكال في الفئة **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**. يمكن الحصول على نسخة من الفئة عبر:

- طريقة **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getThreeDFormat--)** لإنشاء نموذج PowerPoint ثلاثي الأبعاد.
- طريقة **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** لإنشاء نص ثلاثي الأبعاد (WordArt).

جميع التأثيرات التي تم تنفيذها في **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)** يمكن استخدامها لكل من الأشكال والنص. دعونا نلقي نظرة سريعة على الطرق الرئيسية في فئة **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**. في المثال التالي نقوم بإنشاء شكل مستطيل ثنائي الأبعاد مع نص عليه. من خلال الحصول على عرض الكاميرا على الشكل، نغيّر تدويره لجعله يبدو كنموذج ثلاثي الأبعاد. ضبط إضاءة مسطحة واتجاهها إلى أعلى النموذج ثلاثي الأبعاد يضيف حجمًا أكبر للنموذج. تغيير المواد، ارتفاع الاستخراج واللون يجعل النموذج ثلاثي الأبعاد يبدو أكثر حيوية.
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


هنا النموذج ثلاثي الأبعاد الناتج:

![todo:image_alt_text](img_01_01.png)

## تدوير ثلاثي الأبعاد
يمكن القيام بتدوير نموذج ثلاثي الأبعاد في PowerPoint عبر القائمة:

![todo:image_alt_text](img_02_01.png)

لتدوير نموذج ثلاثي الأبعاد باستخدام Aspose.Slides API، استخدم طريقة **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getCamera--)**، واضبط تدوير الكاميرا بالنسبة للشكل ثلاثي الأبعاد:
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... ضبط باقي معلمات مشهد 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


## عمق ثلاثي الأبعاد واستخراج
تستخدم طريقتا **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** و**[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** لإنشاء استخراج على الشكل:
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... ضبط باقي معلمات مشهد 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


في PowerPoint، يتم ضبط عمق الشكل عبر:

![todo:image_alt_text](img_02_02.png)

## تدرج ثلاثي الأبعاد
يمكن للتدرج ثلاثي الأبعاد إضافة حجم أكبر إلى الشكل ثلاثي الأبعاد في PowerPoint:
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


هكذا يبدو:

![todo:image_alt_text](img_02_03.png)
  
يمكنك أيضًا إنشاء تدرج صورة:
``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... إعداد 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* properties

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


النتيجة:

![todo:image_alt_text](img_02_04.png)

## نص ثلاثي الأبعاد (WordArt)
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

## غير مدعوم - قادمًا قريبًا
الميزات التالية في PowerPoint 3D غير مدعومة بعد:
- Bevel
- Material
- Contour
- Lighting