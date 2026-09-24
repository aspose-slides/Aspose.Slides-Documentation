---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong các bản trình chiếu bằng C++
linktitle: Bảng dữ liệu
type: docs
url: /vi/cpp/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tùy chỉnh phông chữ, đường viền và các ký hiệu chú giải của bảng dữ liệu biểu đồ trong các bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides cho C++."
---
## **Overview**

Aspose.Slides cho C++ cho phép bạn hiển thị bảng dữ liệu của biểu đồ và tùy chỉnh định dạng văn bản, đường viền và các ký hiệu chú giải. Bài viết này giải thích cách bật bảng, định dạng văn bản, kiểm soát từng loại đường viền và hiển thị hoặc ẩn các ký hiệu chú giải. Các ví dụ lưu biểu đồ đã cấu hình dưới dạng tệp PPTX.

## **Set Font Properties**

Để hiển thị bảng dữ liệu của biểu đồ, truyền `true` vào [IChart::set_HasDataTable](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Sử dụng [IChart::get_ChartDataTable](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/get_chartdatatable/) để truy cập bảng và cấu hình định dạng văn bản của nó.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Thêm một biểu đồ cột nhóm vào slide đầu tiên.
1. Bật bảng dữ liệu của biểu đồ.
1. Bật chữ đậm với [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_fontbold/) và truyền `20` vào [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_fontheight/) để có văn bản 20 điểm.
1. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ sau yêu cầu có tệp `test.pptx` trong thư mục làm việc với ít nhất một slide. Nó thêm một biểu đồ với dữ liệu mặc định tại vị trí (50, 50), có độ rộng 600 điểm và chiều cao 400 điểm. Tệp `output.pptx` đã lưu chứa biểu đồ với bảng dữ liệu được bật và các thiết lập phông chữ đã chỉ định được áp dụng.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Customize Data Table Borders**

Bật bảng bằng [IChart::set_HasDataTable](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/set_hasdatatable/) và truy cập nó qua [IChart::get_ChartDataTable](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/get_chartdatatable/). Bạn có thể điều khiển ba loại đường viền một cách độc lập:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) kiểm soát đường viền ngang của ô.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) kiểm soát đường viền dọc của ô.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) kiểm soát đường viền bao ngoài của bảng.

Truyền `true` vào mỗi setter để hiển thị đường viền tương ứng hoặc `false` để ẩn chúng. Ví dụ sau tạo một biểu đồ cột nhóm với dữ liệu mặc định, hiển thị đường viền ngang và đường viền bao ngoài, và ẩn đường viền dọc. Nó không yêu cầu tệp đầu vào. Vị trí và kích thước của biểu đồ được chỉ định bằng điểm.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

So sánh dưới đây sử dụng cùng một dữ liệu biểu đồ và thiết lập ký hiệu chú giải trong bốn trường hợp. Bắt đầu với tất cả các đường viền được bật, mỗi biến thể còn lại chỉ tắt một thiết lập đường viền. Biến thể ở góc trái dưới khớp với các thiết lập đường viền trong ví dụ.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Show or Hide Legend Keys**

Các ký hiệu chú giải là các dấu màu nhỏ bên cạnh tên chuỗi trong bảng dữ liệu. Chúng giúp người đọc ghép mỗi hàng bảng với một chuỗi biểu đồ. Truyền `true` vào [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) để hiển thị các ký hiệu này hoặc `false` để ẩn chúng.

Chú giải riêng của biểu đồ được điều khiển bởi [IChart::set_HasLegend](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/set_haslegend/). Các thiết lập này độc lập: ẩn chú giải riêng sẽ không ẩn các ký hiệu trong bảng dữ liệu, và ẩn các ký hiệu trong bảng sẽ không ẩn chú giải riêng.

Ví dụ sau tạo một biểu đồ với dữ liệu mặc định, bật bảng dữ liệu và hiển thị các ký hiệu chú giải bên trong bảng trong khi ẩn chú giải riêng. Tất cả các đường viền của bảng đều được bật rõ ràng. Không cần bản trình chiếu đầu vào. Để chỉ ẩn các ký hiệu của bảng, truyền `false` vào [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

So sánh dưới đây hiển thị cùng một bảng với các ký hiệu chú giải được bật và tắt. Tất cả các đường viền vẫn được bật, và chú giải riêng của biểu đồ được ẩn trong cả hai trường hợp.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **FAQ**

**Can I show legend keys in a chart's data table?**

Có. Truyền `true` vào [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) để hiển thị các ký hiệu chú giải hoặc `false` để ẩn chúng.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Có. Aspose.Slides sẽ render biểu đồ và bảng dữ liệu đã hiển thị như một phần của slide khi xuất sang [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/vi/cpp/convert-powerpoint-to-html/) hoặc [images](/slides/vi/cpp/convert-powerpoint-to-png/).

**Can I work with data tables in charts loaded from a template?**

Có. Đối với biểu đồ được tải từ một bản trình chiếu hoặc mẫu hiện có, sử dụng [IChart::get_HasDataTable](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/get_hasdatatable/) để kiểm tra bảng dữ liệu có được hiển thị hay không và [IChart::set_HasDataTable](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/set_hasdatatable/) để thay đổi trạng thái hiển thị.

**How can I find charts that have a data table enabled?**

Duyệt qua các shape trên mỗi slide, xác định các biểu đồ và kiểm tra kết quả của [IChart::get_HasDataTable](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Giá trị `true` cho biết bảng dữ liệu của biểu đồ đã được bật.