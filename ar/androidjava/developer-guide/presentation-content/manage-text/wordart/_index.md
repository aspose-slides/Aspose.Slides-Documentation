---
title: فن كتابة الكلمات
type: docs
weight: 110
url: /androidjava/wordart/
---


## **ما هو فن كتابة الكلمات؟**
فن كتابة الكلمات هو ميزة تتيح لك تطبيق تأثيرات على النصوص لجعلها بارزة. مع فن كتابة الكلمات، يمكنك مثلاً تحديد النص أو ملأه بلون (أو تدرج)، إضافة تأثيرات ثلاثية الأبعاد، إلخ. يمكنك أيضًا تحريف أو انحناء أو تمديد شكل النص. 

{{% alert color="primary" %}} 

فن كتابة الكلمات يتيح لك التعامل مع النص كما لو كان كائنًا رسوميًا. بشكل عام، يتألف فن كتابة الكلمات من تأثيرات أو تعديلات خاصة تُجرى على النصوص لجعلها أكثر جاذبية أو وضوحًا. 

{{% /alert %}} 

**فن كتابة الكلمات في Microsoft PowerPoint**

لاستخدام فن كتابة الكلمات في Microsoft PowerPoint، عليك اختيار أحد قوالب فن كتابة الكلمات المُعدة مسبقًا. قالب فن كتابة الكلمات هو مجموعة من التأثيرات التي تُطبق على نص أو شكله. 

**فن كتابة الكلمات في Aspose.Slides**

في Aspose.Slides لنظام Android عبر Java 20.10، نفذنا دعم فن كتابة الكلمات وقمنا بإجراء تحسينات على الميزة في إصدارات Aspose.Slides التالية لنظام Android عبر Java.

مع Aspose.Slides لنظام Android عبر Java، يمكنك بسهولة إنشاء قالب فن كتابة كلمات خاص بك (تأثير واحد أو مجموعة من التأثيرات) في Java وتطبيقه على النصوص.

## إنشاء قالب فن كتابة كلمات بسيط وتطبيقه على نص

**باستخدام Aspose.Slides** 

أولاً، نُنشئ نصًا بسيطًا باستخدام كود Java هذا: 

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

انتقل إلى قائمة تأثيرات فن كتابة الكلمات في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير فن كتابة كلمات مُعد مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات لفن كتابة كلمات جديد. 

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نطبق [لون نمط الشبكة الصغيرة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) على النص ونضيف حدود نص سوداء بعرض 1 باستخدام هذا الكود:

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

## تطبيق تأثيرات فن كتابة كلمات أخرى

**باستخدام Microsoft PowerPoint**

يمكنك من واجهة البرنامج تطبيق هذه التأثيرات على نص، كتلة نصية، شكل، أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على النص؛ يمكن تطبيق تأثيرات التنسيق ثلاثي الأبعاد والدوران ثلاثي الأبعاد على كتلة نصية؛ يمكن تطبيق خاصية الحواف الناعمة على كائن الشكل (لا تزال لها تأثير عندما لا يتم تعيين خاصية التنسيق ثلاثي الأبعاد).

### تطبيق تأثيرات الظل

هنا، نعتزم تعيين الخصائص المتعلقة بنص فقط. نطبق تأثير الظل على النص باستخدام هذا الكود في Java:

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

تدعم واجهة برمجة التطبيقات Aspose.Slides ثلاثة أنواع من الظلال: الظل الخارجي، الظل الداخلي، والظل المحدد مسبقًا. 

مع الظل المحدد مسبقًا، يمكنك تطبيق ظل على نص (باستخدام قيم محددة مسبقًا). 

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظل. إليك مثال:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

في الواقع، تسمح Aspose.Slides لك بتطبيق نوعين من الظلال في نفس الوقت: الظل الداخلي والظل المحدد مسبقًا.

**ملاحظات:**

- عند استخدام الظل الخارجي والظل المحدد مسبقًا معًا، يتم تطبيق تأثير الظل الخارجي فقط. 
- إذا تم استخدام الظل الخارجي والظل الداخلي في نفس الوقت، يعتمد التأثير الناتج أو المطبق على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013، يتم مضاعفة التأثير. ولكن في PowerPoint 2007، يتم تطبيق تأثير الظل الخارجي. 

### تطبيق العرض على النصوص

نضيف عرضًا على النص من خلال عينة كود Java هذه:

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

### تطبيق تأثير التوهج على النصوص

