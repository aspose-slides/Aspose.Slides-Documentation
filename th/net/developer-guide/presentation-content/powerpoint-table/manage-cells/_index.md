---
title: จัดการเซลล์ตารางในงานนำเสนอใน .NET
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/net/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบเส้นขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการเซลล์ตารางใน PowerPoint อย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET. ทำความเชี่ยวชาญในการเข้าถึง, แก้ไข, และตกแต่งเซลล์อย่างรวดเร็วเพื่อการอัตโนมัติงานสไลด์ที่ราบรื่น."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ของตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีการระบุเซลล์ตารางที่รวมกัน, ลบเส้นขอบของเซลล์, ทำงานกับการนับเลขของเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีการสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ระบุเซลล์ตารางที่รวมกัน**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. ดึงตารางจากสไลด์แรก  
3. วนซ้ำผ่านแถวและคอลัมน์ของตารางเพื่อค้นหาเซลล์ที่รวมกัน  
4. แสดงข้อความเมื่อพบเซลล์ที่รวมกัน  

โค้ด C# นี้แสดงวิธีการระบุเซลล์ตารางที่รวมกันในงานนำเสนอ:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // สมมติว่า Slide#0.Shape#0 เป็นตาราง
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **ลบเส้นขอบของเซลล์ตาราง**

1. สร้างอินสแตนซ์ของคลาส `Presentation`  
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง  
4. กำหนดอาเรย์ของแถวพร้อมความสูง  
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด `AddTable`  
6. วนซ้ำผ่านทุกเซลล์เพื่อเคลียร์เส้นขอบด้านบน, ด้านล่าง, ด้านขวา และด้านซ้าย  
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีการลบเส้นขอบจากเซลล์ตาราง:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation())
{
   // เข้าถึงสไลด์แรก
    Slide sld = (Slide)pres.Slides[0];

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **การนับเลขในเซลล์ที่รวมกัน**

หากเรารวมเซลล์ 2 คู่ (1, 1) x (2, 1) และ (1, 2) x (2, 2) ตารางที่ได้จะมีการเรียงลำดับเลข  
โค้ด C# นี้แสดงกระบวนการ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก
    ISlide sld = presentation.Slides[0];

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // รวมเซลล์ (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // รวมเซลล์ (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

จากนั้นเรารวมเซลล์ต่อโดยการรวม (1, 1) และ (1, 2) ผลลัพธ์คือตารางที่มีเซลล์ที่รวมกันขนาดใหญ่อยู่ตรงกลาง:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // รวมเซลล์ (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // รวมเซลล์ (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // รวมเซลล์ (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    //บันทึกไฟล์ PPTX ลงดิสก์
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **การนับเลขในเซลล์ที่แยก**

ในตัวอย่างก่อนหน้า เมื่อเซลล์ตารางถูกรวม ระบบการนับเลขหรือการจัดลำดับในเซลล์อื่นไม่ได้เปลี่ยนแปลง  
ครั้งนี้เราจะใช้ตารางปกติ (ตารางที่ไม่มีการรวมเซลล์) แล้วพยายามแยกเซลล์ (1,1) เพื่อให้ได้ตารางพิเศษ คุณอาจต้องใส่ใจการนับเลขของตารางนี้ ซึ่งอาจดูแปลก แต่ก็เป็นวิธีที่ Microsoft PowerPoint นับเลขเซลล์ตารางและ Aspose.Slides ทำเช่นเดียวกัน  

โค้ด C# นี้แสดงกระบวนการที่อธิบายไว้:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // รวมเซลล์ (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // รวมเซลล์ (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // แยกเซลล์ (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    //บันทึกไฟล์ PPTX ลงดิสก์
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

โค้ด C# นี้แสดงวิธีการเปลี่ยนสีพื้นหลังของเซลล์ตาราง:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // สร้างตารางใหม่
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // ตั้งค่าสีพื้นหลังของเซลล์
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มภาพภายในเซลล์ตาราง**

1. สร้างอินสแตนซ์ของคลาส`Presentation`  
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง  
4. กำหนดอาเรย์ของแถวพร้อมความสูง  
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด `AddTable`  
6. สร้างอ็อบเจ็กต์ `Bitmap` เพื่อเก็บไฟล์ภาพ  
7. เพิ่มภาพ bitmap เข้าไปในอ็อบเจ็กต์ `IPPImage`  
8. ตั้งค่า `FillFormat` ของเซลล์ตารางเป็น `Picture`  
9. เพิ่มภาพลงในเซลล์แรกของตาราง  
10. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีการวางภาพภายในเซลล์ตารางเมื่อสร้างตาราง:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // โหลดภาพจากไฟล์และเพิ่มไปยังทรัพยากรของงานนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // เพิ่มภาพลงในเซลล์ตารางแรก
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นขอบต่าง ๆ สำหรับด้านต่าง ๆ ของเซลล์เดียวได้หรือไม่?**

Yes. The [top](https://reference.aspose.com/slides/th/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/th/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/th/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/th/net/aspose.slides/cellformat/borderright/) borders have separate properties, so the thickness and style of each side can differ. This logically follows from the per-side border control for a cell demonstrated in the article.

**จะเกิดอะไรขึ้นกับภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated. The article mentions the image display modes in a cell.

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/net/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**ฉันสามารถตั้งฟอนต์ที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/th/net/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.