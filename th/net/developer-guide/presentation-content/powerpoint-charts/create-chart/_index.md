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
- แผนภูมิกระจายจุด
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิแผนที่ต้นไม้
- แผนภูมิหุ้น
- แผนภูมิ Box and Whisker
- แผนภูมิ Funnel
- แผนภูมิ Sunburst
- แผนภูมิ Histogram
- แผนภูมิ Radar
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET. เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ใช้งานได้จริงใน C#."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำอย่างละเอียดเกี่ยวกับวิธีสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for .NET คุณจะได้เรียนรู้วิธีเพิ่มแผนภูมิลงในสไลด์อย่างโปรแกรมเมติก เติมข้อมูลเข้าไปและใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้สอดคล้องกับความต้องการออกแบบของคุณ ตลอดบทความ ตัวอย่างโค้ดที่ละเอียดจะอธิบายทุกขั้นตอน ตั้งแต่การเริ่มต้น Presentation และออบเจกต์แผนภูมิ ไปจนถึงการกำหนด Series, Axes และ Legend ด้วยการทำตามคำแนะนำนี้ คุณจะเข้าใจวิธีผสานการสร้างแผนภูมิแบบไดนามิกเข้าไปในแอปพลิเคชัน .NET ของคุณ ทำให้การสร้างงานนำเสนอที่อิงข้อมูลเป็นเรื่องง่ายและรวดเร็ว

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและได้รับอินไซต์ที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

โดยใช้แผนภูมิ คุณสามารถ:

* รวมรวม ย่อหรือสรุปข้อมูลจำนวนมากลงในสไลด์เดียวของงานนำเสนอ;
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล;
* สรุปทิศทางและความเคลื่อนไหวของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดที่กำหนด;
* ตรวจพบค่าผิดปกติ ความเบี่ยงเบน ความผิดพลาด และข้อมูลที่ไม่สมเหตุสมผล;
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ที่มีแม่แบบสำหรับออกแบบแผนภูมิต่าง ๆ ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (จากประเภทแผนภูมิยอดนิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="primary" %}} 
ใช้ [ChartType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) enumeration ภายใต้ namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/th/net/aspose.slides.charts/) ค่าต่าง ๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ
{{% /alert %}} 

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ส่วนนี้อธิบายวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่มด้วย Aspose.Slides for .NET คุณจะได้เรียนรู้การเริ่มต้น Presentation, เพิ่มแผนภูมิ, และปรับแต่งองค์ประกอบต่าง ๆ เช่น ชื่อเรื่อง, ข้อมูล, Series, Categories และสไตล์ ตามขั้นตอนด้านล่างเพื่อดูวิธีการสร้างแผนภูมิคอลัมน์แบบกลุ่มมาตรฐาน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภท `ChartType.ClusteredColumn`  
1. เพิ่มชื่อเรื่องให้กับแผนภูมิ  
1. เข้าถึง worksheet ของข้อมูลแผนภูมิ  
1. ลบ Series และ Categories เริ่มต้นทั้งหมด  
1. เพิ่ม Series และ Categories ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series  
1. ตั้งค่าสีเติมให้กับ Series  
1. เพิ่มป้ายกำกับให้กับ Series  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่ม:

