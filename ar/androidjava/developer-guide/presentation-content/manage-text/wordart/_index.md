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
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides لنظام Android. يساعد هذا الدليل خطوة بخطوة المطورين على تحسين العروض التقديمية بنص احترافي باستخدام Java."
---

## **حول WordArt؟**
WordArt أو Word Art هي ميزة تسمح لك بتطبيق تأثيرات على النصوص لجعلها بارزة. باستخدام WordArt، على سبيل المثال، يمكنك رسم حد للنص أو ملئه بلون (أو تدرج)، إضافة تأثيرات ثلاثية الأبعاد، إلخ. يمكنك أيضًا إمالة النص، انحنائه، وتمديد شكله.

{{% alert color="primary" %}} 
WordArt يتيح لك التعامل مع النص كما تتعامل مع كائن رسومي. بشكل عام، يتكون WordArt من تأثيرات أو تعديلات خاصة تُجرى على النصوص لجعلها أكثر جاذبية أو وضوحًا. 
{{% /alert %}} 

**WordArt في Microsoft PowerPoint**

لاستخدام WordArt في Microsoft PowerPoint، عليك اختيار أحد قوالب WordArt المحددة مسبقًا. قالب WordArt هو مجموعة من التأثيرات تُطبق على نص أو شكله.

**WordArt في Aspose.Slides**

في Aspose.Slides for Android via Java 20.10، قمنا بتنفيذ دعم WordArt وأجرينا تحسينات على الميزة في إصدارات Aspose.Slides for Android via Java اللاحقة.

مع Aspose.Slides for Android via Java، يمكنك بسهولة إنشاء قالب WordArt الخاص بك (تأثير واحد أو مجموعة من التأثيرات) في Java وتطبيقه على النصوص.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

**باستخدام Aspose.Slides** 

أولاً، ننشئ نصًا بسيطًا باستخدام كود Java هذا: 
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

الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الكود:
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**باستخدام Microsoft PowerPoint**

اذهب إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير WordArt محدد مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات WordArt جديد.

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نطبق نمط اللون [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) على النص ونضيف حد نص أسود بسمك 1 باستخدام هذا الكود:
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

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص أو كتلة نصية أو شكل أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على النص؛ وتأثيرات الشكل ثلاثي الأبعاد والدوران ثلاثي الأبعاد على كتلة نصية؛ ويمكن تطبيق خاصية الحواف الناعمة على كائن الشكل (لا يزال لها تأثير عندما لا يتم ضبط خاصية الشكل ثلاثي الأبعاد).

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


يدعم Aspose.Slides API ثلاثة أنواع من الظلال: OuterShadow، InnerShadow، و PresetShadow.

مع PresetShadow، يمكنك تطبيق ظل للنص (باستخدام قيم مسبقة).

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظل. إليك مثالًا:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

يسمح Aspose.Slides فعليًا بتطبيق نوعين من الظلال في آن واحد: InnerShadow و PresetShadow.

**ملاحظات:**

- عندما يُستخدم OuterShadow و PresetShadow معًا، يتم تطبيق تأثير OuterShadow فقط. 
- إذا استُخدم OuterShadow و InnerShadow معًا، فإن النتيجة أو التأثير المطبق يعتمد على نسخة PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير. لكن في PowerPoint 2007، يتم تطبيق تأثير OuterShadow. 

### **تطبيق تأثيرات الانعكاس على النص**

نضيف عرضًا للنص عبر مثال الكود هذا في Java:
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


### **تطبيق تأثيرات التوهج على النص**

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
يمكنك تغيير المعلمات للظل، العرض، والتوهج. يتم ضبط خصائص التأثيرات على كل جزء من النص بشكل منفصل. 
{{% /alert %}} 

### **استخدام التحولات في WordArt**

نستخدم خاصية Transform (المطبقة على كتلة النص بأكملها) عبر هذا الكود:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
يقدم كل من Microsoft PowerPoint و Aspose.Slides for Android via Java عددًا من أنواع التحولات المحددة مسبقًا. 
{{% /alert %}} 

**باستخدام PowerPoint**

