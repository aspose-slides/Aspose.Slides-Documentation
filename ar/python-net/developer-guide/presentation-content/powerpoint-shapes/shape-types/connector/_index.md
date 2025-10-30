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
description: "مكّن تطبيقات بايثون من رسم وربط وتوجيه الخطوط تلقائيًا في عروض PowerPoint وOpenDocument — احصل على التحكم الكامل في الموصلات المستقيمة والمثنية والمنحنية."
---

## **المقدمة**

موصل PowerPoint هو خط متخصص يربط شكلين ويبقى ملتصقًا عندما يتم نقل الأشكال أو إعادة وضعها على الشريحة. تُرفق الموصلات بـ **نقاط الاتصال** (النقاط الخضراء) على الأشكال. تظهر نقاط الاتصال عندما يقترب المؤشر منها. **مقابض الضبط** (النقاط الصفراء)، المتوفرة في بعض الموصلات، تسمح لك بتعديل موضع وشكل الموصل.

## **أنواع الموصلات**

في PowerPoint يمكنك استخدام ثلاثة أنواع من الموصلات: مستقيم، مثني (زاوي)، ومنحني.

Aspose.Slides يدعم الأنواع التالية من الموصلات:

| نوع الموصل                     | الصورة                                                    | عدد نقاط الضبط |
| ------------------------------ | -------------------------------------------------------- | -------------- |
| `ShapeType.LINE`               | ![موصل خط](shapetype-lineconnector.png)                 | 0              |
| `ShapeType.STRAIGHT_CONNECTOR1`| ![موصل مستقيم 1](shapetype-straightconnector1.png)      | 0              |
| `ShapeType.BENT_CONNECTOR2`    | ![موصل مثني 2](shapetype-bent-connector2.png)           | 0              |
| `ShapeType.BENT_CONNECTOR3`    | ![موصل مثني 3](shapetype-bentconnector3.png)            | 1              |
| `ShapeType.BENT_CONNECTOR4`    | ![موصل مثني 4](shapetype-bentconnector4.png)            | 2              |
| `ShapeType.BENT_CONNECTOR5`    | ![موصل مثني 5](shapetype-bentconnector5.png)            | 3              |
| `ShapeType.CURVED_CONNECTOR2`  | ![موصل منحني 2](shapetype-curvedconnector2.png)          | 0              |
| `ShapeType.CURVED_CONNECTOR3`  | ![موصل منحني 3](shapetype-curvedconnector3.png)          | 1              |
| `ShapeType.CURVED_CONNECTOR4`  | ![موصل منحني 4](shapetype-curvedconnector4.png)          | 2              |
| `ShapeType.CURVED_CONNECTOR5`  | ![موصل منحني 5](shapetype.curvedconnector5.png)          | 3              |

## **ربط الأشكال بالموصلات**

يوضح هذا القسم كيفية ربط الأشكال بالموصلات في Aspose.Slides. ستضيف موصلاً إلى شريحة، وتُلحق نقطتي البداية والنهاية بالأشكال المستهدفة. يضمن استخدام مواقع الاتصال بقاء الموصل "ملصقًا" بالأشكال حتى عندما تتحرك أو يتغير حجمها.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة عبر فهرسها.
3. إضافة كائنين من الفئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `add_auto_shape` التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. إضافة موصل باستخدام طريقة `add_connector` التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) وتحديد نوع الموصل.
5. ربط الأشكال بالموصل.
6. استدعاء طريقة `reroute` لتطبيق أقصر مسار اتصال.
7. حفظ العرض التقديمي.

الكود التالي يوضح كيفية إضافة موصل مثني بين شكلين (إهليلج ومستطيل):

