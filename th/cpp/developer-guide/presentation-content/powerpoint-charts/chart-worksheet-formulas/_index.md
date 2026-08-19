---
title: ใช้สูตรเวิร์กชีตของแผนภูมิในงานนำเสนอด้วย C++
linktitle: สูตรเวิร์กชีต
type: docs
weight: 70
url: /th/cpp/chart-worksheet-formulas/
keywords:
- สเปรดชีตแผนภูมิ
- เวิร์กชีตแผนภูมิ
- สูตรแผนภูมิ
- สูตรเวิร์กชีต
- สูตรสเปรดชีต
- เวิร์กบุ๊กข้อมูลแผนภูมิ
- การคำนวณสูตร
- ค่าคงที่ตรรกะ
- ค่าคงที่เชิงตัวเลข
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- รูปแบบ A1
- รูปแบบ R1C1
- ฟังก์ชันที่กำหนดไว้ล่วงหน้า
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ใน Aspose.Slides สำหรับเวิร์กชีตแผนภูมิของ C++ คำนวณค่าใหม่ และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

แผนภูมิ PowerPoint โดยทั่วไปจะเก็บข้อมูลต้นฉบับไว้ในเวิร์กชีตที่ฝังอยู่ ใน Aspose.Slides สำหรับ C++ คุณสามารถเข้าถึงเวิร์กชีตนั้นผ่าน chart data workbook, เขียนค่าตัวแปรเข้า, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่รองรับ, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลของแผนภูมิได้

บทความนี้อธิบายขั้นตอนการทำงานของสูตรแบบครบวงจร: สร้างแผนภูมิ, เติมข้อมูลในเวิร์กชีต, กำหนดสูตรแบบ A1 หรือแบบ R1C1, คำนวณสูตรใหม่, อ่านค่าที่คำนวณแล้ว, เชื่อมเซลล์เหล่านั้นกับซีรีส์ของแผนภูมิ, และบันทึกการนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่รองรับ, ชุดฟังก์ชันในตัว, ค่าที่เก็บไว้ในแคช, สูตรที่ไม่รองรับ, และข้อผิดพลาดเฉพาะของสเปรดชีต

## **เวิร์กชีตและสูตรของแผนภูมิ**

เวิร์กชีตของแผนภูมิประกอบด้วยประเภท, ชื่อซีรีส์, และค่าที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบเวิร์กชีตได้โดยเปิด chart data editor:

![แผนภูมิ PowerPoint พร้อมเวิร์กชีตที่ฝังอยู่เปิดอยู่ แสดงข้อมูลประเภทและซีรีส์](chart-worksheet-formulas_1.png)

