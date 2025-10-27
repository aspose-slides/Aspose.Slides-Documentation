---
title: تخصيص الأشكال في العروض التقديمية باستخدام بايثون
linktitle: الشكل المخصص
type: docs
weight: 20
url: /ar/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/custom-shapes/
keywords: 
- شكل مخصص
- إضافة شكل
- إنشاء شكل
- تغيير الشكل
- هندسة الشكل
- مسار الهندسة
- نقاط المسار
- تحرير النقاط
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للبايثون عبر .NET: مسارات الهندسة، الزوايا المنحنية، الأشكال المركبة."
---

## **نظرة عامة**

تخيَّل مربعًا. في PowerPoint، باستخدام **تحرير النقاط**، يمكنك:

* تحريك زاوية المربع إلى الداخل أو الخارج،
* ضبط انحناء زاوية أو نقطة،
* إضافة نقاط جديدة للمربع،
* تعديل نقاطه.

يمكنك تطبيق هذه العمليات على أي شكل. باستخدام **تحرير النقاط**، يمكنك تعديل شكل أو إنشاء شكل جديد من شكل موجود.

## **نصائح تحرير الشكل**

!["Edit Points" command](custom_shape_0.png)

قبل أن تبدأ في تحرير أشكال PowerPoint باستخدام **تحرير النقاط**، ضع في اعتبارك هذه الملاحظات حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) **مغلقًا** أو **مفتوحًا**.
* الشكل المغلق لا يحتوي على نقطة بداية أو نهاية؛ الشكل المفتوح له بداية ونهاية.
* لكل شكل نقطتا ارتساء على الأقل متصلتين بشرائح خطية.
* الشريحة إما مستقيمة أو منحنية؛ نقاط الارتساء تحدد طبيعة الشريحة.
* نقاط الارتساء يمكن أن تكون **زاوية** أو **ناعم** أو **مستقيم**:
  * نقطة **زاوية** هي حيث يلتقي قطعتان مستقيمان بزاوية.
  * نقطة **ناعم** لديها مقبضان متوازيان، وتكوّن القطعات المتجاورة منحنىً ناعماً. في هذه الحالة، يكون طول المقبضين متساويًا من نقطة الارتساء.
  * نقطة **مستقيم** لديها أيضًا مقبضان متوازيان، وتكوّن القطعات المتجاورة منحنىً ناعماً. في هذه الحالة، لا يلزم أن يكون طول المقبضين متساويًا من نقطة الارتساء.
* بتحريك أو تحرير نقاط الارتساء (وبالتالي تغيير زوايا الشرائح)، يمكنك تغيير مظهر الشكل.

