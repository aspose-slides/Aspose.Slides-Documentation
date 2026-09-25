---
title: إنشاء وتطبيق تأثيرات WordArt في Java
linktitle: WordArt
type: docs
weight: 110
url: /ar/java/wordart/
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
- Java
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides for Java. يساعد هذا الدليل خطوة بخطوة المطورين على تحسين العروض التقديمية بنص احترافي في Java."
---
## **نظرة عامة**

تتيح تأثيرات WordArt لك تنسيق النص بملء، حدود، ظلال، انعكاسات، توهج، تحولات، وتنسيق ثلاثي الأبعاد. يوضح هذا المقال كيفية إنشاء هذه التأثيرات وتخصيصها في عروض PowerPoint باستخدام Aspose.Slides for Java، دون الحاجة إلى تثبيت Microsoft Office.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

الأمثلة التالية تنشئ نمط WordArt بسيط عن طريق تعيين النص، الخط، ملء النمط، والحد.

كل مثال ينشئ عرضًا تقديميًا جديدًا ويضيف مستطيلًا إلى شريحته الأولى؛ لا يلزم ملف إدخال. المثال الأول يحدد النص إلى "Aspose.Slides". يتم قياس موضع الشكل وأبعاده بوحدات النقاط:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

تعيين الخط إلى Arial Black بحجم 36 نقطة لجعل التنسيق أكثر وضوحًا:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

تطبيق نمط [SmallGrid](https://reference.aspose.com/slides/ar/java/com.aspose.slides/patternstyle/#SmallGrid) بامام برتقالي غامق وخلفية بيضاء، ثم إضافة حد نص أسود بسمك نقطة واحدة:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

النص الناتج:

![قالب WordArt البسيط](WordArt_template.png)

## **تطبيق تأثيرات WordArt أخرى**

توضح الأمثلة التالية كيفية تطبيق الظلال، الانعكاسات، التوهج، التحولات، وتأثيرات ثلاثية الأبعاد على النص.

### **تطبيق تأثيرات الظل الخارجي**

يضيف الظل الخارجي عمقًا بوضع ظل خلف النص. يمكنك تخصيص لونه، اتجاهه، مسافته، نصف قطر الضباب، المقياس، والالتواء.

هذا المثال يستدعي [enableOuterShadowEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) ويضبط ظلًا أسودً بنصف قطر ضباب 4 نقاط، اتجاه 230 درجة، ومسافة 30 نقطة. قيم المقياس 100 تحافظ على حجم الظل، بينما يميل الالتواء الأفقي 20 درجة. تحويل ألفا يضبط الشفافية إلى 32%:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تأثير الظل الخارجي](outer_shadow_effect.png)

{{% alert color="info" title="ملاحظة" %}}
- عند استخدام الظلال الخارجية والظلال المسبقة معًا، يُطبق الظل الخارجي فقط.
- إذا استُُخدم الظلال الخارجية والداخلية في آنٍ واحد، يعتمد التأثير الناتج على نسخة PowerPoint. على سبيل المثال، في PowerPoint 2013 يُضاعف التأثير، في حين في PowerPoint 2007 يُطبق الظل الخارجي فقط.
{{% /alert %}}

### **تطبيق تأثيرات الانعكاس**

يُنشئ الانعكاس نسخةً مرآةً من النص. اضبط موضعه، مقياسه، ضبابه، وشفافيته للتحكم في مظهره.

