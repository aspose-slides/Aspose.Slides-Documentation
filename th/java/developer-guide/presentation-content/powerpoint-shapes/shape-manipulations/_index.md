---
title: จัดการรูปร่างการนำเสนอใน Java
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/java/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- คัดลอกรูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ ID รูปร่าง interop
- ข้อความทางเลือกของรูปร่าง
- จุดปรับรูปร่าง
- การปรับรูปร่างที่ตั้งไว้
- เรขาคณิตของรูปร่าง
- รูปแบบเลย์เอาต์ของรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- พลิกรูปร่าง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, ปรับ, คัดลอก, ลบ, ซ่อน, จัดลำดับใหม่, ส่งออก, จัดแนว, และพลิกรูปร่างการนำเสนอด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides for Java แสดงรูปร่างบนสไลด์เป็น [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) ที่จัดลำดับตามลำดับ ซึ่งคอลเลคชันนี้เป็นทั้งที่คุณค้นหาและแก้ไขรูปร่างและเป็นแหล่งของลำดับการจัดซ้อน: ดัชนี `0` คือรูปร่างที่อยู่ท้ายนที่สุด ส่วนดัชนีสุดท้ายคือรูปร่างที่อยู่หน้าที่สุด

บทความนี้ทำตามโมเดลนั้น โดยอธิบายวิธีระบุรูปร่างอย่างมั่นคงและแก้ไขจุดปรับรูปแบบที่ตั้งไว้ จากนั้นแสดงวิธีคัดลอก ลบ ซ่อน และจัดลำดับใหม่ของรูปร่าง ส่วนสุดท้ายจะครอบคลุมการจัดรูปแบบระดับเลย์เอาต์ การส่งออกเป็น SVG การจัดแนว และการตั้งค่าการพลิกภาพ ตัวอย่างแต่ละอันเป็นอิสระ ดังนั้นคุณสามารถใช้เฉพาะการดำเนินการที่ workflow ของคุณต้องการได้

## **ระบุและค้นหารูปร่าง**

ดัชนีของคอลเลคชันสะดวกเมื่อประมวลผลไฟล์ที่รู้จัก แต่ไม่ใช่ตัวระบุที่คงที่ การเพิ่ม ลบ หรือจัดลำดับใหม่ของรูปร่างสามารถเปลี่ยนดัชนีของมันได้ เลือกตัวระบุตามวิธีที่การนำเสนอถูกสร้างและดูแลรักษา:

- [Name](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getName--) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและตรวจสอบได้ง่ายในแถบ Selection ของ PowerPoint ชื่อสามารถแก้ไขได้และไม่ได้รับการรับประกันว่าจะแม่นเอกลักษณ์ ดังนั้นจึงควรกำหนดแนวปฏิบัติการตั้งชื่อหากโค้ดพึ่งพา
- [AlternativeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getAlternativeText--) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้สร้างกำหนดไว้แล้วระบุรูปร่างนั้น มันมองเห็นได้โดยผู้ใช้ อาจแปลเป็นภาษาต่าง ๆ หรือเขียนใหม่เพื่อการเข้าถึง และไม่ได้รับการรับประกันว่าเป็นเอกลักษณ์ อย่าเปลี่ยนข้อความการเข้าถึงที่มีความหมายให้กลายเป็นคีย์ฐานข้อมูลอย่างเงียบ ๆ
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) เป็นตัวระบุแบบอ่านอย่างเดียวที่มีเอกลักษณ์ภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint interop ใช้ ใช้เมื่อทำการเชื่อมต่อกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ไม่คลุมเครือตลอดช่วงชีวิตของรูปร่าง รูปร่างที่คัดลอกหรือสร้างใหม่จะเป็นรูปร่างที่ต่างออกไปและจะได้รับ ID ของตนเอง

