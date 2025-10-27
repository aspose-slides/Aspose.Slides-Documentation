---
title: إدارة الموصلات في العروض التقديمية باستخدام Python
linktitle: موصل
type: docs
weight: 10
url: /ar/python-net/connector/
keywords:
- connector
- connector type
- connector point
- connector line
- connector angle
- connect shapes
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "تمكين تطبيقات Python من رسم وربط وتوجيه الخطوط تلقائيًا في شرائح PowerPoint وOpenDocument — الحصول على تحكم كامل في الموصلات المستقيمة والمزدوجة والمنحنية."
---

## **المقدمة**

الموصل في PowerPoint هو خط متخصص يربط شكلين ويظل ملتصقًا عندما يتم نقل الأشكال أو إعادة وضعها على الشريحة. تُلصق الموصلات بـ **نقاط الاتصال** (النقاط الخضراء) على الأشكال. تظهر نقاط الاتصال عندما يقترب المؤشر منها. **مقابض الضبط** (النقاط الصفراء)، المتوفرة في بعض الموصلات، تتيح لك تعديل موضع الموصل وشكله.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام ثلاثة أنواع من الموصلات: مستقيمة، زائفة (زاوية)، ومنحنية.

يدعم Aspose.Slides الأنواع التالية من الموصلات:

| نوع الموصل                     | الصورة                                                    | عدد نقاط الضبط |
| ------------------------------ | -------------------------------------------------------- | -------------- |
| `ShapeType.LINE`               | ![موصل خط](shapetype-lineconnector.png)                 | 0              |
| `ShapeType.STRAIGHT_CONNECTOR1`| ![موصل مستقيم 1](shapetype-straightconnector1.png)      | 0              |
| `ShapeType.BENT_CONNECTOR2`    | ![موصل منحني 2](shapetype-bent-connector2.png)          | 0              |
| `ShapeType.BENT_CONNECTOR3`    | ![موصل منحني 3](shapetype-bentconnector3.png)           | 1              |
| `ShapeType.BENT_CONNECTOR4`    | ![موصل منحني 4](shapetype-bentconnector4.png)           | 2              |
| `ShapeType.BENT_CONNECTOR5`    | ![موصل منحني 5](shapetype-bentconnector5.png)           | 3              |
| `ShapeType.CURVED_CONNECTOR2`  | ![موصل منحني 2](shapetype-curvedconnector2.png)          | 0              |
| `ShapeType.CURVED_CONNECTOR3`  | ![موصل منحني 3](shapetype-curvedconnector3.png)          | 1              |
| `ShapeType.CURVED_CONNECTOR4`  | ![موصل منحني 4](shapetype-curvedconnector4.png)          | 2              |
| `ShapeType.CURVED_CONNECTOR5`  | ![موصل منحني 5](shapetype.curvedconnector5.png)          | 3              |

## **ربط الأشكال بالموصلات**

يوضح هذا القسم كيفية ربط الأشكال بالموصلات في Aspose.Slides. ستضيف موصلًا إلى الشريحة، وتُلصق بدايته ونهايته بالأشكال المستهدفة. يضمن استخدام مواقع الاتصال بقاء الموصل "ملتصقًا" بالأشكال حتى عند تحريكها أو تغيير حجمها.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة عبر فهرستها.
1. إضافة كائنين من النوع [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام الطريقة `add_auto_shape` التي توفرها فئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. إضافة موصل باستخدام الطريقة `add_connector` المتوفرة في فئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) وتحديد نوع الموصل.
1. ربط الأشكال بالموصل.
1. استدعاء الطريقة `reroute` لتطبيق أقصر مسار للاتصال.
1. حفظ العرض التقديمي.

الكود التالي بلغة Python يوضح كيفية إضافة موصل منحني بين شكلين (بيضاوي ومستطيل):

