---
title: จัดการตารางการนำเสนอใน Java
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/java/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วน
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Java. ค้นหาตัวอย่างโค้ดง่าย ๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระเบียบและรวดเร็วขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล ข้อมูลในตารางเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) มีความชัดเจนและเข้าใจง่าย.

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/java/com.aspose.slides/Table) อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) คลาส [Cell](https://reference.aspose.com/slides/th/java/com.aspose.slides/cell/) อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/) และประเภทอื่น ๆ เพื่อให้คุณสร้าง ปรับปรุง และจัดการตารางในงานนำเสนอทุกประเภท. 

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. กำหนดอาร์เรย์ของ `columnWidth`.
4. กำหนดอาร์เรย์ของ `rowHeight`.
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) ไปยังสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. ทำการวนซ้ำผ่านแต่ละ [ICell](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/) เพื่อกำหนดรูปแบบให้กับเส้นขอบด้านบน, ด้านล่าง, ด้านขวาและด้านซ้าย.
7. รวมเซลล์สองเซลล์แรกของแถวแรกของตาราง. 
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ของ [ICell](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/). 
9. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/).
10. บันทึกการนำเสนอที่แก้ไขแล้ว.

โค้ด Java ตัวนี้จะแสดงวิธีสร้างตารางในงานนำเสนอ:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // เพิ่มรูปทรงตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // กำหนดรูปแบบขอบสำหรับแต่ละเซลล์
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
    // รวมเซลล์ที่ 1 และ 2 ของแถวที่ 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // เพิ่มข้อความบางส่วนลงในเซลล์ที่รวมแล้ว
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // บันทึกการนำเสนอลงดิสก์
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การกำหนดหมายเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน การระบุหมายเลขของเซลล์เป็นแบบง่ายและเริ่มจากศูนย์ เซลล์แรกในตารางมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0). 

สำหรับตัวอย่าง ตารางที่มี 4 คอลัมน์และ 4 แถวจะมีการกำหนดหมายเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด Java ตัวนี้จะแสดงวิธีระบุหมายเลขสำหรับเซลล์ในตาราง:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปทรงตารางลงในสไลด์
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

    // บันทึกการนำเสนอลงดิสก์
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).

2. รับอ้างอิงสไลด์ที่มีตารางผ่านดัชนีของมัน. 

3. สร้างอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) และกำหนดค่าเป็น null.

4. วนซ้ำผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) ทั้งหมดจนกว่าจะพบตาราง.

   หากคุณสงสัยว่าสไลด์ที่คุณกำลังทำงานอยู่มีเพียงตารางเดียว คุณสามารถตรวจสอบรูปทรงทั้งหมดที่สไลด์มีได้โดยตรง เมื่อรูปทรงถูกระบุว่าเป็นตาราง คุณสามารถแปลงเป็นอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/th/java/com.aspose.slides/Table) ได้ แต่หากสไลด์มีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่านเมธอด [setAlternativeText(String value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. ใช้อ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราเพิ่มแถวใหม่ให้กับตาราง.

6. บันทึกการนำเสนอที่แก้ไขแล้ว.

โค้ด Java ตัวนี้จะแสดงวิธีเข้าถึงและทำงานกับตารางที่มีอยู่:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดค่าเริ่มต้นเป็น null สำหรับ TableEx
    ITable tbl = null;

    // วนผ่านรูปร่างและตั้งค่าอ้างอิงไปยังตารางที่พบ
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // ตั้งค่าข้อความสำหรับคอลัมน์แรกของแถวที่สอง
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // บันทึกการนำเสนอที่แก้ไขลงดิสก์
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ค้นหาเซลล์ที่เป็นเจ้าของกรอบข้อความ**

เมื่อโค้ดการประมวลผลข้อความทั่วไปได้รับ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) จากตาราง ให้ใช้เมธอด [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentCell--) เพื่อดึง [ICell](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/) ที่เป็นเจ้าของ สำหรับกรอบข้อความของเซลล์ตาราง [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentCell--) จะคืนค่าเจ้าของและ [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentShape--) จะคืนค่า `null` แม้ว่าตารางเองจะเป็นรูปทรงก็ตาม.

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านเมธอดแบบอ่านอย่างเดียว [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/#getFirstColumnIndex--) และ [ICell.getFirstRowIndex](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/#getFirstRowIndex--). เมธอด [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentCell--) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนค่าเจ้าของแต่ไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบว่าเซลล์ที่คืนค่ามีค่า `null` หรือไม่ก่อนใช้เสมอ.

สำหรับตัวอย่างสมบูรณ์ที่ระบุเจ้าของเซลล์ตารางและรูปทรง รวมถึงรูปทรงที่เชื่อมโยงกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/java/search-and-replace-text/).

## **จัดแนวข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) ไปยังสไลด์. 
4. เข้าถึงอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) จากตาราง. 
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) ของ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/).
6. จัดแนวข้อความตามแนวตั้ง.
7. บันทึกการนำเสนอที่แก้ไขแล้ว.

