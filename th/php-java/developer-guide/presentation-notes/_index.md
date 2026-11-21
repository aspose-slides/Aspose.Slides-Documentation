---
title: จัดการบันทึกการนำเสนอใน PHP
linktitle: บันทึกการนำเสนอ
type: docs
weight: 110
url: /th/php-java/presentation-notes/
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
- PHP
- Aspose.Slides
description: "ปรับแต่งบันทึกการนำเสนอด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ทำงานร่วมกับบันทึก PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **ภาพรวม**

Aspose.Slides รองรับการลบสไลด์บันทึกจากงานนำเสนอ ในหัวข้อนี้ เราจะอธิบายฟีเจอร์นี้ รวมถึงวิธีการลบบันทึกและวิธีการใช้สไตล์กับสไลด์บันทึกในงานนำเสนอ Aspose.Slides ช่วยให้คุณลบบันทึกจากสไลด์ใดก็ได้และยังสามารถปรับสไตล์ให้กับบันทึกที่มีอยู่ได้ นักพัฒนาสามารถลบบันทึกได้ตามวิธีต่อไปนี้:

- ลบบันทึกจากสไลด์เฉพาะในงานนำเสนอ
- ลบบันทึกจากสไลด์ทั้งหมดในงานนำเสนอ

หากต้องการอ่านหรือเปลี่ยนขนาดหน้าบันทึก, สลับทิศทาง, และตรวจสอบพฤติกรรมการส่งออก ดูที่ [ขนาดหน้าบันทึก](/slides/th/php-java/notes-size/).

## **ลบบันทึกจากสไลด์**

บันทึกจากสไลด์เฉพาะสามารถลบได้ตามตัวอย่างด้านล่าง:

```php
  # สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์การนำเสนอ
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # ลบบันทึกของสไลด์แรก
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบบันทึกจากงานนำเสนอ**

บันทึกจากสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์การนำเสนอ
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # ลบบันทึกของสไลด์ทั้งหมด
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มสไตล์ให้บันทึก**

เมธอด [getNotesStyle](https://reference.aspose.com/slides/th/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) ของคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/MasterNotesSlide) ให้การเข้าถึงสไตล์ข้อความบันทึก การทำงานแสดงในตัวอย่างด้านล่าง.

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์การนำเสนอ
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # ดึงสไตล์ข้อความของ MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # ตั้งสัญลักษณ์ bullet สำหรับย่อหน้าในระดับแรก
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**คำนำ API ใดที่ให้การเข้าถึงบันทึกของสไลด์เฉพาะ?**

บันทึกถูกเข้าถึงผ่านผู้จัดการบันทึกของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/notesslidemanager/) และ [เมธอด](https://reference.aspose.com/slides/th/php-java/aspose.slides/notesslidemanager/getnotesslide/) ที่คืนค่าอ็อบเจ็กต์บันทึก, หรือ `null` หากไม่มีบันทึก

**มีความแตกต่างในการสนับสนุนบันทึกระหว่างเวอร์ชัน PowerPoint ที่ไลบรารีทำงานกับหรือไม่?**

ไลบรารีรองรับรูปแบบ Microsoft PowerPoint อย่างกว้างขวาง (รุ่น 97–newer) และ ODP; บันทึกได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องพึ่งพาติดตั้ง PowerPoint