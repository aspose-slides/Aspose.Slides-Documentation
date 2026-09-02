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
- ข้อความทางเลือกของรูปร่าง
- รูปแบบการจัดเรียงรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- พลิกรูปร่าง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการระบุ, คัดลอก, ลบ, ซ่อน, จัดลำดับใหม่, ส่งออก, จัดแนว, และพลิกรูปร่างการนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **Overview**

Aspose.Slides for Android via Java แสดงรูปร่างบนสไลด์เป็นลำดับของ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) ที่จัดเรียงไว้ ความต่อเนื่องนี้เป็นทั้งที่คุณค้นหาและแก้ไขรูปร่างและแหล่งที่มาของลำดับซ้อนกัน: ดัชนี `0` คือรูปร่างที่อยู่ด้านหลังที่สุด ในขณะที่ดัชนีสุดท้ายคือรูปร่างที่อยู่ด้านหน้าที่สุด

บทความนี้ทำตามโมเดลนั้น โดยอธิบายวิธีระบุรูปร่างอย่างมั่นคง จากนั้นแสดงวิธีคัดลอก ลบ ซ่อน และจัดเรียงใหม่ของรูปร่าง ส่วนสุดท้ายจะครอบคลุมการจัดรูปแบบระดับเลย์เอาต์ การส่งออกเป็น SVG การจัดแนว และการตั้งค่าการพลิกของรูปร่าง ตัวอย่างแต่ละส่วนเป็นอิสระกัน ดังนั้นคุณสามารถใช้เฉพาะการดำเนินการที่โฟลว์ของคุณต้องการได้

## **Identify and Find Shapes**

ดัชนีของคอลเลกชันสะดวกเมื่อประมวลผลไฟล์ที่รู้จักแล้ว แต่ไม่ใช่ตัวระบุที่คงที่ การเพิ่ม ลบ หรือจัดเรียงใหม่ของรูปร่างอาจเปลี่ยนดัชนีของมัน เลือกตัวระบุตามวิธีที่การนำเสนอถูกสร้างและดูแล:

- [Name](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getName--) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและง่ายต่อการตรวจสอบในแผงการเลือกของ PowerPoint ชื่อสามารถแก้ไขได้และไม่ได้รับประกันว่าจะเป็นเอกลักษณ์ ดังนั้นควรกำหนดแนวปฏิบัติกับชื่อ หากโค้ดต้องอิงชื่อ
- [AlternativeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getAlternativeText--) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบรูปร่างอยู่แล้ว มันมองเห็นได้โดยผู้ใช้ อาจมีการแปลหรือเขียนใหม่เพื่อการเข้าถึง และไม่ได้รับประกันว่าเป็นเอกลักษณ์ อย่าเปลี่ยนข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่แจ้งผู้ใช้
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) เป็นตัวระบุแบบอ่านอย่างเดียวที่เป็นเอกลักษณ์ภายในสไลด์และสอดคล้องกับ ID ของรูปร่างที่ PowerPoint ใช้ ใช้เมื่อต้องผสานกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ชัดเจนตลอดอายุของรูปร่าง รูปร่างที่คัดลอกหรือสร้างใหม่จะเป็นรูปร่างที่แตกต่างและจะได้รับ ID ของตนเอง

เมธอด [getUniqueId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getUniqueId--) ที่เกี่ยวข้องคืนตัวระบุระดับการนำเสนอ แต่ตัวระบุนั้นออกแบบมาสำหรับแอด‑อินและอาจถูกกำหนดใหม่ ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร หากความเป็นตัวตนระยะยาวเป็นสิ่งสำคัญ ให้เก็บแมพปิ้งไว้ในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปร่างที่คาดหวังยังคงมีอยู่

ตัวอย่างต่อไปค้นหาตามชื่อด้วยการเปรียบเทียบแบบตรงและรายงาน ID Interop ที่มีขอบเขตสไลด์ เมื่อเทมเพลตไม่มีรูปร่างที่คาดไว้ โค้ดจะรายงานผลนั้นแทนที่จะทำต่อด้วยออบเจ็กต์ที่ผิด

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

เมื่อการดำเนินการเฉพาะเจาะจงต่อประเภทของรูปร่าง ให้ตรวจสอบอินเทอร์เฟซก่อนใช้สมาชิกที่เฉพาะเจาะจง ตัวอย่างนี้อัปเดตข้อความและข้อความทางเลือกเฉพาะเมื่อออบเจ็กต์ที่ระบุชื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/)

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

## **Modify the Shape Collection**

