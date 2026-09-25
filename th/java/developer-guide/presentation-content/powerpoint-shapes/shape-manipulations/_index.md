---
title: จัดการรูปทรงการนำเสนอใน Java
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/java/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงการนำเสนอ
- รูปทรงบนสไลด์
- ค้นหารูปทรง
- ทำสำเนารูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ ID รูปทรง interop
- ข้อความสำรองของรูปทรง
- จุดปรับรูปทรง
- การปรับรูปทรงตั้งล่วงหน้า
- เรขาคณิตรูปทรง
- รูปแบบเลเอาต์ของรูปทรง
- รูปทรงในรูปแบบ SVG
- แปลงรูปทรงเป็น SVG
- จัดแนวรูปทรง
- พลิกรูปทรง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, ปรับ, ทำสำเนา, ลบ, ซ่อน, จัดลำดับใหม่, ส่งออก, จัดแนว, และพลิกรูปทรงการนำเสนอด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

Aspose.Slides for Java แสดงรูปทรงบนสไลด์เป็น IShapeCollection ที่จัดลำดับไว้. คอลเลกชันเป็นทั้งที่ที่คุณค้นหาและแก้ไขรูปทรงและเป็นแหล่งที่มาของลำดับการซ้อน: ดัชนี `0` คือรูปทรงที่อยู่ด้านหลังที่สุด, ส่วนดัชนีสุดท้ายคือรูปทรงที่อยู่ด้านหน้าที่สุด.

บทความนี้อิงตามโมเดลนั้น. มันอธิบายวิธีระบุรูปทรงอย่างมั่นคงและแก้ไขจุดปรับรูปทรงตั้งล่วงหน้า, แล้วแสดงวิธีทำสำเนา, ลบ, ซ่อน, และจัดลำดับรูปทรงใหม่. ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลเอาต์, การส่งออก SVG, การจัดแนว, และการตั้งค่าการพลิก. ตัวอย่างแต่ละอันเป็นอิสระ, ดังนั้นคุณสามารถใช้เพียงการดำเนินการที่เวิร์กโฟลว์ของคุณต้องการ.

## **ระบุและค้นหารูปทรง**

ดัชนีของคอลเลกชันเป็นวิธีที่สะดวกขณะประมวลผลไฟล์ที่รู้จัก, แต่ไม่ได้เป็นตัวระบุที่คงที่. การเพิ่ม, ลบ, หรือจัดลำดับรูปทรงใหม่สามารถทำให้ดัชนีเปลี่ยนได้. เลือกตัวระบุตามวิธีที่การนำเสนอถูกสร้างและดูแล:

- [Name](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getName--) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและตรวจสอบได้ง่ายในแผงการเลือกของ PowerPoint. ชื่อสามารถแก้ไขได้และไม่ได้รับประกันว่าจะไม่ซ้ำกัน, ดังนั้นควรกำหนดแนวทางการตั้งชื่อหากโค้ดต้องอาศัยชื่อเหล่านี้.
- [AlternativeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getAlternativeText--) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบุรูปทรง. คำอธิบายนี้มองเห็นได้โดยผู้ใช้, สามารถแปลเป็นภาษาต่างๆ หรือเขียนใหม่เพื่อการเข้าถึง, และไม่ได้รับประกันว่าจะไม่ซ้ำกัน. อย่าใช้ข้อความการเข้าถึงที่มีความหมายเป็นคีย์ของฐานข้อมูลโดยไม่มีการแจ้งผู้ใช้.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) เป็นตัวระบุแบบอ่านอย่างเดียวที่เป็นเอกลักษณ์ภายในสไลด์และตรงกับ ID รูปทรงที่ PowerPoint interop ใช้. ใช้เมื่อผสานกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ชัดเจนตลอดอายุของรูปทรง. รูปทรงที่ทำสำเนาหรือสร้างใหม่เป็นรูปทรงที่แตกต่างและจะได้รับ ID ของตนเอง.

