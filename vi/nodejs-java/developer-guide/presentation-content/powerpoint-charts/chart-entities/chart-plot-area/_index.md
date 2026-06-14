---
title: Tùy chỉnh vùng vẽ của biểu đồ trong bản trình chiếu bằng JavaScript
linktitle: Vùng vẽ
type: docs
url: /vi/nodejs-java/chart-plot-area/
keywords:
- biểu đồ
- vùng vẽ
- độ rộng vùng vẽ
- chiều cao vùng vẽ
- kích thước vùng vẽ
- chế độ bố cục
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá cách tùy chỉnh vùng vẽ của biểu đồ trong các bản trình chiếu PowerPoint bằng JavaScript và Aspose.Slides cho Node.js. Nâng cao hình ảnh slide của bạn một cách dễ dàng."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với vùng vẽ (plot area) của biểu đồ trong Aspose.Slides. Nó giải thích cách lấy vị trí và kích thước thực tế của vùng vẽ bằng cách xác thực bố cục biểu đồ và sau đó đọc các giá trị X, Y, chiều rộng và chiều cao của nó.

Nó cũng trình bày cách cấu hình chế độ bố cục của vùng vẽ khi bố cục được thiết lập thủ công, sử dụng `LayoutTargetType` để xác định vùng vẽ được tính dựa trên vùng bên trong hay vùng bên ngoài cùng với các trục và nhãn trục.

## **Lấy Chiều rộng, Chiều cao của Vùng Vẽ Biểu đồ**

Aspose.Slides cho Node.js thông qua Java cung cấp một API đơn giản cho .

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Gọi phương thức [Chart.validateChartLayout()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Chart#validateChartLayout--) trước khi lấy các giá trị thực tế.
5. Lấy vị trí X thực tế (trái) của phần tử biểu đồ so với góc trên bên trái của biểu đồ.
6. Lấy vị trí trên thực tế của phần tử biểu đồ so với góc trên bên trái của biểu đồ.
7. Lấy chiều rộng thực tế của phần tử biểu đồ.
8. Lấy chiều cao thực tế của phần tử biểu đồ.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Chế độ Bố cục cho Vùng Vẽ Biểu đồ**

Aspose.Slides cho Node.js thông qua Java cung cấp một API đơn giản để đặt chế độ bố cục của vùng vẽ biểu đồ. Các phương thức [**setLayoutTargetType**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) và [**getLayoutTargetType**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) đã được thêm vào lớp [**ChartPlotArea**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartPlotArea). Nếu bố cục của vùng vẽ được xác định thủ công, thuộc tính này chỉ định việc bố trí vùng vẽ theo bên trong (không bao gồm trục và nhãn trục) hay bên ngoài (bao gồm trục và nhãn trục). Có hai giá trị có thể, được định nghĩa trong enum [**LayoutTargetType**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LayoutTargetType#Inner) - chỉ định rằng kích thước vùng vẽ sẽ xác định kích thước của vùng vẽ, không bao gồm các dấu tick và nhãn trục.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LayoutTargetType#Outer) - chỉ định rằng kích thước vùng vẽ sẽ xác định kích thước của vùng vẽ, các dấu tick và nhãn trục.

Mã mẫu được đưa ra bên dưới.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Đơn vị nào được sử dụng để trả về X thực tế, Y thực tế, Chiều rộng thực tế và Chiều cao thực tế?**

Trong đơn vị điểm; 1 inch = 72 điểm. Đây là đơn vị tọa độ của Aspose.Slides.

**Vùng Vẽ (Plot Area) khác với Vùng Biểu Đồ (Chart Area) như thế nào về nội dung?**

Vùng Vẽ là khu vực vẽ dữ liệu (chuỗi, lưới, đường xu hướng, v.v.); Vùng Biểu Đồ bao gồm các yếu tố bao quanh (tiêu đề, chú giải, v.v.). Trong biểu đồ 3D, Vùng Vẽ cũng bao gồm các tường/sàn và các trục.

**Khi bố cục được thiết lập thủ công, X, Y, Chiều rộng và Chiều cao của Vùng Vẽ được hiểu như thế nào?**

Chúng là các tỷ lệ (0–1) của kích thước tổng thể của biểu đồ; trong chế độ này, việc tự động định vị bị tắt và các tỷ lệ bạn đặt sẽ được sử dụng.

**Tại sao vị trí của Vùng Vẽ lại thay đổi sau khi thêm hoặc di chuyển chú giải?**

Chú giải nằm trong vùng biểu đồ ngoài Vùng Vẽ nhưng ảnh hưởng đến bố cục và không gian khả dụng, do đó Vùng Vẽ có thể dịch chuyển khi tính năng tự động định vị đang hoạt động. (Đây là hành vi tiêu chuẩn của biểu đồ PowerPoint.)