---
title: ใช้สูตรแผ่นงานแผนภูมิในงานนำเสนอด้วย .NET
linktitle: สูตรแผ่นงาน
type: docs
weight: 70
url: /th/net/chart-worksheet-formulas/
keywords:
- สเปรดชีตของแผนภูมิ
- แผ่นงานแผนภูมิ
- สูตรแผนภูมิ
- สูตรแผ่นงาน
- สูตรสเปรดชีต
- สมุดงานข้อมูลแผนภูมิ
- การคำนวณสูตร
- วัฒนธรรมที่ต้องการ
- สูตรตามวัฒนธรรม
- DBCS
- ค่าคงที่ตรรกะ
- ค่าคงที่เชิงจำนวน
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันกำหนดล่วงหน้า
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ในแผ่นงานแผนภูมิของ Aspose.Slides สำหรับ .NET, คำนวณค่าซ้ำ, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

แผนภูมิ PowerPoint มักจะเก็บข้อมูลต้นฉบับไว้ในแผ่นงานที่ฝังอยู่ ใน Aspose.Slides for .NET คุณสามารถเข้าถึงแผ่นงานนั้นผ่านสมุดงานข้อมูลแผนภูมิ, เขียนค่าอินพุต, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่รองรับ, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลแผนภูมิได้

บทความนี้อธิบายขั้นตอนการทำงานของสูตรอย่างสมบูรณ์: สร้างแผนภูมิ, เติมข้อมูลในแผ่นงาน, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณสูตรใหม่, อ่านค่าที่คำนวณได้, เชื่อมต่อเซลล์เหล่านั้นกับซีรีส์ของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่รองรับ, ชุดฟังก์ชันในตัว, ค่าที่แคชไว้, สูตรที่ไม่รองรับ, และข้อผิดพลาดเฉพาะสเปรดชีต

## **แผ่นงานแผนภูมิและสูตร**

แผ่นงานแผนภูมิประกอบด้วยหมวดหมู่, ชื่อซีรีส์, และค่าที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบแผ่นงานได้โดยเปิดตัวแก้ไขข้อมูลแผนภูมิ:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides แผ่นงานจะถูกเปิดเผยผ่าน[สมุดงานข้อมูลแผนภูมิ](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/)。ใช้คุณสมบัติ[Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/formula/)สำหรับสูตรแบบ A1 และคุณสมบัติ[R1C1Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/r1c1formula/)สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียก[CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)เพื่อคำนวณสูตรที่รองรับและอัปเดตค่าของเซลล์ที่เกี่ยวข้อง

เซลล์ที่คำนวณแล้วยังคงให้ผลลัพธ์ผ่านคุณสมบัติ[Value](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/value/) นี่สำคัญเมื่อคุณต้องการตรวจสอบผลของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในแผ่นงาน**

ตัวอย่างต่อไปนี้แสดงขั้นตอนทำงานครบวงจร มันสร้างแผนภูมิคอลัมน์แบบจัดกลุ่ม, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายรายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าของแผนภูมิ, และบันทึกงานนำเสนอ

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณได้ ไม่ต้องเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากในขั้นตอนนี้: คำนวณสมุดงานก่อน, แล้วจึงใช้หรือบันทึกข้อมูลแผนภูมิที่ชี้ไปยังเซลล์ที่คำนวณแล้ว

## **ใช้สูตรแบบ A1**

การอ้างอิงแบบ A1 ใช้ตัวอักษรระบุคอลัมน์และตัวเลขระบุแถว กำหนดนิพจน์แบบ A1 ผ่าน[IChartDataCell.Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/formula/)

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

รูปแบบการอ้างอิง A1 ที่พบบ่อยมีดังนี้

| การอ้างอิง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงสัมพัทธ์อาจเปลี่ยนเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปสเปรดชีต การอ้างอิงแน่นอนจะคงค่าพิกัดทั้งสองคงที่ ส่วนการอ้างอิงผสมจะคงแค่แถวหรือคอลัมน์หนึ่งเท่านั้น

