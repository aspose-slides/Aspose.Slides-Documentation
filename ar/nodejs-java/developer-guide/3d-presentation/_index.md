---
title: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/nodejs-java/3d-presentation/
---

## **نظرة عامة**

منذ نسخة Aspose.Slides for Java 20.9 أصبح من الممكن إنشاء ثلاثي الأبعاد في العروض التقديمية. يُعد PowerPoint 3D طريقة لإضفاء الحيوية على العروض. اعرض كائنات العالم الحقيقي باستخدام عرض ثلاثي الأبعاد، أو استعرض نموذج ثلاثي الأبعاد لمشروع عملك المستقبلي، أو نموذج ثلاثي الأبعاد للمبنى أو داخله، أو نموذج ثلاثي الأبعاد لشخصية اللعبة، أو مجرد تمثيل ثلاثي الأبعاد لبياناتك.

يمكن إنشاء نماذج PowerPoint 3D من أشكال ثنائية الأبعاد، عن طريق تطبيق هذه التأثيرات عليها: دوران ثلاثي الأبعاد، عمق واستخلاص ثلاثي الأبعاد، تدرج لوني ثلاثي الأبعاد، نص ثلاثي الأبعاد، إلخ. يمكن العثور على قائمة ميزات الثلاثي الأبعاد المطبقة على الأشكال في فئة **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. يمكن الحصول على مثيل الفئة عبر:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getThreeDFormat--)** طريقة لإنشاء نموذج PowerPoint 3D.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** طريقة لإنشاء نص ثلاثي الأبعاد (WordArt).

يمكن استخدام جميع التأثيرات المُنفذة في **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)** لكل من الأشكال والنص. دعونا نلقي نظرة سريعة على الطرق الرئيسية لفئة **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. في المثال التالي
ننشئ شكلاً مستطيلاً ثنائي الأبعاد مع نص عليه. من خلال الحصول على عرض الكاميرا على الشكل، نغيّر دورانه لجعله يبدو كنموذج ثلاثي الأبعاد. ضبط إضاءة مسطحة
واتجاهها إلى أعلى النموذج الثلاثي الأبعاد يضيف حجمًا أكبر للنموذج. تغيير المواد، ارتفاع الاستخلاص واللون يجعل النموذج الثلاثي الأبعاد يبدو أكثر حيوية.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("sandbox_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


إليك النموذج الثلاثي الأبعاد الناتج:

![todo:image_alt_text](img_01_01.png)

## **دوران ثلاثي الأبعاد**

يمكن تنفيذ دوران النموذج الثلاثي الأبعاد في PowerPoint عبر القائمة:

![todo:image_alt_text](img_02_01.png)

لتدوير النموذج الثلاثي الأبعاد باستخدام Aspose.Slides API، استخدم طريقة **[ThreeDFormat.getCamera()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getCamera--)**، واضبط دوران الكاميرا بالنسبة إلى الشكل الثلاثي الأبعاد:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... ضبط باقي معلمات مشهد 3D
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


## **العمق الثلاثي الأبعاد والاستخلاص**

تُستخدم طريقتا **[ThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** و **[ThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** لإنشاء الاستخلاص على الشكل:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 128, 0, 128));
// ... ضبط باقي معلمات مشهد 3D
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


في PowerPoint، يتم ضبط عمق الشكل عبر:

![todo:image_alt_text](img_02_02.png)

## **تدرج لوني ثلاثي الأبعاد**

يمكن للتدرج الثلاثي الأبعاد إضفاء حجم أكبر على شكل PowerPoint ثلاثي الأبعاد:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


هذا هو الشكل:

![todo:image_alt_text](img_02_03.png)
  
يمكنك أيضًا إنشاء تدرج لوني للصورة:
```javascript
shape.getFillFormat().setFillType(java.newByte(java.newByteaspose.slides.FillType.Picture));
var picture;
var image = aspose.slides.Images.fromFile("image.png");
try {
    picture = pres.getImages().addImage(image);
} finally {
    if (image != null) {
        image.dispose();
    }
}
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
// .. إعداد ثلاثي الأبعاد: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* properties
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


النتيجة:

![todo:image_alt_text](img_02_04.png)

## **نص ثلاثي الأبعاد (WordArt)**

لإنشاء نص ثلاثي الأبعاد (WordArt)، قم بما يلي:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");
    var portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);
    var textFrame = shape.getTextFrame();
    // إعداد تأثير تحويل WordArt "قوس أعلى"
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("text3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("text3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


النتيجة:

![todo:image_alt_text](img_02_05.png)

## **الأسئلة الشائعة**

**هل سيتم حفظ التأثيرات الثلاثية الأبعاد عند تصدير العرض التقديمي إلى صور/PDF/HTML؟**

نعم. يقوم محرك Slides 3D بتصيير التأثيرات الثلاثية الأبعاد عند التصدير إلى الصيغ المدعومة ([images](/slides/ar/nodejs-java/convert-powerpoint-to-png/), [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/), إلخ).

**هل يمكنني استرجاع القيم "الفعالة" (النهائية) لمعلمات 3D التي تأخذ في الاعتبار السمات والوراثة وما إلى ذلك؟**

نعم. توفِّر Slides واجهات برمجة تطبيقات ل[قراءة القيم الفعالة](/slides/ar/nodejs-java/shape-effective-properties/) (بما في ذلك للـ 3D—الإضاءة، الحواف، إلخ) حتى تتمكن من رؤية الإعدادات النهائية المطبقة.

**هل تعمل التأثيرات الثلاثية الأبعاد عند تحويل العرض التقديمي إلى فيديو؟**

نعم. عند [إنشاء الإطارات للفيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/)، يتم تصيير التأثيرات الثلاثية الأبعاد بنفس طريقة تصييرها لل[صور المصدَّرَة](/slides/ar/nodejs-java/convert-powerpoint-to-png/).