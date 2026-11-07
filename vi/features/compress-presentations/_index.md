---
title: Nén các bản trình chiếu
description: Giảm kích thước bản trình chiếu bằng cách nén hình ảnh và loại bỏ nội dung không sử dụng.
type: docs
url: /vi/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Tổng quan**

Nén hình ảnh, loại bỏ các khu vực hình đã cắt khi chúng không còn cần thiết và chọn cài đặt nén bản trình chiếu trước khi lưu. Điều này hữu ích cho các bộ slide có nhiều ảnh lớn hoặc phương tiện lặp lại. Lượng dữ liệu được tiết kiệm phụ thuộc vào nội dung và cài đặt bạn chọn.

## **Ví dụ sử dụng**

Ví dụ C# này tải `input.pptx`, nén bản trình chiếu và lưu nó dưới dạng `compressed.pptx`.

Sử dụng Aspose.Slides cho .NET 26.11 hoặc mới hơn. Để cài đặt, xem [Cài đặt Aspose.Slides cho .NET](/slides/vi/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

### **Đây có phải là công tắc tối ưu hoá toàn bộ tệp không?**

Aspose.Slides cho .NET 26.11 bổ sung [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), kết hợp việc loại bỏ bố cục/mẫu không dùng, cắt tệp phông chữ nhúng và nén hình ảnh 150 DPI. Nó loại bỏ vĩnh viễn các khu vực ảnh đã cắt. Đối với xử lý chỉ ảnh, dùng [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); để kiểm soát chi tiết hơn, xem [ví dụ nén ảnh riêng lẻ](/slides/vi/net/examples/optimization-batch/compression/). Các công cụ mới này chỉ áp dụng cho phiên bản .NET đã nêu; hãy kiểm tra hướng dẫn tương ứng cho các SDK khác.

### **Nén ảnh có thay đổi văn bản hoặc biểu đồ có thể chỉnh sửa không?**

Nén ảnh chỉ nhắm vào dữ liệu hình ảnh, không ảnh hưởng đến văn bản hoặc dữ liệu biểu đồ có thể chỉnh sửa. Kiểm tra các hình ảnh vì việc thay đổi kích thước hoặc nén lại có thể giảm chi tiết.

### **Tôi nên chọn độ phân giải cho hình ảnh trong bản trình chiếu như thế nào?**

Chọn độ phân giải mục tiêu dựa trên kích thước hình ảnh hiển thị và mục đích sử dụng trên màn hình hoặc in. Giữ độ phân giải cao hơn cho màn hình lớn, in ấn và sơ đồ chi tiết, và so sánh kết quả khi render trước khi loại bỏ bản gốc.

## **Hướng dẫn**

- [Nén toàn bộ bản trình chiếu trong .NET](/slides/vi/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Tối ưu hóa quản lý hình ảnh trong bản trình chiếu trong .NET](/slides/vi/net/image/)

Tính năng liên quan: [Xóa các mẫu, bố cục và phương tiện không sử dụng](/slides/vi/features/remove-unused-content/).

## Các ví dụ .NET có thể chạy

- [Giảm kích thước bản trình chiếu](/slides/vi/net/examples/optimization-batch/compression/)