---
title: จัดการโน้ตการนำเสนอบน Android
linktitle: โน้ตการนำเสนอ
type: docs
weight: 110
url: /th/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "ปรับแต่งโน้ตการนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java ทำงานกับโน้ต PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์โน้ตจากการนำเสนอ ในหัวข้อนี้ เราจะแนะนำคุณลักษณะนี้ รวมถึงวิธีการลบโน้ตและวิธีการใช้สไตล์ให้กับสไลด์โน้ตในการนำเสนอ Aspose.Slides ให้คุณลบโน้ตจากสไลด์ใดก็ได้และยังสามารถใช้การจัดรูปแบบกับโน้ตที่มีอยู่ได้ นักพัฒนาสามารถลบโน้ตได้ตามวิธีต่อไปนี้:

- ลบโน้ตจากสไลด์เฉพาะในการนำเสนอ
- ลบโน้ตจากสไลด์ทั้งหมดในการนำเสนอ

## **ลบโน้ตจากสไลด์**
โน้ตของสไลด์เฉพาะบางสไลด์สามารถลบได้ตามตัวอย่างด้านล่าง:

```java
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์การนำเสนอ
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // ลบโน้ตของสไลด์แรก
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // บันทึกการนำเสนอไปยังดิสก์
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบโน้ตจากการนำเสนอ**
โน้ตของสไลด์ทั้งหมดในการนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```java
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์การนำเสนอ
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // ลบโน้ตของสไลด์ทั้งหมด
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // บันทึกการนำเสนอไปยังดิสก์
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มสไตล์โน้ต**
[getNotesStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) เมธอดถูกเพิ่มให้กับอินเทอร์เฟซ [IMasterNotesSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMasterNotesSlide) และคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/MasterNotesSlide) ตามลำดับ คุณสมบัตินี้กำหนดสไตล์ของข้อความโน้ต การใช้งานแสดงในตัวอย่างด้านล่าง

```java
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์การนำเสนอ
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // รับสไตล์ข้อความของ MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // ตั้งค่ารูปสัญลักษณ์บูลเล็ตสำหรับย่อหน้าระดับแรก
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**อะไรคือเอนทิตี API ที่ให้เข้าถึงโน้ตของสไลด์เฉพาะ?**

โน้ตจะเข้าถึงผ่านตัวจัดการโน้ตของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notesslidemanager/) และ [method](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) ที่ส่งคืนออบเจ็กต์โน้ต หรือ `null` หากไม่มีโนต

**มีความแตกต่างในการสนับสนุนโน้ตระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีรองรับหรือไม่?**

ไลบรารีมุ่งเป้าไปที่รูปแบบไฟล์ Microsoft PowerPoint ช่วงกว้าง (ตั้งแต่ 97‑newer) และ ODP; โน้ตได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาการติดตั้ง PowerPoint