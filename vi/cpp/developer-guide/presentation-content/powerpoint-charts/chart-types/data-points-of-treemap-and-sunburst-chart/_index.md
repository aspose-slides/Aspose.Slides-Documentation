---
title: Tùy chỉnh các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst bằng С++
linktitle: Các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst
type: docs
url: /vi/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- điểm dữ liệu
- màu nhãn
- màu nhánh
- PowerPoint
- bản trình bày
- С++
- Aspose.Slides
description: "Tìm hiểu cách quản lý các điểm dữ liệu trong biểu đồ treemap và sunburst với Aspose.Slides cho С++, tương thích với các định dạng PowerPoint."
---
## **Giới thiệu**

Trong số các loại biểu đồ PowerPoint, có hai loại “phân cấp” - **Treemap** và **Sunburst** ( còn được gọi là Đồ thị Sunburst, Sơ đồ Sunburst, Biểu đồ bán tròn, Đồ thị bán tròn hoặc Biểu đồ bánh đa cấp ). Những biểu đồ này hiển thị dữ liệu phân cấp được tổ chức dưới dạng cây - từ các lá tới đỉnh nhánh. Các lá được xác định bởi các điểm dữ liệu của series, và mỗi cấp nhóm lồng nhau tiếp theo được xác định bởi danh mục tương ứng. Aspose.Slides for C++ cho phép định dạng các điểm dữ liệu của biểu đồ Sunburst và Treemap trong C++.

Dưới đây là một biểu đồ Sunburst, trong đó dữ liệu trong cột Series1 xác định các nút lá, trong khi các cột khác xác định các điểm dữ liệu phân cấp:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Hãy bắt đầu bằng cách thêm một biểu đồ Sunburst mới vào bản trình bày:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="See also" %}} 
- [**Tạo biểu đồ Sunburst**](/slides/vi/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Nếu cần định dạng các điểm dữ liệu của biểu đồ, chúng ta nên sử dụng những thứ sau:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/) classes and [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) method provide access to format data points of Treemap and Sunburst charts.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) is used for accessing multi-level categories - it represents the container of [**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/) objects. 
Basically it is a wrapper for [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) with the properties added specific for data points. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/) class has two methods: [**get_Format()**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) and [**get_Label()**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) which provide access to corresponding settings.

## **Hiển thị Giá trị Điểm Dữ liệu**
Hiển thị giá trị của điểm dữ liệu "Leaf 4":

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Đặt Nhãn và Màu cho Điểm Dữ liệu**
Đặt nhãn dữ liệu "Branch 1" để hiển thị tên series ("Series1") thay vì tên danh mục. Sau đó đặt màu văn bản thành màu vàng:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Đặt Màu Nhánh cho Điểm Dữ liệu**
Thay đổi màu của nhánh "Stem 4":

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi thứ tự (sắp xếp) của các phân đoạn trong Sunburst/Treemap không?**

Không. PowerPoint tự động sắp xếp các phân đoạn (thông thường theo giá trị giảm dần, theo chiều kim đồng hồ). Aspose.Slides mô phỏng hành vi này: bạn không thể thay đổi thứ tự một cách trực tiếp; bạn phải thực hiện việc này bằng cách tiền xử lý dữ liệu.

**Chủ đề của bản trình bày ảnh hưởng như thế nào đến màu sắc của các phân đoạn và nhãn?**

Màu biểu đồ kế thừa [theme/palette](/slides/vi/cpp/presentation-theme/) của bản trình bày trừ khi bạn đặt màu nền/phông chữ một cách rõ ràng. Để có kết quả nhất quán, hãy cố định các màu nền đặc và định dạng văn bản ở các cấp cần thiết.

**Xuất ra PDF/PNG có giữ lại màu nhánh tùy chỉnh và cài đặt nhãn không?**

Có. Khi xuất bản trình bày, các cài đặt biểu đồ (màu nền, nhãn) được giữ nguyên trong các định dạng đầu ra vì Aspose.Slides render với định dạng biểu đồ đã áp dụng.

**Tôi có thể tính toán tọa độ thực tế của một nhãn/đối tượng để đặt lớp phủ tùy chỉnh lên trên biểu đồ không?**

Có. Sau khi bố cục biểu đồ được xác nhận, giá trị X thực tế và Y thực tế có sẵn cho các phần tử (ví dụ, một [DataLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/datalabel/)), giúp định vị chính xác các lớp phủ.