---
title: จัดการตารางการนำเสนอใน PHP
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/php-java/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วน
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- พาวเวอร์พอยท์
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ค้นพบตัวอย่างโค้ดง่าย ๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระบบและรวดเร็วขึ้น"
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและนำเสนอข้อมูล ข้อมูลในตารางของเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) มีความชัดเจนและเข้าใจง่าย

Aspose.Slides ให้คลาส [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) , คลาส [Cell](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/) และประเภทอื่น ๆ เพื่อให้คุณสร้าง, ปรับปรุง, และจัดการตารางในงานนำเสนอทุกประเภท

## **สร้างตารางตั้งแต่ต้น**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
2. รับการอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. กำหนดอาร์เรย์ของ `columnWidth` 
4. กำหนดอาร์เรย์ของ `rowHeight` 
5. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/) ลงในสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addtable/) 
6. วนซ้ำผ่านแต่ละ [Cell](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/) เพื่อกำหนดรูปแบบให้กับเส้นขอบด้านบน, ด้านล่าง, ขวา, และซ้าย 
7. รวมสองเซลล์แรกของแถวแรกของตาราง 
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ [Cell](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/) 
9. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) 
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # เพิ่มรูปร่างตารางลงในสไลด์
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # ผสานเซลล์ที่ 1 และ 2 ของแถวที่ 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # เพิ่มข้อความบางส่วนลงในเซลล์ที่ผสานแล้ว
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **การหมายเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน การกำหนดหมายเลขของเซลล์ทำได้ง่ายและใช้ศูนย์เป็นจุดเริ่มต้น เซลล์แรกในตารางจะมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0)

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกหมายเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # เพิ่มรูปร่างตารางลงในสไลด์
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
2. รับการอ้างอิงสไลด์ที่มีตารางผ่านดัชนีของมัน 
3. สร้างอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) และตั้งค่าเป็น null 
4. วนซ้ำผ่านอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ทั้งหมดจนกว่าจะพบตาราง  

   หากคุณสงสัยว่าสไลด์ที่ทำงานอยู่มีตารางเดียว คุณสามารถตรวจสอบรูปทรงทั้งหมดที่สไลด์ประกอบอยู่ เมื่อรูปทรงถูกระบุว่าเป็นตาราง คุณสามารถทำการแคสต์เป็นอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) ได้ แต่หากสไลด์มีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่าน [setAlternativeText(String value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/setalternativetext/) 
5. ใช้อ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราได้เพิ่มแถวใหม่ลงในตาราง 
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # กำหนดค่าเริ่มต้นให้ TableEx เป็น null
    $tbl = null;
    # วนลูปผ่านรูปทรงและตั้งค่าการอ้างอิงไปยังตารางที่พบ
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # ตั้งค่าข้อความสำหรับคอลัมน์แรกของแถวที่สอง
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **จัดแนวข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
2. รับการอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) ลงในสไลด์ 
4. เข้าถึงอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) จากตาราง 
5. เข้าถึง [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) 
6. จัดแนวข้อความในแนวตั้ง 
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # เพิ่มรูปร่างตารางลงในสไลด์
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # เข้าถึง TextFrame
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # สร้างอ็อบเจกต์ Paragraph สำหรับ TextFrame
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # จัดแนวข้อความในแนวตั้ง
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
2. รับการอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เข้าถึงอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) จากสไลด์ 
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setFontHeight) สำหรับข้อความ 
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setalignment/) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setmarginright/) 
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/settextverticaltype/) 
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

```php
  # สร้างอินสแทนซ์ของคลาส Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # ตั้งค่าความสูงของฟอนต์สำหรับเซลล์ตาราง
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # ตั้งค่าการจัดแนวข้อความและระยะขอบขวาของเซลล์ตารางในหนึ่งคำสั่ง
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # ตั้งค่าชนิดการวางข้อความในแนวตั้งของเซลล์ตาราง
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ให้คุณเรียกคืนคุณสมบัติสไตล์ของตารางเพื่อที่คุณจะใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือที่อื่น โค้ด PHP นี้แสดงวิธีการรับคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดล่วงหน้า:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// เปลี่ยนธีม preset สไตล์เริ่มต้น

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงเรขาคณิตคืออัตราส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีเมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) เพื่อให้คุณล็อกการตั้งค่าอัตราส่วนสำหรับตารางและรูปทรงอื่น ๆ

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ของมันได้หรือไม่?**

ใช่ ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/setrighttoleft/) และย่อหน้ามี [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setrighttoleft/) การใช้ทั้งสองทำให้แน่ใจว่าลำดับ RTL ถูกต้องและการเรนเดอร์ภายในเซลล์

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้การล็อกรูปทรงเพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ การล็อกเหล่านี้ใช้กับตารางด้วย

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) สำหรับเซลล์; รูปภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ขยายหรือเรียงรูปต่อเนื่อง)