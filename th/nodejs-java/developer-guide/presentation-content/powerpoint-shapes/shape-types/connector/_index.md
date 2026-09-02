---
title: จัดการตัวเชื่อมในงานนำเสนอด้วย JavaScript
linktitle: ตัวเชื่อม
type: docs
weight: 10
url: /th/nodejs-java/connector/
keywords:
- ตัวเชื่อม
- ประเภทตัวเชื่อม
- จุดตัวเชื่อม
- เส้นตัวเชื่อม
- มุมตัวเชื่อม
- ตำแหน่งการเชื่อมต่อ
- จุดปรับค่า
- เชื่อมต่อรูป
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, แนบ, รีรูท, ปรับและตรวจสอบตัวเชื่อม PowerPoint แบบตรง, โค้งและบิดด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java"
---
## **ภาพรวม**

ตัวเชื่อมคือเส้นที่สามารถคงการเชื่อมต่อกับรูปสองรูปเมื่อรูปใดรูปหนึ่งเคลื่อนที่ ข้อต่อของมันเชื่อมต่อกับตำแหน่งการเชื่อมต่อ ซึ่งแสดงด้วยจุดสีเขียวใน PowerPoint บางตัวเชื่อมที่โค้งและบิดงอยังมีจุดปรับค่า แสดงด้วยจุดสีส้ม ที่ควบคุมตำแหน่งของส่วนย่อยของตัวเชื่อมแต่ละส่วน

Aspose.Slides แสดงตัวเชื่อมผ่านคลาส [Connector](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/) คุณสามารถสร้างตัวเชื่อม แนบปลายของมันกับรูปเลือกตำแหน่งการเชื่อมต่อ รีรูทและแก้ไขเรขาคณิตของตัวเชื่อมที่มีจุดปรับค่าได้

## **ประเภทตัวเชื่อม**

คลาส [ShapeType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapetype/) มีพรีเซ็ตตัวเชื่อมแบบตรง, แบบบิด, และแบบโค้ง ตารางต่อไปนี้แสดงเรขาคณิตของตัวเชื่อมที่พร้อมใช้งานและจำนวนจุดปรับค่าที่กำหนดโดยแต่ละพรีเซ็ต

| ตัวเชื่อม | Image | จำนวนจุดปรับค่า |
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

จำนวนและความหมายของจุดปรับค่าขึ้นอยู่กับพรีเซ็ตตัวเชื่อมที่เลือก อย่าคาดว่าแบบตัวเชื่อมสองแบบที่แตกต่างกันจะเปิดเผยโครงสร้างคอลเลกชันเดียวกัน

## **เชื่อมต่อรูปสองรูป**

ใช้ [ShapeCollection.addConnector](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/addconnector/) เพื่อเพิ่มตัวเชื่อม และใช้ [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) กับ [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) เพื่อเชื่อมต่อปลายของมัน หลังจากเชื่อมต่อปลายทั้งสองแล้ว [Connector.reroute](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/reroute/) จะเลือกเส้นทางสั้นสุดระหว่างรูป

ตัวอย่างต่อไปนี้เชื่อมต่อรูปวงรีกับสี่เหลี่ยมโดยใช้ตัวเชื่อมแบบบิด:

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
การเรียก `reroute` อาจทำให้ค่าของ [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) และ [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/) เปลี่ยนแปลงได้ ให้กำหนดตำแหน่งการเชื่อมต่อที่ระบุหลังจากรีรูท หากต้องการให้ตำแหน่งเหล่านั้นคงที่
{{% /alert %}}

## **เลือกตำแหน่งการเชื่อมต่อ**

รูปที่สามารถเชื่อมต่อได้แต่ละรูปจะบอกจำนวนตำแหน่งผ่าน [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getconnectionsitecount/)。ตรวจสอบดัชนีตำแหน่งแบบศูนย์ก่อนกำหนดให้กับปลายของตัวเชื่อม; จำนวนตำแหน่งจะแตกต่างกันตามรูปเรขาคณิต

ตัวอย่างนี้แนบตัวเชื่อมกับตำแหน่งเฉพาะบนวงรีเมื่อมีตำแหน่งนั้น:

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

## **ปรับค่าจุดของตัวเชื่อม**

