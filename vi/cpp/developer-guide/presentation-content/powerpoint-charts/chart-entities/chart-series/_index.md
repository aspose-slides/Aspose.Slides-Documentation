---
title: Quản lý chuỗi dữ liệu biểu đồ trong bản trình chiếu bằng C++
linktitle: Chuỗi Dữ liệu
type: docs
url: /vi/cpp/chart-series/
keywords:
- chuỗi biểu đồ
- độ chồng lấn series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng cách series
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, ô workbook, định dạng, độ chồng lấn, độ rộng khoảng cách và các giá trị âm trong bản trình chiếu bằng C++."
---
## **Tổng quan**

Một biểu đồ lưu trữ dữ liệu đã vẽ trong một workbook dữ liệu biểu đồ. Một [IChartSeries](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/) trong series tham chiếu tới một hoặc nhiều ô trong workbook. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các series. Vì vậy tên series, các danh mục và giá trị điểm đều được kết nối với các đối tượng [IChartDataCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục và các ô còn lại cho giá trị series. Các chỉ mục worksheet, hàng và cột được truyền vào [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) là dạng chỉ số bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình chiếu đã tải, hãy kiểm tra các ô được series, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp Series, chẳng hạn [IChartSeries::get_Format](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_format/), cung cấp diện mạo mặc định cho tất cả các điểm trong một series.
- Cài đặt cấp Data-point, chẳng hạn [IChartDataPoint::get_Format](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_format/), ghi đè lên diện mạo series cho một điểm.
- Cài đặt nhóm áp dụng cho các series tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/). Truy cập nhóm qua [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) khi bạn cần đặt các tùy chọn như overlap hoặc gap width.

