---
title: สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นวัตถุ OLE
type: docs
weight: 30
url: /th/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- วัตถุ OLE
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างแผนภูมิ Excel ด้วย Aspose.Cells สำหรับ PHP ผ่าน Java และฝัง workbook ลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java รวมถึงภาพตัวอย่างของแผนภูมิ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างแผนภูมิกลุ่มคอลัมน์ของ Excel ด้วย Aspose.Cells สำหรับ PHP ผ่าน Java และฝัง workbook ของมันในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. workbook ที่ฝังไว้ประกอบด้วยข้อมูลต้นฉบับและแผนภูมิ. ภาพตัวอย่าง PNG แยกต่างหากจะแสดงแผนภูมิบนสไลด์ก่อนที่วัตถุ OLE จะถูกเปิดใช้งาน.

ผลลัพธ์คือวัตถุ Excel ที่ฝังอยู่ ไม่ใช่แผนภูมิ PowerPoint แบบดั้งเดิม. การแก้ไข workbook ผ่าน OLE ต้องการแอปพลิเคชันเดสก์ท็อปที่สนับสนุนการเปิดใช้งาน OLE และการติดตั้ง Excel ที่เข้ากันได้.

## **ข้อกำหนดเบื้องต้น**

กำหนดค่า Aspose.Cells สำหรับ PHP ผ่าน Java และ Aspose.Slides สำหรับ PHP ผ่าน Java ด้วยอินสแตนซ์ PHP/Java Bridgeเดียวกัน. โหลด wrapper ของ PHP ทั้งสองและทำให้ไลบรารี Java ของผลิตภัณฑ์ทั้งสองพร้อมใช้งานสำหรับ bridge. ไม่จำเป็นต้องมี Microsoft Office เพื่อสร้างงานนำเสนอด้วยไลบรารีเหล่านี้.

ไม่จำเป็นต้องมีไฟล์อินพุต: ตัวอย่างจะสร้างข้อมูลและแผนภูมิในหน่วยความจำ จากนั้นเขียน `OutputChart.pptx` ลงในไดเรกทอรีทำงานปัจจุบัน. ใช้ใบอนุญาตสำหรับผลิตภัณฑ์ทั้งสองเมื่อทำงานนอกโหมดประเมินผล.

## **วิธีการทำงานของการฝัง**

1. สร้าง workbook ที่มีแผ่นงานข้อมูลและแผ่นงานแผนภูมิ.
1. ทำให้ chart sheet เป็นแผ่นที่ใช้งานเพื่อให้ workbook เปิดที่แผนภูมิ.
1. กำหนดช่วงการแสดง OLE ของ workbook และแปลงแผนภูมิเป็น PNG.
1. บันทึก workbook เป็น XLSX ในหน่วยความจำและฝังไบต์เหล่านั้นลงในสไลด์.
1. กำหนด PNG เป็นภาพตัวอย่างของวัตถุ OLE แล้วบันทึกงานนำเสนอเป็น PPTX.

ช่วงการแสดงของ workbook และกรอบบนสไลด์มีบทบาทที่แตกต่างกัน. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) รับค่าดัชนีแถวและคอลัมน์เริ่มต้น/สิ้นสุดที่เริ่มจากศูนย์. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) แทนที่จะรับแถวบน, คอลัมน์ซ้าย, แถวล่าง, และคอลัมน์ขวา. ตัวอย่างใช้ดัชนีแถว 55 และดัชนีคอลัมน์ 25 เป็นขอบล่างขวา; ค่าต่างๆ เหล่านี้เป็นการเลือกจัดวาง ไม่ได้เป็นจำนวนแถวหรือคอลัมน์ของข้อมูล.

กรอบสไลด์ใช้หน่วย point. ตัวอย่างทำให้มันพอดีภายในสไลด์และจัดกึ่งกลางโดยคงอัตราส่วนของ PNG ไว้ แทนที่จะยืดภาพตัวอย่างให้เต็มสไลด์.

## **สร้างและฝังแผนภูมิ**

ตัวอย่างเต็มด้านล่างนี้จะเติม `DataSheet` ด้วยค่าที่มีสี่แถวและห้าคอลัมน์. แต่ละแถวจะกลายเป็น series ของแผนภูมิ. `ChartSheet` ถูกเลือกเป็นแผ่นงานที่ทำงานอยู่ก่อนบันทึก workbook.

