---
title: Tùy chỉnh biểu đồ bánh Donut trong bản trình bày bằng C++
linktitle: Biểu đồ bánh Donut
type: docs
weight: 30
url: /vi/cpp/doughnut-chart/
keywords:
- biểu đồ bánh Donut
- khoảng trống trung tâm
- kích thước lỗ
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ bánh Donut trong Aspose.Slides cho C++, hỗ trợ các định dạng PowerPoint cho các bản trình bày động."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với biểu đồ bánh Donut trong Aspose.Slides bằng cách thêm biểu đồ vào một slide, đặt kích thước lỗ ở trung tâm và lưu bản trình bày. Nó tập trung vào phương thức `set_DoughnutHoleSize` và trình bày các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này trong mã.

## **Xác định khoảng trống trung tâm trong biểu đồ bánh Donut**
Để chỉ định kích thước của lỗ trong biểu đồ bánh Donut, vui lòng làm theo các bước dưới đây:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
- Thêm biểu đồ bánh Donut vào slide.
- Xác định kích thước lỗ trong biểu đồ bánh Donut.
- Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt kích thước lỗ trong biểu đồ bánh Donut.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **Câu hỏi thường gặp**

**Tôi có thể tạo bánh Donut đa cấp với nhiều vòng không?**

Có. Thêm nhiều series vào một biểu đồ bánh Donut—mỗi series sẽ trở thành một vòng riêng. Thứ tự các vòng được xác định bởi thứ tự của các series trong bộ sưu tập.

**Bánh Donut "exploded" (các miếng riêng biệt) có được hỗ trợ không?**

Có. Có loại biểu đồ Exploded Doughnut [chart type](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/) và thuộc tính explosion trên các điểm dữ liệu; bạn có thể tách các miếng riêng lẻ.

**Làm sao để lấy hình ảnh của biểu đồ bánh Donut (PNG/SVG) cho báo cáo?**

Biểu đồ là một hình dạng; bạn có thể render nó thành một [hình ảnh raster](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/) hoặc xuất biểu đồ ra một [hình ảnh SVG](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/writeassvg/).