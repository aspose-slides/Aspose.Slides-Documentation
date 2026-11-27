---
title: تطبيق تأثيرات الأشكال في العروض التقديمية باستخدام Java
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
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الأشكال المتقدمة مع Aspose.Slides for Java — أنشئ شرائح جذابة ومهنية في ثوانٍ."
---
## **مقدمة**

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [التعبئة](/slides/ar/java/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، أو نشر توهج الشكل، وما إلى ذلك.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يوفر PowerPoint خيارات تحت **Preset**. خيارات Preset هي تركيبات من اثنين أو أكثر من التأثيرات المعروفة بأنها تبدو جيدة. بهذه الطريقة، عند اختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

يوفر Aspose.Slides خصائص وأساليب تحت فئة [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides for Java الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، واتجاهها، والمسافة، ونصف قطر الضباب لتحقيق توافق مع تصميم العرض التقديمي.

### **تطبيق ظل خارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة تبرز أمام خلفية الشريحة. يمتد الظل خارج حدود الشكل، ما يُعطي الانطباع بأن الشكل مرتفع فوق الشريحة. عدّل لونه، واتجاهه، ومسافته، ونصف قطر الضباب ليتماشى مع الإضاءة وتنسيق القالب الخاص بك.

يظهر هذا الكود بلغة Java كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) على مستطيل:

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

#### **التحكم في اتجاه الظل عند دوران الشكل**

افتراضيًا، يدور الظل الخارجي مع الشكل. لجعل الأشكال ذات الدورانات المختلفة تبدو مضاءة من نفس الاتجاه، استدعِ [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) مع `false` واستخدم [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-) لإعطاء الظلال نفس الاتجاه.

إن المثال ينشئ سهمين أزرقين بظلال رمادية إزاحة 42 نقطة إلى اليمين (0°). ثم يكرر الشريحة ويدور السهمين 90° باتجاه عقارب الساعة.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في الشريحة الثانية، يرسم السهم الأيسر ظله للأسفل، بينما يظل ظلال السهم الأيمن إلى اليمين. يبقى الاتجاه المحدد 0° لكلا الظلين.

![عرض PowerPoint قبل وبعد تدوير 90°. كلا الظلين يبدأان على اليمين. بعد التدوير، يتحرك الظل أسفل السهم الأيسر ويبقى إلى يمين السهم الأيمن.](arrow-shadow-rotation.png)

### **تطبيق ظل داخلي**

عند إعادة إنشاء نمط بصري للقالب، استخدم الظل الداخلي لإعطاء البطاقة أو اللوحة مظهرًا مغمورًا. يمد الظل الخارجي خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حواف الشكل.

استدعِ [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)، ثم اضبط الظل الذي يُرجعها [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). قيم نصف قطر الضباب الأكبر تنتج حوافًا أكثر نعومة.

هذا المثال بلغة Java ينشئ بطاقة زرقاء فاتحة بظل داخلي رمادي داكن ويحفظها كملف PPTX. اتجاه الظل 225 درجة، والمسافة 7 نقاط، ونصف قطر الضباب 6 نقاط:

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

![مستطيل أزرق فاتح مع ظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) على تنسيق تأثير الشكل.

### **تطبيق وتغيير وإزالة ظل مسبق**

استدعِ [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) واستخدم [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) لتحديد [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/). لتبديل الأنماط، غيّر الإعداد المسبق على نفس الشكل. استدعِ [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) لإزالة الظل مع الحفاظ على التعبئة والحدود.

يظهر هذا المثال أربع مراحل جنبًا إلى جنب على شريحة واحدة. كلا الظلين إزاحة 10 نقاط. اتجاه 225° يضع الظل الأول أعلى ويسار المستطيل، و45° يضع الظل الثاني أسفل ويمين المستطيل.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| الأصل | الإعداد المسبق الأول | الإعداد المسبق الثاني | بعد الإزالة |
| :---: | :---: | :---: | :---: |
| ![بدون ظل](preset_shadow_original.png) | ![ظل أسقط أعلى اليسار](preset_shadow_top_left.png) | ![ظل أسقط أسفل اليمين](preset_shadow_bottom_right.png) | ![بدون ظل بعد الإزالة](preset_shadow_removed.png) |

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير انعكاس في Aspose.Slides for Java، يمكنك إضافة انعكاس يشبه المرآة إلى الأشكال، مع ضبط معلمات مثل المسافة، الشفافية، والحجم. يُحسّن هذا التأثير مظهر عروضك التقديمية بإعطاء الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تنفيذه بكود بسيط، مما يتيح تطبيقًا سريعًا عبر عناصر متعددة لتصميم موحد.

يظهر هذا الكود بلغة Java كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) على شكل:

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

لتطبيق تأثير التوهج على شكل في Aspose.Slides for Java، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع ضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال وإضفاء عنصر بصري جذاب على العرض التقديمي. من السهل تنفيذه بكود قليل، مما يعزز المظهر العام للشرائح.

يظهر هذا الكود بلغة Java كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) على شكل:

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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for Java، يمكنك إنشاء انتقال سلس ومطمس حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة و refinement، وهو مثالي للتصاميم التي تحتاج إلى مظهر ناعم. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال متعددة في العرض التقديمي.

يظهر هذا الكود بلغة Java كيفية تطبيق [تأثير الحواف الناعمة](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) على شكل:

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

استخدم ضبابية الشكل لتنعيم تعبئة الشكل وحدوده مع الحفاظ على إمكانية تحرير الشكل. استدعِ [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، فالقيم الأكبر تنتج ضبابية أقوى. نصف القطر صفر يترك المظهر دون تغيير.

إعداد [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) يتحكم في الحدود المرئية للتأثير. مع `false`، تُقَص الضبابية على حدود الرسم الأصلية، بما في ذلك الحد. مع `true`، يمكن للضبابية أن تمتد خارج تلك الحدود. لا يغيّر أي من الإعدادين موقع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس التعبئة والحدود وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مستطيل أصلي مقارنةً مع أقطار ضبابية 5 و15 نقطة، مع تعطيل وتمكين النمو](shape_blur_comparison.png)

هذا المثال بلغة Java ينشئ مستطيلًا برتقاليًا بحد أزرق داكن، يطبق ضبابية 5 نقاط، ثم يحدّثه إلى ضبابية 15 نقطة باستدعاء [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) مرة أخرى. يحفظ كلا الحالتين الضبابيتين، ثم يستدعي [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) ويحفظ الشكل بدون ضبابية.

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

تؤثر ضبابية الشكل على التعبئة والحدود معًا. يُبهت تأثير الحواف الناعمة حواف الشكل، بينما ينعّم ضباب الظل الظل فقط. تعمل تأثيرات تحويل الصور على محتوى الصورة؛ يطبق هذا المثال الضبابية مباشرةً على تنسيق تأثير الشكل دون تحويله إلى صورة.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، والانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر حيوية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على مجموعة متنوعة من الأشكال، بما في ذلك الأشكال التلقائية، والمخططات، والجداول، والصور، وكائنات SmartArt، وكائنات OLE، وغيرها.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمَّعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمَّعة. سيُطبق التأثير على المجموعة بأكملها.