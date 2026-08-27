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
- موقع الاتصال
- نقطة تعديل
- ربط الأشكال
- PowerPoint
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تعلم كيفية إضافة، ربط، إعادة توجيه، تعديل، وفحص الموصلات المستقيمة، المنحنية، والمقوسة في PowerPoint باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

الموصل هو خط يمكن أن يظل مرتبطًا بشكليّن عندما يتحرك أحدهما. نهايته تتصل بمواقع الاتصال، التي تمثَّل بنقاط خضراء في PowerPoint. بعض الموصلات المنحنية والمنحرفة تُظهر أيضًا نقاط تعديل، تمثَّل بنقاط برتقالية، تتحكم في موضع أقسام الموصل الفردية.

Aspose.Slides تمثّل الموصلات من خلال واجهة [IConnector](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iconnector/) . يمكنك إنشاءها، ربط نهاياتها بالأشكال، اختيار مواقع الاتصال، إعادة توجيهها، وتعديل هندسة الموصلات التي تحتوي على نقاط تعديل.

## **أنواع الموصل**

التعداد [ShapeType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapetype/) يتضمن إعدادات موصل مستقيم، منحني، ومنحني. يوضح الجدول التالي هندسات الموصل المتاحة وعدد نقاط التعديل التي يُحدِّدها كل إعداد.

| الموصل | الصورة | عدد نقاط التعديل |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

عدد ومعنى نقاط التعديل جزء من إعداد الموصل المحدد. لا تفترض أن نوعي موصل مختلفين يكشفان عن نفس تخطيط المجموعة.

## **ربط شكلين**

استخدم [IShapeCollection.add_connector](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapecollection/add_connector/) لإضافة موصل، وعيّن خصائص [start_shape_connected_to](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iconnector/start_shape_connected_to/) و [end_shape_connected_to](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iconnector/end_shape_connected_to/). بعد ربط الطرفين، [IConnector.reroute](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iconnector/reroute/) يختار مسارًا قصيرًا بين الشكلين.

المثال التالي يربط إهليلجًا ومستطيلًا بموصل منحني:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="تحذير" %}}
استدعاء `reroute` يمكن أن يغيّر قيمتي [start_shape_connection_site_index](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) و [end_shape_connection_site_index](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). عيّن مواقع اتصال محددة بعد إعادة التوجيه إذا كان يجب أن تظل تلك المواقع ثابتة.
{{% /alert %}}

## **اختيار موقع الاتصال**

