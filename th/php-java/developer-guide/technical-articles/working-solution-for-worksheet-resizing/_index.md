---
title: วิธีแก้ปัญหาการปรับขนาดแผ่นงาน
type: docs
weight: 20
url: /th/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- รูปภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- แผ่นงาน
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในงานนำเสนอ: สองวิธีเพื่อให้กรอบอ็อบเจกต์คงที่—ปรับสเกลกรอบหรือแผ่นงาน—ในฟอร์แมต PPT และ PPTX"
---
{{% alert color="info" title="Note" %}}

Excel worksheets embedded as OLE objects in a PowerPoint presentation using Aspose components may resize unexpectedly after their first activation. This behavior creates a noticeable visual difference between the OLE object before and after activation. This article explains the issue and describes two ways to address it.

{{% /alert %}}

## **พื้นหลัง**

ในบทความ [จัดการ OLE](/slides/th/php-java/manage-ole/) เราอธิบายวิธีเพิ่มเฟรม OLE ลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างอ็อบเจกต์](/slides/th/php-java/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพของพื้นที่แผ่นงานที่เลือกให้กับเฟรมอ็อบเจกต์ OLE ในงานนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่เฟรมอ็อบเจกต์ OLE ที่แสดงภาพแผ่นงาน แฟ้มงาน Excel จะถูกเปิดใช้งาน ผู้ใช้ปลายทางสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการกับแฟ้มงาน Excel จริงและจากนั้นกลับไปยังสไลด์โดยคลิกนอกแฟ้มงาน Excel ที่เปิดใช้งาน ขนาดของเฟรมอ็อบเจกต์ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันตามขนาดของเฟรมอ็อบเจกต์ OLE และแฟ้มงาน Excel ที่ฝังอยู่.

## **สาเหตุของการปรับขนาด**

เนื่องจากแฟ้มงาน Excel มีขนาดหน้าต่างของตัวเอง มันพยายามรักษาขนาดเดิมเมื่อลากิจการเปิดใช้งานครั้งแรก ในขณะเดียวกันเฟรมอ็อบเจกต์ OLE มีขนาดของตัวเอง ตามข้อมูลของ Microsoft เมื่อแฟ้มงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจากันเรื่องขนาดเพื่อให้รักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดขึ้นจากความแตกต่างระหว่างขนาดหน้าต่างของ Excel กับขนาดและตำแหน่งของเฟรมอ็อบเจกต์ OLE

## **วิธีแก้ไขที่ทำงาน**

มีสองวิธีแก้ไขที่เป็นไปได้เพื่อหลีกเลี่ยงผลกระทบจากการปรับขนาด

- ปรับขนาดเฟรม OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือก
- คงขนาดเฟรม OLE ไว้คงที่และปรับสเกลแถวและคอลัมน์ที่เลือกให้พอดีภายในเฟรม

### **ปรับขนาดเฟรม OLE**

แนวทางนี้ตั้งค่าขนาดเฟรม OLE ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือกในแผ่นงาน Excel ที่ฝังไว้.

ตัวอย่างจะโหลดแฟ้มงาน Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) กำหนดช่วงที่แสดง ตัวอย่างแสดงผลที่ความละเอียด 96 DPI และแปลงขนาดพิกเซลเป็นจุดโดยใช้ 72 จุดต่ออินช์ [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) ฝังแฟ้มงานที่แก้ไขไว้ในเฟรมที่มีขนาดดังกล่าว ตัวอย่างแสดงผลถูกกำหนดผ่าน [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) เพื่อแทนที่ตัวแทนข้อความ "EMBEDDED OLE OBJECT" ในงานนำเสนอที่บันทึก

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // ฝังเวิร์กบุ๊กที่แก้ไขและเก็บข้อมูลไบนารีในอาร์เรย์ไบต์ของ Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

ตัวช่วยสร้างตัวอย่างตั้งค่า [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) ให้เป็นช่วงที่เลือกและลบขอบเขต, ส่วนหัวและส่วนท้ายออก เมื่เปิดใช้งาน [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) แล้ว [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) จะเรนเดอร์ช่วงเป็นภาพ PNG ตัวช่วยจะคืนสตรีมอินพุตใหม่ที่บรรจุภาพ PNG และตำแหน่งเริ่มต้นของสตรีมเพื่อใช้ในงานนำเสนอ

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **ปรับขนาดช่วงเซลล์**

แนวทางนี้จะปรับสเกลความสูงของแถวที่เลือกและความกว้างของคอลัมน์ที่เลือกให้ตรงกับขนาดเฟรม OLE ที่กำหนดเอง

