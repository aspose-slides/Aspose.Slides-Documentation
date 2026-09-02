---
title: إدارة الموصلات في العروض التقديمية باستخدام JavaScript
linktitle: موصل
type: docs
weight: 10
url: /ar/nodejs-java/connector/
keywords:
- موصل
- نوع الموصل
- نقطة الموصل
- خط الموصل
- زاوية الموصل
- موقع الاتصال
- نقطة الضبط
- ربط الأشكال
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إضافة وربط وإعادة توجيه وتعديل وفحص الموصلات المستقيمة والملتوية والمنحنية في PowerPoint باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

الموصل هو خط يمكن أن يبقى موصولًا إلى شكلين عندما يتحرك أي من الشكلين. نهايته تُرفق بمواقع الاتصال، التي تُمثَّل بنقاط خضراء في PowerPoint. بعض الموصلات المنحنية والملتوية تُظهر أيضًا نقاط ضبط، التي تُمثَّل بنقاط برتقالية، وتتحكم في موضع أجزاء الموصل الفردية.

تمثل Aspose.Slides الموصلات عبر الفئة [Connector](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/connector/). يمكنك إنشاؤها، ربط نهاياتها بأشكال، اختيار مواقع الاتصال، إعادة توجيهها، وتعديل هندسة الموصلات التي تحتوي على نقاط ضبط.

## **أنواع الموصلات**

تضم الفئة [ShapeType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapetype/) إعدادات مسبقة للموصلات المستقيمة، المنحنية، والملتوية. يظهر الجدول التالي الهندسات المتاحة للموصل وعدد نقاط الضبط المعرفة لكل إعداد مسبق.

| الموصل | الصورة | عدد نقاط الضبط |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

عدد ومعنى نقاط الضبط جزء من الإعداد المسبق للموصل المختار. لا تفترض أن نوعي موصل مختلفين يعرضان نفس تخطيط المجموعة.

## **ربط شكلين**

استخدم [ShapeCollection.addConnector](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/addconnector/) لإضافة موصل، واستخدم [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) و[Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) لربط نهاياته. بعد ربط النهايتين، تقوم [Connector.reroute](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/connector/reroute/) باختيار مسار قصير بين الشكلين.

المثال التالي يربط قطعًا بيضاويًا ومستطيلًا بموصل ملتوي:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}

استدعاء `reroute` قد يغيّر قيمتي [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) و[setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). عيّن مواقع اتصال محددة بعد إعادة التوجيه إذا كان يجب أن تظل تلك المواقع ثابتة.

{{% /alert %}}

## **اختيار موقع الاتصال**

كل شكل قابل للاتصال يُبلغ عن عدد مواقع الاتصال عبر [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getconnectionsitecount/). تحقّق من فهرس الموقع الصفري‑المُستند قبل إسناده إلى نهاية الموصل؛ فعدد المواقع يختلف حسب هندسة الشكل.

هذا المثال يربط الموصل بموقع معين على الشكل الإهليلجي عندما يكون ذلك الموقع موجودًا:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط نقطة الموصل**

الموصلات التي تحتوي على نقاط ضبط تُظهرها عبر [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/geometryshape/). افحص كل [AdjustValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/) وتحقق من قيمة [getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/) قبل تعديلها باستخدام [setRawValue](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). القواعد العامة لتحديد تعديلات الشكل المسبقة موصوفة في [Shape Manipulation](/slides/ar/nodejs-java/shape-manipulations/).

عدد، ترتيب، معنى، والنطاق الصالح لقيم ضبط الموصل تعتمد على الإعداد المسبق للموصل. نوع الضبط للقراءة فقط، بينما قيمة الضبط قابلة للكتابة. طريقة القراءة فقط [getName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/getname/) توفر تعريفًا إضافيًا عندما يحتوي الموصل على أكثر من ضبط من نفس النوع الدلالي.

### **توجيه حول عائق**

في التخطيط التالي، موصل `BentConnector5` بين شكلين يمر عبر شكل ثالث:

![connector-obstruction](connector-obstruction.png)

هذا الكود يُنشئ الموصل المعوق:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تحريك الانحناء العمودي يغيّر المسار بحيث يتجاوز الموصل العائق:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

بدلاً من الافتراض أن الفهرس 1 للمجموعة يمثل دائمًا الانحناء العمودي، يبحث هذا المثال عن `ConnectorBendPositionY` ويعدّله فقط عندما يكون النوع الدلالي المتوقع موجودًا:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

يحتوي `BentConnector5` على ضبطين من نوع `ConnectorBendPositionX` وضبط واحد من نوع `ConnectorBendPositionY`. إذا ظهر النوع الذي تحتاجه أكثر من مرة، افحص `getName` والهندسة المعروفة لهذا الإعداد قبل اختيار أحدهما. إذا أبلغ ضبط عن `ShapeAdjustmentType.Custom`، اعتبر معناه ونطاقه خاصًا بالإعداد المسبق ولا تغيّره إلا إذا كان ذلك العقد معروفًا.

