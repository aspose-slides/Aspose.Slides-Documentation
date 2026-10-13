---
title: Tùy chỉnh trục biểu đồ trong bản trình chiếu sử dụng C++
linktitle: Trục biểu đồ
type: docs
url: /vi/cpp/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tuỳ chỉnh trục
- thao tác trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho C++ để tùy chỉnh trục biểu đồ trong các bản trình chiếu PowerPoint cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ với Aspose.Slides cho C++. Nó bao gồm các giá trị trục được tính toán, chuyển đổi hàng và cột của biểu đồ, hiển thị trục, khoảng cách nhãn danh mục và dấu tick, danh mục ngày và định dạng, góc xoay tiêu đề, vị trí trục, đơn vị hiển thị và tỷ lệ logarit.

## **Lấy Giá Trị Tối Đa Trên Trục Dọc Trong Biểu Đồ**

Tạo một [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) và thêm một biểu đồ vùng với dữ liệu mặc định. Gọi [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) trước khi đọc các giá trị trục đã tính toán để bố cục biểu đồ được cập nhật.

Đọc [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) và [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) để lấy giới hạn trục, và [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) và [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) để lấy khoảng cách dấu tick. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) và [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) cung cấp các tỉ lệ đơn vị thời gian, có liên quan đến trục ngày. Ví dụ lưu các giá trị này vào các biến cục bộ và lưu biểu đồ.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **Hoán Đổi Dữ Liệu Giữa Các Trục**

Sử dụng [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) để đổi vai trò giữa series và danh mục trong dữ liệu biểu đồ. Mỗi danh mục cũ trở thành một series, và mỗi series cũ trở thành một danh mục. Thao tác này thay đổi cách dữ liệu được nhóm; nó không đổi chỗ trục ngang và trục dọc. Ví dụ sử dụng [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) để gắn dữ liệu mặc định vào `Sheet1!A1:D5`, bao gồm dòng tiêu đề và cột danh mục, trước khi hoán đổi hàng và cột. Nó lưu một biểu đồ có bốn series và ba danh mục.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Vô Hiệu Hóa Trục Dọc cho Biểu Đồ Đường**

Sử dụng [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) với `false` trên trục dọc để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu nó với trục dọc đã ẩn.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **Vô Hiệu Hóa Trục Ngang cho Biểu Đồ Đường**

Sử dụng [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) với `false` trên trục ngang để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu nó với trục ngang đã ẩn.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **Thay Đổi Trục Danh Mục**

