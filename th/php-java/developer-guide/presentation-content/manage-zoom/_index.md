---
title: จัดการการซูมของงานนำเสนอใน PHP
linktitle: จัดการซูม
type: docs
weight: 60
url: /th/php-java/manage-zoom/
keywords:
- ซูม
- เฟรมซูม
- ซูมสไลด์
- ซูมส่วน
- ซูมสรุป
- เพิ่มซูม
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่ง Zoom ด้วย Aspose.Slides for PHP via Java — กระโดดระหว่างส่วน, เพิ่มรูปย่อและการเปลี่ยนฉากในงานนำเสนอรูปแบบ PPT, PPTX และ ODP."
---
## **บทนำ**

Zoom ใน PowerPoint ช่วยให้คุณกระโดดไปและมาจากสไลด์, ส่วน, และส่วนย่อยของการนำเสนอได้ เมื่อคุณกำลังนำเสนอ ความสามารถนี้ในการนำทางอย่างรวดเร็วผ่านเนื้อหาอาจมีประโยชน์อย่างมาก  

![overview_image](overview.png)

* เพื่อสรุปการนำเสนอทั้งหมดในสไลด์เดียว, ใช้ [Summary Zoom](#Summary-Zoom).
* หากต้องการแสดงเฉพาะสไลด์ที่เลือก, ใช้ [Slide Zoom](#Slide-Zoom).
* หากต้องการแสดงเฉพาะส่วนเดียว, ใช้ [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Zoom สไลด์สามารถทำให้การนำเสนอของคุณมีความไดนามิกมากขึ้น, โดยให้คุณนำทางระหว่างสไลด์ได้อย่างอิสระในลำดับใดก็ได้โดยไม่ทำลายการไหลของการนำเสนอ Zoom สไลด์เหมาะสำหรับการนำเสนอสั้น ๆ ที่ไม่มีหลายส่วน, แต่คุณก็ยังสามารถใช้ในสถานการณ์การนำเสนออื่น ๆ ได้

Zoom สไลด์ช่วยให้คุณเจาะลึกข้อมูลหลายชิ้นในขณะที่รู้สึกเหมือนอยู่บนผืนผ้าใบเดียว  

![overview_image](slidezoomsel.png)

สำหรับวัตถุ Zoom สไลด์, Aspose.Slides มี enumeration **ZoomImageType**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/zoomimagetype/)), คลาส **ZoomFrame**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/zoomframe/)) และเมธอดบางอย่างในคลาส **ShapeCollection**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/))  

### **สร้าง Zoom Frame**

คุณสามารถเพิ่ม Zoom Frame บนสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. สร้างสไลด์ใหม่ที่คุณต้องการเชื่อมต่อกับ Zoom Frame.
3. เพิ่มข้อความระบุตัวและพื้นหลังให้กับสไลด์ที่สร้าง.
4. เพิ่ม Zoom Frame (ซึ่งอ้างอิงสไลด์ที่สร้าง) ไปยังสไลด์แรก.
5. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP นี้แสดงวิธีสร้าง Zoom Frame บนสไลด์:

```php
  $pres = new Presentation();
  try {
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # สร้างพื้นหลังสำหรับสไลด์ที่สอง
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # สร้างกล่องข้อความสำหรับสไลด์ที่สอง
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # สร้างพื้นหลังสำหรับสไลด์ที่สาม
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # สร้างกล่องข้อความสำหรับสไลด์ที่สาม
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # เพิ่มอ็อบเจ็กต์ ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # บันทึกงานนำเสนอ
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **สร้าง Zoom Frame ด้วยภาพกำหนดเอง**
ด้วย Aspose.Slides for PHP via Java, คุณสามารถสร้าง Zoom Frame ที่มีภาพตัวอย่างสไลด์แตกต่างกันได้โดยทำดังนี้:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. สร้างสไลด์ใหม่ที่คุณต้องการเชื่อมต่อกับ Zoom Frame.
3. เพิ่มข้อความระบุตัวและพื้นหลังให้กับสไลด์.
4. สร้างอ็อบเจ็กต์ **PPImage**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)) โดยเพิ่มภาพลงในคอลเลกชัน Images ของอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่จะใช้เติมกรอบ.
5. เพิ่ม Zoom Frame (ซึ่งอ้างอิงสไลด์ที่สร้าง) ไปยังสไลด์แรก.
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP นี้แสดงวิธีสร้าง Zoom Frame ด้วยภาพกำหนดเอง:

```php
  $pres = new Presentation();
  try {
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # สร้างพื้นหลังสำหรับสไลด์ที่สอง
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # สร้างกล่องข้อความสำหรับสไลด์ที่สาม
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # สร้างภาพใหม่สำหรับอ็อบเจ็กต์ซูม
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # เพิ่มอ็อบเจ็กต์ ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # บันทึกงานนำเสนอ
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **ฟอร์แมต Zoom Frame**
ในส่วนก่อนหน้า เราได้แสดงวิธีสร้าง Zoom Frame อย่างง่าย. เพื่อสร้าง Zoom Frame ที่ซับซ้อนมากขึ้น, คุณต้องปรับเปลี่ยนการฟอร์แมตของเฟรมอย่างง่าย. มีตัวเลือกการฟอร์แมตหลายอย่างที่คุณสามารถใช้กับ Zoom Frame.

คุณสามารถควบคุมการฟอร์แมตของ Zoom Frame บนสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. สร้างสไลด์ใหม่ที่คุณต้องการเชื่อมต่อกับ Zoom Frame.
3. เพิ่มข้อความระบุตัวและพื้นหลังให้กับสไลด์ที่สร้าง.
4. เพิ่ม Zoom Frame (ซึ่งอ้างอิงสไลด์ที่สร้าง) ไปยังสไลด์แรก.
5. สร้างอ็อบเจ็กต์ **PPImage**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)) โดยเพิ่มภาพลงในคอลเลกชัน Images ของอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่จะใช้เติมกรอบ.
6. ตั้งค่าภาพกำหนดเองสำหรับอ็อบเจ็กต์ Zoom Frame แรก.
7. เปลี่ยนรูปแบบเส้นสำหรับอ็อบเจ็กต์ Zoom Frame ที่สอง.
8. ลบพื้นหลังจากภาพของอ็อบเจ็กต์ Zoom Frame ที่สอง.
5. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP นี้แสดงวิธีเปลี่ยนการฟอร์แมตของ Zoom Frame บนสไลด์:

