---
title: تطبيق تأثيرات الشكل في العروض باستخدام Java
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/java/shape-effect/
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعمة
- تنسيق التأثير
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides for Java—أنشئ شرائح جذابة ومهنية خلال ثوانٍ."
---
## **مقدمة**

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [التعبئة](/slides/ar/java/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، إلخ.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يوفر PowerPoint خيارات تحت **Preset**. خيارات Preset هي تركيبات من اثنين أو أكثر من التأثيرات المعروفة بأنها تبدو جيداً. بهذه الطريقة، باختيار إعداد مسبق، لن تضطر إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة جيدة.

توفر Aspose.Slides خصائص وأساليب ضمن الفئة [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

تدعم Aspose.Slides for Java الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص اللون والاتجاه والمسافة ونصف قطر الضبابية لتتناسب مع تصميم عرضك التقديمي.

### **تطبيق ظل خارجي**

استخدم ظلاً خارجياً لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حدود الشكل، مما يخلق انطباع أن الشكل مرتفع فوق الشريحة. اضبط لونه واتجاهه ومسافته ونصف قطر الضبابية لتتناسب مع إضاءة وتنسيق القالب الخاص بك.

يظهر هذا الكود Java كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) على مستطيل:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تأثير الظل](shadow_effect.png)

### **تطبيق ظل داخلي**

عند إعادة إنتاج نمط القالب البصري، استخدم ظلًا داخليًا لمنح بطاقة أو لوحة مظهرًا غائرًا. يمتد الظل الخارجي خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حوافه.

استدعِ [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)، ثم قم بتكوين الظل الذي تُرجعه [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). القيم الأكبر لنصف قطر الضبابية تنتج حوافًا أكثر نعومة.

ينشئ هذا المثال Java بطاقة زرقاء فاتحة بظل داخلي رمادي داكّن ويحفظه كملف PPTX. اتجاه الظل هو 225 درجة، مسافته 7 نقاط، ونصف قطر الضبابية 6 نقاط:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![مستطيل أزرق فاتح بظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) على تنسيق تأثير الشكل.

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides for Java، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، وضبط معلمات مثل المسافة والشفافية والحجم. يعزز هذا التأثير جمالية عروضك التقديمية من خلال إعطاء الأشكال مظهرًا أكثر صقلاً وتطورًا. إنه سهل التنفيذ باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عدة عناصر لضمان تصميم متناسق.

يظهر هذا الكود Java كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) على شكل:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تأثير الانعكاس](reflection_effect.png)

## **تطبيق تأثير التوهج**

لتطبيق تأثير التوهج على شكل في Aspose.Slides for Java، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، وضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا ولافتًا للانتباه إلى عرضك التقديمي. إنه سهل التنفيذ باستخدام كود قليل، مما يعزز المظهر العام لشرائحك.

يظهر هذا الكود Java كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) على شكل:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تأثير التوهج](glow_effect.png)

## **تطبيق تأثير الحواف الناعمة**

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for Java، يمكنك إنشاء انتقال سلس ومُطمَّس حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وتفصيلًا، مثاليًا للتصاميم التي تحتاج إلى مظهر هادئ وناعم. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال مختلفة في عرضك التقديمي.

يظهر هذا الكود Java كيفية تطبيق [تأثير الحواف الناعمة](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) على شكل:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تأثير الحواف الناعمة](soft_edges_effect.png)

## **تطبيق تأثير الضبابية**

استخدم ضبابية الشكل لتليين تعبئة الشكل وحدوده مع الحفاظ على إمكانية تحرير الشكل. استدعِ [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، حيث تنتج القيم الأكبر ضبابية أقوى. نصف القطر صفر يترك المظهر دون تغيير.

تتحكم إعدادات [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) في الحدود المرئية للتأثير. عند `false`، يتم قص الضبابية إلى الحدود المرسومة الأصلية، بما في ذلك الحدود. عند `true`، يمكن للضبابية أن تمتد خارج تلك الحدود. لا يغيّر أي من الإعدادين موضع الشكل أو أبعاده.

تستخدم المقارنة أدناه نفس التعبئة والحدود وأبعاد الشكل في جميع الحالات. الصف الأعلى يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مستطيل أصلي مقارنةً بنصف قطر الضبابية 5 و15 نقطة، مع تعطيل وتمكين النمو](shape_blur_comparison.png)

ينشئ هذا المثال Java مستطيلًا برتقاليًا بحدود زرقاء داكنة، يطبق ضبابية 5 نقاط، ثم يحدّثها إلى ضبابية 15 نقطة عن طريق استدعاء [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) مرة أخرى. يحفظ كلا الحالتين الضبابيتين، ثم يستدعي [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) ويحفظ الشكل بدون ضبابية.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تؤثر ضبابية الشكل على التعبئة والحدود معًا. يخفف تأثير الحواف الناعمة حواف الشكل، بينما تُلين ضبابية الظل الظل فقط. تعمل تأثيرات تحويل الصورة على محتوى الصورة؛ يطبق هذا المثال الضبابية مباشرة على تنسيق تأثير الشكل دون تحويل الشكل إلى صورة.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل والانعكاس والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال مختلفة، بما في ذلك الأشكال المرسومة تلقائيًا، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وأكثر.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.