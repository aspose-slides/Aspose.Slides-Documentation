---
title: จัดการรูปทรงพรีเซนเทชันบน Android
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/androidjava/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงพรีเซนเทชัน
- รูปทรงบนสไลด์
- ค้นหารูปทรง
- คัดลอกรูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ ID รูปทรง Interop
- ข้อความแทนรูปทรง
- จุดปรับรูปทรง
- การปรับรูปทรงพรีเซ็ต
- เรขาคณิตรูปทรง
- รูปแบบเลย์เอาต์รูปทรง
- รูปทรงเป็น SVG
- แปลงรูปทรงเป็น SVG
- จัดแนวรูปทรง
- พลิกรูปทรง
- PowerPoint
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีระบุ ปรับเปลี่ยน คัดลอก ลบ ซ่อน เปลี่ยนลำดับ ส่งออก จัดแนว และพลิกรูปทรงพรีเซนเทชันด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java แสดงรูปทรงบนสไลด์เป็น [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) ที่จัดลำดับไว้แล้ว คอลเลกชันนี้เป็นทั้งที่ที่คุณค้นหาและแก้ไขรูปทรงและเป็นแหล่งที่มาของลำดับการซ้อนกัน: ดัชนี `0` คือรูปทรงที่อยู่ด้านหลังสุด ขณะที่ดัชนีสุดท้ายคือรูปทรงที่อยู่ด้านหน้าสุด

บทความนี้ทำตามโมเดลนั้น โดยอธิบายวิธีระบุตัวรูปทรงอย่างน่าเชื่อถือและแก้ไขจุดปรับรูปทรงที่กำหนดไว้ จากนั้นแสดงวิธีคัดลอก ลบ ซ่อน และเปลี่ยนลำดับรูปทรง ส่วนตอนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาท์ การส่งออกเป็น SVG การจัดแนว และการตั้งค่าการพลิก ทุกตัวอย่างเป็นอิสระกัน ดังนั้นคุณสามารถใช้เฉพาะการดำเนินการที่เวิร์กโฟลว์ของคุณต้องการได้

## **ระบุและค้นหารูปทรง**

ดัชนีของคอลเลกชันเป็นประโยชน์เมื่อประมวลผลไฟล์ที่รู้จักแล้ว แต่ไม่ได้เป็นตัวระบุที่คงที่ การเพิ่ม ลบ หรือเปลี่ยนลำดับรูปทรงอาจทำให้ดัชนีเปลี่ยนไป เลือกตัวระบุตามวิธีการสร้างและการดูแลพรีเซนเทชัน:

- [Name](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getName--) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและตรวจสอบได้ง่ายในส่วน Selection Pane ของ PowerPoint ชื่อสามารถแก้ไขได้และไม่ได้รับการรับประกันว่าจะเป็นเอกลักษณ์ ดังนั้นควรกำหนดแนวทางการตั้งชื่อหากโค้ดพึ่งพา
- [AlternativeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getAlternativeText--) มีประโยชน์เมื่อมีคำบรรยายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบุตัวรูปทรง มันมองเห็นได้โดยผู้ใช้ อาจแปลหรือเขียนใหม่เพื่อการเข้าถึงได้ และไม่ได้รับการรับประกันว่าจะเป็นเอกลักษณ์ อย่าเปลี่ยนข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยเงียบ ๆ
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) เป็นตัวระบุแบบอ่านอย่างเดียวที่เป็นเอกลักษณ์ภายในสไลด์และสอดคล้องกับ ID รูปทรงที่ PowerPoint interop ใช้ ใช้เมื่อผสานกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ชัดเจนตลอดอายุของรูปทรง รูปทรงที่คัดลอกหรือสร้างใหม่จะเป็นรูปทรงที่แตกต่างและจะได้รับ ID ของตนเอง

เมธอด [getUniqueId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getUniqueId--) ที่เกี่ยวข้องจะคืนตัวระบุระดับพรีเซนเทชัน แต่ตัวระบุนี้ออกแบบมาสำหรับแอด‑อินและอาจถูกกำหนดใหม่ ไม่ควรถือเป็นคีย์ภายนอกถาวร หากต้องการอัตลักษณ์ในระยะยาว ให้เก็บการแมปในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปทรงที่คาดหวังยังคงมีอยู่หรือไม่

