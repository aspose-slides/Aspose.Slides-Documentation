---
title: จัดการตารางการนำเสนอใน Android
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/androidjava/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วนภาพ
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Android ค้นหาตัวอย่างโค้ด Java ง่าย ๆ เพื่อทำให้การทำงานกับตารางของคุณเป็นขั้นตอนที่ราบรื่นขึ้น"
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและอธิบายข้อมูล ข้อมูลในกริดของเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) มีความชัดเจนและเข้าใจง่าย.

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Table) , อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) , คลาส [Cell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cell/) , อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/) และประเภทอื่น ๆ เพื่อให้คุณสามารถสร้าง, ปรับปรุงและจัดการตารางในงานนำเสนอทุกประเภทได้.

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. กำหนดอาร์เรย์ของ `columnWidth`.
4. กำหนดอาร์เรย์ของ `rowHeight`.
5. เพิ่มอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) ลงในสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. วนผ่านแต่ละ [ICell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/) เพื่อใช้การจัดรูปแบบกับขอบบน, ล่าง, ขวาและซ้าย.
7. ผสานเซลล์สองเซลล์แรกของแถวแรกของตาราง. 
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ของ [ICell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/).
9. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/).
10. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Java นี้จะแสดงวิธีการสร้างตารางในงานนำเสนอ:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // รวมเซลล์ 1 และ 2 ของแถว 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // เพิ่มข้อความบางส่วนลงในเซลล์ที่รวมกัน
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การกำหนดลำดับในตารางมาตรฐาน**

ในตารางมาตรฐาน การกำหนดหมายเลขของเซลล์เป็นเรื่องตรงไปตรงมาและเริ่มต้นที่ศูนย์ เซลล์แรกในตารางมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0). 

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกเรียงลำดับดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด Java นี้จะแสดงวิธีการระบุลำดับหมายเลขของเซลล์ในตาราง:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).

2. รับการอ้างอิงของสไลด์ที่มีตารางผ่านดัชนีของมัน. 

3. สร้างอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) และกำหนดค่าเป็น null.

4. วนผ่านอ็อบเจกต์ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ทั้งหมดจนกว่าจะพบตาราง.

   ถ้าคุณสงสัยว่าสไลด์ที่กำลังทำงานอยู่มีตารางเดียว คุณสามารถตรวจสอบรูปทรงทั้งหมดที่สไลด์นั้นบรรจุได้โดยตรง เมื่อรูปทรงถูกระบุว่าเป็นตาราง คุณสามารถทำการแคสท์เป็นอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Table) แต่ถ้าสไลด์นั้นมีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่านเมธอด [setAlternativeText(String value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. ใช้อ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราตั้งค่าข้อความของเซลล์ในตาราง.

6. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Java นี้จะแสดงวิธีการเข้าถึงและทำงานกับตารางที่มีอยู่:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดค่าเริ่มต้นเป็น null สำหรับ TableEx
    ITable tbl = null;

    // วนผ่านรูปทรณะทั้งหมดและกำหนดการอ้างอิงไปยังตารางที่พบ
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // ตั้งค่าข้อความสำหรับคอลัมน์แรกของแถวที่สอง
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ค้นหาเซลล์ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดการประมวลผลข้อความทั่วไปได้รับอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) จากตาราง ให้ใช้เมธอด [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentCell--) เพื่อดึง [ICell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/) ที่เป็นเจ้าของ สำหรับ Text Frame ของเซลล์ในตาราง [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentCell--) จะคืนค่าเจ้าของและ [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentShape--) จะคืนค่า `null` แม้ว่าตารางเองจะเป็นรูปทรงก็ตาม

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านเมธอดอ่านอย่างเดียว [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) และ [ICell.getFirstRowIndex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/#getFirstRowIndex--). เมธอด [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentCell--) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนค่าเจ้าของแต่ไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบว่าเซลล์ที่คืนค่ามีค่า `null` หรือไม่ก่อนใช้งานเสมอ

สำหรับตัวอย่างสมบูรณ์ที่ระบุเจ้าของของเซลล์และรูปทรง รวมถึงรูปทรงที่เชื่อมกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/androidjava/search-and-replace-text/).

## **จัดแนวข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่มอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) ลงในสไลด์.
4. เข้าถึงอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) จากตาราง.
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) ของ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/).
6. จัดแนวข้อความในแนวตั้ง.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Java นี้จะแสดงวิธีการจัดแนวข้อความในตาราง:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // เขาถึง Text Frame
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // สร้างอ็อบเจกต์ Paragraph สำหรับ Text Frame
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // จัดแนวข้อความในแนวตั้ง
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เข้าถึงอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) จากสไลด์.
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับข้อความ.
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ด Java นี้จะแสดงวิธีการใช้ตัวเลือกการจัดรูปแบบที่คุณต้องการกับข้อความในตาราง:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // ตั้งค่าความสูงของฟอนต์ในเซลล์ตาราง
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // ตั้งค่าการจัดแนวข้อความและขอบขวาของเซลล์ตารางในหนึ่งคำสั่ง
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // ตั้งค่าประเภทการจัดแนวข้อความในแนวตั้งของเซลล์ตาราง
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ให้คุณดึงคุณสมบัติสไตล์ของตารางเพื่อที่คุณจะได้นำรายละเอียดเหล่านั้นไปใช้กับตารางอื่นหรือที่อื่น โค้ด Java นี้จะแสดงวิธีการรับคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดล่วงหน้า:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // เปลี่ยนธีม preset style เริ่มต้น

    // Get the style preset of the table
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Apply the retrieved style preset to another table
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ล็อคอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงเรขาคณิตคืออัตราส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีคุณสมบัติ [**setAspectRatioLocked**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) เพื่อให้คุณสามารถล็อคการตั้งค่าอัตราส่วนสำหรับตารางและรูปทรงอื่น ๆ

โค้ด Java นี้จะแสดงวิธีการล็อคอัตราส่วนสำหรับตาราง:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // สลับค่า

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันสามารถเปิดใช้ทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ได้หรือไม่?**

ใช่ ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) และพารากราฟมี [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). การใช้ทั้งสองวิธีร่วมกันจะทำให้ลำดับ RTL ถูกต้องและการแสดงผลภายในเซลล์เป็นไปตามที่คาดหวัง.

**ฉันจะป้องกันผู้ใช้ไม่ให้ย้ายหรือปรับขนาดตารางในไฟล์ขั้นสุดท้ายได้อย่างไร?**

ใช้การล็อครูปทรงเพื่อปิดการย้าย, ปรับขนาด, การเลือก เป็นต้น การล็อคเหล่านี้ทำงานกับตารางเช่นกัน.

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturefillformat/) สำหรับเซลล์; รูปภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ยืดหรือเรียงต่อกัน).