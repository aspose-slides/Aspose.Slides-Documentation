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
description: "تطبيق وتصيير تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص على Android باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Android via Java إنشاء وتحرير وحفظ وعرض تنسيق 3D على نمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات 3D مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، التعبئات المتدرجة أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="primary" %}}
هذا المقال يتناول تأثيرات تنسيق 3D على أشكال PowerPoint والنص. لا يتعلق بإدراج أو تحرير ملفات نماذج 3D مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بتجسيد تلك التأثيرات ثلاثية الأبعاد في الناتج الثنائي الأبعاد المُصدّر.
{{% /alert %}}

## **مفاهيم تنسيق 3D**

استخدم الطريقة [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) لتطبيق تنسيق 3D على شكل. تُعيد الطريقة [IThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/)، الذي يتحكم في مشهد 3D لهذا الشكل.

بالنسبة للنص، استخدم الطريقة [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--)، حيث تُطبق تنسيق 3D على إطار النص بدلاً من جسم الشكل.

أهم الأعضاء في API هي:

| عضو API | ما يتحكم به | متى يتم استخدامه |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | نقطة المشاهدة، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق لدوران 3D في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | إعداد مسبق للضوء، الاتجاه، ودوران الإضاءة. | تغيير طريقة ظهور الإبرازات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) و [setMaterial](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | جعل الهندسة نفسها تبدو أكثر تسطحًا، نعومة، لامعة، أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | مدى بُعد الشكل إلى الخلف من واجهته الأمامية. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك مرئي. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | لون الجوانب المستخرجة. | إظهار العمق أو تنسيق لون الجوانب مع التعبئة الأمامية. |
| [getDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getDepth--) و [setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | عمق ثلاثي أبعاد إضافي يُستخدم في تنسيق 3D الخاص بـ PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصة عند الجمع مع إعدادات الحافة والمواد. |
| [getBevelTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مصبوبة بدلاً من وجه مسطح وحاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), و [setContourWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | الخط الخارجي حول الكائن ثلاثي الأبعاد. | تأكيد حدود الكائن في المخرجات المرسومة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثي الأبعاد بشكل مقنع:

- إعدادات الكاميرا، لأن الرؤية الأمامية الافتراضية قد تخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى واجهته الأمامية، يطبق تنسيق 3D، يحفظ العرض التقديمي كملف PPTX، ويصدر الشريحة كصورة PNG.

```java
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

تظهر صورة الشريحة المصدَّرة المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مُرَسَّم مع نص ثلاثي الأبعاد أبيض على الواجهة الأمامية](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين تدوير 3D من لوحة 3-D Rotation. قيم التدوير X و Y و Z تتطابق مع التدوير الذي تحدده عبر API الكاميرا.

![لوحة تدوير ثلاثي الأبعاد في PowerPoint مع إبراز قيم التدوير X و Y و Z](img_02_01.png)

في Aspose.Slides، اضبط نوع الكاميرا والدوران عبر [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا تغير الهندسة الثنائية الأبعاد للشكل على الشريحة. إنها تغير نقطة المشاهدة ثلاثية الأبعاد المستخدمة من قبل PowerPoint وAspose.Slides عند التصيير.

## **إضافة البثق والعمق**

البثق يجعل الشكل يبدو سميكًا بتمديده خلف الواجهة الأمامية. في PowerPoint، يتحكم التحكم بالعمق في هذه السماكة المرئية، ويتحكم التحكم باللون في لون الجوانب.

![ضوابط العمق في PowerPoint مرتبطة بلون البثق وخصائص ارتفاع البثق](img_02_02.png)

اضبط [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) لتحديد السماكة و[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) لتحديد لون الجوانب:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

استخدم [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) عندما تحتاج إلى التعامل مباشرةً مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة والمادة وتأثيرات النص. في كثير من سيناريوهات الشكل، يكون `setExtrusionHeight` هو الإعداد الأوضح لأنه يعبر مباشرةً عن البثق الظاهر.

## **استخدام تعبئات تدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق 3D مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الواجهة الأمامية مع الاستمرار في استخدام نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تعبئة تدرج على الشكل ولون بثق أغمق على الجوانب:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

تحتفظ النتيجة المصدَّرة بالتدرج على الواجهة الأمامية وتُظهر البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مُرَسَّم بتعبئة تدرج أزرق إلى برتقالي وبثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

تُرسم الصورة على الواجهة الأمامية، بينما يُظهر البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مُرَسَّم بتعبئة صورة على الواجهة الأمامية وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق 3D للشكل يؤثر على جسم الشكل. تنسيق 3D للنص يؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الحروف نفسها إلى بثق ومادة وإضاءة وإعدادات كاميرا.

المثال التالي ينشئ نصًا بتعبئة نمط، يطبق تحويل WordArt، ويُكوّن إعدادات 3D على [ITextFrameFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

يُرسم النص كحروف ثلاثية الأبعاد مقوسة ومُبَثق:

![نص ثلاثي الأبعاد مُرَسَّم بتجربة WordArt مقوسة، تعبئة نمط برتقالية، وبثق غامق](img_02_05.png)

## **سلوك التصدير والتصوير**

تحافظ Aspose.Slides على تنسيق 3D عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند التصيير أو التصدير إلى صيغ ثابتة التخطيط، يتم تحويل مشهد 3D إلى نقطية أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تُصوّر الشرائح إلى [PNG](/slides/ar/androidjava/convert-powerpoint-to-png/)، أو تُصدر إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، أو تُصدر إلى [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، أو تُولد إطارات للتحويل إلى [video](/slides/ar/androidjava/convert-powerpoint-to-video/).

ضع هذه النقاط في الاعتبار:

- الصور وملفات PDF المُصدَّرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، وإضاءة rig، والمادة، والبثق، والتعبئة، وتوسيع الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى الثيم، اقرأ [الخصائص الفعّالة للأشكال](/slides/ar/androidjava/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق 3D القابل للتحرير في PowerPoint. في تلك الصيغ، يتم تجسيد النتيجة البصرية بدلاً من حفظها كإعدادات 3D قابلة للتحرير.

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية تفاعلية ثلاثية الأبعاد؟**

تُنشئ Aspose.Slides وتُصوّر تأثيرات 3D في PowerPoint للأشكال والنص. لا تجعل الصور المُصدَّرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق 3D قابلاً للتحرير في PowerPoint حيث يدعم الصيغة ذلك.

**ما الفرق بين نموذج 3D وتأثير 3D؟**

النموذج ثلاثي الأبعاد هو كائن 3D منفصل يُدرج في العرض التقديمي. التأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. يغطي هذا المقال تأثيرات 3D.

**ما الإعدادات المطلوبة للحصول على شكل 3D مرئي؟**

على الأقل، اضبط دوران الكاميرا وأيًا كان البثق أو العمق. عمليًا، يجب أيضًا ضبط إضاءة rig والمادة حتى تكون الوجوه المُصوّرة ذات إبرازات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات 3D على كل من الأشكال والنص؟**

نعم. استخدم [IShape.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) لجسم الشكل و[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) للنص.

**هل تظهر تأثيرات 3D عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. تقوم Aspose.Slides بتصوير تأثيرات 3D عند إنتاج صور الشرائح، أو مخرجات PDF، أو مخرجات HTML، وإطارات تُستخدم للتحويل إلى فيديو. يحتوي الناتج المُصدَّر على المظهر المُصوَّر، وليس كائن 3D قابل للتحرير.

**هل يمكنني قراءة القيم النهائية لـ 3D بعد تطبيق الوراثة وإعدادات الثيم؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [Shape Effective Properties](/slides/ar/androidjava/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة rig، والحافة، والقيم الثلاثية الأبعاد ذات الصلة.