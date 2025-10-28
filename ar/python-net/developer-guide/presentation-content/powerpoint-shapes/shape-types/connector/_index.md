---
title: إدارة الموصلات في العروض التقديمية باستخدام بايثون
linktitle: موصل
type: docs
weight: 10
url: /ar/python-net/connector/
keywords:
- موصل
- نوع الموصل
- نقطة الموصل
- خط الموصل
- زاوية الموصل
- ربط الأشكال
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "مكّن تطبيقات بايثون من الرسم والربط وتوجيه الخطوط تلقائيًا في شرائح PowerPoint & OpenDocument — احصل على التحكم الكامل في الموصلات المستقيمة، الزاوية والمنحنية."
---

## **المقدمة**

موصل PowerPoint هو خط متخصص يربط شكلين ويبقى ملتصقًا بهما عندما يتم نقل الأشكال أو إعادة وضعها على الشريحة. الموصلات تُرفق بـ **نقاط الاتصال** (النقاط الخضراء) على الأشكال. تظهر نقاط الاتصال عندما يقترب المؤشر منها. **مقابض التعديل** (النقاط الصفراء)، المتوفرة على بعض الموصلات، تسمح لك بتعديل موضع وشكل الموصل.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام ثلاثة أنواع من الموصلات: مستقيم، زاوية (مُعَوَّج)، ومنحني.

يدعم Aspose.Slides الأنواع التالية من الموصلات:

| نوع الموصل                     | صورة                                                       | عدد نقاط التعديل |
| ------------------------------ | ---------------------------------------------------------- | ---------------- |
| `ShapeType.LINE`               | ![موصل خط](shapetype-lineconnector.png)                   | 0                |
| `ShapeType.STRAIGHT_CONNECTOR1`| ![موصل مستقيم 1](shapetype-straightconnector1.png)       | 0                |
| `ShapeType.BENT_CONNECTOR2`    | ![موصل منحني 2](shapetype-bent-connector2.png)            | 0                |
| `ShapeType.BENT_CONNECTOR3`    | ![موصل منحني 3](shapetype-bentconnector3.png)             | 1                |
| `ShapeType.BENT_CONNECTOR4`    | ![موصل منحني 4](shapetype-bentconnector4.png)             | 2                |
| `ShapeType.BENT_CONNECTOR5`    | ![موصل منحني 5](shapetype-bentconnector5.png)             | 3                |
| `ShapeType.CURVED_CONNECTOR2`  | ![موصل منحني 2](shapetype-curvedconnector2.png)           | 0                |
| `ShapeType.CURVED_CONNECTOR3`  | ![موصل منحني 3](shapetype-curvedconnector3.png)           | 1                |
| `ShapeType.CURVED_CONNECTOR4`  | ![موصل منحني 4](shapetype-curvedconnector4.png)           | 2                |
| `ShapeType.CURVED_CONNECTOR5`  | ![موصل منحني 5](shapetype.curvedconnector5.png)           | 3                |

## **ربط الأشكال بالموصلات**

يوضح هذا القسم كيفية ربط الأشكال بالموصلات في Aspose.Slides. ستضيف موصلًا إلى شريحة، وتربط بدايته ونهايته بالأشكال المستهدفة. يضمن ربط المواقع أن يبقى الموصل "ملتصقًا" بالأشكال حتى عند تحريكها أو تعديل حجمها.

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بحسب الفهرس.
3. إضافة كائنين من النوع [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `add_auto_shape` التي توفرها كائنة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) .
4. إضافة موصل باستخدام طريقة `add_connector` التي توفرها كائنة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) وتحديد نوع الموصل.
5. ربط الأشكال بالموصل.
6. استدعاء طريقة `reroute` لتطبيق أقصر مسار للاتصال.
7. حفظ العرض التقديمي.

الكود التالي بايثون يوضح كيفية إضافة موصل منحني بين شكلين (بيضاوي ومستطيل):

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Call reroute to set the shortest path.
    connector.reroute()

    # Save the presentation.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

