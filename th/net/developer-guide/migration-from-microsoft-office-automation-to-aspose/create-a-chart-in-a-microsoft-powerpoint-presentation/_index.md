---
title: สร้างแผนภูมิด้วย VSTO และ Aspose.Slides สำหรับ .NET
linktitle: สร้างแผนภูมิ
type: docs
weight: 80
url: /th/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- สร้างแผนภูมิ
- การย้าย
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการทำงานอัตโนมัติในการสร้างแผนภูมิ PowerPoint ด้วย C#. คู่มือแบบขั้นตอนนี้แสดงเหตุผลว่าทำไม Aspose.Slides for .NET จึงเป็นทางเลือกที่เร็วกว่าและมีประสิทธิภาพมากกว่า Microsoft.Office.Interop."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการสร้างและปรับแต่งแผนภูมิในงานนำเสนอ Microsoft PowerPoint ด้วยการเขียนโปรแกรมโดยใช้ C#. ด้วย Aspose.Slides for .NET คุณสามารถทำงานอัตโนมัติในการสร้างแผนภูมิระดับมืออาชีพที่ขับเคลื่อนด้วยข้อมูลโดยไม่ต้องพึ่งพา Microsoft Office หรือไลบรารี Interop API มีชุดฟีเจอร์ที่หลากหลายสำหรับการสร้างแผนภูมิคอลัมน์, แผนภูมิพาย, แผนภูมิเส้น, และอื่น ๆ — ทั้งหมดด้วยการควบคุมเต็มรูปแบบของลักษณะ, ข้อมูล, และรูปแบบ หากคุณกำลังสร้างรายงาน, แดชบอร์ด, หรือการนำเสนอบริษัท Aspose.Slides จะช่วยให้คุณส่งมอบการแสดงผลคุณภาพสูงโดยตรงจากแอปพลิเคชัน .NET ของคุณ

## **ตัวอย่าง VSTO**

ส่วนนี้แสดงวิธีการสร้างแผนภูมิในงานนำเสนอ Microsoft PowerPoint ด้วย **VSTO (Visual Studio Tools for Office)**. ด้วย VSTO คุณสามารถสร้างและปรับแต่งแผนภูมิโดยอัตโนมัติโดยการผสานการทำงานของ PowerPoint และ Excel ตัวอย่างที่ให้มาจะแสดงวิธีเพิ่ม **แผนภูมิคอลัมน์แบบ 3 มิติที่จัดกลุ่ม**, เติมข้อมูลจากแผ่นงาน Excel, ปรับรูปแบบและการจัดวาง, แล้วบันทึกงานนำเสนอสุดท้าย — ทั้งหมดจากภายในแอปพลิเคชัน .NET

1. สร้างอินสแตนซ์ของงานนำเสนอ Microsoft PowerPoint
1. เพิ่มสไลด์ว่างในงานนำเสนอ
1. เพิ่มแผนภูมิคอลัมน์แบบ 3 มิติที่จัดกลุ่มและเข้าถึงแผนภูนินั้น
1. สร้างอินสแตนซ์ของเวิร์กบุ๊ค Microsoft Excel ใหม่และโหลดข้อมูลแผนภูมิ
1. เข้าถึงแผ่นงานข้อมูลแผนภูมิโดยใช้อินสแตนซ์เวิร์กบุ๊ค Excel
1. กำหนดช่วงข้อมูลของแผนภูมิในแผ่นงานและลบ Series 2 และ Series 3 ออกจากแผนภูมิ
1. ปรับแก้ข้อมูลประเภทของแผนภูมิในแผ่นงานข้อมูลแผนภูมิ
1. ปรับแก้ข้อมูล Series 1 ในแผ่นงานข้อมูลแผนภูมิ
1. เข้าถึงชื่อแผนภูมิและตั้งค่าคุณสมบัติของฟอนต์
1. เข้าถึงแกนค่าของแผนภูมิและตั้งค่าหน่วยหลัก, หน่วยย่อย, ค่ามากสุด, และค่าต่ำสุด
1. เข้าถึงแกนความลึก (Series) ของแผนภูมิและลบออก — ตัวอย่างนี้ใช้เพียง Series หนึ่ง
1. ตั้งค่ามุมการหมุนของแผนภูมิในทิศทาง X และ Y
1. บันทึกงานนำเสนอ
1. ปิดอินสแตนซ์ของ Microsoft Excel และ PowerPoint