workbook ถูกบันทึกเป็น XLSX อย่างชัดเจน เพื่อให้ตรงกับส่วนขยาย `xlsx` ที่ส่งให้กับ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). ผลลัพธ์เชิงตัวเลขของ Java จะถูกแปลงด้วย `java_values` ก่อนที่ PHP จะทำการคำนวณ, ขณะที่ข้อมูลไบนารียังคงอยู่ในอาเรย์ไบต์ของ Java. PNG ถูกโหลดโดยตรงจากไบต์โดยไม่ต้องแปลงเป็นบิตแมพกลาง. การกำหนดค่าโดยผ่าน [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) จะทดแทนตัวแทน OLE เริ่มต้น.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // เก็บ PNG และ XLSX เป็นอาร์เรย์ไบต์ของ Java เมื่อส่งไปยัง Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // ปรับขนาดและจัดกึ่งกลางภาพตัวอย่างโดยคงอัตราส่วนเดิม.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **ผลลัพธ์ที่คาดหวัง**

`OutputChart.pptx` มีหนึ่งสไลด์ที่ฝัง workbook ของ Excel และภาพตัวอย่างของแผนภูมิ. workbook มีข้อมูลเดิมและแผนภูมิกลุ่มคอลัมน์ที่มีสี่ series. ภาพตัวอย่างถูกจัดกึ่งกลางบนสไลด์และคงอัตราส่วนไว้.

![แผนภูมิกลุ่มคอลัมน์ของ Excel แสดงเป็นภาพตัวอย่างของ workbook ที่ฝัง](excel-chart-ole-preview.png)

ในสภาพแวดล้อม PowerPoint บนเดสก์ท็อปที่รองรับพร้อมมี Excel, ให้คลิกสองครั้งที่วัตถุเพื่อเปิดใช้งานและแก้ไข workbook ที่ฝังอยู่. การเปิดใช้งานและการแก้ไขขึ้นอยู่กับการสนับสนุน OLE ของแอปพลิเคชันโฮสต์และการตั้งค่าความปลอดภัย.

## **คำถามที่พบบ่อย**

**ทำไมต้องมีภาพตัวอย่าง?**

Workbook ที่ฝังไว้และภาพตัวอย่างบนสไลด์เป็นเนื้อหาแยกกัน. ให้ภาพแผนภูมิเพื่อให้สไลด์แสดงแผนภูมิแทนตัวแทนค่าเริ่มต้น "EMBEDDED OLE OBJECT". ดู [ปัญหาภาพตัวอย่างของวัตถุเมื่อเพิ่ม OleObjectFrame](/slides/th/php-java/object-preview-issue-when-adding-oleobjectframe/).

**ภาพตัวอย่างจะอัปเดตโดยอัตโนมัติเมื่อฉันเปลี่ยน workbook ในโค้ดหรือไม่?**

ถือว่าภาพตัวอย่างเป็นสแนปช็อต. เมื่ออัปเดตข้อมูล workbook ผ่านโปรแกรม, ให้สร้างภาพแผนภูมิใหม่และแทนที่ภาพตัวอย่างพร้อมกับข้อมูล workbook ที่ฝัง.

**ฉันสามารถใช้ XLS แทน XLSX ได้หรือไม่?**

ใช่. บันทึก workbook ในรูปแบบ XLS และใช้ `xls` เป็นส่วนขยายของข้อมูลที่ฝัง. ส่วนขยายต้องตรงกับรูปแบบ workbook จริง; การเปลี่ยนส่วนขยายอย่างเดียวจะไม่แปลงข้อมูล.

**ทำไมวัตถุอาจเปลี่ยนขนาดหลังจากเปิดใช้งาน?**

แอปพลิเคชันโฮสต์อาจอัปเดตการแสดงผลของวัตถุ OLE เมื่อเปิดใช้งาน workbook. ช่วงการแสดง OLE ของ workbook และขนาดของกรอบสไลด์ทั้งสองมีผล. ดู [Working Solution for Chart Resizing in PPTX](/slides/th/java/working-solution-for-chart-resizing-in-pptx/).

## **ส่วนที่เกี่ยวข้อง**

- [โซลูชันที่ทำงานได้สำหรับการปรับขนาดแผนภูมิใน PPTX](/slides/th/java/working-solution-for-chart-resizing-in-pptx/)
- [ปัญหาภาพตัวอย่างของวัตถุเมื่อเพิ่ม OleObjectFrame](/slides/th/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [จัดการวัตถุ OLE](/slides/th/php-java/manage-ole/)