เมธอด [getUniqueId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getUniqueId--) ที่เกี่ยวข้องส่งคืนตัวระบุระดับการนำเสนอ, แต่ตัวระบุดังกล่าวออกแบบมาสำหรับแอด‑อินและอาจถูกกำหนดใหม่. ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร. หากต้องการอัตลักษณ์ระยะยาว, เก็บการแมปไว้ในข้อมูลของแอปพลิเคชันและตรวจสอบว่ารูปทรงที่คาดหวังยังคงมีอยู่หรือไม่.

สำหรับตัวอย่างการอ่านและอัปเดตทั้งหัวเรื่องข้อความสำรองและคำอธิบาย, ดูที่ [Manage Alternative Text Titles and Descriptions](/slides/th/java/presentation-accessibility/). ใช้ข้อความสำรองเพื่ออธิบายความหมายของภาพให้ผู้อ่านเข้าใจ, และแยกมันออกจากชื่อรูปทรงที่โค้ดใช้เพื่อค้นหารูปทรง.

ตัวอย่างต่อไปนี้ค้นหาตามชื่อด้วยการเปรียบเทียบแบบตรงและรายงาน interop ID ระดับสไลด์. เมื่อเทมเพลตไม่มีรูปทรงที่คาดหวัง, โค้ดจะรายงานผลลัพธ์นั้นแทนที่จะดำเนินต่อด้วยอ็อบเจ็กต์ที่ผิด.

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

เมื่อการดำเนินการเฉพาะประเภทรูปทรง, ให้ตรวจสอบอินเทอร์เฟสก่อนใช้สมาชิกที่เฉพาะเจาะจง. ตัวอย่างนี้อัปเดตข้อความและข้อความสำรองเฉพาะเมื่ออ็อบเจ็กต์ที่มีชื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/).

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

## **ระบุและปรับการปรับค่าแบบตั้งล่วงหน้าของรูปทรง**

