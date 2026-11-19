---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام Java
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/java/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد للأشكال والنص في PowerPoint باستخدام Java مع Aspose.Slides. ضبط الكاميرا والإضاءة والمادة والبثق والملء والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides for Java يمكنه إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، ملء التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذه المقالة تتحدث عن تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. فهي لا تتعلق بإدراج أو تعديل ملفات نماذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بتضمين تلك التأثيرات ثلاثية الأبعاد في المخرجات ذات البعدين.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/)، الذي يتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

للنص، استخدم طريقة [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم أعضاء API هي:

| عضو API | ما الذي يتحكم فيه | متى يُستَخدم |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | نقطة المشاهد، نوع الكاميرا المُعد مسبقًا، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد من PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | إعداد الضوء المسبق، الاتجاه، ودوران الضوء. | تغيير كيفية ظهور اللمعات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | جعل الشكل نفسه يبدو أكثر مسطحًا أو ناعمًا أو لامعًا أو معدنيًا. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | المسافة التي يمتد فيها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطّح إلى كائن ثلاثي الأبعاد سميك مرئي. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | لون الجوانب البثقية. | إظهار العمق أو تنسيق لون الجانب مع ملء الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق 3D في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | حواف مرتفعة أو مستديرة على الواجهتين الأمامية والخلفية. | إضافة حافة مُلينَة أو مُشكَّلة بدلاً من وجه مسطّح حاد. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | حدود حول الكائن ثلاثي الأبعاد. | إبراز حدود الكائن في المخرجات المرسومة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يتطلب الشكل أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بصدق:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب مقروءة.
- إعدادات المادة، لأن سطح الشكل يؤثر على طريقة عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطّح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيق ثلاثي الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق 100 نقطة. يُظهر المثال الشريحة كصورة PNG بمقاسين مضاعفين عن الأبعاد الافتراضية ويحفظ العرض كملف PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الصورة المرمَّزة تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل أزرق ثلاثي الأبعاد مع نص أبيض ثلاثي الأبعاد على الوجه الأمامي](img_01_01.png)

## **دوران شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من لوحة “3-D Rotation”. قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة دوران 3-D في PowerPoint مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، يتم الوصول إلى الكاميرا عبر [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--). يُنشئ هذا المثال مستطيلًا، يحدد عرضًا أماميًا أرثوغرافيًا، ويضبط دوراني X وY وZ إلى 20 و30 و40 درجة على التوالي. يكوّن الشكل في الذاكرة دون حفظ ملف:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائي الأبعاد على الشريحة؛ بل يغيّر منظور ثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides عند العرض.

### **نسخ توجيه الكاميرا من شكل القالب**

لمطابقة توجيه الشكل القالب، اقرأ إعداد الكاميرا المسبق باستخدام [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) ودوران الزوايا باستخدام [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--). يفتح المثال `template.pptx` وينسخ توجيه الكاميرا من الشكل الأول على الشريحة الأولى إلى الشكل الثاني. كلا الشكلين لديهما إضاءة ثلاثية الأبعاد مسبقة، ولا يحتوي الشكل الثاني على دوران كاميرا صريح.

القيم بالدرجات. الفهرس `0` يمثل الخط العرضي، الفهرس `1` يمثل الخط الطولي، والفهرس `2` يمثل الدوران. مررها إلى [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) بهذا الترتيب. إذا أرجع المصدر `null`، فهذا يعني أنه لا يوجد دوران صريح، فاترك زوايا الشكل الثاني غير مُحددة. دوران صريح بـ `(0, 0, 0)` يَعيد ثلاثة أصفار ويجب نسخه.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

عند إعادة فتح `camera-copy.pptx` في PowerPoint، يكون السهم الأيمن له نفس إعداد الكاميرا والدوران مثل المستطيل الأيسر. كلا الشكلين يستخدمان نفس الإضاءة وعمق البثق.

![مستطيل أزرق ثلاثي الأبعاد وسهم أيمن مع توجيه كاميرا متطابق، يُظهران من الأعلى واليمين](camera-orientation.png)

## **إضافة بثق وعمق**

يُضيف البثق سماكة إلى الشكل بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم في العمق بهذا السماكة الظاهرة، وتتحكم خاصية اللون بلون الجوانب.

![تحكمات العمق في PowerPoint المرتبطة بلون البثق وارتفاع البثق](img_02_02.png)

استخدم [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) لتعيين السماكة و[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) للوصول إلى لون الجوانب. يمنح هذا المثال المستطيل بارتفاع بثق 100 نقطة ولون جوانب بنفسجي، ويدور الكاميرا لإظهار سماكته. يكوّن الشكل في الذاكرة دون حفظ ملف:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

طريقة [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) تُحدّد عمق الشكل ثلاثي الأبعاد. طريقة [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) تتحكم بارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام ملء التدرج أو الصورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن ملء الشكل. يمكنك تطبيق لون ثابت أو تدرج أو نمط أو ملء صورة على الوجه الأمامي والاستمرار باستخدام نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تدرج أزرق إلى برتقالي على الوجه الأمامي ولون برتقالي داكن على بُثق 150 نقطة. نقاط التدرج عند 0 و100 تحدد بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُرسم الشريحة كصورة PNG بمقاسين مضاعفين عن الأبعاد الافتراضية:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

