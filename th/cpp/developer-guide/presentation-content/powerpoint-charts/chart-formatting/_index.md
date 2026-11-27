---
title: จัดรูปแบบแผนภูมิการนำเสนอใน C++
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/cpp/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- เอนทิตี้แผนภูมิ
- คุณสมบัติแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติแบบอักษร
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ C++ และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง แบบอักษร รูปแบบตัวเลข และขอบแผนภูมิที่โค้ง"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides. มันแสดงวิธีปรับแต่งองค์ประกอบหลักของแผนภูมิเช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่แผนภูมิ, และการเติมสีผนังเพื่อปรับปรุงลักษณะและความอ่านง่ายของข้อมูลแผนภูมิ.

มันยังแสดงวิธีตั้งค่าคุณสมบัติตัวอักษรสำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขตั้งล่วงหน้ากับข้อมูลแผนภูมิ, และเปิดใช้มุมโค้งสำหรับพื้นที่แผนภูมิ. ตัวอย่างเหล่านี้แสดงวิธีควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ.

สำหรับการเติมสีและขอบแยกต่างหากสำหรับช่วงที่เพิ่มขึ้นและลดลง, ดู[ตัวอย่างแผนภูมิหุ้น](/slides/th/cpp/create-chart/#create-stock-charts).

## **จัดรูปแบบเอนทิตี้ของแผนภูมิ**

ใช้[IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/)เพื่อจัดรูปแบบชื่อแผนภูมิ, แกน, เส้นกริด, คำอธิบาย, และพื้นที่แผนภูมิ. ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมเครื่องหมายและข้อมูลเริ่มต้น, จากนั้นนำสไตล์ข้อความและเส้นแยกต่างหากไปใช้กับแกนค่และแกนหมวดหมู่ของมัน. ขนาดตัวอักษรและความกว้างของเส้นระบุเป็นจุด; ป้ายชื่อหมวดหมู่ถูกหมุน 45 องศา.

แกนค่าใช้[get_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_numberformat/)อย่างอิสระจากเซลล์ต้นฉบับ. สเกลของมันเริ่มจาก -2 ถึง 15, โดยช่วงหลักที่ 2 และช่วงย่อยที่ 0.5. ตัวอย่างนี้ยังรวมการจัดรูปแบบเป็นเปอร์เซ็นต์กับ[get_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_displayunit/)ที่ตั้งเป็นพัน, ดังนั้นให้ปรับการตั้งค่าเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ. คำอธิบายอยู่ด้านนอกพื้นที่แผนภูมิเนื่องจาก[get_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegend/get_overlay/)ถูกปิดการใช้งาน. การเติมสีหลังผนังและพื้นกำหนดผ่าน[get_BackWall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/)และ[get_Floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/), แต่พื้นผิวเหล่านี้จะมองเห็นได้เฉพาะในแผนภูมิ 3D.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <drawing/color.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortion.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/DisplayUnitType.h>
#include <DOM/Chart/TickLabelPositionType.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IChartPlotArea.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"");
auto chartTitle = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
chartTitle->set_Text(u"Sample Chart");
chartTitle->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
chartTitle->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
chartTitle->get_PortionFormat()->set_FontHeight(20);
chartTitle->get_PortionFormat()->set_FontBold(NullableBool::True);
chartTitle->get_PortionFormat()->set_FontItalic(NullableBool::True);

chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->set_Width(5);
chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->set_Width(3);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Thousands);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.0%");

chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinorUnit(false);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);

chart->get_Axes()->get_VerticalAxis()->set_MaxValue(15.0f);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-2.0f);
chart->get_Axes()->get_VerticalAxis()->set_MinorUnit(0.5f);
chart->get_Axes()->get_VerticalAxis()->set_MajorUnit(2.0f);

auto valueAxisText = chart->get_Axes()->get_VerticalAxis()->get_TextFormat()->get_PortionFormat();
valueAxisText->set_FontBold(NullableBool::True);
valueAxisText->set_FontHeight(16);
valueAxisText->set_FontItalic(NullableBool::True);
valueAxisText->get_FillFormat()->set_FillType(FillType::Solid);
valueAxisText->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkGreen());
auto valueAxisFont = System::MakeObject<FontData>(u"Times New Roman");
valueAxisText->set_LatinFont(valueAxisFont);

chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"");
auto valueAxisTitle = chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
valueAxisTitle->set_Text(u"Primary Axis");
valueAxisTitle->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
valueAxisTitle->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
valueAxisTitle->get_PortionFormat()->set_FontHeight(20);
valueAxisTitle->get_PortionFormat()->set_FontBold(NullableBool::True);
valueAxisTitle->get_PortionFormat()->set_FontItalic(NullableBool::True);

chart->get_Axes()->get_HorizontalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_HorizontalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
chart->get_Axes()->get_HorizontalAxis()->get_MajorGridLinesFormat()->get_Line()->set_Width(5);

chart->get_Axes()->get_HorizontalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_HorizontalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
chart->get_Axes()->get_HorizontalAxis()->get_MinorGridLinesFormat()->get_Line()->set_Width(3);

auto categoryAxisText = chart->get_Axes()->get_HorizontalAxis()->get_TextFormat()->get_PortionFormat();
categoryAxisText->set_FontBold(NullableBool::True);
categoryAxisText->set_FontHeight(16);
categoryAxisText->set_FontItalic(NullableBool::True);
categoryAxisText->get_FillFormat()->set_FillType(FillType::Solid);
categoryAxisText->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
auto categoryAxisFont = System::MakeObject<FontData>(u"Arial");
categoryAxisText->set_LatinFont(categoryAxisFont);

chart->get_Axes()->get_HorizontalAxis()->set_HasTitle(true);
chart->get_Axes()->get_HorizontalAxis()->get_Title()->AddTextFrameForOverriding(u"");

auto categoryAxisTitle = chart->get_Axes()->get_HorizontalAxis()->get_Title()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
categoryAxisTitle->set_Text(u"Sample Category");
categoryAxisTitle->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
categoryAxisTitle->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
categoryAxisTitle->get_PortionFormat()->set_FontHeight(20);
categoryAxisTitle->get_PortionFormat()->set_FontBold(NullableBool::True);
categoryAxisTitle->get_PortionFormat()->set_FontItalic(NullableBool::True);

chart->get_Axes()->get_HorizontalAxis()->set_TickLabelPosition(TickLabelPositionType::Low);
chart->get_Axes()->get_HorizontalAxis()->set_TickLabelRotationAngle(45);

auto legendText = chart->get_Legend()->get_TextFormat()->get_PortionFormat();
legendText->set_FontBold(NullableBool::True);
legendText->set_FontHeight(16);
legendText->set_FontItalic(NullableBool::True);
legendText->get_FillFormat()->set_FillType(FillType::Solid);
legendText->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkRed());

chart->get_Legend()->set_Overlay(false);

chart->get_BackWall()->set_Thickness(1);
chart->get_BackWall()->get_Format()->get_Fill()->set_FillType(FillType::Solid);
chart->get_BackWall()->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Orange());

chart->get_Floor()->get_Format()->get_Fill()->set_FillType(FillType::Solid);
chart->get_Floor()->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

chart->get_PlotArea()->get_Format()->get_Fill()->set_FillType(FillType::Solid);
chart->get_PlotArea()->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_LightCyan());

presentation->Save(u"FormattedChart_out.pptx", SaveFormat::Pptx);
```

## **กำหนดคุณสมบัติตัวอักษรสำหรับแผนภูมิ**

ตั้งค่าขนาดตัวอักษรเริ่มต้นสำหรับข้อความแผนภูมิผ่าน[Chart::get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_textformat/). ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มโดยใช้ตัวอักษรขนาด 20 จุดและเปิดใช้งานป้ายค่าสำหรับชุดแรกผ่าน[set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/). องค์ประกอบข้อความที่มีการตั้งค่าตัวอักษรเฉพาะของตนเองสามารถทับค่าตั้งต้นของแผนภูมิได้.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
chart->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_ChartData()->get_Series()->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"FontPropertiesForChart.pptx", SaveFormat::Pptx);
```

