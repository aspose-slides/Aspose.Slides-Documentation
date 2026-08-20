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
- รูปแบบการจัดวางรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- กลับด้านรูปร่าง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, คัดลอก, ลบ, ซ่อน, เปลี่ยนลำดับ, ส่งออก, จัดแนว, และกลับด้านรูปร่างการนำเสนอด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides for Java แสดงรูปร่างบนสไลด์เป็น [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) ที่จัดลำดับ. คอลเลกชันเป็นทั้งที่ที่คุณค้นหาและแก้ไขรูปร่างและเป็นแหล่งที่มาของลำดับการซ้อน: ดัชนี `0` คือรูปร่างที่อยู่ลึกสุดด้านหลัง, ส่วนดัชนีสุดท้ายคือรูปร่างที่อยู่ด้านหน้าสุด.

บทความนี้อิงตามโมเดลนั้น. มันอธิบายวิธีการระบุรูปร่างอย่างแม่นยำ, จากนั้นแสดงวิธีคัดลอก, ลบ, ซ่อน, และเปลี่ยนลำดับของรูปร่าง. ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์, การส่งออก SVG, การจัดแนว, และการตั้งค่าการกลับด้าน. ตัวอย่างแต่ละอันเป็นอิสระ, ดังนั้นคุณสามารถใช้เฉพาะการดำเนินการที่ workflow ของคุณต้องการ.

## **ระบุและค้นหา Shape**

ดัชนีของคอลเลกชันสะดวกขณะประมวลผลไฟล์ที่รู้จัก, แต่ไม่ใช่ตัวระบุที่คงที่. การเพิ่ม, ลบ, หรือเปลี่ยนลำดับของรูปร่างอาจทำให้ดัชนีเปลี่ยน. เลือกตัวระบุตามวิธีที่การนำเสนอถูกสร้างและดูแล:

- [Name](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getName--) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและตรวจสอบได้ง่ายในแถบ Selection ของ PowerPoint. ชื่อสามารถแก้ไขได้และไม่รับประกันว่าจะเป็นเอกลักษณ์, ดังนั้นควรกำหนดแนวทางการตั้งชื่อถ้ารหัสพึ่งพา.
- [AlternativeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getAlternativeText--) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบุรูปร่าง. มันมองเห็นได้โดยผู้ใช้, อาจแปลเป็นภาษาต่าง ๆ หรือปรับใหม่เพื่อการเข้าถึง, และไม่รับประกันว่าเป็นเอกลักษณ์. อย่าใช้ข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่มีการแจ้งเตือน.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) เป็นตัวระบุแบบอ่านอย่างเดียวที่เป็นเอกลักษณ์ภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint ใช้. ใช้เมื่อต้องบูรณาการกับ PowerPoint หรือเมื่อต้องการอ้างอิงที่ชัดเจนตลอดอายุของรูปร่าง. รูปร่างที่คัดลอกหรือสร้างใหม่จะเป็นรูปร่างที่แตกต่างและจะได้รับ ID ของตนเอง.

เมธอด [getUniqueId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getUniqueId--) ที่เกี่ยวข้องจะคืนตัวระบุที่มีขอบเขตระดับการนำเสนอ, แต่ตัวระบุนี้ออกแบบมาสำหรับแอด‑อินและอาจถูกกำหนดใหม่. ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร. หากต้องการความเป็นตัวตนระยะยาว, เก็บการแม็ปในข้อมูลของแอปพลิเคชันและตรวจสอบว่ารูปร่างที่คาดหวังยังคงมีอยู่.

ตัวอย่างต่อไปนี้ค้นหาตามชื่อด้วยการเปรียบเทียบที่ตรงกันและแสดงค่า interop ID ที่มีขอบเขตสไลด์. เมื่อเทมเพลตไม่มีรูปร่างที่คาดหวัง, รหัสจะแจ้งผลนั้นแทนที่จะดำเนินต่อด้วยวัตถุผิด.

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

เมื่อการดำเนินการเฉพาะกับประเภทของรูปร่าง, ตรวจสอบอินเทอร์เฟซก่อนใช้สมาชิกที่เจาะจงประเภท. ตัวอย่างนี้อัปเดตข้อความและข้อความทางเลือกเฉพาะเมื่อวัตถุที่ระบุเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/).

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

## **แก้ไข Collection ของ Shape**

เมธอดการเพิ่ม, คัดลอก, ลบ, และเปลี่ยนลำดับทำงานบนคอลเลกชันโดยทันที. หากการดำเนินการมีการเปลี่ยนแปลงจำนวนหรือลำดับของรูปร่าง, อย่าอ้างอิงดัชนีที่จับไว้ก่อนการดำเนินการนั้นต่อไป.

