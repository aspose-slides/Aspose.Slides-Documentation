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
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides للـ Python عبر Java. هذا الدليل خطوة بخطوة يساعد المطورين على تعزيز العروض التقديمية بنص احترافي في Python عبر Java."
---
## **نظرة عامة**

تتيح تأثيرات WordArt لك تنسيق النص باستخدام التعبئات، والحدود، والظلال، والانعكاسات، والتوهج، والتحولات، وتنسيق ثلاثي الأبعاد. يشرح هذا المقال كيفية إنشاء وتخصيص هذه التأثيرات في عروض PowerPoint باستخدام Aspose.Slides للـ Python عبر Java، دون تثبيت Microsoft Office.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

الأمثلة التالية تنشئ نمط WordArt بسيط عن طريق ضبط النص، الخط، تعبئة النمط، والحد.

كل مثال ينشئ عرض تقديمي جديد ويضيف مستطيلًا إلى شريحته الأولى؛ لا يلزم ملف إدخال. المثال الأول يضع النص على "Aspose.Slides". موضع الشكل وأبعاده تقاس بالنقاط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

اضبط الخط على Arial Black بحجم 36 نقطة لجعل التنسيق أكثر وضوحًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

طبق نمط [SmallGrid](https://reference.aspose.com/slides/ar/python-java/aspose.slides/patternstyle/#SmallGrid) بخلفية برتقالية داكنة ولون أمامي أبيض، ثم أضف حدًا أسودًا للنص بعرض نقطة واحدة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

النص الناتج:

![قالب WordArt البسيط](WordArt_template.png)

## **تطبيق تأثيرات WordArt الأخرى**

تظهر الأمثلة التالية كيفية تطبيق الظلال، الانعكاسات، التوهج، التحولات، وتأثيرات ثلاثية الأبعاد على النص.

### **تطبيق تأثيرات الظل الخارجي**

يضيف الظل الخارجي عمقًا بوضع ظل خلف النص. يمكنك تخصيص لونه، اتجاهه، مسافته، نصف قطر الضبابية، المقياس، والميل.

هذا المثال يستدعي [enableOuterShadowEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) ويضبط ظلًا أسود بنصف قطر ضبابية 4 نقاط، باتجاه 230 درجة، ومسافة 30 نقطة. قيم المقياس 100 تحافظ على حجم الظل، بينما الميل الأفقي يميل به 20 درجة. تحويل ألفا يضبط شفافيته إلى 32%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

النص الناتج:

![تأثير الظل الخارجي](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- عند استخدام الظلال الخارجية والمحددة معًا، يتم تطبيق الظل الخارجي فقط.
- إذا تم استخدام الظلال الخارجية والداخلية في آنٍ واحد، يعتمد التأثير الناتج على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يُطبق الظل الخارجي فقط.
{{% /alert %}}

### **تطبيق تأثيرات الانعكاس**

يخلق الانعكاس نسخةً معكوسةً من النص. اضبط موقعه، مقياسه، ضبابيته، وشفافيته للتحكم في مظهره.

هذا المثال يستدعي [enableReflectionEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effectformat/#enableReflectionEffect) ويقلب الانعكاس عموديًا بمقياس -100%. يستخدم نصف قطر ضبابية 0.5 نقطة ومسافة 4.72 نقطة. تتناقص الشفافية من 60% إلى 0.9% بين المواضع 0% و60% على طول الانعكاس:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

النص الناتج:

![تأثير الانعكاس](reflection_effect.png)

### **تطبيق تأثيرات التوهج**

يضيف التوهج حدودًا ملونةً ناعمةً حول النص. اضبط لونه، شفافيته، ونصف قطره للتحكم في التأثير.

هذا المثال يستدعي [enableGlowEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effectformat/#enableGlowEffect) ويطبق توهجًا أحمر بنسبة شفافية 54% ونصف قطر 7 نقاط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

النص الناتج:

![تأثير التوهج](glow_effect.png)

### **تطبيق تحويلات WordArt**

تحويلات WordArt تنحني أو تمط أو تشوه كتلة النص.

اضبط [setTransform](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setTransform) إلى [ArchUpPour](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textshapetype/#ArchUpPour) لتقوس إطار النص بالكامل إلى الأعلى:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

النص الناتج:

![تحويل WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
توفر Aspose.Slides للـ Python عبر Java مجموعة من [أنواع التحويل المعرّفة مسبقًا](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص**

يمكنك تطبيق تأثيرات ثلاثية الأبعاد على شكل أو على نصه. تتحكم الحواف، والبروز، والإضاءة، وإعدادات الكاميرا في المظهر الناتج.

يستخدم المثال التالي [ThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/) لإضافة حواف دائرية، بروز برتقالي، وحواف حمراء داكنة إلى المستطيل. تُقاس أبعاد الحافة، ارتفاع البروز، عرض الحافة، والعمق بالنقاط. مادة بلاستيكية، إضاءة متوازنة تدور بزاوية 40 درجة حول المحور Z، وكاميرا منظور تحدد مظهره:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

الشكل الناتج:

![تأثير الشكل ثلاثي الأبعاد](shape_3D_effect.png)

يطبق هذا المثال تنسيقًا ثلاثيًا أبعادًا مماثلًا على النص عبر [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat). تُشكل الحواف الصغيرة حواف الحروف، بينما يمنح البروز والإضاءة النص عمقًا:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

النص الناتج:

![تأثير النص ثلاثي الأبعاد](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
تطبيق تأثيرات ثلاثية الأبعاد على النص أو أشكالها—وتفاعل هذه التأثيرات—يحكمه قواعد محددة. اعتبر مشهدًا يشمل كلًا من النص والشكل الذي يحتويه. يتضمن تأثير ثلاثي الأبعد تمثيلًا ثلاثيًا للعنصر والمشهد الذي يُوضع فيه.

- إذا تم تعيين مشهد لكل من الشكل والنص، يأخذ مشهد الشكل الأولوية وتُتجاهل مشهد النص.
- إذا كان الشكل يفتقر إلى مشهد خاص به لكنه يملك تمثيلًا ثلاثيًا، يُستخدم مشهد النص.
- إذا لم يكن لدى الشكل أي تأثير ثلاثي أبعاد، يُعامل كمسطح، ويُطبق التأثير ثلاثي الأبعاد فقط على النص.

هذه السلوكيات تتعلق بطريقتي [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getLightRig) و[ThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

للحفاظ على النص مسطحًا وقابلًا للقراءة مع الاحتفاظ بتنسيق ثلاثي الأبعاد للشكل، اطلع على [حافظ على النص مسطحًا على شكل ثلاثي الأبعاد](/slides/ar/python-java/3d-presentation/) للمقارنة بين الإعدادين ومثال كامل للـ Python.

## **الأسئلة المتكررة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية، الصينية)؟**

نعم، يدعم Aspose.Slides للـ Python عبر Java Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخط وعرضه قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر الشريحة الأم؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في شرائح القالب، بما في ذلك عناصر العنونة، التذييلات، أو النص الخلفي. ستنعكس التغييرات التي تجريها على القالب على جميع الشرائح المرتبطة به.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض التقديمي؟**

قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهجات، وتعبئات التدرج من حجم الملف قليلًا بسبب بيانات التنسيق المضافة، لكن الاختلاف عادة ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تحويل الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage)، أو تحويل أشكال فردية باستخدام [Shape.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.