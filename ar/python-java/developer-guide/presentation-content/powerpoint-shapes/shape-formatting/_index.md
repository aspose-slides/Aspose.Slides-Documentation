---
title: تنسيق أشكال PowerPoint في Python عبر Java
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/python-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط شكل مخطّط
- تنسيق نمط الوصل
- تعبئة تدرجية
- تعبئة نمطية
- تعبئة صورة
- تعبئة نسيج
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بالدرجات الرمادية
- تدوير الشكل
- تأثير بروز ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- العرض
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Python عبر Java باستخدام Aspose.Slides—حدد أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في كيفية تعبئة داخلها.

![تنسيق-الشكل-في-PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java يوفر فئات وطرق تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتوفرة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. توضح الخطوات التالية الإجراء:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) للشكل.
1. ضبط عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تنسيق مستطيل [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل تلقائي من نوع المستطيل.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # تعيين لون التعبئة للشكل المستطيل.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # تطبيق تنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # تعيين لون خط المستطيل.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # حفظ ملف PPTX على القرص.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

تجعل تأثيرات الرسم التخطيطي خط الشكل يبدو مرسومًا يدويًا. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) .

الكود التالي بلغة Python يوضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved) ، وقراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # الوصول إلى تنسيق الخط للشكل وتنسيق الرسم التخطيطي الخاص به.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # تطبيق تأثير رسم تخطيطي.
    sketch_format.setSketchType(LineSketchType.Curved)

    # قراءة تأثير الرسم التخطيطي المعين مباشرةً للشكل.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # إزالة تأثير الرسم التخطيطي.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

القيمة التي تُرجعها الدالة [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) تمثل الإعداد المعين مباشرةً للشكل. إذا كان يمكن توريث تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective)، وادخل إلى `LineFormatEffectiveData.getSketchFormat`، وقراءة `SketchFormatEffectiveData.getSketchType`. القيمة الفعلية تعكس التنسيق المطبق فعليًا بعد حل الوراثة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **تنسيق أنماط الوصلات**

إليك ثلاثة خيارات لأنواع الوصلات:

* Round
* Miter
* Bevel

بشكل افتراضي، عندما يجمع PowerPoint خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم الإعداد **Round**. مع ذلك، إذا كنت ترسم شكلًا بزاويا حادة، قد تفضّل خيار **Miter**.

![نمط الوصلة في العرض](join-style-powerpoint.png)

الكود التالي بلغة Python يوضح كيفية إنشاء ثلاثة مستطيلات (كما في الصورة أعلاه) باستخدام إعدادات نوع الوصلة Miter وBevel وRound :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة ثلاثة أشكال تلقائية من نوع المستطيل.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # تعيين لون التعبئة لكل شكل مستطيل.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # تعيين عرض الخط.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # تعيين لون خط كل مستطيل.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # تعيين نمط الوصلة.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # إضافة نص إلى كل مستطيل.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # حفظ ملف PPTX على القرص.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعبئة تدرجية**