เมธอดเพิ่ม คัดลอก ลบ และจัดเรียงใหม่ทำงานบนคอลเลกชันโดยตรง หากการดำเนินการทำให้จำนวนหรือลำดับของรูปร่างเปลี่ยนแปลง อย่าอ้างอิงดัชนีที่จับไว้ก่อนหน้านั้นต่อไป

### **Clone a Shape**

[addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) สร้างสำเนาอิสระและเพิ่มต่อท้ายคอลเลกชันเป้าหมาย [insertClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) ก็สร้างสำเนาเช่นกันแต่ใส่ไว้ที่ดัชนี z‑order ที่ระบุ ค่าที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; ค่าที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างสร้างสไลด์ปลายทาง คัดลอกรูปสี่เหลี่ยมที่มีป้ายกำกับไปด้านหน้า และแทรกสำเนาที่สองไว้ที่ด้านหลัง การเปลี่ยนแปลงใด ๆ กับสำเนาใด ๆ จะไม่กระทบต่อรูปร่างต้นฉบับ

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

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปร่างรวมถึงชื่อและข้อความทางเลือกด้วย ให้กำหนดตัวระบุเชิงลอจิกใหม่ให้กับสำเนาเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์ ทรัพยากรที่ใช้โดยรูปร่างซับซ้อนจะจัดการโดยการนำเสนอ แต่สำเนาก็ยังคงเป็นรายการใหม่ในคอลเลกชันพร้อมอัตลักษณ์รูปร่างใหม่

### **Remove Shapes**

[remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) ลบออบเจ็กต์รูปร่างเฉพาะออกจากคอลเลกชันของมัน เมื่อลบหลายรายการที่ตรงกันระหว่างการวนลูปตามดัชนี ให้วนจากท้ายที่สุดเพื่อให้ดัชนีที่เหลือทั้งหมดยังคงใช้ได้

ตัวอย่างนี้ลบรูปร่างทุกอันที่มีชื่อที่กำหนดไว้ มันอ่านรูปร่างที่ดัชนีปัจจุบัน ไม่ใช่รายการคอลเลกชันคงที่และไม่ได้ทำการแคสท์รูปร่างโดยไม่มีเหตุผล

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

หลังจากลบ จำนวนรูปร่างและดัชนีของรูปร่างที่เหลือจะเปลี่ยน แหล่งอ้างอิงที่ไม่ถูกกระทบยังคงเชื่อถือได้กว่าดัชนีที่บันทึกไว้ ควรพิจารณาตัวเชื่อมต่อ แอนิเมชัน และคุณลักษณะการนำเสนออื่น ๆ ที่อาจอ้างอิงถึงออบเจ็กต์ที่ถูกลบ; การลบรูปร่างที่มองเห็นได้อาจเปลี่ยนมากกว่าตัวสไลด์เดียว

### **Hide a Shape**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) เป็น `true` จะทำให้รูปร่างยังคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในการสไลด์โชว์ปกติ ดัชนี การจัดรูปแบบและเนื้อหายังคงสามารถเข้าถึงได้โดยโค้ด ดังนั้นการซ่อนจึงเหมาะกับองค์ประกอบที่เป็นตัวเลือกและอาจถูกกู้คืนในภายหลัง

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

การซ่อนไม่ได้เป็นการลบหรือการรักษาความปลอดภัย ออบเจ็กต์ยังคงถูกค้นพบและสามารถทำให้แสดงออกได้โดยผู้ใช้หรือโดยโค้ด และยังคงเป็นส่วนหนึ่งของไฟล์การนำเสนอ

### **Change the Z-Order**

