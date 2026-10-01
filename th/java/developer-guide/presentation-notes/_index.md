---
title: จัดการโน้ตการนำเสนอใน Java
linktitle: โน้ตการนำเสนอ
type: docs
weight: 110
url: /th/java/presentation-notes/
keywords:
- โน้ต
- สไลด์โน้ต
- เพิ่มโนต
- ลบโนต
- สไตล์โนต
- โนตหลัก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ปรับแต่งโน้ตการนำเสนอด้วย Aspose.Slides สำหรับ Java ทำงานอย่างราบรื่นกับโน้ต PowerPoint และ OpenDocument เพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์โน้ตจากการนำเสนอ ในหัวข้อนี้ เราจะอธิบายคุณลักษณะนี้รวมถึงวิธีการลบโน้ตและวิธีการใช้สไตล์กับสไลด์โน้ตในการนำเสนอ Aspose.Slides ให้คุณลบโน้ตจากสไลด์ใด ๆ และยังสามารถใช้การจัดรูปแบบกับโน้ตที่มีอยู่ได้ นักพัฒนาสามารถลบโน้ตได้ตามวิธีต่อไปนี้:

- ลบโน้ตจากสไลด์เฉพาะในการนำเสนอ
- ลบโน้ตจากสไลด์ทั้งหมดในการนำเสนอ

เพื่ออ่านหรือเปลี่ยนขนาดหน้ากระดาษโน้ต, สลับการวางแนว, และตรวจสอบพฤติกรรมการส่งออก, ดูที่ [ขนาดหน้าข้อความโน้ต](/slides/th/java/notes-size/).

## **ลบโน้ตจากสไลด์**
โน้ตจากสไลด์เฉพาะสามารถลบได้ตามตัวอย่างด้านล่าง:

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // ลบโน้ตของสไลด์แรก
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // บันทึกการนำเสนอลงดิสก์
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบโน้ตจากการนำเสนอ**
โน้ตจากสไลด์ทั้งหมดในการนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // ลบโน้ตของสไลด์ทั้งหมด
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // บันทึกการนำเสนอลงดิสก์
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มสไตล์โน้ต**
เมธอด [getNotesStyle](https://reference.aspose.com/slides/th/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) ถูกเพิ่มในอินเตอร์เฟซ [IMasterNotesSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/IMasterNotesSlide) และคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/MasterNotesSlide) ตามลำดับ คุณสมบัตินี้ระบุสไตล์ของข้อความโน้ต การใช้งานจะแสดงในตัวอย่างด้านล่าง

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // รับสไตล์ข้อความ MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //ตั้งสัญลักษณ์บูลเล็ตสำหรับย่อหน้าในระดับแรก
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**API entity ใดให้การเข้าถึงโน้ตของสไลด์เฉพาะ?**

โน้ตเข้าถึงผ่านผู้จัดการโน้ตของสไลด์: สไלด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/notesslidemanager/) และเมธอด [getNotesSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) ที่ส่งคืนอ็อบเจกต์โน้ต, หรือ `null` หากไม่มีโน้ต

**มีความแตกต่างในการสนับสนุนโน้ตระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานกับหรือไม่?**

ไลบรารีรองรับรูปแบบ Microsoft PowerPoint ช่วงกว้าง (97–ใหม่กว่า) และ ODP; โน้ตได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาการติดตั้ง PowerPoint.