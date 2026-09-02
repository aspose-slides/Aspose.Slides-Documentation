---
title: จัดการคอนเน็กเตอร์ในงานนำเสนอโดยใช้ PHP
linktitle: คอนเน็กเตอร์
type: docs
weight: 10
url: /th/php-java/connector/
keywords:
- คอนเน็กเตอร์
- ประเภทคอนเน็กเตอร์
- จุดคอนเน็กเตอร์
- เส้นคอนเน็กเตอร์
- มุมคอนเน็กเตอร์
- ตำแหน่งการเชื่อมต่อ
- จุดปรับค่า
- เชื่อมต่อรูปร่าง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่ม, เชื่อมต่อ, ปรับเส้นทางใหม่, ปรับค่า, และตรวจสอบคอนเน็กเตอร์ PowerPoint แบบตรง, โค้ง, และบิดด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

คอนเน็กเตอร์คือเส้นที่สามารถเชื่อมต่อกับรูปร่างสองรูปได้แม้ว่ารูปร่างใดจะเคลื่อนที่ จุดเชื่อมต่ออยู่ที่ตำแหน่งการเชื่อมต่อซึ่งแสดงด้วยจุดสีเขียวใน PowerPoint คอนเน็กเตอร์แบบโค้งและบิดบางประเภทยังมีจุดปรับค่าแสดงด้วยจุดสีส้ม ซึ่งควบคุมตำแหน่งของส่วนต่าง ๆ ของคอนเน็กเตอร์

Aspose.Slides แสดงคอนเน็กเตอร์โดยใช้คลาส [Connector](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/) คุณสามารถสร้าง, เชื่อมต่อปลายกับรูปร่าง, เลือกตำแหน่งการเชื่อมต่อ, ปรับเส้นทางใหม่, และแก้ไขเรขาคณิตของคอนเน็กเตอร์ที่มีจุดปรับค่าได้

## **ประเภทคอนเน็กเตอร์**

คลาส [ShapeType](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapetype/) มีพรีเซ็ตคอนเน็กเตอร์แบบตรง, บิด, และโค้ง ตารางต่อไปนี้แสดงเรขาคณิตของคอนเน็กเตอร์ที่มีให้ใช้และจำนวนจุดปรับค่าที่กำหนดโดยแต่ละพรีเซ็ต

| คอนเน็กเตอร์ | รูปภาพ | จำนวนจุดปรับค่า |
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

จำนวนและความหมายของจุดปรับค่าเป็นส่วนหนึ่งของพรีเซ็ตคอนเน็กเตอร์ที่เลือก ไม่ควรสมมติว่าประเภทคอนเน็กเตอร์ที่ต่างกันจะแสดงโครงสร้างคอลเลกชันเดียวกัน

## **เชื่อมต่อสองรูปร่าง**

ใช้ [ShapeCollection::addConnector](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addconnector/) เพื่อเพิ่มคอนเน็กเตอร์ และใช้ [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/setstartshapeconnectedto/) และ [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/setendshapeconnectedto/) เพื่อเชื่อมต่อปลายของมัน หลังจากเชื่อมต่อทั้งสองปลายแล้ว [Connector::reroute](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/reroute/) จะเลือกเส้นทางสั้นที่สุดระหว่างรูปร่าง

ตัวอย่างต่อไปนี้เชื่อมต่อวงรีและสี่เหลี่ยมด้วยคอนเน็กเตอร์แบบบิด:

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
การเรียก `reroute` สามารถเปลี่ยนค่าของ [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) และ [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/) ให้กำหนดตำแหน่งการเชื่อมต่อเฉพาะหลังจากปรับเส้นทางใหม่หากต้องการให้ตำแหน่งเหล่านั้นคงที่
{{% /alert %}}

## **เลือกตำแหน่งการเชื่อมต่อ**

แต่ละรูปร่างที่สามารถเชื่อมต่อได้รายงานจำนวนตำแหน่งผ่าน [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getconnectionsitecount/) ตรวจสอบดัชนีตำแหน่งที่เป็นศูนย์ก่อนนำไปใช้กับปลายคอนเน็กเตอร์; จำนวนตำแหน่งจะแตกต่างตามเรขาคณิตของรูปร่าง

ตัวอย่างนี้เชื่อมคอนเน็กเตอร์กับตำแหน่งเฉพาะบนวงรีเมื่อมีตำแหน่งนั้น:

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

## **ปรับจุดคอนเน็กเตอร์**