```python
import aspose.slides as slides

# إنشاء كائن Presentation لإنشاء ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى مجموعة الأشكال للشفرة الأولى.
    shapes = presentation.slides[0].shapes

    # إضافة شكل بيضاوي AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # إضافة شكل مستطيل AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # إضافة موصل إلى الشريحة.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # ربط الأشكال بالموصل.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # استدعاء reroute لتعيين أقصر مسار.
    connector.reroute()

    # حفظ العرض التقديمي.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ملاحظة" color="warning" %}}

الطريقة `connector.reroute` تعيد توجيه الموصل، مما يجبره على أخذ أقصر مسار ممكن بين الأشكال. قد تقوم الطريقة بتغيير قيم `start_shape_connection_site_index` و `end_shape_connection_site_index`.

{{% /alert %}}

## **تحديد نقاط الاتصال**

يوضح هذا القسم كيفية إلحاق موصل بنقطة اتصال محددة على شكل في Aspose.Slides. من خلال استهداف مواقع الاتصال بدقة، يمكنك التحكم في توجيه الموصل وتنسيقه، مما ينتج مخططات نظيفة ومتوقعة في عروضك التقديمية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة عبر فهرستها.
1. إضافة كائنين من النوع [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام الطريقة `add_auto_shape` المتوفرة في فئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. إضافة موصل باستخدام الطريقة `add_connector` على فئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) وتحديد نوع الموصل.
1. ربط الأشكال بالموصل.
1. ضبط نقاط الاتصال المفضلة على الأشكال.
1. حفظ العرض التقديمي.

الكود التالي بلغة Python يوضح كيفية تحديد نقطة اتصال مفضلة:

```python
import aspose.slides as slides

# إنشاء كائن Presentation لإنشاء ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى مجموعة الأشكال للشفرة الأولى.
    shapes = presentation.slides[0].shapes

    # إضافة شكل بيضاوي AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # إضافة شكل مستطيل AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # إضافة موصل إلى مجموعة أشكال الشريحة.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # ربط الأشكال بالموصل.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # تعيين فهرس موقع الاتصال المفضل على البيضاوي.
    site_index = 6

    # التحقق من أن الفهرس المفضل ضمن عدد المواقع المتاحة.
    if  ellipse.connection_site_count > site_index:
        # تعيين موقع الاتصال المفضل على شكل البيضاوي.
        connector.start_shape_connection_site_index = site_index

    # حفظ العرض التقديمي.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط نقاط الموصل**

