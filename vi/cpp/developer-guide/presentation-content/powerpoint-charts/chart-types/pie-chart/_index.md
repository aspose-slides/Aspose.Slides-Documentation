---
title: Tùy chỉnh biểu đồ tròn trong bản trình bày bằng C++
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
- màu lát
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ tròn trong C++ với Aspose.Slides, có thể xuất ra PowerPoint, giúp bạn kể câu chuyện dữ liệu chỉ trong vài giây."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó cho thấy cách cấu hình các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật tính năng tự động tô màu các lát cho biểu đồ tròn tiêu chuẩn.  

Ví dụ tập trung vào các bước tùy chỉnh biểu đồ thực tế như thêm biểu đồ vào slide, điều chỉnh cài đặt series và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie**

Aspose.Slides cho C++ hiện đã hỗ trợ các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie hoặc Bar of Pie. Trong chủ đề này, chúng ta sẽ xem qua ví dụ cách chỉ định các tùy chọn này bằng Aspose.Slides. Để chỉ định các thuộc tính, hãy làm theo các bước dưới đây:

1. Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/)
2. Thêm biểu đồ vào slide.
3. Chỉ định các tùy chọn biểu đồ phụ cho biểu đồ.
4. Ghi bản trình bày ra đĩa.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Đặt màu tự động cho các lát của biểu đồ tròn**

Aspose.Slides cho C++ cung cấp một API đơn giản để thiết lập màu tự động cho các lát của biểu đồ tròn. Mã mẫu áp dụng việc thiết lập các thuộc tính đã đề cập ở trên.

1. Tạo một thể hiện của lớp Presentation.
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Đặt tiêu đề cho biểu đồ.
5. Đặt series đầu tiên để Hiển thị Giá trị.
6. Đặt chỉ mục của bảng dữ liệu biểu đồ.
7. Lấy worksheet dữ liệu biểu đồ.
8. Xóa các series và danh mục được tạo mặc định.
9. Thêm danh mục mới.
10. Thêm series mới.

Viết bản trình bày đã chỉnh sửa ra file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Các biến thể 'Pie of Pie' và 'Bar of Pie' có được hỗ trợ không?**

Đúng, thư viện [supports](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/) một biểu đồ phụ cho các biểu đồ tròn, bao gồm các loại 'Pie of Pie' và 'Bar of Pie'.

**Tôi có thể xuất riêng biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Đúng, bạn có thể [export the chart itself as an image](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/) (ví dụ PNG) mà không cần toàn bộ bản trình bày.