---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام Java
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/java/3d-presentation/
keywords:
- 3D PowerPoint
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- إخراج ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في Java باستخدام Aspose.Slides. تكوين الكاميرا، الإضاءة، المادة، الإخراج، التعبئات، والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides for Java يمكنه إنشاء، تعديل، حفظ، وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، الإخراج، الحواف، الإضاءة، المادة، التعبئة المتدرجة أو صورة، والنص ثلاثي الأبعاد.

{{% alert color="info" %}}
هذه المقالة تتحدث عن تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا تتعلق بإدراج أو تعديل ملفات نموذج ثلاثي الأبعاد مستقلة. عندما تقوم بتصدير شريحة إلى صورة، PDF، أو HTML، يقوم Aspose.Slides بتجسيد تلك التأثيرات ثلاثية الأبعاد في الناتج الثنائي الأبعاد المصدَّر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/).`getThreeDFormat()` لتطبيق تنسيق ثلاثي الأبعاد على شكل. الكائن المعاد يتحكم في المشهد ثلاثي الأبعاد لذلك الشكل.

بالنسبة للنص، استخدم [ITextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. يطبق هذا تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

الأعضاء الأكثر أهمية في API هي:

| عضو API | ما الذي يتحكم فيه | متى يستخدم |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getCamera--) | نقطة المشهد، نوع الكاميرا المحدد مسبقًا، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد المحدد مسبقًا في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getLightRig--) | إعداد الضوء المحدد مسبقًا، الاتجاه، ودوران الضوء. | تغيير كيفية ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادة السطح، مثل مسطح، مطفي، بلاستيك، أو معدن. | اجعل الشكل نفسه يبدو أكثر تسطحًا، نعومة، لامعًا، أو معدنيًا. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | المسافة التي يمتد فيها الشكل إلى الخلف من وجهه الأمامي. | تحويل الشكل المسطح إلى جسم ثلاثي الأبعاد سميك بوضوح. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | لون الجوانب المستخرجة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مُشكَّلة بدلاً من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getContourWidth--), و [setContourWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | الخط الخارجي حول الكائن ثلاثي الأبعاد. | تسليط الضوء على حدود الكائن في النتيجة المرسومة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثياً بصورة مقنعة:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي الإخراج.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات الإخراج أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلاً، يضيف نصاً إلى وجهه الأمامي، يطبق تنسيق ثلاثي الأبعاد، يحفظ العرض التقديمي كملف PPTX، ويعرض الشريحة كصورة PNG.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

تُظهر صورة الشريحة المرسومة المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق تم عرضه مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **تدوير الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة 3‑D Rotation. قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة PowerPoint 3‑D Rotation مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، حدد نوع الكاميرا والدوران عبر التنسيق ثلاثي الأبعاد المعاد من `shape.getThreeDFormat()`:

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

استخدم الكاميرا عندما تحتاج لتغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائي الأبعاد على الشريحة. إنه يغيّر نقطة المشهد ثلاثية الأبعاد المستخدمة من قبل PowerPoint وAspose.Slides عند العرض.

## **إضافة إخراج وعمق**

الإخراج يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم في العمق في هذه السماكة المرئية، ويتحكم التحكم في اللون في لون الجوانب.

![ضوابط العمق في PowerPoint مرتبطة بخصائص لون الإخراج وارتفاع الإخراج](img_02_02.png)

حدد ارتفاع الإخراج للسماكة ولون الإخراج للجانب:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

استخدم إعداد العمق عندما تحتاج للعمل مباشرةً مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة، المادة، وتأثيرات النص. في كثير من سيناريوهات الشكل، يكون ارتفاع الإخراج هو الإعداد الأكثر وضوحًا لأنه يعبر مباشرةً عن الإخراج المرئي.

## **استخدام تعبئات متدرجة أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون ثابت، متدرج، نمط، أو تعبئة صورة على الوجه الأمامي وما زلت تستخدم نفس إعدادات الكاميرا، الإضاءة، المادة، والإخراج.

هذا المثال يطبق تعبئة متدرجة على الشكل ولون إخراج أغمق للجوانب:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

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

الإخراج المرسوم يحافظ على المتدرج على الوجه الأمامي ويعرض الإخراج بشكل منفصل:

![مستطيل ثلاثي الأبعاد بملء متدرج من الأزرق إلى البرتقالي وإخراج برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
    byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

الصورة تُعرض على الوجه الأمامي، بينما يُعرض الإخراج كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد بملء صورة على الوجه الأمامي وإخراج برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الأحرف نفسها إلى إخراج، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بتعبئة نمط، يطبق تحويل WordArt، ويضبط إعدادات ثلاثية الأبعاد على [ITextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/):

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

النص يُعرض كحروف ثلاثية الأبعاد منحنية ومُخرَجة:

![نص ثلاثي الأبعاد مُعرض مع تحويل WordArt مقوس، تعبئة نمط برتقالي، وإخراج داكن](img_02_05.png)

## **سلوك التصدير والعرض**

Aspose.Slides يحافظ على تنسيق ثلاثي الأبعاد عند الحفظ إلى تنسيقات PowerPoint مثل PPTX. عند العرض أو التصدير إلى تنسيقات ذات تخطيط ثابت، يتم تحويل المشهد ثلاثي الأبعاد إلى نقط raster أو يُرسم في الناتج كنتيجة ثنائية الأبعاد. ينطبق هذا عندما تعرض الشرائح إلى [PNG](/slides/ar/java/convert-powerpoint-to-png/)، تصدر إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، تصدر إلى [HTML](/slides/ar/java/convert-powerpoint-to-html/)، أو تولد إطارًا للتحويل إلى [video conversion](/slides/ar/java/convert-powerpoint-to-video/).

تذكر هذه النقاط:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، نظام الإضاءة، المادة، الإخراج، التعبئة، وتوسيع الشريحة.
- إذا كنت بحاجة لاستعراض القيم الموروثة أو المستندة إلى السمة، اقرأ [الخصائص الفعالة للشكل](/slides/ar/java/shape-effective-properties/).
- بعض تنسيقات الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك التنسيقات، يتم عرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة الشائعة**

### هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟

Aspose.Slides ينشئ ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة، ملفات PDF، أو صفحات HTML مشاهدات ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث يدعم ذلك التنسيق.

### ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعد؟

النموذج ثلاثي الأبعاد هو كائن ثلاثي أبعاد منفصل يُدرج في العرض التقديمي. التأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، الإخراج، الحافة، الإضاءة، والمادة. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد.

### ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد ظاهر؟

على الأقل، حدد دوران الكاميرا وإما الإخراج أو العمق. عمليًا، قم أيضًا بتحديد نظام الإضاءة والمادة حتى تكون الوجوه المرسومة ذات إضاءات وظلال واضحة.

### هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟

نعم. استخدم [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/).`getThreeDFormat()` لجسم الشكل و[ITextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` للنص.

### هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟

نعم. Aspose.Slides يعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات تُستخدم لتحويل الفيديو. يحتوي الناتج المصدّر على المظهر المرسوم، وليس كائنًا ثلاثيًا قابلًا للتحرير.

### هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الوراثة وإعدادات السمة؟

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [الخصائص الفعالة للشكل](/slides/ar/java/shape-effective-properties/) لقراءة الكاميرا النهائية، نظام الإضاءة، الحافة، والقيم الثلاثية الأبعاد ذات الصلة.