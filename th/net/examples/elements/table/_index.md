---
title: ตาราง
type: docs
weight: 120
url: /th/net/examples/elements/table/
keywords:
- ตาราง
- เพิ่มตาราง
- เข้าถึงตาราง
- ลบตาราง
- รวมเซลล์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำงานกับตารางใน Aspose.Slides for .NET: สร้าง, จัดรูปแบบ, รวมเซลล์, ใช้สไตล์, นำเข้าข้อมูล, และส่งออกด้วยตัวอย่าง C# สำหรับ PPT, PPTX, และ ODP."
---
ตัวอย่างการเพิ่มตาราง, การเข้าถึงตาราง, การลบตาราง และการรวมเซลล์โดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มตาราง**

สร้างตารางง่ายๆ ที่มีสองแถวและสองคอลัมน์.

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **เข้าถึงตาราง**

ดึงรูปทรงตารางแรกบนสไลด์.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // เข้าถึงตารางแรกบนสไลด์.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **ลบตาราง**

ลบตารางออกจากสไลด์.

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **รวมเซลล์ตาราง**

รวมเซลล์ที่อยู่ติดกันของตารางให้เป็นเซลล์เดียว.

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```