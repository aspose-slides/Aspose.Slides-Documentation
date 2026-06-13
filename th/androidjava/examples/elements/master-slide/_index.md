---
title: สไลด์หลัก
type: docs
weight: 30
url: /th/androidjava/examples/elements/master-slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์หลัก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สำรวจตัวอย่างสไลด์หลักของ Aspose.Slides for Android: สร้าง, แก้ไขและจัดรูปแบบมาสเตอร์, พื้นที่สำรอง, และธีมใน PPT, PPTX, และ ODP ด้วยโค้ด Java ที่ชัดเจน."
---
Master slides อยู่ในระดับบนสุดของลำดับชั้นการสืบทอดสไลด์ใน PowerPoint. **master slide** กำหนดองค์ประกอบการออกแบบที่ใช้ร่วมกัน เช่น พื้นหลัง, โลโก้, และการจัดรูปแบบข้อความ. **Layout slides** สืบทอดจาก master slides, และ **normal slides** สืบทอดจาก layout slides.

บทความนี้แสดงวิธีการสร้าง, แก้ไข, และจัดการ master slides ด้วย Aspose.Slides for Android ผ่าน Java.

## **เพิ่ม Master Slide**

ตัวอย่างนี้แสดงวิธีการสร้าง master slide ใหม่โดยการโคลน slide เริ่มต้น. จากนั้นจะเพิ่มแบนเนอร์ชื่อบริษัทลงในสไลด์ทั้งหมดผ่านการสืบทอด layout.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // คัดลอกมาสเตอร์สไลด์เริ่มต้น.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // เพิ่มแบนเนอร์ชื่อบริษัทที่ด้านบนของมาสเตอร์สไลด์.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // กำหนดมาสเตอร์สไลด์ใหม่ให้กับเลย์เอาต์สไลด์.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // กำหนดเลย์เอาต์สไลด์ให้กับสไลด์แรกในพรีเซนเทชัน.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **หมายเหตุ 1:** Master slides ให้วิธีการนำเสนอการสร้างแบรนด์หรือองค์ประกอบการออกแบบที่สอดคล้องกันทั่วทั้งสไลด์. การเปลี่ยนแปลงใด ๆ ที่ทำกับ master จะถูกสะท้อนโดยอัตโนมัติกับ layout และ normal slides ที่ขึ้นอยู่กับมัน.
> 
> 💡 **หมายเหตุ 2:** รูปร่างหรือการจัดรูปแบบใด ๆ ที่เพิ่มลงใน master slide จะถูกสืบทอดโดย layout slides และต่อมาทั้งหมดของ normal slides ที่ใช้ layout เหล่านั้น.
> 
> ภาพด้านล่างแสดงให้เห็นว่า textbox ที่เพิ่มบน master slide จะถูกแสดงอัตโนมัติบนสไลด์สุดท้าย.

![ตัวอย่างการสืบทอด Master](master-slide-banner.png)

## **เข้าถึง Master Slide**

คุณสามารถเข้าถึง master slides ได้โดยใช้คอลเลกชัน master ของการนำเสนอ. ต่อไปนี้เป็นวิธีการดึงและทำงานกับพวกมัน:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // เปลี่ยนประเภทพื้นหลัง.
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ Master Slide**

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // ลบมาสเตอร์สไลด์ตามดัชนี.
        presentation.getMasters().removeAt(0);

        // ลบมาสเตอร์สไลด์ตามการอ้างอิง.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ Master Slides ที่ไม่ได้ใช้**

บางการนำเสนอมี master slides ที่ไม่ได้ใช้. การลบสไลด์เหล่านี้สามารถช่วยลดขนาดไฟล์ได้.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้ทั้งหมด (รวมถึงที่ทำเครื่องหมายว่า Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```