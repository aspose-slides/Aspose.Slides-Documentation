---
title: Tùy chỉnh Chú giải Biểu đồ trong Bài thuyết trình bằng C++
linktitle: Chú giải Biểu đồ
type: docs
url: /vi/cpp/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho C++ để tối ưu hoá các bài thuyết trình PowerPoint với định dạng chú giải được thiết kế riêng."
---
## **Tổng quan**

Aspose.Slides for C++ cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong bài thuyết trình PowerPoint. Bài viết này cho thấy cách đặt vị trí và kích thước của chú giải, thiết lập kích thước phông chữ cho toàn bộ chú giải, định dạng một mục chú giải riêng lẻ, và ẩn hoặc khôi phục các mục đã chọn.

Phần Câu hỏi thường gặp đề cập đến các hành vi liên quan, bao gồm việc dự trữ không gian cho chú giải, hiển thị nhãn đa dòng và kế thừa định dạng từ chủ đề của bài thuyết trình.

## **Định vị chú giải**

Sử dụng các phương thức [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/), và [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) của chú giải để chỉ định vị trí và kích thước của nó dưới dạng phần tỷ lệ của các kích thước biểu đồ.

Ví dụ này tạo một bài thuyết trình và thêm một biểu đồ cột nhóm với dữ liệu mặc định vào slide đầu tiên. Việc chia các độ lệch và kích thước chú giải mong muốn cho chiều rộng và chiều cao của biểu đồ sẽ chuyển chúng thành các giá trị tương đối: chú giải được dịch 50 điểm so với góc trên‑trái của biểu đồ và có kích thước 100 × 100 điểm.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Đặt kích thước phông chữ cho chú giải**

Sử dụng [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) của chú giải để truy cập định dạng văn bản và sử dụng [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) để đặt kích thước phông chữ tính bằng điểm.

Ví dụ này tạo một biểu đồ với dữ liệu mặc định và đặt văn bản chú giải thành 20 điểm. Nó cũng tắt giới hạn tự động cho trục dọc và đặt khoảng giá trị từ -5 đến 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Đặt kích thước phông chữ cho một mục chú giải riêng lẻ**

Sử dụng tập hợp trả về bởi phương thức [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) của chú giải để truy cập định dạng cho một mục cụ thể. Chỉ mục mục nhập dựa trên chỉ số 0, vì vậy chỉ số `1` đề cập đến mục thứ hai.

Ví dụ này tạo một biểu đồ cột nhóm trong đó dữ liệu mặc định bao gồm ít nhất hai chuỗi. Nó định dạng mục chú giải thứ hai với văn bản in đậm, in nghiêng và màu xanh 20 điểm.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Ẩn các mục chú giải riêng lẻ**

Để loại bỏ một chuỗi phụ khỏi chú giải trong khi vẫn giữ dữ liệu của nó hiển thị, gọi [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) với `true` thông qua [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Điều này chỉ ẩn mục chú giải đã chọn; nó không xóa chuỗi hoặc các điểm dữ liệu của nó. Ngược lại, gọi [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) với `false` sẽ ẩn toàn bộ chú giải.

Ví dụ dưới đây tạo một biểu đồ cột nhóm với nhiều chuỗi sử dụng dữ liệu mặc định. Nó ẩn mục chú giải của chuỗi thứ hai (chỉ số `1`) và lưu bài thuyết trình. Sau đó nó khôi phục mục này bằng cách gọi `set_Hide` với `false` và lưu một bản sao thứ hai. Các cột vẫn hiển thị trong cả hai tệp.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Khôi phục mục giống nhau mà không thay đổi dữ liệu biểu đồ.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

So sánh bên dưới cho thấy cùng một biểu đồ với tất cả các mục đều hiển thị và với mục thứ hai bị ẩn. Các cột của chuỗi thứ hai vẫn không thay đổi.

![So sánh một biểu đồ với tất cả các mục chú giải hiện ra và với Series 2 bị ẩn khỏi chú giải; tất cả các cột vẫn hiển thị.](hide-legend-entry.png)

Trong các biểu đồ cột, thanh và đường, các mục chú giải xác định các chuỗi. Đối với biểu đồ tròn, chúng xác định các điểm dữ liệu riêng lẻ (mảnh), vì vậy hãy sử dụng [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) trên mảnh được chọn thay thế. API ghi lại phương thức điểm dữ liệu này cho các loại biểu đồ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` và `BarOfPie`. Đừng cho rằng nó áp dụng cho biểu đồ vòng bán, những loại không có trong danh sách đó.

## **Câu hỏi thường gặp**

**Có thể làm cho biểu đồ dự trữ không gian cho chú giải thay vì chồng lên nó không?**

Có. Gọi [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) với `false` để dự trữ không gian cho chú giải thay vì cho phép nó chồng lên khu vực vẽ.

**Có thể tạo nhãn chú giải đa dòng không?**

Có. Nhãn dài có thể xuống dòng khi chiều rộng khả dụng không đủ. Bạn cũng có thể sử dụng ký tự xuống dòng trong tên chuỗi để yêu cầu ngắt dòng.

**Làm sao để chú giải tuân theo bảng màu của chủ đề bài thuyết trình?**

Để lại các màu, tô và phông chữ của chú giải chưa được đặt để nó có thể kế thừa định dạng từ chủ đề. Định dạng rõ ràng sẽ ghi đè lên các cài đặt chủ đề tương ứng.