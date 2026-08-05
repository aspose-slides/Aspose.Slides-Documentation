---
title: Tùy chỉnh biểu đồ 3D trong bản trình bày bằng C++
linktitle: Biểu đồ 3D
type: docs
url: /vi/cpp/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ 3D trong Aspose.Slides cho C++, hỗ trợ các tệp PPT và PPTX—nâng cao các bản trình bày của bạn ngay hôm nay."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh biểu đồ 3D trong Aspose.Slides bằng cách cấu hình các thiết lập `Rotation3D` như `RotationX`, `RotationY`, `DepthPercents` và `RightAngleAxes`. Nó hướng dẫn tạo một bản trình bày, thêm biểu đồ 3D với dữ liệu mặc định, áp dụng các thiết lập dạng xem 3D cần thiết và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

## **Đặt các Thuộc tính RotationX, RotationY và DepthPercents của Biểu đồ 3D**
Aspose.Slides for C++ cung cấp một API đơn giản để đặt các thuộc tính này. Bài viết sau sẽ giúp bạn cách đặt các thuộc tính khác nhau như X,Y Rotation, **DepthPercents** v.v. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Đặt các thuộc tính Rotation3D.
5. Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được hiển thị qua enumeration [ChartType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/). Để có danh sách chính xác và cập nhật, vui lòng kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/) trong tài liệu API của phiên bản bạn đã cài đặt.

**Tôi có thể nhận được ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ ra ảnh thông qua [chart API](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/) hoặc [render toàn bộ slide](/slides/vi/cpp/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần một bản xem trước pixel-perfect hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu suất của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu suất phụ thuộc vào lượng dữ liệu và độ phức tạp trực quan. Để đạt kết quả tốt nhất, hãy giữ các hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên các bức tường và khu vực vẽ, hạn chế số điểm dữ liệu mỗi series khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để khớp nhu cầu hiển thị hoặc in ấn.