โค้ด Java ตัวนี้จะแสดงวิธีจัดแนวข้อความในตาราง:

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
    
    // เพิ่มรูปทรงตารางลงในสไลด์
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // เข้าถึงกรอบข้อความ
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // สร้างอ็อบเจ็กต์ Paragraph สำหรับกรอบข้อความ
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // สร้างอ็อบเจ็กต์ Portion สำหรับย่อหน้า
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // จัดแนวข้อความในแนวตั้ง
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // บันทึกการนำเสนอลงดิสก์
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable) จากสไลด์.
4. ตั้งค่าเมธอด [setFontHeight(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับข้อความ. 
5. ตั้งค่าเมธอด [setAlignment(int value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. ตั้งค่าเมธอด [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. บันทึกการนำเสนอที่แก้ไขแล้ว. 

โค้ด Java ตัวนี้จะแสดงวิธีนำตัวเลือกการจัดรูปแบบที่คุณต้องการไปใช้กับข้อความในตาราง:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // สมมติว่า shape แรกบนสไลด์แรกเป็นตาราง
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // ตั้งค่าความสูงของฟอนต์ในเซลล์ตาราง
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // ตั้งค่าการจัดแนวข้อความและระยะห่างขวาของเซลล์ตารางในครั้งเดียว
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // ตั้งค่าชนิดการวางแนวตั้งของข้อความในเซลล์ตาราง
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับคุณสมบัติรูปแบบของตาราง**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติรูปแบบของตารางเพื่อใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือในที่อื่น โค้ด Java ตัวนี้จะแสดงวิธีดึงคุณสมบัติรูปแบบจากสไตล์ที่กำหนดล่วงหน้าของตาราง:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // เปลี่ยน preset สไตล์เริ่มต้นของธีม

    // ดึง preset สไตล์ของตาราง
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // ใช้ preset สไตล์ที่ดึงมาให้กับตารางอื่น
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงเรขาคณิตคืออัตราส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีคุณสมบัติ [**setAspectRatioLocked**](https://reference.aspose.com/slides/th/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) เพื่อให้คุณล็อกการตั้งค่าอัตราส่วนสำหรับตารางและรูปทรงอื่น ๆ 

โค้ด Java ตัวนี้จะแสดงวิธีล็อกอัตราส่วนสำหรับตาราง:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // สลับ

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ของมันได้ไหม?**

ใช่. ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/table/#setRightToLeft-boolean-) และย่อหน้ามีเมธอด [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). การใช้ทั้งสองจะทำให้ลำดับ RTL และการแสดงผลภายในเซลล์ถูกต้อง.

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/java/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, เลือก เป็นต้น การล็อกเหล่านี้ใช้กับตารางเช่นกัน.

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังรองรับหรือไม่?**

ใช่. คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturefillformat/) ให้กับเซลล์; ภาพจะครอบพื้นที่เซลล์ตามโหมดที่เลือก (ขยายหรือเรียงต่อกัน).