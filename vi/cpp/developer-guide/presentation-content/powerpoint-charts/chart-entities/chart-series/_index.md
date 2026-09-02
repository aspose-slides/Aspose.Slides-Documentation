---
title: Quản lý Chuỗi Dữ liệu Biểu đồ trong Bản trình bày bằng C++
linktitle: Chuỗi Dữ liệu
type: docs
url: /vi/cpp/chart-series/
keywords:
- chuỗi biểu đồ
- độ chồng lấp chuỗi
- màu chuỗi
- màu danh mục
- tên chuỗi
- điểm dữ liệu
- khoảng cách chuỗi
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, ô workbook, định dạng, độ chồng lấp, độ rộng khoảng cách và các giá trị âm trong bản trình bày bằng C++."
---
## **Tổng quan**

Biểu đồ lưu trữ dữ liệu đã vẽ trong một workbook dữ liệu biểu đồ. Một [IChartSeries](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [IChartDataPoint](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/) trong chuỗi tham chiếu đến một hoặc nhiều ô workbook. Các đối tượng [IChartCategory](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Vì vậy, tên chuỗi, danh mục và giá trị điểm đều được kết nối với các đối tượng [IChartDataCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục và các ô còn lại cho giá trị chuỗi. Các chỉ mục worksheet, hàng và cột được truyền vào [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) là dựa trên chỉ số 0. bố cục này hữu ích khi bạn tạo một biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô mà các chuỗi, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt ở mức chuỗi, chẳng hạn như [IChartSeries::get_Format](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_format/), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt ở mức điểm dữ liệu, chẳng hạn như [IChartDataPoint::get_Format](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_format/), ghi đè giao diện chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/). Truy cập nhóm thông qua [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) khi bạn cần đặt các tùy chọn như độ chồng lấp hoặc chiều rộng khoảng cách.

Khi không có màu nền điểm hoặc chuỗi nào được chỉ định rõ ràng, kiểu biểu đồ và giao diện xác định giao diện tự động. Khi cả định dạng chuỗi và điểm đều tồn tại, định dạng điểm sẽ được ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Độ Trùng Lấp Của Chuỗi Biểu Đồ**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_overlap/) báo cáo mức độ các thanh hoặc cột chồng lên nhau trong một biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Gọi [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm chuỗi không liên quan trong một biểu đồ kết hợp.

Ví dụ sau đặt độ trùng lấp cho nhóm chứa chuỗi đầu tiên:

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

## **Thay Đổi Màu Nền Của Chuỗi**

Sử dụng [IChartSeries::get_Format](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_format/) để đặt màu nền mặc định cho toàn bộ một chuỗi. Nếu một điểm đã có màu nền cụ thể, cài đặt [IChartDataPoint::get_Format](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_format/) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

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

Tên chuỗi được lưu trong workbook dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong workbook mặc định được tạo cho một biểu đồ cột cụm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các hằng số có tên trong ví dụ sau làm cho cấu trúc này trở nên rõ ràng:

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

## **Lấy Màu Nền Tự Động Của Chuỗi**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ mục chuỗi và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền chuỗi không được định nghĩa rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in ra màu tự động của mỗi chuỗi mặc định:

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

Màu chính xác phụ thuộc vào kiểu biểu đồ và giao diện.

## **Đặt Màu Nền Đảo Ngược Cho Một Chuỗi Biểu Đồ**

Đối với các chuỗi thanh, cột và bong bóng, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) có thể hiển thị các giá trị âm với màu nền khác. Đặt màu nền chuỗi thông thường thành đặc, bật tính năng đảo ngược và gán màu cho giá trị âm qua [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Các số âm vẫn không thay đổi trong workbook; chỉ màu hiển thị của chúng thay đổi.

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

Bạn có thể bật đảo ngược cho một điểm thông qua [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Trong ví dụ sau, việc đảo ngược được tắt cho chuỗi và chỉ bật cho điểm đã chọn. Điểm này cũng được gán một giá trị âm để hiệu ứng hiển thị:

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

## **Xóa Giá Trị Cụ Thể Của Một Điểm Dữ Liệu**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô workbook hỗ trợ của nó thành `nullptr`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Điểm dữ liệu vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

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

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng còn sử dụng ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Đừng gọi [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn giữ các điểm khác, vì phương thức đó sẽ xóa mọi điểm dữ liệu khỏi bộ sưu tập.

## **Đặt Chiều Rộng Khoảng Cách Giữa Các Chuỗi**

Chiều rộng khoảng cách là khoảng cách giữa các cụm thanh hoặc cột liền kề, biểu thị dưới dạng phần trăm của chiều rộng thanh hoặc cột. Giống như độ trùng lấp, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi riêng lẻ. Gọi [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) một lần cho nhóm. Giá trị lớn hơn tạo ra nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi chiều rộng khoảng cách và chỉ lưu bản trình bày cuối cùng:

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

Tất cả các loại biểu đồ được liệt kê trong kiểu liệt kê [ChartType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng chuỗi của chúng không phải lúc nào cũng có cùng cấu trúc giá trị hoặc cùng cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ scatter sử dụng giá trị X và Y, và biểu đồ bong bóng còn thêm kích thước bong bóng. Hãy sử dụng phương pháp tạo điểm dữ liệu tương ứng với loại chuỗi. Các tùy chọn như độ trùng lấp và chiều rộng khoảng cách chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm chuỗi biểu đồ là gì?**

Một [IChartSeriesGroup](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/) chứa các chuỗi tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một chuỗi không nhất thiết làm thay đổi mọi chuỗi trong biểu đồ.

**Biểu đồ mới tạo có dữ liệu mặc định không?**

Có. Mặc định, [IShapeCollection::AddChart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addchart/) tạo các chuỗi, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả hai bộ sưu tập chuỗi và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ mà không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu tới các ô trong một [IChartDataWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật thành phần biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ cho các hàng danh mục và các hàng giá trị chuỗi căn chỉnh để mỗi điểm được vẽ dưới danh mục mong muốn.

**Làm sao để xóa một điểm mà không xóa toàn bộ chuỗi?**

Đặt ô giá trị tương ứng thành `nullptr` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ gọi [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) khi bạn muốn xóa tất cả các điểm trong chuỗi đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi chuỗi để các giá trị vẫn đồng bộ với bộ sưu tập danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Các biểu đồ được hỗ trợ có thể hiển thị các điểm trống dưới dạng khoảng trống, giá trị zero, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình bày của bạn.

**Giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bong bóng được hỗ trợ, gọi [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) và đặt màu qua [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Bạn có thể ghi đè hành vi này cho một điểm riêng lẻ bằng [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Các phương thức này ảnh hưởng đến định dạng, không phải các giá trị số được lưu.

**Định dạng nào thắng khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng có ưu tiên cho điểm đó. Các điểm khác tiếp tục sử dụng định dạng chuỗi rõ ràng hoặc, nếu chuỗi không có định dạng, sử dụng kiểu biểu đồ và giao diện tự động. Các cài đặt nhóm như độ trùng lấp và chiều rộng khoảng cách kiểm soát bố cục và không phải là các ghi đè định dạng ở mức điểm.

**Có giới hạn về số chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng cho số chuỗi. Trong thực tế, các ràng buộc của tệp trình chiếu, bộ nhớ khả dụng, thời gian render và khả năng đọc của biểu đồ quyết định giới hạn hữu dụng.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa nhau?**

Gọi [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) trên nhóm chuỗi cha thích hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm giá trị để đưa các cụm lại gần nhau hơn.