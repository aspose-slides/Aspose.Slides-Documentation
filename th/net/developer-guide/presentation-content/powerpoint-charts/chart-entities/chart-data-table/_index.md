---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอด้วย .NET
linktitle: ตารางข้อมูล
type: docs
url: /th/net/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติฟอนต์
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับแต่งตารางข้อมูลแผนภูมิใน .NET สำหรับไฟล์ PPT และ PPTX ด้วย Aspose.Slides เพื่อเพิ่มประสิทธิภาพและความน่าสนใจในงานนำเสนอ."
---
## **Overview**

บทความนี้อธิบายวิธีการทำงานกับตารางข้อมูลแผนภูมิใน Aspose.Slides แสดงวิธีการแสดงตารางข้อมูลสำหรับแผนภูมิและการปรับแต่งการจัดรูปแบบข้อความโดยตั้งค่าคุณสมบัติฟอนต์ เช่น รูปแบบตัวหนาและความสูงของฟอนต์ ตัวอย่างนี้สาธิตการโหลดงานนำเสนอ การเพิ่มแผนภูมิ การเปิดใช้งานตารางข้อมูลแผนภูมิ การใช้การตั้งค่าฟอนต์ และการบันทึกงานนำเสนอที่อัปเดตแล้ว

บทความยังรวมคำตอบสั้น ๆ สำหรับคำถามทั่วไปเกี่ยวกับการแสดงคีย์คำอธิบายในตารางข้อมูลแผนภูมิ การคงรักษาตารางข้อมูลระหว่างการส่งออก การทำงานกับแผนภูมิที่โหลดจากงานนำเสนอหรือแม่แบบที่มีอยู่ และการระบุแผนภูมิที่เปิดใช้งานตารางข้อมูล

## **Set Font Properties for a Chart Data Table**
Aspose.Slides for .NET ให้การสนับสนุนการเปลี่ยนสีของประเภทในสีของซีรีส์

1. สร้างอ็อบเจ็กต์คลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
1. เพิ่มแผนภูมิบนสไลด์.
1. ตั้งค่าตารางแผนภูมิ.
1. ตั้งค่าความสูงของฟอนต์.
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

 ตัวอย่างโค้ดตัวอย่างมีดังนี้.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

Yes. The data table supports [legend keys](https://reference.aspose.com/slides/th/net/aspose.slides.charts/datatable/showlegendkey/), and you can turn them on or off.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Yes. Aspose.Slides renders the chart as part of the slide, so the exported [PDF](/slides/th/net/convert-powerpoint-to-pdf/)/[HTML](/slides/th/net/convert-powerpoint-to-html/)/[image](/slides/th/net/convert-powerpoint-to-png/) includes the chart with its data table.

**Are data tables supported for charts that come from a template file?**

Yes. For any chart loaded from an existing presentation or template, you can check and change whether a data table [is shown](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/hasdatatable/) using the chart’s properties.

**How can I quickly find which charts in a file have the data table enabled?**

Inspect each chart’s property that indicates whether the data table [is shown](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/hasdatatable/) and iterate through the slides to identify the charts where it is enabled.