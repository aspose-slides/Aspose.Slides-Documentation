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
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في بايثون عبر جافا باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمواد والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Python via Java إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، والبثق، والحواف المائلة، والإضاءة، والمواد، وتعبئات التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذه المقالة تتحدث عن تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا تتعلق بإدراج أو تعديل ملفات نماذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بتحويل تلك التأثيرات ثلاثية الأبعاد إلى النتيجة ثنائية الأبعاد المصدرة.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) التي تتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

للنص، استخدم طريقة [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). يطبق هذا تنسيق ثلاثي الأبعاد على إطار النص بدلًا من جسم الشكل.

أهم أعضاء API هي:

| عضو API | ما الذي يتحكم به | متى يتم استخدامه |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | نقطة المشاهدة، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد مسبق في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | إعداد إضاءة مسبق، الاتجاه، ودوران الضوء. | تغيير مظهر الإبرازات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | جعل الهندسة نفسها تبدو أكثر تسطحًا، أو ناعمة، أو لامعة، أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | المسافة التي يمتد بها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى جسم ثلاثي الأبعاد سميك مرئي. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | لون الجوانب البثقية. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمواد. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | حواف مرتفعة أو مدورة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مُقَومة بدلًا من وجه مسطح وحاد. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | حدود حول الجسم ثلاثي الأبعاد. | تأكيد حدود الكائن في الناتج المرسوم. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثي الأبعاد بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية إظهار الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي ينشئ مستطيلاً، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيق ثلاثي الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق هو 100 نقطة. يُظهر المثال الشريحة كصورة PNG بأبعاد ضعف الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

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

الصورة المرسومة للشريحة تُظهر المستطيل ككتلة سميكة ثلاثية الأبعاد:

![مستطيل أزرق ثلاثي الأبعاد مُرسم مع نص أبيض ثلاثي الأبعاد على الوجه الأمامي](img_01_01.png)

## **دوران شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة 3-D Rotation. قيم دوران X وY وZ تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة 3-D Rotation في PowerPoint مع إبراز قيم دوران X وY وZ](img_02_01.png)

في Aspose.Slides، يمكن الوصول إلى الكاميرا عبر [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). هذا المثال ينشئ مستطيلاً، يختار عرضًا أماميًا أرثوغرافيًا، ويضبط دورانات X وY وZ إلى 20، 30، و40 درجة على التوالي. يقوم بتهيئة الشكل في الذاكرة دون حفظ ملف:

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

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائي الأبعاد على الشريحة. يغيّر منظور ثلاثي الأبعاد المستخدم من قبل PowerPoint وAspose.Slides عند العرض.

### **نسخ توجيه الكاميرا من شكل القالب**

لمطابقة توجيه شكل القالب، اقرأ إعداد الكاميرا المسبق باستخدام [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) وزوايا دورانه باستخدام [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). يفتح المثال `template.pptx` وينسخ توجيه الكاميرا من الشكل الأول على الشريحة الأولى إلى الشكل الثاني. كلا الشكلين يمتلكان إضاءة ثلاثية الأبعاد مسبقة، ولا يحتوي الشكل الثاني على دوران كاميرا صريح.

الزوايا بالدرجات. الفهرس `0` هو خط العرض، الفهرس `1` هو خط الطول، والفهرس `2` هو دوران. مررها إلى [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) بهذا الترتيب. إذا أعاد المصدر `None` فهذا يعني عدم وجود دوران صريح، لذا اترك زوايا الشكل الثاني غير مضبوطة. دوران صريح `(0, 0, 0)` يُعيد ثلاثة أصفار ويجب نسخه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

عند إعادة فتح `camera-copy.pptx` في PowerPoint، يحمل السهم على اليمين نفس إعداد الكاميرا والدوران كالمنحنى الأيسر. يستخدم كلا الشكلين نفس الإضاءة وعمق البثق.

![مستطيل أزرق ثلاثي الأبعاد وسهم يميني بتوجيه كاميرا متطابق، يُرى من الأعلى واليمين](camera-orientation.png)

## **إضافة بثق وعمق**

البثق يجعل الشكل يبدو سميكًا بتمديده إلى الخلف من الوجه الأمامي. في PowerPoint، يحدد التحكم في العمق هذا السماكة الظاهرة، وتحدد أداة التحكم في اللون لون الجوانب.

![تحكم العمق في PowerPoint مرتبط بلون البثق وخصائص ارتفاع البثق](img_02_02.png)

استخدم [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) لتحديد السماكة و[ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) للوصول إلى لون الجوانب. يمنح هذا المثال مستطيلًا بارتفاع بثق 100 نقطة مع جوانب أرجوانية ويدور الكاميرا لتظهر سماكته. يهيئ الشكل في الذاكرة دون حفظ ملف:

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

طريقة [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) تضبط عمق الشكل ثلاثي الأبعاد. طريقة [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) تتحكم في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام تعبئات التدرج أو الصورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي ولا يزال بإمكانك استخدام نفس الكاميرا والإضاءة والمواد وإعدادات البثق.

