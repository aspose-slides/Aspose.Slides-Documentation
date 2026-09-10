---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ใน .NET
linktitle: สร้างหรืออัปเดตแผนภูมิ
type: docs
weight: 10
url: /th/net/create-chart/
keywords:
- เพิ่มแผนภูมิ
- สร้างแผนภูมิ
- แก้ไขแผนภูมิ
- เปลี่ยนแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิเพทแมพ
- แผนภูมิเส้นหุ้น
- แผนภูมิ Box and Whisker
- แผนภูมิกรวย
- แผนภูมิดาว
- แผนภูมิฮิสโตแกรม
- แผนภูมิเรดาร์
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET. เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ใช้งานได้จริงใน C#."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำแบบครบถ้วนเกี่ยวกับวิธีสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for .NET คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงบนสไลด์โดยใช้โค้ด, เติมข้อมูลให้แผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ ตลอดทั้งบทความ ตัวอย่างโค้ดที่ละเอียดจะแสดงขั้นตอนต่าง ๆ ตั้งแต่การเริ่มต้นนำเสนอและอ็อบเจกต์แผนภูมิไปจนถึงการกำหนดค่าซีรีส์, แกน, และคำอธิบายภาพโดยละเอียด ด้วยการทำตามคำแนะนำนี้ คุณจะเข้าใจวิธีการรวมการสร้างแผนภูมิกระ动态เข้ากับแอปพลิเคชัน .NET ของคุณได้อย่างมั่นคงและทำให้กระบวนการสร้างงานนำเสนอที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่าย

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและพบข้อสรุปที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

โดยใช้แผนภูมิ คุณสามารถ:

* รวม, ย่อย, หรือสรุปข้อมูลจำนวนมากบนสไลด์เดียวในงานนำเสนอ;
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล;
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดที่เฉพาะเจาะจง;
* ค้นหา ค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีความหมาย;
* สื่อสารหรือแสดงข้อมูลซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งมีเทมเพลตสำหรับออกแบบแผนภูมิต่าง ๆ ได้หลายประเภท ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (ตามประเภทแผนภูมิยอดนิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="info" %}} 
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) ภายใต้ namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/th/net/aspose.slides.charts/) ค่าต่าง ๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิที่แตกต่างกัน
{{% /alert %}} 

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม (Clustered Column)**

ส่วนนี้อธิบายวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่มโดยใช้ Aspose.Slides for .NET คุณจะได้เรียนรู้การเริ่มต้นนำเสนอ, เพิ่มแผนภูมิ, และปรับแต่งองค์ประกอบต่าง ๆ เช่น ชื่อเรื่อง, ข้อมูล, ซีรีส์, หมวดหมู่, และสไตล์ ทำตามขั้นตอนด้านล่างเพื่อดูว่าการสร้างแผนภูมิคอลัมน์แบบกลุ่มมาตรฐานทำอย่างไร:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภท `ChartType.ClusteredColumn`  
1. เพิ่มชื่อเรื่องให้กับแผนภูมิ  
1. เข้าถึงแผนภูมิ worksheet ของข้อมูล  
1. ล้างซีรีส์และหมวดหมู่เริ่มต้นทั้งหมด  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
1. ใส่สีพื้นหลังให้กับซีรีส์ของแผนภูมิ  
1. เพิ่มป้ายข้อความให้กับซีรีส์ของแผนภูมิ  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่ม:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // ตั้งค่าชื่อเรื่องของแผนภูมิ.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ.
    int worksheetIndex = 0;

    // ดึง workbook ของข้อมูลแผนภูมิ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // เพิ่มซีรีส์ใหม่.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // เพิ่มหมวดหมู่ใหม่.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // ดึงซีรีส์แผนภูมุตัวแรก.
    IChartSeries series = chart.ChartData.Series[0];

    // เติมข้อมูลให้ซีรีส์.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // ตั้งค่าสีเติมให้กับซีรีส์.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // ดึงซีรีส์แผนภูมิที่สอง.
    series = chart.ChartData.Series[1];

    // เติมข้อมูลให้ซีรีส์.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // ตั้งค่าสีเติมให้กับซีรีส์.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // ตั้งค่าป้ายแรกให้แสดงชื่อหมวดหมู่.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // ตั้งค่าให้ซีรีส์แสดงค่าบนป้ายที่สาม.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // บันทึกงานนำเสนอลงดิสก์เป็นไฟล์ PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Clustered Column chart](clustered_column_chart.png)

