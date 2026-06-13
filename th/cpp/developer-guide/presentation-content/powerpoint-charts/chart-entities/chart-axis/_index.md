---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอโดยใช้ С++
linktitle: แกนแผนภูมิ
type: docs
url: /th/cpp/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- ควบคุมแกน
- คุณสมบัตแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- С++
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ С++ เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแกนของแผนภูมิใน Aspose.Slides แสดงวิธีการรับค่าจากแกนจริง, สลับข้อมูลระหว่างแกน, ซ่อนแกนแนวตั้งหรือแนวนอนสำหรับแผนภูมิเส้น, เปลี่ยนประเภทของแกนประเภท, ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท, หมุนชื่อแกน, ตั้งค่าตำแหน่งแกน, และแสดงป้ายหน่วยบนแกนค่า

## **รับค่ามากที่สุดบนแกนแนวตั้ง**
Aspose.Slides for C++ ให้คุณรับค่าต่ำสุดและค่าสูงสุดบนแกนแนวตั้ง ปฏิบัติตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) class.
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิกับข้อมูลค่าเริ่มต้น
4. รับค่ามากที่สุดจริงบนแกน
5. รับค่าน้อยที่สุดจริงบนแกน
6. รับหน่วยหลักจริงของแกน
7. รับหน่วยรองจริงของแกน
8. รับสเกลของหน่วยหลักจริงของแกน
9. รับสเกลของหน่วยรองจริงของแกน

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// บันทึกงานนำเสนอ
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **สลับข้อมูลระหว่างแกน**
Aspose.Slides ให้คุณสลับข้อมูลระหว่างแกนได้อย่างรวดเร็ว — ข้อมูลที่แสดงบนแกนแนวตั้ง (y‑axis) จะย้ายไปยังแกนแนวนอน (x‑axis) และกลับกัน

โค้ด C++ นี้แสดงวิธีทำการสลับข้อมูลระหว่างแกนบนแผนภูมิ:

``` cpp
// สร้างงานนำเสนอเปล่า
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// สลับแถวและคอลัมน์
chart->get_ChartData()->SwitchRowColumn();

// บันทึกงานนำเสนอ
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

โค้ด C++ นี้แสดงวิธีซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **ปิดการแสดงแกนแนวนอนสำหรับแผนภูมิเส้น**

โค้ดนี้แสดงวิธีซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนแกนประเภท**

โดยใช้เมธอด **set_CategoryAxisType()** คุณสามารถกำหนดประเภทแกนประเภทที่ต้องการ (**date** หรือ **text**) โค้ด C++ ด้านล่างแสดงการดำเนินการนี้:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **ตั้งค่ารูปแบบวันที่สำหรับค่าแกนประเภท**
Aspose.Slides for C++ ให้คุณตั้งรูปแบบวันที่สำหรับค่าแกนประเภท การทำงานนี้แสดงในโค้ด C++ ต่อไปนี้:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **ตั้งค่ามุมการหมุนสำหรับชื่อแกน**
Aspose.Slides for C++ ให้คุณตั้งมุมการหมุนสำหรับชื่อแกนของแผนภูมิ โค้ด C++ นี้แสดงการดำเนินการ:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าตำแหน่งแกนบนแกนประเภทหรือค่า**
Aspose.Slides for C++ ให้คุณตั้งตำแหน่งแกนในแกนประเภทหรือค่า โค้ด C++ นี้แสดงวิธีทำงาน:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **เปิดใช้งานการแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ**
Aspose.Slides for C++ ให้คุณกำหนดค่าให้แผนภูมิแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ โค้ด C++ นี้แสดงการดำเนินการ:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันจะกำหนดค่าที่แกนหนึ่งตัดกับแกนอื่น (การตัดแกน) อย่างไร?**

แกนมี [crossing setting](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/axis/set_crosstype/) ให้คุณเลือกตัดที่ศูนย์, ที่ค่าประเภท/ค่ามากสุด, หรือที่ค่าตัวเลขเฉพาะ ซึ่งเป็นประโยชน์สำหรับการยกหรือวางแกน X ขึ้นหรือลง หรือเพื่อเน้นฐานเส้น

**ฉันจะตั้งค่าตำแหน่งป้ายเครื่องหมาย (tick label) ให้สัมพันธ์กับแกนอย่างไร (ข้างๆ, นอก, ใน)?**

ตั้งค่า [label position](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/axis/set_majortickmark/) เป็น "cross", "outside", หรือ "inside" การตั้งค่านี้ส่งผลต่อความอ่านง่ายและช่วยประหยัดพื้นที่ โดยเฉพาะบนแผนภูมิขนาดเล็ก