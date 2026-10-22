---
title: تخصيص أشكال العرض التقديمي في Python
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
- نقاط تحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Python عبر .NET: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العرض في Aspose.Slides عن طريق تحرير هندسة الشكل من خلال نقاط التحرير ومسارات الهندسة. توضح كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) لتعديل الأشكال الموجودة، إجراء عمليات تحرير أساسية للمسار، إضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة على الشكل.

كما تُظهر كيفية إنشاء أشكال مخصصة ومركبة، بناء أشكال ذات زوايا منحنية، تحديد ما إذا كانت هندسة الشكل مغلقة، واستخراج عناصر الشكل لتحليل الحدود.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* ضبط الانحناء عند نقطة.
* إضافة نقاط جديدة.

تمكنك نقاط التحرير من تعديل حدود الشكل أو استخدام شكل موجود كأساس لشكل جديد.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

عند تحرير أشكال PowerPoint، ضع في اعتبارك المفاهيم التالية:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط ارتكاز متصلة بمقاطع.
* يمكن أن يكون المقطع مستقيمًا أو منحنيًا. تحدد نقاط الارتكاز ومقابض التحكم شكله.
* توجد نقاط الارتكاز كأنواع: نقاط زاوية، نقاط مستقيمة، أو نقاط ناعمة:
  * عند نقطة الزاوية، يمكن أن تلتقي المقاطع المجاورة بزاوية.
  * عند نقطة ناعمة، تكون مقبضا التحكم محاذيين وعلى مسافة متساوية من نقطة الارتكاز.
  * عند نقطة مستقيمة، تكون مقبضا التحكم محاذيين لكن يمكن أن تكون المسافة عنهما مختلفة.
