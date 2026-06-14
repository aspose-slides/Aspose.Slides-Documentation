---
title: Tùy chỉnh biểu đồ Donut trong bài thuyết trình bằng C++
linktitle: Biểu đồ Donut
type: docs
weight: 30
url: /vi/cpp/doughnut-chart/
keywords:
- biểu đồ donut
- khoảng trống trung tâm
- kích thước lỗ
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh biểu đồ donut trong Aspose.Slides cho C++, hỗ trợ các định dạng PowerPoint cho các bài thuyết trình động."
---
## **Tổng quan**

Bài viết này chỉ ra cách làm việc với biểu đồ Donut trong Aspose.Slides bằng cách thêm biểu đồ vào một slide, đặt kích thước lỗ ở trung tâm, và lưu bản trình bày. Nội dung tập trung vào phương thức `set_DoughnutHoleSize` và trình bày các bước cơ bản cần thiết để tùy chỉnh loại biểu đồ này trong mã.

## **Xác định khoảng trống trung tâm trong biểu đồ Donut**
Để chỉ định kích thước lỗ trong biểu đồ Donut, vui lòng làm theo các bước sau:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
- Thêm biểu đồ Donut vào slide.
- Chỉ định kích thước lỗ trong biểu đồ Donut.
- Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập kích thước lỗ trong biểu đồ Donut.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **Câu hỏi thường gặp**

**Tôi có thể tạo Donut đa cấp với nhiều vòng không?**

Có. Thêm nhiều series vào một biểu đồ Donut—mỗi series sẽ trở thành một vòng riêng. Thứ tự các vòng được xác định bởi thứ tự của các series trong bộ sưu tập.

**Biểu đồ Donut "nổ" (các lát riêng biệt) có được hỗ trợ không?**

Có. Có loại biểu đồ Exploded Doughnut [chart type](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/) và thuộc tính explosion trên các điểm dữ liệu; bạn có thể tách các lát riêng lẻ.

**Làm thế nào tôi có thể lấy hình ảnh của biểu đồ Donut (PNG/SVG) cho báo cáo?**

Biểu đồ là một hình dạng; bạn có thể render nó thành một [raster image](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/) hoặc xuất biểu đồ ra một [SVG image](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/writeassvg/).