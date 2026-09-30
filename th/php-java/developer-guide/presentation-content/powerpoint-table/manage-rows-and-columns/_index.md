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
- ทำสำเนาแถว
- ทำสำเนาคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความของแถว
- การจัดรูปแบบข้อความของคอลัมน์
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides for PHP via Java และเร่งการแก้ไขการนำเสนอและการอัปเดตข้อมูล."
---
## **บทนำ**

Aspose.Slides for PHP via Java ให้คุณจัดการโครงสร้างและการจัดรูปแบบของตารางในงานนำเสนอ PowerPoint ผ่านคลาส [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) คุณสามารถกำหนดแถวหัวเรื่อง, ทำสำเนาหรือเอาแถวและคอลัมน์ออก, และใช้การจัดรูปแบบข้อความกับทั้งหมดของแถวหรือคอลัมน์ได้

บทความนี้อธิบายการดำเนินการเหล่านี้ด้วยตัวอย่าง PHP นอกจากนี้ยังแสดงวิธีดึงสไตล์พรีเซ็ตของตารางเพื่อให้คุณสามารถนำกลับมาใช้ใหม่ได้ ดัชนีแถวและคอลัมน์ของตารางเป็นศูนย์ฐาน

## **ควบคุมความสูงของแถว**

ใช้ [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) เพื่อกำหนดความสูงขั้นต่ำของแถวเป็นหน่วยจุด เป็นขอบเขตล่าง ไม่ใช่ความสูงคงที่ [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) จะคืนค่าความสูงจริง เข้าถึงแถวผ่าน [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/)

ตัวอย่างโหลดไฟล์ [row-height-input.pptx](row-height-input.pptx) ซึ่งมีตารางเป็นรูปร่างแรกบนสไลด์แรก แถวแรกเริ่มที่ 70 จุด เซลล์ใช้ข้อความ Arial ขนาด 18 จุด มีการตัดบรรทัดและขอบบน‑ล่าง 6 จุด; ข้อความยาวในคอลัมน์ที่สองตัดบรรทัดหลายบรรทัด ตัวอย่างเพิ่มค่าขั้นต่ำเป็น 100 จุด แล้วลดลงเป็น 20 จุด พิมพ์ความสูงจริงหลังแต่ละการเปลี่ยนแปลงและบันทึกผลลัพธ์ทั้งสอง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ด้วยงานนำเสนอที่ให้มา การเพิ่มค่าขั้นต่ำจะเพิ่มพื้นที่ให้กับแถว การลดค่าขั้นต่ำจะลบพื้นที่พิเศษนั้นออก แต่ความสูงจริงยังคงมากกว่า 20 จุดเนื่องจากข้อความและขอบของเซลล์ต้องการพื้นที่เพิ่มเติม การลดค่าขั้นต่ำอย่างเดียวไม่สามารถบังคับให้แถวสั้นกว่าพื้นที่ที่เนื้อหาต้องการได้

ปัจจัยหลายอย่างมีผลต่อความสูงจริง:

- **ข้อความและขนาดฟอนต์:** ข้อความยาว, การตัดบรรทัดอย่างชัดเจน, หรือฟอนต์ใหญ่กว่าอาจต้องการพื้นที่แนวตั้งเพิ่มขึ้น
- **การตัดบรรทัดและความกว้างคอลัมน์:** เมื่อเปิดการตัดบรรทัดไว้ การลดความกว้างคอลัมน์ด้วย [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) สามารถทำให้เกิดบรรทัดเพิ่มขึ้น คอลัมน์กว้างขึ้นอาจลดพื้นที่ที่ต้องการในแนวตั้ง
- **ขอบของเซลล์:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) และ [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) เพิ่มพื้นที่แนวตั้ง [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) และ [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) ลดความกว้างที่ใช้สำหรับข้อความและอาจทำให้ตัดบรรทัดเพิ่ม

