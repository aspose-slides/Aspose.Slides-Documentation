---
title: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/androidjava/3d-presentation/
keywords:
- ثلاثي الأبعاد
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- عرض PowerPoint
- أندرويد
- Aspose.Slides من أجل أندرويد عبر Java
description: "عرض PowerPoint ثلاثي الأبعاد على أندرويد"
---

## نظرة عامة
منذ Aspose.Slides Java 20.9، أصبح من الممكن إنشاء عروض ثلاثية الأبعاد. PowerPoint ثلاثي الأبعاد هو طريقة لإضفاء الحياة على العروض. اعرض الأجسام الواقعية 
من خلال عرض ثلاثي الأبعاد، قدم نموذج ثلاثي الأبعاد لمشروع عملك المستقبلي، نموذج ثلاثي الأبعاد للمبنى أو داخله، نموذج ثلاثي الأبعاد لشخصية لعبة، 
أو مجرد تمثيل ثلاثي الأبعاد لبياناتك.

يمكن إنشاء نماذج PowerPoint ثلاثية الأبعاد من أشكال ثنائية الأبعاد، عن طريق تطبيق مثل هذه التأثيرات عليها: دوران ثلاثي الأبعاد، عمق ثلاثي الأبعاد وبروز، تدرج ثلاثي الأبعاد، نص ثلاثي الأبعاد، إلخ. 
يمكن العثور على قائمة الميزات ثلاثية الأبعاد المطبقة على الأشكال في **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**.
يمكن الحصول على نسخة من الفئة بواسطة:
 
- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)** الطريقة لإنشاء نموذج PowerPoint ثلاثي الأبعاد.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** الطريقة لإنشاء نص ثلاثي الأبعاد
(WordArt).

يمكن استخدام جميع التأثيرات المطبقة في **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)** لكل من الأشكال والنصوص.
دعونا نلقي نظرة سريعة على الأساليب الرئيسية لفئة **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**. في المثال التالي
نقوم بإنشاء شكل مستطيل ثنائي الأبعاد مع نص عليه. من خلال الحصول على عرض الكاميرا على الشكل، نقوم بتغيير دورانه ونجعل الشكل يبدو كنموذج ثلاثي الأبعاد. إعداد ضوء مسطح 
واتجاهه إلى أعلى النموذج الثلاثي الأبعاد، يضيف المزيد من الحجم للنموذج. المواد المتغيرة، ارتفاع البروز ولونها تجعل النموذج الثلاثي الأبعاد يبدو أكثر حيوية.  
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

إليكم النموذج الثلاثي الأبعاد الناتج:

![todo:image_alt_text](img_01_01.png)

## دوران ثلاثي الأبعاد
يمكن القيام بدوران النموذج الثلاثي الأبعاد في PowerPoint عبر القائمة:

![todo:image_alt_text](img_02_01.png)

لتدوير النموذج الثلاثي الأبعاد باستخدام واجهة برمجة التطبيقات Aspose.Slides، استخدم **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)**
الطريقة، واضبط دوران الكاميرا بالنسبة للشكل الثلاثي الأبعاد:

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... ضبط معلمات المشهد الثلاثي الأبعاد الأخرى

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

## عمق ثلاثي الأبعاد وبروز
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)**
و **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** الطريقتان
تستخدمان لإنشاء البروز على الشكل:

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... ضبط معلمات المشهد الثلاثي الأبعاد الأخرى

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

في PowerPoint، يتم ضبط عمق الشكل عبر:

![todo:image_alt_text](img_02_02.png)

## تدرج ثلاثي الأبعاد
يمكن أن يجلب التدرج الثلاثي الأبعاد المزيد من الحجم لشكل PowerPoint ثلاثي الأبعاد:

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

إليكم كيف يبدو:

![todo:image_alt_text](img_02_03.png)

يمكنكم أيضًا إنشاء تدرج صورة:
``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... إعداد 3D: shape.ThreeDFormat.Camera، shape.ThreeDFormat.LightRig، shape.ThreeDFormat.Extrusion* الخصائص

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

إليكم النتيجة:

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
shape.getTextFrame().setText("نص ثلاثي الأبعاد");

Portion portion = (Portion)shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
// تعيين تأثير تحويل WordArt "قوس لأعلى"
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

إليكم النتيجة:

![todo:image_alt_text](img_02_05.png)

## غير مدعوم - قادم قريبًا
الميزات الثلاثية الأبعاد التالية في PowerPoint غير مدعومة بعد: 
- تزويد
- مادة
- محيط
- إضاءة