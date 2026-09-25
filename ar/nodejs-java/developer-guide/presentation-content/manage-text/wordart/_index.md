---
title: إنشاء وتطبيق تأثيرات WordArt في Node.js
linktitle: WordArt
type: docs
weight: 110
url: /ar/nodejs-java/wordart/
keywords:
- WordArt
- إنشاء WordArt
- قالب WordArt
- تأثير WordArt
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides لـ Node.js عبر Java. يقدّم هذا الدليل خطوة بخطوة للمطورين كيفية تحسين العروض التقديمية بالنص الاحترافي في Node.js."
---
## **نظرة عامة**

تتيح لك تأثيرات WordArt تنسيق النص باستخدام التعبئة، والحدود، والظلال، والإنعكاسات، والتوهج، والتحولات، وتنسيق ثلاثي الأبعاد. تشرح هذه المقالة كيفية إنشاء وتخصيص هذه التأثيرات في عروض PowerPoint باستخدام Aspose.Slides لـ Node.js عبر Java، دون الحاجة إلى تثبيت Microsoft Office.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

الأمثلة التالية تبني نمط WordArt بسيط عن طريق ضبط النص، الخط، تعبئة النمط، والحد.

كل مثال ينشئ عرضًا تقديميًا جديدًا ويضيف مستطيلًا إلى شريحته الأولى؛ لا يلزم ملف إدخال. يضبط المثال الأول النص إلى "Aspose.Slides". يتم قياس موضع الشكل وأبعاده بالنقاط:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

ضبط الخط إلى Arial Black بحجم 36 نقطة لجعل التنسيق أكثر وضوحًا:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

تطبيق نمط [SmallGrid](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/patternstyle/#SmallGrid) مع لون أمامي برتقالي داكن وخلفية بيضاء، ثم إضافة حد نص أسود بسمك نقطة واحدة:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

النص الناتج:

![قالب WordArt البسيط](WordArt_template.png)

## **تطبيق تأثيرات WordArt الأخرى**

الأمثلة التالية توضح كيفية تطبيق الظلال، الانعكاسات، التوهج، التحولات، وتأثيرات ثلاثية الأبعاد على النص.

### **تطبيق تأثيرات الظل الخارجي**

يضيف الظل الخارجي عمقًا عن طريق وضع ظل خلف النص. يمكنك تخصيص لونه، اتجاهه، مسافته، نصف قطر الضبابية، مقياسه، وزاوية الميل.

هذا المثال يستدعي [enableOuterShadowEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) ويضبط ظلًا أسود بنصف قطر ضبابية 4 نقاط، باتجاه 230 درجة، ومسافة 30 نقطة. قيم المقياس 100 تحافظ على حجم الظل، بينما يميل الميل الأفقي بزاوية 20 درجة. تحويل ألفا يحدد التعتيم إلى 32٪:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تأثير الظل الخارجي](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- عند استخدام الظل الخارجي والظلال المسبقة معًا، يتم تطبيق الظل الخارجي فقط.
- إذا تم استخدام الظل الخارجي والداخلي في آن واحد، يعتمد التأثير الناتج على نسخة PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير، بينما في PowerPoint 2007 يتم تطبيق الظل الخارجي فقط.
{{% /alert %}}

### **تطبيق تأثيرات الانعكاس**

ينشئ الانعكاس نسخة مرآة من النص. عدّل موضعه، مقياسه، ضبابيته، وتعتيمه للتحكم في مظهره.

هذا المثال يستدعي [enableReflectionEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) ويقلب الانعكاس عموديًا بمقياس -100٪. يستخدم نصف قطر ضبابية 0.5 نقطة ومسافة 4.72 نقطة. يتناقص التعتيم من 60٪ إلى 0.9٪ بين الموضعين 0٪ و60٪ على طول الانعكاس:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تأثير الانعكاس](reflection_effect.png)

### **تطبيق تأثيرات التوهج**

