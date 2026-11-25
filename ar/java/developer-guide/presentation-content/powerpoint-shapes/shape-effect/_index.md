---
title: تطبيق تأثيرات الشكل في العروض التقديمية باستخدام Java
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
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides for Java — أنشئ شرائح جذابة ومهنية في ثوانٍ."
---
## **المقدمة**

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل بارزًا، فإنها تختلف عن [الملء](/slides/ar/java/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، وتمديد توهج الشكل، وغيرها.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يوفر PowerPoint خيارات تحت **الإعداد المسبق**. خيارات الإعداد المسبق هي تركيبات من تأثيرين أو أكثر تُعرف بأنها تبدو جيدة. بهذه الطريقة، باختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides خصائص وأساليب تحت الفئة [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides for Java الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، اتجاهها، مسافتها، ونصف قطر الضبابية لتتناسب مع تصميم عرضك.

### **تطبيق ظل خارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة بارزة مقابل خلفية الشريحة. يمتد الظل خارج حدود الشكل، مما يخلق الانطباع بأن الشكل مرتفع فوق الشريحة. عدّل لونه، اتجاهه، مسافته، ونصف قطر الضبابية ليتناسب مع الإضاءة وتنسيق القالب.

يعرض هذا الكود Java كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) على مستطيل:

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

عند إعادة إنتاج نمط القالب البصري، استخدم ظلًا داخليًا لإعطاء البطاقة أو اللوحة مظهرًا متراجعًا. يمتد الظل الخارجي خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حواف الشكل.

استدعِ [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)، ثم قم بتكوين الظل الذي تُعيده [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). قيم نصف القطر الضبابية الأكبر تُنتج حوافًا أكثر نعومة.

يُنشئ هذا المثال Java بطاقة زرقاء فاتحة مع ظل داخلي رمادي داكن ويحفظها كملف PPTX. اتجاه الظل 225 درجة، مسافته 7 نقاط، ونصف قطر الضبابية 6 نقاط:

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

### **تطبيق، تعديل، وإزالة ظل إعداد مسبق**

استدعِ [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) واستخدم [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) لاختيار [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/). لتبديل الأنماط، غيّر الإعداد المسبق على نفس الشكل. استدعِ [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) لإزالة الظل مع الحفاظ على الملء والحد.

يعرض هذا المثال أربع مراحل جنبًا إلى جنب على شريحة واحدة. كلا الظلين يُزاحان بمقدار 10 نقاط. اتجاه 225° يضع الظل الأول أعلى ويسار المستطيل، و45° يضع الظل الثاني أسفل ويسار.

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
| ![بدون ظل](preset_shadow_original.png) | ![ظل إسقاط أعلى يسار](preset_shadow_top_left.png) | ![ظل إسقاط أسفل يمين](preset_shadow_bottom_right.png) | ![بدون ظل بعد الإزالة](preset_shadow_removed.png) |

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides for Java، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، وضبط معلمات مثل المسافة، الشفافية، والحجم. يُحسن هذا التأثير من جمالية عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تنفيذه باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عناصر متعددة لتصميم متسق.

يوضح هذا الكود Java كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) على شكل:

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

لتطبيق تأثير التوهج على شكل في Aspose.Slides for Java، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، وضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إظهار الأشكال وإضافة عنصر بصري جذاب ولافت للانتباه إلى عرضك. من السهل تنفيذه بكود قليل، مما يحسن المظهر العام لشرائحك.

يوضح هذا الكود Java كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) على شكل:

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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for Java، يمكنك إنشاء انتقال ناعم ومموه حول حواف الشكل. يُضيف هذا التأثير مظهرًا أكثر رقة وتفصيلًا، وهو مثالي للتصاميم التي تحتاج إلى مظهر هادئ وأكثر نعومة. يمكنك ضبط المعلمات مثل نصف القطر بسهولة لتحقيق التأثير المطلوب عبر أشكال مختلفة في عرضك.

يُظهر هذا الكود Java كيفية تطبيق [تأثير الحواف الناعمة](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) على شكل:

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

استخدم ضبابية الشكل لتنعيم ملء الشكل وحدوده مع الحفاظ على إمكانية تحرير الشكل. استدعِ [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، حيث تُنتج القيم الأكبر ضبابية أقوى. نصف القطر صفر يترك المظهر دون تغيير.

تتحكم إعدادات [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) في الحدود المرئية للتأثير. عند `false`، تُقَص الضبابية إلى الحدود المرسومة الأصلية، بما في ذلك الحدود. عند `true`، يمكن أن تمتد الضبابية إلى ما وراء تلك الحدود. لا يغيّر أي من الإعدادين موضع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس الملء، الحدود، وأبعاد الشكل في جميع الحالات. الصف الأعلى يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مستطيل أصلي مقارنة بأقطار ضبابية 5 و15 نقطة، مع تمكين وتعطيل النمو](shape_blur_comparison.png)

يُنشئ هذا المثال Java مستطيلًا برتقاليًا مع حدود زرقاء داكنة، يُطبق ضبابية 5 نقاط، ثم يُحدّثها إلى ضبابية 15 نقطة عن طريق استدعاء [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) مرة أخرى. يحفظ كلا الحالتين الضبابيتين، ثم يستدعي [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) ويحفظ الشكل دون ضبابية.

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

تؤثر ضبابية الشكل على الملء والحدود معًا. يُبهت تأثير الحواف الناعمة حواف الشكل، بينما تُنعم ضبابية الظل الظل فقط. تعمل تأثيرات تحويل الصور على محتوى الصورة؛ يطبق هذا المثال الضبابية مباشرةً على تنسيق تأثير الشكل دون تحويله إلى صورة.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق تأثيرات متعددة على الشكل نفسه؟**  
نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل والانعكاس والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**  
يمكنك تطبيق التأثيرات على أشكال مختلفة، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وغيرها.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**  
نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.