### **สร้างแผนภูมิสเกล (Scatter)**

แผนภูมิสเกล (หรือ scatter plot, กราฟ x‑y) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิสเกลเมื่อ:

* มีข้อมูลเชิงตัวเลขเป็นคู่  
* มีสองตัวแปรที่สัมพันธ์กันดี  
* ต้องการกำหนดว่าตัวแปรทั้งสองเกี่ยวข้องกันหรือไม่  
* มีตัวแปรอิสระที่มีหลายค่าต่อค่าตัวแปรตาม  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิสเกลพร้อมเครื่องหมายซีรีส์ที่แตกต่างกัน:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // สร้างแผนภูมิกระจายค่าเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ.
    int worksheetIndex = 0;

    // ดึง workbook ของข้อมูลแผนภูมิ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ลบซีรีส์ค่าเริ่มต้น.
    chart.ChartData.Series.Clear();

    // เพิ่มซีรีส์ใหม่.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // ดึงซีรีส์แผนภูมุตัวแรก.
    IChartSeries series = chart.ChartData.Series[0];

    // เพิ่มจุดใหม่ (1:3) ให้กับซีรีส์.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // เพิ่มจุดใหม่ (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // เปลี่ยนประเภทของซีรีส์.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // เปลี่ยนเครื่องหมายของซีรีส์แผนภูมิ.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // ดึงซีรีส์แผนภูมิที่สอง.
    series = chart.ChartData.Series[1];

    // เพิ่มจุดใหม่ (5:2) ให้กับซีรีส์แผนภูมิ.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // เพิ่มจุดใหม่ (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // เพิ่มจุดใหม่ (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // เพิ่มจุดใหม่ (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // เปลี่ยนเครื่องหมายของซีรีส์แผนภูมิ.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // บันทึกงานนำเสนอลงดิสก์เป็นไฟล์ PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Scatter chart](scatter_chart.png)

### **สร้างแผนภูมิวงกลม (Pie)**

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล, โดยเฉพาะเมื่อข้อมูลมีป้ายประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีส่วนหรือป้ายหลายส่วน อาจพิจารณาใช้แผนภูมิแท่งแทน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท `ChartType.Pie`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
1. เพิ่มจุดใหม่ให้กับแผนภูมิและใส่สีกำหนดเองให้กับเซกเมนต์ของแผนภูมิวงกลม  
1. ตั้งค่าป้ายข้อความสำหรับซีรีส์  
1. เปิดใช้งานเส้นนำสำหรับป้ายข้อความของซีรีส์  
1. ตั้งค่ามุมการหมุนของแผนภูมิวงกลม  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิวงกลม:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//    สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    //    เข้าถึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    //    เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    //    ตั้งค่าชื่อเรื่องของแผนภูมิ.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    //    ตั้งค่าซีรีส์แรกให้แสดงค่า.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    //    ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ.
    int worksheetIndex = 0;

    //    ดึง workbook ของข้อมูลแผนภูมิ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    //    ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    //    เพิ่มหมวดหมู่ใหม่.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    //    เพิ่มซีรีส์ใหม่.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    //    เติมข้อมูลให้ซีรีส์.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    //    ตั้งค่าสีของส่วนแผนภูมิ.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    //    ตั้งค่าขอบของส่วนแผนภูมิ.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    //    ตั้งค่าขอบของส่วนแผนภูมิ.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    //    ตั้งค่าขอบของส่วนแผนภูมิ.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    //    สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ในซีรีส์ใหม่.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    //    ตั้งค่าให้ซีรีส์แสดงเส้นนำสำหรับแผนภูมิ.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    //    ตั้งมุมการหมุนของส่วนแผนภูมิวงกลม.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    //    บันทึกงานนำเสนอลงดิสก์เป็นไฟล์ PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Pie chart](pie_chart.png)