รูปทรงเรขาคณิตตั้งล่วงหน้าสามารถเปิดเผยจุดปรับที่ควบคุมคุณสมบัติต่าง ๆ เช่น ขนาดมุม, อัตราส่วนลูกศร, หรือมุมโค้ง. เข้าถึงได้ผ่านคอลเลกชันแบบอ่าน‑อย่างเดียว [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/th/java/com.aspose.slides/igeometryshape/#getAdjustments--) . คอลเลกชันนี้จัดหาโดยรูปทรง, แต่ละ [IAdjustValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/) มีค่าเป็นตัวที่สามารถเปลี่ยนได้.

อย่าเพียงพึ่งพาดัชนีคอลเลกชันที่คงที่. ให้วนผ่านการปรับและตรวจสอบเมธอดอ่าน‑อย่างเดียว [getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/#getType--) ซึ่งค่าประเภท [ShapeAdjustmentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapeadjustmenttype/) บรรยายว่าการปรับนั้นควบคุมอะไร. เมธอดอ่าน‑อย่างเดียว [getName](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/#getName--) ให้ข้อมูลระบุตัวเพิ่มเติมและมีประโยชน์มากเมื่อชุดตั้งล่วงหน้ามีการปรับหลายรายการที่มีประเภทเชิงความหมายเดียวกัน.

ใช้เมธอดค่าที่สอดคล้องกับความหมายของการปรับ:

| ประเภทการปรับ | วัตถุประสงค์ | ค่าที่ต้องการเปลี่ยน |
|---|---|---|
| `CornerSize` | ขนาดของมุมโค้ง | [setRawValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | ความหนาของหางลูกศร | `setRawValue` |
| `ArrowheadLength` | ความยาวของหัวลูกศร | `setRawValue` |
| `ArrowheadWidth` | ความกว้างของหัวลูกศร | `setRawValue` |
| `StartAngle` | มุมเริ่มต้นของพายหรือโค้ง | [setAngleValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | มุมสิ้นสุดของพายหรือโค้ง | `setAngleValue` |

`getType` และ `getName` ส่งคืนข้อมูลแบบอ่าน‑อย่างเดียว. `getRawValue` และ `setRawValue` ทำงานกับจำนวนเต็มในหน่วยเรขาคณิตดั้งเดิมของชุดตั้งค่า, ในขณะที่ `getAngleValue` และ `setAngleValue` ทำงานกับมุมในหน่วยองศา. จำนวน, ลำดับ, ความหมาย, และช่วงค่าที่ถูกต้องของการปรับขึ้นอยู่กับ [ShapeType](https://reference.aspose.com/slides/th/java/com.aspose.slides/igeometryshape/#getShapeType--) ของชุดตั้งค่า. ค่าที่ใช้ได้กับชุดหนึ่งอาจไม่ถูกต้องหรือให้ผลลัพธ์ที่แตกต่างกับชุดอื่น.

เมื่อ `getType` คืนค่า `ShapeAdjustmentType.Custom`, API ไม่รู้จักความหมายเชิงมาตรฐาน. ตรวจสอบ `getName`, ประเภทชุดตั้งค่า, และค่าที่มีอยู่, แล้วคงการปรับไว้โดยไม่เปลี่ยนเว้นแต่คุณรู้ความหมายและช่วงที่คาดหวัง. แม้กับประเภทที่รับรู้แล้ว, ควรตรวจสอบว่ามีประเภทเดียวกันปรากฏมากกว่าหนึ่งครั้งก่อนเลือกค่า. บทความ [Connector](/slides/th/java/connector/) แสดงกรณีนี้กับการปรับการดัดของคอนเนคเตอร์.

ตัวอย่างเต็มต่อไปนี้สร้างเวอร์ชันค่าเริ่มต้นและเวอร์ชันที่แก้ไขของรูปทรงตั้งล่วงหน้าสามรูป. มันวนผ่านการปรับแต่ละรายการ, รายงานชื่อและประเภท, เปลี่ยนค่าที่เกี่ยวกับขนาดผ่าน `setRawValue`, เปลี่ยนมุมผ่าน `setAngleValue`, และบันทึกผลลัพธ์. คอลัมน์ด้านซ้ายคงเรขาคณิตเดิม; คอลัมน์ด้านขวาแสดงสี่เหลี่ยมมุมโค้ง, ลูกศรสี่ทาง, และพายที่ปรับแล้ว.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มส่วนหัวสำหรับคอลัมน์รูปทรงเริ่มต้นและรูปทรงที่ปรับค่า.
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

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่า ทำให้โค้ดแสดงเจตนาชัดเจนและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันเดียวกันมีความหมายเดียวกันในรูปทรงตั้งล่วงหน้าอื่น ๆ.

## **แก้ไขคอลเลกชันรูปทรง**

เมธอดเพิ่ม, ทำสำเนา, ลบ, และจัดลำดับทำงานกับคอลเลกชันโดยทันที. หากการดำเนินการทำให้จำนวนหรือลำดับของรูปทรงเปลี่ยน, อย่ายังคงพึ่งพาดัชนีที่เก็บไว้ก่อนการดำเนินการนั้น.

### **ทำสำเนารูปทรง**

[addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) สร้างสำเนาอิสระและเพิ่มต่อท้ายคอลเลกชันเป้าหมาย. [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) ก็สร้างสำเนาเช่นกันแต่วางที่ดัชนี z‑order ที่ระบุ. การโอเวอร์โหลดที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; การโอเวอร์โหลดที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย.

ตัวอย่างสร้างสไลด์ปลายทาง, ทำสำเนาสี่เหลี่ยมที่มีป้ายชื่อไปด้านหน้า, และแทรกสำเนาที่สองไปด้านหลัง. การเปลี่ยนแปลงใด ๆ กับสำเนาใดสำเนาหนึ่งจะไม่แก้ไขรูปทรงต้นฉบับ.

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

การทำสำเนาจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปทรง, รวมถึงชื่อและข้อความสำรอง. กำหนดตัวระบุเชิงตรรกะใหม่ให้กับสำเนาเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์. ทรัพยากรที่ใช้โดยรูปทรงซับซ้อนจัดการโดยการนำเสนอ, แต่สำเนายังคงเป็นรายการใหม่ในคอลเลกชันพร้อมอัตลักษณ์รูปทรงใหม่.

### **ลบรูปทรง**

[remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) ลบอ็อบเจ็กต์รูปทรงเฉพาะจากคอลเลกชันของมัน. เมื่อลบหลายรายการในระหว่างการวนตามดัชนี, ควรวนจากท้ายเพื่อให้ดัชนีที่เหลือยังคงใช้ได้.

ตัวอย่างนี้ลบทุกรูปทรงที่มีชื่อที่กำหนดไว้. มันอ่านรูปทรงที่ดัชนีปัจจุบัน, ไม่ใช่รายการคอลเลกชันที่คงที่, และไม่ทำการคาสท์รูปทรงโดยไม่จำเป็น.

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

หลังจากลบ, จำนวนรูปทรงและดัชนีของรูปทรงที่เหลือจะเปลี่ยน. การอ้างอิงรูปทรงที่ไม่ได้รับผลกระทบจะน่าเชื่อถือกว่าการบันทึกดัชนี. ควรพิจารณาคอนเนคเตอร์, แอนิเมชั่น, และคุณลักษณะการนำเสนออื่น ๆ ที่อาจอ้างอิงอ็อบเจ็กต์ที่ลบ; การลบรูปทรงที่มองเห็นได้อาจทำให้เปลี่ยนแปลงมากกว่าลักษณะของสไลด์.

### **ซ่อนรูปทรง**

ตั้งค่า [Hidden](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setHidden-boolean-) ให้เป็น `true` จะทำให้รูปทรงคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในการแสดงสไลด์ปกติ. ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงสามารถเข้าถึงได้จากโค้ด, ดังนั้นการซ่อนเหมาะกับองค์ประกอบเลือกที่อาจต้องการกู้คืนในภายหลัง.

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

การซ่อนไม่ใช่การลบหรือความปลอดภัย. วัตถุยังคงถูกค้นพบและสามารถแสดงได้อีกครั้งโดยผู้ใช้หรือโค้ด, และยังคงเป็นส่วนหนึ่งของไฟล์การนำเสนอ.

### **เปลี่ยนลำดับ Z‑Order**

รูปทรงที่ซ้อนกันจะถูกวาดตามลำดับคอลเลกชัน. [reorder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ย้ายรูปทรงที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ทำสำเนา. ดัชนี `0` คือด้านหลัง; `size() - 1` คือด้านหน้า.

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

สี่เหลี่ยมถูกสร้างก่อนและเริ่มต้นอยู่ด้านหลังวงรี. การย้ายไปดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า. ควรสรุปลำดับ z‑order หลังจากเพิ่มหรือทำสำเนารูปทรงทั้งหมดที่เกี่ยวข้อง, เพราะการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการใหม่ในคอลเลกชันและอาจทำให้ลำดับสแตกเปลี่ยนแปลง.

## **ตรวจสอบรูปทรงบนสไลด์เลเอาต์**

สไลด์ทั่วไป, สไลด์เลเอาต์, และสไลด์มาสเตอร์มีคอลเลกชันรูปทรงแยกกัน. รูปทรงในคอลเลกชันเลเอาต์ไม่ใช่อ็อบเจ็กต์เดียวกับรูปทรงที่มีตำแหน่งคล้ายกันบนสไลด์ทั่วไป. ตรวจสอบรูปทรงเลเอาต์เมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปแบบที่เลเอาต์จัดหาไว้.

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getFillFormat--) และ [LineFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getLineFormat--) ของแต่ละรูปทรงเลเอาต์โดยไม่สมมติว่าทุกรูปทรงเป็น `AutoShape`.

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

การแก้ไขเลเอาต์อาจส่งผลต่อหลายสไลด์ที่ใช้มัน. ก่อนเปลี่ยนรูปทรงเลเอาต์, ให้ตรวจสอบว่าสไลด์ทั่วไปสืบทอดอ็อบเจ็กต์หรือมีการ overriding ภายใน, และทดสอบทุกสไลด์ที่ใช้เลเอาต์นั้น.

## **ส่งออกรูปทรงเป็น SVG**

[writeAsSvg](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) เขียนเนื้อหาที่เรนเดอร์ของรูปทรงหนึ่งไปยังสตรีม. ผลลัพธ์จะมีเฉพาะรูปทรง, ไม่รวมพื้นหลังสไลด์ทั้งหมดหรือรูปทรงใกล้เคียง.

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

ให้เปิดการนำเสนอตลอดระหว่างการเรนเดอร์. ผลลัพธ์ขึ้นกับการจัดรูปแบบของรูปทรงและทรัพยากรเช่นฟอนต์และรูปภาพ. หากต้องการส่วนประกอบทั้งหมด, ให้ส่งออกสไลด์แทนการส่งออกรูปทรงเดี่ยว. ผู้เรียกจัดการสตรีมและต้องปิดสตรีมนั้นเอง.

## **จัดแนวรูปทรง**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) มีโอเวอร์โหลดที่จัดแนวทั้งชุดรูปทรงหรือดัชนีคอลเลกชันที่เลือก. [ShapesAlignmentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapesalignmenttype/) กำหนดขอบ, เส้นกึ่งกลาง, หรือโหมดกระจาย. ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งค่าเป็น `false` เพื่อจัดแนวรูปทรงที่เลือกให้สัมพันธ์กัน.

ตัวอย่างนี้จัดแนวสามรูปทรงให้ชิดขอบบนของสไลด์. การอ้างอิงรูปทรงที่คืนมาจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนจัดแนว.

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

การจัดแนวเปลี่ยนตำแหน่ง, ไม่ใช่ลำดับ z‑order. การจัดแนวแบบสัมพันธ์ทั่วไปต้องการอย่างน้อยสองรูปทรง, ในขณะที่การกระจายแนวนอนหรือแนวตั้งต้องมีรูปทรงเพียงพอเพื่อกำหนดช่องว่าง. หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอด, ให้คำนวณดัชนีใหม่.

## **พลิกรูปทรง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าพลิกแนวนอนและแนวตั้ง, และการหมุน. ค่า `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/java/com.aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิด, และ `NotDefined` รักษาสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น.

การนำเสนออินพุตด้านล่างมีรูปทรงที่ไม่ได้พลิก.

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างคงค่ากรอบอื่น ๆ ทั้งหมดและแทนที่เฉพาะการตั้งค่าพลิกสองค่า. สิ่งนี้สำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ใหม่จะแทนที่กรอบทั้งหมด.

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

รูปทรงที่บันทึกจะถูกสะท้อนทั้งแนวนอนและแนวตั้งในขณะที่ตำแหน่ง, ขนาด, และการหมุนยังคงเดิม.

![The shape after flipping](flipped_shape.png)

## **คำถามที่พบบ่อย**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปทรงหรือไม่?**

ใช้ได้เฉพาะสำหรับการประมวลผลระยะสั้นที่คอลเลกชันจะไม่เปลี่ยนก่อนใช้ดัชนีนั้น. ควรใช้ `Name` หรือแนวทาง `AlternativeText` ที่ตรวจสอบแล้วสำหรับเทมเพลตที่สร้างโดยผู้เขียน, หรือ `OfficeInteropShapeId` สำหรับงาน interop ระดับสไลด์.

**การซ่อนรูปทรงทำให้มันหายจาก z‑order หรือไม่?**

ไม่. รูปทรงที่ซ่อนจะคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน. สามารถค้นหา, จัดลำดับใหม่, แก้ไข, หรือทำให้มองเห็นอีกครั้งได้.

**ทำไมรูปทรงที่ทำสำเนาถึงปรากฏอยู่หน้าอีกรูปทรึงหนึ่ง?**

`addClone` จะเพิ่มสำเนาไปที่ท้ายคอลเลกชัน, ซึ่งเป็นด้านหน้าของ z‑order. ใช้ `insertClone` เพื่อกำหนดดัชนีเริ่มต้นหรือใช้ `reorder` หลังจากเพิ่มรูปทรงทั้งหมดแล้ว.

**สามารถใช้ดัชนีคงที่เพื่อระบุการปรับค่าแบบตั้งล่วงหน้าของรูปทรงได้หรือไม่?**

ทำได้เฉพาะหลังจากตรวจสอบชุดตั้งค่าและโครงสร้างคอลเลกชันอย่างละเอียด. แนะนำให้วนผ่าน `IGeometryShape.getAdjustments` และตรวจสอบ `IAdjustValue.getType`; ใช้ `IAdjustValue.getName` เป็นข้อมูลเสริมเมื่อประเภทเชิงความหมายเดียวกันปรากฏหลายครั้ง.