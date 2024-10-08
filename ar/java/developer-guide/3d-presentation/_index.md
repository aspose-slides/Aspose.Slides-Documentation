---
title: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/java/3d-presentation/
keywords:
- 3D
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- عرض PowerPoint
- Java
- Aspose.Slides for Java
description: "عرض PowerPoint ثلاثي الأبعاد في Java"
---

## نظرة عامة
منذ Aspose.Slides Java 20.9، من الممكن إنشاء 3D في العروض التقديمية. PowerPoint ثلاثي الأبعاد هو وسيلة لإضافة الحياة إلى العروض التقديمية. عرض الأشياء الحقيقية 
بشكل ثلاثي الأبعاد، أو عرض نموذج ثلاثي الأبعاد لمشروعك التجاري المستقبلي، أو نموذج ثلاثي الأبعاد للمبنى أو داخله، أو نموذج ثلاثي الأبعاد لشخصية لعبة، 
أو مجرد تمثيل ثلاثي الأبعاد لبياناتك.

يمكن إنشاء نماذج PowerPoint ثلاثي الأبعاد من أشكال ثنائية الأبعاد، من خلال تطبيق التأثيرات التالية عليها: دوران ثلاثي الأبعاد، عمق ثلاثي الأبعاد وبروز، تدرج ثلاثي الأبعاد، نص ثلاثي الأبعاد، إلخ.
يمكن العثور على قائمة ميزات 3D المطبقة على الأشكال في **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**.
يمكن الحصول على مثيل من الفئة عن طريق:
 
- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getThreeDFormat--)** طريقة لإنشاء نموذج PowerPoint ثلاثي الأبعاد.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** طريقة لإنشاء نص ثلاثي الأبعاد
(WordArt).

يمكن استخدام جميع التأثيرات المطبقة في **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)** لكل من الأشكال والنص.
لنلقِ نظرة سريعة على الطرق الرئيسية لفئة **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**. في المثال التالي 
نقوم بإنشاء شكل مستطيل ثنائي الأبعاد مع نص عليه. من خلال الحصول على عرض كاميرا على الشكل، نقوم بتغيير دورانه ونجعله يبدو كنموذج ثلاثي الأبعاد. ضبط الضوء 
المسطح واتجاهه نحو أعلى النموذج الثلاثي الأبعاد يضيف المزيد من الحجم إلى النموذج. المواد المعدلة، وارتفاع البروز واللون تجعل النموذج الثلاثي الأبعاد يبدو أكثر حياة.
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

إليك نموذج الثلاثي الأبعاد الناتج:

![todo:image_alt_text](img_01_01.png)

## الدوران ثلاثي الأبعاد
يمكن الدوران لنموذج ثلاثي الأبعاد في PowerPoint عبر القائمة:

![todo:image_alt_text](img_02_01.png)

لتحريك النموذج ثلاثي الأبعاد باستخدام واجهة برمجة تطبيقات Aspose.Slides، استخدم **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getCamera--)** 
طريقة، اضبط دوران الكاميرا بالنسبة للشكل ثلاثي الأبعاد:

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... ضبط معلمات المشهد ثلاثي الأبعاد الأخرى

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

## العمق والبروز ثلاثي الأبعاد
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** 
و **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** الطرق 
تستخدم لإنشاء بروز على الشكل:

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... ضبط معلمات المشهد ثلاثي الأبعاد الأخرى

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

في PowerPoint، يتم ضبط عمق الشكل عبر:

![todo:image_alt_text](img_02_02.png)

## التدرج ثلاثي الأبعاد
يمكن أن يجلب التدرج ثلاثي الأبعاد المزيد من الحجم لشكل PowerPoint ثلاثي الأبعاد:

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

إليك كيف يبدو:

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


إليك النتيجة:

![todo:image_alt_text](img_02_04.png)

## نص ثلاثي الأبعاد (WordArt)
لإنشاء نص ثلاثي الأبعاد (WordArt)، قم بما يلي:
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
// ضبط تأثير تحويل WordArt "Arch Up"
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

إليك النتيجة:

![todo:image_alt_text](img_02_05.png)


 
## غير مدعوم - قريبا
ميزات PowerPoint ثلاثي الأبعاد التالية غير مدعومة بعد:
- تقليم
- مادة
- محيط
- إضاءة