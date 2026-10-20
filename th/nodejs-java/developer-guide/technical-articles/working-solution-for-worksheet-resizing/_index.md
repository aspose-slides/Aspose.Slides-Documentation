---
title: วิธีทำงานสำหรับการปรับขนาดเวิร์กชีต
type: docs
weight: 20
url: /th/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- เวิร์กชีต
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของเวิร์กชีต Excel ในการนำเสนอ: มีสองวิธีเพื่อคงกรอบวัตถุให้สอดคล้อง—ปรับสเกลกรอบหรือแผ่น—ในรูปแบบ PPT และ PPTX."
---
{{% alert color="info" title="Note" %}}
เวิร์กชีต Excel ที่ฝังเป็นวัตถุ OLE ในการนำเสนอ PowerPoint โดยใช้คอมโพเนนต์ของ Aspose อาจปรับขนาดโดยไม่ได้คาดคิดหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างของภาพที่เห็นได้ชัดระหว่างวัตถุ OLE ก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายปัญหาและอธิบายวิธีแก้ไขสองวิธี
{{% /alert %}}

## **พื้นฐาน**

ในบทความ [Manage OLE](/slides/th/nodejs-java/manage-ole/) เราได้อธิบายวิธีการเพิ่มกรอบ OLE ไปยังการนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อแก้ไขปัญหา [object preview issue](/slides/th/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดรูปภาพของพื้นที่เวิร์กชีตที่เลือกให้กับกรอบวัตถุ OLE ในการนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบวัตถุ OLE ที่แสดงรูปภาพของเวิร์กชีต เวิร์กบุ๊ก Excel จะถูกเปิดใช้งาน ผู้ใช้สุดท้ายสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการในเวิร์กบุ๊ก Excel จริงได้และจากนั้นกลับไปยังสไลด์โดยคลิกนอกเวิร์กบุ๊กที่เปิดใช้งาน ขนาดของกรอบวัตถุ OLE จะเปลี่ยนเมื่อผู้ใช้กลับไปยังสไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของกรอบวัตถุ OLE และเวิร์กบุ๊ก Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของตนเอง มันพยายามคงขนาดเดิมไว้เมื่อตั้งค่าเปิดใช้งานครั้งแรก ในขณะที่กรอบวัตถุ OLE มีขนาดของตนเอง ตามที่ Microsoft ระบุเมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะทำการเจรจาขนาดเพื่อให้แน่ใจว่ามีอัตราส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดขึ้นโดยอิงจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบวัตถุ OLE

## **วิธีแก้ไขที่ทำงาน**

มีวิธีแก้ไขสองวิธีที่เป็นไปได้เพื่อหลีกเลี่ยงผลของการปรับขนาด

- ปรับขนาดกรอบ OLE ในการนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือก
- คงขนาดกรอบ OLE คงที่และปรับขนาดแถวและคอลัมน์ที่เลือกให้พอดีกับกรอบนั้น

### **ปรับขนาดกรอบ OLE**

วิธีนี้ตั้งค่าขนาดกรอบ OLE ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือกในเวิร์กชีต Excel ที่ฝังอยู่

ตัวอย่างโหลดเวิร์กบุ๊ก Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของเวิร์กชีตแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) กำหนดช่วงที่แสดง ตัวอย่างภาพตัวอย่างถูกเรนเดอร์ที่ 96 DPI และมิติพิกเซลของมันถูกแปลงเป็นพอยต์โดยใช้ 72 พอยต์ต่ออินช์ [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) ฝังเวิร์กบุ๊กที่แก้ไขแล้วในกรอบที่มีมิติดังกล่าว ตัวอย่างภาพถูกรับมอบผ่าน [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) เพื่อแทนที่ตัวเล่นที่อยู่ในส่วนของ placeholder "EMBEDDED OLE OBJECT" ในการนำเสนอที่บันทึกไว้

ติดตั้งแพคเกจ `aspose.cells`, `aspose.slides.via.java` และ `java` แล้ววางไฟล์ `sample.xlsx` ในไดเรกทอรีทำงาน สำหรับแต่ละวิธี ให้เรียกสคริปต์เตรียมก่อน จากนั้นสคริปต์ฝังในกระบวนการ Node.js แยกต่างหากในไดเรกทอรีเดียวกัน แพคเกจ Aspose สองชุดจะเริ่มต้นบริดจ์ Java แยกกัน

บันทึกสคริปต์เตรียมนี้เป็น `prepare-frame-scaled.js` แล้วเรียกใช้ด้วย `node prepare-frame-scaled.js` จะสร้างไฟล์ `frame-scaled.xlsx` และ `frame-scaled.png`
```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// งานที่ทำแบบซิงโครนัสทั้งหมดเสร็จสิ้น; หยุดกระบวนการบริดจ์ของ Java.
process.exit(0);
```
บันทึกสคริปต์ฝังนี้เป็น `embed-frame-scaled.js` แล้วเรียกใช้ด้วย `node embed-frame-scaled.js` จะอ่านไฟล์เหล่านั้นและสร้างไฟล์ `frame-scaled.pptx`
```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// งานที่ทำแบบซิงโครนัสทั้งหมดเสร็จสิ้น; หยุดกระบวนการบริดจ์ของ Java.
process.exit(0);
```