ใน Aspose.Slides, เวิร์กชีตถูกเปิดเผยผ่านอินเทอร์เฟซ [IChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/) ใช้ [IChartDataCell::set_Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_formula/) สำหรับสูตรแบบ A1 และ [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียก [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) เพื่อคำนวณสูตรที่รองรับและอัปเดตค่าของเซลล์ที่เกี่ยวข้อง

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่าน [IChartDataCell::get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/get_value/) สิ่งนี้สำคัญเมื่อคุณต้องการตรวจสอบผลลัพธ์ของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในเวิร์กชีต**

ตัวอย่างต่อไปนี้สาธิตกระบวนการทำงานตั้งแต่ต้นจนจบ โดยสร้างแผนภูมิคอลัมน์แบบกลุ่ม, ลบข้อมูลตัวอย่าง, เขียนค่า รายได้และค่าใช้จ่ายรายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าของแผนภูมิ, และบันทึกการนำเสนอ

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณแล้ว ไม่มีการเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากในกระบวนการนี้: คำนวณเวิร์กบุ๊คก่อน แล้วจึงใช้หรือบันทึกข้อมูลแผนภูมิที่ชี้ไปยังเซลล์ที่คำนวณแล้ว

## **ใช้สูตรแบบ A1**

การอ้างอิงแบบ A1 ใช้ตัวอักษรระบุคอลัมน์และตัวเลขระบุแถว กำหนดนิพจน์แบบ A1 ผ่าน [IChartDataCell::set_Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_formula/)

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

รูปแบบการอ้างอิง A1 ที่พบบ่อยมีดังนี้:

| อ้างอิง | สัมพัทธ์ | คงที่ | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงแบบสัมพัทธ์อาจเปลี่ยนแปลงเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปสเปรดชีต ส่วนการอ้างอิงแบบคงที่จะคงค่าพิกัดทั้งสองไว้คงที่ ส่วนการอ้างอิงแบบผสมจะคงแถวหรือคอลัมน์อย่างใดอย่างหนึ่งเท่านั้น

## **ใช้สูตรแบบ R1C1**

การอ้างอิงแบบ R1C1 ใช้ตัวเลขระบุทั้งแถวและคอลัมน์ การอ้างอิงแบบสัมพัทธ์ใช้การเบี่ยงเบนในวงเล็บเหลี่ยม กำหนดไวยากรณ์นี้ผ่าน [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/)

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

รูปแบบการอ้างอิง R1C1 ที่พบบ่อยมีดังนี้:

| อ้างอิง | สัมพัทธ์ | คงที่ | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

ตัวอย่างเช่น ในเซลล์ `D2` คำว่า `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันที่สองคอลัมน์ทางซ้าย (`B2`)

## **ค่าคงที่และตัวดำเนินการของสูตร**

ตัวประเมินสูตรในตัวรองรับค่าตรรกะ, ตัวลิเทรัลเชิงตัวเลข, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิเทรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะ เช่น `A2=TRUE` |
| ตัวเลข | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบปกติและวิทยาศาสตร์ |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ลิเทรัลข้อความจะอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจประเมินเป็นค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ |

ตัวอย่างต่อไปนี้ใช้ค่าคงที่หลายประเภท:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // เท็จ
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **ตัวดำเนินการคณิตศาสตร์**

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `+` | การบวกหรือเครื่องหมายบวกเอกพจน์ | `2+3` |
| `-` | การลบหรือการทำลบเอกพจน์ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อบ่งบอกลำดับการประเมิน เช่น `(A2+B2)*C2`

### **ตัวดำเนินการเปรียบเทียบ**

นิพจน์เปรียบเทียบจะคืนค่าเป็นค่าตรรกะ

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดไว้ล่วงหน้าและรองรับ**

Aspose.Slides มีตัวประเมินสูตรในตัวสำหรับเวิร์กชีตของแผนภูมิ แต่ไม่ใช่เครื่องยนต์คำนวณ Excel อย่างเต็มรูปแบบ ชุดฟังก์ชันที่ระบุไว้จำกัดอยู่ที่ฟังก์ชันต่อไปนี้ อย่าหัดสันนิษฐานว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวณใหม่ได้โดย [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)

| ฟังก์ชัน | จุดประสงค์หรือรูปแบบที่รองรับ | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยเลขคณิต | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดขึ้นเป็นจำนวนเต็มที่เป็นผลคูณ | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | เชื่อมข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | เชื่อมข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่า วันที่โดยใช้ระบบปี 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งภายในอีกข้อความหนึ่ง | `FIND("-",A2)` |
| `FINDB` | การค้นหาข้อความแบบไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่ามากที่สุด | `MAX(B2:B5)` |
| `SUM` | ผลรวม | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดในตารางมีความสำคัญ: `INDEX` ระบุในรูปแบบอ้างอิง, ส่วน `LOOKUP` และ `MATCH` ระบุในรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ปี 1900 ฟีเจอร์และฟังก์ชันที่ไม่ได้ระบุที่นี่ควรถือว่าไม่รองรับโดยตัวประเมินสูตรของ Aspose.Slides เว้นแต่จะมีการระบุเป็นพิเศษ

## **การคำนวณใหม่และค่าที่เก็บในแคช**

ไฟล์สเปรดชีตทั่วไปมักเก็บทั้งสูตรและค่าที่คำนวณล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่เก็บในแคชจาก [IChartDataCell::get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/get_value/) เมื่อนำเสนอถูกโหลดและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกเปลี่ยนแปลง

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าอ้างอิงผลลัพธ์แคชเก่า ให้เรียก [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่พึ่งพาค่านั้น

สำหรับสูตรที่อยู่นอกชุดที่รองรับ Aspose.Slides อาจไม่สามารถแยกวิเคราะห์สูตรหรือหาความขึ้นต่อกันได้ หากเวิร์กบุ๊กถูกแก้ไข ค่าที่แคชไว้ก่อนหน้านี้จะไม่สามารถเชื่อถือได้อีกแล้ว ในสถานการณ์นั้น การอ่านค่าของเซลล์ที่มีข้อมูลไม่รองรับอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)

หากแผนภูมิของคุณพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประเมิน ให้คำนวณสูตรเหล่านั้นด้วยเครื่องมือสเปรดชีตที่รองรับแล้วเขียนค่าที่ได้กลับไปยังเวิร์กบุ๊กของแผนภูมิ อย่าแทนที่สูตรที่ไม่รองรับด้วยค่าที่คาดเดา

## **จัดการกับข้อผิดพลาดของสูตร**

มีปัญหาสองประเภทที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเคนข้อผิดพลาดถือเป็นผลลัพธ์ของเซลล์และสามารถคืนค่าผ่าน [IChartDataCell::get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/get_value/)

สูตรอาจล้มเหลวที่ระดับการแยกวิเคราะห์, การอ้างอิง, การพึ่งพา, หรือระดับข้อมูลที่รองรับ Aspose.Slides มีข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรืออินพุตของผู้ใช้ ให้จัดการข้อยกเว้นเหล่านี้รอบการคำนวณใหม่และการเข้าถึงค่า:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // จัดการสูตรที่ไม่ถูกต้อง.
}
catch (CellInvalidReferenceException&)
{
    // จัดการการอ้างอิงเซลล์ที่ไม่ถูกต้อง.
}
catch (CellCircularReferenceException&)
{
    // จัดการการอ้างอิงวงกลม.
}
catch (CellUnsupportedDataException&)
{
    // จัดการข้อมูลสเปรดชีตที่ไม่รองรับ.
}
```

## **ข้อจำกัดเชิงปฏิบัติ**

การสนับสนุนสูตรในเวิร์กชีตของแผนภูมิมุ่งเน้นที่ชุดย่อยที่กำหนดไว้ของการคำนวณสเปรดชีต ไม่ได้เพื่อความเข้ากันได้เต็มรูปแบบกับ Excel ควรคำนึงถึงข้อจำกัดเหล่านี้เมื่อตั้งค่ากระบวนการรายงาน:

- ใช้ค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่ระบุในเอกสารเท่านั้นเมื่อคุณต้องการให้ Aspose.Slides คำนวณสูตรใหม่
- คำนวณใหม่หลังจากเปลี่ยนเซลล์ที่ผลลัพธ์สูตรอ้างอิง
- ถือค่าที่แคชจากการนำเสนอที่โหลดเป็นภาพนิ่ง ไม่ใช่การแทนที่การคำนวณใหม่หลังการแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนนำค่าที่คำนวณไปใช้ โดยเฉพาะเมื่อสูตรใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเครื่องยนต์คำนวณสเปรดชีตเต็มรูปแบบ ให้คำนวณภายนอกแล้วอัปเดตค่าในเวิร์กบุ๊กของแผนภูมิ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง `set_Formula` และ `set_R1C1Formula` คืออะไร?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_formula/) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ส่วน [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ใช้รูปแบบที่สอดคล้องกับวิธีที่คุณสร้างหรือคัดลอกสูตร

**ฉันต้องอ่านค่าเซลล์เองหรือค่าในเซลล์หลังการคำนวณหรือไม่?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) คืนค่า `IChartDataCell` เพื่อรับผลลัพธ์ที่คำนวณแล้ว ให้เรียกค่า [IChartDataCell::get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/get_value/) หลังการคำนวณ

