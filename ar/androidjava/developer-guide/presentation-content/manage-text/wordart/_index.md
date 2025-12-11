---
title: "إنشاء وتطبيق تأثيرات WordArt على Android"
linktitle: "WordArt"
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
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides للـ Android. يساعد هذا الدليل خطوة بخطوة المطورين على تحسين العروض التقديمية بنص احترافي في Java."
---

## **حول WordArt؟**
WordArt أو Word Art هي ميزة تتيح لك تطبيق تأثيرات على النصوص لجعلها بارزة. باستخدام WordArt، على سبيل المثال، يمكنك إضافة حدود للنص أو ملءه بلون (أو تدرج)، وإضافة تأثيرات ثلاثية الأبعاد إليه، وما إلى ذلك. يمكنك أيضًا إمالة، انحناء، وتمديد شكل النص. 

{{% alert color="primary" %}} 
يتيح لك WordArt التعامل مع النص كما تتعامل مع كائن رسومي. بشكل عام، يتكون WordArt من تأثيرات أو تعديلات خاصة تُجرى على النصوص لجعلها أكثر جاذبية أو ملحوظة. 
{{% /alert %}} 

**WordArt في Microsoft PowerPoint**
لاستخدام WordArt في Microsoft PowerPoint، عليك اختيار أحد قوالب WordArt المعرفة مسبقًا. قالب WordArt هو مجموعة من التأثيرات التي تُطبق على نص أو شكله. 

**WordArt في Aspose.Slides**
في Aspose.Slides for Android عبر Java 20.10، قمنا بتنفيذ دعم لـ WordArt وأجرينا تحسينات على الميزة في إصدارات Aspose.Slides for Android عبر Java اللاحقة. 
مع Aspose.Slides for Android عبر Java، يمكنك بسهولة إنشاء قالب WordArt خاص بك (تأثير واحد أو مجموعة من التأثيرات) في Java وتطبيقه على النصوص. 

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**
**استخدام Aspose.Slides** 
أولاً، نقوم بإنشاء نص بسيط باستخدام كود Java التالي: 
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

الآن، نقوم بتعيين ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الكود: 
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**استخدام Microsoft PowerPoint**
انتقل إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير WordArt معرف مسبقًا. من القائمة على اليسار، يمكنك تحديد الإعدادات لـ WordArt جديد. 

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**استخدام Aspose.Slides**
هنا، نطبق نمط اللون [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) على النص ونضيف حدًا أسود بعرض 1 باستخدام هذا الكود: 
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
**استخدام Microsoft PowerPoint**
من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص، كتلة نص، شكل، أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على النص؛ ويمكن تطبيق تأثيرات تنسيق ثلاثي الأبعاد وتدوير ثلاثي الأبعاد على كتلة النص؛ ويمكن تطبيق خاصية الحواف الناعمة على كائن الشكل (تظل لها تأثير حتى إذا لم يتم تعيين خاصية تنسيق ثلاثي الأبعاد). 

### **تطبيق تأثيرات الظل**
هنا، نهدف إلى ضبط الخصائص المتعلقة بالنص فقط. نطبق تأثير الظل على النص باستخدام هذا الكود في Java: 
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


يدعم Aspose.Slides API ثلاثة أنواع من الظلال: OuterShadow و InnerShadow و PresetShadow. 
مع PresetShadow، يمكنك تطبيق ظل للنص (باستخدام قيم مسبقة). 

**استخدام Microsoft PowerPoint**
في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثالًا:

![todo:image_alt_text](image-20200930114225-6.png)

**استخدام Aspose.Slides**
في الواقع، يسمح Aspose.Slides لك بتطبيق نوعين من الظلال في آن واحد: InnerShadow و PresetShadow. 

**ملاحظات:**
- عندما يُستخدم OuterShadow مع PresetShadow معًا، يتم تطبيق تأثير OuterShadow فقط. 
- إذا تم استخدام OuterShadow و InnerShadow معًا، يختلف التأثير المطبق بحسب إصدار PowerPoint. فمثلاً، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يتم تطبيق تأثير OuterShadow فقط. 

### **تطبيق تأثيرات الانعكاس على النص**
نضيف الانعكاس إلى النص عبر هذا المثال في Java: 
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


### **تطبيق تأثير التوهج على النص**
نطبق تأثير التوهج على النص لجعله يضيء أو يبرز باستخدام هذا الكود: 
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
يمكنك تغيير المعلمات الخاصة بالظل، الانعكاس، والتوهج. تُضبط خصائص التأثيرات على كل جزء من النص على حدة. 
{{% /alert %}} 

