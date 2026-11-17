---
title: จัดการเซลตารางในงานนำเสนอบน Android
linktitle: จัดการเซล
type: docs
weight: 30
url: /th/androidjava/manage-cells/
keywords:
- เซลตาราง
- รวมเซล
- ลบกรอบ
- แยกเซล
- รูปภาพในเซล
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการเซลตาราง PowerPoint บน Android: ระบุเซลที่รวมกัน, ลบกรอบ, แยกเซล, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเข้าถึงและแก้ไขเซลตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีระบุเซลที่รวมกัน, ลบกรอบเซล, ทำงานกับการจัดเลขเซลหลังจากรวมหรือแยกเซล, เปลี่ยนสีพื้นหลังของเซล, และเพิ่มรูปภาพภายในเซลตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลผ่านคุณสมบัติของเซล, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีเริ่มต้นจากศูนย์เพื่อเข้าถึงเซลตารางตามลำดับ `(column, row)`.

## **ระบุเซลที่รวมกัน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกในสไลด์แรกเป็นตาราง สมมติว่ามีสไลด์และรูปร่างและรูปร่างเป็นตาราง จากนั้นวนลูปผ่านแถวและคอลัมน์ทั้งหมดและใช้ [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) เพื่อระบุเซลในพื้นที่ที่รวมกัน สำหรับแต่ละการตรงกันจะแสดงพิกัดเซลในลำดับ `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), และพิกัดเริ่มต้นของพื้นที่, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) และ [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **ลบกรอบเซลตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) และเพิ่มตารางในสไลด์แรกโดยใช้ [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) ความกว้างคอลัมน์, ความสูงแถว, และตำแหน่งของตารางระบุเป็นพอยต์ ตัวอย่างตั้งค่ากรอบเซลทั้งสี่เป็น [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) ทำให้ไม่มองเห็นได้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มกรอบเซลแบบทแยง**

ใช้ [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) เพื่อวาดเส้นจากมุมบนซ้ายไปมุมล่างขวาและ [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) เพื่อวาดเส้นจากมุมล่างซ้ายไปมุมบนขวา เส้นทแยงสามารถทำเครื่องหมายหัวข้อมุมได้; เส้นทแยงทั้งสองสามารถสร้างรูป X เพื่อทำเครื่องหมายเซลว่าไม่ใช้ได้

แต่ละเส้นทแยงเป็น [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/). ใน [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) ให้ใช้ [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) เพื่อเลือก [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) และเลือกสีผ่าน [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--). ตั้งความกว้างของเส้นเป็นพอยต์ด้วย [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-).

ตัวอย่างสร้างเซลสามเซลในแถวเดียว: เส้นทแยงลงสีแดง, เส้นทแยงขึ้นสีฟ้า, และเส้นทแยงทั้งสอง โดยทิ้งกรอบบน, ล่าง, ซ้าย, ขวาไว้เหมือนเดิม

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เส้นทแยงเป็นคุณสมบัติการจัดรูปแบบ ไม่ใช่การแยกเซล แต่ละเซลจะเก็บเฟรมข้อความเดียวเข้าถึงได้ผ่าน [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--); พื้นที่ด้านใดด้านหนึ่งของเส้นทแยงไม่สามารถแก้ไขแยกจากกันได้

The saved table, rendered in Microsoft PowerPoint:

![เซลตารางสามเซลที่แสดงเส้นทแยงสีแดงจากบนซ้ายไปล่างขวา, เส้นทแยงสีน้ำเงินจากล่างซ้ายไปบนขวา, และเส้นทแยงสองเส้นสร้างรูป X.](diagonal-cell-borders.png)

*จากซ้ายไปขวา: เส้นทแยงลง (สีแดง, 3 pt), เส้นทแยงขึ้น (สีน้ำเงิน, 5 pt), และเส้นทแยงสองเส้น*

## **รวมเซลตาราง**

ใช้ [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) เพื่อรวมช่วงสี่เหลี่ยมของเซลตารางให้เป็นเซลเดียว กำหนดเซลที่มุมบนซ้ายและมุมล่างขวาของช่วง อากิวเมนต์สุดท้ายควบคุมว่าการรวมอาจรวมเซลที่อยู่นอกช่วงที่ระบุหรือไม่; `false` จะทำให้การรวมอยู่ในช่วงนั้นเท่านั้น

