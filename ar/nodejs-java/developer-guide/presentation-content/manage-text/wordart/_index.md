---
title: ووردآرت
type: docs
weight: 110
url: /ar/nodejs-java/wordart/
---

## **حول WordArt؟**

WordArt أو Word Art هي ميزة تسمح لك بتطبيق تأثيرات على النصوص لجعلها بارزة. باستخدام WordArt، على سبيل المثال، يمكنك تلوين حدود النص أو ملئه بلون (أو تدرج)، إضافة تأثيرات ثلاثية الأبعاد إليه، إلخ. كما يمكنك إمالة، انحناء، وتمديد شكل النص.

{{% alert color="primary" %}} 

WordArt يسمح لك بمعالجة النص كما لو كان كائنًا رسوميًا. بشكل عام، يتكون WordArt من تأثيرات أو تعديلات خاصة تُطبق على النصوص لجعلها أكثر جذبًا أو وضوحًا. 

{{% /alert %}} 

**WordArt في Microsoft PowerPoint**

لاستخدام WordArt في Microsoft PowerPoint، عليك اختيار أحد قوالب WordArt المحددة مسبقًا. قالب WordArt هو مجموعة من التأثيرات تُطبق على النص أو شكله.

**WordArt في Aspose.Slides**

في Aspose.Slides for Node.js via Java 20.10، قمنا بتنفيذ دعم WordArt وأجرينا تحسينات على الميزة في إصدارات Aspose.Slides for Node.js via Java اللاحقة.

مع Aspose.Slides for Node.js via Java، يمكنك بسهولة إنشاء قالب WordArt الخاص بك (تأثير واحد أو مجموعة من التأثيرات) بجافا سكريبت وتطبيقه على النصوص.

## **إنشاء قالب WordArt بسيط وتطبيقه على نص**

**استخدام Aspose.Slides** 

أولاً، ننشئ نصًا بسيطًا باستخدام شيفرة جافا سكريبت التالية:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا عبر الشيفرة التالية:
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**استخدام Microsoft PowerPoint**

انتقل إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير WordArt محدد مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات WordArt جديد.

هذه بعض المعلمات أو الخيارات المتوفرة:

![todo:image_alt_text](image-20200930114015-3.png)

**استخدام Aspose.Slides**

هنا، نطبق نمط اللون [SmallGrid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid) على النص ونضيف حدًا أسودًا بعرض 1 باستخدام الشيفرة التالية:
```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```


النص الناتج:

![todo:image_alt_text](image-20200930114108-4.png)

## **تطبيق تأثيرات WordArt أخرى**

**استخدام Microsoft PowerPoint**

من فئة البرنامج، يمكنك تطبيق هذه التأثيرات على نص أو كتلة نص أو شكل أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على النص؛ وتأثيرات تنسيق ثلاثي الأبعاد وتدوير ثلاثي الأبعاد على كتلة النص؛ وتطبيق خاصية الحواف الناعمة على كائن الشكل (تظل لها تأثير حتى إذا لم يتم تعيين خاصية تنسيق ثلاثي الأبعاد).

### **تطبيق تأثيرات الظل**

هنا نعتزم ضبط الخصائص المتعلقة بنص فقط. نطبق تأثير الظل على النص باستخدام الشيفرة التالية بجافا سكريبت:
```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```


يدعم Aspose.Slides API ثلاثة أنواع من الظلال: OuterShadow و InnerShadow و PresetShadow.

مع PresetShadow، يمكنك تطبيق ظل على نص (باستخدام قيم مسبقة).

**استخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثالًا:

![todo:image_alt_text](image-20200930114225-6.png)

**استخدام Aspose.Slides**

يسمح Aspose.Slides فعليًا بتطبيق نوعين من الظلال في آنٍ واحد: InnerShadow و PresetShadow.

**ملاحظات:**

- عند استخدام OuterShadow و PresetShadow معًا، يُطبق تأثير OuterShadow فقط. 
- إذا تم استخدام OuterShadow و InnerShadow معًا، يعتمد التأثير الناتج على نسخة PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يُطبق تأثير OuterShadow.

### **تطبيق العرض على النصوص**

نضيف العرض إلى النص عبر عينة الشيفرة التالية بجافا سكريبت:
```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```


### **تطبيق تأثير التوهج على النصوص**

