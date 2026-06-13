---
title: จัดการเซลล์ตารางในงานนำเสนอโดยใช้ PHP
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/php-java/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการเซลล์ตารางใน PowerPoint อย่างง่ายดายด้วย Aspose.Slides สำหรับ PHP. เชี่ยวชาญการเข้าถึง, แก้ไข, และจัดรูปแบบเซลล์อย่างรวดเร็วเพื่อการทำงานอัตโนมัติของสไลด์ที่ราบรื่น."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีการระบุเซลล์ตารางที่รวมกัน, ลบขอบเซลล์, ทำงานกับการนัมเบอร์ของเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างจะแสดงวิธีการสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ระบุเซลล์ตารางที่รวมกัน**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
2. รับตารางจากสไลด์แรก 
3. วนซ้ำผ่านแถวและคอลัมน์ของตารางเพื่อค้นหาเซลล์ที่รวม 
4. พิมพ์ข้อความเมื่อพบเซลล์ที่รวม

โค้ด PHP นี้แสดงวิธีระบุเซลล์ตารางที่รวมกันในงานนำเสนอ:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// สมมติว่า Slide#0.Shape#0 เป็นตาราง

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบขอบเซลล์ตาราง**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง 
4. กำหนดอาเรย์ของแถวพร้อมความสูง 
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addTable) 
6. วนซ้ำผ่านทุกเซลล์เพื่อลบขอบบน, ล่าง, ขวา, และซ้าย 
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด PHP นี้แสดงวิธีลบขอบจากเซลล์ตาราง:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # เพิ่มรูปร่างตารางลงในสไลด์
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # กำหนดรูปแบบขอบสำหรับแต่ละเซลล์
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **การจัดลำดับเลขในเซลล์ที่รวม**
หากเรารวมเซลล์ 2 คู่ (1, 1) x (2, 1) และ (1, 2) x (2, 2) ตารางที่ได้จะมีการนัมเบอร์ โค้ด PHP นี้แสดงกระบวนการ:

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
    # กำหนดรูปแบบขอบสำหรับแต่ละเซลล์
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
    # รวมเซลล์ (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # รวมเซลล์ (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

จากนั้นเราจะรวมเซลล์ต่อโดยรวม (1, 1) และ (1, 2) ผลลัพธ์คือตารางที่มีเซลล์ใหญ่ที่รวมอยู่ตรงกลาง:

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
    # กำหนดรูปแบบขอบสำหรับแต่ละเซลล์
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
    # รวมเซลล์ (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # รวมเซลล์ (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # รวมเซลล์ (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **การจัดลำดับเลขในเซลล์ที่แยก**
ในตัวอย่างก่อนหน้า เมื่อเซลล์ตารางถูกรวม ระบบการนัมเบอร์หรือเลขในเซลล์อื่น ๆ ไม่เปลี่ยนแปลง

ครั้งนี้เราจะใช้ตารางปกติ (ตารางที่ไม่มีเซลล์ที่รวม) แล้วลองแยกเซลล์ (1,1) เพื่อให้ได้ตารางพิเศษ คุณอาจต้องใส่ใจการนัมเบอร์ของตารางนี้ ซึ่งอาจดูแปลก แต่เป็นวิธีที่ Microsoft PowerPoint นัมเบอร์เซลล์ตารางและ Aspose.Slides ทำเช่นเดียวกัน

โค้ด PHP นี้แสดงกระบวนการที่อธิบาย:

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
    # กำหนดรูปแบบขอบสำหรับแต่ละเซลล์
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
    # รวมเซลล์ (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # รวมเซลล์ (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # แยกเซลล์ (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

โค้ด PHP นี้แสดงวิธีเปลี่ยนสีพื้นหลังของเซลล์ตาราง:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # สร้างตารางใหม่
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # ตั้งค่าสีพื้นหลังสำหรับเซลล์
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **เพิ่มรูปภาพภายในเซลล์ตาราง**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง 
4. กำหนดอาเรย์ของแถวพร้อมความสูง 
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด [AddTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addTable) 
6. สร้างอ็อบเจ็กต์ `Images` เพื่อเก็บไฟล์รูปภาพ 
7. เพิ่มรูปภาพ `IImage` ไปยังอ็อบเจ็กต์ `IPPImage` 
8. ตั้งค่า `FillFormat` ของเซลล์ตารางเป็น `Picture` 
9. เพิ่มรูปภาพลงในเซลล์แรกของตาราง 
10. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด PHP นี้แสดงวิธีวางรูปภาพภายในเซลล์ตารางเมื่อสร้างตาราง:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $islide = $pres->getSlides()->get_Item(0);
    # กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # เพิ่มรูปร่างตารางลงในสไลด์
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # สร้างอ็อบเจ็กต์ IPPImage ด้วยไฟล์ภาพ
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # เพิ่มภาพลงในเซลล์ตารางที่แรก
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นที่แตกต่างสำหรับแต่ละด้านของเซลล์เดียวได้ไหม?**

ได้. ขอบ[top](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellformat/getborderright/) มีคุณสมบัติเสียแยกกัน ดังนั้นความหนาและสไตล์ของแต่ละด้านจึงสามารถแตกต่างกันได้ สิ่งนี้สอดคล้องกับการควบคุมขอบตามด้านของเซลล์ที่แสดงในบทความ

**ถ้าฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์ จะเกิดอะไรขึ้นกับรูปภาพ?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillmode/) (stretch/tile) หากใช้การยืดรูปภาพจะปรับให้พอดีกับเซลล์ใหม่; หากใช้การทำซ้ำ (tile) ช่องภาพจะถูกคำนวณใหม่ บทความกล่าวถึงโหมดการแสดงผลรูปภาพในเซลล์

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/php-java/manage-hyperlinks/) สามารถตั้งได้ที่ระดับข้อความ (portion) ภายในเฟรมข้อความของเซลล์หรือที่ระดับของตาราง/รูปร่างทั้งหมด ในการปฏิบัติคุณจะกำหนดลิงก์ให้กับส่วนย่อยหรือทั้งหมดของข้อความในเซลล์

**ฉันสามารถตั้งฟอนต์ที่แตกต่างภายในเซลล์เดียวได้หรือไม่?**

ได้. เฟรมข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) (run) ที่มีการจัดรูปแบบแยกกัน—ฟอนต์, สไตล์, ขนาด, และสี.