---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية على Android
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص على Android باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides لنظام Android عبر Java إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، التعبئة بالتدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذا المقال يتحدث عن تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا يتعلق بإدراج أو تحرير ملفات نماذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في النتيجة الثنائية الأبعاد المصدرة.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/) التي تتحكم في المشهد ثلاثي الأبعاد لذلك الشكل.

بالنسبة للنص، استخدم طريقة [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

الأعضاء الأكثر أهمية في API هي:

| عضو API | ما يتحكم فيه | متى يتم استخدامه |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | نقطة المشهد، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد مسبق في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | إعداد إضاءة مسبق، الاتجاه، ودوران الإضاءة. | تغيير مظهر الإضاءة والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | جعل الشكل نفسه يبدو أكثر تسطحًا أو نعومة أو لمعانًا أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | مدى بُعد الامتداد الخلفي للوجه الأمامي للشكل. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميكًّا بشكل واضح. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | لون الجوانب البارزة. | إظهار العمق أو تنسيق لون الجانب مع تعبئة الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق ثلاثي أبعاد إضافي يستخدمه تنسيق PowerPoint ثلاثي الأبعاد. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مُشكَّلة بدلاً من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | حدود حول الكائن ثلاثي الأبعاد. | إبراز حد الكائن في النتيجة المعروضة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على طريقة عرض الإضاءة.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق 100 نقطة. المثال يعرض الشريحة كصورة PNG بضعف أبعادها الافتراضية ويحفظ العرض التقديمي كملف PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

الصورة المرسومة للشفرة تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **تدوير شكل باستخدام الكاميرا**

في PowerPoint، يتم ضبط دوران ثلاثي الأبعاد من لوحة 3‑D Rotation. قيم الدوران X وY وZ تتCorrespond... (keep translation)

![
PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

في Aspose.Slides، يمكن الوصول إلى الكاميرا عبر [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--). هذا المثال ينشئ مستطيلًا، يختار عرضًا أماميًا شبه متعامد، ويضبط دورانات X وY وZ إلى 20 و30 و40 درجة على التوالي. يكوّن الشكل في الذاكرة دون حفظ ملف:

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

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغير ذلك هندسة الشكل الثنائي الأبعاد على الشريحة. بل يغيّر نقطة المشهد ثلاثية الأبعاد المستخدمة من قبل PowerPoint وAspose.Slides عند العرض.

### **نسخ توجيه الكاميرا من شكل نموذج**

لمطابقة توجيه شكل قالب، اقرأ إعداد الكاميرا المسبق باستخدام [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) ودوراناته باستخدام [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). يفتح المثال `template.pptx` وينسخ توجيه الكاميرا من الشكل الأول على الشريحة الأولى إلى الشكل الثاني. كلا الشكلين يحتويان بالفعل على إضاءة ثلاثية الأبعاد، ولا يحتوي الشكل الثاني على دوران كاميرا صريح.

القيم بالدرجات. الفهرس `0` هو خط العرض، الفهرس `1` هو خط الطول، والفهرس `2` هو الثورة. مرّرها إلى [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) بهذا الترتيب. إذا أعاد المصدر `null`، فهذا يعني عدم وجود دوران صريح، لذا اترك زوايا الشكل الثاني غير مضبوطة. دوران صريح `(0, 0, 0)` يعيد ثلاثة أصفار ويجب نسخه.

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

عند إعادة فتح `camera-copy.pptx` في PowerPoint، السهم الأيمن له نفس إعداد الكاميرا والدوران مثل المستطيل الأيسر. كلا الشكلين يستخدمان نفس الإضاءة وعمق البثق.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **إضافة بُثق وعمق**

الصق يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم بالعمق في السماكة الظاهرة، ويتحكم التحكم باللون في لون الوجه الجانبي.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

استخدم [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) لتحديد السماكة و[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) للوصول إلى لون الجانبين. هذا المثال يمنح المستطيل بُثقًا بارتفاع 100 نقطة بلون جانب بنفسجي ويُدوّر الكاميرا لإظهار سمكه. يكوّن الشكل في الذاكرة دون حفظ ملف:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

طريقة [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) تضبط عمق الشكل ثلاثي الأبعاد. طريقة [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) تتحكم في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام تعبئة بالتدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون ثابت أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي مع الاستمرار في استخدام نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تدرج أزرق إلى برتقالي على الوجه الأمامي ولون برتقالي داكن على البثق بارتفاع 150 نقطة. نقاط التدرج عند 0 و100 تمثل بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. الشريحة تُعرض كصورة PNG بضعف أبعادها الافتراضية:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
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

النتيجة المرسومة تحتفظ بالتدرج على الوجه الأمامي وتعرض البثق بشكل منفصل:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

لاستخدام تعبئة صورة بدلًا من ذلك، أضف الصورة إلى العرض التقديمي وقم بتعيينها لتعبئة الشكل. يتطلب هذا المثال وجود ملف باسم "image.jpg" في دليل العمل. يُمدد الصورة لملء المستطيل، يطبّق بُثقًا بارتفاع 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يكوّن الشكل في الذاكرة دون حفظ أو عرض ملف:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

الصورة تُعرض على الوجه الأمامي، بينما يُعرض البثق كسطح جانبي ثلاثي الأبعاد:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تؤثر تنسيقات ثلاثية الأبعاد للشكل على جسم الشكل. تؤثر تنسيقات ثلاثية الأبعاد للنص على إطار النص. وهذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الحروف نفسها إلى بُثق ومادة وإضاءة وإعدادات كاميرا.

المثال التالي ينشئ نصًا بنمط شبكة برتقالي-أبيض، يطبّق قوسًا صاعدًا، ويكوّن إعدادات ثلاثية الأبعاد عبر [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). ارتفاع البُثق والعمق بالنقاط، ودوران الإضاءة بالدرجات. تعبئة وإطار الشكل مخفيان بحيث يظهر النص فقط. المثال يعرض صورة PNG بضعف أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كـ PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

النص يُعرض كحروف ثلاثية الأبعاد منحنية ومبثوقة:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **إبقاء النص مسطحًا على شكل ثلاثي الأبعاد**

لإبقاء النص مقروءًا مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، استدعِ [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) عبر [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). عندما تكون القيمة `true`، يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `false`، يشارك النص المشهد ويتبع توجيه ثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق ثلاثي الأبعاد للشكل: الكاميرا والإضاءة والمادة والبُثق تظل مُكوَّنة عبر [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). وهو مختلف عن الدوران العادي. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) يدور الشكل في مستوى الشريحة، بينما [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) يتحكم في دوران مخصص للنص داخل صندوقه. إبقاء النص خارج المشهد ثلاثي الأبعاد لا يعيد ضبط أيٍ من تلك الزوايا.

المثال التالي يخلق مستطيلًا أزرقًا مع نص ويستنسخه بجانب الأصلي. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ الاختلاف فقط في إعداد النص: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، ارتفاع البُثق 40 نقطة. المثال يحفظ العرض التقديمي كـ PPTX ويعرض شريحة المقارنة كصورة PNG بضعف أبعادها الافتراضية.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

على اليسار، يتبع النص توجيه ثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل قراءة. كلا المستطيلين يحتفظان بنفس البُثق الظاهر وتوجيه ثلاثي الأبعاد.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **سلوك التصدير والعرض**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ذات تخطيط ثابت، يُرَسَّم مشهد ثلاثي الأبعاد أو يُدمج في النتيجة كنتاج ثنائي الأبعاد. ينطبق ذلك عند عرض الشرائح إلى [PNG](/slides/ar/androidjava/convert-powerpoint-to-png/)، أو تصديرها إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، أو إلى [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، أو إنشاء إطارات لتحويل الفيديو [video conversion](/slides/ar/androidjava/convert-powerpoint-to-video/).

ضع في اعتبارك النقاط التالية:

- الصور وPDF المصدرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مجموعة الكاميرا، وإضاءة المشهد، والمادة، والبُثق، والتعبئة، وتضخيم الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [effective shape properties](/slides/ar/androidjava/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك الصيغ، يُعرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

إن Aspose.Slides ينشئ ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة أو PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يظل تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين النموذج ثلاثي الأبعاد والتأثير ثلاثي الأبعاد؟**

النموذج ثلاثي الأبعاد هو كائن ثلاثي مستقل يتم إدراجه في العرض التقديمي. التأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. يغطي هذا المقال تأثيرات ثلاثية الأبعاد.

**ما الإعدادات المطلوبة لرؤية شكل ثلاثي الأبعاد؟**

على الأقل، اضبط دوران الكاميرا وإما البُثق أو العمق. عمليًا، يُفضَّل أيضًا ضبط إضاءة المشهد والمادة حتى تحصل الوجوه المعروضة على إضاءات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**

نعم. استخدم [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) لجسم الشكل و[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) للنص.

**هل ستظهر التأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. تقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، أو مخرجات PDF، أو HTML، أو إطارات تُستخدم لتحويل الفيديو. تحتوي النتيجة المصدرة على المظهر المعروض، وليس كائنًا ثلاثيًا قابلًا للتحرير.

**هل يمكنني قراءة القيم النهائية ثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات لتنسيق الشكل الفعّال الموضحة في [Shape Effective Properties](/slides/ar/androidjava/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة المشهد، والحافة، والقيم ثلاثية الأبعاد المرتبطة.