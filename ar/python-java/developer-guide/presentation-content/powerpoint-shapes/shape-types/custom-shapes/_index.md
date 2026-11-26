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
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة Python عبر Java: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تعديل هندسة الشكل عبر نقاط التحرير ومسارات الهندسة. تظهر كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) لتعديل الأشكال الموجودة، وتنفيذ عمليات تحرير أساسية للمسار، وإضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة على الشكل.

كما توضح كيفية إنشاء أشكال مخصصة ومركبة، بناء أشكال بزايا منحنية، تحديد ما إذا كانت هندسة الشكل مغلقة، فحص عناصر الشكل، وتحويل مخططات نص Java AWT إلى مسارات هندسية.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **Edit Points** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* ضبط الانحناء عند نقطة.
* إضافة نقاط جديدة.

تتيح لك تحرير النقاط تعديل مخطط الشكل أو استخدام شكل موجود كأساس لخلق شكل جديد.

## **نصائح تحرير الشكل**

![صورة نظرة عامة](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على مراعاة المفاهيم التالية:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط ارتكاز مرتبطة بشرائح.
* يمكن أن يكون الشريحة مستقيمًا أو منحنيًا. تحدد نقاط الارتكاز ومقابض التحكم شكله.
* توجد نقاط الارتكاز كنقاط زاوية أو نقاط مستقيمة أو نقاط ناعمة:
  * في نقطة الزاوية، يمكن للشرائح المتجاورة أن تلتقي بزاوية.
  * في نقطة ناعمة، يتم محاذاة مقبضي التحكم ويتساويان في البُعد عن نقطة الارتكاز.
  * في نقطة مستقيمة، يتم محاذاة مقبضي التحكم لكن قد يكونا على مسافات مختلفة عن نقطة الارتكاز.
* تحريك نقاط الارتكاز أو تعديل مقابضها يغير مخطط الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* تمثل مثيل [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) مسارًا هندسيًا لكائن [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* لاسترداد [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) من مثيل [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)، يمكنك استخدام طريقة [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) للأشكال ذات المسار الواحد و[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) للأشكال ذات المسارات المتعددة.
* لإضافة شرائح، يمكنك استخدام الطرق المتاحة ضمن [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* باستخدام طريقتي [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) و[GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode)، يمكنك تحديد مظهر مسار الهندسة.
* باستخدام طريقة [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData)، يمكنك استرجاع مسار الهندسة لكائن [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) كمصفوفة من شرائح المسار.
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك قراءة [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) عبر [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) الخاص به وإعادة تشغيل الشرائح على [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **عمليات التحرير البسيطة**

استخدم الطرق التالية لتحرير مسار هندسي. تُدرج النسخ المتعددة التي تقبل فهرسًا شريحةً في ذلك الموضع الصفري في مصفوفة شرائح المسار.

| العملية | الطريقة |
| --- | --- |
| إضافة أو إدراج خط مستقيم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| إضافة أو إدراج منحنى بيزييه مكعب مع نقطتي تحكم ونقطة نهائية. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| إضافة أو إدراج منحنى بيزييه تربيعي مع نقطة تحكم واحدة ونقطة نهائية. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| إضافة قوس إهليلجي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| إغلاق الشكل الحالي بربط نقطته النهائية بنقطة البداية. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| تعيين نقطة البداية لشكل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| إزالة شريحة عند فهرس صفري. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **إضافة نقاط مخصصة إلى شكل**

تقوم هذه الأمثلة بإدراج نقطتين في شكل مستطيل باستخدام [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) وتطبيق المسار المعدل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). الإحداثيات محلية بالنسبة للشكل: كلا النقطتين الجديدتين تقعان في مركزه، 100 نقطة من اليسار و50 نقطة من الأعلى. تضع مؤشرات الشرائح 1 و4 النقطتين على الحافتين العليا والسفلى، سحابةً هاتين الحافتين إلى الداخل.

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

![صورة المثال 1](custom_shape_1.png)

## **إزالة نقاط من شكل**

تغيّر هذه الأمثلة مخطط شكل قلب عن طريق إزالة الشريحة عند الفهرس الصفري 2 باستخدام [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). تطبيق المسار المعدل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) يُحدّث محيط الشكل.

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
![صورة المثال 2](custom_shape_2.png)

## **إنشاء شكل مخصص**

تبني هذه الأمثلة نجمة خماسية باستخدام [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). تُحدد نصفا القطر الخارجي والداخلي 100 و50 نقطة لتشكيل القمم والفراغات؛ يحدد خطوة 72 درجة التباعد المتساوي بين القمم الخمس. يُغلق المسار عبر [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) ويُطبق على شكل مستطيل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)، مستبدلًا مخططه الأصلي.

```python
import jpile
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
![صورة المثال 3](custom_shape_3.png)

## **إنشاء شكل مخصص مركب**

تعرّف هذه الأمثلة كائنين مُغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) للثلث العلوي والسفلي من الشكل. إنشاء الشكل المركب عبر تطبيق كلا المسارين باستخدام [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) ينتج شكلًا واحدًا به فجوة عبر الثلث الأوسط.

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
![صورة المثال 4](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

تدمج هذه الأمثلة شرائح مستقيمة مع [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) لإنشاء شكل بزوايا منحنية إلى الداخل. يحدد حجم كل زاوية عرض وارتفاع القوس بالنقاط، وتقوم حركة -90 درجة برسم ربع إهليلج عكس اتجاه عقارب الساعة. يُطبق المسار المكتمل عبر [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)، ثم يُحفظ العرض بصيغة PPTX.

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

يتحقق المساعد التالي مما إذا كان كل مسار هندسي غير فارغ ينتهي بشريحة إغلاق. يقرأ [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) ويقارن أمر الشريحة الأخير [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) مع [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). يُعيد `False` عندما لا توجد مسارات غير فارغة. يتحقق هذا من الأمر النهائي لكل مسار؛ ولا يفحص كل شكل فرعي داخل المسار. تُظهر الأمثلة القيمة `True` لمستطيل.

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

## **فحص أوامر مسار الهندسة**

حمّل [contour.pptx](contour.pptx) وضعه في دليل عمل التطبيق. يحتوي الشكل الأول على الشريحة الأولى على حافة علوية مستقيمة، ومنحنى بيزييه مكعب، وحافة إغلاق مستقيمة. استخدم [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) لقراءة مسارات الشكل و[getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) لقراءة شرائح كل مسار بترتيب الرسم. لكل شريحة، يحدد [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) الأمر ويُقرر كيفية تفسير القيم المرجعة من [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

يقع الشكل عند النقطة (200, 100) نقاط على الشريحة. الإحداثيات المبلغ عنها محلية بالنسبة للشكل، بحيث تكون (0, 0) في الزاوية العلوية اليسرى، وتزداد ‎x‎ إلى اليمين وتزداد ‎y‎ إلى الأسفل. تعود الشريحة الإغلاقية إلى نقطة البداية دون إحداثيات إضافية.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![شكل PowerPoint بحافة علوية مستقيمة، وحافة منحنية من أعلى اليمين إلى أسفل اليسار، وحافة يسار مستقيمة](contour.png)

## **استخراج وفحص عناصر الشكل**

استخدم [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) لفحص شكل موجود كعناصر تحتوي على نقاط مسار وأنواع النقاط. حوّل كل عنصر تم إرجاعه إلى [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) باستخدام `jpype.JObject` لاسترجاع مصفوفات النقاط والأنواع عبر طريقتي [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) و[getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). هذا التمثيل مفيد للتحليل المتتابع أو تمرير الهندسة إلى أدوات رسم مخصصة.

تفتح الأمثلة ملف input.pptx، وتجد أول شكل هندسي مباشرةً على الشريحة الأولى، وتطبع شرائحه. استخدم عرضًا يحتوي على شكل بشرائح مستقيمة ومنحنية لرؤية كلا النوعين من الإخراج. لا يبحث داخل المجموعات.

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
                point_type = types[i] & 0x07  # احتفظ بنوع القطعة، مع استبعاد العلامات.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # استهلك كلًا من نقطتي التحكم ونقطة النهاية.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

المصفوفات متطابقة بحسب الفهرس: `points[i]` هي نقطة و`types[i]` تصف دورها. النوع `0` يبدأ شكلًا، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. تبدأ شريحة بيزييه مكعب من النهاية السابقة وتستخدم ثلاث مدخلات من النوع `3` متتالية: نقطتي تحكم ثم النقطة النهائية الجديدة. يستهلك الحلقة هذه الثلاثة مدخلات معًا ويفحص النهاية للإغلاق.

تحتوي أنواع النقاط أيضًا على أعلام. استخدم القناع `0x07` لتحديد نوع الشريحة، واختبر `0x80` بشكل منفصل لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزييه تغلق واحدًا. تخزن Java هذه الأعلام في بايتات موقعة؛ القناع يحافظ على القيم البتية المقصودة. مقارنة القيمة الخام فقط مع `1` أو `3` سيفوت هذه الحالات. الأعلام الأخرى، مثل `0x10` (متقطّع) و`0x20` (علامة)، لا تغيّر نوع الشريحة الأساسية.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، مع زيادة X إلى اليمين وY إلى الأسفل. بالنسبة لشكل غير مجموعة، تشمل الإحداثيات المستخرجة بالفعل الموضع المسترجع عبر [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) و[getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) وتعكس عرضه وارتفاعه الحاليين. على سبيل المثال، المستطيل غير المدور عند `(100, 200)` بحجم `120 × 80` له حدود محيطية `(100, 200)`–`(220, 280)`. لا تقم بإضافة موضع الشكل مرة أخرى. اطرح قيم X وY للحصول على إحداثيات نسبية لإطار الشكل غير المدور.

النقاط المستخرجة لا تشمل دوران الشكل المسترجع عبر [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) أو الانعكاسات الأفقية والرأسية. لإعادة إنتاج المخطط المعروض، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمعة، احسب أيضًا تحويلات إطارات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشرائح النهائية أو أن تُطبّق ترجمة أو مقياسًا مرتين إذا كان ذلك قد ضمنه الإطار الفرعي بالفعل.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة المخطط؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا النهج عندما تحتاج إلى مصفوفات نقطة/نوع لتحليل أو رسمك. استخدم [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) عندما تحتاج إلى أوامر هندسية في نظام إحداثيات الشكل المحلي أو تريد تحرير هندسته. طبّق المسارات المعدلة عبر [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) أو [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **تحويل شكل Java AWT إلى GeometryPath**

تدمج هذه الأمثلة مخططًا مستطيلًا مع نص محول إلى هندسة. تُعطّل طريقة [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) تعبئة المخطط. ينشئ [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) مخطط النص في [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). يزود [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) بـ move، line، quadratic، cubic، وclosing، والتي تُعيد تشغيلها الأمثلة على [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

يستخدم النص خط Arial بحجم 40 نقطة. يُزاح المخطط 20 نقطة أفقيًا ويُوضَع بحيث يكون أعلىه البصري 10 نقاط أسفل الحافة العلوية للشكل. يُملأ مسار النص، بينما يظل المستطيل الأصلي مخططًا فقط. يدمج كلا المسارين عبر [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) لإنتاج شكل واحد يحتوي على المستطيل والنص.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # احصل على مسار الهندسة للشكل.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # أنشئ مسار رسومي جديد بالنص.
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

    # تحويل مسار الرسوم إلى مسار هندسي.
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
![صورة المثال 5](custom_shape_5.png)

## **الأسئلة الشائعة**

**ماذا سيحدث للملء والحد بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ فقط المخطط يتغيّر. يتم تطبيق الملء والحد تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص بشكل صحيح مع هندسته؟**

استخدم طريقة الشكل [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation)؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر [الشريحة](/slides/ar/python-java/convert-powerpoint-to-png/) المطلوبة أو [الشكل](/slides/ar/python-java/create-shape-thumbnails/) نفسه إلى تنسيق نقطي؛ يبسط ذلك العمل اللاحق مع الهندسات المعقّدة.