---
title: إدارة أشكال العروض التقديمية في Python عبر Java
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/python-java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل Interop
- نص بديل للشكل
- نقطة ضبط الشكل
- ضبط شكل مُعرَّف مسبقًا
- هندسة الشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- قلب الشكل
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية تحديد، ضبط، استنساخ، إزالة، إخفاء، إعادة ترتيب، تصدير، محاذاة، وقلب أشكال العروض التقديمية باستخدام Aspose.Slides for Python عبر Java."
---
## **نظرة عامة**

تمثل مكتبة Aspose.Slides for Python عبر Java الأشكال على الشريحة كمجموعة مرتبة من [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/). تُستخدم المجموعة لتحديد وتعديل الأشكال، كما تُعرّف ترتيب تكدسها: الفهرس `0` هو الشكل الأبعد في الخلفية، بينما الفهرس الأخير هو الشكل الأقرب إلى الواجهة.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية تحديد الشكل بصورة موثوقة وتعديل نقاط الضبط المعرّفة مسبقًا، ثم يوضح كيفية استنساخ، حذف، إخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق المستوى التخطيطي، تصدير SVG، المحاذاة، وإعدادات الانعكاس. كل مثال مستقل، لذا يمكنك استخدام العمليات التي يحتاجها سير عملك فقط.

## **تحديد وإيجاد الأشكال**

تُعد فهارس المجموعة مريحة عند معالجة ملف معروف، لكنها ليست معرّفات ثابتة. يمكن أن تُغيّر إضافة أو حذف أو إعادة ترتيب شكل فهرسه. اختر معرّفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getName) مفيد للقوالب التي يتحكم فيها المطور وسهل الفحص في جزء الاختيار داخل PowerPoint. يمكن تعديل الأسماء ولا يُضمن أن تكون فريدة، لذا ضع قاعدة تسمية إذا كانت الشيفرة تعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getAlternativeText) مفيد عندما تكون الوصف الأخلاقي أو العلامة التي يضيفها المؤلف قد حددت الشكل بالفعل. يُظهر للمستخدمين، قد يُترجم أو يُعاد كتابته للتمكين، ولا يُضمن أن يكون فريدًا. لا تُعيد استخدام نص الوصف المهم كمفتاح قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getOfficeInteropShapeId) هو معرّف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم من قبل PowerPoint interop. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع لا غنى عنه طوال فترة وجود الشكل. الشكل المستنسخ أو المُعاد إنشاؤه يُعطى معرفًا مختلفًا.

الطريقة المرتبطة [getUniqueId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getUniqueId) تُعيد معرّفًا بنطاق العرض التقديمي، لكن هذا المعرف مخصص للإضافات ويمكن إعادة تعيينه. لا يجب اعتباره مفتاحًا خارجيًا دائمًا. إذا كان الهوية طويلة الأمد ضرورية، احفظ التناظر في بيانات التطبيق وتأكد من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث عن اسم باستخدام مقارنة دقيقة ويُظهر معرف interop النطاق الشريحي. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن ذلك بدلاً من المتابعة مع الكائن الخطأ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