สำหรับตัวอย่างการอ่านและอัปเดตทั้งหัวข้อและคำอธิบายของ alternative text ดูที่ [Manage Alternative Text Titles and Descriptions](/slides/th/androidjava/presentation-accessibility/). ใช้ alternative text เพื่ออธิบายความหมายของภาพให้ผู้อ่าน และแยกออกจากชื่อรูปทรงที่โค้ดใช้ค้นหา

ตัวอย่างต่อไปนี้ค้นหาโดยชื่อด้วยการเปรียบเทียบที่ตรงกันและรายงาน ID interop ที่อยู่ในระดับสไลด์ เมื่อเทมเพลตไม่มีรูปทรงที่คาดหวัง โค้ดจะรายงานผลลัพธ์นั้นแทนที่จะดำเนินการต่อด้วยอ็อบเจกต์ที่ผิด

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

เมื่อการดำเนินการเฉพาะกับประเภทรูปทรง ให้ตรวจสอบอินเทอร์เฟซก่อนใช้สมาชิกที่ระบุประเภท ตัวอย่างนี้อัปเดตข้อความและ alternative text เฉพาะเมื่ออ็อบเจกต์ที่ตั้งชื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/)

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

## **ระบุและแก้ไขการปรับค่ารูปทรงที่กำหนดล่วงหน้า**

รูปทรงเรขาคณิตที่กำหนดล่วงหน้าสามารถเปิดเผยจุดปรับค่าที่ควบคุมคุณสมบัติเช่น ขนาดมุม, สัดส่วนลูกศร, หรือมุมโค้ง เข้าถึงได้ผ่านคอลเลกชันอ่านอย่างเดียว [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) คอลเลกชันนี้จัดหาโดยรูปทรงเอง แต่แต่ละ [IAdjustValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/) มีค่าที่สามารถเปลี่ยนได้

