---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام Node.js
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- عرض تقديمي ثلاثي الأبعاد
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
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في Node.js باستخدام Aspose.Slides. تكوين الكاميرا، الإضاءة، المادة، البثق، التعبئات، والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides لـ Node.js عبر Java يمكنه إنشاء، تعديل، حفظ، وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة التأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف، الإضاءة، المادة، التعبئة المتدرجة أو صورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذه المقالة تدور حول تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا تتعلق بإدراج أو تعديل ملفات نماذج ثلاثية الأبعاد منفصلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في النتيجة المصدرة ثنائية الأبعاد.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getThreeDFormat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة الكائن [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/)، الذي يتحكم في المشهد ثلاثي الأبعاد لذلك الشكل.

بالنسبة للنص، استخدم طريقة [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). يطبق هذا تنسيقًا ثلاثيًا الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم أعضاء API هي:

| عضو API | ما يتحكم فيه | متى تستخدمه |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getCamera) | نقطة العرض، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | قم بدوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق لدوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getLightRig) | إعداد إضاءة مسبق، الاتجاه، ودوران الإضاءة. | تغيير طريقة ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getMaterial) و[setMaterial](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setMaterial) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | اجعل الهندسة نفسها تبدو أكثر تسطيحًا، نعومة، لامعة، أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) و[setExtrusionHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | المسافة التي يمتد بها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك بشكل واضح. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | لون الجوانب البثقية. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getDepth) و[setDepth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setDepth) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getBevelTop) و[getBevelBottom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مصقولة بدلاً من وجه مسطح وحاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getContourColor)، [getContourWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getContourWidth)، و[setContourWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setContourWidth) | الخط الخارجي حول الكائن ثلاثي الأبعاد. | تأكيد حدود الكائن في المخرجات المرسومة. |

## **إنشاء شكل ثلاثي الأبعاد**

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.  
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجانبين قابلين للقراءة.  
- إعدادات المادة، لأن السطح يؤثر على طريقة عرض الضوء.  
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى السماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيق ثلاثي الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق هو 100 نقطة. يقوم المثال بعرض الشريحة كصورة PNG بأبعاد مضاعفة عن الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

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

صورة الشريحة المعروضة تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي أبعاد أزرق مع نص ثلاثي أبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة "3-D Rotation". قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة دوران ثلاثي الأبعاد في PowerPoint مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، يمكنك الوصول إلى الكاميرا عبر [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getCamera). ينشئ هذا المثال مستطيلًا، يختار عرضًا أماميًا أرثوغرافيًا، ويضبط دورانات X وY وZ إلى 20 و30 و40 درجة على التوالي. يقوم بتكوين الشكل في الذاكرة دون حفظ ملف:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائية الأبعاد على الشريحة. إنه يغيّر منظور الـ3D المستخدم من قبل PowerPoint وAspose.Slides عند العرض.

## **إضافة بثق وعمق**

البثق يجعل الشكل يبدو سميكًا عن طريق تمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم بالعمق في هذا السُمك المرئي، ويتحكم التحكم باللون في لون الوجوه الجانبية.

