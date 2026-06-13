---
title: เพิ่มสไลด์ในงานนำเสนอด้วย PHP
linktitle: เพิ่มสไลด์
type: docs
weight: 10
url: /th/php-java/add-slide-to-presentation/
keywords:
- เพิ่มสไลด์
- สร้างสไลด์
- สไลด์เปล่า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่มสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ของคุณได้อย่างง่ายดายโดยใช้ Aspose.Slides for PHP via Java — การแทรกสไลด์ที่ราบรื่นและมีประสิทธิภาพภายในไม่กี่วินาที."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเพิ่มสไลด์ลงในงานนำเสนอ PowerPoint ด้วยโปรแกรม งานนำเสนอประกอบด้วยสไลด์แม่แบบ/เค้าโครงและสไลด์ปกติ และสไลด์ปกติจะถูกจัดเรียงตามดัชนีเริ่มจากศูนย์แต่ละสไลด์มี ID ที่ไม่ซ้ำกัน และไฟล์งานนำเสนอที่ไม่มีสไลด์จะไม่รองรับ

บทความนี้อธิบายวิธีสร้างออบเจ็กต์ `Presentation` เข้าถึงคอลเลกชันสไลด์ เพิ่มสไลด์เปล่า ทำงานกับสไลด์ที่เพิ่มใหม่ และบันทึกงานนำเสนอที่อัปเดต นอกจากนี้ยังครอบคลุมประเด็นที่เกี่ยวข้องเช่น การแทรกสไลด์ในตำแหน่งเฉพาะ การใช้เค้าโครง และการทำความเข้าใจสไลด์เปล่าที่มีอยู่ในงานนำเสนอที่สร้างใหม่

## **เพิ่มสไลด์ลงในงานนำเสนอ**

ก่อนที่จะพูดถึงการเพิ่มสไลด์ลงในไฟล์งานนำเสนอ ให้เราพูดถึงข้อเท็จจริงเกี่ยวกับสไลด์แต่ละไฟล์งานนำเสนอ PowerPoint ประกอบด้วยสไลด์ **Master / Layout** และสไลด์ **Normal** อื่น ๆ หมายความว่าไฟล์งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์หรือมากกว่านั้น สิ่งสำคัญคือต้องทราบว่าไฟล์งานนำเสนอที่ไม่มีสไลด์ไม่ได้รับการสนับสนุนโดย Aspose.Slides for PHP via Java แต่ละสไลด์มี Id ที่ไม่ซ้ำกันและสไลด์ Normal ทั้งหมดถูกจัดเรียงตามดัชนีเริ่มจากศูนย์

Aspose.Slides for PHP via Java ให้ผู้พัฒนาสามารถเพิ่มสไลด์เปล่าไปยังงานนำเสนอของตนได้ เพื่อเพิ่มสไลด์เปล่าในงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
- รับออบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) โดยใช้เมธอด [getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#getSlides--) (คอลเลกชันของออบเจ็กต์ Slide) ที่เปิดเผยโดยออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
- เพิ่มสไลด์เปล่าไปยังงานนำเสนอที่ตำแหน่งท้ายของคอลเลกชันสไลด์เนื้อหาโดยเรียกเมธอด [**addEmptySlide**](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/#addEmptySlide) ที่เปิดเผยโดยออบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/)
- ทำงานบางอย่างกับสไลด์เปล่าที่เพิ่มใหม่
- สุดท้าย เขียนไฟล์งานนำเสนอโดยใช้ออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
  $pres = new Presentation();
  try {
    # สร้างอินสแตนซ์ของคลาส SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # เพิ่มสไลด์เปล่าไปยังคอลเลกชัน Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # ทำงานบางอย่างกับสไลด์ที่เพิ่มใหม่
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแทรกสไลด์ใหม่ในตำแหน่งเฉพาะได้หรือไม่ ไม่ใช่แค่ที่ท้ายรายการ?**

ได้ ไลบรารีรองรับคอลเลกชันสไลด์และการดำเนินการ [insert](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/insertclone/) ดังนั้นคุณสามารถเพิ่มสไลด์ที่ดัชนีที่ต้องการได้ ไม่จำกัดเพียงที่ท้ายรายการ

**ธีม/สไตล์จะถูกเก็บไว้เมื่อเพิ่มสไลด์โดยอิงจากเค้าโครงหรือไม่?**

ใช่ เค้าโครงสืบทอดการจัดรูปแบบจากมาสเตอร์ของมัน และสไลด์ใหม่จะสืบทอดจากเค้าโครงที่เลือกและมาสเตอร์ที่เชื่อมโยงกับเค้าโครงนั้น

**สไลด์ใดที่ปรากฏในงานนำเสนอ "เปล่า" ใหม่ก่อนที่จะเพิ่มสไลด์?**

งานนำเสนอที่สร้างใหม่จะมีสไลด์ว่างหนึ่งสไลด์ที่มีดัชนีศูนย์อยู่แล้ว สิ่งนี้สำคัญเมื่อคำนวณดัชนีการแทรก

**ฉันจะเลือกรูปแบบเค้าโครงที่ "เหมาะสม" สำหรับสไลด์ใหม่ได้อย่างไร หากมาสเตอร์มีตัวเลือกหลายอย่าง?**

โดยทั่วไปให้เลือก [LayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) ที่ตรงกับโครงสร้างที่ต้องการ ([Title and Content, Two Content, ฯลฯ](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidelayouttype/)) หากไม่มีเค้าโครงดังกล่าวคุณสามารถ [add it to the master](/slides/th/php-java/slide-layout/) แล้วใช้ต่อไปได้