ตัวเชื่อมที่มีจุดปรับค่าจะเปิดเผยค่าผ่าน [GeometryShape.getAdjustments](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/geometryshape/)。ตรวจสอบทุก [AdjustValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/) และดูค่า [getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/) ก่อนเปลี่ยนด้วย [setRawValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/setrawvalue/)。กฎทั่วไปสำหรับการระบุการปรับค่าพรีเซ็ตรูปอธิบายไว้ใน [Shape Manipulation](/slides/th/nodejs-java/shape-manipulations/)

จำนวน ลำดับ ความหมาย และช่วงค่าที่เป็นไปได้ของการปรับค่าตัวเชื่อมขึ้นอยู่กับพรีเซ็ต ตัวปรับค่าจะเป็นแบบอ่านอย่างเดียว ส่วนค่าการปรับจะสามารถเขียนได้ วิธีอ่านอย่างเดียว [getName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/getname/) ให้ข้อมูลเพิ่มเติมเมื่อตัวเชื่อมมีการปรับค่าที่มีประเภทเชิงความหมายเดียวกันมากกว่าหนึ่งรายการ

### **หลบเส้นทางอุปสรรค**

ในเลย์เอาต์ต่อไป ตัวเชื่อม `BentConnector5` ระหว่างสองรูปจะผ่านรูปที่สาม:

![connector-obstruction](connector-obstruction.png)

โค้ดนี้สร้างตัวเชื่อมที่ถูกบัง:

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

การย้ายการบิดแนวตั้งเปลี่ยนเส้นทางเพื่อให้ตัวเชื่อมหลบอุปสรรค:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

แทนที่จะสันนิษฐานว่าดัชนีคอลเลกชัน `1` คือการบิดแนวตั้งเสมอ ตัวอย่างนี้ค้นหา `ConnectorBendPositionY` และเปลี่ยนค่าเฉพาะเมื่อพบประเภทเชิงความหมายที่คาดหวัง:

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

`BentConnector5` มีการปรับค่า `ConnectorBendPositionX` สองค่าและ `ConnectorBendPositionY` หนึ่งค่า หากประเภทที่ต้องการปรากฏหลายครั้ง ให้ตรวจสอบ `getName` และเรขาคณิตของพรีเซ็ตนั้นก่อนเลือกใช้ หากการปรับค่ารายงานเป็น `ShapeAdjustmentType.Custom` ให้ถือว่าความหมายและช่วงค่าของมันเป็นแบบพรีเซ็ตเฉพาะและไม่ควรเปลี่ยนจนกว่าจะทราบสัญญาเหล่านั้น

## **เชื่อมโยงค่าการปรับกับเรขาคณิตของตัวเชื่อม**

สำหรับตัวเชื่อมแบบบิด ค่า ปรับ สามารถใช้ประมาณตำแหน่งของส่วนย่อยแต่ละส่วน การคำนวณเหล่านี้จำเพาะต่อพรีเซ็ตตัวเชื่อม:

- `BentConnector4` ปกติจะแสดงการปรับค่า `ConnectorBendPositionX` หนึ่งค่าและ `ConnectorBendPositionY` หนึ่งค่า
- สำหรับตำแหน่งบิดเหล่านี้ การหารค่าที่ได้จาก `getRawValue` ด้วย `100000` จะให้ส่วนของความกว้างหรือความสูงของกรอบตัวเชื่อมตามตัวอย่างด้านล่าง
- กรอบตัวเชื่อมอาจถูกหมุนหรือพลิก ดังนั้นพิกัดของกรอบต้องแปลงก่อนนำไปเปรียบเทียบกับพิกัดสไลด์

ตัวอย่างต่อไปนี้ใช้ `getType` เพื่อตรวจสอบการปรับก่อน จากนั้นจึงทำงาน ไม่ถือว่าดัชนีคอลเลกชันเป็นตัวระบุที่พกพาได้

### **ตัวเชื่อมที่ไม่ได้หมุน**

