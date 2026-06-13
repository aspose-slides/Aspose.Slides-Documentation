---
title: ปรับแต่งแผนภูมิ Doughnut ในงานนำเสนอด้วย .NET
linktitle: แผนภูมิ Doughnut
type: docs
weight: 30
url: /th/net/doughnut-chart/
keywords:
- แผนภูมิ doughnut
- ช่องว่างตรงกลาง
- ขนาดช่องหล่อ
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีการสร้างและปรับแต่งแผนภูมิ doughnut ใน Aspose.Slides สำหรับ .NET รองรับรูปแบบ PowerPoint สำหรับงานนำเสนอแบบไดนามิก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิ doughnut ใน Aspose.Slides โดยการเพิ่มแผนภูมิลงในสไลด์ ตั้งค่าขนาดของช่องกลาง และบันทึกงานนำเสนอ มุ่งเน้นที่การตั้งค่า `DoughnutHoleSize` และสาธิตขั้นตอนพื้นฐานที่จำเป็นสำหรับการปรับแต่งประเภทแผนภูมินี้ในโค้ด

บทความยังมีส่วน FAQ สั้น ๆ ที่ครอบคลุมสถานการณ์ที่เกี่ยวข้องกับแผนภูมิ doughnut เช่น การใช้หลาย series เพื่อสร้างหลายวง, การทำงานกับแผนภูมิ doughnut ที่แยกส่วน (exploded), และการส่งออกแผนภูมิเพื่อเป็นภาพ raster หรือ SVG

## **ระบุช่องว่างตรงกลางในแผนภูมิ Doughnut**

เพื่อระบุขนาดของช่องกลางในแผนภูมิ doughnut โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
- เพิ่มแผนภูมิ doughnut ลงในสไลด์
- ระบุขนาดของช่องกลางในแผนภูมิ doughnut
- เขียนงานนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าขนาดของช่องกลางในแผนภูมิ doughnut

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// บันทึกงานนำเสนอลงดิสก์
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**ฉันสามารถสร้าง doughnut ระดับหลายชั้นที่มีหลายวงได้หรือไม่?**

ได้. เพิ่มหลาย series ลงในแผนภูมิ doughnut เดียว—แต่ละ series จะกลายเป็นวงแยกต่างหาก ลำดับของวงจะกำหนดโดยลำดับของ series ในคอลเลกชัน.

**รองรับ doughnut “exploded” (ส่วนที่แยกออก) หรือไม่?**

ได้. มีประเภทแผนภูมิ Exploded Doughnut [chart type](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) และคุณสมบัติ explosion บน data point; คุณสามารถแยกส่วนแต่ละชิ้นได้.

**ฉันจะรับภาพของแผนภูมิ doughnut (PNG/SVG) สำหรับรายงานได้อย่างไร?**

แผนภูมิเป็นรูปทรง; คุณสามารถแสดงผลเป็น [raster image](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getimage/) หรือส่งออกแผนภูมิเป็น [SVG image](https://reference.aspose.com/slides/th/net/aspose.slides/shape/writeassvg/).