---
title: จัดการโน้ตการนำเสนอใน JavaScript
linktitle: โน้ตการนำเสนอ
type: docs
weight: 110
url: /th/nodejs-java/presentation-notes/
keywords:
- โน้ต
- สไลด์โน้ต
- เพิ่มโน้ต
- ลบโน้ต
- สไตล์โน้ต
- โน้ตหลัก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับแต่งโน้ตการนำเสนอใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ทำงานกับโน้ต PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ"
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์โน้ตออกจากงานนำเสนอ ในหัวข้อนี้เราจะอธิบายคุณลักษณะนี้ รวมถึงวิธีการลบโน้ตและวิธีการใช้สไตล์กับสไลด์โน้ตในงานนำเสนอ Aspose.Slides ให้คุณสามารถลบโน้ตจากสไลด์ใดก็ได้และยังสามารถนำสไตล์ไปใช้กับโน้ตที่มีอยู่ได้ นักพัฒนาสามารถลบโน้ตได้โดยวิธีต่อไปนี้:

- ลบโน้ตจากสไลด์เฉพาะในงานนำเสนอ
- ลบโน้ตจากทุกสไลด์ในงานนำเสนอ

## **ลบโน้ตจากสไลด์**
โน้ตของสไลด์ที่ระบุสามารถลบได้ตามตัวอย่างด้านล่าง:

```javascript
// สร้างวัตถุ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // ลบโน้ตของสไลด์แรก
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // บันทึกการนำเสนอลงดิสก์
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบโน้ตจากงานนำเสนอ**
โน้ตของทุกสไลด์ในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```javascript
// สร้างวัตถุ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // ลบโน้ตของสไลด์ทั้งหมด
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // บันทึกการนำเสนอลงดิสก์
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เพิ่ม NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) เมธอดได้ถูกเพิ่มเข้าไปในคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterNotesSlide) และคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterNotesSlide) ตามลำดับ คุณสมบัตินี้ระบุสไตล์ของข้อความโน้ต การทำงานจะถูกแสดงในตัวอย่างด้านล่าง

```javascript
// สร้างวัตถุ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // รับสไตล์ข้อความของ MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // ตั้งค่ารูปสัญลักษณ์ bullet สำหรับย่อหน้าในระดับแรก
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**API entity ใดที่ให้การเข้าถึงโน้ตของสไลด์เฉพาะ?**

โน้ตจะถูกเข้าถึงผ่านตัวจัดการโน้ตของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notesslidemanager/) และ [method](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) ที่ส่งคืนอ็อบเจ็กต์โน้ต หรือ `null` หากไม่มีโน้ต

**มีความแตกต่างในการสนับสนุนโน้ตระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีรองรับหรือไม่?**

ไลบรารีนี้รองรับรูปแบบ Microsoft PowerPoint ช่วงกว้าง (ตั้งแต่เวอร์ชัน 97 จนถึงใหม่กว่า) และ ODP; โน้ตได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพากลุ่ม PowerPoint ที่ติดตั้งไว้