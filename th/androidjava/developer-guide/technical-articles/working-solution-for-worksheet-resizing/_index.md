---
title: วิธีแก้ปัญหาการปรับขนาดชีตงาน
type: docs
weight: 20
url: /th/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ภาพแสดงตัวอย่าง
- การปรับขนาดภาพ
- Excel
- ชีตงาน
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แก้ไขการปรับขนาด OLE ของชีตงาน Excel ในงานนำเสนอ: สองวิธีเพื่อให้กรอบวัตถุตรงกัน - ปรับขนาดกรอบหรือชีต - ในรูปแบบ PPT และ PPTX"
---
{{% alert color="info" %}}
พบว่าชีตงาน Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint ผ่านคอมโพเนนต์ของ Aspose จะถูกปรับขนาดเป็นสเกลที่ไม่ระบุหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างด้านภาพที่สังเกตได้ระหว่างสถานะก่อนและหลังการเปิดใช้งานของวัตถุ OLE เราได้สอบสวนปัญหานี้อย่างละเอียดและได้ให้วิธีแก้ ซึ่งครอบคลุมในบทความนี้
{{% /alert %}}

## **พื้นฐาน**

ในบทความ [จัดการ OLE](/slides/th/androidjava/manage-ole/) เราได้อธิบายวิธีการเพิ่มเฟรม OLE ลงในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างวัตถุ](/slides/th/androidjava/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดรูปภาพของพื้นที่ชีตงานที่เลือกให้กับเฟรม OLE ในงานนำเสนอที่ได้ผลลัพธ์ เมื่อคุณดับเบิลคลิกที่เฟรม OLE ที่แสดงรูปภาพของชีต งาน Excel จะถูกเปิดใช้งาน ผู้ใช้ขั้นสุดท้ายสามารถทำการเปลี่ยนแปลงใดๆ ที่ต้องการกับไฟล์ Excel จริงแล้วกลับไปยังสไลด์โดยคลิกนอกไฟล์ Excel ที่เปิดอยู่ ขนาดของเฟรม OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปยังสไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันตามขนาดของเฟรม OLE และไฟล์ Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจากไฟล์งาน Excel มีขนาดหน้าต่างของตนเอง มันพยายามคงขนาดเดิมไว้เมื่อติดตั้งครั้งแรก ในขณะเดียวกันเฟรม OLE มีขนาดของมันเอง ตามที่ Microsoft ระบุ เมื่อไฟล์งาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้แน่ใจว่ารักษาส่วนสัดส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดขึ้นตามความแตกต่างระหว่างขนาดหน้าต่าง Excel กับขนาดและตำแหน่งของเฟรม OLE

## **วิธีแก้ปัญหา**

มีวิธีแก้สองวิธีเพื่อหลีกเลี่ยงผลของการปรับขนาด

- ปรับขนาดเฟรม OLE ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างของจำนวนแถวและคอลัมน์ที่ต้องการในเฟรม OLE
- คงขนาดเฟรม OLE ไคยไว้และปรับขนาดของแถวและคอลัมน์ที่เกี่ยวข้องให้พอดีกับขนาดเฟรม OLE ที่เลือก

### **ปรับขนาดเฟรม OLE**

ในวิธีนี้ เราจะเรียนรู้วิธีตั้งค่าขนาดเฟรม OLE ของไฟล์ Excel ที่ฝังไว้ให้ตรงกับขนาดรวมของแถวและคอลัมน์ที่เกี่ยวข้องในชีตงาน Excel

สมมติว่าเรามีแผ่นงาน Excel เป็นเทมเพลตและต้องการเพิ่มลงในงานนำเสนอเป็นเฟรม OLE ในสถานการณ์นี้ ขนาดของเฟรม OLE จะถูกคำนวณเป็นครั้งแรกจากความสูงแถวและความกว้างคอลัมน์รวมของแถวและคอลัมน์ที่เกี่ยวข้องในเวิร์กบุ๊ก จากนั้นเราจะตั้งค่าขนาดของเฟรม OLE ให้เป็นค่าที่คำนวณได้ เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับเฟรม OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งเป็นภาพของเฟรม OLE

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// รับความกว้างและความสูงของภาพ OLE เป็นหน่วยพอยต์.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// เราต้องใช้เวิร์กบุ๊กที่ปรับปรุงแล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// สร้างเฟรมวัตถุ OLE.
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

### **ปรับขนาดช่วงเซลล์**

ในวิธีนี้ เราจะเรียนรู้วิธีปรับความสูงของแถวที่เกี่ยวข้องและความกว้างของคอลัมน์ที่เกี่ยวข้องให้ตรงกับขนาดเฟรม OLE ที่กำหนดเอง

สมมติว่าเรามีแผ่นงาน Excel เป็นเทมเพลตและต้องการเพิ่มลงในงานนำเสนอเป็นเฟรม OLE ในสถานการณ์นี้ เราจะตั้งค่าขนาดของเฟรม OLE และปรับขนาดของแถวและคอลัมน์ที่เข้าร่วมในพื้นที่เฟรม OLE จากนั้นเราจะบันทึกเวิร์กบุ๊กลงในสตรีมเพื่อใช้การเปลี่ยนแปลงและแปลงเป็นอาเรย์ไบต์เพื่อเพิ่มลงในเฟรม OLE เพื่อหลีกเลี่ยงข้อความสีแดง “EMBEDDED OLE OBJECT” สำหรับเฟรม OLE ใน PowerPoint เราจะจับภาพส่วนที่ต้องการของแถวและคอลัมน์ในเวิร์กบุ๊กและตั้งเป็นภาพของเฟรม OLE

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

// ตั้งค่าขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็นวัตถุ OLE ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับสเกลช่วงเซลล์ให้พอดีกับขนาดเฟรม.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้เวิร์กบุ๊กที่ปรับแก้แล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มภาพ OLE ไปยังทรัพยากรของงานนำเสนอ.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// สร้างเฟรมวัตถุ OLE.
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
 * @param width     ความกว้างที่คาดหวังของช่วงเซลล์ในหน่วยพอยต์.
 * @param height    ความสูงที่คาดหวังของช่วงเซลล์ในหน่วยพอยต์.
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

## **สรุป**

{{% alert color="info" %}} 
มีสองวิธีเพื่อแก้ไขปัญหาการปรับขนาดของชีตงาน การเลือกวิธีที่เหมาะสมขึ้นอยู่กับความต้องการและกรณีการใช้งานเฉพาะ ทั้งสองวิธีทำงานแบบเดียวกัน ไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีข้อจำกัดเรื่องขนาดของเฟรม OLE ในวิธีนี้
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ทำไมชีตงาน Excel ที่ฝังอยู่จึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?

เกิดจาก Excel พยายามคงขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ในขณะที่เฟรม OLE ใน PowerPoint มีมิติของตัวเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วน ซึ่งทำให้เกิดการปรับขนาด

### สามารถป้องกันปัญหาการปรับขนาดนี้ได้อย่างสมบูรณ์หรือไม่?

ทำได้โดยปรับขนาดเฟรม OLE ให้พอดีกับขนาดช่วงเซลล์ของ Excel หรือปรับขนาดช่วงเซลล์ให้พอดีกับขนาดเฟรม OLE ที่ต้องการ ซึ่งจะป้องกันการปรับขนาดที่ไม่ต้องการ

### ควรใช้วิธีการปรับขนาดใด ควรใช้การปรับขนาดเฟรม OLE หรือการปรับขนาดช่วงเซลล์?

เลือก **การปรับขนาดเฟรม OLE** หากต้องการคงขนาดแถวและคอลัมน์ของ Excel ดั้งเดิม เลือก **การปรับขนาดช่วงเซลล์** หากต้องการให้เฟรม OLE มีขนาดคงที่ในงานนำเสนอของคุณ

### วิธีการเหล่านี้จะทำงานได้หรือไม่หากงานนำเสนอของฉันสร้างจากเทมเพลต?

ทำงานได้ทั้งในงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

### มีขนาดจำกัดของเฟรม OLE เมื่อใช้วิธีเหล่านี้หรือไม่?

ไม่มีข้อจำกัด คุณสามารถทำให้เฟรม OLE มีขนาดเท่าไรก็ตามตราบใดที่ตั้งค่าการสเกลอย่างเหมาะสม

### มีวิธีใดที่จะหลีกเลี่ยงข้อความแทนที่ “EMBEDDED OLE OBJECT” ใน PowerPoint หรือไม่?

ทำได้โดยถ่ายภาพช่วงเซลล์ Excel ที่ต้องการและตั้งเป็นภาพแทนของเฟรม OLE ซึ่งจะแสดงภาพตัวอย่างที่กำหนดเองแทนข้อความแทนที่เริ่มต้น