**ควรเรียก `CalculateFormulas` เมื่อใด?**

เรียก [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) หลังจากเปลี่ยนค่าอินพุตหรือสูตรและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณ ตัวเมธอดนี้จะอัปเดตค่าของสูตรที่ตัวประเมินในตัวรองรับ

**Aspose.Slides รองรับทุกฟังก์ชันของ Excel หรือไม่?**

ไม่ ตัวประเมินในตัวรองรับเพียงชุดฟังก์ชันที่ระบุไว้เท่านั้น ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรสันนิษฐานว่าจะคำนวณได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบกับสูตร Excel ให้ทำการคำนวณด้วยเครื่องมือสเปรดชีตที่เหมาะสมและเขียนค่าที่ได้ลงในเวิร์กบุ๊กของแผนภูมิ

**จะเกิดอะไรขึ้นหากการนำเสนอที่โหลดมามีสูตรที่ไม่รองรับ?**

หากข้อมูลแผนภูมิไม่ได้ถูกเปลี่ยน ค่าที่แคชในเวิร์กบุ๊กอาจยังคงอยู่ หลังจากที่ข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชอาจไม่ถูกต้องอีกต่อไป การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรเหมือนกับข้อยกเว้นของ C++ หรือไม่?**

ไม่ ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่เกิดจากการคำนวณที่ถูกต้อง ข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) บ่งบอกว่าระบบไม่สามารถประมวลผลสูตรได้ตามปกติ

**แผนภูมิจะอัปเดตโดยอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ซีรีส์ของแผนภูมิสามารถอ้างอิงเซลล์ในเวิร์กบุ๊กได้ ให้คำนวณเวิร์กบุ๊กก่อน แล้วบันทึกหรือเรนเดอร์การนำเสนอ หากจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัปเดตนั้นโดยไม่ต้องมีเมธอดรีเฟรชแยกต่างหาก

**แผนภูมิสามารถใช้เวิร์กบุ๊ก Excel ภายนอกได้หรือไม่?**

ได้ สามารถกำหนดให้ข้อมูลแผนภูมิใช้เวิร์กบุ๊กภายนอกผ่าน API ของข้อมูลแผนภูมิ อย่างไรก็ตาม กระบวนการคำนวณสูตรที่อธิบายในบทความนี้เกี่ยวข้องกับเวิร์กบุ๊กข้อมูลแผนภูมิและชุดสูตรที่ Aspose.Slides ประเมิน อย่าเชื่อว่า [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ให้การคำนวณเต็มรูปแบบของสูตรใด ๆ ในไฟล์ XLSX ภายนอก

**ฉันสามารถใช้สูตรที่อ้างอิงเวิร์กชีตหรือเวิร์กบุ๊กอื่นได้หรือไม่?**

การอ้างอิงสไตล์ Excel อาจปรากฏในเวิร์กบุ๊กของแผนภูมิ แต่การประเมินสูตรถูกจำกัดด้วยตัวแยกวิเคราะห์และชุดฟังก์ชันที่รองรับ หากต้องอ้างอิงข้ามชีตหรือไฟล์ภายนอกที่สำคัญ ควรตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้ สำหรับกระบวนการที่ต้องการความเข้ากันได้ของการอ้างอิง Excel อย่างกว้าง ควรคำนวนเวิร์กบุ๊กภายนอกแล้วเขียนค่าที่แก้ไขกลับไปยังข้อมูลแผนภูมิ

**สูตรต้องเริ่มด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มีเครื่องหมาย `=` นำหน้าการใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคลับกับตัวอย่างในเอกสาร API