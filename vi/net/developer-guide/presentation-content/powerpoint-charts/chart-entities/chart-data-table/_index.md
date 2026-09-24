---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong các bản trình chiếu .NET
linktitle: Bảng dữ liệu
type: docs
url: /vi/net/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tùy chỉnh phông chữ, viền và chìa khóa chú giải của bảng dữ liệu biểu đồ trong các bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides cho .NET và C#."
---
## **Tổng quan**

Aspose.Slides for .NET cho phép bạn hiển thị bảng dữ liệu của biểu đồ và tùy chỉnh định dạng văn bản, viền và chìa khóa chú giải. Bài viết này giải thích cách bật bảng, định dạng văn bản, điều khiển từng loại viền và hiển thị hoặc ẩn chìa khóa chú giải. Các ví dụ lưu các biểu đồ đã cấu hình vào tệp PPTX.

## **Đặt Thuộc Tính Phông Chữ**

Để hiển thị bảng dữ liệu của biểu đồ, đặt [HasDataTable](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/hasdatatable/) thành `true`. Sử dụng [ChartDataTable](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/chartdatatable/) để truy cập bảng và cấu hình định dạng văn bản.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
1. Thêm biểu đồ cột nhóm vào slide đầu tiên.
1. Bật bảng dữ liệu của biểu đồ.
1. Bật văn bản in đậm với [FontBold](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/fontbold/) và đặt [FontHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/fontheight/) thành `20` cho văn bản 20 điểm.
1. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ sau yêu cầu tệp `test.pptx` trong thư mục làm việc có ít nhất một slide. Nó thêm một biểu đồ với dữ liệu mặc định ở vị trí (50, 50), có chiều rộng 600 điểm và chiều cao 400 điểm. Tệp `output.pptx` đã lưu chứa biểu đồ với bảng dữ liệu được bật và các thiết lập phông chữ đã chỉ định được áp dụng.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Tùy Chỉnh Viền Bảng Dữ Liệu**

Bật bảng bằng [IChart.HasDataTable](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/hasdatatable/) và truy cập nó qua [IChart.ChartDataTable](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/chartdatatable/). Bạn có thể kiểm soát ba loại viền một cách độc lập:

- [HasBorderHorizontal](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/idatatable/hasborderhorizontal/) kiểm soát viền ô ngang.
- [HasBorderVertical](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/idatatable/hasbordervertical/) kiểm soát viền ô dọc.
- [HasBorderOutline](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/idatatable/hasborderoutline/) kiểm soát viền ngoài của bảng.

Đặt mỗi thuộc tính thành `true` để hiển thị viền hoặc `false` để ẩn. Ví dụ sau tạo một biểu đồ cột nhóm với dữ liệu mặc định, hiển thị viền ngang và viền ngoài, và ẩn viền dọc. Không yêu cầu tệp đầu vào. Vị trí và kích thước của biểu đồ được chỉ định bằng điểm.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

So sánh dưới đây sử dụng cùng một dữ liệu biểu đồ và thiết lập chìa khóa chú giải trong cả bốn trường hợp. Bắt đầu với tất cả viền được bật, mỗi biến thể còn lại chỉ tắt một thuộc tính viền. Biến thể góc dưới bên trái khớp với các thiết lập viền trong ví dụ.

![Bảng dữ liệu biểu đồ với tất cả viền được bật, không viền ngang, không viền dọc và không viền ngoài](data-table-borders.png)

## **Hiển Thị Hoặc Ẩn Chìa Khóa Chú Giải**

Chìa khóa chú giải là các dấu màu nhỏ bên cạnh tên chuỗi trong bảng dữ liệu. Chúng giúp người đọc khớp mỗi hàng bảng với một chuỗi biểu đồ. Đặt [ShowLegendKey](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/idatatable/showlegendkey/) thành `true` để hiển thị các dấu này hoặc `false` để ẩn chúng.

Chú giải riêng của biểu đồ được điều khiển bởi [IChart.HasLegend](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/haslegend/). Các thiết lập này độc lập: ẩn chú giải riêng sẽ không ẩn các chìa khóa trong bảng dữ liệu, và ẩn chìa khóa trong bảng sẽ không ẩn chú giải riêng.

Ví dụ sau tạo một biểu đồ với dữ liệu mặc định, bật bảng dữ liệu và hiển thị chìa khóa chú giải bên trong trong khi ẩn chú giải riêng. Tất cả viền bảng đều được bật rõ ràng. Không yêu cầu bản trình chiếu đầu vào. Để chỉ ẩn chìa khóa của bảng, đổi `dataTable.ShowLegendKey` thành `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

So sánh dưới đây cho thấy cùng một bảng với chìa khóa chú giải được bật và tắt. Tất cả viền vẫn được bật, và chú giải riêng của biểu đồ bị ẩn trong cả hai trường hợp.

![Bảng dữ liệu biểu đồ với chìa khóa chú giải hiển thị ở bên trái và ẩn ở bên phải](data-table-legend-keys.png)

## **FAQ**

**Tôi có thể hiển thị chìa khóa chú giải trong bảng dữ liệu của biểu đồ không?**

Có. Đặt [ShowLegendKey](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/datatable/showlegendkey/) thành `true` để hiển thị chìa khóa chú giải hoặc thành `false` để ẩn chúng.

**Bảng dữ liệu có được giữ nguyên khi xuất bản trình chiếu sang PDF, HTML hoặc ảnh không?**

Có. Aspose.Slides sẽ render biểu đồ và bảng dữ liệu đã hiển thị như một phần của slide khi xuất sang [PDF](/slides/vi/net/convert-powerpoint-to-pdf/), [HTML](/slides/vi/net/convert-powerpoint-to-html/) hoặc [images](/slides/vi/net/convert-powerpoint-to-png/).

**Tôi có thể làm việc với bảng dữ liệu trong biểu đồ được tải từ mẫu không?**

Có. Đối với biểu đồ được tải từ bản trình chiếu hoặc mẫu hiện có, sử dụng [HasDataTable](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/hasdatatable/) để kiểm tra hoặc thay đổi việc bảng dữ liệu có được hiển thị hay không.

**Làm sao tôi có thể tìm các biểu đồ có bảng dữ liệu được bật?**

Duyệt qua các hình dạng trên mỗi slide, xác định các biểu đồ và kiểm tra thuộc tính [HasDataTable](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/hasdatatable/) của chúng. Giá trị `true` cho biết bảng dữ liệu đã được bật.