## **ใช้สูตรแบบ R1C1**

การอ้างอิงแบบ R1C1 ระบุแถวและคอลัมน์เป็นตัวเลข การอ้างอิงสัมพัทธ์ใช้การออฟเซ็ตในวงเล็บเหลี่ยม กำหนดไวยากรณ์นี้ผ่าน[IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/r1c1formula/)

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

รูปแบบการอ้างอิง R1C1 ที่พบบ่อยมีดังนี้

| การอ้างอิง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

ตัวอย่างเช่น ในเซลล์ `D2` `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`)

## **ค่าคงที่และตัวดำเนินการของสูตร**

เครื่องมือประเมินสูตรในตัวสนับสนุนค่าตรรกะ, ตัวเลขลิเทรัล, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิเทรัล**

| ชนิด | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะเช่น `A2=TRUE` |
| ตัวเลข | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบทั่วไปและวิทยาศาสตร์ |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ลิเทรัลข้อความต้องอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจประเมินเป็นค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ |

ตัวอย่างต่อไปนี้ใช้ค่าคงที่หลายประเภท

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // เท็จ
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **ตัวดำเนินการคณิตศาสตร์**

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `+` | การบวกหรือเครื่องหมายบวกหน้า | `2+3` |
| `-` | การลบหรือเครื่องหมายลบหน้า | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อกำหนดลำดับการประเมินอย่างชัดเจน เช่น `(A2+B2)*C2`

### **ตัวดำเนินการเปรียบเทียบ**

นิพจน์เปรียบเทียบให้ค่าตรรกะกลับมา

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดล่วงหน้าที่รองรับ**

Aspose.Slides มีเครื่องประเมินสูตรในตัวสำหรับแผ่นงานแผนภูมิ แต่ไม่ใช่เอนจินคำนวณ Excel อย่างเต็มรูปแบบ ชุดฟังก์ชันที่ระบุไว้ในเอกสารมีดังต่อไปนี้ อย่าสันนิษฐานว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวณได้ด้วย[CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)

| ฟังก์ชัน | จุดประสงค์หรือรูปแบบที่รองรับ | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าตัวเลขเชิงบวก | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยคณิตศาสตร์ | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดขึ้นเป็นจำนวนเต็มหลายเท่า | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | รวมข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | รวมข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าค่าวันที่โดยใช้ระบบปี 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างสองวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งภายในอีกข้อความหนึ่ง | `FIND("-",A2)` |
| `FINDB` | การค้นหาข้อความแบบไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบการอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่าสูงสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวม | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดในตารางมีความสำคัญ: `INDEX` ถูกอธิบายในรูปแบบการอ้างอิง, ส่วน `LOOKUP` และ `MATCH` อยู่ในรูปแบบเวกเตอร์ `DATE` ใช้ระบบปี 1900 ฟังก์ชันหรือคุณลักษณะที่ไม่ได้ระบุไว้ที่นี่ควรถือว่าไม่รองรับโดยเครื่องประเมินสูตรของ Aspose.Slides เว้นแต่จะมีเอกสารแยกต่างหาก

## **คำนวณสูตรด้วยวัฒนธรรมที่ต้องการ**

บางฟังก์ชันของสมุดงานแผนภูมิตีความหมายตามกฎของวัฒนธรรม ซึ่งสำคัญอย่างยิ่งสำหรับฟังก์ชันที่ออกแบบมาสำหรับภาษาแบบใช้ชุดอักขระสองไบต์ (DBCS) เพื่อคำนวณสูตรเหล่านี้ให้ถูกต้อง สร้าง[LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/), ตั้งค่า[ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/th/net/aspose.slides/ispreadsheetoptions/preferredculture/)ผ่าน[LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/spreadsheetoptions/), แล้วโหลดงานนำเสนอ

ตัวอย่างต่อไปนี้เลือกวัฒนธรรมญี่ปุ่น, เปิดงานนำเสนอด้วย LoadOptions ที่กำหนดค่า, แล้วเรียก[IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)สำหรับสมุดงานแผนภูมิแต่ละรายการ

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

