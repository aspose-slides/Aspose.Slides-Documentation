---
title: จัดการโหนดรูปแบบ SmartArt ในงานนำเสนอด้วย PHP
linktitle: โหนดรูปแบบ SmartArt
type: docs
weight: 30
url: /th/php-java/manage-smartart-shape-node/
keywords:
- โหนด SmartArt
- โหนดย่อย
- เพิ่มโหนด
- ตำแหน่งโหนด
- เข้าถึงโหนด
- ลบโหนด
- ตำแหน่งกำหนดเอง
- โหนดผู้ช่วย
- รูปแบบการเติมสี
- เรนเดอร์โหนด
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการโหนดรูปแบบ SmartArt ในไฟล์ PPT และ PPTX ด้วย Aspose.Slides for PHP via Java. รับตัวอย่างโค้ดที่ชัดเจนและเคล็ดลับเพื่อทำให้งานนำเสนอของคุณเป็นระเบียบขึ้น."
---
## **ภาพรวม**

กราฟิก SmartArt ในการนำเสนอ PowerPoint ถูกจัดระเบียบผ่านโหนดที่มีข้อความและกำหนดโครงสร้างของแผนภาพ Aspose.Slides ให้คุณทำงานกับโหนด SmartArt เหล่านี้โดยใช้โปรแกรม: เพิ่มโหนดและโหนดย่อยใหม่, แทรกโหนดย่อยในตำแหน่งที่กำหนด, เข้าถึงโหนดที่มีอยู่, และอ่านข้อความ ระดับ และตำแหน่งของโหนด

บทความนี้อธิบายวิธีจัดการโหนดรูปแบบ SmartArt แสดงวิธีลบโหนด, ทำงานกับโหนดย่อยโดยใช้ดัชนีหรือตำแหน่ง, เปลี่ยนโหนดผู้ช่วยเป็นโหนดปกติ, ปรับตำแหน่ง ขนาด และการหมุนของรูปแบบโหนด SmartArt, ตั้งค่ารูปแบบการเติมสีของโหนด, และสร้างภาพย่อของโหนดย่อย SmartArt

