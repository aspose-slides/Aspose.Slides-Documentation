---
title: จัดการตารางงานนำเสนอใน Java
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
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Java. ค้นพบตัวอย่างโค้ดง่าย ๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระบบมากขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint จัดระเบียบข้อมูลเป็นแถวและคอลัมน์ ทำให้อ่านและเปรียบเทียบค่าได้ง่ายขึ้น.

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) , อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) , คลาส [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) , อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) , และประเภทอื่น ๆ เพื่อให้คุณสามารถสร้าง, ปรับปรุงและจัดการตารางในงานนำเสนอได้.

## **สร้างตารางตั้งแต่ต้น**

สร้างตารางโดยระบุตำแหน่ง, ความกว้างของคอลัมน์, และความสูงของแถว หลังจากเพิ่มลงในสไลด์ คุณสามารถจัดรูปแบบเส้นขอบของเซลล์, ผสานเซลล์, และแทรกข้อความได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. กำหนดอาเรย์ของความกว้างคอลัมน์เป็นหน่วยจุด.
4. กำหนดอาเรย์ของความสูงแถวเป็นหน่วยจุด.
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. วนรอบผ่านแต่ละ [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) เพื่อนำรูปแบบไปใช้กับเส้นขอบบน, ล่าง, ขวา, และซ้าย.
7. ผสานสองเซลล์แรกของแถวแรกของตาราง.
8. เข้าถึงเซลล์ที่ผสานโดยใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) .
9. ตั้งค่าข้อความในเซลล์ที่ผสาน.
10. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างด้านล่างสร้างตารางที่มีสามคอลัมน์และห้าแถวที่ตำแหน่ง (100, 50) จุด มันใส่เส้นขอบสีแดงด้วยความกว้าง 5 จุด, ผสานสองเซลล์แรกในแถวแรก, และบันทึกผลลัพธ์เป็น `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การนับลำดับในตารางมาตรฐาน**

ในตารางมาตรฐาน ดัชนีของเซลล์เริ่มจากศูนย์และใช้ลำดับ (คอลัมน์, แถว) เซลล์แรกมีดัชนีเป็น (0, 0).

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกนับตามนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ตัวอย่างนี้สร้างตาราง 4 × 4 ตามภาพด้านบน โดยกำหนดความกว้างคอลัมน์และความสูงแถวเป็น 70 จุด และเส้นขอบเซลล์สีแดงด้วยความกว้าง 5 จุด พิกัดแสดงดัชนีของเซลล์; ตัวอย่างนี้ทิ้งเซลล์ให้ว่างและบันทึกตารางเป็น `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เข้าถึงตารางที่มีอยู่**

ตารางถูกเก็บในคอลเลกชันรูปร่างของสไลด์. วนรอบผ่านรูปร่างเพื่อตรวจหาตาราง, จากนั้นใช้อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) เพื่ออ่านหรืออัปเดตเซลล์ของมัน.

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. รับอ้างอิงไปยังสไลด์ที่มีตารางโดยใช้ดัชนีของมัน.
3. วนรอบผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) และหยุดเมื่อพบตาราง หากสไลด์มีหลายตาราง, ใช้ [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) เพื่อระบุตารางที่คุณต้องการ.
4. อัปเดตข้อความในเซลล์เป้าหมาย.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างด้านล่างเปิดไฟล์ `UpdateExistingTable.pptx` และค้นหาตารางแรกบนสไลด์แรก มันตั้งค่าเซลล์ที่คอลัมน์ 0, แถว 1 เป็น `New` และบันทึกผลลัพธ์เป็น `table1_out.pptx` อินพุตต้องมีอย่างน้อยหนึ่งสไลด์ และตารางแรกบนสไลด์นั้นต้องมีอย่างน้อยหนึ่งคอลัมน์และสองแถว.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