ตัวอย่างสร้างตาราง 4x4 ที่คอลัมน์และแถวมีความกว้าง 70 พอยต์ แล้วรวมเซลศูนย์กลางสี่เซลจาก `(1, 1)` ถึง `(2, 2)` เซลที่ได้จะครอบคลุมสองคอลัมน์และสองแถว ขณะที่กริดของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหา或รูปแบบของเซลที่รวม ให้ใช้ตำแหน่งบนซ้ายของเซล: `table.get_Item(1, 1)` ในตัวอย่างนี้ ตำแหน่งอื่น ๆ ในช่วงที่รวมยังคงเป็นส่วนหนึ่งของกริดตาราง ดังนั้นดัชนีของเซลที่อยู่นอกช่วงจะไม่เปลี่ยน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แยกเซลตาราง**

การรวมเซลในตัวอย่างก่อนหน้าเก็บกริดของตารางไว้ การแยกเซลอาจสร้างคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลที่อยู่ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของ PowerPoint

ตัวอย่างนี้สร้างตาราง 4x4 ที่คอลัมน์และแถวมีความกว้าง 70 พอยต์และเรียกใช้ [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) บนเซล `(1, 1)` ครึ่งความกว้าง 70 พอยต์ของเซลถูกส่งเข้าเพื่อสร้างเซลสองเซลที่มีความกว้างเท่ากัน

หลังจากการแยกนี้ ครึ่งสองส่วนเข้าถึงได้เป็น `table.get_Item(1, 1)` และ `table.get_Item(2, 1)` ตารางตอนนี้มีห้าคอลัมน์: เซลที่เคยอยู่ในคอลัมน์ 2 และ 3 ย้ายไปเป็นคอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวไม่เปลี่ยน ใช้ดัชนีคอลัมน์ที่อัปเดตเมื่อเข้าถึงเซลหลังการแยก

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


