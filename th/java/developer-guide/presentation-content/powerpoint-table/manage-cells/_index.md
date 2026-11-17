---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย Java
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/java/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย Java: ระบุเซลล์ที่รวม, ลบขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกัน, ลบขอบเซลล์, ทำงานกับการจัดลำดับเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

Aspose.Slides ใช้ดัชนีเริ่มต้นจากศูนย์เพื่อเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`.

## **ระบุเซลล์ตารางที่รวมกัน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกเป็นตาราง สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นตาราง จากนั้นวนลูปผ่านทุกแถวและคอลัมน์และใช้ [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) เพื่อระบุเซลล์ในบริเวณที่รวมกัน สำหรับแต่ละผลลัพธ์จะแสดงพิกัดเซลล์ในรูป `row;column`, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), และพิกัดเริ่มต้นของบริเวณ, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) และ [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--)  

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

## **ลบขอบเซลล์ตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกด้วย [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) ความกว้างของคอลัมน์, ความสูงของแถว, และตำแหน่งของตารางระบุเป็นพ้อยท์ ตัวอย่างกำหนดให้ขอบเซลล์สี่ด้านทั้งหมดเป็น [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), ทำให้ขอบไม่ปรากฏ  

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

## **เพิ่มขอบเซลล์แบบทแยง**

ใช้ [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) วาดเส้นจากมุมซ้ายบนไปมุมขวาล่าง, และ [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) วาดเส้นจากมุมซ้ายล่างไปมุมขวาบน เส้นทแยงสามารถใช้เป็นหัวข้อมุม; เส้นทแยงทั้งสองสามารถสร้างรูป X เพื่อบ่งบอกว่าเซลล์ไม่ใช้ได้  

แต่ละเส้นทแยงเป็น [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) ใน [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) ใช้ [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) เลือก [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) และเลือกสีผ่าน [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) ตั้งความกว้างของเส้นเป็นพ้อยท์ด้วย [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-)  

ตัวอย่างสร้างสามเซลล์ในแถวเดียว: เส้นทแยงลงสีแดง, เส้นทแยงขึ้นสีฟ้า, และทั้งสองเส้นทแยง คงขอบด้านบน, ล่าง, ซ้าย, ขวาไว้ตามเดิม  

```java
import com.aspose.slides.*;
import java.awt.Color;

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

เส้นทแยงเป็นคุณสมบัติการจัดรูปแบบ, ไม่ใช่การแยกเซลล์ แต่ละเซลล์คงกรอบข้อความเดียวซึ่งเข้าถึงได้ผ่าน [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) ; พื้นที่ทั้งสองข้างของเส้นทแยงไม่สามารถแก้ไขแยกกันได้  

ตารางที่บันทึกแล้ว แสดงผลใน Microsoft PowerPoint:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*จากซ้ายไปขวา: เส้นทแยงลง (สีแดง, 3 pt), เส้นทแยงขึ้น (สีฟ้า, 5 pt), และเส้นทแยงทั้งสอง.*

## **รวมเซลล์ตาราง**

ใช้ [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) รวมช่วงสี่เหลี่ยมของเซลล์ตารางเป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและขวาล่างของช่วง อาร์กิวเมนต์สุดท้ายควบคุมว่าการรวมอาจรวมเซลล์ที่อยู่นอกช่วงที่กำหนดหรือไม่; `false` ทำให้การรวมคงอยู่ภายในช่วงเท่านั้น  

ตัวอย่างสร้างตารางขนาด 4x4 โดยคอลัมน์และแถวละ 70 พอยท์, จากนั้นรวมเซลล์ศูนย์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)` เซลล์ที่ได้จะครอบคลุมสองคอลัมน์และสองแถว, ในขณะที่กริดของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหาหรือรูปแบบของเซลล์ที่รวม ให้ใช้ตำแหน่งมุมซ้ายบน: `table.get_Item(1, 1)` ในตัวอย่างนี้ ตำแหน่งอื่นในช่วงที่รวมยังคงเป็นส่วนหนึ่งของกริดตาราง, ดังนั้นดัชนีของเซลล์ที่อยู่นอกช่วงจะไม่เปลี่ยนแปลง  

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

## **แยกเซลล์ตาราง**

การรวมเซลล์ในตัวอย่างก่อนหน้ารักษากริดของตารางไว้ การแยกเซลล์อาจทำให้เกิดคอลัมน์กริดใหม่และเปลี่ยนดัชนีของเซลล์ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของ PowerPoint  

ตัวอย่างนี้สร้างตาราง 4x4 โดยคอลัมน์และแถวละ 70 พอยท์และเรียก [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) บนเซลล์ `(1, 1)` ส่งค่าความกว้าง 70 พอยท์ครึ่งหนึ่งเพื่อสร้างสองเซลล์ที่มีความกว้างเท่ากัน  

หลังจากแยก, ครึ่งสองส่วนเข้าถึงได้เป็น `table.get_Item(1, 1)` และ `table.get_Item(2, 1)` กริดของตารางตอนนี้มีห้าคอลัมน์: เซลล์ที่เคยอยู่ในคอลัมน์ 2 และ 3 ย้ายไปเป็นคอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวคงที่ ใช้ดัชนีคอลัมน์ที่อัปเดตนี้เมื่อเข้าถึงเซลล์หลังจากแยก  

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
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*การแยกความกว้างส่งผลต่อเซลล์ (1, 1) โดยใช้ดัชนีเริ่มต้นจากศูนย์ (คอลัมน์, แถว) ด้านอื่นของแถวยังคงมีเซลล์ที่ครอบคลุมตำแหน่งคอลัมน์ใหม่ทั้งสอง*
<!-- visual-explanation:manage-cells:end -->

### **แยกเซลล์ที่รวมกันตามช่วงแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์แม่แบบที่รวมไว้สำหรับการเติมข้อมูล, ใช้ [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) แยกตามขอบแถวที่มีอยู่, หรือใช้ [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) แยกตามขอบคอลัมน์  

อาร์กิวเมนต์ `index` นับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; ค่าจากจุดเริ่มต้นของพื้นที่ที่รวม:

- แยกตามแถว: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- แยกตามคอลัมน์: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

ตัวอย่างคาดว่าผลงานนำเสนอมีตารางเป็นรูปร่างแรกบนสไลด์แรก, โดยเซลล์ `(1, 2)` และ `(1, 3)` รวมกันแนวตั้ง เริ่มจากตำแหน่งล่าง ใช้ [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) และ [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) เพื่อหาตำแหน่งเริ่มต้นและตรวจสอบทั้งสองช่วง `splitByRowSpan(1)` จะทำการแยกแถว 2 และ 3 สำหรับชื่อสินค้า สำหรับการรวมแนวนอนสองคอลัมน์ ให้ใช้ `splitByColSpan(1)` แทน  

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

        // ดึงเซลล์ที่ได้จากตารางหลังจากการแยก
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

กริดของตารางและดัชนีเซลล์รอบข้างคงเดิม เรียกเซลล์ที่ได้ด้วยพิกัด; ทั้งสองเซลล์มีช่วงเป็น 1 และ [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) แสดง `false` พื้นที่ใหญ่กว่าสามารถคงเหลือบางส่วนที่ยังรวมอยู่หลังการแยกหนึ่งครั้ง  

ข้อความและรูปแบบเดิมคงอยู่ในเซลล์บน (หรือซ้าย) เซลล์ใหม่เป็นค่าว่างแต่รับสืบทอดรูปแบบเซลล์เช่นสีเติม, ขอบ, และระยะเว้นขอบ เติมข้อความลงในเซลล์หลังการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน  

งานนำเสนอที่บันทึกไว้มีเซลล์ “Product A” และ “Product B” แยกจากกันโดยคงรูปแบบเซลล์ตามแม่แบบ ดูที่ [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) เพื่อรับรายละเอียดเพิ่มเติม  

### **แยกเซลล์ตามความสูงที่กำหนด**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) รับค่าความสูงของส่วนบนเป็นพอยท์ [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) รับจำนวนแถวกริดที่มีอยู่ในส่วนบน เพื่อตำแหน่งเซลล์สูง 40 พอยท์ในคอลัมน์ขวา ให้ลบ 40 จากความสูงจริงของเซลล์และแบ่งพื้นที่ที่เหลือเท่า ๆ กันเหนือและใต้  

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

การแยกครั้งแรกเพิ่มแถวกริดและเหลือ 90 พอยท์ที่ด้านล่างของเซลล์ `(1, 1)` การแยกครั้งที่สองแบ่งเซลล์นั้นเป็นเซลล์กลางสูง 40 พอยท์และเซลล์ล่างสูง 50 พอยท์ คอลัมน์ขวามีสามเซลล์ที่มีความสูง 50, 40, และ 50 พอยท์จากบนลงล่าง เซลล์ซ้ายครอบคลุมทุกแถวสามแถวและคงความสูงเดิมที่ 140 พอยท์  

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางที่คอลัมน์กว้าง 150 พอยท์และแถวสูง 50 พอยท์ ใช้ [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) เลือกเติมสีทึบและตั้งค่าสีที่ได้จาก [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) เป็นสีแดงสำหรับเซลล์ `(2, 3)` ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่  

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

วางรูปภาพต้นฉบับในไดเรกทอรีทำงานก่อนรันตัวอย่างนี้ จะโหลดรูปภาพด้วย [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) และเพิ่มลงในคอลเลกชันภาพของงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) จากนั้นกำหนดภาพให้กับการเติมรูปภาพของเซลล์ `(0, 0)` เซลล์แรกในตาราง  

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) ยืดรูปภาพให้เติมเต็มเซลล์ ซึ่งอาจทำให้อัตราส่วนภาพเปลี่ยน ความกว้างของคอลัมน์และความสูงของแถวเป็นพอยท์ รูปภาพที่โหลดจะถูกทำลายในบล็อก `finally` หลังจากเพิ่มลงในงานนำเสนอ  

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

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นที่แตกต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**  

ใช่. ขอบ [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) มีคุณสมบัติเพียายกัน ดังนั้นความหนาและสไตล์ของแต่ละด้านจึงสามารถแตกต่างกันได้  

**จะเกิดอะไรขึ้นกับรูปภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปเป็นพื้นหลังของเซลล์?**  

พฤติกรรมขึ้นกับ [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile) หากใช้การยืดรูปภาพจะปรับตามเซลล์ใหม่; หากใช้การทำซ้ำ (tile) แผ่นภาพจะถูกคำนวณใหม่  

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**  

[Hyperlinks](/slides/th/java/manage-hyperlinks/) ตั้งระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือที่ระดับตาราง/รูปร่างทั้งหมด ในการปฏิบัติคุณสามารถกำหนดลิงก์ให้กับส่วนหนึ่งหรือกับข้อความทั้งหมดในเซลล์  

**ฉันสามารถตั้งฟอนต์ที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**  

ใช่. กรอบข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (รัน) ที่มีการจัดรูปแบบอิสระ เช่น ชื่อฟอนต์, สไตล์, ขนาด, และสี  