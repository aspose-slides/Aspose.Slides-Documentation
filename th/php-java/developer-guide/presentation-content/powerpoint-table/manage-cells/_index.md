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
description: "จัดการเซลล์ตาราง PowerPoint ด้วย PHP: ระบุเซลล์ที่รวม, ลบเส้นขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides ทำให้คุณสามารถเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวม การลบเส้นขอบของเซลล์ การทำงานกับการนับเลขเซลล์หลังจากการรวมหรือการแยกเซลล์ การเปลี่ยนสีพื้นหลังของเซลล์ และการเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างจะแสดงวิธีสร้างหรือเปิดงานนำเสนอ ดึงตารางจากสไลด์ ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์ และบันทึกงานนำเสนอที่ปรับเปลี่ยนเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีที่เริ่มจากศูนย์เพื่อเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`.

## **ระบุเซลล์ตารางที่รวม**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่แล้วและเข้าถึงรูปทรงแรกบนสไลด์แรกเป็นตาราง โดยสมมติว่ามีสไลด์และรูปทรงอยู่และรูปทรงเป็นตาราง จากนั้นวนลูปผ่านทุกแถวและคอลัมน์และใช้ [เซลล์ที่รวม](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) เพื่อระบุเซลล์ในพื้นที่ที่รวม สำหรับแต่ละที่ตรงกันจะแสดงพิกัดเซลล์ในลำดับ `row;column` , [รับช่วงแถว](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [รับช่วงคอลัมน์](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), และพิกัดเริ่มต้นของพื้นที่นั้น, [ดัชนีแถวแรก](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) และ [ดัชนีคอลัมน์แรก](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

