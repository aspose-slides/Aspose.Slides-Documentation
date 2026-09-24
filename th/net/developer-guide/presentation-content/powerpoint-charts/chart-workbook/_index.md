---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอด้วย .NET
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/net/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายชื่อข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ .NET: จัดการสมุดงานแผนภูมิใน PowerPoint และรูปแบบ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิโดยผ่านสตรีมของสมุดงาน, ใช้เซลล์ในสมุดงานเป็นป้ายชื่อข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับสมุดงานภายนอกในฐานะแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดสมุดงานภายนอก, ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์ในสมุดงานที่แสดงข้อมูลที่หายไป, ดูที่ [Control the Display of Empty Cells](/slides/th/net/chart-series/) เพื่อเรียนรู้ความแตกต่างระหว่างเซลล์ว่างและศูนย์, และการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่อนุญาตให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องจัดระเบียบในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายคลึงกับแหล่งข้อมูล

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

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังไว้ด้วยสมุดงานที่แก้ไขแล้ว, แผนภูมิจะยังคงรักษาชุดข้อมูลซีรีส์และคอลเลกชันประเภทเดิมไว้ ความไม่ตรงกันนี้อาจทำให้ [IChart.ValidateChartLayout](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวโดยเกิดข้อผิดพลาด index-out-of-range ให้ล้างซีรีส์และประเภทที่มีอยู่ก่อนที่จะเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ

```csharp
// หลังจากแก้ไขสตรีมของสมุดงาน (เช่น ใช้ Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

การล้างคอลเลกชันจะทำให้โครงสร้างข้อมูลแผนภูมิสอดคล้องกับสมุดงานใหม่, ทำให้ `ValidateChartLayout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **กำหนดเซลล์ใน WorkBook เป็นป้ายชื่อข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) 
1. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน
1. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
1. เข้าถึงซีรีส์ของแผนภูมิ
1. กำหนดเซลล์ในสมุดงานเป็นป้ายชื่อข้อมูล
1. บันทึกการนำเสนอ

โค้ด C# นี้แสดงวิธีกำหนดเซลล์ในสมุดงานเป็นป้ายชื่อข้อมูลแผนภูมิ:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ

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

## **ระบุประเภทแหล่งข้อมูล**

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

## **ตรวจจับรูปแบบสมุดงานที่ฝังไว้ที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงานไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ `EmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/) ร่วมกับการอธิบายค่าใน enum [WorkbookType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

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
            // สมุดงานที่ฝังอยู่ในรูปแบบ .xlsb ไม่ได้รับการสนับสนุน.
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่นี่.
    }
}
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด **`ReadWorkbookStream`** และ **`SetExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกจากศูนย์หรือทำให้สมุดงานภายในกลายเป็นภายนอกได้

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

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธอด **`SetExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางของสมุดงานภายนอก (หากสมุดงานนั้นถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งหรือทรัพยากรระยะไกลได้, คุณยังคงสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากมีการระบุเส้นทางสัมพัทธ์สำหรับสมุดงานภายนอก, ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

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

พารามิเตอร์ `ChartData` (ใต้เมธอด `SetExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดสมุดงาน Excel หรือไม่

* เมื่อค่า `ChartData` ถูกตั้งเป็น `false`, จะอัปเดตเฉพาะเส้นทางของสมุดงาน — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจต้องการใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีหรือไม่พร้อมใช้งาน
* เมื่อค่า `ChartData` ถูกตั้งเป็น `true`, ข้อมูลแผนภูมิจะถูกอัปเดตจากสมุดงานเป้าหมาย

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

### **รับเส้นทางสมุดงานแหล่งข้อมูลภายนอกจากแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน
1. สร้างอ็อบเจ็กต์สำหรับรูปทรงแผนภูมิ
1. สร้างอ็อบเจ็กต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แสดงถึงแหล่งข้อมูลของแผนภูมิ
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงตามประเภทของแหล่งข้อมูลที่เป็นประเภทเดียวกันกับประเภทแหล่งข้อมูลสมุดงานภายนอก

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
    
    // บันทึกงานนำเสนอ
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในสมุดงานภายใน เมื่อไม่สามารถโหลดสมุดงานภายนอกได้ จะมีการโยนข้อยกเว้น

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

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน, Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่แคชในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/), กำหนดค่า [SpreadsheetOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/spreadsheetoptions/), และตั้งค่า [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง C# ด้านล่างเปิดงานนำเสนอที่แผนภูมิอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.ChartData](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/chartdata/) และ [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

// อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะโยน `InvalidOperationException` ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นทางเลือกที่ยอมรับได้, เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากงานนำเสนอได้รับการอัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังไว้?**

ใช่. แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/); หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อให้แน่ใจว่ามีการใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพัทธ์ไปยังสมุดงานภายนอกหรือไม่, และเก็บอย่างไร?**

ใช่. หากระบุเส้นทางสัมพัทธ์ ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ; อย่างไรก็ตาม โปรดทราบว่างานนำเสนอจะเก็บเส้นทางเต็มในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนเครือข่าย/แชร์ได้หรือไม่?**

ได้, สมุดงานเช่นนั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

ไม่. งานนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) และใช้เพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกงานนำเสนอ

**ควรทำอย่างไรถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อลิงก์ วิธีที่พบบ่อยคือการลบการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/net/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งถัดไปที่โหลดข้อมูล