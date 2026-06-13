---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย .NET
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/net/manage-rows-and-columns/
keywords:
- แถวของตาราง
- คอลัมน์ของตาราง
- แถวแรก
- หัวตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความของแถว
- การจัดรูปแบบข้อความของคอลัมน์
- สไตล์ของตาราง
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides สำหรับ .NET และเพิ่มความเร็วในการแก้ไขงานนำเสนอและอัปเดตข้อมูล."
---
## **บทนำ**

เพื่อให้คุณสามารถจัดการแถวและคอลัมน์ของตารางในงานนำเสนอ PowerPoint ได้ Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/net/aspose.slides/table/) อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) และประเภทอื่น ๆ มากมาย  

## **ตั้งค่าแถวแรกเป็นหัวตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) และโหลดงานนำเสนอ  
2. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) แล้วตั้งค่าเป็น null  
4. วนรอบอ็อบเจ็กต์ทั้งหมดของ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) เพื่อค้นหาตารางที่เกี่ยวข้อง  
5. ตั้งค่าแถวแรกของตารางเป็นหัวตาราง  

โค้ด C# นี้แสดงวิธีตั้งค่าแถวแรกของตารางให้เป็นหัวตาราง:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("table.pptx");

// เข้าถึงสไลด์แรก
ISlide sld = pres.Slides[0];

// กำหนดค่าเริ่มต้นให้ TableEx เป็น null
ITable tbl = null;

// วนผ่านรูปร่างทั้งหมดและตั้งค่าอ้างอิงไปยังตาราง
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// ตั้งค่าแถวแรกของตารางเป็นหัวตาราง
tbl.FirstRow = true;

// บันทึกงานนำเสนอลงดิสก์
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) และโหลดงานนำเสนอ  
2. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาเรย์ของ `columnWidth`  
4. กำหนดอาเรย์ของ `rowHeight`  
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) ไปยังสไลด์ผ่านเมธอด [AddTable](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addtable/)  
6. คัดลอกแถวของตาราง  
7. คัดลอกคอลัมน์ของตาราง  
8. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C# นี้แสดงวิธีคัดลอกแถวหรือคอลัมน์ของตาราง PowerPoint:

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // เข้าถึงสไลด์แรก
    ISlide sld = presentation.Slides[0];

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // เพิ่มข้อความบางส่วนในแถว 1 เซลล์ 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // เพิ่มข้อความบางส่วนในแถว 1 เซลล์ 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // คัดลอกแถว 1 ไปยังตำแหน่งสุดท้ายของตาราง
    table.Rows.AddClone(table.Rows[0], false);

    // เพิ่มข้อความบางส่วนในแถว 2 เซลล์ 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // เพิ่มข้อความบางส่วนในแถว 2 เซลล์ 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // คัดลอกแถว 2 เป็นแถวที่ 4 ของตาราง
    table.Rows.InsertClone(3,table.Rows[1], false);

    // คัดลอกคอลัมน์แรกที่ตำแหน่งสุดท้าย
    table.Columns.AddClone(table.Columns[0], false);

    // คัดลอกคอลัมน์ที่ 2 ที่ตำแหน่งคอลัมน์ที่ 4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // บันทึกงานนำเสนอลงดิสก์ 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **ลบแถวหรือคอลัมน์จากตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) และโหลดงานนำเสนอ  
2. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาเรย์ของ `columnWidth`  
4. กำหนดอาเรย์ของ `rowHeight`  
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) ไปยังสไลด์ผ่านเมธอด [AddTable](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addtable/)  
6. ลบแถวของตาราง  
7. ลบคอลัมน์ของตาราง  
8. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C# นี้แสดงวิธีลบแถวหรือคอลัมน์จากตาราง:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับแถวของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) และโหลดงานนำเสนอ  
2. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) ที่เกี่ยวข้องจากสไลด์  
4. ตั้งค่า [FontHeight](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/fontheight/) ของเซลล์ในแถวแรก  
5. ตั้งค่า [Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/alignment/) และ [MarginRight](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginright/) ของเซลล์ในแถวแรก  
6. ตั้งค่า [TextVerticalType](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/textverticaltype/) ของเซลล์ในแถวที่สอง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C# นี้แสดงการดำเนินการ:

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง

// ตั้งค่าความสูงของฟอนต์สำหรับเซลล์ในแถวแรก
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// ตั้งค่าการจัดแนวข้อความและระยะขอบขวาของเซลล์ในแถวแรก
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// ตั้งค่าประเภทการจัดแนวข้อความแนวตั้งของเซลล์ในแถวที่สอง
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// บันทึกงานนำเสนอลงดิสก์
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) และโหลดงานนำเสนอ  
2. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) ที่เกี่ยวข้องจากสไลด์  
4. ตั้งค่า [FontHeight](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/fontheight/) ของเซลล์ในคอลัมน์แรก  
5. ตั้งค่า [Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/alignment/) และ [MarginRight](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginright/) ของเซลล์ในคอลัมน์แรก  
6. ตั้งค่า [TextVerticalType](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/textverticaltype/) ของเซลล์ในคอลัมน์ที่สอง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C# นี้แสดงการดำเนินการ:

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง

// ตั้งค่าความสูงของฟอนต์สำหรับเซลล์ในคอลัมน์แรก
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// ตั้งค่าการจัดแนวข้อความและระยะขอบขวาของเซลล์ในคอลัมน์แรกในหนึ่งคำสั่ง
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// ตั้งค่าประเภทการจัดแนวข้อความแนวตั้งของเซลล์ในคอลัมน์ที่สอง
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// บันทึกงานนำเสนอลงดิสก์
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **รับคุณสมบัติรูปแบบของตาราง**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติรูปแบบของตารางเพื่อใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือที่อื่น โค้ด C# นี้แสดงวิธีรับคุณสมบัติรูปแบบจากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // เปลี่ยนธีมพรีเซ็ตสไตล์เริ่มต้น
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถนำธีม/สไตล์ของ PowerPoint ไปใช้กับตารางที่สร้างแล้วได้หรือไม่?**

ได้ ตารางจะสืบทอดธีมของสไลด์/เลเอาต์/มาสเตอร์ และคุณยังสามารถแoverride การเติมสี ขอบ และสีข้อความได้บนธีมดังกล่าว

**ฉันสามารถเรียงลำดับแถวของตารางเหมือนใน Excel ได้หรือไม่?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือฟิลเตอร์ในตัว ให้เรียงลำดับข้อมูลในหน่วยความจำก่อน แล้วค่อยเติมแถวของตารางตามลำดับนั้น

**ฉันสามารถใช้คอลัมน์แบบมีแถบ (striped) พร้อมสีที่กำหนดเองในเซลล์เฉพาะได้หรือไม่?**

ได้ เปิดใช้งานคอลัมน์แบบมีแถบ แล้วแoverride เซลล์เฉพาะด้วยการจัดรูปแบบระดับเซลล์; การจัดรูปแบบระดับเซลล์จะมีลำดับความสำคัญเหนือสไตล์ของตาราง