---
title: จัดการรูปร่างการนำเสนอบน Android
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/androidjava/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- คัดลอกรูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ ID รูปร่าง Interop
- ข้อความแทนรูปแบบ
- จุดปรับรูปร่าง
- การปรับรูปร่างที่กำหนดไว้ล่วงหน้า
- รูปทรงของรูปร่าง
- รูปแบบการจัดวางรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- พลิกรูปร่าง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, ปรับ, คัดลอก, ลบ, ซ่อน, เปลี่ยนลำดับ, ส่งออก, จัดแนว, และพลิกรูปร่างการนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java แสดงรูปแบบบนสไลด์เป็น [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) ที่เรียงลำดับกัน คอลเลกชันนี้เป็นทั้งที่ที่คุณค้นหาและแก้ไขรูปร่างและเป็นแหล่งที่มาของลำดับการซ้อน: ดัชนี `0` เป็นรูปแบบที่อยู่ด้านหลังสุด, ส่วนดัชนีสุดท้ายคือรูปแบบที่อยู่ด้านหน้าสุด

บทความนี้ปฏิบัติตามโมเดลนั้น โดยอธิบายวิธีระบุรูปแบบอย่างแม่นยำและแก้ไขจุดปรับค่าที่กำหนดไว้ล่วงหน้า, จากนั้นแสดงวิธีคัดลอก, ลบ, ซ่อน และจัดลำดับรูปแบบใหม่ ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลเอาต์, การส่งออกเป็น SVG, การจัดแนว, และการตั้งค่าการพลิกภาพ ตัวอย่างแต่ละอันเป็นอิสระกัน, ดังนั้นคุณสามารถใช้เฉพาะการดำเนินการที่จำเป็นสำหรับ workflow ของคุณได้

## **ระบุและค้นหารูปร่าง**

ดัชนีของคอลเลกชันสะดวกขณะประมวลผลไฟล์ที่ทราบ, แต่ไม่ใช่ตัวระบุที่คงที่ การเพิ่ม, ลบ, หรือจัดลำดับรูปแบบใหม่อาจเปลี่ยนดัชนีของมัน เลือกตัวระบุตามวิธีการสร้างและการบำรุงรักษา presentation:

- [Name](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getName--) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและตรวจสอบได้ง่ายใน Selection Pane ของ PowerPoint ชื่อสามารถแก้ไขได้และไม่รับประกันว่าจะเป็นเอกลักษณ์, ดังนั้นจึงควรกำหนดมาตรฐานการตั้งชื่อหากโค้ดพึ่งพา
- [AlternativeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getAlternativeText--) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบุรูปแบบ มันมองเห็นได้โดยผู้ใช้, อาจแปลเป็นภาษาต่างๆ หรือเขียนใหม่เพื่อการเข้าถึง, และไม่รับประกันว่าจะเป็นเอกลักษณ์ อย่าใช้ข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่ได้แจ้งให้ผู้ใช้ทราบ
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) เป็นตัวระบุแบบอ่านอย่างเดียวที่เป็นเอกลักษณ์ภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint interop ใช้ ใช้เมื่อเชื่อมต่อกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ไม่มีความกำกวมตลอดอายุของรูปแบบ รูปแบบที่คัดลอกหรือสร้างใหม่จะเป็นรูปแบบที่แตกต่างและจะได้รับ ID ของตัวเอง

เมธอด [getUniqueId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getUniqueId--) ที่เกี่ยวข้องคืนค่าตัวระบุที่มีขอบเขตระดับ presentation, แต่ตัวระบุนั้นออกแบบมาสำหรับ add‑in และอาจถูกกำหนดใหม่ ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร หากต้องการความเป็นตัวตนระยะยาวให้เก็บการแมปในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปแบบที่คาดหวังยังคงมีอยู่

ตัวอย่างต่อไปนี้ค้นหาด้วยชื่อโดยการเปรียบเทียบที่ตรงกันและรายงาน slide‑scoped interop ID เมื่อเทมเพลตไม่มีรูปแบบที่คาดหวัง โค้ดจะรายงานผลนั้นแทนที่จะดำเนินการต่อกับอ็อบเจกต์ที่ผิดพลาด

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

เมื่อการดำเนินการเฉพาะเจาะจงต่อประเภทรูปแบบ ให้ตรวจสอบอินเทอร์เฟซก่อนใช้สมาชิกประเภท‑เฉพาะ ตัวอย่างนี้อัปเดตข้อความและ alternative text เฉพาะเมื่ออ็อบเจกต์ที่ตั้งชื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/)

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

## **ระบุและแก้ไขการปรับค่ารูปร่างที่กำหนดไว้ล่วงหน้า**

