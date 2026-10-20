---
title: วิธีแก้ปัญหาการปรับขนาด Worksheet ที่ใช้งานได้
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
description: "แก้ไขการปรับขนาด OLE ของแผ่นงาน Excel ในงานนำเสนอ: สองวิธีเพื่อให้กรอบวัตถุคงที่—ปรับขนาดกรอบหรือแผ่นงาน—ในรูปแบบ PPT และ PPTX"
---
{{% alert color="info" title="Note" %}}
Excel worksheets ที่ฝังเป็น OLE objects ในงานนำเสนอ PowerPoint โดยใช้คอมโพเนนต์ของ Aspose อาจปรับขนาดโดยไม่คาดคิดหลังจากการเปิดใช้งานครั้งแรก พฤติกรรมนี้ทำให้เกิดความแตกต่างด้านภาพที่สังเกตได้ระหว่าง OLE object ก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายปัญหาและแนะนำสองวิธีในการแก้ไข
{{% /alert %}}

## **พื้นหลัง**

ในบทความ [จัดการ OLE](/slides/th/androidjava/manage-ole/), เราได้อธิบายวิธีเพิ่ม OLE frame ลงในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อแก้ไข [ปัญหาการแสดงตัวอย่างวัตถุ](/slides/th/androidjava/object-preview-issue-when-adding-oleobjectframe/), เราได้กำหนดภาพของพื้นที่ worksheet ที่เลือกให้กับ OLE object frame ในงานนำเสนอผลลัพธ์ เมื่อคุณดับเบิลคลิกที่ OLE object frame ที่แสดงภาพ worksheet, workbook ของ Excel จะถูกเปิดใช้งาน ผู้ใช้ขั้นสุดท้ายสามารถทำการเปลี่ยนแปลงใด ๆ ที่ต้องการกับ workbook จริงของ Excel แล้วกลับไปยังสไลด์โดยคลิกนอก workbook ที่เปิดใช้งาน ขนาดของ OLE object frame จะเปลี่ยนเมื่อผู้ใช้กลับไปยังสไลด์ ปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดของ OLE object frame และ workbook ของ Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

เนื่องจาก workbook ของ Excel มีขนาดหน้าต่างของตัวเอง จึงพยายามคงขนาดเดิมไว้เมื่อตั้งค่าเปิดใช้งานครั้งแรก ในทางกลับกัน OLE object frame มีขนาดของตนเอง ตามที่ Microsoft ระบุ เมื่อ workbook ของ Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดเพื่อให้คงอัตราส่วนที่ถูกต้องเป็นส่วนหนึ่งของกระบวนการฝัง การปรับขนาดเกิดจากความแตกต่างระหว่างขนาดหน้าต่างของ Excel กับขนาดและตำแหน่งของ OLE object frame

## **วิธีแก้ที่ใช้งานได้**

มีสองวิธีแก้ไขที่เป็นไปได้เพื่อหลีกเลี่ยงผลการปรับขนาด

- ปรับขนาด OLE frame ในงานนำเสนอ PowerPoint ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือก
- คงขนาด OLE frame ไคไว้คงที่และปรับขนาดแถวและคอลัมน์ที่เลือกให้พอดีกับมัน

### **ปรับขนาด OLE Frame Size**

วิธีนี้ตั้งค่าขนาดของ OLE frame ให้ตรงกับความสูงและความกว้างรวมของแถวและคอลัมน์ที่เลือกใน worksheet ของ Excel ที่ฝังอยู่

