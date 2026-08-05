---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอด้วย C++
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
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ C++ เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผลข้อมูล"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนแผนภูมิใน Aspose.Slides โดยแสดงวิธีการรับค่าแกนจริง, สลับข้อมูลระหว่างแกน, ซ่อนแกนแนวตั้งหรือแนวนอนสำหรับแผนภูมิเส้น, เปลี่ยนประเภทของแกนประเภท, ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท, หมุนชื่อแกน, ตั้งตำแหน่งของแกน, และแสดงป้ายหน่วยบนแกนค่า

## **รับค่ามากสุดบนแกนแนวตั้ง**
Aspose.Slides for C++ ให้คุณรับค่าต่ำสุดและค่าสูงสุดบนแกนแนวตั้ง ไปตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
4. รับค่ามากสุดจริงบนแกน
5. รับค่าต่ำสุดจริงบนแกน
6. รับหน่วยหลักจริงของแกน
7. รับหน่วยรองจริงของแกน
8. รับสเกลหน่วยหลักจริงของแกน
9. รับสเกลหน่วยรองจริงของแกน

โค้ดตัวอย่างที่แสดงขั้นตอนด้านบนนี้บ่งบอกวิธีการรับค่าที่ต้องการใน C++:

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
Aspose.Slides ให้คุณสลับข้อมูลระหว่างแกนได้อย่างรวดเร็ว — ข้อมูลที่แสดงบนแกนแนวตั้ง (แกน y) จะย้ายไปยังแกนแนวนอน (แกน x) และกลับกัน

โค้ด C++ นี้แสดงวิธีการสลับข้อมูลระหว่างแกนบนแผนภูมิ:

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

## **ปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

โค้ด C++ นี้แสดงวิธีซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **ปิดการใช้งานแกนแนวนอนสำหรับแผนภูมิเส้น**

โค้ดนี้แสดงวิธีซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนแกนประเภท**

โดยใช้เมธอด **set_CategoryAxisType()** คุณสามารถระบุประเภทของแกนประเภทที่ต้องการ (**date** หรือ **text**) โค้ด C++ นี้แสดงการทำงาน:

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

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**
Aspose.Slides for C++ ให้คุณตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท การดำเนินการนี้แสดงในโค้ด C++ นี้:

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
Aspose.Slides for C++ ให้คุณตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ โค้ด C++ นี้แสดงการดำเนินการ:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **ตั้งตำแหน่งแกนบนแกนประเภทหรือแกนค่า**
Aspose.Slides for C++ ให้คุณตั้งตำแหน่งแกนในแกนประเภทหรือแกนค่า โค้ด C++ นี้แสดงวิธีทำงานดังกล่าว:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **เปิดใช้งานการแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ**
Aspose.Slides for C++ ให้คุณกำหนดค่าแผนภูมิเพื่อแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ โค้ด C++ นี้แสดงการดำเนินการ:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งตัดกับแกนอื่น (การตัดแกน) อย่างไร?**

แกนมีการตั้งค่า[การตัดแกน](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/axis/set_crosstype/) : คุณสามารถเลือกให้ตัดที่ศูนย์, ที่ค่าประเภท/ค่าสูงสุด, หรือที่ค่าตัวเลขเฉพาะ ซึ่งเป็นประโยชน์สำหรับการเลื่อนแกน X ไปขึ้นหรือลง หรือเพื่อเน้นเส้นฐาน

**ฉันจะวางตำแหน่งป้ายตีกรอบ (tick label) relativoกับแกน (ด้านข้าง, นอก, ใใน) อย่างไร?**

ตั้งค่า[ตำแหน่งป้าย](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/axis/set_majortickmark/)เป็น "cross", "outside", หรือ "inside" การตั้งค่านี้มีผลต่อความอ่านง่ายและช่วยประหยัดพื้นที่โดยเฉพาะบนแผนภูมิขนาดเล็ก