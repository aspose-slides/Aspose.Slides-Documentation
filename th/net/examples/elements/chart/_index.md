---
title: แผนภูมิ
type: docs
weight: 60
url: /th/net/examples/elements/chart/
keywords:
- แผนภูมิ
- เพิ่มแผนภูมิ
- เข้าถึงแผนภูมิ
- ลบแผนภูมิ
- อัปเดตแผนภูมิ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมแผนภูมิด้วย Aspose.Slides for .NET: สร้าง, กำหนดรูปแบบ, ผูกข้อมูล, และส่งออกแผนภูมิในรูปแบบ PPT, PPTX, และ ODP พร้อมตัวอย่าง C#."
---
ตัวอย่างสำหรับการเพิ่ม, การเข้าถึง, การลบ, และการอัปเดตรูปแบบแผนภูมิต่างๆ ด้วย **Aspose.Slides for .NET**. ตัวอย่างโค้ดด้านล่างแสดงการดำเนินการแผนภูมิพื้นฐาน.

## **เพิ่มแผนภูมิ**

เมธอดนี้เพิ่มแผนภูมิพื้นที่แบบง่ายไปยังสไลด์แรก.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // เพิ่มแผนภูมิพื้นที่แบบง่ายไปยังสไลด์แรก.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **เข้าถึงแผนภูมิ**

หลังจากสร้างแผนภูมิแล้ว คุณสามารถดึงมันออกมาผ่านคอลเลกชันรูปร่างได้.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // เข้าถึงแผนภูมิแรกบนสไลด์.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **ลบแผนภูมิ**

โค้ดต่อไปนี้ลบแผนภูมิออกจากสไลด์.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // ลบแผนภูมิ.
    slide.Shapes.Remove(chart);
}
```

## **อัปเดตข้อมูลแผนภูมิ**

คุณสามารถเปลี่ยนแปลงคุณสมบัติของแผนภูมิ เช่น ชื่อเรื่อง.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // เปลี่ยนชื่อแผนภูมิ.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```