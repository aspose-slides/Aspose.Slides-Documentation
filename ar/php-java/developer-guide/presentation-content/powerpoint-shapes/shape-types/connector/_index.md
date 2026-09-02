---
title: إدارة الموصلات في العروض التقديمية باستخدام PHP
linktitle: موصل
type: docs
weight: 10
url: /ar/php-java/connector/
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
- PHP
- Aspose.Slides
description: "تعلم كيفية إضافة، إرفاق، إعادة توجيه، تعديل، وفحص الموصلات المستقيمة، المنحنية، والمنحنية المنحدرة في PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

الموصل هو خط يمكن أن يبقى مثبتًا إلى شكلين عندما يتحرك أي من الشكلين. نهاياته تُرفق بمواقع الاتصال، التي تمثل بنقاط خضراء في PowerPoint. وبعض الموصلات المنحنية والمنحدرة تُظهر أيضًا نقاط تعديل، تمثل بنقاط برتقالية، تتحكم في موضع قطاعات الموصل الفردية.

Aspose.Slides تمثل الموصلات عبر الفئة [Connector](https://reference.aspose.com/slides/ar/php-java/aspose.slides/connector/) . يمكنك إنشاؤها، إرفاق نهاياتها بالأشكال، اختيار مواقع الاتصال، إعادة توجيهها، وتعديل هندسة الموصلات التي تحتوي على نقاط تعديل.

## **أنواع الموصلات**

الفئة [ShapeType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapetype/) تشمل إعدادات موصل مستقيم، منحنٍ، ومنحني. الجدول التالي يوضح الأشكال الهندسية المتاحة للموصل وعدد نقاط التعديل المعرفة لكل إعداد.

| الموصل | الصورة | عدد نقاط التعديل |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

عدد ومعنى نقاط التعديل جزء من إعداد الموصل المختار. لا تفترض أن نوعي موصل مختلفين يعرضان نفس تخطيط المجموعة.

## **ربط شكلين**

استخدم [ShapeCollection::addConnector](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addconnector/) لإضافة موصل، واستخدم [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/connector/setstartshapeconnectedto/) و[Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/connector/setendshapeconnectedto/) لإرفاق نهاياته. بعد إرفاق النهايتين، تقوم [Connector::reroute](https://reference.aspose.com/slides/ar/php-java/aspose.slides/connector/reroute/) باختيار مسار قصير بين الشكلين.

المثال التالي يربط إهليلجًا ومستطيلًا بموصل منحنٍ:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    $connector->reroute();

    $presentation->save("connected-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
استدعاء `reroute` يمكن أن يغيّر قيمتي [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) و[Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). قم بتعيين مواقع اتصال محددة بعد إعادة التوجيه إذا كان يجب أن تبقى تلك المواقع ثابتة.
{{% /alert %}}

## **اختيار موقع الاتصال**

كل شكل قابل للاتصال يُبلغ عن عدد المواقع عبر [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getconnectionsitecount/). تحقق من فهرس موقع صفري‑مبني قبل إسناده إلى نهاية الموصل؛ عدد المواقع يختلف بحسب هندسة الشكل.

هذا المثال يُرفق الموصل بموقع معين على الإهليلج عندما يكون هذا الموقع موجودًا:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);

    $preferredSiteIndex = 2;
    $connectionSiteCount = java_values($ellipse->getConnectionSiteCount());
    if ($preferredSiteIndex < $connectionSiteCount) {
        $connector->setStartShapeConnectionSiteIndex($preferredSiteIndex);
    } else {
        echo "The ellipse has only " . $connectionSiteCount . " connection sites." . PHP_EOL;
    }

    $presentation->save("specific-connection-site.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعديل نقطة الموصل**

الموصلات التي تحتوي على نقاط تعديل تُظهرها عبر [GeometryShape::getAdjustments](https://reference.aspose.com/slides/ar/php-java/aspose.slides/geometryshape/#getadjustments). فحص كل [AdjustValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/) وتحقق من قيمة [AdjustValue::getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/#gettype) قبل تغييرها باستخدام [AdjustValue::setRawValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/setrawvalue/). القواعد العامة لتحديد تعديلات الشكل المسبقة موضحة في [Shape Manipulation](/slides/ar/php-java/shape-manipulations/).

عدد، ترتيب، معنى، ونطاق القيم الصالحة لتعديلات الموصل تعتمد على إعداد الموصل. نوع التعديل للقراءة فقط، بينما قيمة التعديل قابلة للكتابة. الطريقة للقراءة فقط [AdjustValue::getName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/getname/) توفر تعريفًا إضافيًا عندما يحتوي الموصل على أكثر من تعديل من نفس النوع الدلالي.

### **التحرك حول عائق**

في التخطيط التالي، موصل `BentConnector5` بين شكلين يمر عبر شكل ثالث:

![connector-obstruction](connector-obstruction.png)

هذا الكود يُنشئ الموصل المعترض:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $presentation->save("connector-obstruction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تحريك الانحناء العمودي يغير المسار بحيث يتجاوز الموصل العائق:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

بدلاً من افتراض أن فهرس المجموعة `1` يمثل دائمًا الانحناء العمودي، يبحث هذا المثال عن `ConnectorBendPositionY` ويغيّره فقط عندما يكون النوع الدلالي المتوقع موجودًا:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentName = java_values($adjustment->getName());
        $adjustmentType = java_values($adjustment->getType());
        $rawValue = java_values($adjustment->getRawValue());
        echo $adjustmentName . ": " . $adjustmentType . ", raw value = " . $rawValue . PHP_EOL;
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
            break;
        }
    }

    if ($verticalBend === null) {
        echo "The connector does not expose a vertical bend adjustment." . PHP_EOL;
    } else {
        $verticalBend->setRawValue(60000);
        $presentation->save("connector-obstruction-fixed.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

يمتلك `BentConnector5` تعديلين `ConnectorBendPositionX` وتعديلًا واحدًا `ConnectorBendPositionY`. إذا ظهر النوع الذي تحتاجه أكثر من مرة، فافحص `getName` والهندسة المعروفة لهذا الإعداد قبل اختيار أحدهما. إذا أبلغ تعديل عن `ShapeAdjustmentType::Custom`، فاعتبر معناه ونطاقه خاصًا بالإعداد ولا تغيّره إلا بعد معرفة العقد.

## **ربط قيم التعديل بهندسة الموصل**

بالنسبة للموصلات المنحنية، يمكن استخدام قيم التعديل لتقدير مواضع القطاعات الفردية. هذه الحسابات خاصة بإعداد الموصل:

- `BentConnector4` عادةً يُظهر تعديلًا واحدًا `ConnectorBendPositionX` وتعديلًا واحدًا `ConnectorBendPositionY`.
- بالنسبة لهذه المواضع، قسمة القيمة المرتجعة من `getRawValue` على `100000` تُنتج جزء عرض أو ارتفاع إطار الموصل المستخدم في الأمثلة أدناه.
- يمكن أن يُدوَّر أو يُقلب إطار الموصل، لذا يجب تحويل إحداثيات الإطار قبل مقارنتها بإحداثيات الشريحة.

الأمثلة التالية تستخدم `getType` لتحديد التعديلات أولاً. لا تتعامل مع فهارس المجموعات كمعرفات محمولة.

### **موصل غير مدور**

التخطيط الأولي يحتوي على شكلين نصيين متصلين بـ `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

هذا المثال يفحص الموصل ويحصل على تعديلات الانحناء الأفقي والعمودي:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $targetShape->getTextFrame()->setText("To");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        echo $adjustment->getName() . ": " . $adjustment->getType() . ", raw value = " . $adjustment->getRawValue() . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

لتغيير كلا الانحنائين، ابحث عن كل نوع متوقع وعدّل القيم فقط بعد العثور على كلاهما:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);
        $presentation->save("connector-adjusted.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

النتيجة موصل تحركت قطعه الأفقيّة والعموديّة:

![connector-adjusted-1](connector-adjusted-1.png)

بمجرد معرفة الأنواع الدلالية، يمكن تحويل قيمها إلى إحداثيات إطار الموصل. هذا المثال يرسم مستطيلًا رفيعًا فوق القطعة العمودية التي يتحكم فيها تعديلّا الانحناء:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $x = $connectorX + $connectorWidth * $horizontalBendValue / 100000;
        $y = $connectorY;
        $height = $connectorHeight * $verticalBendValue / 100000;
        $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 1, $height);
        $presentation->save("connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

الشكل الدليل يحدد القطعة المحسوبة:

![connector-adjusted-2](connector-adjusted-2.png)

### **موصل مدور أو مقلوب**

عند توجيه نفس هندسة الموصل عموديًا، تؤثر قيم [Shape::getFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getframe/)، [ShapeFrame::getFlipH](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapeframe/getfliph/)، و[ShapeFrame::getFlipV](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapeframe/getflipv/) على تحويل إحداثيات إطار الموصل إلى إحداثيات الشريحة.

هذا المثال ينشئ ويعدّل الموصل الموجه عموديًا:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $targetShape->getTextFrame()->setText("To 1");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(102, 205, 170));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 20000);
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 200000);
        }
    }

    $presentation->save("vertical-connector-adjusted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الموصل المعدل يظهر عموديًا بين الشكلين:

![connector-adjusted-3](connector-adjusted-3.png)

لزاوية دوران عشوائية `alpha`، دوّر نقطة إطار الموصل `(x, y)` حول مركز الإطار `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

الكود التالي يعالج التوجيه بزاوية 90 درجة المستخدمة في هذا المثال ويرسم دليلًا أحمر فوق القطاع المقابل للموصل:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);

        $frame = $connector->getFrame();
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $flipH = java_values($frame->getFlipH()) == NullableBool::True;
        $flipV = java_values($frame->getFlipV()) == NullableBool::True;
        $centerX = java_values($frame->getCenterX());
        $centerY = java_values($frame->getCenterY());

        $x = $connectorX;
        $y = $connectorY;
        if ($flipH) {
            $x += $connectorWidth;
        }
        if ($flipV) {
            $y += $connectorHeight;
        }

        $x += $connectorWidth * $horizontalBendValue / 100000;
        $rotatedX = $centerX - $y + $centerY;
        $rotatedY = $x - $centerX + $centerY;
        $segmentWidth = $connectorHeight * $verticalBendValue / 100000;
        $guide = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $rotatedX, $rotatedY, $segmentWidth, 1);
        $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));

        $presentation->save("rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

الدليل الأحمر يحدد القطعة المحسوبة بعد تحويل الإحداثيات:

![connector-adjusted-4](connector-adjusted-4.png)

هذه الصيغ تصف الإعدادات المستخدمة في الأمثلة، لا نموذج موصل عالمي. تحقق من أنواع التعديل، توجيه الإطار، ونطاق القيم قبل تطبيق الحساب نفسه على إعداد مختلف.

## **العثور على زاوية اتجاه الموصل**

يمكن حساب اتجاه موصل مستقيم من عرضه وارتفاعه، مع مراعاة الانعكاسات الأفقية والعمودية. المثال التالي يُظهر الزاوية باتجاه عقارب الساعة من المحور الأفقي الموجب في إحداثيات الشريحة:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);

    $frame = $connector->getFrame();
    $flipH = java_values($frame->getFlipH()) == NullableBool::True;
    $flipV = java_values($frame->getFlipV()) == NullableBool::True;
    $width = java_values($connector->getWidth());
    $height = java_values($connector->getHeight());
    $deltaX = $width * ($flipH ? -1 : 1);
    $deltaY = $height * ($flipV ? -1 : 1);
    $angle = atan2($deltaY, $deltaX) * 180.0 / pi();

    if ($angle < 0) {
        $angle += 360;
    }

    printf("Connector direction: %.2f degrees%s", $angle, PHP_EOL);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان الموصل يمكنه الارتباط بشكل؟**  
تحقق من قيمة [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getconnectionsitecount/). عدد إيجابي يعني أن الشكل يقدم مواقع اتصال. تحقق من فهرس الموقع المختار قبل إسناده إلى أي طرف من الطرفين.

**هل يمكنني التعرف على تعديل الموصل عبر فهرس المجموعة؟**  
الفهرس ذو معنى فقط لإعداد موصل معروف وتخطيط مجموعة معروف. تحقق من [AdjustValue::getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/#gettype) قبل تعديل القيمة، واستخدم [AdjustValue::getName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/getname/) كمعلومات إضافية عندما يتكرر نفس النوع الدلالي أكثر من مرة.

**ماذا يحدث عندما يُحذف الشكل المرتبط؟**  
يصبح الطرف المقابل للمُوصل منفصلًا. يبقى الموصل على الشريحة ويمكن حذفه، أو وضعه كخط حر، أو إرفاقه بشكل آخر.

**هل تُحافظ روابط الموصل عند نسخ الشريحة؟**  
تُحافظ الروابط بشكل عام عندما يتم نسخ الأشكال المرتبطة مع الشريحة. إذا تم نسخ موصل دون أحد الأشكال المستهدفة، يجب إعادة إرفاق الطرف المتأثر مرة أخرى.