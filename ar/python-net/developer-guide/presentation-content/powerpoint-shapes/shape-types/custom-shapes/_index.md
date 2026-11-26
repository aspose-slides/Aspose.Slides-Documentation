---
title: تخصيص أشكال العروض التقديمية في Python
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/python-net/custom-shape/
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
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لــPython عبر .NET: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تعديل هندسة الشكل عبر نقاط التحرير ومسارات الهندسة. توضح كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) لتعديل الأشكال الموجودة، وإجراء عمليات تحرير أساسية للمسار، وإضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة على الشكل مرة أخرى.

كما توضح كيفية إنشاء أشكال مخصصة ومركبة، وبناء أشكال ذات زوايا منحنية، وتحديد ما إذا كانت هندسة الشكل مغلقة، واستخراج عناصر الشكل لتحليل الحد.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* تعديل الانحناء عند نقطة.
* إضافة نقاط جديدة.

تمكنك نقاط التحرير من تعديل مخطط الشكل أو استخدام شكل موجود كأساس لشكل جديد.

## **نصائح تحرير الشكل**

![صورة نظرة عامة](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على مراعاة هذه المفاهيم:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* يتكوّن مسار الشكل من نقاط ارتكاز متصلة بمقاطع.
* يمكن أن يكون المقطع مستقيمًا أو منحنيًا. تحدد نقاط الارتكاز ومقابض التحكم شكله.
* توجد نقاط الارتكاز كالنقاط الزاوية، أو النقاط المستقيمة، أو النقاط الملساء:
  * في النقطة الزاوية، يمكن للمقاطع المجاورة أن تلتقي بزاوية.
  * في النقطة الملساء، تكون مقبضان التحكم محاذيين ومتساويين البعد عن نقطة الارتكاز.
  * في النقطة المستقيمة، تكون مقبضان التحكم محاذيين لكن يمكن أن تكون مسافتهما عن نقطة الارتكاز مختلفة.
* تحريك نقاط الارتكاز أو تعديل مقابضها يغيّر مخطط الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** فئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* تمثل نسخة من [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) مسار هندسة كائن [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* لاسترداد [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من نسخة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)، يمكنك استخدام طريقة [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) للأشكال ذات المسار الواحد و[GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) للأشكال ذات المسارات المتعددة.
* لإضافة مقاطع، يمكنك استخدام الطرق المتاحة تحت [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* باستخدام خاصيتي [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) و[GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/)، يمكنك ضبط مظهر مسار الهندسة.
* باستخدام خاصية [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/)، يمكنك استرداد مسار هندسة [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) كمصفوفة من مقاطع المسار.

## **عمليات تحرير بسيطة**

استخدم الطرق التالية لتحرير مسار الهندسة. التحميلات التي تقبل فهرسًا تُدخل مقطعًا في ذلك الموضع الصفري في مصفوفة مقاطع المسار.

| العملية | الطريقة |
| --- | --- |
| إلحاق أو إدراج خط مستقيم. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| إلحاق أو إدراج منحنى بيزييه مكعب مع نقطتي تحكم ونقطة النهاية. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| إلحاق أو إدراج منحنى بيزييه تربيعي مع نقطة تحكم واحدة ونقطة النهاية. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| إلحاق قوس بيضاوي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| إغلاق الشكل الحالي بربط نقطة النهاية بنقطة البداية. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| تعيين نقطة البداية لشكل. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| إزالة مقطع عند فهرس صفري. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **إضافة نقاط مخصصة إلى شكل**

يُدرج هذا المثال نقطتين في شكل مستطيل باستخدام [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) ويطبّق المسار المعدل عبر [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). الإحداثيات محلية بالنسبة للشكل: كلا النقطتين الجديدتين في مركزه، على بعد 100 نقطة من اليسار و50 نقطة من الأعلى. مؤشرات المقاطع 1 و4 تضعهما على حواف الأعلى والأسفل، ساحبًا تلك الحواف إلى الداخل.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![صورة مثال 1](custom_shape_1.png)

## **إزالة نقاط من شكل**

يُغيّر هذا المثال مخطط شكل قلب عن طريق إزالة المقطع عند الفهرس الصفري 2 باستخدام [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). تطبيق المسار المعدل عبر [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) يُحدّث حافة الشكل.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![صورة مثال 2](custom_shape_2.png)

## **إنشاء شكل مخصص**

يبني هذا المثال نجمة خماسية النقاط باستخدام [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). تُحدد نصفا القطر المتناوبين 100 و50 نقطة لتحديد رؤوس الحواف الداخلية؛ خطوة 72 درجة تُوزّع الرؤوس الخمسة بصورة متساوية. يُغلق المسار عبر [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) ويُطبّق على شكل مستطيل باستخدام [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)، مستبدلًا مخططه.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![صورة مثال 3](custom_shape_3.png)

## **إنشاء شكل مخصص مركب**

يعّرف هذا المثال مسارين مغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) للثلثين العلوي والسفلي من الشكل. تطبيق كلا المسارين عبر [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) يُنشئ شكلًا مركبًا واحدًا مع فجوة عبر الثلث الأوسط.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![صورة مثال 4](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

يجمع هذا المثال مقاطع مستقيمة مع [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) لإنشاء شكل بزوايا منحنية إلى الداخل. كل حجم زاوية يحدد عرض وارتفاع القوس بالنقاط، والمسح بزاوية -90 درجة يرسم ربع إهليلج باتجاه عكس عقارب الساعة. يُطبّق المسار المكتمل عبر [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)، ثم يُحفظ العرض بصيغة PPTX.

```python
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

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **معرفة ما إذا كانت هندسة الشكل مغلقة**

يتحقق المساعد التالي ما إذا كان كل مسار هندسي غير فارغ ينتهي بمقطع إغلاق. يقرأ [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) ويقارن أمر المقطع الأخير [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) بـ[PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). يُعيد false عندما لا توجد مسارات غير فارغة. يتحقق هذا من الأمر الأخير لكل مسار؛ لا يتفقد كل شكل فرعي داخل المسار. يطبع المثال `True` لمستطيل.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **فحص أوامر مسار الهندسة**

حمّل [contour.pptx](contour.pptx) وضعه في دليل العمل الخاص بك. الشكل الأول على الشريحة الأولى يحتوي على حافة علوية مستقيمة، ومنحنى بيزييه مكعب، وحافة إغلاق مستقيمة. استخدم [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) لقراءة مساراته. لكل مسار، تُدرج [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) المقاطع بترتيب الرسم. يحدد [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) كيفية تفسير [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/) لكل مقطع.

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

يقع الشكل عند (200, 100) نقطة على الشريحة. الإحداثيات المبلّغ عنها محلية بالنسبة للشكل. زاويته العلوية اليسرى هي (0, 0)، يزداد x إلى اليمين، ويزداد y إلى الأسفل. يُعيد المقطع الإغلاق إلى نقطة البداية دون إحداثيات إضافية.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![شكل PowerPoint بحافة علوية مستقيمة، وحافة منحنية من الأعلى يمينًا إلى الأسفل يسارًا، وحافة يسارية مستقيمة](contour.png)

## **استخراج وفحص عناصر الشكل**

استخدم [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. كل [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) مُرجع يُظهر مصفوفتي [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) و [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). يُعد هذا التمثيل مفيدًا لتحليل الحد أو تمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال عرضًا، يجد أول شكل هندسي مباشرةً على الشريحة الأولى، ويطبع مقاطع مساره. استخدم عرضًا يحتوي على شكل بمقاطع مستقيمة ومنحنية لتظهر كلا النوعين من المخرجات. لا يبحث داخل المجموعات.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # احتفظ بنوع المقطع مع استبعاد العلامات.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # استهلك نقطتي التحكم ونقطة النهاية.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

تُطابق المصفوفات بحسب الفهرس: `points[i]` هي نقطة و`types[i]` تصف دورها. النوع `0` يبدأ شكلًا، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ مقطع بيزييه مكعب عند نقطة النهاية السابقة ويستخدم ثلاث إدخالات من النوع `3` متتالية: نقطتا تحكم ثم نقطة النهاية الجديدة. يستهلك الحلقة هذه الثلاث إدخالات معًا ويفحص نقطة النهاية للإغلاق.

تحتوي أنواع النقاط أيضًا على أعلام. قناع بـ`0x07` لتحديد نوع المقطع، واختبر `0x80` منفصلًا لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تُغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزييه تُغلق أحدهما. مقارنة القيمة الخام فقط بـ`1` أو `3` سيتجاهل هذه الحالات. لا تُغيّر أعلام أخرى مثل الشرط (`0x10`) أو العلامة (`0x20`) نوع المقطع الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، مع زيادة X إلى اليمين وزيادة Y إلى الأسفل. بالنسبة لشكل غير مجموع، تشمل الإحداثيات المستخرجة بالفعل موضعه [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) و [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) وتعكس عرضه وارتفاعه الحاليين. على سبيل المثال، مستطيل غير مُدوَّر عند `(100, 200)` بحجم `120 × 80` له حدود الحد `(100, 200)`–`(220, 280)`. لا تُضف موضع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبية لإطاره غير المُدوَّر.

لا تُطبّق النقاط المستخرجة دوران [shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) أو انعكاسات أفقية/عمودية. لتكرار الحد المعروض، طبّق هذه التحويلات حول مركز الشكل. بالنسبة للأشكال المجمعة، احسب أيضًا تحويلات وإسقاطات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية أو تُطبق ترجمة أو مقياسًا مرتين إذا كان مُعكسًا بالفعل في إطار الطفل.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة الحد؛ تعديلها لا يحدّث الشكل الأصلي. استخدم هذا النهج عندما يحتاج تحليلك أو كود الرسم إلى مصفوفات نقطة/نوع. استخدم [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) عندما تحتاج أوامر هندسية في نظام إحداثيات الشكل المحلي أو تريد تحرير هندسته. طبّق المسارات المُعدَّلة عبر [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) أو [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **الأسئلة المتكررة**

**ماذا يحدث للملء والخط الخارجي بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ يتغيّر الحد فقط. يُطبق الملء والخط الخارجي تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع هندسته بشكل صحيح؟**

استخدم خاصية [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثياته الخاص.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر المنطقة المطلوبة من [الشرحة](/slides/ar/python-net/convert-powerpoint-to-png/) أو الـ[شكل](/slides/ar/python-net/create-shape-thumbnails/) نفسه إلى تنسيق نقطي؛ يُسهّل ذلك العمل مع الهندسات المعقدة.