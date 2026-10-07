---
title: จัดการเซลล์ตารางในงานนำเสนอโดยใช้ Java
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
description: "จัดการเซลล์ตาราง PowerPoint ใน Java: ระบุเซลล์ที่รวมกัน, ลบขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint. บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกัน, ลบขอบเซลล์, ทำงานกับการนับหมายเลขเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง. ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

Aspose.Slides ใช้ดัชนีเริ่มจากศูนย์เพื่อเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`.

## **ระบุเซลล์ตารางที่รวมกัน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกเป็นตาราง. มันสมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างนั้นเป็นตาราง. จากนั้นมันวนลูปผ่านทุกแถวและคอลัมน์และใช้ [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) เพื่อระบุเซลล์ในพื้นที่ที่รวมกัน. สำหรับแต่ละที่ตรงกัน, จะพิมพ์พิกัดเซลล์ในลำดับ `row;column`, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), และพิกัดเริ่มต้นของพื้นที่, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) และ [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

สร้าง [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกของมันด้วย [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). ความกว้างของคอลัมน์, ความสูงของแถว, และตำแหน่งของตารางระบุเป็นจุด. ตัวอย่างตั้งค่าขอบเซลล์สี่ด้านทั้งหมดเป็น [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), ทำให้ขอบไม่ปรากฏ.

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

## **รวมเซลล์ตาราง**

ใช้ [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางให้เป็นเซลล์เดียว. ระบุเซลล์ที่มุมบนซ้ายและมุมล่างขวาของช่วง. อาร์กิวเมนต์สุดท้ายกำหนดว่า การรวมอาจรวมเซลล์นอกช่วงที่กำหนดหรือไม่; `false` ทำให้การรวมอยู่ภายในช่วงนั้นเท่านั้น.

ตัวอย่างสร้างตาราง 4x4 ด้วยคอลัมน์และแถวขนาด 70 จุด, จากนั้นรวมเซลล์ศูนย์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)`. เซลล์ที่ได้ครอบคลุมสองคอลัมน์และสองแถว, ในขณะที่กริดพื้นฐานของตารางยังคงมีสี่คอลัมน์และสี่แถว. เพื่อเข้าถึงเนื้อหา或รูปแบบของเซลล์ที่รวม, ใช้ตำแหน่งบนซ้าย: `table.get_Item(1, 1)` ในตัวอย่างนี้. ตำแหน่งอื่นในช่วงที่รวมยังคงเป็นส่วนหนึ่งของกริดตาราง, ดังนั้นดัชนีของเซลล์นอกช่วงจะไม่เปลี่ยนแปลง.

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

การรวมเซลล์ในตัวอย่างก่อนหน้ารักษากริดของตารางไว้. การแยกเซลล์สามารถเพิ่มคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ที่อยู่ทางขวา. Aspose.Slides ปฏิบัติตามโมเดลกริดตารางของ PowerPoint.

ตัวอย่างนี้สร้างตาราง 4x4 ด้วยคอลัมน์และแถวขนาด 70 จุดและเรียกใช้ [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) บนเซลล์ `(1, 1)`. ครึ่งหนึ่งของความกว้าง 70 จุดของเซลล์ถูกส่งผ่านเพื่อสร้างเซลล์สองอันที่มีความกว้างเท่ากัน.

หลังจากแยกนี้, ครึ่งสองส่วนเข้าถึงได้โดย `table.get_Item(1, 1)` และ `table.get_Item(2, 1)`. กริดของตารางขณะนี้มีห้าคอลัมน์: เซลล์ที่เคยอยู่ในคอลัมน์ 2 และ 3 ย้ายไปเป็นคอลัมน์ 3 และ 4 ตามลำดับ. ดัชนีแถวคงที่. ใช้ดัชนีคอลัมน์ที่อัปเดตนี้เมื่อเข้าถึงเซลล์หลังจากการแยก.

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

### **แยกเซลล์ที่รวมกันตามช่วงแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์เทมเพลตที่รวมกันสำหรับการเติมข้อมูล, ใช้ [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) เพื่อแยกตามเส้นขอบแถวที่มีอยู่, หรือ [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) เพื่อแยกตามเส้นขอบคอลัมน์.

