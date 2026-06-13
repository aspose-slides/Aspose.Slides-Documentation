---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอใน .NET
linktitle: ป้ายข้อมูล
type: docs
url: /th/net/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้าย
- ตำแหน่งป้าย
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลบนแผนภูมิแสดงรายละเอียดเกี่ยวกับชุดข้อมูลของแผนภูมิหรือจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านสามารถระบุชุดข้อมูลได้อย่างรวดเร็วและทำให้แผนภูมิเข้าใจง่ายขึ้น

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลแผนภูมิ**

โค้ด C# นี้จะแสดงวิธีตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลแผนภูมิ:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **แสดงเปอร์เซ็นต์เป็นป้าย**

Aspose.Slides for .NET อนุญาตให้คุณตั้งค่าป้ายเปอร์เซ็นต์บนแผนภูมิที่แสดง โค้ด C# นี้แสดงการดำเนินการ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// บันทึกงานนำเสนอที่มีแผนภูมิอยู่
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าสัญลักษณ์เปอร์เซ็นต์กับป้ายข้อมูลแผนภูมิ**

โค้ด C# นี้จะแสดงวิธีตั้งสัญลักษณ์เปอร์เซ็นต์สำหรับป้ายข้อมูลแผนภูมิ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();

// Gets a slide's reference through its index
ISlide slide = presentation.Slides[0];

// Creates the PercentsStackedColumn chart on a slide
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Sets the NumberFormatLinkedToSource to false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Gets the chart data worksheet
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Adds new series
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Sets the fill color of series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Sets the LabelFormat properties
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Adds new series
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Sets Fill type and color
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Writes the presentation to disk
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าระยะห่างของป้ายจากแกน**

โค้ด C# นี้จะแสดงวิธีตั้งค่าระยะห่างของป้ายจากแกนหมวดหมู่เมื่อคุณทำงานกับแผนภูมิที่วางจากแกน:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();

// ดึงอ้างอิงของสไลด์
ISlide sld = presentation.Slides[0];

// สร้างแผนภูมิบนสไลด์
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// ตั้งค่าระยะห่างของป้ายจากแกน
ch.Axes.HorizontalAxis.LabelOffset = 500;

// บันทึกงานนำเสนอลงดิสก์
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **ปรับตำแหน่งป้าย**

เมื่อคุณสร้างแผนภูมิที่ไม่พึ่งพาแกนใดๆ เช่น แผนภูมิวงกลม ป้ายข้อมูลของแผนภูมิอาจอยู่ใกล้ขอบมากเกินไป ในกรณีดังกล่าว คุณต้องปรับตำแหน่งของป้ายข้อมูลเพื่อให้เส้นนำแสดงอย่างชัดเจน

โค้ด C# นี้จะแสดงวิธีปรับตำแหน่งป้ายบนแผนภูมิวงกลม:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันบนแผนภูมิที่แน่นหนาได้อย่างไร?**

ใช้การจัดตำแหน่งป้ายอัตโนมัติ, เส้นนำ, และลดขนาดฟอนต์ร่วมกัน; หากจำเป็นให้ซ่อนฟิลด์บางส่วน (เช่น หมวดหมู่) หรือแสดงป้ายเฉพาะจุดสุดขีด/สำคัญเท่านั้น

**ฉันจะปิดการใช้งานป้ายสำหรับค่าศูนย์, ค่าติดลบ, หรือค่าที่ว่างเปล่าได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงค่าที่เป็น 0, ค่าติดลบ, หรือค่าที่ขาดหายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ของป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

ตั้งค่าแบบอักษร (ตระกูล, ขนาด) อย่างชัดเจนและตรวจสอบว่าแบบอักษรนั้นมีอยู่บนเครื่องเรนเดอร์เพื่อหลีกเลี่ยงการใช้แบบอักษรสำรอง