يمكنك تعديل الموصلات باستخدام نقاط الضبط الخاصة بها. فقط الموصلات التي تعرض نقاط ضبط يمكن تعديلها بهذه الطريقة. للحصول على تفاصيل حول الموصلات التي تدعم الضبط، راجع الجدول تحت [أنواع الموصلات](/slides/ar/python-net/connector/#connector-types).

### **حالة بسيطة**

تخيل حالة يكون فيها موصل بين شكلين (A و B) يقطع شكلًا ثالثًا (C):

![عائق الموصل](connector-obstruction.png)

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

لتفادي الشكل الثالث، اضبط الموصل بنقل قطعه العمودية إلى اليسار:

![عائق الموصل بعد الإصلاح](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **حالات معقدة**

لضبط أكثر تقدمًا، ضع في اعتبارك التالي:

- تُحكم نقطة الضبط في الموصل بواسطة صيغة تحدد موقعها. تغيير هذه النقطة يمكن أن يؤثر على شكل الموصل ككل.
- تُخزن نقاط الضبط في مصفوفة مرتبة بصرامة، مرقَّمة من بداية الموصل إلى نهايته.
- تمثل قيم نقاط الضبط نسبًا مئوية من عرض/ارتفاع شكل الموصل.
  - يحدُّ الشكل بنقاط بداية ونهاية الموصل ويُضَرب بـ 1000.
  - تمثل النقطة الأولى والثانية والثالثة على التوالي: نسبة العرض، نسبة الارتفاع، ونسبة العرض مرة أخرى.
- عند حساب إحداثيات نقاط الضبط، يجب مراعاة دوران الموصل وانعكاسه. **ملاحظة:** لجميع الموصلات المذكورة في [أنواع الموصلات](/slides/ar/python-net/connector/#connector-types)، زاوية الدوران هي 0.

#### **الحالة 1**

تخيل حالة يكون فيها كائنان من إطار النص مرتبطان بموصل:

![أشكال مرتبطة](connector-shape-complex.png)

مثال على الكود:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation لإنشاء ملف PPTX.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # الحصول على الشريحة الأولى.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # إضافة موصل.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # تعيين اتجاه الموصل.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # تعيين لون الموصل.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # تعيين سمك خط الموصل.
    connector.line_format.width = 3

    # ربط الأشكال بالموصل.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # الحصول على نقاط ضبط الموصل.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**الضبط**

غيّر قيم نقاط ضبط الموصل بزيادة نسبة العرض بنسبة 20٪ ونسبة الارتفاع بنسبة 200٪ على التوالي:

```python
    # تغيير قيم نقاط الضبط.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

النتيجة:

![ضبط الموصل 1](connector-adjusted-1.png)

لتعريف نموذج يحدد إحداثيات وشكل مقاطع الموصل، أنشئ شكلاً يتوافق مع المكوّن العمودي للموصل عند `connector.adjustments[0]`:

```python
    # رسم المكوّن العمودي للموصل.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

النتيجة:

![ضبط الموصل 2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، عرضنا ضبطًا بسيطًا للموصل باستخدام مبادئ أساسية. في السيناريوهات النموذجية، يجب مراعاة دوران الموصل وإعداداته العرضية (المحددة بواسطة `connector.rotation`، `connector.frame.flip_h`، و `connector.frame.flip_v`). إليك كيفية تنفيذ ذلك.

أولاً، أضف كائن إطار نص جديد (**To 1**) إلى الشريحة (للاتصال)، وأنشئ موصلًا أخضرًا يربطه بالكائنات الحالية.

```python
    # إنشاء كائن هدف جديد.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # إنشاء موصل جديد.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # ربط الكائنات باستخدام الموصل الجديد.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # الحصول على نقاط ضبط الموصل.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # تغيير قيم نقاط الضبط.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

النتيجة:

![ضبط الموصل 3](connector-adjusted-3.png)

ثانيًا، أنشئ شكلاً يتوافق مع المكوّن **الأفقي** للموصل الذي يمر عبر نقطة الضبط الجديدة `connector.adjustments[0]`. استخدم القيم المستمدة من `connector.rotation`، `connector.frame.flip_h`، و `connector.frame.flip_v`، وطبق صيغة تحويل الإحداثيات للتدوير حول نقطة معينة `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن 90 درجة والموصل يُعرض عموديًا، لذا يكون الكود المقابل:

```python
    # حفظ إحداثيات الموصل.
    x = connector.x
    y = connector.y
    
    # تصحيح إحداثيات الموصل إذا كان مقلوبًا.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # استخدام قيمة نقطة الضبط كإحداثي.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # تحويل الإحداثيات لأن sin(90°) = 1 و cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # تحديد عرض المكوّن الأفقي باستخدام قيمة نقطة الضبط الثانية.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

النتيجة:

![ضبط الموصل 4](connector-adjusted-4.png)

لقد عرضنا حسابات تتضمن ضبطًا بسيطًا ومزيدًا من تعقيد نقاط الضبط (التي تأخذ الدوران في الحسبان). باستخدام هذه المعرفة، يمكنك تطوير نموذجك الخاص—أو كتابة كود—للحصول على كائن `GraphicsPath` أو حتى ضبط قيم نقاط الضبط للموصل بناءً على إحداثيات معينة في الشريحة.

## **اكتشاف زوايا خطوط الموصل**

استخدم المثال أدناه لتحديد زاوية خطوط الموصل على شريحة باستخدام Aspose.Slides. ستتعلم كيفية قراءة نقطتي النهاية للموصل وحساب اتجاهه حتى تتمكن من محاذاة الأسهم والعناوين والأشكال الأخرى بدقة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة عبر الفهرس.
1. الوصول إلى شكل خط الموصل.
1. استخدام عرض وارتفاع الخط، وعرض وارتفاع إطار الشكل، لحساب الزاوية.

الكود التالي بلغة Python يوضح كيفية حساب الزاوية للشكل خط الموصل:

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

**كيف يمكنني معرفة ما إذا كان يمكن "لصق" الموصل إلى شكل معين؟**

تحقق من أن الشكل يُظهر [مواقع الاتصال](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). إذا لم يكن هناك أو كان العدد صفرًا، فإن اللصق غير متاح؛ في هذه الحالة استخدم نقاط النهاية الحرة وضعها يدويًا. من المنطقي التحقق من عدد المواقع قبل الإلحاق.

**ماذا يحدث للموصل إذا حذفت أحد الأشكال المتصلة؟**

سينفصل نهاياه؛ سيبقى الموصل على الشريحة كخط عادي بنقطة بداية ونهاية حرة. يمكنك إما حذفه أو إعادة تعيين الاتصالات، وإذا لزم الأمر، استدعاء [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**هل تُحافظ ربطات الموصل عند نسخ شريحة إلى عرض تقديمي آخر؟**

عمومًا نعم، بشرط نسخ الأشكال المستهدفة أيضًا. إذا أُضيفت الشريحة إلى ملف آخر بدون الأشكال المرتبطة، تصبح النهايات حرة وستحتاج إلى إلحاقها مرة أخرى.