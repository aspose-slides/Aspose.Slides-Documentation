---
title: Đánh giá Aspose.Slides
type: docs
weight: 120
url: /vi/net/evaluate-aspose-slides/
keywords:
- đánh giá Aspose.Slides
- đánh giá Aspose.Slides
- phiên bản đánh giá
- chức năng đầy đủ
- dấu watermark đánh giá
- mua Aspose.Slides
- giới hạn
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Đánh giá Aspose.Slides cho .NET và khám phá các tính năng API cho các bản trình chiếu PowerPoint (PPT, PPTX) và OpenDocument (ODP) — bắt đầu dùng bản dùng thử miễn phí."
---
## **Đánh giá Aspose.Slides**

Bạn có thể dễ dàng tải xuống Aspose.Slides để đánh giá. Gói đánh giá giống với gói đã mua. Phiên bản đánh giá sẽ trở thành bản có giấy phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép. 

Phiên bản đánh giá của Aspose.Slides (không chỉ định giấy phép) cung cấp đầy đủ chức năng của sản phẩm, nhưng sẽ chèn một dấu watermark đánh giá ở đầu tài liệu khi mở và lưu. Bạn cũng bị giới hạn chỉ một slide khi trích xuất văn bản từ các slide trình chiếu.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 

Nếu bạn muốn thử Aspose.Slides mà không có các giới hạn của phiên bản đánh giá, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Vui lòng tham khảo [Cách nhận Giấy phép Tạm thời?](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.

{{% /alert %}}

## **Cài đặt Gói Đánh giá**

```bash
dotnet add package Aspose.Slides.NET
```

## **Áp dụng Giấy phép**

Đây là “một vài dòng mã” biến gói đánh giá thành bản có giấy phép. Áp dụng giấy phép một lần khi khởi động ứng dụng, trước khi bất kỳ đối tượng `Presentation` nào được tạo — một bản trình chiếu được tạo trước sẽ giữ lại dấu watermark đánh giá.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` cũng chấp nhận một `Stream`, đây là tùy chọn tốt hơn khi giấy phép được đóng gói dưới dạng tài nguyên nhúng thay vì một tệp trên đĩa. Nếu đường dẫn sai hoặc tệp đã hết hạn, lời gọi sẽ ném ngoại lệ, vì vậy các lỗi sẽ xuất hiện ngay khi khởi động thay vì im lặng chuyển về chế độ đánh giá.

Khi giấy phép đã được áp dụng, dấu watermark sẽ biến mất và giới hạn trích xuất văn bản một slide sẽ được gỡ bỏ.

## **Câu hỏi thường gặp**

### Tôi có thể kiểm tra nhiều bản trình chiếu đồng thời trên các luồng khác nhau trong chế độ đánh giá không?

Có. Bạn có thể xử lý các tài liệu khác nhau đồng thời; bạn không nên chia sẻ cùng một đối tượng presentation [giữa các luồng](/slides/vi/net/multithreading/). Chế độ đánh giá không ảnh hưởng tới điều này.

### Tôi có cần cài đặt Microsoft PowerPoint để đánh giá thư viện trên máy chủ hoặc trong CI không?

Không. Aspose.Slides là một engine độc lập và không cần cài đặt PowerPoint cho cả việc đánh giá lẫn sản xuất.

### Tôi có thể hoàn toàn kiểm tra chuyển đổi PPT/PPTX sang PDF và hình ảnh trong chế độ đánh giá không?

Có. Các [bộ chuyển đổi](/slides/vi/net/convert-presentation/) hoạt động; kết quả sẽ bao gồm một watermark.

### Tôi có thể sử dụng giấy phép tạm thời cho kiểm thử tải mà không có watermark không?

Có. Giấy phép tạm thời 30 ngày loại bỏ các giới hạn của chế độ đánh giá và cho phép kiểm thử mà không có watermark.