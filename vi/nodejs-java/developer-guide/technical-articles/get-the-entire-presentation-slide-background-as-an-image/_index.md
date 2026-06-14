---
title: Lấy toàn bộ nền slide từ một bài thuyết trình dưới dạng hình ảnh
linktitle: Toàn bộ nền slide
type: docs
weight: 95
url: /vi/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
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
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Trích xuất toàn bộ nền slide dưới dạng hình ảnh từ các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js via Java, giúp đơn giản hoá quy trình làm việc trực quan."
---
## **Tổng quan**

Trong các bài thuyết trình PowerPoint, nền của một slide có thể được tạo thành từ nhiều yếu tố, bao gồm hình nền slide, chủ đề bài thuyết trình, bảng màu và các đối tượng được đặt trên slide master hoặc slide bố cục.

Bài viết này cho thấy cách trích xuất toàn bộ nền slide dưới dạng hình ảnh bằng Aspose.Slides. Vì không có phương thức duy nhất cho nhiệm vụ này, phương pháp được thực hiện bằng cách sao chép slide đã chọn vào một bài thuyết trình tạm thời, xóa các hình dạng trên slide sao chép, sau đó chuyển nền slide còn lại thành hình ảnh.

## **Lấy toàn bộ nền slide**

Aspose.Slides for Node.js via Java không cung cấp phương thức đơn giản để trích xuất toàn bộ nền slide của bài thuyết trình dưới dạng hình ảnh, nhưng bạn có thể thực hiện các bước sau:
1. Tải bài thuyết trình bằng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy kích thước slide từ bài thuyết trình.
3. Chọn một slide.
4. Tạo một bài thuyết trình tạm thời.
5. Đặt cùng kích thước slide cho bài thuyết trình tạm thời.
6. Sao chép slide đã chọn vào bài thuyết trình tạm thời.
7. Xóa các hình dạng khỏi slide đã sao chép.
8. Chuyển slide đã sao chép thành hình ảnh.

Đoạn mã dưới đây trích xuất toàn bộ nền slide của bài thuyết trình dưới dạng hình ảnh.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **Câu hỏi thường gặp**

**Liệu các gradient phức tạp, kết cấu hoặc các hình ảnh nền từ slide master có được giữ nguyên trong hình nền kết quả không?**

Có. Aspose.Slides sẽ render các gradient, hình ảnh và kết cấu được định nghĩa trên slide, bố cục hoặc master. Nếu bạn muốn tách biệt giao diện khỏi các master được kế thừa, hãy [set an own background](/slides/vi/nodejs-java/presentation-background/) cho slide hiện tại trước khi xuất.

**Tôi có thể thêm dấu watermark vào hình nền kết quả trước khi lưu không?**

Có. Bạn có thể [add a watermark](/slides/vi/nodejs-java/watermark/) dưới dạng hình dạng hoặc hình ảnh trên một [copy of the slide](/slides/vi/nodejs-java/clone-slides/) (đặt phía sau nội dung khác) rồi xuất. Điều này cho phép bạn tạo ra một hình nền có watermark được nhúng sẵn.

**Tôi có thể lấy nền cho một bố cục hoặc master cụ thể mà không cần gắn vào một slide hiện có không?**

Có. Truy cập master hoặc bố cục mong muốn, áp dụng nó vào một [temporary slide](/slides/vi/nodejs-java/clone-slides/) với kích thước yêu cầu, rồi xuất slide đó để nhận nền được tạo ra từ bố cục hoặc master đó.

**Có hạn chế giấy phép nào ảnh hưởng đến việc xuất hình ảnh không?**

Các tính năng render đều khả dụng với một [valid license](/slides/vi/nodejs-java/licensing/). Ở chế độ đánh giá, đầu ra có thể bao gồm các hạn chế như watermark. Kích hoạt giấy phép một lần cho mỗi quá trình trước khi thực hiện xuất hàng loạt.