لتحرير أشكال PowerPoint، توفّر Aspose.Slides الفئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* تمثّل كائن [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) مسار الهندسة لكائن [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* لاسترجاع [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من كائن [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)، استخدم طريقة [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) لشكل، استخدم [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) للأشكال الصلبة و [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) للأشكال المركبة.
* لإضافة شرائح، استخدم الأساليب المتوفرة في [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* استخدم خصائص [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) و [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) للتحكم في مظهر مسار الهندسة.
* استخدم خاصية [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) لاسترجاع مسار الهندسة لشكل كمصفوفة من شرائح المسار.

## **عمليات تحرير بسيطة**

الطرق التالية تُستخدم لعمليات تحرير بسيطة.

**إضافة خط** إلى نهاية مسار:

```py
line_to(point)
line_to(x, y)
```

**إضافة خط** في موضع محدد داخل المسار:

```py    
line_to(point, index)
line_to(x, y, index)
```

**إضافة منحنى بزيير مكعب** إلى نهاية مسار:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**إضافة منحنى بزيير مكعب** في موضع محدد داخل المسار:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**إضافة منحنى بزيير تربيعي** إلى نهاية مسار:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**إضافة منحنى بزيير تربيعي** في موضع محدد داخل المسار:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**إلحاق قوس** إلى مسار:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**إغلاق الشكل الحالي** في مسار:

```py
close_figure()
```

**تحديد موضع النقطة التالية**:

```py
move_to(point)
move_to(x, y)
```

**إزالة شريحة المسار** عند فهرس معين:

```py
remove_at(index)
```

## **إضافة نقاط مخصصة إلى الأشكال**

ستتعلم هنا كيفية تعريف شكل حر عن طريق إضافة تسلسل خاص بك من النقاط. من خلال تحديد نقاط مرتبة وأنواع الشرائح (مستقيمة أو منحنية) وإغلاق المسار اختياريًا، يمكنك رسم رسومات مخصصة دقيقة—مثل المضلعات، الأيقونات، التعليقات أو الشعارات—مباشرةً على الشرائح.

1. أنشئ كائنًا من الفئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) وحدد نوعه إلى [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. احصل على كائن [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من الشكل.
3. أدخل نقطة جديدة بين النقطتين العلويتين على المسار.
4. أدخل نقطة جديدة بين النقطتين السفلية على المسار.
5. طبّق المسار المحدّث على الشكل.

الكود التالي يوضح كيفية إضافة نقاط مخصصة إلى شكل:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![نقاط مخصصة](custom_shape_1.png)

##  **إزالة نقاط من الأشكال**

أحيانًا يحتوي الشكل المخصص على نقاط غير ضرورية تعقّد هندسته أو تؤثّر على طريقة عرضه. يوضح هذا القسم كيفية إزالة نقاط معينة من مسار الشكل لتبسيط الحدود والحصول على نتائج أنقى وأكثر دقة.

1. أنشئ كائنًا من الفئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) وحدد نوعه إلى [ShapeType.HEART](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. احصل على كائن [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من الشكل.
3. احذف شريحة من المسار.
4. طبّق المسار المحدّث على الشكل.

الكود التالي يوضح كيفية إزالة نقاط من شكل:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![نقاط مُزالة](custom_shape_2.png)

##  **إنشاء أشكال مخصصة**

أنشئ أشكالًا متجهية مخصصة عبر تعريف [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) وتكوينه من خطوط، أقواس، ومنحنيات بيزير. يوضح هذا القسم كيفية بناء هندسة مخصصة من الصفر وإضافة الشكل الناتج إلى شريحتك.

1. احسب نقاط الشكل.
2. أنشئ كائنًا من الفئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. عبّئ المسار بالنقاط.
4. أنشئ كائنًا من الفئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
5. طبّق المسار على الشكل.

الكود التالي يوضح كيفية إنشاء شكل مخصص:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![شكل مخصص](custom_shape_3.png)

## **إنشاء أشكال مركبة مخصصة**

إنشاء شكل مركب مخصص يتيح لك دمج مسارات هندسية متعددة في شكل واحد قابل لإعادة الاستخدام على الشريحة. عرّف ودمج هذه المسارات لبناء رسومات معقّدة تتجاوز مجموعة الأشكال القياسية.

1. أنشئ كائنًا من الفئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
2. أنشئ النسخة الأولى من الفئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. أنشئ النسخة الثانية من الفئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
4. طبّق كلتا المساراتين على الشكل.

الكود التالي يوضح كيفية إنشاء شكل مركب مخصص:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![شكل مركب](custom_shape_4.png)

## **إنشاء أشكال مخصصة بزوايا منحنية**

يوضّح هذا القسم كيفية رسم شكل مخصص بزوايا منحنية بسلاسة باستخدام مسار هندسي. ستجمع بين الشرائح المستقيمة والأقواس الدائرية لتشكيل الحد الخارجي وتضيف الشكل النهائي إلى شريحتك.

الكود التالي يوضح كيفية إنشاء شكل مخصص بزوايا منحنية:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![زوايا منحنية](custom_shape_6.png)

## **تحديد ما إذا كانت هندسة الشكل مغلقة**

يُعرّف الشكل المغلق بأنه الشكل الذي تتصل جميع جوانبه، مكوّنًا حدًا واحدًا دون فراغات. يمكن أن يكون هذا الشكل شكلًا هندسيًا بسيطًا أو مخططًا مخصصًا معقّدًا. يوضح المثال التالي كيفية التحقق مما إذا كانت هندسة الشكل مغلقة:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **الأسئلة الشائعة**

**ما الذي سيحدث للملء والحدود بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ فقط الحد يتغيّر. يتم تطبيق الملء والحدود تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير الشكل المخصص مع هندسته بشكل صحيح؟**

استخدم خاصية [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/) الخاصة بالشكل؛ الهندسة تدور مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر منطقة [الشريحة](/slides/ar/python-net/convert-powerpoint-to-png/) المطلوبة أو [الشكل](/slides/ar/python-net/create-shape-thumbnails/) نفسه إلى صيغة نقطية؛ هذا يبسّط العمل اللاحق مع الهندسات الثقيلة.