สำหรับตารางนี้ที่ไม่มีการรวมเซลล์ เซลล์ที่ต้องการพื้นที่แนวตั้งมากที่สุดจะกำหนดขอบเขตล่างตามเนื้อหาเพื่อทั้งแถว หากต้องการให้แถวสั้นลง คุณอาจต้องย่อตัวข้อความ, ลดขนาดฟอนต์หรือขอบ, หรือขยายคอลัมน์

รูปภาพด้านล่างแสดงตารางเดียวกันในสเกลเดียวกัน ในผลลัพธ์ที่แสดง ความสูงจริงคือ 70, 100 และ 55.2 จุด: แถวสุดท้ายยังคงสูงกว่าค่าขั้นต่ำ 20 จุด การวัดข้อความอาจแตกต่างตามฟอนต์ที่มีในสภาพแวดล้อมของคุณ ดาวน์โหลดผลลัพธ์ที่บันทึกไว้: [เพิ่มค่าต่ำสุด](row-height-increased.pptx) และ [ลดค่าต่ำสุด](row-height-decreased.pptx)

| ต้นฉบับ: ค่าต่ำสุด 70 pt, ความสูงจริง 70 pt | เพิ่มขึ้น: ค่าต่ำสุด 100 pt, ความสูงจริง 100 pt | ลดลง: ค่าต่ำสุด 20 pt, ความสูงจริง 55.2 pt |
| --- | --- | --- |
| ![ตารางต้นฉบับที่มีแถวแรกความสูง 70 pt.](row-height-before.png) | ![ตารางหลังจากเพิ่มค่าต่ำสุดของแถวแรกเป็น 100 pt.](row-height-increased.png) | ![ตารางหลังจากลดค่าต่ำสุดของแถวแรกเป็น 20 pt; ข้อความที่ห่อหุ้มทำให้แถวสูงกว่าค่าต่ำสุด.](row-height-decreased.png) |

## **ตั้งค่าแถวแรกเป็นหัวเรื่อง**

ใช้เมธอด [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) เพื่อทำเครื่องหมายแถวแรกสำหรับการจัดรูปแบบหัวเรื่อง การแสดงผลขึ้นอยู่กับสไตล์ตารางที่ใช้กับตาราง

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เข้าถึงตารางที่เก็บเป็นรูปร่างแรกบนสไลด์
4. เปิดใช้งานการจัดรูปแบบหัวเรื่องสำหรับแถวแรกของมัน
5. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก มันเปิดใช้งานการจัดรูปแบบหัวเรื่องสำหรับแถวแรกและบันทึกเป็น `First_row_header.pptx`

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ทำสำเนาแถวหรือคอลัมน์ของตาราง**

ทำสำเนาแถวหรือคอลัมน์เพื่อใช้งานเนื้อหาและการจัดรูปแบบซ้ำ คุณสามารถเพิ่มเติมสำเนาที่ส่วนท้ายของตารางหรือแทรกที่ตำแหน่งเฉพาะได้

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยเมธอด [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/)
5. ทำสำเนาแถวที่ต้องการ
6. ทำสำเนาคอลัมน์ที่ต้องการ
7. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่างต้องการไฟล์ `Test.pptx` ที่มีอย่างน้อยหนึ่งสไลด์ มันสร้างตารางที่มีสามคอลัมน์และห้าแถว โดยกำหนดขนาดเป็นหน่วยจุด มันเพิ่มสำเนาของแถวแรกและคอลัมน์แรก แล้วแทรกสำเนาของแถวและคอลัมน์ที่สองที่ตำแหน่งดัชนี 3 (ตำแหน่งที่สี่) ตารางที่ได้มีเจ็ดแถวและห้าคอลัมน์ อาร์กิวเมนต์ `false` ปิดการทำสำเนาในแถวหรือคอลัมน์ที่รวมกัน; ตารางนี้ไม่มีเซลล์ที่รวมกัน

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ลบแถวหรือคอลัมน์จากตาราง**