هذا المثال يطبق تدرج أزرق إلى برتقالي على الوجه الأمامي ولون برتقالي داكن على بارتفاع بثق 150 نقطة. توقفت نقاط التدرج عند 0 و100 لتحديد بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُعرض الشريحة كصورة PNG بأبعاد ضعف الأبعاد الافتراضية:

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

الناتج المرسوم يحافظ على التدرج على الوجه الأمامي ويعرض البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مُرسم بتعبئة تدرج أزرق إلى برتقالي وبثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال وجود ملف موجود باسم "image.jpg" في دليل العمل. يملأ الصورة المستطيل، يطبق بارتفاع بثق 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يهيئ الشكل في الذاكرة دون حفظ أو عرض ملف:

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

يتم عرض الصورة على الوجه الأمامي، بينما يُظهر البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مُرسم بتعبئة صورة على الوجه الأمامي وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الحروف نفسها إلى بثق ومادة وإضاءة وإعدادات كاميرا.

المثال التالي ينشئ نصًا بنمط شبكة برتقالية-بيضاء، يطبق قوسًا صاعدًا، ويضبط إعدادات ثلاثية الأبعاد عبر [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). ارتفاع البثق والعمق بالنقاط، ودوران الضوء بالدرجات. تُخفى تعبئة الشكل والحدود بحيث لا يُظهر إلا النص. يُظهر المثال صورة PNG بضعف أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

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

يُعرض النص كحروف ثلاثية الأبعاد منحنية ومبعثة:

![نص ثلاثي الأبعاد مُرسم بتأثير تحويل مقوس على WordArt، تعبئة بنمط برتقالي، وبثق داكن](img_02_05.png)

## **الحفاظ على نص مسطح على شكل ثلاثي الأبعاد**

للحفاظ على قراءة النص مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، استدعِ [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) عبر [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). عندما تكون القيمة `True` يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `False` يشارك النص في المشهد ويتبع توجيه ثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق ثلاثي الأبعاد للشكل: لا يزال الكاميرا والإضاءة والمواد والبثق مضبوطة عبر [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). وهو مختلف أيضًا عن الدوران العادي. تقوم [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) بدوران الشكل في مستوى الشريحة، بينما تتحكم [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) في دوران النص داخل حدوده. الحفاظ على النص خارج المشهد ثلاثي الأبعاد لا يعيد تعيين أيٍ من هذين الزاويتين.

المثال التالي المستقل ينشئ مستطيلًا أزرقًا مع نص ويستنسخه بجانب الأصل. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ يختلف إعداد النص فقط: `False` على اليسار و`True` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البثق 40 نقطة. يحفظ المثال العرض التقديمي كـ PPTX ويعرض شريحة المقارنة كـ PNG بضعف أبعادها الافتراضية.

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

على اليسار، يتبع النص توجيه ثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل قراءة. يحتفظ كلا المستطيلين بنفس البثق الظاهر وتوجيه ثلاثي الأبعاد.

![مستطيلات ثلاثية الأبعاد جنبًا إلى جنب: النص يتبع التوجيه ثلاثي الأبعاد على اليسار ويبقى مسطحًا على اليمين](keep_text_flat.png)

## **سلوك التصدير والعرض**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ثابتة التخطيط، يتم تحويل المشهد ثلاثي الأبعاد إلى نقطية أو رسمه في النتيجة كصورة ثنائية الأبعاد. ينطبق ذلك عندما تقوم بعرض الشرائح إلى [PNG](/slides/ar/python-java/convert-powerpoint-to-png/)، أو التصدير إلى [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، أو التصدير إلى [HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، أو إنشاء إطارات لتحويل [video conversion](/slides/ar/python-java/convert-powerpoint-to-video/).

ضع في اعتبارك النقاط التالية:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمستخدم تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، وإعداد الإضاءة، والمواد، والبثق، والتعبئة، وتوسيع الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو القائمة على السمة، اقرأ [effective shape properties](/slides/ar/python-java/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد القابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من الاحتفاظ بها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

تنشئ Aspose.Slides وتعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا تجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يظل تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما هو الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**

النموذج ثلاثي الأبعاد هو كائن ثلاثي الأبعاد منفصل يُدرج في العرض التقديمي. التأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران أو البثق أو الحافة أو الإضاءة أو المادة. هذه المقالة تغطي التأثيرات ثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، اضبط دوران الكاميرا وإما البثق أو العمق. عمليًا، يُفضَّل أيضًا ضبط إضاءة المشهد والمواد بحيث تظهر الوجوه بوضوح مع إبرازات وظلال.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟**

نعم. استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) لجسم الشكل و[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى الصور أو PDF أو HTML أو إطارات الفيديو؟**

نعم. تقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح أو مخرجات PDF أو HTML أو إطارات الفيديو. يحتوي الإخراج المصدَّر على المظهر المرسوم، وليس كائنًا ثلاثيًا قابلًا للتحرير.

**هل يمكنني قراءة القيم النهائية ثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [effective shape properties](/slides/ar/python-java/shape-effective-properties/) لقراءة الكاميرا النهائية وإعدادات الإضاءة والحافة والقيم الثلاثية الأبعاد ذات الصلة.