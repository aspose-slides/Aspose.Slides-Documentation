---
title: เข้าถึงสไลด์การนำเสนอใน PHP
linktitle: เข้าถึงสไลด์
type: docs
weight: 20
url: /th/php-java/access-slide-in-presentation/
keywords:
- เข้าถึงสไลด์
- ดัชนีสไลด์
- ไอดีสไลด์
- ตำแหน่งสไลด์
- เปลี่ยนตำแหน่ง
- คุณสมบัติสไลด์
- หมายเลขสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีเข้าถึงและจัดการสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพิ่มประสิทธิภาพการทำงานด้วยตัวอย่างโค้ด"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีดึงสไลด์ตามดัชนีที่เริ่มจากศูนย์จากคอลเลกชันสไลด์และวิธีเข้าถึงสไลด์โดยใช้ ID ที่เป็นเอกลักษณ์ผ่านเมธอด `getSlideById`  

คุณจะได้เรียนรู้วิธีเปลี่ยนตำแหน่งสไลด์โดยใช้เมธอด `setSlideNumber` และวิธีกำหนดหมายเลขสไลด์เริ่มต้นสำหรับงานนำเสนอด้วยเมธอด `setFirstSlideNumber` ตัวอย่างจะสาธิตการโหลดงานนำเสนอ, การรับอ้างอิงสไลด์, การอัปเดตลำดับหรือหมายเลขสไลด์, และการบันทึกงานนำเสนอที่แก้ไขแล้ว  

## **เข้าถึงสไลด์ด้วยดัชนี**

สไลด์ทั้งหมดในงานนำเสนอจะถูกจัดเรียงเป็นตัวเลขตามตำแหน่งสไลด์โดยเริ่มจาก 0 สไลด์แรกสามารถเข้าถึงได้ผ่านดัชนี 0; สไลด์ที่สองสามารถเข้าถึงได้ผ่านดัชนี 1; เป็นต้น  

คลาส Presentation ซึ่งเป็นตัวแทนไฟล์งานนำเสนอ จะเปิดเผยสไลด์ทั้งหมดเป็นคอลเลกชัน [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) (คอลเลกชันของออบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/)) โค้ด PHP นี้จะแสดงวิธีเข้าถึงสไลด์ผ่านดัชนีของมัน:

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
  $pres = new Presentation("demo.pptx");
  try {
    # เข้าถึงสไลด์โดยใช้ดัชนีสไลด์
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **เข้าถึงสไลด์ด้วย ID**

สไลด์แต่ละสไลด์ในงานนำมี ID ที่เป็นเอกลักษณ์สัมพันธ์กัน คุณสามารถใช้เมธอด [getSlideById](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlideById-long-) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)) เพื่อระบุ ID นั้น โค้ด PHP นี้จะแสดงวิธีการใส่ ID สไลด์ที่ถูกต้องและเข้าถึงสไลด์ผ่านเมธอด [getSlideById](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlideById-long-):

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
  $pres = new Presentation("demo.pptx");
  try {
    # รับไอดีสไลด์
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # เข้าถึงสไลด์ผ่านไอดีของมัน
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **เปลี่ยนตำแหน่งสไลด์**

Aspose.Slides ให้คุณเปลี่ยนตำแหน่งสไลด์ ตัวอย่างเช่น คุณสามารถกำหนดให้สไลด์แรกกลายเป็นสไลด์ที่สอง  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ (ที่ต้องการเปลี่ยนตำแหน่ง) ผ่านดัชนีของมัน  
3. กำหนดตำแหน่งใหม่ให้สไลด์ผ่านเมธอด [setSlideNumber](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#setSlideNumber)  
4. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด PHP นี้สาธิตการปฏิบัติการที่สไลด์ตำแหน่ง 1 ถูกย้ายไปยังตำแหน่ง 2:

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
  $pres = new Presentation("Presentation.pptx");
  try {
    # รับสไลด์ที่ตำแหน่งจะถูกเปลี่ยน
    $sld = $pres->getSlides()->get_Item(0);
    # ตั้งตำแหน่งใหม่ให้สไลด์
    $sld->setSlideNumber(2);
    # บันทึกงานนำเสนอที่แก้ไขแล้ว
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

สไลด์แรกกลายเป็นสไลด์ที่สอง; สไลด์ที่สองกลายเป็นสไลด์แรก เมื่อคุณเปลี่ยนตำแหน่งของสไลด์ สไลด์อื่น ๆ จะปรับอัตโนมัติ  

## **ตั้งหมายเลขสไลด์**

โดยใช้เมธอด [setFirstSlideNumber](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)) คุณสามารถกำหนดหมายเลขใหม่ให้สไลด์แรกในงานนำเสนอ การดำเนินการนี้จะทำให้หมายเลขสไลด์อื่น ๆ ถูกคำนวณใหม่  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับหมายเลขสไลด์  
3. ตั้งหมายเลขสไลด์  
4. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด PHP นี้สาธิตการดำเนินการที่ตั้งหมายเลขสไลด์แรกเป็น 10:

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # รับหมายเลขสไลด์
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # ตั้งหมายเลขสไลด์
    $pres->setFirstSlideNumber(10);
    # บันทึกงานนำเสนอที่แก้ไขแล้ว
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

หากคุณต้องการข้ามสไลด์แรก คุณสามารถเริ่มการนับหมายเลขจากสไลด์ที่สอง (และซ่อนการแสดงหมายเลขสำหรับสไลด์แรก) ได้ดังนี้:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # ตั้งหมายเลขสำหรับสไลด์แรกของงานนำเสนอ
    $presentation->setFirstSlideNumber(0);
    # แสดงหมายเลขสไลด์สำหรับสไลด์ทั้งหมด
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # ซ่อนหมายเลขสไลด์สำหรับสไลด์แรก
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # บันทึกงานนำเสนอที่แก้ไขแล้ว
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**หมายเลขสไลด์ที่ผู้ใช้เห็นตรงกับดัชนีเริ่มจากศูนย์ของคอลเลกชันหรือไม่?**

หมายเลขที่แสดงบนสไลด์สามารถเริ่มจากค่าที่กำหนดเอง (เช่น 10) และไม่จำเป็นต้องตรงกับดัชนี ความสัมพันธ์นี้ถูกควบคุมโดยการตั้งค่า [first slide number](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/setfirstslidenumber/) ของงานนำเสนอ  

**สไลด์ที่ซ่อนอยู่ส่งผลต่อการทำดัชนีหรือไม่?**

ใช่ สไลด์ที่ซ่อนอยู่ยังคงอยู่ในคอลเลกชันและถูกนับในดัชนี; “hidden” หมายถึงการแสดงผล ไม่ได้หมายถึงตำแหน่งในคอลเลกชัน  

**ดัชนีของสไลด์จะเปลี่ยนเมื่อสไลด์อื่นถูกเพิ่มหรือเอาออกหรือไม่?**

ใช่ ดัชนีจะสะท้อนลำดับปัจจุบันของสไลด์เสมอและจะคำนวณใหม่เมื่อทำการแทรก, ลบ หรือย้ายสไลด์  