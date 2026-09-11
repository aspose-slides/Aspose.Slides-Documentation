---
title: تنسيق أشكال PowerPoint في Python عبر Java
linktitle: تنسيق الأشكال
type: docs
weight: 20
url: /ar/python-java/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط شكل رسومي تخطيطي
- تنسيق نمط الوصلة
- تعبئة متدرجة
- تعبئة بنمط
- تعبئة بصورة
- تعبئة بنقشة
- تعبئة بلون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بتدرج الرمادي
- تدوير الشكل
- تأثير بيفيل ثلاثي الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في Python عبر Java باستخدام Aspose.Slides — اضبط أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **المقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال بتحديد إعدادات تتحكم في كيفية تعبئة داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides للغة Python عبر Java فئات وأساليب تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. توضح الخطوات التالية الإجراء:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب مؤشرها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [line style](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. ضبط [dash style](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linedashstyle/) للخط.
1. ضبط لون الخط للشكل.
1. حفظ العرض المُعدَّل كملف PPTX.

الشفرة التالية توضح كيفية تنسيق مستطيل [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) :

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

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # تعيين لون التعبئة لشكل المستطيل.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # تطبيق التنسيق على خطوط المستطيل.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # تعيين اللون لخط المستطيل.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # حفظ ملف PPTX إلى القرص.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُظهر تأثير الرسم التخطيطي أن خط الشكل يبدو كأنه مرسوم يدوياً. استخدم [Shape.getLineFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getLineFormat) للوصول إلى إعدادات الخط، و[LineFormat.getSketchFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/lineformat/#getSketchFormat) للوصول إلى إعدادات الرسم التخطيطي، و[SketchFormat.setSketchType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sketchformat/#setSketchType) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linesketchtype/) .

الشفرة بايثون التالية توضح كيفية تطبيق تأثير [LineSketchType.Curved](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linesketchtype/#Curved) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType.None_](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linesketchtype/#None) :

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

القيمة التي تُرجِعها [SketchFormat.getSketchType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sketchformat/#getSketchType) تمثل الإعداد المعين مباشرةً للشكل. إذا كان تنسيق الخط يمكن وراثته من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [LineFormat.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/lineformat/#getEffective)، وابدأ بـ `LineFormatEffectiveData.getSketchFormat`، ثم اقرأ `SketchFormatEffectiveData.getSketchType`. القيمة الفعّالة تعكس التنسيق المطبق فعلياً بعد حل الوراثة:

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

فيما يلي ثلاثة خيارات لنوع الوصلات:

* مستديرة
* مِيتَر
* منحدر

افتراضيًا، عندما يجمع PowerPoint خطين بزاوية (مثل زاوية الشكل)، يستخدم الإعداد **مستديرة**. ومع ذلك، إذا كنت ترسم شكلاً بزاويا حادة، قد تفضّل خيار **مِيتَر**.

![نمط الوصلة في العرض](join-style-powerpoint.png)

الشفرة بايثون التالية توضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصلة مِيتَر، منحدر، ومستديرة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة ثلاثة أشكال تلقائية من النوع Rectangle.
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

    # تعيين اللون لخط كل مستطيل.
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

    # حفظ ملف PPTX إلى القرص.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعبئة متدرجة**

في PowerPoint، تُعد تعبئة المتدرجة خيار تنسيق يتيح لك تطبيق تدرج مستمر من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بطريقة يتلاشى فيها أحدهما تدريجياً في الآخر.

إليك كيفية تطبيق تعبئة متدرجة على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب مؤشرها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين مع تحديد المواقع باستخدام طريقة [addPresetColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/gradientstopcollection/#addPresetColor) لمجموعة نقاط التوقف المتدرجة التي تُعرض عبر فئة [GradientFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/gradientformat/) .
1. حفظ العرض المُعدَّل كملف PPTX.

الشفرة بايثون التالية توضح كيفية تطبيق تأثير تعبئة متدرجة على قطع ناقص:

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

    # إضافة شكل تلقائي من النوع Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # تطبيق تنسيق تدرج على الشكل البيضاوي.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # تحديد اتجاه التدرج.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # إضافة نقطتي توقف للمتدرج.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # حفظ ملف PPTX إلى القرص.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![القطع الناقص مع تعبئة متدرجة](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تُعد تعبئة بنمط خيار تنسيق يسمح لك بتطبيق تصميم ثنائي اللون—مثل النقاط أو الشرائط أو المتعرجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لمقدمة النمط وخلفيته.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقه على الأشكال لتعزيز جاذبية عروضك البصرية. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي سيستخدمها.

إليك كيفية تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب مؤشرها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمط من الخيارات المسبقة.
1. ضبط [Background Color](https://reference.aspose.com/slides/ar/python-java/aspose.slides/patternformat/#getBackColor) للنمط.
1. ضبط [Foreground Color](https://reference.aspose.com/slides/ar/python-java/aspose.slides/patternformat/#getForeColor) للنمط.
1. حفظ العرض المُعدَّل كملف PPTX.

الشفرة بايثون التالية توضح كيفية تطبيق تعبئة بنمط على مستطيل:

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

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # تعيين نمط النقشة.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # تعيين ألوان الخلفية والواجهة للنقشة.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # حفظ ملف PPTX إلى القرص.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![المستطيل مع تعبئة بنمط](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تُعد تعبئة الصورة خيار تنسيق يسمح لك بإدراج صورة داخل شكل—أي استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب مؤشرها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) للشكل إلى `Picture`.
1. ضبط وضعية تعبئة الصورة إلى `Tile` (أو وضعية أخرى مفضلة).
1. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `SlidesPicture.setImage` .
1. حفظ العرض المُعدَّل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الشفرة بايثون التالية توضح كيفية تعبئة شكل بالصورة:

```python
import jpway
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # تعيين نوع التعبئة إلى Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # تعيين وضعية تعبئة الصورة.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # تحميل صورة وإضافتها إلى موارد العرض التقديمي.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # تعيين الصورة.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # حفظ ملف PPTX إلى القرص.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الشكل مع تعبئة صورة](picture-fill.png)

### **تكرار الصورة كنقش**

إذا رغبت في تعيين صورة مكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الأساليب التالية من فئة [PictureFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#setPictureFillMode): يضبط وضعية تعبئة الصورة—إما `Tile` أو `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#setTileAlignment): يحدد محاذاة المربعات داخل الشكل.
- [setTileFlip](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#setTileFlip): يتحكم ما إذا كان المربع يُقلب أفقياً أو عمودياً أو كلياً.
- [setTileOffsetX](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#setTileOffsetX): يضبط الإزاحة الأفقية للمربع (بالنقاط) من أصل الشكل.
- [setTileOffsetY](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#setTileOffsetY): يضبط الإزاحة العمودية للمربع (بالنقاط) من أصل الشكل.
- [setTileScaleX](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#setTileScaleX): يحدد النسبة المئوية لتوسيع المربع أفقياً.
- [setTileScaleY](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#setTileScaleY): يحدد النسبة المئوية لتوسيع المربع عمودياً.

الشفرة التالية توضح كيفية إضافة شكل مستطيل مع تعبئة صورة مكررة وتكوين خيارات المربعات:

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

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # تعيين نوع التعبئة للشكل إلى Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # تعيين الصورة إلى الشكل.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # تكوين وضعية تعبئة الصورة وخصائص التبليط.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # حفظ ملف PPTX إلى القرص.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![خيارات التكرار](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تُعد تعبئة بلون صلب خيار تنسيق يملأ الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو نقوش أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب مؤشرها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين لون التعبئة المفضل للشكل.
1. حفظ العرض المُعدَّل كملف PPTX.

الشفرة بايثون التالية توضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

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

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # تعيين نوع التعبئة إلى Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # تعيين لون التعبئة.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # حفظ ملف PPTX إلى القرص.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الشكل مع تعبئة لون صلب](solid-color-fill.png)

## **ضبط الشفافية**

في PowerPoint، عند تطبيق تعبئة بلون صلب أو متدرجة أو صورة أو نقش على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في مدى وضوح التعبئة. كلما ارتفعت قيمة الشفافية، أصبح الشكل أكثر شفافية، مما يسمح للعنصر الخلفي أو الكائنات السفلية بأن تكون مرئية جزئياً.

تتيح لك Aspose.Slides ضبط مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب مؤشرها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) إلى `Solid`.
1. استخدم [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) لتعريف لون بشفافية (مكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الشفرة بايثون التالية توضح كيفية تطبيق لون تعبئة شفاف على مستطيل:

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

    # إضافة شكل مستطيل صلب تلقائي.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # إضافة شكل مستطيل شفاف تلقائي فوق الشكل الصلب.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # حفظ ملف PPTX إلى القرص.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون هذا مفيدًا عند وضع العناصر البصرية بمواضع تحتاج إلى محاذاة أو تصميم معين.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب مؤشرها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. ضبط خاصية الدوران للشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الشفرة بايثون التالية توضح كيفية تدوير شكل بمقدار 5 درجات:

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

    # إضافة شكل تلقائي من النوع Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # تدوير الشكل بمقدار 5 درجات.
    shape.setRotation(5)

    # حفظ ملف PPTX إلى القرص.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات بيفيل ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات بيفيل ثلاثية الأبعاد على الأشكال من خلال تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات بيفيل ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب مؤشرها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/) للشكل لتحديد إعدادات البيفيل.
1. حفظ العرض.

الشفرة بايثون التالية توضح كيفية تطبيق تأثيرات بيفيل ثلاثية الأبعاد على شكل:

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

    # إضافة شكل إلى الشريحة.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # تعيين خصائص ThreeDFormat للشكل.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تأثير البيفيل ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال من خلال تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/threedformat/) الخاصة بها.

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بحسب مؤشرها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى الشريحة.
1. استخدم الطريقتين [setCameraType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/camera/#setCameraType) و[setLightType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/lightrig/#setLightType) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض.

الشفرة بايثون التالية توضح كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

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

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في العرض بالأبيض والأسود للأشكال**

تحدد الطريقة [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setBlackWhiteMode) كيفية عرض شكل فردي عندما يُعرض أو يُعالج عرضاً بوضع الأبيض والأسود. لا تقوم هذه الطريقة بتمكين العرض بالأبيض والأسود بحد ذاتها، ولا تغيّر تعبئة الشكل أو حدوده أو تنسيقه في وضع اللون العادي.

استخدم قيمة من فئة [BlackWhiteMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يترك تطبيق العرض يختار التحويل، و`Gray` و`LightGray` يستخدمان اللون الرمادي، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يفرضان لونًا واحدًا، و`Color` يحافظ على الألوان العادية، و`Hidden` يزيل الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

الشفرة بايثون التالية تنشئ شكلاً ملونًا وتجعله يظهر باللون الرمادي في وضع العرض بالأبيض والأسود:

```python
import jpype
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

    # احتفظ بالتعبئة البرتقالية في وضع اللون، ولكن اعرض الشكل بلون رمادي في وضع الأسود والأبيض.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

في وضع اللون العادي، يحتفظ المستطيل بتعبئته البرتقالية. في سير عمل العرض بالأبيض والأسود، يستخدم اللون الرمادي لأن وضعه محدد إلى `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو أي سير عمل آخر يحترم إعدادات العرض بالأبيض والأسود للعرض.

## **إعادة تعيين التنسيق**

الشفرة بايثون التالية توضح كيفية إعادة تعيين تنسيق شريحة وإرجاع الموقع والحجم وتنسيق جميع الأشكال التي بها عناصر نائب إلى إعداداتهم الافتراضية على [LayoutSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/) :

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

بشكل طفيف فقط. الصور والوسائط المدمجة تشغل الجزء الأكبر من حجم الملف، بينما معلمات الشكل مثل الألوان وال تأثيرات والتدرجات تُخزن كبيانات وصفية وتضيف حجمًا ضئيلًا تقريبًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في تنسيق متماثل لتجميعها؟**

قارن الخصائص التنسيقية الرئيسية لكل شكل—التعبئة، الخط، وإعدادات التأثير. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متماثلة وقم بتجميع تلك الأشكال منطقيًا، ما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصص في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ أشكالًا عينة ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات التنسيق المطلوب، وأعد تطبيق تنسيقها حسب الحاجة.