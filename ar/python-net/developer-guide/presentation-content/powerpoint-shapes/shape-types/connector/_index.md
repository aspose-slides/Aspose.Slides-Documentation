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
description: "مكّن تطبيقات بايثون من رسم وربط وتوجيه الخطوط تلقائيًا في شرائح PowerPoint وOpenDocument — احصل على تحكم كامل في الموصلات المستقيمة، الزاوية والمنحنية."
---

## **المقدمة**

موصل PowerPoint هو خط متخصص يربط شكلين ويبقى ملتصقًا عندما يتم تحريك الأشكال أو إعادة وضعها على الشريحة. يلتصق الموصلون بـ **نقاط الاتصال** (النقاط الخضراء) على الأشكال. تظهر نقاط الاتصال عندما يقترب المؤشر منها. **مقابض الضبط** (النقاط الصفراء)، المتوفرة على بعض الموصلات، تتيح لك تعديل موضع وشكل الموصل.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام ثلاثة أنواع من الموصلات: مستقيم، كوع (زاوي)، ومنحني.

يدعم Aspose.Slides الأنواع التالية من الموصلات:

| نوع الموصل | صورة | عدد نقاط الضبط |
| ------------------------------- | --------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE` | ![موصل خط](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![موصل مستقيم 1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![موصل منحني 2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![موصل منحني 3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![موصل منحني 4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![موصل منحني 5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![موصل مقوس 2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![موصل مقوس 3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![موصل مقوس 4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![موصل مقوس 5](shapetype.curvedconnector5.png) | 3 |

## **ربط الأشكال بالموصلات**

يوضح هذا القسم كيفية ربط الأشكال بالموصلات في Aspose.Slides. ستضيف موصلاً إلى شريحة، وتلصق بدايته ونهايته بالأشكال المستهدفة. يضمن استخدام مواقع الاتصال أن يبقى الموصل "ملتصقًا" بالأشكال حتى عندما تتحرك أو يتغير حجمها.

1. إنشاء مثال من الفئة [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة عبر فهرسها.
1. إضافة كائنين من النوع [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `add_auto_shape` التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. إضافة موصل باستخدام طريقة `add_connector` التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) وتحديد نوع الموصل.
1. ربط الأشكال بالموصل.
1. استدعاء طريقة `reroute` لتطبيق أقصر مسار اتصال.
1. حفظ العرض.

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لإنشاء ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى مجموعة الأشكال للشريحة الأولى.
    shapes = presentation.slides[0].shapes

    # إضافة شكل AutoShape إهليلجي.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # إضافة شكل AutoShape مستطيل.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # إضافة موصل إلى الشريحة.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # ربط الأشكال بالموصل.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # استدعاء reroute لتعيين أقصر مسار.
    connector.reroute()

    # حفظ العرض.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}
`طريقة connector.reroute` تعيد توجيه الموصل، مما يجبره على اتخاذ أقصر مسار ممكن بين الأشكال. للقيام بذلك، قد تقوم الطريقة بتغيير قيم `start_shape_connection_site_index` و `end_shape_connection_site_index`.
{{% /alert %}}

## **تحديد نقاط الاتصال**

يوضح هذا القسم كيفية إرفاق موصل بنقطة اتصال محددة على شكل في Aspose.Slides. من خلال استهداف مواقع الاتصال الدقيقة، يمكنك التحكم في توجيه الموصل وتخطيطه، مما ينتج مخططات نظيفة ومتوقعة في عروضك.

1. إنشاء مثال من الفئة [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة عبر فهرسها.
1. إضافة كائنين من النوع [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `add_auto_shape` التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. إضافة موصل باستخدام طريقة `add_connector` على كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) وتحديد نوع الموصل.
1. ربط الأشكال بالموصل.
1. ضبط نقاط الاتصال المفضلة على الأشكال.
1. حفظ العرض.

```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لإنشاء ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى مجموعة الأشكال للشريحة الأولى.
    shapes = presentation.slides[0].shapes

    # إضافة شكل AutoShape إهليلجي.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # إضافة شكل AutoShape مستطيل.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # إضافة موصل إلى مجموعة أشكال الشريحة.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # ربط الأشكال بالموصل.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # تعيين فهرس موقع الاتصال المفضَّل على الشكل الإهليلجي.
    site_index = 6

    # التحقق من أن الفهرس المفضَّل ضمن عدد مواقع الاتصال المتاحة.
    if  ellipse.connection_site_count > site_index:
        # تعيين موقع الاتصال المفضَّل على شكل AutoShape الإهليلجي.
        connector.start_shape_connection_site_index = site_index

    # حفظ العرض.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```


## **ضبط نقاط الموصل**