```c#
EnsurePowerPointIsRunning(true, true);

// Instantiate a slide object.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Access the first presentation slide.
objSlide = objPres.Slides[1];

// Select the first slide and set its layout.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Add a default chart to the slide.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Access the added chart.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Access the chart data.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Create an instance of the Excel workbook to work with the chart data.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Access the data worksheet for the chart.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Set the data range for the chart.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Apply the specified range to the chart data table.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Set values for categories and respective series data.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Set the chart title.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Access the chart value axis.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Set the values for the axis units.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Access the chart depth axis.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Set the chart rotation.
ppChart.Rotation = 20;   // ค่า Y
ppChart.Elevation = 15;  // ค่า X
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX file.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Close the workbook and presentation.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // ลองเข้าถึงคุณสมบัติ Name หากเกิดข้อยกเว้น ให้เริ่มอินสแตนซ์ใหม่ของ PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation ใช้เพื่อให้แน่ใจว่ามีการโหลดงานนำเสนอแล้ว.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide ใช้เพื่อให้แน่ใจว่ามีสไลด์อย่างน้อยหนึ่งสไลด์ในงานนำเสนอ.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

ผลลัพธ์:

![แผนภูมิที่สร้างด้วย VSTO](chart-created-using-VSTO.png)

## **ตัวอย่าง Aspose.Slides for .NET**

ตัวอย่างต่อไปนี้แสดงวิธีการสร้างแผนภูมิแบบง่ายในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET โค้ดนี้แสดงวิธีเพิ่ม **แผนภูมิคอลัมน์แบบ 3 มิติที่จัดกลุ่ม**, เติมข้อมูลตัวอย่าง, และปรับแต่งลักษณะของแผนภูมิ ด้วยเพียงไม่กี่บรรทัดของโค้ด คุณสามารถสร้างแผนภูมิแบบไดนามิกและรวมเข้ากับงานนำเสนอของคุณได้โดยไม่ต้องใช้ Microsoft Office

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับการอ้างอิงถึงสไลด์แรก
1. เพิ่มแผนภูมิคอลัมน์แบบ 3 มิติที่จัดกลุ่มและเข้าถึงแผนภูมินั้น
1. เข้าถึงข้อมูลแผนภูมิ
1. ลบ Series 2 และ Series 3 ที่ไม่ได้ใช้
1. ปรับแก้หมวดหมู่ของแผนภูมิโดยอัปเดตป้ายกำกับ
1. อัปเดตค่าของ Series 1
1. เข้าถึงชื่อแผนภูมิและตั้งค่าคุณสมบัติของฟอนต์
1. กำหนดค่าการตั้งค่าแกนค่าของแผนภูมิ รวมถึงหน่วยหลัก, หน่วยย่อย, ค่ามากสุด, และค่าต่ำสุด
1. ตั้งค่ามุมการหมุนของแผนภูมิบนแกน X และ Y
1. บันทึกงานนำเสนอในรูปแบบ PPTX

```cs
// สร้างงานนำเสนอเปล่า.
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่มแผนภูมิเริ่มต้น.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // รับข้อมูลแผนภูมิ.
    IChartData chartData = chart.ChartData;

    // ลบซีรีส์เริ่มต้นที่เกินออก.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // แก้ไขชื่อประเภทของแผนภูมิ.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // กำหนดดัชนีของแผ่นงานข้อมูลแผนภูมิ.
    int worksheetIndex = 0;

    // รับเวิร์กบุ๊กข้อมูลแผนภูมิ.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // แก้ไขค่าของซีรีส์แผนภูมิ.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // ตั้งค่าชื่อแผนภูมิ.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // ตั้งค่าตัวเลือกของแกน.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // ตั้งค่าการหมุนของแผนภูมิ.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![แผนภูมิที่สร้างด้วย Aspose.Slides for .NET](chart-created-using-aspose-slides.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถสร้างแผนภูมิประเภทอื่นเช่นพาย, เส้น, หรือแผนภูมิบาร์ด้วย Aspose.Slides ได้หรือไม่?**

ใช่. Aspose.Slides for .NET รองรับรูปแบบแผนภูมิหลายประเภทเช่น [chart types](/slides/th/net/create-chart/), รวมถึงแผนภูมิก้อนพาย, แผนภูมิเส้น, แผนภูมิบาร์, แผนภูมิกระจาย, แผนภูมิบับเบิล, และอื่น ๆ คุณสามารถระบุประเภทแผนภูมิที่ต้องการโดยใช้ตัวแปรนับจำนวน [ChartType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) เมื่อเพิ่มแผนภูมิ

**ฉันสามารถใช้สไตล์หรือธีมที่กำหนดเองกับแผนภูมิได้หรือไม่?**

ใช่. คุณสามารถปรับแต่งลักษณะของแผนภูมิได้อย่างเต็มที่ รวมถึงสี, ฟอนต์, การเติมสี, เส้นขอบ, เส้นกริด, และการจัดวาง อย่างไรก็ตาม การนำธีมของ Office ไปใช้เช่นเดียวกับใน PowerPoint จำเป็นต้องตั้งค่าสไตล์แต่ละอย่างด้วยตนเอง

**ฉันสามารถส่งออกแผนภูมิเป็นภาพแยกจากสไลด์ได้หรือไม่?**

ใช่, Aspose.Slides ให้คุณส่งออกรูปทรงใด ๆ — รวมถึงแผนภูมิ — เป็นภาพแยก (เช่น PNG, JPEG) โดยใช้เมธอด `GetImage` บน [shape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ของแผนภูมิ