للوصول إلى أنواع التحولات المحددة مسبقًا، انتقل عبر: **Format** -> **TextEffect** -> **Transform**

**باستخدام Aspose.Slides**

لاختيار نوع التحول، استخدم تعداد TextShapeType.

### **تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال**

نضع تأثيرًا ثلاثيًا الأبعاد على شكل نص باستخدام مثال الكود هذا:
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


النص والشكل الناتج:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثيرًا ثلاثيًا الأبعاد على النص عبر هذا الكود في Java:
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
تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها وتفاعل التأثيرات معًا يعتمد على قواعد معينة.

اعتبر مشهدًا للنص والشكل الذي يحتويه. يحتوي تأثير ثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي وضُع فيه الكائن.

- عندما يُضبط المشهد لكل من الشكل والنص، يحصل مشهد الشكل على أولوية أعلى—يُتجاهل مشهد النص. 
- عندما لا يملك الشكل مشهدًا خاصًا به لكن لديه تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص. 
- وإلا—عند عدم وجود تأثير ثلاثي الأبعاد أصلاً للشكل—يظل الشكل مسطحًا ويتم تطبيق التأثير ثلاثي الأبعاد على النص فقط.

هذه الأوصاف مرتبطة بأساليب ThreeDFormat.getLightRig() و ThreeDFormat.getCamera().
{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النص**
توفر Aspose.Slides for Android via Java الفئتين [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/) و [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinnershadow/) اللتين تتيحان لك تطبيق تأثيرات الظل على نص داخل [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/). اتبع الخطوات التالية:

1. أنشئ مثالًا لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation). 
2. احصل على مرجع الشريحة باستخدام فهرسها. 
3. أضف AutoShape من نوع Rectangle إلى الشريحة. 
4. وصول إلى TextFrame المرتبط بـ AutoShape. 
5. اضبط FillType للـ AutoShape إلى NoFill. 
6. أنشئ كائن OuterShadow. 
7. اضبط BlurRadius للظل. 
8. اضبط Direction للظل. 
9. اضبط Distance للظل. 
10. اضبط RectanglelAlign إلى TopLeft. 
11. اضبط PresetColor للظل إلى Black. 
12. احفظ العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/). 

يعرض لك هذا المثال البرمجي في Java—تنفيذ الخطوات السابقة—كيفية تطبيق تأثير الظل الخارجي على نص:
```java
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // إضافة TextFrame إلى الشكل المستطيل
    ashp.addTextFrame("Aspose TextBox");

    // تعطيل تعبئة الشكل في حال نريد الحصول على ظل النص
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // إضافة ظل خارجي وتعيين جميع المعلمات اللازمة
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // كتابة العرض على القرص
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تطبيق تأثيرات الظل الداخلي على الأشكال**
اتبع الخطوات التالية:

1. أنشئ مثالًا لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation). 
2. احصل على مرجع الشريحة. 
3. أضف AutoShape من نوع Rectangle. 
4. فعّل InnerShadowEffect. 
5. اضبط جميع المعلمات الضرورية. 
6. اضبط ColorType إلى Scheme. 
7. اضبط Scheme Color. 
8. احفظ العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/). 

يعرض لك هذا المثال البرمجي (المستند إلى الخطوات السابقة) كيفية إضافة موصل بين شكلين في Java:
```java
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // إضافة TextFrame إلى الشكل المستطيل
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // تمكين تأثير الظل الداخلي
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // تعيين جميع المعلمات اللازمة
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // تعيين ColorType كـ Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // تعيين لون المخطط
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // حفظ العرض التقديمي
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو لغات مختلفة (مثل العربية أو الصينية)؟**

نعم، يدعم Aspose.Slides Unicode ويعمل مع جميع الخطوط واللغات الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر قالب الشريحة؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في شرائح القالب، بما في ذلك نوافل العنوان، التذييلات، أو النص الخلفي. ستنعكس التغييرات التي تجريها على القالب على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

تأثير طفيف. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، والتعبئة المتدرجة حجم الملف قليلًا بسبب إضافة بيانات تنسيق، لكن الفارق عادة ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تحويل الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `getImage` من واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) أو [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.