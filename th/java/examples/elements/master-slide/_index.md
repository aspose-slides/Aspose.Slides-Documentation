---
title: สไลด์มาสเตอร์
type: docs
weight: 30
url: /th/java/examples/elements/master-slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์มาสเตอร์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สำรวจตัวอย่างสไลด์มาสเตอร์ของ Aspose.Slides for Java: สร้าง, แก้ไขและออกแบบมาสเตอร์, พื้นที่ใส่เนื้อหา, และธีมในไฟล์ PPT, PPTX, และ ODP ด้วยโค้ด Java ที่ชัดเจน."
---
สไลด์มาสเตอร์อยู่ในระดับบนสุดของลำดับชั้นการสืบทอดสไลด์ใน PowerPoint. **สไลด์มาสเตอร์** กำหนดองค์ประกอบการออกแบบทั่วไป เช่น พื้นหลัง, โลโก้, และการจัดรูปแบบข้อความ. **สไลด์เลย์เอาท์** สืบทอดจากสไลด์มาสเตอร์, และ **สไลด์ปกติ** สืบทอดจากสไลด์เลย์เอาท์.

บทความนี้แสดงวิธีการสร้าง, แก้ไข, และจัดการสไลด์มาสเตอร์โดยใช้ Aspose.Slides for Java.

## **เพิ่มสไลด์มาสเตอร์**

ตัวอย่างนี้แสดงวิธีการสร้างสไลด์มาสเตอร์ใหม่โดยการโคลนสไลด์มาสเตอร์เริ่มต้น. จากนั้นเพิ่มแบนเนอร์ชื่อบริษัทให้กับสไลด์ทั้งหมดผ่านการสืบทอดเลย์เอาท์.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // คัดลอกสไลด์มาสเตอร์เริ่มต้น.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // เพิ่มแบนเนอร์ชื่อบริษัทที่ด้านบนของสไลด์มาสเตอร์.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // กำหนดสไลด์มาสเตอร์ใหม่ให้กับสไลด์เลย์เอาท์.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // กำหนดสไลด์เลย์เอาท์ให้กับสไลด์แรกในงานนำเสนอ.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** สไลด์มาสเตอร์ให้วิธีการใช้การสร้างแบรนด์หรือองค์ประกอบการออกแบบที่สอดคล้องกันในทุกสไลด์ การเปลี่ยนแปลงใด ๆ ที่ทำบนมาสเตอร์จะสะท้อนโดยอัตโนมัติบนสไลด์เลย์เอาท์และสไลด์ปกติที่พึ่งพา.
> 
> 💡 **Note 2:** รูปร่างหรือการจัดรูปแบบใด ๆ ที่เพิ่มลงในสไลด์มาสเตอร์จะถูกสืบทอดโดยสไลด์เลย์เอาท์และต่อมาทุกสไลด์ปกติที่ใช้เลย์เอาท์เหล่านั้น.
> ภาพด้านล่างแสดงให้เห็นว่ากล่องข้อความที่เพิ่มบนสไลด์มาสเตอร์จะถูกแสดงผลโดยอัตโนมัติบนสไลด์สุดท้าย.

![ตัวอย่างการสืบทอดมาสเตอร์](master-slide-banner.png)

## **เข้าถึงสไลด์มาสเตอร์**

คุณสามารถเข้าถึงสไลด์มาสเตอร์โดยใช้คอลเลกชันมาสเตอร์ของงานนำเสนอ นี่คือวิธีการดึงและทำงานกับสไลด์เหล่านั้น:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // เปลี่ยนประเภทพื้นหลัง.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบสไลด์มาสเตอร์**

สไลด์มาสเตอร์สามารถลบได้โดยใช้ดัชนีหรือโดยอ้างอิง.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // ลบสไลด์มาสเตอร์โดยใช้ดัชนี.
        presentation.getMasters().removeAt(0);

        // ลบสไลด์มาสเตอร์โดยอ้างอิง.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

งานนำเสนอบางส่วนมีสไลด์มาสเตอร์ที่ไม่ได้ใช้งาน การลบสไลด์เหล่านี้สามารถช่วยลดขนาดไฟล์ได้.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้ทั้งหมด (แม้สไลด์ที่ถูกทำเครื่องหมายเป็น Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```