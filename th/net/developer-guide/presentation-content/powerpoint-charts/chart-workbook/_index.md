---
title: จัดการเวิร์กบุ๊คแผนภูมิในงานนำเสนอด้วย .NET
linktitle: เวิร์กบุ๊คแผนภูมิ
type: docs
weight: 70
url: /th/net/chart-workbook/
keywords:
- เวิร์กบุ๊คแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ค
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กบุ๊คภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ค
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ .NET: จัดการเวิร์กบุ๊คแผนภูมิใน PowerPoint และรูปแบบ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลงานนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเวิร์กบุ๊คของแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ค, ใช้เซลล์ของเวิร์กบุ๊คเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความยังครอบคลุมการทำงานกับเวิร์กบุ๊คภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดเวิร์กบุ๊คภายนอก, ดึงเส้นทางของเวิร์กบุ๊คภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊คพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ค**

Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ช่วยให้คุณอ่านและเขียนเวิร์กบุ๊คข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูติต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

โค้ด C# นี้แสดงตัวอย่างการดำเนินการ:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

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

### **ตรวจสอบการจัดเรียงแผนภูมิหลังการแก้ไขเวิร์กบุ๊ค**

เมื่อคุณแทนที่เวิร์กบุ๊คที่ฝังไว้ด้วยเวิร์กบุ๊คที่แก้ไขแล้ว แผนภูมิจะยังคงรักษาชุดข้อมูลซีรีส์และคอลเลกชันของประเภทเดิม การไม่ตรงกันนี้อาจทำให้ [IChart.ValidateChartLayout](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ล้างซีรีส์และประเภทที่มีอยู่ก่อนเขียนเวิร์กบุ๊คที่อัปเดตกลับไปยังแผนภูมิ

```csharp
// หลังจากแก้ไขสตรีมของเวิร์กบุ๊ค (เช่น การใช้ Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

การล้างคอลเลกชันทำให้โครงสร้างข้อมูลแผนภูมิสอดคล้องกับเวิร์กบุ๊คใหม่, ทำให้ `ValidateChartLayout` สามารถทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **ตั้งค่าเซลล์เวิร์กบุ๊คเป็นป้ายกำกับข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน  
4. เข้าถึงซีรีส์ของแผนภูมิ  
5. ตั้งค่าเซลล์ของเวิร์กบุ๊คเป็นป้ายกำกับข้อมูล  
6. บันทึกการนำเสนอ  

โค้ด C# นี้แสดงวิธีตั้งค่าเซลล์เวิร์กบุ๊คเป็นป้ายกำกับข้อมูลแผนภูมิ:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาส presentation ที่แสดงไฟล์งานนำเสนอ 

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

โค้ด C# นี้แสดงการดำเนินการที่ใช้คุณสมบัติ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) เพื่อเข้าถึงคอลเลกชันของแผ่นงาน:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **ระบุประเภทของแหล่งข้อมูล**

โค้ด C# นี้แสดงวิธีการระบุประเภทสำหรับแหล่งข้อมูล:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

## **ตรวจจับรูปแบบเวิร์กบุ๊คฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊คแบบไบนารี Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ `EmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมินั้นๆ

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

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
            // เวิร์กบุ๊คที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊คของแผนภูมิเกรงนี้.
    }
}
```

## **เวิร์กบุ๊คภายนอก**

{{% alert color="info" %}} 
ใน [Aspose.Slides 19.4](https://docs.aspose.com/slides/th/net/aspose-slides-for-net-19-4-release-notes/), เราได้เพิ่มการสนับสนุนเวิร์กบุ๊คภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ
{{% /alert %}} 

### **สร้างเวิร์กบุ๊คภายนอก**

โดยใช้เมธอด **`ReadWorkbookStream`** และ **`SetExternalWorkbook`** คุณสามารถสร้างเวิร์กบุ๊คภายนอกจากศูนย์หรือทำให้เวิร์กบุ๊คภายในกลายเป็นภายนอกได้

โค้ด C# นี้แสดงกระบวนการสร้างเวิร์กบุ๊คภายนอก:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

### **กำหนดเวิร์กบุ๊คภายนอก**

โดยใช้เมธอด **`SetExternalWorkbook`** คุณสามารถกำหนดเวิร์กบุ๊คภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังเวิร์กบุ๊คภายนอก (หากไฟล์ดังกล่าวถูกย้าย)

แม้ว่าคุณไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊คที่เก็บในตำแหน่งหรือแหล่งข้อมูลระยะไกลได้ แต่คุณยังสามารถใช้เวิร์กบุ๊คเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางแบบสัมพันธ์สำหรับเวิร์กบุ๊คภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด C# นี้แสดงวิธีกำหนดเวิร์กบุ๊คภายนอก:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `SetExternalWorkbook`) ใช้กำหนดว่าจะโหลดเวิร์กบุ๊ค Excel หรือไม่

* เมื่อค่าพารามิเตอร์ `ChartData` ตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของเวิร์กบุ๊คเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊คเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อเวิร์กบุ๊คเป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้  
* เมื่อค่าพารามิเตอร์ `ChartData` ตั้งเป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากเวิร์กบุ๊คเป้าหมาย

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **รับเส้นทางเวิร์กบุ๊คแหล่งข้อมูลภายนอกของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างออบเจกต์สำหรับรูปแบบแผนภูมิ  
4. สร้างออบเจกต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แทนแหล่งข้อมูลของแผนภูมิ  
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่เหมือนกับประเภทแหล่งข้อมูลเวิร์กบุ๊คภายนอก  

โค้ด C# นี้แสดงการดำเนินการ:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // บันทึกการนำเสนอ
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊คภายนอกได้เช่นเดียวกับที่ทำการเปลี่ยนแปลงเนื้อหาในเวิร์กบุ๊คภายใน เมื่อเวิร์กบุ๊คภายนอกไม่สามารถโหลดได้ จะมีการโยนข้อยกเว้น

โค้ด C# นี้เป็นการดำเนินการตามขั้นตอนที่อธิบายไว้:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **กู้คืนเวิร์กบุ๊คจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กบุ๊คภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างเวิร์กบุ๊คแผนภูมิโดยอิงจากข้อมูลที่แคชไว้ในไฟล์การนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/), ตั้งค่าของ [SpreadsheetOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/spreadsheetoptions/), และตั้งค่า [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดไฟล์การนำเสนอ

ตัวอย่าง C# ต่อไปนี้เปิดไฟล์การนำเสนอที่แผนภูมิอ้างอิงเวิร์กบุ๊คภายนอกที่ไม่สามารถเข้าถึงได้ และเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.ChartData](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/chartdata/) และ [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

หากเวิร์กบุ๊คภายนอกไม่สามารถเข้าถึงได้และการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยน `InvalidOperationException` เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชไว้เป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊คภายนอกหลังจากการอัปเดตไฟล์การนำเสนอครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิที่กำหนดเชื่อมโยงกับเวิร์กบุ๊คภายนอกหรือเวิร์กบุ๊คที่ฝังอยู่?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) หากแหล่งข้อมูลเป็นเวิร์กบุ๊คภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ากำลังใช้ไฟล์ภายนอก

**รองรับเส้นทางแบบสัมพันธ์สำหรับเวิร์กบุ๊คภายนอกหรือไม่ และจัดเก็บอย่างไร?**

ใช่ หากคุณระบุเส้นทางแบบสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ; อย่างไรก็ตาม โปรดทราบว่าไฟล์การนำเสนอจะบันทึกเส้นทางเต็มในไฟล์ PPTX

**ฉันสามารถใช้เวิร์กบุ๊คที่อยู่บนทรัพยากรหรือแชร์เครือข่ายได้หรือไม่?**

ได้ เวิร์กบุ๊คเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊คระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

ไม่ การนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกจะไม่ถูกแก้ไขเมื่อบันทึกการนำเสนอ

**ควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อลิงก์ แนะนำให้ถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น การใช้ [Aspose.Cells](/cells/net/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊คภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดอ้างอิงไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล