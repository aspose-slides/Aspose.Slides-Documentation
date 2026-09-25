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
- بثرق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد للأشكال والنص في PowerPoint باستخدام Java مع Aspose.Slides. ضبط الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، تعبئات التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="ملاحظة" %}}

هذه المقالة تتحدث عن تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. ولا تتعلق بإدراج أو تحرير ملفات نموذج ثلاثي الأبعاد مستقلة. عندما تقوم بتصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بتحويل تلك التأثيرات ثلاثية الأبعاد إلى مخرجات ثنائية الأبعاد.

{{% /alert %}}

## **مفاهيم التنسيق ثلاثي الأبعاد**

استخدم الطريقة [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getThreeDFormat--) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة [IThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/) الذي يتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

بالنسبة للنص، استخدم الطريقة [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . تُطبق هذه الطريقة تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم أعضاء API هي:

| عضو API | ما يتحكم فيه | متى يُستخدم |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getCamera--) | نقطة الرؤية، نوع الكاميرا المُحدد مسبقًا، الدوران، التكبير، والمنظور. | دوّر الكائن في الفضاء ثلاثي الأبعاد أو طابق إعداد دوران ثلاثي الأبعاد محدد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getLightRig--) | إعداد الإضاءة المُحدد مسبقًا، الاتجاه، ودوران الضوء. | غير طريقة ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادة السطح، مثل مسطح، مطفأ، بلاستيك أو معدن. | اجعل الهندسة نفسها تبدو أكثر تسطيحًا أو نعومة أو لمعانًا أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | مدى بُعد الشكل إلى الخلف من وجهه الأمامي. | حوّل الشكل المسطح إلى كائن ثلاثي الأبعاد سميك يُظهر بُعدًا واضحًا. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | لون الجوانب البثقة. | اجعل العمق مرئيًا أو نسق لون الجوانب مع التعبئة الأمامية. |
| [getDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق ثلاثي الأبعاد إضافي يُستخدم في تنسيق ثلاثي الأبعاد في PowerPoint. | اضبط العمق بدقة للأشكال أو النص، خصوصًا مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | حواف مرتفعة أو مستديرة على الوجهين الأمامي والخلفي. | أضف حافة ناعمة أو مُقوَّسة بدلًا من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getContourColor--) و [getContourWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getContourWidth--) و [setContourWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | الحد المحيط بالكائن ثلاثي الأبعاد. | أبرز حد الجسم في المخرجات المرسومة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثي الأبعاد بصورة مقنعة:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على طريقة عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي يُنشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق 100 نقطة. يُظهر المثال الشريحة على صورة PNG بمقاس ضعف أبعادها الافتراضية ويحفظ العرض التقديمي كملف PPTX.

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

صورة الشريحة المرسومة تُظهر المستطيل ككتلة ثلاثية أبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مُعالج مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من خلال لوحة 3-D Rotation. قيم دوران X وY وZ تتوافق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة PowerPoint 3-D Rotation مع تمييز قيم دوران X وY وZ](img_02_01.png)

في Aspose.Slides، يمكن الوصول إلى الكاميرا عبر [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getCamera--). يُنشئ هذا المثال مستطيلًا، يختار عرضًا أماميًا أرثوغرافيًا، ويضبط دورانات X وY وZ إلى 20 و30 و40 درجة على التوالي. يُكوّن الشكل في الذاكرة دون حفظ ملف:

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

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المُشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائي الأبعاد على الشريحة، بل يغيّر منظور ثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides عند العرض.

## **إضافة بثرق وعمق**

البثق يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم بالعمق في هذه السماكة المرئية، ويتحكم التحكم باللون في لون وجوه الجوانب.

![ضوابط العمق في PowerPoint مرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

استخدم [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) لتعيين السماكة و[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) للوصول إلى لون الجوانب. يُعطي هذا المثال مستطيلًا بارتفاع بثرق 100 نقطة مع جوانب أرجوانية ويدور الكاميرا لتظهر السماكة. يُكوّن الشكل في الذاكرة دون حفظ ملف:

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

طريقة [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setDepth-double-) تُحدد عمق الشكل ثلاثي الأبعاد. طريقة [setExtrusionHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) تتحكم في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام تعبئات التدرج أو الصورة مع تأثيرات ثلاثية الأبعاد**

التنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي وما زلت تستخدم نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تدرج أزرق إلى برتقالي على الوجه الأمامي ولون برتقالي داكن على البثرق بارتفاع 150 نقطة. توقّف التدرج عند 0 و100 لتحديد بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُرسم الشريحة إلى صورة PNG بمقاس ضعف أبعادها الافتراضية:

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

الناتج المرسوم يحافظ على التدرج على الوجه الأمامي ويعرض البثرق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مع تعبئة تدرج أزرق إلى برتقالي وبثرق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال وجود ملف موجود باسم "image.jpg" في دليل العمل. يُمدّد الصورة لتملأ المستطيل، يطبق بثرق 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يُكوّن الشكل في الذاكرة دون حفظ أو عرض ملف:

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

الصورة تُعرض على الوجه الأمامي، بينما يُعرض البثرق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مع تعبئة صورة على الوجه الأمامي وبثرق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الحروف نفسها إلى بثرق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي يُنشئ نصًا بنمط شبكة برتقالي-أبيض، يطبق قوسًا صاعدًا، ويكوّن إعدادات ثلاثية الأبعاد عبر [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). ارتفاع البثرق والعمق بالنقاط، ودوران الضوء بالدرجات. تُخفى تعبئة الشكل والحد لتظهر النص فقط. يُرسم المثال صورة PNG بمقاس ضعف أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

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

يُعرض النص كحروف ثلاثية الأبعاد مقوسة ومبثقة:

![نص ثلاثي الأبعاد مُعالج بقوس WordArt، تعبئة بنمط برتقالي، وبثرق داكن](img_02_05.png)

## **إبقاء النص مسطحًا على شكل ثلاثي الأبعاد**

للحفاظ على قابلية قراءة النص مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، استدعِ [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) عبر [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getTextFrameFormat--). عندما تكون القيمة `true`، يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع توجهه ثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق الشكل ثلاثي الأبعاد: الكاميرا، الإضاءة، المادة، والبثق لا تزال مُكوَّنة عبر [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getThreeDFormat--). وهو مختلف عن الدوران العادي. [IShape.setRotation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setRotation-float-) يدور الشكل في مستوى الشريحة، بينما [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) يتحكم في دوران النص داخل إطار الحد. إبقاء النص خارج المشهد ثلاثي الأبعاد لا يُعيد ضبط أيٍ من هذين الزاويتين.

المثال المستقل التالي يُنشئ مستطيلًا أزرقًا مع نص، ثم ينسخه بجانب الأصلي. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ الاختلاف فقط في إعداد النص: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البثرق 40 نقطة. يحفظ المثال العرض التقديمي كملف PPTX ويرسم شريحة المقارنة إلى PNG بمقاس ضعف أبعادها الافتراضية.

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

على اليسار، يتبع النص توجيه الثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل قراءة. كلا المستطيلين يحتفظان بنفس البثرق الظاهر وتوجه الثلاثي الأبعاد.

![مستطيلان ثلاثيان معًا: النص يتبع توجيه الثلاثي الأبعاد على اليسار ويبقى مسطحًا على اليمين](keep_text_flat.png)

## **سلوك التصدير والعرض**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى تنسيقات PowerPoint مثل PPTX. عند العرض أو التصدير إلى تنسيقات ثابتة، يتم تحويل المشهد ثلاثي الأبعاد إلى صورة ثنائية الأبعاد أو رسمه في النتيجة. ينطبق ذلك عند عرض الشرائح إلى [PNG](/slides/ar/java/convert-powerpoint-to-png/)، التصدير إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، التصدير إلى [HTML](/slides/ar/java/convert-powerpoint-to-html/)، أو إنشاء إطارات للتحويل إلى [فيديو](/slides/ar/java/convert-powerpoint-to-video/).

احرص على مراعاة النقاط التالية:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمُشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، مجموعة الإضاءة، المادة، البثرق، التعبئة، وتوسيع الشريحة.
- إذا كنت بحاجة إلى فحص القيم الموروثة أو القيم المستندة إلى السمات، اقرأ [خصائص الشكل الفعّالة](/slides/ar/java/shape-effective-properties/).
- بعض تنسيقات الإخراج لا يمكنها تخزين تنسيق ثلاثي أبعاد قابل للتحرير في PowerPoint. في تلك التنسيقات، يتم عرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية أبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

تنشئ Aspose.Slides وتعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا تجعل الصور أو ملفات PDF أو صفحات HTML تفاعلية ثلاثية الأبعاد يمكن للمُشاهد تدويرها. في ملفات PPTX، يظل تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint عندما يدعم الصيغة ذلك.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد مستقل يُدرج في العرض. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. تغطي هذه المقالة فقط التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة لظهور شكل ثلاثي الأبعاد؟**

على الأقل، حدد دوران كاميرا وإما بثرق أو عمق. في التطبيق العملي، يُفضَّل أيضًا ضبط مجموعة الإضاءة والمادة للحصول على واجهات واضحة مع إضاءات وظلال.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**

نعم. استخدم [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getThreeDFormat--) لجسم الشكل و[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) للنص.

**هل تظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. تقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنشاء صور للشرائح، مخرجات PDF، مخرجات HTML، وإطارات تُستخدم للتحويل إلى فيديو. يحتوي الناتج المصدر على المظهر المُعرض، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

**هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الميراث وإعدادات السمات؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [خصائص الشكل الفعّالة](/slides/ar/java/shape-effective-properties/) لقراءة الكاميرا النهائية، مجموعة الإضاءة، الحافة، والقيم الثلاثية الأبعاد المرتبطة.