```python
import aspose.slides as slides

# إنشاء كائن Presentation لإنشاء ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى مجموعة الأشكال للشرائح الأولى.
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

{{% alert title="NOTE" color="warning" %}}

طريقة `connector.reroute` تعيد توجيه الموصل، مما يجعله يسلك أقصر مسار ممكن بين الأشكال. للقيام بذلك قد تقوم الطريقة بتغيير قيم `start_shape_connection_site_index` و `end_shape_connection_site_index`.

{{% /alert %}}

## **تحديد نقاط الاتصال**

يوضح هذا القسم كيفية ربط موصل بنقطة اتصال محددة على شكل في Aspose.Slides. من خلال استهداف مواقع اتصال دقيقة، يمكنك التحكم في توجيه الموصل وتخطيطه، مما ينتج مخططات نظيفة ومتوقعة في عروضك.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة عبر فهرسها.
3. إضافة كائنين من الفئة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `add_auto_shape` التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. إضافة موصل باستخدام طريقة `add_connector` على كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) وتحديد نوع الموصل.
5. ربط الأشكال بالموصل.
6. تعيين نقاط الاتصال المفضلة على الأشكال.
7. حفظ العرض التقديمي.

الكود التالي يوضح كيفية تحديد نقطة اتصال مفضلة:

```python
import aspose.slides as slides

# إنشاء كائن Presentation لإنشاء ملف PPTX.
with slides.Presentation() as presentation:

    # الوصول إلى مجموعة الأشكال للشرائح الأولى.
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

    # تعيين فهرس موقع الاتصال المفضل على الإهليلج.
    site_index = 6

    # التحقق من أن الفهرس المفضل يقع ضمن عدد المواقع المتاحة.
    if  ellipse.connection_site_count > site_index:
        # تعيين موقع الاتصال المفضل على شكل الإهليلج AutoShape.
        connector.start_shape_connection_site_index = site_index

    # حفظ العرض التقديمي.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط نقاط الموصل**

