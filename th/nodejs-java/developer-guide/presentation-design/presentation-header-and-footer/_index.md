---
title: จัดการส่วนหัวและส่วนท้ายของงานนำเสนอใน JavaScript
linktitle: ส่วนหัว & ส่วนท้าย
type: docs
weight: 140
url: /th/nodejs-java/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งค่าส่วนหัว
- ตั้งค่าส่วนท้าย
- เอกสารประกอบ
- บันทึกย่อ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้ JavaScript และ Aspose.Slides สำหรับ Node.js เพื่อเพิ่มและปรับแต่งส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint และ OpenDocument ให้ดูเป็นมืออาชีพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการการตั้งค่าหัวเรื่องและส่วนท้ายในงานนำเสนอ PowerPoint ได้ หัวเรื่องและส่วนท้ายจะถูกจัดการระดับมาสเตอร์ของงานนำเสนอ และ API มีเมธอดสำหรับตั้งค่าข้อความส่วนท้าย การเปลี่ยนการมองเห็นของส่วนท้าย และอัปเดตข้อความหัวเรื่องบนสไลด์บันทึกย่อมาสเตอร์

คุณยังสามารถจัดการหัวเรื่องและส่วนท้ายสำหรับสไลด์เอกสารประกอบและสไลด์บันทึกย่อได้ ซึ่งรวมถึงการเปลี่ยนการมองเห็นและข้อความของตำแหน่งเก็บหัวเรื่อง ส่วนท้าย หมายเลขสไลด์ และตัวบรรจุวัน‑เวลา สำหรับมาสเตอร์บันทึกย่อ สไลด์บันทึกย่อทั้งหมดที่เป็นลูก หรือสไลด์บันทึกย่อเฉพาะหนึ่งสไลด์

## **จัดการหัวเรื่องและส่วนท้ายในงานนำเสนอ**
บันทึกย่อของสไลด์เฉพาะบางสไลด์อาจถูกลบตามที่แสดงในตัวอย่างด้านล่าง:

