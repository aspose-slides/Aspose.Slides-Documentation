---
title: تخصيص الأشكال في العروض التقديمية باستخدام بايثون
linktitle: الشكل المخصص
type: docs
weight: 20
url: /ar/python-net/custom-shape/
keywords:
- شكل مخصص
- إضافة شكل
- إنشاء شكل
- تغيير شكل
- هندسة الشكل
- مسار هندسي
- نقاط المسار
- تعديل النقاط
- إضافة نقطة
- إزالة نقطة
- عملية تعديل
- زاوية منحنية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للبايثون عبر .NET: مسارات هندسية، زوايا منحنية، أشكال مركبة."
---

## **نظرة عامة**

تخيل مربعًا. في PowerPoint، باستخدام **Edit Points**، يمكنك:

* تحريك زاوية المربع إلى الداخل أو الخارج،
* تعديل انحناء زاوية أو نقطة،
* إضافة نقاط جديدة إلى المربع،
* تعديل نقاطه.

يمكنك تطبيق هذه العمليات على أي شكل. باستخدام **Edit Points**، يمكنك تعديل شكل أو إنشاء شكل جديد من شكل موجود.

## **نصائح تعديل الشكل**

!["Edit Points" command](custom_shape_0.png)

قبل أن تبدأ بتعديل أشكال PowerPoint باستخدام **Edit Points**، ضع في اعتبارك الملاحظات التالية حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) **مغلقًا** أو **مفتوحًا**.
* الشكل المغلق لا يحتوي على نقطة بداية أو نهاية؛ الشكل المفتوح لديه بداية ونهاية.
* كل شكل يحتوي على نقطتي ارتكاز على الأقل متصلتين بشرطات خطية.
* الشرط إما مستقيم أو منحني؛ تحدد نقاط الارتكاز طبيعة الشرط.
* يمكن أن تكون نقاط الارتكاز **زاوية** أو **سلسلة** أو **مستقيمة**:
  * النقطة **الزاوية** هي المكان الذي يلتقي فيه شرطان مستقيمان بزاوية.
  * النقطة **السلسلة** لها مقبضان متعامدان، وتشكل الشرطان المتصلان منحنىً سلسًا. في هذه الحالة، يكون كلا المقبضين على نفس البعد من نقطة الارتكاز.
  * النقطة **المستقيمة** لها أيضًا مقبضان متعامدان، وتشكل الشرطان المتصلان منحنىً سلسًا. في هذه الحالة، لا يلزم أن يكون المقبضان على نفس البعد من نقطة الارتكاز.
* عن طريق تحريك أو تعديل نقاط الارتكاز (وبذلك تغيير زوايا الشرط)، يمكنك تغيير مظهر الشكل.

لتعديل أشكال PowerPoint، توفر Aspose.Slides الفئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* تمثل مثابة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) مسارًا هندسيًا لكائن [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* لاسترداد [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من مثابة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)، استخدم الطريقة [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) .
* لتعيين [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) لشكل، استخدم [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) للأشكال **الصلبة** و[GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) للأشكال **المركبة**.
* لإضافة شرط، استخدم الأساليب الموجودة في فئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
* استخدم خاصيتي [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) و[GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) للتحكم في مظهر المسار الهندسي.
* استخدم خاصية [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) لاسترداد مسار الشكل الهندسي كمصفوفة من الشرط.

## **عمليات تعديل بسيطة**

الطرق التالية تُستخدم لعمليات تعديل بسيطة.

**إضافة خط** إلى نهاية مسار:

```py
line_to(point)
line_to(x, y)
```

**إضافة خط** في موضع محدد في مسار:

```py
line_to(point, index)
line_to(x, y, index)
```

**إضافة منحنى بيزيه مكعب** إلى نهاية مسار:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**إضافة منحنى بيزيه مكعب** في موضع محدد في مسار:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**إضافة منحنى بيزيه رباعي** إلى نهاية مسار:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**إضافة منحنى بيزيه رباعي** في موضع محدد في مسار:

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

**إزالة الشرط** في فهرس معين:

```py
remove_at(index)
```

## **إضافة نقاط مخصصة إلى الأشكال**

ستتعلم هنا كيفية تعريف شكل حر بإضافة تسلسل خاص بك من النقاط. عن طريق تحديد نقاط مرتبة وأنواع الشرط (مستقيم أو منحني) وإغلاق المسار اختياريًا، يمكنك رسم رسومات مخصصة دقيقة—مثل مضلعات، أيقونات، تعليقات توضيحية أو شعارات—مباشرة على الشرائح.

1. أنشئ مثابة من الفئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) وحدد نوعها إلى [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) .
2. احصل على مثابة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من الشكل.
3. أدخل نقطة جديدة بين النقطتين العلويتين في المسار.
4. أدخل نقطة جديدة بين النقطتين السفليتين في المسار.
5. طبّق المسار المحدّث على الشكل.

