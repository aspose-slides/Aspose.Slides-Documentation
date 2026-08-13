---
title: إنشاء وتطبيق تأثيرات WordArt على Android
linktitle: WordArt
type: docs
weight: 110
url: /ar/androidjava/wordart/
keywords:
- WordArt
- إنشاء WordArt
- قالب WordArt
- تأثير WordArt
- تأثير الظل
- تأثير العرض
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides لنظام Android. يساعد هذا الدليل خطوة بخطوة المطورين على تحسين العروض التقديمية بنص احترافي في Java."
---
## **نظرة عامة**

تسمح تأثيرات WordArt لك بإضافة نصٍ مصمم بصريًا وجذاب إلى عروض PowerPoint التقديمية. مع Aspose.Slides، يمكن للمطورين إنشاء WordArt وتخصيصه وإدارته برمجياً تمامًا كما هو في Microsoft PowerPoint—دون الحاجة إلى تثبيت Office. يقدم هذا المقال نظرة عامة على العمل مع WordArt، بما في ذلك كيفية تطبيق تحولات النص، وأنماط التعبئة، والحدود، والظلال، وخيارات التنسيق الأخرى لجعل محتوى العرض أكثر تعبيرًا وجاذبية. يتيح WordArt لك معاملة النص ككائن رسومي. وهو يتكون من تأثيرات أو تعديلات خاصة تُطبّق على النص لجعله أكثر جاذبية أو بروزًا.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

**استخدام Aspose.Slides** 

أولاً، نقوم بإنشاء نص بسيط باستخدام هذا الكود Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الكود:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**استخدام Microsoft PowerPoint**

اذهب إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير WordArt معرف مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات WordArt جديد.

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**استخدام Aspose.Slides**

هنا، نطبق لون نمط [SmallGrid](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/PatternStyle#SmallGrid) على النص ونضيف حدًا نصيًا أسود بعرض 1 باستخدام هذا الكود:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}

```

النص الناتج:

![todo:image_alt_text](image-20200930114108-4.png)

## **تطبيق تأثيرات WordArt أخرى**

**استخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص أو كتلة نص أو شكل أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، والانعكاس، والتوهج على النص؛ ويمكن تطبيق تنسيقات 3D وتدوير 3D على كتلة النص؛ ويمكن تطبيق خاصية الحواف الناعمة على كائن الشكل (تظل لها تأثير حتى عندما لا يتم تعيين خاصية تنسيق 3D).

### **تطبيق تأثيرات الظل**

هنا نُعنى بتعيين الخصائص المتعلقة بالنص فقط. نطبق تأثير الظل على النص باستخدام هذا الكود في Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

يدعم Aspose.Slides API ثلاثة أنواع من الظلال: OuterShadow و InnerShadow و PresetShadow.

مع PresetShadow، يمكنك تطبيق ظل للنص (باستخدام قيم مُحددة مسبقًا).

**استخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثالًا:

![todo:image_alt_text](image-20200930114225-6.png)

**استخدام Aspose.Slides**

يسمح لك Aspose.Slides فعليًا بتطبيق نوعين من الظلال معًا: InnerShadow و PresetShadow.

**ملاحظات:**

- عندما يتم استخدام OuterShadow و PresetShadow معًا، يتم تطبيق تأثير OuterShadow فقط.  
- إذا تم استخدام OuterShadow و InnerShadow في آنٍ واحد، يعتمد التأثير الناتج أو المطبق على نسخة PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يتم تطبيق تأثير OuterShadow.

### **تطبيق تأثيرات الانعكاس على النص**

نضيف عرضًا إلى النص من خلال عينة الكود هذه في Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
    if (pres != null) pres.dispose();
}
```

### **تطبيق تأثيرات التوهج على النص**

نطبق تأثير التوهج على النص لجعله يلمع أو يبرز باستخدام هذا الكود:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

يمكنك تغيير معلمات الظل، والعرض، والتوهج. يتم تعيين خصائص التأثيرات على كل جزء من النص بشكل منفصل. 

{{% /alert %}} 

### **استخدام التحولات في WordArt**

نستخدم الخاصية Transform (الموروثة على كتلة النص بالكامل) عبر هذا الكود:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

يوفر كل من Microsoft PowerPoint و Aspose.Slides for Android عبر Java عددًا معينًا من أنواع التحولات المعرفة مسبقًا. 

{{% /alert %}} 

**استخدام PowerPoint**

للوصول إلى أنواع التحولات المحددة مسبقًا، انتقل عبر: **Format** -> **TextEffect** -> **Transform**

**استخدام Aspose.Slides**

لاختيار نوع التحول، استخدم التعداد TextShapeType.

### **تطبيق تأثيرات 3D على النص والأشكال**

نضبط تأثير 3D على شكل نص باستخدام عينة الكود هذه:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

النص الناتج وشكله:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثير 3D على النص بهذا الكود Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

نتيجة العملية:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

تطبيق تأثيرات 3D على النصوص أو أشكالها وتداخل التأثيرات يعتمد على قواعد معينة.  

اعتبر مشهدًا للنص والشكل الذي يحتوي النص. يحتوي تأثير 3D على تمثيل كائن ثلاثي الأبعاد والمشهد الذي يوضع فيه الكائن.  

- عندما يتم تعيين المشهد لكل من الشكل والنص، يحصل المشهد الخاص بالشكل على أولوية أعلى—ويُهمل مشهد النص.  
- عندما يفتقر الشكل إلى مشهد خاص به لكنه يحتوي على تمثيل 3D، يُستخدم مشهد النص.  
- وإلا—عند عدم وجود تأثير 3D أصلاً على الشكل—يظل الشكل مسطحًا ويتم تطبيق تأثير 3D فقط على النص.  

هذه الوصوف مرتبطة بالطريقتين ThreeDFormat.getLightRig() و ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النص**
توفر Aspose.Slides for Android عبر Java الفئتين [**IOuterShadow**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioutershadow/) و [**IInnerShadow**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinnershadow/) اللتين تسمحان لك بتطبيق تأثيرات الظل على نص محمول بواسطة [TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframe/). اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).  
2. الحصول على مرجع الشريحة باستخدام فهرسها.  
3. إضافة AutoShape من نوع Rectangle إلى الشريحة.  
4. الوصول إلى TextFrame المرتبط بـ AutoShape.  
5. ضبط FillType للـ AutoShape إلى NoFill.  
6. إنشاء مثال من الفئة OuterShadow.  
7. تعيين BlurRadius للظل.  
8. تعيين Direction للظل.  
9. تعيين Distance للظل.  
10. تعيين RectangleAlign إلى TopLeft.  
11. تعيين PresetColor للظل إلى Black.  
12. كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  