كل شكل قابل للاتصال يبلغ عن عدد المواقع عبر [connection_site_count](https://reference.aspose.com/slides/ar/python-net/aspose.slides/igeometryshape/connection_site_count/). تحقق من فهرس موقع صفري أساسي مفضَّل قبل تعيينه إلى طرف موصل؛ عدد المواقع يختلف حسب هندسة الشكل.

هذا المثال يربط الموصل بموقع معين على الإهليلج عندما يكون ذلك الموقع موجودًا:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط نقطة الموصل**

الموصلات التي تحتوي على نقاط تعديل تكشف عنها عبر [IGeometryShape.adjustments](https://reference.aspose.com/slides/ar/python-net/aspose.slides/igeometryshape/adjustments/). افحص كل [IAdjustValue](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iadjustvalue/) وتحقق من [type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iadjustvalue/type/) قبل تغيير [raw_value](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iadjustvalue/raw_value/). للتعامل العام مع الأشكال، راجع [Shape Manipulation](/slides/ar/python-net/shape-manipulations/).

عدد وترتيب ومعنى ونطاق القيم الصالحة لتعديلات الموصل يعتمد على إعداد الموصل. خاصية `type` للقراءة فقط، بينما قيمة التعديل قابلة للكتابة. خاصية [name](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iadjustvalue/name/) للقراءة فقط توفر تعريفًا إضافيًا عندما يحتوي الموصل على أكثر من تعديل لنفس النوع الدلالي.

### **التحرك حول عائق**

في التخطيط التالي، موصل `ShapeType.BENT_CONNECTOR5` بين شكلين يمر عبر شكل ثالث:

![connector-obstruction](connector-obstruction.png)

هذا الكود ينشئ الموصل المتعطّل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

تحريك الانحناء العمودي يغيّر المسار بحيث يتجاوز الموصل العائق:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

بدلاً من افتراض أن فهرس المجموعة `1` يمثل دائمًا الانحناء العمودي، يبحث هذا المثال عن `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` ويغيّره فقط عندما يكون النوع الدلالي المتوقع موجودًا:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

موصل `ShapeType.BENT_CONNECTOR5` يحتوي على تعديلين لـ `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` وتعديل واحد لـ `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. إذا ظهر النوع الذي تحتاجه أكثر من مرة، افحص `name` والهندسة المعروفة لهذا الإعداد قبل اختيار أحدهما. إذا أبلغ تعديل عن [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapeadjustmenttype/)، فاعتبر معناه ونطاقه خاصًا بالإعداد ولا تغيّره حتى يعرف العقد.

## **ربط قيم التعديل بهندسة الموصل**

للموصلات المنحنية، يمكن استخدام قيم التعديل لتقدير مواضع الأقسام الفردية. هذه الحسابات خاصة بإعداد الموصل:

- `ShapeType.BENT_CONNECTOR4` عادةً يكشف عن تعديل واحد لـ `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` وتعديل واحد لـ `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`.
- لهذه المواضع، `raw_value / 100000` ينتج الجزء من عرض أو ارتفاع إطار الموصل المستخدم في الأمثلة أدناه.
- يمكن تدوير أو عكس إطار الموصل، لذلك يجب تحويل إحداثيات الإطار قبل مقارنتها بإحداثيات الشريحة.

الأمثلة التالية تستخدم `type` لتحديد التعديلات أولًا. لا تتعامل مع فهارس المجموعة كمُعرّفات محمولة.

### **موصل غير مدور**

التخطيط الأولي يحتوي على شكلين نصيين متصلين بموصل `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

هذا المثال يفحص الموصل ويحصل على تعديلات الانحناء الأفقية والعمودية:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

لتغيير الانحنائين، حدّد كل نوع متوقع وعدّل القيم فقط بعد العثور على الاثنين:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة موصل تحركت أقسامه الأفقية والعمودية:

![connector-adjusted-1](connector-adjusted-1.png)

بمجرد معرفة الأنواع الدلالية، يمكن تحويل قيمها إلى إحداثيات إطار الموصل. هذا المثال يرسم مستطيلًا رفيعًا على القسم العمودي الذي يتحكم به تعديلّا الانحناء:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

الشكل الدليلي يوضح الجزء المحسوب:

![connector-adjusted-2](connector-adjusted-2.png)

### **موصل مدور أو مقلوب**

عندما تكون هندسة الموصل نفسها موجهة عموديًا، تؤثر قيم [frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iconnector/frame/)، [flip_h](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapeframe/flip_h/)، و[flip_v](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishapeframe/flip_v/) على التحويل من إحداثيات إطار الموصل إلى إحداثيات الشريحة.

هذا المثال ينشئ ويضبط الموصل الموجه عموديًا:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

الموصل المُعدَل يظهر عموديًا بين الشكلين:

![connector-adjusted-3](connector-adjusted-3.png)

لزاوية دوران عشوائية `alpha`، دوّر نقطة إطار الموصل `(x, y)` حول مركز الإطار `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

الكود التالي يتعامل مع التوجيه بزاوية 90 درجة المستخدم في هذا المثال ويرسم دليلًا أحمرًا على القسم المقابل من الموصل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

الدليل الأحمر يوضح الجزء المحسوب بعد تحويل الإحداثيات:

![connector-adjusted-4](connector-adjusted-4.png)

هذه الصيغ تصف الإعدادات المستخدمة في الأمثلة، ليست نموذجًا عالميًا للموصل. تحقّق من أنواع التعديل، توجيه الإطار، ونطاقات القيم قبل تطبيق نفس الحساب على إعداد مختلف.

## **إيجاد زاوية اتجاه الموصل**

يمكن حساب اتجاه الموصل المستقيم من عرضه وارتفاعه، مع تطبيق الانعكاسات الأفقية والعمودية. المثال التالي يُظهر الزاوية في اتجاه عقارب الساعة من المحور الأفقي الموجب في إحداثيات الشريحة:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **الأسئلة الشائعة**

**كيف يمكنني معرفة ما إذا كان الموصل يمكن أن يرتبط بشكل؟**  
تحقق من [connection_site_count](https://reference.aspose.com/slides/ar/python-net/aspose.slides/igeometryshape/connection_site_count/) للشكل. عدد إيجابي يعني أن الشكل يكشف عن مواقع اتصال. تحقّق من فهرس الموقع المحدد قبل تعيينه إلى أي طرف من الموصل.

**هل يمكنني تحديد تعديل موصل عبر فهرسه في المجموعة؟**  
الفهرس ذو معنى فقط بالنسبة لإعداد موصل معروف وتخطيط مجموعة معروف. افحص [IAdjustValue.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iadjustvalue/type/) قبل تعديل قيمة، واستخدم [IAdjustValue.name](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iadjustvalue/name/) كمعلومات إضافية عندما يتكرر نفس النوع الدلالي أكثر من مرة.

**ماذا يحدث عندما يُحذف الشكل المتصل؟**  
ينفصل الطرف المقابل من الموصل. يظل الموصل على الشريحة ويمكن حذفه أو وضعه كخط حر أو ربطه بشكل آخر.

**هل يتم الحفاظ على ربط الموصلات عندما تُنسخ الشريحة؟**  
تُحفظ الروابط عادةً عندما تُنسخ الأشكال المتصلة مع الشريحة. إذا نُسخ موصل دون أحد الأشكال المستهدفة، يجب ربط الطرف المتأثر مرة أخرى.