---
title: ใช้สูตร Worksheet ของแผนภูมิในงานนำเสนอด้วย .NET
linktitle: สูตร Worksheet
type: docs
weight: 70
url: /th/net/chart-worksheet-formulas/
keywords:
- แผนภูมิ สเปรดชีต
- แผ่นงานแผนภูมิ
- สูตรแผนภูมิ
- สูตรแผ่นงาน
- สูตรสเปรดชีต
- workbook ข้อมูลแผนภูมิ
- การคำนวนสูตร
- คอนสแตนต์ตรรกะ
- คอนสแตนต์เชิงตัวเลข
- คอนสแตนต์สตริง
- คอนสแตนต์ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันที่กำหนดไว้ล่วงหน้า
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ใน Aspose.Slides สำหรับแผ่นงานแผนภูมิ .NET, คำนวนค่าใหม่, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

แผนภูมิ PowerPoint โดยทั่วไปจะเก็บข้อมูลต้นทางไว้ในเวิร์กชีตแบบฝังตัว ใน Aspose.Slides สำหรับ .NET คุณสามารถเข้าถึงเวิร์กชีตนั้นผ่าน chart data workbook เขียนค่าข้อมูลเข้า กำหนดสูตรให้กับเซลล์ คำนวณสูตรที่สนับสนุน และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลของแผนภูมิ

บทความนี้อธิบายขั้นตอนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ เติมข้อมูลในเวิร์กชีต กำหนดสูตรแบบ A1‑style หรือ R1C1‑style คำนวนสูตรใหม่ อ่านค่าที่คำนวนแล้ว เชื่อมเซลล์เหล่านั้นกับชุดข้อมูลของแผนภูมิ และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่สนับสนุน ชุดฟังก์ชันในตัว ค่าที่แคชไว้ สูตรที่ไม่สนับสนุนและข้อผิดพลาดเฉพาะสเปรดชีต

## **เวิร์กชีตและสูตรของแผนภูมิ**

เวิร์กชีตของแผนภูมิประกอบด้วยประเภท แถวชื่อชุดข้อมูล และค่าที่แผนภูมิต้องการ ใน PowerPoint คุณสามารถตรวจสอบเวิร์กชีตได้โดยเปิด chart data editor:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides เวิร์กชีตถูกเปิดเผยผ่าน [chart data workbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/)。ใช้คุณสมบัติ [Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/formula/) สำหรับสูตรแบบ A1‑style และคุณสมบัติ [R1C1Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/r1c1formula/) สำหรับสูตรแบบ R1C1‑style หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียกใช้ [CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) เพื่อคำนวณสูตรที่สนับสนุนและอัปเดตค่าของเซลล์ที่สอดคล้องกัน

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่านคุณสมบัติ [Value](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/value/) นี่สำคัญเมื่อคุณต้องตรวจสอบผลลัพธ์ของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในเวิร์กชีต**

ตัวอย่างต่อไปนี้แสดงกระบวนการทำงานแบบจากต้นจนจบ มันสร้างแผนภูมิคอลัมน์แบบ clustered ล้างข้อมูลตัวอย่าง เขียนค่ารายได้และค่าใช้จ่ายรายไตรมาส คำนวนกำไรด้วยสูตร อ่านผลลัพธ์ ใช้เซลล์ที่คำนวนแล้วเป็นค่าของแผนภูมิ และบันทึกงานนำเสนอ

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

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิใช้ค่ากำไรที่คำนวนแล้ว ไม่ต้องเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากในกระบวนการนี้: คำนวนเวิร์กชีตก่อน แล้วจึงใช้หรือบันทึกข้อมูลแผนภูมิที่ชี้ไปยังเซลล์ที่คำนวนแล้ว

## **ใช้สูตรแบบ A1‑Style**

การเขียนแบบ A1 ระบุคอลัมน์ด้วยตัวอักษรและแถวด้วยตัวเลข กำหนดนิพจน์แบบ A1 ผ่าน [IChartDataCell.Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/formula/)  

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

รูปแบบการอ้างอิงแบบ A1 ที่พบบ่อยคือ:

| อ้างอิง | สัมพัทธ์ | เชิงอัตตา | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงสัมพัทธ์อาจเปลี่ยนเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปพลิเคชันสเปรดชีต การอ้างอิงเชิงอัตตาจะคงพิกัดทั้งสองคงที่ ส่วนการอ้างอิงผสมจะคงแค่แถวหรือคอลัมน์หนึ่งเท่านั้น

## **ใช้สูตรแบบ R1C1‑Style**

การเขียนแบบ R1C1 ระบุทั้งแถวและคอลัมน์เป็นตัวเลข การอ้างอิงสัมพัทธ์ใช้การเลื่อนในวงเล็บเหลี่ยม กำหนดไวยากรณ์นี้ผ่าน [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/r1c1formula/)  

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

รูปแบบการอ้างอิงแบบ R1C1 ที่พบบ่อยคือ:

| อ้างอิง | สัมพัทธ์ | เชิงอัตตา | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