نطبق تأثير التوهج على النص لجعله يلمع أو يبرز باستخدام الشيفرة التالية:
```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

يمكنك تغيير معلمات الظل، العرض، والتوهج. يتم ضبط خصائص التأثيرات على كل جزء من النص بشكل منفصل. 

{{% /alert %}} 

### **استخدام التحويلات في WordArt**

نستخدم خاصية Transform (الموجودة في كتلة النص بالكامل) عبر الشيفرة التالية:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

يقدم كل من Microsoft PowerPoint و Aspose.Slides for Node.js via Java عددًا معينًا من أنواع التحويلات المحددة مسبقًا.

{{% /alert %}} 

**استخدام PowerPoint**

للوصول إلى أنواع التحويلات المحددة مسبقًا، انتقل إلى: **Format** → **TextEffect** → **Transform**

**استخدام Aspose.Slides**

لاختيار نوع التحويل، استخدم تعداد TextShapeType.

### **تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال**

نضبط تأثير ثلاثي الأبعاد على شكل نص باستخدام عينة الشيفرة التالية:
```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


النص والشكل الناتج:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثيرًا ثلاثيًا الأبعاد على النص باستخدام الشيفرة التالية بجافا سكريبت:
```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها والتفاعلات بين التأثيرات تستند إلى قواعد معينة.

اعتبر مشهدًا للنص والشكل الذي يحتوي على النص. يحتوي تأثير ثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي يُوضع فيه الكائن.

- عندما يُحدد المشهد لكل من الشكل والنص، يحصل مشهد الشكل على أولوية أعلى—يُتجاهل مشهد النص. 
- عندما يفتقر الشكل إلى مشهد خاص به لكنه يحتوي على تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص. 
- وإلا—عندما لا يحتوي الشكل أصلاً على تأثير ثلاثي الأبعاد—يكون الشكل مسطحًا ويُطبق التأثير ثلاثي الأبعاد فقط على النص. 

هذه الأوصاف مرتبطة بالطرق ThreeDFormat.getLightRig() و ThreeDFormat.getCamera().

{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النصوص**

توفر Aspose.Slides for Node.js via Java الفئات [**OuterShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IOuterShadow) و [**InnerShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IInnerShadow) التي تسمح لك بتطبيق تأثيرات الظل على نص داخل [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame). اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
2. الحصول على مرجع شريحة باستخدام فهارسها.  
3. إضافة AutoShape من النوع Rectangle إلى الشريحة.  
4. الوصول إلى TextFrame المرتبط بـ AutoShape.  
5. ضبط FillType الخاص بـ AutoShape إلى NoFill.  
6. إنشاء مثيل من فئة OuterShadow.  
7. ضبط BlurRadius للظل.  
8. ضبط Direction للظل.  
9. ضبط Distance للظل.  
10. ضبط RectanglelAlign إلى TopLeft.  
11. ضبط PresetColor للظل إلى Black.  
12. حفظ العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

تظهر شيفرة Java التالية—تنفيذ للخطوات أعلاه—كيفية تطبيق تأثير الظل الخارجي على نص:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // الحصول على مرجع الشريحة
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من النوع Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");
    // إلغاء ملء الشكل في حالة رغبتنا بالحصول على ظل النص
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // إضافة ظل خارجي وتعيين جميع المعلمات اللازمة
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // كتابة العرض إلى القرص
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تطبيق تأثير الظل الداخلي على الأشكال**

اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
2. الحصول على مرجع الشريحة.  
3. إضافة AutoShape من النوع Rectangle.  
4. تمكين InnerShadowEffect.  
5. ضبط جميع المعلمات الضرورية.  
6. ضبط ColorType إلى Scheme.  
7. ضبط Scheme Color.  
8. حفظ العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

تظهر شيفرة العينة (المبنية على الخطوات أعلاه) كيفية إضافة موصل بين شكلين في جافا سكريبت:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // الحصول على مرجع الشريحة
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // تمكين InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // تعيين جميع المعلمات اللازمة
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // تعيين ColorType كـ Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // تعيين Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // حفظ العرض
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية أو الصينية)؟**

نعم، يدعم Aspose.Slides Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد على أي لغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر ماستر الشريحة؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في ماستر الشرائح، بما في ذلك نوافذ العناوين، التذييلات، أو النص الخلفي. سيُنعكس أي تغيير يُجرى على تخطيط الماستر على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئة التدرجات من حجم الملف قليلاً بسبب إضافة بيانات تنسيق، لكن الفرق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام الطريقة `getImage` من فئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) أو فئة [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.