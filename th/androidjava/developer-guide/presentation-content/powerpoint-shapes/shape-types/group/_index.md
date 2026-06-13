---
title: กลุ่มรูปร่างการนำเสนอบน Android
linktitle: กลุ่มรูปร่าง
type: docs
weight: 40
url: /th/androidjava/group/
keywords:
- กลุ่มรูป
- รูปร่างกลุ่ม
- เพิ่มกลุ่ม
- ข้อความทางเลือก
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้การจัดกลุ่มและยกเลิกการจัดกลุ่มรูปในชุด PowerPoint ด้วย Aspose.Slides สำหรับ Android—คู่มือเร็วขั้นตอนต่อขั้นตอนพร้อมโค้ด Java ฟรี"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับรูปแบบกลุ่มใน Aspose.Slides แสดงวิธีเพิ่มรูปแบบกลุ่มลงในสไลด์ ใส่รูปร่างภายใน และบันทึกงานนำเสนอที่อัปเดต นอกจากนี้ยังสาธิตวิธีเข้าถึงรูปร่างที่เก็บอยู่ภายในกลุ่มและอ่านค่า `AlternativeText` ของพวกมัน อีกทั้งบทความยังสรุปสั้น ๆ เกี่ยวกับความสามารถของรูปแบบกลุ่มที่เกี่ยวข้อง เช่น กลุ่มซ้อนกัน ลำดับ z‑order และตัวเลือกการล็อก

## **เพิ่มรูปแบบกลุ่ม**
Aspose.Slides รองรับการทำงานกับรูปแบบกลุ่มบนสไลด์ ฟีเจอร์นี้ช่วยให้นักพัฒนาสามารถสร้างงานนำเสนอที่มีความหลากหลายมากขึ้น Aspose.Slides for Android via Java รองรับการเพิ่มหรือเข้าถึงรูปแบบกลุ่ม สามารถเพิ่มรูปร่างลงในรูปแบบกลุ่มที่เพิ่มเข้ามาเพื่อเติมเนื้อหา หรือเข้าถึงคุณสมบัติใด ๆ ของรูปแบบกลุ่ม เพื่อเพิ่มรูปแบบกลุ่มลงในสไลด์โดยใช้ Aspose.Slides for Android via Java:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เพิ่มรูปแบบกลุ่มลงในสไลด์
1. เพิ่มรูปร่างลงในรูปแบบกลุ่มที่เพิ่มเข้ามา
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่มรูปแบบกลุ่มลงในสไลด์

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เข้าถึงคอลเลกชันรูปร่างของสไลด์
    IShapeCollection slideShapes = sld.getShapes();

    // เพิ่มรูปแบบกลุ่มลงในสไลด์
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // เพิ่มรูปร่างภายในรูปแบบกลุ่มที่เพิ่มเข้ามา
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // เพิ่มเฟรมของรูปแบบกลุ่ม
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงคุณสมบัติ AltText**
หัวข้อนี้แสดงขั้นตอนง่าย ๆ พร้อมตัวอย่างโค้ด สำหรับการเพิ่มรูปแบบกลุ่มและการเข้าถึงคุณสมบัติ AltText ของรูปแบบกลุ่มบนสไลด์ เพื่อเข้าถึง AltText ของรูปแบบกลุ่มในสไลด์โดยใช้ Aspose.Slides for Android via Java:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่แทนไฟล์ PPTX
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เข้าถึงคอลเลกชันรูปร่างของสไลด์
1. เข้าถึงรูปแบบกลุ่ม
1. เข้าถึงคุณสมบัติ[AlternativeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getAlternativeText--) 

ตัวอย่างด้านล่างเข้าถึงข้อความทางเลือกของรูปแบบกลุ่ม

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // เข้าถึงคอลเลกชันรูปร่างของสไลด์
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // เข้าถึงรูปแบบกลุ่ม.
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

ใช่. [GroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/groupshape/) มีเมธอด[getParentGroup](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getParentGroup--) ซึ่งบ่งชี้การสนับสนุนระดับชั้น (กลุ่มสามารถเป็นลูกของกลุ่มอื่นได้)

**ฉันจะควบคุมลำดับ z‑order ของกลุ่มเทียบกับวัตถุอื่นบนสไลด์ได้อย่างไร?**

ใช้เมธอด[GroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/groupshape/)’s[getZOrderPosition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getZOrderPosition--) เพื่อตรวจสอบตำแหน่งของมันในสแต็คการแสดงผล

**ฉันสามารถป้องกันไม่ให้ย้าย/แก้ไข/ยกเลิกการจัดกลุ่มได้หรือไม่?**

ใช่. ส่วนการล็อกของกลุ่มเปิดให้เข้าถึงผ่าน[getGroupShapeLock](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) ซึ่งช่วยให้คุณจำกัดการดำเนินการบนอ็อบเจ็กต์ได้