สร้าง [งานนำเสนอ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกด้วย [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). ความกว้างคอลัมน์, ความสูงแถว, และตำแหน่งตารางระบุเป็นจุด ตัวอย่างตั้งค่าเส้นขอบสี่ด้านของเซลล์ทั้งหมดเป็น [ไม่มีการเติม](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), ทำให้มองไม่เห็น.

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

## **รวมเซลล์ตาราง**

ใช้ [รวมเซลล์](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางเป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง พารามิเตอร์สุดท้ายควบคุมว่าการรวมอาจรวมเซลล์นอกช่วงที่กำหนดหรือไม่; `false` จะคงการรวมให้อยู่ในช่วงนั้น

ตัวอย่างสร้างตาราง 4x4 ด้วยคอลัมน์และแถวขนาด 70 จุด จากนั้นรวมสี่เซลล์ตรงกลางจาก `(1, 1)` ถึง `(2, 2)`. เซลล์ที่ได้ครอบคลุมสองคอลัมน์และสองแถว ในขณะที่ตารางยังคงมีกริดสี่คอลัมน์สี่แถว เพื่อเข้าถึงเนื้อหา或รูปแบบของเซลล์ที่รวม ให้ใช้ตำแหน่งซ้ายบน: `$table->get_Item(1, 1)` ในตัวอย่างนี้ ตำแหน่งอื่นในช่วงที่รวมยังคงเป็นส่วนหนึ่งของกริดตาราง ดังนั้นดัชนีของเซลล์ที่อยู่นอกช่วงจะไม่เปลี่ยน

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

การรวมเซลล์ในตัวอย่างก่อนหน้ารักษาโครงสร้างกริดของตาราง การแยกเซลล์อาจสร้างคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ทางด้านขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของ PowerPoint

ตัวอย่างนี้สร้างตาราง 4x4 ด้วยคอลัมน์และแถวขนาด 70 จุดและเรียกใช้ [แยกตามความกว้าง](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) บนเซลล์ `(1, 1)`. ครึ่งหนึ่งของความกว้าง 70 จุดของเซลล์ถูกใช้เพื่อสร้างเซลล์สองอันที่กว้างเท่ากัน

หลังจากแยกแล้ว ครึ่งสองส่วนเข้าถึงได้โดย `$table->get_Item(1, 1)` และ `$table->get_Item(2, 1)`. กริดตารางตอนนี้มีห้าคอลัมน์: เซลล์ที่เคยอยู่ในคอลัมน์ 2 และ 3 ย้ายไปที่คอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวไม่เปลี่ยน ใช้ดัชนีคอลัมน์ที่อัพเดตเมื่อเข้าถึงเซลล์หลังการแยก

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

### **แยกเซลล์ที่รวมตามช่วงแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์เทมเพลตที่รวมสำหรับการเติมข้อมูล ใช้ [แยกตามช่วงแถว](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) เพื่อแยกตามขอบแถวที่มีอยู่ หรือ [แยกตามช่วงคอลัมน์](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) เพื่อแยกตามขอบคอลัมน์

อาร์กิวเมนต์ `index` นับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; มีค่าอ้างอิงจากพื้นที่ที่รวม:

- แยกแถว: `0 < index <` [รับช่วงแถว](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- แยกคอลัมน์: `0 < index <` [รับช่วงคอลัมน์](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

ตัวอย่างคาดว่างานนำเสนอมีตารางเป็นรูปทรงแรกบนสไลด์แรก โดย `(1, 2)` และ `(1, 3)` ถูกรวมแนวตั้ง เริ่มจากตำแหน่งล่าง ใช้ [ดัชนีคอลัมน์แรก](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) และ [ดัชนีแถวแรก](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) เพื่อหาตำแหน่งต้น แล้วตรวจสอบทั้งสองช่วง `splitByRowSpan(1)` จะแยกแถว 2 และ 3 สำหรับชื่อสินค้า สำหรับการรวมแนวนอนสองคอลัมน์ ให้ใช้ `splitByColSpan(1)` แทน

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

        // ดึงเซลล์ที่ได้จากตารางหลังจากแยกออก.
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

กริดของตารางและดัชนีเซลล์โดยรอบคงเดิม ให้ดึงเซลล์ที่แยกออกมาด้วยพิกัดของมัน; ในที่นี้ทั้งสองเซลล์มีช่วงเป็น 1 และ [เซลล์ที่รวม](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) แสดง `false`. พื้นที่ใหญ่กว่าอาจยังคงรวมบางส่วนหลังจากการแยกหนึ่งครั้ง

ข้อความและรูปแบบเดิมยังคงอยู่ในเซลล์บน (หรือซ้าย); เซลล์ใหม่เป็นค่าว่างแต่สืบทอดรูปแบบเซลล์เช่น การเติม, เส้นขอบ, และระยะขอบ เติมข้อความลงในเซลล์หลังการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน

งานนำเสนอที่บันทึกมีเซลล์ "Product A" และ "Product B" แยกจากกันโดยคงรูปแบบเซลล์ของเทมเพลตไว้ ดูที่ [อ้างอิง Cell API](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) สำหรับรายละเอียด

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางที่มีคอลัมน์ขนาด 150 จุดและแถวขนาด 50 จุด ใช้ [กำหนดประเภทการเติม](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) เพื่อเลือกการเติมทึบและตั้งค่าสีที่ได้จาก [รับสีเติมแบบทึบ](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) เป็นสีแดงสำหรับเซลล์ `(2, 3)`, ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่

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

วางภาพอินพุตในโฟลเดอร์ทำงานก่อนรันตัวอย่างนี้ โปรแกรมโหลดภาพด้วย [จากไฟล์](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) และเพิ่มเข้าไปในคอลเลกชันภาพของงานนำเสนอด้วย [เพิ่มรูปภาพ](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). จากนั้นกำหนดภาพให้กับการเติมรูปภาพของเซลล์ `(0, 0)`, เซลล์แรกของตาราง

[ขยาย](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) ทำให้ภาพขยายเต็มเซลล์ซึ่งอาจเปลี่ยนสัดส่วนของภาพ ความกว้างคอลัมน์และความสูงแถวระบุเป็นจุด ภาพที่โหลดแล้วจะถูกลบในบล็อก `finally` หลังจากเพิ่มเข้าไปในงานนำเสนอ

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

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [บน](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[ล่าง](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[ซ้าย](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[ขวา](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) borders have separate properties, so the thickness and style of each side can differ.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [โหมดการเติม](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated.

**Can I assign a hyperlink to all the content of a cell?**

[ไฮเปอร์ลิงก์](/slides/th/php-java/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [ส่วนย่อย](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.