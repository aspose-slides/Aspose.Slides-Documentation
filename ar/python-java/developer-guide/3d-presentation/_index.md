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
- امتداد ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنصوص في بايثون عبر جافا باستخدام Aspose.Slides. ضبط الكاميرا والإضاءة والمواد والامتداد والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Python via Java إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنصوص. تغطي هذه المقالة التأثيرات ثلاثية الأبعاد مثل الدوران، والامتداد، والحواف المائلة، والإضاءة، والمواد، وتعبئات التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذه المقالة تتناول تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا تتعلق بإدراج أو تعديل ملفات نموذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بعرض تلك التأثيرات الثلاثية الأبعاد في النتيجة الثنائية الأبعاد المصدرة.
{{% /alert %}}

قم بتثبيت الحزمة كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides`، يبدأ JVM إذا لزم الأمر، ثم يستورد API. مثال تعبئة الصورة يتطلب ملف `image.jpg` في مجلد العمل.

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. يتحكم كائن التنسيق المعاد في المشهد ثلاثي الأبعاد لهذا الشكل.

للنص، استخدم [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat). يطبق هذا تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم الأعضاء في API هي:

| عضو API | ما الذي يتحكم به | متى يتم استخدامه |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getCamera) | نقطة المشاهدة، نوع الكاميرا المحدد مسبقًا، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء الثلاثي الأبعاد أو مطابقة إعداد مسبق للدوران الثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getLightRig) | إعداد الضوء المسبق، الاتجاه، ودوران الضوء. | تغيير كيفية ظهور الإضاءات والظلال على السطح الثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setMaterial) | مادة السطح، مثل مسطح، مطفي، بلاستيك، أو معدن. | جعل الشكل نفسه يبدو أكثر تسطحًا أو نعومة أو لمعانًا أو معدنيًا. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setExtrusionHeight) | المسافة التي يمتد فيها الشكل للخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك يَظهر. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getExtrusionColor) | لون الجوانب الممتدة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setDepth) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق PowerPoint ثلاثي الأبعاد. | ضبط العمق للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getBevelBottom) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة مُنعمة أو مُشكَّلة بدلاً من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getContourColor)، [getContourWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getContourWidth)، و [setContourWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setContourWidth) | الخط الخارجي حول الكائن الثلاثي الأبعاد. | إبراز حد الكائن في المخرجات المرسومة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو بصورة مقنعة ثلاثية الأبعاد:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي الامتداد.
- إعدادات الضوء، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على طريقة عرض الضوء.
- إعدادات الامتداد أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيق ثلاثي الأبعاد، يحفظ العرض كملف PPTX، ويعرض الشريحة كصورة PNG.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

تُظهر صورة الشريحة المرسومة المستطيل ككتلة سميكة ثلاثية الأبعاد:

![مستطيل ثلاثي الأبعاد أزرق مُعرض مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **تدوير شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران الثلاثي الأبعاد من لوحة 3-D Rotation. قيم الدوران X و Y و Z تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة PowerPoint 3-D Rotation مع إبراز قيم الدوران X و Y و Z](img_02_01.png)

في Aspose.Slides، اضبط نوع الكاميرا والدوران عبر تنسيق 3D المعاد من [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat):

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

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغير ذلك هندسة الشكل الثنائي الأبعاد على الشريحة. إنه يغيّر منظور 3D الذي يستخدمه PowerPoint وAspose.Slides عند العرض.

## **إضافة امتداد وعمق**

يجعل الامتداد الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم إعداد العمق في هذه السماكة المرئية، ويتحكم إعداد اللون في لون الوجوه الجانبية.

![إعدادات العمق في PowerPoint مرتبطة بخصائص لون الامتداد وارتفاع الامتداد](img_02_02.png)

اضبط ارتفاع الامتداد للسماكة ولون الامتداد للون الجوانب:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

استخدم إعداد العمق عندما تحتاج إلى العمل مباشرةً مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة والمادة وتأثيرات النص. في العديد من سيناريوهات الشكل، يكون ارتفاع الامتداد هو الإعداد الأكثر وضوحًا لأنه يعبر مباشرةً عن الامتداد المرئي.

## **استخدام تعبئات التدرج أو الصورة مع تأثيرات ثلاثية الأبعاد**

تنسيق 3D مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب، أو تدرج، أو نمط، أو تعبئة صورة على الوجه الأمامي وما زالت تستخدم نفس إعدادات الكاميرا والضوء والمادة والامتداد.

هذا المثال يطبق تعبئة تدرج على الشكل ولون امتداد أغمق للجوانب:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

![مستطيل ثلاثي الأبعاد مُعرض بتعبئة تدرج من الأزرق إلى البرتقالي وامتداد برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض وعيّنها كتعبئة للشكل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

![مستطيل ثلاثي الأبعاد مُعرض بتعبئة صورة على الوجه الأمامي وامتداد برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق 3D للشكل يؤثر على جسم الشكل. تنسيق 3D للنص يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الحروف نفسها إلى امتداد، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بتعبئة نمط، يطبق تحويل WordArt، ويضبط إعدادات 3D على [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/):

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

![نص ثلاثي الأبعاد مُعرَّض بتحويل WordArt مقوس، تعبئة نمط برتقالي، وامتداد داكن](img_02_05.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق 3D عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ذات تخطيط ثابت، يتم رسم المشهد ثلاثي الأبعاد كصورة نقطية أو يُدمج في الناتج كنتيجة ثنائية الأبعاد. ينطبق هذا عند عرض الشرائح كـ PNG، أو التصدير إلى PDF، أو HTML، أو توليد إطارات للتحويل إلى فيديو.

احرص على هذه النقاط:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على دمج الكاميرا، وإضاءة rig، والمادة، والامتداد، والتعبئة، وتدرج حجم الشريحة.
- إذا كنت تحتاج إلى فحص قيم التنسيق الموروثة أو المستندة إلى القالب، استخدم API التنسيق الفعّال.
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق 3D القابل للتحرير في PowerPoint. في تلك الصيغ، تُعرض النتيجة بصريًا بدلاً من حفظها كإعدادات 3D قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

إن Aspose.Slides ينشئ ويعرض تأثيرات 3D في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX يبقى تنسيق 3D قابلًا للتحرير في PowerPoint حيث يدعم الصيغة ذلك.

**ما الفرق بين النموذج ثلاثي الأبعاد والتأثير ثلاثي الأبعاد؟**

النموذج ثلاثي الأبعاد هو كائن ثلاثي أبعاد منفصل يُدرج في العرض. التأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، والامتداد، والحافة، والإضاءة، والمادة. تتناول هذه المقالة التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، اضبط دوران الكاميرا وإما الامتداد أو العمق. عمليًا، يُفضَّل أيضًا ضبط إضاءة rig والمادة بحيث تكون الوجوه المُرسومة واضحة الإضاءات والظلال.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟**

نعم. استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat) لجسم الشكل و [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat) للنص.

**هل ستظهر تأثيرات 3D عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. يقوم Aspose.Slides بعرض تأثيرات 3D عند إنتاج صور الشرائح، أو إخراج PDF، أو HTML، أو الإطارات المستخدمة للتحويل إلى فيديو. يحتوي الناتج المصدّر على المظهر المرسوم، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

**هل يمكنني قراءة القيم النهائية لـ 3D بعد تطبيق الوراثة وإعدادات القالب؟**

نعم. استخدم [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getEffective) لقراءة الكاميرا النهائية، وإضاءة rig، والحافة، والقيم الثلاثية الأبعاد ذات الصلة.