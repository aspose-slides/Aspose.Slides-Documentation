---
title: تخصيص أشكال العروض التقديمية في Python عبر Java
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/python-java/custom-shape/
keywords:
- شكل مخصص
- إضافة شكل
- إنشاء شكل
- تغيير شكل
- هندسة الشكل
- مسار الهندسة
- نقاط المسار
- نقاط التحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة Python عبر Java: مسارات الهندسة، الزوايا المنحنية، الأشكال المركبة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تعديل هندسة الشكل عبر نقاط التحرير ومسارات الهندسة. تُظهر كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) لتعديل الأشكال الحالية، وتنفيذ عمليات تحرير أساسية للمسار، وإضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة مرة أخرى على الشكل.

كما توضح كيفية إنشاء أشكال مخصصة ومركبة، بناء أشكال ذات زوايا منحنية، تحديد ما إذا كانت هندسة الشكل مغلقة، فحص عناصر الشكل، وتحويل خطوط نص Java AWT إلى مسارات هندسية.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **Edit Points** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* تعديل الانحناء عند نقطة.
* إضافة نقاط جديدة.

تتيح لك تحرير النقاط تعديل حدود الشكل أو استخدام شكل موجود كأساس لشكل جديد.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

عند تحرير أشكال PowerPoint، ضع في اعتبارك هذه المفاهيم:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط ربط متصلة بقطعات.
* يمكن أن تكون القطعة مستقيمة أو منحنية. تحدد نقاط الربط ومقابض التحكم شكلها.
* توجد نقاط الربط ك نقاط زاوية، نقاط مستقيمة، أو نقاط ناعمة:
  * في نقطة الزاوية، يمكن أن تتقاطع القطع المتجاورة بزاوية.
  * في نقطة ناعمة، يتم محاذاة مقبضين التحكم ويكونان على مسافة متساوية من نقطة الربط.
  * في نقطة مستقيمة، يتم محاذاة مقبضين التحكم لكن قد تكون المسافات مختلفة عن نقطة الربط.
* تحريك نقاط الربط أو تعديل مقابضها يغيّر حدود الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* تمثل مثيلة [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) مسار هندسة كائن [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* لاسترداد [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) من مثيلة [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)، يمكنك استخدام طريقة [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) للأشكال ذات المسار الفردي و[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) للأشكال ذات مسارات متعددة.
* لإضافة قطعات، يمكنك استخدام الطرق الموجودة تحت [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* باستخدام طريقتي [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) و[GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode)، يمكنك تحديد مظهر مسار الهندسة.
* باستخدام طريقة [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData)، يمكنك استرداد مسار الهندسة لكائن [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) كمصفوفة من قطعات المسار.
* للوصول إلى خيارات تخصيص هندسة إضافية، يمكنك قراءة كائن [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) عبر ‎[PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) وإعادة تشغيل القطعات على [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **عمليات تحرير بسيطة**

استخدم الطرق التالية لتحرير مسار هندسي. تُدخل النسخ التي تقبل فهرسًا قطعة في ذلك الموضع الصفري الأساس في مصفوفة قطعات المسار.

| العملية | الطريقة |
| --- | --- |
| إلحاق أو إدراج خط مستقيم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| إلحاق أو إدراج منحنى بيزير مكعب مع نقطتي تحكم ونقطة نهائية. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| إلحاق أو إدراج منحنى بيزير رباعي مع نقطة تحكم واحدة ونقطة نهائية. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| إلحاق قوس بيضاوي بالأبعاد وزوايا محددة بالدرجات. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| إغلاق الشكل الحالي بربط نقطته النهائية بنقطة البداية. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| تعيين نقطة البداية لشكل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| إزالة قطعة في فهرس صفري الأساس. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **إضافة نقاط مخصصة إلى شكل**

هذا المثال يدخل نقطتين إلى شكل مستطيل باستخدام [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) ويطبق المسار المعدل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). الإحداثيات محلية إلى الشكل: كلا النقطتين الجديدتين في وسطه، على بعد 100 نقطة من اليسار و50 نقطة من الأعلى. يضع فهرسا القطعة 1 و4 النقطتين على الحافتين العلوية والسفلية، ساحبًا هاتين الحافتين إلى الداخل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **إزالة نقاط من شكل**

هذا المثال يغيّر مخطط القلب بإزالة القطعة في الفهرس الصفري الأساس 2 عبر [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). تطبيق المسار المعدل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) يحدث حدود الشكل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

هذا المثال يبني نجمة خماسية القمم باستخدام [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). تُعرّف نصف القطر الخارجي والداخلي المتناوب بـ 100 و50 نقطة لتحديد القمم والفراغات؛ خطوة 72 درجة توازن الخمس قمم بالتساوي. يُغلق المسار عبر [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) ويُطبق على شكل مستطيل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)، مستبدلًا مخططه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **إنشاء شكل مركب مخصص**

هذا المثال يعرّف مسارين مغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) للثلثين العلوي والسفلي من الشكل. تطبيق كلا المسارين عبر [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) يُنشئ شكلًا مركبًا واحدًا به فجوة عبر الثلث الأوسط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

هذا المثال يجمع قطعات مستقيمة مع [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) لإنشاء شكل بزوايا منحنية إلى الداخل. يحدد كل حجم زاوية عرض وارتفاع القوس بالنقاط، ويرسم قطاعًا بزاوية -90 درجة ربع إهليلجي عكس اتجاه عقارب الساعة. يُطبق المسار المكتمل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ويُحفظ العرض بصيغة PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **معرفة ما إذا كانت هندسة الشكل مغلقة**

