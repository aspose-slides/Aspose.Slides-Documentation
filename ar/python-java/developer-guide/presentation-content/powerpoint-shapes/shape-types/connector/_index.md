---
title: إدارة الموصلات في العروض التقديمية باستخدام بايثون عبر جافا
linktitle: موصل
type: docs
weight: 10
url: /ar/python-java/connector/
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
description: "تعلم كيفية إضافة وربط وإعادة توجيه وتعديل وفحص الموصلات المستقيمة والمائلة والمنحنية في PowerPoint باستخدام Aspose.Slides للبايثون عبر جافا."
---
## **نظرة عامة**

الموصل هو خط يمكن أن يظل مرتبطًا بشكليّن عندما يتحرك أي من الشكلين. نهايته تلتصق بنقاط الاتصال، ممثلة بنقاط خضراء في PowerPoint. بعض الموصلات المنحنية والملتوية تعرض أيضًا نقاط تعديل، ممثلة بنقاط برتقالية، تتحكم في موضع مقاطع الموصل الفردية.

تمثل Aspose.Slides الموصلات من خلال الفئة [Connector](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connector/). يمكنك إنشاؤها، ربط نهاياتها بالأشكال، اختيار نقاط الاتصال، إعادة توجيهها، وتعديل هندسة الموصلات التي تحتوي على نقاط تعديل.

## **أنواع الموصلات**

تشتمل فئة [ShapeType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/) على إعدادات موصل مستقيم، مائل، ومنحني. يوضح الجدول التالي هندسات الموصل المتاحة وعدد نقاط التعديل المعرفة لكل إعداد مسبق.

| موصل | صورة | عدد نقاط التعديل |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

عدد ومعنى نقاط التعديل جزء من إعداد الموصل المحدد. لا تفترض أن نوعين مختلفين من الموصلات يعرضان نفس تخطيط المجموعة.

## **ربط شكلين**

استخدم [ShapeCollection.addConnector](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addConnector) لإضافة موصل، واستخدم [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connector/#setStartShapeConnectedTo) و[Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connector/#setEndShapeConnectedTo) لربط نهاياته. بعد ربط كلتا النهايتين، يحدد [Connector.reroute](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connector/#reroute) مسارًا قصيرًا بين الشكلين.

المثال التالي يربط إهليجًا ومستطيلًا بموصل مائل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
استدعاء [reroute](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connector/#reroute) يمكن أن يغيّر قيمتي [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) و[setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). عيّن مواقع اتصال محددة بعد إعادة التوجيه إذا كان يجب أن تبقى تلك المواقع ثابتة.
{{% /alert %}}

## **اختيار موقع الاتصال**

كل شكل قابل للاتصال يُبلغ عن عدد المواقع من خلال [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getConnectionSiteCount). تحقق من صحة فهرس موقع صفر‑مبني مفضل قبل تعيينه لنهاية الموصل؛ عدد المواقع يختلف حسب هندسة الشكل.

هذا المثال يربط الموصل بموقع معين على الإهليج عندما يكون هذا الموقع موجودًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعديل نقطة الموصل**

الموصلات التي تحتوي على نقاط تعديل تعرضها عبر [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ar/python-java/aspose.slides/geometryshape/#getAdjustments). افحص كل [AdjustValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/) وتحقق من قيمة [getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getType) قبل تغييرها باستخدام [setRawValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#setRawValue). القواعد العامة لتحديد تعديلات الشكل المسبق موصوفة في [Shape Manipulation](/slides/ar/python-java/shape-manipulations/).

عدد وترتيب ومعنى ونطاق القيم الصالحة لتعديلات الموصل يعتمد على إعداد الموصل. نوع التعديل للقراءة فقط، بينما قيمة التعديل قابلة للكتابة. طريقة القراءة فقط [getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getName) توفر تعريفًا إضافيًا عندما يحتوي الموصل على أكثر من تعديل واحد من النوع الدلالي نفسه.

### **مسار حول عقبة**

في التخطيط التالي، موصل [BentConnector5](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#BentConnector5) بين شكلين يمر عبر شكل ثالث:

![connector-obstruction](connector-obstruction.png)

هذا الكود ينشئ الموصل المعترض:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تحريك الانحناء العمودي يغيّر المسار بحيث يتجاوز الموصل العقبة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

بدلاً من افتراض أن فهرس المجموعة `1` يمثل دائمًا الانحناء العمودي، يبحث هذا المثال عن [ConnectorBendPositionY](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) ويغيّره فقط عندما يكون النوع الدلالي المتوقع موجودًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

موصل [BentConnector5](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#BentConnector5) يحتوي على تعديلين من نوع [ConnectorBendPositionX](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) وتعديل واحد من نوع [ConnectorBendPositionY](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). إذا ظهر النوع الذي تحتاجه أكثر من مرة، افحص [getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getName) والهندسة المعروفة لذلك الإعداد قبل الاختيار. إذا أبلغ تعديل عن [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#Custom)، فعامل مع معناه ونطاقه كإعداد خاص ولا تغيره إلا إذا كان الاتفاق معروفًا.

## **ربط قيم التعديل بهندسة الموصل**

بالنسبة للموصلات المائلة، يمكن استخدام قيم التعديل لتقدير مواضع المقاطع الفردية. هذه الحسابات خاصة بإعداد الموصل:

- عادةً ما يعرض [BentConnector4](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#BentConnector4) تعديلًا واحدًا من نوع [ConnectorBendPositionX](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) وتعديلًا واحدًا من نوع [ConnectorBendPositionY](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- لهذه المواضع، قسمة القيمة التي تُعيدها [getRawValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getRawValue) على `100000.0` ينتج الكسر من عرض أو ارتفاع إطار الموصل المستخدم في الأمثلة أدناه.
- قد يُدوَّر إطار الموصل أو يُقلب، لذا يجب تحويل إحداثيات الإطار قبل مقارنتها بإحداثيات الشريحة.

الأمثلة التالية تستخدم [getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getType) لتحديد التعديلات أولاً. هي لا تعالج فهارس المجموعة كمعرفات محمولة.

### **موصل غير دوَّر**

التخطيط الأولي يحتوي على شكلين نصيين متصلين بموصل [BentConnector4](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

هذا المثال يفحص الموصل ويحصل على تعديلَي الانحناء الأفقي والعمودي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

لتغيير الانحنائين، ابحث عن كل نوع متوقع وعدِّل القيم فقط بعد العثور على كليهما:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة موصل حركت مقاطعها الأفقية والعمودية:

![connector-adjusted-1](connector-adjusted-1.png)

بمجرد معرفة الأنواع الدلالية، يمكن تحويل قيمها إلى إحداثيات إطار الموصل. يرسم هذا المثال مستطيلًا رفيعًا فوق المقطع العمودي المتحكم بهما:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

شكل الدليل يوضح المقطع المحسوب:

![connector-adjusted-2](connector-adjusted-2.png)

### **موصل دوَّر أو قُلب**

عند توجيه نفس هندسة الموصل عموديًا، تؤثر قيم [Shape.getFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getFrame)، [ShapeFrame.getFlipH](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeframe/#getFlipH) و[ShapeFrame.getFlipV](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapeframe/#getFlipV) على التحويل من إحداثيات إطار الموصل إلى إحداثيات الشريحة.

هذا المثال ينشئ ويضبط الموصل الموجه عموديًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الموصل المعدل يظهر عموديًا بين الشكلين:

![connector-adjusted-3](connector-adjusted-3.png)

لزاوية دوران عشوائية `alpha`، دوّر نقطة إطار الموصل `(x, y)` حول مركز الإطار `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

الكود التالي يتعامل مع التوجيه بزاوية 90 درجة المستخدم في هذا المثال ويرسم دليلًا أحمر فوق المقطع المقابل للموصل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الدليل الأحمر يوضح المقطع المحسوب بعد تحويل الإحداثيات:

![connector-adjusted-4](connector-adjusted-4.png)

هذه الصيغ تصف الإعدادات المستخدمة في الأمثلة، ليست نموذجًا عالميًا للموصل. تحقق من أنواع التعديل، توجيه الإطار، ونطاق القيم قبل تطبيق نفس الحساب على إعداد مختلف.

## **إيجاد زاوية اتجاه الموصل**

يمكن حساب اتجاه موصل مستقيم من عرضه وارتفاعه مع مراعاة الانعكاسات الأفقية والعمودية. المثال التالي يبلغ الزاوية في اتجاه عقارب الساعة من المحور الأفقي الموجب بإحداثيات الشريحة:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان الموصل يمكن أن يتصل بشكل؟**

تحقق من قيمة [getConnectionSiteCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getConnectionSiteCount) للشكل. العدد الإيجابي يعني أن الشكل يعرض مواقع اتصال. تحقق من صحة فهرس الموقع المختار قبل تعيينه لأي من نهايتي الموصل.

**هل يمكنني تحديد تعديل موصل عبر فهرس المجموعة؟**

الفهرس ذو معنى فقط لإعداد موصل معروف وتخطيط مجموعة معروف. تحقق من [AdjustValue.getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getType) قبل تعديل قيمة، واستخدم [AdjustValue.getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/adjustvalue/#getName) كمعلومات إضافية عندما يتكرر النوع الدلالي نفسه أكثر من مرة.

**ماذا يحدث عندما يتم حذف الشكل المتصل؟**

تُفصل النهاية المقابلة للموصل. يبقى الموصل على الشريحة ويمكن حذفه، أو وضعه كخط حر، أو ربطه بشكل آخر.

**هل تُحفظ ارتباطات الموصل عند نسخ الشريحة؟**

تُحفظ الارتباطات عادةً عندما تُنسخ الأشكال المتصلة مع الشريحة. إذا تم نسخ موصل بدون أحد الأشكال المستهدفة، يجب ربط النهاية المتأثرة مرة أخرى.