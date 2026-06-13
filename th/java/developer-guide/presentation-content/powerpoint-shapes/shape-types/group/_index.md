---
title: รูปร่างการนำเสนอแบบกลุ่มใน Java
linktitle: กลุ่มรูปร่าง
type: docs
weight: 40
url: /th/java/group/
keywords:
- รูปร่างกลุ่ม
- กลุ่มรูปร่าง
- เพิ่มกลุ่ม
- ข้อความแทน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การจัดกลุ่มและยกเลิกการจัดกลุ่มรูปร่างในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Java—คู่มือเร็วขั้นตอนต่อขั้นตอนพร้อมโค้ด Java ฟรี"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับกลุ่มรูปร่างใน Aspose.Slides แสดงวิธีการเพิ่มกลุ่มรูปร่างลงในสไลด์ ใส่รูปร่างภายใน และบันทึกการนำเสนอที่อัปเดต นอกจากนี้ยังสาธิตวิธีการเข้าถึงรูปร่างที่จัดเก็บอยู่ในกลุ่มและอ่านค่า `AlternativeText` ของพวกมัน อีกทั้งบทความยังครอบคลุมความสามารถที่เกี่ยวข้องกับกลุ่มรูปร่าง เช่น กลุ่มซ้อนกัน การจัดลำดับ z‑order และตัวเลือกการล็อก อย่างสั้น

## **เพิ่มกลุ่มรูปร่าง**
Aspose.Slides รองรับการทำงานกับกลุ่มรูปร่างบนสไลด์ คุณลักษณะนี้ช่วยให้ผู้พัฒนาสร้างการนำเสนอที่หลากหลายยิ่งขึ้น Aspose.Slides for Java รองรับการเพิ่มหรือเข้าถึงกลุ่มรูปร่าง สามารถเพิ่มรูปร่างลงในกลุ่มที่เพิ่มแล้วเพื่อเติมข้อมูลหรือเข้าถึงคุณสมบัติใด ๆ ของกลุ่มรูปร่าง เพื่อเพิ่มกลุ่มรูปร่างลงในสไลด์โดยใช้ Aspose.Slides for Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
2. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
3. เพิ่มกลุ่มรูปร่างลงในสไลด์.
4. เพิ่มรูปร่างลงในกลุ่มรูปร่างที่เพิ่มแล้ว.
5. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

ตัวอย่างด้านล่างเพิ่มกลุ่มรูปร่างลงในสไลด์.

```java
    // สร้างอินสแตนซ์ของคลาส Presentation
    Presentation pres = new Presentation();
    try {
        // ดึงสไลด์แรก
        ISlide sld = pres.getSlides().get_Item(0);

        // เข้าถึงคอลเลกชันของรูปร่างในสไลด์
        IShapeCollection slideShapes = sld.getShapes();

        // เพิ่มกลุ่มรูปร่างลงในสไลด์
        IGroupShape groupShape = slideShapes.addGroupShape();
        
        // เพิ่มรูปร่างภายในกลุ่มรูปร่างที่เพิ่มแล้ว
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
        groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

        // เพิ่มกรอบของกลุ่มรูปร่าง
        groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

        // เขียนไฟล์ PPTX ไปยังดิสก์
        pres.save("GroupShape.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **เข้าถึงคุณสมบัติ AltText**
หัวข้อนี้แสดงขั้นตอนง่าย ๆ พร้อมตัวอย่างโค้ด สำหรับการเพิ่มกลุ่มรูปร่างและการเข้าถึงคุณสมบัติ AltText ของกลุ่มรูปร่างบนสไลด์ เพื่อเข้าถึง AltText ของกลุ่มรูปร่างในสไลด์โดยใช้ Aspose.Slides for Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่แสดงไฟล์ PPTX.
2. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
3. เข้าถึงคอลเลกชันของรูปร่างในสไลด์.
4. เข้าถึงกลุ่มรูปร่าง.
5. เข้าถึงคุณสมบัติ [AlternativeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#getAlternativeText--).

ตัวอย่างด้านล่างเข้าถึงข้อความทางเลือกของกลุ่มรูปร่าง.

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // เข้าถึงคอลเลกชันของรูปร่างในสไลด์
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // เข้าถึงกลุ่มรูปร่าง.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // เข้าถึงคุณสมบัติ AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**รองรับการจัดกลุ่มซ้อนกัน (กลุ่มภายในกลุ่ม) หรือไม่?**

ใช่. [GroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/groupshape/) มีเมธอด [getParentGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getParentGroup--) ซึ่งบ่งชี้การสนับสนุนโครงสร้างลำดับขั้นโดยตรง (กลุ่มหนึ่งสามารถเป็นลูกของกลุ่มอื่นได้).

**ฉันจะควบคุมลำดับ z-order ของกลุ่มสัมพันธ์กับวัตถุอื่น ๆ บนสไลด์อย่างไร?**

ใช้เมธอด [getZOrderPosition](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getZOrderPosition--) ของ [GroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/groupshape/) เพื่อตรวจสอบตำแหน่งของมันในสแต็กการแสดงผล.

**ฉันสามารถป้องกันการย้าย/แก้ไข/ยกเลิกการจัดกลุ่มได้หรือไม่?**

ใช่. ส่วนการล็อกของกลุ่มถูกเปิดเผยผ่าน [GroupShapeLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/groupshape/#getGroupShapeLock--) ซึ่งให้คุณจำกัดการทำงานบนออบเจกต์นั้น.