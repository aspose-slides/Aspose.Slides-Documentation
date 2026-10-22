---
title: Quản lý chuỗi dữ liệu biểu đồ trong bài thuyết trình bằng C++
linktitle: Chuỗi dữ liệu
type: docs
url: /vi/cpp/chart-series/
keywords:
- chuỗi biểu đồ
- độ chồng lấn chuỗi
- màu chuỗi
- màu danh mục
- tên chuỗi
- điểm dữ liệu
- khoảng trống chuỗi
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, các ô workbook, định dạng, độ chồng lấn, độ rộng khoảng trống và các giá trị âm trong bài thuyết trình bằng C++."
---
## **Tổng quan**

Biểu đồ có thể lưu trữ các giá trị đã vẽ trong các ô của workbook hoặc trực tiếp dưới dạng các số literal. Một [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/) đại diện cho một điểm trong chuỗi đó. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Trong các biểu đồ được tạo bằng dữ liệu mặc định, tên chuỗi, danh mục và giá trị điểm sử dụng các đối tượng [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/) từ workbook của biểu đồ.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục và các ô còn lại cho giá trị chuỗi. Các chỉ số worksheet, hàng và cột được truyền vào [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) đều bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bài thuyết trình đã tải, hãy kiểm tra các ô được tham chiếu bởi chuỗi, danh mục và các điểm dữ liệu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp chuỗi, chẳng hạn như [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt cấp điểm dữ liệu, chẳng hạn như [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/), ghi đè giao diện chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/). Truy cập nhóm thông qua [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) khi bạn cần đặt các tùy chọn như độ chồng lấn hoặc độ rộng khoảng trống.

Khi không có màu nền điểm hoặc chuỗi nào được đặt một cách rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định giao diện tự động. Khi cả định dạng chuỗi và điểm dữ liệu đều có, định dạng điểm dữ liệu sẽ có ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Thiết Lập Giá Trị Chuỗi Bằng Các Số Literal**

Sử dụng các số literal khi giá trị chuỗi đến từ dữ liệu hoặc phép tính của ứng dụng và không cần tham chiếu đến ô worksheet. Gọi [set_DataSourceTypeForValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforvalues/) với [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) trước khi gán giá trị trả về bởi [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_value/) của mỗi điểm thông qua [set_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/set_asliteraldouble/).

Cài đặt bộ sưu tập kiểm soát kiểu nguồn của tất cả các giá trị điểm trong chuỗi đó. Mỗi điểm có [IBaseChartValue::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ibasechartvalue/get_datasourcetype/) báo cáo kiểu đã chọn; thay đổi nó thông qua cài đặt bộ sưu tập. Khi dùng `Worksheet`, sử dụng [get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/isinglecellchartvalue/get_ascell/) để truy cập ô được tham chiếu. Khi dùng `DoubleLiterals`, sử dụng [get_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/get_asliteraldouble/) hoặc `set_AsLiteralDouble` để đọc hoặc ghi số trực tiếp.

Ví dụ sau tạo một biểu đồ cột với chuỗi và danh mục mặc định, sau đó gán các giá trị tính toán 10, 20, … cho các điểm hiện có của chuỗi đầu tiên. Nó lưu bài thuyết trình, mở lại và in các giá trị đã lưu.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

series->get_DataPoints()->set_DataSourceTypeForValues(DataSourceType::DoubleLiterals);
for (auto i = 0; i < series->get_DataPoints()->get_Count(); i++)
{
    series->get_DataPoints()->idx_get(i)->get_Value()->set_AsLiteralDouble((i + 1) * 10);
}

