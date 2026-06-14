---
title: Tùy chỉnh thanh lỗi trong biểu đồ trình chiếu bằng C++
linktitle: Thanh lỗi
type: docs
url: /vi/cpp/error-bar/
keywords:
- thanh lỗi
- giá trị tùy chỉnh
- PowerPoint
- trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm và tùy chỉnh thanh lỗi trong biểu đồ với Aspose.Slides cho C++ — tối ưu hóa hình ảnh dữ liệu trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với thanh lỗi trong biểu đồ trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách thêm thanh lỗi vào một chuỗi biểu đồ, cấu hình cài đặt thanh lỗi X và Y, và áp dụng các kiểu giá trị khác nhau như cố định, phần trăm và giá trị tùy chỉnh.

Nó cũng trình bày cách gán giá trị thanh lỗi tùy chỉnh cho các điểm dữ liệu riêng lẻ trong một chuỗi bằng cách sử dụng bộ sưu tập điểm dữ liệu tương ứng. Ngoài ra, bài viết bao gồm các ghi chú ngắn gọn về cách thanh lỗi hoạt động khi xuất, tính tương thích của chúng với các dấu đánh dấu và nhãn dữ liệu, và nơi tìm các lớp và enum tham chiếu API liên quan.

## **Thêm Thanh Lỗi**
Aspose.Slides cho C++ cung cấp một API đơn giản để quản lý các giá trị thanh lỗi. Mã mẫu áp dụng khi sử dụng kiểu giá trị tùy chỉnh. Để chỉ định một giá trị, sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập **DataPoints** của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Thêm một biểu đồ bong bóng vào slide mong muốn.
3. Truy cập chuỗi biểu đồ đầu tiên và thiết lập định dạng thanh lỗi X.
4. Truy cập chuỗi biểu đồ đầu tiên và thiết lập định dạng thanh lỗi Y.
5. Thiết lập giá trị và định dạng cho các thanh.
6. Ghi bản trình bày đã sửa đổi vào tệp PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Thêm Thanh Lỗi Tùy Chỉnh**
Aspose.Slides cho C++ cung cấp một API đơn giản để quản lý các giá trị thanh lỗi tùy chỉnh. Mã mẫu áp dụng khi thuộc tính **IErrorBarsFormat.ValueType** bằng **Custom**. Để chỉ định một giá trị, sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập **DataPoints** của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Thêm một biểu đồ bong bóng vào slide mong muốn.
3. Truy cập chuỗi biểu đồ đầu tiên và thiết lập định dạng thanh lỗi X.
4. Truy cập chuỗi biểu đồ đầu tiên và thiết lập định dạng thanh lỗi Y.
5. Truy cập các điểm dữ liệu riêng lẻ của chuỗi biểu đồ và thiết lập giá trị thanh lỗi cho một điểm dữ liệu riêng biệt trong chuỗi.
6. Thiết lập giá trị và định dạng cho các thanh.
7. Ghi bản trình bày đã sửa đổi vào tệp PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **Câu hỏi thường gặp**

**Điều gì xảy ra với thanh lỗi khi xuất bản trình chiếu sang PDF hoặc hình ảnh?**

Chúng được vẽ như một phần của biểu đồ và được giữ nguyên trong quá trình chuyển đổi cùng với phần còn lại của định dạng biểu đồ, với giả định rằng phiên bản hoặc bộ render tương thích.

**Thanh lỗi có thể kết hợp với các dấu đánh dấu và nhãn dữ liệu không?**

Có. Thanh lỗi là một yếu tố riêng biệt và tương thích với các dấu đánh dấu và nhãn dữ liệu; nếu các yếu tố chồng lên nhau, bạn có thể cần điều chỉnh định dạng.

**Tôi có thể tìm danh sách các thuộc tính và enum để làm việc với thanh lỗi trong API ở đâu?**

Trong tài liệu tham chiếu API: lớp [ErrorBarsFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/errorbarsformat/) và các enum liên quan [ErrorBarType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/errorbartype/) và [ErrorBarValueType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/errorbarvaluetype/).