عند أن العملية خاصة بنوع شكل معين، تحقّق من النوع قبل استخدام الأعضاء الخاصة بالنوع. يُحدِّث هذا المثال النص والنص البديل فقط إذا كان الكائن المُسمّى هو [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **تحديد وتعديل ضبط الشكل المعرّف مسبقًا**

يمكن لأشكال الهندسة المعرّفة مسبقًا إظهار نقاط ضبط تتحكم في ميزات مثل حجم الزوايا، نسب السهم، أو زوايا القوس. يمكن الوصول إليها عبر مجموعة القراءة فقط [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ar/python-java/aspose.slides/geometryshape/#getAdjustments). تُقدّم المجموعة نفسها من قبل الشكل، لكن كل [AdjustValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/) يحتوي على قيمة يمكن تعديلها.

لا تعتمد فقط على فهرس ثابت للمجموعة. كرّر عبر الضبط وتفحص طريقة القراءة فقط [getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getType)، التي تُعيد قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/) التي تصف ما يتحكم به الضبط. تُوفر طريقة القراءة فقط [getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getName) معلومات تعريف إضافية وهي مفيدة خصوصًا عندما يحتوي الضبط المعرّف مسبقًا على أكثر من ضبط من نفس النوع الدلالي.

استخدم طريقة القيمة التي تتوافق مع معنى الضبط:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | حجم الزوايا المدورة | [setRawValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | سماكة ذيل السهم | [setRawValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | طول رأس السهم | [setRawValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | عرض رأس السهم | [setRawValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | زاوية البدء لقطة أو قوس | [setAngleValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | زاوية النهاية لقطة أو قوس | [setAngleValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setAngleValue) |

تُعيد [getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getType) و[getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getName) معلومات للقراءة فقط. يعمل [getRawValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getRawValue) و[setRawValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setRawValue) مع عدد صحيح بوحدات الهندسة الأصلية للضبط، بينما يعمل [getAngleValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getAngleValue) و[setAngleValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setAngleValue) مع زاوية بالدرجات. يعتمد عدد، ترتيب، معنى، ونطاق الضبط الصالح على [ShapeType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/geometryshape/#getShapeType) المعرّف مسبقًا. قد تكون القيمة الصالحة لضبط واحد غير صالحة أو لها تأثير مختلف لضبط آخر.

عندما تُعيد [getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getType) [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#Custom)، لا تتعرف الواجهة البرمجية على معنى دلالي قياسي. افحص [getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getName)، نوع الضبط المعرّف مسبقًا، والقيمة الحالية، واترك الضبط دون تغيير ما لم يكن المعنى والنطاق معروفين. حتى للأنواع المعروفة، تحقق ما إذا كان النوع نفسه يظهر أكثر من مرة قبل اختيار قيمة. تُظهر مقالة [Connector](/slides/ar/python-java/connector/) هذه الحالة مع ضبط انحناءات الموصل.

المثال الكامل التالي يخلق إصدارات افتراضية ومعدّلة لثلاثة أشكال مُعرّفة مسبقًا. يكرّر عبر كل ضبط، يُبلغ عن اسمه ونوعه، يغيّر القيم المتعلقة بالحجم عبر [setRawValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setRawValue)، يغيّر الزوايا عبر [setAngleValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setAngleValue)، ويحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المدور المعدل، السهم رباعي الاتجاهات، والقطعة الدائرية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # يضيف رؤوسًا لأعمدة الشكل الافتراضية والمعدلة.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

التحقق من النوع الدلالي قبل تغيير قيمة يجعل الشيفرة صريحة بشأن نيتها ويتجنّب الافتراض بأن فهرس مجموعة ثابت يحمل نفس المعنى عبر أشكال مُعرّفة مسبقًا مختلفة.

## **تعديل مجموعة الأشكال**

تُطبق طرق الإضافة، الاستنساخ، الحذف، وإعادة الترتيب على المجموعة فورًا. إذا غيرت عملية ما عدد أو ترتيب الأشكال، لا تواصل الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addClone) يخلق نسخة مستقلة ويضيفها إلى نهاية المجموعة الهدف. [insertClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#insertClone) يخلق نسخة أيضًا لكنه يضعها عند فهرس z-order محدد. التحميل الزائد الذي يقبل إحداثيات يحرك النسخة دون تغيير حجمها؛ التحميل الزائد الذي يحدد العرض والارتفاع يمكنه تغيير الحجم كذلك.

المثال يخلق شريحة هدف، يستنسخ مستطيلًا معنونا إلى الأمام، ويُدخل نسخة ثانية إلى الخلف. لا تُغيّر أي من النسختين المصدر.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرّفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. تُدار الموارد المستخدمة بواسطة الأشكال المعقّدة من قبل العرض التقديمي، لكن النسخة تظل عنصر مجموعة جديد بمعرف شكل جديد.

### **حذف أشكال**

[remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#remove) يحذف كائن شكل محدد من مجموعته. عند حذف تطابقات متعددة أثناء التكرار بالفهارس، تجوَّل من النهاية بحيث يظل كل فهرس متبقٍ صالحًا.

المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل عند الفهرس الحالي، وليس عنصر مجموعة ثابت، ولا يتحوّل الشكل إلى نوع آخر دون ضرورة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

بعد الحذف، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تبقى الإشارات إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك الموصلات، الرسوم المتحركة، وميزات العرض الأخرى التي قد تشير إلى الكائن المحذوف؛ حذف شكل مرئي قد يغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

ضبط [Hidden](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setHidden) إلى `True` يبقي الشكل في المجموعة لكنه يمنعه من الظهور في عرض الشرائح العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للشيفرة، لذا يُعد الإخفاء مناسبًا للعناصر الاختيارية التي قد تُستعاد لاحقًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بالإمكان اكتشاف الكائن وإظهاره مرة أخرى من قبل المستخدم أو الشيفرة، ويظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

تُرسم الأشكال المتداخلة بترتيب المجموعة. [reorder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#reorder) ينقل شكلًا موجودًا إلى فهرس الهدف دون استنساخه. الفهرس `0` هو الخلف؛ [size](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#size) ناقص واحد هو الأمام.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يُنشأ المستطيل أولًا ويقع في البداية خلف الشكل البيضاوي. نقله إلى الفهرس النهائي يجعله في الأمام. أنهِ ترتيب Z بعد إضافة أو استنساخ جميع الأشكال المرتبطة، لأن هذه العمليات تُضيف أو تُدخل عناصر مجموعة جديدة وقد تُغيّر التكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

تمتلك الشرائح العادية، وشرائح التخطيط، والشرائح السائدة مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس هو نفسه الشكل الموجود في شريحة عادية في موضع مشابه. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تعديل التنسيق الذي توفره التخطيط.

المثال التالي يقرأ كل شكل تخطيط ويستخرج [FillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getFillFormat) و[LineFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getLineFormat) دون افتراض أن كل شكل هو [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

يمكن لتعديل التخطيط أن يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل التخطيط، حدّد ما إذا كانت شريحة عادية تُورث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

طريقة `writeAsSvg` من [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) تُكتب محتوى شكل واحد مُرسَم إلى تدفق. النتيجة تحتوي على الشكل فقط، لا الخلفية الكاملة للشريحة أو الأشكال المجاورة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

احتفظ بالعرض التقديمي مفتوحًا أثناء التصدير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت تحتاج إلى التكوين الكامل، صدّر الشريحة بدلاً من شكل فردي. يمتلك المُستدعي التدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

تُطابق التحميلات الزائدة [SlideUtil.alignShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/#alignShapes) إما كل الأشكال أو مؤشرات مجموعة مختارة. تُحدد [ShapesAlignmentType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapesalignmenttype/) الحافة، أو الخط المركزي، أو وضع التوزيع. اضبط `align_to_slide` إلى `True` لاستخدام حواف الشريحة؛ اضبطه إلى `False` لمطابقة الأشكال المحددة بالنسبة إلى بعضها البعض.

المثال يطابق ثلاثة أشكال إلى الحافة العليا للشريحة. تُحوَّل مراجع الأشكال المرجعة إلى فهارسها الحالية مباشرةً قبل المطابقة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

المطابقة تُغيّر المواقع، لا ترتيب Z. عادةً ما يحتاج المطابق النسبي إلى شكلين على الأقل، بينما يتطلب التوزيع الأفقي أو العمودي عددًا كافيًا من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **تدوير شكل**

تخزن فئة [ShapeFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeframe/) الموضع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. تُستخدم قيم [getFlipH](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeframe/#getFlipH) و[getFlipV](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeframe/#getFlipV) من نوع [NullableBool](https://reference.aspose.com/slides/ar/python-java/aspose.slides/nullablebool/): `True` يفعّل الانعكاس، `False` يعطله، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مُنعكس.

![The shape before flipping](shape_to_be_flipped.png)

المثال يحافظ على جميع قيم الإطار الأخرى ويستبدل فقط إعدادات الانعكاس الثنائية. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setFrame) جديد يحل محل الإطار الكامل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الشكل المحفوظ يُعكس أفقيًا وعموديًا مع الحفاظ على موضعه وحجمه ودورانه.

![The shape after flipping](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يجب علي استخدام فهرس المجموعة كمعرف للشكل؟**

فقط للمعالجة المؤقتة عندما لا تتغيّر المجموعة قبل استخدام الفهرس. يُفضَّل اعتماد [Name](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getName) أو [AlternativeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getAlternativeText) كمعيار للقوالب التي تم إنشاؤها، أو [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getOfficeInteropShapeId) لأعمال interop ذات نطاق الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر شكل مستنسخ في أمام شكل آخر؟**

[addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addClone) يضيف النسخة إلى نهاية المجموعة، وهي أمامية ترتيب Z. استخدم [insertClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#insertClone) لاختيار الفهرس الأولي أو [reorder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#reorder) بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد ضبط شكل مُعرّف مسبقًا؟**

فقط بعد التحقق من الضبط المعرّف مسبقًا وترتيب المجموعة بدقة. يُفضَّل التكرار عبر [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ar/python-java/aspose.slides/geometryshape/#getAdjustments) وفحص [AdjustValue.getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getType)؛ استخدم [AdjustValue.getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getName) كمعلومة إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.