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
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในการนำเสนอ: สองวิธีเพื่อให้กรอบออบเจกต์สอดคล้องกัน - ปรับขนาดกรอบหรือแผ่นงาน - ในรูปแบบ PPT และ PPTX"
---
{{% alert color="info" title="Note" %}}
แผ่นงาน Excel ที่ฝังเป็นออบเจกต์ OLE ในการนำเสนอ PowerPoint ด้วยคอมโพเนนต์ของ Aspose อาจเปลี่ยนขนาดโดยไม่คาดคิดหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างด้านภาพที่ชัดเจนระหว่างออบเจกต์ OLE ก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายปัญหาและแสดงวิธีแก้สองวิธี
{{% /alert %}}

## **พื้นหลัง**

ในบทความ [จัดการ OLE](/slides/th/java/manage-ole/), เราอธิบายวิธีการเพิ่มกรอบ OLE ลงในการนำเสนอ PowerPoint ด้วย Aspose.Slides for Java. เพื่อจัดการกับ [ปัญหาการแสดงตัวอย่างออบเจกต์](/slides/th/java/object-preview-issue-when-adding-oleobjectframe/), เราได้กำหนดรูปภาพของพื้นที่แผ่นงานที่เลือกให้กับกรอบออบเจกต์ OLE. ในการนำเสนอที่ได้, เมื่อคุณดับเบิลคลิกที่กรอบออบเจกต์ OLE ที่แสดงรูปภาพแผ่นงาน, ไฟล์งาน Excel จะเปิดใช้งาน. ผู้ใช้ปลายทางสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการกับไฟล์งาน Excel จริงและจากนั้นกลับไปยังสไลด์โดยคลิกนอกไฟล์งาน Excel ที่เปิดใช้งาน. ขนาดของกรอบออบเจกต์ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์. ปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของกรอบออบเจกต์ OLE และไฟล์งาน Excel ที่ฝังอยู่.

## **สาเหตุของการปรับขนาด**

เนื่องจากไฟล์งาน Excel มีขนาดหน้าต่างของตนเอง มันพยายามรักษาขนาดเดิมเมื่อตอนเปิดใช้งานครั้งแรก ในทางกลับกันกรอบออบเจกต์ OLE มีขนาดของมันเอง ตามข้อมูลของ Microsoft เมื่อไฟล์งาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้รักษาสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดขึ้นจากความแตกต่างระหว่างขนาดหน้าต่าง Excel และขนาดและตำแหน่งของกรอบออบเจกต์ OLE.

## **วิธีแก้ที่ทำงาน**

มีสองวิธีแก้ที่เป็นไปได้เพื่อหลีกเลี่ยงผลการปรับขนาด.

- ปรับขนาดกรอบ OLE ในการนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือก.
- รักษาขนาดกรอบ OLE คงที่และปรับขนาดแถวและคอลัมน์ที่เลือกให้พอดีภายในกรอบ.

### **ปรับขนาดกรอบ OLE**

วิธีนี้ตั้งค่าขนาดกรอบ OLE ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือกในแผ่นงาน Excel ที่ฝังอยู่.

ตัวอย่างโหลดไฟล์งาน Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) กำหนดช่วงที่แสดง. ตัวอย่างก่อนแสดง (preview) ถูกเรนเดอร์ที่ 96 DPI และขนาดพิกเซลของมันถูกแปลงเป็นพ้อยต์โดยใช้ 72 พ้อยต์ต่ออินช์. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ฝังไฟล์งานที่ปรับเปลี่ยนลงในกรอบที่มีขนาดดังกล่าว. ตัวอย่างก่อนแสดงถูกกำหนดผ่าน [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) เพื่อแทนที่ตัวยึดตำแหน่ง "EMBEDDED OLE OBJECT" ในการนำเสนอที่บันทึก.

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

// ตั้งค่าขนาดที่แสดงเมื่อตัวไฟล์ workbook ถูกใช้เป็นออบเจกต์ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// รับความกว้างและความสูงของภาพ OLE หน่วยเป็นพ้อยต์.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// เราต้องใช้ workbook ที่แก้ไขแล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของการนำเสนอ.
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

ตัวช่วยแสดงตัวอย่างตั้งค่า [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) ให้เป็นช่วงที่เลือกและลบขอบ, ส่วนหัว, ส่วนท้าย. เมื่อเปิดใช้งาน [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) , [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) จะเรนเดอร์ช่วงเป็นภาพ PNG. ตัวช่วยจะคืนค่า stream ใหมที่มีภาพ PNG อยู่ที่ตำแหน่งเริ่มต้นเพื่อใช้ในการนำเสนอ.

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

### **ปรับขนาดช่วงเซลล์**

วิธีนี้ปรับสเกลความสูงของแถวที่เลือกและความกว้างของคอลัมน์ที่เลือกให้ตรงกับขนาดกรอบ OLE ที่กำหนดเอง.

