---
title: จัดการเซลล์ตารางในงานนำเสนอบน Android
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/androidjava/manage-cells/
keywords:
- เซลล์ตาราง
- ผสานเซลล์
- ลบขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint บน Android: ระบุเซลล์ที่ผสาน, ลบขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่ผสาน, ลบขอบเซลล์, ทำงานกับหมายเลขเซลล์หลังจากการผสานหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีเริ่มจากศูนย์เพื่อเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`.

## **ระบุเซลล์ตารางที่ผสาน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกเป็นตาราง สมมติว่าสไลด์และรูปร่างมีอยู่และรูปร่างเป็นตาราง จากนั้นวนลูปผ่านแถวและคอลัมน์ทั้งหมดและใช้ [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) เพื่อระบุเซลล์ในพื้นที่ที่ผสาน สำหรับแต่ละผลลัพธ์จะพิมพ์พิกัดเซลล์ในรูปแบบ `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), และพิกัดเริ่มต้นของพื้นที่, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) และ [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

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

สร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) และเพิ่มตารางลงบนสไลด์แรกด้วย [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). ความกว้างของคอลัมน์, ความสูงของแถว, และตำแหน่งของตารางระบุเป็นจุด ตัวอย่างกำหนดขอบเซลล์สี่ด้านทั้งหมดให้เป็น [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), ทำให้ขอบไม่ปรากฏ

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

## **ผสานเซลล์ตาราง**

