---
title: Thêm Slides vào Bản Trình Bày trong Java
linktitle: Thêm Slide
type: docs
weight: 10
url: /vi/java/add-slide-to-presentation/
keywords:
- thêm slide
- tạo slide
- slide trống
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Dễ dàng thêm slide vào các bản trình bày PowerPoint và OpenDocument của bạn bằng Aspose.Slides cho Java—chèn slide liền mạch, hiệu quả trong vài giây."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các slide vào bản trình bày PowerPoint một cách lập trình. Một bản trình bày chứa các slide Master/Layout và các slide bình thường, và các slide bình thường được sắp xếp theo chỉ mục bắt đầu từ 0. Mỗi slide có một ID duy nhất, và các tệp bản trình bày không có slide không được hỗ trợ.

Bài viết này giải thích cách tạo một đối tượng `Presentation`, truy cập bộ sưu tập slide của nó, thêm một slide trống, làm việc với slide vừa thêm, và lưu bản trình bày đã cập nhật. Nó cũng đề cập tới các điểm liên quan như chèn slide vào vị trí cụ thể, sử dụng layout, và hiểu slide trống có trong một bản trình bày mới tạo.

## **Thêm một Slide vào Bản Trình Bày**

Trước khi nói về việc thêm slide vào các tệp bản trình bày, chúng ta hãy thảo luận một số thực tế về các slide. Mỗi tệp bản trình bày PowerPoint chứa slide **Master / Layout** và các slide **Normal** khác. Điều này có nghĩa là một tệp bản trình bày chứa ít nhất một hoặc nhiều slide. Cần lưu ý rằng các tệp bản trình bày không có slide không được Aspose.Slides for Java hỗ trợ. Mỗi slide có một Id duy nhất và tất cả các Normal Slide được sắp xếp theo thứ tự chỉ mục bắt đầu từ 0.

Aspose.Slides for Java cho phép các nhà phát triển thêm slide trống vào bản trình bày của họ. Để thêm một slide trống vào bản trình bày, hãy làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
- Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection) bằng cách đặt tham chiếu tới thuộc tính [Slides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getSlides--) (tập hợp các đối tượng Slide nội dung) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
- Thêm một slide trống vào bản trình bày ở cuối bộ sưu tập slide nội dung bằng cách gọi phương thức [**addEmptySlide**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) được cung cấp bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlideCollection).
- Thực hiện một số công việc với slide trống vừa được thêm.
- Cuối cùng, ghi tệp bản trình bày bằng đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).

```java
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày
Presentation pres = new Presentation();
try {
    // Khởi tạo lớp SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Thêm một slide trống vào bộ sưu tập Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Thực hiện một số công việc trên slide vừa được thêm

    // Lưu tệp PPTX vào Đĩa
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể chèn một slide mới vào vị trí cụ thể, không chỉ ở cuối không?**

Có. Thư viện hỗ trợ các bộ sưu tập slide và các thao tác [insert](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), vì vậy bạn có thể thêm một slide tại chỉ mục mong muốn thay vì chỉ ở cuối.

**Các chủ đề/phong cách có được giữ nguyên khi thêm slide dựa trên layout không?**

Có. Một layout kế thừa định dạng từ master của nó, và slide mới kế thừa từ layout đã chọn và master liên quan.

**Slide nào có trong một bản trình bày "trống" mới trước khi thêm slide?**

Một bản trình bày mới tạo đã chứa sẵn một slide trống với chỉ mục zero. Điều này quan trọng khi tính toán các chỉ mục chèn.

**Làm thế nào để chọn layout "đúng" cho một slide mới nếu master có nhiều tùy chọn?**

Thông thường chọn [LayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/layoutslide/) phù hợp với cấu trúc yêu cầu ([Title and Content, Two Content, v.v.](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidelayouttype/)). Nếu layout như vậy thiếu, bạn có thể [thêm nó vào master](/slides/vi/java/slide-layout/) và sau đó sử dụng nó.