ลบแถวหรือคอลัมน์ที่ไม่ต้องการจากตาราง การลบรายการหนึ่งจะทำให้ดัชนีของแถวหรือคอลัมน์ที่ตามมาถูกเลื่อน

1. สร้างงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยเมธอด [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/)
5. ลบแถวที่สองและคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่างนี้สร้างตารางสามโดยสามและลบแถวและคอลัมน์ที่ดัชนี 1 ทำให้เหลือตารางสองโดยสองในไฟล์ `TestTable_out.pptx` ขนาดเป็นหน่วยจุด อาร์กิวเมนต์ `false` ปิดการลบแถวหรือคอลัมน์ที่รวมกัน; ตารางนี้ไม่มีเซลล์ที่รวมกัน

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **กำหนดการจัดรูปแบบข้อความในระดับแถวของตาราง**

ใช้การจัดรูปแบบข้อความกับแถวทั้งหมดเพื่อให้เซลล์สอดคล้องกัน คุณสามารถตั้งค่าคุณสมบัติฟอนต์, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ใช้ [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) สำหรับแถวแรก
4. ใช้ [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) และ [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) สำหรับแถวแรก
5. ใช้ [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) สำหรับแถวที่สอง
6. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและมีอย่างน้อยสองแถว มันใช้ข้อความขนาด 25 จุด, การจัดชิดขวา, และระยะขอบย่อหน้าขวา 20 จุดกับแถวแรก จากนั้นกำหนดข้อความแนวตั้งในแถวที่สอง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **กำหนดการจัดรูปแบบข้อความในระดับคอลัมน์ของตาราง**

ใช้การจัดรูปแบบข้อความกับคอลัมน์ทั้งหมดเพื่อให้เซลล์สอดคล้องกัน คุณสามารถตั้งค่าคุณสมบัติฟอนต์, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ใช้ [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) สำหรับคอลัมน์แรก
4. ใช้ [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) และ [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) สำหรับคอลัมน์แรก
5. ใช้ [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) สำหรับคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไข

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและมีอย่างน้อยสองคอลัมน์ มันใช้ข้อความขนาด 25 จุด, การจัดชิดขวา, และระยะขอบย่อหน้าขวา 20 จุดกับคอลัมน์แรก จากนั้นกำหนดข้อความแนวตั้งในคอลัมน์ที่สอง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้เมธอด [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) เพื่อดึงพรีเซ็ตที่ใช้กับตารางและนำกลับมาใช้กับตารางอื่น วิธีนี้จะระบุพรีเซ็ตแทนการเขียนทับการจัดรูปแบบของเซลล์แต่ละอัน

ตัวอย่างสร้างตาราง, ใช้ [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1), แล้วอ่านพรีเซ็ตกลับมา มันพิมพ์ค่าจำนวนเต็มที่สอดคล้องกับ `DarkStyle1` และบันทึกตารางในไฟล์ `table.pptx`

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีม/สไตล์ของ PowerPoint กับตารางที่สร้างแล้วได้หรือไม่?**

ใช่ ตารางสืบทอดธีมของสไลด์/เลย์เอาต์/มาสเตอร์ และคุณยังสามารถเขียนทับการเติมสี, เส้นขอบ, และสีข้อความเหนือธีมนั้นได้

**ฉันสามารถจัดเรียงแถวของตารางแบบใน Excel ได้หรือไม่?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือฟิลเตอร์ในตัว คุณต้องจัดเรียงข้อมูลในหน่วยความจำก่อน แล้วค่อยเติมแถวของตารางใหม่ตามลำดับนั้น

**ฉันสามารถใช้คอลัมน์แบบลายเส้น (banded) พร้อมค่าสีที่กำหนดเองสำหรับเซลล์เฉพาะได้หรือไม่?**

ได้ เปิดใช้งานคอลัมน์แบบลายเส้น จากนั้นเขียนทับเซลล์เฉพาะด้วยการจัดรูปแบบท้องถิ่น; การจัดรูปแบบระดับเซลล์มีลำดับความสำคัญเหนือสไตล์ของตาราง