---
title: Tùy chỉnh vùng vẽ của biểu đồ trong bản trình chiếu bằng Python
linktitle: Vùng vẽ
type: docs
url: /vi/python-net/chart-plot-area/
keywords:
- biểu đồ
- vùng vẽ
- độ rộng vùng vẽ
- độ cao vùng vẽ
- kích thước vùng vẽ
- chế độ bố cục
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khám phá cách tùy chỉnh vùng vẽ của biểu đồ trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET. Nâng cao hình ảnh slide của bạn một cách dễ dàng."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với vùng vẽ (plot area) của biểu đồ trong Aspose.Slides. Nó giải thích cách lấy vị trí và kích thước thực tế của vùng vẽ bằng cách xác thực bố cục biểu đồ và sau đó đọc các giá trị X, Y, chiều rộng và chiều cao của nó.

Nó cũng trình bày cách cấu hình chế độ bố cục của vùng vẽ khi bố cục được thiết lập thủ công, sử dụng `LayoutTargetType` để xác định vùng vẽ được tính dựa trên khu vực bên trong hay khu vực bên ngoài cùng với các trục và nhãn trục.

## **Lấy Chiều Rộng, Chiều Cao của Vùng Vẽ Biểu Đồ**
Aspose.Slides for Python qua .NET cung cấp một API đơn giản cho .

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/)
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Gọi phương thức IChart.ValidateChartLayout() trước để lấy các giá trị thực tế.
5. Lấy vị trí X thực tế (trái) của phần tử biểu đồ so với góc trên bên trái của biểu đồ.
6. Lấy vị trí trên thực tế của phần tử biểu đồ so với góc trên bên trái của biểu đồ.
7. Lấy chiều rộng thực tế của phần tử biểu đồ.
8. Lấy chiều cao thực tế của phần tử biểu đồ.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Lưu bản trình chiếu với biểu đồ
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Đặt Chế Độ Bố Cục của Vùng Vẽ Biểu Đồ**
Aspose.Slides for Python qua .NET cung cấp một API đơn giản để đặt chế độ bố cục của vùng vẽ biểu đồ. Thuộc tính **LayoutTargetType** đã được thêm vào các lớp **ChartPlotArea** và **IChartPlotArea**. Nếu bố cục của vùng vẽ được định nghĩa thủ công, thuộc tính này xác định việc bố trí vùng vẽ theo bên trong (không bao gồm trục và nhãn trục) hay bên ngoài (bao gồm trục và nhãn trục). Có hai giá trị có thể được định nghĩa trong enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - chỉ định rằng kích thước vùng vẽ sẽ quyết định kích thước của vùng vẽ, không bao gồm các dấu tick và nhãn trục.
- **LayoutTargetType.Outer** - chỉ định rằng kích thước vùng vẽ sẽ quyết định kích thước của vùng vẽ, các dấu tick và nhãn trục.

Mã mẫu được đưa dưới đây.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu Hỏi Thường Gặp**

**Các đơn vị của actual_x, actual_y, actual_width và actual_height là gì?**

Trong điểm; 1 inch = 72 điểm. Đây là đơn vị tọa độ của Aspose.Slides.

**Vùng Vẽ (Plot Area) khác với Vùng Biểu Đồ (Chart Area) như thế nào về nội dung?**

Vùng Vẽ là khu vực vẽ dữ liệu (chuỗi, lưới, đường xu hướng, v.v.); Vùng Biểu Đồ bao gồm các yếu tố bao quanh (tiêu đề, chú giải, v.v.). Trong biểu đồ 3D, Vùng Vẽ còn bao gồm các tường/sàn và các trục.

**Khi bố cục được thiết lập thủ công, X, Y, Width và Height của Vùng Vẽ được hiểu như thế nào?**

Chúng là các tỷ lệ (0–1) của kích thước tổng thể của biểu đồ; trong chế độ này, việc định vị tự động bị tắt và các tỷ lệ bạn thiết lập sẽ được áp dụng.

**Tại sao vị trí của Vùng Vẽ thay đổi sau khi thêm/di chuyển chú giải?**

Chú giải nằm trong vùng biểu đồ bên ngoài Vùng Vẽ nhưng ảnh hưởng đến bố cục và không gian khả dụng, vì vậy Vùng Vẽ có thể dịch chuyển khi chế độ định vị tự động đang hoạt động. (Đây là hành vi tiêu chuẩn của biểu đồ PowerPoint.)