هذا المثال يستدعي [enableReflectionEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effectformat/#enableReflectionEffect--) ويقلب الانعكاس عموديًا بمقياس -100٪. يستخدم نصف قطر ضباب 0.5 نقطة ومسافة 4.72 نقطة. تتناقص الشفافية من 60٪ إلى 0.9٪ بين الموضعين 0٪ و60٪ على طول الانعكاس:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تأثير الانعكاس](reflection_effect.png)

### **تطبيق تأثيرات التوهج**

يضيف التوهج حدودًا ملونة ناعمة حول النص. اضبط لونه، شفافيته، ونصف قطره للتحكم في التأثير.

هذا المثال يستدعي [enableGlowEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effectformat/#enableGlowEffect--) ويطبق توهجًا أحمر بشفافية 54٪ ونصف قطر 7 نقاط:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تأثير التوهج](glow_effect.png)

### **تطبيق تحولات WordArt**

تحولات WordArt تنحني أو تمدد أو تشوه كتلة النص.

اضبط [setTransform](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframeformat/#setTransform-int-) إلى [ArchUpPour](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textshapetype/#ArchUpPour) لتقويس إطار النص بالكامل إلى الأعلى:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تحول WordArt](transform_effect.png)

{{% alert color="info" title="ملاحظة" %}}
توفر Aspose.Slides for Java مجموعة من [أنواع التحول المسبقة التعريف](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص**

يمكنك تطبيق تأثيرات ثلاثية الأبعاد على شكل أو على نصه. التحكم في الزوايا، البثق، الإضاءة، وإعدادات الكاميرا يحدد المظهر النهائي.

يستخدم المثال التالي [ThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/threedformat/) لإضافة حواف دائرية، بريق برتقالي، وتحديد داكن للخط الأحمر إلى المستطيل. تُقاس أبعاد الحافة، ارتفاع البثق، عرض التحديد، والعمق بوحدات النقاط. يحدد مادة بلاستيكية، إضاءة متوازنة تدور 40 درجة حول المحور Z، وكاميرا منظور المظهر:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

الشكل الناتج:

![تأثير الشكل ثلاثي الأبعاد](shape_3D_effect.png)

يطبق هذا المثال تنسيقًا ثلاثيًا أبعادًا مماثلًا على النص عبر [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframeformat/#getThreeDFormat--). تشكل الحواف الصغيرة حواف الأحرف، بينما يمنح البثق والإضاءة النص عمقًا:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

النص الناتج:

![تأثير النص ثلاثي الأبعاد](text_3D_effect.png)

{{% alert color="info" title="ملاحظة" %}}
تحكم قواعد محددة تطبيق تأثيرات ثلاثية الأبعاد على النص أو أشكاله وتفاعل هذه التأثيرات. تصور مشهدًا يضم النص والشكل المحتوي عليه. يتضمن تأثير ثلاثي الأبعاد تمثيل كائن ثلاثي الأبعاد والمشهد الذي يوضع فيه.

- إذا تم تعيين مشهد لكل من الشكل والنص، يُعطى أولوية لمشهد الشكل ويُهمل مشهد النص.
- إذا كان الشكل لا يملك مشهدًا خاصًا ولكنه يحتوي على تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص.
- إذا لم يكن لدى الشكل أي تأثير ثلاثي الأبعاد، يُعامل كمسطح، ويُطبق التأثير ثلاثي الأبعاد فقط على النص.

تتعلق هذه السلوكيات بطريقتي [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ar/java/com.aspose.slides/threedformat/#getLightRig--) و [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/java/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

للحفاظ على النص مسطحًا وقابلًا للقراءة مع الحفاظ على تنسيق الشكل الثلاثي الأبعاد، راجع [Keep Text Flat on a 3D Shape](/slides/ar/java/3d-presentation/) للحصول على مقارنة بين الإعدادين ومثال Java كامل.

## **الأسئلة المتكررة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو لغات مختلفة (مثل العربية أو الصينية)؟**

نعم، يدعم Aspose.Slides for Java Unicode ويعمل مع جميع الخطوط واللغات الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر القالب الرئيسي للشرائح؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في القوالب الرئيسية، بما في ذلك عناصر النواصب، التذييلات، أو النص الخلفي. ستنعكس التغييرات التي تجريها على القالب على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، والتعبئات المتدرجة حجم الملف قليلاً بسبب بيانات التنسيق الإضافية، لكن الفرق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تحويل الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام [ISlide.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage--)، أو تحويل الأشكال الفردية باستخدام [IShape.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getImage--). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض الكامل.