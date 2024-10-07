---
title: وورد آرت
type: docs
weight: 110
url: /java/wordart/
---

## **ما هو وورد آرت؟**
وورد آرت أو فن الكتابة هو ميزة تتيح لك تطبيق تأثيرات على النصوص لجعلها تبرز. مع وورد آرت، على سبيل المثال، يمكنك تحديد نص أو ملؤه بلون (أو تدرج)، وإضافة تأثيرات ثلاثية الأبعاد إليه، وما إلى ذلك. يمكنك أيضًا إمالة، وثني، وإطالة شكل النص.

{{% alert color="primary" %}}

يتيح لك وورد آرت التعامل مع النص كما لو كان كائنًا رسوميًا. بشكل عام، يتكون وورد آرت من تأثيرات أو تعديلات خاصة تُجرى على النصوص لجعلها أكثر جاذبية أو وضوحًا.

{{% /alert %}}

**وورد آرت في Microsoft PowerPoint**

لاستخدام وورد آرت في Microsoft PowerPoint، يجب عليك اختيار أحد قوالب وورد آرت المسبقة. قالب وورد آرت هو مجموعة من التأثيرات التي يتم تطبيقها على نص أو شكله.

**وورد آرت في Aspose.Slides**

في Aspose.Slides لجافا 20.10، قمنا بتنفيذ دعم لوورد آرت وقمنا بتحسين الميزة في إصدارات Aspose.Slides للجافا التي تلت ذلك.

مع Aspose.Slides للجافا، يمكنك بسهولة إنشاء قالب وورد آرت خاص بك (تأثير واحد أو مجموعة من التأثيرات) في جافا وتطبيقه على النصوص.

## إنشاء قالب وورد آرت بسيط وتطبيقه على نص

**باستخدام Aspose.Slides**

أولاً، نقوم بإنشاء نص بسيط باستخدام هذا الكود جافا:

```java
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

```java
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**باستخدام Microsoft PowerPoint**

انتقل إلى قائمة تأثيرات وورد آرت في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير وورد آرت مسبق. من القائمة على اليسار، يمكنك تحديد إعدادات لوورد آرت جديد.

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نقوم بتطبيق لون نمط [SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid) على النص ونضيف حدود نصية سوداء بعرض 1 باستخدام هذا الكود:

```java
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

النص الناتج:

![todo:image_alt_text](image-20200930114108-4.png)

## تطبيق تأثيرات وورد آرت أخرى

**باستخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص أو كتلة نص أو شكل أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على النص؛ ويمكن تطبيق تأثيرات التنسيق الثلاثي الأبعاد والتدوير الثلاثي الأبعاد على كتلة نص؛ بينما يمكن تطبيق خاصية الحواف الناعمة على كائن الشكل (لا تزال لها تأثير عندما لا يتم تعيين خاصية التنسيق الثلاثي الأبعاد).

### تطبيق تأثيرات الظل

هنا، نعتزم تعيين الخصائص المتعلقة بالنص فقط. نقوم بتطبيق تأثير الظل على نص باستخدام هذا الكود في جافا:

```java
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

تدعم واجهة برمجة Aspose.Slides API ثلاثة أنواع من الظلال: OuterShadow وInnerShadow وPresetShadow.

مع PresetShadow، يمكنك تطبيق ظل على نص (باستخدام قيم مسبقة).

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثال:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

تسمح Aspose.Slides فعليًا بتطبيق نوعين من الظلال في وقت واحد: InnerShadow وPresetShadow.

**ملاحظات:**

- عند استخدام OuterShadow وPresetShadow معًا، يتم تطبيق تأثير OuterShadow فقط.
- إذا تم استخدام OuterShadow وInnerShadow في الوقت نفسه، فإن التأثير الناتج أو المطبق يعتمد على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013، يتم مضاعفة التأثير. لكن في PowerPoint 2007، يتم تطبيق تأثير OuterShadow.

### تطبيق التوهج على النصوص

نقوم بتطبيق تأثير التوهج على النص لجعلها تتألق أو تبرز باستخدام هذا الكود:

```java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}}

يمكنك تغيير المعلمات للظل، العرض، والتوهج. يتم تعيين خصائص التأثيرات على كل جزء من النص بشكل منفصل.

{{% /alert %}}

### استخدام التحويلات في وورد آرت

نستخدم خاصية Transform (الموجودة في الكتلة النصية بالكامل) من خلال هذا الكود:
```java
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}}

يوفر كل من Microsoft PowerPoint وAspose.Slides للجافا عددًا معينًا من أنواع التحويل المسبقة.

{{% /alert %}}

**باستخدام PowerPoint**

للوصول إلى أنواع التحويل المسبقة، انتقل من خلال: **تنسيق** -> **تأثير النص** -> **تحويل**

**باستخدام Aspose.Slides**

لاختيار نوع تحويل، استخدم تعداد TextShapeType.

### تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال

نقوم بتعيين تأثير ثلاثي الأبعاد على شكل نص باستخدام هذا الكود:

```java
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

نطبق تأثير ثلاثي الأبعاد على النص بهذا الكود جافا:

```java
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

تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها وتفاعلات التأثيرات يعتمد على قواعد معينة.

اعتبر مشهدًا لنص والشكل الذي يحتوي على ذلك النص. يحتوي تأثير الثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي تم وضع الكائن عليه.

- عندما يتم تعيين المشهد لكل من الشكل والنص، يتمتع مشهد الشكل بأولوية أعلى - يتم تجاهل مشهد النص.
- عندما يفتقر الشكل إلى مشهد خاص به ولكنه يحتوي على تمثيل ثلاثي الأبعاد، يتم استخدام مشهد النص.
- خلاف ذلك - عندما لا يحتوي الشكل في الأصل على تأثير ثلاثي الأبعاد - يكون الشكل مسطحًا ولا يتم تطبيق تأثير الثلاثي الأبعاد إلا على النص.

ترتبط هذه الأوصاف بأساليب ThreeDFormat.getLightRig() وThreeDFormat.getCamera().

{{% /alert %}}

## **تطبيق تأثيرات الظل الخارجي على النصوص**
توفر Aspose.Slides للجافا الفصول [**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IOuterShadow) و[**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IInnerShadow) التي تتيح لك تطبيق تأثيرات ظل على نص مُحمل بواسطة [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame). اتبع هذه الخطوات:

1. إنشاء مثيل من فصل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. احصل على مرجع لشرائح باستخدام فهرسها.
3. أضف AutoShape من نوع المستطيل إلى الشريحة.
4. الوصول إلى TextFrame المرتبط بـ AutoShape.
5. تعيين FillType لـ AutoShape إلى NoFill.
6. تهيئة فئة OuterShadow
7. تعيين BlurRadius للظل.
8. تعيين اتجاه الظل.
9. تعيين مسافة الظل.
10. تعيين RectangleAlign إلى أعلى اليسار.
11. تعيين PresetColor للظل إلى الأسود.
12. حفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

يوضح هذا الكود النموذجي في جافا - تجسيد الخطوات أعلاه - كيفية تطبيق تأثير الظل الخارجي على نص:

```java
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع مستطيل
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");

    // تعطيل ملء الشكل في حال أردنا الحصول على ظل للنص
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // إضافة ظل خارجي وتعيين جميع المعلمات الضرورية
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
اتبع هذه الخطوات:

1. إنشاء مثيل من فصل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. احصل على مرجع الشريحة.
3. أضف AutoShape من نوع المستطيل.
4. تمكين InnerShadowEffect.
5. تعيين جميع المعلمات اللازمة.
6. تعيين ColorType كخطة.
7. تعيين لون الخطة.
8. حفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) . 

يوضح هذا الكود النموذجي (المبني على الخطوات أعلاه) كيف يمكنك إضافة موصل بين شكلين في جافا:

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

    // تعيين جميع المعلمات الضرورية
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // تعيين ColorType كخطة
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // تعيين لون الخطة
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // حفظ العرض التقديمي
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```