Sử dụng [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) để chọn một trục danh mục dạng ngày hoặc dạng văn bản. Ví dụ này yêu cầu `ExistingChart.pptx`, với một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và các ô danh mục chứa giá trị ngày Excel dạng số. Nó thay đổi trục ngang thành trục ngày. Gọi [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) với `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) với `1`, và [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) với tháng để đặt các dấu tick chính cách nhau một tháng.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Kiểm Soát Khoảng Cách Nhãn Trục Danh Mục**

Khi một biểu đồ có nhiều danh mục, giảm số lượng nhãn trục hiển thị mà không loại bỏ danh mục hay điểm dữ liệu. Sử dụng [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) với `false`, sau đó dùng [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) với khoảng cách danh mục mong muốn. Đối với danh mục văn bản theo thứ tự bình thường, việc đếm bắt đầu từ danh mục đầu tiên:

| Khoảng | Nhãn hiển thị trong ví dụ |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Một khoảng `3` hiển thị mỗi nhãn thứ ba, để hai nhãn ẩn giữa các nhãn hiển thị. Nó không loại bỏ các cột tương ứng. Khoảng cách tự động chọn một khoảng dựa trên không gian khả dụng; nó không nhất thiết hiển thị mọi nhãn.

Dấu tick có các điều khiển riêng. Sử dụng [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) với `false` và dùng [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) để đặt khoảng cách cho chúng. Ví dụ, `1` giữ một dấu tick ở mỗi khoảng danh mục trong khi nhãn chỉ xuất hiện mỗi danh mục thứ ba. Sử dụng [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) với kiểu hiển thị để bạn có thể thấy kết quả. Đặt lại thuộc tính tự động‑spacing nào đó về `true` để biểu đồ tự chọn lại khoảng đó.

Ví dụ tự chứa dưới đây tạo 24 danh mục và một series, sau đó lưu ba slide trong `CategoryAxisIntervals.pptx`: khoảng cách tự động, khoảng cách nhãn thủ công với dấu tick độc lập, và khôi phục khoảng cách tự động. Hai bản sao giữ nguyên dữ liệu biểu đồ gốc. Không cần bản trình bày đầu vào. Văn bản nhãn ngang làm cho sự khác biệt về mật độ dễ thấy.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// Slide 2: hiển thị mỗi nhãn thứ ba, nhưng vẫn giữ một dấu tick cho mỗi danh mục.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: cho phép biểu đồ chọn lại cả hai khoảng cách.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Khoảng cách tự động (slide 1):** Trong bản vẽ này, mỗi nhãn danh mục thứ hai được hiển thị và gói thành hai dòng. Kết quả tự động có thể thay đổi tùy kích thước biểu đồ, phông chữ và bộ vẽ.

![Khoảng cách nhãn danh mục tự động với tất cả 24 cột hiển thị](category-axis-automatic.png)

**Khoảng cách thủ công (slide 2):** Mỗi nhãn thứ ba được hiển thị trên một dòng, trong khi dấu tick vẫn tồn tại ở mỗi khoảng danh mục. Tất cả 24 cột, bao gồm cả những cột không có nhãn, vẫn hiển thị với cùng các giá trị. Slide 3 khôi phục lại giao diện tự động được hiển thị ở trên.

![Khoảng cách nhãn danh mục thủ công ba với tất cả 24 cột hiển thị](category-axis-manual.png)

### **Chọn Trục và Khoảng Cách Phù Hợp**

Sử dụng khoảng đếm danh mục này cho một trục danh mục dạng văn bản, chẳng hạn trục danh mục của biểu đồ cột, đường, vùng hoặc thanh. Trong biểu đồ cột, nó là trục ngang. Trong biểu đồ thanh ngang, trục danh mục là trục dọc, vì vậy áp dụng các cài đặt này cho [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Khoảng cách dấu tick cũng áp dụng cho trục series trong các biểu đồ có trục series.

Đừng sử dụng khoảng cách nhãn danh mục để đặt thang đo số của trục giá trị. Trên trục giá trị, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) chỉ định sự khác biệt về giá trị: ví dụ, một đơn vị chính `10` tạo các dấu tick tại 0, 10, 20, … khi trục bắt đầu từ zero. Một khoảng nhãn danh mục `3` thay vào đó đếm vị trí danh mục, bất kể giá trị dữ liệu của chúng. Các biểu đồ scatter và bubble sử dụng trục giá trị thay vì trục danh mục dạng văn bản. Đối với trục ngày, sử dụng các đơn vị chính và thang thời gian như mô tả trong [Thay Đổi Trục Danh Mục](#change-a-category-axis).

## **Đặt Định Dạng Ngày cho Giá Trị Trục Danh Mục**

Ví dụ thay thế dữ liệu biểu đồ mặc định bằng bốn giá trị hàng năm. Ngày được lưu dưới dạng số serial OLE Automation trong bảng tính đầu tiên (chỉ mục `0`). Sử dụng [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) để chọn trục ngày, tắt định dạng liên kết nguồn bằng [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), và gán `yyyy` với [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) để nhãn danh mục hiển thị năm bốn chữ số độc lập với định dạng ô.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **Đặt Góc Xoay cho Tiêu Đề Trục Biểu Đồ**

Kích hoạt tiêu đề trục dọc bằng [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), cung cấp văn bản tiêu đề, và dùng [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) để xoay tiêu đề. Góc đo bằng độ; ví dụ này lưu một biểu đồ cột với tiêu đề trục giá trị được xoay 90 độ.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **Đặt Vị Trí Trục trên Trục Danh Mục hoặc Trục Giá Trị**

Sử dụng [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) để kiểm soát việc trục giá trị cắt trục danh mục giữa các danh mục hay tại các dấu tick danh mục. Thuộc tính này áp dụng cho trục danh mục. Ví dụ đặt nó thành `true` trên trục danh mục ngang của một biểu đồ cột và lưu kết quả.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **Đặt Đơn Vị Hiển Thị trên Trục Giá Trị của Biểu Đồ**

Sử dụng [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) để thu phóng các nhãn trên trục giá trị mà không thay đổi dữ liệu cơ bản. Với [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) đặt thành `Millions`, giá trị 60 000 000 sẽ hiển thị là 60. Ví dụ tạo một biểu đồ cột và áp dụng đơn vị hiển thị hàng triệu cho trục dọc của nó.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Cấu Hình Trục Giá Trị Logarit**

Trục giá trị logarit hữu ích khi các giá trị dương trải rộng qua nhiều bậc độ. Ví dụ, một dịch vụ có thể nhận 10, 100, 1 000, 10 000 và 100 000 yêu cầu trong năm khoảng thời gian. Trên thang tuyến tính, các giá trị nhỏ xuất hiện gần nhau ở gần zero. Thang logarit làm cho sự tăng trưởng tương đối của chúng dễ so sánh hơn: khoảng cách bằng nhau biểu thị tỉ lệ bằng nhau thay vì chênh lệch bằng nhau.

Gọi [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) với `true` trên trục giá trị và dùng [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) để chọn cơ số. Thao tác này thay đổi cách các giá trị hiện có được hiển thị; nó không thay đổi dữ liệu hay thêm đường xu hướng logarit. Đường xu hướng là một tính năng riêng, đại diện cho mối quan hệ vừa khít trong dữ liệu.

### **Chọn Trục Giá Trị và Cơ Số**

Đối với biểu đồ đường hoặc cột, trục giá trị là [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Đối với biểu đồ thanh ngang, nó là [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Biểu đồ scatter và bubble có hai trục giá trị, vì vậy chọn trục ngang cho giá trị X, trục dọc cho giá trị Y, hoặc cả hai. Đừng áp dụng thang logarit cho trục danh mục.

Cơ số logarit mặc định là `10`. Đối với biểu đồ PPTX, sử dụng cơ số từ `2` đến `1000`, bao gồm; các cơ số phân số như `2.5` cũng được hỗ trợ. Với cơ số `10`, các lũy thừa liên tiếp như 10, 100, 1 000 và 10 000 cách nhau đều nhau.

### **So Sánh Thang Tự Nhiên và Logarit**

Ví dụ tự chứa dưới đây tạo một biểu đồ đường với năm lượng yêu cầu trên slide đầu tiên, sau đó sao chép slide đó và bật trục giá trị logarit cơ số‑10 trên slide thứ hai. Cả hai slide đều giữ nguyên dữ liệu.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Giữ slide đầu tiên ở dạng tuyến tính và chỉ thay đổi thang trục giá trị của bản sao.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Thang tuyến tính (slide 1):** Khoảng cách dọc bằng nhau biểu thị chênh lệch bằng nhau trong số lượng yêu cầu. Giá trị lớn nhất chi phối biểu đồ, làm cho các giá trị nhỏ khó phân biệt.

![Biểu đồ đường trong PowerPoint hiển thị năm lượng yêu cầu trên trục giá trị tuyến tính](value-axis-linear.png)

**Thang logarit (slide 2):** Khoảng cách dọc bằng nhau biểu thị tỉ lệ bằng nhau. Mỗi khoảng thời gian có số yêu cầu gấp mười lần so với khoảng trước, vì vậy các điểm tạo thành một đường thẳng tăng lên trên thang logarit cơ số‑10. Nhãn trục vẫn hiển thị số lượng yêu cầu gốc.

![Năm lượng yêu cầu giống nhau trong PowerPoint trên trục giá trị logarit cơ số 10](value-axis-logarithmic.png)

### **Xử Lý Giá Trị Zero và Âm**

Thang logarit chỉ có thể hiển thị các giá trị dương tuyệt đối. Kiểm tra dữ liệu trước khi bật nó. Nếu các giá trị zero hoặc âm có ý nghĩa, giữ thang tuyến tính hoặc hiển thị chúng riêng. Nếu loại bỏ các giá trị đó là phù hợp cho phân tích, hãy giải thích lý do bỏ qua. Đừng âm thầm thay chúng bằng các số dương nhỏ, vì điều đó làm thay đổi ý nghĩa của dữ liệu. Bất kỳ giá trị tối thiểu hoặc tối đa nào được cấu hình thủ công cho trục logarit cũng phải là dương.

## **Câu Hỏi Thường Gặp**

**Làm thế nào để đặt giá trị mà một trục cắt nhau (điểm giao trục)?**

Sử dụng [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) để chọn hành vi giao cắt. Để chỉ định một giá trị giao cắt số, dùng [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Các cài đặt này cho phép bạn di chuyển điểm giao trục đến mức nền phù hợp.

**Làm thế nào để đặt vị trí nhãn tick so với trục?**

Sử dụng [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) với một giá trị từ [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, hoặc `None`. Để điều khiển các dấu tick riêng, dùng [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) hoặc [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); chúng là các yếu tố riêng biệt so với vị trí nhãn.