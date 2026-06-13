---
title: รวมงานนำเสนออย่างมีประสิทธิภาพใน PHP
linktitle: รวมงานนำเสนอ
type: docs
weight: 40
url: /th/php-java/merge-presentation/
keywords:
- รวม PowerPoint
- รวมงานนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- ผสาน PowerPoint
- ผสานงานนำเสนอ
- ผสานสไลด์
- ผสาน PPT
- ผสาน PPTX
- ผสาน ODP
- PHP
- Aspose.Slides
description: "ผสานงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) อย่างง่ายดายด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ช่วยให้กระบวนการทำงานของคุณเป็นระบบมากขึ้น"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณรวมงานนำเสนอโดยการคัดลอกสไลด์จากงานนำเสนอหนึ่งไปยังอีกงานหนึ่ง บทความนี้อธิบายวิธีการรวมงานนำเสนอทั้งหมดหรือสไลด์ที่เลือก ใช้สไลด์มาสเตอร์หรือเค้าโครงเฉพาะระหว่างการรวม จัดการงานนำเสนอที่มีขนาดสไลด์แตกต่างกัน และเพิ่มสไลด์ที่รวมแล้วไปยังส่วนของงานนำเสนอ นอกจากนี้ยังครอบคลุมบันทึกสำคัญที่เกี่ยวกับเนื้อหาที่รวม เช่น โน้ตผู้พูด ความคิดเห็น ไฟล์ต้นแบบที่มีการป้องกันด้วยรหัสผ่าน และการใช้เธรด

## **การรวมงานนำเสนอ**

เมื่อคุณรวมงานนำเสนอหนึ่งเข้ากับอีกงานหนึ่ง คุณกำลังผสานสไลด์ของพวกมันเข้าไว้ในงานนำเสนอเดียวเพื่อให้ได้ไฟล์หนึ่งไฟล์

{{% alert title="Info" color="info" %}}

โปรแกรมงานนำเสนอส่วนใหญ่ (PowerPoint หรือ OpenOffice) ขาดฟังก์ชันที่อนุญาตให้ผู้ใช้รวมงานนำเสนอในลักษณะดังกล่าว

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/th/php-java/), แต่ Aspose.Slides for PHP via Java ให้คุณรวมงานนำเสนอในรูปแบบต่าง ๆ คุณสามารถรวมงานนำเสนอพร้อมกับรูปทรง สไตล์ ข้อความ การจัดรูปแบบ ความคิดเห็น แอนิเมชัน ฯลฯ โดยไม่ต้องกังวลเรื่องการสูญเสียคุณภาพหรือข้อมูล

**ดูเพิ่มเติม**

[คัดลอกสไลด์](/slides/th/php-java/clone-slides/)

{{% /alert %}}

### **สิ่งที่สามารถรวมได้**

With Aspose.Slides, you can merge 

* งานนำเสนอทั้งหมด สไลด์ทั้งหมดจากงานนำเสนอจะถูกรวมเป็นงานนำเสนอเดียว
* สไลด์เฉพาะ สไลด์ที่เลือกจะถูกรวมเป็นงานนำเสนอเดียว
* งานนำเสนอในรูปแบบเดียวกัน (เช่น PPT ไป PPT, PPTX ไป PPTX ฯลฯ) และในรูปแบบต่างกัน (เช่น PPT ไป PPTX, PPTX ไป ODP ฯลฯ) ไปยังกันและกัน. 

{{% alert title="Note" color="warning" %}} 

นอกจากงานนำเสนอแล้ว Aspose.Slides ยังอนุญาตให้คุณรวมไฟล์อื่น ๆ:

