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
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في Java باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمواد والبروز والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java إنشاء وتحرير والحفاظ على وعرض تنسيق ثلاثي الأبعاد بنمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، والبروز، والحواف، والإضاءة، والمواد، وتعبئات التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="primary" %}}
هذا المقال يدور حول تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا يتعلق بإدراج أو تحرير ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بتطبيق تلك التأثيرات ثلاثية الأبعاد على الناتج الثنائي الأبعاد المُصدَّر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/).`getThreeDFormat()` لتطبيق تنسيق ثلاثي الأبعاد على شكل. يتحكم كائن التنسيق المعاد في المشهد ثلاثي الأبعاد لهذا الشكل.

بالنسبة للنص، استخدم [ITextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. يطبق هذا تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم أعضاء الواجهة البرمجية هي:

| عضو API | ما الذي يتحكم به | متى تستخدمه |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getCamera--) | نقطة المشاهدة، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق للدوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getLightRig--) | إعداد مسبق للإضاءة، الاتجاه، ودوران الضوء. | تغيير طريقة ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | جعل الهندسة نفسها تبدو أكثر تسطحًا أو نعومة أو لامعًا أو معدنيًا. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | المسافة التي يمتد فيها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك يُرى بوضوح. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | لون الجوانب البازولة. | إظهار العمق أو تنسيق لون الجوانب مع التعبئة الأمامية. |
| [getDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق PowerPoint ثلاثي الأبعاد. | ضبط العمق للأشكال أو النص، خاصةً مع إعدادات الحواف والمواد. |
| [getBevelTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مقلوبة بدلاً من سطح مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#getContourWidth--), و [setContourWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | حدود حول الكائن ثلاثي الأبعاد. | إبراز حدود الكائن في الناتج المرسوم. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات ليظهر بشكل ثلاثي الأبعاد مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البروز.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب مقروءة.
- إعدادات المواد، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات البروز أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيقًا ثلاثيًا الأبعاد، يحفظ العرض التقديمي كـ PPTX، ويعرض الشريحة كصورة PNG.

```java
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

الصورة المصدرة تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **تدوير شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة 3‑D Rotation. قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر واجهة برمجة كاميرا.

![لوحة دوران ثلاثي الأبعاد في PowerPoint مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، عيّن نوع الكاميرا والدوران عبر تنسيق 3D المعاد من `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

استخدم الكاميرا عندما تحتاج إلى تعديل طريقة رؤية المشاهد للكائن. لا يغير ذلك هندسة الشكل الثنائي الأبعاد على الشريحة. إنه يغير نقطة المشاهدة ثلاثية الأبعاد التي يستخدمها PowerPoint وAspose.Slides أثناء العرض.

## **إضافة بروز وعمق**

البروز يجعل الشكل يبدو سميكًا بامتداده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم بالعمق في هذا السمك المرئي، ويتحكم التحكم باللون في لون وجوه الجوانب.

![ضوابط عمق PowerPoint مربوطة بخصائص لون البروز وارتفاع البروز](img_02_02.png)

عيّن ارتفاع البروز للسمك ولون البروز للجانب:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

استخدم إعداد العمق عندما تحتاج إلى العمل مباشرة مع قيمة العمق في PowerPoint أو دمجه مع الحواف والمواد وتأثيرات النص. في العديد من الحالات، يكون ضبط ارتفاع البروز هو الإعداد الأكثر وضوحًا لأنه يعبر مباشرة عن البروز المرئي.

## **استخدام تعبئة تدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي مع الاستمرار في استخدام نفس إعدادات الكاميرا والإضاءة والمواد والبروز.

هذا المثال يطبق تعبئة تدرج على الشكل ولون بروز أغمق على الجوانب:

```java
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

الناتج المصدّر يحافظ على التدرج على الوجه الأمامي ويعرض البروز بشكل منفصل:

![مستطيل ثلاثي الأبعاد بتعبئة تدرج من الأزرق إلى البرتقالي وبروز برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلًا من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها كملء الشكل:

```java
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
```

تظهر الصورة على الوجه الأمامي، بينما يُعرض البروز كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد بتعبئة صورة على الوجه الأمامي وبروز برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الحروف نفسها إلى بروز، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بتعبئة نمط، يطبق تحويل WordArt، ويضبط إعدادات ثلاثية الأبعاد على [ITextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/):

```java
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

النص يُعرض كحروف منحنيّة ومبطونة ثلاثيًا:

![نص ثلاثي الأبعاد مع تحويل WordArt مقوس، تعبئة نمط برتقالية، وبروز داكن](img_02_05.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ثابتة، يتم تحويل المشهد ثلاثي الأبعاد إلى نقطية أو رسمه في النتيجة كإخراج ثنائي الأبعاد. ينطبق ذلك عند عرض الشرائح إلى [PNG](/slides/ar/java/convert-powerpoint-to-png/)، أو تصدير إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، أو تصدير إلى [HTML](/slides/ar/java/convert-powerpoint-to-html/)، أو إنشاء إطارات لتحويل [الفيديو](/slides/ar/java/convert-powerpoint-to-video/).

احرص على مراعاة التالي:

- الصور وملفات PDF المصدَّرة ليست تفاعلية. لا يمكن للمستخدم تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، وإضاءة المشهد، والمواد، والبروز، والتعبئة، وتوسيع الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو القائمة على القالب، اقرأ [خصائص الشكل الفعّالة](/slides/ar/java/shape-effective-properties/).
- بعض صيغ الإخراج لا تستطيع تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتعديل.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

يُنشئ Aspose.Slides ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور أو ملفات PDF أو صفحات HTML تفاعلية كمشاهد ثلاثية الأبعاد يمكن للمستخدم تدويرها. في PPTX، يظل تنسيق ثلاثي الأبعاد قابلًا للتحرير في PowerPoint حيث يدعم الصيغة ذلك.

**ما الفرق بين النموذج الثلاثي الأبعاد والتأثير الثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد مستقل يُدرج في العرض. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البروز، الحافة، الإضاءة، والمواد. يغطِّى هذا المقال تأثيرات ثلاثية الأبعاد.

**ما الإعدادات المطلوبة لظهور شكل ثلاثي الأبعاد؟**

على الأقل، عيّن دوران الكاميرا وإما البروز أو العمق. عمليًا، يُفضَّل أيضًا ضبط إضاءة المشهد والمواد لكي تكون الوجوه ذات إضاءات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟**

نعم. استخدم [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/).`getThreeDFormat()` لجسم الشكل و[ITextFrameFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات الفيديو؟**

نعم. يقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، ومخرجات PDF، ومخرجات HTML، وإطارات الفيديو. يحتوي الناتج المصدَّر على المظهر المرسوم، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

**هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الوراثة وإعدادات القالب؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [خصائص الشكل الفعّالة](/slides/ar/java/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة المشهد، والحافة، والقيم الثلاثية الأبعاد ذات الصلة.