เมธอด [getUniqueId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getUniqueId--) ที่เกี่ยวข้องส่งคืนตัวระบุที่มีขอบเขตระดับการนำเสนอ แต่ตัวระบนั้นออกแบบมาสำหรับแอด‑อินและอาจถูกกำหนดใหม่ ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร หากต้องการอัตลักษณ์ระยะยาว ควรเก็บการแมปในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปร่างที่คาดหวังยังคงมีอยู่

ตัวอย่างต่อไปนี้ค้นหาด้วยชื่อโดยเปรียบเทียบแบบตรงและรายงาน Interop ID ระดับสไลด์ เมื่อเทมเพลตไม่มีรูปร่างที่คาดหวัง โค้ดจะแสดงผลนั้นแทนที่จะดำเนินต่อด้วยอ็อบเจกต์ที่ผิด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

เมื่อการดำเนินการเฉพาะกับประเภทของรูปร่าง ให้ตรวจสอบอินเทอร์เฟซก่อนใช้สมาชิกที่เฉพาะเจาะจง ประโยคตัวอย่างนี้อัปเดตข้อความและข้อความทางเลือกเฉพาะเมื่ออ็อบเจกต์ที่ตั้งชื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **ระบุและแก้ไขการปรับรูปที่ตั้งไว้**

