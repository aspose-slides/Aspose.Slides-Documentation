---
title: สไลด์มาสเตอร์
type: docs
weight: 30
url: /th/nodejs-java/examples/elements/master-slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์มาสเตอร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สำรวจตัวอย่างสไลด์มาสเตอร์ของ Aspose.Slides สำหรับ Node.js: สร้าง, แก้ไขและกำหนดรูปแบบมาสเตอร์, ตัวแทนตำแหน่ง, และธีมใน PPT, PPTX, และ ODP ด้วยโค้ดที่ชัดเจน."
---
สไลด์มาสเตอร์เป็นระดับบนสุดของลำดับชั้นการสืบทอดสไลด์ใน PowerPoint. **สไลด์มาสเตอร์** กำหนดองค์ประกอบการออกแบบที่ใช้ร่วมกันเช่นพื้นหลัง, โลโก้, และการจัดรูปแบบข้อความ. **สไลด์เลเอาต์** สืบทอดจากสไลด์มาสเตอร์, และ **สไลด์ปกติ** สืบทอดจากสไลด์เลเอาต์.

บทความนี้แสดงวิธีสร้าง, แก้ไข, และจัดการสไลด์มาสเตอร์โดยใช้ Aspose.Slides for Node.js ผ่าน Java.

## **เพิ่มสไลด์มาสเตอร์**

ตัวอย่างนี้แสดงวิธีสร้างสไลด์มาสเตอร์ใหม่โดยทำสำเนาจากสไลด์มาสเตอร์ค่าเริ่มต้น. จากนั้นจะเพิ่มแบนเนอร์ชื่อบริษัทไปยังสไลด์ทั้งหมดผ่านการสืบทอดเลเอาต์.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // คัดลอกสไลด์มาสเตอร์ค่าเริ่มต้น.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // เพิ่มแบนเนอร์ชื่อบริษัทที่ด้านบนของสไลด์มาสเตอร์.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // กำหนดสไลด์มาสเตอร์ใหม่ให้กับสไลด์เลเอาต์.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // กำหนดสไลด์เลเอาต์ให้กับสไลด์แรกในพรีเซนเทชัน.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **หมายเหตุ 1:** สไลด์มาสเตอร์ให้วิธีการนำแบรนด์หรือองค์ประกอบการออกแบบที่สอดคล้องกันไปใช้ในทุกสไลด์. การเปลี่ยนแปลงใด ๆ ที่ทำกับมาสเตอร์จะสะท้อนโดยอัตโนมัตต่อสไลด์เลเอาต์และสไลด์ปกติที่ขึ้นอยู่.  
> 💡 **หมายเหตุ 2:** รูปทรงหรือการจัดรูปแบบใด ๆ ที่เพิ่มลงในสไลด์มาสเตอร์จะถูกสืบทอดไปยังสไลด์เลเอาต์และต่อไปยังสไลด์ปกติทั้งหมดที่ใช้เลเอาต์เหล่านั้น.  
> ภาพด้านล่างแสดงให้เห็นว่ากล่องข้อความที่เพิ่มบนสไลด์มาสเตอร์จะถูกเรนเดอร์โดยอัตโนมัติบนสไลด์สุดท้าย.

![Master Inheritance Example](master-slide-banner.png)

## **เข้าถึงสไลด์มาสเตอร์**

คุณสามารถเข้าถึงสไลด์มาสเตอร์โดยใช้คอลเลกชันมาสเตอร์ของพรีเซนเทชัน. นี่คือวิธีการดึงและทำงานกับสไลด์เหล่านั้น:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // เปลี่ยนประเภทพื้นหลัง.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบสไลด์มาสเตอร์**

สไลด์มาสเตอร์สามารถลบได้ทั้งโดยตำแหน่งดัชนีหรือโดยการอ้างอิง.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // ลบสไลด์มาสเตอร์ตามดัชนี.
        presentation.getMasters().removeAt(0);

        // ลบสไลด์มาสเตอร์ตามการอ้างอิง.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

บางพรีเซนเทชันมีสไลด์มาสเตอร์ที่ไม่ได้ใช้งาน. การลบสไลด์เหล่านี้สามารถช่วยลดขนาดไฟล์ได้.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้งานทั้งหมด (รวมถึงสไลด์ที่ทำเครื่องหมายว่า Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```