### **สร้างแผนภูมิเส้น (Line)**

แผนภูมิเส้น (หรือ line graph) เหมาะสำหรับสถานการณ์ที่ต้องแสดงการเปลี่ยนแปลงของค่าตามเวลา การใช้แผนภูมิเส้นช่วยให้คุณเปรียบเทียบข้อมูลจำนวนมากพร้อมกัน, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติในซีรีส์ข้อมูล, เป็นต้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท `ChartType.Line`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิเส้น:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยเส้นขีด สามารถระบุประเภทเส้นขีดที่ต้องการได้ดังนี้:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

ผลลัพธ์:

![The Line chart](line_chart.png)

### **สร้างแผนภูมิเพทแมพ (Tree Map)**

แผนภูมิเพทแมพเหมาะสำหรับข้อมูลการขายที่ต้องการแสดงขนาดสัมพันธ์ของประเภทข้อมูลและเน้นรายการที่มีส่วนร่วมสูงในแต่ละประเภทอย่างรวดเร็ว

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท `ChartType.Treemap`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิเพทแมพ:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // สาขา 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // สาขา 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Treemap chart](treemap_chart.png)

### **สร้างแผนภูมิเส้นหุ้น (Stock)**

แผนภูมิเส้นหุ้นใช้แสดงข้อมูลทางการเงินเช่น ราคาเปิด, ราคาสูง, ราคาต่ำ, และราคาปิด ช่วยวิเคราะห์แนวโน้มตลาดและความผันผวน ให้ข้อมูลเชิงลึกสำคัญเกี่ยวกับประสิทธิภาพของหุ้นแก่ผู้ลงทุนและนักวิเคราะห์ในการตัดสินใจอย่างมีข้อมูล

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท `ChartType.OpenHighLowClose`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
1. ระบุรูปแบบ HiLowLines  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิเส้นหุ้น:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Stock chart](stock_chart.png)

### **สร้างแผนภูมิ Box and Whisker**

แผนภูมิ Box and Whisker ใช้แสดงการกระจายของข้อมูลโดยสรุปมาตรการสถิติสำคัญเช่น มูลค่ากลาง, ควอร์ไทล์, และค่าผิดปกติ เหมาะกับการวิเคราะห์ข้อมูลสำรวจและการศึกษาทางสถิติ เพื่อเข้าใจความแปรผันของข้อมูลและค้นหาความผิดปกติอย่างรวดเร็ว

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท `ChartType.BoxAndWhisker`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Box and Whisker:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **สร้างแผนภูมิ Funnel**

แผนภูมิ Funnel ใช้ในการแสดงกระบวนการที่มีขั้นตอนต่อเนื่องโดยปริมาณข้อมูลจะลดลงเมื่อดำเนินการจากขั้นตอนหนึ่งไปยังขั้นตอนต่อไป มีประโยชน์ในการวิเคราะห์อัตราการแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท `ChartType.Funnel`  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Funnel:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Funnel chart](funnel_chart.png)

### **สร้างแผนภูมิ Sunburst**

แผนภูมิ Sunburst ใช้แสดงข้อมูลเชิงลำดับชั้นโดยแสดงระดับต่าง ๆ เป็นวงแหวนศูนย์กลาง ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนและเหมาะสำหรับการแสดงหมวดหมู่ย่อยและหมวดหมู่ย่อยต่อไปในรูปแบบที่ชัดเจนและกระชับ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท `ChartType.Sunburst`  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Sunburst:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // สาขา 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // สาขา 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Sunburst chart](sunburst_chart.png)

### **สร้างแผนภูมิ Histogram**

แผนภูมิ Histogram ใช้แสดงการกระจายของข้อมูลตัวเลขโดยการจัดกลุ่มค่าลงในช่วงหรือบิ้น ช่วยระบุรูปแบบข้อมูลเช่น ความถี่, ความเอนเอียง, การกระจาย, และการตรวจจับค่าผิดปกติในชุดข้อมูล

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภท `ChartType.Histogram`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Histogram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Histogram chart](histogram_chart.png)