طريقة `connector.reroute` تعيد توجيه الموصل، مما يجبره على أخذ أقصر مسار ممكن بين الأشكال. للقيام بذلك، قد تقوم الطريقة بتغيير قيم `start_shape_connection_site_index` و `end_shape_connection_site_index`.

{{% /alert %}}

## **تحديد نقاط الاتصال**

يوضح هذا القسم كيفية ربط موصل بنقطة اتصال محددة على شكل في Aspose.Slides. من خلال استهداف مواقع الاتصال بدقة، يمكنك التحكم في توجيه الموصل وتنسيقه، مما ينتج عنه مخططات نظيفة ومتوقعة في عروضك التقديمية.

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بحسب الفهرس.
3. إضافة كائنين من النوع [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `add_auto_shape` التي توفرها كائنة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) .
4. إضافة موصل باستخدام طريقة `add_connector` على كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) وتحديد نوع الموصل.
5. ربط الأشكال بالموصل.
6. ضبط نقاط الاتصال المفضلة على الأشكال.
7. حفظ العرض التقديمي.

الكود التالي بايثون يوضح كيفية تحديد نقطة اتصال مفضلة:

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide's shape collection.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Set the preferred connection site index on the ellipse.
    site_index = 6

    # Check that the preferred index is within the available site count.
    if  ellipse.connection_site_count > site_index:
        # Assign the preferred connection site on the ellipse AutoShape.
        connector.start_shape_connection_site_index = site_index

    # Save the presentation.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **تعديل نقاط الموصل**