คอนเน็กเตอร์ที่มีจุดปรับค่าจะเปิดเผยผ่าน [GeometryShape::getAdjustments](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometryshape/#getadjustments) ตรวจสอบแต่ละ [AdjustValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/) และตรวจสอบค่า [AdjustValue::getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/#gettype) ก่อนเปลี่ยนค่าโดยใช้ [AdjustValue::setRawValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/setrawvalue/) กฎทั่วไปสำหรับการระบุการปรับค่าพรีเซ็ตของรูปแบบอธิบายไว้ใน [Shape Manipulation](/slides/th/php-java/shape-manipulations/)

จำนวน, ลำดับ, ความหมายและช่วงค่าที่เป็นไปได้ของการปรับค่าคอนเน็กเตอร์ขึ้นกับพรีเซ็ตคอนเน็กเตอร์ ประเภทการปรับค่าเป็นแบบอ่านอย่างเดียว ส่วนค่าการปรับเป็นแบบเขียนได้ วิธีการอ่านอย่างเดียว [AdjustValue::getName](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/getname/) ให้ข้อมูลเพิ่มเติมเมื่อคอนเน็กเตอร์มีการปรับค่าที่มีประเภทเชิงความหมายเดียวกันหลายรายการ

### **เลี่ยงอุปสรรค**

ในเลเอาต์ต่อไป `BentConnector5` ระหว่างสองรูปร่างจะผ่านรูปร่างที่สาม:

![connector-obstruction](connector-obstruction.png)

โค้ดนี้สร้างคอนเน็กเตอร์ที่ถูกบัง:

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

การย้ายการบิดแนวตั้งทำให้เส้นทางเปลี่ยนเป็นการหลบอุปสรรค:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

แทนการสมมติว่าดัชนีคอลเลกชัน `1` คือการบิดแนวตั้งเสมอ ตัวอย่างนี้ค้นหา `ConnectorBendPositionY` และเปลี่ยนค่าเฉพาะเมื่อพบประเภทเชิงความหมายที่คาดหวัง:

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

`BentConnector5` มีการปรับค่า `ConnectorBendPositionX` สองค่าและ `ConnectorBendPositionY` หนึ่งค่า หากประเภทที่ต้องการปรากฏหลายครั้งให้ตรวจสอบ `getName` และรูปร่างเรขาคณิตของพรีเซ็ตนั้นก่อนเลือกค่า หากการปรับค่ารายงานเป็น `ShapeAdjustmentType::Custom` ให้ถือว่าความหมายและช่วงเป็นของพรีเซ็ตนั้นและไม่เปลี่ยนจนกว่าจะทราบสัญญา

## **เชื่อมโยงค่าการปรับกับเรขาคณิตของคอนเน็กเตอร์**

สำหรับคอนเน็กเตอร์บิด ค่าการปรับสามารถใช้ประเมินตำแหน่งของส่วนต่าง ๆ ของคอนเน็กเตอร์ได้ การคำนวณเหล่านี้เป็นเฉพาะพรีเซ็ตคอนเน็กเตอร์:

- `BentConnector4` ปกติจะเปิดเผยการปรับค่า `ConnectorBendPositionX` หนึ่งค่าและ `ConnectorBendPositionY` หนึ่งค่า
- สำหรับตำแหน่งบิดเหล่านี้ การหารค่าที่ได้จาก `getRawValue` ด้วย `100000` จะให้ส่วนของความกว้างหรือความสูงของกรอบคอนเน็กเตอร์ที่ใช้ในตัวอย่างด้านล่าง
- กรอบคอนเน็กเตอร์อาจถูกหมุนหรือพลิก ดังนั้นพิกัดกรอบต้องแปลงก่อนเปรียบเทียบกับพิกัดสไลด์

ตัวอย่างต่อไปใช้ `getType` เพื่อตรวจสอบประเภทการปรับก่อน ไม่ใช้ดัชนีคอลเลกชันเป็นตัวระบุพกพา

### **คอนเน็กเตอร์ที่ไม่ได้หมุน**

เลเอาต์เริ่มต้นมีสองรูปข้อความเชื่อมต่อด้วย `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

ตัวอย่างนี้ตรวจสอบคอนเน็กเตอร์และรับค่าการบิดแนวนอนและแนวตั้ง:

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

เพื่อเปลี่ยนการบิดทั้งสอง ให้ค้นหาประเภทที่คาดหวังแต่ละประเภทและแก้ไขค่าหลังจากพบทั้งสอง:

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

ผลลัพธ์คือคอนเน็กเตอร์ที่ส่วนแนวนอนและแนวตั้งเคลื่อนย้าย:

![connector-adjusted-1](connector-adjusted-1.png)

เมื่อทราบประเภทเชิงความหมายแล้ว สามารถแปลงค่เป็นพิกัดกรอบคอนเน็กเตอร์ ตัวอย่างนี้วาดสี่เหลี่ยมบางบนส่วนแนวตั้งที่ควบคุมโดยการบิดสองค่า:

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

รูปร่างแนวทางทำเครื่องหมายส่วนที่คำนวณได้:

![connector-adjusted-2](connector-adjusted-2.png)

### **คอนเน็กเตอร์ที่หมุนหรือพลิก**

เมื่อเรขาคณิตคอนเน็กเตอร์เดียวกันถูกกว้างตามแนวตั้ง ค่า [Shape::getFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapeframe/getfliph/), และ [ShapeFrame::getFlipV](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapeframe/getflipv/) มีผลต่อการแปลงจากพิกัดกรอบคอนเน็กเตอร์เป็นพิกัดสไลด์

ตัวอย่างนี้สร้างและปรับคอนเน็กเตอร์ที่มีแนวตั้ง:

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

คอนเน็กเตอร์ที่ปรับแล้วปรากฏเป็นแนวตั้งระหว่างรูปร่าง:

![connector-adjusted-3](connector-adjusted-3.png)

สำหรับมุมการหมุนใด ๆ `alpha` ให้หมุนจุดกรอบคอนเน็กเตอร์ `(x, y)` รอบศูนย์กรอบ `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

โค้ดต่อไปจัดการกับการหมุน 90 องศาที่ใช้ในตัวอย่างนี้และวาดแนวทางสีแดงบนส่วนคอนเน็กเตอร์ที่สอดคล้อง:

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

แนวทางสีแดงทำเครื่องหมายส่วนที่คำนวณหลังการแปลงพิกัด:

![connector-adjusted-4](connector-adjusted-4.png)

สูตรเหล่านี้อธิบายพรีเซ็ตที่ใช้ในตัวอย่าง ไม่ใช่โมเดลคอนเน็กเตอร์ทั่วไป ตรวจสอบประเภทการปรับ, การวางแนวกรอบ, และช่วงค่าก่อนนำการคำนวณเดียวกันไปใช้กับพรีเซ็ตอื่น

## **หามุมทิศทางของคอนเน็กเตอร์**

ทิศทางของคอนเน็กเตอร์ตรงสามารถคำนวณจากความกว้างและความสูงพร้อมการพลิกแนวนอนและแนวตั้ง ตัวอย่างต่อไปรายงานมุมตามเข็มนาฬิกาจากแกนแนวนอนบวกในพิกัดสไลด์:

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

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบว่าคอนเน็กเตอร์สามารถเชื่อมต่อกับรูปร่างได้หรือไม่?**

ตรวจสอบค่าของ [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getconnectionsitecount/) ของรูปร่าง จำนวนบวกหมายถึงรูปร่างมีตำแหน่งการเชื่อมต่อ ตรวจสอบดัชนีตำแหน่งที่เลือกก่อนนำไปใช้กับปลายคอนเน็กเตอร์ใด ๆ

**ฉันสามารถระบุการปรับค่าคอนเน็กเตอร์ด้วยดัชนีของคอลเลกชันได้หรือไม่?**

ดัชนีมีความหมายเฉพาะพรีเซ็ตคอนเน็กเตอร์และโครงสร้างคอลเลกชันที่รู้จัก ตรวจสอบ [AdjustValue::getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/#gettype) ก่อนแก้ค่ และใช้ [AdjustValue::getName](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/getname/) เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดียวกันปรากฏหลายครั้ง

**เกิดอะไรขึ้นเมื่อรูปร่างที่เชื่อมต่อถูกลบ?**

ปลายคอนเน็กเตอร์ที่เชื่อมต่อกับรูปร่างนั้นจะถูกตัดการเชื่อมต่อ คอนเน็กเตอร์ยังคงอยู่บนสไลด์และสามารถลบ, ตั้งเป็นเส้นอิสระ, หรือเชื่อมต่อกับรูปร่างอื่นได้

**การผูกคอนเน็กเตอร์ยังคงอยู่เมื่อตัวสไลด์ถูกคัดลอกหรือไม่?**

โดยทั่วไปการผูกจะคงอยู่เมื่อรูปร่างที่เชื่อมต่อถูกคัดลอกพร้อมสไลด์ หากคอนเน็กเตอร์ถูกคัดลอกโดยไม่มีรูปร่างเป้าหมายหนึ่งด้าน ปลายที่ได้รับผลกระทบจะต้องเชื่อมต่อใหม่อีกครั้ง