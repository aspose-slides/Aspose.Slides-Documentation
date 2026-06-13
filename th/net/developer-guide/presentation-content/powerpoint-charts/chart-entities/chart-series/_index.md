---
title: จัดการซีรีส์ข้อมูลแผนภูมิในงานนำเสนอด้วย .NET
linktitle: ซีรีส์ข้อมูล
type: docs
url: /th/net/chart-series/
keywords:
- ซีรีส์แผนภูมิ
- การทับซ้อนของซีรีส์
- สีของซีรีส์
- สีของประเภท
- ชื่อซีรีส์
- จุดข้อมูล
- ช่องว่างของซีรีส์
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการซีรีส์แผนภูมิใน C# สำหรับ PowerPoint (PPT/PPTX) ด้วยตัวอย่างโค้ดที่เป็นประโยชน์และแนวทางปฏิบัติที่ดีที่สุดเพื่อยกระดับการนำเสนอข้อมูลของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายบทบาทของ [ChartSeries](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartseries/) ใน Aspose.Slides for .NET โดยเน้นที่วิธีการจัดโครงสร้างและการแสดงผลข้อมูลภายในงานนำเสนอ วัตถุเหล่านี้เป็นส่วนประกอบพื้นฐานที่กำหนดชุดข้อมูล จุดข้อมูล หมวดหมู่ และพารามิเตอร์การแสดงผลในแผนภูมิ โดยการทำงานกับ [ChartSeries](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartseries/) นักพัฒนาสามารถผสานแหล่งข้อมูลพื้นฐานได้อย่างราบรื่นและควบคุมการแสดงผลของข้อมูลได้อย่างเต็มที่ ส่งผลให้ได้งานนำเสนอที่ไดนามิกและขับเคลื่อนด้วยข้อมูลที่สื่อสารเชิงวิเคราะห์ได้ชัดเจน

ซีรีส์คือแถวหรือคอลัมน์ของตัวเลขที่แสดงบนแผนภูมิ

