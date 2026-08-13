---
title: วิธีแก้ปัญหาการปรับขนาดแผ่นงาน
type: docs
weight: 20
url: /th/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- รูปภาพตัวอย่าง
- การปรับขนาดภาพ
- Excel
- แผ่นงาน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในการนำเสนอ: สองวิธีเพื่อคงกรอบออบเจกต์ให้สอดคล้อง—ปรับสเกลกรอบหรือแผ่นงาน—ในรูปแบบ PPT และ PPTX."
---
{{% alert color="info" %}}
พบว่าชุดงาน Excel ที่ฝังเป็นออบเจกต์ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนท์ของ Aspose ถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างด้านการมองเห็นที่ชัดเจนในงานนำเสนอระหว่างสถานะก่อนและหลังการเปิดใช้งานออบเจกต์ OLE เราได้ศึกษาปัญหานี้อย่างละเอียดและได้จัดทำวิธีแก้ ซึ่งได้อธิบายไว้ในบทความนี้
{{% /alert %}}

## **Background**
ในบทความ [Manage OLE](/slides/th/java/manage-ole/), เราอธิบายวิธีการเพิ่มกรอบ OLE ลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Java เพื่อแก้ไขปัญหา [object preview issue](/slides/th/java/object-preview-issue-when-adding-oleobjectframe/), เราได้กำหนดรูปภาพของพื้นที่แผ่นงานที่เลือกให้กับกรอบออบเจกต์ OLE ในงานนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่กรอบ OLE ที่แสดงรูปภาพแผ่นงาน Excel เวิร์กบุ๊กจะถูกเปิดใช้งาน ผู้ใช้สามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการกับเวิร์กบุ๊ก Excel จริง ๆ แล้วกลับไปยังสไลด์โดยคลิกนอกเวิร์กบุ๊กที่เปิดใช้งาน ขนาดของกรอบ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปที่สไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของกรอบ OLE และเวิร์กบุ๊ก Excel ที่ฝังไว้

## **Cause of Resizing**
เนื่องจากเวิร์กบุ๊ก Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมไว้เมื่อตอนเปิดใช้งานครั้งแรก ในทางตรงกันข้าม กรอบออบเจกต์ OLE มีขนาดของมันเอง ตามข้อมูลของ Microsoft เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้แน่ใจว่ารักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดขึ้นจากความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของกรอบออบเจกต์ OLE

## **Working Solution**
มีวิธีแก้สองวิธีเพื่อลดผลกระทบของการปรับขนาด

- ปรับสเกลขนาดกรอบ OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในกรอบ OLE
- คงขนาดกรอบ OLE ไค adquirand เพื่อวเรียบบรshaller and bwrong in도 사

### **Scale the OLE Frame Size**
ในวิธีนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดกรอบ OLE ของเวิร์กบุ๊ก Excel ที่ฝังไว้ให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่มีส่วนร่วมในแผ่นงาน Excel

สมมติว่าเรามีเทมเพลตแผ่นงาน Excel และต้องการเพิ่มลงในงานนำเสนอเป็นกรอบ OLE ในสถานการณ์นี้ ขนาดของกรอบออบเจกต์ OLE จะถูกคำนวณก่อนโดยอิงจากความสูงรวมของแถวและความกว้างรวมของคอลัมน์ที่มีส่วนร่วมในเวิร์กบุ๊ก จากนั้นเราจะตั้งค่าขนาดของกรอบ OLE ตามค่าที่คำนวณได้ เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับกรอบ OLE ใน PowerPoint เราจะจับภาพของส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งเป็นภาพกรอบ OLE ด้วย

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็นออบเจกต์ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// รับความกว้างและความสูงของภาพ OLE ในหน่วยจุด.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// สร้างกรอบออบเจกต์ OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

### **Scale the Cell Range Size**
ในวิธีนี้ เราจะเรียนรู้วิธีปรับความสูงของแถวที่มีส่วนร่วมและความกว้างของคอลัมน์ที่มีส่วนร่วมให้ตรงกับขนาดกรอบ OLE ที่กำหนดเอง

สมมติว่าเรามีเทมเพลตแผ่นงาน Excel และต้องการเพิ่มลงในงานนำเสนอเป็นกรอบ OLE ในสถานการณ์นี้ เราจะตั้งค่าขนาดของกรอบ OLE แล้วปรับสเกลขนาดของแถวและคอลัมน์ที่อยู่ในพื้นที่กรอบ OLE จากนั้นเราจะบันทึกเวิร์กบุ๊กเป็นสตรีมเพื่อทำการเปลี่ยนแปลงและแปลงเป็นอาร์เรย์ไบต์เพื่อเพิ่มลงในกรอบ OLE เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับกรอบ OLE ใน PowerPoint เราจะจับภาพของส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งเป็นภาพกรอบ OLE ด้วย

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็นอ็อบเจกต์ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มรูปภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// สร้างกรอบอ็อบเจกต์ OLE.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

## **Conclusion**
{{% alert color="info" %}} 
มีสองวิธีในการแก้ไขปัญหาการปรับขนาดแผ่นงาน การเลือกวิธีที่เหมาะสมขึ้นอยู่กับข้อกำหนดและกรณีการใช้งานเฉพาะ ทั้งสองวิธีทำงานในลักษณะเดียวกัน ไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ยังไม่มีขีดจำกัดขนาดของกรอบออบเจกต์ OLE ในวิธีแก้นี้
{{% /alert %}}

## **FAQ**

### ทำไมแผ่นงาน Excel ที่ฝังไว้จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?
เนื่องจาก Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ในขณะที่กรอบออบเจกต์ OLE ใน PowerPoint มีมิติของมันเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

### สามารถป้องกันปัญหาการปรับขนาดนี้ได้โดยสมบูรณ์หรือไม่?
ได้ เราสามารถป้องกันการปรับขนาดโดยการปรับสเกลกรอบ OLE ให้พอดีกับขนาดช่วงเซลล์ของ Excel หรือปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ OLE ที่ต้องการ

### ควรใช้วิธีสเกลใด ระหว่างการสเกลกรอบ OLE หรือการสเกลช่วงเซลล์?
เลือก **การสเกลกรอบ OLE** หากต้องการคงขนาดแถวและคอลัมน์ของ Excel ไว้ตามเดิม เลือก **การสเกลช่วงเซลล์** หากต้องการให้กรอบ OLE มีขนาดคงที่ในงานนำเสนอของคุณ

### วิธีเหล่านี้จะทำงานได้หากงานนำเสนอของฉันสร้างจากเทมเพลตหรือไม่?
ได้ ทั้งสองวิธีทำงานได้สำหรับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

### มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?
ไม่มี คุณสามารถทำให้กรอบออบเจกต์ OLE มีขนาดใดก็ได้ตราบใดที่ตั้งค่าสเกลอย่างเหมาะสม

### มีวิธีหลีกเลี่ยงข้อความตัวแทน “EMBEDDED OLE OBJECT” ใน PowerPoint หรือไม่?
ได้ โดยการจับภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพตัวแทนของกรอบ OLE คุณสามารถแสดงภาพพรีวิวแบบกำหนดเองแทนข้อความตัวแทนเริ่มต้นได้

## **Related Articles**
[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/th/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/th/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)