```php
  $pres = new Presentation();
  try {
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # สร้างพื้นหลังสำหรับสไลด์ที่สอง
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # สร้างกล่องข้อความสำหรับสไลด์ที่สอง
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # สร้างพื้นหลังสำหรับสไลด์ที่สาม
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # สร้างกล่องข้อความสำหรับสไลด์ที่สาม
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # เพิ่มอ็อบเจ็กต์ ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # สร้างภาพใหม่สำหรับอ็อบเจ็กต์ซูม
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # ตั้งค่าภาพกำหนดเองสำหรับอ็อบเจ็กต์ zoomFrame1
    $zoomFrame1->setImage($picture);
    # ตั้งค่ารูปแบบเฟรมซูมสำหรับอ็อบเจ็กต์ zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # การตั้งค่าสำหรับไม่แสดงพื้นหลังสำหรับอ็อบเจ็กต์ zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # บันทึกงานนำเสนอ
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Section Zoom**

Section Zoom คือการเชื่อมโยงไปยังส่วนในการนำเสนอของคุณ. คุณสามารถใช้ Section Zoom เพื่อกลับไปที่ส่วนที่ต้องการเน้นจริง ๆ หรือใช้เพื่อแสดงให้เห็นว่าชิ้นส่วนต่าง ๆ ของการนำเสนอของคุณเชื่อมต่อกันอย่างไร.

![overview_image](seczoomsel.png)

สำหรับวัตถุ Section Zoom, Aspose.Slides มีคลาส **SectionZoomFrame**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/sectionzoomframe/)) และเมธอดบางอย่างในคลาส **ShapeCollection**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/))  

### **สร้าง Section Zoom Frame**

คุณสามารถเพิ่ม Section Zoom Frame ไปยังสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. สร้างสไลด์ใหม่.
3. เพิ่มพื้นหลังระบุตัวให้กับสไลด์ที่สร้าง.
4. สร้างส่วนใหม่ที่คุณต้องการเชื่อมต่อกับ Zoom Frame.
5. เพิ่ม Section Zoom Frame (ซึ่งอ้างอิงส่วนที่สร้าง) ไปยังสไลด์แรก.
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP นี้แสดงวิธีสร้าง Section Zoom Frame บนสไลด์:

```php
  $pres = new Presentation();
  try {
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 1", $slide);
    # เพิ่มอ็อบเจ็กต์ SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # บันทึกงานนำเสนอ
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **สร้าง Section Zoom Frame ด้วยภาพกำหนดเอง**

ใช้ Aspose.Slides for PHP via Java, คุณสามารถสร้าง Section Zoom Frame ที่มีภาพตัวอย่างสไลด์แตกต่างกันได้โดยทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. สร้างสไลด์ใหม่.
3. เพิ่มพื้นหลังระบุตัวให้กับสไลด์ที่สร้าง.
4. สร้างส่วนใหม่ที่คุณต้องการเชื่อมต่อกับ Zoom Frame.
5. สร้างอ็อบเจ็กต์ **PPImage**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)) โดยเพิ่มภาพลงในคอลเลกชัน Images ของอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่จะใช้เติมกรอบ.
5. เพิ่ม Section Zoom Frame (ซึ่งอ้างอิงส่วนที่สร้าง) ไปยังสไลด์แรก.
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP นี้แสดงวิธีสร้าง Section Zoom Frame ด้วยภาพกำหนดเอง:

