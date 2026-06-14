---
title: Lấy toàn bộ nền slide từ bản trình chiếu dưới dạng hình ảnh
linktitle: Toàn bộ nền slide
type: docs
weight: 95
url: /vi/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- nền slide
- nền cuối cùng
- trích xuất nền
- toàn bộ nền
- nền sang hình ảnh
- nền PPT
- nền PPTX
- nền ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Trích xuất toàn bộ nền slide thành hình ảnh từ các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET, giúp đơn giản hoá quy trình làm việc trực quan."
---
## **Tổng quan**

Trong các bản trình chiếu PowerPoint, nền của một slide có thể được tạo thành từ nhiều thành phần, bao gồm hình ảnh nền slide, giao diện trình chiếu, bảng màu và các đối tượng được đặt trên slide chủ hoặc slide bố cục.

Bài viết này cho biết cách trích xuất toàn bộ nền slide dưới dạng ảnh bằng Aspose.Slides for .NET. Vì không có phương pháp đơn lẻ cho nhiệm vụ này, cách tiếp cận bao gồm sao chép slide đã chọn vào một bản trình chiếu tạm thời, xóa các hình dạng trên slide, sau đó chuyển đổi nền slide kết quả thành ảnh.

## **Lấy Nền Toàn Bộ của Slide**

Aspose.Slides for .NET không cung cấp phương pháp đơn giản để trích xuất toàn bộ nền slide của bản trình chiếu dưới dạng ảnh, nhưng bạn có thể làm theo các bước sau:

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
1. Lấy kích thước slide từ bản trình chiếu.
1. Chọn một slide.
1. Tạo một bản trình chiếu tạm thời.
1. Đặt cùng kích thước slide trong bản trình chiếu tạm thời.
1. Sao chép (clone) slide đã chọn vào bản trình chiếu tạm thời.
1. Xóa các hình dạng khỏi slide đã sao chép.
1. Chuyển đổi slide đã sao chép thành hình ảnh.

Đoạn mã sau trích xuất toàn bộ nền slide của bản trình chiếu dưới dạng ảnh.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **Câu hỏi thường gặp**

**Các gradient phức tạp, kết cấu hoặc nền ảnh từ slide chủ có được giữ lại trong hình ảnh nền kết quả không?**

Có. Aspose.Slides sẽ render các gradient, ảnh và kết cấu nền được định nghĩa trên slide, bố cục hoặc slide chủ. Nếu bạn cần tách biệt giao diện khỏi các slide chủ được kế thừa, hãy [đặt nền riêng](/slides/vi/net/presentation-background/) trên slide hiện tại trước khi xuất.

**Có thể thêm watermark vào hình ảnh nền kết quả trước khi lưu không?**

Có. Bạn có thể [thêm một watermark](/slides/vi/net/watermark/) dạng hình hoặc ảnh trên một [bản sao của slide](/slides/vi/net/clone-slides/) đang làm việc (đặt phía sau nội dung khác) và sau đó xuất. Điều này cho phép bạn tạo ra một hình ảnh nền có watermark đã được tích hợp.

**Có thể lấy nền cho một layout hoặc master cụ thể mà không gắn vào slide hiện có không?**

Có. Truy cập vào master hoặc layout mong muốn, áp dụng nó vào một [slide tạm thời](/slides/vi/net/clone-slides/) với kích thước cần thiết, và xuất slide đó để lấy nền được tạo ra từ layout hoặc master đó.

**Có những hạn chế về giấy phép ảnh hưởng đến việc xuất ảnh không?**

Các tính năng render có sẵn đầy đủ khi có [giấy phép hợp lệ](/slides/vi/net/licensing/). Trong chế độ đánh giá, đầu ra có thể bị giới hạn như có watermark. Kích hoạt giấy phép một lần cho mỗi tiến trình trước khi chạy xuất hàng loạt.