## **เพิ่มโหนด SmartArt**
Aspose.Slides for PHP via Java มี API ที่ง่ายที่สุดในการจัดการรูปแบบ SmartArt อย่างง่ายที่สุด ตัวอย่างโค้ดต่อไปนี้จะช่วยเพิ่มโหนดและโหนดย่อยภายในรูปแบบ SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) และโหลดการนำเสนอที่มีรูปแบบ SmartArt
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนรอบผ่านรูปร่างทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หรือไม่ และทำการแปลงประเภทของรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หากเป็น SmartArt
5. [Add a new Node](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnodecollection/#addNode) ในรูปแบบ SmartArt [**NodeCollection**](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/#getAllNodes) และตั้งค่าข้อความใน TextFrame
6. ตอนนี้, [Add](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnodecollection/#addNode) [**Child Node**](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/#getChildNodes) ใน [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) Node ที่เพิ่มใหม่และตั้งค่าข้อความใน TextFrame
7. บันทึกการนำเสนอ

```php
  # โหลดการนำเสนอที่ต้องการ
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # วนรอบผ่านรูปร่างทั้งหมดในสไลด์แรก
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทรูปร่างเป็น SmartArt
        $smart = $shape;
        # เพิ่มโหนด SmartArt ใหม่
        $TemNode = $smart->getAllNodes()->addNode();
        # เพิ่มข้อความ
        $TemNode->getTextFrame()->setText("Test");
        # เพิ่มโหนดย่อยใหม่ในโหนดหลัก โหนดนี้จะถูกเพิ่มในตอนท้ายของคอลเลกชัน
        $newNode = $TemNode->getChildNodes()->addNode();
        # เพิ่มข้อความ
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # บันทึกการนำเสนอ
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มโหนด SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างโค้ดต่อไปนี้เราจะอธิบายวิธีเพิ่มโหนดย่อยที่เป็นของโหนดต่าง ๆ ของรูปแบบ SmartArt ในตำแหน่งเฉพาะ

1. สร้างอินสแตนซ์ของคลาส Presentation
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. เพิ่มรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt) ประเภท [**StackedList**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArtLayoutType#StackedList) ในสไลด์ที่เข้าถึง
4. เข้าถึงโหนดแรกในรูปแบบ SmartArt ที่เพิ่ม
5. ตอนนี้, เพิ่ม [**Child Node**](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/#getChildNodes) สำหรับ [**Node**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArtNode) ที่เลือกที่ตำแหน่ง 2 และตั้งค่าข้อความ
6. บันทึกการนำเสนอ

```php
  # สร้างอินสแตนซ์ของการนำเสนอ
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์ของการนำเสนอ
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่ม Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # เข้าถึงโหนด SmartArt ที่ตำแหน่ง 0
    $node = $smart->getAllNodes()->get_Item(0);
    # เพิ่มโหนดย่อยใหม่ที่ตำแหน่ง 2 ในโหนดหลัก
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # เพิ่มข้อความ
    $chNode->getTextFrame()->setText("Sample Text Added");
    # บันทึกการนำเสนอ
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เข้าถึงโหนด SmartArt**
โค้ดตัวอย่างต่อไปนี้จะช่วยในการเข้าถึงโหนดภายในรูปแบบ SmartArt โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เนื่องจากเป็นค่าอ่านอย่างเดียวและจะตั้งค่าเมื่อรูปแบบ SmartArt ถูกเพิ่ม

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนรอบผ่านรูปร่างทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หรือไม่ และทำการแปลงประเภทของรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หากเป็น SmartArt
5. วนรอบผ่าน [**Nodes**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt#getAllNodes--) ทั้งหมดภายใน SmartArt Shape
6. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่ง โหนด SmartArt ระดับและข้อความ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # รับสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # วนรอบผ่านรูปร่างทั้งหมดในสไลด์แรก
    foreach($slide->getShapes() as $shape) {
      # ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทของรูปร่างเป็น SmartArt
        $smart = $shape;
        # วนรอบผ่านโหนดทั้งหมดใน SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # เข้าถึงโหนด SmartArt ที่ตำแหน่ง i
          $node = $smart->getAllNodes()->get_Item($i);
          # พิมพ์พารามิเตอร์ของโหนด SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เข้าถึงโหนดย่อย SmartArt**
โค้ดตัวอย่างต่อไปนี้จะช่วยเข้าถึงโหนดย่อยของโหนดต่าง ๆ ของรูปแบบ SmartArt

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนรอบผ่านรูปร่างทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หรือไม่ และทำการแปลงประเภทของรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หากเป็น SmartArt
5. วนรอบผ่าน [**Nodes**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArt#getAllNodes--) ทั้งหมดภายใน SmartArt Shape
6. สำหรับแต่ละ [**Node**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArtNode) ที่เลือกในรูปแบบ SmartArt, วนรอบผ่าน [**Child Nodes**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArtNode#getChildNodes--) ทั้งหมดภายในโหนดนั้น
7. เข้าถึงและแสดงข้อมูลเช่น [**Child Node**](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/#getChildNodes) ตำแหน่ง ระดับและข้อความ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # รับสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # วนรอบผ่านรูปร่างทั้งหมดในสไลด์แรก
    foreach($slide->getShapes() as $shape) {
      # ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทของรูปร่างเป็น SmartArt
        $smart = $shape;
        # วนรอบผ่านโหนดทั้งหมดใน SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # เข้าถึงโหนด SmartArt ที่ตำแหน่ง i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # วนรอบผ่านโหนดย่อยในโหนด SmartArt ที่ตำแหน่ง i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # เข้าถึงโหนดย่อยในโหนด SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # พิมพ์พารามิเตอร์ของโหนดย่อย SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เข้าถึงโหนดย่อย SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างนี้เราจะเรียนรู้วิธีเข้าถึงโหนดย่อยที่อยู่ในตำแหน่งเฉพาะของโหนดต่าง ๆ ของรูปแบบ SmartArt

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) 
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. เพิ่มรูปแบบ SmartArt ประเภท [**StackedList**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArtLayoutType#StackedList)
4. เข้าถึงรูปแบบ SmartArt ที่เพิ่ม
5. เข้าถึงโหนดที่ตำแหน่ง 0 สำหรับรูปแบบ SmartArt ที่เข้าถึง
6. ตอนนี้, เข้าถึง [**Child Node**](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/#getChildNodes) ที่ตำแหน่ง 1 สำหรับโหนด SmartArt ที่เข้าถึงโดยใช้ **get_Item()** method
7. เข้าถึงและแสดงข้อมูลเช่น [**Child Node**](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/#getChildNodes) ตำแหน่ง ระดับและข้อความ

```php
  # สร้างอินสแตนซ์ของการนำเสนอ
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มรูปแบบ SmartArt ในสไลด์แรก
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # เข้าถึงโหนด SmartArt ที่ตำแหน่ง 0
    $node = $smart->getAllNodes()->get_Item(0);
    # เข้าถึงโหนดย่อยที่ตำแหน่ง 1 ในโหนดหลัก
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # พิมพ์พารามิเตอร์ของโหนดย่อย SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบโหนด SmartArt**
ในตัวอย่างนี้เราจะเรียนรู้วิธีลบโหนดภายในรูปแบบ SmartArt

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนรอบผ่านรูปร่างทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หรือไม่ และทำการแปลงประเภทของรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หากเป็น SmartArt
5. ตรวจสอบว่า SmartArt มีโหนดมากกว่า 0 หรือไม่
6. เลือกโหนด SmartArt ที่ต้องการลบ
7. ตอนนี้, ลบโหนดที่เลือกโดยใช้ [**removeNode**](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnodecollection/#removeNode) method
8. บันทึกการนำเสนอ

```php
  # โหลดการนำเสนอที่ต้องการ
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # วนรอบผ่านรูปร่างทั้งหมดในสไลด์แรก
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทของรูปร่างเป็น SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # เข้าถึงโหนด SmartArt ที่ตำแหน่ง 0
          $node = $smart->getAllNodes()->get_Item(0);
          # ลบโหนดที่เลือก
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # บันทึกการนำเสนอ
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบโหนด SmartArt จากตำแหน่งเฉพาะ**
ในตัวอย่างนี้เราจะเรียนรู้วิธีลบโหนดภายในรูปแบบ SmartArt ที่ตำแหน่งเฉพาะ

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
3. วนรอบผ่านรูปร่างทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หรือไม่ และทำการแปลงประเภทของรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หากเป็น SmartArt
5. เลือกโหนดรูปแบบ SmartArt ที่ตำแหน่ง 0
6. ตอนนี้, ตรวจสอบว่าโหนด SmartArt ที่เลือกมีโหนดย่อยมากกว่า 2 หรือไม่
7. ตอนนี้, ลบโหนดที่ **Position 1** โดยใช้ [**removeNode**](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnodecollection/#removeNode) method
8. บันทึกการนำเสนอ

```php
  # โหลดการนำเสนอที่ต้องการ
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # วนรอบผ่านรูปร่างทั้งหมดในสไลด์แรก
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทของรูปร่างเป็น SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # เข้าถึงโหนด SmartArt ที่ตำแหน่ง 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # ลบโหนดย่อยที่ตำแหน่ง 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # บันทึกการนำเสนอ
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าตำแหน่งกำหนดเองสำหรับโหนดย่อยในวัตถุ SmartArt**
Aspose.Slides for PHP via Java รองรับการตั้งค่าคุณสมบัติ [SmartArtShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#setX) และ [Y](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#setY) โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าตำแหน่ง ขนาด และการหมุนของ SmartArtShape แบบกำหนดเอง โปรดทราบว่าการเพิ่มโหนดใหม่จะทำให้มีการคำนวณตำแหน่งและขนาดของโหนดทั้งหมดใหม่ อีกทั้งด้วยการตั้งค่าตำแหน่งกำหนดเอง ผู้ใช้สามารถตั้งค่าโหนดตามความต้องการได้

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # ย้ายรูปร่าง SmartArt ไปยังตำแหน่งใหม่
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # เปลี่ยนความกว้างของรูปร่าง SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # เปลี่ยนความสูงของรูปร่าง SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # เปลี่ยนการหมุนของรูปร่าง SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **ตรวจสอบโหนดผู้ช่วย**
{{% alert color="primary" %}} 

ในบทความนี้เราจะสำรวจคุณลักษณะเพิ่มเติมของรูปแบบ SmartArt ที่เพิ่มในสไลด์การนำเสนอโดยใช้โปรแกรม Aspose.Slides for PHP via Java

{{% /alert %}} 

เราจะใช้รูปแบบ SmartArt ต้นฉบับต่อไปนี้ในการสำรวจในส่วนต่าง ๆ ของบทความนี้

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**รูปที่: รูปแบบ SmartArt ต้นฉบับในสไลด์**|

ในโค้ดตัวอย่างต่อไปนี้เราจะตรวจสอบวิธีระบุ **Assistant Nodes** ในคอลเลกชันโหนด SmartArt และการเปลี่ยนแปลงพวกมัน

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) และโหลดการนำเสนอที่มี SmartArt Shape
2. รับอ้างอิงของสไลด์ที่สองโดยใช้ Index ของมัน
3. วนรอบผ่านรูปร่างทั้งหมดภายในสไลด์แรก
4. ตรวจสอบว่ารูปร่างเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หรือไม่ และทำการแปลงประเภทของรูปร่างที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หากเป็น SmartArt
5. วนรอบผ่านโหนดทั้งหมดภายในรูปแบบ SmartArt และตรวจสอบว่าพวกมันเป็น [**Assistant Nodes**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArtNode#isAssistant--) หรือไม่
6. เปลี่ยนสถานะของ Assistant Node ให้เป็นโหนดปกติ
7. บันทึกการนำเสนอ

```php
  # สร้างอินสแตนซ์ของการนำเสนอ
  $pres = new Presentation("AddNodes.pptx");
  try {
    # วนรอบผ่านรูปร่างทั้งหมดในสไลด์แรก
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # แปลงประเภทของรูปร่างเป็น SmartArt
        $smart = $shape;
        # วนรอบผ่านโหนดทั้งหมดของรูปแบบ SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # ตรวจสอบว่าโหนดเป็นโหนดผู้ช่วยหรือไม่
          if ($node->isAssistant()) {
            # ตั้งค่าโหนดผู้ช่วยเป็น false และทำให้เป็นโหนดปกติ
            $node->isAssistant();
          }
        }
      }
    }
    # บันทึกการนำเสนอ
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**รูปที่: โหนดผู้ช่วยที่เปลี่ยนแปลงในรูปแบบ SmartArt ภายในสไลด์**|

## **ตั้งค่ารูปแบบการเติมสีของโหนด**
Aspose.Slides for PHP via Java ทำให้สามารถเพิ่มรูปแบบ SmartArt แบบกำหนดเองและตั้งค่ารูปแบบการเติมสีได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปแบบ SmartArt และตั้งค่ารูปแบบการเติมสีโดยใช้ Aspose.Slides for PHP via Java

โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) โดยตั้งค่า [**LayoutType**](https://reference.aspose.com/slides/th/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess)
4. ตั้งค่า [**Fill Format**](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getFillFormat) สำหรับโหนดรูปแบบ SmartArt
5. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```php
  # สร้างอินสแตนซ์ของการนำเสนอ
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มรูปร่าง SmartArt และโหนด
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # ตั้งค่าสีเติมของโหนด
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # บันทึกการนำเสนอ
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **สร้างภาพย่อของโหนดย่อย SmartArt**
นักพัฒนาสามารถสร้างภาพย่อของโหนดย่อย SmartArt ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
2. [Add SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnodecollection/#addNode)
3. รับอ้างอิงของโหนดโดยใช้ Index ของมัน
4. รับภาพย่อ
5. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใด ๆ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เพิ่ม SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # รับอ้างอิงของโหนดโดยใช้ Index ของมัน
    $node = $smart->getNodes()->get_Item(1);
    # รับภาพย่อ
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # บันทึกภาพย่อ
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**สนับสนุนการทำแอนิเมชันของ SmartArt หรือไม่?**

ใช่. SmartArt ถูกจัดการเป็นรูปทรงทั่วไป ดังนั้นคุณสามารถ [ใช้แอนิเมชันมาตรฐาน](/slides/th/php-java/shape-animation/) (การปรากฏ, การหายไป, การเน้น, เส้นทางการเคลื่อน) และปรับเวลาการเล่นได้ คุณยังสามารถทำแอนิเมชันให้กับรูปทรงภายในโหนด SmartArt เมื่อจำเป็น

**ฉันจะค้นหา SmartArt เฉพาะบนสไลด์ได้อย่างเชื่อถือได้อย่างไร หากไม่รู้ ID ภายใน?**

โดยกำหนดและค้นหาจาก [ข้อความแทน](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getalternativetext/) การตั้งค่า AltText ที่แตกต่างบน SmartArt จะทำให้คุณค้นหาได้โดยใช้โปรแกรมโดยไม่ต้องอ้างอิงถึงตัวระบุภายใน

**รูปลักษณ์ของ SmartArt จะคงเดิมเมื่อแปลงการนำเสนอเป็น PDF หรือไม่?**

ใช่. Aspose.Slides renders SmartArt with high visual fidelity during [PDF export](/slides/th/php-java/convert-powerpoint-to-pdf/), preserving layout, colors, and effects.

**ฉันสามารถดึงภาพของ SmartArt ทั้งหมด (เพื่อคัดลอกหรือรายงาน) ได้หรือไม่?**

ใช่. คุณสามารถเรนเดอร์รูปแบบ SmartArt เป็น [raster formats](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage) หรือเป็น [SVG](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/writeassvg/) สำหรับการส่งออกแบบเวกเตอร์ขนาดใหญ่ ทำให้เหมาะสำหรับภาพย่อ รายงาน หรือการใช้บนเว็บ.