### **สร้างแผนภูมิ Radar**

แผนภูมิ Radar ใช้แสดงข้อมูลหลายมิติในรูปแบบสองมิติ ทำให้เปรียบเทียบหลายตัวแปรพร้อมกันได้ง่าย เหมาะสำหรับระบุรูปแบบ, จุดแข็ง, และจุดอ่อนในหลายเมตริกหรือคุณลักษณะของประสิทธิภาพ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภท `ChartType.Radar`  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Radar:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Radar chart](radar_chart.png)

### **สร้างแผนภูมิหลายหมวดหมู่ (Multi‑Category)**

แผนภูมิหลายหมวดหมู่นำเสนอข้อมูลที่มีการจัดกลุ่มประเภทหลายระดับ ช่วยให้คุณเปรียบเทียบค่าในหลายมิติพร้อมกัน เหมาะเมื่อจำเป็นต้องวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลที่ซับซ้อนและหลายชั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท `ChartType.ClusteredColumn`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิหลายหมวดหมู่:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // เพิ่มซีรีส์.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // บันทึกงานนำเสนอพร้อมแผนภูมิ.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The multi category chart](multi_category_chart.png)

### **สร้างแผนภูมิแผนที่ (Map)**

แผนภูมิแผนที่ใช้ในการแสดงข้อมูลทางภูมิศาสตร์โดยแมปข้อมูลไปยังตำแหน่งเฉพาะเช่น ประเทศ, รัฐ, หรือเมือง เหมาะสำหรับวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและดึงดูดสายตา

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิแผนที่:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The Map chart](map_chart.png)

{{% alert color="info" %}} 
ภาพด้านบนแสดงงานนำเสนอที่บันทึกแล้วเปิดใน PowerPoint. Aspose.Slides บันทึกแผนภูมิแผนที่และข้อมูลของมันอย่างถูกต้อง แต่ไม่ได้วาดแผนภูมิแผนที่เอง: เมื่อสไลด์ที่มีแผนภูมินี้ถูกแปลงเป็นรูปภาพหรือแปลงเป็น PDF หรือ SVG พื้นที่แผนภูมิจะแสดงเป็นสีขาว รูปร่างอื่น ๆ บนสไลด์เดียวกันไม่มีผลกระทบ
{{% /alert %}} 

### **สร้างแผนภูมิรวม (Combination)**

แผนภูมิรวม (หรือ combo chart) ผสานประเภทแผนภูมิสองประเภทหรือมากกว่าบนกราฟเดียว ทำให้คุณสามารถเน้น, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุดได้ ช่วยให้มองเห็นความสัมพันธ์ระหว่างข้อมูลต่าง ๆ อย่างชัดเจน

![The combination chart](combination_chart.png)

โค้ด C# ต่อไปนี้แสดงวิธีสร้างแผนภูมิรวมที่แสดงในภาพด้านบนในงานนำเสนอ PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // ตั้งค่าชื่อเรื่องของแผนภูมิ
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // ตั้งค่าคําอธิบายของแผนภูมิ
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // เพิ่มหมวดหมู่ใหม่
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // เพิ่มซีรีส์แรก
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // ตั้งค่ามิติแนวนอน
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // ตั้งค่ามิติแนวตั้ง
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // ตั้งค่าสีของเส้นกริดหลักแนวตั้ง
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // ตั้งค่ามิติแนวนอนรอง
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // ตั้งค่ามิติแนวตั้งรอง
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **อัปเดตแผนภูมิ**

