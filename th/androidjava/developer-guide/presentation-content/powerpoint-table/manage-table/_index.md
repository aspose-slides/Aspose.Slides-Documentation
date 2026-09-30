---
title: จัดการตารางงานนำเสนอบน Android
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Android. ค้นหาตัวอย่างโค้ด Java อย่างง่ายเพื่อทำให้กระบวนการทำงานกับตารางของคุณราบรื่นขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint จัดระเบียบข้อมูลเป็นแถวและคอลัมน์ ทำให้อ่านและเปรียบเทียบค่าต่าง ๆ ได้ง่ายขึ้น

Aspose.Slides ให้บริการคลาส [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) คลาส [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) และประเภทอื่น ๆ เพื่อให้คุณสร้าง อัปเดต และจัดการตารางในงานนำเสนอ

## **สร้างตารางจากศูนย์**

สร้างตารางโดยระบุตำแหน่ง ความกว้างของคอลัมน์ และความสูงของแถว หลังจากเพิ่มลงในสไลด์แล้ว คุณสามารถกำหนดรูปแบบเส้นขอบของเซลล์ ผสานเซลล์ และแทรกข้อความได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. กำหนดอาเรย์ของความกว้างคอลัมน์เป็นพอยท์
4. กำหนดอาเรย์ของความสูงแถวเป็นพอยท์
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)
6. วนซ้ำผ่านแต่ละ [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) เพื่อกำหนดรูปแบบเส้นขอบด้านบน ด้านล่าง ขวา และซ้าย
7. ผสานสองเซลล์แรกของแถวแรกของตาราง
8. เรียกเข้าถึงเซลล์ที่ผสานแล้วผ่านเมธอด [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--)
9. ตั้งค่าข้อความในเซลล์ที่ผสาน
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างด้านล่างสร้างตารางที่มี 3 คอลัมน์และ 5 แถวที่ตำแหน่ง (100, 50) พอยท์ กำหนดเส้นขอบสีแดงความกว้าง 5 พอยท์ ผสานสองเซลล์แรกในแถวแรก และบันทึกผลลัพธ์เป็น `table.pptx`

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **การจัดหมายเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน ดัชนีของเซลล์เริ่มจากศูนย์และใช้ลำดับ (คอลัมน์, แถว) เซลล์แรกมีดัชนีเป็น (0, 0)

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกนับดังนี้

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ตัวอย่างนี้สร้างตาราง 4 × 4 ตามที่แสดงด้านบน โดยกำหนดความกว้างคอลัมน์และความสูงแถวเป็น 70 พอยท์ และเส้นขอบเซลล์สีแดงความกว้าง 5 พอยท์ พิกัดแสดงดัชนีของเซลล์; ตัวอย่างปล่อยเซลล์ให้ว่างเปล่าและบันทึกตารางเป็น `StandardTables_out.pptx`

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

ตารางถูกจัดเก็บในคอลเลกชันรูปทรงของสไลด์ วนซ้ำผ่านรูปทรงเพื่อค้นหาตาราง จากนั้นใช้อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) เพื่ออ่านหรืออัปเดตเซลล์ของมัน

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ที่มีตารางตามดัชนีของมัน
3. วนซ้ำผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) และหยุดเมื่อพบตาราง หากสไลด์มีหลายตาราง ให้ใช้เมธอด [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) เพื่อตรวจสอบว่าเป็นตารางที่ต้องการ
4. อัปเดตข้อความในเซลล์เป้าหมาย
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างด้านล่างเปิดไฟล์ `UpdateExistingTable.pptx` และค้นหาตารางแรกในสไลด์แรก ตั้งค่าเซลล์ที่คอลัมน์ 0 แถว 1 เป็น `New` และบันทึกผลลัพธ์เป็น `table1_out.pptx` อินพุตต้องมีอย่างน้อยหนึ่งสไลด์และตารางแรกบนสไลด์นั้นต้องมีอย่างน้อยหนึ่งคอลัมน์และสองแถว

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

