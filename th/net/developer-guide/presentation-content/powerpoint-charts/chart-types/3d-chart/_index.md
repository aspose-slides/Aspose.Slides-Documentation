---
title: ปรับแต่งแผนภูมิ 3 มิติในพรีเซนเทชันด้วย .NET
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/net/3d-chart/
keywords:
- แผนภูมิ 3 มิติ
- การหมุน
- ความลึก
- PowerPoint
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการสร้างและปรับแต่งแผนภูมิ 3 มิติใน Aspose.Slides สำหรับ .NET พร้อมการสนับสนุนไฟล์ PPT และ PPTX — เพิ่มประสิทธิภาพพรีเซนเทชันของคุณวันนี้."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแผนภูมิ 3 มิติใน Aspose.Slides โดยกำหนดค่าการตั้งค่า `Rotation3D` เช่น `RotationX`, `RotationY`, `DepthPercents` และ `RightAngleAxes` ซึ่งจะอธิบายขั้นตอนการสร้างพรีเซนเทชัน การเพิ่มแผนภูมิ 3 มิติพร้อมข้อมูลเริ่มต้น การใช้การตั้งค่ามุมมอง 3 มิติที่จำเป็น และการบันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

## **กำหนดคุณสมบัติ RotationX, RotationY และ DepthPercents ของแผนภูมิ 3 มิติ**
Aspose.Slides for .NET มี API ที่ง่ายสำหรับการตั้งค่าคุณสมบัติเหล่านี้ บทความต่อไปนี้จะช่วยคุณในการตั้งค่าต่าง ๆ เช่น การหมุน X, Y, **DepthPercents** เป็นต้น ตัวอย่างโค้ดด้านล่างแสดงการตั้งค่าคุณสมบัติเก่านี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
1. ตั้งค่าคุณสมบัติ Rotation3D
1. เขียนพรีเซนเทชันที่แก้ไขลงไฟล์ PPTX

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();
           
// เข้าถึงสไลด์แรก
ISlide slide = presentation.Slides[0];

// เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
int defaultWorksheetIndex = 0;

// ดึงแผ่นงานข้อมูลแผนภูมิ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// เพิ่มซีรีส์
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// เพิ่มหมวดหมู่
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// ตั้งค่าคุณสมบัติ Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// เลือกซีรีส์แผนภูมิที่สอง
IChartSeries series = chart.ChartData.Series[1];

// ตอนนี้กำลังเติมข้อมูลซีรีส์
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// ตั้งค่าค่า OverLap
series.ParentSeriesGroup.Overlap = 100;         

// บันทึกพรีเซนเทชันลงดิสก์
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดที่รองรับโหมด 3 มิติใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3 มิติของแผนภูมิคอลัมน์ ได้แก่ Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D รวมถึงประเภท 3 มิติที่เกี่ยวข้องที่เปิดให้ใช้งานผ่านการอ้างอิงแบบ enumeration [ChartType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) สำหรับรายการที่เป็นปัจจุบันและครบถ้วน โปรดตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพราสเตอร์ของแผนภูมิ 3 มิติสำหรับรายงานหรือเว็บได้หรือไม่?**

ใช่ คุณสามารถส่งออกแผนภูมิเป็นภาพได้ผ่าน [chart API](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getimage/) หรือ [render the entire slide](/slides/th/net/convert-powerpoint-to-png/) เป็นรูปแบบเช่น PNG หรือ JPEG ซึ่งเป็นประโยชน์เมื่อคุณต้องการการแสดงตัวอย่างที่พิกเซลแม่นยำหรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด หรือเว็บเพจโดยไม่ต้องใช้ PowerPoint

**ประสิทธิภาพของการสร้างและเรนเดอร์แผนภูมิ 3 มิติขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของการแสดงผล เพื่อให้ได้ผลลัพธ์ที่ดีที่สุด ควรใช้เอฟเฟกต์ 3D อย่างจำกัด หลีกเลี่ยงการใช้เทกเจอร์ที่หนาบนผนังและพื้นที่แผนภูมิ จำกัดจำนวนจุดข้อมูลต่อชุดเมื่อเป็นไปได้และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