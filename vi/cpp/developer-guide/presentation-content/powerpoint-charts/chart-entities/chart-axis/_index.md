---
title: Tùy chỉnh Trục Biểu đồ trong Bài thuyết trình bằng C++
linktitle: Trục Biểu đồ
type: docs
url: /vi/cpp/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
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
- bài thuyết trình
- C++
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho C++ để tùy chỉnh trục biểu đồ trong các bài thuyết trình PowerPoint cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các trục biểu đồ trong Aspose.Slides. Nó chỉ ra cách lấy giá trị thực tế của trục, hoán đổi dữ liệu giữa các trục, ẩn trục dọc hoặc ngang cho biểu đồ đường, thay đổi loại trục danh mục, đặt định dạng ngày cho các giá trị trục danh mục, xoay tiêu đề trục, đặt vị trí trục và hiển thị nhãn đơn vị trên trục giá trị.

## **Lấy Giá Trị Tối Đa Trên Trục Dọc**
Aspose.Slides for C++ cho phép bạn lấy giá trị tối thiểu và tối đa trên trục dọc. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
1. Truy cập slide đầu tiên.
1. Thêm một biểu đồ với dữ liệu mặc định.
1. Lấy giá trị tối đa thực tế trên trục.
1. Lấy giá trị tối thiểu thực tế trên trục.
1. Lấy đơn vị chính thực tế của trục.
1. Lấy đơn vị phụ thực tế của trục.
1. Lấy tỷ lệ đơn vị chính thực tế của trục.
1. Lấy tỷ lệ đơn vị phụ thực tế của trục.

Mã mẫu—các bước được thực hiện ở trên—cho bạn thấy cách lấy các giá trị cần thiết trong C++:

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

// Lưu bản trình chiếu
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```


## **Hoán Đổi Dữ Liệu Giữa Các Trục**
Aspose.Slides cho phép bạn nhanh chóng hoán đổi dữ liệu giữa các trục—dữ liệu trên trục dọc (trục y) chuyển sang trục ngang (trục x) và ngược lại. 

Mã C++ này cho bạn thấy cách thực hiện việc hoán đổi dữ liệu giữa các trục trên một biểu đồ:

``` cpp
// Tạo bản trình chiếu trống
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Chuyển đổi hàng và cột
chart->get_ChartData()->SwitchRowColumn();

// Lưu bản trình chiếu
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Vô Hiệu Hóa Trục Dọc cho Biểu Đồ Đường**

Mã C++ này cho bạn thấy cách ẩn trục dọc cho một biểu đồ đường:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Vô Hiệu Hóa Trục Ngang cho Biểu Đồ Đường**

Mã này cho bạn thấy cách ẩn trục ngang cho một biểu đồ đường:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Thay Đổi Trục Danh Mục**

Bằng phương thức **set_CategoryAxisType()**, bạn có thể chỉ định loại trục danh mục ưa thích (**date** hoặc **text**). Đoạn mã C++ sau minh họa thao tác này: 

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

## **Đặt Định Dạng Ngày cho Giá Trị Trục Danh Mục**
Aspose.Slides for C++ cho phép bạn đặt định dạng ngày cho một giá trị trục danh mục. Hoạt động này được minh họa trong đoạn mã C++ sau:

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

## **Đặt Góc Xoay cho Tiêu Đề Trục**
Aspose.Slides for C++ cho phép bạn đặt góc xoay cho tiêu đề trục biểu đồ. Đoạn mã C++ này minh họa hoạt động:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Đặt Vị Trí Trục trên Trục Danh Mục hoặc Giá Trị**
Aspose.Slides for C++ cho phép bạn đặt vị trí trục trong một trục danh mục hoặc giá trị. Đoạn mã C++ này cho thấy cách thực hiện nhiệm vụ:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Bật Hiển Thị Nhãn Đơn Vị trên Trục Giá Trị của Biểu Đồ**
Aspose.Slides for C++ cho phép bạn cấu hình biểu đồ để hiển thị nhãn đơn vị trên trục giá trị của nó. Đoạn mã C++ này minh họa hoạt động:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Câu Hỏi Thường Gặp**

**Làm thế nào để đặt giá trị mà một trục cắt qua trục còn lại (cắt trục)?**

Các trục cung cấp một [crossing setting](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/axis/set_crosstype/): bạn có thể chọn cắt ở không, ở giá trị danh mục/tối đa, hoặc ở một giá trị số cụ thể. Tùy chọn này hữu ích để kéo trục X lên hoặc xuống hoặc để nhấn mạnh đường cơ sở.

**Làm sao tôi có thể đặt vị trí nhãn đánh dấu so với trục (bên cạnh, bên ngoài, bên trong)?**

Đặt [label position](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/axis/set_majortickmark/) thành "cross", "outside" hoặc "inside". Điều này ảnh hưởng tới khả năng đọc và giúp tiết kiệm không gian, đặc biệt trên các biểu đồ nhỏ.