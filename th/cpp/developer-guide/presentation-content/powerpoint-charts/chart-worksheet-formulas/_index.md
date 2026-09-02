---
title: ใช้สูตรแผ่นงานแผนภูมิในงานนำเสนอด้วย C++
linktitle: สูตรแผ่นงาน
type: docs
weight: 70
url: /th/cpp/chart-worksheet-formulas/
keywords:
- สเปรดชีตแผนภูมิ
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
- ค่าคงที่เชิงตัวเลข
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันที่กำหนดล่วงหน้า
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ในแผ่นงานแผนภูมิของ Aspose.Slides สำหรับ C++, คำนวณค่าใหม่, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

แผนภูมิ PowerPoint ปกติเก็บข้อมูลต้นฉบับไว้ในแผ่นงานฝังตัว ใน Aspose.Slides for C++ คุณสามารถเข้าถึงแผ่นงานนั้นผ่าน workbook ของข้อมูลแผนภูมิ, เขียนค่าอินพุต, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่สนับสนุน, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลแผนภูมิได้

บทความนี้อธิบายกระบวนการทำสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลในแผ่นงาน, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณสูตรใหม่, อ่านค่าที่คำนวณได้, เชื่อมเซลล์เหล่านั้นกับซีรีส์ของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่สนับสนุน, ชุดฟังก์ชันในตัว, ค่าที่แคชไว้, สูตรที่ไม่สนับสนุน, และข้อผิดพลาดที่เฉพาะของสเปรดชีต

## **แผ่นงานชาร์ตและสูตร**