Aspose.Slides for .NET ช่วยให้คุณอัปเดตแผนภูมิโฟร์พอยต์โดยการแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ ฟังก์ชันนี้ทำให้การทำให้งานนำเสนอเป็นข้อมูลล่าสุดด้วยเนื้อหาไดนามิกง่ายขึ้นและทำให้แผนภูมสอดคล้องกับข้อมูลและมาตรฐานการแสดงผลในปัจจุบัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่เป็นงานนำเสนอที่มีแผนภูมิ  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เรียกดูทุกรูปร่างเพื่อตรวจหาแผนภูมิ  
1. เข้าถึง worksheet ของข้อมูลแผนภูมิ  
1. แก้ไขซีรีส์ข้อมูลของแผนภูมิโดยเปลี่ยนค่าซีรีส์  
1. เพิ่มซีรีส์ใหม่และเติมข้อมูลให้มัน  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีอัปเดตแผนภูมิ:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // เข้าถึงสไลด์แรก
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
            int worksheetIndex = 0;

            // ดึง workbook ของข้อมูลแผนภูมิ
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // เปลี่ยนชื่อหมวดหมู่ของแผนภูมิ
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // ดึงซีรีส์แผนภูมุตัวแรก
            IChartSeries series = chart.ChartData.Series[0];

            // อัปเดตข้อมูลของซีรีส์
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // การแก้ไขชื่อซีรีส์
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // ดึงซีรีส์แผนภูมิที่สอง
            series = chart.ChartData.Series[1];

            // อัปเดตข้อมูลของซีรีส์
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // การแก้ไขชื่อซีรีส์
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // เพิ่มซีรีส์ใหม่
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // เติมข้อมูลให้ซีรีส์
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

Aspose.Slides for .NET ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจาก worksheet เป็นแหล่งข้อมูลของแผนภูมิ หมายความว่าคุณสามารถแมปส่วนของ worksheet ไปยังแผนภูมิได้โดยตรง ช่วยให้ควบคุมได้ว่าเซลล์ใดบ้างที่มีส่วนร่วมในซีรีส์และหมวดหมู่ของแผนภูมิ ทำให้การอัปเดตและซิงโครไนซ์แผนภูมิกับการเปลี่ยนแปลงข้อมูลใน worksheet ทำได้ง่ายและทำให้นำเสนอตรงกับข้อมูลล่าสุดและถูกต้อง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่เป็นงานนำเสนอที่มีแผนภูมิ  
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เรียกดูทุกรูปร่างเพื่อตรวจหาแผนภูมิ  
1. เข้าถึงข้อมูลแผนภูมิและกำหนดช่วง  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีกำหนดช่วงข้อมูลสำหรับแผนภูมิ:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // เข้าถึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **ใช้มาร์คเกอร์เริ่มต้นในแผนภูมิ**

เมื่อใช้มาร์คเกอร์เริ่มต้นในแผนภูมิ แต่ละซีรีส์ของแผนภูมิจะได้รับสัญลักษณ์มาร์คเกอร์เริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

โค้ด C# นี้แสดงวิธีตั้งค่ามาร์คเกอร์ของซีรีส์แผนภูมิอัตโนมัติ:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // เติมข้อมูลให้ซีรีส์
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Aspose.Slides for .NET รองรับประเภทแผนภูมิใดบ้าง?**

Aspose.Slides for .NET รองรับประเภทแผนภูมิมากมาย รวมถึง แท่ง, เส้น, วงกลม, พื้นที่, สเกล, ฮิสโทแกรม, เรดาร์ และอื่น ๆ อีกหลายประเภท ความยืดหยุ่นนี้ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงผลข้อมูลของคุณได้

**ฉันจะเพิ่มแผนภูมิใหม่ลงบนสไลด์อย่างไร?**

ในการเพิ่มแผนภูมิ คุณจะต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) แล้วดึงสไลด์ที่ต้องการโดยใช้ดัชนี จากนั้นเรียกเมธอดเพิ่มแผนภูมิพร้อมระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะใส่แผนภูมิเข้าไปในงานนำเสนอของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยการเข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/)) ล้างซีรีส์และหมวดหมู่เริ่มต้น แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ นั่นทำให้คุณรีเฟรชแผนภูมิเพื่อแสดงข้อมูลล่าสุดได้โดยอัตโนมัติ

**สามารถปรับแต่งรูปลักษณ์ของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for .NET มีตัวเลือกการปรับแต่งที่ครบถ้วน คุณสามารถแก้ไขสี, ฟอนต์, ป้ายข้อความ, คำอธิบายภาพ, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงกับความต้องการด้านการออกแบบของคุณได้อย่างละเอียด