อย่าพึ่งพาดัชนีคอลเลกชันคงที่เท่านั้น ให้วนรอบผ่านการปรับค่าและตรวจสอบเมธอดอ่านอย่างเดียว [getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/#getType--) ซึ่งค่าประเภท [ShapeAdjustmentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapeadjustmenttype/) อธิบายว่าการปรับค่านั้นควบคุมอะไร เมธอดอ่านอย่างเดียว [getName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/#getName--) ให้ข้อมูลระบุตัวเติมที่เป็นประโยชน์โดยเฉพาะเมื่อพรีเซ็ตมีการปรับค่ามากกว่าหนึ่งค่าแต่มีประเภทเชิงความหมายเดียวกัน

ใช้เมธอดค่าที่ตรงกับความหมายของการปรับค่า:

| ประเภทการปรับค่า | วัตถุประสงค์ | ค่าที่ต้องเปลี่ยน |
|---|---|---|
| `CornerSize` | ขนาดของมุมโค้ง | [setRawValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | ความหนาของหางลูกศร | `setRawValue` |
| `ArrowheadLength` | ความยาวของหัวลูกศร | `setRawValue` |
| `ArrowheadWidth` | ความกว้างของหัวลูกศร | `setRawValue` |
| `StartAngle` | มุมเริ่มต้นของพายหรือโค้ง | [setAngleValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | มุมสิ้นสุดของพายหรือโค้ง | `setAngleValue` |

`getType` และ `getName` คืนข้อมูลแบบอ่านอย่างเดียว `getRawValue` และ `setRawValue` ทำงานกับจำนวนเต็มในหน่วยเรขาคณิตดั้งเดิมของพรีเซ็ต ขณะที่ `getAngleValue` และ `setAngleValue` ทำงานกับมุมในหน่วยองศา จำนวน, ลำดับ, ความหมายและช่วงค่าที่ถูกต้องของการปรับค่าขึ้นอยู่กับ [ShapeType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) ของพรีเซ็ต ค่าที่ถูกต้องสำหรับพรีเซ็ตหนึ่งอาจไม่ถูกต้องหรือให้ผลต่างสำหรับพรีเซ็ตอื่น

เมื่อ `getType` คืนค่า `ShapeAdjustmentType.Custom` API จะไม่รู้จักความหมายเชิงมาตรฐาน ตรวจสอบ `getName`, ประเภทพรีเซ็ต, และค่าที่มีอยู่แล้วปล่อยการปรับค่าไม่เปลี่ยนยกเว้นคุณรู้ความหมายและช่วงที่คาดหวัง แม้สำหรับประเภทที่รู้จักแล้ว ให้ตรวจสอบว่าประเภทเดียวกันปรากฏมากกว่าหนึ่งครั้งหรือไม่ก่อนเลือกค่า บทความ [Connector](/slides/th/androidjava/connector/) แสดงสถานการณ์นี้กับการปรับค่าการงอของคอนเนคเตอร์

ตัวอย่างต่อไปนี้สร้างเวอร์ชันเริ่มต้นและเวอร์ชันที่แก้ไขของรูปทรงพรีเซ็ตสามแบบ โดยวนรอบผ่านทุกการปรับค่า, รายงานชื่อและประเภท, เปลี่ยนค่าที่เกี่ยวกับขนาดผ่าน `setRawValue`, เปลี่ยนมุมผ่าน `setAngleValue`, และบันทึกผลลัพธ์ คอลัมน์ซ้ายเก็บเรขาคณิตเริ่มต้น; คอลัมน์ขวาแสดงสี่เหลี่ยมมุมมนที่ปรับแล้ว, ลูกศรสี่ทาง, และพาย

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มหัวข้อสำหรับคอลัมน์รูปทรงเริ่มต้นและรูปทรงที่ปรับค่าแล้ว.
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

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่าทำให้โค้ดแสดงเจตนาชัดเจนและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันเดียวกันมีความหมายเดียวกันในพรีเซ็ตรูปทรงที่แตกต่างกัน

## **แก้ไขคอลเลกชันรูปทรง**

เมธอดเพิ่ม, คัดลอก, ลบ, และเปลี่ยนลำดับทำงานบนคอลเลกชันทันที หากการดำเนินการทำให้จำนวนหรือลำดับของรูปทรงเปลี่ยนแปลง อย่าอาศัยดัชนีที่จับไว้ก่อนหน้าการดำเนินการต่อไป

### **คัดลอกรูปทรง**

[addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) สร้างสำเนาอิสระและต่อท้ายในคอลเลกชันเป้าหมาย [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) ก็สร้างสำเนาเช่นกันแต่วางที่ดัชนี z‑order ที่ระบุ ฟังก์ชันที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; ฟังก์ชันที่รับความกว้างและความสูงสามารถปรับขนาดได้เช่นกัน

ตัวอย่างนี้สร้างสไลด์ปลายทาง, คัดลอกสี่เหลี่ยมที่มีป้ายกำกับไปข้างหน้า, และแทรกคัดลอกที่สองไว้ด้านหลัง การเปลี่ยนแปลงใด ๆ กับสำเนาใดสำเนาหนึ่งจะไม่กระทบต่อรูปทรงต้นฉบับ

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

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปทรง รวมถึงชื่อและ alternative text กำหนดตัวระบุเชิงตรรกะใหม่ให้กับสำเนาหากค่าดังกล่าวต้องเป็นเอกลักษณ์ ทรัพยากรที่ใช้โดยรูปทรงซับซ้อนจะถูกจัดการโดยพรีเซนเทชัน แต่สำเนายังคงเป็นรายการคอลเลกชันใหม่ที่มีอัตลักษณ์รูปทรงใหม่

### **ลบรูปทรง**

[remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) ลบทิ้งอ็อบเจกต์รูปทรงเฉพาะจากคอลเลกชันของมัน เมื่อลบหลายรายการในขณะวนรอบตามดัชนี ให้วนจากท้ายรายการเพื่อให้ดัชนีที่เหลืออยู่ยังคงถูกต้อง

ตัวอย่างนี้ลบทุกรูปทรงที่มีชื่อกำหนดไว้ มันอ่านรูปทรงที่ดัชนีปัจจุบัน ไม่ได้อ้างอิงรายการคอลเลกชันคงที่ และไม่ได้ทำการแคสต์รูปทรงโดยไม่จำเป็น

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

หลังการลบ จำนวนรูปทรงและดัชนีของรูปทรงต่อมาจะเปลี่ยน การอ้างอิงรูปทรงที่ไม่ได้รับผลกระทบจึงคงเชื่อถือได้มากกว่าการบันทึกดัชนี ควรพิจารณาคอนเนคเตอร์, แอนิเมชัน, และคุณลักษณะพรีเซนเทชันอื่น ๆ ที่อาจอ้างอิงอ็อบเจกต์ที่ลบออก; การลบรูปทรงที่มองเห็นได้อาจเปลี่ยนมากกว่ารูปลักษณ์ของสไลด์เท่านั้น

### **ซ่อนรูปทรง**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) เป็น `true` ทำให้รูปทรงคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในการนำเสนอแบบปกติ ดัชนี, การจัดรูปแบบ, และเนื้อหาของมันยังคงพร้อมให้โค้ดเข้าถึง ดังนั้นการซ่อนจึงเหมาะสำหรับองค์ประกอบที่เป็นตัวเลือกและอาจเรียกคืนได้ในภายหลัง

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

การซ่อนไม่ได้เป็นการลบหรือความปลอดภัย ออบเจกต์สามารถยังคงถูกค้นพบและแสดงผลอีกครั้งโดยผู้ใช้หรือโดยโค้ด และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน

### **เปลี่ยนลำดับ Z‑Order**

รูปทรงที่ซ้อนกันจะถูกวาดตามลำดับของคอลเลกชัน [reorder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ย้ายรูปทรงที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องคัดลอก ดัชนี `0` คือด้านหลัง; `size() - 1` คือด้านหน้า

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

สี่เหลี่ยมถูกสร้างขึ้นก่อนและเดิมอยู่ด้านหลังวงรี การย้ายมันไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า ให้จัดลำดับ z‑order สุดท้ายหลังจากเพิ่มหรือคัดลอกรูปทรงที่เกี่ยวข้องทั้งหมด เนื่องจากการดำเนินการเหล่านั้นจะต่อท้ายหรือแทรกรายการใหม่ในคอลเลกชันและอาจเปลี่ยนสแต็กที่ต้องการ

## **ตรวจสอบรูปทรงในสไลด์เลย์เอาท์**

สไลด์ปกติ, สไลด์เลย์เอาท์, และสไลด์มาสเตอร์มีคอลเลกชันรูปทรงที่แยกจากกัน รูปทรงในคอลเลกชันเลย์เอาท์ไม่ใช่วัตถุเดียวกับรูปทรงที่ตำแหน่งเดียวกันบนสไลด์ปกติ ตรวจสอบรูปทรงเลย์เอาท์เมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปแบบที่เลย์เอาท์กำหนด

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getFillFormat--) และ [LineFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getLineFormat--) ของแต่ละรูปทรงในเลย์เอาท์โดยไม่สันนิษฐานว่าทุกรูปทรงเป็น `AutoShape`

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

การแก้ไขเลย์เอาท์อาจมีผลต่อหลายสไลด์ที่ใช้มัน ก่อนเปลี่ยนรูปทรงในเลย์เอาท์ ให้กำหนดว่ารูปทรกน์บนสไลด์ปกติสืบทอดวัตถุนี้หรือมีการตั้งค่าภายในท้องถิ่น และทดสอบทุกสไลด์ที่ใช้เลย์เอาท์นั้น

## **ส่งออกรูปทรงเป็น SVG**

[writeAsSvg](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) เขียนเนื้อหาที่เรนเดอร์ของรูปทรงหนึ่งไปยังสตรีม ผลลัพธ์จะมีเพียงรูปทรงนั้น ไม่รวมพื้นหลังสไลด์ทั้งหมดหรือรูปทรงใกล้เคียง

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

ให้เปิดพรีเซนเทชันไว้ขณะเรนเดอร์ ผลลัพธ์ขึ้นกับการจัดรูปแบบของรูปทรงและทรัพยากรเช่นแบบอักษรและภาพ หากต้องการส่งออกส่วนประกอบทั้งหมด ให้ส่งออกรหัสสไลด์แทนการส่งออกรูปทรงเดี่ยว ผู้เรียกต้องเป็นเจ้าของสตรีมและต้องปิดสตรีมด้วยตนเอง

## **จัดแนวรูปทรง**

เมธอด [SlideUtil.alignShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) มีรูปแบบการโอเวอร์โหลดเพื่อจัดแนวทั้งชุดหรือดัชนีคอลเลกชันที่เลือก [ShapesAlignmentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapesalignmenttype/) ระบุขอบ, เส้นกึ่งกลาง, หรือโหมดการกระจาย ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปทรงที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปทรงให้อยู่ที่ขอบด้านบนของสไลด์ การอ้างอิงรูปทรงที่ส่งกลับจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนการจัดแนว

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

การจัดแนวเปลี่ยนตำแหน่ง ไม่ใช่ลำดับ z‑order การจัดแนวเชิงสัมพันธ์มักต้องมีอย่างน้อยสองรูปทรง ในขณะกระจายแนวนอนหรือแนวตั้งต้องมีรูปทรงเพียงพอที่จะกำหนดระยะห่าง หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอด ให้คำนวณดัชนีใหม่

## **พลิกรูปทรง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าการพลิกรูปแบบแนวนอนและแนวตั้ง, และการหมุน ค่าของ `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิดการพลิก, `NotDefined` รักษาสถานะที่ไม่ได้ระบุ/ค่าเริ่มต้น

การนำเสนออินพุตด้านล่างมีรูปทรงที่ไม่ได้พลิก

![รูปทรงก่อนการพลิก](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่น ๆ ทั้งหมดและแทนที่เฉพาะค่าการพลิกสองค่า เท่านั้น ซึ่งสำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ใหม่จะทับกรอบทั้งหมด

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

รูปทรงที่บันทึกจะถูกสะท้อนทั้งแนวนอนและแนวตั้ง ในขณะที่ตำแหน่ง, ขนาด, และการหมุนยังคงเดิม

![รูปทรงหลังการพลิก](flipped_shape.png)

## **FAQ**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปทรงหรือไม่?**

ใช้ได้เฉพาะการประมวลผลระยะสั้นที่คอลเลกชันจะไม่เปลี่ยนก่อนใช้ดัชนี แนะนำให้ใช้ `Name` หรือแนวทางตั้งค่า `AlternativeText` สำหรับเทมเพลตที่จัดทำขึ้น, หรือ `OfficeInteropShapeId` สำหรับงานระดับสไลด์ที่ต้องใช้ interop

**การซ่อนรูปทรงทำให้มันออกจาก z‑order หรือไม่?**

ไม่ รูปทรงที่ซ่อนอยู่ยังคงอยู่ในคอลเลกชันที่ดัชนีเดิม สามารถค้นหา, เปลี่ยนลำดับ, แก้ไข, หรือทำให้มองเห็นอีกครั้งได้

**ทำไมรูปทรงที่คัดลอกจึงปรากฏอยู่หน้ารูปทรงอื่น?**

`addClone` จะต่อท้ายสำเนาไปยังตำแหน่งสุดท้ายของคอลเลกชัน ซึ่งเป็นด้านหน้าของ z‑order ใช้ `insertClone` เพื่อกำหนดดัชนีเริ่มต้น หรือใช้ `reorder` หลังจากเพิ่มรูปทรงทั้งหมดแล้ว

**สามารถใช้ดัชนีคงที่เพื่อระบุการปรับค่ารูปทรงพรีเซ็ตได้หรือไม่?**

ได้เฉพาะหลังจากตรวจสอบพรีเซ็ตและโครงสร้างคอลเลกชันอย่างแม่นยำ แนะนำให้วนผ่าน `IGeometryShape.getAdjustments` และตรวจสอบ `IAdjustValue.getType`; ใช้ `IAdjustValue.getName` เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดียวกันปรากฏหลายครั้ง