---
title: จัดการเซลล์ตารางในงานนำเสนอบน Android
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/androidjava/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบเส้นขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการเซลล์ตารางใน PowerPoint อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java. เชี่ยวชาญการเข้าถึง, แก้ไขและจัดรูปแบบเซลล์อย่างรวดเร็วเพื่อการทำงานอัตโนมัติของสไลด์อย่างราบรื่น."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเข้าถึงและแก้ไขเซลล์ของตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกันแล้ว, ลบเส้นขอบของเซลล์, ทำงานกับการกำหนดหมายเลขเซลล์หลังจากการรวมหรือการแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างจะแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ระบุตารางที่รวมเซลล์**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. ดึงตารางจากสไลด์แรก
3. วนลูปผ่านแถวและคอลัมน์ของตารางเพื่อค้นหาเซลล์ที่รวมกัน
4. พิมพ์ข้อความเมื่อพบเซลล์ที่รวมกัน

โค้ด Java นี้แสดงวิธีระบุตารางที่รวมเซลล์ในงานนำเสนอ:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // สมมติว่า Slide#0.Shape#0 เป็นตาราง
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบเส้นขอบของเซลล์ตาราง**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง
4. กำหนดอาเรย์ของแถวพร้อมความสูง
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-)
6. วนลูปผ่านทุกเซลล์เพื่อลบเส้นขอบบน, ล่าง, ขวาและซ้าย
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีลบเส้นขอบจากเซลล์ตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การกำหนดหมายเลขในเซลล์ที่รวมกัน**
หากเรารวมเซลล์ 2 คู่ (1,1) x (2,1) และ (1,2) x (2,2) ตารางที่ได้จะมีการกำหนดหมายเลข โค้ด Java นี้แสดงกระบวนการ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
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

    // รวมเซลล์ (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // รวมเซลล์ (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

จากนั้นเราเพิ่มการรวมเซลล์ต่อโดยการรวม (1,1) กับ (1,2) ผลลัพธ์คือ جدول يحتوي على خلية مدمجة كبيرة في وسطه:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
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

    // รวมเซลล์ (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // รวมเซลล์ (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // รวมเซลล์ (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การกำหนดหมายเลขในเซลล์ที่แยกออก**
ในตัวอย่างก่อนหน้าเมื่อเซลล์ตารางถูกรวมกัน ระบบการนับหรือหมายเลขในเซลล์อื่น ๆ ไม่เปลี่ยนแปลง

ครั้งนี้เราจะใช้ตารางปกติ (ตารางที่ไม่มีเซลล์รวม) แล้วทำการแยกเซลล์ (1,1) เพื่อสร้างตารางพิเศษ คุณอาจสังเกตการกำหนดหมายเลขของตารางนี้ที่ดูแปลก แต่นั่นเป็นวิธีที่ Microsoft PowerPoint จัดหมายเลขเซลล์ตารางและ Aspose.Slides ทำเช่นเดียวกัน

โค้ด Java นี้แสดงกระบวนการที่อธิบายไว้:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
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

    // รวมเซลล์ (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // รวมเซลล์ (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // แยกเซลล์ (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

โค้ด Java นี้แสดงวิธีเปลี่ยนสีพื้นหลังของเซลล์ตาราง:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // สร้างตารางใหม่
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // ตั้งค่าสีพื้นหลังสำหรับเซลล์ 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง
4. กำหนดอาเรย์ของแถวพร้อมความสูง
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด [AddTable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-)
6. สร้างอ็อบเจกต์ `Images` เพื่อถือไฟล์รูปภาพ
7. เพิ่มรูปภาพ `IImage` ไปยังอ็อบเจกต์ `IPPImage`
8. ตั้งค่า `FillFormat` ของเซลล์ตารางเป็น `Picture`
9. เพิ่มรูปภาพลงในเซลล์แรกของตาราง
10. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีใส่รูปภาพภายในเซลล์ตารางเมื่อสร้างตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide islide = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // สร้างอ็อบเจกต์ IPPImage โดยใช้ไฟล์รูปภาพ
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่มรูปภาพไปยังเซลล์ตารางแรก
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันสามารถตั้งค่าความหนาและสไตล์เส้นที่ต่างกันสำหรับด้านต่าง ๆ ของเซลล์เดียวได้หรือไม่?**

ได้. เส้นขอบ [top](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellformat/#getBorderRight--) มีคุณสมบัติแยกกัน จึงสามารถกำหนดความหนาและสไตล์ของแต่ละด้านให้ต่างกันได้ ซึ่งสอดคล้องกับการควบคุมเส้นขอบฝ่ายละด้านสำหรับเซลล์ที่แสดงในบทความนี้

**ภาพจะเกิดอะไรขึ้นถ้าฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นกับ [fill mode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) หากใช้การยืดรูปภาพจะปรับตามเซลล์ใหม่; หากใช้การเรียงกระเบื้องจะคำนวณกระเบื้องใหม่ บทความได้อธิบายโหมดการแสดงภาพในเซลล์แล้ว

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/androidjava/manage-hyperlinks/) ถูกตั้งค่าในระดับข้อความ (portion) ภายในเฟรมข้อความของเซลล์หรือในระดับตาราง/รูปทั้งหมด ในการปฏิบัติคุณอาจกำหนดลิงก์ให้กับส่วนใดส่วนหนึ่งหรือให้กับข้อความทั้งหมดในเซลล์

**ฉันสามารถตั้งแบบอักษรที่ต่างกันภายในเซลล์เดียวได้หรือไม่?**

ได้. เฟรมข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) (run) ที่มีการจัดรูปแบบอิสระ—ครอบครัวแบบอักษร, สไตล์, ขนาดและสี.