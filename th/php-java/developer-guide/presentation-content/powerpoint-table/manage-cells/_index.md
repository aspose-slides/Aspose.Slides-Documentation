---
title: จัดการเซลล์ตารางในงานนำเสนอโดยใช้ PHP
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/php-java/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบเส้นขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย PHP: ระบุเซลล์ที่รวมแล้ว, ลบเส้นขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีระบุเซลล์ที่รวมแล้ว, ลบเส้นขอบเซลล์, ทำงานกับการจัดลำดับเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างจะแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีเริ่มต้นจากศูนย์เพื่อเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`  

## **ระบุเซลล์ตารางที่รวมแล้ว**

ตัวอย่างจะเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกในรูปแบบตาราง สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นตาราง จากนั้นจะวนลูปผ่านแถวและคอลัมน์ทั้งหมดและใช้ [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) เพื่อระบุเซลล์ในพื้นที่ที่รวมไว้ สำหรับแต่ละผลลัพธ์จะแสดงพิกัดเซลล์ในรูปแบบ `row;column` พร้อมกับ [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), และพิกัดเริ่มต้นของพื้นที่นั้น ได้แก่ [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) และ [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/)

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **ลบเส้นขอบเซลล์ตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกของมันด้วย [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). ความกว้างของคอลัมน์, ความสูงของแถว, และตำแหน่งของตารางระบุเป็นจุด ตัวอย่างตั้งค่าเส้นขอบสี่ด้านของเซลล์ทั้งหมดให้เป็น [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), ทำให้เส้นขอบไม่มองเห็น

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เพิ่มเส้นขอบแนวทแยงของเซลล์**

ใช้ [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) เพื่อวาดเส้นจากมุมซ้ายบนไปยังมุมขวาล่าง, และ [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) เพื่อวาดเส้นจากมุมซ้ายล่างไปยังมุมขวา แนวทแยงสามารถทำเครื่องหมายหัวข้อหัวมุม; ทั้งสองแนวสามารถสร้างรูป X เพื่อบ่งชี้ว่าเซลล์ไม่ใช้ได้

แต่ละแนวทแยงมี [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) ของตนเอง ใน [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) ให้ใช้ [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) เพื่อเลือก [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) และเลือกสีด้วย [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). ตั้งค่าความกว้างของเส้นเป็นจุดด้วย [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/)

ตัวอย่างสร้างเซลล์สามเซลล์ในแถวเดียว: แนวทแยงลงสีแดง, แนวทแยงขึ้นสีฟ้า, และทั้งสองแนวพร้อมกัน เส้นขอบด้านบน, ด้านล่าง, ซ้าย, และขวาจะคงไว้ตามเดิม

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

แนวทแยงเปลี่ยนเฉพาะรูปแบบของเซลล์เท่านั้น แต่ละเซลล์ยังคงมีกรอบข้อความเดียวที่เข้าถึงได้ผ่าน [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). พื้นที่ทางสองข้างของแนวทแยงไม่สามารถแก้ไขแยกกันได้

ตารางที่บันทึกแล้ว แสดงใน Microsoft PowerPoint:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*ซ้ายไปขวา: แนวทแยงลง (สีแดง, 3 pt), แนวทแยงขึ้น (สีฟ้า, 5 pt) และทั้งสองแนวทแยงสร้างรูป X*  

## **รวมเซลล์ตาราง**

ใช้ [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางเป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง อาร์กิวเมนต์สุดท้ายควบคุมว่า การรวมอาจรวมเซลล์ที่อยู่นอกช่วงที่ระบุหรือไม่; `false` ทำให้การรวมอยู่ภายในช่วงเท่านั้น

ตัวอย่างสร้างตารางขนาด 4x4 มีคอลัมน์และแถวขนาด 70 จุด, จากนั้นรวมเซลล์ศูนย์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)`. เซลล์ที่ได้ครอบคลุมสองคอลัมน์และสองแถว ในขณะที่กริดพื้นฐานของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหา หรือรูปแบบของเซลล์ที่รวมไว้ ให้ใช้ตำแหน่งซ้ายบน: `$table->get_Item(1, 1)` ในตัวอย่างนี้ ตำแหน่งอื่น ๆ ในช่วงที่รวมยังคงเป็นส่วนหนึ่งของกริดตาราง ดังนั้นดัชนีของเซลล์นอกช่วงจะไม่เปลี่ยน

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **แยกเซลล์ตาราง**

การรวมเซลล์ในตัวอย่างก่อนหน้าเก็บกริดของตารางไว้ การแยกเซลล์อาจเพิ่มคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ที่อยู่ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของ PowerPoint

ตัวอย่างนี้สร้างตาราง 4x4 ที่คอลัมน์และแถวขนาด 70 จุดและเรียก [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) บนเซลล์ `(1, 1)`. ความกว้าง 70 จุดของเซลล์ถูกแบ่งครึ่งเพื่อสร้างสองเซลล์ที่มีความกว้างเท่ากัน