في PowerPoint، تعبئة التدرج اللوني هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك كيفية تطبيق تعبئة تدرجية على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين الخاصية [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة لونين مفضلين مع مواقع محددة باستخدام طريقة [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) من مجموعة التدرجات التي يعرضها الفصل [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة Python يوضح كيفية تطبيق تأثير تعبئة تدرجية على قطع بيضاوية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل تلقائي من نوع Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # تطبيق تنسيق تدرج على القطعة البيضاوية.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # تعيين اتجاه التدرج.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # إضافة نقطتي توقف للتدرج.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # حفظ ملف PPTX على القرص.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![القطع الإهليلجي مع تعبئة تدرجية](gradient-fill.png)

إذا كان التدرج يبدو مختلفًا في الصورة المصدَّرة مقارنةً بما هو عليه في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير تعبئة التدرج المخزَّنة في العرض.

## **تعبئة نمطية**

في PowerPoint، تعبئة نمطية هي خيار تنسيق يتيح لك تطبيق تصميم بلونين—مثل النقاط أو الخطوط أو التعرجات أو المربعات—على الشكل. يمكنك اختيار ألوان مخصصة لخلفية النمط واللون الأمامي.

Aspose.Slides يقدم أكثر من 45 نمطًا نمطيًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز الجاذبية البصرية لعرضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب أن يستخدمها.

إليك كيفية تطبيق تعبئة نمطية على شكل باستخدام Aspose.Slides:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين الخاصية [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمطي من الخيارات المسبقة.
1. تعيين [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) للخلفية.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) للون الأمامي.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة Python يوضح كيفية تطبيق تعبئة نمطية على مستطيل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل تلقائي من نوع المستطيل.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى نمط.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # تعيين نمط النمط.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # تعيين ألوان الخلفية والواجهة للنمط.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # حفظ ملف PPTX على القرص.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![المستطيل مع تعبئة نمطية](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة صورة هي خيار تنسيق يسمح لك بإدراج صورة داخل الشكل—وبالتالي استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين الخاصية [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضعية تعبئة الصورة إلى `Tile` (أو وضعية مفضلة أخرى).
1. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `SlidesPicture.setImage`.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الكود التالي بلغة Python يوضح كيفية تعبئة الشكل بالصورة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل تلقائي من نوع المستطيل.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # تعيين نوع التعبئة إلى صورة.
    shape.getFillFormat().setFillType(FillType.Picture)

    # تعيين وضع تعبئة الصورة.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # تحميل صورة وإضافتها إلى موارد العرض.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # تعيين الصورة.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # حفظ ملف PPTX على القرص.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **تعيين صورة متكررة كملمس**

إذا أردت تعيين صورة متكررة كملمس وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من فصل [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): يحدد وضعية تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة المربعات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم فيما إذا كان المربع يُقلب أفقيًا أو عموديًا أو كليًا.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): يحدد الإزاحة الأفقية للمربع (بوحدات النقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): يحدد الإزاحة الرأسية للمربع (بوحدات النقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد مقياس المربع الأفقي كنسبة مئوية.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد مقياس المربع الرأسي كنسبة مئوية.

العينة التالية تُظهر كيفية إضافة شكل مستطيل بتعبئة صورة متكررة وتكوين خيارات التكرار:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    first_slide = presentation.getSlides().get_Item(0)

    # إضافة شكل تلقائي من نوع المستطيل.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # تعيين نوع التعبئة للشكل إلى صورة.
    shape.getFillFormat().setFillType(FillType.Picture)

    # تحميل الصورة وإضافتها إلى موارد العرض.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # تعيين الصورة إلى الشكل.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # تكوين وضع تعبئة الصورة وخصائص التبليط.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # حفظ ملف PPTX على القرص.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![خيارات التكرار](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة بلون صلب هي خيار تنسيق يملأ الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط بدون أي تدرجات أو أقمشة أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين الخاصية [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين اللون الصلب المفضل كملء للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة Python يوضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل تلقائي من نوع المستطيل.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # تعيين لون التعبئة.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # حفظ ملف PPTX على القرص.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الشكل مع تعبئة بلون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عندما تطبق تعبئة بلون صلب أو تدرج أو صورة أو نسيج على الأشكال، يمكنك أيضًا تعيين مستوى شفافية للتحكم في شفافية التعبئة. القيمة الأعلى للشفافية تجعل الشكل أكثر شفافية، مما يسمح بخلفية أو كائنات تحتية بأن تظهر جزئيًا.

Aspose.Slides يتيح لك تعيين مستوى الشفافية عبر ضبط قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين الخاصية [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) إلى `Solid`.
1. استخدام [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) لتعريف لون بشفافية (مكون `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الكود التالي بلغة Python يوضح كيفية تطبيق لون تعبئة شفاف على مستطيل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل تلقائي مستطيل صلب.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # إضافة شكل تلقائي مستطيل شفاف فوق الشكل الصلب.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # حفظ ملف PPTX على القرص.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

Aspose.Slides يتيح لك تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية مع متطلبات محاذاة أو تصميم معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. تعيين خاصية تدوير الشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الكود التالي بلغة Python يوضح كيفية تدوير شكل بزاوية 5 درجات:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل تلقائي من نوع المستطيل.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # تدوير الشكل بزاوية 5 درجات.
    shape.setRotation(5)

    # حفظ ملف PPTX على القرص.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات بروز ثلاثية الأبعاد**

Aspose.Slides يسمح لك بتطبيق تأثيرات بروز ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات بروز ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) لتحديد إعدادات البروز.
1. حفظ العرض.

الكود التالي بلغة Python يوضح كيفية تطبيق تأثير بروز ثلاثي الأبعاد على شكل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من فئة Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Add a shape to the slide.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Set the shape's ThreeDFormat properties.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تأثير البروز ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات تدوير ثلاثية الأبعاد**

Aspose.Slides يسمح لك بتطبيق تأثيرات تدوير ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) الخاصة بها.

لتطبيق تدوير ثلاثي الأبعاد على شكل:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. استخدام الطريقتين [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) و[setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) لتحديد التدوير ثلاثي الأبعاد.
1. حفظ العرض.

الكود التالي بلغة Python يوضح كيفية تطبيق تأثيرات تدوير ثلاثية الأبعاد على شكل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# إنشاء كائن من فئة Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # حفظ العرض كملف PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تأثير التدوير ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في عرض أبيض وأسود للأشكال**

طريقة [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) تحدد كيف يتم عرض شكل مفرد عندما يُعرض أو يُعالج العرض بوضع الأبيض والأسود. لا تقوم بتمكين وضع الأبيض والأسود بحد ذاتها، ولا تغير تعبئة الشكل أو خطه أو تنسيقه في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يترك التطبيق يختار التحويل، و`Gray` و`LightGray` يستخدمان اللون الرمادي، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يجبران اللون الواحد، و`Color` يحافظ على الألوان الطبيعية، و`Hidden` يحذف الشكل في وضع الأبيض والأسود. `NotDefined` يعني أنه لم يُعيّن وضع على مستوى الشكل.

الكود التالي بلغة Python ينشئ شكلًا ملونًا ويجعله يظهر باللون الرمادي في وضع عرض أبيض وأسود:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # احتفظ بتعبئة اللون البرتقالي في وضع اللون، ولكن اعرض الشكل بتلوين رمادي في وضع الأبيض والأسود.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

في وضع اللون العادي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل عرض أبيض وأسود، يستخدم اللون الرمادي لأن وضعه مضبوط على `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو أي سير عمل يراعي إعدادات عرض الأبيض والأسود.

## **إعادة تعيين التنسيق**

الكود التالي بلغة Python يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع الموضع والحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # إعادة ضبط كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

بصفة طفيفة فقط. الصور والوسائط المضمَّنة تشغل معظم مساحة الملف، بينما معلمات الشكل مثل الألوان والتأثيرات والتدرجات تُخزن كبيانات تعريفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في نفس التنسيق لكي أجمعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—التعبئة، الخط، وإعدادات التأثير. إذا كانت جميع القيم مطابقة، اعتبر أن أنماطها متماثلة وامجموعها منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقها حيثما دعت الحاجة.