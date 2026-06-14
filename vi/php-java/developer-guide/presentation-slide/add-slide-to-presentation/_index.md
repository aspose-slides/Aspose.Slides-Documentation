---
title: Thêm Slides vào Presentations trong PHP
linktitle: Thêm Slide
type: docs
weight: 10
url: /vi/php-java/add-slide-to-presentation/
keywords:
- thêm slide
- tạo slide
- slide trống
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Dễ dàng thêm slides vào các bản PowerPoint và OpenDocument của bạn bằng Aspose.Slides for PHP via Java — chèn slide mượt mà, hiệu quả trong vài giây."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm slide vào các bản trình bày PowerPoint một cách lập trình. Một bản trình bày chứa các slide Master/Layout và các slide Normal, và các slide Normal được sắp xếp theo chỉ mục bắt đầu từ 0. Mỗi slide có một ID duy nhất, và các tệp bản trình bày không có slide không được hỗ trợ.

Bài viết này giải thích cách tạo đối tượng `Presentation`, truy cập bộ sưu tập slide của nó, thêm một slide trống, làm việc với slide mới được thêm và lưu bản trình bày đã cập nhật. Nó cũng đề cập đến các điểm liên quan như chèn slide vào vị trí cụ thể, sử dụng layout, và hiểu slide trống tồn tại trong một bản trình bày mới tạo.

## **Thêm slide vào bản trình bày**

Trước khi nói về việc thêm slide vào các tệp bản trình bày, chúng ta hãy thảo luận một số thực tế về các slide. Mỗi tệp bản trình bày PowerPoint chứa **slide Master / Layout** và các slide **Normal** khác. Điều này có nghĩa là một tệp bản trình bày chứa ít nhất một slide. Điều quan trọng là phải biết rằng các tệp bản trình bày không có slide không được Aspose.Slides for PHP via Java hỗ trợ. Mỗi slide có một Id duy nhất và tất cả các Slide Normal được sắp xếp theo thứ tự được chỉ định bằng chỉ mục bắt đầu từ 0.

Aspose.Slides for PHP via Java cho phép các nhà phát triển thêm slide trống vào bản trình bày của họ. Để thêm một slide trống vào bản trình bày, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
- Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/) bằng cách sử dụng phương thức [getSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation#getSlides--) (tập hợp các đối tượng Slide nội dung) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
- Thêm một slide trống vào bản trình bày ở cuối tập hợp các slide nội dung bằng cách gọi phương thức [**addEmptySlide**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/#addEmptySlide) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/).
- Thực hiện một số công việc với slide trống vừa được thêm.
- Cuối cùng, ghi tệp bản trình bày bằng đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).

```php
  # Khởi tạo lớp Presentation đại diện cho tệp bản trình bày
  $pres = new Presentation();
  try {
    # Khởi tạo lớp SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Thêm một slide trống vào bộ sưu tập Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Thực hiện một số công việc trên slide vừa được thêm
    # Lưu tệp PPTX vào Đĩa
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể chèn một slide mới vào vị trí cụ thể, không chỉ ở cuối không?**

Có. Thư viện hỗ trợ các bộ sưu tập slide và các thao tác [insert](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/insertclone/) nên bạn có thể thêm slide tại chỉ mục yêu cầu thay vì chỉ ở cuối.

**Các chủ đề/kiểu dáng có được giữ nguyên khi thêm slide dựa trên layout không?**

Có. Một layout kế thừa định dạng từ master của nó, và slide mới kế thừa từ layout đã chọn và master liên quan.

**Slide nào có trong một bản trình bày "trống" mới tạo trước khi thêm slide?**

Một bản trình bày mới tạo đã chứa sẵn một slide trống với chỉ mục zero. Điều này quan trọng khi tính toán chỉ mục chèn.

**Làm sao để chọn "layout" phù hợp cho slide mới nếu master có nhiều lựa chọn?**

Thông thường chọn [LayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/) phù hợp với cấu trúc yêu cầu ([Title and Content, Two Content, v.v.](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidelayouttype/)). Nếu thiếu layout như vậy, bạn có thể [add it to the master](/slides/vi/php-java/slide-layout/) và sau đó sử dụng.