### **استخدام التحويلات في WordArt**
نستخدم خاصية Transform (الموروثة في كامل كتلة النص) عبر هذا الكود: 
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
يوفر كل من Microsoft PowerPoint و Aspose.Slides for Android عبر Java عددًا معينًا من أنواع التحويلات المعرفة مسبقًا. 
{{% /alert %}} 

**استخدام PowerPoint**
للوصول إلى أنواع التحويلات المعرفة مسبقًا، اذهب عبر: **Format** -> **TextEffect** -> **Transform** 

**استخدام Aspose.Slides**
لاختيار نوع التحويل، استخدم تعداد TextShapeType. 

### **تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال**
نُعيّن تأثيرًا ثلاثيًا الأبعاد على شكل نص باستخدام مثال الكود هذا: 
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


النص الناتج وشكله:

![todo:image_alt_text](image-20200930114816-9.png)

نُطبّق تأثيرًا ثلاثيًا الأبعاد على النص بهذا الكود في Java: 
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
تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها وتفاعلاتها معًا يعتمد على قواعد معينة. 

تخيل مشهدًا للنص والشكل الذي يحتويه. يحتوي تأثير ثلاثي الأبعاد على تمثيل الكائن ثلاثي الأبعاد والمشهد الذي وضع فيه الكائن. 

- عندما يُحدد المشهد لكل من الشكل والنص، يحصل مشهد الشكل على أولوية أعلى—ويُتجاهل مشهد النص. 
- إذا كان الشكل يفتقر إلى مشهد خاص به لكنه يمتلك تمثيلًا ثلاثيًا الأبعاد، يُستخدم مشهد النص. 
- خلاف ذلك—إذا لم يكن لل形 أصلاً تأثير ثلاثي الأبعاد—يبقى الشكل مسطحًا ويُطبق التأثير ثلاثيًا الأبعاد فقط على النص. 

هذه الأوصاف مرتبطة بالطريقتين ThreeDFormat.getLightRig() و ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **تطبيق تأثير الظل الخارجي على النص**
توفر Aspose.Slides for Android عبر Java الفئات [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow) و [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow) التي تسمح لك بتطبيق تأثيرات الظل على نص موجود داخل [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame). اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. احصل على مرجع الشريحة باستخدام فهرستها.  
3. أضف AutoShape من النوع Rectangle إلى الشريحة.  
4. احصل على TextFrame المرتبط بـ AutoShape.  
5. اضبط FillType للـ AutoShape على NoFill.  
6. أنشئ كائن OuterShadow.  
7. عيّن BlurRadius للظل.  
8. عيّن Direction للظل.  
9. عيّن Distance للظل.  
10. عيّن RectanglelAlign إلى TopLeft.  
11. عيّن PresetColor للظل إلى Black.  
12. احفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  

يعرض هذا الكود في Java—تنفيذ للخطوات أعلاه—كيفية تطبيق تأثير الظل الخارجي على نص: 
```java
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");

    // تعطيل تعبئة الشكل في حال أردنا الحصول على ظل النص
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // إضافة ظل خارجي وتعيين جميع المعلمات اللازمة
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // حفظ العرض التقديمي إلى القرص
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. احصل على مرجع الشريحة.  
3. أضف AutoShape من النوع Rectangle.  
4. فعّل InnerShadowEffect.  
5. عيّن جميع المعلمات اللازمة.  
6. عيّن ColorType إلى Scheme.  
7. عيّن Scheme Color.  
8. احفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  

يعرض هذا الكود (المستند إلى الخطوات أعلاه) كيفية إضافة موصل بين شكلين في Java: 
```java
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // تمكين InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // تعيين جميع المعلمات اللازمة
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // تعيين ColorType إلى Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // تعيين Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // حفظ العرض التقديمي
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية، الصينية)؟**  
نعم، يدعم Aspose.Slides Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر الشريحة الأساسية؟**  
نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في الشرائح الأساسية، بما في ذلك نوافذ العناوين، التذييلات، أو النص الخلفي. ستنعكس التغييرات التي تجريها على التخطيط الأساسي على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض التقديمي؟**  
تؤثر بشكل طفيف. قد تؤدي تأثيرات WordArt مثل الظلال، التوهجات، وتعبئات التدرج إلى زيادة بسيطة في حجم الملف بسبب إضافة بيانات تنسيق، لكن الفرق عادةً ما يكون غير ملحوظ.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض التقديمي؟**  
نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `getImage` من واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) أو [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض التقديمي بالكامل.