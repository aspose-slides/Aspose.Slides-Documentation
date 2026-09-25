---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام بايثون
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/python-java/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بُثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تطبيق وتصيير تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في بايثون عبر جافا باستخدام Aspose.Slides. إعداد الكاميرا والإضاءة والمواد والبُثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides للـ Python عبر Java إنشاء وتعديل والحفاظ على وتصيير تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، التعبئة بالتدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذا المقال يدور حول تأثيرات التنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا يتناول إدراج أو تعديل ملفات نموذج ثلاثي الأبعاد منفصلة. عندما تقوم بتصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بتصيير تلك التأثيرات ثلاثية الأبعاد في النتيجة الثنائية الأبعاد المصدرة.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة [ThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/)، التي تتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

للنص، استخدم طريقة [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat). هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

الأعضاء الأكثر أهمية في واجهة برمجة التطبيقات هم:

| عضو API | ما الذي يتحكم فيه | متى يتم الاستخدام |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getCamera) | نقطة الرؤية، نوع الكاميرا المُعد مسبقًا، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getLightRig) | إعداد إضاءة مسبق، الاتجاه، ودوران الإضاءة. | تغيير مظهر الإبرازات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getMaterial) و[setMaterial](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setMaterial) | مادة السطح، مثل مسطح، مطفي، بلاستيك، أو معدني. | جعل الهندسة نفسها تبدو أكثر تسطحًا، نعومة، لامعة، أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getExtrusionHeight) و[setExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setExtrusionHeight) | المسافة التي يمتد فيها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي أبعاد سميك من الظاهر. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getExtrusionColor) | لون الجوانب البارزة. | إظهار العمق أو تنسيق لون الجوانب مع ملء الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getDepth) و[setDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setDepth) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getBevelTop) و[getBevelBottom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getBevelBottom) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مُشكَّلة بدلاً من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getContourColor) و[getContourWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getContourWidth) و[setContourWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setContourWidth) | الحد الخارجي حول الكائن ثلاثي الأبعاد. | تأكيد حدود الكائن في الناتج المصور. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثي الأبعاد بصورة مقنعة:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.  
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.  
- إعدادات المادة، لأن السطح يؤثر على طريقة تصيير الضوء.  
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق 100 نقطة. المثال يصيّر الشريحة إلى صورة PNG بمضاعفة أبعادها الافتراضية ويحفظ العرض التقديمي كملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الصورة المصدرة تُظهر المستطيل ككتلة ثلاثية أبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق تم تصييره مع نص أبيض ثلاثي الأبعاد على الوجه الأمامي](img_01_01.png)

## **دوران شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من خلال لوحة 3-D Rotation. قيم دوران X وY وZ تتوافق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة دوران ثلاثي الأبعاد في PowerPoint مع تمييز قيم دوران X وY وZ](img_02_01.png)

في Aspose.Slides، يمكن الوصول إلى الكاميرا عبر [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getCamera). يُنشئ هذا المثال مستطيلًا، يختار عرضاً أمامياً أرثوغرافيًا، ويضبط دوران X وY وZ إلى 20، 30، و40 درجة على التوالي. يكوّن الشكل في الذاكرة دون حفظ ملف:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل الثنائية الأبعاد على الشريحة، بل يغيّر منظور الثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides عند التصيير.

## **إضافة بثق وعمق**

البثق يجعل الشكل يبدو سميكًا عن طريق تمديده خلف الوجه الأمامي. في PowerPoint، يتحكم تحكم العمق في هذا السُمك الظاهر، وتتحكم خاصية اللون في لون الجوانب.