ใช้ [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางให้เป็นเซลล์เดียว ระบุตำแหน่งเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง ตัวเลือกสุดท้ายควบคุมว่าการผสานอาจรวมเซลล์ที่อยู่นอกช่วงที่ระบุหรือไม่; `false` จะทำให้การผสานคงอยู่ภายในช่วงนั้น

ตัวอย่างสร้างตาราง 4x4 ที่คอลัมน์และแถวมีขนาด 70 จุด แล้วผสานเซลล์ศูนย์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)`. เซลล์ที่ได้ครอบคลุมสองคอลัมน์และสองแถว ในขณะที่กริดของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหาหรือรูปแบบของเซลล์ที่ผสานให้ใช้ตำแหน่งมุมซ้ายบน: `table.get_Item(1, 1)` ในตัวอย่างนี้ ตำแหน่งอื่นในช่วงที่ผสานยังคงเป็นส่วนของกริดตาราง ดังนั้นดัชนีของเซลล์นอกช่วงจะไม่เปลี่ยนแปลง

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

การผสานเซลล์ในตัวอย่างก่อนหน้าให้กริดของตารางคงที่ การแยกเซลล์อาจทำให้เกิดคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ที่อยู่ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของ PowerPoint

ตัวอย่างนี้สร้างตาราง 4x4 ที่คอลัมน์และแถวมีขนาด 70 จุดและเรียกใช้ [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) กับเซลล์ `(1, 1)`. ครึ่งหนึ่งของความกว้าง 70 จุดของเซลล์จะถูกใช้เพื่อสร้างเซลล์ที่มีความกว้างเท่ากันสองเซลล์

หลังจากแยกแล้ว ครึ่งสองส่วนจะเข้าถึงได้โดยใช้ `table.get_Item(1, 1)` และ `table.get_Item(2, 1)`. กริดของตารางขณะนี้มีห้าคอลัมน์: เซลล์ที่อยู่ในคอลัมน์ 2 และ 3 เดิมจะย้ายไปยังคอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวไม่เปลี่ยนแปลง ใช้ดัชนีคอลัมน์ที่อัปเดตนี้เมื่อเข้าถึงเซลล์หลังการแยก

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

### **แยกเซลล์ที่ผสานตามแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์เทมเพลตที่ผสานไว้สำหรับการเติมข้อมูล ให้ใช้ [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) เพื่อแยกตามเส้นขอบแถวที่มีอยู่ หรือใช้ [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) เพื่อแยกตามเส้นขอบคอลัมน์

อาร์กิวเมนต์ `index` นับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; ค่าจะสัมพันธ์กับพื้นที่ที่ผสาน:

- การแยกแถว: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- การแยกคอลัมน์: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

ตัวอย่างคาดว่ามีงานนำเสนอที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก โดยมีเซลล์ `(1, 2)` และ `(1, 3)` ผสานกันในแนวตั้ง เริ่มจากตำแหน่งล่างสุด ใช้ [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) และ [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) เพื่อหาตำแหน่งต้นทางและตรวจสอบทั้งสองช่วง `splitByRowSpan(1)` จะทำการแยกแถวที่ 2 และ 3 สำหรับชื่อสินค้า สำหรับการผสานสองคอลัมน์ในแนวนอนให้ใช้ `splitByColSpan(1)` แทน

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

        // ดึงเซลล์ที่ได้จากตารางหลังการแยก.
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

กริดของตารางและดัชนีเซลล์รอบข้างคงที่ ดึงเซลล์ที่ได้โดยใช้พิกัด; ตัวอย่างนี้ทั้งสองเซลล์มีช่วงเป็น 1 และ [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) จะพิมพ์ `false`. พื้นที่ที่ใหญ่ขึ้นอาจยังคงผสานบางส่วนหลังการแยกหนึ่งครั้ง

ข้อความและรูปแบบดั้งเดิมยังคงอยู่ในเซลล์บน (หรือซ้าย); เซลล์ใหม่จะว่างเปล่าแต่รับมรดกรูปแบบเซลล์ เช่น การเติม, ขอบ, และระยะขอบ เติมข้อความลงในเซลล์หลังการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน

งานนำเสนอที่บันทึกไว้จะมีเซลล์ “Product A” และ “Product B” แยกจากกันโดยคงรูปแบบเซลล์ของเทมเพลตไว้ ดูที่ [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) สำหรับรายละเอียด

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางที่คอลัมน์มีขนาด 150 จุดและแถวมีขนาด 50 จุด ใช้ [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) เพื่อเลือกการเติมแบบทึบและตั้งค่าสีที่ได้จาก [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) เป็นสีแดงสำหรับเซลล์ `(2, 3)`, ที่คอลัมน์ที่สามและแถวที่สี่

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

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

วางรูปภาพต้นฉบับในไดเรกทอรีทำงานก่อนรันตัวอย่างนี้ โปรแกรมจะโหลดรูปภาพด้วย [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) และเพิ่มลงในคอลเลกชันภาพของงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). จากนั้นจะกำหนดรูปภาพให้กับการเติมรูปภาพของเซลล์ `(0, 0)`, เซลล์แรกของตาราง

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) จะยืดรูปภาพให้เต็มเซลล์ซึ่งอาจทำให้สัดส่วนเปลี่ยนแปลง ความกว้างของคอลัมน์และความสูงของแถวเป็นหน่วยจุด รูปภาพที่โหลดจะถูกทำลายในบล็อก `finally` หลังจากเพิ่มลงในงานนำเสนอ

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

**ฉันสามารถตั้งความหนาและสไตล์เส้นที่แตกต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ใช่. ขอบ [ด้านบน](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[ด้านล่าง](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[ด้านซ้าย](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[ด้านขวา](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) มีคุณสมบัติแยกกัน จึงสามารถกำหนดความหนาและสไตล์ของแต่ละด้านได้ต่างกัน

**จะเกิดอะไรขึ้นกับรูปภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปเป็นพื้นหลังของเซลล์?**

พฤติจะแตกต่างกันตาม [โหมดเติม](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). หากใช้การยืดรูปภาพจะปรับให้พอดีกับเซลล์ใหม่; หากใช้การเรียงซ้ำ (tiling) จะคำนวณเซลล์ใหม่อีกครั้ง

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[ไฮเปอร์ลิงก์](/slides/th/androidjava/manage-hyperlinks/) จะถูกตั้งระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือระดับของตาราง/รูปร่างทั้งหมด ในการปฏิบัติคุณจะกำหนดลิงก์ให้กับส่วนหรือกับข้อความทั้งหมดในเซลล์

**ฉันสามารถตั้งแบบอักษรที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ใช่. กรอบข้อความของเซลล์รองรับ [ส่วน](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (run) ที่มีการฟอร์แมตอิสระ — ฟอนต์, สไตล์, ขนาด และสี.