แผ่นงานชาร์ตประกอบด้วยประเภท, ชื่อซีรีส์, และค่าที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบแผ่นงานได้โดยเปิดตัวแก้ไขข้อมูลแผนภูมิ:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides แผ่นงานถูกเปิดเผยผ่านอินเทอร์เฟซ[IChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/) ใช้[IChartDataCell::set_Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_formula/) สำหรับสูตรแบบ A1 และ[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียก[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) เพื่อคำนวณสูตรที่สนับสนุนและอัปเดตค่าของเซลล์ที่สอดคล้องกัน

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่าน[IChartDataCell::get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/get_value/) สิ่งนี้สำคัญเมื่อคุณต้องการตรวจสอบผลลัพธ์สูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในแผ่นงาน**

ตัวอย่างต่อไปนี้แสดงกระบวนการทำงานตั้งแต่ต้นจนจบ มันสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าของแผนภูมิ, และบันทึกงานนำเสนอ

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

จุดข้อมูลของแผนภูมิเกี่ยวกับ `D2:D4` ดังนั้นแผนภูมิจะแสดงค่ากำไรที่คำนวณแล้ว ในขั้นตอนนี้ไม่มีการเรียกฟังก์ชันรีเฟรชแผนภูมิแยกออก: คำนวณ workbook ก่อน, แล้วใช้หรือบันทึกข้อมูลแผนภูมิที่อ้างอิงถึงเซลล์ที่คำนวณแล้ว

## **ใช้สูตรแบบ A1**

การระบุแบบ A1 ใช้อักษรเป็นคอลัมน์และตัวเลขเป็นแถว กำหนดนิพจน์แบบ A1 ผ่าน[IChartDataCell::set_Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_formula/)

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

รูปแบบการอ้างอ้างแบบ A1 ที่พบบ่อยคือ:

| การอ้างอ้าง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอ้างสัมพัทธ์อาจเปลี่ยนเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปพลิเคชันสเปรดชีต การอ้างอ้างแน่นอนจะคงค่าทั้งสองพิกัดคงที่ ส่วนการอ้างอ้างผสมจะคงแค่แถวหรือคอลัมน์อย่างใดอย่างหนึ่ง

## **ใช้สูตรแบบ R1C1**

การระบุแบบ R1C1 จะใช้ตัวเลขสำหรับทั้งแถวและคอลัมน์ การอ้างอ้างสัมพัทธ์ใช้การชี้ตำแหน่งในวงเล็บสี่เหลี่ยม กำหนดไวยากรณ์นี้ผ่าน[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/)

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

รูปแบบการอ้างอ้างแบบ R1C1 ที่พบบ่อยคือ:

| การอ้างอ้าง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

เช่น ในเซลล์ `D2` คำว่า `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันที่อยู่สองคอลัมน์ทางซ้าย (`B2`)

## **ค่าคงที่และตัวดำเนินการของสูตร**

เครื่องประเมินสูตรในตัวรองรับค่าตรรกะ, ตัวเลขลิตเตรัล, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิตเตรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะ เช่น `A2=TRUE` |
| ตัวเลข | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบทศนิยมและวิทยาศาสตร์ |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ลิตเตรัลข้อความต้องอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจให้ค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ |

ตัวอย่างนี้ใช้ค่าคงที่หลายประเภท:

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
| `+` | การบวกหรือเครื่องหมายบวกเอกเทศ | `2+3` |
| `-` | การลบหรือเครื่องหมายลบเอกเทศ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อทำให้ลำดับการประเมินชัดเจน เช่น `(A2+B2)*C2`

### **ตัวดำเนินการเปรียบเทียบ**

นิพจน์เปรียบเทียบให้ค่าแบบตรรกะ

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดล่วงหน้าและสนับสนุน**

Aspose.Slides มีเครื่องประเมินสูตรในตัวสำหรับแผ่นงานแผนภูมิ แต่ไม่ใช่เครื่องยนต์คำนวณ Excel เต็มรูปแบบ ชุดฟังก์ชันที่ระบุไว้จำกัดอยู่ในตารางด้านล่าง อย่าสันนิษฐานว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวณใหม่ได้โดย[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)

| ฟังก์ชัน | วัตถุประสงค์หรือรูปแบบที่สนับสนุน | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าตัวเลขเชิงสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยคณิตศาสตร์ | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดเศษขึ้นเป็นหลายเท่าที่กำหนด | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าโดยดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | เชื่อมข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | เชื่อมข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าที่เป็นวันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างสองวัน | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งภายในอีกข้อความหนึ่ง | `FIND("-",A2)` |
| `FINDB` | ค้นหาข้อความโดยอิงไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบการอ้างอ้าง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่ามากสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวมค่า | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดที่แสดงในตารางสำคัญ: `INDEX` ระบุในรูปแบบการอ้างอ้าง, ส่วน `LOOKUP` และ `MATCH` ระบุในรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ 1900 ฟังก์ชันที่ไม่ได้ระบุในที่นี้ควรถือว่าไม่สนับสนุนโดยเครื่องประเมินสูตรของ Aspose.Slides เว้นแต่จะมีเอกสารแยกต่างหาก

## **คำนวณสูตรด้วยวัฒนธรรมที่ต้องการ**

บางฟังก์ชันของ workbook แปลข้อความตามกฎเฉพาะวัฒนธรรม สิ่งนี้สำคัญอย่างยิ่งสำหรับฟังก์ชันที่ออกแบบมาสำหรับภาษาที่ใช้ชุดอักษรสองไบต์ (DBCS) เพื่อคำนวณสูตรเหล่านี้อย่างถูกต้อง ให้สร้าง[LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/), กำหนดค่า[ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/th/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) ผ่าน[LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), แล้วโหลดงานนำเสนอ

ตัวอย่างต่อไปนี้เลือกวัฒนธรรมญี่ปุ่น, เปิดงานนำเสนอด้วยตัวเลือกโหลดที่กำหนด, และเรียก[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) สำหรับทุก workbook ของแผนภูมิ

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

วัฒนธรรมที่ต้องการเป็นส่วนหนึ่งของการกำหนดค่าการโหลดงานนำเสนอ ดังนั้นต้องระบุก่อนสร้างอินสแตนซ์[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ใช้วัฒนธรรมที่สูตรของ workbook คาดหวัง; ตัวอย่างเช่นใช้ `ja-JP` สำหรับสูตรที่ควรปฏิบัติตามกฎการคำนวณ DBCS ของญี่ปุ่น

## **การคำนวณซ้ำและค่าที่แคชไว้**

ไฟล์สเปรดชีตมักจะเก็บสูตรพร้อมค่าที่คำนวณล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก[IChartDataCell::get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/get_value/) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกเปลี่ยน

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าอิงค่าที่แคชเก่า เรียก[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่ขึ้นอยู่กับค่าเหล่านั้น

สำหรับสูตรที่อยู่นอกชุดที่สนับสนุน Aspose.Slides อาจไม่สามารถแยกสูตรหรือหาความขึ้นต่อกันได้ หาก workbook ถูกแก้ไข ค่าที่แคชไว้ก่อนหน้านั้นจะไม่เชื่อถือได้ ในกรณีดังกล่าว การอ่านค่าของเซลล์ที่มีข้อมูลที่ไม่สนับสนุนอาจทำให้เกิด[CellUnsupportedDataException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)

หากแผนภูมิของคุณต้องพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประมวลผล ให้คำนวณสูตรเหล่านั้นด้วยเครื่องยนต์สเปรดชีตที่สนับสนุนและเขียนค่าที่ได้กลับไปยัง workbook ของแผนภูมิ อย่าแทนสูตรที่ไม่สนับสนุนด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นค่าข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ token ข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถคืนค่าผ่าน[IChartDataCell::get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/get_value/)

สูตรอาจล้มเหลวที่ขั้นตอนการแยก, การอ้างอิง, ความขึ้นต่อกัน, หรือระดับข้อมูลที่สนับสนุน Aspose.Slides มีข้อยกเว้นเฉพาะสเปรดชีตสำหรับสถานการณ์เหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)

เมื่อสูตรมาจากแม่แบบหรือผู้ใช้ ให้จัดการข้อยกเว้นเหล่านี้รอบการคำนวณซ้ำและการเข้าถึงค่า:

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
    // จัดการการอ้างอิงแบบวนลูป.
}
catch (CellUnsupportedDataException&)
{
    // จัดการข้อมูลสเปรดชีตที่ไม่สนับสนุน.
}
```

## **ข้อจำกัดเชิงปฏิบัติ**

การสนับสนุนสูตรในแผ่นงานแผนภูมิมีเป้าหมายสำหรับชุดย่อยที่กำหนดของการคำนวณสเปรดชีต ไม่ได้เพื่อความเข้ากันได้เต็มรูปแบบกับ Excel คำนึงถึงข้อจำกัดเหล่านี้เมื่อออกแบบการทำงานของรายงาน:

- ใช้เพียงค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่ระบุไว้เมื่อคุณต้องการให้ Aspose.Slides คำนวณสูตรใหม่
- คำนวณซ้ำหลังจากเปลี่ยนเซลล์ที่ผลลัพธ์สูตรพึ่งพา
- ถือค่าที่แคชจากงานนำเสนอที่โหลดเป็นภาพสแนปชอต ไม่ใช่ทดแทนการคำนวณใหม่หลังการแก้ไข
- ทดสอบสูตรจากแม่แบบที่มีอยู่ก่อนพึ่งพาค่าที่คำนวณได้, โดยเฉพาะอย่างยิ่งเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเครื่องยนต์คำนวณสเปรดชีตเต็มรูปแบบ ให้คำนวณภายนอกแล้วอัปเดตค่าใน workbook ของแผนภูมิ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง `set_Formula` กับ `set_R1C1Formula` คืออะไร?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_formula/) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ส่วน[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ใช้รูปแบบที่สอดคล้องกับวิธีการสร้างหรือคัดลอกสูตรของคุณ

**ต้องอ่านเซลล์เองหรือค่าในเซลล์หลังการคำนวณหรือไม่?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) คืนค่า `IChartDataCell` ให้ได้ผลลัพธ์ที่คำนวณแล้ว ให้เรียก[IChartDataCell::get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/get_value/) หลังการคำนวณ

