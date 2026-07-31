---
title: Tùy chỉnh biểu đồ tròn trong bài thuyết trình bằng C++
linktitle: Biểu đồ tròn
type: docs
url: /vi/cpp/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn vẽ
- màu lát cắt
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ tròn trong C++ với Aspose.Slides, có thể xuất ra PowerPoint, tăng cường kể chuyện dữ liệu của bạn trong vài giây."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó trình bày cách cấu hình các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật tính năng tự động màu cho các lát cắt của biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các bước tùy chỉnh biểu đồ thực tiễn như thêm biểu đồ vào slide, điều chỉnh cài đặt series và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình chiếu đã cập nhật.

## **Tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie**
Aspose.Slides cho C++ hiện hỗ trợ các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie hoặc Bar of Pie. Trong phần này, chúng ta sẽ xem qua ví dụ cách chỉ định các tùy chọn này bằng Aspose.Slides. Để chỉ định các thuộc tính, vui lòng làm theo các bước dưới đây:

1. Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Thêm biểu đồ vào slide.
1. Chỉ định tùy chọn biểu đồ phụ cho biểu đồ.
1. Ghi trình chiếu ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt các thuộc tính khác nhau cho biểu đồ Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Đặt màu tự động cho các lát cắt của biểu đồ tròn**
Aspose.Slides cho C++ cung cấp một API đơn giản để thiết lập màu tự động cho các lát cắt của biểu đồ tròn. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp Presentation.
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Đặt tiêu đề cho biểu đồ.
1. Đặt series đầu tiên hiển thị giá trị.
1. Đặt chỉ mục của bảng dữ liệu biểu đồ.
1. Lấy worksheet dữ liệu biểu đồ.
1. Xóa series và danh mục được tạo mặc định.
1. Thêm danh mục mới.
1. Thêm series mới.

Ghi trình chiếu đã chỉnh sửa thành tệp PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **Câu hỏi thường gặp**

**Các biến thể 'Pie of Pie' và 'Bar of Pie' có được hỗ trợ không?**

Có, thư viện [supports](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/) một biểu đồ phụ cho các biểu đồ tròn, bao gồm các loại 'Pie of Pie' và 'Bar of Pie'.

**Tôi có thể xuất riêng biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Có, bạn có thể [export the chart itself as an image](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/) (như PNG) mà không cần xuất toàn bộ bản trình chiếu.