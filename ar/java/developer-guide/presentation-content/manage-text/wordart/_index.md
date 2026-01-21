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
- تأثير العرض
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides لـ Java. يساعد هذا الدليل خطوة بخطوة المطورين على تحسين العروض التقديمية بنص احترافي في Java."
---

## **حول WordArt؟**
WordArt أو Word Art هي ميزة تسمح لك بتطبيق تأثيرات على النصوص لجعلها بارزة. مع WordArt، على سبيل المثال، يمكنك تحديد حدود للنص أو ملئه بلون (أو تدرج)، إضافة تأثيرات ثلاثية الأبعاد، إلخ. يمكنك أيضاً إمالة النص، انحنائه، وتمديد شكله.

{{% alert color="primary" %}} 
WordArt يتيح لك معالجة النص كما لو كان كائنًا رسوميًا. بشكل عام، يتكون WordArt من تأثيرات أو تعديلات خاصة تُجرى على النصوص لجعلها أكثر جاذبية أو وضوحًا. 
{{% /alert %}} 

**WordArt في Microsoft PowerPoint**

لاستخدام WordArt في Microsoft PowerPoint، عليك اختيار أحد قوالب WordArt المعرفة مسبقًا. قالب WordArt هو مجموعة من التأثيرات التي تُطبق على النص أو شكله. 

**WordArt في Aspose.Slides**

في Aspose.Slides for Java 20.10، قمنا بتنفيذ دعم لـ WordArt وأجرينا تحسينات على الميزة في إصدارات Aspose.Slides for Java اللاحقة. 

مع Aspose.Slides for Java، يمكنك بسهولة إنشاء قالب WordArt الخاص بك (تأثير واحد أو مجموعة من التأثيرات) في Java وتطبيقه على النصوص. 

## **إنشاء قالب WordArt بسيط وتطبيقه على نص**
**باستخدام Aspose.Slides** 

أولاً، ننشئ نصًا بسيطًا باستخدام كود Java التالي: 
``` java
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

الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير واضحًا أكثر من خلال هذا الكود:
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**باستخدام Microsoft PowerPoint**

انتقل إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير WordArt معرف مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات WordArt جديد. 

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نطبق نمط اللون [SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid) على النص ونضيف حدًا أسود بعرض 1 باستخدام هذا الكود:
``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```


النص الناتج:

![todo:image_alt_text](image-20200930114108-4.png)

## **تطبيق تأثيرات WordArt أخرى**
**باستخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص أو كتلة نص أو شكل أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على نص؛ تأثيرات تنسيق ثلاثي الأبعاد وتدوير ثلاثي الأبعاد يمكن تطبيقها على كتلة نص؛ خاصية الحواف الناعمة يمكن تطبيقها على كائن الشكل (تظل لها تأثير حتى إذا لم يتم تعيين خاصية تنسيق ثلاثي الأبعاد). 

### **تطبيق تأثيرات الظل**
هنا، ننوي ضبط الخصائص المتعلقة بنص فقط. نطبق تأثير الظل على نص باستخدام هذا الكود في Java:
``` java
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
```


يدعم Aspose.Slides API ثلاثة أنواع من الظلال: OuterShadow، InnerShadow، وPresetShadow. 

مع PresetShadow، يمكنك تطبيق ظل على نص (باستخدام قيم مسبقة). 

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثالاً:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

يسمح Aspose.Slides فعليًا لك بتطبيق نوعين من الظلال في نفس الوقت: InnerShadow وPresetShadow.

**ملاحظات:**
- عندما يُستخدم OuterShadow وPresetShadow معًا، يُطبق فقط تأثير OuterShadow. 
- إذا تم استخدام OuterShadow وInnerShadow معًا، يعتمد التأثير الناتج أو المطبق على نسخة PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير. لكن في PowerPoint 2007، يُطبق تأثير OuterShadow. 

### **تطبيق العرض على النصوص**
نضيف العرض إلى النص عبر عينة الكود هذه في Java:
``` java
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
```


### **تطبيق تأثير التوهج على النصوص**
نطبق تأثير التوهج على النص لجعله يلمع أو يبرز باستخدام هذا الكود:
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
يمكنك تغيير معلمات الظل، العرض، والتوهج. يتم ضبط خصائص التأثيرات على كل جزء من النص على حدة. 
{{% /alert %}} 