## **ใช้การจัดรูปแบบกรอบข้อความซ้ำสำหรับคำอธิบายแผนภูมิ**

เพื่อตรงกับคำอธิบายกับหัวข้อสไลด์, ตั้งค่าตัวอักษรในรูปแบบส่วนเริ่มต้นของย่อหน้าแรกผ่าน[get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/). ใช้[get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iformattedtextcontainer/get_textformat/)เพื่อเข้าถึงรูปแบบข้อความของคำอธิบาย, แล้วเรียก[CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyfrom/)ด้วยกรอบข้อความของหัวข้อ. นี้จะคัดลอกการตั้งค่ากรอบข้อความ, การจัดรูปแบบของย่อหน้าแรก, และคุณสมบัติตัวอักษรเริ่มต้นของย่อมนั้น. การจัดรูปแบบที่ใช้โดยตรงกับส่วนย่อยหรือย่อหน้าต่อมาจะอยู่ในแหล่งที่มานั้น.

ตัวอย่างนี้ใช้หัวข้อ Calibri หนา 26 จุดสีกรมท่าเป็นแม่แบบ. หลังจากจัดรูปแบบคำอธิบาย, จะใช้[CopyTo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyto/)เพื่อใช้รูปแบบเดียวกันกับคำบรรยายแยกต่างหาก.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ShapeType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/StyleType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/LegendPositionType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto heading = shapes->AddAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
auto sourceTextFrame = heading->AddTextFrame(u"Quarterly sales");
auto font = sourceTextFrame->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
font->set_LatinFont(MakeObject<FontData>(u"Calibri"));
font->set_FontHeight(26);
font->set_FontBold(NullableBool::True);
font->get_FillFormat()->set_FillType(FillType::Solid);
font->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::FromArgb(32, 64, 96));

auto chart = shapes->AddChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
chart->set_Style(StyleType::Style3);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Retail"));
workbook->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Online"));
workbook->GetCell(0, 0, 3, ObjectExt::Box<String>(u"Wholesale"));
for (auto quarter = 1; quarter <= 4; ++quarter)
{
    auto label = String::Format(u"Q{0}", quarter);
    workbook->GetCell(0, quarter, 0, ObjectExt::Box<String>(label));
}

chart->set_HasLegend(true);
auto legend = chart->get_Legend();
legend->set_Position(LegendPositionType::Bottom);
auto legendTextFormat = legend->get_TextFormat();
legendTextFormat->CopyFrom(sourceTextFrame);

auto caption = shapes->AddAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
auto captionTextFrame = caption->AddTextFrame(u"Sales in millions of dollars");
legendTextFormat->CopyTo(captionTextFrame);