* تحريك نقاط الارتكاز أو تعديل مقابضها يغير حدود الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* تمثل مثالية [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) مسار هندسة كائن [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* لاسترجاع [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) من مثالية [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)، يمكنك استخدام طريقة [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرقيْن: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) للأشكال ذات المسار الواحد و[GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) للأشكال ذات المسارات المتعددة.
* لإضافة مقاطع، يمكنك استخدام الطرق الموجودة تحت [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* باستخدام خاصيتي [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) و[GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/)، يمكنك تحديد مظهر مسار الهندسة.
* باستخدام خاصية [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/)، يمكنك استرجاع مسار الهندسة لكائن [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) كمصفوفة من مقاطع المسار.

## **عمليات تحرير بسيطة**

استخدم الطرقيْن التاليين لتحرير مسار الهندسة. التحميلات التي تقبل فهرسًا تُدرج مقطعًا في ذلك الموضع الصفري‑الأساسي داخل مصفوفة مقاطع المسار.

| العملية | الطريقة |
| --- | --- |
| إلحاق أو إدراج خط مستقيم. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| إلحاق أو إدراج منحنى بيزيه مكعب مع نقطتي تحكم ونقطة نهائية. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| إلحاق أو إدراج منحنى بيزيه تربيعي مع نقطة تحكم واحدة ونقطة نهائية. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| إلحاق قوس بيضاوي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| إغلاق الشكل الحالي بربط نقطته النهائية بنقطة البداية. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| تعيين نقطة البداية لشكل. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| إزالة مقطع عند فهرس صفري‑أساسي. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **إضافة نقاط مخصصة إلى شكل**

يقوم هذا المثال بإدراج نقطتين في شكل مستطيل باستخدام [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) ويطبق المسار المعدل عبر [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). الإحداثيات محلية بالنسبة للشكل: كلتا النقطتين الجديدتين في مركزه، 100 نقطة من اليسار و50 نقطة من الأعلى. موضع مقاطع الفهرس 1 و4 يضعهما على الحافتين العلوية والسفلية، سحبًا لتلك الحافات للداخل.

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

![example1_image](custom_shape_1.png)

## **إزالة نقاط من شكل**

هذا المثال يغيّر مخطط شكل قلب عن طريق إزالة المقطع في الفهرس الصفري‑الأساسي 2 باستخدام [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). تطبيق المسار المُعدَّل عبر [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) يُحدّث حدّ الشكل.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

يبني هذا المثال نجمة خماسية باستخدام [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). تحدد نصف القطرين الخارجي والداخلي المتناوبين 100 و50 نقطة القمم والفراغات؛ خطوة قدرها 72 درجة تُوزّع القمم الخمس بالتساوي. يُغلق المسار عبر [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) ويُطبق على شكل مستطيل عبر [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)، مستبدلًا المخطط الأصلي.

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
![example3_image](custom_shape_3.png)

## **إنشاء شكل مخصص مركب**

يعرف هذا المثال مسارين مغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) للثلثين العلوي والسفلي من الشكل. يخلق تطبيق كلا المسارين عبر [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) شكلاً مركبًا واحدًا مع فجوة عبر الثلث الأوسط.

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
![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بذوايا منحنية**

يجمع هذا المثال المقاطع المستقيمة مع [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) لإنشاء شكل ذات زوايا منحنية إلى الداخل. يحدد حجم كل زاوية عرض وارتفاع القوس بالنقاط، وتؤدي القطعة ‑90 درجة إلى رسم ربع إهليلج عكسية. يُطبق المسار الكامل عبر [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)، ويُحفظ العرض بصيغة PPTX.

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

يتحقق المساعد التالي مما إذا كان كل مسار هندسي غير فارغ ينتهي بمقطع إغلاق. يقرأ [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) ويقارن الأمر الأخير للمسار [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) بـ[PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). يرجع false عندما لا توجد مسارات غير فارغة. يتحقق هذا من الأمر النهائي لكل مسار؛ لا يفحص كل شكل فرعي داخل المسار. يطبع المثال `True` لمستطيل.

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

## **استخراج وفحص عناصر الشكل**

استخدم [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. كل كائن [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) يُظهر مصفوفتي [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) و[path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). هذا التمثيل مفيد لتحليل الحدود أو تمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال عرضًا، يجد أول شكل هندسي مباشرةً على الشريحة الأولى، ويطبع مقاطع مساره. استخدم عرضًا يحتوي على شكل به مقاطع مستقيمة ومنحنية لملاحظة كلا النوعين من المخرجات. لا يبحث داخل المجموعات.

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
                point_type = types[i] & 0x07  # احتفظ بنوع المقطع، مستثنيًا العلامات.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

تطابق المصفوفات وفق الفهرس: `points[i]` هي نقطة و`types[i]` تصف دورها. النوع 0 يبدأ شكلًا، والنوع 1 يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ مقطع بيزيه مكعب عند النهاية السابقة ويستخدم ثلاث سجلات من النوع 3 متتالية: نقطتي تحكم ثم النهاية الجديدة. يستهلك الحلقة هذه السجلات الثلاث معًا ويفحص النهاية للإغلاق.

تحتوي أنواع النقاط أيضًا على علامات. استخدم القناع `0x07` لتحديد نوع المقطع، واختبر `0x80` منفصلًا لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزيه تغلق واحدًا. مقارنة القيمة الخام فقط بـ`1` أو `3` سيفوت هذه الحالات. العلامات الأخرى، مثل العلامة المتقطعة (`0x10`) والعلامة المؤشر (`0x20`)، لا تغيّر نوع المقطع الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بالنقاط (1/72 بوصة)، مع زيادة X إلى اليمين وY إلى الأسفل. بالنسبة لشكل غير مجموع، تشمل الإحداثيات المستخرجة موضعه ‎[x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) و‎[y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) وتعكس عرضه وارتفاعه الحاليين. على سبيل المثال، مستطيل غير مُدوَّر عند `(100, 200)` بحجم `120 × 80` له حدود حدية `(100, 200)`‑`(220, 280)`. لا تُضيف موضع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبية لإطار الشكل غير المُدوَّر.

لا تُطبق الإحداثيات المستخرجة خاصية [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) أو الانعكاسات الأفقية والعمودية. لتكرار الشكل المعروض، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمعة، احسب أيضًا تحويلات وإسقاط إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية أو أن تُضيف ترجمة أو مقياسًا مرتين إذا كان قد تم عكسه بالفعل في إطار العنصر الفرعي.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة الحد؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا النهج عندما تحتاج تحليلاتك أو كود الرسم إلى مصفوفات نقطة/نوع. استخدم [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) عندما تحتاج إلى أوامر هندسية في نظام إحداثيات الشكل المحلي أو ترغب في تحرير هندسته. طبّق المسارات المعدلة عبر [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) أو [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **الأسئلة المتكررة**

**ماذا يحدث للملء والحد بعد استبدال الهندسة؟**

يظل النمط مرتبطًا بالشكل؛ فقط الحد يتغيّر. يُطبق الملء والحد تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير الشكل المخصص مع هندسته بشكل صحيح؟**

استخدم خاصية [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة "لتثبيت" النتيجة؟**

نعم. صدِّر منطقة [شريحة](/slides/ar/python-net/convert-powerpoint-to-png/) المطلوبة أو [الشكل](/slides/ar/python-net/create-shape-thumbnails/) نفسه إلى تنسيق نقطي؛ هذا يبسط العمل اللاحق مع الهندسات المعقدة.