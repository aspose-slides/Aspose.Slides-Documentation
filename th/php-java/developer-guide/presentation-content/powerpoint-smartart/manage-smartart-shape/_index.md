---
title: จัดการกราฟิก SmartArt ในการนำเสนอด้วย PHP
linktitle: กราฟิก SmartArt
type: docs
weight: 20
url: /th/php-java/manage-smartart-shape/
keywords:
- วัตถุ SmartArt
- ภาพกราฟิก SmartArt
- สไตล์ SmartArt
- สี SmartArt
- สร้าง SmartArt
- เพิ่ม SmartArt
- แก้ไข SmartArt
- เปลี่ยน SmartArt
- เข้าถึง SmartArt
- ประเภท Layout ของ SmartArt
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "อัตโนมัติกระบวนการสร้าง, แก้ไขและจัดรูปแบบ SmartArt ของ PowerPoint ใน PHP ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดสั้น ๆ และคำแนะนำที่เน้นประสิทธิภาพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสร้างและจัดการกราฟิก SmartArt ในงานนำเสนอ PowerPoint ด้วยโปรแกรมเมติก. บทความนี้อธิบายวิธีเพิ่มรูปทรง SmartArt ลงในสไลด์, เข้าถึงรูปทรง SmartArt ที่มีอยู่, ค้นหา SmartArt ตามประเภท Layout ที่กำหนด, และปรับปรุงลักษณะการแสดงผลโดยการเปลี่ยนสไตล์หรือสีของ SmartArt.

ตัวอย่างแสดงวิธีทำงานกับรูปทรง SmartArt ผ่านคอลเลกชันรูปทรงของสไลด์งานนำเสนอ, ตรวจสอบว่ารูปทรงเป็น SmartArt หรือไม่ แล้วทำการแก้ไขหรือสอบถามคุณสมบัติต่าง ๆ ของมัน.

## **สร้างรูปทรง SmartArt**
Aspose.Slides for PHP via Java มี API ที่จัดให้เพื่อสร้างรูปทรง SmartArt. เพื่อสร้างรูปทรง SmartArt บนสไลด์, โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
3. [เพิ่มรูปทรง SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addSmartArt) โดยกำหนด [LayoutType](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArtLayoutType)
4. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มรูปทรง Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # บันทึกการนำเสนอ
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**รูปภาพ: รูปทรง SmartArt ที่เพิ่มในสไลด์**|

## **เข้าถึงรูปทรง SmartArt บนสไลด์**
โค้ดต่อไปนี้จะใช้เพื่อเข้าถึงรูปทรง SmartArt ที่เพิ่มในสไลด์งานนำเสนอ. ในตัวอย่างโค้ด เราจะวนผ่านทุกรูปทรงภายในสไลด์และตรวจสอบว่ามันเป็นรูปทรง [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt) หรือไม่. หากรูปทรงเป็นประเภท SmartArt เราจะทำการแปลงประเภทเป็นอินสแตนซ์ของ [**SmartArt**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt).