نطبق تأثير التوهج على النص لجعله يتلألأ أو يبرز باستخدام هذا الكود:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

يمكنك تغيير معلمات الظل والعرض والتوهج. يتم تعيين خصائص التأثيرات على كل جزء من النص بشكل منفصل. 

{{% /alert %}} 

### استخدام التحويلات في فن كتابة الكلمات

نستخدم خاصية التحويل (الموجودة في كامل كتلة النص) من خلال هذا الكود:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

توفر كل من Microsoft PowerPoint وAspose.Slides لنظام Android عبر Java عددًا معينًا من أنواع التحويل المحددة مسبقًا.

{{% /alert %}} 

**باستخدام PowerPoint**

للوصول إلى أنواع التحويل المحددة مسبقًا، انتقل عبر: **تنسيق** -> **تأثير النص** -> **تحويل**

**باستخدام Aspose.Slides**

لاختيار نوع التحويل، استخدم عدد النص نوع نص الشكل. 

### تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال

نقوم بتعيين تأثير ثلاثي الأبعاد على شكل نص باستخدام عينة كود:

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

نطبق تأثير ثلاثي الأبعاد على النص باستخدام كود Java هذا:

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

تطبيق التأثيرات ثلاثية الأبعاد على النصوص أو أشكالها والتفاعلات بين التأثيرات يعتمد على قواعد معينة. 

اعتبر مشهدًا لنص والشكل الذي يحتوي على ذلك النص. يحتوي التأثير ثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي وُضع عليه الكائن. 

- عندما يتم تعيين المشهد لكل من الشكل والنص، يحصل شكل النص على أولوية أعلى - يتم تجاهل مشهد النص. 
- عندما يفتقر الشكل إلى مشهده الخاص ولكنه يحتوي على تمثيل ثلاثي الأبعاد، يتم استخدام مشهد النص. 
- خلاف ذلك - عندما لا يحتوي الشكل أصلاً على تأثير ثلاثي الأبعاد - يكون الشكل مسطحًا ويتم تطبيق التأثير ثلاثي الأبعاد فقط على النص. 

ترتبط هذه الأوصاف بأساليب ThreeDFormat.getLightRig() وThreeDFormat.getCamera().

{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النصوص**
توفر Aspose.Slides لنظام Android عبر Java فئة [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow) وفئة [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow) التي تسمح لك بتطبيق تأثيرات الظل على نص محمول بواسطة [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame). اتبع هذه الخطوات:

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. احصل على مرجع الشريحة باستخدام فهرسها.
3. أضف شكل أوتوماتيكي من النوع المستطيل إلى الشريحة.
4. الوصول إلى TextFrame المرتبط بالشكل الأوتوماتيكي.
5. اضبط FillType للشكل الأوتوماتيكي إلى NoFill.
6. قم بإنشاء مثيل لفئة الظل الخارجي.
7. اضبط BlurRadius للظل.
8. اضبط Direction للظل.
9. اضبط Distance للظل.
10. اضبط RectangleAlign على TopLeft.
11. اضبط PresetColor للظل على الأسود.
12. اكتب العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

توضح عينة كود Java هذه - المثيل للخطوات المذكورة أعلاه - كيفية تطبيق تأثير الظل الخارجي على نص:

```java
Presentation pres = new Presentation();
try {
    // احصل على مرجع الشريحة
    ISlide sld = pres.getSlides().get_Item(0);

    // أضف شكل أوتوماتيكي من النوع المستطيل
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // أضف TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");

    // تعطيل ملء الشكل في حالة رغبتنا في الحصول على ظل النص
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // أضف الظل الخارجي واضبط جميع المعلمات اللازمة
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // اكتب العرض إلى القرص
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع هذه الخطوات:

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. احصل على مرجع للشريحة.
3. أضف شكل أوتوماتيكي من النوع المستطيل.
4. فعّل InnerShadowEffect.
5. اضبط جميع المعلمات اللازمة.
6. اضبط ColorType كـ Scheme.
7. اضبط لون المخطط.
8. اكتب العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

توضح عينة كود (استنادًا إلى الخطوات السابقة) كيفية إضافة موصل بين شكلين في Java:

```java
Presentation pres = new Presentation();
try {
    // احصل على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // أضف شكل أوتوماتيكي من النوع المستطيل
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // أضف TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // فعّل InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // اضبط جميع المعلمات اللازمة
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // اضبط ColorType كـ Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // اضبط لون المخطط
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // حفظ العرض
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```