يضيف التوهج حدًا ملونًا ناعمًا حول النص. عدّل لونه، تعتميه، ونصف قطره للتحكم في التأثير.

هذا المثال يستدعي [enableGlowEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) ويطبق توهجًا أحمر بتعتيم 54٪ ونصف قطر 7 نقاط:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تأثير التوهج](glow_effect.png)

### **تطبيق تحولات WordArt**

تحولات WordArt تُعَوج، تمدد أو تشوّه كتلة النص.

اضبط [setTransform](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setTransform) إلى [ArchUpPour](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) لإقوس إطار النص بأكمله إلى الأعلى:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تحويل WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides لـ Node.js عبر Java يوفر مجموعة من [أنواع التحويل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textshapetype/) المحددة مسبقًا.
{{% /alert %}}

### **تطبيق تأثيرات 3D على الأشكال والنص**

يمكنك تطبيق تأثيرات 3D على شكل أو على نصه. تتحكم الحواف، البروز، الإضاءة، وإعدادات الكاميرا في المظهر النهائي.

المثال التالي يستخدم [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/) لإضافة حواف دائرية، بروز برتقالي، وحدود حمراء داكنة إلى المستطيل. تُقاس أبعاد الحافة، ارتفاع البروز، عرض الحد، والعمق بالنقاط. مادة بلاستيكية، إضاءة متوازنة تدور 40 درجة حول المحور Z، وكاميرا منظور تحدد مظهره:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

الشكل الناتج:

![تأثير الشكل ثلاثي الأبعاد](shape_3D_effect.png)

هذا المثال يطبق تنسيق 3D مشابه للنص عبر [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). الحواف الصغيرة تُشكل حواف الأحرف، بينما يمنح البروز والإضاءة النص عمقًا:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تأثير النص ثلاثي الأبعاد](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
تطبيق تأثيرات 3D على النص أو أشكاله—والتفاعل بين هذه التأثيرات—يحكمه قواعد محددة. اعتبر مشهدًا يضم النص والشكل الذي يحتويه. يتضمن تأثير 3D تمثيلًا ثلاثيًا للجسم والمشهد الذي يُوضع فيه.

- إذا تم تعيين مشهد لكل من الشكل والنص، يُعطى أولوية لمشهد الشكل وتُهمل مشهد النص.
- إذا كان الشكل لا يملك مشهدًا خاصًا لكنه يحتوي تمثيلًا ثلاثيًا، يُستخدم مشهد النص.
- إذا لم يكن لدى الشكل أي تأثير 3D، يُعامل كمسطح، ويُطبق تأثير 3D فقط على النص.

هذه السلوكيات تتعلق بطريقتي [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getLightRig) و[ThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

للحفاظ على النص مسطحًا وقابلًا للقراءة مع الحفاظ على تنسيق 3D للشكل، راجع [Keep Text Flat on a 3D Shape](/slides/ar/nodejs-java/3d-presentation/) للمقارنة بين الإعدادين ومثال JavaScript كامل.

## **FAQ**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو أنظمة كتابة مختلفة (مثل العربية أو الصينية)؟**

نعم، Aspose.Slides لـ Node.js عبر Java يدعم Unicode ويعمل مع جميع الخطوط والأنظمة الكتابية الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، على الرغم من أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر شريحة القالب الرئيسي؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في شرائح القالب الرئيسي، بما في ذلك عناصر العنوان، التذييل، أو النص الخلفي. سيُعكس أي تعديل تُجريّه على تخطيط القالب على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

تؤثر بشكل طفيف. قد تزيد تأثيرات WordArt مثل الظلال، التوهجات، وتعبئات التدرج حجم الملف قليلًا بسبب إضافة بيانات التنسيق، لكن الفارق عادة ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام [Slide.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getImage)، أو تصيير الأشكال الفردية باستخدام [Shape.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getImage). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض كاملاً.