### **คัดลอก Shape**

[addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) สร้างสำเนาอิสระและเพิ่มต่อท้ายคอลเลกชันเป้าหมาย. [insertClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) ก็สร้างสำเนาเช่นกันแต่วางไว้ที่ดัชนี z‑order ที่ระบุ. overload ที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; overload ที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย.

ตัวอย่างสร้างสไลด์ปลายทาง, คัดลอกสี่เหลี่ยมที่มีป้ายชื่อไปที่ด้านหน้า, และแทรกสำเนาที่สองไว้ที่ด้านหลัง. การเปลี่ยนแปลงใด ๆ กับสำเนาใดสำเนาหนึ่งจะไม่กระทบรูปร่างต้นฉบับ.

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

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปร่าง, รวมถึงชื่อและข้อความทางเลือก. กำหนดตัวระบุเชิงตรรกะใหม่ให้กับสำเนาเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์. ทรัพยากรที่ใช้โดยรูปร่างซับซ้อนจะจัดการโดยการนำเสนอ, แต่สำเนาจะยังคงเป็นรายการใหม่ในคอลเลกชันพร้อมอัตลักษณ์รูปร่างใหม่.

### **ลบ Shape**

[remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) ลบวัตถุ Shape เฉพาะออกจากคอลเลกชันของมัน. เมื่อทำการลบหลายรายการระหว่างการวนลูปตามดัชนี, ให้วนจากท้ายเพื่อให้ดัชนีที่เหลือยังคงใช้ได้.

ตัวอย่างนี้ลบทุกรูปร่างที่มีชื่อที่กำหนด. มันอ่านรูปร่างที่ดัชนีปัจจุบัน, ไม่ใช่รายการคอลเลกชันคงที่, และไม่ทำการแคสรูปร่างโดยไม่จำเป็น.

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

หลังการลบ, จำนวนรูปร่างและดัชนีของรูปร่างที่เหลือจะเปลี่ยน. การอ้างอิงรูปร่างที่ไม่ได้รับผลกระทบจะเชื่อถือได้กว่าดัชนีที่บันทึกไว้. ควรคำนึงถึงคอนเนคเตอร์, แอนิเมชัน, และคุณลักษณะการนำเสนออื่น ๆ ที่อาจอ้างอิงถึงวัตถุที่ลบ; การลบรูปร่างที่มองเห็นได้อาจเปลี่ยนมากกว่าลักษณะของสไลด์เท่านั้น.

### **ซ่อน Shape**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setHidden-boolean-) ให้เป็น `true` จะทำให้รูปร่างคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในโหมดสไลด์ปกติ. ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงพร้อมให้โค้ดเข้าถึง, ดังนั้นการซ่อนเหมาะกับองค์ประกอบที่เป็นตัวเลือกและอาจนำกลับมาใช้ใหม่ในภายหลัง.

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

การซ่อนไม่ใช่การลบหรือความปลอดภัย. วัตถุยังคงสามารถถูกค้นพบและยกเลิกการซ่อนโดยผู้ใช้หรือโดยโค้ด, และยังคงเป็นส่วนหนึ่งของไฟล์การนำเสนอ.

### **เปลี่ยน Z‑Order**

รูปร่างที่ทับกันจะถูกวาดตามลำดับของคอลเลกชัน. [reorder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ย้ายรูปร่างที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องคัดลอก. ดัชนี `0` อยู่ด้านหลัง; `size() - 1` อยู่ด้านหน้า.

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

สี่เหลี่ยมถูกสร้างก่อนและเริ่มต้นอยู่ด้านหลังวงรี. การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า. ควรทำการจัดลำดับ z‑order สุดท้ายหลังจากเพิ่มหรือคัดลอกรูปร่างที่เกี่ยวข้องทั้งหมด, เนื่องจากการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการใหม่ในคอลเลกชันและอาจเปลี่ยนสแต็กที่ตั้งใจไว้.

## **ตรวจสอบ Shape บน Layout Slides**

สไลด์ปกติ, Layout Slides, และ Master Slides มีคอลเลกชันรูปร่างแยกกัน. รูปร่างในคอลเลกชัน Layout ไม่ใช่วัตถุเดียวกับรูปร่างที่ตำแหน่งเดียวกันบนสไลด์ปกติ. ตรวจสอบรูปร่าง Layout เมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปแบบที่มาจาก Layout.

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getFillFormat--) และ [LineFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getLineFormat--) ของแต่ละรูปร่างใน Layout โดยไม่สันนิษฐานว่าทุกรูปร่างเป็น `AutoShape`.

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