อาร์กิวเมนต์ `index` นับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; ค่าจึงสัมพันธ์กับพื้นที่ที่รวมกัน:

- การแยกแถว: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- การแยกคอลัมน์: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

ตัวอย่างสมมติว่ามีงานนำเสนอที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก, โดยเซลล์ `(1, 2)` และ `(1, 3)` รวมกันตามแนวตั้ง. เริ่มจากตำแหน่งด้านล่าง, ใช้ [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) และ [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) เพื่อค้นหาตำแหน่งต้นทางและตรวจสอบทั้งสองช่วง. `splitByRowSpan(1)` จะแยกแถวที่ 2 และ 3 สำหรับชื่อสินค้า. สำหรับการรวมแนวนอนสองคอลัมน์, ใช้ `splitByColSpan(1)` แทน.

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

        // ดึงเซลล์ที่ได้จากตารางหลังจากทำการแยก.
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

กริดของตารางและดัชนีเซลล์โดยรอบคงที่. ดึงเซลล์ที่ได้ตามพิกัด; ในที่นี้ ทั้งสองเซลล์มีช่วงเป็น 1 และ [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) แสดง `false`. พื้นที่ที่ใหญ่กว่าอาจยังคงรวมกันบางส่วนหลังจากการแยกหนึ่งครั้ง.

ข้อความต้นฉบับและรูปแบบของมันคงอยู่ในเซลล์ด้านบน (หรือด้านซ้าย); เซลล์ใหม่ว่างเปล่าแต่สืบทอดรูปแบบเซลล์เช่นการเติม, ขอบ, และระยะเว้น. เติมข้อมูลลงในเซลล์หลังจากการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน.

งานนำเสนอที่บันทึกไว้จะมีเซลล์ "Product A" และ "Product B" แยกกันโดยคงรูปแบบเซลล์ของเทมเพลตไว้. ดูที่ [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) สำหรับรายละเอียด.

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางที่มีคอลัมน์ขนาด 150 จุดและแถวขนาด 50 จุด. มันใช้ [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) เพื่อเลือกการเติมแบบทึบและตั้งค่าสีที่ได้จาก [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) เป็นสีแดงสำหรับเซลล์ `(2, 3)`, ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่.

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

วางรูปภาพต้นเข้าไปในไดเรกทอรีทำงานก่อนเรียกใช้ตัวอย่างนี้. มันโหลดรูปภาพด้วย [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) และเพิ่มมันไปยังคอลเลกชันรูปภาพของงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). จากนั้นกำหนดรูปภาพให้กับการเติมรูปภาพของเซลล์ `(0, 0)`, เซลล์แรกในตาราง.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) ทำให้รูปภาพขยายเต็มเซลล์, ซึ่งอาจเปลี่ยนอัตราส่วนของรูป. ความกว้างของคอลัมน์และความสูงของแถวระบุเป็นจุด. รูปที่โหลดจะถูกทำลายในบล็อก `finally` หลังจากเพิ่มไปยังงานนำเสนอ.

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

## **FAQ**

**Can I set different line thicknesses and styles for different sides of a single cell?**

ใช่. ขอบ [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) มีคุณสมบัติแยกกัน, ดังนั้นความหนาและสไตล์ของแต่ละด้านสามารถต่างกันได้.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile). หากใช้การยืด, รูปภาพจะปรับตามเซลล์ใหม่; หากใช้การทำแผ่นกระเบื้อง, แผ่นกระเบื้องจะถูกคำนวณใหม่.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/th/java/manage-hyperlinks/) ตั้งที่ระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือที่ระดับตาราง/รูปร่างทั้งหมด. โดยปฏิบัติจริง, คุณจะกำหนดลิงก์ให้กับส่วนหนึ่งหรือให้กับข้อความทั้งหมดในเซลล์.

**Can I set different fonts within a single cell?**

ใช่. กรอบข้อความของเซลล์สนับสนุน [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (runs) ที่มีการจัดรูปแบบแยกกัน—แบบอักษร, สไตล์, ขนาด, และสี.