يتحقق المساعد التالي ما إذا كان كل مسار هندسي غير فارغ ينتهي بقطعة إغلاق. يقرأ [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) ويقارن أمر القطعة النهائي ‎[PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) مع ‎[PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). يرجّع `False` عندما لا توجد مسارات غير فارغة. يتحقق هذا من الأمر النهائي لكل مسار؛ لا يفحص كل شكل فرعي داخل المسار. يطبع المثال `True` لمستطيل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **استخراج وفحص عناصر الشكل**

استخدم [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. حوّل كل عنصر عائد إلى [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) عبر `jpype.JObject` لاسترجاع مصفوفات النقاط والأنواع عبر طريقتي [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) و[getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). يُعد هذا التمثيل مفيدًا لتحليل الحدود أو تمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال `input.pptx`، يجد أول شكل هندسي مباشرة على الشريحة الأولى، ويطبع قطعات مساره. استخدم عرضًا يحتوي على شكل بقطعات مستقيمة ومنحنية لرؤية كلا النوعين من الإخراج. لا يبحث داخل المجموعات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # احتفظ بنوع القطعة، مع استبعاد الأعلام.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

المصفوفات متطابقة بحسب الفهرس: `points[i]` هي نقطة و`types[i]` تصف دورها. النوع `0` يبدأ شكلًا، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ القطعة المكعبة بيزير من نقطة النهاية السابقة وتستخدم ثلاث مداخل متتالية من النوع `3`: نقطتي تحكم ثم نقطة النهاية الجديدة. يُستهلك هذا الثلاثة معًا في الحلقة ويتحقق من نقطة النهاية للإغلاق.

تحتوي أنواع النقاط أيضًا على أعلام. قُم بعملية قناع بـ `0x07` لتحديد نوع القطعة، واختبر `0x80` منفصلًا لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تُغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزير تُغلق واحدًا. تخزن Java هذه الأعلام في بايتات موقّعة؛ القناع يحافظ على القيم البتية المقصودة. مقارنة القيمة الخام فقط بـ `1` أو `3` سيفوت هذه الحالات. الأعلام الأخرى، مثل الشرط (`0x10`) والعلامة (`0x20`)، لا تغيّر نوع القطعة الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، مع زيادة X نحو اليمين وزيادة Y نحو الأسفل. بالنسبة لشكل غير مجمع، تتضمن الإحداثيات المستخرجة بالفعل الموضع المسترجع عبر [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) و[getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) وتعكس عرضه وارتفاعه الحالي. على سبيل المثال، مستطيل غير مُدوَّر عند `(100, 200)` بحجم `120 × 80` له حدود حدودية `(100, 200)`–`(220, 280)`. لا تُضيف موضع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبةً إلى إطاره غير المدور.

النقاط المستخرجة لا تُطبق دوران الشكل المسترجع عبر [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation)، ولا الانعكاسات الأفقية والرأسية. لإعادة إنتاج الحدود المعروضة، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمّعة، احسب أيضًا خريطة إحداثيات المجموعة وتحويلاتها؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية أو تُطبق ترجمة أو مقياسًا مرتين إذا كان بالفعل مُعكسًا في إطار الطفل.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة الحدود؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا النهج عندما تحتاج إلى مصفوفات النقاط/الأنواع في تحليل أو كود رسم. استخدم [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) عندما تحتاج إلى أوامر هندسية في نظام إحداثيات الشكل المحلي أو لتعديل هندسته. طبّق المسارات المعدلة عبر [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) أو [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **تحويل شكل Java AWT إلى GeometryPath**

يجمع هذا المثال مخططًا مستطيلًا مع نص محوَّل إلى هندسة. تُعطّل طريقة [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) الملء للمخطط. يُنشئ [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) مخطط النص في كائن [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). يزوِّد ‎[PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) بحركات، خطوط، قطعات رباعية، مكعبية، وإغلاق، والتي يعيد المثال تشغيلها على ‎[GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

يستخدم النص خطًا Arial مقاسه 40 نقطة. يُزاح المخطط 20 نقطة أفقيًا ويُوضَع بحيث يكون أعلىه البصري 10 نقاط أسفل حافة أعلى الشكل. يُملأ مسار النص، بينما يبقى المستطيل الأصلي مخططًا فقط. يطبق كلا المسارين عبر [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) لتكوين شكل واحد يحتوي على المستطيل والنص.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # الحصول على مسار الهندسة للشكل.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # إنشاء مسار رسومي جديد بالنص.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # تحويل المسار الرسومي إلى مسار هندسي.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # تطبيق مسار النص مع مسار الهندسة الأصلي.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **الأسئلة المتكررة**

**ماذا سيحدث للملء والحد عند استبدال الهندسة؟**

يبقى النمط مرتبطًا بالشكل؛ فقط يتغيّر المخطط. يتم تطبيق الملء والحد تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع هندسته بشكل صحيح؟**

استخدم طريقة الشكل ‎[setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation)؛ فإن الهندسة تدور مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر منطقة [slide](/slides/ar/python-java/convert-powerpoint-to-png/) المطلوبة أو [shape](/slides/ar/python-java/create-shape-thumbnails/) نفسها إلى تنسيق نقطي؛ يبسط ذلك العمل اللاحق مع الهندسات المعقّدة.