รูปร่างเรขาคณิตที่กำหนดล่วงหน้าสามารถเปิดเผยจุดปรับค่าที่ควบคุมคุณลักษณะต่างๆ เช่น ขนาดมุม, อัตราส่วนของศร, หรือมุมโค้ง เข้าถึงพวกมันผ่านคอลเลกชันอ่าน‑อย่างเดียว [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) คอลเลกชันนี้จัดหาโดยรูปแบบ, แต่แต่ละ [IAdjustValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/) มีค่าที่สามารถเปลี่ยนแปลงได้

อย่าพึ่งพาเพียงดัชนีคอลเลกชันที่คงที่ ให้วนลูปผ่านการปรับค่าและตรวจสอบเมธอดอ่าน‑อย่างเดียว [getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/#getType--) ซึ่งค่า [ShapeAdjustmentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapeadjustmenttype/) อธิบายว่าการปรับค่านั้นควบคุมอะไร เมธอดอ่าน‑อย่างเดียว [getName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/#getName--) ให้ข้อมูลการระบุตัวเพิ่มและเป็นประโยชน์โดยเฉพาะเมื่อพรีเซ็ตมีการปรับค่ามากกว่าหนึ่งค่าแบบเดียวกัน

ใช้เมธอดค่าที่สอดคล้องกับความหมายของการปรับค่า:

| ประเภทการปรับค่า | วัตถุประสงค์ | ค่าที่จะเปลี่ยน |
|---|---|---|
| `CornerSize` | ขนาดของมุมโค้ง | [setRawValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | ความหนาของหางศร | `setRawValue` |
| `ArrowheadLength` | ความยาวของหัวศร | `setRawValue` |
| `ArrowheadWidth` | ความกว้างของหัวศร | `setRawValue` |
| `StartAngle` | มุมเริ่มต้นของพายหรือโค้ง | [setAngleValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | มุมสิ้นสุดของพายหรือโค้ง | `setAngleValue` |

`getType` และ `getName` คืนข้อมูลแบบอ่าน‑อย่างเดียว `getRawValue` กับ `setRawValue` ทำงานกับจำนวนเต็มในหน่วยเรขาคณิตดั้งเดิมของพรีเซ็ต, ส่วน `getAngleValue` และ `setAngleValue` ทำงานกับมุมในหน่วยองศา จำนวน, ลำดับ, ความหมาย, และช่วงค่าที่ถูกต้องของการปรับค่าขึ้นอยู่กับพรีเซ็ต [ShapeType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) ค่าที่เป็นประโยชน์สำหรับพรีเซ็ตหนึ่งอาจไม่ถูกต้องหรือมีผลต่างสำหรับพรีเซ็ตอื่น

เมื่อ `getType` คืนค่า `ShapeAdjustmentType.Custom` API จะไม่รู้จักความหมายเชิงมาตรฐาน ตรวจสอบ `getName`, ประเภทพรีเซ็ต, และค่าที่มีอยู่, และอย่าเปลี่ยนการปรับค่าเว้นแต่คุณรู้ความหมายและช่วงที่คาดหวัง แม้สำหรับประเภทที่รู้จักแล้วก็ตรวจสอบว่าชนิดเดียวกันปรากฏมากกว่าหนึ่งครั้งหรือไม่ก่อนเลือกค่า บทความ [Connector](/slides/th/androidjava/connector/) แสดงสถานการณ์นี้ด้วยการปรับค่าการโค้งของคอนเน็กเตอร์

ตัวอย่างเต็มต่อไปนี้สร้างเวอร์ชันเริ่มต้นและเวอร์ชันที่แก้ไขของรูปแบบพรีเซ็ตสามแบบ โดยวนลูปผ่านการปรับค่าทุกค่า, รายงานชื่อและประเภท, เปลี่ยนค่าที่เกี่ยวกับขนาดผ่าน `setRawValue`, เปลี่ยนมุมผ่าน `setAngleValue`, และบันทึกผล คอลัมน์ซ้ายเก็บเรขาคณิตเริ่มต้น; คอลัมน์ขวาแสดงสี่เหลี่ยมมุมโค้งที่ปรับค่า, ลูกศรสี่ทาง, และพาย

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มหัวข้อสำหรับคอลัมน์รูปร่างเริ่มต้นและคอลัมน์รูปร่างที่ปรับค่า.
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

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่าช่วยให้โค้ดชัดเจนเกี่ยวกับเจตนารมณ์และหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันเดียวกันมีความหมายเท่าเดิมในพรีเซ็ตต่าง ๆ

## **แก้ไขคอลเลกชันรูปแบบ**

เมธอดเพิ่ม, คัดลอก, ลบ, และจัดลำดับทำงานบนคอลเลกชันโดยทันที หากการดำเนินการเปลี่ยนจำนวนหรือลำดับของรูปแบบ, อย่าอ้างอิงดัชนีที่จับไว้ก่อนการดำเนินการนั้นต่อไป

### **คัดลอกรูปแบบ**

[addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) สร้างสำเนาอิสระและเพิ่มต่อท้ายคอลเลกชันเป้าหมาย [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) ก็สร้างสำเนาเช่นกันแต่วางไว้ที่ดัชนี z‑order ที่กำหนด ตัวโอเวอร์โหลดที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; ตัวโอเวอร์โหลดที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างนี้สร้างสไลด์ปลายทาง, คัดลอกสี่เหลี่ยมที่มีฉลากไปด้านหน้า, แล้วแทรกสำเนาที่สองไว้ด้านหลัง การเปลี่ยนแปลงใด ๆ กับสำเนาแต่ละอันจะไม่กระทบรูปแบบต้นฉบับ

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

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปแบบ รวมถึงชื่อและ alternative text ให้กำหนดตัวระบุแบบลอจิกใหม่ให้กับสำเนาเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์ ทรัพยากรที่ใช้โดยรูปแบบที่ซับซ้อนจัดการโดย presentation, แต่สำเนายังคงเป็นรายการคอลเลกชันใหม่ที่มีอัตลักษณ์รูปแบบใหม่

### **ลบรูปแบบ**

[remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) ลบอ็อบเจกต์รูปแบบเฉพาะจากคอลเลกชันของมัน เมื่อลบหลายรายการที่ตรงกันระหว่างการวนลูปตามดัชนี ให้วนจากท้ายสุดเพื่อให้ดัชนีที่เหลือยังคงถูกต้อง

ตัวอย่างนี้ลบทุกรูปแบบที่มีชื่อกำหนดไว้ มันอ่านรูปแบบตามดัชนีปัจจุบัน ไม่ใช่รายการคอลเลกชันคงที่ และไม่ทำการ cast รูปแบบโดยไม่จำเป็น

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

หลังการลบ จำนวนรูปแบบและดัชนีของรูปแบบต่อมาจะเปลี่ยน แหล่งอ้างอิงไปยังรูปแบบที่ไม่ได้รับผลกระทบจะคงเชื่อถือได้มากกว่าการบันทึกดัชนี นอกจากนี้ยังควรพิจารณา connector, animation, และคุณลักษณะ presentation อื่น ๆ ที่อาจอ้างอิงอ็อบเจกต์ที่ลบ; การลบรูปแบบที่มองเห็นได้อาจทำให้เปลี่ยนแปลงมากกว่ารูปลักษณ์ของสไลด์

### **ซ่อนรูปแบบ**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) เป็น `true` ทำให้รูปแบบคงอยู่ในคอลเลกชันแต่ไม่แสดงใน slide show ปกติ ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงพร้อมให้โค้ดใช้งาน ดังนั้นการซ่อนจึงเหมาะสำหรับองค์ประกอบเลือกที่อาจต้องการกู้คืนในภายหลัง

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

การซ่อนไม่ใช่การลบหรือความปลอดภัย อ็อบเจกต์ยังสามารถค้นพบและแสดงใหม่โดยผู้ใช้หรือโดยโค้ด, และยังคงเป็นส่วนหนึ่งของไฟล์ presentation

### **เปลี่ยน Z‑Order**

รูปแบบที่ทับซ้อนกันจะถูกวาดตามลำดับคอลเลกชัน [reorder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ย้ายรูปแบบที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องคัดลอก ดัชนี `0` คือด้านหลัง; `size() - 1` คือด้านหน้า

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สี่เหลี่ยมถูกสร้างก่อนและโดยแรกจะอยู่หลังวงรี การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า ให้ทำการสรุป z‑order หลังจากเพิ่มหรือคัดลอกรูปแบบทั้งหมดที่เกี่ยวข้อง, เนื่องจากการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการคอลเลกชันใหม่และอาจเปลี่ยนสแต็กที่ตั้งใจไว้

## **ตรวจสอบรูปแบบใน Layout Slides**

สไลด์ปกติ, layout slides, และ master slides มีคอลเลกชันรูปแบบแยกกัน รูปแบบในคอลเลกชัน layout ไม่ใช่อ็อบเจกต์เดียวกับรูปแบบที่อยู่ในตำแหน่งเดียวกันบนสไลด์ปกติ ตรวจสอบรูปแบบ layout เมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปแบบที่มาจาก layout

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getFillFormat--) และ [LineFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getLineFormat--) ของแต่ละรูปแบบใน layout โดยไม่สมมติว่ารูปแบบทุกอันเป็น `AutoShape`

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

การแก้ไข layout สามารถส่งผลต่อหลายสไลด์ที่ใช้มัน ก่อนเปลี่ยนรูปแบบ layout ให้ตรวจสอบว่าสไลด์ปกติสืบทอดอ็อบเจกต์นั้นหรือมีการโอเวอร์ไรด์ในระดับท้องถิ่น, และทดสอบทุกสไลด์ที่ใช้ layout นั้น

## **ส่งออกรูปแบบเป็น SVG**

[writeAsSvg](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) เขียนเนื้อหาที่เรนเดอร์ของรูปแบบหนึ่งไปยังสตรีม ผลลัพธ์จะมีรูปแบบเท่านั้น, ไม่ได้รวมพื้นหลังสไลด์ทั้งหมดหรือรูปแบบใกล้เคียง

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

ให้เปิด presentation ไว้ขณะทำการเรนเดอร์ ผลลัพธ์ขึ้นกับการจัดรูปแบบของรูปแบบและทรัพยากรเช่นฟอนต์และรูปภาพ หากต้องการส่วนประกอบทั้งหมด ให้ส่งออกรูปแบบสไลด์แทนรูปแบบเดี่ยว ผู้เรียกต้องเป็นเจ้าของสตรีมและต้องปิดสตรีมเอง

## **จัดแนวรูปแบบ**

เมธอด [SlideUtil.alignShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) มีโอเวอร์โหลดให้จัดแนวทั้งทั้งหมดหรือดัชนีคอลเลกชันที่เลือก [ShapesAlignmentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapesalignmenttype/) กำหนดขอบ, เส้นกึ่งกลาง, หรือโหมดการจัดกระจาย ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปแบบที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปแบบไปยังขอบบนของสไลด์ การอ้างอิงรูปแบบที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนทำการจัดแนว

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

การจัดแนวเปลี่ยนตำแหน่ง, ไม่ใช่ z‑order การจัดแนวเชิงสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปแบบ, ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปแบบพอที่จะกำหนดระยะห่าง หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอดให้คำนวณดัชนีใหม่

## **พลิกรูปแบบ**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าพลิกแนวนอนและแนวตั้ง, และการหมุน ค่า `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิด, `NotDefined` คงสภาพที่ไม่ได้กำหนด/ค่าเริ่มต้น

presentation ตัวอย่างด้านล่างมีรูปแบบที่ไม่ถูกพลิก

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่นทั้งหมดและแทนที่เฉพาะการตั้งค่าพลิกสองค่าเท่านั้น นี้สำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ใหม่จะทำการแทนที่กรอบทั้งหมด

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

รูปแบบที่บันทึกจะถูกสะท้อนแบบแนวนอนและแนวตั้งขณะคงตำแหน่ง, ขนาด, และการหมุนไว้

![The shape after flipping](flipped_shape.png)

## **คำถามที่พบบ่อย**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปแบบหรือไม่?**

ใช้เฉพาะการประมวลผลระยะสั้นเมื่อคอลเลกชันจะไม่เปลี่ยนแปลงก่อนใช้ดัชนี แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ตรวจสอบแล้วสำหรับเทมเพลตที่สร้างโดยผู้เขียน, หรือ `OfficeInteropShapeId` สำหรับงาน interop ระดับสไลด์

**การซ่อนรูปแบบทำให้มันถูกลบออกจาก z‑order หรือไม่?**

ไม่ รูปแบบที่ซ่อนคงอยู่ในคอลเลกชันที่ดัชนีเดิม สามารถค้นหา, จัดลำดับใหม่, แก้ไข, หรือทำให้มองเห็นอีกครั้งได้

**ทำไมรูปแบบที่คัดลอกจึงปรากฏอยู่หน้ารูปแบบอื่น?**

`addClone` เพิ่มสำเนาที่ตำแหน่งสุดท้ายของคอลเลกชัน, ซึ่งเป็นด้านหน้าของ z‑order ใช้ `insertClone` เพื่อกำหนดดัชนีเริ่มต้นหรือใช้ `reorder` หลังจากเพิ่มรูปแบบทั้งหมดแล้ว

**สามารถใช้ดัชนีคงที่เพื่อระบุการปรับค่ารูปร่างพรีเซ็ตได้หรือไม่?**

ทำได้เฉพาะหลังจากตรวจสอบพรีเซ็ตและโครงสร้างคอลเลกชันอย่างละเอียด แนะนำให้วนผ่าน `IGeometryShape.getAdjustments` และตรวจสอบ `IAdjustValue.getType`; ใช้ `IAdjustValue.getName` เป็นข้อมูลเสริมเมื่อประเภทเชิงความหมายเดียวกันปรากฏหลายครั้ง