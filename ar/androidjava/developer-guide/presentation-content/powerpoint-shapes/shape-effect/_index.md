---
title: تطبيق تأثيرات الأشكال في العروض التقديمية على Android
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/androidjava/shape-effect/
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعمة
- تنسيق التأثير
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides لـ Android باستخدام Java — أنشئ شرائح جذابة واحترافية في ثوانٍ."
---
## **مقدمة**

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فهي تختلف عن [التعبئات](/slides/ar/androidjava/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، وما إلى ذلك.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يقدم PowerPoint خيارات تحت **Preset**. خيارات Preset هي تركيبات من تأثيرين أو أكثر معروفة بأنها تبدو جيدة. بهذه الطريقة، باختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides خصائص وطرق تحت فئة [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides لـ Android عبر Java الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، اتجاهها، مسافتها، ونصف قطر الضبابية لتتناسب مع تصميم عرضك.

### **تطبيق ظل خارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حواف الشكل، مما يعطي الانطباع بأن الشكل مرتفع فوق الشريحة. اضبط لونه، اتجاهه، مسافته، ونصف قطر الضبابية لتتناسب مع الإضاءة وتنسيق قالبك.

هذا الكود Java يوضح كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) على مستطيل:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تأثير الظل](shadow_effect.png)

### **تطبيق ظل داخلي**

عند إعادة إنتاج نمط القالب البصري، استخدم ظلًا داخليًا لإعطاء بطاقة أو لوحة مظهرًا مغمورًا. يمتد الظل الخارجي خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حواف الشكل.

استدعِ [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--)، ثم ضبط الظلال التي تُرجعها [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). القيم الأكبر لنصف قطر الضبابية تنتج حوافًا أكثر نعومة.

هذا المثال Java ينشئ بطاقة زرقاء فاتحة بظل داخلي رمادي داكن ويحفظها كملف PPTX. اتجاه الظل 225 درجة، مسافته 7 نقاط، ونصف قطر الضبابية 6 نقاط:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![مستطيل أزرق فاتح مع ظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) على تنسيق تأثير الشكل.

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides لـ Android عبر Java، يمكنك إضافة انعكاس شبه مرآة إلى الأشكال، مع تعديل معلمات مثل المسافة، الشفافية، والحجم. يعزز هذا التأثير جمالية عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تنفيذه بكتابة كود بسيط، مما يتيح تطبيقه بسرعة عبر عناصر متعددة لتصميم متسق.

هذا الكود Java يوضح كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) على شكل:

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

لتطبيق تأثير التوهج على شكل في Aspose.Slides لـ Android عبر Java، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع تعديل خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا إلى عرضك. من السهل تنفيذه بكود قليل، مما يحسن المظهر العام لشرائحك.

هذا الكود Java يوضح كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) على شكل:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides لـ Android عبر Java، يمكنك إنشاء انتقال سلس وممزوج حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وهدوءًا، وهو مثالي للتصاميم التي تحتاج إلى مظهر ناعم. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال مختلفة في عرضك.

هذا الكود Java يوضح كيفية تطبيق [تأثير الحواف الناعمة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) على شكل:

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

استخدم ضبابية الشكل لتنعيم تعبئة الشكل وحدوده مع الحفاظ على إمكانية تحرير الشكل. استدعِ [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، فالقيم الأكبر تنتج ضبابية أقوى. نصف القطر صفر يترك المظهر دون تغيير.

إعداد [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) يتحكم في حدود التأثير المرئية. عند `false`، يتم قص الضبابية إلى الحدود المرسومة الأصلية، بما في ذلك الحدود. عند `true`، يمكن للضبابية أن تمتد خارج تلك الحدود. لا يغيّر أي من الإعدادين موضع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس التعبئة والحدود وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مستطيل أصلي مقارنة مع أنصاف أقطار الضبابية 5 و15 نقطة، مع تعطيل وتمكين النمو](shape_blur_comparison.png)

هذا المثال Java ينشئ مستطيلًا برتقاليًا بحدود زرقاء داكنة، يطبق ضبابية 5 نقاط، ثم يحدّثها إلى ضبابية 15 نقطة عبر استدعاء [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) مرة أخرى. يحفظ الحالتين الضبابيتين، ثم يستدعي [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) ويحفظ الشكل دون ضبابية.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

تؤثر ضبابية الشكل على التعبئة والحدود معًا. يخفّف تأثير الحواف الناعمة حواف الشكل، بينما ينعّم ضباب الظل الظل فقط. تعمل تأثيرات تحويل الصورة على محتوى الصورة؛ هذا المثال يطبق الضبابية مباشرة على تنسيق تأثير الشكل دون تحويله إلى صورة.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، الانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال متنوعة، بما فيها الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وغير ذلك.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعّة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعّة. سيُطبق التأثير على المجموعة بأكملها.