รูปร่างที่ทับกันจะถูกวาดตามลำดับของคอลเลกชัน [reorder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ย้ายรูปร่างที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องคัดลอก ดัชนี `0` คือด้านหลัง; `size() - 1` คือด้านหน้า

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

สี่เหลี่ยมถูกสร้างก่อนและเริ่มต้นอยู่หลังวงรี การย้ายมันไปยังดัชนีสุดท้ายจะทำให้มันอยู่ด้านหน้า สรุปลำดับ z‑order หลังจากเพิ่มหรือคัดลอกรูปร่างที่เกี่ยวข้องทั้งหมด เพราะการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการใหม่ในคอลเลกชันและอาจเปลี่ยนสแต็กที่ตั้งใจไว้

## **Inspect Shapes on Layout Slides**

สไลด์ปกติ สไลด์เลย์เอาต์ และสไลด์มาสเตอร์มีคอลเลกชันรูปร่างแยกกัน รูปร่างในคอลเลกชันเลย์เอาต์ไม่ใช่ออบเจ็กต์เดียวกับรูปร่างที่มีตำแหน่งคล้ายกันบนสไลด์ปกติ ตรวจสอบรูปร่างเลย์เอาต์เมื่อคุณต้องการทำความเข้าใจหรือเปลี่ยนการจัดรูปแบบที่เลย์เอาต์กำหนด

ตัวอย่างต่อไปอ่าน [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getFillFormat--) และ [LineFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getLineFormat--) ของแต่ละรูปร่างในเลย์เอาต์โดยไม่สมมติว่าทุกรูปร่างเป็น `AutoShape`

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

การแก้ไขเลย์เอาต์อาจส่งผลต่อหลายสไลด์ที่ใช้มัน ก่อนเปลี่ยนรูปร่างในเลย์เอาต์ให้ตรวจสอบว่าซไลด์ปกติสืบทอดออบเจ็กต์นั้นหรือมีการเขียนทับในระดับท้องถิ่น และทดสอบทุกสไลด์ที่ใช้งานเลย์เอาต์นั้น

## **Export a Shape to SVG**

[writeAsSvg](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) จะเขียนเนื้อหาที่เรนเดอร์ของรูปร่างหนึ่งไปยังสตรีม ผลลัพธ์จะมีเฉพาะรูปร่างนั้น ไม่รวมพื้นหลังของสไลด์ทั้งหมดหรือรูปร่างข้างเคียง

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

ควรรักษาการนำเสนอเปิดอยู่ขณะเรนเดอร์ เอาต์พุตขึ้นกับการจัดรูปแบบของรูปร_shapeและทรัพยากรเช่นแบบอักษรและภาพ หากคุณต้องการส่วนประกอบทั้งหมด ให้ส่งออกสไลด์แทนการส่งออกรูปร่างเดี่ยว ผู้เรียกใช้เป็นเจ้าของสตรีมและต้องปิดสตรีมนั้น

## **Align Shapes**

เมธอด [SlideUtil.alignShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) มีหลายรูปแบบเพื่อจัดแนวทั้งหมดหรือดัชนีคอลเลกชันที่เลือก [ShapesAlignmentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapesalignmenttype/) กำหนดขอบ, เส้นศูนย์กลาง หรือโหมดกระจาย ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปร่างที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปร่างให้ชิดด้านบนของสไลด์ การอ้างอิงรูปร่างที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนการจัดแนว

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

การจัดแนวเปลี่ยนตำแหน่ง ไม่เปลี่ยนลำดับ z‑order การจัดแนวเชิงสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปร่าง ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปร่างเพียงพอเพื่อกำหนดระยะห่าง หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอดให้คำนวณดัชนีใหม่

## **Flip a Shape**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าการพลิกแนวนอนและแนวตั้ง, และการหมุน ค่า `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิดการพลิก, `NotDefined` คงสภาพที่ไม่ได้กำหนด/ค่าเริ่มต้น

การนำเสนออินพุตด้านล่างมีรูปร่างที่ไม่ได้พลิก

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้เก็บค่ากรอบอื่น ๆ ไว้ทั้งหมดและแทนที่เพียงสองการตั้งค่าการพลิกเท่านั้น สิ่งนี้สำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) ใหม่จะทับกรอบทั้งหมด

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

รูปร่างที่บันทึกแล้วจะถูกสะท้อนแนวนอนและแนวตั้งพร้อมคงตำแหน่ง, ขนาด, และการหมุนเดิม

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

ใช้ได้เฉพาะสำหรับการประมวลผลสั้น ๆ ที่คอลเลกชันจะไม่เปลี่ยนแปลงก่อนที่ดัชนีจะถูกใช้ แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ผ่านการตรวจสอบเป็นแนวปฏิบัติสำหรับเทมเพลตที่สร้างขึ้น, หรือ `OfficeInteropShapeId` สำหรับงานที่ต้องอิงสไลด์‑scoped interop

**Does hiding a shape remove it from the z-order?**

ไม่. รูปร่างที่ซ่อนอยู่ยังคงอยู่ในคอลเลกชันที่ดัชนีเดิม สามารถค้นหา, จัดเรียงใหม่, แก้ไข, หรือทำให้แสดงผลอีกครั้งได้

**Why did a cloned shape appear in front of another shape?**

`addClone` เพิ่มสำเนาที่ส่วนท้ายของคอลเลกชัน ซึ่งเป็นส่วนหน้าของ z‑order ใช้ `insertClone` เพื่อเลือกดัชนีเริ่มต้น หรือใช้ `reorder` หลังจากเพิ่มรูปร่างทั้งหมดแล้ว