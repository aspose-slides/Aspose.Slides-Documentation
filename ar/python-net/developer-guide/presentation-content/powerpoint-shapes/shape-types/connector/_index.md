---
title: موصل
type: docs
weight: 10
url: /ar/python-net/connector/
keywords: "ربط الأشكال، الموصلات، أشكال PowerPoint، عرض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "ربط أشكال PowerPoint في Python"
---

موصل PowerPoint هو خط خاص يربط شكلين معًا ويبقى متصلًا بالأشكال حتى عندما يتم تحريكها أو إعادة وضعها على شريحة معينة.

عادةً ما تكون الموصلات متصلة بـ *نقاط الاتصال* (نقاط خضراء)، التي توجد على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عندما يقترب مؤشر الفأرة منها.

*نقاط التعديل* (نقاط برتقالية)، التي توجد فقط على موصلات معينة، تُستخدم لتعديل مواضع وأشكال الموصلات.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام موصلات مستقيمة، وزاوية (ملوية)، ومقوسة.

توفر Aspose.Slides هذه الموصلات:

| الموصل                         | الصورة                                                       | عدد نقاط التعديل            |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.LINE`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **ربط الأشكال باستخدام الموصلات**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `add_auto_shape` المعروضة بواسطة كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `add_auto_shape` المعروضة بواسطة كائن `Shapes` عن طريق تعريف نوع الموصل.
1. قم بربط الأشكال باستخدام الموصل.
1. استدعِ طريقة `reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي.

هذا الكود بلغة Python يوضح لك كيفية إضافة موصل (موصل مائل) بين شكلين (بيضاوي ومستطيل):

```python
import aspose.slides as slides

# ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف PPTX
with slides.Presentation() as input:
    # يصل إلى مجموعة الأشكال لشريحة معينة
    shapes = input.slides[0].shapes

    # يضيف شكل بيضاوي
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # يضيف شكل مستطيل
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 300, 100, 100)

    # يضيف شكل موصل إلى مجموعة أشكال الشريحة
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # يربط الأشكال باستخدام الموصل
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # يستدعي reroute الذي يحدد المسار الأقصر التلقائي بين الأشكال
    connector.reroute()

    # يحفظ العرض التقديمي
    input.save("Connecting shapes using connectors_out.pptx", slides.export.SaveFormat.PPTX)

```

{{% alert title="ملحوظة" color="warning" %}} 

تقوم طريقة `connector.reroute` بإعادة توجيه موصل وتلزمها بأن تأخذ أقصر مسار ممكن بين الأشكال. لتحقيق هدفها، قد تقوم الطريقة بتغيير نقاط `start_shape_connection_site_index` و `end_shape_connection_site_index`.

{{% /alert %}} 

## **تحديد نقطة الاتصال**

إذا كنت ترغب في أن يربط موصل شكلين باستخدام نقاط محددة على الأشكال، يجب عليك تحديد نقاط الاتصال المفضلة لديك بهذه الطريقة:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) إلى الشريحة باستخدام طريقة `add_auto_shape` المعروضة بواسطة كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `add_connector` المعروضة بواسطة كائن `Shapes` عن طريق تعريف نوع الموصل.
1. قم بربط الأشكال باستخدام الموصل.
1. قم بتعيين نقاط الاتصال المفضلة لديك على الأشكال.
1. احفظ العرض التقديمي.

هذا الكود بلغة Python يوضح عملية حيث يتم تحديد نقطة الاتصال المفضلة:

```python
import aspose.slides as slides

# ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف PPTX
with slides.Presentation() as presentation:
    # يصل إلى مجموعة الأشكال لشريحة معينة
    shapes = presentation.slides[0].shapes

    # يضيف شكل موصل إلى مجموعة أشكال الشريحة
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # يضيف شكل بيضاوي
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # يضيف شكل مستطيل
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 100, 100)

    # يربط الأشكال باستخدام الموصل
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # يحدد فهرس نقطة الاتصال المفضلة على الشكل البيضاوي
    wantedIndex = 6

    # يتحقق مما إذا كان الفهرس المفضل أقل من العدد الأقصى لمواقع الاتصال
    if ellipse.connection_site_count > wantedIndex:
        # يحدد نقطة الاتصال المفضلة على الشكل البيضاوي
        connector.start_shape_connection_site_index = wantedIndex

    # يحفظ العرض التقديمي
    presentation.save("Connecting_Shape_on_desired_connection_site_out.pptx", slides.export.SaveFormat.PPTX)

```

## **تعديل نقطة الموصل**

يمكنك تعديل موصل موجود من خلال نقاط التعديل الخاصة به. يمكن تعديل فقط الموصلات التي تحتوي على نقاط تعديل بهذه الطريقة. راجع الجدول تحت **[أنواع الموصلات](/slides/ar/python-net/connector/#types-of-connectors)** 

#### **حالة بسيطة**

اعتبر حالة يمر فيها موصل بين شكلين (A و B) عبر شكل ثالث (C):

![connector-obstruction](connector-obstruction.png)

الكود:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    sld = pres.slides[0]
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)

    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black

    connector.start_shape_connected_to = shapeFrom
    connector.end_shape_connected_to = shapeTo
    connector.start_shape_connection_site_index = 2
```

لتجنب أو تجاوز الشكل الثالث، يمكننا تعديل الموصل عن طريق تحريك خطه العمودي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```python
    adj2 = connector.adjustments[1]
    adj2.raw_value += 10000