ตัวช่วยแสดงตัวอย่างตั้งค่า [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) ให้เป็นช่วงที่เลือกและลบขอบกระดาษ ส่วนหัวและส่วนท้าย โดยเปิดใช้งาน [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) แล้ว [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) จะเรนเดอร์ช่วงเป็นภาพ PNG ตัวช่วยบันทึกภาพ PNG ไปยังไฟล์เพื่อใช้ในการนำเสนอ

### **ปรับขนาดช่วงเซลล์**

ตัวอย่างโหลดเวิร์กบุ๊ก Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของเวิร์กชีตแรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) กำหนดช่วงที่แสดงและตัวช่วยปรับขนาดช่วงนั้นให้พอดีกับกรอบกว้าง 400 พอยต์และสูง 100 พอยต์ หลังจากบันทึกเวิร์กบุ๊กที่แก้ไขเป็นไฟล์แล้ว [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) จะฝังมันด้วยขนาดที่ระบุ ตัวอย่างภาพที่เรนเดอร์ที่ 96 DPI จะถูกกำหนดผ่าน [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ทำให้การนำเสนอที่บันทึกจะแสดงเซลล์ที่เลือกแทน placeholder เริ่มต้น

บันทึกสคริปต์เตรียมนี้เป็น `prepare-cells-scaled.js` แล้วเรียกใช้ด้วย `node prepare-cells-scaled.js` จะสร้างไฟล์ `cells-scaled.xlsx` และ `cells-scaled.png`
```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// งานที่ทำแบบซิงโครนัสทั้งหมดเสร็จสิ้น; หยุดกระบวนการบริดจ์ของ Java.
process.exit(cellsPrepared ? 0 : 1);
```
บันทึกสคริปต์ฝังนี้เป็น `embed-cells-scaled.js` แล้วเรียกใช้ด้วย `node embed-cells-scaled.js` จะอ่านไฟล์เหล่านั้นและสร้างไฟล์ `cells-scaled.pptx`
```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// งานที่ทำแบบซิงโครนัสทั้งหมดเสร็จสิ้น; หยุดกระบวนการบริดจ์ของ Java.
process.exit(0);
```

ตัวช่วยปรับสัดส่วนคำนวณอัตราส่วนความกว้างและความสูงแยกกันสำหรับช่วงที่เลือก โดยคงอัตราส่วนความกว้างของคอลัมน์และความสูงของแถวไว้ จากนั้นแปลงมิติที่คำนวณจากพอยต์เป็นนิ้วก่อนนำไปใช้ด้วย [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) และ [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch) ช่วงที่เลือกต้องมีความกว้างและความสูงที่ไม่เป็นศูนย์

ตัวช่วยแสดงตัวอย่างนี้เรนเดอร์ช่วงที่ปรับขนาดโดยใช้ [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) มันจำกัด [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) ให้เป็นช่วงนั้น ลบขอบกระดาษ ส่วนหัวและส่วนท้าย และบันทึกภาพ PNG ไปยังไฟล์

## **สรุป**
{{% alert color="info" title="Note" %}}
มีสองวิธีในการแก้ไขปัญหาการปรับขนาดของเวิร์กชีต เลือกวิธีที่เหมาะกับความต้องการและกรณีการใช้งานของคุณ วิธีทั้งสองทำงานเหมือนกัน ไม่ว่าจะสร้างการนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบวัตถุ OLE ในวิธีนี้
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมเวิร์กชีต Excel ที่ฝังอยู่จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**  
เหตุการณ์นี้เกิดขึ้นเนื่องจาก Excel พยายามคงขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ขณะที่กรอบวัตถุ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel ทำการเจรจาขนาดเพื่อคงอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้อย่างสมบูรณ์หรือไม่?**  
ได้เลย โดยการปรับขนาดกรอบ OLE ให้พอดีกับขนาดช่วงเซลล์ Excel หรือปรับขนาดช่วงเซลล์ให้พอดกับขนาดกรอบ OLE ที่ต้องการ คุณสามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีการปรับขนาดแบบใด OLE frame scaling หรือ cell range scaling?**  
เลือก **OLE frame scaling** หากคุณต้องการคงขนาดแถวและคอลัมน์ของ Excel ตามเดิม เลือก **cell range scaling** หากคุณต้องการขนาดคงที่สำหรับกรอบ OLE ในการนำเสนอของคุณ

**วิธีแก้เหล่านี้จะทำงานได้หรือไม่หากการนำเสนอของฉันอิงจากเทมเพลต?**  
ได้เลย ทั้งสองวิธีทำงานได้สำหรับการนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?**  
ไม่มี คุณสามารถตั้งค่าขนาดกรอบวัตถุ OLE ได้ตามต้องการตราบใดที่ตั้งค่าสเกลอย่างเหมาะสม

**มีวิธีหลีกเลี่ยงข้อความ placeholder "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**  
ได้ โดยการจับภาพช่วงเซลล์ Excel ที่ต้องการและตั้งค่าเป็นภาพ placeholder ของกรอบ OLE คุณสามารถแสดงภาพตัวอย่างที่กำหนดเองแทน placeholder เริ่มต้นได้

## **บทความที่เกี่ยวข้อง**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/th/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)