يعرض لك هذا الكود التجريبي في Java—تنفيذ للخطوات أعلاه—كيفية تطبيق تأثير الظل الخارجي على نص:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع المستطيل
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");

    // تعطيل تعبئة الشكل في حالة رغبتنا في الحصول على ظل النص
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // إضافة ظل خارجي وتعيين جميع المعلمات الضرورية
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // حفظ العرض على القرص
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).  
2. الحصول على مرجع الشريحة.  
3. إضافة AutoShape من نوع Rectangle.  
4. تمكين InnerShadowEffect.  
5. تعيين جميع المعلمات الضرورية.  
6. تعيين ColorType إلى Scheme.  
7. تعيين لون المخطط (Scheme Color).  
8. كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  

يعرض لك هذا الكود التجريبي (المستند إلى الخطوات أعلاه) كيفية تطبيق تأثير الظل الداخلي على نص في Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع المستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // تمكين تأثير الظل الداخلي
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // تعيين جميع المعلمات الضرورية
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // تعيين ColorType كـ Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // تعيين لون المخطط
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // حفظ العرض
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة المتكررة**

### هل يمكنني استخدام تأثيرات WordArt مع خطوط أو سكريبتات مختلفة (مثل العربية أو الصينية)؟

نعم، يدعم Aspose.Slides Unicode ويعمل مع جميع الخطوط والسكريبتات الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل والتعبئة والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

### هل يمكنني تطبيق تأثيرات WordArt على عناصر ماستر الشريحة؟

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في ماستر الشريحة، بما في ذلك عناصر العنونة، وتذييل الصفحات، أو النص الخلفي. ستنعكس التغييرات التي تُجرى على تخطيط الماستر على جميع الشرائح المرتبطة.

### هل تؤثر تأثيرات WordArt على حجم ملف العرض؟

قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، والتوهج، وتعبئات التدرج من حجم الملف قليلاً بسبب إضافة بيانات تنسيق، لكن الفرق عادةً ما يكون ضئيلًا.

### هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟

نعم، يمكنك تحويل الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `getImage` من واجهات [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) أو [ISlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/). هذا يتيح لك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.