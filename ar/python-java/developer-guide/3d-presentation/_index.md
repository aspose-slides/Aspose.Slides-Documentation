---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام Python
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/python-java/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثرق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال ونصوص PowerPoint في Python عبر Java باستخدام Aspose.Slides. ضبط الكاميرا، الإضاءة، المادة، البثرق، التعبئات، والنص الثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يمكنه إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. يغطي هذا المقال تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، التعبئات المتدرجة أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="ملاحظة" %}}

هذا المقال يتناول تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا يتناول إدراج أو تحرير ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بعرض تلك التأثيرات الثلاثية الأبعاد في الإخراج الثنائي الأبعاد.

{{% /alert %}}

ثبت الحزمة كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides`، يبدأ JVM إذا لزم الأمر، ثم يستورد الـ API. مثال تعبئة الصورة يتطلب ملف `image.jpg` في دليل العمل.

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. كائن التنسيق المرتجع يتحكم في المشهد الثلاثي الأبعاد لهذا الشكل.

للنص، استخدم [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat). هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلًا من جسم الشكل.

أهم أعضاء الـ API هي:

| عضو API | ما الذي يتحكم فيه | متى يستخدم |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getCamera) | نقطة المشاهدة، نوع الكاميرا الافتراضي، الدوران، التكبير، والمنظر. | لتدوير الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد في PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getLightRig) | إعداد الضوء الافتراضي، الاتجاه، ودوران الضوء. | لتغيير مظهر الإضاءة والظلال على السطح الثلاثي الأبعاد. |
| [getMaterial](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setMaterial) | مادة السطح، مثل مسطح، غير لامع، بلاستيك أو معدن. | لجعل الشكل نفسه يبدو مسطحًا أكثر، ناعمًا، لامعًا أو معدنيًا. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setExtrusionHeight) | مقدار بروز الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك يُرى بوضوح. |
| [getExtrusionColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getExtrusionColor) | لون الجوانب البارزة. | إظهار العمق أو تنسيق لون الجانب مع التعبئة الأمامية. |
| [getDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setDepth) | عمق ثلاثي الأبعاد إضافي يُستخدم من قبل تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحواف والمادة. |
| [getBevelTop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getBevelBottom) | حواف مرتفعة أو مدورة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مُقَوَّسة بدلاً من وجه مسطح حاد. |
| [getContourColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getContourColor)، [getContourWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#setContourWidth) | حدود حول الكائن الثلاثي الأبعاد. | إبراز حدود الكائن في الإخراج المُصوَّر. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثيًا بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الضوء، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سمك.

المثال التالي يُنشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيقًا ثلاثيًا الأبعاد، يحفظ العرض كملف PPTX، ويعرض الشريحة كصورة PNG.

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

الصورة المصدَّرة تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل أزرق ثلاثي الأبعاد مُصوَّر مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **تدوير الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران الثلاثي الأبعاد من لوحة "3‑D Rotation". قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر API الكاميرا.

![لوحة 3‑D Rotation في PowerPoint مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، اضبط نوع الكاميرا والدوران عبر تنسيق 3D الذي تُعيده [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat):

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

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يُغيّر ذلك الهندسة الثنائية الأبعاد للشكل على الشريحة. بل يغيّر وجهة النظر الثلاثية الأبعاد التي يستخدمها PowerPoint وAspose.Slides عند العرض.

## **إضافة بثق وعمق**

البثق يجعل الشكل يبدو سميكًا بامتداده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم في العمق في هذا السمك الظاهر، وتتحكم أداة التحكم في اللون في لون وجوه الجوانب.

![تحكمات العمق في PowerPoint مرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

اضبط ارتفاع البثق للسمك ولون البثق للون الجوانب:

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

استخدم إعداد العمق عندما تحتاج إلى العمل مباشرةً مع قيمة العمق في PowerPoint أو دمج العمق مع الحواف، المادة، وتأثيرات النص. في العديد من سيناريوهات الشكل، يكون ارتفاع البثق هو الإعداد الأكثر وضوحًا لأنه يعبر مباشرةً عن البثق الظاهر.

## **استخدام تعبئات متدرجة أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب، أو متدرج، أو نمط، أو تعبئة صورة على الوجه الأمامي ولا يزال بإمكانك استخدام نفس إعدادات الكاميرا، الضوء، المادة، والبثق.

هذا المثال يطبق تعبئة متدرجة على الشكل ولون بثرق أغمق للجوانب:

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

الإخراج المصدَّر يحتفظ بالمتدرج على الوجه الأمامي ويعرض البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مُصوَّر بتعبئة متدرجة من الأزرق إلى البرتقالي وبثرق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض وعيّنها كتعبئة الشكل:

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

الصورة تُعرض على الوجه الأمامي، بينما يُعرض البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مُصوَّر بتعبئة صورة على الوجه الأمامي وبثرق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الأحرف نفسها إلى بثرق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي يُنشئ نصًا بتعبئة نمط، يطبق تحويل WordArt، ويضبط إعدادات 3D على [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/):

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

النص يُعرض كحروف ثلاثية الأبعاد مقوسة ومُبثقة:

![نص ثلاثي الأبعاد مُصوَّر بتحويل WordArt مقوس، تعبئة نمط برتقالي، وبثرق داكن](img_02_05.png)

## **سلوك التصدير والعرض**

Aspose.Slides يحتفظ بتنسيق ثلاثي الأبعاد عند الحفظ إلى تنسيقات PowerPoint مثل PPTX. عند العرض أو التصدير إلى تنسيقات ثابتة، يتم تحويل المشهد الثلاثي الأبعاد إلى رسومي أو يُرسم في الإخراج كناتج ثنائي الأبعاد. ينطبق ذلك عند عرض الشرائح إلى PNG، أو تصدير إلى PDF، أو تصدير إلى HTML، أو إنشاء إطارات لتحويل الفيديو.

ضع هذه النقاط في الاعتبار:

- الصور وملفات PDF المُصدَّرة غير تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- الشكل النهائي يعتمد على مزيج الكاميرا، مجموعة الإضاءة، المادة، البثرق، التعبئة، وتكبير الشريحة.
- إذا احتجت إلى فحص القيم الموروثة أو القيم المستندة إلى السمة، استخدم API التنسيق الفعّال.
- بعض تنسيقات الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك التنسيقات، يتم عرض النتيجة بصريًا بدلًا من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

Aspose.Slides يخلق ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المُصدَّرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلًا للتحرير في PowerPoint حيث يدعم التنسيق ذلك.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي مستقل يتم إدراجه في العرض. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. هذا المقال يغطي التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، اضبط دوران الكاميرا إما البثق أو العمق. عمليًا، يفضَّل أيضًا ضبط مجموعة الإضاءة والمادة حتى تكون الوجوه المُعرضة واضحة مع إبرازات وظلال.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟**

نعم. استخدم [Shape.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getThreeDFormat) لجسم الشكل و[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#getThreeDFormat) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور، PDF، HTML، أو إطارات فيديو؟**

نعم. Aspose.Slides يعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، إصدارات PDF، إصدارات HTML، وإطارات تُستخدم لتحويل الفيديو. الإخراج المُصدَّر يحتوي على المظهر المصدَّر، وليس ككائن ثلاثي الأبعاد قابل للتحرير.

**هل يمكنني قراءة القيم النهائية الثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/#getEffective) لقراءة الكاميرا النهائية، مجموعة الإضاءة، الحافة، والقيم الثلاثية الأبعاد المرتبطة.