presentation->Save(u"legend-formatting.pptx", SaveFormat::Pptx);
```

ในงานนำเสนอที่บันทึกไว้, คำอธิบายและคำบรรยายตรงกับหัวข้อในด้านขนาด, น้ำหนัก, และสี. คำอธิบายยังคงแสดงชื่อชุดข้อมูล, และคำบรรยายคงข้อความของตนเอง. หากส่วนหนึ่งในคำบรรยายมีขนาดตัวอักษรที่กำหนดไว้แล้ว, ขนาดนั้นจะมีลำดับความสำคัญเหนือค่าตั้งต้นของย่อค้าที่คัดลอก.

| ก่อนคัดลอก | หลังคัดลอก |
| --- | --- |
| ![แผนภูมิการขายไตรมาสที่มีป้ายคำอธิบายสีดำปกติและคำบรรยายสีดำ](legend-formatting-before.png) | ![แผนภูมิเดียวกันที่มีป้ายคำอธิบายสีกรมท่าวัดใหญ่, หนา, และคำบรรยายที่ตรงกัน](legend-formatting.png) |

## **กำหนดรูปแบบตัวเลข**

ใช้[IChartDataCell::set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/)เพื่อใช้รูปแบบตัวเลขที่มีอยู่ล่วงหน้าในเซลล์สมุดงานของแผนภูมิ. ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้นที่อิงเซลล์และใช้ดัชนีรูปแบบ 10 (`0.00%`) กับเซลล์ค่าชุดข้อมูลแต่ละชุด. สิ่งนี้เปลี่ยนวิธีการแสดงค่าภายในสมุดงานโดยไม่เปลี่ยนตัวเลขพื้นฐาน; ตัวอย่างเช่น 0.25 จะถูกแสดงเป็น 25.00%. รูปแบบแกนและป้ายข้อมูลสามารถกำหนดค่าแยกกันได้.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IChartDataCell.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series();

for (auto chartSeries : series)
{
    for (auto dataPoint : chartSeries->get_DataPoints())
    {
        dataPoint->get_Value()->get_AsCell()->set_PresetNumberFormat(10); // 0.00%
    }
}

presentation->Save(u"PresetNumberFormat_out.pptx", SaveFormat::Pptx);
```

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่มีอยู่ล่วงหน้าพร้อมรูปแบบ Excel ตัวอย่างสำหรับที่ตั้งภาษาอังกฤษ (สหรัฐอเมริกา). สตริงรูปแบบที่แน่นอนและการแสดงผลอาจแตกต่างกันตามแอปพลิเคชันและที่ตั้ง, โดยเฉพาะสำหรับสกุลเงินและวันที่. รูปแบบ Excel บางอย่างยังแตกต่างจากค่าตั้งต้นในมาตรฐาน OOXML, ตามที่อธิบายใน[บันทึกการนำรูปแบบตัวเลขของ Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| ดัชนี | รูปแบบ |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **กำหนดขอบโค้งสำหรับพื้นที่แผนภูมิ**

เปิดใช้งาน[IChart::set_HasRoundedCorners](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasroundedcorners/)เพื่อทำให้มุมของพื้นที่แผนภูมิโค้ง. ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้[get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/)เพื่อให้ขอบของมันเป็นสีเทาเข้มแบบทึบและสไตล์เส้นเดี่ยวก่อนบันทึกงานนำเสนอ.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <drawing/color.h>
#include <DOM/FillType.h>
#include <DOM/LineStyle.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
chart->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
chart->get_LineFormat()->set_Style(LineStyle::Single);
chart->set_HasRoundedCorners(true);

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **แก้ไขคำอธิบายแผนภูมิที่มีอยู่**

แผนภูมิอาจมีรูปร่างที่กำหนดเอง, เช่น คำอธิบายข้อความที่อธิบายสถานะของรายงาน. เข้าถึงรูปเหล่านี้ผ่าน[IChart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_usershapes/), ซึ่งยังปรากฏภายใต้[Chart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_usershapes/)ในเอกสารอ้างอิง API ของแผนภูมิ. คอลเลกชัน[get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)ของมันมีรูปที่เป็นของแผนภูมิ.

กล่องข้อความธรรมดาที่วางเหนือแผนภูมิเป็นของสไลด์, แม้ว่ามันจะดูเหมือนเป็นส่วนหนึ่งของแผนภูมิ. การวนลูปผ่าน[Slide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/)จะพบแผนภูมิและรูปร่างของสไลด์ทั่วไป, แต่จะไม่แสดงรายการรูปแต่ละรูปภายในแผนภูมิ. ชื่อเรื่องแผนภูมิและป้ายข้อมูลเป็นองค์ประกอบแผนภูมิแยกต่างหาก, ไม่ใช่คำอธิบายที่กำหนดเองในคอลเลกชันนี้.

ดาวน์โหลด[chart-annotations.pptx](chart-annotations.pptx)และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน. สไลด์แรกของมันมีแผนภูมิพร้อมคำอธิบายที่ไม่ได้จัดกลุ่มอ่านว่า "Preliminary results", เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ธรรมดาอ่านว่า "Slide overlay". ตัวอย่างนี้ค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนคำอธิบายเป็น "Final results" เมื่อรายงานพร้อมเผยแพร่. มันตรวจสอบว่าคอลเลกชันว่างหรือไม่และแก้ไขเฉพาะ[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)ที่มี [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) ไม่เป็น null และมีข้อความที่คาดหวัง.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <DOM/IGroupShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"chart-annotations.pptx");
auto slide = presentation->get_Slide(0);

