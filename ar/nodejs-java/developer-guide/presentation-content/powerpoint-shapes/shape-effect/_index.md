---
title: "تطبيق تأثيرات الشكل في العروض التقديمية باستخدام JavaScript"
linktitle: "تأثير الشكل"
type: docs
weight: 30
url: /ar/nodejs-java/shape-effect/
keywords:
- "تأثير الشكل"
- "تأثير الظل"
- "تأثير الانعكاس"
- "تأثير التوهج"
- "تأثير الحواف الناعمة"
- "تنسيق التأثير"
- "PowerPoint"
- "عرض تقديمي"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر JavaScript و Aspose.Slides لـ Node.js—أنشئ شرائح جذابة ومهنية في ثوانٍ."
---
## **مقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [الملئ](/slides/ar/nodejs-java/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات واقعية على الشكل، ونشر توهج الشكل، وغيرها.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يوفر PowerPoint خيارات تحت **الإعداد المسبق**. خيارات الإعداد المسبق هي تركيبات من تأثيرين أو أكثر تُعرف بأنها تبدو جيدة. بهذه الطريقة، عند اختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة جيدة.

توفر Aspose.Slides خصائص وأساليب ضمن فئة [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides لـ Node.js عبر Java الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، واتجاهها، والمسافة، ونصف قطر التشويش لتتناسب مع تصميم عرضك.

### **تطبيق ظل خارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حواف الشكل، مما يعطي انطباعًا بأن الشكل مرتفع فوق الشريحة. اضبط لونه، واتجاهه، ومسافته، ونصف قطر التشويش ليتناسب مع الإضاءة وتنسيق القالب.

يعرض هذا الكود JavaScript كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) على مستطيل:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تأثير الظل](shadow_effect.png)

### **تطبيق ظل داخلي**

عند إعادة إنتاج النمط البصري للقالب، استخدم ظلًا داخليًا لإعطاء البطاقة أو اللوحة مظهرًا متراجعًا. يمتد الظل الخارجي خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حوافه.

استدعِ [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)، ثم قم بتهيئة الظل الذي تعيده الدالة [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). قيم نصف قطر التشويش الأكبر تنتج حوافًا أكثر نعومة.

هذا المثال JavaScript ينشئ بطاقة زرقاء فاتحة مع ظل داخلي رمادي غامق ويحفظها كملف PPTX. اتجاه الظل هو 225 درجة، والمسافة 7 نقاط، ونصف قطر التشويش 6 نقاط:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![مستطيل أزرق فاتح مع ظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) على تنسيق تأثير الشكل.

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides لـ Node.js عبر Java، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، مع ضبط معلمات مثل المسافة، والشفافية، والحجم. يعزز هذا التأثير جمالية عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تنفيذها باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عناصر متعددة لتصميم متسق.

يعرض هذا الكود JavaScript كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) على شكل:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تأثير الانعكاس](reflection_effect.png)

## **تطبيق تأثير التوهج**

لتطبيق تأثير توهج على شكل في Aspose.Slides لـ Node.js عبر Java، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع ضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا وملفتًا للانتباه إلى عرضك. من السهل تنفيذه باستخدام كود قليل، مما يعزز المظهر العام لشرائحك.

يعرض هذا الكود JavaScript كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) على شكل:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تأثير التوهج](glow_effect.png)

## **تطبيق تأثير الحواف الناعمة**

لتطبيق تأثير الحواف الناعمة في Aspose.Slides لـ Node.js عبر Java، يمكنك إنشاء انتقال سلس ومشوش حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر دقة ورقة، وهو مثالي للتصاميم التي تحتاج إلى مظهر ناعم وأقل وضوحًا. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال متعددة في عرضك.

يعرض هذا الكود JavaScript كيفية تطبيق [تأثير الحواف الناعمة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) على شكل:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تأثير الحواف الناعمة](soft_edges_effect.png)

## **الأسئلة الشائعة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، والانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال متنوعة، بما في ذلك الأشكال التلقائية، والرسوم البيانية، والجداول، والصور، وكائنات SmartArt، وكائنات OLE، وغيرها.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيطبق التأثير على المجموعة بأكملها.