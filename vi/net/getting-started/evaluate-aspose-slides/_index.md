---
title: Đánh giá Aspose.Slides
type: docs
weight: 75
url: /vi/net/evaluate-aspose-slides/
keywords:
- đánh giá Aspose.Slides
- đánh giá Aspose.Slides
- phiên bản dùng thử
- đầy đủ chức năng
- watermark dùng thử
- mua Aspose.Slides
- hạn chế
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Đánh giá Aspose.Slides cho .NET và khám phá các tính năng API cho các bản trình chiếu PowerPoint (PPT, PPTX) và OpenDocument (ODP) — bắt đầu dùng thử miễn phí của bạn."
---
## **Đánh giá Aspose.Slides**

Bạn có thể tải xuống Aspose.Slides để dùng thử. Gói dùng thử giống với gói đã mua; nó sẽ được cấp phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

Nếu không có giấy phép, Aspose.Slides cung cấp đầy đủ chức năng trong chế độ dùng thử, nhưng có hai hạn chế: nó thêm một hộp văn bản watermark dùng thử vào mỗi slide của mỗi bản trình chiếu được lưu, và văn bản mà mã của bạn đọc từ bản trình chiếu sẽ bị cắt ngắn đến một vài ký tự đầu, kèm theo thông báo về giới hạn dùng thử. Văn bản mà mã của bạn ghi sẽ được lưu đầy đủ.

![Một slide có watermark dùng thử](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Nếu bạn muốn thử Aspose.Slides mà không có các hạn chế của phiên bản dùng thử, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Vui lòng tham khảo [Cách nhận Giấy phép Tạm thời?](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.
{{% /alert %}}

## **Cài đặt Gói Dùng Thử**

```bash
dotnet add package Aspose.Slides.NET
```

Trên Linux và macOS, bạn có thể sử dụng gói Aspose.Slides.NET6.CrossPlatform thay thế; xem [Cài đặt](/slides/vi/net/installation/).

## **Áp dụng Giấy phép**

Đây là “một vài dòng mã” chuyển gói dùng thử thành phiên bản có giấy phép. Áp dụng giấy phép một lần khi khởi động ứng dụng, trước khi bất kỳ đối tượng `Presentation` nào được tạo — một bản trình chiếu được tạo trước đó sẽ giữ watermark dùng thử.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` cũng chấp nhận một `Stream`, là lựa chọn tốt hơn khi giấy phép được đóng gói dưới dạng tài nguyên nhúng thay vì một file trên đĩa. Nếu đường dẫn sai hoặc tệp đã hết hạn, cuộc gọi sẽ ném ngoại lệ, do đó các lỗi sẽ xuất hiện ngay khi khởi động thay vì im lặng chuyển sang chế độ dùng thử.

Sau khi giấy phép được áp dụng, các bản trình chiếu đã lưu sẽ không còn chứa watermark, và văn bản được đọc đầy đủ.

## **Câu hỏi thường gặp**

### Tôi có thể kiểm tra nhiều bản trình chiếu đồng thời trên các luồng khác nhau trong chế độ dùng thử không?
Có. Bạn có thể xử lý các tài liệu khác nhau một cách song song; bạn không nên chia sẻ cùng một đối tượng bản trình chiếu [trên các luồng](/slides/vi/net/multithreading/). Chế độ dùng thử không ảnh hưởng đến điều này.

### Tôi có cần cài đặt Microsoft PowerPoint để đánh giá thư viện trên máy chủ hoặc trong CI không?
Không. Aspose.Slides là một engine độc lập và không yêu cầu cài đặt PowerPoint cho cả chế độ dùng thử và sản xuất.

### Tôi có thể kiểm tra đầy đủ việc chuyển đổi PPT/PPTX sang PDF và hình ảnh trong chế độ dùng thử không?
Có. Các [bộ chuyển đổi](/slides/vi/net/convert-presentation/) hoạt động; kết quả sẽ bao gồm một watermark.

### Tôi có thể sử dụng giấy phép tạm thời để kiểm thử tải mà không có watermark không?
Có. Giấy phép tạm thời 30 ngày loại bỏ các hạn chế của chế độ dùng thử và cho phép kiểm thử mà không có watermark.