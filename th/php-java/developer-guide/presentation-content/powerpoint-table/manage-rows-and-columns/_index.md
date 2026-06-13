---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย PHP
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/php-java/manage-rows-and-columns/
keywords:
- แถวของตาราง
- คอลัมน์ของตาราง
- แถวแรก
- ส่วนหัวของตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความแถว
- การจัดรูปแบบข้อความคอลัมน์
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อเร่งการแก้ไขการนำเสนอและการอัปเดตข้อมูล."
---
## **บทนำ**

เพื่อให้คุณสามารถจัดการแถวและคอลัมน์ของตารางในงานนำเสนอ PowerPoint, Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/) และชนิดอื่น ๆ อีกหลายประเภท.

## **ตั้งแถวแรกเป็นส่วนหัว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และโหลดงานนำเสนอ.
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. สร้างออบเจ็กต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) แล้วกำหนดให้เป็น null.
4. วนซ้ำผ่านออบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ทั้งหมดเพื่อค้นหาตารางที่เกี่ยวข้อง.
5. ตั้งค่าแถวแรกของตารางเป็นส่วนหัวของตาราง. 

โค้ด PHP นี้แสดงวิธีตั้งค่าแถวแรกของตารางเป็นส่วนหัวของตาราง:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("table.pptx");
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # กำหนดค่าเริ่มต้น TableEx เป็น null
    $tbl = null;
    # วนซ้ำผ่านรูปร่างและตั้งค่าอ้างอิงไปยังตาราง
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # ตั้งค่าแถวแรกของตารางเป็นส่วนหัว
        $tbl->setFirstRow(true);
      }
    }
    # บันทึกการนำเสนอไปยังดิสก์
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และโหลดงานนำเสนอ,
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. กำหนดอาร์เรย์ของ `columnWidth`.
4. กำหนดอาร์เรย์ของ `rowHeight`.
5. เพิ่มออบเจ็กต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) ลงในสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addtable/).
6. คัดลอกแถวของตาราง.
7. คัดลอกคอลัมน์ของตาราง.
8. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด PHP นี้แสดงวิธีคัดลอกแถวหรือคอลัมน์ของตาราง PowerPoint:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # เพิ่มรูปร่างตารางลงบนสไลด์
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # เพิ่มข้อความบางส่วนลงในแถว 1 เซลล์ 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # เพิ่มข้อความบางส่วนลงในแถว 1 เซลล์ 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # คัดลอกแถว 1 ไปยังท้ายตาราง
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # เพิ่มข้อความบางส่วนลงในแถว 2 เซลล์ 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # เพิ่มข้อความบางส่วนลงในแถว 2 เซลล์ 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # คัดลอกแถว 2 เป็นแถวที่ 4 ของตาราง
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # คัดลอกคอลัมน์แรกไปยังตำแหน่งสุดท้าย
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # คัดลอกคอลัมน์ที่ 2 ไปยังตำแหน่งคอลัมน์ที่ 4
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # บันทึกการนำเสนอไปยังดิสก์
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบแถวหรือคอลัมน์ออกจากตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และโหลดงานนำเสนอ,
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. กำหนดอาร์เรย์ของ `columnWidth`.
4. กำหนดอาร์เรย์ของ `rowHeight`.
5. เพิ่มออบเจ็กต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) ลงในสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addtable/).
6. ลบแถวของตาราง.
7. ลบคอลัมน์ของตาราง.
8. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ด PHP นี้แสดงวิธีลบแถวหรือคอลัมน์ออกจากตาราง:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับแถวของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และโหลดงานนำเสนอ,
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. เข้าถึงออบเจ็กต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) ที่เกี่ยวข้องจากสไลด์.
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setFontHeight) ของเซลล์ในแถวแรก.
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setalignment/) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setmarginright/) ของเซลล์ในแถวแรก.
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/settextverticaltype/) ของเซลล์ในแถวที่สอง.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด PHP นี้แสดงการทำงาน.

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # ตั้งค่าความสูงของฟอนต์ในเซลล์แถวแรก
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาของเซลล์แถวแรก
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # ตั้งค่าชนิดข้อความแนวตั้งของเซลล์แถวที่สอง
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # บันทึกการนำเสนอไปยังดิสก์
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และโหลดงานนำเสนอ,
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. เข้าถึงออบเจ็กต์ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/Table) ที่เกี่ยวข้องจากสไลด์.
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setFontHeight) ของเซลล์ในคอลัมน์แรก.
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setalignment/) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setmarginright/) ของเซลล์ในคอลัมน์แรก.
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/settextverticaltype/) ของเซลล์ในคอลัมน์ที่สอง.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ด PHP นี้แสดงการทำงาน:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # ตั้งค่าความสูงของฟอนต์ในเซลล์คอลัมน์แรก
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาของเซลล์คอลัมน์แรกด้วยคำสั่งเดียว
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # ตั้งค่าชนิดข้อความแนวตั้งของเซลล์คอลัมน์ที่สอง
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ทำให้คุณสามารถดึงคุณสมบัติสไตล์ของตารางเพื่อที่คุณจะใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือในที่อื่นได้ โค้ด PHP นี้แสดงวิธีรับคุณสมบัติสไตล์จากสไตล์สำเร็จรูปของตาราง:

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

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีม/สไตล์ของ PowerPoint กับตารางที่สร้างไว้แล้วได้หรือไม่?**

ได้ ตารางจะสืบทอดธีมของสไลด์/เลย์เอาต์/มาสเตอร์ และคุณยังสามารถเขียนทับสีพื้น, เส้นขอบ, และสีข้อความเหนือธีมนั้นได้.

**ฉันสามารถจัดเรียงแถวของตารางแบบใน Excel ได้หรือไม่?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือกรองในตัว คุณต้องจัดเรียงข้อมูลในหน่วยความจำก่อน แล้วจึงเติมแถวของตารางใหม่ตามลำดับนั้น.

**ฉันสามารถมีคอลัมน์เป็นแถบ (striped) พร้อมกับคงสีที่กำหนดเองในเซลล์เฉพาะได้หรือไม่?**

ได้ เปิดคอลัมน์แบบแถบ จากนั้นเขียนทับเซลล์เฉพาะด้วยการจัดรูปแบบท้องถิ่น; การจัดรูปแบบระดับเซลล์จะมีความสำคัญเหนือสไตล์ของตาราง.