![ضوابط العمق في PowerPoint مرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

استخدم [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) لتعيين السمك و[ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) للوصول إلى لون الجوانب. يمنح هذا المثال المستطيل بُثقًا بارتفاع 100 نقطة مع جوانب بنفسجية ويقوم بدوران الكاميرا لإظهار سُمكه. يضبط الشكل في الذاكرة دون حفظ ملف:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

طريقة [ThreeDFormat.setDepth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setDepth) تحدد عمق الشكل ثلاثي الأبعاد. طريقة [setExtrusionHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) تتحكم في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام تعبئات متدرجة أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب، أو تدرج، أو نمط، أو تعبئة صورة على الوجه الأمامي وما زلت تستطيع استخدام نفس إعدادات الكاميرا، والإضاءة، والمادة، والبثق.

يطبق هذا المثال تدرجًا من الأزرق إلى البرتقالي على الوجه الأمامي ولونًا برتقاليًا داكنًا على البثق بارتفاع 150 نقطة. نقاط التدرج عند 0 و100 تمثل بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُعرض الشريحة كصورة PNG بأبعاد مضاعفة عن الأبعاد الافتراضية:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

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

![مستطيل ثلاثي أبعاد مع تعبئة تدرج أزرق إلى برتقالي وبثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال ملفًا موجودًا باسم "image.jpg" في دليل العمل. يقوم بتمديد الصورة لملء المستطيل، يطبق بُثقًا بارتفاع 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يضبط الشكل في الذاكرة دون حفظ أو عرض ملف:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![مستطيل ثلاثي أبعاد مع تعبئة صورة على الوجه الأمامي وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الحروف نفسها إلى بُثق، مادة، إضاءة، وإعدادات كاميرا.

ينشئ المثال التالي نصًا بنمط شبكة برتقالي وأبيض، يطبق قوسًا صاعدًا، ويضبط إعدادات ثلاثية الأبعاد عبر [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). ارتفاع البثق والعمق بالنقاط، ودوران الضوء بالدرجات. تم إخفاء تعبئة الشكل والحد بحيث يكون النص هو الوحيد الظاهر. يعرض المثال صورة PNG بأبعاد مضاعفة عن أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

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
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
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

![نص ثلاثي أبعاد مع تحويل WordArt مقوس، تعبئة نمط برتقالي، وبثق داكن](img_02_05.png)

## **الحفاظ على نص مسطح على شكل ثلاثي الأبعاد**

للحفاظ على قابلية قراءة النص مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، استدعِ [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) عبر [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). عندما تكون القيمة `true`، يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع توجيه ثلاثي الأبعاد.

هذه الإعدادات لا تزيل تنسيق ثلاثي الأبعاد للشكل: الكاميرا، الإضاءة، المادة، والبثق لا يزالون مُكوَّنين عبر [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getThreeDFormat). وهو مختلف أيضًا عن الدوران العادي. [Shape.setRotation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#setRotation) يدور الشكل في مستوى الشريحة، بينما [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) يتحكم في دوران النص داخل مربع حدوده. إبقاء النص خارج المشهد ثلاثي الأبعاد لا يعيد تعيين أي من هذين الزاويتين.

يخلق المثال التالي المستقل مستطيلًا أزرقًا مع نص ويستنسخه بجانب الأصلي. كلا الشكلين يملكان نفس تنسيق ثلاثي الأبعاد؛ فقط إعداد النص يختلف: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البثق 40 نقطة. يحفظ العرض التقديمي كملف PPTX ويعرض شريحة المقارنة كصورة PNG بأبعاد مضاعفة عن الأبعاد الافتراضية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

على اليسار، يتبع النص توجيه ثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل للقراءة. كلا المستطيلين يحتفظان بنفس البُثق المرئي وتوجيه ثلاثي الأبعاد.

![مستطيلات ثلاثية الأبعاد جنبًا إلى جنب: النص يتبع توجيه ثلاثي الأبعاد على اليسار ويظل مسطحًا على اليمين](keep_text_flat.png)

## **سلوك التصدير والعرض**

تُحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ذات تخطيط ثابت، يتم تحويل المشهد ثلاثي الأبعاد إلى صورة ثنائية الأبعاد أو يُرسم في النتيجة. ينطبق ذلك عند عرض الشرائح إلى [PNG](/slides/ar/nodejs-java/convert-powerpoint-to-png/)، أو تصدير إلى [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، أو تصدير إلى [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)، أو إنشاء إطارات لتحويل [الفيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/).

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.  
- المظهر النهائي يعتمد على مزيج الكاميرا، وإضاءة المشهد، والمادة، والبثق، والتعبئة، وتكبير الشريحة.  
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [خصائص الشكل الفعّالة](/slides/ar/nodejs-java/shape-effective-properties/).  
- بعض صيغ الإخراج لا تستطيع تخزين تنسيق ثلاثي الأبعاد القابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة البصرية بدلًا من الاحتفاظ بها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**  
Aspose.Slides ينشئ ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلاً للتعديل في PowerPoint حيث يدعم الصيغة ذلك.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**  
النموذج ثلاثي الأبعاد هو كائن ثلاثي الأبعاد منفصل يُدرج في العرض التقديمي. التأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. تغطي هذه المقالة التأثيرات ثلاثية الأبعاد.

**ما الإعدادات المطلوبة لتكوين شكل ثلاثي الأبعاد مرئي؟**  
على الأقل، اضبط دوران الكاميرا وإما البثق أو العمق. عمليًا، قم أيضًا بضبط إضاءة المشهد والمادة حتى تكون الوجوه المرسومة واضحة مع إبرازات وظلال.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**  
نعم. استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getThreeDFormat) للجسم الشكل و[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور، PDF، HTML، أو إطارات فيديو؟**  
نعم. تقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، ملفات PDF، ملفات HTML، وإطارات الفيديو. الناتج المصدّر يحتوي على المظهر المرجعي، وليس كائنًا ثلاثي الأبعاد قابلًا للتعديل.

**هل يمكنني قراءة القيم النهائية ثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات السمة؟**  
نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [خصائص الشكل الفعّالة](/slides/ar/nodejs-java/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة المشهد، والحافة، والقيم الثلاثية الأبعاد المرتبطة.