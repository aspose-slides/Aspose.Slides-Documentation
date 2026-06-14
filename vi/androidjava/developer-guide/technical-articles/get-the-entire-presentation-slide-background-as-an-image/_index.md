---
title: Lấy toàn bộ nền slide từ một bản trình bày dưới dạng hình ảnh
linktitle: Toàn bộ nền slide
type: docs
weight: 95
url: /vi/androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Trích xuất toàn bộ nền slide dưới dạng hình ảnh từ các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Android qua Java, giúp tối ưu hoá quy trình làm việc trực quan."
---
## **Tổng quan**

Trong các bài thuyết trình PowerPoint, nền của một slide có thể được tạo thành từ nhiều thành phần, bao gồm hình nền slide, giao diện bài thuyết trình, bảng màu và các đối tượng được đặt trên slide chủ hoặc slide bố cục.

Bài viết này trình bày cách trích xuất toàn bộ nền slide dưới dạng hình ảnh bằng Aspose.Slides cho .NET. Vì không có phương pháp đơn lẻ cho nhiệm vụ này, cách tiếp cận bao gồm nhân bản slide đã chọn vào một bản trình bày tạm thời, xóa các hình dạng trên slide, sau đó chuyển nền slide kết quả thành hình ảnh.

## **Lấy toàn bộ nền slide**

Aspose.Slides cho Android qua Java không cung cấp phương pháp đơn giản để trích xuất toàn bộ nền slide của bản trình bày dưới dạng hình ảnh, nhưng bạn có thể thực hiện các bước dưới đây để làm điều đó:
1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/)
1. Lấy kích thước slide từ bản trình bày.
1. Chọn một slide.
1. Tạo một bản trình bày tạm thời.
1. Đặt cùng kích thước slide trong bản trình bày tạm thời.
1. Nhân bản slide đã chọn vào bản trình bày tạm thời.
1. Xóa các hình dạng khỏi slide đã nhân bản.
1. Chuyển slide đã nhân bản thành hình ảnh.

Ví dụ mã sau trích xuất toàn bộ nền slide của bản trình bày dưới dạng hình ảnh.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **Câu hỏi thường gặp**

**Liệu các gradient phức tạp, họa tiết hoặc nền hình ảnh từ slide chủ có được giữ nguyên trong hình nền kết quả không?**

Có. Aspose.Slides render các gradient, hình ảnh và họa tiết được định nghĩa trên slide, bố cục hoặc slide chủ. Nếu bạn cần tách biệt giao diện khỏi các slide chủ kế thừa, [đặt nền riêng](/slides/vi/androidjava/presentation-background/) cho slide hiện tại trước khi xuất.

**Tôi có thể thêm watermark vào hình nền kết quả trước khi lưu không?**

Có. Bạn có thể [thêm watermark](/slides/vi/androidjava/watermark/) dưới dạng hình dạng hoặc hình ảnh trên một [bản sao của slide](/slides/vi/androidjava/clone-slides/) đang làm việc (đặt phía sau nội dung khác) và sau đó xuất. Điều này cho phép bạn tạo ra hình nền có watermark được nhúng sẵn.

**Tôi có thể lấy nền cho một bố cục hoặc slide chủ cụ thể mà không cần gắn vào slide hiện có không?**

Có. Truy cập vào slide chủ hoặc bố cục mong muốn, áp dụng nó vào một [slide tạm thời](/slides/vi/androidjava/clone-slides/) với kích thước yêu cầu, sau đó xuất slide đó để nhận nền được tạo từ bố cục hoặc slide chủ đó.

**Có những hạn chế về giấy phép nào ảnh hưởng đến việc xuất hình ảnh không?**

Các tính năng render hoàn toàn khả dụng khi có [giấy phép hợp lệ](/slides/vi/androidjava/licensing/). Trong chế độ đánh giá, đầu ra có thể bị giới hạn như có watermark. Kích hoạt giấy phép một lần cho mỗi tiến trình trước khi thực hiện xuất hàng loạt.