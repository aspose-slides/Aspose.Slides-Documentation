---
title: เพิ่มเส้นเทรนด์ในแผนภูมิการนำเสนอด้วย .NET
linktitle: เส้นเทรนด์
type: docs
url: /th/net/trend-line/
keywords:
- แผนภูมิ
- เส้นเทรนด์
- เส้นเทรนด์เอ็กซ์โปเนนเชียล
- เส้นเทรนด์เชิงเส้น
- เส้นเทรนด์ลอการิทึม
- เส้นเทรนด์ค่าเฉลี่ยเคลื่อนที่
- เส้นเทรนด์พหุนาม
- เส้นเทรนด์พาวเวอร์
- เส้นเทรนด์กำหนดเอง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นเทรนด์ในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for .NET — คู่มือเชิงปฏิบัติสำหรับดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเพิ่มเส้นเทรนด์ลงในแผนภูมิการพรีเซนเทชันโดยใช้ Aspose.Slides แสดงวิธีสร้างแผนภูมิ, เพิ่มเส้นเทรนด์ให้กับซีรีส์ของแผนภูมิ, และทำงานกับประเภทของเส้นเทรนด์หลายประเภท รวมถึงเส้นเทรนด์แบบเอ็กซ์โปเนนเชียล, เส้นเทรนด์เชิงเส้น, เส้นเทรนด์ลอการิทึม, เส้นเทรนด์ค่าเฉลี่ยเคลื่อนที่, เส้นเทรนด์พหุนาม, และเส้นเทรนด์พาวเวอร์  

นอกจากนี้ยังอธิบายวิธีการเพิ่มเส้นกำหนดเองลงในแผนภูมิโดยการแทรกรูปร่างเส้น และมีส่วน FAQ สั้น ๆ เกี่ยวกับค่าการฉายในแนวหน้าและแนวหลังของเส้นเทรนด์และว่าการส่งออกเป็น PDF หรือ SVG หรือการแสดงผลแผนภูมิเป็นภาพจะยังคงรักษาเส้นเทรนด์ไว้หรือไม่  

## **เพิ่มเส้นเทรนด์**
Aspose.Slides for .NET มี API ง่ายสำหรับจัดการเส้นเทรนด์ของแผนภูมิต่าง ๆ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ตัวอย่างนี้ใช้ ChartType.ClusteredColumn).
1. เพิ่มเส้นเทรนด์แบบเอ็กซ์โปเนนเชียลให้กับซีรีส์แผนภูมิ 1.
1. เพิ่มเส้นเทรนด์เชิงเส้นให้กับซีรีส์แผนภูมิ 1.
1. เพิ่มเส้นเทรนด์ลอการิทึมให้กับซีรีส์แผนภูมิ 2.
1. เพิ่มเส้นเทรนด์ค่าเฉลี่ยเคลื่อนที่ให้กับซีรีส์แผนภูมิ 2.
1. เพิ่มเส้นเทรนด์พหุนามให้กับซีรีส์แผนภูมิ 3.
1. เพิ่มเส้นเทรนด์พาวเวอร์ให้กับซีรีส์แผนภูมิ 3.
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX.

โค้ดต่อไปนี้ใช้เพื่อสร้างแผนภูมิพร้อมเส้นเทรนด์

```c#
// สร้างพรีเซนเทชันเปล่า
Presentation pres = new Presentation();

// สร้างแผนภูมิกลัสเตอร์คอลัมน์
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// เพิ่มเส้นเทรนด์เอ็กซ์โปเนนเชียลให้กับซีรีส์แผนภูมิที่ 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// เพิ่มเส้นเทรนด์เชิงเส้นให้กับซีรีส์แผนภูมิที่ 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// เพิ่มเส้นเทรนด์ลอการิทึมให้กับซีรีส์แผนภูมิที่ 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// เพิ่มเส้นเทรนด์ค่าเฉลี่ยเคลื่อนที่ให้กับซีรีส์แผนภูมิที่ 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// เพิ่มเส้นเทรนด์พหุนามให้กับซีรีส์แผนภูมิที่ 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// เพิ่มเส้นเทรนด์พาวเวอร์ให้กับซีรีส์แผนภูมิที่ 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// บันทึกพรีเซนเทชัน
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```

## **เพิ่มเส้นกำหนดเอง**
Aspose.Slides for .NET มี API ง่ายเพื่อเพิ่มเส้นกำหนดเองในแผนภูมิ. เพื่อเพิ่มเส้นธรรมดาแบบเรียบง่ายบนสไลด์ที่เลือกของพรีเซนเทชัน, โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- สร้างแผนภูมิใหม่โดยใช้เมธอด AddChart ของอ็อบเจกต์ Shapes
- เพิ่ม AutoShape ชนิด Line โดยใช้เมธอด AddAutoShape ของอ็อบเจกต์ Shapes
- ตั้งค่าสีของเส้นรูปทรง
- บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

โค้ดต่อไปนี้ใช้เพื่อสร้างแผนภูมิพร้อมเส้นกำหนดเอง

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**'forward' และ 'backward' หมายถึงอะไรในเส้นเทรนด์?**

พวกมันคือความยาวของเส้นเทรนด์ที่ถูกฉายไปข้างหน้า/ข้างหลัง: สำหรับแผนภูมิแบบกระจาย (XY) — หน่วยของแกน; สำหรับแผนภูมิที่ไม่ใช่แบบกระจาย — จำนวนของหมวดหมู่ ค่าใด ๆ ต้องเป็นจำนวนที่ไม่เป็นลบเท่านั้น

**เส้นเทรนด์จะถูกรักษาไว้เมื่อนำพรีเซนเทชันส่งออกเป็น PDF หรือ SVG หรือเมื่อเรนเดอร์สไลด์เป็นภาพหรือไม่?**

ใช่. Aspose.Slides แปลงพรีเซนเทชันเป็น [PDF](/slides/th/net/convert-powerpoint-to-pdf/)/[SVG](/slides/th/net/render-a-slide-as-an-svg-image/) และแสดงแผนภูมิเป็นภาพ; เส้นเทรนด์ซึ่งเป็นส่วนหนึ่งของแห

นภูมิจะถูกเก็บรักษาไว้ระหว่างการดำเนินการเหล่านี้ นอกจากนี้ยังมีเมธอดให้ [ส่งออกภาพของแผนภูมิ](/slides/th/net/create-shape-thumbnails/) ด้วย