วัฒนธรรมที่ต้องการเป็นส่วนหนึ่งของการกำหนดค่าการโหลดงานนำเสนอ จึงต้องกำหนดก่อนสร้างอินสแตนซ์[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ใช้วัฒนธรรมที่สูตรสมุดงานคาดหวัง ตัวอย่างเช่นใช้ `ja-JP` สำหรับสูตรที่ต้องการกฎการคำนวณ DBCS ของญี่ปุ่น

## **การคำนวณซ้ำและค่าที่แคชไว้**

ไฟล์สเปรดชีตส่วนใหญ่จะเก็บสูตรและค่าที่คำนวณล่าสุดไว้ด้วย Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก[IChartDataCell.Value](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/value/)เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกแก้ไข

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าอ้างอิงผลลัพธ์ที่แคชเก่า ให้เรียก[IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่พึ่งพาเหล่านั้น

สำหรับสูตรที่อยู่นอกชุดที่รองรับ Aspose.Slides อาจไม่สามารถแยกสูตรหรือหาการพึ่งพาได้ หากสมุดงานได้รับการแก้ไข ค่าที่แคชไว้ก่อนหน้าอาจไม่เชื่อถือได้ ในกรณีนั้น การอ่านค่าของเซลล์ที่มีสูตรไม่รองรับอาจทำให้เกิด[CellUnsupportedDataException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

หากแผนภูมิของคุณต้องใช้ฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประเมิน ให้คำนวณสูตรเหล่านั้นด้วยเอนจินสเปรดชีตที่รองรับ แล้วเขียนค่าที่ได้กลับไปยังสมุดงานแผนภูมิ อย่าทดแทนสูตรที่ไม่รองรับด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นค่าข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเค็นข้อผิดพลาดเป็นผลของเซลล์และสามารถส่งคืนผ่าน `Value`

สูตรอาจล้มเหลวที่ขั้นตอนการแยก, การอ้างอิง, การพึ่งพา, หรือระดับข้อมูลที่รองรับ Aspose.Slides มีข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

เมื่อสูตรมาจากแม่แบบหรือการป้อนข้อมูลของผู้ใช้ ให้จับข้อยกเว้นเหล่านี้รอบการคำนวณซ้ำและการเข้าถึงค่า

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **ข้อจำกัดเชิงปฏิบัติ**

การสนับสนุนสูตรในแผ่นงานแผนภูมิมีเป้าหมายสำหรับชุดย่อยที่กำหนดของการคำนวณสเปรดชีต ไม่ได้มีความเข้ากันได้เต็มรูปแบบกับ Excel ให้คำนึงถึงข้อจำกัดเหล่านี้เมื่อออกแบบกระบวนการทำรายงาน:

- ใช้เพียงค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่ระบุในเอกสารเมื่อคุณต้องการให้ Aspose.Slides คำนวณสูตร
- คำนวณซ้ำหลังจากเปลี่ยนเซลล์ที่สูตรอิงถึง
- ถือค่าที่แคชจากงานนำเสนอที่โหลดเป็นภาพ snapshot ไม่ใช่การคำนวณทดแทนหลังจากแก้ไข
- ทดสอบสูตรจากแม่แบบที่มีอยู่ก่อนพึ่งพาผลลัพธ์ที่คำนวณได้, โดยเฉพาะอย่างยิ่งเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเอนจินคำนวณสเปรดชีตเต็มรูปแบบ, ให้คำนวณภายนอกแล้วอัปเดตสมุดงานแผนภูมิกับค่าที่ได้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง `Formula` กับ `R1C1Formula` คืออะไร?**

[Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/formula/) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ส่วน[R1C1Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/r1c1formula/) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ใช้รูปแบบที่ตรงกับวิธีการสร้างหรือคัดลอกสูตรของคุณ

**ฉันต้องอ่านเซลล์เองหรือค่า (`Value`) หลังการคำนวณหรือไม่?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/getcell/) คืนค่า `IChartDataCell` เพื่อให้ได้ผลลัพธ์ที่คำนวณแล้ว ให้อ่านคุณสมบัติ[Value](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/value/) หลังจากคำนวณซ้ำ

**ควรเรียก `CalculateFormulas` เมื่อใด?**

เรียก[CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)หลังจากเปลี่ยนค่าอินพุตหรือสูตรและก่อนที่คุณจะอ้างอิงผลลัพธ์ที่คำนวณ นี้จะอัปเดตค่าของสูตรที่เครื่องประเมินในตัวรองรับ

**Aspose.Slides รองรับฟังก์ชัน Excel ทุกอย่างหรือไม่?**

ไม่ เครื่องประเมินในตัวรองรับเพียงชุดฟังก์ชันที่ระบุในเอกสาร ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรสันนิษฐานว่าจะคำนวณได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบกับสูตร Excel ให้คำนวณด้วยเอนจินสเปรดชีตที่เหมาะสมแล้วเขียนค่าที่ได้ลงในสมุดงานแผนภูมิ

**หากงานนำเสนอที่โหลดมีสูตรที่ไม่รองรับจะเกิดอะไรขึ้น?**

หากข้อมูลแผนภูมิไม่มีการเปลี่ยนแปลง สมุดงานอาจยังคงมีค่าที่แคชไว้จากการคำนวณก่อนหน้า หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชนั้นอาจไม่ถูกต้องแล้ว การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด[CellUnsupportedDataException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรเท่ากับข้อยกเว้นของ .NET หรือไม่?**

ไม่ ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่เกิดจากการคำนวณที่ถูกต้อง ส่วนข้อยกเว้นเช่น[CellInvalidFormulaException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellinvalidformulaexception/)หรือ[CellCircularReferenceException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellcircularreferenceexception/)บ่งชี้ว่ารูปแบบสูตรไม่สามารถประมวลผลได้ตามปกติ

**แผนภูมิจะอัปเดตโดยอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ซีรีส์ของแผนภูมิสามารถอ้างอิงเซลล์ในสมุดงานได้ ให้คำนวณสมุดงานก่อน แล้วบันทึกหรือแสดงผลงานนำเสนอ หากจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัปเดตเหล่านั้น ไม่ต้องมีเมธอดรีเฟรชแผนภูมิแยกต่างหากในขั้นตอนนี้

**แผนภูมิสามารถใช้สมุดงาน Excel ภายนอกได้หรือไม่?**

ใช่ ข้อมูลแผนภูมิสามารถกำหนดให้ใช้สมุดงานภายนอกผ่าน API ของข้อมูลแผนภูมิได้ อย่างไรก็ตาม ขั้นตอนการคำนวณสูตรที่อธิบายในบทความนี้เกี่ยวข้องกับสมุดงานข้อมูลแผนภูมิและชุดสูตรที่ Aspose.Slides ประเมิน อย่าสันนิษฐานว่า[CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)ให้การคำนวณเต็มรูปแบบของสูตรใด ๆ ในไฟล์ XLSX ภายนอก

**ฉันสามารถใช้สูตรที่อ้างอิงแผ่นงานหรือสมุดงานอื่นได้หรือไม่?**

อ้างอิงสไตล์ Excel อาจมีในสมุดงานแผนภูมิ แต่การประเมินสูตรนั้นจำกัดโดยพาร์เซอร์และชุดฟังก์ชันที่รองรับ หากต้องการอ้างอิงข้ามแผ่นหรือไฟล์ภายนอกอย่างจำเป็น ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้ สำหรับกระบวนการที่ต้องการความเข้ากันได้กับการอ้างอิง Excel อย่างกว้าง ควรคำนวณสมุดงานภายนอกแล้วเขียนค่าที่แก้ไขแล้วกลับไปยังข้อมูลแผนภูมิ

**สูตรควรเริ่มด้วยเครื่องหมาย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มีเครื่องหมาย `=` การใช้รูปแบบนี้ทำให้สูตรที่สร้างตรงกับตัวอย่างในเวนต์ API ที่ระบุ**