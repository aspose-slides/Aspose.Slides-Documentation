---
title: จัดการส่วนสไลด์ในงานนำเสนอด้วย PHP
linktitle: ส่วนสไลด์
type: docs
weight: 90
url: /th/php-java/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ทำให้การจัดการส่วนสไลด์ใน PowerPoint และ OpenDocument มีประสิทธิภาพด้วย Aspose.Slides for PHP via Java — แบ่ง, เปลี่ยนชื่อ, และจัดลำดับใหม่เพื่อเพิ่มประสิทธิภาพการทำงานของ PPTX และ ODP"
---
## **บทนำ**

ด้วย Aspose.Slides for PHP ผ่าน Java คุณสามารถจัดระเบียบ PowerPoint Presentation เป็นส่วนต่าง ๆ คุณสามารถสร้างส่วนที่บรรจุสไลด์เฉพาะได้

คุณอาจต้องการสร้างส่วนและใช้มันเพื่อจัดระเบียบหรือแบ่งสไลด์ในงานนำเสนอเป็นส่วนที่มีเหตุผลในสถานการณ์ต่อไปนี้:

- เมื่อคุณกำลังทำงานบนการนำเสนอขนาดใหญ่กับคนอื่นหรือทีม — และคุณต้องการมอบหมายสไลด์บางส่วนให้กับเพื่อนร่วมงานหรือสมาชิกในทีม
- เมื่อคุณต้องจัดการกับการนำเสนอที่มีสไลด์หลายจำนวน — และคุณกำลังประสบปัญหาในการจัดการหรือแก้ไขเนื้อหาในครั้งเดียว

โดยทั่วไป คุณควรสร้างส่วนที่เก็บสไลด์ที่คล้ายกัน — สไลด์เหล่านี้มีคุณสมบัติร่วมกันหรือสามารถอยู่ในกลุ่มตามกฎ — และตั้งชื่อส่วนให้สื่อถึงสไลด์ภายใน

## **สร้างส่วนในงานนำเสนอ**

เพื่อเพิ่มส่วนที่บรรจุสไลด์ในงานนำเสนอ Aspose.Slides for PHP ผ่าน Java มีเมธอด [addSection()](https://reference.aspose.com/slides/th/php-java/aspose.slides/sectioncollection/#addSection) ที่ช่วยให้คุณระบุชื่อของส่วนที่ต้องการสร้างและสไลด์ที่ส่วนเริ่มต้นจาก

โค้ดตัวอย่างนี้แสดงวิธีสร้างส่วนในงานนำเสนอ :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 จะสิ้นสุดที่ newSlide2 และหลังจากนั้น section2 จะเริ่มต้น

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เปลี่ยนชื่อส่วน**

หลังจากที่คุณสร้างส่วนใน PowerPoint presentation แล้ว คุณอาจต้องการเปลี่ยนชื่อของมัน

โค้ดตัวอย่างนี้แสดงวิธีการเปลี่ยนชื่อของส่วนในงานนำเสนอโดยใช้ Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ส่วนจะถูกเก็บไว้เมื่อบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

ไม่. รูปแบบ PPT ไม่รองรับเมตาดาต้าของส่วน ดังนั้นการจัดกลุ่มส่วนจะหายไปเมื่อบันทึกเป็น .ppt

**ส่วนทั้งหมดสามารถซ่อนได้หรือไม่?**

ไม่. สามารถซ่อนได้เฉพาะสไลด์แต่ละอันเท่านั้น ส่วนในฐานะเอนทิตีไม่มีสถานะ "hidden"

**ฉันสามารถค้นหาส่วนโดยอิงจากสไลด์ได้อย่างรวดเร็วและในทางกลับกันค้นหาสไลด์แรกของส่วนได้หรือไม่?**

ได้. ส่วนจะถูกกำหนดโดยสไลด์เริ่มต้นของมันอย่างเอกลักษณ์; เมื่อรู้สไลด์คุณสามารถระบุได้ว่ามันอยู่ในส่วนใด และสำหรับส่วนคุณสามารถเข้าถึงสไลด์แรกของมันได้