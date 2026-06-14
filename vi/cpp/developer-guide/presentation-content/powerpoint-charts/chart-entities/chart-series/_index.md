---
title: Quản lý Series dữ liệu biểu đồ trong bản thuyết trình bằng С++
linktitle: Series dữ liệu
type: docs
url: /vi/cpp/chart-series/
keywords:
- series biểu đồ
- chồng chập series
- màu series
- màu danh mục
- tên series
- điểm dữ liệu
- khoảng cách series
- PowerPoint
- bản thuyết trình
- С++
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ trong С++ cho PowerPoint (PPT/PPTX) với các ví dụ mã thực tế và các thực tiễn tốt nhất để nâng cao bản trình bày dữ liệu của bạn."
---
## **Tổng quan**

Bài viết này mô tả vai trò của [ChartSeries](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts.chartseries/) trong Aspose.Slides, tập trung vào cách dữ liệu được cấu trúc và hiển thị trong các bản thuyết trình. Các đối tượng này cung cấp các phần tử nền tảng xác định các tập hợp điểm dữ liệu, danh mục và các tham số hiển thị trong biểu đồ. Khi làm việc với [ChartSeries](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts.chartseries/), các nhà phát triển có thể tích hợp liền mạch các nguồn dữ liệu cơ bản và duy trì kiểm soát hoàn toàn cách thông tin được hiển thị, tạo ra các bản thuyết trình động, dựa trên dữ liệu, truyền đạt rõ ràng các thông tin chi tiết và phân tích.

Một series là một hàng hoặc cột các số được vẽ trên biểu đồ.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt độ chồng chập của Series dữ liệu**

Với phương thức [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb), bạn có thể chỉ định mức độ chồng chập của các thanh và cột trên biểu đồ 2D (phạm vi: -100 đến 100). Thuộc tính này áp dụng cho tất cả series trong nhóm series cha: đây là một phép chiếu của thuộc tính nhóm thích hợp.

Sử dụng phương thức `get_ParentSeriesGroup()::set_Overlap()` để đặt giá trị mong muốn cho `Overlap`.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Thêm biểu đồ cột nhóm vào một slide.
3. Truy cập series biểu đồ đầu tiên.
4. Truy cập `ParentSeriesGroup` của series biểu đồ và đặt giá trị chồng chập mong muốn cho series.
5. Ghi bản thuyết trình đã chỉnh sửa vào tệp PPTX.

Đoạn mã C++ này cho bạn thấy cách đặt độ chồng chập cho một series biểu đồ:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Thêm biểu đồ
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Đặt chồng chập series
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Ghi tệp bản thuyết trình ra đĩa
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Thay đổi màu của Series dữ liệu**

Aspose.Slides cho C++ cho phép bạn thay đổi màu của một series theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Thêm biểu đồ vào slide.
3. Truy cập series mà bạn muốn thay đổi màu.
4. Đặt kiểu tô và màu tô mong muốn.
5. Lưu bản thuyết trình đã chỉnh sửa.

Đoạn mã C++ này cho bạn thấy cách thay đổi màu của một series:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Thay đổi màu của Danh mục Series dữ liệu**

Aspose.Slides cho C++ cho phép bạn thay đổi màu của một danh mục series theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Thêm biểu đồ vào slide.
3. Truy cập danh mục series mà bạn muốn thay đổi màu.
4. Đặt kiểu tô và màu tô mong muốn.
5. Lưu bản thuyết trình đã chỉnh sửa.

Đoạn mã C++ này cho bạn thấy cách thay đổi màu của một danh mục series:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Thay đổi Tên của Series dữ liệu**

Mặc định, tên trong chú giải cho một biểu đồ là nội dung của các ô nằm trên mỗi cột hoặc hàng dữ liệu.

Trong ví dụ của chúng tôi (hình mẫu),

* các cột là *Series 1*, *Series 2* và *Series 3*;
* các hàng là *Category 1*, *Category 2*, *Category 3* và *Category 4*.

Aspose.Slides cho C++ cho phép bạn cập nhật hoặc thay đổi tên của một series trong dữ liệu biểu đồ và chú giải của nó.