```php
  $pres = new Presentation();
  try {
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 1", $slide);
    # สร้างภาพใหม่สำหรับอ็อบเจ็กต์ซูม
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # เพิ่มอ็อบเจ็กต์ SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # บันทึกงานนำเสนอ
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **ฟอร์แมต Section Zoom Frame**

เพื่อสร้าง Section Zoom Frame ที่ซับซ้อนมากขึ้น, คุณต้องปรับเปลี่ยนการฟอร์แมตของเฟรมอย่างง่าย. มีตัวเลือกการฟอร์แมตหลายอย่างที่คุณสามารถใช้กับ Section Zoom Frame.

คุณสามารถควบคุมการฟอร์แมตของ Section Zoom Frame บนสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. สร้างสไลด์ใหม่.
3. เพิ่มพื้นหลังระบุตัวให้กับสไลด์ที่สร้าง.
4. สร้างส่วนใหม่ที่คุณต้องการเชื่อมต่อกับ Zoom Frame.
5. เพิ่ม Section Zoom Frame (ซึ่งอ้างอิงส่วนที่สร้าง) ไปยังสไลด์แรก.
6. เปลี่ยนขนาดและตำแหน่งของอ็อบเจ็กต์ Section Zoom ที่สร้าง.
7. สร้างอ็อบเจ็กต์ **PPImage**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)) โดยเพิ่มภาพลงในคอลเลกชัน Images ของอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่จะใช้เติมกรอบ.
8. ตั้งค่าภาพกำหนดเองสำหรับอ็อบเจ็กต์ Section Zoom ที่สร้าง.
9. ตั้งค่าความสามารถ *กลับไปยังสไลด์ต้นฉบับจากส่วนที่เชื่อมโยง*.
10. ลบพื้นหลังจากภาพของอ็อบเจ็กต์ Section Zoom.
11. เปลี่ยนรูปแบบเส้นสำหรับอ็อบเจ็กต์ Zoom Frame ที่สอง.
12. เปลี่ยนระยะเวลาเปลี่ยนฉาก.
13. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP นี้แสดงวิธีเปลี่ยนการฟอร์แมตของ Section Zoom Frame:

```php
  $pres = new Presentation();
  try {
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 1", $slide);
    # เพิ่มอ็อบเจ็กต์ SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # การจัดรูปแบบสำหรับ SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # บันทึกงานนำเสนอ
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Summary Zoom**

Summary Zoom คล้ายกับหน้า Landing Page ที่แสดงส่วนต่าง ๆ ของการนำเสนอทั้งหมดพร้อมกัน. เมื่อคุณกำลังนำเสนอ, คุณสามารถใช้ Zoom เพื่อไปจากตำแหน่งหนึ่งไปยังอีกตำแหน่งหนึ่งในลำดับใดก็ได้ตามที่คุณต้องการ. คุณสามารถสร้างสรรค์, ข้ามหน้า, หรือกลับมาที่ส่วนต่าง ๆ ของการสไลด์โชว์โดยไม่ขัดจังหวะการไหลของการนำเสนอ.

![overview_image](sumzoomsel.png)

สำหรับวัตถุ Summary Zoom, Aspose.Slides มีคลาส **SummaryZoomFrame**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/summaryzoomframe/)), **SummaryZoomSection**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/summaryzoomsection/)), **SummaryZoomSectionCollection**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/summaryzoomsectioncollection/)) และเมธอดบางอย่างในคลาส **ShapeCollection**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/))  

### **สร้าง Summary Zoom**

คุณสามารถเพิ่ม Summary Zoom Frame ไปยังสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. สร้างสไลด์ใหม่พร้อมพื้นหลังระบุตัวและส่วนใหม่สำหรับสไลด์ที่สร้าง.
3. เพิ่ม Summary Zoom Frame ไปยังสไลด์แรก.
4. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP นี้แสดงวิธีสร้าง Summary Zoom Frame บนสไลด์:

```php
  $pres = new Presentation();
  try {
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 1", $slide);
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 2", $slide);
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 3", $slide);
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 4", $slide);
    # เพิ่มอ็อบเจ็กต์ SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # บันทึกงานนำเสนอ
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **เพิ่มและลบ Summary Zoom Section**

ทุกส่วนใน Summary Zoom Frame จะถูกแทนด้วยอ็อบเจ็กต์ **SummaryZoomSection** ที่จัดเก็บอยู่ในอ็อบเจ็กต์ **SummaryZoomSectionCollection**. คุณสามารถเพิ่มหรือลบอ็อบเจ็กต์ Summary Zoom Section ผ่านคลาส **SummaryZoomSectionCollection** ได้โดยทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. สร้างสไลด์ใหม่พร้อมพื้นหลังระบุตัวและส่วนใหม่สำหรับสไลด์ที่สร้าง.
3. เพิ่ม Summary Zoom Frame ไปยังสไลด์แรก.
4. เพิ่มสไลด์และส่วนใหม่ไปยังการนำเสนอ.
5. เพิ่มส่วนที่สร้างลงใน Summary Zoom Frame.
6. ลบส่วนแรกออกจาก Summary Zoom Frame.
7. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP นี้แสดงวิธีเพิ่มและลบส่วนใน Summary Zoom Frame:

```php
  $pres = new Presentation();
  try {
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 1", $slide);
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 2", $slide);
    # เพิ่มอ็อบเจ็กต์ SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # เพิ่มส่วนลงใน Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # ลบส่วนออกจาก Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # บันทึกงานนำเสนอ
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ฟอร์แมต Summary Zoom Section**

เพื่อสร้างอ็อบเจ็กต์ Summary Zoom Section ที่ซับซ้อนมากขึ้น, คุณต้องปรับเปลี่ยนการฟอร์แมตของเฟรมอย่างง่าย. มีตัวเลือกการฟอร์แมตหลายอย่างที่คุณสามารถใช้กับอ็อบเจ็กต์ Summary Zoom Section.

คุณสามารถควบคุมการฟอร์แมตของอ็อบเจ็กต์ Summary Zoom Section ใน Summary Zoom Frame ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. สร้างสไลด์ใหม่พร้อมพื้นหลังระบุตัวและส่วนใหม่สำหรับสไลด์ที่สร้าง.
3. เพิ่ม Summary Zoom Frame ไปยังสไลด์แรก.
4. ดึงอ็อบเจ็กต์ Summary Zoom Section ตัวแรกจาก `SummaryZoomSectionCollection`.
7. สร้างอ็อบเจ็กต์ **PPImage**([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)) โดยเพิ่มภาพลงในคอลเลกชัน Images ของอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่จะใช้เติมกรอบ.
8. ตั้งค่าภาพกำหนดเองสำหรับอ็อบเจ็กต์ Section Zoom ที่สร้าง.
9. ตั้งค่าความสามารถ *กลับไปยังสไลด์ต้นฉบับจากส่วนที่เชื่อมโยง*.
11. เปลี่ยนรูปแบบเส้นสำหรับอ็อบเจ็กต์ Zoom Frame ที่สอง.
12. เปลี่ยนระยะเวลาเปลี่ยนฉาก.
13. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP นี้แสดงวิธีเปลี่ยนการฟอร์แมตของอ็อบเจ็กต์ Summary Zoom Section:

```php
  $pres = new Presentation();
  try {
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 1", $slide);
    # เพิ่มสไลด์ใหม่ในงานนำเสนอ
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # เพิ่ม Section ใหม่ในงานนำเสนอ
    $pres->getSections()->addSection("Section 2", $slide);
    # เพิ่มอ็อบเจ็กต์ SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # ดึงอ็อบเจ็กต์ SummaryZoomSection ตัวแรก
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # การจัดรูปแบบสำหรับอ็อบเจ็กต์ SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # บันทึกงานนำเสนอ
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**ฉันสามารถควบคุมการกลับไปยังสไลด์ “แม่” หลังจากแสดงเป้าหมายได้หรือไม่?**

ใช่. Zoom Frame([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/zoomframe/)) หรือ Section([ลิงก์](https://reference.aspose.com/slides/th/php-java/aspose.slides/sectionzoomframe/)) มีพฤติกรรม `ReturnToParent` ซึ่งเมื่อเปิดใช้งานจะส่งผู้ชมกลับไปยังสไลด์ต้นทางหลังจากเยี่ยมชมเนื้อหาเป้าหมาย.

**ฉันสามารถปรับ “ความเร็ว” หรือระยะเวลาในการเปลี่ยนฉากของ Zoom ได้หรือไม่?**

ใช่. Zoom รองรับการตั้งค่า `TransitionDuration` เพื่อให้คุณควบคุมระยะเวลาการกระโดดของแอนิเมชัน.

**การนำเสนอสามารถมีวัตถุ Zoom ได้กี่ตัว? มีขีดจำกัดหรือไม่?**

ไม่มีขีดจำกัด API ที่ระบุอย่างชัดเจน. ขีดจำกัดเชิงปฏิบัติจะแตกต่างตามความซับซ้อนของการนำเสนอและประสิทธิภาพของผู้ชม. คุณสามารถเพิ่ม Zoom Frame ได้จำนวนมาก, แต่ควรคำนึงถึงขนาดไฟล์และเวลาเรนเดอร์.