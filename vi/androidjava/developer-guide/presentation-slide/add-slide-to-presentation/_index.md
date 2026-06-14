---
title: Thêm slide vào bản trình bày trên Android
linktitle: Thêm slide
type: docs
weight: 10
url: /vi/androidjava/add-slide-to-presentation/
keywords:
- thêm slide
- tạo slide
- slide trống
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Dễ dàng thêm slide vào các bản trình bày PowerPoint và OpenDocument của bạn bằng Aspose.Slides cho Android qua Java - việc chèn slide liền mạch, hiệu quả trong vài giây."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các slide vào bản trình bày PowerPoint một cách lập trình. Một bản trình bày chứa các slide Master/Layout và các slide bình thường, và các slide bình thường được sắp xếp theo chỉ số bắt đầu từ 0. Mỗi slide có một ID duy nhất, và các tệp bản trình bày không có slide không được hỗ trợ.

Bài viết này giải thích cách tạo đối tượng `Presentation`, truy cập bộ sưu tập slide của nó, thêm một slide trống, làm việc với slide vừa thêm và lưu bản trình bày đã cập nhật. Nó cũng đề cập đến các điểm liên quan như chèn slide vào vị trí cụ thể, sử dụng layout và hiểu slide trống có trong một bản trình bày mới tạo.

## **Thêm slide vào bản trình bày**

Trước khi nói về việc thêm slide vào các tệp bản trình bày, hãy thảo luận một số thực tế về slide. Mỗi tệp bản trình bày PowerPoint chứa slide **Master / Layout** và các slide **Normal** khác. Điều này có nghĩa là một tệp bản trình bày chứa ít nhất một hoặc nhiều slide. Cần lưu ý rằng các tệp bản trình bày không có slide không được Aspose.Slides for Android via Java hỗ trợ. Mỗi slide có một Id duy nhất và tất cả các Normal Slide được sắp xếp theo thứ tự được xác định bởi chỉ số bắt đầu từ 0.

Aspose.Slides for Android via Java cho phép các nhà phát triển thêm slide trống vào bản trình bày của họ. Để thêm một slide trống vào bản trình bày, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
- Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection) bằng cách thiết lập tham chiếu tới thuộc tính [Slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getSlides--) (tập hợp các đối tượng Slide nội dung) được công khai bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
- Thêm một slide trống vào bản trình bày ở cuối tập hợp các slide nội dung bằng cách gọi phương thức [**addEmptySlide**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) được công khai bởi đối tượng [ISlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlideCollection).
- Thực hiện một số công việc với slide trống vừa được thêm.
- Cuối cùng, ghi tệp bản trình bày bằng cách sử dụng đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).

```java
// Tạo đối tượng Presentation đại diện cho tệp bản trình bày
Presentation pres = new Presentation();
try {
    // Khởi tạo lớp SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Thêm một slide trống vào bộ sưu tập Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Thực hiện một số công việc trên slide vừa được thêm

    // Lưu tệp PPTX vào đĩa
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể chèn slide mới vào vị trí cụ thể, không chỉ ở cuối không?**

Có. Thư viện hỗ trợ các tập hợp slide và các thao tác [insert](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) , vì vậy bạn có thể thêm slide ở chỉ mục yêu cầu thay vì chỉ ở cuối.

**Các giao diện/kiểu dáng có được giữ nguyên khi thêm slide dựa trên layout không?**

Có. Layout kế thừa định dạng từ master của nó, và slide mới kế thừa từ layout đã chọn và master liên quan.

**Slide nào có trong bản trình bày "trống" mới tạo trước khi thêm các slide?**

Một bản trình bày mới tạo đã chứa sẵn một slide trống với chỉ mục 0. Điều này quan trọng khi tính toán chỉ số chèn.

**Làm thế nào để chọn layout "phù hợp" cho slide mới nếu master có nhiều tùy chọn?**

Thông thường chọn [LayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/layoutslide/) phù hợp với cấu trúc yêu cầu ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidelayouttype/)). Nếu thiếu layout như vậy, bạn có thể [add it to the master](/slides/vi/androidjava/slide-layout/) và sau đó sử dụng nó.