يمكنك تعديل الموصلات باستخدام نقاط الضبط الخاصة بها. فقط الموصلات التي تُظهر نقاط الضبط يمكن تحريرها بهذه الطريقة. للحصول على تفاصيل حول أي الموصلات تدعم الضبط، راجع الجدول تحت [أنواع الموصلات](/slides/ar/python-net/connector/#connector-types).

### **حالة بسيطة**

اعتبر حالة يكون فيها موصل بين شكلين (A و B) يتقاطع مع شكل ثالث (C):

![عائق الموصل](connector-obstruction.png)

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


لتجنب الشكل الثالث، اضبط الموصل بنقل جزئه الرأسي إلى اليسار:

![عائق الموصل المُثبت](connector-obstruction-fixed.png)
```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```


### **حالات معقدة**

للمزيد من الضبط المتقدم، ضع في الاعتبار ما يلي:

- نقطة الضبط للموصل تخضع لصيغة تحدد موضعها. تغيير هذه النقطة يمكن أن يغير الشكل الكلي للموصل.
- نقاط ضبط الموصل مخزنة في مصفوفة مرتبة بشكل صارم، مرقمة من بداية الموصل إلى نهايته.
- قيم نقاط الضبط تمثل نسبًا مئوية لعرض/ارتفاع شكل الموصل.
  - الشكل محاط بنقطة بداية ونهاية الموصل ويتم تحجيمه بـ 1000.
  - تمثل النقطة الأولى والثانية والثالثة على التوالي: نسبة العرض، نسبة الارتفاع، ونسبة العرض مرة أخرى.
- عند حساب إحداثيات نقاط الضبط، يجب أخذ دوران وانعكاس الموصل في الاعتبار. **ملاحظة:** لجميع الموصلات المذكورة تحت [أنواع الموصلات](/slides/ar/python-net/connector/#connector-types)، زاوية الدوران هي 0.

#### **الحالة 1**

اعتبر حالة يكون فيها كائنان من نوع إطار نص مرتبطين بموصل:

![الأشكال المرتبطة](connector-shape-complex.png)
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation لإنشاء ملف PPTX.
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
    # تحديد اتجاه الموصل.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # تحديد لون الموصل.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # تحديد سمك خط الموصل.
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

قم بتغيير قيم نقاط ضبط الموصل بزيادة نسبة العرض بنسبة 20% ونسبة الارتفاع بنسبة 200% على التوالي:

```python
    # تغيير قيم نقاط الضبط.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```


النتيجة:

![ضبط الموصل 1](connector-adjusted-1.png)

لتعريف نموذج يسمح لنا بتحديد إحداثيات وشكل أقسام الموصل، أنشئ شكلاً يتطابق مع المكوّن العمودي للموصل عند `connector.adjustments[0]`:

```python
    # ارسم المكوّن العمودي للموصل.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```


النتيجة:

![ضبط الموصل 2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، أظهرنا ضبط موصل بسيط باستخدام المبادئ الأساسية. في السيناريوهات المعتادة، يجب مراعاة دوران الموصل وإعدادات عرضه (المتحكم بها بواسطة `connector.rotation`، `connector.frame.flip_h`، و `connector.frame.flip_v`). إليك كيفية سير العملية.

أولاً، أضف كائن إطار نص جديد (**To 1**) إلى الشريحة (للاتصال)، وأنشئ موصلاً أخضرًا جديدًا يربطه بالكائنات الموجودة.

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

    # ربط الكائنات باستخدام الموصل الذي تم إنشاؤه حديثًا.
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

ثانيًا، أنشئ شكلاً يتطابق مع الجزء **الأفقي** من الموصل الذي يمر عبر نقطة الضبط الجديدة للموصل، `connector.adjustments[0]`. استخدم القيم من `connector.rotation`، `connector.frame.flip_h`، و `connector.frame.flip_v`، وطبق صيغة تحويل الإحداثيات القياسية للدوران حول نقطة معينة `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90 درجة والموصل يُعرض رأسيًا، لذا يكون الكود المقابل:

```python
    # احفظ إحداثيات الموصل.
    x = connector.x
    y = connector.y
    
    # صحح إحداثيات الموصل إذا كان مقلوبًا.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # استخدم قيمة نقطة الضبط كإحداثي.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # حوّل الإحداثيات لأن sin(90°) = 1 و cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # حدد عرض الجزء الأفقي باستخدام قيمة نقطة الضبط الثانية.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```


النتيجة:

![ضبط الموصل 4](connector-adjusted-4.png)

لقد أظهرنا حسابات تتضمن ضبطًا بسيطًا ونقاط ضبط أكثر تعقيدًا (تلك التي تأخذ الدوران في الاعتبار). باستخدام هذه المعرفة، يمكنك تطوير نموذجك الخاص—أو كتابة كود—للحصول على كائن `GraphicsPath` أو حتى ضبط قيم نقاط ضبط الموصل بناءً على إحداثيات شريحة معينة.

## **إيجاد زوايا خط الموصل**

استخدم المثال أدناه لتحديد زاوية خطوط الموصل على شريحة باستخدام Aspose.Slides. ستتعلم كيفية قراءة نقاط نهاية الموصل وحساب اتجاهه لتتمكن من محاذاة الأسهم، التسميات، وغيرها من الأشكال بدقة.

1. إنشاء مثال من الفئة [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة عبر الفهرس.
1. الوصول إلى شكل خط الموصل.
1. استخدم عرض وارتفاع الخط، وعرض وارتفاع إطار الشكل، لحساب الزاوية.

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


## **الأسئلة الشائعة**

**كيف يمكنني معرفة ما إذا كان يمكن "لصق" موصل إلى شكل محدد؟**

تحقق من أن الشكل يوفر [مواقع الاتصال](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). إذا لم تكن هناك أي موقع أو كان العدد صفرًا، فإن اللصق غير متاح؛ في هذه الحالة استخدم نقاط النهاية الحرة وضعها يدويًا. من المنطقي التحقق من عدد المواقع قبل الإرفاق.

**ماذا يحدث للموصل إذا حذفت أحد الأشكال المتصلة؟**

ستنفصل نهاياته؛ يبقى الموصل على الشريحة كخط عادي بنقطة بداية/نهاية حرة. يمكنك إما حذفه أو إعادة تعيين الوصلات، وإذا لزم الأمر، [إعادة توجيه](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**هل يتم الحفاظ على ربط الموصلات عند نسخ شريحة إلى عرض آخر؟**

عادةً نعم، بشرط نسخ الأشكال المستهدفة أيضًا. إذا تم إدراج الشريحة في ملف آخر بدون الأشكال المتصلة، تصبح النهايات حرة وستحتاج إلى إرفاقها مرة أخرى.