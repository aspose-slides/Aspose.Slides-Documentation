---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอด้วย .NET
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/net/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ .NET: จัดการเวิร์กบุ๊กแผนภูมิใน PowerPoint และรูปแบบ OpenDocument อย่างง่ายดาย เพื่อทำให้ข้อมูลการนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเวิร์กบุ๊กแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ก, ใช้เซลล์ของเวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันแผ่นงาน, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก, ดึงเส้นทางของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ก**
Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ซึ่งอาจถูกแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

โค้ด C# ตัวอย่างต่อไปนี้แสดงการทำงาน:

```c#
using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

## **กำหนดเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน  
1. เข้าถึงซีรีส์ของแผนภูมิ  
1. ตั้งค่าเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูล  
1. บันทึกพรีเซนเทชัน

โค้ด C# นี้แสดงวิธีกำหนดเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน 

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **จัดการแผ่นงาน**

โค้ด C# นี้แสดงการทำงานที่ใช้คุณสมบัติ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) เพื่อเข้าถึงคอลเลกชันแผ่นงาน:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **ระบุประเภทแหล่งข้อมูล**

โค้ด C# นี้แสดงวิธีระบุประเภทสำหรับแหล่งข้อมูล:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **ตรวจจับรูปแบบเวิร์กบุ๊กฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊ก Excel แบบไบนารี (.xlsb) ที่อาจถูกฝังในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ `EmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/) ร่วมกับการอธิบายค่า [WorkbookType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // เวิร์กบุ๊กที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กของแผนภูมิที่นี่.
    }
}
```

## **เวิร์กบุ๊กภายนอก**

{{% alert color="primary" %}} 
ใน [Aspose.Slides 19.4](https://docs.aspose.com/slides/th/net/aspose-slides-for-net-19-4-release-notes/) เราได้เพิ่มการสนับสนุนเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ
{{% /alert %}} 

### **สร้างเวิร์กบุ๊กภายนอก**
โดยใช้เมธอด **`ReadWorkbookStream`** และ **`SetExternalWorkbook`** คุณสามารถสร้างเวิร์กบุ๊กภายนอกจากศูนย์หรือทำให้เวิร์กบุ๊กภายในกลายเป็นภายนอกได้

โค้ด C# นี้แสดงกระบวนการสร้างเวิร์กบุ๊กภายนอก:

```c#
using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **กำหนดเวิร์กบุ๊กภายนอก**
โดยใช้เมธอด **`SetExternalWorkbook`** คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางของเวิร์กบุ๊กภายนอก (หากเวิร์กบุ๊กถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรอื่นๆ ได้ แต่คุณยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด C# นี้แสดงวิธีกำหนดเวิร์กบุ๊กภายนอก:

```c#
// เส้นทางไปยังไดเรกทอรีเอกสาร.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `SetExternalWorkbook`) ใช้ในการระบุว่าจะโหลดเวิร์กบุ๊ก Excel หรือไม่

* เมื่อค่า `ChartData` ตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของเวิร์กบุ๊ก — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊กเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อเวิร์กบุ๊กเป้าหมายไม่มีหรือไม่สามารถเข้าถึงได้  
* เมื่อค่า `ChartData` ตั้งเป็น `true` ข้อมูลแผนภูมิจะถูกอัปเดตจากเวิร์กบุ๊กเป้าหมาย

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **ดึงเส้นทางเวิร์กบุ๊กแหล่งข้อมูลภายนอกจากแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ  
1. สร้างอ็อบเจกต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แทนแหล่งข้อมูลของแผนภูมิ  
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่ตรงกับประเภทแหล่งข้อมูลเวิร์กบุ๊กภายนอก

โค้ด C# นี้แสดงการทำงาน:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // บันทึกพรีเซนเทชัน
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในเวิร์กบุ๊กภายใน เมื่อเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ ระบบจะโยนข้อยกเว้น

โค้ด C# นี้เป็นการทำตามกระบวนการที่อธิบายไว้:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะใดเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กฝัง?**

ได้ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) หากเป็นเวิร์กบุ๊กภายนอกคุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกกำลังถูกใช้

**รองรับเส้นทางสัมพันธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่และจัดเก็บอย่างไร?**

รองรับ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะทำการแปลงเป็นเส้นทางสัมบูรณ์โดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ; อย่างไรก็ตาม การพรีเซนเทชันจะเก็บเส้นทางสัมบูรณ์ไว้ในไฟล์ PPTX

**ฉันสามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากรเครือข่ายหรือแชร์ได้หรือไม่?**

ได้ สามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอก อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชันหรือไม่?**

ไม่ พรีเซนเทชันจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกพรีเซนเทชัน

**ถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่านฉันควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ไม่เข้ารหัส (เช่น ใช้ [Aspose.Cells](/cells/net/)) และเชื่อมโยงไปยังสำเนานั้น

**แผนภูมิหลายรายการสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิเมื่อข้อมูลถูกโหลดครั้งต่อไป