يمكنك تعديل الموصلات باستخدام نقاط التعديل الخاصة بها. يمكن تحرير فقط الموصلات التي تُظهر نقاط تعديل. لمزيد من التفاصيل حول أي الموصلات تدعم التعديلات، راجع الجدول تحت [أنواع الموصلات](/slides/ar/python-net/connector/#connector-types).

### **حالة بسيطة**

فكر في حالة يتقاطع فيها موصل بين شكلين (A و B) مع شكل ثالث (C):

![عقبة الموصل](connector-obstruction.png)

مثال على الكود:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

لتجنب الشكل الثالث، عدل الموصل بنقل مقطع العمودي إلى اليسار:

![عقبة الموصل تم إصلاحها](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **حالات معقدة** 

للتعديلات المتقدمة، ضع في الاعتبار ما يلي:

- نقطة تعديل الموصل تُحكمها صيغة تحدد موقعها. تغيير هذه النقطة قد يغيّر الشكل الكلي للموصل.
- تُخزن نقاط تعديل الموصل في مصفوفة مرتبة بصرامة، مرقمة من بداية الموصل إلى نهايته.
- قيم نقاط التعديل تمثل نسب مئوية من عرض/ارتفاع شكل الموصل.
  - يُحدّد الشكل بنقطة البداية والنهاية للموصل ويُضَرب في 1000.
  - النقطة الأولى، الثانية، والثالثة تمثل على التوالي: نسبة العرض، نسبة الارتفاع، ونسبة العرض مرة أخرى.
- عند حساب إحداثيات نقاط التعديل، خذ بعين الاعتبار دوران الموصل وانعكاسه. **ملاحظة:** لجميع الموصلات المذكورة تحت [أنواع الموصلات](/slides/ar/python-net/connector/#connector-types)، زاوية الدوران هي 0.

#### **الحالة 1**

فكر في حالة ربط كائنين من نوع إطار نصي بموصل:

![الأشكال المرتبطة](connector-shape-complex.png)

مثال على الكود:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Get the first slide.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Add a connector.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Set the connector's direction.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Set the connector's color.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Set the connector's line thickness.
    connector.line_format.width = 3

    # Link the shapes with the connector.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Get the connector's adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**التعديل**

غيّر قيم نقاط تعديل الموصل بزيادة نسبة العرض 20% ونسبة الارتفاع 200% على التوالي:

```python
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

النتيجة:

![تعديل الموصل 1](connector-adjusted-1.png)

لتحديد نموذج يتيح حساب إحداثيات وشكل مقاطع الموصل، أنشئ شكلاً يمثل المكوّن العمودي للموصل عند `connector.adjustments[0]`:

```python
    # Draw the vertical component of the connector.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

النتيجة:

![تعديل الموصل 2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، عرضنا تعديلًا بسيطًا للموصل باستخدام مبادئ أساسية. في السيناريوهات العادية، يجب مراعاة دوران الموصل وإعدادات عرضه (تتحكم فيها `connector.rotation`، `connector.frame.flip_h`، و `connector.frame.flip_v`). إليك كيفية تنفيذ ذلك.

أولاً، أضف كائن إطار نصي جديد (**To 1**) إلى الشريحة (للاتصال)، وأنشئ موصلًا أخضرًا يربطه بالكائنات الموجودة.

```python
    # Create a new target object.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Create a new connector.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Connect the objects using the newly created connector.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Get the connector adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

النتيجة:

![تعديل الموصل 3](connector-adjusted-3.png)

ثانيًا، أنشئ شكلاً يمثل المكوّن **الأفقي** للموصل الذي يمر عبر نقطة التعديل الجديدة `connector.adjustments[0]`. استخدم القيم من `connector.rotation`، `connector.frame.flip_h`، و `connector.frame.flip_v`، وطبق صيغة تحويل الإحداثيات للدوران حول النقطة `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن 90 درجة والموصل يُعرض عموديًا، لذا يكون الكود المقابل:

```python
    # Save the connector coordinates.
    x = connector.x
    y = connector.y
    
    # Correct the connector coordinates if it is flipped.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Use the adjustment point value as the coordinate.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Convert the coordinates because sin(90°) = 1 and cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Determine the width of the horizontal segment using the second adjustment point value.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

النتيجة:

![تعديل الموصل 4](connector-adjusted-4.png)

لقد عرضنا عمليات حسابية تتضمن تعديلات بسيطة وأكثر تعقيدًا (تلك التي تأخذ الدوران في الاعتبار). باستخدام هذه المعرفة، يمكنك تطوير نموذجك الخاص—أو كتابة كود—to obtain a `GraphicsPath` object أو حتى ضبط قيم نقاط تعديل الموصل بناءً على إحداثيات شريحة محددة.

## **العثور على زوايا خطوط الموصل**

استخدم المثال أدناه لتحديد زاوية خطوط الموصل على شريحة باستخدام Aspose.Slides. ستتعلم كيفية قراءة نقاط النهاية للموصل وحساب توجيهه لتتمكن من محاذاة الأسهم، التسميات، وغيرها من الأشكال بدقة.

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بحسب الفهرس.
3. الوصول إلى شكل خط الموصل.
4. استخدام عرض وارتفاع الخط، وعرض وارتفاع إطار الشكل، لحساب الزاوية.

الكود التالي بايثون يوضح كيفية حساب زاوية شكل خط الموصل:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **الأسئلة المتكررة**

**كيف أتحقق مما إذا كان يمكن "تثبيت" موصل إلى شكل معين؟**

تحقق أن الشكل يُظهر [مواقع الاتصال](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). إذا لم توجد أو كان العدد صفرًا، فإن التثبيت غير متاح؛ في هذه الحالة، استخدم نقاط النهاية الحرة وقم بموضعها يدويًا. من الحكمة فحص عدد المواقع قبل الربط.

**ماذا يحدث للموصل إذا حذفت أحد الأشكال المتصلة؟**

ستُفصل نهاياته؛ يظل الموصل على الشريحة كخط عادي بنقطة بداية/نهاية حرة. يمكنك إما حذفه أو إعادة تعيين الاتصالات، وإذا لزم الأمر، [إعادة توجيه](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/)ه.

**هل تُحافظ ارتباطات الموصل عند نسخ شريحة إلى عرض تقديمي آخر؟**

عادةً نعم، بشرط أن تُنسخ الأشكال المستهدفة أيضًا. إذا أُدرجت الشريحة في ملف آخر دون الأشكال المتصلة، تصبح النهايات حرة وستحتاج إلى إعادة ربطها.