### **استخدام التحويلات في WordArt**
نستخدم خاصية Transform (الموجودة في كتلة النص بالكامل) عبر هذا الكود:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
يوفر كل من Microsoft PowerPoint وAspose.Slides for Java عددًا من أنواع التحويلات المعرفة مسبقًا. 
{{% /alert %}} 

**باستخدام PowerPoint**

للوصول إلى أنواع التحويلات المعرفة مسبقًا، انتقل عبر: **Format** -> **TextEffect** -> **Transform**

**باستخدام Aspose.Slides**

لاختيار نوع التحويل، استخدم تعداد TextShapeType. 

### **تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال**
نضبط تأثيرًا ثلاثيًا الأبعاد على شكل نص باستخدام عينة الكود هذه:
``` java
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
```


النص وشكله الناتج:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثيرًا ثلاثيًا الأبعاد على النص باستخدام كود Java هذا:
``` java
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
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها وتفاعل هذه التأثيرات يعتمد على قواعد معينة. 

اعتبر مشهدًا للنص والشكل الذي يحتوي على ذلك النص. يحتوي تأثير ثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي وُضع فيه الكائن. 

- عندما يُحدد المشهد لكلٍ من الشكل والنص، يحصل مشهد الشكل على أولوية أعلى—ويُتجاهل مشهد النص. 
- عندما يفتقر الشكل إلى مشهد خاص به لكن لديه تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص. 
- وإلا—عندما لا يحتوي الشكل أصلاً على تأثير ثلاثي الأبعاد—يكون الشكل مسطحًا ويُطبق تأثير ثلاثي الأبعاد فقط على النص. 

ترتبط هذه الأوصاف بالطريقتين ThreeDFormat.getLightRig() وThreeDFormat.getCamera(). 
{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النصوص**
توفر Aspose.Slides for Java الفئات [**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/) و[**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/iinnershadow/) التي تسمح لك بتطبيق تأثيرات الظل على نص موجود داخل [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/). اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. الحصول على مرجع الشريحة باستخدام فهرسها. 
3. إضافة AutoShape من النوع Rectangle إلى الشريحة. 
4. الوصول إلى TextFrame المرتبط بـ AutoShape. 
5. ضبط FillType للـ AutoShape على NoFill. 
6. إنشاء مثيل من فئة OuterShadow 
7. ضبط BlurRadius للظل. 
8. ضبط Direction للظل 
9. ضبط Distance للظل. 
10. ضبط RectanglelAlign إلى TopLeft. 
11. ضبط PresetColor للظل إلى Black. 
12. كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/). 

يعرض هذا الكود النموذجي في Java—تنفيذ للخطوات أعلاه—كيفية تطبيق تأثير الظل الخارجي على نص:
```java
Presentation pres = new Presentation();
try {
    // احصل على مرجع الشريحة
    ISlide sld = pres.getSlides().get_Item(0);

    // أضف AutoShape من نوع Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // أضف TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");

    // عطل تعبئة الشكل في حال أردنا الحصول على ظل النص
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // أضف الظل الخارجي واضبط جميع المعلمات الضرورية
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // احفظ العرض التقديمي إلى القرص
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. الحصول على مرجع الشريحة. 
3. إضافة AutoShape من النوع Rectangle. 
4. تمكين InnerShadowEffect. 
5. ضبط جميع المعلمات اللازمة. 
6. ضبط ColorType كـ Scheme. 
7. ضبط Scheme Color. 
8. كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/). 

يعرض هذا الكود (استنادًا إلى الخطوات أعلاه) كيفية إضافة موصل بين شكلين في Java:
```java
Presentation pres = new Presentation();
try {
    // احصل على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // أضف AutoShape من نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // أضف TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // تفعيل تأثير الظل الداخلي
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // تعيين جميع المعلمات الضرورية
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // تعيين نوع اللون كـ Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // تعيين لون المخطط
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // حفظ العرض التقديمي
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**
**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية أو الصينية)؟**  
نعم، يدعم Aspose.Slides Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر الشريحة الرئيسية؟**  
نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في الشرائح الرئيسية، بما في ذلك العناصر النائبة للعنوان، التذييل، أو النص الخلفي. ستنعكس التغييرات التي تجريها على تخطيط الشريحة الرئيسية على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**  
قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئات التدرج حجم الملف قليلاً بسبب إضافة بيانات تنسيق، لكن الفرق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**  
نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `getImage` من واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) أو [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض الكامل.