```

### **حالات معقدة**

لإجراء تعديلات أكثر تعقيدًا، يجب أن تأخذ هذه الأمور بعين الاعتبار:

* نقطة التعديل للموصل مرتبطة ارتباطًا وثيقًا بصيغة تحسب وتحدد موقعها. لذلك قد تؤدي التغييرات في موقع النقطة إلى تغيير شكل الموصل.
* يتم تحديد نقاط تعديل الموصل بترتيب صارم في مصفوفة. يتم ترقيم نقاط التعديل من نقطة بدء الموصل إلى نقطة نهايته.
* تعكس قيم نقاط التعديل نسبة عرض/ارتفاع شكل الموصل.
  * يتم تحديد الشكل بحدود نقطة بدء الموصل ونقطة انتهاء الموصل مضروبًا في 1000.
  * تحدد النقطة الأولى، والثانية، والثالثة النسبة من العرض، والنسبة من الارتفاع، والنسبة من العرض (مرة أخرى) على التوالي.
* لحسابات تحدد إحداثيات نقاط تعديل الموصل، عليك أن تأخذ في الاعتبار دوران الموصل وانعكاسه. **ملحوظة** أن زاوية الدوران لجميع الموصلات المعروضة تحت **[أنواع الموصلات](/slides/ar/python-net/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

اعتبر حالة يرتبط فيها كائنين من إطار النص معًا من خلال موصل:

![connector-shape-complex](connector-shape-complex.png)

الكود:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # يحصل على الشريحة الأولى في العرض التقديمي
    sld = pres.slides[0]
    # يضيف أشكالًا سيتم ربطها معًا من خلال موصل
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shapeFrom.text_frame.text = "من"
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shapeTo.text_frame.text = "إلى"
    # يضيف موصل
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # يحدد اتجاه الموصل
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # يحدد لون الموصل
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # يحدد سمك خط الموصل
    connector.line_format.width = 3

    # يربط الأشكال معًا باستخدام الموصل
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shapeTo
    connector.end_shape_connection_site_index = 2

    # يحصل على نقاط التعديل للموصل
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
```

**التعديل**

يمكننا تغيير قيم نقاط تعديل الموصل من خلال زيادة النسبة المئوية للعرض والارتفاع بمقدار 20% و200%، على التوالي:

```python
    # يغير قيم نقاط التعديل
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتعريف نموذج يسمح لنا بتحديد إحداثيات وشكل الأجزاء الفردية من الموصل، دعونا ننشئ شكلًا يتوافق مع المكون الأفقي للموصل عند النقطة connector.adjustments[0]:

```python
    # رسم المكون العمودي للموصل

    x = connector.x + connector.width * adjValue_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjValue_1.raw_value / 100000
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، قمنا بعرض عملية تعديل موصل بسيطة باستخدام مبادئ أساسية. في الحالات العادية، يجب أن تأخذ دوران الموصل وعرضه (الذي يتم ضبطه بواسطة connector.rotation و connector.frame.flip_h و connector.frame.flip_v) في الاعتبار. سنوضح الآن هذه العملية.

أولاً، دعونا نضيف كائن إطار نص جديد (**إلى 1**) إلى الشريحة (لأغراض الربط) وننشئ موصلًا جديدًا (أخضر) يربطه بالأشياء التي أنشأناها بالفعل.

```python
    # ينشئ كائن ربط جديد
    shapeTo_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shapeTo_1.text_frame.text = "إلى 1"
    # ينشئ موصلًا جديدًا
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    # يربط الأشياء باستخدام الموصل الجديد
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shapeTo_1
    connector.end_shape_connection_site_index = 3
    # يحصل على نقاط تعديل الموصل
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
    # يغير قيم نقاط التعديل 
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، دعونا ننشئ شكلًا سيتوافق مع المكون الأفقي للموصل الذي يمر عبر نقطة تعديل الموصل الجديدة connector.adjustments[0]. سنستخدم القيم من بيانات الموصل لـ connector.rotation و connector.frame.flip_h و connector.frame.flip_v ونطبق صيغة تحويل الإحداثيات الشائعة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زواية دوران الكائن 90 درجة والموصل يظهر عموديًا، لذا فالكود المقابل هو:

```python
    # يحفظ إحداثيات الموصل
    x = connector.x
    y = connector.y
    # يصحح إحداثيات الموصل في حال ظهرت
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # يأخذ في نقطة التعديل قيمة كإحداثية
    x += connector.width * adjValue_0.raw_value / 100000
    
    #  يحول الإحداثيات حيث أن Sin(90) = 1 و Cos(90) = 0
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # يحدد عرض المكون الأفقي باستخدام قيمة نقطة التعديل الثانية
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد أظهرنا حسابات تتعلق بالتعديلات البسيطة ونقاط التعديل المعقدة (نقاط التعديل ذات زوايا الدوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذج خاص بك (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى تعيين قيم نقطة تعديل الموصل بناءً على إحداثيات الشريحة المحددة.

## **العثور على زاوية خطوط الموصل**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. الوصول إلى شكل خط الموصل.
1. استخدم عرض الخط وارتفاعه، وارتفاع إطار الشكل، وعرض إطار الشكل لحساب الزاوية.

هذا الكود بلغة Python يوضح عملية قمنا فيها بحساب الزاوية لشكل خط الموصل:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flipH, flipV):
    endLineX = w * (-1 if flipH else 1)
    endLineY = h * (-1 if flipV else 1)
    endYAxisX = 0
    endYAxisY = h
    angle = math.atan2(endYAxisY, endYAxisX) - math.atan2(endLineY, endLineX)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation(path + "ConnectorLineAngle.pptx") as pres:
    slide = pres.slides[0]
    for i in range(len(slide.shapes)):
        dir = 0.0
        shape = slide.shapes[i]
        if (type(shape) is slides.AutoShape):
            if shape.shape_type == slides.ShapeType.LINE:
                dir = get_direction(shape.width, shape.Height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            dir = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)

        print(dir)
```