![ซีรีส์แผนภูมิ PowerPoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของซีรีส์แผนภูมิ**

คุณสมบัติ [IChartSeriesOverlap](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/properties/overlap) ควบคุมการทับซ้อนของแถบและคอลัมน์ในแผนภูมิ 2D โดยระบุค่าช่วงจาก -100 ถึง 100 เนื่องจากคุณสมบัตินี้เชื่อมโยงกับกลุ่มซีรีส์ ไม่ใช่กับซีรีส์แต่ละรายการ จึงเป็นแบบอ่านอย่างเดียวในระดับซีรีส์ เพื่อกำหนดค่าการทับซ้อนให้ใช้คุณสมบัติ `ParentSeriesGroup.Overlap` ที่สามารถอ่าน/เขียนได้ ซึ่งจะนำค่าการทับซ้อนที่ระบุไปใช้กับซีรีส์ทั้งหมดในกลุ่มนั้น

ด้านล่างเป็นตัวอย่าง C# ที่แสดงวิธีสร้างงานนำเสนอ เพิ่มแผนภูมิคอลัมน์แบบกลุ่ม เข้าถึงซีรีส์แผนภูมิแรก ตั้งค่าการทับซ้อน แล้วบันทึกผลลัพธ์เป็นไฟล์ PPTX:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลค่าเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // ตั้งค่าการทับซ้อนของซีรีส์.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // บันทึกไฟล์งานนำเสนอลงดิสก์.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![การทับซ้อนของซีรีส์](series_overlap.png)

## **เปลี่ยนสีเติมของซีรีส์**

Aspose.Slides ทำให้การปรับสีเติมของซีรีส์แผนภูมิง่ายขึ้น คุณสามารถเน้นจุดข้อมูลเฉพาะและสร้างแผนภูมิที่ดูน่าสนใจได้ ผ่านวัตถุ [IFormat](https://reference.aspose.com/slides/th/net/aspose.slides.charts/iformat/) ซึ่งรองรับรูปแบบการเติมหลายแบบ การกำหนดสีและตัวเลือกการสไตล์ขั้นสูงอื่นๆ หลังจากเพิ่มแผนภูมิเข้าสไลด์และเข้าถึงซีรีส์ที่ต้องการ เพียงดึงซีรีส์และกำหนดสีเติมที่เหมาะสม นอกจากการเติมแบบทึบ คุณยังสามารถใช้การเติมแบบไล่สีหรือแบบลวดลายเพื่อความยืดหยุ่นในการออกแบบ เมื่อกำหนดสีตามที่ต้องการแล้ว ให้บันทึกงานนำเสนอเพื่อให้การเปลี่ยนแปลงมีผล

ตัวอย่างโค้ด C# ด้านล่างแสดงวิธีเปลี่ยนสีของซีรีส์แรก:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลค่าเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // ตั้งค่าสีของซีรีส์แรก.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // บันทึกไฟล์งานนำเสนอลงดิสก์.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![สีของซีรีส์](series_color.png)

## **เปลี่ยนชื่อซีรีส์** 

Aspose.Slides มีวิธีง่ายๆ ในการแก้ไขชื่อของซีรีส์แผนภูมิ ทำให้การตั้งป้ายข้อมูลทำได้อย่างชัดเจนและมีความหมาย โดยการเข้าถึงเซลล์ใน worksheet ที่เกี่ยวข้องกับข้อมูลแผนภูมิ นักพัฒนาสามารถปรับแต่งการแสดงผลของข้อมูลได้ การแก้ไขนี้มีประโยชน์เมื่อชื่อซีรีส์ต้องการอัปเดตหรือชี้แจงตามบริบทของข้อมูล หลังจากเปลี่ยนชื่อซีรีส์แล้ว สามารถบันทึกงานนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

ด้านล่างเป็นโค้ด C# ที่แสดงขั้นตอนนี้ในเชิงปฏิบัติ

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลค่าเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // ตั้งชื่อของซีรีส์แรก.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // บันทึกไฟล์งานนำเสนอลงดิสก์.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

โค้ด C# ต่อไปนี้แสดงวิธีทางเลือกในการเปลี่ยนชื่อซีรีส์:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลค่าเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // ตั้งชื่อของซีรีส์แรก.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // บันทึกไฟล์งานนำเสนอลงดิสก์.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![ชื่อของซีรีส์](series_name.png)

## **รับสีเติมอัตโนมัติของซีรีส์**

Aspose.Slides for .NET ให้คุณดึงสีเติมอัตโนมัติของซีรีส์แผนภูมิในพื้นที่พล็อตได้ หลังจากสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คุณสามารถอ้างอิงสไลด์ที่ต้องการโดยใช้ดัชนี แล้วเพิ่มแผนภูมิด้วยประเภทที่ต้องการ (เช่น `ChartType.ClusteredColumn`) โดยการเข้าถึงซีรีส์ในแผนภูมิ คุณสามารถรับสีเติมอัตโนมัติได้

โค้ด C# ด้านล่างอธิบายขั้นตอนนี้อย่างละเอียด

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลค่าเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // ดึงสีเติมของซีรีส์.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

ผลลัพธ์:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **ตั้งค่าสีเติมกลับด้านสำหรับซีรีส์แผนภูมิ**

เมื่อซีรีส์ข้อมูลของคุณมีทั้งค่าบวกและค่าลบ การเติมสีเดียวกันให้ทุกคอลัมน์หรือแถบอาจทำให้แผนภูมิอ่านยาก Aspose.Slides for .NET ให้คุณกำหนดสีเติมกลับด้าน — สีเติมแยกที่ใช้โดยอัตโนมัติกับจุดข้อมูลที่อยู่ต่ำกว่า 0 — ทำให้ค่าลบเด่นชัดทันที ในส่วนนี้คุณจะได้เรียนรู้การเปิดใช้งานตัวเลือกนั้น เลือกสีที่เหมาะสม และบันทึกงานนำเสนอที่อัปเดตแล้ว

ตัวอย่างโค้ดต่อไปนี้แสดงการทำงาน:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // เพิ่มประเภทใหม่.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // เพิ่มซีรีส์ใหม่.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // เติมข้อมูลให้ซีรีส์.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // ตั้งค่าการตั้งสีสำหรับซีรีส์.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![สีเติมแบบทึบกลับด้าน](inverted_solid_fill_color.png)

คุณสามารถกลับสีเติมสำหรับจุดข้อมูลเดียวได้โดยไม่ต้องกลับสีของทั้งซีรีส์ เพียงเข้าถึง `IChartDataPoint` ที่ต้องการและตั้งค่า `InvertIfNegative` เป็น true

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำ:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // กลับสีถ้าจุดข้อมูลที่ดัชนี 2 มีค่าเป็นลบ.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **ลบค่าจุดข้อมูลเฉพาะ**

บางครั้งแผนภูมิอาจมีค่าทดสอบ ค่าผิดปกติ หรือรายการล้าสมัยที่คุณต้องการลบโดยไม่ต้องสร้างซีรีส์ใหม่ทั้งหมด Aspose.Slides for .NET ให้คุณเลือกจุดข้อมูลตามดัชนี ล้างเนื้อหา และรีเฟรชพล็อตทันที ส่วนที่เหลือจะเลื่อนตำแหน่งและแกนจะปรับสเกลโดยอัตโนมัติ

ตัวอย่างโค้ดต่อไปนี้แสดงการทำงาน:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าความกว้างช่องว่างของซีรีส์**

ความกว้างช่องว่าง (GapWidth) ควบคุมจำนวนพื้นที่ว่างระหว่างคอลัมน์หรือแถบที่อยู่ติดกัน — ช่องว่างกว้างทำให้แต่ละหมวดเด่นชัดขึ้น ส่วนช่องว่างแคบทำให้แผนภูมิดูแน่นและเป็นระเบียบ ผ่าน Aspose.Slides for .NET คุณสามารถปรับค่านี้สำหรับซีรีส์ทั้งหมดได้อย่างละเอียดเพื่อให้ได้สมดุลภาพที่ต้องการโดยไม่ต้องแก้ไขข้อมูลพื้นฐาน

โค้ดต่อไปนี้แสดงวิธีตั้งค่าความกว้างช่องว่างสำหรับซีรีส์:

```cs
ushort gapWidth = 30;

// สร้างงานนำเสนอเปล่า.
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่มแผนภูมิพร้อมข้อมูลค่าเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // บันทึกงานนำเสนอลงดิสก์.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // ตั้งค่าความกว้างช่องว่าง (GapWidth).
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // บันทึกงานนำเสนอลงดิสก์.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![ความกว้างช่องว่าง](gap_width.png)

## **FAQ**

**มีขีดจำกัดจำนวนซีรีส์ที่แผนภูมิหนึ่งสามารถมีได้หรือไม่?**

Aspose.Slides ไม่กำหนดขีดจำกัดคงที่สำหรับจำนวนซีรีส์ที่คุณเพิ่ม ขีดจำกัดเชิงปฏิบัติกำหนดโดยความอ่านง่ายของแผนภูมิและหน่วยความจำที่แอปพลิเคชันของคุณมี

**ถ้าคอลัมน์ในกลุ่มใกล้กันเกินไปหรือห่างกันเกินไปควรทำอย่างไร?**

ปรับค่าการตั้งค่า `GapWidth` สำหรับซีรีส์นั้น (หรือกลุ่มซีรีส์แม่) การเพิ่มค่าจะทำให้ช่องว่างระหว่างคอลัมน์กว้างขึ้น ส่วนการลดค่าจะทำให้คอลัมน์ใกล้กันมากขึ้น