<!-- visual-explanation:manage-cells:start -->
[![เซลที่มีความกว้าง 70 พอยต์ที่ไม่ได้รวมกันแยกเป็นเซลสองเซลที่มีความกว้าง 35 พอยต์, เพิ่มคอลัมน์กริดที่ห้าและเลื่อนดัชนีที่อยู่ทางขวา.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*การแยกความกว้างส่งผลต่อเซล (1, 1) โดยใช้ดัชนี (column, row) เริ่มจากศูนย์ แถวอื่น ๆ ยังคงมีเซลที่ครอบคลุมตำแหน่งคอลัมน์ใหม่ทั้งสอง.*
<!-- visual-explanation:manage-cells:end -->

### **แยกเซลที่รวมกันตามแถวหรือคอลัมน์**

เพื่อเตรียมเซลเทมเพลตที่รวมไว้สำหรับการใส่ข้อมูล ให้ใช้ [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) เพื่อแยกตามขอบเขตแถวที่มีอยู่ หรือ [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) เพื่อแยกตามขอบเขตคอลัมน์

อากิวเมนต์ `index` นับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; มันสัมพันธ์กับพื้นที่ที่รวมกัน:

- การแยกแถว: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- การแยกคอลัมน์: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

ตัวอย่างคาดว่าการนำเสนอมีตารางเป็นรูปร่างแรกในสไลด์แรก โดยเซล `(1, 2)` และ `(1, 3)` รวมกันในแนวตั้ง เริ่มจากตำแหน่งล่าง ใช้ [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) และ [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) เพื่อหาตำแorigin และตรวจสอบทั้งสองช่วง `splitByRowSpan(1)` จะแยกแถว 2 และ 3 สำหรับชื่อสินค้า สำหรับการรวมสองคอลัมน์ในแนวนอน ใช้ `splitByColSpan(1)` แทน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // ดึงเซลผลลัพธ์จากตารางหลังจากการแยก
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

กริดของตารางและดัชนีเซลโดยรอบคงเดิม ดึงเซลที่ได้ตามพิกัด; ที่นี่ทั้งสองมีช่วงเท่ากับ 1 และ [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) แสดง `false` พื้นที่ที่ใหญ่กว่าสามารถคงอยู่เป็นบางส่วนที่รวมไว้หลังการแยกหนึ่งครั้ง

ข้อความต้นฉบับและรูปแบบยังคงอยู่ในเซลบน (หรือซ้าย) เซลใหม่จะว่างเปล่าแต่สืบทอดรูปแบบเซลเช่นสีพื้น, กรอบ, และระยะห่าง เติมข้อมูลในเซลหลังการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการโดยชัดเจน

งานนำเสนอที่บันทึกไว้มีเซล “Product A” และ “Product B” แยกกันโดยยังคงรูปแบบเซลของเทมเพลต ดู [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) สำหรับรายละเอียด

### **แยกเซลตามความสูงที่ระบุ**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) รับความสูงของส่วนบนเป็นพอยต์ [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) รับจำนวนแถวกริดที่มีอยู่ในส่วนบน เพื่อวางเซล 40 พอยต์ไว้ตรงกลางคอลัมน์ขวา ให้ลด 40 จากความสูงจริงของเซลและแบ่งพื้นที่ที่เหลือเท่า ๆ กันด้านบนและด้านล่าง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การแยกแรกเพิ่มแถวกริดและเหลือพื้นที่ด้านล่าง 90 พอยต์ในเซล `(1, 1)` การแยกที่สองแบ่งเซลนั้นเป็นเซลกลาง 40 พอยต์และเซลล่าง 50 พอยต์ คอลัมน์ขวาตอนนี้มีสามเซลที่มีความสูง 50, 40, และ 50 พอยต์จากบนลงล่าง เซลซ้ายครอบคลุมทั้งสามแถวและคงความสูงเดิมที่ 140 พอยต์

![เซลซ้ายครอบคลุมความสูงเต็มของตารางข้างเซลสามเซลที่มีข้อความ Middle อยู่ตรงกลาง.](split-by-height.png)

## **เปลี่ยนสีพื้นหลังของเซลตาราง**

ตัวอย่างนี้สร้างตารางที่คอลัมน์กว้าง 150 พอยต์และแถวสูง 50 พอยต์ ใช้ [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) เพื่อเลือกการเติมสีแบบทึบและตั้งสีที่ได้จาก [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) เป็นสีแดงสำหรับเซล `(2, 3)` ที่คอลัมน์ที่สามและแถวที่สี่

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มรูปภาพภายในเซลตาราง**

วางรูปภาพนำเข้าในไดเร็กทอรีการทำงานก่อนรันตัวอย่างนี้ จะโหลดรูปด้วย [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) แล้วเพิ่มลงในคอลเลกชันรูปของงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). จากนั้นกำหนดรูปให้กับการเติมภาพของเซล `(0, 0)` ซึ่งเป็นเซลแรกในตาราง

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) จะยืดรูปเพื่อเติมเซล ซึ่งอาจเปลี่ยนอัตราส่วนของรูป ความกว้างคอลัมน์และความสูงแถวเป็นพอยต์ ภาพที่โหลดจะถูกกำจัดในบล็อก `finally` หลังจากเพิ่มลงในงานนำเสนอ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นต่าง ๆ สำหรับแต่ละด้านของเซลเดียวได้หรือไม่?**

ใช่. ขอบ [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) มีคุณสมบัติเสริมแยกกัน ดังนั้นความหนาและสไตล์ของแต่ละด้านจึงสามารถแตกต่างกันได้

**ภาพจะเกิดอะไรขึ้นหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปเป็นพื้นหลังของเซล?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) หากยืดรูปภาพจะปรับให้เข้ากับเซลใหม่; หากเป็นการ tiled รูปภาพย่อยจะถูกคำนวณใหม่

**ฉันสามารถกำหนดไฮเพอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลได้หรือไม่?**

[Hyperlinks](/slides/th/androidjava/manage-hyperlinks/) จะตั้งที่ระดับข้อความ (portion) ภายในเฟรมข้อความของเซลหรือที่ระดับตาราง/รูปร่างทั้งหมด ในการใช้งานจริงคุณกำหนดลิงก์ให้กับ portion หรือให้กับข้อความทั้งหมดในเซล

**ฉันสามารถตั้งฟอนต์ต่าง ๆ ภายในเซลเดียวได้หรือไม่?**

ใช่. เฟรมข้อความของเซลสนับสนุน [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (runs) ที่มีการจัดรูปแบบอิสระ — ครอบครัวฟอนต์, สไตล์, ขนาด, และสี.