เลย์เอาต์เริ่มต้นมีรูปข้อความสองรูปเชื่อมด้วย `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

ตัวอย่างนี้ตรวจสอบตัวเชื่อมและดึงการปรับบิดแนวนอนและแนวตั้ง:

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

เพื่อเปลี่ยนบิดทั้งสอง ให้ค้นหาชนิดที่คาดหวังแต่ละชนิดและแก้ไขค่าหลังจากพบครบทั้งสอง:

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

ผลลัพธ์คือตัวเชื่อมที่ส่วนแนวนอนและแนวตั้งเลื่อนไป:

![connector-adjusted-1](connector-adjusted-1.png)

เมื่อรู้ประเภทเชิงความหมายแล้ว ค่าที่ได้สามารถแปลงเป็นพิกัดกรอบตัวเชื่อม ตัวอย่างนี้วาดสี่เหลี่ยมบางเหนือส่วนแนวตั้งที่ควบคุมโดยการบิดสองค่า:

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

รูปแบบแนะแนวระบุส่วนที่คำนวณได้:

![connector-adjusted-2](connector-adjusted-2.png)

### **ตัวเชื่อมที่หมุนหรือพลิก**

เมื่อเรขาคณิตเดียวกันถูกวางแนวตั้ง ค่า [Shape.getFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapeframe/getfliph/), และ [ShapeFrame.getFlipV](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapeframe/getflipv/) มีผลต่อการแปลงจากพิกัดกรอบตัวเชื่อมเป็นพิกัดสไลด์

ตัวอย่างนี้สร้างและปรับตัวเชื่อมที่วางแนวตั้ง:

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

ตัวเชื่อมที่ปรับแล้วปรากฏเป็นแนวตั้งระหว่างรูป:

![connector-adjusted-3](connector-adjusted-3.png)

สำหรับมุมการหมุน 任意 `alpha` ให้หมุนจุดกรอบตัวเชื่อม `(x, y)` รอบศูนย์กลางกรอบ `(x0, y0)` :

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

โค้ดต่อไปนี้จัดการกับการวางแนว 90 องศาที่ใช้ในตัวอย่างและวาดแนวทางสีแดงเหนือส่วนตัวเชื่อมที่สอดคล้องกัน:

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

แนวทางสีแดงระบุส่วนที่คำนวณหลังการแปลงพิกัด:

![connector-adjusted-4](connector-adjusted-4.png)

สูตรเหล่านี้อธิบายพรีเซ็ตที่ใช้ในตัวอย่าง ไม่ใช่โมเดลตัวเชื่อมสากล ตรวจสอบประเภทการปรับ, การวางเฟรม, และช่วงค่าก่อนนำสูตรเดียวกันไปใช้กับพรีเซ็ตอื่น

## **หาองศาทิศทางของตัวเชื่อม**

ทิศทางของตัวเชื่อมตรงสามารถคำนวณจากความกว้างและความสูง พร้อมพิจารณาการพลิกแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้รายงานมุมตามเข็มนาฬิกาจากแกนแนวนอนบวกในพิกัดสไลด์:

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

## **คำถามที่พบบ่อย**

**ฉันจะรู้ว่าตัวเชื่อมสามารถเชื่อมต่อกับรูปได้หรือไม่?**

ตรวจสอบค่าของ [getConnectionSiteCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getconnectionsitecount/) ของรูป จำนวนบวกหมายความว่ารูปมีตำแหน่งการเชื่อมต่อ ตรวจสอบดัชนีตำแหน่งที่เลือกก่อนกำหนดให้กับปลายของตัวเชื่อมใด ๆ

**ฉันสามารถระบุตำแหน่งการปรับของตัวเชื่อมโดยใช้ดัชนีคอลเลกชันได้หรือไม่?**

ดัชนีมีความหมายเฉพาะกับพรีเซ็ตตัวเชื่อมและโครงสร้างคอลเลกชันที่รู้ ตรวจสอบ [AdjustValue.getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/) ก่อนแก้ไขค่า และใช้ [AdjustValue.getName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/getname/) เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดียวกันปรากฏหลายครั้ง

**เกิดอะไรขึ้นเมื่อรูปที่เชื่อมต่อถูกลบ?**

ปลายของตัวเชื่อมที่เชื่อมต่อจะถอดออก ตัวเชื่อมยังคงอยู่บนสไลด์และสามารถลบ, ตั้งเป็นเส้นอิสระ, หรือเชื่อมต่อกับรูปอื่นได้

**การเชื่อมต่อของตัวเชื่อมจะถูกเก็บไว้เมื่อคัดลอกสไลด์หรือไม่?**

โดยทั่วไปการเชื่อมต่อจะถูกเก็บไว้เมื่อรูปที่เชื่อมต่อถูกคัดลอกพร้อมสไลด์ หากตัวเชื่อมถูกคัดลอกโดยไม่มีรูปเป้าหมายหนึ่งรูป ปลายที่ได้รับผลกระทบต้องเชื่อมต่อใหม่อีกครั้ง