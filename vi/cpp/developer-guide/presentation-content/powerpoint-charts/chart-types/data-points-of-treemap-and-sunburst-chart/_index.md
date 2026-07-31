---
title: Tùy chỉnh các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst bằng C++
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
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách quản lý các điểm dữ liệu trong biểu đồ treemap và sunburst với Aspose.Slides cho C++, tương thích với định dạng PowerPoint."
---
## **Giới thiệu**

Trong số các loại biểu đồ PowerPoint khác, có hai loại “phân cấp” - **Treemap** và **Sunburst** chart (còn được gọi là Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph hoặc Multi Level Pie Chart). Các biểu đồ này hiển thị dữ liệu phân cấp được tổ chức dạng cây - từ lá đến đầu nhánh. Lá được xác định bằng các điểm dữ liệu của series, và mỗi mức nhóm lồng nhau tiếp theo được xác định bởi danh mục tương ứng. Aspose.Slides for C++ cho phép định dạng các điểm dữ liệu của Biểu đồ Sunburst và Treemap trong C++.

Đây là một biểu đồ Sunburst, trong đó dữ liệu trong cột Series1 định nghĩa các nút lá, trong khi các cột khác định nghĩa các điểm dữ liệu phân cấp:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Hãy bắt đầu bằng việc thêm một biểu đồ Sunburst mới vào bản trình chiếu:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Xem thêm" %}} 
- [**Creating Sunburst Chart**](/slides/vi/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Nếu cần định dạng các điểm dữ liệu của biểu đồ, chúng ta nên sử dụng những thứ sau:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/) classes và [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) method cung cấp quyền truy cập để định dạng các điểm dữ liệu của Treemap và Sunburst charts.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) được sử dụng để truy cập các danh mục đa cấp - nó đại diện cho bộ chứa các đối tượng [**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/). 
Cơ bản nó là một wrapper cho [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) với các thuộc tính được thêm vào riêng cho các điểm dữ liệu. 
Lớp [**IChartDataPointLevel**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/) có hai phương thức: [**get_Format()**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) và [**get_Label()**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) cung cấp quyền truy cập tới các cài đặt tương ứng.

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

**Tôi có thể thay đổi thứ tự (sắp xếp) của các đoạn trong Sunburst/Treemap không?**

Không. PowerPoint tự động sắp xếp các đoạn (thông thường theo giá trị giảm dần, theo chiều kim đồng hồ). Aspose.Slides phản chiếu hành vi này: bạn không thể thay đổi thứ tự trực tiếp; bạn phải thực hiện bằng cách tiền xử lý dữ liệu.

**Chủ đề của bản trình chiếu ảnh hưởng như thế nào đến màu của các đoạn và nhãn?**

Màu của biểu đồ kế thừa [chủ đề/bảng màu](/slides/vi/cpp/presentation-theme/) của bản trình chiếu trừ khi bạn đặt màu nền/phông chữ một cách rõ ràng. Để có kết quả nhất quán, hãy cố định màu nền đặc và định dạng văn bản ở các mức cần thiết.

**Xuất ra PDF/PNG có giữ lại màu nhánh tùy chỉnh và cài đặt nhãn không?**

Có. Khi xuất bản trình chiếu, các cài đặt biểu đồ (đổ màu, nhãn) được giữ lại trong các định dạng đầu ra vì Aspose.Slides render với định dạng của biểu đồ đã được áp dụng.

**Tôi có thể tính toán tọa độ thực tế của một nhãn/đối tượng để đặt lớp phủ tùy chỉnh lên trên biểu đồ không?**

Có. Sau khi bố cục biểu đồ được xác thực, giá trị X thực tế và Y thực tế có sẵn cho các đối tượng (ví dụ, một [DataLabel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/datalabel/)), giúp định vị lớp phủ một cách chính xác.