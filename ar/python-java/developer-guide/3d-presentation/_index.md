---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام Python
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/python-java/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- تدوير ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تطبيق وتصيّر تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في Python عبر Java باستخدام Aspose.Slides. قم بتكوين الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يمكنه إنشاء وتحرير والحفاظ على وتصيير تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل التدوير، البثق، الحواف المائلة، الإضاءة، المادة، التعبئة بالتدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="ملاحظة" %}}
هذا المقال يتناول تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا يتعلق بإدراج أو تحرير ملفات نماذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بتصيّر تلك التأثيرات ثلاثية الأبعاد في المخرجات الثنائية الأبعاد.
{{% /alert %}}

ثبّت الحزمة كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). تستورد كل مثال `asposeslides`، وتبدأ JVM إذا لزم الأمر، ثم تستورد API. مثال تعبئة الصورة يتطلب ملف `image.jpg` في دليل العمل.

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. يتحكم كائن التنسيق المرتجع في مشهد ثلاثي الأبعاد لهذا الشكل.

للنص، استخدم [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat). يطبق هذا تنسيقًا ثلاثيًا أبعاد على إطار النص بدلًا من جسم الشكل.

أهم أعضاء API هي:

| عضو API | ما الذي يتحكم فيه | متى يستخدم |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getCamera) | نقطة الرؤية، نوع الكاميرا المسبق، الدوران، التكبير، والمنظور. | تدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعدادات دوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getLightRig) | إعدادات الإضاءة المسبقة، الاتجاه، ودوران الضوء. | تغيير كيفية ظهور اللمعات والظلال على السطح ثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setMaterial) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | جعل الهندسة نفسها تبدو مسطحة أكثر، ناعمة، لامعة، أو معدنية. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setExtrusionHeight) | مدى امتداد الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك واضح. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getExtrusionColor) | لون الجوانب البثقية. | إظهار العمق أو تنسيق لون الجانب مع تعبئة الوجه الأمامي. |
| [getDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setDepth) | عمق ثلاثي أبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getBevelBottom) | حواف مرتفعة أو مستديرة على الوجهين الأمامي والخلفي. | إضافة حافة ناعمة أو مصقولة بدلاً من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getContourColor)، [getContourWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getContourWidth)، و [setContourWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setContourWidth) | الخط الخارجي حول الكائن ثلاثي الأبعاد. | إبراز حدود الكائن في المخرجات المصيّرة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا الأبعاد بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على طريقة تصيير الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيقًا ثلاثيًا أبعاد، يحفظ العرض التقديمي كملف PPTX، ويصيّر الشريحة إلى صورة PNG.

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

صورة الشريحة المصيّرة تُظهر المستطيل ككتلة سميكة ثلاثية الأبعاد:

![مستطيل أزرق ثلاثي الأبعاد مصيّر مع نص أبيض ثلاثي الأبعاد على الوجه الأمامي](img_01_01.png)

## **تدوير الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين التدوير ثلاثي الأبعاد من لوحة "3-D Rotation". قيم التدوير X وY وZ تتطابق مع التدوير الذي تحدده عبر API الكاميرا.

![لوحة PowerPoint 3-D Rotation مع تمييز قيم التدوير X، Y، Z](img_02_01.png)

في Aspose.Slides، عيّن نوع الكاميرا والدوران عبر تنسيق 3D المرتجع من [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat):

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

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغير ذلك هندسة الشكل الثنائية الأبعاد على الشريحة؛ بل يغير منظور العرض ثلاثي الأبعاد المستخدم من قبل PowerPoint وAspose.Slides عند التصيّر.

## **إضافة بثق وعمق**

البثق يجعل الشكل يبدو سميكًا بتمديده خلف الوجه الأمامي. في PowerPoint، يتحكم إعداد العمق في هذا السُمك الظاهر، وتتحكم إعدادات اللون في لون وجوه الجوانب.

![ضوابط العمق في PowerPoint المرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

عيّن ارتفاع البثق للسمك ولون البثق للجانب:

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

استخدم إعداد العمق عندما تحتاج إلى العمل مباشرةً مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة، المادة، وتأثيرات النص. في العديد من سيناريوهات الشكل، يُعد ارتفاع البثق الإعداد الأكثر وضوحًا لأنه يعبّر مباشرةً عن البثق الظاهر.

## **استخدام تعبئة بالتدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب، أو تدرج، أو نمط، أو تعبئة صورة على الوجه الأمامي ويبقى بإمكانك استخدام نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تعبئة بالتدرج على الشكل ولون بثق داكن على الجوانب:

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

المخرج المصيّر يحافظ على التدرج على الوجه الأمامي ويصيّر البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مصيّر بتدرج أزرق إلى برتقالي وتطبيق بسطن برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

الصورة تُصَيّر على الوجه الأمامي، بينما يُصَيّر البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مصيّر بتعبئة صورة على الوجه الأمامي وتطبيق بسطن برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الحروف نفسها إلى بثق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بتعبئة نمط، يطبق تحويل WordArt، ويضبط إعدادات ثلاثية الأبعاد على [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/):

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

النص يُصَيّر كحروف ثلاثية الأبعاد منحنية ومُبَثق:

![نص ثلاثي الأبعاد مصيّر بتحويل WordArt مقوس وتعبئة نمط برتقالية وبثق غامق](img_02_05.png)

## **سلوك التصدير والتصيّر**

Aspose.Slides يحتفظ بتنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند التصيّر أو التصدير إلى صيغ ذات تخطيط ثابت، يتم تحويل مشهد 3D إلى نقطية أو رسم داخل المخرج بنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تُصِيّر الشرائح إلى PNG، أو تصدير إلى PDF، أو HTML، أو توليد إطارات لتحويل الفيديو.

احتفظ بهذه النقاط في الاعتبار:

- الصور وملفات PDF المصدَّرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، وإضاءة Rig، والمادة، والبثق، والتعبئة، وتوسيع الشريحة.
- إذا احتجت إلى فحص قيم التنسيق الموروثة أو القائمة على السمة، استخدم API التنسيق الفعّال.
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك الصيغ، يتم تصيير النتيجة المرئية بدلاً من الحفاظ عليها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

Aspose.Slides ينشئ ويصيّر تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدَّرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث يدعم الصيغة ذلك.

**ما الفرق بين النموذج الثلاثي الأبعاد والتأثير الثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد منفصل يُدرج في العرض التقديمي. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل التدوير، البثق، الحافة، الإضاءة، والمادة. يغطي هذا المقال التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، عيّن دوران الكاميرا وإما البثق أو العمق. في الممارسة العملية، عيّن أيضًا إضاءة Rig والمادة لكي تكون الوجوه المصيّرة ذات إضاءات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟**

نعم. استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat) لجسم الشكل و[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat) للنص.

**هل ستظهر التأثيرات الثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. Aspose.Slides يصيّر التأثيرات الثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات تُستخدم لتحويل الفيديو. يحتوي المخرج المصدّر على المظهر المصيّر، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

**هل يمكنني قراءة القيم الثلاثية الأبعاد النهائية بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getEffective) لقراءة الكاميرا النهائية، وإضاءة Rig، والحافة، والقيم الثلاثية الأبعاد المرتبطة.