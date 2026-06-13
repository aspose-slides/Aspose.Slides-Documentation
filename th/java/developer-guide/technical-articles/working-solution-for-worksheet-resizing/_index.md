---
title: วิธีแก้ปัญหาการปรับขนาดแผ่นงาน
type: docs
weight: 20
url: /th/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- แผ่นงาน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในการนำเสนอ: วิธีสองวิธีเพื่อให้กรอบวัตถุคงที่—ปรับขนาดกรอบหรือปรับขนาดแผ่นงาน—ในรูปแบบ PPT และ PPTX."
---
{{% alert color="primary" %}}
พบว่าชุดงาน Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint ผ่านส่วนประกอบ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างที่มองเห็นได้ชัดเจนในงานนำเสนอระหว่างสถานะก่อนและหลังการเปิดใช้งานของวัตถุ OLE เราได้ทำการสืบค้นปัญหานี้อย่างละเอียดและจัดหาแนวทางแก้ไขซึ่งครอบคลุมในบทความนี้.
{{% /alert %}}

## **พื้นฐาน**

ในบทความ [Manage OLE](/slides/th/java/manage-ole/) เราได้อธิบายวิธีการเพิ่มกรอบ OLE ลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Java เพื่อแก้ไข [object preview issue](/slides/th/java/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดรูปภาพของพื้นที่แผ่นงานที่เลือกให้กับกรอบวัตถุ OLE ในงานนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบ OLE ที่แสดงรูปภาพแผ่นงาน Excel จะทำการเปิดใช้งาน workbook ของ Excel ผู้ใช้ปลายสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการกับ workbook จริงแล้วคลิกนอก workbook ที่เปิดใช้งานเพื่อกลับไปยังสไลด์ ขนาดของกรอบ OLE จะเปลี่ยนไปเมื่อผู้ใช้กลับสู่สไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันตามขนาดของกรอบ OLE และ workbook Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจาก workbook ของ Excel มีขนาดหน้าต่างของตนเอง มันพยายามคงขนาดเดิมไว้เมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบ OLE มีขนาดของมันเอง ตามที่ Microsoft ระบุ เมื่อ workbook ของ Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้รักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดขึ้นตามความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบ OLE

## **วิธีแก้ปัญหาที่ทำงานได้**

มีสองวิธีแก้ไขเพื่อหลีกเลี่ยงผลของการปรับขนาด

- ปรับขนาดของกรอบ OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในกรอบ OLE
- คงขนาดของกรอบ OLE ไว้คงที่และปรับขนาดของแถวและคอลัมน์ที่เกี่ยวข้องให้พอดีภายในขนาดกรอบ OLE ที่เลือก

### **ปรับขนาดกรอบ OLE**

ในแนวทางนี้ เราจะเรียนรู้วิธีตั้งขนาดกรอบ OLE ของ workbook Excel ที่ฝังไว้ให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่เกี่ยวข้องในแผ่นงาน Excel

สมมติเรามีแผ่นงาน Excel แบบเทมเพลตและต้องการเพิ่มลงในงานนำเสนอเป็นกรอบ OLE ในสถานการณ์นี้ ขนาดของกรอบ OLE จะถูกคำนวณเป็นอันดับแรกตามความสูงรวมของแถวและความกว้างรวมของคอลัมน์ที่เกี่ยวข้องใน workbook จากนั้นเราจะตั้งค่าขนาดของกรอบ OLE ให้เป็นค่าที่คำนวณได้ เพื่อหลีกเลี่ยงข้อความสีแดง "EMBEDDED OLE OBJECT" สำหรับกรอบ OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ใน workbook แล้วตั้งเป็นรูปภาพของกรอบ OLE

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// ตั้งขนาดที่แสดงเมื่อไฟล์ workbook ถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// รับความกว้างและความสูงของภาพ OLE หน่วยเป็นจุด.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// เราต้องใช้ workbook ที่แก้ไขแล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// สร้างกรอบวัตถุ OLE.
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

### **ปรับขนาดช่วงเซลล์**

ในแนวทางนี้ เราจะเรียนรู้วิธีปรับความสูงของแถวที่เกี่ยวข้องและความกว้างของคอลัมน์ที่เกี่ยวข้องให้ตรงกับขนาดกรอบ OLE ที่กำหนดเอง

สมมติเรามีแผ่นงาน Excel แบบเทมเพลตและต้องการเพิ่มลงในงานนำเสนอเป็นกรอบ OLE ในสถานการณ์นี้ เราจะตั้งค่าขนาดของกรอบ OLE และปรับขนาดของแถวและคอลัมน์ที่เข้าร่วมในพื้นที่กรอบ OLE จากนั้นเราจะบันทึก workbook ลงในสตรีมเพื่อใช้การเปลี่ยนแปลงและแปลงเป็นอาเรย์ไบต์เพื่อเพิ่มลงในกรอบ OLE เพื่อหลีกเลี่ยงข้อความสีแดง "EMBEDDED OLE OBJECT" สำหรับกรอบ OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ใน workbook แล้วตั้งเป็นรูปภาพของกรอบ OLE

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์ workbook ถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับขนาดช่วงเซลล์ให้พอดีกับขนาดกรอบ.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้ workbook ที่แก้ไขแล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
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
 * @param width     ความกว้างที่คาดหวังของช่วงเซลล์ในหน่วยจุด.
 * @param height    ความสูงที่คาดหวังของช่วงเซลล์ในหน่วยจุด.
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
มีสองแนวทางเพื่อแก้ไขปัญหาการปรับขนาดของแผ่นงาน การเลือกแนวทางที่เหมาะสมขึ้นอยู่กับความต้องการและกรณีการใช้งานเฉพาะ ทั้งสองแนวทางทำงานเช่นเดียวกันไม่ว่างานนำเสนอจะสร้างจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบ OLE ในวิธีการนี้
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไมแผ่นงาน Excel ที่ฝังอยู่จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**  
เกิดจาก Excel พยายามคงขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ในขณะที่กรอบ OLE ใน PowerPoint มีมิติของมันเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาสัดส่วน ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้โดยสมบูรณ์หรือไม่?**  
ได้ โดยการปรับขนาดกรอบ OLE ให้พอดีกับช่วงเซลล์ของ Excel หรือปรับช่วงเซลล์ให้พอดีกับขนาดกรอบ OLE ที่ต้องการ สามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีปรับขนาดใด OLE frame scaling หรือ cell range scaling?**  
เลือก **OLE frame scaling** หากต้องการคงขนาดแถวและคอลัมน์ของ Excel ดั้งเดิม เลือก **cell range scaling** หากต้องการให้กรอบ OLE มีขนาดคงที่ในงานนำเสนอของคุณ

**วิธีแก้เหล่านี้จะทำงานหากงานนำเสนอของฉันสร้างจากเทมเพลตหรือไม่?**  
ใช่ ทั้งสองวิธีทำงานกับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?**  
ไม่มี คุณสามารถกำหนดขนาดกรอบ OLE ใดก็ได้ตราบใดที่ตั้งสเกลอย่างเหมาะสม

**มีวิธีใดหลีกเลี่ยงข้อความตัวแทน “EMBEDDED OLE OBJECT” ใน PowerPoint หรือไม่?**  
ใช่ โดยการจับภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพตลับสำหรับกรอบ OLE คุณจะสามารถแสดงภาพตัวอย่างที่กำหนดเองแทนข้อความตัวแทนเริ่มต้นได้

## **บทความที่เกี่ยวข้อง**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/th/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/th/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)