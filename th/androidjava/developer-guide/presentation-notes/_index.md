---
title: จัดการบันทึกการนำเสนอบน Android
linktitle: บันทึกการนำเสนอ
type: docs
weight: 110
url: /th/androidjava/presentation-notes/
keywords:
- บันทึก
- สไลด์บันทึก
- เพิ่มบันทึก
- ลบบันทึก
- สไตล์บันทึก
- บันทึกหลัก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ปรับแต่งบันทึกการนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java ทำงานกับบันทึก PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ"
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์บันทึกจากงานนำเสนอ ในหัวข้อนี้ เราจะอธิบายคุณสมบัตินี้ รวมถึงวิธีการลบบันทึกและวิธีการใช้สไตล์กับสไลด์บันทึกในงานนำเสนอ Aspose.Slides ให้คุณสามารถลบบันทึกจากสไลด์ใดก็ได้และยังสามารถใช้การจัดรูปแบบกับบันทึกที่มีอยู่ได้ นักพัฒนาสามารถลบบันทึกได้ตามวิธีต่อไปนี้:

- ลบบันทึกจากสไลด์เฉพาะในงานนำเสนอ
- ลบบันทึกจากสไลด์ทั้งหมดในงานนำเสนอ

เพื่ออ่านหรือเปลี่ยนขนาดหน้าบันทึก, สลับทิศทาง, และตรวจสอบพฤติกรรมการส่งออก ดูที่ [ขนาดหน้าโน้ต](/slides/th/androidjava/notes-size/).

## **ลบบันทึกจากสไลด์**
บันทึกจากสไลด์เฉพาะสามารถลบได้ตามตัวอย่างด้านล่าง:

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์การนำเสนอ
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // ลบบันทึกของสไลด์แรก
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // บันทึกการนำเสนอลงดิสก์
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบบันทึกจากงานนำเสนอ**
บันทึกจากสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์การนำเสนอ
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // ลบบันทึกของสไลด์ทั้งหมด
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

## **เพิ่มสไตล์บันทึก**
[getNotesStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) เมธอดได้รับการเพิ่มในอินเตอร์เฟซ [IMasterNotesSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMasterNotesSlide) และคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/MasterNotesSlide) ตามลำดับ คุณสมบัตินี้ระบุสไตล์ของข้อความบันทึก การทำงานถูกแสดงในตัวอย่างด้านล่าง.

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์การนำเสนอ
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // รับสไตล์ข้อความของ MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //ตั้งสัญลักษณ์ bullet สำหรับย่อหน้าระดับแรก
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**คำนิยาม API ใดที่ให้การเข้าถึงบันทึกของสไลด์เฉพาะ?**

บันทึกเข้าถึงได้ผ่านตัวจัดการบันทึกของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notesslidemanager/) และ [method](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) ที่คืนค่าอ็อบเจกต์บันทึก หรือ `null` หากไม่มีบันทึก

**มีความแตกต่างในการสนับสนุนบันทึกระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานหรือไม่?**

ไลบรารีนี้รองรับรูปแบบ Microsoft PowerPoint ที่หลากหลาย (97‑ใหม่กว่า) และ ODP; บันทึกได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาการติดตั้ง PowerPoint