**ควรเรียก `CalculateFormulas` เมื่อใด?**

เรียก[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) หลังจากเปลี่ยนค่าอินพุตหรือสูตรและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณแล้ว ซึ่งจะอัปเดตค่าของสูตรที่เครื่องประเมินในตัวสนับสนุน

**Aspose.Slides รองรับทุกฟังก์ชันของ Excel หรือไม่?**

ไม่. เครื่องประเมินในตัวรองรับชุดฟังก์ชันที่ระบุไว้เท่านั้น ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรสันนิษฐานว่าจะคำนวณได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบของสูตร Excel ให้ทำการคำนวณด้วยเครื่องยนต์สเปรดชีตที่เหมาะสมและเขียนค่าที่ได้ลงใน workbook ของแผนภูมิ

**จะเกิดอะไรขึ้นหากงานนำเสนอที่โหลดมีสูตรที่ไม่สนับสนุน?**

ถ้าข้อมูลแผนภูมิไม่ได้เปลี่ยน แบ่ง workbook อาจยังคงมีค่าที่แคชจากการคำนวณก่อนหน้า หลังจากที่ข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชนั้นอาจไม่ถูกต้อง การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด[CellUnsupportedDataException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรคือข้อยกเว้นของ C++ หรือไม่?**

ไม่. ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่มาจากการคำนวณที่ถูกต้อง ข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) บ่งบอกว่สูตรไม่สามารถประมวลผลตามปกติได้

**แผนภูมิจะอัพเดตอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ซีรีส์ของแผนภูมิสามารถอ้างอิงเซลล์ใน workbook ได้ คำนวณ workbook ก่อนแล้วบันทึกหรือเรนเดอร์งานนำเสนอ หากจุดข้อมูลของแผนภูมิเกี่ยวกับเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัพเดตเหล่านั้น; ไม่จำเป็นต้องมีเมธอดรีเฟรชแผนภูมิเพิ่มเติม

**แผนภูมิสามารถใช้ workbook ของ Excel ภายนอกได้หรือไม่?**

ได้, ข้อมูลแผนภูมิสามารถกำหนดให้ใช้ workbook ภายนอกผ่าน API ของข้อมูลแผนภูมิ อย่างไรก็ตาม กระบวนการคำนวณสูตรที่อธิบายในบทความนี้เกี่ยวกับ workbook ของแผนภูมิและชุดสูตรที่ Aspose.Slides ประเมินค่า อย่าสันนิษฐานว่า[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ให้การคำนวณเต็มรูปแบบของสูตรใด ๆ ในไฟล์ XLSX ภายนอก

**ฉันสามารถใช้สูตรที่อ้างอิงถึงแผ่นงานหรือ workbook อื่นได้หรือไม่?**

การอ้างอิงสไตล์ Excel อาจมีอยู่ใน workbook ของแผนภูมิ แต่การประเมินสูตรจำกัดโดยเครื่องแยกสูตรและชุดฟังก์ชันที่สนับสนุน หากการอ้างอิงข้ามแผ่นงานหรือไฟล์ภายนอกเป็นสิ่งจำเป็น ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้ สำหรับกระบวนการที่ต้องการความเข้ากันได้ของการอ้างอิง Excel อย่างกว้างขวาง ให้คำนวณ workbook ภายนอกแล้วเขียนค่าที่แก้ไขกลับไปยังข้อมูลแผนภูมิ

**สูตรควรเริ่มด้วยเครื่องหมาย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มีเครื่องหมาย `=` นำรูปแบบนั้นไปใช้ทำให้สูตรที่สร้างสอดคล้องกับตัวอย่าง API ที่ระบุไว้