يمكنك تعديل الموصلات باستخدام نقاط الضبط الخاصة بها. فقط الموصلات التي تكشف عن نقاط ضبط يمكن تعديلها بهذه الطريقة. للحصول على تفاصيل حول أي الموصلات تدعم الضبط، راجع الجدول تحت [أنواع الموصلات](/slides/ar/python-net/connector/#connector-types).

### **حالة بسيطة**

تخيل حالة يكون فيها موصل بين شكلين (A و B) يتقاطع مع شكل ثالث (C):

![Connector obstruction](connector-obstruction.png)

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

لتجنب الشكل الثالث، اضبط الموصل بنقل قطعه العمودية إلى اليسار:

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **حالات معقدة**

لضبطات أكثر تقدماً، انظر إلى ما يلي:

- يتم التحكم في نقطة الضبط للموصل بواسطة صيغة تحدد موقعها. تعديل هذه النقطة قد يغيّر الشكل الكلي للموصل.
- تُخزن نقاط الضبط في مصفوفة مرتبة بصرامة، مُرقَّمة من بداية الموصل إلى نهايته.
- تمثل قيم نقاط الضبط نسبًا مئوية لعرض/ارتفاع شكل الموصل.
  - يُقيد الشكل بنقطتي البداية والنهاية للموصل ويُضرب في 1000.
  - النقطة الأولى والثانية والثالثة تمثل النسبة المئوية للعرض، للارتفاع، وللعرض مرة أخرى على الترتيب.
- عند حساب إحداثيات نقاط الضبط، يجب مراعاة دوران الموصل وانعكاسه. **ملاحظة:** لجميع الموصلات المذكورة تحت [أنواع الموصلات](/slides/ar/python-net/connector/#connector-types)، زاوية الدوران هي 0.

#### **الحالة 1**

تخيل حالة يكون فيها كائنان من إطار النص مرتبطان بموصل:

![Linked shapes](connector-shape-complex.png)

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
    # ضبط اتجاه الموصل.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # ضبط لون الموصل.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # ضبط سماكة خط الموصل.
    connector.line_format.width = 3

    # ربط الأشكال بالموصل.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # الحصول على نقاط تعديل الموصل.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**التعديل**

قم بتغيير قيم نقاط تعديل الموصل بزيادة نسبة العرض بنسبة 20 % ونسبة الارتفاع بنسبة 200 % على التوالي:

```python
    # تعديل قيم نقاط التعديل.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

النتيجة:

![Connector adjustment 1](connector-adjusted-1.png)

لتعريف نموذج يحدد إحداثيات وشكل مقاطع الموصل، أنشئ شكلاً يتوافق مع المكوّن العمودي للموصل عند `connector.adjustments[0]`:

```python
    # رسم المكوّن العمودي للموصل.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

النتيجة:

![Connector adjusted 2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، استعرضنا تعديلًا بسيطًا للموصل باستخدام مبادئ أساسية. في السيناريوهات العادية، يجب مراعاة دوران الموصل وإعدادات عرضه (التي يتحكم فيها `connector.rotation`، `connector.frame.flip_h` و `connector.frame.flip_v`). إليك كيفية تنفيذ ذلك.

أولًا، أضف كائن إطار نص جديد (**To 1**) إلى الشريحة (للاتصال)، وأنشئ موصلًا أخضرًا جديدًا يربطه بالكائنات الموجودة.

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

    # الحصول على نقاط تعديل الموصل.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # تعديل قيم نقاط التعديل.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

النتيجة:

![Connector adjusted 3](connector-adjusted-3.png)

ثانيًا، أنشئ شكلاً يتوافق مع المكوّن **الأفقي** للموصل الذي يمر عبر نقطة تعديل الموصل الجديدة `connector.adjustments[0]`. استخدم القيم من `connector.rotation`، `connector.frame.flip_h`، و `connector.frame.flip_v`، وطبق معادلة تحويل الإحداثيات القياسية للدوران حول نقطة معينة `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90° والموصل معروض عموديًا، لذا يكون الكود المقابل:

```python
    # حفظ إحداثيات الموصل.
    x = connector.x
    y = connector.y
    
    # تصحيح إحداثيات الموصل إذا كان مقلوبًا.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # استخدام قيمة نقطة التعديل كإحداثي.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # تحويل الإحداثيات لأن sin(90°) = 1 و cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # تحديد عرض المكوّن الأفقي باستخدام قيمة نقطة التعديل الثانية.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

النتيجة:

![Connector adjusted 4](connector-adjusted-4.png)

لقد استعرضنا حسابات تتضمن تعديلات بسيطة وأكثر تعقيدًا (تلك التي تأخذ الدوران في الاعتبار). باستخدام هذه المعرفة، يمكنك بناء نموذجك الخاص—أو كتابة كود—للحصول على كائن `GraphicsPath` أو حتى ضبط قيم نقاط تعديل الموصل بناءً على إحداثيات شريحة محددة.

## **اكتشاف زوايا خطوط الموصل**

استخدم المثال أدناه لتحديد زاوية خطوط الموصل في شريحة باستخدام Aspose.Slides. ستتعلم كيفية قراءة نقاط النهاية للموصل وحساب اتجاهه لتتمكن من محاذاة الأسهم، التسميات، وغيرها من الأشكال بدقة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة عبر الفهرس.
3. الوصول إلى شكل خط الموصل.
4. استخدام عرض وارتفاع الخط، وعرض وارتفاع إطار الشكل، لحساب الزاوية.

الكود التالي يوضح كيفية حساب زاوية شكل خط الموصل:

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

**كيف يمكنني معرفة ما إذا كان يمكن "لصق" موصل إلى شكل معين؟**

تحقق مما إذا كان الشكل يُظهر [مواقع الاتصال](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). إذا لم توجد أو كان العدد صفرًا، فإن اللصق غير متاح؛ في هذه الحالة استخدم نقاط النهاية الحرة وضعها يدويًا. من المنطقي التحقق من عدد المواقع قبل الإرفاق.

**ماذا يحدث للموصل إذا حذفت أحد الأشكال المرتبطة به؟**

سيتم فصل نهاياته؛ سيبقى الموصل على الشريحة كخط عادي بنقطة بداية/نهاية حرة. يمكنك إما حذفه أو إعادة توصيله، وإذا لزم الأمر، استخدم [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**هل يتم الحفاظ على ارتباطات الموصل عند نسخ شريحة إلى عرض تقديمي آخر؟**

عمومًا نعم، شريطة أن تُنسخ الأشكال المستهدفة أيضًا. إذا تم إدراج الشريحة في ملف آخر دون الأشكال المتصلة، تصبح النهايات حرة وستحتاج إلى إرفاقها مرة أخرى.