หลังจากแยกนี้ ครึ่งสองส่วนจะเข้าถึงโดย `$table->get_Item(1, 1)` และ `$table->get_Item(2, 1)`. กริดตารางตอนนี้มีห้าคอลัมน์: เซลล์ที่อยู่ในคอลัมน์ที่ 2 และ 3 เดิมจะย้ายไปที่คอลัมน์ที่ 3 และ 4 ตามลำดับ ดัชนีแถวคงที่ ใช้ดัชนีคอลัมน์ที่อัปเดตนี้เมื่อต้องเข้าถึงเซลล์หลังการแยก

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![เซลล์ที่ไม่ได้รวมขนาด 70 จุด แบ่งเป็นสองเซลล์ขนาด 35 จุด เพิ่มคอลัมน์กริดที่ห้าที่ทำให้ดัชนีของด้านขวาเปลี่ยนตำแหน่ง.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*การแยกความกว้างส่งผลต่อเซลล์ (1, 1) โดยใช้ดัชนี (คอลัมน์, แถว) เริ่มจากศูนย์ แถวอื่น ๆ คงเซลล์ที่ครอบคลุมตำแหน่งคอลัมน์ใหม่ทั้งสอง*
<!-- visual-explanation:manage-cells:end -->

### **แยกเซลล์ที่รวมแล้วตามช่วงแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์เทมเพลตที่รวมไว้สำหรับการเติมข้อมูล, ใช้ [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) เพื่อแยกตามขอบแถวที่มีอยู่, หรือ [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) เพื่อแยกตามขอบคอลัมน์

อาร์กิวเมนต์ `index` นับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; มีค่าอิงจากพื้นที่ที่รวมไว้:

- แยกแถว: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- แยกคอลัมน์: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

ตัวอย่างสมมติว่ามีงานนำเสนอที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก, โดยเซลล์ `(1, 2)` และ `(1, 3)` รวมกันในแนวตั้ง เริ่มจากตำแหน่งล่าง ใช้ [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) และ [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) เพื่อหาตำแหน่งต้นทางและตรวจสอบทั้งสองช่วง `splitByRowSpan(1)` จะทำให้แยกแถว 2 และ 3 สำหรับชื่อสินค้า สำหรับการรวมสองคอลัมน์ในแนวนอน ให้ใช้ `splitByColSpan(1)` แทน

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // ดึงเซลล์ที่ได้จากตารางหลังจากการแยก.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

กริดของตารางและดัชนีเซลล์รอบข้างคงเดิม ดึงเซลล์ที่ได้โดยใช้พิกัดของมัน; ทั้งสองเซลล์นี้มีช่วงเป็น 1 และ [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) จะพิมพ์ `false`. พื้นที่ใหญ่กว่าอาจยังคงรวมบางส่วนหลังจากการแยกหนึ่งครั้ง

ข้อความและรูปแบบเดิมยังคงอยู่ในเซลล์บน (หรือซ้าย) ส่วนเซลล์ใหม่จะว่างเปล่าแต่สืบทอดรูปแบบเซลล์ เช่น การเติม, เส้นขอบ, และระยะขอบ เติมข้อมูลหลังการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน

งานนำเสนอที่บันทึกไว้มีเซลล์ “Product A” และ “Product B” แยกกันโดยคงรูปแบบของเทมเพลตไว้ ดูรายละเอียดเพิ่มเติมได้ที่ [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)

### **แยกเซลล์ตามความสูงที่กำหนด**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) รับค่าความสูงของส่วนบนเป็นจุด, [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) รับจำนวนแถวกริดที่มีอยู่ในส่วนบน เพื่อวางเซลล์ขนาด 40 จุดตรงกลางคอลัมน์ขวา ให้นำ 40 จากความสูงจริงของเซลล์มาลบและแบ่งส่วนที่เหลือเท่า ๆ กันด้านบนและด้านล่าง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การแยกครั้งแรกเพิ่มแถวกริดและเหลือ 90 จุดในเซลล์ `(1, 1)`. การแยกครั้งที่สองจะแบ่งเซลล์นั้นเป็นเซลล์กลางขนาด 40 จุดและเซลล์ล่างขนาด 50 จุด คอลัมน์ขวา الآن มีสามเซลล์ที่สูง 50, 40, และ 50 จุดจากบนลงล่าง เซลล์ซ้ายครอบคลุมทั้งสามแถวและคงความสูงเดิม 140 จุด

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางที่คอลัมน์ขนาด 150 จุดและแถวขนาด 50 จุด ใช้ [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) เพื่อเลือกการเติมสีทึบและตั้งค่าสีที่คืนจาก [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) ให้เป็นสีแดงสำหรับเซลล์ `(2, 3)`, ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

วางรูปภาพต้นฉบับในไดเรกทอรีทำงานก่อนรันตัวอย่างนี้ ตัวอย่างโหลดรูปด้วย [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) และเพิ่มเข้าไปในคอลเลกชันรูปของงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). จากนั้นกำหนดรูปภาพให้กับการเติมรูปภาพของเซลล์ `(0, 0)`, เซลล์แรกของตาราง

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) ยืดรูปภาพให้เต็มเซลล์ ซึ่งอาจทำให้สัดส่วนแตกต่างกัน ความกว้างคอลัมน์และความสูงแถวระบุเป็นจุด รูปภาพที่โหลดจะถูกทำลายในบล็อก `finally` หลังจากถูกเพิ่มเข้าไปในงานนำเสนอ

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นที่แตกต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ได้. เส้นขอบ [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) มีคุณสมบัติแยกกันจึงสามารถกำหนดความหนาและสไตล์ของแต่ละด้านให้แตกต่างกันได้

**ภาพจะเกิดอะไรขึ้นหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). หากยืดภาพจะปรับตามเซลล์ใหม่; หากทำเป็นกระเบื้อง (tile) กระเบื้องจะถูกคำนวณใหม่

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/php-java/manage-hyperlinks/) ถูกกำหนดระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือระดับของตาราง/รูปร่างทั้งหมด ในการปฏิบัติจริงคุณจะกำหนดลิงก์ให้กับส่วนหนึ่งหรือทั้งหมดของข้อความในเซลล์

**ฉันสามารถตั้งฟอนต์ที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ได้. กรอบข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (run) ที่มีการจัดรูปแบบอิสระ — ครอบครัวฟอนต์, สไตล์, ขนาด, และสี.