รูปร่างเรขาคณิตที่ตั้งไว้สามารถเปิดเผยจุดปรับที่ควบคุมฟีเจอร์เช่น ขนาดมุม อัตราส่วนลูกศร หรือมุมโค้งได้ เข้าถึงผ่านคอลเลคชันอ่าน‑อย่างเดียว [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/th/java/com.aspose.slides/igeometryshape/#getAdjustments--) คอลเลคชันนี้มาจากรูปร่างเอง แต่ละ [IAdjustValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/) มีค่าที่สามารถเปลี่ยนได้

อย่าพึ่งพาเฉพาะดัชนีคอลเลคชันที่คงที่ ให้วนลูปผ่านการปรับและตรวจสอบเมธอดอ่าน‑อย่างเดียว [getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/#getType--) ซึ่งค่าประเภท [ShapeAdjustmentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapeadjustmenttype/) บรรยายว่าการปรับนั้นควบคุมอะไร เมธอดอ่าน‑อย่างเดียว [getName](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/#getName--) ให้ข้อมูลการระบุเพิ่มเติมและมีประโยชน์อย่างยิ่งเมื่อพรีเซ็ตมีการปรับมากกว่าหนึ่งรายการที่มีประเภทเชิงความหมายเดียวกัน

ใช้เมธอดค่าที่ตรงกับความหมายของการปรับ:

| ประเภทการปรับ | วัตถุประสงค์ | ค่าที่จะเปลี่ยน |
|---|---|---|
| `CornerSize` | ขนาดของมุมโค้ง | [setRawValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | ความหนาของหางลูกศร | `setRawValue` |
| `ArrowheadLength` | ความยาวของหัวศร | `setRawValue` |
| `ArrowheadWidth` | ความกว้างของหัวศร | `setRawValue` |
| `StartAngle` | มุมเริ่มต้นของพายหรือโค้ง | [setAngleValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | มุมสิ้นสุดของพายหรือโค้ง | `setAngleValue` |

`getType` และ `getName` คืนข้อมูลแบบอ่าน‑อย่างเดียว `getRawValue` และ `setRawValue` ทำงานกับจำนวนเต็มในหน่วยเรขาคณิตดั้งเดิมของพรีเซ็ต ส่วน `getAngleValue` และ `setAngleValue` ทำงานกับมุมเป็นองศา จำนวน, ลำดับ, ความหมายและช่วงค่าที่ถูกต้องของการปรับขึ้นอยู่กับพรีเซ็ต [ShapeType](https://reference.aspose.com/slides/th/java/com.aspose.slides/igeometryshape/#getShapeType--) ค่าที่ใช้ได้กับพรีเซ็ตหนึ่งอาจไม่ถูกต้องหรือให้ผลต่างกันกับพรีเซ็ตอื่น

เมื่อ `getType` คืนค่า `ShapeAdjustmentType.Custom` API จะไม่รู้ความหมายเชิงมาตรฐาน ตรวจสอบ `getName` ประเภทพรีเซ็ตและค่าที่มีอยู่ และอย่าเปลี่ยนการปรับเว้นแต่คุณรู้ความหมายและช่วงค่าที่คาดหวัง แม้สำหรับประเภทที่รู้จักแล้ว อย่าลืมตรวจสอบว่าชนิดเดียวกันปรากฏมากกว่าหนึ่งครั้งหรือไม่ก่อนเลือกค่า บทความ [Connector](/slides/th/java/connector/) แสดงสถานการณ์นี้กับการปรับการโค้งของคอนเน็กเตอร์

ตัวอย่างเต็มต่อไปนี้สร้างเวอร์ชันเริ่มต้นและเวอร์ชันที่แก้ไขของสามรูปร่างที่ตั้งไว้ โดยวนลูปผ่านการปรับทุกอย่าง รายงานชื่อและประเภทของมัน เปลี่ยนค่าที่เกี่ยวข้องกับขนาดผ่าน `setRawValue` เปลี่ยนมุมผ่าน `setAngleValue` แล้วบันทึกผล คอลัมน์ซ้ายคงเรขาคณิตเริ่มต้น; คอลัมน์ขวาแสดงสี่เหลี่ยมมุมโค้ง, ลูกศรสี่ทาง, และพายที่ถูกปรับ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มหัวข้อสำหรับคอลัมน์รูปทรงเริ่มต้นและรูปทรงที่ปรับค่า
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่าทำให้โค้ดชัดเจนเกี่ยวกับเจตนาและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลคชันเดียวกันมีความหมายเดียวกันในพรีเซ็ตต่าง ๆ

## **แก้ไขคอลเลคชันของรูปร่าง**

เมธอดเพิ่ม, คัดลอก, ลบ, และจัดลำดับใหม่ทำงานบนคอลเลคชันโดยทันที หากการดำเนินการเปลี่ยนจำนวนหรือลำดับของรูปร่าง อย่าอ้างอิงดัชนีที่เก็บไว้ก่อนการดำเนินการนั้นต่อไป

### **คัดลอกรูปร่าง**

[addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) สร้างสำเนาอิสระและต่อท้ายลงในคอลเลคชันเป้าหมาย [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) ก็สร้างสำเนาเช่นกัน แต่วางไว้ที่ดัชนี z‑order ที่ระบุ การ overload ที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; overload ที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างสร้างสไลด์ปลายทาง คัดลอกสี่เหลี่ยมที่มีป้ายกำกับไปด้านหน้า และแทรกสำเนาที่สองไว้ด้านหลัง การเปลี่ยนแปลงใด ๆ กับสำเนาใดสำเนาหนึ่งก็ไม่กระทบรูปร่างต้นฉบับ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปร่างรวมถึงชื่อและข้อความทางเลือก กำหนดตัวระบุตรรกะใหม่ให้กับสำเนาหากค่าดังกล่าวต้องเป็นเอกลักษณ์ ทรัพยากรที่ใช้โดยรูปร่างเชิงซับซ้อนจะจัดการโดยการนำเสนอ แต่สำเนายังคงเป็นรายการคอลเลคชันใหม่พร้อมอัตลักษณ์รูปร่างใหม่

### **ลบรูปร่าง**

[remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) ลบอ็อบเจกต์รูปร่างเฉพาะจากคอลเลคชันของมัน เมื่อทำการลบหลายรายการระหว่างการวนลูปโดยอ้างอิงดัชนี ให้เดินจากท้ายสุดเพื่อให้ดัชนีที่เหลือยังคงถูกต้อง

ตัวอย่างลบรูปร่างทุกอันที่มีชื่อที่กำหนดไว้ มันอ่านรูปร่างที่ดัชนีปัจจุบัน ไม่ใช่รายการคอลเลคชันคงที่ และไม่ได้ทำการคาสท์รูปร่างโดยไม่จำเป็น

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หลังการลบ จำนวนรูปร่างและดัชนีของรูปร่างต่อมาจะเปลี่ยน การอ้างอิงรูปร่างที่ไม่ได้รับผลกระทบยังคงน่าเชื่อถือกว่าการบันทึกดัชนี ควรพิจารณาคอนเน็กเตอร์, แอนิเมชัน, และฟีเจอร์การนำเสนออื่น ๆ ที่อาจอ้างอิงอ็อบเจกต์ที่ถูกลบ; การลบรูปร่างที่มองเห็นได้อาจเปลี่ยนมากกว่าลักษณะของสไลด์เท่านั้น

### **ซ่อนรูปร่าง**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setHidden-boolean-) เป็น `true` จะทำให้รูปร่างยังคงอยู่ในคอลเลคชันแต่ไม่ปรากฏในสไลด์โชว์ปกติ ดัชนี, การจัดรูปแบบและเนื้อหายังคงพร้อมให้โค้ดใช้ ดังนั้นการซ่อนจึงเหมาะกับองค์ประกอบทางเลือกที่อาจต้องการเรียกคืนในภายหลัง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การซ่อนไม่ใช่การลบหรือการรักษาความปลอดภัย อ็อบเจกต์ยังคงถูกค้นพบและสามารถทำให้มองเห็นได้อีกครั้งโดยผู้ใช้หรือโดยโค้ด และยังคงเป็นส่วนหนึ่งของไฟล์การนำเสนอ

### **เปลี่ยน Z‑Order**

รูปร่างที่ซ้อนทับกันจะถูกวาดตามลำดับคอลเลคชัน [reorder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ย้ายรูปร่างที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องคัดลอก ดัชนี `0` คือด้านหลัง; `size() - 1` คือด้านหน้า

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สี่เหลี่ยมถูกสร้างก่อนและเริ่มต้นอยู่ด้านหลังวงรี การย้ายมันไปยังดัชนีสุดท้ายจะทำให้มันอยู่ด้านหน้า ให้ทำการสรุป Z‑Order หลังจากเพิ่มหรือคัดลอกรูปร่างที่เกี่ยวข้องทั้งหมด เพราะการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการคอลเลคชันใหม่และอาจเปลี่ยนสแต็กที่ตั้งใจไว้

## **ตรวจสอบรูปร่างบนสไลด์เลย์เอาต์**

สไลด์ปกติ, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์มีคอลเลคชันรูปร่างแยกกัน รูปร่างในคอลเลคชันเลย์เอาต์ไม่ใช่อ็อบเจกต์เดียวกับรูปร่างที่อยู่ในตำแหน่งคล้ายกันบนสไลด์ปกติ ตรวจสอบรูปร่างเลย์เอาต์เมื่อคุณต้องการทำความเข้าใจหรือเปลี่ยนรูปแบบที่เลย์เอาต์จัดให้

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getFillFormat--) และ [LineFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getLineFormat--) ของแต่ละรูปร่างในเลย์เอาต์โดยไม่สมมติว่าทุกรูปร่างเป็น `AutoShape`

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

การแก้ไขเลย์เอาต์อาจมีผลต่อหลายสไลด์ที่ใช้เลย์เอาต์นั้น ก่อนเปลี่ยนรูปร่างในเลย์เอาต์ให้ตรวจสอบว่าสไลด์ปกติสืบทอดอ็อบเจกต์นั้นหรือมีการเขียนทับในระดับท้องถิ่น และทดสอบทุกสไลด์ที่ใช้เลย์เอาต์นั้น

## **ส่งออกรูปร่างเป็น SVG**

[writeAsSvg](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) เขียนเนื้อหาที่เรนเดอร์ของรูปร่างหนึ่งลงสตรีม ผลลัพธ์จะมีเฉพาะรูปร่างนั้น ไม่รวมพื้นหลังสไลด์ทั้งหมดหรือรูปร่างข้างเคียง

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

ให้เปิดการนำเสนอไว้ขณะเรนเดอร์ ผลลัพธ์ขึ้นกับการจัดรูปแบบของรูปร่างและทรัพยากรเช่น ฟอนต์และรูปภาพ หากต้องการภาพรวมทั้งหมด ให้ส่งออกสไลด์แทนการส่งออกรูปร่างเดี่ยว ตัวเรียกต้องเป็นเจ้าของสตรีมและต้องปิดสตรีมเอง

## **จัดแนวรูปร่าง**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) overloads ให้จัดแนวได้ทั้งทั้งหมดหรือเฉพาะดัชนีคอลเลคชันที่เลือก [ShapesAlignmentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapesalignmenttype/) กำหนดขอบ, เส้นศูนย์กลาง หรือโหมดการกระจาย ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปร่างที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปร่างให้ชิดขอบบนของสไลด์ การอ้างอิงรูปร่างที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันของมันก่อนทำการจัดแนว

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การจัดแนวเปลี่ยนตำแหน่ง ไม่ใช่ Z‑Order การจัดแนวเชิงสัมพันธ์โดยปกติจำเป็นต้องมีอย่างน้อยสองรูปร่าง ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปร่างจำนวนพอที่จะกำหนดระยะห่าง หากคุณแก้ไขคอลเลคชันก่อนเรียกเมธอด ให้คำนวณดัชนีใหม่

## **พลิกรูปร่าง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การพลิกแนวนอนและแนวตั้ง, และการหมุน ค่า `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/java/com.aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิด, `NotDefined` คงสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น

การนำเสนออินพุตด้านล่างมีรูปร่างหนึ่งที่ไม่ได้พลิก

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่นทั้งหมดไว้และแทนที่เฉพาะการตั้งค่าพลิกสองค่าเท่านั้น ซึ่งสำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ใหม่จะทับกรอบทั้งหมด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปร่างที่บันทึกจะถูกสะท้อนแนวนอนและแนวตั้งในขณะที่คงตำแหน่ง, ขนาดและการหมุนเดิม

![The shape after flipping](flipped_shape.png)

## **FAQ**

**ควรใช้ดัชนีคอลเลคชันเป็นตัวระบุรูปร่างหรือไม่?**

ใช้เฉพาะสำหรับการประมวลผลสั้น ๆ ที่คอลเลคชันจะไม่เปลี่ยนแปลงก่อนใช้ดัชนี แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ผ่านการตรวจสอบสำหรับเทมเพลตที่สร้างโดยคน หรือ `OfficeInteropShapeId` สำหรับงาน interop ระดับสไลด์

**การซ่อนรูปร่างทำให้มันออกจาก Z‑Order หรือไม่?**

ไม่ การซ่อนจะทำให้รูปร่างยังคงอยู่ในคอลเลคชันที่ดัชนีเดียวกัน สามารถค้นหา, จัดลำดับใหม่, แก้ไข หรือทำให้มองเห็นได้อีกครั้ง

**ทำไมรูปร่างที่คัดลอกจึงปรากฏอยู่หน้ารูปร่างอื่น?**

`addClone` จะต่อท้ายสำเนาที่ส่วนสุดของคอลเลคชัน ซึ่งเป็นหน้าที่ Z‑Order ใช้ `insertClone` เพื่อระบุดัชนีเริ่มต้น หรือใช้ `reorder` หลังจากเพิ่มรูปร่างทั้งหมด

**สามารถใช้ดัชนีคงที่เพื่อระบุการปรับรูปร่างพรีเซ็ตได้หรือไม่?**

ได้เฉพาะหลังจากยืนยันพรีเซ็ตและรูปแบบคอลเลคชันที่ตรงครบ แนะนำให้วนลูปผ่าน `IGeometryShape.getAdjustments` และตรวจสอบ `IAdjustValue.getType`; ใช้ `IAdjustValue.getName` เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดียวกันปรากฏมากกว่าหนึ่งครั้ง.