เพื่อปรับขนาดแถวในตารางที่มีอยู่และทำความเข้าใจเหตุผลที่ความสูงจริงอาจเกินค่าขั้นต่ำที่ร้องขอ ให้ดูที่ [Control Row Height](/slides/th/androidjava/manage-rows-and-columns/#control-row-height)

## **ค้นหาเซลล์ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดประมวลผลข้อความทั่วไปได้รับอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) จากตาราง ให้ใช้เมธอด [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) เพื่อดึง [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) ที่เป็นเจ้าของ สำหรับ Text Frame ของเซลล์ตาราง เมธอด [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) จะคืนค่าเจ้าของและเมธอด [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) จะคืนค่า `null` แม้ว่าตารางเองจะเป็นรูปทรงก็ตาม

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านเมธอดอ่านอย่างเดียว [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) และ [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--)  เมธอด [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนค่าเจ้าของแต่ไม่ได้เปลี่ยนแปลงความเป็นเจ้าของ อย่าลืมตรวจสอบว่าเซลล์ที่ได้ไม่เป็น `null` ก่อนนำไปใช้

สำหรับตัวอย่างสมบูรณ์ที่ระบุเจ้าของเซลล์ตารางและรูปทรง รวมถึงรูปทรงที่เชื่อมโยงกับโหนด SmartArt ให้ดูที่ [Search and Replace Text](/slides/th/androidjava/search-and-replace-text/)

## **จัดแนวข้อความในตาราง**

คุณสามารถควบคุมการยึดแนวตั้งและทิศทางของข้อความในแต่ละเซลล์ของตาราง ตัวอย่างในส่วนนี้จัดศูนย์ข้อความภายในเซลล์แรกและหมุนข้อความ 270 องศา

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ไปยังสไลด์
4. เข้าถึงอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) จากตาราง
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) แรกและตั้งข้อความและสีของมัน
6. ตั้งค่าการยึดแนวตั้งและทิศทางของข้อความของเซลล์โดยใช้เมธอด [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) และ [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-)
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างนี้สร้างตาราง 4 × 4 ที่มีความกว้างคอลัมน์ 120 พอยท์และความสูงแถว 100 พอยท์ จัดรูปแบบข้อความในเซลล์ (0, 0) เพิ่มค่าลงในเซลล์ที่เหลือของแถวแรก และบันทึกผลลัพธ์เป็น `Vertical_Align_Text_out.pptx`

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **ตั้งค่าการจัดรูปแบบข้อความในระดับตาราง**

ใช้เมธอด [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) เพื่อกำหนดการจัดรูปแบบข้อความให้กับเซลล์ทั้งหมดในตาราง การโอเวอร์โหลดของมันรับรูปแบบส่วน, ย่อหน้า, และ Text Frame ทำให้คุณตั้งค่าคุณสมบัติเหล่านี้ได้โดยไม่ต้องวนผ่านแต่ละเซลล์

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) จากสไลด์
4. ตั้งค่าขนาดฟอนต์โดยใช้เมธอด [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับข้อความ
5. ตั้งค่าการจัดแนวย่อหน้าและระยะขอบขวาโดยใช้เมธอด [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) และ [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)
6. ตั้งค่าทิศทางของข้อความโดยใช้เมธอด [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างด้านล่างเปิดไฟล์ `table.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปทรงแรก ตั้งค่าขนาดฟอนต์เป็น 25 พอยท์ จัดย่อหน้าขวาโดยมีระยะขอบขวา 20 พอยท์ และทำให้ข้อความเป็นแนวตั้ง งานนำเสนอที่จัดรูปแบบแล้วบันทึกเป็น `result.pptx`

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

ใช้เมธอด [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) เพื่ออ่านสไตล์ที่ตั้งไว้ล่วงหน้าของตาราง และใช้เมธอด [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) เพื่อกำหนดสไตล์นั้น ตัวอย่างนี้ใช้ [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) กับตารางหนึ่ง พิมพ์ค่าพรีเซ็ต แล้วกำหนดพรีเซ็ตเดียวกันให้กับตารางที่สอง ทั้งสองตารางบันทึกเป็น `table-style.pptx`

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

อัตราส่วนของตารางคืออัตราส่วนระหว่างความกว้างและความสูงของมัน ใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) เพื่อทำการล็อกอัตราส่วนนี้สำหรับตาราง

ตัวอย่างด้านล่างเปิดไฟล์ `pres.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปทรงแรก พิมพ์สถานะล็อกปัจจุบัน เปิดการล็อกอัตราส่วน พิมพ์สถานะที่อัปเดต (`true`) และบันทึกผลลัพธ์เป็น `pres-out.pptx`

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

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) ทั้งหมดของตารางและข้อความในเซลล์ได้หรือไม่?**

ได้ ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) และย่อหน้ามีเมธอด [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) การใช้ทั้งสองอย่างร่วมกันจะทำให้ลำดับ RTL และการแสดงผลในเซลล์ถูกต้อง

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้ [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ ส่วนล็อกเหล่านี้ใช้ได้กับตารางเช่นกัน

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**

ได้ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) สำหรับเซลล์; รูปภาพจะครอบพื้นที่เซลล์ตามโหมดที่เลือก (ยืดหรือกระเบื้อง)