```javascript
// โหลดงานนำเสนอ
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // ตั้งค่าส่วนท้าย
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // เข้าถึงและอัปเดตส่วนหัว
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // บันทึกงานนำเสนอ
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **จัดการหัวเรื่องและส่วนท้ายในสไลด์เอกสารประกอบและบันทึกย่อ**
Aspose.Slides สำหรับ Node.js ผ่าน Java รองรับหัวเรื่องและส่วนท้ายในสไลด์เอกสารประกอบและบันทึกย่อ โปรดทำตามขั้นตอนด้านล่าง:

- โหลด [งานนำเสนอ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่มีวิดีโอ.
- เปลี่ยนการตั้งค่าหัวเรื่องและส่วนท้ายสำหรับมาสเตอร์บันทึกย่อและสไลด์บันทึกย่อทั้งหมด.
- ตั้งค่าตำแหน่งเก็บส่วนท้ายของมาสเตอร์บันทึกย่อและลูกทั้งหมดให้มองเห็นได้.
- ตั้งค่าตำแหน่งเก็บวันและเวลาของมาสเตอร์บันทึกย่อและลูกทั้งหมดให้มองเห็นได้.
- เปลี่ยนการตั้งค่าหัวเรื่องและส่วนท้ายสำหรับสไลด์บันทึกย่อแรกเท่านั้น.
- ตั้งค่าตำแหน่งเก็บหัวเรื่องของสไลด์บันทึกย่อให้มองเห็นได้.
- ตั้งค่าข้อความให้กับตำแหน่งเก็บหัวเรื่องของสไลด์บันทึกย่อ.
- ตั้งค่าข้อความให้กับตำแหน่งเก็บวัน‑เวลา ของสไลด์บันทึกย่อ.
- เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างโค้ดสแนปป์มีให้ด้านล่างนี้.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // เปลี่ยนการตั้งค่าหัวเรื่องและส่วนท้ายสำหรับมาสเตอร์บันทึกย่อและสไลด์บันทึกย่อทั้งหมด
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// ทำให้สไลด์บันทึกย่อมาสเตอร์และตำแหน่งเก็บ Footer ลูกทั้งหมดมองเห็นได้
        headerFooterManager.setFooterAndChildFootersVisibility(true);// ทำให้สไลด์บันทึกย่อมาสเตอร์และตำแหน่งเก็บ Header ลูกทั้งหมดมองเห็นได้
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// ทำให้สไลด์บันทึกย่อมาสเตอร์และตำแหน่งเก็บ SlideNumber ลูกทั้งหมดมองเห็นได้
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// ทำให้สไลด์บันทึกย่อมาสเตอร์และตำแหน่งเก็บ Date and time ลูกทั้งหมดมองเห็นได้
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// ตั้งข้อความให้สไลด์บันทึกย่อมาสเตอร์และตำแหน่งเก็บ Header ลูกทั้งหมด
        headerFooterManager.setFooterAndChildFootersText("Footer text");// ตั้งข้อความให้สไลด์บันทึกย่อมาสเตอร์และตำแหน่งเก็บ Footer ลูกทั้งหมด
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// ตั้งข้อความให้สไลด์บันทึกย่อมาสเตอร์และตำแหน่งเก็บ Date and time ลูกทั้งหมด
    }
    // เปลี่ยนการตั้งค่าหัวเรื่องและส่วนท้ายสำหรับสไลด์บันทึกย่อแรกเท่านั้น
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// ทำให้ตำแหน่งเก็บ Header ของสไลด์บันทึกย่อนี้มองเห็นได้
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// ทำให้ตำแหน่งเก็บ Footer ของสไลด์บันทึกย่อนี้มองเห็นได้
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// ทำให้ตำแหน่งเก็บ SlideNumber ของสไลด์บันทึกย่อนี้มองเห็นได้
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// ทำให้ตำแหน่งเก็บ Date-time ของสไลด์บันทึกย่อนี้มองเห็นได้
        headerFooterManager.setHeaderText("New header text");// ตั้งข้อความให้ตำแหน่งเก็บ Header ของสไลด์บันทึกย่อ
        headerFooterManager.setFooterText("New footer text");// ตั้งข้อความให้ตำแหน่งเก็บ Footer ของสไลด์บันทึกย่อ
        headerFooterManager.setDateTimeText("New date and time text");// ตั้งข้อความให้ตำแหน่งเก็บ Date-time ของสไลด์บันทึกย่อ
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่ม "หัวเรื่อง" ให้กับสไลด์ปกติได้หรือไม่?**

ใน PowerPoint, "Header" มีเฉพาะสำหรับบันทึกย่อและเอกสารประกอบเท่านั้น; บนสไลด์ปกติ มีเพียงส่วนท้าย, วัน‑เวลา, และหมายเลขสไลด์ที่รองรับ. ใน Aspose.Slides มีข้อจำกัดเช่นเดียวกัน: หัวเรื่องใช้ได้เฉพาะกับบันทึกย่อ/เอกสารประกอบ, และบนสไลด์—ส่วนท้าย/วัน‑เวลา/หมายเลขสไลด์.

**ถ้าเค้าโครงไม่มีพื้นที่ส่วนท้าย—ฉันสามารถ "เปิด" การมองเห็นได้หรือไม่?**

ได้. ตรวจสอบการมองเห็นผ่านตัวจัดการหัวเรื่อง/ส่วนท้ายและเปิดใช้งานหากจำเป็น. ตัวชี้วัดและเมธอดของ API นี้ออกแบบมาสำหรับกรณีที่ตำแหน่งเก็บหายไปหรือถูกซ่อน.

**ฉันจะทำให้หมายเลขสไลด์เริ่มจากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

ตั้งค่าหมายเลขสไลด์แรกของงานนำเสนอด้วย [หมายเลขสไลด์แรก](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/setfirstslidenumber/); หลังจากนั้น การนับหมายเลขทั้งหมดจะถูกคำนวณใหม่. ตัวอย่างเช่น คุณสามารถเริ่มที่ 0 หรือ 10 และซ่อนหมายเลขบนสไลด์หัวเรื่อง.

**หัวเรื่อง/ส่วนท้ายจะเกิดอะไรขึ้นเมื่อส่งออกเป็น PDF/รูปภาพ/HTML?**

พวกมันจะถูกเรนเดอร์เป็นองค์ประกอบข้อความปกติของงานนำเสนอ. กล่าวคือ หากองค์ประกอบเหล่านั้นมองเห็นได้บนสไลด์/หน้าบันทึกย่อ พวกมันก็จะแสดงในรูปแบบผลลัพธ์พร้อมกับเนื้อหาอื่น ๆ.