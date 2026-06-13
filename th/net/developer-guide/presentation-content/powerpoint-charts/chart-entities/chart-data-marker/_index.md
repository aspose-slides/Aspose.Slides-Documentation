---
title: จัดการเครื่องหมายข้อมูลแผนภูมิในการนำเสนอด้วย .NET
linktitle: เครื่องหมายข้อมูล
type: docs
url: /th/net/chart-data-marker/
keywords:
- แผนภูมิ
- จุดข้อมูล
- เครื่องหมาย
- ตัวเลือกเครื่องหมาย
- ขนาดเครื่องหมาย
- ประเภทการเติม
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีปรับแต่งเครื่องหมายข้อมูลแผนภูมิใน Aspose.Slides สำหรับ .NET เพื่อเพิ่มประสิทธิภาพการนำเสนอในรูปแบบ PPT และ PPTX พร้อมตัวอย่างโค้ด C# ที่ชัดเจน"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเครื่องหมายข้อมูลของแผนภูมิใน Aspose.Slides โดยจะแสดงวิธีสร้างแผนภูมิ, เข้าถึงซีรีส์และจุดข้อมูลของมัน, ใช้การเติมรูปภาพให้กับเครื่องหมายในระดับจุดข้อมูล, ปรับขนาดเครื่องหมาย, และบันทึกงานนำเสนอที่อัปเดต นอกจากนี้ยังระบุว่ารูปแบบเครื่องหมายมาตรฐานสามารถใช้ได้ผ่าน enumeration `MarkerStyleType` และลักษณะของเครื่องหมายจะคงไว้เมื่อส่งออกแผนภูมิเป็นรูปแบบเรสเตอร์หรือ SVG.

## **ตั้งค่าตัวเลือกเครื่องหมายแผนภูมิ**
เครื่องหมายสามารถตั้งค่าได้บนจุดข้อมูลของแผนภูมิในซีรีส์ที่กำหนดเพื่อกำหนดตัวเลือกเครื่องหมายแผนภูมิ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) 
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่ารูปภาพ
- ดึงซีรีส์แรกของแผนภูมิ
- เพิ่มจุดข้อมูลใหม่
- บันทึกงานนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าตัวเลือกเครื่องหมายแผนภูมิระดับจุดข้อมูล

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// สร้างแผนภูมิเริ่มต้น
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// รับดัชนี worksheet ข้อมูลแผนภูมิเริ่มต้น
int defaultWorksheetIndex = 0;

// รับ worksheet ข้อมูลแผนภูมิ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// ลบซีรีส์สาธิต
chart.ChartData.Series.Clear();

// เพิ่มซีรีส์ใหม่
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// ตั้งค่าภาพ
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// ตั้งค่าภาพ
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// ดึงซีรีส์แผนภูมิแรก
IChartSeries series = chart.ChartData.Series[0];

// เพิ่มจุดใหม่ (1:3) ที่นั่น.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// เปลี่ยนเครื่องหมายซีรีส์แผนภูมิ
series.Marker.Size = 15;

// บันทึกงานนำเสนอลงดิสก์
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**รูปแบบเครื่องหมายใดบ้างที่พร้อมใช้งานโดยไม่ต้องกำหนดเอง?**

รูปแบบมาตรฐานพร้อมใช้งาน (วงกลม, สี่เหลี่ยม, เพชร, สามเหลี่ยม ฯลฯ) รายการนี้กำหนดโดย enumeration [MarkerStyleType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/markerstyletype/) หากคุณต้องการรูปแบบที่ไม่เป็นมาตรฐาน ให้ใช้เครื่องหมายที่เติมด้วยรูปภาพเพื่อจำลองภาพที่กำหนดเอง

**เครื่องหมายจะคงอยู่เมื่อส่งออกแผนภูมิเป็นภาพหรือ SVG หรือไม่?**

ใช่ เมื่อเราดึงแผนภูมิเป็น [รูปแบบเรสเตอร์](/slides/th/net/convert-powerpoint-to-png/) หรือบันทึก [รูปร่างเป็น SVG](/slides/th/net/render-a-slide-as-an-svg-image/) เครื่องหมายจะคงรูปลักษณ์และการตั้งค่าของมันไว้ รวมถึงขนาด การเติมสี และเส้นขอบ