System::SharedPtr<IChart> chart;
for (auto shape : slide->get_Shapes())
{
    auto candidate = System::DynamicCast<IChart>(shape);
    if (candidate != nullptr)
    {
        chart = candidate;
        break;
    }
}

if (chart == nullptr || chart->get_UserShapes()->get_Shapes()->get_Count() == 0)
{
    System::Console::WriteLine(u"No chart or chart-owned shapes found.");
    return;
}

auto updated = false;
for (auto shape : chart->get_UserShapes()->get_Shapes())
{
    auto annotation = System::DynamicCast<IAutoShape>(shape);
    if (annotation != nullptr &&
        annotation->get_TextFrame() != nullptr &&
        annotation->get_TextFrame()->get_Text() == u"Preliminary results")
    {
        annotation->get_TextFrame()->set_Text(u"Final results");
        updated = true;
        break;
    }
}

if (updated)
{
    presentation->Save(u"chart-annotations-updated.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"No matching text annotation found.");
}
```

เส้นและกล่องข้อความสไลด์ยังคงไม่เปลี่ยนแปลง. ภาพต่อไปนี้แสดงอินพุตและผลลัพธ์ที่บันทึกและเปิดใหม่:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![คำอธิบายแผนภูมิเขียนว่า Preliminary results](chart-annotations-before.png) | ![คำอธิบายแผนภูมิเขียนว่า Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างตรวจสอบเฉพาะรูปที่เป็นของแผนภูมิระดับบนสุด. หากคำอธิบายอยู่ภายใน[IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), ตรวจสอบคอลเลกชัน[get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)ของกลุ่มนั้นด้วย. ทำซ้ำเช่นนี้แบบเรียกซ้ำสำหรับกลุ่มที่ซ้อนกัน, ใช้การตรวจสอบข้อความเดียวกันกับรูปร่างลูกของพวกมัน. กลุ่มเองเป็นคอนเทนเนอร์; อย่าสมมติว่าเป็นกล่องข้อความ.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าการเติมสีกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่ในขณะที่ยังคงทำให้ขอบไม่โปร่งใสได้หรือไม่?**

ใช่. ความโปร่งใสของการเติมสีและเส้นขอบกำหนดค่าแยกกัน. สิ่งนี้เป็นประโยชน์ในการปรับปรุงความอ่านง่ายของกริดและข้อมูลในการแสดงผลที่หนาแน่น.

**ฉันจะจัดการกับป้ายข้อมูลเมื่อมันทับซ้อนกันอย่างไร?**

ลดขนาดตัวอักษร, ปิดการใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น หมวดหมู่), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะจุดที่เลือกเมื่อจำเป็น, หรือเปลี่ยนรูปแบบเป็น "ค่า + คำอธิบาย".

**ฉันสามารถใช้การเติมสีไล่ระดับหรือแบบลายเส้นให้กับชุดข้อมูลได้หรือไม่?**

ใช่. ชุดข้อมูลรองรับการเติมสีแบบทึบ, ไล่ระดับ, และลายเส้น. ในการปฏิบัติ, ควรใช้ไล่ระดับอย่างจำกัดและหลีกเลี่ยงการผสมที่ทำให้ความคอนทราสต์กับกริดและข้อความลดลง.