* [รูปภาพ](https://products.aspose.com/slides/th/php-java/merger/image-to-image/), เช่น [JPG ไป JPG](https://products.aspose.com/slides/th/php-java/merger/jpg-to-jpg/) หรือ [PNG ไป PNG](https://products.aspose.com/slides/th/php-java/merger/png-to-png/)
* เอกสาร เช่น [PDF ไป PDF](https://products.aspose.com/slides/th/php-java/merger/pdf-to-pdf/) หรือ [HTML ไป HTML](https://products.aspose.com/slides/th/php-java/merger/html-to-html/)
* และไฟล์ที่แตกต่างสองประเภท เช่น [รูปภาพไป PDF](https://products.aspose.com/slides/th/php-java/merger/image-to-pdf/) หรือ [JPG ไป PDF](https://products.aspose.com/slides/th/php-java/merger/jpg-to-pdf/) หรือ [TIFF ไป PDF](https://products.aspose.com/slides/th/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **ตัวเลือกการรวม**

You can apply options that determine whether

* แต่ละสไลด์ในงานนำเสนอผลลัพธ์จะคงสไตล์เฉพาะของตน
* สไตล์เฉพาะจะถูกใช้กับสไลด์ทั้งหมดในงานนำเสนอผลลัพธ์. 

เพื่อรวมงานนำเสนอ Aspose.Slides มีเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) (จากคลาส [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/)) มีการนำไปใช้หลายแบบของเมธอด `addClone` ที่กำหนดพารามิเตอร์ของกระบวนการรวมงานนำเสนอ ทุกอ็อบเจ็กต์ Presentation มีคอลเล็กชัน [slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getslides/) ดังนั้นคุณสามารถเรียกเมธอด `addClone` จากงานนำเสนอที่ต้องการรวมสไลด์ได้

เมธอด `addClone` จะคืนค่าเป็นอ็อบเจ็กต์ `Slide` ซึ่งเป็นสำเนาของสไลด์ต้นฉบับ สไลด์ในงานนำเสนอผลลัพธ์เป็นเพียงสำเนาของสไลด์จากต้นฉบับ ดังนั้นคุณสามารถทำการเปลี่ยนแปลงสไลด์ที่ได้ (เช่น ใช้สไตล์หรือตัวเลือกการจัดรูปแบบหรือเค้าโครง) โดยไม่ต้องกังวลว่างานนำเสนอเดิมจะได้รับผลกระทบ

## **รวมงานนำเสนอ**

Aspose.Slides มีเมธอด [addClone(Slide)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) ที่ช่วยให้คุณรวมสไลด์โดยสไลด์คงเค้าโครงและสไตล์เดิม (พารามิเตอร์ค่าเริ่มต้น).

โค้ด PHP นี้จะแสดงวิธีการรวมงานนำเสนอ:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **รวมงานนำเสนอด้วยสไลด์มาสเตอร์**

Aspose.Slides มีเมธอด [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) ที่ช่วยให้คุณรวมสไลด์พร้อมกับการใช้เทมเพลตสไลด์มาสเตอร์ของงานนำเสนอ วิธีนี้ทำให้คุณสามารถเปลี่ยนสไตล์ของสไลด์ในงานนำเสนอผลลัพธ์ได้หากต้องการ

โค้ดนี้แสดงการทำงานที่อธิบายไว้:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

เค้าโครงสไลด์สำหรับสไลด์มาสเตอร์จะถูกกำหนดโดยอัตโนมัติ หากไม่สามารถกำหนดเค้าโครงที่เหมาะสมได้ หากพารามิเตอร์บูลีน `allowCloneMissingLayout` ของเมธอด `addClone` ถูกตั้งค่าเป็น true จะใช้เค้าโครงของสไลด์ต้นฉบับ มิฉะนั้น จะเกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

หากคุณต้องการให้สไลด์ในงานนำเสนอผลลัพธ์มีเค้าโครงสไลด์ที่แตกต่าง ให้ใช้เมธอด [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) แทนเมื่อทำการรวม

## **รวมสไลด์เฉพาะจากงานนำเสนอ**

การรวมสไลด์เฉพาะจากหลายงานนำเสนอเป็นประโยชน์สำหรับการสร้างชุดสไลด์ที่กำหนดเอง Aspose.Slides for PHP via Java ให้คุณเลือกและนำเข้าเฉพาะสไลด์ที่ต้องการ API จะรักษาการจัดรูปแบบ เค้าโครง และการออกแบบของสไลด์ต้นฉบับ

โค้ด PHP ด้านล่างนี้สร้างงานนำเสนอใหม่ เพิ่มสไลด์หัวเรื่องจากงานนำเสนอสองแฟ้มอื่น และบันทึกผลลัพธ์ลงไฟล์:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **รวมงานนำเสนอด้วยเค้าโครงสไลด์**

โค้ด PHP นี้แสดงวิธีการรวมสไลด์จากงานนำเสนอพร้อมกับการใช้เค้าโครงสไลด์ที่คุณต้องการ เพื่อให้ได้งานนำเสนอผลลัพธ์หนึ่งไฟล์:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **รวมงานนำเสนอที่มีขนาดสไลด์แตกต่างกัน**

{{% alert title="Note" color="warning" %}} 

คุณไม่สามารถรวมงานนำเสนอที่มีขนาดสไลด์แตกต่างกันได้.

{{% /alert %}}

เพื่อรวมงานนำเสนอ 2 งานที่มีขนาดสไลด์แตกต่างกัน คุณต้องปรับขนาดของหนึ่งงานนำเสนอให้ตรงกับขนาดของงานนำเสนออีกงานหนึ่ง

โค้ดตัวอย่างนี้แสดงการทำงานที่อธิบายไว้:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **รวมสไลด์ไปยังส่วนของงานนำเสนอ**

โค้ด PHP นี้จะแสดงวิธีการรวมสไลด์เฉพาะไปยังส่วนของงานนำเสนอ:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

สไลด์จะถูกเพิ่มที่ส่วนท้ายของส่วนนั้น.

## **ดูเพิ่มเติม**

Aspose มีบริการ [FREE Online Collage Maker](https://products.aspose.app/slides/th/collage) ฟรี โดยใช้บริการออนไลน์นี้คุณสามารถรวมภาพ [JPG ไป JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG ไป PNG สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) และอื่น ๆ

ลองใช้ [Aspose FREE Online Merger](https://products.aspose.app/slides/th/merger) ซึ่งช่วยให้คุณรวมงานนำเสนอ PowerPoint ในรูปแบบเดียวกัน (เช่น PPT ไป PPT, PPTX ไป PPTX) หรือข้ามรูปแบบต่างกัน (เช่น PPT ไป PPTX, PPTX ไป ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/th/merger)

## **คำถามที่พบบ่อย**

**มีข้อจำกัดใดเกี่ยวกับจำนวนสไลด์เมื่อรวมงานนำเสนอหรือไม่?**

ไม่มีข้อจำกัดที่เข้มงวด Aspose.Slides สามารถจัดการไฟล์ขนาดใหญ่ได้ แต่ประสิทธิภาพขึ้นอยู่กับขนาดและทรัพยากรของระบบ สำหรับงานนำเสนอที่ใหญ่มาก แนะนำให้ใช้ JVM 64-bit และจัดสรรหน่วยความจำ heap เพียงพอ.

**ฉันสามารถรวมงานนำเสนอที่มีวิดีโอหรือเสียงฝังอยู่ได้หรือไม่?**

ใช่ Aspose.Slides จะคงเนื้อหามัลติมีเดียที่ฝังในสไลด์ไว้ แต่ไฟล์งานนำเสนอสุดท้ายอาจมีขนาดใหญ่ขึ้นอย่างมีนัยสำคัญ.

**แบบอักษรจะถูกคงไว้เมื่อรวมงานนำเสนอหรือไม่?**

ใช่ แบบอักษรที่ใช้ในงานนำต้นแบบจะถูกคงไว้ในไฟล์ผลลัพธ์ โดยสมมติว่ามีการติดตั้งบนระบบหรือ [embedded](/slides/th/php-java/embedded-font/).