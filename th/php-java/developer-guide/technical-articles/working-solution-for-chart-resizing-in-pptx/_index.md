---
title: วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX
type: docs
weight: 40
url: /th/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดแผนภูมิ
- แผนภูมิ Excel
- อ็อบเจ็กต์ OLE
- ฝังแผนภูมิ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "แก้ไขการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ OLE ของ Excel ที่ฝังไว้กับ Aspose.Slides สำหรับ PHP ผ่าน Java ตั้งค่าขนาดแผนภูมิคงที่เพื่อให้ขนาดของแผนภูมิและกรอบ OLE สม่ำเสมอ"
---
## **ภาพรวม**

แผนภูมิ Excel ที่ฝังเป็นอ็อบเจ็กต์ OLE ในงานนำเสนอ PowerPoint โดยใช้ส่วนประกอบของ Aspose สามารถเปลี่ยนขนาดได้หลังจากการเปิดใช้งานครั้งแรก สิ่งนี้อาจทำให้เห็นความแตกต่างที่ชัดเจนในการแสดงผลของแผนภูมิก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายเหตุผลที่เกิดการปรับขนาดและแสดงวิธีป้องกันโดยการจับคู่ขนาดแผนภูมิคงที่กับกรอบ OLE

ใน [สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจ็กต์ OLE ในงานนำเสนอ](/slides/th/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) เราอธิบายวิธีสร้างแผนภูมิ Excel ด้วย Aspose.Cells for PHP via Java และฝังลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for PHP via Java เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างอ็อบเจ็กต์](/slides/th/php-java/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดรูปภาพแผนภูมิกับกรอบอ็อบเจ็กต์ OLE ของแผนภูมิ ในงานนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบอ็อบเจ็กต์ OLE ที่แสดงรูปภาพแผนภูมิ แผนภูมิ Excel จะถูกเปิดใช้งาน ผู้ใช้สามารถแก้ไขสมุดงาน Excel ที่ฝังอยู่และจากนั้นกลับไปยังสไลด์โดยคลิกนอกสมุดงานที่เปิดใช้งาน ขนาดของกรอบอ็อบเจ็กต์ OLE จะเปลี่ยนเมื่อผู้ใช้กลับไปยังสไลด์ และอัตราการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดเดิมของกรอบอ็อบเจ็กต์ OLE และสมุดงาน Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

สมุดงาน Excel ที่ฝังอยู่มีขนาดหน้าต่างของตนเอง ซึ่ง Excel พยายามคงไว้เมื่ออ็อบเจ็กต์ถูกเปิดใช้งานครั้งแรก กรอบ OLE บนสไลด์มีการกำหนดขนาดอย่างอิสระ เมื่อสมุดงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดของอ็อบเจ็กต์เพื่อรักษาสัดส่วนของมันเป็นส่วนหนึ่งของกระบวนการฝัง ความแตกต่างระหว่างหน้าต่างสมุดงานและกรอบ OLE จึงอาจทำให้เกิดการปรับขนาดของอ็อบเจ็กต์

## **วิธีแก้ไขที่ทำงาน**

จับคู่ขนาดแผนภูมิกับกรอบ OLE บนสไลด์และทำให้ขนาดแผนภูมิเป็นอิสระจากหน้าต่างสมุดงาน วิธีแก้ไขนี้ทำงานได้ทั้งกับงานนำเสนอใหม่และแม่แบบที่มีอยู่

ตัวอย่างนี้ต้องใช้ Aspose.Cells for PHP via Java และ Aspose.Slides for PHP via Java ตั้งค่าทั้งสองผลิตภัณฑ์ด้วยอินสแตนซ์ PHP/Java Bridge เดียวกัน โหลด wrapper ของ PHP ทั้งสองและทำให้ไลบรารี Java ทั้งสองพร้อมใช้งานสำหรับ Bridge ไม่จำเป็นต้องมีไฟล์อินพุต ตัวอย่างสร้างแผนภูมิคอลัมน์อย่างง่ายบนแผ่นแผนภูมิที่ใช้งานอยู่และฝังสมุดงานในรูปแบบ XLS ไม่ได้กำหนดรูปภาพตัวอย่างแผนภูมิ; แผนภูมิจะปรากฏเมื่ออ็อบเจ็กต์ OLE ถูกเปิดใช้งานใน PowerPoint

ตัวอย่างสร้างงานนำเสนอใหม่พร้อมกรอบ OLE ขนาด 9.5 × 4 นิ้ว ที่วางห่างจากขอบซ้าย 0.5 นิ้วและจากด้านบน 1 นิ้ว พิกัดและขนาดของสไลด์ใช้หน่วยเป็นพอยท์ (72 พอยท์ต่อหนึ่งนิ้ว) สำหรับงานนำเสนอที่มีอยู่แล้ว ดูที่ [ใช้แม่แบบ](#use-a-template)

## **ตั้งค่าขนาดแผนภูมิคงที่**

ตั้งค่า [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) ให้เป็น false เพื่อตั้งค่าขนาดแผนภูมิให้เป็นอิสระจากหน้าต่างสมุดงาน ตั้งค่ามิติของ [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) ผ่าน [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) และ [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height) โดยแปลงพอยท์เป็นพิกเซลด้วย 96 พิกเซลต่อหนึ่งนิ้ว: กรอบที่มีขนาด 684 × 288 พอยท์สอดคล้องกับแผนภูมิที่มีขนาด 912 × 384 พิกเซล ตั้งค่า [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) ให้เป็นค่า CUSTOM ของ [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/) ตัวอย่างฝังสมุดงานด้วย [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) และบันทึกงานนำเสนอด้วยกรอบ OLE ขนาด 9.5 × 4 นิ้ว

ผลลัพธ์เชิงตัวเลขของ Java จะถูกแปลงด้วย `java_values` ก่อนที่จะใช้เป็นดัชนีของ PHP ไบต์ของสมุดงานจะคงอยู่ในอาร์เรย์ไบต์ของ Java เมื่อส่งต่อให้กับ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/)

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // พิกัดและขนาดของสไลด์ใช้หน่วยเป็นพอยท์ (72 พอยท์ต่อหนึ่งนิ้ว).
        $width = 684; // 9.5 นิ้ว.
        $height = 288; // 4 นิ้ว.

        $chart->setSizeWithWindow(false);
        // แปลงพอยท์เป็นพิกเซลของแผนภูมิโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **ใช้แม่แบบ**

ตรรกะการกำหนดขนาดเหมือนกันสำหรับงานนำเสนอที่มีอยู่ เพื่อปรับตัวอย่างให้เข้ากับ:

1. โหลดงานนำเสนอแม่แบบแทนการสร้างงานนำเสนอเปล่า
1. ตรวจสอบว่าสตรียด์แรกมีรูปร่างอย่างน้อยสามรูป แล้วใช้รูปร่างที่ดัชนี 2 เป็นตัวแทน
1. นำความกว้างและความสูงของกรอบจากรูปร่างนั้นแทนการใช้ค่าคงที่ 684 และ 288 รักษาการคำนวณขนาดไว้ไม่เปลี่ยน
1. เพิ่มกรอบ OLE ที่ตำแหน่งของตัวแทนแทนการใช้พิกัดคงที่ 36 และ 72
1. ลบตัวแทนออกก่อนบันทึกงานนำเสนอ

## **คำถามที่พบบ่อย**

**ทำไมแผนภูมิ Excel ที่ฝังอยู่ของฉันถึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**

เหตุการณ์นี้เกิดขึ้นเนื่องจาก Excel พยายามกู้คืนขนาดหน้าต่างดั้งเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบอ็อบเจ็กต์ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

**ฉันจะทำให้ขนาดของแผนภูมิและกรอบ OLE สม่ำเสมอได้อย่างไร?**

ตั้งค่าขนาดแผนภูมิคงที่ให้ตรงกับกรอบ OLE และใช้ขนาดการพิมพ์แผนภูมิแบบกำหนดเองก่อนฝังสมุดงาน ตัวอย่างด้านบนแสดงการตั้งค่าที่จำเป็นและการแปลงหน่วย

**การจับคู่ขนาดหน้าต่างสมุดงานเพียงอย่างเดียวเพียงพอหรือไม่?**

การจับคู่ขนาดหน้าต่างสมุดงานโดยเดียวไม่สามารถทำให้กรอบ OLE ไม่เปลี่ยนขนาดหลังจากเปิดใช้งานได้อย่างเชื่อถือได้ ใช้ขนาดแผนภูมิคงที่ตามที่แสดงในตัวอย่าง

**วิธีแก้ไขนี้ทำงานกับงานนำเสนอแบบใช้แม่แบบและงานนำเสนอใหม่หรือไม่?**

ใช่ สำหรับแม่แบบ ใช้ขนาดและตำแหน่งของตัวแทน สำหรับงานนำเสนอใหม่ ให้ระบุขนาดและตำแหน่งของกรอบโดยตรง

**ฉันสามารถใช้ตัวอย่างนี้กับแผนภูมิที่สร้างจากโปรแกรมสเปรดชีตอื่นได้หรือไม่?**

ตัวอย่างนี้ใช้สมุดงาน Excel ที่สร้างด้วย Aspose.Cells ไม่ได้แสดงพฤติกรรมการเปิดใช้งานสำหรับโปรแกรมสเปรดชีตอื่น

## **ส่วนที่เกี่ยวข้อง**

- [สร้างแผนภูมิ Excel และฝังเป็นอ็อบเจ็กต์ OLE ในงานนำเสนอ](/slides/th/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)