presentation->Save(u"numeric_literals.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"numeric_literals.pptx");
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedChart = ExplicitCast<IChart>(reopenedSlide->get_Shape(0));
auto reopenedSeries = reopenedChart->get_ChartData()->get_Series()->idx_get(0);
for (auto i = 0; i < reopenedSeries->get_DataPoints()->get_Count(); i++)
{
    auto point = reopenedSeries->get_DataPoints()->idx_get(i);
    Console::WriteLine(point->get_Value()->get_AsLiteralDouble());
}
reopenedPresentation->Dispose();
```

Kiểu nguồn giá trị điểm tách biệt khỏi [IChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_datasourcetype/), kiểu này xác định cấu hình workbook nội bộ hoặc ngoại vi của biểu đồ. Việc sử dụng các số literal không tự động loại bỏ workbook nhúng. Trong ví dụ này, workbook vẫn còn sẵn cho nhãn danh mục, tên chuỗi và các chuỗi khác. Xem [Chart Workbook](/slides/vi/cpp/chart-workbook/) để biết quản lý workbook.

Đối với biểu đồ scatter và bubble, gọi [set_DataSourceTypeForXValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforxvalues/) và [set_DataSourceTypeForYValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforyvalues/) để chọn nguồn cho [get_XValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_xvalue/) và [get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Biểu đồ bubble cũng sử dụng [set_DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforbubblesizes/) cho [get_BubbleSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_bubblesize/). Đặt mỗi nguồn áp dụng thành `DoubleLiterals` trước khi gán số qua phương thức `set_AsLiteralDouble` của giá trị đó.

## **Đặt Độ Chồng Lấn Của Chuỗi Biểu Đồ**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/) báo cáo mức độ các thanh hoặc cột chồng lên nhau trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Gọi [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột nhóm; nó không ảnh hưởng đến các nhóm chuỗi không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt độ chồng lấn cho nhóm chứa chuỗi đầu tiên:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// Biểu đồ mới chứa các chuỗi mẫu, danh mục và giá trị.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![The series overlap](series_overlap.png)

## **Thay Đổi Màu Độ Đổ Nền Của Chuỗi**

Sử dụng [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) để đặt màu nền mặc định cho toàn bộ chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho chuỗi đầu tiên:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![The color of the series](series_color.png)

## **Thay Đổi Tên Chuỗi**

Tên chuỗi được lưu trong workbook dữ liệu biểu đồ và thường hiển thị trong chú giải. Trong workbook mặc định được tạo cho biểu đồ cột cụm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm cho cấu trúc này rõ ràng:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bạn cũng có thể cập nhật ô đã được tham chiếu bởi [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/). Cách tiếp cận này tránh việc giả định một hàng và cột cụ thể trong biểu đồ đã tồn tại:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![The series name](series_name.png)

### **Tạo Chuỗi Với Tên Từ Nhiều Ô**

Tên chuỗi hợp thành hữu ích khi tên sản phẩm và kỳ báo cáo được lưu trong các ô workbook riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` ở B1 và `2026` ở C1 thành một tên chuỗi duy nhất trong khi vẫn giữ cả hai phần liên kết với ô nguồn của chúng.

Sử dụng [IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/) để lấy dải tên, sau đó truyền dải này cho [IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/). Tham số `skipHiddenCells` kiểm soát việc bao gồm các ô ẩn: `true` loại bỏ chúng, `false` giữ lại. Ví dụ này dùng `false` để bao gồm mọi ô trong dải tên.

Ví dụ sau tạo một bài thuyết trình với một chuỗi và hai điểm dữ liệu. Các ô B1:C1 chỉ cung cấp tên chuỗi; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 620.0f, 180.0f);
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
chart->set_HasLegend(true);

auto workbook = chartData->get_ChartDataWorkbook();
workbook->Clear(0);

// Hai ô này cung cấp tên chuỗi.
auto productName = ObjectExt::Box<String>(u"Product A");
auto reportingPeriod = ObjectExt::Box<String>(u"2026");
workbook->GetCell(0, 0, 1, productName);
workbook->GetCell(0, 0, 2, reportingPeriod);
auto nameCells = workbook->GetCellCollection(u"Sheet1!$B$1:$C$1", false);
auto series = chartData->get_Series()->Add(nameCells, ChartType::ClusteredColumn);

// Các ô riêng biệt cung cấp danh mục và các điểm dữ liệu số.
auto northLabel = ObjectExt::Box<String>(u"North");
auto southLabel = ObjectExt::Box<String>(u"South");
auto northCategory = workbook->GetCell(0, 1, 0, northLabel);
auto southCategory = workbook->GetCell(0, 2, 0, southLabel);
chartData->get_Categories()->Add(northCategory);
chartData->get_Categories()->Add(southCategory);
auto northAmount = ObjectExt::Box<int>(120);
auto southAmount = ObjectExt::Box<int>(150);
auto northValue = workbook->GetCell(0, 1, 1, northAmount);
auto southValue = workbook->GetCell(0, 2, 1, southAmount);
series->get_DataPoints()->AddDataPointForBarSeries(northValue);
series->get_DataPoints()->AddDataPointForBarSeries(southValue);