ตัวอย่างโหลดไฟล์งาน Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของแผ่นงานแรกโดยใช้ดัชนีเริ่มจากศูนย์. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) กำหนดช่วงที่แสดงและตัวช่วยด้านล่างปรับสเกลช่วงนั้นให้พอดีกับกรอบขนาด 400 พ้อยต์กว้างและ 100 พ้อยต์สูง. หลังจากบันทึกไฟล์งานที่แก้ไขลงใน stream, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ฝังไฟล์นั้นในขนาดที่ระบุ. ตัวอย่างก่อนแสดงที่เรนเดอร์ที่ 96 DPI ถูกกำหนดผ่าน [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) ดังนั้นการนำเสนอที่บันทึกจะแสดงเซลล์ที่เลือกแทนตัวยึดตำแหน่งเริ่มต้น.

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

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์ workbook ถูกใช้เป็นออบเจกต์ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดกรอบ.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้ workbook ที่แก้ไขแล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของการนำเสนอ.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// สร้างกรอบออบเจกต์ OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

ตัวช่วยการสเกลคำนวณอัตราส่วนความกว้างและความสูงแยกกันสำหรับช่วงที่เลือก, รักษาความกว้างสัมพัทธ์ของคอลัมน์และความสูงสัมพัทธ์ของแถว. มันจะแปลงมิติที่คำนวณจากพ้อยต์เป็นนิ้วก่อนนำไปใช้ด้วย [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) และ [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). ช่วงที่เลือกต้องมีความกว้างและความสูงที่ไม่เป็นศูนย์.

```java
/**
 * @param width     ความกว้างที่คาดหวังของช่วงเซลล์ในหน่วยพ้อยต์.
 * @param height    ความสูงที่คาดหวังของช่วงเซลล์ในหน่วยพ้อยต์.
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

ตัวช่วยแสดงตัวอย่างนี้เรนเดอร์ช่วงที่ปรับขนาดโดยใช้ [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). มันจำกัด [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) ไว้ที่ช่วงนั้น, ลบขอบ, ส่วนหัว, ส่วนท้าย, และคืนค่า stream PNG ที่อยู่ที่ตำแหน่งเริ่มต้น.

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

## **สรุป**

{{% alert color="info" title="Note" %}}
มีสองแนวทางในการแก้ไขปัญหาการปรับขนาดแผ่นงาน. เลือกแนวทางที่ตรงกับความต้องการและกรณีการใช้งานของคุณมากที่สุด. ทั้งสองแนวทางทำงานในลักษณะเดียวกัน, ไม่ว่าจะเป็นการสร้างการนำเสนอจากแม่แบบหรือจากศูนย์. นอกจากนี้ไม่มีขีดจำกัดขนาดของกรอบออบเจกต์ OLE ในวิธีแก้นี้.
{{% /alert %}}

## **FAQ**

**ทำไมแผ่นงาน Excel ที่ฝังอยู่จึงเปลี่ยนขนาดเมื่อตอนเปิดใช้งานครั้งแรกใน PowerPoint?**  
นี่เกิดขึ้นเนื่องจาก Excel พยายามรักษาขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน, ในขณะที่กรอบออบเจกต์ OLE ใน PowerPoint มีมิติของมันเอง. PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ, ซึ่งอาจทำให้เกิดการปรับขนาด.

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้โดยสมบูรณ์หรือไม่?**  
ได้. โดยการปรับสเกลกรอบ OLE ให้พอดีกับช่วงเซลล์ Excel หรือปรับสเกลช่วงเซลล์ให้พอดูกับขนาดกรอบ OLE ที่ต้องการ, คุณสามารถป้องกันการปรับขนาดที่ไม่ต้องการได้.

**ฉันควรใช้วิธีการสเกลแบบใด, การสเกลกรอบ OLE หรือการสเกลช่วงเซลล์?**  
เลือก **การสเกลกรอบ OLE** หากคุณต้องการรักษาขนาดแถวและคอลัมน์ของ Excel ดั้งเดิม. เลือก **การสเกลช่วงเซลล์** หากคุณต้องการขนาดคงที่สำหรับกรอบ OLE ในการนำเสนอของคุณ.

**วิธีแก้เหล่านี้จะทำงานได้หรือไม่หากการนำเสนอของฉันอ้างอิงจากแม่แบบ?**  
ได้. ทั้งสองวิธีทำงานสำหรับการนำเสนอที่สร้างจากแม่แบบและจากศูนย์.

**มีขีดจำกัดขนาดของกรอบ OLE เมื่อใช้วิธีเหล่านี้หรือไม่?**  
ไม่มี. คุณสามารถกำหนดขนาดกรอบออบเจกต์ OLE ได้ตามต้องการตราบใดที่คุณตั้งค่าสเกลอย่างเหมาะสม.

**มีวิธีหลีกเลี่ยงข้อความตัวยึดตำแหน่ง "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**  
ได้. โดยการถ่ายภาพช่วงเซลล์ Excel ที่ต้องการและตั้งค่าเป็นภาพตัวยึดตำแหน่งของกรอบ OLE, คุณสามารถแสดงภาพตัวอย่างที่กำหนดเองแทนตัวยึดตำแหน่งเริ่มต้น.

## **บทความที่เกี่ยวข้อง**

[การสร้างแผนภูมิ Excel และฝังลงในการนำเสนอเป็นออบเจกต์ OLE](/slides/th/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[อัปเดตออบเจกต์ OLE โดยอัตโนมัติด้วย Add-In ของ MS PowerPoint](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)