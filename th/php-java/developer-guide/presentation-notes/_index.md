---
title: จัดการโน้ตงานนำเสนอใน PHP
linktitle: โน้ตงานนำเสนอ
type: docs
weight: 110
url: /th/php-java/presentation-notes/
keywords:
- โน้ต
- สไลด์โน้ต
- เพิ่มโน้ต
- ลบโน้ต
- สไตล์โน้ต
- มาสเตอร์โน้ต
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ปรับแต่งโน้ตของงานนำเสนอด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ทำงานกับโน้ตของ PowerPoint และ OpenDocument อย่างราบรื่นเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **Overview**

Aspose.Slides รองรับการลบสไลด์โน้ตออกจากงานนำเสนอ ในหัวข้อนี้ เราจะอธิบายคุณลักษณะนี้ รวมถึงวิธีการลบโน้ตและวิธีการนำสไตล์ไปใช้กับสไลด์โน้ตในงานนำเสนอ Aspose.Slides ช่วยให้คุณสามารถลบโน้ตจากสไลด์ใดก็ได้และยังสามารถใช้การตกแต่งกับโน้ตที่มีอยู่ นักพัฒนาสามารถลบโน้ตได้ตามวิธีต่อไปนี้:

- ลบโน้ตจากสไลด์เฉพาะในงานนำเสนอ
- ลบโน้ตจากสไลด์ทั้งหมดในงานนำเสนอ

## **Remove Notes from a Slide**
โน้ตของสไลด์ที่ระบุสามารถลบได้ตามตัวอย่างด้านล่าง:

```php
  # สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # ลบโน้ตของสไลด์แรก
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # บันทึกงานนำเสนอลงดิสก์
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remove Notes from a Presentation**
โน้ตของสไลด์ทั้งหมดในงานนำเสนอสามารถลบได้ตามตัวอย่างด้านล่าง:

```php
  # สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # ลบโน้ตของสไลด์ทั้งหมด
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # บันทึกงานนำเสนอลงดิสก์
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add a Notes Style**
[getNotesStyle](https://reference.aspose.com/slides/th/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) เมธอดได้ถูกเพิ่มลงในคลาส [MasterNotesSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/MasterNotesSlide) ตามลำดับ คุณสมบัตินี้ระบุสไตล์ของข้อความโน้ต การใช้งานได้แสดงในตัวอย่างด้านล่าง

```php
  # สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # รับสไตล์ข้อความของ MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # ตั้งค่า bullet แบบสัญลักษณ์สำหรับย่อหน้าระดับแรก
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

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

โน้ตถูกเข้าถึงผ่านตัวจัดการโน้ตของสไลด์: สไลด์มี [NotesSlideManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/notesslidemanager/) และ [method](https://reference.aspose.com/slides/th/php-java/aspose.slides/notesslidemanager/getnotesslide/) ที่ส่งคืนอ็อบเจกต์โน้ต หรือ `null` หากไม่มีโน้ต

**Are there differences in notes support across the PowerPoint versions the library works with?**

ไลบรารีรองรับรูปแบบ Microsoft PowerPoint ช่วงกว้าง (ตั้งแต่รุ่น 97 จนถึงรุ่นใหม่) และ ODP; โน้ตได้รับการสนับสนุนในรูปแบบเหล่านี้โดยไม่ต้องอิงกับการติดตั้ง PowerPoint