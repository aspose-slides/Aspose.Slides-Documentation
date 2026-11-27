---
title: Nén bản trình chiếu
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

Nén hình ảnh, loại bỏ các khu vực hình đã cắt khi không còn cần thiết, và chọn các cài đặt nén bản trình chiếu trước khi lưu. Điều này hữu ích cho các bộ slide có ảnh lớn hoặc phương tiện lặp lại. Lượng tiết kiệm phụ thuộc vào nội dung và cài đặt bạn chọn.

## **Ví dụ sử dụng**

Ví dụ C# này tải `input.pptx`, nén bản trình chiếu và lưu nó dưới dạng `compressed.pptx`.

Sử dụng Aspose.Slides for .NET 26.11 hoặc cao hơn. Để thiết lập, xem [Cài đặt Aspose.Slides cho .NET](/slides/vi/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Các hình ảnh được thu phóng đồng nhất trước và sau khi nén, đi kèm với các thanh kích thước tệp PPTX được đo và kích thước hình ảnh đã lưu.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Được đo trên một mẫu lưới chi tiết tổng hợp: 584.030 → 128.323 byte. Cả hai bản render đều sử dụng cùng tỷ lệ và khung 252 × 336 điểm. Nén loại bỏ các lề đã cắt và giảm hình ảnh lưu trữ xuống 525 × 700 pixel; mức tiết kiệm kích thước phụ thuộc vào dữ liệu đầu vào.* 
<!-- visual-explanation:compress-presentations:end -->

## **Câu hỏi thường gặp**

### **Đây có phải là công tắc tối ưu hoá toàn bộ tệp không?**

Aspose.Slides for .NET 26.11 thêm [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), kết hợp việc xóa bỏ layout/master không dùng, subsetting phông chữ nhúng và nén hình ảnh 150 DPI. Nó loại bỏ vĩnh viễn các khu vực hình đã cắt. Đối với xử lý chỉ hình ảnh, sử dụng [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); để kiểm soát chi tiết hơn, xem [ví dụ nén hình ảnh riêng lẻ](/slides/vi/net/examples/optimization-batch/compression/). Từ phiên bản 26.11, cùng một lời gọi toàn bộ bản trình chiếu cũng khả dụng trong Java, Node.js thông qua Java, Python qua .NET và C++. Ví dụ và các liên kết trên trang này dành cho .NET.

### **Nén hình ảnh có làm thay đổi văn bản có thể chỉnh sửa hoặc biểu đồ không?**

Nén hình ảnh chỉ nhắm vào dữ liệu hình, không phải văn bản có thể chỉnh sửa hoặc dữ liệu biểu đồ. Hãy xem lại các hình ảnh vì việc thay đổi kích thước hoặc nén lại có thể giảm chi tiết.

### **Tôi nên chọn độ phân giải cho hình ảnh trong bản trình chiếu như thế nào?**

Chọn mục tiêu dựa trên kích thước hình ảnh hiển thị và mục đích sử dụng trên màn hình hoặc in. Giữ lại độ phân giải cao hơn cho các màn hình lớn, in ấn và sơ đồ chi tiết, và so sánh kết quả render trước khi loại bỏ bản gốc.

## **Hướng dẫn**

- [Nén toàn bộ bản trình chiếu trong .NET](/slides/vi/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Tối ưu quản lý hình ảnh trong bản trình chiếu trong .NET](/slides/vi/net/image/)

Related feature: [Xóa các master, layout và phương tiện không dùng](/slides/vi/features/remove-unused-content/).

## Các ví dụ .NET có thể chạy

- [Giảm kích thước bản trình chiếu](/slides/vi/net/examples/optimization-batch/compression/)