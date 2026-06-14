---
title: Lấy toàn bộ nền slide từ bản trình bày dưới dạng hình ảnh
linktitle: Toàn bộ nền slide
type: docs
weight: 95
url: /vi/php-java/get-the-entire-presentation-slide-background-as-an-image/
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
  - PHP
  - Aspose.Slides
description: "Trích xuất toàn bộ nền slide dưới dạng hình ảnh từ các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java, giúp đơn giản hoá quy trình làm việc trực quan."
---
## **Tổng quan**

Trong các bản trình bày PowerPoint, nền của một slide có thể được tạo thành từ nhiều yếu tố, bao gồm hình nền slide, giao diện bản trình bày, bảng màu và các đối tượng được đặt trên slide master hoặc slide bố cục.

Bài viết này trình bày cách trích xuất toàn bộ nền slide dưới dạng hình ảnh bằng Aspose.Slides. Vì không có một phương thức duy nhất cho nhiệm vụ này, cách tiếp cận bao gồm sao chép slide đã chọn vào một bản trình bày tạm thời, xóa các hình dạng trên slide, và sau đó chuyển nền slide đã tạo ra thành hình ảnh.

## **Lấy toàn bộ nền slide**

Aspose.Slides cho PHP thông qua Java không cung cấp phương thức đơn giản để trích xuất toàn bộ nền slide của bản trình bày dưới dạng hình ảnh, nhưng bạn có thể thực hiện theo các bước dưới đây để làm điều này:
1. Tải bản trình bày bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy kích thước slide từ bản trình bày.
1. Chọn một slide.
1. Tạo một bản trình bày tạm thời.
1. Đặt cùng kích thước slide trong bản trình bày tạm thời.
1. Sao chép slide đã chọn vào bản trình bày tạm thời.
1. Xóa các hình dạng khỏi slide đã sao chép.
1. Chuyển đổi slide đã sao chép thành hình ảnh.

Ví dụ mã sau trích xuất toàn bộ nền slide của bản trình bày dưới dạng hình ảnh.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **Câu hỏi thường gặp**

**Liệu các gradient phức tạp, kết cấu hoặc tô ảnh từ slide master có được giữ nguyên trong hình nền kết quả không?**

Có. Aspose.Slides render các gradient, ảnh và kết cấu được định nghĩa trên slide, bố cục hoặc master. Nếu bạn cần tách biệt giao diện khỏi các master được kế thừa, [đặt nền riêng](/slides/vi/php-java/presentation-background/) cho slide hiện tại trước khi xuất.

**Tôi có thể thêm watermark vào hình nền kết quả trước khi lưu không?**

Có. Bạn có thể [thêm watermark](/slides/vi/php-java/watermark/) dạng hình hoặc hình ảnh trên một [bản sao của slide](/slides/vi/php-java/clone-slides/) đang làm việc (đặt phía sau nội dung khác) và sau đó xuất. Điều này cho phép bạn tạo ra hình nền có watermark đã được nhúng.

**Tôi có thể lấy nền cho một bố cục hoặc master cụ thể mà không cần gắn vào slide hiện có không?**

Có. Truy cập master hoặc bố cục mong muốn, áp dụng nó vào một [slide tạm thời](/slides/vi/php-java/clone-slides/) với kích thước cần thiết, và xuất slide đó để lấy nền được tạo từ bố cục hoặc master đó.

**Có những hạn chế về giấy phép nào ảnh hưởng đến việc xuất hình ảnh không?**

Các tính năng render hoàn toàn khả dụng với một [giấy phép hợp lệ](/slides/vi/php-java/licensing/). Trong chế độ đánh giá, đầu ra có thể có các hạn chế như watermark. Kích hoạt giấy phép một lần cho mỗi quy trình trước khi thực hiện xuất hàng loạt.