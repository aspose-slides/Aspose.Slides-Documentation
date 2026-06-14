---
title: Lấy toàn bộ nền slide của bản trình chiếu dưới dạng hình ảnh
linktitle: Toàn bộ nền slide
type: docs
weight: 95
url: /vi/cpp/get-the-entire-presentation-slide-background-as-an-image/
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
- C++
- Aspose.Slides
description: "Trích xuất toàn bộ nền slide dưới dạng hình ảnh từ các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho C++, giúp đơn giản hoá quy trình làm việc trực quan."
---
## **Tổng quan**

Trong các bản trình chiếu PowerPoint, nền của một slide có thể được tạo thành từ nhiều yếu tố, bao gồm hình nền slide, chủ đề bản trình chiếu, bảng màu, và các đối tượng được đặt trên slide chủ hoặc slide bố cục.

Bài viết này hướng dẫn cách trích xuất toàn bộ nền slide dưới dạng hình ảnh bằng Aspose.Slides. Vì không có một phương pháp duy nhất cho nhiệm vụ này, cách tiếp cận là sao chép slide đã chọn vào một bản trình chiếu tạm thời, xóa các hình dạng trên slide, và sau đó chuyển nền slide kết quả thành hình ảnh.

## **Lấy nền toàn bộ slide**

Aspose.Slides for C++ không cung cấp phương pháp đơn giản để trích xuất toàn bộ nền slide của bản trình chiếu dưới dạng hình ảnh, nhưng bạn có thể làm theo các bước sau:
1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) class.
2. Lấy kích thước slide từ bản trình chiếu.
3. Chọn một slide.
4. Tạo một bản trình chiếu tạm thời.
5. Đặt cùng kích thước slide trong bản trình chiếu tạm thời.
6. Sao chép slide đã chọn vào bản trình chiếu tạm thời.
7. Xóa các hình dạng khỏi slide đã sao chép.
8. Chuyển slide đã sao chép thành hình ảnh.

The following code example extracts the entire presentation slide background as an image.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Các gradient phức tạp, kết cấu hoặc nền ảnh từ slide chủ có được giữ nguyên trong hình nền kết quả không?**

Đúng. Aspose.Slides sẽ render các gradient, ảnh và kết cấu được định nghĩa trên slide, bố cục hoặc slide chủ. Nếu bạn cần tách biệt giao diện khỏi các slide chủ được kế thừa, [đặt nền riêng](/slides/vi/cpp/presentation-background/) trên slide hiện tại trước khi xuất.

**Tôi có thể thêm watermark vào hình nền kết quả trước khi lưu không?**

Đúng. Bạn có thể [thêm watermark](/slides/vi/cpp/watermark/) dưới dạng hình dạng hoặc hình ảnh trên một [bản sao của slide](/slides/vi/cpp/clone-slides/) đang làm việc (đặt phía sau nội dung khác) và sau đó xuất. Điều này cho phép bạn tạo ra hình nền có watermark đã được nhúng.

**Tôi có thể lấy nền cho một bố cục hoặc slide chủ cụ thể mà không cần gắn vào slide hiện có không?**

Đúng. Truy cập slide chủ hoặc bố cục mong muốn, áp dụng nó vào một [slide tạm thời](/slides/vi/cpp/clone-slides/) với kích thước yêu cầu, và xuất slide đó để lấy nền được tạo ra từ bố cục hoặc slide chủ đó.

**Có những hạn chế về giấy phép nào ảnh hưởng đến việc xuất hình ảnh không?**

Các tính năng render hoàn toàn khả dụng khi có một [giấy phép hợp lệ](/slides/vi/cpp/licensing/). Trong chế độ đánh giá, kết quả có thể bao gồm các hạn chế như watermark. Kích hoạt giấy phép một lần cho mỗi tiến trình trước khi thực hiện xuất hàng loạt.