الكود التالي بايثون يوضح كيفية إضافة نقاط مخصصة إلى شكل:

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

## **إزالة نقاط من الأشكال**

أحيانًا يحتوي الشكل المخصص على نقاط غير ضرورية تعقّد هندسته أو تؤثر على طريقة عرضه. يوضح هذا القسم كيفية إزالة نقاط محددة من مسار الشكل لتبسيط الحدود والحصول على نتائج أنظف وأكثر دقة.

1. أنشئ مثابة من الفئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) وحدد نوعها إلى [ShapeType.HEART](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) .
2. احصل على مثابة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من الشكل.
3. أزل شرطًا من المسار.
4. طبّق المسار المحدّث على الشكل.

الكود التالي بايثون يوضح كيفية إزالة نقاط من شكل:

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

## **إنشاء أشكال مخصصة**

أنشئ أشكالًا متجهة مخصصة بتعريف [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) وتكوينها من خطوط، أقواس، ومنحنيات بيزيه. يوضح هذا القسم كيفية بناء هندسة مخصصة من الصفر وإضافة الشكل الناتج إلى شريحتك.

1. احسب نقاط الشكل.
2. أنشئ مثابة من الفئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
3. عَبّئ المسار بالنقاط.
4. أنشئ مثابة من الفئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) .
5. طبّق المسار على الشكل.

الكود التالي بايثون يوضح كيفية إنشاء شكل مخصص:

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

إنشاء شكل مركب مخصص يتيح لك دمج مسارات هندسية متعددة في شكل واحد قابل لإعادة الاستخدام على شريحة. عرّف ودمج هذه المسارات لبناء رسومات معقدة تتجاوز مجموعة الأشكال القياسية.

1. أنشئ مثابة من الفئة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) .
2. أنشئ المثابة الأولى من الفئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
3. أنشئ المثابة الثانية من الفئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
4. طبّق كلا المسارين على الشكل.

الكود التالي بايثون يوضح كيفية إنشاء شكل مركب مخصص:

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

## **إنشاء أشكال مخصصة ذات زوايا منحنية**

يُظهر هذا القسم كيفية رسم شكل مخصص بزوايا منحنية بسلاسة باستخدام مسار هندسي. ستدمج أقسامًا مستقيمة وأقواس دائرية لتشكيل الحدود وتضيف الشكل المكتمل إلى شريحتك.

الكود التالي بايثون يوضح كيفية إنشاء شكل مخصص بزوايا منحنية:

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

## **تحديد ما إذا كان هندسة الشكل مغلقة**

يُعرّف الشكل المغلق بأنه الشكل الذي تتصل جميع جوانبه، مكوّنًا حدًا واحدًا دون فجوات. يمكن أن يكون هذا الشكل شكلًا هندسيًا بسيطًا أو مخططًا مخصصًا معقدًا. يوضح المثال التالي كيفية التحقق مما إذا كان هندسة الشكل مغلقة:

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

## **الأسئلة المتكررة**

**ماذا يحدث للملء والحدود بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ يتغير الشكل فقط. يُطبق الملء والحدود تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع الهندسة بشكل صحيح؟**

استخدم خاصية [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/) للshape؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل ذاته.

**هل يمكن تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر منطقة الشريحة [slide](/slides/ar/python-net/convert-powerpoint-to-png/) أو [shape](/slides/ar/python-net/create-shape-thumbnails/) نفسها إلى صيغة نقطية؛ يبسط ذلك العمل اللاحق مع الهندسات الكبيرة.