ตัวอย่างจะโหลดแฟ้มงาน Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) กำหนดช่วงที่แสดงและตัวช่วยด้านล่างจะปรับสเกลช่วงนั้นให้พอดีกับเฟรมที่กว้าง 400 จุดและสูง 100 จุด หลังจากบันทึกแฟ้มงานที่แก้ไขเป็นสตรีมแล้ว [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) จะฝังมันในขนาดที่ระบุ ตัวอย่างที่เรนเดอร์ที่ความละเอียด 96 DPI ถูกกำหนดผ่าน [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ดังนั้นงานนำเสนอที่บันทึกจะแสดงเซลล์ที่เลือกแทนตัวแทนเริ่มต้น

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // ฝังเวิร์กบุ๊กที่แก้ไขและเก็บข้อมูลไบนารีในอาร์เรย์ไบต์ของ Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

ตัวช่วยการสเกลคำนวณอัตราส่วนความกว้างและความสูงแยกกันสำหรับช่วงที่เลือก โดยคงความกว้างสัมพัทธ์ของคอลัมน์และความสูงสัมพัทธ์ของแถวไว้ มันแปลงขนาดที่คำนวณจากจุดเป็นนิ้วก่อนนำไปใช้กับ [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) และ [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch) ช่วงที่เลือกต้องมีความกว้างและความสูงไม่เป็นศูนย์

```php
use aspose\cells\CellsUnitType;

// ความกว้างและความสูงคือมิติที่คาดหวังของช่วงเซลล์ในหน่วยจุด.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

ตัวช่วยสร้างตัวอย่างนี้เรนเดอร์ช่วงที่ปรับขนาดใหม่โดยใช้ [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) มันจำกัด [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) ไว้ที่ช่วงนั้น ลบขอบเขต ส่วนหัว และส่วนท้ายออก และคืนสตรีม PNG ที่ตำแหน่งเริ่มต้นของสตรีม

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **สรุป**

{{% alert color="info" title="Note" %}}

มีสองวิธีในการแก้ไขปัญหาการปรับขนาดแผ่นงาน เลือกวิธีที่เหมาะกับความต้องการและกรณีการใช้งานของคุณ วิธีการทั้งสองทำงานเช่นเดียวกัน ไม่ว่าจะเป็นการสร้างงานนำเสนอจากแม่แบบหรือจากศูนย์ นอกจากนี้โซลูชันนี้ไม่มีขีดจำกัดขนาดของเฟรมอ็อบเจกต์ OLE

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมแผ่นงาน Excel ที่ฝังอยู่จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**

เหตุการณ์นี้เกิดขึ้นเนื่องจาก Excel พยายามรักษาขนาดหน้าต่างดั้งเดิมเมื่อเปิดใช้งาน ในขณะที่เฟรมอ็อบเจกต์ OLE ใน PowerPoint มีขนาดของมันเอง PowerPoint และ Excel จะเจรจากันเรื่องขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้อย่างสมบูรณ์หรือไม่?**

ใช่ โดยการปรับสเกลเฟรม OLE ให้พอดีกับขนาดช่วงเซลล์ของ Excel หรือปรับสเกลช่วงเซลล์ให้พอดกับขนาดเฟรม OLE ที่ต้องการ คุณสามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

**ฉันควรใช้วิธีการสเกลแบบใด ระหว่างการสเกลเฟรม OLE หรือการสเกลช่วงเซลล์?**

เลือก **OLE frame scaling** หากคุณต้องการรักษาขนาดแถวและคอลัมน์ของ Excel ดั้งเดิม เลือก **cell range scaling** หากคุณต้องการให้เฟรม OLE มีขนาดคงที่ในงานนำเสนอของคุณ

**วิธีแก้ไขเหล่านี้จะทำงานได้หรือไม่หากงานนำเสนอของฉันสร้างจากแม่แบบ?**

ใช่ ทั้งสองวิธีทำงานสำหรับงานนำเสนอที่สร้างจากแม่แบบหรือจากศูนย์

**มีขีดจำกัดขนาดของเฟรม OLE หรือไม่เมื่อใช้วิธีเหล่านี้?**

ไม่มี คุณสามารถตั้งค่าเฟรมอ็อบเจกต์ OLE ให้มีขนาดใดก็ได้ตราบเท่าที่กำหนดสเกลอย่างเหมาะสม

**มีวิธีใดที่จะหลีกเลี่ยงข้อความตำแหน่งตัวแทน "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**

ใช่ โดยการถ่ายภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพตัวแทนของเฟรม OLE คุณสามารถแสดงภาพตัวอย่างที่กำหนดเองแทนตำแหน่งตัวแทนเริ่มต้น

## **บทความที่เกี่ยวข้อง**

[สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นอ็อบเจกต์ OLE](/slides/th/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[อัปเดตอ็อบเจกต์ OLE อัตโนมัติด้วยแอดอิน MS PowerPoint](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)