Đoạn mã C++ này cho bạn thấy cách thay đổi tên của một series trong `ChartDataWorkbook` của dữ liệu biểu đồ:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Đoạn mã C++ này cho bạn thấy cách thay đổi tên của một series trong chú giải thông qua `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Đặt Màu Tô Tự Động cho Series dữ liệu**

Aspose.Slides cho C++ cho phép bạn đặt màu tô tự động cho các series biểu đồ trong khu vực vẽ theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu đến một slide theo chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định dựa trên loại muốn dùng (trong ví dụ dưới, chúng tôi sử dụng `ChartType::ClusteredColumn`).
4. Truy cập series biểu đồ và đặt màu tô thành Automatic.
5. Lưu bản thuyết trình vào tệp PPTX.

Đoạn mã C++ này cho bạn thấy cách đặt màu tô tự động cho một series biểu đồ:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Tạo biểu đồ cột nhóm
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Đặt định dạng tô series thành tự động
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Ghi tệp bản thuyết trình ra đĩa
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Đặt Màu Tô Đảo Ngược cho Series dữ liệu**

Aspose.Slides cho phép bạn đặt màu tô đảo ngược cho các series biểu đồ trong khu vực vẽ theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu đến một slide theo chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định dựa trên loại muốn dùng (trong ví dụ dưới, chúng tôi sử dụng `ChartType::ClusteredColumn`).
4. Truy cập series biểu đồ và đặt màu tô thành invert.
5. Lưu bản thuyết trình vào tệp PPTX.

Đoạn mã C++ này minh họa thao tác:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Đặt Màu Tô Đảo Ngược cho Một Series Biểu đồ**

Aspose.Slides cho phép bạn thiết lập đảo ngược thông qua các phương thức `IChartDataPoint::set_InvertIfNegative()` và `ChartDataPoint.set_InvertIfNegative()`. Khi thiết lập đảo ngược bằng các phương thức này, điểm dữ liệu sẽ đổi màu khi nhận được giá trị âm.

Đoạn mã C++ này minh họa thao tác:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Xóa Giá trị Điểm Dữ liệu Cụ thể**

Aspose.Slides cho C++ cho phép bạn xóa dữ liệu `DataPoints` của một series biểu đồ cụ thể theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu đến một slide qua chỉ số của nó.
3. Lấy tham chiếu đến một biểu đồ qua chỉ số của nó.
4. Duyệt toàn bộ `DataPoints` của biểu đồ và đặt `XValue` và `YValue` thành null.
5. Xóa toàn bộ `DataPoints` cho series biểu đồ cụ thể.
6. Ghi bản thuyết trình đã chỉnh sửa vào tệp PPTX.

Đoạn mã C++ này minh họa thao tác:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Đặt Độ Rộng Khoảng Cách của Series dữ liệu**

Aspose.Slides cho C++ cho phép bạn đặt Độ Rộng Khoảng Cách (Gap Width) của một series thông qua phương thức **`set_GapWidth()`** theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Truy cập bất kỳ series nào của biểu đồ.
5. Đặt thuộc tính `GapWidth`.
6. Ghi bản thuyết trình đã chỉnh sửa vào tệp PPTX.

Đoạn mã C++ này cho bạn thấy cách đặt Độ Rộng Khoảng Cách cho một series:

```cpp
// Tạo bản thuyết trình rỗng 
auto presentation = System::MakeObject<Presentation>();

// Truy cập slide đầu tiên của bản thuyết trình
auto slide = presentation->get_Slides()->idx_get(0);

// Thêm biểu đồ với dữ liệu mặc định
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Đặt chỉ mục của bảng dữ liệu biểu đồ
int32_t worksheetIndex = 0;

// Lấy worksheet dữ liệu biểu đồ
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Thêm series
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Thêm danh mục
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Lấy series biểu đồ thứ hai
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Điền dữ liệu cho series
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Đặt giá trị GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Lưu bản thuyết trình vào đĩa
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **Câu hỏi Thường gặp**

**Có giới hạn số lượng series mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt giới hạn cố định về số series bạn có thể thêm. Giới hạn thực tế bị quyết định bởi khả năng đọc biểu đồ và bộ nhớ có sẵn cho ứng dụng của bạn.

**Nếu các cột trong một cụm quá gần nhau hoặc quá xa nhau thì sao?**

Điều chỉnh cài đặt Gap Width cho series đó (hoặc cho nhóm series cha). Tăng giá trị sẽ làm rộng khoảng cách giữa các cột, trong khi giảm giá trị sẽ làm chúng gần nhau hơn.