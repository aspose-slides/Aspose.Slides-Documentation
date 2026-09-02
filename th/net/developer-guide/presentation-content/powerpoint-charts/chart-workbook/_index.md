---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานพรีเซนเทชันด้วย .NET
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/net/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายข้อมูล
- เวิร์กชีท
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ .NET: จัดการเวิร์กบุ๊กแผนภูมิใน PowerPoint และรูปแบบ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลพรีเซนเทชันของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเวิร์กบุ๊กของแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ก, ใช้เซลล์ในเวิร์กบุ๊กเป็นป้ายข้อมูลของแผนภูมิ, เข้าถึงคอลเลกชันของชีท, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก, ดึงเส้นทางของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ก**
Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ซึ่งประกอบด้วยข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ว่าข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูลต้นฉบับ

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

## **ตั้งค่าเซลล์ของเวิร์กบุ๊กเป็นป้ายข้อมูลของแผนภูมิ**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน  
4. เข้าถึงซีรีส์ของแผนภูมิ  
5. ตั้งค่าเซลล์ของเวิร์กบุ๊กเป็นป้ายข้อมูล  
6. บันทึกการพรีเซนเทชัน

โค้ด C# นี้แสดงวิธีตั้งค่าเซลล์ของเวิร์กบุ๊กเป็นป้ายข้อมูลของแผนภูมิ:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่เป็นตัวแทนไฟล์พรีเซนเทชัน 

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

## **จัดการ Worksheet**

โค้ด C# นี้แสดงการทำงานโดยใช้คุณสมบัติ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) เพื่อเข้าถึงคอลเลกชันของ Worksheet:

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊กไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ `EmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/) พร้อมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิที่เกี่ยวข้อง

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

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กของแผนภูมิที่นี่
    }
}
```

## **เวิร์กบุ๊กภายนอก**

{{% alert color="primary" %}} 
ใน [Aspose.Slides 19.4](https://docs.aspose.com/slides/th/net/aspose-slides-for-net-19-4-release-notes/) เราเพิ่มการรองรับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ
{{% /alert %}} 

### **สร้างเวิร์กบุ๊กภายนอก**
โดยใช้เมธอด **`ReadWorkbookStream`** และ **`SetExternalWorkbook`** คุณสามารถสร้างเวิร์กบุ๊กภายนอกตั้งแต่ต้นหรือทำให้เวิร์กบุ๊กภายในกลายเป็นภายนอกได้

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
โดยใช้เมธอด **`SetExternalWorkbook`** คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางของเวิร์กบุ๊กภายนอก (หากไฟล์ดังกล่าวถูกย้ายไป)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้ คุณก็ยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

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

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `SetExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดเวิร์กบุ๊ก Excel หรือไม่  

* เมื่อค่า `ChartData` ตั้งเป็น `false` จะอัปเดตเพียงเส้นทางของเวิร์กบุ๊ก — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊กเป้าหมาย คุณอาจต้องการใช้การตั้งค่านี้เมื่อเวิร์กบุ๊กเป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้  
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

### **ดึงเส้นทางของเวิร์กบุ๊กแหล่งข้อมูลภายนอกจากแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์สำหรับรูปร่างแผนภูมิ  
4. สร้างอ็อบเจ็กต์สำหรับชนิดแหล่งข้อมูล (`ChartDataSourceType`) ที่แสดงถึงแหล่งข้อมูลของแผนภูมิ  
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอ้างอิงประเภทแหล่งข้อมูลที่ตรงกับประเภทของเวิร์กบุ๊กภายนอก

โค้ด C# นี้แสดงการดำเนินการ:

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

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการแก้ไขเนื้อหาของเวิร์กบุ๊กภายใน หากไม่สามารถโหลดเวิร์กบุ๊กภายนอก ระบบจะขว้างข้อยกเว้น

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

### **กู้คืนเวิร์กบุ๊กจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างเวิร์กบุ๊กของแผนภูมิใหม่จากข้อมูลที่แคชอยู่ในพรีเซนเทชันได้ ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/), กำหนดค่า [SpreadsheetOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/spreadsheetoptions/), และตั้งค่า [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดพรีเซนเทชัน

ตัวอย่าง C# ด้านล่างเปิดพรีเซนเทชันที่แผนภูมิอ้างอิงเวิร์กบุ๊กภายนอกที่ไม่สามารถเข้าถึงได้และเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.ChartData](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/chartdata/) และ [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/chartdataworkbook/) :

```csharp
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

// อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กที่กู้คืนที่นี่.
```

หากเวิร์กบุ๊กภายนอกไม่สามารถเข้าถึงได้และการกู้คืนถูกปิดการทำงาน Aspose.Slides จะขว้าง `InvalidOperationException` เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชไว้เป็นการสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊กภายนอกหลังจากพรีเซนเทชันอัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดได้หรือไม่ว่าแผนภูมิกำลังเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กที่ฝังอยู่?**

ใช่ แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/datasourcetype/) และ [เส้นทางไปยังเวิร์กบุ๊กภายนอก](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) หากแหล่งข้อมูลเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกถูกใช้งานอยู่

**รองรับเส้นทางสัมพันธ์สำหรับเวิร์กบุ๊กภายนอกหรือไม่และมันถูกจัดเก็บอย่างไร?**

รองรับ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ ซึ่งสะดวกสำหรับการพกโครงการ อย่างไรก็ตาม พรีเซนเทชันจะเก็บเส้นทางเต็มไว้ในไฟล์ PPTX

**ฉันสามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากรหรือแชร์เครือข่ายได้หรือไม่?**

ใช่ เวิร์กบุ๊กเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชันหรือไม่?**

ไม่ พรีเซนเทชันจะเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) แล้วใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกพรีเซนเทชัน

**ถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่านควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัส (เช่นโดยใช้ [Aspose.Cells](/cells/net/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดอ้างอิงไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะส่งผลต่อทุกแผนภูมิในครั้งถัดไปที่โหลดข้อมูล**