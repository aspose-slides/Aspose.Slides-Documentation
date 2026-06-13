---
title: สไลด์เลเอาต์
type: docs
weight: 20
url: /th/nodejs-java/examples/elements/layout-slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์เลเอาต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ครอบคลุมการใช้สไลด์เลเอาต์ใน Aspose.Slides สำหรับ Node.js: เลือก ใช้ และปรับแต่งรูปแบบสไลด์, พื้นที่จอง, และมาสเตอร์ พร้อมตัวอย่างสำหรับงานนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการทำงานกับ **Layout Slides** ใน Aspose.Slides สำหรับ Node.js ผ่าน Java. Layout slide กำหนดการออกแบบและการจัดรูปแบบที่สไลด์ปกติสืบทอดมา. คุณสามารถเพิ่ม, เข้าถึง, คัดลอก, และลบ layout slides, รวมถึงทำความสะอาด layout ที่ไม่ได้ใช้เพื่อลดขนาดของงานนำเสนอได้.

## **Add a Layout Slide**

คุณสามารถสร้าง layout slide แบบกำหนดเองเพื่อกำหนดการจัดรูปแบบที่สามารถใช้ซ้ำได้.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // สร้างสไลด์เลเอาต์ด้วยประเภทเลเอาต์ว่างและชื่อที่กำหนดเอง
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Layout slides ทำหน้าที่เป็นแม่แบบสำหรับสไลด์แต่ละอัน คุณสามารถกำหนดองค์ประกอบทั่วไปหนึ่งครั้งและใช้ซ้ำได้ในหลายสไลด์.

> 💡 **Note 2:** เมื่อคุณเพิ่มรูปทรงหรือข้อความลงใน layout slide สไลด์ทั้งหมดที่อ้างอิงจาก layout นั้นจะเปิดเผยเนื้อหาแบบแชร์นี้โดยอัตโนมัติ.  
> ภาพหน้าจอด้านล่างแสดงสองสไลด์ที่แต่ละสไลด์สืบทอดกล่องข้อความจาก layout slide เดียวกัน.

![สไลด์ที่สืบทอดเนื้อหา Layout](layout-slide-result.png)

## **Access a Layout Slide**

Layout slides สามารถเข้าถึงได้โดยใช้ดัชนีหรือโดยประเภทของ layout (เช่น `Blank`, `Title`, `SectionHeader` เป็นต้น).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // เข้าถึงสไลด์เลเอาต์ตามดัชนี
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // เข้าถึงสไลด์เลเอาต์ตามประเภท
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Layout Slide**

คุณสามารถลบ layout slide ที่ระบุได้หากไม่จำเป็นต้องใช้อีกต่อไป.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // รับสไลด์เลเอาต์ตามประเภทและลบออก
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Unused Layout Slides**

เพื่อลดขนาดของงานนำเสนอ คุณอาจต้องการลบ layout slides ที่ไม่ได้ถูกใช้โดยสไลด์ปกติใด ๆ.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // ลบสไลด์เลเอาต์ที่ไม่ได้อ้างอิงโดยสไลด์ใดๆโดยอัตโนมัติ
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Clone a Layout Slide**

คุณสามารถทำสำเนา layout slide ได้โดยใช้เมธอด `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // ดึงสไลด์เลเอาต์ที่มีอยู่ตามประเภท
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // คัดลอกสไลด์เลเอาต์ไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์เลเอาต์
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** Layout slides เป็นเครื่องมือที่มีประสิทธิภาพสำหรับการจัดการการจัดรูปแบบที่สอดคล้องกันทั่วทั้งสไลด์ Aspose.Slides ให้การควบคุมเต็มรูปแบบในการสร้าง, จัดการ, และปรับแต่ง layout slides.