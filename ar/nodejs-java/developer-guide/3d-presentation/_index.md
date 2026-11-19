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
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في Node.js باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبثق والملء والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides لـ Node.js عبر Java إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد على طراز PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المستديرة، الإضاءة، المادة، التعبئة بالتدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذه المقالة تتحدث عن تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. ليست عن إدراج أو تعديل ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بتحويل تلك التأثيرات ثلاثية الأبعاد إلى الناتج الثنائي الأبعاد المُصدَّر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/)، الذي يتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

بالنسبة إلى النص، استخدم طريقة [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). يُطبق هذا تنسيقًا ثلاثيًا الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم عناصر API هي:

| عضو API | ما يتحكم به | متى يتم استخدامه |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | نقطة المشاهدة، نوع الكاميرا المحدد مسبقًا، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد محدد مسبقًا في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | إعداد الضوء المحدد مسبقًا، الاتجاه، ودوران الضوء. | تغيير طريقة ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | مادة السطح، مثل مسطح، مطفي، بلاستيك أو معدن. | جعل الهندسة نفسها تبدو أكثر تسطحًا أو نعومة أو لامعة أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | المسافة التي يمتد بها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك مرئي. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | لون الجوانب المُبثقة. | إظهار العمق أو تنسيق لون الجوانب مع ملء الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | عمق ثلاثي الأبعاد إضافي تُستخدمه تنسيقات ثلاثية الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | حواف مرتفعة أو مستديرة على الوجهين الأمامي والخلفي. | إضافة حافة مُنعّمة أو مُقوّسة بدلًا من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor)، [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth)، و [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | حدود حول الكائن ثلاثي الأبعاد. | إبراز حدود الكائن في الناتج المُعَرض. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بصدق:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على طريقة عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي يُنشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق هو 100 نقطة. يُصدِّر المثال الشريحة إلى صورة PNG بمقاس ضعف الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

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

تُظهر صورة الشريحة المُصدَّرة المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **تدوير الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من خلال لوحة “3-D Rotation”. قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة “3-D Rotation” في PowerPoint مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، يمكن الوصول إلى الكاميرا عبر [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera). يُنشئ هذا المثال مستطيلًا، يختار عرضًا أماميًا أرثوغرافيًا، ويضبط دورانات X وY وZ إلى 20 و30 و40 درجة على التوالي. يُكوّن الشكل في الذاكرة دون حفظ ملف:

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

استخدم الكاميرا عندما تحتاج إلى تعديل طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائي الأبعاد على الشريحة. يغيّر فقط منظور ثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides عند العرض.

### **نسخ توجيه الكاميرا من شكل قالب**

لمطابقة توجيه شكل القالب، اقرأ إعداد الكاميرا المحدد مسبقًا عبر [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) وزوايا الدوران عبر [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation). يفتح المثال الملف `template.pptx` ويُنسخ توجيه الكاميرا من الشكل الأول في الشريحة الأولى إلى الشكل الثاني. كلا الشكلين يمتلكان إضاءة ثلاثية الأبعاد، والشكل الثاني لا يملك دوران كاميرا صريح.

القيم بالدرجات. الفهرس `0` هو دائرة العرض، الفهرس `1` هو خط الطول، والفهرس `2` هو الثورة. مرّرها إلى [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) بهذا الترتيب. إذا أرجع المصدر `null`، فهذا يعني عدم وجود دوران صريح، لذا اترك زوايا الشكل الثاني غير مضبوطة. دوران صريح `(0, 0, 0)` يُرجع ثلاثة أصفار ويجب نسخه.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

عند إعادة فتح `camera-copy.pptx` في PowerPoint، يكون السهم الأيمن له نفس إعداد الكاميرا والدوران مثل المستطيل الأيسر. كلا الشكلين يستخدمان الإضاءة وعمق البثق نفسه.

![مستطيل أزرق ثلاثي الأبعاد وسهم أيمن بتوجيه كاميرا متطابق، معروض من الأعلى وإلى اليمين](camera-orientation.png)

## **إضافة البثق والعمق**

البثق يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم بالعمق في هذا السمك الظاهر، وتتحكم خاصية اللون في لون الجوانب.

![عناصر تحكم العمق في PowerPoint مرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

استخدم [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) لتحديد السمك و[ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) للوصول إلى لون الجوانب. يُعطي هذا المثال المستطيل بارتفاع بثق 100 نقطة مع جوانب أرجوانية ويُدوّر الكاميرا لإظهار السمك. يُكوّن الشكل في الذاكرة دون حفظ ملف:

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

تُحدد طريقة [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) عمق الشكل ثلاثي الأبعاد. تُتحكم طريقة [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام تعبئة التدرج أو الصورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي وما زلت تستخدم نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تدرج أزرق إلى برتقالي على الوجه الأمامي ولون برتقالي غامق على بُثق بطول 150 نقطة. توقّف التدرج عند 0 و100 لتحديد بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُصدّر الشريحة إلى صورة PNG بمقاس ضعف الأبعاد الافتراضية:

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

الإخراج المُصدَّر يحتفظ بالتدرج على الوجه الأمامي ويُظهر البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مع تعبئة تدرج أزرق إلى برتقالي وبُثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال ملفًا موجودًا باسم "image.jpg" في دليل العمل. يُمدّد الصورة لملء المستطيل، يطبق بُثق 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يُكوّن الشكل في الذاكرة دون حفظ أو عرض ملف:

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

تُعرض الصورة على الوجه الأمامي، بينما يُظهر البُثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مع تعبئة صورة على الوجه الأمامي وبُثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تؤثر تنسيقات ثلاثية الأبعاد للأشكال على جسم الشكل. وتؤثر تنسيقات ثلاثية الأبعاد للنص على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الأحرف نفسها إلى بُثق ومادة وإضاءة وإعدادات كاميرا.

المثال التالي يُنشئ نصًا بنمط شبكة برتقالي-أبيض، يطبّق قوسًا صاعدًا، ويُكوّن إعدادات ثلاثية الأبعاد عبر [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). ارتفاع البثق والعمق بالنقاط، ودوران الإضاءة بالدرجات. يُخفى ملء الشكل والحد حتى يصبح النص هو العنصر الوحيد المرئي. يُصدّر المثال صورة PNG بمقاس ضعف أبعاد الشريحة الافتراضية ويحفظ العرض كملف PPTX:

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

يُعرض النص كحروف ثلاثية الأبعاد مقوسة ومُبثقة:

![نص ثلاثي الأبعاد مع تحويل WordArt مقوّس وتعبئة بنمط برتقالي ونص مُبثق داكن](img_02_05.png)

## **إبقاء النص مسطّحًا على شكل ثلاثي الأبعاد**

للحفاظ على قابلية قراءة النص مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، استدعِ [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) عبر [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). عندما تكون القيمة `true`، يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع توجيه ثلاثي الأبعاد.

هذه الإعدادات لا تُزيل تنسيق الشكل ثلاثي الأبعاد: الكاميرا والإضاءة والمادة والبُثق لا تزال مُكوَّنة عبر [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat). وهي مختلفة عن الدوران العادي. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) يدور الشكل في مستوى الشريحة، بينما [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) يتحكم في دوران النص داخل مربع محتواه. إبقاء النص خارج المشهد لا يُعيد تعيين أي من هذين الزاويتين.

المثال التالي المُتكامل يُنشئ مستطيلًا أزرقًا مع نص ويُستنسخه بجانب الأصل. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ اختلاف إعداد النص فقط: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البُثق 40 نقطة. يُحفظ العرض كملف PPTX ويُصدّر شريحة المقارنة إلى PNG بمقاس ضعف الأبعاد الافتراضية.

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

على اليسار، يتبع النص توجيه ثلاثي الأبعاد. على اليمين، يبقى مسطّحًا وأسهل قراءة. كلا المستطيلين يحتفظان بنفس البُثق الظاهري وتوجيه ثلاثي الأبعاد.

![مستطيلان ثلاثيان جنبًا إلى جنب: النص يتبع توجيه ثلاثي الأبعاد على اليسار ويظل مسطّحًا على اليمين](keep_text_flat.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى تنسيقات PowerPoint مثل PPTX. عند العرض أو التصدير إلى تنسيقات ذات تخطيط ثابت، يتم تقطيع المشهد ثلاثي الأبعاد أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق هذا عند عرض الشرائح إلى [PNG](/slides/ar/nodejs-java/convert-powerpoint-to-png/)، أو التصدير إلى [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، أو التصدير إلى [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)، أو إنشاء إطارات لتحويل [video](/slides/ar/nodejs-java/convert-powerpoint-to-video/).

احرص على ما يلي:

- الصور وملفات PDF المُصدَّرة ليست تفاعلية. لا يمكن للمُشاهد دوران الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، وإضاءة rig، والمادة، والبُثق، والملء، وتوسيع الشريحة.
- إذا أردت فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [خصائص الشكل الفعالة](/slides/ar/nodejs-java/shape-effective-properties/).
- بعض تنسيقات الإخراج لا يمكنها تخزين تنسيقات PowerPoint ثلاثية الأبعاد القابلة للتحرير. في هذه الصيغ، يُعرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

إن Aspose.Slides تنشئ وتعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا تجعل الصور أو ملفات PDF أو صفحات HTML تفاعلية كمشاهد ثلاثية الأبعاد يمكن للمُشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث يدعم التنسيق ذلك.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد مستقل يُدرج في العرض. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد ظاهر؟**

على الأقل، اضبط دوران الكاميرا وإما البثق أو العمق. عمليًا، يُفضَّل أيضًا ضبط إضاءة rig والمادة حتى تكون الوجوه المعروضة ذات إضاءات وظلال واضحة.

**هل يمكن تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**

نعم. استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) لجسم الشكل و[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) للنص.

**هل تظهر التأثيرات الثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات الفيديو؟**

نعم. يقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات تُستخدم لتحويل الفيديو. يحتوي الإخراج المُصدَّر على المظهر المعروض، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

**هل يمكن قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات لتنسيق فعَّال الموصوفة في [خصائص الشكل الفعالة](/slides/ar/nodejs-java/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة rig، والحافة، والقيم الثلاثية الأبعاد ذات الصلة.