---
title: จัดการบันทึกย่อการนำเสนอใน JavaScript
linktitle: บันทึกย่อการนำเสนอ
type: docs
weight: 110
url: /th/nodejs-java/presentation-notes/
keywords:
- บันทึกย่อ
- สไลด์บันทึกย่อ
- เพิ่มบันทึกย่อ
- ลบบันทึกย่อ
- สไตล์บันทึกย่อ
- บันทึกย่อหลัก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับแต่งบันทึกย่อการนำเสนอใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ทำงานกับบันทึกย่อ PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์บันทึกย่อจากการนำเสนอ ในหัวข้อนี้ เราจะอธิบายคุณลักษณะนี้ รวมถึงวิธีลบบันทึกย่อและวิธีใช้สไตล์กับสไลด์บันทึกย่อในการนำเสนอ Aspose.Slides ให้คุณสามารถลบบันทึกย่อจากสไลด์ใดก็ได้และยังสามารถใช้การจัดรูปแบบกับบันทึกย่อที่มีอยู่ได้ นักพัฒนาสามารถลบบันทึกย่อได้ตามวิธีต่อไปนี้:

- ลบบันทึกย่อจากสไลด์เฉพาะในการนำเสนอ
- ลบบันทึกย่อจากสไลด์ทั้งหมดในการนำเสนอ

หากต้องการอ่านหรือเปลี่ยนขนาดหน้าบันทึกย่อ สลับการวางแนว และตรวจสอบพฤติกรรมการส่งออก ให้ดูที่ [ขนาดหน้าบันทึกย่อ](/slides/th/nodejs-java/notes-size/).

## **ลบบันทึกย่อจากสไลด์**
บันทึกย่อจากสไลด์เฉพาะสามารถลบได้ตามตัวอย่างด้านล่าง:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // กำลังลบบันทึกย่อของสไลด์แรก
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // กำลังบันทึกการนำเสนอลงดิสก์
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบบันทึกย่อจากการนำเสนอ**
บันทึกย่อจากสไลด์ทั้งหมดในการนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // กำลังลบบันทึกย่อของสไลด์ทั้งหมด
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // กำลังบันทึกการนำเสนอลงดิสก์
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เพิ่ม NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) เมธอดได้ถูกเพิ่มเข้าไปในคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterNotesSlide) และคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterNotesSlide) ตามลำดับ คุณสมบัตินี้ระบุสไตล์ของข้อความบันทึกย่อ การนำไปใช้แสดงในตัวอย่างด้านล่าง
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // รับสไตล์ข้อความของ MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // ตั้งค่ารูปแบบ bullet แบบสัญลักษณ์สำหรับย่อหน้าในระดับแรก
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**องค์ประกอบ API ใดที่ให้การเข้าถึงบันทึกย่อของสไลด์เฉพาะ?**

บันทึกย่อเข้าถึงได้ผ่านตัวจัดการบันทึกย่อของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notesslidemanager/) และ [method](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) ที่คืนค่าออบเจกต์บันทึกย่อ หรือ `null` หากไม่มีบันทึกย่อ

**มีความแตกต่างในการสนับสนุนบันทึกย่อในเวอร์ชัน PowerPoint ที่ไลบรารีทำงานด้วยหรือไม่?**

ไลบรารีนี้มุ่งเป้าไปที่รูปแบบ Microsoft PowerPoint ช่วงกว้าง (ตั้งแต่ 97‑จนถึงล่าสุด) และ ODP; บันทึกย่อได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาการติดตั้ง PowerPoint