Khi không có màu nền point hoặc series nào được đặt rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định diện mạo tự động. Khi cả định dạng series và point đều tồn tại, định dạng point sẽ có ưu tiên cho point đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Overlap cho Series Biểu đồ**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_overlap/) báo cáo mức độ chồng lấn của các thanh hoặc cột trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm series cha. Gọi [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ dưới đây đặt overlap cho nhóm chứa series đầu tiên:

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

// Biểu đồ mới chứa các series mẫu, danh mục và giá trị.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![The series overlap](series_overlap.png)

## **Thay đổi màu nền Series**

Sử dụng [IChartSeries::get_Format](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_format/) để đặt màu nền mặc định cho toàn bộ một series. Nếu một point đã có màu nền cụ thể, cài đặt [IChartDataPoint::get_Format](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_format/) của nó sẽ ghi đè màu nền series cho point đó.

Ví dụ dưới đây áp dụng màu nền xanh đậm đặc cho series đầu tiên:

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

## **Thay đổi Tên Series**

Tên series được lưu trong workbook dữ liệu biểu đồ và thường hiển thị trong chú giải. Trong workbook mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các hằng số được đặt tên trong ví dụ dưới đây làm cho cấu trúc này rõ ràng:

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

Bạn cũng có thể cập nhật ô đã được [IChartSeries::get_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_name/) tham chiếu. Cách này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ hiện có:

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

## **Lấy Màu Nền Series Tự Động**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ mục series và kiểu biểu đồ. Đây là màu được dùng khi màu nền series chưa được định nghĩa rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ dưới đây in màu tự động của mỗi series mặc định:

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

Màu sắc chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt Màu Nền Đảo Ngược cho Series Biểu đồ**

Đối với series thanh, cột và bóng, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) có thể hiển thị các giá trị âm bằng một màu nền khác. Đặt màu nền series thường thành màu đặc, bật chế độ đảo ngược, và gán màu giá trị âm qua [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Các số âm không thay đổi trong workbook; chỉ màu hiển thị của chúng thay đổi.

Ví dụ dưới đây thay thế dữ liệu biểu đồ mặc định bằng một series. Hàng 0 của worksheet chứa tên series, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

Bạn có thể bật đảo ngược cho một point thông qua [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Trong ví dụ sau, đảo ngược bị tắt cho series và chỉ bật cho point đã chọn. Point cũng được gán giá trị âm để hiệu ứng hiển thị:

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

## **Xóa Giá Trị Điểm Dữ liệu Cụ Thể**

Để làm cho một point rỗng mà không xóa các point khác, đặt ô workbook tương ứng thành `nullptr`. Đối với biểu đồ cột, giá trị được vẽ sẵn có thể lấy qua [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Điểm dữ liệu vẫn nằm ở cùng vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ dưới đây chỉ xóa point thứ hai trong series đầu tiên:

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

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble còn dùng ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) khi muốn giữ các point còn lại, vì phương thức này sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Kiểm Soát Hiển Thị Ô Trống**

Các ô ẩn chứa giá trị là một trường hợp riêng so với các ô trống. Để bao gồm hoặc loại trừ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Gọi [IChartDataCell::set_Value](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/set_value/) với `nullptr` để làm ô trở nên trống. Số không vẫn là số không bất kể cài đặt ô trống.

Sử dụng [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/set_displayblanksas/) để chọn cách biểu đồ hiển thị ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách vẽ các ô trống, mà không điền giá trị 0 hay giá trị nội suy vào ô workbook trống.

Ví dụ tự chứa dưới đây tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [IChartDataWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 chứa tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

// Leave Day 3 genuinely empty, while retaining its category and data point.
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

Mỗi tệp đầu ra lưu chế độ được gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình chiếu một lần thay vì lặp qua các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong cả ba tệp. Ngày 3 là ô trống trong workbook trong mọi trường hợp:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường làm cho ba chế độ dễ so sánh. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột mất và một cột chiều cao bằng 0 cũng có thể trông giống nhau. Tương tự, biểu đồ scatter chỉ có dấu chấm không có đường nối. Đừng mong đợi ba kết quả riêng biệt cho mọi loại biểu đồ; kiểm tra kết quả đầu ra cho loại bạn sử dụng.

## **Đặt Khoảng Cách Giữa Các Series (Gap Width)**

Khoảng cách gap là không gian giữa các cụm thanh hoặc cột kề nhau, tính bằng phần trăm của chiều rộng thanh hoặc cột. Giống như overlap, nó thuộc về nhóm series cha chứ không phải một series riêng. Gọi [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) một lần cho nhóm. Giá trị lớn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ làm chúng dày đặc hơn.

Ví dụ dưới đây thay đổi gap width và chỉ lưu bản trình chiếu cuối cùng:

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

**Các loại biểu đồ nào hỗ trợ series dữ liệu?**

Tất cả các loại biểu đồ được biểu thị bởi enumeration [ChartType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng series của chúng không cùng một cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục dùng danh mục và giá trị, biểu đồ scatter dùng giá trị X và Y, và biểu đồ bubble còn thêm kích thước bong bóng. Sử dụng phương pháp tạo point dữ liệu phù hợp với loại series. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Series group là gì?**

[IChartSeriesGroup](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/) chứa các series tương thích chia sẻ cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có dữ liệu mặc định không?**

Có. Mặc định, [IShapeCollection::AddChart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addchart/) tạo các series, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả bộ sưu tập series và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ mà không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị point dữ liệu tham chiếu tới các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/). Thay đổi ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và hàng giá trị series đồng nhất để mỗi point được vẽ dưới danh mục mong muốn.

**Làm sao để xóa một point mà không xóa toàn bộ series?**

Đặt ô giá trị liên quan thành `nullptr` để giữ vị trí danh mục của point như một point trống. Gọi [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) chỉ khi bạn muốn xóa mọi point trong series đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi series sao cho giá trị của chúng vẫn căn chỉnh với bộ sưu tập danh mục.

**Các point trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Các biểu đồ hỗ trợ có thể hiển thị ô trống dưới dạng khoảng trống, giá trị 0, hoặc bằng cách nối các point lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình chiếu của bạn. Xem [Control the Display of Empty Cells](#control-the-display-of-empty-cells) để biết ví dụ đầy đủ và so sánh hình ảnh.

**Giá trị âm được định dạng như thế nào?**

Đối với các series thanh, cột và bubble được hỗ trợ, gọi [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) và đặt màu qua [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Bạn có thể ghi đè hành vi cho một point riêng lẻ bằng [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Các phương thức này ảnh hưởng tới định dạng, không thay đổi giá trị số lưu trữ.

**Định dạng nào thắng khi cả series và point đều được định dạng?**

Định dạng point cụ thể sẽ có ưu tiên cho point đó. Các point khác vẫn sử dụng định dạng series rõ ràng hoặc, khi series không có định dạng, sẽ dùng kiểu biểu đồ và chủ đề tự động. Cài đặt nhóm như overlap và gap width kiểm soát bố cục và không phải là ghi đè định dạng cấp point.

**Có giới hạn số lượng series trong một biểu đồ không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng cho số series. Trong thực tế, các ràng buộc của tệp trình chiếu, bộ nhớ khả dụng, thời gian render và khả năng đọc biểu đồ quyết định mức giới hạn hữu dụng.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Gọi [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) trên nhóm series cha phù hợp. Tăng giá trị để mở rộng khoảng cách giữa các cụm, hoặc giảm giá trị để đưa các cụm lại gần nhau hơn.