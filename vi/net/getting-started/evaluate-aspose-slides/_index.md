---
title: Đánh giá Aspose.Slides
type: docs
weight: 120
url: /vi/net/evaluate-aspose-slides/
keywords:
- đánh giá Aspose.Slides
- đánh giá Aspose.Slides
- phiên bản đánh giá
- đầy đủ chức năng
- watermark đánh giá
- mua Aspose.Slides
- giới hạn
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Đánh giá Aspose.Slides cho .NET và khám phá các tính năng API cho các bản trình bày PowerPoint (PPT, PPTX) và OpenDocument (ODP) — bắt đầu dùng thử miễn phí của bạn."
---
## **Đánh giá Aspose.Slides**

Bạn có thể tải xuống Aspose.Slides để đánh giá. Gói đánh giá giống hệt gói đã mua; nó sẽ được cấp phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

Nếu không có giấy phép, Aspose.Slides cung cấp toàn bộ chức năng trong chế độ đánh giá, với hai giới hạn: nó sẽ thêm một hộp chữ ký watermark đánh giá vào mỗi slide của mỗi bản trình bày khi lưu, và văn bản mà mã của bạn đọc từ bản trình bày sẽ bị cắt ngắn đến một vài ký tự đầu, kèm theo thông báo về giới hạn đánh giá. Văn bản mà mã của bạn ghi sẽ được lưu đầy đủ.

![Một slide với watermark đánh giá](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Nếu bạn muốn thử Aspose.Slides mà không gặp các giới hạn của phiên bản đánh giá, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Vui lòng tham khảo [Cách nhận Giấy phép Tạm thời?](https://purchase.aspose.com/temporary-license) để biết thêm chi tiết.
{{% /alert %}}

## **Cài đặt Gói Đánh giá**

```bash
dotnet add package Aspose.Slides.NET
```

Trên Linux và macOS, bạn có thể sử dụng gói Aspose.Slides.NET6.CrossPlatform; xem [Installation](/slides/vi/net/installation/).

## **Áp dụng Giấy phép**

Đây là “một vài dòng mã” biến gói đánh giá thành gói có giấy phép. Áp dụng giấy phép một lần khi khởi động ứng dụng, trước khi bất kỳ đối tượng `Presentation` nào được tạo — một bản trình bày được tạo trước đó sẽ giữ lại watermark đánh giá.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` cũng chấp nhận một `Stream`, đây là tùy chọn tốt hơn khi giấy phép được đóng gói dưới dạng tài nguyên nhúng thay vì là tệp trên đĩa. Nếu đường dẫn sai hoặc tệp đã hết hạn, lời gọi sẽ ném ngoại lệ, vì vậy các lỗi sẽ xuất hiện ngay khi khởi động thay vì im lặng chuyển sang chế độ đánh giá.

Sau khi giấy phép được áp dụng, các bản trình bày đã lưu sẽ không còn watermark, và văn bản được đọc đầy đủ.

## **Câu hỏi thường gặp**

### Tôi có thể kiểm tra nhiều bản trình bày đồng thời trên các luồng khác nhau trong chế độ đánh giá không?

Có. Bạn có thể xử lý các tài liệu khác nhau song song; bạn không nên chia sẻ cùng một đối tượng bản trình bày [across threads](/slides/vi/net/multithreading/). Chế độ đánh giá không ảnh hưởng đến việc này.

### Tôi có cần cài đặt Microsoft PowerPoint để đánh giá thư viện trên máy chủ hoặc trong CI không?

Không. Aspose.Slides là một công cụ độc lập và không yêu cầu PowerPoint được cài đặt cho cả chế độ đánh giá và sản xuất.

### Tôi có thể kiểm tra đầy đủ việc chuyển đổi PPT/PPTX sang PDF và ảnh trong chế độ đánh giá không?

Có. Các [converters](/slides/vi/net/convert-presentation/) hoạt động; kết quả sẽ bao gồm watermark.

### Tôi có thể sử dụng giấy phép tạm thời để tải thử mà không có watermark không?

Có. Giấy phép tạm thời 30 ngày loại bỏ các giới hạn của chế độ đánh giá và cho phép thử mà không có watermark.