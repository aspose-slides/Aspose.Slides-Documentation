---
title: Nén bản trình chiếu
description: Giảm kích thước bản trình chiếu bằng cách nén hình ảnh và lưu cài đặt.
type: docs
url: /vi/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Tổng quan**

Nén hình ảnh, loại bỏ các khu vực ảnh đã cắt khi không còn cần thiết, và chọn các cài đặt nén bản trình chiếu trước khi lưu. Điều này hữu ích cho các bài thuyết trình có ảnh lớn hoặc phương tiện lặp lại. Lượng tiết kiệm phụ thuộc vào nội dung và cài đặt bạn chọn.

## **Ví dụ sử dụng**

Ví dụ C# này sử dụng Aspose.Slides cho .NET. Nó tạo ra một ảnh PNG gradient kích thước 1600 × 900 pixel, chèn vào một khung ảnh nhỏ và lưu *before.pptx*. Sau đó nó nén ảnh đó tới độ phân giải mục tiêu là 96 DPI và lưu *compressed.pptx*. So sánh kích thước tệp và bản xem trước của cả hai: mức tiết kiệm phụ thuộc vào ảnh đầu vào và kích thước hiển thị.

Để cài đặt, xem [Cài đặt Aspose.Slides cho .NET](/slides/vi/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **Câu hỏi thường gặp**

### **Liệu đây có phải là công tắc tối ưu hóa toàn bộ tệp không?**

Aspose.Slides cho .NET 26.11 thêm [Compress.CompressPresentation](/slides/vi/net/low-code-presentation-operations/#compress-the-whole-presentation), kết hợp việc loại bỏ bố cục/master không dùng, chia nhỏ phông chữ nhúng và nén ảnh 150 DPI. Nó loại bỏ vĩnh viễn các khu vực ảnh đã cắt. Đối với xử lý chỉ ảnh, hãy sử dụng Compress.CompressImages; để kiểm soát chi tiết hơn, giữ quy trình làm việc cho từng ảnh như trên. Các trợ giúp mới này chỉ áp dụng cho phiên bản .NET đã nêu; kiểm tra hướng dẫn tương ứng cho các SDK khác.

### **Nén ảnh có thay đổi văn bản có thể chỉnh sửa hoặc biểu đồ không?**

Nén ảnh chỉ nhắm vào dữ liệu hình ảnh, không ảnh hưởng đến văn bản có thể chỉnh sửa hoặc dữ liệu biểu đồ. Kiểm tra lại các hình ảnh vì việc thay đổi kích thước hoặc nén lại có thể làm giảm chi tiết.

### **Làm sao để chọn độ phân giải cho hình ảnh trong bản trình chiếu?**

Chọn độ phân giải mục tiêu dựa trên kích thước ảnh hiển thị và mục đích sử dụng trên màn hình hoặc in. Giữ độ phân giải cao hơn cho các màn hình lớn, việc in và các sơ đồ chi tiết, và so sánh kết quả render trước khi loại bỏ bản gốc.

## **Hướng dẫn**

- [Tối ưu quản lý hình ảnh trong bản trình chiếu trong .NET](/slides/vi/net/image/)

Tính năng liên quan: [Xóa các master, bố cục và phương tiện không sử dụng](/slides/vi/features/remove-unused-content/).

## Ví dụ .NET có thể chạy

- [Giảm kích thước bản trình chiếu](/slides/vi/net/examples/optimization-batch/compression/)