## **ربط قيم الضبط بهندسة الموصل**

بالنسبة للموصلات المنحنية، يمكن استخدام قيم الضبط لتقدير مواضع الأجزاء الفردية. هذه الحسابات خاصة بإعداد الموصل المسبق:

- `BentConnector4` عادةً يُظهر ضبطًا واحدًا من نوع `ConnectorBendPositionX` وضبطًا واحدًا من نوع `ConnectorBendPositionY`.
- بالنسبة لهذه المواضع، قسمة القيمة المُسترجعة من `getRawValue` على `100000` تُنتج الجزء من عرض أو ارتفاع إطار الموصل كما هو موضح في الأمثلة أدناه.
- يمكن تدوير إطار الموصل أو عكسه، لذا يجب تحويل إحداثيات الإطار قبل مقارنتها بإحداثيات الشريحة.

الأمثلة التالية تستخدم `getType` لتحديد الضبط أولًا. لا تُعامل فهارس المجموعة كمعرّفات قابلة للنقل.

### **موصل غير مُدوَّر**

التخطيط الأولي يحتوي على شكلين نصيين موصلين بـ `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

هذا المثال يفحص الموصل ويحصل على ضبط الانحناء الأفقي والعمودي:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

لتغيير الانحنائين، حدِّد كل نوع متوقع وعدّل القيم فقط بعد العثور على الاثنين:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

النتيجة موصل يتحرك فيه الجزءان الأفقي والعمودي:

![connector-adjusted-1](connector-adjusted-1.png)

بمجرد معرفة الأنواع الدلالية، يمكن تحويل قيمها إلى إحداثيات إطار الموصل. يرسم هذا المثال مستطيلًا رفيعًا فوق الجزء العمودي المتحكم بهما الضبطان:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

شكل الدليل يُظهر الجزء المُحسوب:

![connector-adjusted-2](connector-adjusted-2.png)

### **موصل مُدوَّر أو مقلوب**

عند توجيه نفس هندسة الموصل عموديًا، تؤثر قيم [Shape.getFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getframe/)، [ShapeFrame.getFlipH](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapeframe/getfliph/)، و[ShapeFrame.getFlipV](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapeframe/getflipv/) على التحويل من إحداثيات إطار الموصل إلى إحداثيات الشريحة.

هذا المثال يُنشئ ويُعدّل الموصل الموجه عموديًا:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الموصل المُعدَّل يظهر عموديًا بين الشكلين:

![connector-adjusted-3](connector-adjusted-3.png)

لزاوية دوران عشوائية `alpha`، دوِّر نقطة إطار الموصل `(x, y)` حول مركز الإطار `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

الكود التالي يتعامل مع التوجيه بزاوية 90 درجة المستخدم في هذا المثال ويرسم دليلًا أحمر فوق الجزء المقابل من الموصل:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

الدليل الأحمر يحدد الجزء المُحسوب بعد تحويل الإحداثيات:

![connector-adjusted-4](connector-adjusted-4.png)

هذه الصيغ تصف الإعدادات المستخدمة في الأمثلة، ليست نموذج موصل عالمي. تحقق من أنواع الضبط، توجيه الإطار، ونطاقات القيم قبل تطبيق نفس الحساب على إعداد مسبق مختلف.

## **إيجاد زاوية اتجاه الموصل**

يمكن حساب اتجاه موصل مستقيم من عرضه وارتفاعه، مع تطبيق انعكاسات أفقية ورأسية. المثال التالي يُظهر الزاوية في اتجاه عقارب الساعة من المحور الأفقي الموجب في إحداثيات الشريحة:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**كيف يمكنني معرفة ما إذا كان الموصل يمكن أن يُربط بشكل؟**

تحقّق من قيمة [getConnectionSiteCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getconnectionsitecount/) للشكل. القيمة الإيجابية تعني أن الشكل يُظهر مواقع اتصال. تحقق من فهرس الموقع المختار قبل إسناده إلى أي من نهايتي الموصل.

**هل يمكنني تحديد ضبط الموصل من خلال فهرس المجموعة؟**

الفهرس ذو معنى فقط لإعداد موصل معروف وتخطيط مجموعة معروف. تحقق من [AdjustValue.getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/) قبل تعديل قيمة، واستخدم [AdjustValue.getName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/adjustvalue/getname/) كمعلومات إضافية عندما يظهر النوع الدلالي نفسه أكثر من مرة.

**ماذا يحدث عندما يتم حذف الشكل المتصل؟**

تُفصل النهاية المقابلة للموصل. يبقى الموصل على الشريحة ويمكن حذفه، وضعه كخط حر، أو ربطه بشكل آخر.

**هل تُحافظ ربطات الموصل عند نسخ الشريحة؟**

تُحافظ الروابط عادةً عند نسخ الأشكال المتصلة مع الشريحة. إذا تم نسخ موصل دون أحد الأشكال الهدف، يجب ربط النهاية المتأثرة مجدداً.