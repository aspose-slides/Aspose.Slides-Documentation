---
title: Lấy toàn bộ nền slide từ bản trình chiếu dưới dạng hình ảnh
linktitle: Toàn bộ nền slide
type: docs
weight: 95
url: /vi/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- nền slide
- nền cuối cùng
- trích xuất nền
- toàn bộ nền
- nền thành hình ảnh
- nền PPT
- nền PPTX
- nền ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Trích xuất toàn bộ nền slide dưới dạng hình ảnh từ các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Java, giúp tối ưu hóa quy trình làm việc hình ảnh."
---
## **Tổng quan**

Trong các bài thuyết trình PowerPoint, nền của một slide có thể được tạo thành từ nhiều yếu tố, bao gồm hình nền slide, chủ đề bản trình chiếu, bảng màu và các đối tượng được đặt trên slide mẫu hoặc slide bố cục.

Bài viết này hướng dẫn cách trích xuất toàn bộ nền slide dưới dạng hình ảnh bằng Aspose.Slides for .NET. Vì không có một phương thức duy nhất cho tác vụ này, cách tiếp cận bao gồm sao chép slide đã chọn vào một bản trình chiếu tạm thời, xóa các hình dạng trên slide sao chép, sau đó chuyển nền slide thu được thành hình ảnh.

## **Lấy toàn bộ nền slide**

Aspose.Slides for Java không cung cấp phương thức đơn giản để trích xuất toàn bộ nền slide của bản trình chiếu dưới dạng hình ảnh, nhưng bạn có thể thực hiện các bước sau:
1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
1. Lấy kích thước slide từ bản trình chiếu.
1. Chọn một slide.
1. Tạo một bản trình chiếu tạm thời.
1. Đặt cùng kích thước slide cho bản trình chiếu tạm thời.
1. Sao chép slide đã chọn vào bản trình chiếu tạm thời.
1. Xóa các hình dạng khỏi slide đã sao chép.
1. Chuyển slide đã sao chép thành hình ảnh.

Ví dụ mã dưới đây trích xuất toàn bộ nền slide của bản trình chiếu dưới dạng hình ảnh.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **Câu hỏi thường gặp**

**Nền phức tạp với gradient, kết cấu hoặc ảnh nền từ slide mẫu có được giữ nguyên trong hình ảnh nền kết quả không?**

Có. Aspose.Slides sẽ dựng các lớp fill gradient, picture và texture được định nghĩa trên slide, bố cục hoặc mẫu. Nếu bạn cần tách riêng giao diện khỏi các mẫu kế thừa, [đặt nền riêng](/slides/vi/java/presentation-background/) cho slide hiện tại trước khi xuất.

**Tôi có thể thêm watermark vào hình ảnh nền kết quả trước khi lưu không?**

Có. Bạn có thể [thêm watermark](/slides/vi/java/watermark/) dưới dạng hình dạng hoặc ảnh trên một [bản sao của slide](/slides/vi/java/clone-slides/) (đặt phía sau nội dung khác) rồi xuất. Điều này cho phép tạo ra hình nền có watermark đã được nhúng.

**Tôi có thể lấy nền cho một bố cục hoặc mẫu cụ thể mà không cần gắn vào slide hiện có không?**

Có. Truy cập mẫu hoặc bố cục mong muốn, áp dụng nó vào một [slide tạm thời](/slides/vi/java/clone-slides/) với kích thước yêu cầu, sau đó xuất slide đó để lấy nền được tạo từ bố cục hoặc mẫu đó.

**Có giới hạn giấy phép nào ảnh hưởng tới việc xuất hình ảnh không?**

Các tính năng dựng ảnh hoàn toàn khả dụng khi có [giấy phép hợp lệ](/slides/vi/java/licensing/). Ở chế độ đánh giá, kết quả có thể bao gồm các hạn chế như watermark. Kích hoạt giấy phép một lần cho mỗi tiến trình trước khi thực hiện xuất hàng loạt.