![عناصر تحكم العمق في PowerPoint المرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

استخدم [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setExtrusionHeight) لتحديد السماكة و[ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getExtrusionColor) للوصول إلى لون الجوانب. يمنح هذا المثال المستطيل بُثقًا بمقدار 100 نقطة مع جوانب بنفسجية ويدور الكاميرا لإظهار سمكه. يكوّن الشكل في الذاكرة دون حفظ ملف:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

طريقة [ThreeDFormat.setDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setDepth) تحدد عمق الشكل الثلاثي الأبعاد. طريقة [setExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setExtrusionHeight) تتحكم في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام تعبئة تدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق 3D مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي وما زلت تستخدم نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تدرج أزرق إلى برتقالي على الوجه الأمامي ولون برتقالي داكن على البثق بارتفاع 150 نقطة. توقّفات التدرج عند 0 و100 تمثل بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُصَير الشريحة إلى صورة PNG بمضاعفة أبعادها الافتراضية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

الناتج المصدّر يحافظ على التدرج على الوجه الأمامي ويصِّر البثق منفصلًا:

![مستطيل ثلاثي الأبعاد تم تصييره بتعبئة تدرج أزرق إلى برتقالي وبثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال وجود ملف باسم "image.jpg" في دليل العمل. يمدد الصورة لتملأ المستطيل، يطبق بُثقًا بارتفاع 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يكوّن الشكل في الذاكرة دون حفظ أو تصيير ملف:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

الصورة تُصَير على الوجه الأمامي، بينما يُصَير البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد تم تصييره بتعبئة صورة على الوجه الأمامي وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق 3D للشكل يؤثر على جسم الشكل. تنسيق 3D للنص يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الأحرف نفسها إلى بُثق ومادة وإضاءة وإعدادات كاميرا.

المثال التالي ينشئ نصًا بنمط شبكة برتقالي-أبيض، يطبّق قوسًا صاعدًا، ويكوّن إعدادات 3D عبر [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat). ارتفاع البُثق والعمق بالنقاط، ودوران الإضاءة بالدرجات. تم إخفاء تعبئة الشكل والحد بحيث يكون النص فقط مرئيًا. يصِّر المثال صورة PNG بمضاعفة أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النص يُصَير كحروف ثلاثية الأبعاد منحنية ومُبثق:

![نص ثلاثي الأبعاد تم تصييره بتحويل WordArt مقوس، تعبئة نمط برتقالي، وبثق داكن](img_02_05.png)

## **الحفاظ على النص مسطحًا على شكل ثلاثي الأبعاد**

للحفاظ على قراءة النص مع الحفاظ على مظهر الشكل الثلاثي الأبعاد، استدعِ [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setKeepTextFlat) عبر [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getTextFrameFormat). عندما تكون القيمة `True`، يبقى النص خارج المشهد الثلاثي الأبعاد. عندما تكون `False`، يشارك النص في المشهد ويتبع توجيهه الثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق 3D للشكل: لا يزال الكاميرا والإضاءة والمادة والبُثق مُكوَّنين عبر [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat). وهو مختلف أيضًا عن الدوران العادي. [Shape.setRotation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setRotation) يدور الشكل في مستوى الشريحة، بينما [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setRotationAngle) يتحكم في دوران النص داخل صندوقه. إبقاء النص خارج المشهد لا يُعيد تعيين أيٍّ من هذين الزاويتين.

المثال التالي المنشئ ذاتيًا ينشئ مستطيلًا أزرقًا مع نص ويستنسخه بجوار الأصلي. كلا الشكلين لهما نفس تنسيق 3D؛ الاختلاف فقط في إعداد النص: `False` على اليسار و`True` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البُثق 40 نقطة. يحفظ المثال العرض التقديمي كملف PPTX ويصِّر شريحة المقارنة إلى PNG بمضاعفة أبعادها الافتراضية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

على اليسار، يتبع النص توجيه 3D. على اليمين، يبقى مسطحًا وأسهل للقراءة. كلا المستطيلين يحتفظان بالبُثق والاتجاه الثلاثي الأبعاد الظاهرين.

![مستطيلات ثلاثية الأبعاد جنبًا إلى جنب: النص يتبع الاتجاه ثلاثي الأبعاد على اليسار ويبقى مسطحًا على اليمين](keep_text_flat.png)

## **سلوك التصدير والتصيير**

تحافظ Aspose.Slides على تنسيق 3D عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند التصيير أو التصدير إلى صيغ ثابتة، يتم تحويل المشهد ثلاثي الأبعاد إلى صورة ثنائية الأبعاد أو رسمه في الناتج. ينطبق ذلك عند تصيير الشرائح إلى [PNG](/slides/ar/python-java/convert-powerpoint-to-png/)، التصدير إلى [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، التصدير إلى [HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، أو إنشاء إطارات لـ [تحويل الفيديو](/slides/ar/python-java/convert-powerpoint-to-video/).

احرص على الأخذ بهذه النقاط في الاعتبار:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.  
- المظهر النهائي يعتمد على تركيبة الكاميرا، وإضاءة المشهد، والمادة، والبُثق، والتعبئة، وتكبير الشريحة.  
- إذا كنت بحاجة إلى فحص القيم الموروثة أو القيم المستندة إلى السمات، اقرأ [الخصائص الفعّالة للشكل](/slides/ar/python-java/shape-effective-properties/).  
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق 3D القابل للتعديل في PowerPoint. في تلك الصيغ، يتم تصيير النتيجة المرئية بدلاً من حفظها كإعدادات 3D قابلة للتعديل.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**  
Aspose.Slides ينشئ ويصيّر تأثيرات 3D في PowerPoint للأشكال والنص. لا يجعل الصور أو ملفات PDF أو صفحات HTML تفاعلية كمشاهد ثلاثية الأبعاد يمكن للمشاهد تدويرها. في ملفات PPTX، يبقى تنسيق 3D قابلاً للتعديل في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين النموذج الثلاثي الأبعاد والتأثير الثلاثي الأبعاد؟**  
النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد منفصل يُدرج في العرض التقديمي. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البُثق، الحافة، الإضاءة، والمادة. هذا المقال يغطي تأثيرات 3D.

**ما الإعدادات المطلوبة لشكل ثلاثي الأبعاد ظاهر؟**  
على الأقل، عيّن دوران الكاميرا وإما البُثق أو العمق. عمليًا، يفضَّل أيضًا ضبط إضاءة المشهد والمادة للحصول على إبرازات وظلال واضحة على الأسطح المصورة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**  
نعم. استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat) لجسم الشكل و[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**  
نعم. Aspose.Slides يصيّر تأثيرات 3D عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات تستخدم في تحويل الفيديو. الناتج المصدّر يحتوي على المظهر المصور، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتعديل.

**هل يمكنني قراءة القيم النهائية ثلاثية الأبعاد بعد تطبيق وراثة الإعدادات والسمات؟**  
نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [الخصائص الفعّالة للشكل](/slides/ar/python-java/shape-effective-properties/) لقراءة الكاميرا النهائية، وإضاءة المشهد، والحافة، والقيم الثلاثية الأبعاد المرتبطة.