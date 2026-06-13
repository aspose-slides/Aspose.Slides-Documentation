---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย Java
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/java/manage-cells/
keywords:
- เซลล์ตาราง
- ผสานเซลล์
- ลบเส้นขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการเซลล์ตารางใน PowerPoint อย่างง่ายดายด้วย Aspose.Slides สำหรับ Java ทำความเชี่ยวชาญในการเข้าถึง, แก้ไข และออกแบบเซลล์อย่างรวดเร็วเพื่อการทำงานอัตโนมัติของสไลด์ที่ราบรื่น."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ของตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีระบุเซลล์ตารางที่ถูกผสาน, ลบเส้นกรอบเซลล์, ทำงานกับการกำหนดหมายเลขเซลล์หลังจากผสานหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างจะแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ระบุเซลล์ตารางที่ผสานกัน**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. ดึงตารางจากสไลด์แรก
3. วนลูปผ่านแถวและคอลัมน์ของตารางเพื่อค้นหาเซลล์ที่ถูกผสาน
4. พิมพ์ข้อความเมื่อพบเซลล์ที่ผสานกัน

โค้ด Java นี้แสดงวิธีระบุเซลล์ตารางที่ผสานในงานนำเสนอ:

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

## **ลบเส้นกรอบเซลล์ตาราง**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. นิยามอาเรย์ของคอลัมน์พร้อมความกว้าง
4. นิยามอาเรย์ของแถวพร้อมความสูง
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-)
6. วนลูปผ่านทุกเซลล์เพื่อลบเส้นกรอบด้านบน, ด้านล่าง, ด้านขวา, และด้านซ้าย
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีลบเส้นกรอบจากเซลล์ตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // กำหนดรูปแบบเส้นกรอบให้กับแต่ละเซลล์
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

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การกำหนดหมายเลขในเซลล์ที่ผสาน**
หากเราผสานเซลล์ 2 คู่ (1, 1) × (2, 1) และ (1, 2) × (2, 2) ตารางที่ได้จะถูกกำหนดหมายเลข โค้ด Java นี้แสดงกระบวนการ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงบนสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // กำหนดรูปแบบเส้นขอบให้กับแต่ละเซลล์
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

    // ผสานเซลล์ (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // ผสานเซลล์ (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

จากนั้นเราผสานเซลล์ต่อด้วยการผสาน (1, 1) และ (1, 2) ผลลัพธ์คือตารางที่มีเซลล์ผสานใหญ่ตรงกลาง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงบนสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // กำหนดรูปแบบเส้นขอบให้กับแต่ละเซลล์
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

    // ผสานเซลล์ (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // ผสานเซลล์ (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // ผสานเซลล์ (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// เขียนไฟล์ PPTX ลงดิสก์
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **การกำหนดหมายเลขในเซลล์ที่แยกออก**
ในตัวอย่างก่อนหน้า เมื่อเซลล์ตารางถูกผสาน ระบบการนับหมายเลขในเซลล์อื่น ๆ ไม่ได้เปลี่ยนแปลง  

ครั้งนี้เราจะใช้ตารางปกติ (ตารางที่ไม่มีเซลล์ผสาน) แล้วทำการแยกเซลล์ (1,1) เพื่อให้ได้ตารางพิเศษ คุณอาจสังเกตว่าการกำหนดหมายเลขของตารางนี้ดูแปลก แต่เป็นวิธีที่ Microsoft PowerPoint นับหมายเลขเซลล์ตารางและ Aspose.Slides ทำเช่นเดียวกัน  

โค้ด Java นี้แสดงกระบวนการที่อธิบาย:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงบนสไลด์
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // กำหนดรูปแบบเส้นขอบให้กับแต่ละเซลล์
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

    // ผสานเซลล์ (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // ผสานเซลล์ (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // แยกเซลล์ (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //เขียนไฟล์ PPTX ลงดิสก์
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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. นิยามอาเรย์ของคอลัมน์พร้อมความกว้าง
4. นิยามอาเรย์ของแถวพร้อมความสูง
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด [AddTable](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-)
6. สร้างอ็อบเจ็กต์ `Images` เพื่อเก็บไฟล์รูปภาพ
7. เพิ่มอ็อบเจ็กต์ `IImage` ไปยังอ็อบเจ็กต์ `IPPImage`
8. ตั้งค่า `FillFormat` ของเซลล์ตารางเป็น `Picture`
9. เพิ่มรูปภาพลงในเซลล์แรกของตาราง
10. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีใส่รูปภาพภายในเซลล์ตารางเมื่อสร้างตาราง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide islide = pres.getSlides().get_Item(0);

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // เพิ่มรูปร่างตารางลงบนสไลด์
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // สร้างอ็อบเจกต์ IPPImage ด้วยไฟล์รูปภาพ
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่มรูปภาพลงในเซลล์ตารางแรก
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

## **คำถามที่พบบ่อย**

**สามารถตั้งค่าความหนาและสไตล์ของเส้นกรอบที่แตกต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ได้. เส้นกรอบ [ด้านบน](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellformat/#getBorderTop--)/[ด้านล่าง](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellformat/#getBorderBottom--)/[ด้านซ้าย](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellformat/#getBorderLeft--)/[ด้านขวา](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellformat/#getBorderRight--) มีคุณสมบัติแยกกัน ทำให้ความหนาและสไตล์ของแต่ละด้านสามารถแตกต่างกันได้ สิ่งนี้สอดคล้องกับการควบคุมเส้นกรอบต่อด้านสำหรับเซลล์ที่อธิบายไว้ในบทความ

**จะเกิดอะไรขึ้นกับรูปภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [โหมดการเติม](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturefillmode/) (stretch/tile) หากเลือกการยืดรูปภาพจะปรับให้เข้ากับเซลล์ใหม่; หากเลือกการทำ tiled รูปภาพจะถูกคำนวณใหม่ บทความได้อธิบายโหมดการแสดงผลของรูปภาพในเซลล์แล้ว

**สามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/java/manage-hyperlinks/) ถูกตั้งค่าที่ระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือที่ระดับของตาราง/รูปทั้งหมด ในทางปฏิบัติคุณสามารถกำหนดลิงก์ให้กับส่วนหรือให้กับข้อความทั้งหมดในเซลล์ได้

**สามารถตั้งค่าแบบอักษรที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ได้. กรอบข้อความของเซลล์รองรับ [portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) (run) ที่มีการจัดรูปแบบอิสระ—ฟอนต์, สไตล์, ขนาด, และสี