```c#
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

    // ตั้งค่า series แรกให้แสดงค่า.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // ตั้งดัชนีของชีตข้อมูลแผนภูมิ.
    int worksheetIndex = 0;

    // ดึง workbook ของข้อมูลแผนภูมิ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ลบ series และ categories ที่สร้างโดยอัตโนมัติ.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // เพิ่ม series ใหม่.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // เพิ่ม categories ใหม่.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // ดึง series แผนภูมิเ�แรก.
    IChartSeries series = chart.ChartData.Series[0];

    // เติมข้อมูลให้ series.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // ตั้งค่าสีเติมสำหรับ series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // ดึง series แผนภูมิที่สอง.
    series = chart.ChartData.Series[1];

    // เติมข้อมูลให้ series.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // ตั้งค่าสีเติมสำหรับ series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // ตั้งค่า label แรกให้แสดงชื่อหมวดหมู่.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // ตั้งค่า series ให้แสดงค่าบน label ที่สาม.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // บันทึกการนำเสนอเป็นไฟล์ PPTX บนดิสก์.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![แผนภูมิคอลัมน์แบบกลุ่ม](clustered_column_chart.png)

### **สร้างแผนภูมิแบบกระจายจุด**

แผนภูมิแบบกระจายจุด (หรือ scatter plot, กราฟ x‑y) มักใช้เพื่อตรวจหารูปแบบหรือแสดงความสัมพันธ์ระหว่างตัวแปรสองตัว

ใช้แผนภูมิแบบกระจายจุดเมื่อ:

* คุณมีข้อมูลตัวเลขแบบคู่  
* มีสองตัวแปรที่สัมพันธ์กันดี  
* ต้องการตรวจสอบว่าตัวแปรทั้งสองเกี่ยวข้องกันหรือไม่  
* มีตัวแปรอิสระที่มีค่าหลายค่าเพื่อกำหนดค่าตัวแปรตาม  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิแบบกระจายจุดพร้อมชุด marker ที่แตกต่างกัน:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // สร้างแผนภูมิกระจาย (scatter) เริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ.
    int worksheetIndex = 0;

    // ดึง workbook ของข้อมูลแผนภูมิ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ลบ series เริ่มต้น.
    chart.ChartData.Series.Clear();

    // เพิ่ม series ใหม่.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // ดึง series แผนภูมิแรก.
    IChartSeries series = chart.ChartData.Series[0];

    // เพิ่มจุดใหม่ (1:3) ไปยัง series.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // เพิ่มจุดใหม่ (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // เปลี่ยนประเภทของ series.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // เปลี่ยน marker ของ series แผนภูมิ.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // ดึง series แผนภูมิที่สอง.
    series = chart.ChartData.Series[1];

    // เพิ่มจุดใหม่ (5:2) ไปยัง series แผนภูมิ.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // เพิ่มจุดใหม่ (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // เพิ่มจุดใหม่ (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // เพิ่มจุดใหม่ (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // เปลี่ยน marker ของ series แผนภูมิ.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // บันทึกการนำเสนอเป็นไฟล์ PPTX บนดิสก์.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![แผนภูมิกระจายจุด](scatter_chart.png)

### **สร้างแผนภูมิวงกลม**

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนทั้งหมดของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายหมวดหมู่พร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลมีหลายส่วนหรือหลายป้ายบ่งชี้ ควรพิจารณาใช้แผนภูมิแท่งแทน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.Pie`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ลบ Series และ Categories เริ่มต้นทั้งหมด  
1. เพิ่ม Series และ Categories ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series  
1. เพิ่มจุดใหม่ให้กับแผนภูมิและกำหนดสีแบบกำหนดเองให้กับส่วนของแผนภูมิวงกลม  
1. ตั้งค่าป้ายกำกับสำหรับ Series  
1. เปิดใช้งาน leader lines สำหรับป้ายกำกับ Series  
1. ตั้งค่ามุมการหมุนของแผนภูมิวงกลม  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิวงกลม:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่มแผนภูมิกับข้อมูลเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // ตั้งค่าชื่อเรื่องของแผนภูมิ.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // ตั้งค่า series แรกให้แสดงค่า.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // ตั้งดัชนีของชีตข้อมูลแผนภูมิ.
    int worksheetIndex = 0;

    // ดึง workbook ของข้อมูลแผนภูมิ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ลบ series และ categories ที่สร้างโดยอัตโนมัติ.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // เพิ่ม categoriesใหม่.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // เพิ่ม seriesใหม่.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // เติมข้อมูลให้ series.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // ตั้งค่าสีของส่วน.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // ตั้งค่าเส้นขอบของส่วน.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // ตั้งค่าเส้นขอบของส่วน.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // ตั้งค่าเส้นขอบของส่วน.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ใน series ใหม่.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // ตั้งค่า series ให้แสดงเส้นเชื่อมสำหรับแผนภูมิ.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // ตั้งค่ามุมการหมุนของส่วนในแผนภูมวงกลม.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // บันทึกการนำเสนอเป็นไฟล์ PPTX บนดิสก์.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![แผนภูมิวงกลม](pie_chart.png)