```php
  # โหลดงานนำเสนอที่ต้องการ
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # วนผ่านทุกรูปทรงภายในสไลด์แรก
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทรูปทรงเป็น SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เข้าถึงรูปทรง SmartArt ด้วย Layout Type เฉพาะ**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงรูปทรง [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt) ด้วย LayoutType เฉพาะ: โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เนื่องจากเป็นค่าอ่านอย่างเดียวและจะถูกตั้งค่าเฉพาะเมื่อรูปทรง [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt) ถูกเพิ่ม.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนผ่านทุกรูปทรงภายในสไลด์แรก
4. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt) หรือไม่ และทำการแปลงประเภทของรูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
5. ตรวจสอบรูปทรง SmartArt ด้วย LayoutType เฉพาะและดำเนินการตามที่ต้องการต่อไป

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # วนผ่านทุกรูปทรงภายในสไลด์แรก
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทของรูปทรงเป็น SmartArtEx
        $smart = $shape;
        # ตรวจสอบ Layout ของ SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เปลี่ยนสไตล์ของรูปทรง SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การเปลี่ยนสไตล์เร็วสำหรับรูปทรง SmartArt ใด ๆ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนผ่านทุกรูปทรงภายในสไลด์แรก
4. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt) หรือไม่ และทำการแปลงประเภทของรูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
5. ค้นหารูปทรง SmartArt ด้วย Style เฉพาะ
6. ตั้งค่า Style ใหม่ให้กับรูปทรง SmartArt
7. บันทึกงานนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # ดึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # วนผ่านทุกรูปทรงภายในสไลด์แรก
    foreach($slide->getShapes() as $shape) {
      # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทของรูปทรงเป็น SmartArtEx
        $smart = $shape;
        # ตรวจสอบสไตล์ของ SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # เปลี่ยนสไตล์ของ SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # บันทึกการนำเสนอ
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**รูปภาพ: รูปทรง SmartArt ที่สไตล์ถูกเปลี่ยน**|

## **เปลี่ยนสไตล์สีของรูปทรง SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การเปลี่ยนสไตล์สีสำหรับรูปทรง SmartArt ใด ๆ. ในตัวอย่างโค้ดต่อไปนี้จะเข้าถึงรูปทรง SmartArt ด้วยสไตล์สีเฉพาะและจะเปลี่ยนสไตล์ของมัน.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนผ่านทุกรูปทรงภายในสไลด์แรก
4. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt) หรือไม่ และทำการแปลงประเภทของรูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
5. ค้นหารรูปทรง SmartArt ด้วย Color Style เฉพาะ
6. ตั้งค่า Color Style ใหม่ให้กับรูปทรง SmartArt
7. บันทึกงานนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # ดึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # วนผ่านทุกรูปทรงภายในสไลด์แรก
    foreach($slide->getShapes() as $shape) {
      # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทของรูปทรงเป็น SmartArtEx
        $smart = $shape;
        # ตรวจสอบประเภทสีของ SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # เปลี่ยนประเภทสีของ SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # บันทึกการนำเสนอ
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**รูปภาพ: รูปทรง SmartArt ที่สไตล์สีถูกเปลี่ยน**|

## **คำถามที่พบบ่อย**

**ฉันสามารถทำให้ SmartArt เคลื่อนที่เป็นวัตถุเดียวได้หรือไม่?**

ใช่. SmartArt เป็นรูปทรง ดังนั้นคุณสามารถใช้ [standard animations](/slides/th/php-java/powerpoint-animation/) ผ่าน API ของการเคลื่อนไหว (การเข้ามา, การออก, การเน้น, เส้นทางการเคลื่อนที่) เช่นเดียวกับรูปทรงอื่น ๆ.

**ฉันจะค้นหา SmartArt เฉพาะบนสไลด์ได้อย่างไรหากไม่รู้ ID ภายในของมัน?**

ตั้งค่าและใช้ Alternative Text (AltText) แล้วค้นหารูปทรงด้วยค่าดังกล่าว — วิธีนี้เป็นวิธีที่แนะนำให้ค้นหารูปทรงเป้าหมาย.

**ฉันสามารถกลุ่ม SmartArt กับรูปทรงอื่น ๆ ได้หรือไม่?**

ใช่. คุณสามารถกลุ่ม SmartArt กับรูปทรงอื่น ๆ (รูปภาพ, ตาราง, ฯลฯ) แล้ว [manipulate the group](/slides/th/php-java/group/).

**ฉันจะได้ภาพของ SmartArt เฉพาะ (เช่นสำหรับตัวอย่างหรือรายงาน) อย่างไร?**

ส่งออก thumbnail/รูปภาพของรูปทรง; ไลบรารีสามารถ [render individual shapes](/slides/th/php-java/create-shape-thumbnails/) ไปเป็นไฟล์ raster (PNG/JPG/TIFF).

**ลักษณะของ SmartArt จะคงเดิมเมื่อต้องแปลงงานนำเสนอทั้งหมดเป็น PDF หรือไม่?**

ใช่. เครื่องมือเรนเดอร์มุ่งเน้นความเที่ยงตรงสูงสำหรับ [PDF export](/slides/th/php-java/convert-powerpoint-to-pdf/), พร้อมช่วงของตัวเลือกคุณภาพและความเข้ากันได้.