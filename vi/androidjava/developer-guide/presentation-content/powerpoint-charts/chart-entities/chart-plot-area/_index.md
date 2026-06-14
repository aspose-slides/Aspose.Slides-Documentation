---
title: Tùy chỉnh vùng vẽ của biểu đồ trong bản trình chiếu trên Android
linktitle: Vùng vẽ
type: docs
url: /vi/androidjava/chart-plot-area/
keywords:
- biểu đồ
- vùng vẽ
- chiều rộng vùng vẽ
- chiều cao vùng vẽ
- kích thước vùng vẽ
- chế độ bố cục
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá cách tùy chỉnh vùng vẽ biểu đồ trong các bản trình chiếu PowerPoint với Aspose.Slides cho Android thông qua Java. Nâng cao trực quan slide một cách dễ dàng."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với vùng vẽ của biểu đồ trong Aspose.Slides. Nó giải thích cách lấy vị trí và kích thước thực tế của vùng vẽ bằng cách xác thực bố cục biểu đồ và sau đó đọc các giá trị X, Y, chiều rộng và chiều cao.

Nó cũng minh họa cách cấu hình chế độ bố cục của vùng vẽ khi bố cục được đặt thủ công, sử dụng `LayoutTargetType` để xác định vùng vẽ được tính dựa trên khu vực bên trong hoặc khu vực bên ngoài cùng với các trục và nhãn trục.

## **Lấy chiều rộng và chiều cao của vùng vẽ biểu đồ**
Aspose.Slides cho Android thông qua Java cung cấp một API đơn giản cho .

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Gọi phương thức [IChart.validateChartLayout()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChart#validateChartLayout--) trước khi lấy các giá trị thực tế.
5. Lấy vị trí X thực tế (bên trái) của phần tử biểu đồ so với góc trái trên của biểu đồ.
6. Lấy vị trí trên thực tế của phần tử biểu đồ so với góc trái trên của biểu đồ.
7. Lấy chiều rộng thực tế của phần tử biểu đồ.
8. Lấy chiều cao thực tế của phần tử biểu đồ.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt chế độ bố cục cho vùng vẽ biểu đồ**
Aspose.Slides cho Android thông qua Java cung cấp một API đơn giản để đặt chế độ bố cục của vùng vẽ biểu đồ. Các phương thức [**setLayoutTargetType**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) và [**getLayoutTargetType**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) đã được thêm vào lớp [**ChartPlotArea**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ChartPlotArea) và giao diện [**IChartPlotArea**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartPlotArea). Nếu bố cục của vùng vẽ được xác định thủ công, thuộc tính này chỉ định việc bố trí vùng vẽ theo bên trong (không bao gồm trục và nhãn trục) hay bên ngoài (bao gồm trục và nhãn trục). Có hai giá trị khả dụng được định nghĩa trong enum [**LayoutTargetType**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LayoutTargetType#Inner) - chỉ định kích thước vùng vẽ sẽ xác định kích thước của vùng vẽ, không bao gồm các dấu đánh dấu và nhãn trục.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LayoutTargetType#Outer) - chỉ định kích thước vùng vẽ sẽ xác định kích thước của vùng vẽ, các dấu đánh dấu và nhãn trục.

Mã mẫu được đưa ra bên dưới.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Đơn vị nào được sử dụng cho x thực tế, y thực tế, chiều rộng thực tế và chiều cao thực tế?**

Được trả về bằng điểm; 1 inch = 72 điểm. Đây là đơn vị tọa độ của Aspose.Slides.

**Vùng vẽ khác gì so với vùng biểu đồ về nội dung?**

Vùng vẽ là khu vực vẽ dữ liệu (dòng dữ liệu, lưới, đường xu hướng, v.v.); vùng biểu đồ bao gồm các yếu tố xung quanh (tiêu đề, chú giải, v.v.). Trong các biểu đồ 3D, vùng vẽ còn bao gồm các mặt tường/sàn và các trục.

**Các giá trị x, y, chiều rộng và chiều cao của vùng vẽ được hiểu như thế nào khi bố cục được đặt thủ công?**

Chúng là các tỷ lệ (0–1) của toàn bộ kích thước biểu đồ; ở chế độ này, việc tự động định vị bị tắt và các tỷ lệ bạn thiết lập sẽ được sử dụng.

**Tại sao vị trí của vùng vẽ lại thay đổi sau khi thêm hoặc di chuyển chú giải?**

Chú giải nằm trong vùng biểu đồ bên ngoài vùng vẽ nhưng ảnh hưởng đến bố cục và không gian khả dụng, do đó vùng vẽ có thể dịch chuyển khi tính năng tự động định vị hoạt động. (Đây là hành vi tiêu chuẩn của các biểu đồ PowerPoint.)