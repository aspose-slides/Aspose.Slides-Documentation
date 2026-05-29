---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام Node.js
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في Node.js باستخدام Aspose.Slides. قم بضبط الكاميرا والإضاءة والمادة والبثق والملء والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides لـ Node.js عبر Java إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف، الإضاءة، المواد، التدرجات أو ملء الصور، والنص ثلاثي الأبعاد.

{{% alert color="primary" %}}
هذه المقالة تتعلق بتأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا تتعلق بإدراج أو تحرير ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في الإخراج الثنائي الأبعاد المُصدّر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` لتطبيق تنسيق ثلاثي الأبعاد على شكل. الكائن [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/) المعاد يتحكم في مشهد ثلاثي الأبعاد لذلك الشكل.

بالنسبة للنص، استخدم [TextFrameFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`. هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم أعضاء API هي:

| عضو API | ما الذي يتحكم فيه | متى يتم استخدامه |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getCamera) | نقطة المشهد، نوع الكاميرا المحددة مسبقًا، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق للدوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getLightRig) | إعداد مسبق للضوء، الاتجاه، ودوران الضوء. | تغيير طريقة ظهور الإضاءات والظلال على سطح الشكل ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setMaterial) | مادة السطح، مثل مسطح، غير لامع، بلاستيك أو معدن. | جعل الشكل نفسه يبدو مسطحًا أكثر، ناعمًا، لامعًا أو معدنيًا. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | المسافة التي يمتد بها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك ظاهر. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | لون الجوانب البثق. | إظهار العمق أو تنسيق لون الجوانب مع التعبئة الأمامية. |
| [getDepth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setDepth) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | تعديل العمق للأشكال أو النص، خصوصًا مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مصبوبة بدلاً من سطح مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getContourColor)، [getContourWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setContourWidth) | الخط الخارجي حول الكائن ثلاثي الأبعاد. | إبراز حدود الكائن في الإخراج المعروض. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.  
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.  
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.  
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيقًا ثلاثيًا الأبعاد، يحفظ العرض التقديمي كملف PPTX، ويعرض الشريحة كصورة PNG.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تظهر صورة الشريحة المُعرضة المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق تم عرضه مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **تدوير شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين التدوير ثلاثي الأبعاد من لوحة 3‑D Rotation. قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة تدوير ثلاثي الأبعاد في PowerPoint مع إبراز قيم الدوران X، Y، Z](img_02_01.png)

في Aspose.Slides، اضبط نوع الكاميرا والدوران عبر تنسيق 3D المعاد من `shape.getThreeDFormat()`:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل الثنائي الأبعاد على الشريحة. إنه يغيّر نقطة المشهد ثلاثية الأبعاد التي يستخدمها PowerPoint وAspose.Slides عند العرض.

## **إضافة بثق وعمق**

البثق يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم عمق التحكم في هذا السماكة الظاهرة، وتتحكم خاصية اللون في لون الجوانب.

![تحكمات العمق في PowerPoint مرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

قم بتعيين ارتفاع البثق للسماكة ولون البثق للون الجوانب:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

استخدم إعداد العمق عندما تحتاج إلى العمل مباشرةً بقيمة العمق في PowerPoint أو دمج العمق مع الحافة، المادة، وتأثيرات النص. في العديد من سيناريوهات الشكل، يكون ارتفاع البثق هو الإعداد الأكثر وضوحًا لأنه يعبر مباشرةً عن البثق الظاهر.

## **استخدام تعبئة تدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي ولا يزال بإمكانك استخدام نفس إعدادات الكاميرا، والإضاءة، والمادة، والبثق.

هذا المثال يطبق تعبئة تدرج على الشكل ولون بثق أغمق للجوانب:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

الناتج المعروض يحتفظ بالتدرج على الوجه الأمامي ويعرض البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد تم عرضه مع تعبئة متدرجة من الأزرق إلى البرتقالي وبثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

الصورة تُعرض على الوجه الأمامي، بينما يُعرض البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد تم عرضه مع تعبئة صورة على الوجه الأمامي وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الأحرف نفسها إلى بثق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بتعبئة نمطية، يطبق تحول WordArt، ويُكوّن إعدادات ثلاثية الأبعاد على [TextFrameFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/):

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النص يُعرض كحروف ثلاثية الأبعاد منحنية ومبثوقة:

![نص ثلاثي الأبعاد تم عرضه مع تحويل WordArt مقوّس، تعبئة نمطية برتقالية، وبثق داكن](img_02_05.png)

## **سلوك التصدير والعرض**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ثابتة، يتم تحويل المشهد ثلاثي الأبعاد إلى نقطية أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق هذا عندما تعرض الشرائح إلى [PNG](/slides/ar/nodejs-java/convert-powerpoint-to-png/)، أو تصدر إلى [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، أو إلى [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)، أو تولد إطارات للتحويل إلى [video](/slides/ar/nodejs-java/convert-powerpoint-to-video/).

احرص على ما يلي:

- الصور وملفات PDF التي تم تصديرها غير تفاعلية. لا يمكن للمستخدم تدوير الكائن بعد التصدير.  
- المظهر النهائي يعتمد على دمج الكاميرا، وإضاءة المشهد، والمادة، والبثق، والملء، وتكبير الشريحة.  
- إذا كنت بحاجة إلى فحص القيم الموروثة أو قيم التنسيق المستندة إلى القالب، اقرأ [effective shape properties](/slides/ar/nodejs-java/shape-effective-properties/).  
- بعض صيغ الإخراج لا يمكنها حفظ تنسيق 3D القابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من حفظها كإعدادات 3D قابلة للتعديل.

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**  
إن Aspose.Slides ينشئ ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدّرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في ملفات PPTX يبقى تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**  
النموذج ثلاثي الأبعاد هو كائن ثلاثي أبعاد مستقل يُدرج في العرض التقديمي. أما التأثير الثلاثي الأبعاد فهو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. تغطي هذه المقالة التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة لشكل ثلاثي الأبعاد مرئي؟**  
كحد أدنى، يجب تحديد دوران الكاميرا وإما البثق أو العمق. عمليًا، من الأفضل أيضًا تحديد إضاءة المشهد والمادة حتى تكون الوجوه الظلية والإضاءات واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟**  
نعم. استخدم [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` لجسم الشكل و[TextFrameFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**  
نعم. تقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنشاء صور الشرائح، أو إخراج PDF، أو إخراج HTML، أو إطارات تُستخدم للتحويل إلى فيديو. يحتوي الناتج المُصدّر على المظهر المعروض، وليس كائنًا ثلاثيًا أُبعادًا قابلاً للتحرير.

**هل يمكنني قراءة القيم النهائية ثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات القالب؟**  
نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموصوفة في [Shape Effective Properties](/slides/ar/nodejs-java/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة المشهد، والحافة، والقيم الثلاثية الأبعاد ذات الصلة.