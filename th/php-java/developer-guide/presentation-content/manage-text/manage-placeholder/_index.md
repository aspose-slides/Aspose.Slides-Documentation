---
title: จัดการ Placeholder ของงานนำเสนอใน PHP
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/php-java/manage-placeholder/
keywords:
- ตำแหน่งที่วาง
- ตำแหน่งที่วางข้อความ
- ตำแหน่งที่วางภาพ
- ตำแหน่งที่วางแผนภูมิ
- ข้อความพรอมต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการ placeholder อย่างง่ายดายใน Aspose.Slides สำหรับ PHP ผ่าน Java: แทนที่ข้อความ ปรับแต่งข้อความพรอมต์ และตั้งค่าความโปร่งใสของภาพใน PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถจัดการ placeholder ของงานนำเสนอได้โดยโปรแกรม วิธีการนี้อธิบายวิธีค้นหา placeholder บนสไลด์และเปลี่ยนข้อความของพวกมัน ตั้งค่าข้อความ Prompt แบบกำหนดเองสำหรับ layout ของ placeholder และปรับความโปร่งใสของรูปภาพที่ใช้เป็นพื้นหลังของ placeholder นอกจากนี้ยังมี FAQ สั้น ๆ ที่ชี้แจงความแตกต่างระหว่าง base placeholder กับ local shape อธิบายวิธีการนำการเปลี่ยนแปลงของ placeholder ไปใช้ผ่าน layout หรือ master และชี้ไปยังการจัดการ placeholder ของส่วนหัวและส่วนท้าย

## **เปลี่ยนข้อความใน Placeholder**

โดยใช้ [Aspose.Slides for PHP via Java](/slides/th/php-java/), คุณสามารถค้นหาและแก้ไข placeholder บนสไลด์ในงานนำเสนอได้ Aspose.Slides ช่วยให้คุณสามารถเปลี่ยนแปลงข้อความใน placeholder

**ข้อกำหนดเบื้องต้น**: คุณต้องมีงานนำเสนอที่มี placeholder คุณสามารถสร้างงานนำเสนอเช่นนั้นได้ในแอป Microsoft PowerPoint มาตรฐาน

นี่คือวิธีการใช้ Aspose.Slides เพื่อแทนที่ข้อความใน placeholder ของงานนำเสนนั้น:

1. สร้างอินสแตนซ์ของคลาส [`Presentation`](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) และส่งงานนำเสนอเป็นอาร์กิวเม็นต์
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน
3. วนลูปผ่าน shapes เพื่อค้นหา placeholder
4. แปลงประเภท shape ของ placeholder ไปเป็น [`AutoShape`](https://reference.aspose.com/slides/th/php-java/aspose.slides/AutoShape) และเปลี่ยนข้อความโดยใช้ [`TextFrame`](https://reference.aspose.com/slides/th/php-java/aspose.slides/TextFrame) ที่เชื่อมโยงกับ [`AutoShape`](https://reference.aspose.com/slides/th/php-java/aspose.slides/AutoShape)
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้แสดงวิธีการเปลี่ยนข้อความใน placeholder:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # วนลูปผ่าน shapes เพื่อค้นหา placeholder
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # เปลี่ยนข้อความในแต่ละ placeholder
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # บันทึกงานนำเสนอลงดิสก์
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าข้อความ Prompt ใน Placeholder**

layout มาตรฐานและที่สร้างไว้ล่วงหน้ามีข้อความ prompt ของ placeholder เช่น ***Click to add a title*** หรือ ***Click to add a subtitle*** โดยใช้ Aspose.Slides คุณสามารถแทรกข้อความ prompt ที่คุณต้องการลงใน layout ของ placeholder

โค้ด PHP นี้แสดงวิธีการตั้งค่าข้อความ prompt ใน placeholder:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # วนลูปผ่านสไลด์
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint แสดง "คลิกเพื่อเพิ่มชื่อเรื่อง"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // เพิ่มคำบรรยายย่อย
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าความโปร่งใสของรูปภาพ Placeholder**

Aspose.Slides ช่วยให้คุณตั้งค่าความโปร่งใสของภาพพื้นหลังใน placeholder ของข้อความได้ โดยการปรับความโปร่งใสของรูปภาพในเฟรมดังกล่าว คุณสามารถทำให้ข้อความหรือภาพโดดเด่นขึ้น (ขึ้นอยู่กับสีของข้อความและรูปภาพ)

โค้ด PHP นี้แสดงวิธีการตั้งค่าความโปร่งใสสำหรับพื้นหลังรูปภาพ (ภายใน shape):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**Base placeholder คืออะไรและแตกต่างจาก local shape บนสไลด์อย่างไร?**

Base placeholder คือ shape ต้นฉบับบน layout หรือ master ที่ shape ของสไลด์สืบทอดมา—ประเภท ตำแหน่ง และการจัดรูปแบบบางส่วนมาจากนั้น ส่วน local shape เป็นอิสระ; หากไม่มี base placeholder การสืบทอดจะไม่เกิดขึ้น

**ฉันจะอัปเดตหัวเรื่องหรือคำอธิบายทั้งหมดในงานนำเสนอโดยไม่ต้องวนลูปทุกสไลด์ได้อย่างไร?**

แก้ไข placeholder ที่เกี่ยวข้องบน layout หรือ master สไลด์ที่อ้างอิงจาก layout/ master ดังกล่าวจะสืบทอดการเปลี่ยนแปลงโดยอัตโนมัติ

**ฉันจะควบคุม placeholder มาตรฐานของส่วนหัว/ส่วนท้าย—วันที่และเวลา, หมายเลขสไลด์, และข้อความส่วนท้ายได้อย่างไร?**

ใช้ตัวจัดการ HeaderFooter ในระดับที่เหมาะสม (สไลด์ปกติ, layout, master, notes/handouts) เพื่อเปิดหรือปิด placeholder เหล่านั้นและตั้งค่าข้อมูลของพวกมัน