ตัวอย่างนี้โหลด workbook ของ Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของ worksheet แรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) กำหนดช่วงที่จะแสดง ตัวอย่างภาพพรีวิวถูกเรนเดอร์ที่ 96 DPI และมิติพิกเซลถูกแปลงเป็น points โดยใช้ 72 points ต่ออินช์ [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ฝัง workbook ที่แก้ไขแล้วในกรอบที่มีขนาดดังกล่าว พรีวิวถูกกำหนดผ่าน [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) เพื่อแทนที่ตำแหน่งตัวอักษรแทนที่ "EMBEDDED OLE OBJECT" ในงานนำเสนอที่บันทึก

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

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

ตัวช่วยพรีวิวตั้งค่า [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) ให้เป็นช่วงที่เลือกและลบช่องขอบ, ส่วนหัวและส่วนท้าย พร้อมกับเปิดใช้งาน [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) ทำให้ [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) แสดงผลช่วงเป็นภาพ PNG ตัวช่วยจะส่งคืน stream อินพุตใหม่ที่มีภาพ PNG อยู่ที่ตำแหน่งเริ่มต้นเพื่อใช้ในงานนำเสนอ

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

วิธีนี้ปรับความสูงของแถวที่เลือกและความกว้างของคอลัมน์ที่เลือกให้ตรงกับขนาด OLE frame ที่กำหนดเอง

ตัวอย่างนี้โหลด workbook ของ Excel ที่มีอยู่และเลือกแถวแรก 10 แถวและคอลัมน์แรก 13 คอลัมน์ของ worksheet แรกโดยใช้ดัชนีเริ่มจากศูนย์ [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) กำหนดช่วงที่แสดง และตัวช่วยด้านล่างปรับขนาดช่วงนั้นให้พอดีกับกรอบที่กว้าง 400 points และสูง 100 points หลังจากบันทึก workbook ที่แก้ไขลงใน stream, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ฝังมันด้วยขนาดที่ระบุ พรีวิวที่เรนเดอร์ที่ 96 DPI ถูกกำหนดผ่าน [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) เพื่อให้งานนำเสนอที่บันทึกแสดงเซลล์ที่เลือกแทนตำแหน่งตัวอักษรเริ่มต้น

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

// กำหนดขนาดที่แสดงเมื่อไฟล์เวิร์กบุ๊กถูกใช้เป็น OLE object ใน PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// ปรับขนาดช่วงเซลล์ให้พอดิกับขนาดกรอบ.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// เราต้องใช้เวิร์กบุ๊กที่แก้ไขแล้ว.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มภาพ OLE ลงในทรัพยากรของงานนำเสนอ.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// สร้างกรอบ OLE object.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

ตัวช่วยการปรับขนาดคำนวณอัตราส่วนความกว้างและความสูงแยกกันสำหรับช่วงที่เลือก โดยคงความกว้างสัมพัทธ์ของคอลัมน์และความสูงสัมพัทธ์ของแถวไว้ มันแปลงมิติที่คำนวณจาก points เป็น inches ก่อนนำไปใช้กับ [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) และ [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). ช่วงที่เลือกต้องมีความกว้างและความสูงไม่เป็นศูนย์

```java
/**
 * @param width     ความกว้างที่คาดหวังของช่วงเซลล์ในหน่วย points.
 * @param height    ความสูงที่คาดหวังของช่วงเซลล์ในหน่วย points.
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

ตัวช่วยพรีวิวนี้เรนเดอร์ช่วงที่ปรับขนาดใหม่โดยใช้ [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) มันจำกัด [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) ไว้ที่ช่วงนั้น, ลบช่องขอบ, ส่วนหัวและส่วนท้าย, และส่งคืน stream PNG ที่อยู่ตำแหน่งเริ่มต้น

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
มีสองวิธีในการแก้ไขปัญหาการปรับขนาด worksheet เลือกวิธีที่เหมาะกับความต้องการและกรณีการใช้งานของคุณ ทั้งสองวิธีทำงานแบบเดียวกัน ไม่ว่าจะสร้างงานนำเสนอจากเทมเพลตหรือจากศูนย์ นอกจากนี้ไม่มีขีดจำกัดขนาดของ OLE object frame ในวิธีนี้
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ทำไม worksheet ของ Excel ที่ฝังอยู่ถึงเปลี่ยนขนาดเมื่อเปิดใช้งานครั้งแรกใน PowerPoint?**

นี่เกิดขึ้นเนื่องจาก Excel พยายามคงขนาดหน้าต่างเดิมเมื่อเปิดใช้งาน ขณะที่ OLE object frame ใน PowerPoint มีมิติของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อคงอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

**สามารถป้องกันปัญหาการปรับขนาดนี้ได้อย่างสมบูรณ์หรือไม่?**

ใช่. โดยการปรับขนาด OLE frame ให้พอดีกับขนาดช่วงเซลล์ของ Excel หรือปรับขนาดช่วงเซลล์ให้พอดูกับขนาด OLE frame ที่ต้องการ คุณสามารถป้องกันการปรับขนาดที่ไม่ต้องการได้

**ควรใช้วิธีการปรับขนาดใด OLE frame scaling หรือ cell range scaling?**

เลือก **OLE frame scaling** หากคุณต้องการคงขนาดเดิมของแถวและคอลัมน์ใน Excel เลือก **cell range scaling** หากคุณต้องการขนาดคงที่สำหรับ OLE frame ในงานนำเสนอของคุณ

**วิธีแก้เหล่านี้จะทำงานได้หรือไม่หากงานนำเสนอของฉันสร้างจากเทมเพลต?**

ใช่. ทั้งสองวิธีทำงานได้กับงานนำเสนอที่สร้างจากเทมเพลตและจากศูนย์

**มีขีดจำกัดขนาดของ OLE frame หรือไม่เมื่อใช้วิธีเหล่านี้?**

ไม่มี. คุณสามารถกำหนดขนาด OLE object frame ได้ตามต้องการ ตราบใดที่ตั้งค่าการสเกลอย่างเหมาะสม

**มีวิธีหลีกเลี่ยงข้อความตัวอย่าง "EMBEDDED OLE OBJECT" ใน PowerPoint หรือไม่?**

ใช่. โดยการจับภาพช่วงเซลล์ของ Excel ที่ต้องการและตั้งค่าเป็นรูปภาพตัวแทนของ OLE frame คุณสามารถแสดงภาพพรีวิวที่กำหนดเองแทนตำแหน่งตัวอย่างเริ่มต้นได้

## **บทความที่เกี่ยวข้อง**

[สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็น OLE Object](/slides/th/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[อัปเดต OLE Objects โดยอัตโนมัติด้วย MS PowerPoint Add-In](/slides/th/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)