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
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ค้นพบตัวอย่างโค้ดอย่างง่ายเพื่อเพิ่มประสิทธิภาพกระบวนการทำงานกับตารางของคุณ"
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล ข้อมูลในตารางที่ประกอบด้วยเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) มีความชัดเจนและเข้าใจง่าย

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) , [Cell](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/) และประเภทอื่น ๆ ที่ช่วยให้คุณสร้าง, แก้ไขและจัดการตารางในงานนำเสนอทุกประเภท

## **Create a Table from Scratch**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาเรย์ของ `columnWidth`  
4. กำหนดอาเรย์ของ `rowHeight`  
5. เพิ่มออบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/) ลงในสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addtable/)  
6. วนผ่านแต่ละ [Cell](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/) เพื่อกำหนดรูปแบบเส้นขอบด้านบน, ด้านล่าง, ด้านขวาและด้านซ้าย  
7. รวมสองเซลล์แรกของแถวแรกในตาราง  
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ [Cell](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/)  
9. เพิ่มข้อความใน [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/)  
10. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด PHP นี้แสดงวิธีสร้างตารางในงานนำเสนอ:

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
    # รวมเซลล์ที่ 1 และ 2 ของแถวที่ 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # เพิ่มข้อความบางส่วนลงในเซลล์ที่รวมกัน
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numbering in a Standard Table**

ในตารางมาตรฐาน การจัดลำดับหมายเลขของเซลล์เป็นการนับจากศูนย์ เซลล์แรกในตารางมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0)  

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกนับดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด PHP นี้แสดงวิธีระบุลำดับหมายเลขของเซลล์ในตาราง:

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
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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

## **Access an Existing Table**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ที่มีตารางผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) แล้วตั้งค่าเป็น null  
4. วนผ่านออบเจกต์ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ทั้งหมดจนกว่าจะพบตาราง  

   หากคุณสงสัยว่ารูปที่กำลังทำงานอยู่มีเพียงตารางเดียว คุณสามารถตรวจสอบรูปทั้งหมดที่มันมีได้ เมื่อรูปถูกระบุว่าเป็นตาราง คุณสามารถแคสต์เป็นอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) แต่หากสไลด์มีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่าน [setAlternativeText(String value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/setalternativetext/)  

5. ใช้อ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราเพิ่มแถวใหม่ให้กับตาราง  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด PHP นี้แสดงวิธีเข้าถึงและทำงานกับตารางที่มีอยู่:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # กำหนดค่าเริ่มต้นให้ TableEx เป็น null
    $tbl = null;
    # วนลูปผ่านรูปร่างทั้งหมดและตั้งค่าอ้างอิงไปยังตารางที่พบ
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
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

## **Find the Cell That Owns a Text Frame**

เมื่อโค้ดประมวลผลข้อความทั่วไปได้รับออบเจกต์ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) จากตาราง ให้ใช้เมธอด [TextFrame::getParentCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentCell) เพื่อดึง [Cell](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/) เจ้าของ สำหรับ TextFrame ของเซลล์ตาราง, [TextFrame::getParentCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentCell) จะคืนค่าเจ้าของและ [TextFrame::getParentShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentShape) จะคืนค่า `null` แม้ว่าตารางเองเป็น Shape  

พิกัดเซลล์สามารถเข้าถึงได้ผ่านเมธอดอ่าน‑เท่านั้น [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/#getFirstColumnIndex) และ [Cell::getFirstRowIndex](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/#getFirstRowIndex)  [TextFrame::getParentCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentCell) ยังให้การนำทางแบบอ่าน‑เท่านั้น: มันคืนค่าเจ้าของแต่ไม่เปลี่ยนความเป็นเจ้าของ ตรวจสอบว่าเซลล์ที่คืนมาไม่ใช่ `java_is_null` ก่อนใช้งานเสมอ  

สำหรับตัวอย่างสมบูรณ์ที่ระบุเจ้าของของเซลล์ตารางและ Shape รวมถึง Shape ที่เชื่อมโยงกับโหนด SmartArt ให้ดูที่ [Search and Replace Text](/slides/th/php-java/search-and-replace-text/)

## **Align Text in a Table**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) ลงในสไลด์  
4. เข้าถึงอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) จากตาราง  
5. เข้าถึง [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/)  
6. จัดแนวข้อความในแนวตั้ง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด PHP นี้แสดงวิธีจัดแนวข้อความในตาราง:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
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

## **Set Text Formatting on the Table Level**

1. สร้างอินสแตนซ์ของ คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) จากสไลด์  
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setFontHeight) สำหรับข้อความ  
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setalignment/) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setmarginright/)  
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/settextverticaltype/)  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด PHP นี้แสดงวิธีปรับใช้ตัวเลือกการจัดรูปแบบที่คุณต้องการให้กับข้อความในตาราง:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # สมมติว่า shape แรกบนสไลด์แรกเป็นตาราง
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # ตั้งค่าความสูงของฟอนต์ในเซลล์ตาราง
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # ตั้งค่าการจัดแนวข้อความและระยะขวาของเซลล์ตารางในหนึ่งคำสั่ง
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # ตั้งค่าชนิดการวางแนวข้อความในแนวตั้งของเซลล์ตาราง
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

## **Get Table Style Properties**

Aspose.Slides ให้คุณดึงคุณสมบัติลักษณะของตารางเพื่อใช้กับตารางอื่นหรือในที่อื่น โค้ด PHP นี้แสดงวิธีดึงคุณสมบัติสไตล์จากตารางที่ใช้สไตล์กำหนดล่วงหน้า:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// เปลี่ยนธีมสไตล์พรีเซ็ตเริ่มต้น

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lock Aspect Ratio of a Table**

อัตราส่วนของรูปร่างเรขาคณิตคือสัดส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีเมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) เพื่อให้คุณล็อกการตั้งค่าอัตราส่วนสำหรับตารางและรูปร่างอื่น ๆ  

โค้ด PHP นี้แสดงวิธีล็อกอัตราส่วนของตาราง:

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

## **FAQ**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับทั้งตารางและข้อความในเซลล์ได้หรือไม่?**  
ใช่ ตารางเปิดเผยเมธอด [setRightToLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/setrighttoleft/) และพารากราฟมี [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setrighttoleft/) การใช้ทั้งสองจะทำให้ลำดับ RTL ถูกต้องและแสดงผลภายในเซลล์ได้ถูกต้อง  

**ฉันจะป้องกันผู้ใช้จากการย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**  
ใช้การล็อกรูปเพื่อปิดการย้าย, ปรับขนาด, เลือก ฯลฯ การล็อกเหล่านี้ใช้ได้กับตารางเช่นกัน  

**การแทรกรูปภาพเป็นพื้นหลังภายในเซลล์ได้รับการสนับสนุนหรือไม่?**  
ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) ให้กับเซลล์ได้ ภาพจะครอบพื้นที่เซลล์ตามโมดที่เลือก (ขยายหรือเปลี่ยนเป็นกระเบื้อง)  