---
title: Tùy chỉnh Vùng Vẽ của Biểu Đồ trong Bản Trình chiếu bằng C++
linktitle: Vùng Vẽ
type: docs
url: /vi/cpp/chart-plot-area/
keywords:
- biểu đồ
- vùng vẽ
- chiều rộng vùng vẽ
- chiều cao vùng vẽ
- kích thước vùng vẽ
- chế độ bố cục
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá cách tùy chỉnh vùng vẽ của biểu đồ trong bản trình chiếu PowerPoint bằng Aspose.Slides cho C++. Nâng cao hình ảnh slide của bạn một cách dễ dàng."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với vùng vẽ (plot area) của biểu đồ trong Aspose.Slides. Nó giải thích cách lấy vị trí và kích thước thực tế của vùng vẽ bằng cách xác thực bố cục biểu đồ và sau đó đọc các giá trị X, Y, chiều rộng và chiều cao.

Nó cũng trình bày cách cấu hình chế độ bố cục của vùng vẽ khi bố cục được đặt thủ công, sử dụng `LayoutTargetType` để xác định vùng vẽ được tính dựa trên khu vực bên trong hay khu vực bên ngoài cùng với các trục và nhãn trục.

## **Lấy Chiều Rộng và Chiều Cao của Vùng Vẽ Biểu Đồ**
Aspose.Slides for C++ cung cấp một API đơn giản cho .

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Gọi phương thức IChart::ValidateChartLayout() trước để nhận các giá trị thực tế.
5. Lấy vị trí X thực tế (bên trái) của phần tử biểu đồ so với góc trái trên của biểu đồ.
6. Lấy vị trí trên thực tế của phần tử biểu đồ so với góc trái trên của biểu đồ.
7. Lấy chiều rộng thực tế của phần tử biểu đồ.
8. Lấy chiều cao thực tế của phần tử biểu đồ.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Lưu bản trình chiếu với biểu đồ
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Đặt Chế Độ Bố Cục cho Vùng Vẽ Biểu Đồ**
Aspose.Slides for C++ cung cấp một API đơn giản để đặt chế độ bố cục của vùng vẽ biểu đồ. Thuộc tính **LayoutTargetType** đã được thêm vào các lớp **ChartPlotArea** và **IChartPlotArea**. Nếu bố cục của vùng vẽ được xác định thủ công, thuộc tính này chỉ định việc bố cục vùng vẽ bằng bên trong (không bao gồm trục và nhãn trục) hay bên ngoài (bao gồm trục và nhãn trục). Có hai giá trị khả dụng được định nghĩa trong enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - chỉ định rằng kích thước vùng vẽ sẽ được xác định bởi kích thước vùng vẽ, không bao gồm các dấu tick và nhãn trục.
- **LayoutTargetType.Outer** - chỉ định rằng kích thước vùng vẽ sẽ được xác định bởi kích thước vùng vẽ, các dấu tick và nhãn trục.

Mã mẫu được đưa dưới đây.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **Câu Hỏi Thường Gặp**

**Đơn vị nào được sử dụng cho ActualX, ActualY, ActualWidth và ActualHeight?**

Đơn vị là điểm; 1 inch = 72 điểm. Đây là đơn vị tọa độ của Aspose.Slides.

**Vùng Vẽ (Plot Area) khác với Vùng Biểu Đồ (Chart Area) như thế nào về nội dung?**

Vùng Vẽ là khu vực vẽ dữ liệu (dòng dữ liệu, lưới, đường xu hướng, v.v.); Vùng Biểu Đồ bao gồm các thành phần xung quanh (tiêu đề, chú giải, v.v.). Trong biểu đồ 3D, Vùng Vẽ còn bao gồm tường/sàn và các trục.

**Khi bố cục được đặt thủ công, các giá trị X, Y, Width và Height của Vùng Vẽ được hiểu như thế nào?**

Chúng là các phần (0–1) của tổng kích thước biểu đồ; trong chế độ này, vị trí tự động bị tắt và các phần bạn đặt sẽ được sử dụng.

**Tại sao vị trí Vùng Vẽ thay đổi sau khi thêm hoặc di chuyển chú giải (legend)?**

Chú giải nằm trong vùng biểu đồ bên ngoài Vùng Vẽ nhưng ảnh hưởng đến bố cục và không gian khả dụng, vì vậy Vùng Vẽ có thể dịch chuyển khi tính năng vị trí tự động được kích hoạt. (Đây là hành vi tiêu chuẩn của biểu đồ PowerPoint.)