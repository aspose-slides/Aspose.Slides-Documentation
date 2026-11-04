---
title: تطبيق تأثيرات الشكل في العروض التقديمية باستخدام جافاسكريبت
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/nodejs-java/shape-effect/
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعمة
- تنسيق التأثير
- PowerPoint
- عرض تقديمي
- Node.js
- جافاسكريبت
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر جافاسكريبت و Aspose.Slides لـ Node.js—أنشئ شرائح مبهرة واحترافية في ثوانٍ."
---
## **مقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [ملء](/slides/ar/nodejs-java/shape-formatting/#gradient-fill) أو الخطوط الخارجية. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، أو نشر توهج الشكل، إلخ.

![Shape effect](shape-effect.png)

توفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على شكل.

تبدو بعض تركيبات التأثيرات أفضل من غيرها. لهذا السبب، توفر PowerPoint خيارات تحت **Preset**. خيارات Preset هي تركيبات من اثنين أو أكثر من التأثيرات التي يُعرف أنها تبدو جيدة. بهذه الطريقة، باختيار إعداد مسبق، لن تضطر إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides خصائص وأساليب تحت الفئة [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides for Node.js via Java الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، اتجاهها، مسافتها، ونصف قطر التشويش لتتناسب مع تصميم العرض التقديمي الخاص بك.

### **تطبيق ظل خارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حواف الشكل، مُحدثًا الانطباع بأن الشكل مرتفع فوق الشريحة. عدل لونه، اتجاهه، مسافته، ونصف قطر التشويش ليناسب إضاءة ونمط القالب الخاص بك.

هذا الكود JavaScript يوضح كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) على مستطيل:

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

![Shadow effect](shadow_effect.png)

### **تطبيق ظل داخلي**

عند إعادة إنتاج نمط بصري للقالب، استخدم ظلًا داخليًا لإعطاء بطاقة أو لوحة مظهرًا منغمسًا. الظل الخارجي يمتد خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حواف الشكل.

استدعِ [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)، ثم اضبط الظل الذي تُعيده [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). القيم الأكبر لنصف قطر التشويش تُنتج حوافًا أطرى.

هذا المثال JavaScript ينشئ بطاقة زرقاء فاتحة بظل داخلي رمادي داكن ويحفظه كملف PPTX. اتجاه الظل 225 درجة، مسافته 7 نقاط، ونصف قطر التشويش 6 نقاط:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) على تنسيق تأثير الشكل.

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير انعكاس في Aspose.Slides for Node.js via Java، يمكنك إضافة انعكاس شبيه بالمرآة للأشكال، مع تعديل معلمات مثل المسافة، الشفافية، والحجم. يعزز هذا التأثير جمال عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تنفيذه بشفرة بسيطة، مما يتيح تطبيقًا سريعًا عبر عناصر متعددة لتصميم متسق.

هذا الكود JavaScript يوضح كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) على شكل:

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

![Reflection effect](reflection_effect.png)

## **تطبيق تأثير التوهج**

لتطبيق تأثير توهج على شكل في Aspose.Slides for Node.js via Java، يمكنك إضافة هالة لطيفة ومضيئة حول الأشكال، مع تعديل خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال وإضافة عنصر بصري جذاب إلى العرض التقديمي. إنه سهل التنفيذ باستخدام رمز قليل، مما يحسن المظهر العام للشرائح.

هذا الكود JavaScript يوضح كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) على شكل:

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

![Glow effect](glow_effect.png)

## **تطبيق تأثير الحواف الناعمة**

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for Node.js via Java، يمكنك إنشاء انتقال سلس ومُشوش حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وتفصيلًا، مثاليًا للتصاميم التي تحتاج إلى مظهر هادئ وأقل حدة. يمكنك بسهولة تعديل معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال مختلفة في العرض التقديمي.

هذا الكود JavaScript يوضح كيفية تطبيق [تأثير الحواف الناعمة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) على شكل:

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

![Soft edges effect](soft_edges_effect.png)

## **تطبيق تأثير الضبابية**

استخدم ضبابية الشكل لتنعيم ملء الشكل وخطه الخارجي مع الحفاظ على إمكانية تحرير الشكل. استدعِ [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، حيث تُنتج القيم الأكبر ضبابية أقوى. نصف القطر صفر يترك المظهر دون تغيير.

الإعداد [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) يتحكم في حدود التأثير المرئية. عندما يكون `false`، تُقص الضبابية إلى الحدود المرسومة الأصلية، بما في ذلك الخط الخارجي. عندما يكون `true`، يمكن للضبابية أن تمتد خارج تلك الحدود. لا يغيّر أي من الإعدادين موضع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس الملء، الخط الخارجي، وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

هذا المثال JavaScript ينشئ مستطيلًا برتقاليًا بخط خارجي أزرق داكن، ويطبق ضبابية بـ 5 نقاط، ثم يحدّثها إلى 15 نقطة باستدعاء [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) مرة أخرى. يحفظ كلا الحالتين الضبابيتين، ثم يستدعي [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) ويحفظ الشكل بدون ضبابية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تؤثر ضبابية الشكل على الملء والخط الخارجي معًا. يبهت تأثير الحواف الناعمة حواف الشكل، بينما تلطّف ضبابية الظل الظل فقط. تعمل تأثيرات تحويل الصورة على محتوى الصورة؛ هذا المثال يطبق الضبابية مباشرة على تنسيق تأثير الشكل دون تحويل الشكل إلى صورة.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، الانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على مجموعة متنوعة من الأشكال، بما في ذلك الأشكال المرسومة تلقائيًا، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وأكثر.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.