---
title: Thêm Slides vào Bản Trình Bày trong JavaScript
linktitle: Thêm Slide
type: docs
weight: 10
url: /vi/nodejs-java/add-slide-to-presentation/
keywords:
- thêm slide
- tạo slide
- slide trống
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Dễ dàng thêm các slide vào bản trình bày PowerPoint và OpenDocument của bạn bằng Aspose.Slides cho Node.js qua Java — chèn slide liền mạch, hiệu quả trong vài giây."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các slide vào bản trình bày PowerPoint một cách lập trình. Một bản trình bày chứa các slide Master/Layout và các slide bình thường, và các slide bình thường được sắp xếp theo chỉ mục bắt đầu từ 0. Mỗi slide có một ID duy nhất, và các tệp bản trình bày không có slide không được hỗ trợ.

Bài viết này giải thích cách tạo đối tượng `Presentation`, truy cập bộ sưu tập slide của nó, thêm một slide trống, làm việc với slide mới được thêm và lưu bản trình bày đã cập nhật. Ngoài ra còn đề cập đến các điểm liên quan như chèn slide vào vị trí cụ thể, sử dụng layout và hiểu slide trống có trong một bản trình bày mới tạo.

## **Thêm Slide vào Bản Trình Bày**

Trước khi nói về việc thêm slide vào các tệp bản trình bày, hãy thảo luận một vài thực tế về slide. Mỗi tệp bản trình bày PowerPoint chứa slide **Master / Layout** và các slide **Bình thường** khác. Có nghĩa là một tệp bản trình bày chứa ít nhất một hoặc nhiều slide. Điều quan trọng là phải biết rằng các tệp bản trình bày không có slide không được Aspose.Slides for Node.js via Java hỗ trợ. Mỗi slide có một Id duy nhất và tất cả các Slide Bình thường được sắp xếp theo thứ tự được chỉ định bằng chỉ mục bắt đầu từ 0.

Aspose.Slides for Node.js via Java cho phép các nhà phát triển thêm slide trống vào bản trình bày của họ. Để thêm một slide trống vào bản trình bày, hãy làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
- Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection) bằng cách đặt tham chiếu đến thuộc tính [Slides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) (tập hợp các đối tượng Slide nội dung) được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
- Thêm một slide trống vào bản trình bày ở cuối tập hợp các slide nội dung bằng cách gọi phương thức [**addEmptySlide**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) được công bố bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection).
- Thực hiện một số công việc với slide trống mới được thêm.
- Cuối cùng, ghi tệp bản trình bày bằng đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày
var pres = new aspose.slides.Presentation();
try {
    // Khởi tạo lớp SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Thêm một slide trống vào bộ sưu tập Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Thực hiện một số công việc trên slide mới được thêm
    // Lưu tệp PPTX vào Đĩa
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể chèn một slide mới vào vị trí cụ thể, không chỉ ở cuối không?**

Có. Thư viện hỗ trợ các bộ sưu tập slide và các thao tác [insert](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/insertclone/) nên bạn có thể thêm một slide vào chỉ mục cần thiết thay vì chỉ ở cuối.

**Các chủ đề/kiểu dáng có được giữ nguyên khi thêm slide dựa trên một layout không?**

Có. Một layout kế thừa định dạng từ master của nó, và slide mới kế thừa từ layout đã chọn và master liên quan.

**Slide nào có trong một bản trình bày "trống" mới trước khi thêm slide?**

Một bản trình bày mới tạo đã chứa sẵn một slide trống với chỉ mục zero. Điều này quan trọng khi tính toán chỉ mục chèn.

**Làm thế nào để chọn layout "đúng" cho một slide mới nếu master có nhiều tùy chọn?**

Thông thường chọn [LayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/) phù hợp với cấu trúc yêu cầu ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidelayouttype/)). Nếu không có layout như vậy, bạn có thể [add it to the master](/slides/vi/nodejs-java/slide-layout/) và sau đó sử dụng nó.