เช่น ในเซลล์ `D2` คำว่า `RC[-2]` หมายถึงเซลล์ที่อยู่ในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`)

## **คอนสแตนต์และตัวดำเนินการของสูตร**

เครื่องประเมินสูตรในตัวสนับสนุนค่าตรรกะ, ลิตเทรัลเชิงตัวเลข, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์และตัวดำเนินการเปรียบเทียบ

### **คอนสแตนต์และลิตเทรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะ เช่น `A2=TRUE` |
| จำนวน | `1`, `0.5`, `.3`, `1E-2` | รองรับรูปแบบทั่วไปและรูปแบบวิทยาศาสตร์ |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ลิตเทรัลข้อความต้องอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจประเมินเป็นค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ |

ตัวอย่างนี้ใช้คอนสแตนต์หลายประเภท:

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
| `+` | การบวกหรือบวกเชิงเอกภาพ | `2+3` |
| `-` | การลบหรือการลบเชิงเอกภาพ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อกำหนดลำดับการประเมินอย่างชัดเจน เช่น `(A2+B2)*C2`

### **ตัวดำเนินการเปรียบเทียบ**

นิพจน์เปรียบเทียบจะคืนค่าตรรกะ

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดไว้ล่วงหน้าที่รองรับ**

Aspose.Slides มีเครื่องประเมินสูตรในตัวสำหรับเวิร์กชีตของแผนภูมิ แต่ไม่ได้เป็นเอนจินคำนวน Excel เต็มรูปแบบ ชุดฟังก์ชันที่เอกสารอ้างอิงมีเพียงฟังก์ชันต่อไปนี้ ไม่ควรสันนิษฐานว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวนใหม่ด้วย [CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ได้

| ฟังก์ชัน | วัตถุประสงค์หรือรูปแบบที่รองรับ | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าต absoluto | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยเลขคณิต | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดขึ้นเป็นหลายเท่า | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | รวมข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | รวมข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าที่เป็นวันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งในอีกข้อความ | `FIND("-",A2)` |
| `FINDB` | ค้นหาข้อความแบบไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบการอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่าสูงสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวม | `SUM(B2:B5)` |
| `VLOOKUP` | ค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดที่แสดงในตารางมีนัยสำคัญ: `INDEX` ระบุในรูปแบบการอ้างอิง ส่วน `LOOKUP` และ `MATCH` ระบุในรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ 1900 ฟังก์ชันและคุณลักษณะที่ไม่ได้ระบุในที่นี้ควรถือว่าไม่รองรับโดยเครื่องประเมินสูตรของ Aspose.Slides เว้นแต่จะมีเอกสารแยกต่างหาก

## **การคำนวนใหม่และค่าที่แคชไว้**

ไฟล์สเปรดชีตมักจะเก็บทั้งสูตรและค่าที่คำนวนล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [IChartDataCell.Value](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/value/) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิที่เกี่ยวข้องยังไม่ได้เปลี่ยน

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าอ้างอิงผลลัพธ์ที่แคชเก่า ให้เรียก [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ก่อนอ่านค่าที่คำนวนหรือบันทึกข้อมูลแผนภูมิที่ขึ้นกับค่านั้น

สำหรับสูตรที่อยู่นอกชุดที่สนับสนุน Aspose.Slides อาจไม่สามารถพาร์สสูตรหรือกำหนดการพึ่งพาได้ หากเวิร์กชีตถูกแก้ไข ค่าที่แคชไว้เดิมจะไม่ถือว่าเชื่อถือได้ ในสถานการณ์นั้น การอ่านค่าของเซลล์ที่มีข้อมูลไม่สนับสนุนอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

หากแผนภูมิของคุณพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประเมิน ให้คำนวนสูตรเหล่านั้นด้วยเอนจินสเปรดชีตที่สนับสนุนและเขียนค่าที่ได้กลับไปยัง chart workbook อย่าทดแทนสูตรที่ไม่สนับสนุนด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นค่าข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเค็นข้อผิดพลาดคือผลลัพธ์ของเซลล์และสามารถคืนค่าผ่าน `Value` ได้

สูตรอาจล้มเหลวที่ระดับการพาร์ส, การอ้างอิง, การพึ่งพา หรือระดับข้อมูลที่สนับสนุน Aspose.Slides มีข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรือการป้อนข้อมูลโดยผู้ใช้ ให้จัดการข้อยกเว้นเหล่านี้รอบการคำนวนใหม่และการเข้าถึงค่า:

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

การสนับสนุนสูตรในเวิร์กชีตของแผนภูมิมีเจตนาจำกัดไว้สำหรับชุดย่อยของการคำนวนสเปรดชีต ไม่ใช่การเข้ากันได้เต็มรูปแบบกับ Excel คำนึงถึงข้อจำกัดเหล่านี้เมื่อนำไปใช้ในกระบวนการรายงาน:

- ใช้เฉพาะคอนสแตนต์, ตัวดำเนินการ, การอ้างอิงและฟังก์ชันที่ระบุในเอกสารเมื่อคุณต้องการให้ Aspose.Slides คำนวนสูตรใหม่
- คำนวนใหม่หลังจากเปลี่ยนเซลล์ที่สูตรอิงถึง
- ให้ถือว่าค่าแคชจากงานนำเสนอที่โหลดเป็นภาพสแนปช็อต ไม่ใช่การทดแทนการคำนวนใหม่หลังแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาค่าที่คำนวนแล้ว โดยเฉพาะอย่างยิ่งเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเอนจินคำนวนสเปรดชีตเต็มรูปแบบ ให้คำนวนสูตรนั้นภายนอกแล้วอัปเดตค่าใน chart workbook

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง `Formula` กับ `R1C1Formula` คืออะไร?**

[Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/formula/) เก็บนิพจน์แบบ A1‑style เช่น `B2-C2` ส่วน [R1C1Formula](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/r1c1formula/) เก็บนิพจน์แบบ R1C1‑style เช่น `RC[-2]-RC[-1]` ใช้รูปแบบที่ตรงกับวิธีที่คุณสร้างหรือคัดลอกสูตร

**หลังการคำนวนแล้ว ฉันต้องอ่านเซลล์เองหรือค่า (`Value`) ของมัน?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/getcell/) คืนค่า `IChartDataCell` เพื่อนำผลลัพธ์ที่คำนวนแล้วให้อ่านคุณสมบัติ [Value](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/value/) ของเซลล์นั้นหลังการคำนวนใหม่

**ควรเรียก `CalculateFormulas` เมื่อใด?**

เรียก [CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) หลังจากเปลี่ยนค่าข้อมูลเข้าหรือสูตรและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวน นี่จะอัปเดตค่าของสูตรที่เครื่องประเมินในตัวรองรับ

**Aspose.Slides รองรับฟังก์ชัน Excel ทุกตัวหรือไม่?**

ไม่ เครื่องประเมินในตัวรองรับเพียงชุดฟังก์ชันที่ระบุไว้ในเอกสาร ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรสันนิษฐานว่าจะคำนวนได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบของสูตร Excel ให้ใช้เอนจินสเปรดชีตที่เหมาะสมแล้วเขียนค่าผลลัพธ์สุดท้ายไปยัง chart workbook

**ถ้างานนำเสนอที่โหลดมามีสูตรที่ไม่สนับสนุนจะเกิดอะไรขึ้น?**

หากข้อมูลแผนภูมิไม่ได้เปลี่ยน ค่าแคชที่คำนวนไว้ก่อนหน้าอาจยังคงอยู่ หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าแคชอาจไม่ถูกต้องอีกต่อไป การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรเป็นเช่นเดียวกับข้อยกเว้นของ .NET หรือไม่?**

ไม่ ค่าผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่ได้จากการคำนวนที่ถูกต้อง ส่วนข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) แสดงว่าระบบไม่สามารถประมวลผลสูตรได้ตามปกติ

**แผนภูมิจะอัปเดตโดยอัตโนมัติเมื่อสูตรในเซลล์เปลี่ยนหรือไม่?**

ชุดข้อมูลของแผนภูมิสามารถอ้างอิงเซลล์ในเวิร์กชีตได้ ให้คำนวนเวิร์กชีตก่อน จากนั้นบันทึกหรือเรนเดอร์งานนำเสนอ ถ้าจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวนแล้ว แผนภูมิจะใช้ค่าที่อัปเดตนั้นโดยไม่ต้องเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหาก

**แผนภูมิสามารถใช้เวิร์กบุ๊ก Excel ภายนอกได้หรือไม่?**

ได้ ข้อมูลแผนภูมิสามารถกำหนดให้ใช้เวิร์กบุ๊กภายนอกผ่าน API ของ chart data อย่างไรก็ตาม ขั้นตอนการคำนวนสูตรที่อธิบายในบทความนี้เกี่ยวกับ chart data workbook และชุดสูตรที่ Aspose.Slides ประเมิน ไม่ควรสันนิษฐานว่า [CalculateFormulas](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ให้การคำนวนเต็มรูปแบบของสูตรใด ๆ ในไฟล์ XLSX ภายนอก

**ฉันสามารถใช้สูตรที่อ้างอิงเวิร์กชีตหรือเวิร์กบุ๊กอื่นได้หรือไม่?**

การอ้างอิงสไตล์ Excel อาจปรากฏใน chart workbook แต่การประเมินสูตรจะจำกัดโดยพาร์สเซอร์และชุดฟังก์ชันที่สนับสนุน หากการอ้างอิงข้ามชีตหรือภายนอกเป็นสิ่งจำเป็น ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้ สำหรับกระบวนการที่ต้องการความเข้ากันได้ของการอ้างอิง Excel อย่างกว้าง คำนวนเวิร์กบุ๊กภายนอกแล้วเขียนค่าที่แก้ไขแล้วกลับไปยังข้อมูลแผนภูมิ

**สูตรควรเริ่มด้วยเครื่องหมาย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มีเครื่องหมาย `=` นำรูปแบบนั้นไปใช้จะทำให้สูตรที่สร้างสอดคลากับตัวอย่าง API ที่ระบุ**