การแก้ไข Layout อาจส่งผลต่อหลายสไลด์ที่ใช้ Layout นั้น. ก่อนเปลี่ยนรูปร่าง Layout, ตรวจสอบว่าสไลด์ปกติสืบทอดวัตถุหรือมีการเขียนทับในระดับท้องถิ่น, และทดสอบทุกสไลด์ที่ใช้ Layout นั้น.

## **ส่งออก Shape ไปเป็น SVG**

[writeAsSvg](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) จะเขียนเนื้อหาที่เรนเดอร์ของรูปร่างหนึ่งเป็นสตรีม. ผลลัพธ์จะมีเฉพาะรูปร่างนั้น, ไม่รวมพื้นหลังสไลด์ทั้งหมดหรือรูปร่างใกล้เคียง.

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

ควรเปิดการนำเสนอขณะทำการเรนเดอร์. ผลลัพธ์ขึ้นกับการจัดรูปแบบของรูปร่างและทรัพยากรเช่นฟอนต์และรูปภาพ. หากต้องการภาพรวมของทั้งคอมโพสชัน, ให้ส่งออกสไลด์แทนการส่งออกรูปร่างเดี่ยว. ผู้เรียกเป็นผู้เป็นเจ้าของสตรีมและต้องปิดสตรีมเอง.

## **จัดแนว Shape**

เมธอด [SlideUtil.alignShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) มี overload ที่จัดแนวทั้งชุดหรือเฉพาะดัชนีที่เลือก. [ShapesAlignmentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapesalignmenttype/) กำหนดขอบ, เส้นกึ่งกลาง, หรือโหมดการกระจาย. ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปร่างที่เลือกสัมพันธ์กัน.

ตัวอย่างนี้จัดแนวสามรูปร่างให้ชิดขอบบนของสไลด์. การอ้างอิงรูปร่างที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนทำการจัดแนว.

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

การจัดแนวเปลี่ยนตำแหน่ง, ไม่เปลี่ยน z‑order. การจัดแนวแบบสัมพันธ์มักต้องมีอย่างน้อยสองรูปร่าง, ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปร่างเพียงพอเพื่อกำหนดระยะห่าง. หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอด, ควรคำนวณดัชนีใหม่.

## **กลับด้าน Shape**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าการกลับด้านแนวแนวนอนและแนวตั้ง, และการหมุน. ค่าของ `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/java/com.aspose.slides/nullablebool/): `True` เปิดการกลับด้าน, `False` ปิด, และ `NotDefined` รักษาสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น.

การนำเสนออินพุตด้านล่างมีรูปร่างที่ไม่ได้กลับด้านหนึ่งรูป.

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่น ๆ ทั้งหมดและเปลี่ยนเฉพาะการตั้งค่าการกลับด้านสองค่า. สิ่งนี้สำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ใหม่จะทับกรอบทั้งหมด.

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

รูปร่างที่บันทึกจะถูกสะท้อนแนวนอนและแนวตั้งขณะที่ยังคงตำแหน่ง, ขนาด, และการหมุนเดิม.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**ควรใช้ดัชนีของคอลเลกชันเป็นตัวระบุของ Shape หรือไม่?**

ใช้ได้เฉพาะในการประมวลผลสั้น ๆ ที่คอลเลกชันจะไม่เปลี่ยนแปลงก่อนใช้ดัชนีนั้น. แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ผ่านการตรวจสอบสำหรับเทมเพลตที่สร้างโดยผู้เขียน, หรือ `OfficeInteropShapeId` สำหรับงานที่ต้องอิงกับ interop ระดับสไลด์.

**การซ่อน Shape จะทำให้มันหายไปจาก z‑order หรือไม่?**

ไม่. Shape ที่ซ่อนยังคงอยู่ในคอลเลกชันที่ดัชนีเดิม. สามารถค้นหา, เปลี่ยนลำดับ, แก้ไข, หรือทำให้มองเห็นได้อีกครั้ง.

**ทำไม Shape ที่คัดลอกจึงปรากฏอยู่หน้ารูปร่างอื่น?**

`addClone` เพิ่มสำเนาที่ท้ายคอลเลกชัน, ซึ่งเป็นด้านหน้าของ z‑order. ใช้ `insertClone` เพื่อกำหนดดัชนีเริ่มต้นหรือใช้ `reorder` หลังจากเพิ่มรูปร่างทั้งหมดแล้ว.