الناتج المرمَّز يحافظ على التدرج على الوجه الأمامي ويظهر البثق منفصلًا:

![مستطيل ثلاثي الأبعاد بملء تدرج أزرق إلى برتقالي وبثق برتقالي](img_02_03.png)

لإستخدام ملء صورة بدلًا من ذلك، أضف الصورة إلى العرض وعيّنها كملء الشكل. يتطلب هذا المثال وجود ملف باسم "image.jpg" في دليل العمل. يمدد الصورة لتملأ المستطيل، يطبق بُثق 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يكوّن الشكل في الذاكرة دون حفظ أو عرض ملف:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

الصورة تُرسم على الوجه الأمامي، بينما يُظهر البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد بملء صورة على الوجه الأمامي وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الحروف نفسها إلى بثق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بنمط شبكة برتقالي-أبيض، يطبّق قوسًا صاعدًا، ويكوّن إعدادات ثلاثية الأبعاد عبر [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). ارتفاع البثق والعمق بالنقاط، ودوران الإضاءة بالدرجات. يُخفى ملء الشكل والحدود بحيث لا يظهر سوى النص. يُرسم المثال كصورة PNG بمقاسين مضاعفين عن أبعاد الشريحة الافتراضية ويحفظ العرض كملف PPTX:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النص يُعرض كحروف ثلاثية الأبعاد منحنية ومُسطحة:

![نص ثلاثي الأبعاد بتحويل WordArt مقوس، ملء نمط برتقالي، وبثق داكن](img_02_05.png)

## **إبقاء النص مسطحًا على شكل ثلاثي الأبعاد**

لإبقاء النص مقروءًا مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، استدعِ [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) عبر [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--). عندما تكون القيمة `true`، يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع اتجاهه ثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق الشكل ثلاثي الأبعاد: الكاميرا، الإضاءة، المادة، والبثق تظل مُكوَّنة عبر [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--). وهو أيضًا مختلف عن الدوران العادي. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) يدور الشكل في مستوى الشريحة، بينما [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) يتحكم في دوران النص داخل مربع احتوائه. إبقاء النص خارج المشهد ثلاثي الأبعاد لا يعيد تعيين أي من هذين الزاويتين.

المثال التالي يُنشئ مستطيلًا أزرقًا بنص، ثم يُكرره بجوار الأصلي. كلا الشكلين لهما نفس التنسيق ثلاثي الأبعاد؛ الفرق فقط في إعداد النص: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البثق 40 نقطة. يُحفظ العرض كملف PPTX وتُرسم الشريحة مقارنةً كصورة PNG بمقاسين مضاعفين عن الأبعاد الافتراضية.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

على اليمين، يبقى النص مسطحًا وأسهل قراءة؛ على اليسار، يتبع النص توجيه 3D. كلا المستطيلين يحتفظان بنفس البثق الظاهر والتوجيه ثلاثي الأبعاد.

![مستطيلان ثلاثيّا الأبعاد جنبًا إلى جنب: النص يتبع التوجيه ثلاثي الأبعاد على اليسار ويبقى مسطحًا على اليمين](keep_text_flat.png)

## **سلوك التصدير والعرض**

Aspose.Slides يحافظ على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ذات تخطيط ثابت، يتم تضمين المشهد ثلاثي الأبعاد كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تُظهر الشرائح إلى [PNG](/slides/ar/java/convert-powerpoint-to-png/)، تصدير إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، تصدير إلى [HTML](/slides/ar/java/convert-powerpoint-to-html/)، أو توليد إطارات لـ [تحويل الفيديو](/slides/ar/java/convert-powerpoint-to-video/).

احرص على مراعاة النقاط التالية:

- الصور وملفات PDF المُصدَّرة ليست تفاعلية. لا يمكن للمستخدم تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مجموعة الكاميرا، لوحة الإضاءة، المادة، البثق، الملء، وتكبير الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو القائم على السمة، اقرأ [خصائص الشكل الفعّالة](/slides/ar/java/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد القابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يستطيع Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

Aspose.Slides يُنشئ ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور أو ملفات PDF أو صفحات HTML تفاعلية بحيث يمكن للمستخدم تدوير المشهد ثلاثي الأبعاد. في ملفات PPTX، يبقى تنسيق ثلاثي الأبعاد قابلًا للتحرير في PowerPoint إذا كان التنسيق يدعمه.

**ما الفرق بين النموذج الثلاثي الأبعاد والتأثير الثلاثي الأبعاد؟**

النموذج الثلاثي الأبعد هو كائن ثلاثي أبعاد مستقل يُدرج في العرض. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. هذه المقالة تغطي التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، حدد دوران كاميرا وإما بثق أو عمق. عمليًا، يُفضَّل أيضًا إعداد لوحة إضاءة ومادة لتكون الوجوه المرسومة ذات إضاءة وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**

نعم. استخدم [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) للجسم الشكل و[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. Aspose.Slides يُظهر تأثيرات ثلاثية الأبعاد عند إنشاء صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات الفيديو. الناتج المُصدَّر يحتوي على المظهر المرسوم، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

**هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموصوفة في [خصائص الشكل الفعّالة](/slides/ar/java/shape-effective-properties/) لقراءة الكاميرا النهائية، لوحة الإضاءة، الحافة، والقيم الثلاثية الأبعاد المرتبطة.