---
title: ลบสไลด์จากงานนำเสนอใน PHP
linktitle: ลบสไลด์
type: docs
weight: 30
url: /th/php-java/remove-slide-from-presentation/
keywords:
- ลบสไลด์
- ลบสไลด์
- ลบสไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ลบสไลด์จากการนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ PHP ผ่าน Java รับตัวอย่างโค้ดที่ชัดเจนและเพิ่มประสิทธิภาพการทำงานของคุณ"
---
## **บทนำ**

หากสไลด์ (หรือเนื้อหาภายใน) ซ้ำซ้อน คุณสามารถลบออกได้ Aspose.Slides มีคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่รวม [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) ซึ่งเป็นคลังสำหรับสไลด์ทั้งหมดในงานนำเสนอ โดยใช้ตัวชี้ (อ้างอิงหรือ Index) ของอ็อบเจกต์ [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) ที่ระบุ คุณสามารถระบุสไลด์ที่ต้องการลบได้

## **ลบสไลด์ด้วยการอ้างอิง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับการอ้างอิงของสไลด์ที่ต้องการลบผ่าน ID หรือ Index ของมัน  
1. ลบสไลด์ที่อ้างอิงออกจากงานนำเสนอ  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

```php
  # สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
  $pres = new Presentation("demo.pptx");
  try {
    # เข้าถึงสไลด์ผ่านดัชนีในคอลเลกชันสไลด์
    $slide = $pres->getSlides()->get_Item(0);
    # ลบสไลด์ผ่านการอ้างอิงของมัน
    $pres->getSlides()->remove($slide);
    # บันทึกงานนำเสนอที่แก้ไขแล้ว
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **ลบสไลด์ด้วยดัชนี**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. ลบสไลด์ออกจากงานนำเสนอโดยใช้ตำแหน่งดัชนีของมัน  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

```php
  # สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
  $pres = new Presentation("demo.pptx");
  try {
    # ลบสไลด์ผ่านดัชนีสไลด์ของมัน
    $pres->getSlides()->removeAt(0);
    # บันทึกงานนำเสนอที่แก้ไขแล้ว
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (จากคลาส [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/)) เพื่อให้คุณลบสไลด์เค้าโครงที่ไม่ได้ต้องการและไม่ได้ใช้ได้ โค้ด PHP นี้แสดงวิธีลบสไลด์เค้าโครงจากการนำเสนอ PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedMasterSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (จากคลาส [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/)) เพื่อให้คุณลบสไลด์มาสเตอร์ที่ไม่ได้ต้องการและไม่ได้ใช้ได้ โค้ด PHP นี้แสดงวิธีลบสไลด์มาสเตอร์จากการนำเสนอ PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**อะไรเกิดขึ้นกับดัชนีสไลด์หลังจากที่ฉันลบสไลด์?**  
หลังจากลบแล้ว [collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) จะทำการจัดดัชนีใหม่: สไลด์ทุกสไลด์ที่ตามมาจะเลื่อนตำแหน่งไปหนึ่งตำแหน่ง ดังนั้นหมายเลขดัชนีก่อนหน้าจะล้าสมัย หากคุณต้องการอ้างอิงที่คงที่ ให้ใช้ ID คงที่ของแต่ละสไลด์แทนดัชนี

**ID ของสไลด์ต่างจากดัชนีหรือไม่ และจะเปลี่ยนเมื่อสไลด์ใกล้เคียงถูกลบหรือไม่?**  
ใช่ ดัชนีเป็นตำแหน่งของสไลด์และจะเปลี่ยนเมื่อมีการเพิ่มหรือลบสไลด์ ส่วน ID ของสไลด์เป็นตัวระบุคงที่และจะไม่เปลี่ยนเมื่อสไลด์อื่นถูกลบ

**การลบสไลด์ส่งผลต่อส่วนของสไลด์อย่างไร?**  
หากสไลด์เป็นส่วนหนึ่งของ Section Section นั้นจะมีสไลด์น้อยลงหนึ่งสไลด์ โครงสร้างของ Section ยังคงอยู่; หาก Section กลายเป็นว่างเปล่า คุณสามารถ [remove or reorganize sections](/slides/th/php-java/slide-section/) ได้ตามต้องการ

**อะไรเกิดขึ้นกับโน๊ตและความคิดเห็นที่แนบกับสไลด์เมื่อมันถูกลบ?**  
[Notes](/slides/th/php-java/presentation-notes/) และ [comments](/slides/th/php-java/presentation-comments/) เชื่อมโยงกับสไลด์นั้นโดยเฉพาะและจะถูกลบพร้อมกับสไลด์ เนื้อหาในสไลด์อื่นไม่ได้รับผลกระทบ

**การลบสไลด์ต่างจากการทำความสะอาดเค้าโครง/มาสเตอร์ที่ไม่ได้ใช้อย่างไร?**  
การลบจะเอาสไลด์ปกติที่ระบุออกจากชุดสไลด์ การทำความสะอาดเค้าโครง/มาสเตอร์ที่ไม่ได้ใช้จะลบสไลด์เค้าโครงหรือมาสเตอร์ที่ไม่มีใครอ้างอิง เพื่อลดขนาดไฟล์โดยไม่เปลี่ยนแปลงเนื้อหาสไลด์ที่เหลือ การกระทำเหล่านี้ทำงานร่วมกันโดยทั่วไปให้ลบสไลด์ก่อน แล้วจึงทำความสะอาดต่อไป  