เพื่อปรับขนาดแถวในตารางที่มีอยู่และทำความเข้าใจว่าทำไมความสูงจริงอาจเกินค่าต่ำสุดที่ร้องขอ, ดูที่ [Control Row Height](/slides/th/java/manage-rows-and-columns/#control-row-height).

## **ค้นหาเซลล์ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดการประมวลผลข้อความทั่วไปได้รับ [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) จากตาราง, ใช้เมธอด [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) เพื่อดึง [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) ที่เป็นเจ้าของ สำหรับ Text Frame ของเซลล์ตาราง, [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) จะคืนค่าเจ้าของและ [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) จะคืนค่า `null` แม้วัตารางเองจะเป็นรูปร่างก็ตาม.

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านเมธอดอ่านอย่างเดียว [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) และ [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) . [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนค่าเจ้าของแต่ไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบว่าเซลล์ที่คืนค่ามาเป็น `null` หรือไม่เสมอก่อนนำไปใช้.

สำหรับตัวอย่างเต็มที่ระบุเจ้าของตาราง-เซลล์และรูปร่าง, รวมถึงรูปร่างที่เชื่อมโยงกับโหนด SmartArt, ดูที่ [Search and Replace Text](/slides/th/java/search-and-replace-text/).

## **จัดแนวข้อความในตาราง**

คุณสามารถควบคุมการยึดแนวตั้งและทิศทางข้อความของเซลล์ตารางแต่ละอัน ตัวอย่างในส่วนนี้จัดกึ่งกลางข้อความภายในเซลล์แรกและหมุนมัน 270 องศา.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) ไปยังสไลด์.
4. เข้าถึงอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) จากตาราง.
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) ตัวแรกและตั้งค่าข้อความและสีของมัน.
6. ตั้งค่าการยึดแนวตั้งและทิศทางข้อความของเซลล์โดยใช้ [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) และ [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างนี้สร้างตาราง 4 × 4 ที่มีความกว้างคอลัมน์ 120 จุดและความสูงแถว 100 จุด มันจัดรูปแบบข้อความในเซลล์ (0, 0), เพิ่มค่าในเซลล์ที่เหลือในแถวแรก, และบันทึกผลลัพธ์เป็น `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

ใช้ [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) เพื่อใช้การจัดรูปแบบข้อความกับเซลล์ทั้งหมดในตาราง การโอเวอร์โหลดของมันรับการจัดรูปแบบส่วน, ย่อหน้า, และ Text Frame, ดังนั้นคุณสามารถตั้งค่าเหล่านี้โดยไม่ต้องวนรอบผ่านเซลล์แต่ละอัน.

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) จากสไลด์.
4. ตั้งค่าขนาดฟอนต์โดยใช้ [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับข้อความ.
5. ตั้งค่าการจัดแนวย่อหน้าและขอบขวาโดยใช้ [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. ตั้งค่าทิศทางข้อความโดยใช้ [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างด้านล่างเปิดไฟล์ `table.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปร่างแรกของมัน มันตั้งค่าขนาดฟอนต์เป็น 25 จุด, จัดย่อหน้าทางขวาพร้อมขอบขวา 20 จุด, และทำให้ข้อความเป็นแนวตั้ง งานนำเสนอที่จัดรูปแบบแล้วจะถูกบันทึกเป็น `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้ [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) เพื่ออ่านสไตล์ที่ตั้งไว้ของตารางและ [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) เพื่อกำหนดสไตล์นั้น ตัวอย่างนี้ใช้ [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) กับตารางหนึ่ง, พิมพ์ค่าพรีเซ็ต, และกำหนดพรีเซ็ตเดียวกันให้กับตารางที่สอง ตารางทั้งสองจะถูกบันทึกใน `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของตารางคืออัตราส่วนระหว่างความกว้างและความสูงของมัน ใช้ [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) เพื่อล็อกอัตราส่วนนี้สำหรับตาราง.

ตัวอย่างนี้เปิดไฟล์ `pres.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปร่างแรกของมัน มันพิมพ์สถานะล็อกปัจจุบัน, เปิดใช้งานการล็อกอัตราส่วน, พิมพ์สถานะที่อัปเดต (`true`), และบันทึกผลลัพธ์เป็น `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ของมันได้หรือไม่?**

ใช่. ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) และย่อหน้ามี [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) การใช้ทั้งสองจะทำให้ลำดับ RTL ถูกต้องและการเรนเดอร์ภายในเซลล์เป็นไปอย่างเหมาะสม.

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์ขั้นสุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/java/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, เลือก ฯลฯ การล็อกเหล่านี้ใช้กับตารางด้วย.

**การแทรกภาพภายในเซลล์เป็นพื้นหลังรองรับหรือไม่?**

ใช่. คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) สำหรับเซลล์; ภาพจะครอบพื้นที่เซลล์ตามโหมดที่เลือก (ขยายหรือเรียงต่อกัน).