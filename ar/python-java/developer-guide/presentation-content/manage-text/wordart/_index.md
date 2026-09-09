---
title: إنشاء وتطبيق تأثيرات WordArt في Python عبر Java
linktitle: WordArt
type: docs
weight: 110
url: /ar/python-java/wordart/
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
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides للـ Python عبر Java. يقدّم هذا الدليل خطوة بخطوة مساعدة للمطورين لتحسين العروض التقديمية بنص احترافي في Python عبر Java."
---
## **نظرة عامة**

تسمح تأثيرات WordArt لك بإضافة نص بصريًا جذابًا ومصممًا إلى عروض PowerPoint التقديمية. مع Aspose.Slides، يمكن للمطورين إنشاء WordArt وتخصيصه وإدارته برمجيًا تمامًا كما في Microsoft PowerPoint—دون الحاجة إلى تثبيت Office. توفّر هذه المقالة نظرة عامة على العمل مع WordArt، بما في ذلك كيفية تطبيق تحويلات النص، وأنماط التعبئة، والحدود، والظلال، وخيارات التنسيق الأخرى لجعل محتوى العرض أكثر تعبيرًا وجاذبية. يسمح WordArt لك بمعاملة النص ككائن رسومي. يتكون من تأثيرات أو تعديلات خاصة تُطبق على النص لجعله أكثر جاذبية أو بروزًا.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

**باستخدام Aspose.Slides**

أولاً، نقوم بإنشاء نص بسيط باستخدام كود Python هذا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
بعد ذلك، نزيد حجم الخط لجعل التأثير أكثر وضوحًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**باستخدام Microsoft PowerPoint**

انتقل إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![قائمة تأثيرات WordArt في PowerPoint](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير WordArt مُعرَّف مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات WordArt الجديد.

هذه بعض المعلمات أو الخيارات المتاحة:

![خيارات تنسيق WordArt](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نُطبق نمط التعبئة [PatternStyle.SmallGrid](https://reference.aspose.com/slides/ar/python-java/aspose.slides/patternstyle/#SmallGrid) على النص ونضيف حدًا نصيًا أسود باستخدام هذا الكود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

النص الناتج:

![نص مع تعبئة نمطية وحد أسود](image-20200930114108-4.png)

## **تطبيق تأثيرات WordArt أخرى**

**باستخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على النص أو كتلة النص أو الشكل أو عنصر مشابه:

![تأثيرات النص والشكل في PowerPoint](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على النص؛ وتأثيرات تنسيق ثلاثي الأبعاد وتدوير ثلاثي الأبعاد على كتلة النص؛ ويمكن تطبيق تأثير الحواف الناعمة على الشكل (يظل له تأثير حتى إذا لم يُحدَّد تأثير تنسيق ثلاثي الأبعاد).

### **تطبيق تأثيرات الظل**

الكود التالي بلغة Python يطبق تأثير الظل على النص فقط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

تدعم Aspose.Slides API ثلاثة أنواع من الظلال: [OuterShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/outershadow/)، [InnerShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/innershadow/)، و[PresetShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presetshadow/).

مع [PresetShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presetshadow/)، يمكنك تطبيق ظل على النص باستخدام قيم مُعرَّفة مسبقًا.

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثالًا:

![إعدادات الظل في PowerPoint](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

في الواقع، يسمح Aspose.Slides لك بتطبيق نوعين من الظلال في آنٍ واحد: [InnerShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/innershadow/) و[PresetShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presetshadow/).

**ملاحظات:**

- عند استخدام [OuterShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/outershadow/) و[PresetShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presetshadow/) معًا، يتم تطبيق تأثير [OuterShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/outershadow/) فقط.
- إذا تم استخدام [OuterShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/outershadow/) و[InnerShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/innershadow/) معًا، فإن النتيجة أو التأثير المطبق يعتمد على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يُطبق تأثير [OuterShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/outershadow/).

### **تطبيق انعكاس على النص**

نضيف انعكاسًا إلى النص عبر عينة الكود هذه في Python عبر Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **تطبيق تأثير توهج على النص**

نطبق تأثير التوهج على النص لجعله يلمع أو يبرز باستخدام الكود التالي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

نتيجة العملية:

![نص مع تأثير التوهج](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
يمكنك تغيير المعلمات للظل، الانعكاس، والتوهج. تُحدد خصائص التأثيرات لكل جزء من النص على حدة.
{{% /alert %}}

### **استخدام التحويلات في WordArt**

استخدم [TextFrameFormat.setTransform](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setTransform) لتحويل كتلة النص بالكامل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

النتيجة:

![نص مع تحويل قوسي](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
كلًّا من Microsoft PowerPoint وAspose.Slides for Python via Java يقدمان عددًا محددًا من أنواع التحويل المُعرَّفة مسبقًا.
{{% /alert %}}

**باستخدام PowerPoint**

للوصول إلى أنواع التحويل المُعرَّفة مسبقًا، انتقل إلى: **Format** → **TextEffect** → **Transform**

**باستخدام Aspose.Slides**

لاختيار نوع التحويل، استخدم تعداد [TextShapeType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textshapetype/).

### **تطبيق تأثيرات ثلاثية الأبعاد على النص والأشكال**

نطبق تأثيرًا ثلاثيًا الأبعاد على شكل نص باستخدام عينة الكود هذه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

النص والشكل الناتج:

![شكل نص مع تأثيرات ثلاثية الأبعاد](image-20200930114816-9.png)

نطبق تأثيرًا ثلاثيًا الأبعاد على النص باستخدام كود Python هذا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

نتيجة العملية:

![نص مع تأثيرات ثلاثية الأبعاد](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
تطبيق تأثيرات ثلاثية الأبعاد على النص أو أشكاله وتفاعلها معًا يعتمد على قواعد معينة.

اعتبر مشهدًا للنص والشكل الذي يحتويه. يحتوي تأثير ثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي يُوضع فيه الكائن.

- عندما يتم تعيين المشهد لكل من الشكل والنص، يحصل المشهد الخاص بالشكل على الأولوية—ويُتجاهل مشهد النص.
- عندما لا يمتلك الشكل مشهدًا خاصًا به ولكن له تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص.
- وإلا—عند عدم وجود تأثير ثلاثي الأبعاد أصلاً للشكل—يبقى الشكل مسطحًا ويُطبق التأثير ثلاثي الأبعاد فقط على النص.

هذه القواعد تتعلق بطريقتي [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getLightRig) و[ThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **تطبيق تأثير الظل الخارجي على النص**

توفر Aspose.Slides for Python via Java الفئتين [OuterShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/outershadow/) و[InnerShadow](https://reference.aspose.com/slides/ar/python-java/aspose.slides/innershadow/) اللتين تتيحان لك تطبيق تأثيرات الظل على النص داخل [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/). اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة باستخدام فهرستها.
3. أضف شكلًا مستطيلًا إلى الشريحة.
4. وصول إلى إطار النص المرتبط بالشكل.
5. عطل تعبئة الشكل.
6. فعّل تأثير الظل الخارجي.
7. عيّن نصف قطر تمويه الظل.
8. عيّن اتجاه الظل.
9. عيّن مسافة الظل.
10. حاذِ الظل إلى أعلى اليسار.
11. عيّن لون الظل إلى الأسود.
12. احفظ العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

يعرض لك هذا الكود النموذجي في Python عبر Java—تنفيذ الخطوات أعلاه—كيفية تطبيق تأثير الظل الخارجي على النص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # الحصول على مرجع الشريحة
    slide = presentation.getSlides().get_Item(0)

    # إضافة AutoShape من نوع مستطيل
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # إضافة TextFrame إلى المستطيل
    auto_shape.addTextFrame("Aspose TextBox")

    # تعطيل تعبئة الشكل في حال رغبتنا في الحصول على ظل النص
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # إضافة ظل خارجي وتعيين جميع المعلمات الضرورية
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # حفظ العرض على القرص
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تطبيق تأثير الظل الداخلي على الأشكال**

اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة.
3. أضف شكلًا مستطيلًا.
4. فعّل تأثير الظل الداخلي.
5. عيّن جميع المعلمات اللازمة.
6. عيّن نوع لون الظل لاستخدام لون من السِمة.
7. عيّن لون السِمة.
8. احفظ العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

يعرض لك هذا الكود النموذجي (استنادًا إلى الخطوات أعلاه) كيفية تطبيق تأثير الظل الداخلي على النص داخل شكل في Python عبر Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # الحصول على مرجع الشريحة
    slide = presentation.getSlides().get_Item(0)

    # إضافة AutoShape من نوع مستطيل
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # إضافة TextFrame إلى المستطيل
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # تمكين تأثير الظل الداخلي
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # تعيين جميع المعلمات الضرورية
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # تعيين ColorType كـ Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # تعيين لون المخطط
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # حفظ العرض التقديمي
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية أو الصينية)؟**

نعم، تدعم Aspose.Slides Unicode وتعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد regardless من اللغة، على الرغم من أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر القالب (Slide Master)؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال الموجودة في القوالب الرئيسية، بما في ذلك نُسق العناوين، التذييلات، أو النص الخلفي. ستنعكس التغييرات التي تُجريها على القالب عبر جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

بشكل طفيف. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئات التدرج حجم الملف قليلاً بسبب إضافة بيانات تنسيق، ولكن الفارق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تحويل الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام [Shape.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) أو [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.