---
title: ปรับแต่ง Legend ของแผนภูมิในงานนำเสนอด้วย .NET
linktitle: Legend ของแผนภูมิ
type: docs
url: /th/net/chart-legend/
keywords:
- legend ของแผนภูมิ
- ตำแหน่ง legend
- ขนาดฟอนต์
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับแต่ง legend ของแผนภูมิด้วย Aspose.Slides สำหรับ .NET เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบ legend ที่กำหนดเอง."
---
## **ภาพรวม**

Aspose.Slides มีตัวเลือกสำหรับการปรับแต่ง legend ของแผนภูมิในงานนำเสนอ PowerPoint บทความนี้แสดงวิธีการกำหนดตำแหน่งและขนาดของ legend, ตั้งค่าขนาดฟอนต์สำหรับ legend ทั้งหมด, และใช้การจัดรูปแบบกับรายการ legend แยกแต่ละรายการ

นอกจากนี้ยังครอบคลุมพฤติกรรมที่เกี่ยวข้องหลายอย่างใน FAQ รวมถึงการใช้โหมด non‑overlay เพื่อให้พื้นที่ plot มีที่ว่างสำหรับ legend, การทำให้ป้าย legend ยาวห่อหุ้มอัตโนมัติหรือใช้การขึ้นบรรทัดใหม่, และการให้การจัดรูปแบบ legend สืบทอดจากธีมของงานนำเสนอเมื่อไม่ได้กำหนดข้อความและการเติมสีอย่างชัดเจน

## **การจัดตำแหน่ง Legend**
เพื่อกำหนดคุณสมบัติของ legend โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) 
- รับอ้างอิงของสไลด์
- เพิ่มแผนภูมิลงในสไลด์
- ตั้งค่าคุณสมบัติของ legend
- บันทึกการพรีเซนเทชันเป็นไฟล์ PPTX

ในตัวอย่างที่ให้ด้านล่าง เราได้กำหนดตำแหน่งและขนาดสำหรับ Chart legend

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();

// รับอ้างอิงของสไลด์
ISlide slide = presentation.Slides[0];

// เพิ่มแผนภูมิกลัสเตอร์คอลัมน์บนสไลด์
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// ตั้งค่าคุณสมบัติของ Legend
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// บันทึกการพรีเซนเทชันลงดิสก์
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **ตั้งขนาดฟอนต์ของ Legend**
Aspose.Slides for .NET ให้ผู้พัฒนาสามารถตั้งค่าขนาดฟอนต์ของ legend ได้ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส `Presentation`
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่าขนาดฟอนต์
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าสูงสุดของแกน
- บันทึกการพรีเซนเทชันลงดิสก์

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ตั้งขนาดฟอนต์ของ Legend รายการเดี่ยว**
Aspose.Slides for .NET ให้ผู้พัฒนาสามารถตั้งค่าขนาดฟอนต์ของรายการ legend แยกแต่ละรายการได้ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส `Presentation`
- สร้างแผนภูมิเริ่มต้น
- เข้าถึงรายการ legend
- ตั้งค่าขนาดฟอนต์
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าสูงสุดของแกน
- บันทึกการพรีเซนเทชันลงดิสก์

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**ฉันสามารถเปิดใช้งาน legend เพื่อให้แผนภูมิจัดสรรพื้นที่โดยอัตโนมัติแทนการซ้อนทับได้หรือไม่?**

ใช่ ใช้โหมด non‑overlay ([Overlay](https://reference.aspose.com/slides/th/net/aspose.slides.charts/legend/overlay/) = `false`); ในกรณีนี้พื้นที่ plot จะหดลงเพื่อให้ที่ว่างสำหรับ legend

**ฉันสามารถทำให้ป้าย legend มีหลายบรรทัดได้หรือไม่?**

ได้ ป้ายยาวจะห่ออัตโนมัติเมื่อพื้นที่ไม่เพียงพอ; การบังคับขึ้นบรรทัดใหม่สามารถทำได้ด้วยอักขระ newline ในชื่อ series

**ฉันจะทำให้ legend ปฏิบัติตามโทนสีของธีมการพรีเซนเทชันได้อย่างไร?**

หากไม่ได้กำหนดสี/การเติม/ฟอนต์โดยตรงสำหรับ legend หรือข้อความของมัน พวกมันจะสืบทอดจากธีมและจะอัปเดตอย่างถูกต้องเมื่อการออกแบบเปลี่ยนแปลง