presentation->Save(u"composite_series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Tên chuỗi kết quả là `Product A 2026`, với một dấu cách giữa hai giá trị ô. Chú giải hiển thị nó như một mục cho cả hai cột. Hình ảnh dưới minh họa kết quả:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Lấy Màu Độ Đổ Nền Tự Động Của Chuỗi**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ số chuỗi và kiểu biểu đồ. Đây là màu được dùng khi màu nền chuỗi chưa được định nghĩa rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu mới.

Ví dụ sau in màu tự động của mỗi chuỗi mặc định:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

Đầu ra mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Màu chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt Màu Đảo Ngược Cho Chuỗi Biểu Đồ**

Đối với chuỗi thanh, cột và bubble, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) có thể hiển thị các giá trị âm với màu nền khác. Đặt màu nền chuỗi thường thành màu đặc, bật tính năng đảo ngược, và gán màu âm qua [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Các số âm không thay đổi trong workbook; chỉ màu hiển thị thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng 0 của worksheet chứa tên chuỗi, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![The inverted solid fill color](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm duy nhất qua [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Trong ví dụ sau, đảo ngược được tắt cho chuỗi và bật chỉ cho điểm đã chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Xóa Giá Trị Điểm Dữ Liệu Cụ Thể**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô workbook chứa giá trị của nó thành `nullptr`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Điểm dữ liệu vẫn giữ vị trí danh mục, nhưng biểu đồ coi giá trị của nó là trống theo cài đặt blank-value của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong chuỗi đầu tiên:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble còn sử dụng ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn giữ các điểm khác, vì phương thức này sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Kiểm Soát Hiển Thị Các Ô Trống**

Các ô ẩn chứa giá trị là một trường hợp riêng so với các ô trống. Để bao gồm hoặc loại trừ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho giá trị số đã biết. Gọi [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/) với `nullptr` để làm ô trống. Số 0 vẫn giữ là 0 bất kể cài đặt ô trống.

Sử dụng [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách vẽ các khoảng trống, mà không cần điền ô workbook trống bằng 0 hay một giá trị nội suy.

Ví dụ tự chứa dưới đây tạo một biểu đồ đường với một chuỗi, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 chứa tên chuỗi. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Để Ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu của nó.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

Mỗi tệp đầu ra lưu chế độ đã gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bài thuyết trình một lần thay vì lặp qua các chế độ.

Bảng so sánh dưới đây cho thấy cùng một dữ liệu trong ba tệp. Ngày 3 trống trong workbook trong mọi trường hợp:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường dễ so sánh ba chế độ. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột thiếu và một cột chiều cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ scatter chỉ có dấu chấm không có đường nối. Không nên mong đợi ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn đang dùng.

## **Đặt Độ Rộng Khoảng Trống Giữa Các Chuỗi**

Độ rộng khoảng trống là khoảng cách giữa các cụm thanh hoặc cột liền kề, tính bằng phần trăm của độ rộng thanh hoặc cột. Giống như độ chồng lấn, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi riêng. Gọi [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng trống và chỉ lưu bài thuyết trình cuối cùng:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![The gap width](gap_width.png)

## **Câu Hỏi Thường Gặp**

**Các loại biểu đồ nào hỗ trợ chuỗi dữ liệu?**

Tất cả các loại biểu đồ được liệt kê trong enumeration [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng chuỗi của chúng không có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ scatter sử dụng giá trị X và Y, và biểu đồ bubble thêm kích thước bubble. Sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại chuỗi. Các tùy chọn như độ chồng lấn và độ rộng khoảng trống chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm chuỗi biểu đồ là gì?**

Một [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) chứa các chuỗi tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm qua một chuỗi không nhất thiết thay đổi mọi chuỗi trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Theo mặc định, [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) tạo các chuỗi, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả hai bộ sưu tập chuỗi và danh mục trước khi thêm bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ kết nối với các ô workbook như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật thành phần biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, giữ các hàng danh mục và các hàng giá trị chuỗi đồng bộ để mỗi điểm được vẽ dưới danh mục mong muốn.

**Làm sao để xóa một điểm mà không xóa toàn bộ chuỗi?**

Đặt ô giá trị tương ứng thành `nullptr` để giữ vị trí danh mục của điểm như một điểm trống. Gọi [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) chỉ khi bạn muốn xóa tất cả các điểm trong chuỗi đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi chuỗi sao cho giá trị của chúng vẫn khớp với bộ danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Các biểu đồ hỗ trợ có thể hiển thị khoảng trống dưới dạng lỗ hổng, giá trị bằng 0, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bài thuyết trình của bạn. Xem [Control the Display of Empty Cells](#control-the-display-of-empty-cells) để có ví dụ đầy đủ và so sánh hình ảnh.

**Các giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bubble được hỗ trợ, gọi [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) và đặt màu qua [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Bạn có thể ghi đè hành vi cho một điểm riêng bằng [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Các phương pháp này ảnh hưởng tới định dạng, không phải các giá trị số đã lưu.

**Định dạng nào thắng khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ có ưu tiên cho điểm đó. Các điểm khác tiếp tục sử dụng định dạng chuỗi rõ ràng hoặc, khi chuỗi không có định dạng, sẽ dùng kiểu và chủ đề biểu đồ tự động. Các cài đặt nhóm như độ chồng lấn và độ rộng khoảng trống kiểm soát bố cục và không phải là các ghi đè định dạng cấp điểm.

**Có giới hạn số lượng chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt giới hạn cố định cho số chuỗi. Thực tế, các ràng buộc của tệp trình chiếu, bộ nhớ khả dụng, thời gian render và khả năng đọc biểu đồ sẽ quyết định một giới hạn thực tế.

**Nên làm gì khi các cột quá gần nhau hoặc quá xa?**

Gọi [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) trên nhóm chuỗi cha phù hợp. Tăng giá trị để mở rộng khoảng cách giữa các cụm, hoặc giảm để làm các cụm gần nhau hơn.