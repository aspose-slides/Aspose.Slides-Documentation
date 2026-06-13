---
title: วิธีแก้ปัญหาการปรับขนาดแผ่นงาน
type: docs
weight: 20
url: /th/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- แผ่นงาน
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในงานนำเสนอ: สองวิธีเพื่อให้กรอบวัตถุคงที่—ปรับสเกลกรอบหรือแผ่นงาน—ในรูปแบบ PPT และ PPTX."
---
{{% alert color="primary" %}}

พบว่าแผ่นงาน Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนท์ของ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้สร้างความแตกต่างด้านภาพที่สังเกตได้ระหว่างสถานะก่อนและหลังการเปิดใช้งานวัตถุ OLE เราได้สำรวจปัญหานี้อย่างละเอียดและให้วิธีแก้ ซึ่งอธิบายไว้ในบทความนี้

{{% /alert %}}

## **พื้นฐาน**

ในบทความ [จัดการ OLE](/slides/th/androidjava/manage-ole/) เราได้อธิบายวิธีการเพิ่มกรอบ OLE ลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างวัตถุ](/slides/th/androidjava/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพของพื้นที่แผ่นงานที่เลือกให้กับกรอบวัตถุ OLE ในงานนำเสนอที่ส่งออก เมื่อคุณคลิกสองครั้งที่กรอบ OLE ที่แสดงภาพแผ่นงาน Excel จะทำการเปิดใช้งานสมุดงาน Excel ผู้ใช้สามารถทำการแก้ไขใด ๆ ที่ต้องการในสมุดงานจริงแล้วคลิกนอกสมุดงานที่เปิดใช้งานเพื่อกลับไปยังสไลด์ได้ ขนาดของกรอบ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์ ตัวเลขการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของกรอบ OLE และสมุดงาน Excel ที่ฝังไว้

## **สาเหตุของการปรับขนาด**

เนื่องจากสมุดงาน Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมไว้เมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบ OLE มีขนาดของตนเอง ตามคำชี้แจงของ Microsoft เมื่อสมุดงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้รักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบ OLE

## **วิธีแก้ที่ทำงานได้**

มีวิธีแก้สองวิธีเพื่อหลีกเลี่ยงผลของการปรับขนาด

- ปรับสเกลขนาดกรอบ OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในกรอบ OLE
- คงขนาดกรอบ OLE ไคงที่และปรับขนาดของแถวและคอลัมน์ที่เกี่ยวข้องให้พอดีกับขนาดกรอบ OLE ที่เลือก

### **ปรับสเกลขนาดกรอบ OLE**

ในแนวทางนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดกรอบ OLE ของสมุดงาน Excel ที่ฝังไว้ให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่เกี่ยวข้องในแผ่นงาน Excel

สมมติว่าเรามีแผ่นงาน Excel แบบเทมเพลตและต้องการเพิ่มเข้าเป็นกรอบ OLE ในงานนำเสนอ ในสถานการณ์นี้ ขนาดของกรอบ OLE จะถูกคำนวณเป็นครั้งแรกจากความสูงรวมของแถวและความกว้างรวมของคอลัมน์ที่เกี่ยวข้องในสมุดงาน จากนั้นเราจะตั้งค่าขนาดของกรอบ OLE ให้เป็นค่าที่คำนวณได้ เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” ในกรอบ OLE ของ PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในสมุดงานและตั้งค่าเป็นภาพกรอบ OLE

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// ตั้งขนาดที่แสดงเมื่อไฟล์สมุดงานถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **ปรับสเกลขนาดช่วงเซลล์**

ในแนวทางนี้ เราจะเรียนรู้วิธีปรับความสูงของแถวที่เกี่ยวข้องและความกว้างของคอลัมน์ที่เกี่ยวข้องให้ตรงกับขนาดกรอบ OLE ที่กำหนดเอง

สมมติว่าเรามีแผ่นงาน Excel แบบเทมเพลตและต้องการเพิ่มเข้าเป็นกรอบ OLE ในงานนำเสนอ เราจะตั้งค่าขนาดของกรอบ OLE แล้วปรับขนาดของแถวและคอลัมน์ที่เข้าร่วมในพื้นที่กรอบ OLE จากนั้นเราจะบันทึกสมุดงานลงในสตรีมเพื่อใช้การเปลี่ยนแปลงและแปลงเป็นอาร์เรย์ไบต์เพื่อเพิ่มเข้าในกรอบ OLE เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” ในกรอบ OLE ของ PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในสมุดงานและตั้งค่าเป็นภาพกรอบ OLE

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// กำหนดขนาดที่แสดงเมื่อไฟล์สมุดงานถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้สมุดงานที่แก้ไขแล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มภาพ OLE ลงในทรัพยากรของงานนำเสนอ.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// สร้างกรอบวัตถุ OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     ความกว้างที่คาดว่าจะเป็นของช่วงเซลล์ในหน่วยจุด.
 * @param height    ความสูงที่คาดว่าจะเป็นของช่วงเซลล์ในหน่วยจุด.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **สรุป**

{{% alert color="primary" %}} 

มีสองแนวทางเพื่อแก้ไขปัญหาการปรับขนาดแผ่นงาน การเลือกแนวทางที่เหมาะสมขึ้นอยู่กับความต้องการและกรณีการใช้งาน ทั้งสองแนวทางทำงานเช่นเดียวกันไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบ OLE ในวิธีแก้นี้

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมแผ่นงาน Excel ที่ฝังอยู่ถึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**

เกิดจาก Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ในขณะที่กรอบ OLE ใน PowerPoint มีมิติของตนเอง PowerPoint และ Excel จัดขนาดร่วมกันเพื่อรักษาอัตราส่วน ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้โดยสมบูรณ์หรือไม่?**

ได้ เราสามารถปรับสเกลกรอบ OLE ให้พอดีกับขนาดช่วงเซลล์ Excel หรือปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ OLE ที่ต้องการเพื่อป้องกันการปรับขนาดที่ไม่ต้องการ

**ควรใช้วิธีการสเกลใด ระหว่างการสเกลกรอบ OLE หรือการสเกลช่วงเซลล์?**

เลือก **การสเกลกรอบ OLE** หากต้องการคงขนาดแถวและคอลัมน์เดิมของ Excel เลือก **การสเกลช่วงเซลล์** หากต้องการให้กรอบ OLE มีขนาดคงที่ในงานนำเสนอของคุณ

**วิธีแก้เหล่านี้จะทำงานได้หรือไม่หากงานนำเสนอของฉันสร้างจากเทมเพลต?**

ใช่ ทั้งสองวิธีทำงานได้กับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?**

ไม่มี คุณสามารถทำให้กรอบ OLE มีขนาดใดก็ได้ตราบใดที่ตั้งค่าสเกลอย่างเหมาะสม

**มีวิธีใดที่จะหลีกเลี่ยงข้อความตัวแทน “EMBEDDED OLE OBJECT” ใน PowerPoint หรือไม่?**

มี โดยการถ่ายภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพแทนของกรอบ OLE คุณจะสามารถแสดงภาพตัวอย่างที่กำหนดเองแทนข้อความตัวแทนเริ่มต้นได้