### **สร้างแผนภูมิเส้น**

แผนภูมิเส้น (หรือ line graph) เหมาะสำหรับแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ใช้แผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากในครั้งเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, ไฮไลท์ความผิดปกติใน Series ฯลฯ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.Line`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ลบ Series และ Categories เริ่มต้นทั้งหมด  
1. เพิ่ม Series และ Categories ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิเส้น:

```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

โดยปกติ จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมด้วยเส้นประ ให้กำหนดประเภท dash ที่ต้องการดังนี้:

```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

ผลลัพธ์:

![แผนภูมิเส้น](line_chart.png)

### **สร้างแผนภูมิ Tree Map**

แผนภูมิ Tree Map เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปที่รายการที่เป็นผู้สนับสนุนหลักในแต่ละหมวดหมู่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.Treemap`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ลบ Series และ Categories เริ่มต้นทั้งหมด  
1. เพิ่ม Series และ Categories ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Tree Map:

```c#
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

![แผนภูมิ Tree Map](treemap_chart.png)

### **สร้างแผนภูมิ Stock**

แผนภูมิ Stock แสดงข้อมูลการเงินเช่นราคาเปิด, สูง, ต่ำ, ปิด ช่วยวิเคราะห์แนวโน้มตลาดและความผันผวน ให้ข้อมูลสำคัญเกี่ยวกับประสิทธิภาพของหุ้นเพื่อสนับสนุนการตัดสินใจของนักลงทุนและนักวิเคราะห์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.OpenHighLowClose`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ลบ Series และ Categories เริ่มต้นทั้งหมด  
1. เพิ่ม Series และ Categories ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series  
1. ระบุรูปแบบ HiLowLines  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Stock:

```c#
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

![แผนภูมิ Stock](stock_chart.png)

### **สร้างแผนภูมิ Box and Whisker**

แผนภูมิ Box and Whisker แสดงการกระจายของข้อมูลโดยสรุปสถิติสำคัญ เช่น มัธยฐาน, ควอร์ไทล์, และค่า outlier เหมาะสำหรับการวิเคราะห์สำรวจข้อมูลและการศึกษาทางสถิติเพื่อทำความเข้าใจความเปลี่ยนแปลงของข้อมูลและระบุความผิดปกติ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.BoxAndWhisker`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ลบ Series และ Categories เริ่มต้นทั้งหมด  
1. เพิ่ม Series และ Categories ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Box and Whisker:

```c#
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

แผนภูมิ Funnel ใช้แสดงกระบวนการที่มีขั้นตอนต่อเนื่อง โดยปริมาณข้อมูลจะลดลงตามขั้นตอน ช่วยวิเคราะห์อัตราการแปลง, ระบุคอขวด, ติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.Funnel`  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Funnel:

```c#
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

![แผนภูมิ Funnel](funnel_chart.png)

### **สร้างแผนภูมิ Sunburst**

แผนภูมิ Sunburst ใช้แสดงข้อมูลเชิงลำดับชั้นโดยแสดงระดับต่าง ๆ เป็นวงรอบศูนย์กลาง ช่วยสื่อสารความสัมพันธ์ส่วนต่อส่วนทั้งหมดและเหมาะกับการแสดงหมวดหมู่และหมวดย่อยแบบซ้อนกันในรูปแบบที่กระชับ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.Sunburst`  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Sunburst:

```c#
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

![แผนภูมิ Sunburst](sunburst_chart.png)

### **สร้างแผนภูมิ Histogram**

แผนภูมิ Histogram แสดงการกระจายของข้อมูลตัวเลขโดยจัดกลุ่มค่าเป็นช่วงหรือบ๊อกซ์ ใช้เพื่อระบุรูปแบบความถี่, ความผิดปกติ, การกระจาย และตรวจจับ outlier ในชุดข้อมูล

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภท `ChartType.Histogram`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ลบ Series และ Categories เริ่มต้นทั้งหมด  
1. เพิ่ม Series และ Categories ใหม่  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Histogram:

```c#
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

![แผนภูมิ Histogram](histogram_chart.png)

### **สร้างแผนภูมิ Radar**

แผนภูมิ Radar แสดงข้อมูลหลายตัวแปรในรูปแบบสองมิติ ทำให้เปรียบเทียบหลายตัวแปรพร้อมกันได้ง่าย เหมาะสำหรับค้นหารูปแบบ, จุดแข็ง, จุดอ่อนของเมตริกหรือคุณลักษณะหลาย ๆ อย่าง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภท `ChartType.Radar`  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Radar:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![แผนภูมิ Radar](radar_chart.png)

### **สร้างแผนภูมิ Multi‑Category**

แผนภูมิ Multi‑Category ใช้แสดงข้อมูลที่มีการจัดกลุ่มเชิงหมวดหมู่หลายระดับ ช่วยเปรียบเทียบค่าข้ามมิติหลาย ๆ ด้านพร้อมกัน เหมาะกับการวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลที่ซับซ้อนและหลายชั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.ClusteredColumn`  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/))  
1. ลบ Series และ Categories เริ่มต้นทั้งหมด  
1. เพิ่ม Series และ Categories ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Multi‑Category:

```c#
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

    // เพิ่ม series.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // บันทึกการนำเสนอพร้อมแผนภูมิ.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![แผนภูมิ Multi‑Category](multi_category_chart.png)

### **สร้างแผนภูมิ Map**

แผนภูมิ Map ใช้แสดงข้อมูลทางภูมิศาสตร์โดยแมปข้อมูลไปยังตำแหน่งเช่น ประเทศ, รัฐ หรือเมือง ช่วยวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, การกระจายเชิงพื้นที่อย่างชัดเจนและดึงดูดสายตา

โค้ด C# นี้แสดงวิธีสร้างแผนภูมิ Map:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![แผนภูมิ Map](map_chart.png)

### **สร้างแผนภูมิ Combination**

แผนภูมิ Combination (หรือ combo chart) ผสานประเภทแผนภูมิสองประเภทหรือมากกว่าบนกราฟเดียว ช่วยเน้น, เปรียบเทียบ หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด เพื่อให้เห็นความสัมพันธ์ได้ชัดเจน

![แผนภูมิ Combination](combination_chart.png)

โค้ด C# ด้านล่างแสดงวิธีสร้างแผนภูมิ Combination ที่แสดงในภาพด้านบนใน PowerPoint:

```c#
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

    // ตั้งค่า Legend ของแผนภูมิ
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // ลบ series และ categories ที่สร้างโดยอัตโนมัติ
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // เพิ่ม categories ใหม่
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // เพิ่ม series แรก
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
    // ตั้งค่าแกนแนวนอน
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // ตั้งค่าแกนแนวดิ่ง
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // ตั้งค่าสีเส้นกริดหลักแนวดิ่ง
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // ตั้งค่าแกนแนวนอนรอง
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // ตั้งค่าแกนแนวดิ่งรอง
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

Aspose.Slides for .NET ทำให้คุณอัปเดตแผนภูมิ PowerPoint ได้โดยแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ และสไตล์ ช่วยให้งานนำเสนอเป็นปัจจุบันกับเนื้อหาไดนามิกและทำให้แผนภูมิตรงกับข้อมูลและมาตรฐานการออกแบบล่าสุด

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่เป็นตัวแทนของงานนำเสนอที่มีแผนภูมิ  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. วนลูปผ่าน shape ทั้งหมดเพื่อค้นหาแผนภูมิ  
1. เข้าถึง worksheet ของข้อมูลแผนภูมิ  
1. แก้ไข Series ของข้อมูลแผนภูมิโดยเปลี่ยนค่าของ Series  
1. เพิ่ม Series ใหม่และใส่ข้อมูลลงไป  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีอัปเดตแผนภูมิ:

```c#
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
            // ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ
            int worksheetIndex = 0;

            // ดึง workbook ของข้อมูลแผนภูมิ
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // เปลี่ยนชื่อหมวดหมู่ของแผนภูมิ
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // ดึง series แผนภูมิแรก
            IChartSeries series = chart.ChartData.Series[0];

            // อัปเดตข้อมูลของ series
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // แก้ไขชื่อ series.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // ดึง series แผนภูมิที่สอง
            series = chart.ChartData.Series[1];

            // อัปเดตข้อมูลของ series
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // แก้ไขชื่อ series.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // เพิ่ม series ใหม่
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // เติมข้อมูลให้ series
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // บันทึกการนำเสนอพร้อมแผนภูมิ
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

Aspose.Slides for .NET ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจาก worksheet เป็นแหล่งข้อมูลของแผนภูมิของคุณ หมายความว่าคุณสามารถแมปส่วนของ worksheet ไปยังแผนภูมิได้โดยตรง ควบคุมว่าเซลล์ใดบ้างที่มีส่วนร่วมใน Series และ Categories ของแผนภูมิ ทำให้คุณอัปเดตและทำให้แผนภูมิสอดคล้องกับการเปลี่ยนแปลงข้อมูลล่าสุดใน worksheet ได้ง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่เป็นตัวแทนของงานนำเสนอที่มีแผนภูมิ  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์  
1. วนลูปผ่าน shape ทั้งหมดเพื่อค้นหาแผนภูมิ  
1. เข้าถึงข้อมูลแผนภูมิและกำหนดช่วง  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีกำหนดช่วงข้อมูลสำหรับแผนภูมิ:

```c#
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
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **ใช้ Marker เริ่มต้นในแผนภูมิ**

เมื่อใช้ Marker เริ่มต้นในแผนภูมิแต่ละ Series จะได้รับสัญลักษณ์ Marker เริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

โค้ด C# นี้แสดงวิธีตั้งค่า Marker ของ Series โดยอัตโนมัติ:

```c#
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

    // เติมข้อมูลให้ series.
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

**Aspose.Slides for .NET รองรับประเภทแผนภูมิอะไรบ้าง?**

Aspose.Slides for .NET รองรับประเภทแผนภูมิมากมาย รวมถึง bar, line, pie, area, scatter, histogram, radar และอื่น ๆ ทำให้คุณเลือกประเภทที่เหมาะสมกับการแสดงผลข้อมูลของคุณได้

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์ได้อย่างไร?**

ในการเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) แล้วดึงสไลด์ที่ต้องการโดยใช้ดัชนี และเรียกเมธอดเพิ่มแผนภูมิพร้อมระบุประเภทและข้อมูลเริ่มต้น กระบวนการนี้จะผสานแผนภูมิลงในงานนำเสนอของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง workbook ของแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/)) ลบ Series และ Categories เริ่มต้น แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ ซึ่งจะทำให้แผนภูมิรีเฟรชตามข้อมูลล่าสุด

**ฉันสามารถปรับเปลี่ยนลักษณะของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for .NET มีตัวเลือกการปรับแต่งหลายอย่าง คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, Legend และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงกับความต้องการด้านการออกแบบของคุณได้อย่างเต็มที่.